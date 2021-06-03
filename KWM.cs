using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace kwangwoonmoon
{
    public partial class KWM : Form
    {
        public static KWM Instance = null;
        public static Random random = new Random();

        public Action MoneyChanged;

        public int Turn { get; private set; } = 0;
        // 게임이 종료되는 마지막 턴
        public const int LASTTURN = 50;

        List<Stock> stocks = new List<Stock>();
        List<TransactionInfo> transactionList = new List<TransactionInfo>();

        public static int DefaultEventSize = 3;
        public static int DefaultRandomEventSize = 2;
        List<Event> ReferenceEvents = new List<Event>();
        List<List<Event>> events = new List<List<Event>>();
        List<Event> CurrentEvents
        {
            get
            {
                if (Turn > 0 && Turn <= events.Count)
                    return events[Turn - 1];
                else
                    return null;
            }
        }

        EventNInfo eventNInfo = null;

        InfoShop infoShop = null;

        public long CurrentMoney { get; private set; } = 123456;


        ListViewItem selectedItem = null;
        bool isSell = false;


        public KWM()
        {
            InitializeComponent();

            if (Instance == null)
            {
                Instance = this;
            }

            MoneyChanged += UpdateMoneyText;
        }

        void InitStockList()
        {
            // 종목 리스트
            /*
            Stock stock = new Stock("셈스", 10000);
            Stock stock2 = new Stock("먀벤다", 12500);
            stocks.Add(stock);
            stocks.Add(stock2);*/
            stocks.Add(new Stock("셈스", 12500));
            stocks.Add(new Stock("셈스", 10000));
            stocks.Add(new Stock("크라니아", 13000));
            stocks.Add(new Stock("이크로스", 20000));
            stocks.Add(new Stock("파이논", 4550));
            stocks.Add(new Stock("자임", 1000));
            stocks.Add(new Stock("후차이", 8000));
            stocks.Add(new Stock("세을티", 7500));
            stocks.Add(new Stock("구아비", 1300));
            stocks.Add(new Stock("날루", 2000));
            stocks.Add(new Stock("도슬", 1350));
            stocks.Add(new Stock("렝칼", 3000));
            stocks.Add(new Stock("미에브", 4850));
            stocks.Add(new Stock("체카시티", 3200));
            stocks.Add(new Stock("타이푸", 5040));
            stocks.Add(new Stock("헴키리", 10020));
            stocks.Add(new Stock("락카루", 12000));
            stocks.Add(new Stock("아메리", 18050));
            stocks.Add(new Stock("캐다나", 16300));
            stocks.Add(new Stock("차아나우", 7800));

            /*transactionList.Add(new TransactionInfo(stock, 19000, 15));*/
            // --------------------
        }

        void InitEventList()
        {
            XmlDocument eventXml = new XmlDocument();
            eventXml.Load(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("kwangwoonmoon.Event_List.xml"));
            XmlNode eventNodes = eventXml.SelectSingleNode("eventlist");
            foreach (XmlNode eventNode in eventNodes.SelectNodes("event"))
            {
                ReferenceEvents.Add(GetEventFromXml(eventNode));
            }
        }

        Event GetEventFromXml(XmlNode eventNode)
        {
            Event ev = new Event(eventNode.SelectSingleNode("title").InnerText);
            ev.InfluenceStockSize = int.Parse(eventNode.Attributes["size"].Value);

            foreach (string typeStr in eventNode.Attributes["type"].Value.Split(','))
            {
                ev.IsPositiveEvent.Add(typeStr == "up");
            }

            XmlNode affectNode = eventNode.SelectSingleNode("affectevent");
            if (affectNode != null)
            {
                foreach (XmlNode afNode in affectNode.SelectNodes("event"))
                {
                    ev.AddInfluenceEvent(GetEventFromXml(afNode));
                }
            }

            return ev;
        }

        void InitStockListView()
        {
            stock_listview.View = View.Details;

            stock_listview.Columns.Add(StockColumType.StockName.ToString(), "종목명", 200, HorizontalAlignment.Right, 0);
            stock_listview.Columns.Add(StockColumType.StockPrice.ToString(), "현재가", 100, HorizontalAlignment.Right, 0);
            stock_listview.Columns.Add(StockColumType.StockRatio.ToString(), "등락률", 100, HorizontalAlignment.Right, 0);
        }

        void InitTransactionListView()
        {
            mystock_listview.View = View.Details;

            mystock_listview.Columns.Add(TransactionListColumnType.StockName.ToString(), "종목명", 200, HorizontalAlignment.Right, 0);
            mystock_listview.Columns.Add(TransactionListColumnType.AverageBuyingPrice.ToString(), "매수평균가", 100, HorizontalAlignment.Right, 0);
            mystock_listview.Columns.Add(TransactionListColumnType.StockQuantity.ToString(), "보유 수량", 100, HorizontalAlignment.Right, 0);
            mystock_listview.Columns.Add(TransactionListColumnType.EvaluationAmount.ToString(), "평가금액", 100, HorizontalAlignment.Right, 0);
            mystock_listview.Columns.Add(TransactionListColumnType.ValuationProfitNLoss.ToString(), "평가손익", 100, HorizontalAlignment.Right, 0);
            mystock_listview.Columns.Add(TransactionListColumnType.ProfitRatio.ToString(), "수익률", 100, HorizontalAlignment.Right, 0);
        }


        private void KWM_Load(object sender, EventArgs e)
        {
            InitStockList();
            InitEventList();
            InitStockListView();
            InitTransactionListView();

            SetStockListView();

            NextTurn();

            // 라벨 Text 값 초기화
            this.finish_label.Text = "/ " + LASTTURN.ToString();
            MoneyChanged.Invoke();
        }


        // 다음 턴으로 넘어감
        void NextTurn()
        {
            // 이벤트 업데이트
            UpdateEvent();

            ++Turn;

            UpdateEventStockRatio();

            if (Turn >= LASTTURN + 1)
            {
                Ending();
                return;
            }

            SetEventToEventNInfo();
            SetTransactionListView();
            SetEventToInfoShop();

            UpdateStockInfoText();

            // 업데이트 된 Turn 을 label 에 적용
            if (Turn < 10) gameturn_label.Text = "0" + Turn.ToString();
            else if (Turn > 50) gameturn_label.Text = LASTTURN.ToString();
            else gameturn_label.Text = Turn.ToString();

            // Turn 이 변화함에 따라 Child Form 에도 영향
            infoShop?.SetBuyCount();
        }

        void Ending()
        {
            nextTurn_button.Text = "결과 보기";
            long totalMoney = CurrentMoney;
            foreach (TransactionInfo transinf in transactionList)
            {
                totalMoney += transinf.EvaluationAmount;
            }
            string endingText = "최종 보유 금액 : " + String.Format("{0:#,###}", totalMoney);
            MessageBox.Show(endingText);
        }

        // Event

        Event GetRandomEvent()
        {
            Event ev = new Event(ReferenceEvents[random.Next(0, ReferenceEvents.Count)]);
            for (int i = 0; i < ev.InfluenceStockSize;)
            {
                Stock stock = GetRandomStock();
                if (!ev.influenceStock.Contains(stock))
                {
                    ev.AddInfluenceStock(stock);
                    i++;
                }
            }
            ev.UpdateInfluenceEvent();

            return ev;
        }

        void UpdateEventStockRatio()
        {
            foreach (Event e in CurrentEvents)
            {
                e.StockUpdate(); // Stock 등락률 갱신
            }
        }

        /*
         * 이벤트 업데이트
         * 이벤트를 업데이트 하고, 업데이트 된 이벤트를 바탕으로 Stock을 갱신함
         */
        void UpdateEvent()
        {
            List<Event> newEvents = new List<Event>();

            if (CurrentEvents != null)
            {
                foreach (Event e in CurrentEvents)
                {
                    foreach (Event ie in e.influenceEvent)
                    {
                        newEvents.Add(ie);
                    }
                }
            }

            int targetEventSize = DefaultEventSize + random.Next(0, DefaultRandomEventSize + 1);

            // 이벤트 랜덤 생성
            for (int i = newEvents.Count; i < targetEventSize; ++i)
            {
                newEvents.Add(GetRandomEvent());
            }

            events.Add(newEvents);

            UpdateStock();
        }

        // EventNInfo 폼의 ListView에 이벤트 설정
        void SetEventToEventNInfo()
        {
            if (eventNInfo == null) return;

            eventNInfo.SetEventListView(CurrentEvents);
        }


        // Stock

        // Stock 등락률 갱신
        void UpdateStock()
        {
            foreach (Stock stock in stocks)
            {
                stock.UpdateStockRatio();


            }


        }

        public List<Stock> GetStocks()
        {
            return stocks;
        }

        public Stock GetRandomStock()
        {
            return stocks[random.Next(0, stocks.Count)];
        }



        //stock_listview 리스트 뷰 컬럼 정의
        void SetStockListView()
        {
            stock_listview.Items.Clear();
            foreach (Stock s in stocks)
            {
                ListViewItem item = stock_listview.Items.Add(new ListViewItem());
                item.Name = StockColumType.StockName.ToString();
                item.Text = s.StockName;

                var price = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                price.Name = StockColumType.StockPrice.ToString();
                price.Text = s.StockPrice.ToString("N0");

                var ratio = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                ratio.Name = StockColumType.StockRatio.ToString();
                ratio.Text = s.StockRatio.ToString("N2") + "%";

                item.Tag = s;
                s.ReferenceStock = item;
            }
        }

        void SetTransactionListView()
        {
            mystock_listview.Items.Clear();
            foreach (TransactionInfo info in transactionList)
            {
                ListViewItem item = mystock_listview.Items.Add(new ListViewItem());
                item.Name = TransactionListColumnType.StockName.ToString();
                item.Text = info.StockName;

                var avgPrice = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                avgPrice.Name = TransactionListColumnType.AverageBuyingPrice.ToString();
                avgPrice.Text = info.AverageBuyingPrice.ToString("N0");

                var quantity = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                quantity.Name = TransactionListColumnType.StockQuantity.ToString();
                quantity.Text = info.StockQuantity.ToString("N0");

                var evaluationAmount = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                evaluationAmount.Name = TransactionListColumnType.EvaluationAmount.ToString();
                evaluationAmount.Text = info.EvaluationAmount.ToString("N0");

                var valuationProfitNLoss = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                valuationProfitNLoss.Name = TransactionListColumnType.ValuationProfitNLoss.ToString();
                valuationProfitNLoss.Text = info.ValuationProfitNLoss.ToString("N0");

                var ratio = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                ratio.Name = TransactionListColumnType.ProfitRatio.ToString();
                ratio.Text = info.ProfitRatio.ToString("N2") + "%";

                info.ReferenceInfo = item;
                item.Tag = info;
            }
        }

        //inputbox 비우기
        private void ClearInputControl()
        {
            lb_Selected.Text = string.Empty;
            total_amount_textbox.Text = string.Empty;
            price_textbox.Text = string.Empty;
        }

        //mystock_listview 선택 함수
        private void mystock_listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mystock_listview.SelectedItems.Count == 0)
            {
                SetEnableButton(false);
            }
            else
            {
                SetButtonToSell();
                UpdateStockInfoText();
            }
        }





        // Shop

        // InfoShop 폼의 NewsLabel에 이벤트 설정
        void SetToInfoShop()
        {
            if (infoShop == null) return;

            infoShop.SetEventNews(CurrentEvents[CurrentEvents.Count - 1]);
            infoShop.SetBuyCount();
        }

        void SetEventToInfoShop()
        {
            if (infoShop == null) return;

            infoShop.SetInfoAns(CurrentEvents);
        }

        void UpdateMoneyText()
        {
            mymoney_label.Text = string.Format("{0:#,###}", CurrentMoney);
        }

        private void info_shop_button_Click(object sender, EventArgs e)
        {
            if (infoShop == null)
            {
                infoShop = new InfoShop();
                infoShop.Owner = this;
            }

            SetToInfoShop();

            infoShop.Show();
            infoShop.Focus();
        }


        // Money

        public bool UseMoney(long money)
        {
            if (CurrentMoney >= money)
            {
                CurrentMoney -= money;

                MoneyChanged.Invoke();

                return true;
            }
            return false;
        }

        public void AddMoney(long money)
        {
            CurrentMoney += money;

            MoneyChanged.Invoke();
        }


        // Button Events

        private void news_button_Click(object sender, EventArgs e)
        {
            if (eventNInfo == null)
            {
                eventNInfo = new EventNInfo();
                eventNInfo.Owner = this;

                SetEventToEventNInfo();
            }

            eventNInfo.Show();
            eventNInfo.Focus();
        }


        private void number_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void stock_listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stock_listview.SelectedItems.Count == 0)
            {
                SetEnableButton(false);
            }
            else
            {
                SetButtonToBuy();
                UpdateStockInfoText();
            }
        }

        void UpdateStockInfoText()
        {
            if (selectedItem == null || lb_Selected.Enabled == false)
            {
                SetEnableButton(false);
                return;
            }

            if (isSell)
            {
                TransactionInfo info = (TransactionInfo)selectedItem.Tag;
                lb_Selected.Text = info.StockName;
                price_textbox.Text = string.Format("{0:#,###}", info.CurrentStockPrice);
                total_amount_textbox.Text = info.StockQuantity.ToString();
            }
            else
            {
                Stock info = (Stock)selectedItem.Tag;
                lb_Selected.Text = info.StockName;
                price_textbox.Text = string.Format("{0:#,###}", info.StockPrice);
                if (CurrentMoney < info.StockPrice)
                {
                    SetTradeButtonDisable();
                }
                else
                {
                    total_amount_textbox.Text = "1";
                }
            }
        }

        private void plus_button_Click(object sender, EventArgs e)
        {
            if (total_amount_textbox.Text.Length == 0) total_amount_textbox.Text = "1";


            int amount = int.Parse(total_amount_textbox.Text) + 1;
            if (isSell)
            {
                int quantity = ((TransactionInfo)selectedItem.Tag).StockQuantity;
                if (quantity < amount)
                {
                    return;
                }
            }
            else
            {
                long stockPrice = ((Stock)selectedItem.Tag).StockPrice;
                long totalStockPrice = stockPrice * amount;
                if (totalStockPrice > CurrentMoney)
                {
                    return;
                }
            }

            total_amount_textbox.Text = (Convert.ToInt32(total_amount_textbox.Text) + 1).ToString();

            // 수량에 증가에 따른 총액 업데이트 필요
        }

        private void minus_button_Click(object sender, EventArgs e)
        {
            if (total_amount_textbox.Text.Length == 0) total_amount_textbox.Text = "1";

            if (Convert.ToInt32(total_amount_textbox.Text) <= 1) total_amount_textbox.Text = "1";
            else total_amount_textbox.Text = (Convert.ToInt32(total_amount_textbox.Text) - 1).ToString();
            // 수량에 감소에 따른 총액 업데이트 필요
        }

        private void nextTurn_button_Click(object sender, EventArgs e)
        {
            NextTurn();
        }

        private void trade_button_Click(object sender, EventArgs e)
        {
            string name;
            long currentPrice;
            int amount = int.Parse(total_amount_textbox.Text);

            if (isSell)
            {
                TransactionInfo info = (TransactionInfo)selectedItem.Tag;
                name = info.StockName;
                currentPrice = info.CurrentStockPrice;
            }
            else
            {
                Stock info = (Stock)selectedItem.Tag;
                name = info.StockName;
                currentPrice = info.StockPrice;
            }

            long totalPrice = currentPrice * amount;

            string message = string.Format("종목명:{0}\n\n현재가:{1:N0}원\n\n수량:{2}\n\n총액:{3:N0}원\n\n{4}주문 하시겠습니까?", name, currentPrice, amount, totalPrice, (isSell) ? "매도" : "매수");
            DialogResult result = MessageBox.Show(message, ((isSell) ? "매도" : "매수") + " 주문 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result != DialogResult.Yes) return;


            if (isSell)
            {
                AddMoney(totalPrice);

                TransactionInfo info = (TransactionInfo)selectedItem.Tag;
                if (info.DecreaseStockQuantity(amount) == false)
                {
                    transactionList.Remove(info);
                    SetEnableButton(false);
                }
            }
            else
            {
                UseMoney(totalPrice);

                Stock info = (Stock)selectedItem.Tag;
                TransactionInfo transactionInfo = null;
                foreach (var tran in transactionList)
                {
                    if (tran.targetStock == info)
                    {
                        transactionInfo = tran;
                        break;
                    }
                }

                if (transactionInfo == null)
                {
                    transactionInfo = new TransactionInfo(info, currentPrice, amount);
                    transactionList.Add(transactionInfo);
                }
                else
                {
                    transactionInfo.AddTransaction(currentPrice, amount);
                }
            }

            SetTransactionListView();
            UpdateStockInfoText();
        }

        void SetEnableButton(bool isEnabled)
        {
            selectedItem = null;

            lb_Selected.Enabled = isEnabled;
            price_textbox.Enabled = isEnabled;
            total_amount_textbox.Enabled = isEnabled;
            plus_button.Enabled = isEnabled;
            minus_button.Enabled = isEnabled;

            trade_button.Enabled = isEnabled;
            if (!isEnabled)
            {
                ClearInputControl();
                InitTradeButton();
            }
        }

        void InitTradeButton()
        {
            trade_button.Text = "매수/매도";
            trade_button.ForeColor = Color.Black;
            trade_button.BackColor = Color.Gainsboro;
        }

        void SetTradeButtonDisable()
        {
            InitTradeButton();
            trade_button.Enabled = false;

            total_amount_textbox.Text = string.Empty;
            total_amount_textbox.Enabled = false;

            plus_button.Enabled = false;
            minus_button.Enabled = false;
        }

        void SetButtonToBuy()
        {
            mystock_listview.SelectedItems.Clear();
            SetEnableButton(true);
            selectedItem = stock_listview.SelectedItems[0];
            isSell = false;

            trade_button.Text = "매수";
            trade_button.ForeColor = Color.White;
            trade_button.BackColor = Color.IndianRed;
        }

        void SetButtonToSell()
        {
            stock_listview.SelectedItems.Clear();
            SetEnableButton(true);
            selectedItem = mystock_listview.SelectedItems[0];
            isSell = true;

            trade_button.Text = "매도";
            trade_button.ForeColor = Color.White;
            trade_button.BackColor = Color.MediumBlue;
        }

        public void buttoninitialize()
        {
            //버튼 초기값
            trade_button.Text = "매수/매도";
            trade_button.BackColor = Color.Gainsboro;
        }

        private void total_amount_textbox_Leave(object sender, EventArgs e)
        {
            if (!total_amount_textbox.Enabled) return;

            int amount = int.Parse(total_amount_textbox.Text);

            if (amount < 1)
            {
                total_amount_textbox.Text = "1";
                return;
            }

            if (isSell)
            {
                int quantity = ((TransactionInfo)selectedItem.Tag).StockQuantity;
                if (quantity < amount)
                {
                    total_amount_textbox.Text = quantity.ToString();
                }
            }
            else
            {
                long stockPrice = ((Stock)selectedItem.Tag).StockPrice;
                long totalStockPrice = stockPrice * amount;
                if (totalStockPrice > CurrentMoney)
                {
                    total_amount_textbox.Text = (CurrentMoney / stockPrice).ToString();
                }
            }
        }
    }
}
