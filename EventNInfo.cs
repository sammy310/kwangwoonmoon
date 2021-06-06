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
    public partial class EventNInfo : Form
    {
        public enum EventListColumnType
        {
            Title = 0,
        }


        public EventNInfo()
        {
            InitializeComponent();
        }

        public void SetEventListView(List<Event> events)
        {
            if (events == null) return;

            eventListView.Items.Clear();
            foreach (Event e in events)
            {
                ListViewItem item = eventListView.Items.Add(new ListViewItem());
                item.Name = EventListColumnType.Title.ToString();
                item.Text = e.Title;
            }
        }

        public void SetMiddleInfoListView(List<Event> events)
        {
            if (events == null) return;

            List<Stock> stocks = new List<Stock>();
            // 현재 Event 들에게 영향 받는 Stock 들의 List
            foreach(Event e in events)
            {
                for(int i = 0; i < e.InfluenceStockSize; i++)
                {
                    stocks.Add(e.influenceStock[i]);
                }
            }
            // 중급 정보 Text 제작
            string middle = "상향주 : ";
            foreach (Stock stock in stocks)
            {
                if (stock.NextStockRatio > 0)
                {
                    if (!middle.Contains(stock.StockName))
                    {
                        middle += stock.StockName + " ";
                    }
                }
            }
            ListViewItem middle1 = infoListView.Items.Add(new ListViewItem());
            middle1.Name = "info";
            middle1.Text = middle;

            middle = "하향주 : ";
            foreach (Stock stock in stocks)
            {
                if (stock.NextStockRatio < 0)
                {
                    if (!middle.Contains(stock.StockName))
                    {
                        middle += stock.StockName + " ";
                    }
                }
            }
            ListViewItem middle2 = infoListView.Items.Add(new ListViewItem());
            middle2.Name = "info";
            middle2.Text = middle;
        }

        public void SetAdvanceInfoListView(List<Event> events)
        {
            if (events == null) return;

            List<Stock> stocks = new List<Stock>();
            // 현재 Event 들에게 영향 받는 Stock 들의 List
            foreach (Event e in events)
            {
                for (int i = 0; i < e.InfluenceStockSize; i++)
                {
                    stocks.Add(e.influenceStock[i]);
                }
            }
            // 고급 정보 Text 제작
            string advance = "-상승주- ";
            foreach (Stock stock in stocks)
            {
                if (stock.NextStockRatio > 0)
                {
                    if (!advance.Contains(stock.StockName))
                    {
                        advance += string.Format("{0} : {1:N2}%, ", stock.StockName, stock.NextStockRatio);
                    }
                }
            }
            ListViewItem adv1 = infoListView.Items.Add(new ListViewItem());
            adv1.Name = "info";
            adv1.Text = advance;

            advance = "-하향주- ";
            foreach (Stock stock in stocks)
            {
                if (stock.NextStockRatio < 0)
                {
                    if (!advance.Contains(stock.StockName))
                    {
                        advance += string.Format("{0} : {1:N2}%, ", stock.StockName, stock.NextStockRatio);
                    }
                }
            }
            ListViewItem adv2 = infoListView.Items.Add(new ListViewItem());
            adv2.Name = "info";
            adv2.Text = advance;
        }

        public void SetInfoListViewClear()
        {
            infoListView.Items.Clear();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Hide();
        }


        private void EventNInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void EventNInfo_Load(object sender, EventArgs e)
        {
            eventListView.View = View.Details;
            infoListView.View = View.Details;

            eventListView.Columns.Add(EventListColumnType.Title.ToString(), "제목");
            eventListView.Columns[eventListView.Columns.Count - 1].Width = -2;

            infoListView.Columns.Add("info", "구매한 정보");
            infoListView.Columns[infoListView.Columns.Count - 1].Width = -2;
        }
    }
}
