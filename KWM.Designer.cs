﻿
namespace kwangwoonmoon
{
    partial class KWM
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_Selected = new System.Windows.Forms.Label();
            this.lb_SelectedStock = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.info_shop_button = new System.Windows.Forms.Button();
            this.news_button = new System.Windows.Forms.Button();
            this.sell_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mystock_listview = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.mymoney_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buy_button = new System.Windows.Forms.Button();
            this.stock_listview = new System.Windows.Forms.ListView();
            this.labe1 = new System.Windows.Forms.Label();
            this.gameturn_label = new System.Windows.Forms.Label();
            this.finish_label = new System.Windows.Forms.Label();
            this.nowTurn_label = new System.Windows.Forms.Label();
            this.gametime_label = new System.Windows.Forms.Label();
            this.today_label = new System.Windows.Forms.Label();
            this.total_amount_textbox = new System.Windows.Forms.TextBox();
            this.price_textbox = new System.Windows.Forms.TextBox();
            this.plus_button = new System.Windows.Forms.Button();
            this.minus_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 15F);
            this.label8.Location = new System.Drawing.Point(1063, 592);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 25);
            this.label8.TabIndex = 51;
            this.label8.Text = "거래하시겠습니까?";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 15F);
            this.label10.Location = new System.Drawing.Point(1228, 540);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 25);
            this.label10.TabIndex = 50;
            this.label10.Text = "원 입니다.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 15F);
            this.label9.Location = new System.Drawing.Point(1349, 436);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 25);
            this.label9.TabIndex = 49;
            this.label9.Text = "이고,";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Selected
            // 
            this.lb_Selected.BackColor = System.Drawing.Color.White;
            this.lb_Selected.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.lb_Selected.Location = new System.Drawing.Point(1063, 423);
            this.lb_Selected.Name = "lb_Selected";
            this.lb_Selected.Size = new System.Drawing.Size(280, 51);
            this.lb_Selected.TabIndex = 48;
            this.lb_Selected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_SelectedStock
            // 
            this.lb_SelectedStock.AutoSize = true;
            this.lb_SelectedStock.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_SelectedStock.Font = new System.Drawing.Font("굴림", 15F);
            this.lb_SelectedStock.Location = new System.Drawing.Point(1237, 540);
            this.lb_SelectedStock.Name = "lb_SelectedStock";
            this.lb_SelectedStock.Size = new System.Drawing.Size(0, 25);
            this.lb_SelectedStock.TabIndex = 47;
            this.lb_SelectedStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 15F);
            this.label7.Location = new System.Drawing.Point(1063, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(303, 25);
            this.label7.TabIndex = 46;
            this.label7.Text = "선택하신 종목의 시장가는";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 15F);
            this.label5.Location = new System.Drawing.Point(1255, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 25);
            this.label5.TabIndex = 45;
            this.label5.Text = "원";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // info_shop_button
            // 
            this.info_shop_button.Location = new System.Drawing.Point(1242, 26);
            this.info_shop_button.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.info_shop_button.Name = "info_shop_button";
            this.info_shop_button.Size = new System.Drawing.Size(156, 79);
            this.info_shop_button.TabIndex = 44;
            this.info_shop_button.Text = "정보 상점";
            this.info_shop_button.UseVisualStyleBackColor = true;
            // 
            // news_button
            // 
            this.news_button.Location = new System.Drawing.Point(1059, 24);
            this.news_button.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.news_button.Name = "news_button";
            this.news_button.Size = new System.Drawing.Size(163, 79);
            this.news_button.TabIndex = 43;
            this.news_button.Text = "뉴스 / 정보";
            this.news_button.UseVisualStyleBackColor = true;
            this.news_button.Click += new System.EventHandler(this.news_button_Click);
            // 
            // sell_button
            // 
            this.sell_button.BackColor = System.Drawing.Color.DarkBlue;
            this.sell_button.Font = new System.Drawing.Font("굴림", 20F);
            this.sell_button.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.sell_button.Location = new System.Drawing.Point(1234, 807);
            this.sell_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sell_button.Name = "sell_button";
            this.sell_button.Size = new System.Drawing.Size(165, 80);
            this.sell_button.TabIndex = 42;
            this.sell_button.Text = "매도";
            this.sell_button.UseVisualStyleBackColor = false;
            this.sell_button.Click += new System.EventHandler(this.sell_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 15F);
            this.label4.Location = new System.Drawing.Point(1063, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 25);
            this.label4.TabIndex = 40;
            this.label4.Text = "선택하신 종목은";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15F);
            this.label3.Location = new System.Drawing.Point(1063, 661);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "수량";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mystock_listview
            // 
            this.mystock_listview.HideSelection = false;
            this.mystock_listview.Location = new System.Drawing.Point(25, 563);
            this.mystock_listview.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.mystock_listview.MultiSelect = false;
            this.mystock_listview.Name = "mystock_listview";
            this.mystock_listview.Size = new System.Drawing.Size(1014, 324);
            this.mystock_listview.TabIndex = 37;
            this.mystock_listview.UseCompatibleStateImageBehavior = false;
            this.mystock_listview.SelectedIndexChanged += new System.EventHandler(this.mystock_listview_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(19, 526);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "현재 보유 주식";
            // 
            // mymoney_label
            // 
            this.mymoney_label.AutoSize = true;
            this.mymoney_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mymoney_label.Font = new System.Drawing.Font("굴림", 15F);
            this.mymoney_label.Location = new System.Drawing.Point(1073, 305);
            this.mymoney_label.Name = "mymoney_label";
            this.mymoney_label.Size = new System.Drawing.Size(0, 25);
            this.mymoney_label.TabIndex = 35;
            this.mymoney_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(1063, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 34;
            this.label1.Text = "현재 보유 금액";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buy_button
            // 
            this.buy_button.BackColor = System.Drawing.Color.DarkRed;
            this.buy_button.Font = new System.Drawing.Font("굴림", 20F);
            this.buy_button.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.buy_button.Location = new System.Drawing.Point(1063, 807);
            this.buy_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buy_button.Name = "buy_button";
            this.buy_button.Size = new System.Drawing.Size(165, 80);
            this.buy_button.TabIndex = 33;
            this.buy_button.Text = "매수";
            this.buy_button.UseVisualStyleBackColor = false;
            this.buy_button.Click += new System.EventHandler(this.buy_button_Click);
            // 
            // stock_listview
            // 
            this.stock_listview.HideSelection = false;
            this.stock_listview.Location = new System.Drawing.Point(24, 154);
            this.stock_listview.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.stock_listview.Name = "stock_listview";
            this.stock_listview.Size = new System.Drawing.Size(1014, 350);
            this.stock_listview.TabIndex = 28;
            this.stock_listview.UseCompatibleStateImageBehavior = false;
            this.stock_listview.SelectedIndexChanged += new System.EventHandler(this.stock_listview_SelectedIndexChanged);
            // 
            // labe1
            // 
            this.labe1.AutoSize = true;
            this.labe1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labe1.Location = new System.Drawing.Point(17, 24);
            this.labe1.Name = "labe1";
            this.labe1.Size = new System.Drawing.Size(286, 34);
            this.labe1.TabIndex = 27;
            this.labe1.Text = "현재 턴 주요 뉴스";
            // 
            // gameturn_label
            // 
            this.gameturn_label.AutoSize = true;
            this.gameturn_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gameturn_label.Font = new System.Drawing.Font("굴림", 15F);
            this.gameturn_label.Location = new System.Drawing.Point(1273, 207);
            this.gameturn_label.Name = "gameturn_label";
            this.gameturn_label.Size = new System.Drawing.Size(38, 25);
            this.gameturn_label.TabIndex = 56;
            this.gameturn_label.Text = "01";
            // 
            // finish_label
            // 
            this.finish_label.AutoSize = true;
            this.finish_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.finish_label.Font = new System.Drawing.Font("굴림", 15F);
            this.finish_label.Location = new System.Drawing.Point(1309, 207);
            this.finish_label.Name = "finish_label";
            this.finish_label.Size = new System.Drawing.Size(56, 25);
            this.finish_label.TabIndex = 55;
            this.finish_label.Text = "/ 50";
            // 
            // nowTurn_label
            // 
            this.nowTurn_label.AutoSize = true;
            this.nowTurn_label.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.nowTurn_label.Font = new System.Drawing.Font("굴림", 20F);
            this.nowTurn_label.Location = new System.Drawing.Point(1272, 143);
            this.nowTurn_label.Name = "nowTurn_label";
            this.nowTurn_label.Size = new System.Drawing.Size(94, 34);
            this.nowTurn_label.TabIndex = 54;
            this.nowTurn_label.Text = "턴 수";
            // 
            // gametime_label
            // 
            this.gametime_label.AutoSize = true;
            this.gametime_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gametime_label.Font = new System.Drawing.Font("굴림", 15F);
            this.gametime_label.Location = new System.Drawing.Point(1058, 207);
            this.gametime_label.Name = "gametime_label";
            this.gametime_label.Size = new System.Drawing.Size(194, 25);
            this.gametime_label.TabIndex = 53;
            this.gametime_label.Text = "2532년 10월 5일";
            // 
            // today_label
            // 
            this.today_label.AutoSize = true;
            this.today_label.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.today_label.Font = new System.Drawing.Font("굴림", 20F);
            this.today_label.Location = new System.Drawing.Point(1075, 143);
            this.today_label.Name = "today_label";
            this.today_label.Size = new System.Drawing.Size(162, 34);
            this.today_label.TabIndex = 52;
            this.today_label.Text = "현재 날짜";
            // 
            // total_amount_textbox
            // 
            this.total_amount_textbox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.total_amount_textbox.Location = new System.Drawing.Point(1134, 661);
            this.total_amount_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.total_amount_textbox.Name = "total_amount_textbox";
            this.total_amount_textbox.Size = new System.Drawing.Size(154, 25);
            this.total_amount_textbox.TabIndex = 57;
            this.total_amount_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.total_amount_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_textbox_KeyPress);
            // 
            // price_textbox
            // 
            this.price_textbox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.price_textbox.Location = new System.Drawing.Point(1068, 540);
            this.price_textbox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.price_textbox.Name = "price_textbox";
            this.price_textbox.Size = new System.Drawing.Size(154, 25);
            this.price_textbox.TabIndex = 58;
            this.price_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_textbox_KeyPress);
            // 
            // plus_button
            // 
            this.plus_button.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.plus_button.Location = new System.Drawing.Point(1314, 611);
            this.plus_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plus_button.Name = "plus_button";
            this.plus_button.Size = new System.Drawing.Size(74, 49);
            this.plus_button.TabIndex = 59;
            this.plus_button.Text = "+";
            this.plus_button.UseVisualStyleBackColor = true;
            this.plus_button.Click += new System.EventHandler(this.plus_button_Click);
            // 
            // minus_button
            // 
            this.minus_button.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.minus_button.Location = new System.Drawing.Point(1314, 693);
            this.minus_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.minus_button.Name = "minus_button";
            this.minus_button.Size = new System.Drawing.Size(74, 44);
            this.minus_button.TabIndex = 59;
            this.minus_button.Text = "-";
            this.minus_button.UseVisualStyleBackColor = true;
            this.minus_button.Click += new System.EventHandler(this.minus_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 15F);
            this.label6.Location = new System.Drawing.Point(18, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 25);
            this.label6.TabIndex = 60;
            this.label6.Text = "판매중인 주식";
            // 
            // KWM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 904);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.minus_button);
            this.Controls.Add(this.plus_button);
            this.Controls.Add(this.price_textbox);
            this.Controls.Add(this.total_amount_textbox);
            this.Controls.Add(this.gameturn_label);
            this.Controls.Add(this.finish_label);
            this.Controls.Add(this.nowTurn_label);
            this.Controls.Add(this.gametime_label);
            this.Controls.Add(this.today_label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_Selected);
            this.Controls.Add(this.lb_SelectedStock);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.info_shop_button);
            this.Controls.Add(this.news_button);
            this.Controls.Add(this.sell_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mystock_listview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mymoney_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buy_button);
            this.Controls.Add(this.stock_listview);
            this.Controls.Add(this.labe1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MinimumSize = new System.Drawing.Size(1400, 800);
            this.Name = "KWM";
            this.Text = "Kwang Woon Moon";
            this.Load += new System.EventHandler(this.KWM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_Selected;
        private System.Windows.Forms.Label lb_SelectedStock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button info_shop_button;
        private System.Windows.Forms.Button news_button;
        private System.Windows.Forms.Button sell_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView mystock_listview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label mymoney_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buy_button;
        private System.Windows.Forms.ListView stock_listview;
        private System.Windows.Forms.Label labe1;
        private System.Windows.Forms.Label gameturn_label;
        private System.Windows.Forms.Label finish_label;
        private System.Windows.Forms.Label nowTurn_label;
        private System.Windows.Forms.Label gametime_label;
        private System.Windows.Forms.Label today_label;
        private System.Windows.Forms.TextBox total_amount_textbox;
        private System.Windows.Forms.TextBox price_textbox;
        private System.Windows.Forms.Button plus_button;
        private System.Windows.Forms.Button minus_button;
        private System.Windows.Forms.Label label6;
    }
}

