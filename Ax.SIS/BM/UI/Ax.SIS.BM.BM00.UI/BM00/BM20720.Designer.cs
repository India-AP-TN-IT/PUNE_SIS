namespace Ax.SIS.BM.BM00.UI
{
    partial class BM20720
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM20720));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.axCodeBox1 = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.heButton2 = new Ax.DEV.Utility.Controls.AxButton();
            this.heLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_M_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_M_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.dte01_BaseDate = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BaseDate = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cdx01_LINECD2 = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axCodeBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_M_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_M_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BaseDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 117);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1018, 648);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cdx01_VINCD);
            this.tabPage1.Controls.Add(this.lbl01_VINCD);
            this.tabPage1.Controls.Add(this.grd02);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1010, 620);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Part-Line Setting";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(140, 3);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(224, 21);
            this.cdx01_VINCD.TabIndex = 38;
            this.cdx01_VINCD.Tag = null;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(9, 3);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(125, 20);
            this.lbl01_VINCD.TabIndex = 37;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "CAR";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 30);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(1004, 586);
            this.grd02.StyleInfo = resources.GetString("grd02.StyleInfo");
            this.grd02.TabIndex = 8;
            this.grd02.UseCustomHighlight = true;
            this.grd02.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd02_AfterEdit);
            this.grd02.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cdx01_LINECD);
            this.tabPage2.Controls.Add(this.lbl01_LINECD);
            this.tabPage2.Controls.Add(this.grd01);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1010, 620);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Material Part Setting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 80;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(117, 6);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(432, 21);
            this.cdx01_LINECD.TabIndex = 43;
            this.cdx01_LINECD.Tag = null;
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(11, 6);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 20);
            this.lbl01_LINECD.TabIndex = 42;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "LINE";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 33);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1007, 586);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 6;
            this.grd01.UseCustomHighlight = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cdx01_LINECD2);
            this.tabPage3.Controls.Add(this.axLabel2);
            this.tabPage3.Controls.Add(this.axCodeBox1);
            this.tabPage3.Controls.Add(this.axLabel1);
            this.tabPage3.Controls.Add(this.axButton1);
            this.tabPage3.Controls.Add(this.heButton2);
            this.tabPage3.Controls.Add(this.heLabel3);
            this.tabPage3.Controls.Add(this.grd03);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1010, 620);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Station BOM(Batch JOB)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // axCodeBox1
            // 
            this.axCodeBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.axCodeBox1.CodeParameterName = "CODE";
            this.axCodeBox1.CodeTextBoxReadOnly = false;
            this.axCodeBox1.CodeTextBoxVisible = true;
            this.axCodeBox1.CodeTextBoxWidth = 40;
            this.axCodeBox1.HEPopupHelper = null;
            this.axCodeBox1.Location = new System.Drawing.Point(143, 19);
            this.axCodeBox1.Name = "axCodeBox1";
            this.axCodeBox1.NameParameterName = "NAME";
            this.axCodeBox1.NameTextBoxReadOnly = false;
            this.axCodeBox1.NameTextBoxVisible = true;
            this.axCodeBox1.PopupButtonReadOnly = false;
            this.axCodeBox1.PopupTitle = "";
            this.axCodeBox1.PrefixCode = "";
            this.axCodeBox1.Size = new System.Drawing.Size(224, 21);
            this.axCodeBox1.TabIndex = 96;
            this.axCodeBox1.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(12, 19);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(125, 20);
            this.axLabel1.TabIndex = 95;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "CAR";
            // 
            // axButton1
            // 
            this.axButton1.Location = new System.Drawing.Point(401, 6);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(122, 32);
            this.axButton1.TabIndex = 94;
            this.axButton1.Text = "Process";
            this.axButton1.UseVisualStyleBackColor = true;
            this.axButton1.Click += new System.EventHandler(this.axButton1_Click);
            // 
            // heButton2
            // 
            this.heButton2.Location = new System.Drawing.Point(187, 67);
            this.heButton2.Name = "heButton2";
            this.heButton2.Size = new System.Drawing.Size(122, 23);
            this.heButton2.TabIndex = 93;
            this.heButton2.Text = "Refresh";
            this.heButton2.UseVisualStyleBackColor = true;
            this.heButton2.Click += new System.EventHandler(this.heButton2_Click);
            // 
            // heLabel3
            // 
            this.heLabel3.AutoFontSizeMaxValue = 9F;
            this.heLabel3.AutoFontSizeMinValue = 9F;
            this.heLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.heLabel3.Location = new System.Drawing.Point(15, 69);
            this.heLabel3.Name = "heLabel3";
            this.heLabel3.Size = new System.Drawing.Size(166, 21);
            this.heLabel3.TabIndex = 92;
            this.heLabel3.Tag = null;
            this.heLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel3.Value = "Job List";
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd03.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd03.EnabledActionFlag = true;
            this.grd03.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(6, 96);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(999, 523);
            this.grd03.StyleInfo = resources.GetString("grd03.StyleInfo");
            this.grd03.TabIndex = 91;
            this.grd03.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbl01_M_PARTNO);
            this.groupBox1.Controls.Add(this.txt01_M_PARTNO);
            this.groupBox1.Controls.Add(this.dte01_BaseDate);
            this.groupBox1.Controls.Add(this.lbl01_BaseDate);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Location = new System.Drawing.Point(10, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 71);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_M_PARTNO
            // 
            this.lbl01_M_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_M_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_M_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_M_PARTNO.Location = new System.Drawing.Point(6, 43);
            this.lbl01_M_PARTNO.Name = "lbl01_M_PARTNO";
            this.lbl01_M_PARTNO.Size = new System.Drawing.Size(120, 21);
            this.lbl01_M_PARTNO.TabIndex = 35;
            this.lbl01_M_PARTNO.Tag = null;
            this.lbl01_M_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_M_PARTNO.Value = "Part Number";
            // 
            // txt01_M_PARTNO
            // 
            this.txt01_M_PARTNO.Location = new System.Drawing.Point(132, 43);
            this.txt01_M_PARTNO.Name = "txt01_M_PARTNO";
            this.txt01_M_PARTNO.Size = new System.Drawing.Size(232, 21);
            this.txt01_M_PARTNO.TabIndex = 34;
            this.txt01_M_PARTNO.Tag = null;
            // 
            // dte01_BaseDate
            // 
            this.dte01_BaseDate.CustomFormat = "yyyy-MM-dd";
            this.dte01_BaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_BaseDate.Location = new System.Drawing.Point(845, 43);
            this.dte01_BaseDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_BaseDate.Name = "dte01_BaseDate";
            this.dte01_BaseDate.OriginalFormat = "";
            this.dte01_BaseDate.Size = new System.Drawing.Size(100, 21);
            this.dte01_BaseDate.TabIndex = 7;
            // 
            // lbl01_BaseDate
            // 
            this.lbl01_BaseDate.AutoFontSizeMaxValue = 9F;
            this.lbl01_BaseDate.AutoFontSizeMinValue = 9F;
            this.lbl01_BaseDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BaseDate.Location = new System.Drawing.Point(739, 44);
            this.lbl01_BaseDate.Name = "lbl01_BaseDate";
            this.lbl01_BaseDate.Size = new System.Drawing.Size(100, 20);
            this.lbl01_BaseDate.TabIndex = 6;
            this.lbl01_BaseDate.Tag = null;
            this.lbl01_BaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BaseDate.Value = "DATE";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(148, 20);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(225, 23);
            this.cbo01_BIZCD.TabIndex = 3;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(6, 20);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(136, 20);
            this.lbl01_BIZCD.TabIndex = 2;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business Plant";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cdx01_LINECD2
            // 
            this.cdx01_LINECD2.CodeParameterName = "CODE";
            this.cdx01_LINECD2.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD2.CodeTextBoxVisible = true;
            this.cdx01_LINECD2.CodeTextBoxWidth = 80;
            this.cdx01_LINECD2.HEPopupHelper = null;
            this.cdx01_LINECD2.Location = new System.Drawing.Point(120, 44);
            this.cdx01_LINECD2.Name = "cdx01_LINECD2";
            this.cdx01_LINECD2.NameParameterName = "NAME";
            this.cdx01_LINECD2.NameTextBoxReadOnly = false;
            this.cdx01_LINECD2.NameTextBoxVisible = true;
            this.cdx01_LINECD2.PopupButtonReadOnly = false;
            this.cdx01_LINECD2.PopupTitle = "";
            this.cdx01_LINECD2.PrefixCode = "";
            this.cdx01_LINECD2.Size = new System.Drawing.Size(432, 21);
            this.cdx01_LINECD2.TabIndex = 98;
            this.cdx01_LINECD2.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(14, 44);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(100, 20);
            this.axLabel2.TabIndex = 97;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "LINE";
            // 
            // BM20720
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "BM20720";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axCodeBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_M_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_M_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BaseDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.TabPage tabPage2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxLabel lbl01_M_PARTNO;
        private DEV.Utility.Controls.AxTextBox txt01_M_PARTNO;
        private DEV.Utility.Controls.AxDateEdit dte01_BaseDate;
        private DEV.Utility.Controls.AxLabel lbl01_BaseDate;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private System.Windows.Forms.TabPage tabPage3;
        private DEV.Utility.Controls.AxButton heButton2;
        private DEV.Utility.Controls.AxLabel heLabel3;
        private DEV.Utility.Controls.AxFlexGrid grd03;
        private System.Windows.Forms.Timer timer1;
        private DEV.Utility.Controls.AxButton axButton1;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private DEV.Utility.Controls.AxCodeBox axCodeBox1;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD2;
        private DEV.Utility.Controls.AxLabel axLabel2;

    }
}
