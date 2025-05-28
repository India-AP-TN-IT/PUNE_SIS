namespace Ax.SIS.WM.UI
{
    partial class WM20512
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WM20512));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtp01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_Date = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_BASE_QUERY = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_MAT_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_MAT_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_DOM_IMP = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_DOM_IMP = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpg01_TOTAL1 = new System.Windows.Forms.TabPage();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tpg01_DETAIL1 = new System.Windows.Forms.TabPage();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAT_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOM_IMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpg01_TOTAL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.tpg01_DETAIL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 28);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 740);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl01_VENDCD);
            this.panel2.Controls.Add(this.cdx01_VENDCD);
            this.panel2.Controls.Add(this.dtp01_STD_DATE);
            this.panel2.Controls.Add(this.lbl01_Date);
            this.panel2.Controls.Add(this.chk01_BASE_QUERY);
            this.panel2.Controls.Add(this.lbl01_MAT_TYPE);
            this.panel2.Controls.Add(this.cbo01_MAT_TYPE);
            this.panel2.Controls.Add(this.cbo01_DOM_IMP);
            this.panel2.Controls.Add(this.lbl01_DOM_IMP);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.cbo01_PRDT_DIV);
            this.panel2.Controls.Add(this.lbl01_PRDT_DIV);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // dtp01_STD_DATE
            // 
            this.dtp01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STD_DATE.Location = new System.Drawing.Point(137, 337);
            this.dtp01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STD_DATE.Name = "dtp01_STD_DATE";
            this.dtp01_STD_DATE.OriginalFormat = "";
            this.dtp01_STD_DATE.Size = new System.Drawing.Size(114, 21);
            this.dtp01_STD_DATE.TabIndex = 132;
            this.dtp01_STD_DATE.Visible = false;
            // 
            // lbl01_Date
            // 
            this.lbl01_Date.AutoFontSizeMaxValue = 9F;
            this.lbl01_Date.AutoFontSizeMinValue = 9F;
            this.lbl01_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_Date.Location = new System.Drawing.Point(5, 337);
            this.lbl01_Date.Name = "lbl01_Date";
            this.lbl01_Date.Size = new System.Drawing.Size(126, 21);
            this.lbl01_Date.TabIndex = 131;
            this.lbl01_Date.Tag = null;
            this.lbl01_Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_Date.Value = "Date";
            this.lbl01_Date.Visible = false;
            // 
            // chk01_BASE_QUERY
            // 
            this.chk01_BASE_QUERY.AutoSize = true;
            this.chk01_BASE_QUERY.Location = new System.Drawing.Point(5, 318);
            this.chk01_BASE_QUERY.Name = "chk01_BASE_QUERY";
            this.chk01_BASE_QUERY.Size = new System.Drawing.Size(87, 19);
            this.chk01_BASE_QUERY.TabIndex = 130;
            this.chk01_BASE_QUERY.Text = "Base Stock";
            this.chk01_BASE_QUERY.UseVisualStyleBackColor = true;
            this.chk01_BASE_QUERY.CheckedChanged += new System.EventHandler(this.chk01_BASE_QUERY_CheckedChanged);
            // 
            // lbl01_MAT_TYPE
            // 
            this.lbl01_MAT_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_MAT_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_MAT_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MAT_TYPE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_MAT_TYPE.Location = new System.Drawing.Point(5, 131);
            this.lbl01_MAT_TYPE.Name = "lbl01_MAT_TYPE";
            this.lbl01_MAT_TYPE.Padding = new System.Windows.Forms.Padding(3);
            this.lbl01_MAT_TYPE.Size = new System.Drawing.Size(246, 21);
            this.lbl01_MAT_TYPE.TabIndex = 129;
            this.lbl01_MAT_TYPE.Tag = null;
            this.lbl01_MAT_TYPE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_MAT_TYPE.Value = "자재유형";
            this.lbl01_MAT_TYPE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // cbo01_MAT_TYPE
            // 
            this.cbo01_MAT_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_MAT_TYPE.FormattingEnabled = true;
            this.cbo01_MAT_TYPE.Location = new System.Drawing.Point(5, 157);
            this.cbo01_MAT_TYPE.Name = "cbo01_MAT_TYPE";
            this.cbo01_MAT_TYPE.Size = new System.Drawing.Size(246, 23);
            this.cbo01_MAT_TYPE.TabIndex = 128;
            // 
            // cbo01_DOM_IMP
            // 
            this.cbo01_DOM_IMP.DisplayMember = "Y";
            this.cbo01_DOM_IMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DOM_IMP.FormattingEnabled = true;
            this.cbo01_DOM_IMP.Location = new System.Drawing.Point(5, 96);
            this.cbo01_DOM_IMP.Name = "cbo01_DOM_IMP";
            this.cbo01_DOM_IMP.Size = new System.Drawing.Size(246, 23);
            this.cbo01_DOM_IMP.TabIndex = 127;
            // 
            // lbl01_DOM_IMP
            // 
            this.lbl01_DOM_IMP.AutoFontSizeMaxValue = 9F;
            this.lbl01_DOM_IMP.AutoFontSizeMinValue = 9F;
            this.lbl01_DOM_IMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DOM_IMP.Location = new System.Drawing.Point(5, 68);
            this.lbl01_DOM_IMP.Name = "lbl01_DOM_IMP";
            this.lbl01_DOM_IMP.Size = new System.Drawing.Size(246, 23);
            this.lbl01_DOM_IMP.TabIndex = 126;
            this.lbl01_DOM_IMP.Tag = null;
            this.lbl01_DOM_IMP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DOM_IMP.Value = "Dom/Imp Div";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(5, 280);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(246, 21);
            this.txt01_PARTNO.TabIndex = 125;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(5, 252);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(246, 23);
            this.lbl01_PARTNO.TabIndex = 124;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "PART NO";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(5, 5);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(246, 23);
            this.lbl01_BIZNM2.TabIndex = 113;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(5, 33);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(246, 23);
            this.cbo01_BIZCD.TabIndex = 112;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // cbo01_PRDT_DIV
            // 
            this.cbo01_PRDT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRDT_DIV.FormattingEnabled = true;
            this.cbo01_PRDT_DIV.Location = new System.Drawing.Point(5, 698);
            this.cbo01_PRDT_DIV.Name = "cbo01_PRDT_DIV";
            this.cbo01_PRDT_DIV.Size = new System.Drawing.Size(246, 23);
            this.cbo01_PRDT_DIV.TabIndex = 107;
            this.cbo01_PRDT_DIV.Visible = false;
            this.cbo01_PRDT_DIV.SelectedIndexChanged += new System.EventHandler(this.cbo01_PRDT_DIV_SelectedIndexChanged);
            // 
            // lbl01_PRDT_DIV
            // 
            this.lbl01_PRDT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRDT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PRDT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRDT_DIV.Location = new System.Drawing.Point(5, 677);
            this.lbl01_PRDT_DIV.Name = "lbl01_PRDT_DIV";
            this.lbl01_PRDT_DIV.Size = new System.Drawing.Size(246, 23);
            this.lbl01_PRDT_DIV.TabIndex = 106;
            this.lbl01_PRDT_DIV.Tag = null;
            this.lbl01_PRDT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PRDT_DIV.Value = "제품구분";
            this.lbl01_PRDT_DIV.Visible = false;
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 740;
            this.heDockingTab1.PanelWidth = 377;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 740);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpg01_TOTAL1);
            this.tabControl1.Controls.Add(this.tpg01_DETAIL1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 736);
            this.tabControl1.TabIndex = 1;
            // 
            // tpg01_TOTAL1
            // 
            this.tpg01_TOTAL1.Controls.Add(this.grd01);
            this.tpg01_TOTAL1.Location = new System.Drawing.Point(4, 24);
            this.tpg01_TOTAL1.Name = "tpg01_TOTAL1";
            this.tpg01_TOTAL1.Size = new System.Drawing.Size(734, 708);
            this.tpg01_TOTAL1.TabIndex = 0;
            this.tpg01_TOTAL1.Text = "Total";
            this.tpg01_TOTAL1.UseVisualStyleBackColor = true;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(734, 708);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // tpg01_DETAIL1
            // 
            this.tpg01_DETAIL1.Controls.Add(this.grd02);
            this.tpg01_DETAIL1.Location = new System.Drawing.Point(4, 24);
            this.tpg01_DETAIL1.Name = "tpg01_DETAIL1";
            this.tpg01_DETAIL1.Size = new System.Drawing.Size(734, 708);
            this.tpg01_DETAIL1.TabIndex = 1;
            this.tpg01_DETAIL1.Text = "Detail";
            this.tpg01_DETAIL1.UseVisualStyleBackColor = true;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(734, 708);
            this.grd02.StyleInfo = resources.GetString("grd02.StyleInfo");
            this.grd02.TabIndex = 1;
            this.grd02.UseCustomHighlight = true;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 50;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(5, 219);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(246, 21);
            this.cdx01_VENDCD.TabIndex = 134;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.Location = new System.Drawing.Point(5, 192);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(246, 23);
            this.lbl01_VENDCD.TabIndex = 135;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VENDCD.Value = "Vendor";
            // 
            // WM20512
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "WM20512";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAT_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOM_IMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpg01_TOTAL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.tpg01_DETAIL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PRDT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PRDT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_DOM_IMP;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DOM_IMP;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MAT_TYPE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_MAT_TYPE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_STD_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_Date;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_BASE_QUERY;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpg01_TOTAL1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.TabPage tpg01_DETAIL1;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
    }
}
