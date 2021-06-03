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

                // Test
                var target = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                target.Name = "target";
                string newTargetStr = "";
                foreach (var st in e.influenceStock)
                {
                    newTargetStr += (st.StockName + ", ");
                }
                target.Text = newTargetStr;

                var ratio = item.SubItems.Add(new ListViewItem.ListViewSubItem());
                ratio.Name = "ratio";
                string newRatioStr = "";
                foreach(var isP in e.IsPositiveEvent)
                {
                    newRatioStr += isP.ToString() + ", ";
                }
                ratio.Text = newRatioStr;
                // --------------------
            }
        }

        public void SetInfoListView(List<Event> events)
        {
            if (events == null) return;

            infoListView.Items.Clear();
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
            middle1.Name = "middle";
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
            middle2.Name = "middle";
            middle2.Text = middle;

            // 고급 정보 Text 제작
            string advance = "-상승주- ";
            foreach (Stock stock in stocks)
            {
                if (stock.NextStockRatio > 0)
                {
                    if (!advance.Contains(stock.StockName))
                    {
                        advance += stock.StockName + " : " + stock.NextStockRatio + "%\n";
                    }
                }
            }
            var adv1 = middle1.SubItems.Add(new ListViewItem.ListViewSubItem());
            adv1.Name = "advance";
            adv1.Text = advance;

            advance = "-하향주- ";
            foreach (Stock stock in stocks)
            {
                if (stock.NextStockRatio < 0)
                {
                    if (!advance.Contains(stock.StockName))
                    {
                        advance += stock.StockName + " : " + stock.NextStockRatio + "%\n";
                    }
                }
            }
            var adv2 = middle2.SubItems.Add(new ListViewItem.ListViewSubItem());
            adv2.Name = "advance";
            adv2.Text = advance;

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
            eventListView.Columns[eventListView.Columns.Count - 1].Width = -1;

            infoListView.Columns.Add("middle", "중급정보");
            infoListView.Columns.Add("advance", "고급정보");

            // Test
            eventListView.Columns.Add("target", "Stock");
            eventListView.Columns.Add("ratio", "등락률");
            // --------------------
        }
    }
}
