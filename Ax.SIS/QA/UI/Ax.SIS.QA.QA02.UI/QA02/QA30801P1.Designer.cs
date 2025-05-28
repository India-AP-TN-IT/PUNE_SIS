namespace Ax.SIS.QA.QA02.UI
{
    partial class QA30801P1
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grp01_SEARCH = new System.Windows.Forms.GroupBox();
            this.dte01_PRDT_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dte01_PRDT_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_PROD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNOTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_LOTNO_TITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VENDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_SAUP = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_INQUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel2.SuspendLayout();
            this.grp01_SEARCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO_TITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SAUP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 540);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 101);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(572, 439);
            this.panel3.TabIndex = 1;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AutoGenerateColumns = false;
            this.grd01.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 3);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 1;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(566, 433);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grp01_SEARCH);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(572, 101);
            this.panel2.TabIndex = 0;
            // 
            // grp01_SEARCH
            // 
            this.grp01_SEARCH.Controls.Add(this.dte01_PRDT_DATE_TO);
            this.grp01_SEARCH.Controls.Add(this.label1);
            this.grp01_SEARCH.Controls.Add(this.dte01_PRDT_DATE_FROM);
            this.grp01_SEARCH.Controls.Add(this.lbl01_PROD_DATE);
            this.grp01_SEARCH.Controls.Add(this.txt01_PARTNO);
            this.grp01_SEARCH.Controls.Add(this.lbl01_PARTNOTITLE);
            this.grp01_SEARCH.Controls.Add(this.txt01_LOTNO);
            this.grp01_SEARCH.Controls.Add(this.lbl01_LOTNO_TITLE);
            this.grp01_SEARCH.Controls.Add(this.cbo01_BIZCD);
            this.grp01_SEARCH.Controls.Add(this.cdx01_VENDCD);
            this.grp01_SEARCH.Controls.Add(this.lbl01_VENDNM);
            this.grp01_SEARCH.Controls.Add(this.lbl01_SAUP);
            this.grp01_SEARCH.Controls.Add(this.btn01_INQUERY);
            this.grp01_SEARCH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_SEARCH.Location = new System.Drawing.Point(3, 3);
            this.grp01_SEARCH.Name = "grp01_SEARCH";
            this.grp01_SEARCH.Size = new System.Drawing.Size(566, 95);
            this.grp01_SEARCH.TabIndex = 0;
            this.grp01_SEARCH.TabStop = false;
            // 
            // dte01_PRDT_DATE_TO
            // 
            this.dte01_PRDT_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_PRDT_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_PRDT_DATE_TO.Location = new System.Drawing.Point(237, 67);
            this.dte01_PRDT_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_PRDT_DATE_TO.Name = "dte01_PRDT_DATE_TO";
            this.dte01_PRDT_DATE_TO.OriginalFormat = "";
            this.dte01_PRDT_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_PRDT_DATE_TO.TabIndex = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 129;
            this.label1.Text = "~";
            // 
            // dte01_PRDT_DATE_FROM
            // 
            this.dte01_PRDT_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_PRDT_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_PRDT_DATE_FROM.Location = new System.Drawing.Point(111, 66);
            this.dte01_PRDT_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_PRDT_DATE_FROM.Name = "dte01_PRDT_DATE_FROM";
            this.dte01_PRDT_DATE_FROM.OriginalFormat = "";
            this.dte01_PRDT_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_PRDT_DATE_FROM.TabIndex = 128;
            // 
            // lbl01_PROD_DATE
            // 
            this.lbl01_PROD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PROD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_PROD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PROD_DATE.Location = new System.Drawing.Point(6, 66);
            this.lbl01_PROD_DATE.Name = "lbl01_PROD_DATE";
            this.lbl01_PROD_DATE.Size = new System.Drawing.Size(99, 21);
            this.lbl01_PROD_DATE.TabIndex = 127;
            this.lbl01_PROD_DATE.Tag = null;
            this.lbl01_PROD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PROD_DATE.Value = "생산일자";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(342, 40);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(217, 21);
            this.txt01_PARTNO.TabIndex = 126;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNOTITLE
            // 
            this.lbl01_PARTNOTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNOTITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNOTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNOTITLE.Location = new System.Drawing.Point(237, 40);
            this.lbl01_PARTNOTITLE.Name = "lbl01_PARTNOTITLE";
            this.lbl01_PARTNOTITLE.Size = new System.Drawing.Size(99, 21);
            this.lbl01_PARTNOTITLE.TabIndex = 125;
            this.lbl01_PARTNOTITLE.Tag = null;
            this.lbl01_PARTNOTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNOTITLE.Value = "LOT NO";
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.Location = new System.Drawing.Point(111, 39);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(120, 21);
            this.txt01_LOTNO.TabIndex = 124;
            this.txt01_LOTNO.Tag = null;
            // 
            // lbl01_LOTNO_TITLE
            // 
            this.lbl01_LOTNO_TITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOTNO_TITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_LOTNO_TITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LOTNO_TITLE.Location = new System.Drawing.Point(6, 39);
            this.lbl01_LOTNO_TITLE.Name = "lbl01_LOTNO_TITLE";
            this.lbl01_LOTNO_TITLE.Size = new System.Drawing.Size(99, 21);
            this.lbl01_LOTNO_TITLE.TabIndex = 123;
            this.lbl01_LOTNO_TITLE.Tag = null;
            this.lbl01_LOTNO_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LOTNO_TITLE.Value = "LOT NO";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(111, 13);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(120, 20);
            this.cbo01_BIZCD.TabIndex = 122;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = false;
            this.cdx01_VENDCD.CodeTextBoxWidth = 40;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(342, 13);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(217, 21);
            this.cdx01_VENDCD.TabIndex = 121;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_VENDNM
            // 
            this.lbl01_VENDNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDNM.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDNM.Location = new System.Drawing.Point(237, 13);
            this.lbl01_VENDNM.Name = "lbl01_VENDNM";
            this.lbl01_VENDNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VENDNM.TabIndex = 120;
            this.lbl01_VENDNM.Tag = null;
            this.lbl01_VENDNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VENDNM.Value = "협력사";
            // 
            // lbl01_SAUP
            // 
            this.lbl01_SAUP.AutoFontSizeMaxValue = 9F;
            this.lbl01_SAUP.AutoFontSizeMinValue = 9F;
            this.lbl01_SAUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SAUP.Location = new System.Drawing.Point(6, 13);
            this.lbl01_SAUP.Name = "lbl01_SAUP";
            this.lbl01_SAUP.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SAUP.TabIndex = 119;
            this.lbl01_SAUP.Tag = null;
            this.lbl01_SAUP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SAUP.Value = "사업장";
            // 
            // btn01_INQUERY
            // 
            this.btn01_INQUERY.Location = new System.Drawing.Point(484, 67);
            this.btn01_INQUERY.Name = "btn01_INQUERY";
            this.btn01_INQUERY.Size = new System.Drawing.Size(75, 23);
            this.btn01_INQUERY.TabIndex = 18;
            this.btn01_INQUERY.Text = "조회";
            this.btn01_INQUERY.UseVisualStyleBackColor = true;
            this.btn01_INQUERY.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // QA30801P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "QA30801P1";
            this.Size = new System.Drawing.Size(572, 540);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grp01_SEARCH.ResumeLayout(false);
            this.grp01_SEARCH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO_TITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SAUP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grp01_SEARCH;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxButton btn01_INQUERY;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SAUP;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxLabel lbl01_VENDNM;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNOTITLE;
        private DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private DEV.Utility.Controls.AxLabel lbl01_LOTNO_TITLE;
        private DEV.Utility.Controls.AxDateEdit dte01_PRDT_DATE_FROM;
        private DEV.Utility.Controls.AxLabel lbl01_PROD_DATE;
        private DEV.Utility.Controls.AxDateEdit dte01_PRDT_DATE_TO;
        private System.Windows.Forms.Label label1;

    }
}
