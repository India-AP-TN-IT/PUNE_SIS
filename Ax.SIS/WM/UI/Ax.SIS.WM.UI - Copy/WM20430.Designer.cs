namespace Ax.SIS.WM.UI
{
    partial class WM20430
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
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.cbo01_PRINT_DIV3 = new Ax.DEV.Utility.Controls.AxComboBox();
            this.chkLotno = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo01_PRINT_DIV2 = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PRINT_DIV2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo01_A0A = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_A0S = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.dte01_STOCK_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_STOCK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.gbxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRINT_DIV2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STOCK_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.cbo01_PRINT_DIV3);
            this.gbxSearch.Controls.Add(this.chkLotno);
            this.gbxSearch.Controls.Add(this.cbo01_PRINT_DIV2);
            this.gbxSearch.Controls.Add(this.lbl01_PRINT_DIV2);
            this.gbxSearch.Controls.Add(this.groupBox1);
            this.gbxSearch.Controls.Add(this.lbl01_VENDCD);
            this.gbxSearch.Controls.Add(this.cdx01_VENDCD);
            this.gbxSearch.Controls.Add(this.txt01_LOTNO);
            this.gbxSearch.Controls.Add(this.dte01_STOCK_DATE);
            this.gbxSearch.Controls.Add(this.lbl01_LOTNO);
            this.gbxSearch.Controls.Add(this.lbl01_STOCK_DATE);
            this.gbxSearch.Controls.Add(this.cbo01_BIZCD);
            this.gbxSearch.Controls.Add(this.lbl01_BIZNM);
            this.gbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearch.Location = new System.Drawing.Point(0, 34);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(1024, 71);
            this.gbxSearch.TabIndex = 0;
            this.gbxSearch.TabStop = false;
            // 
            // cbo01_PRINT_DIV3
            // 
            this.cbo01_PRINT_DIV3.DisplayMember = "Y";
            this.cbo01_PRINT_DIV3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRINT_DIV3.FormattingEnabled = true;
            this.cbo01_PRINT_DIV3.Location = new System.Drawing.Point(588, 45);
            this.cbo01_PRINT_DIV3.Name = "cbo01_PRINT_DIV3";
            this.cbo01_PRINT_DIV3.Size = new System.Drawing.Size(132, 20);
            this.cbo01_PRINT_DIV3.TabIndex = 80;
            // 
            // chkLotno
            // 
            this.chkLotno.AutoSize = true;
            this.chkLotno.Location = new System.Drawing.Point(1008, 45);
            this.chkLotno.Name = "chkLotno";
            this.chkLotno.Size = new System.Drawing.Size(85, 16);
            this.chkLotno.TabIndex = 79;
            this.chkLotno.Text = "Lotno Only";
            this.chkLotno.UseVisualStyleBackColor = true;
            // 
            // cbo01_PRINT_DIV2
            // 
            this.cbo01_PRINT_DIV2.DisplayMember = "Y";
            this.cbo01_PRINT_DIV2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRINT_DIV2.FormattingEnabled = true;
            this.cbo01_PRINT_DIV2.Location = new System.Drawing.Point(450, 45);
            this.cbo01_PRINT_DIV2.Name = "cbo01_PRINT_DIV2";
            this.cbo01_PRINT_DIV2.Size = new System.Drawing.Size(132, 20);
            this.cbo01_PRINT_DIV2.TabIndex = 78;
            // 
            // lbl01_PRINT_DIV2
            // 
            this.lbl01_PRINT_DIV2.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRINT_DIV2.AutoFontSizeMinValue = 9F;
            this.lbl01_PRINT_DIV2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRINT_DIV2.Location = new System.Drawing.Point(344, 44);
            this.lbl01_PRINT_DIV2.Name = "lbl01_PRINT_DIV2";
            this.lbl01_PRINT_DIV2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PRINT_DIV2.TabIndex = 77;
            this.lbl01_PRINT_DIV2.Tag = null;
            this.lbl01_PRINT_DIV2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PRINT_DIV2.Value = "사용유무";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo01_A0A);
            this.groupBox1.Controls.Add(this.rdo01_A0S);
            this.groupBox1.Location = new System.Drawing.Point(588, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 30);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            // 
            // rdo01_A0A
            // 
            this.rdo01_A0A.AutoSize = true;
            this.rdo01_A0A.Checked = true;
            this.rdo01_A0A.Location = new System.Drawing.Point(17, 10);
            this.rdo01_A0A.Name = "rdo01_A0A";
            this.rdo01_A0A.Size = new System.Drawing.Size(63, 16);
            this.rdo01_A0A.TabIndex = 4;
            this.rdo01_A0A.TabStop = true;
            this.rdo01_A0A.Text = "LOCAL";
            this.rdo01_A0A.UseVisualStyleBackColor = true;
            // 
            // rdo01_A0S
            // 
            this.rdo01_A0S.AutoSize = true;
            this.rdo01_A0S.Location = new System.Drawing.Point(84, 10);
            this.rdo01_A0S.Name = "rdo01_A0S";
            this.rdo01_A0S.Size = new System.Drawing.Size(48, 16);
            this.rdo01_A0S.TabIndex = 73;
            this.rdo01_A0S.Text = "CKD";
            this.rdo01_A0S.UseVisualStyleBackColor = true;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_VENDCD.Location = new System.Drawing.Point(6, 43);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VENDCD.TabIndex = 75;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VENDCD.Value = "사업장명";
            this.lbl01_VENDCD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(112, 44);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(228, 21);
            this.cdx01_VENDCD.TabIndex = 74;
            this.cdx01_VENDCD.Tag = null;
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.Location = new System.Drawing.Point(832, 43);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(163, 21);
            this.txt01_LOTNO.TabIndex = 72;
            this.txt01_LOTNO.Tag = null;
            // 
            // dte01_STOCK_DATE
            // 
            this.dte01_STOCK_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_STOCK_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_STOCK_DATE.Location = new System.Drawing.Point(450, 16);
            this.dte01_STOCK_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_STOCK_DATE.Name = "dte01_STOCK_DATE";
            this.dte01_STOCK_DATE.OriginalFormat = "";
            this.dte01_STOCK_DATE.Size = new System.Drawing.Size(132, 21);
            this.dte01_STOCK_DATE.TabIndex = 2;
            this.dte01_STOCK_DATE.CloseUp += new System.EventHandler(this.dte01_DELI_DATE_CloseUp);
            this.dte01_STOCK_DATE.ValueChanged += new System.EventHandler(this.dte01_PLAN_DATE_ValueChanged);
            this.dte01_STOCK_DATE.Leave += new System.EventHandler(this.dte01_DELI_DATE_Leave);
            // 
            // lbl01_LOTNO
            // 
            this.lbl01_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_LOTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LOTNO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_LOTNO.Location = new System.Drawing.Point(726, 43);
            this.lbl01_LOTNO.Name = "lbl01_LOTNO";
            this.lbl01_LOTNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LOTNO.TabIndex = 0;
            this.lbl01_LOTNO.Tag = null;
            this.lbl01_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LOTNO.Value = "발행차수";
            this.lbl01_LOTNO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // lbl01_STOCK_DATE
            // 
            this.lbl01_STOCK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STOCK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STOCK_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STOCK_DATE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_STOCK_DATE.Location = new System.Drawing.Point(344, 17);
            this.lbl01_STOCK_DATE.Name = "lbl01_STOCK_DATE";
            this.lbl01_STOCK_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STOCK_DATE.TabIndex = 0;
            this.lbl01_STOCK_DATE.Tag = null;
            this.lbl01_STOCK_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STOCK_DATE.Value = "요청일자";
            this.lbl01_STOCK_DATE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(114, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(8, 16);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장명";
            this.lbl01_BIZNM.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 10);
            this.panel1.TabIndex = 1;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 115);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 653);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // WM20430
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxSearch);
            this.Name = "WM20430";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.gbxSearch, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRINT_DIV2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STOCK_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private System.Windows.Forms.GroupBox gbxSearch;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_STOCK_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_STOCK_DATE;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_A0A;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_A0S;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PRINT_DIV2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PRINT_DIV2;
        private Ax.DEV.Utility.Controls.AxCheckBox chkLotno;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PRINT_DIV3;
    }
}
