using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kwangwoonmoon
{
    public partial class InfoShop : Form
    {
        public delegate void FormSendDataHandler(string obj);
        public event FormSendDataHandler FormSendEvent;
        // 정보 가격
        public const int MIDDLE = 5000;
        public const int ADVANCE = 12000;

        // 정보 구매 가능 횟수
        public int Count { get; private set; }

        // 다음 턴 이벤트에 영향 받는 주식 리스트
        List<Stock> InfluncedStocks = new List<Stock>();


        public InfoShop()
        {
            InitializeComponent();

            KWM.Instance.MoneyChanged += UpdateMoneyText;
        }

        // 다음 턴의 이벤트 정보 가져오기
        public void SetInfoAns(List<Event> events)
        {
            MiddleInfo_button.Enabled = true;
            AdvanceInfo_button.Enabled = true;
            if (events == null) return;
            if(InfluncedStocks.Count != 0) InfluncedStocks.RemoveRange(0, InfluncedStocks.Count - 1);
            foreach (Event e in events)
            {
                for(int i = 0; i < e.influenceStock.Count; i++)
                {
                    InfluncedStocks.Add(e.influenceStock[i]);
                }
            }
        }

        private void InfoShop_Load(object sender, EventArgs e)
        {
            UpdateMoneyText();

            this.AdvanceInfo_button.Text = string.Format("{0:#,###}", ADVANCE);
            this.MiddleInfo_button.Text = string.Format("{0:#,###}", MIDDLE);
        }

        public void SetEventNews(Event e)
        {
            this.News_label.Text = e.Title;
        }

        void UpdateMoneyText()
        {
            Mymoney_label.Text = string.Format("{0:#,###}", KWM.Instance.CurrentMoney);
        }

        public void SetBuyCount()
        {
            this.Count = 2;
        }


        // Button Events

        private void OK_button_Click(object sender, EventArgs e)
        {
            Hide();
        }
        
        private void MiddleInfo_button_Click(object sender, EventArgs e)
        {
            if (InfluncedStocks == null) return;
            if (this.Count > 0)
            {
                if (KWM.Instance.UseMoney(MIDDLE))
                {
                    //  정보 제공해주는 창 구현 필요
                    string stocks = "상승주 : ";
                    foreach(Stock stock in InfluncedStocks)
                    {
                        if (stock.NextStockRatio > 0)
                        {
                            if (!stocks.Contains(stock.StockName))
                            {
                                stocks += stock.StockName + " ";
                            }
                        }
                    }
                    stocks += "\n하향주 : ";
                    foreach(Stock stock in InfluncedStocks)
                    {
                        if(stock.NextStockRatio < 0)
                        {
                            if (!stocks.Contains(stock.StockName))
                            {
                                stocks += stock.StockName + " ";
                            }
                        }
                    }

                    MessageBox.Show(stocks, "중급 정보");
                    this.Count--;
                    MiddleInfo_button.Enabled = false;
                    this.FormSendEvent("middle");
                }
                else MessageBox.Show("보유 금액이 부족합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("구매 횟수를 모두 사용했습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AdvanceInfo_button_Click(object sender, EventArgs e)
        {
            if (this.Count > 0)
            {
                if (KWM.Instance.UseMoney(ADVANCE))
                {
                    // 정보 제공해주는 창 구현 필요
                    string stocks = "-상승주-\n";
                    foreach (Stock stock in InfluncedStocks)
                    {
                        if (stock.NextStockRatio > 0)
                        {
                            if (!stocks.Contains(stock.StockName))
                            {
                                stocks += stock.StockName + " : " + stock.NextStockRatio + "%\n";
                            }
                        }
                    }
                    stocks += "\n-하향주-\n";
                    foreach (Stock stock in InfluncedStocks)
                    {
                        if (stock.NextStockRatio < 0)
                        {
                            if (!stocks.Contains(stock.StockName))
                            {
                                stocks += stock.StockName + " : " + stock.NextStockRatio + "%\n";
                            }
                        }
                    }

                    MessageBox.Show(stocks, "고급 정보");
                    this.Count--;
                    AdvanceInfo_button.Enabled = false;
                    this.FormSendEvent("advance");
                }
                else MessageBox.Show("보유 금액이 부족합니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("구매 횟수를 모두 사용했습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InfoShop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }
    }
}
