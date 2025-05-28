namespace Ax.SIS.SD.UI
{
    partial class ZSD02120
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZSD02120));
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_CUSTCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_CUSTCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.axButton2 = new Ax.DEV.Utility.Controls.AxButton();
            this.axTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axCheckBox1 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.axTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd05 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 32);
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(17, 45);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(85, 21);
            this.lbl01_BIZCD.TabIndex = 114;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Plant";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(105, 44);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(123, 23);
            this.cbo01_BIZCD.TabIndex = 113;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(238, 46);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(140, 21);
            this.axLabel2.TabIndex = 118;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "TARGET DATE";
            // 
            // axDateEdit1
            // 
            this.axDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit1.Location = new System.Drawing.Point(384, 45);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(100, 21);
            this.axDateEdit1.TabIndex = 119;
            // 
            // lbl01_CUSTCD
            // 
            this.lbl01_CUSTCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CUSTCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CUSTCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CUSTCD.Location = new System.Drawing.Point(15, 71);
            this.lbl01_CUSTCD.Name = "lbl01_CUSTCD";
            this.lbl01_CUSTCD.Size = new System.Drawing.Size(261, 21);
            this.lbl01_CUSTCD.TabIndex = 139;
            this.lbl01_CUSTCD.Tag = null;
            this.lbl01_CUSTCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CUSTCD.Value = "Customer Code";
            // 
            // cdx01_CUSTCD
            // 
            this.cdx01_CUSTCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_CUSTCD.CodeParameterName = "CODE";
            this.cdx01_CUSTCD.CodeTextBoxReadOnly = false;
            this.cdx01_CUSTCD.CodeTextBoxVisible = true;
            this.cdx01_CUSTCD.CodeTextBoxWidth = 60;
            this.cdx01_CUSTCD.HEPopupHelper = null;
            this.cdx01_CUSTCD.Location = new System.Drawing.Point(279, 72);
            this.cdx01_CUSTCD.Name = "cdx01_CUSTCD";
            this.cdx01_CUSTCD.NameParameterName = "NAME";
            this.cdx01_CUSTCD.NameTextBoxReadOnly = false;
            this.cdx01_CUSTCD.NameTextBoxVisible = true;
            this.cdx01_CUSTCD.PopupButtonReadOnly = false;
            this.cdx01_CUSTCD.PopupTitle = "";
            this.cdx01_CUSTCD.PrefixCode = "";
            this.cdx01_CUSTCD.Size = new System.Drawing.Size(379, 21);
            this.cdx01_CUSTCD.TabIndex = 138;
            this.cdx01_CUSTCD.Tag = null;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(279, 98);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_PARTNO.TabIndex = 141;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(15, 98);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.lbl01_PARTNO.TabIndex = 140;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "Part No (%)";
            // 
            // sfdExcel
            // 
            this.sfdExcel.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdExcel_FileOk);
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel|*.xlsx|Excel|*.xls";
            this.ofdExcel.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdExcel_FileOk);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(507, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 19);
            this.checkBox1.TabIndex = 142;
            this.checkBox1.Text = "Only Different Price";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // axButton2
            // 
            this.axButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.axButton2.BackColor = System.Drawing.Color.Lime;
            this.axButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.axButton2.Location = new System.Drawing.Point(870, 8);
            this.axButton2.Name = "axButton2";
            this.axButton2.Size = new System.Drawing.Size(133, 44);
            this.axButton2.TabIndex = 143;
            this.axButton2.Text = "Confirm Unit Price";
            this.axButton2.UseVisualStyleBackColor = false;
            this.axButton2.Click += new System.EventHandler(this.axButton2_Click);
            // 
            // axTextBox1
            // 
            this.axTextBox1.Location = new System.Drawing.Point(279, 125);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(261, 21);
            this.axTextBox1.TabIndex = 145;
            this.axTextBox1.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(15, 125);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(261, 21);
            this.axLabel1.TabIndex = 144;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Customer\'s PART NO. (%)";
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(659, 125);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(224, 21);
            this.cdx01_VINCD.TabIndex = 147;
            this.cdx01_VINCD.Tag = null;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(556, 125);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VINCD.TabIndex = 146;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "CAR";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 152);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1018, 613);
            this.tabControl1.TabIndex = 148;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.grd01);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1010, 585);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Inquery/Edit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(747, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 23);
            this.button1.TabIndex = 127;
            this.button1.Text = "Import SAP Unit Price from I/F data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(8, 30);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(993, 548);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 126;
            this.grd01.UseCustomHighlight = true;
            this.grd01.Click += new System.EventHandler(this.grd01_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.grd05);
            this.tabPage2.Controls.Add(this.axButton2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1010, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Upload";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(198, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 16);
            this.label1.TabIndex = 144;
            this.label1.Text = "※ SAP Unit Price is be assigned when excel data upload(it is not real-time data)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.axCheckBox1);
            this.groupBox1.Controls.Add(this.axButton1);
            this.groupBox1.Controls.Add(this.axTextBox2);
            this.groupBox1.Controls.Add(this.axLabel4);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 47);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel Upload";
            // 
            // axCheckBox1
            // 
            this.axCheckBox1.AutoSize = true;
            this.axCheckBox1.Checked = true;
            this.axCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.axCheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.axCheckBox1.ForeColor = System.Drawing.Color.Red;
            this.axCheckBox1.Location = new System.Drawing.Point(14, 22);
            this.axCheckBox1.Name = "axCheckBox1";
            this.axCheckBox1.Size = new System.Drawing.Size(152, 19);
            this.axCheckBox1.TabIndex = 129;
            this.axCheckBox1.Text = "Seoyon SAP Format";
            this.axCheckBox1.UseVisualStyleBackColor = true;
            // 
            // axButton1
            // 
            this.axButton1.Location = new System.Drawing.Point(670, 17);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(140, 21);
            this.axButton1.TabIndex = 128;
            this.axButton1.Text = "Excel File Load";
            this.axButton1.UseVisualStyleBackColor = true;
            this.axButton1.Click += new System.EventHandler(this.ExcelLoad);
            // 
            // axTextBox2
            // 
            this.axTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.axTextBox2.Location = new System.Drawing.Point(312, 17);
            this.axTextBox2.Name = "axTextBox2";
            this.axTextBox2.ReadOnly = true;
            this.axTextBox2.Size = new System.Drawing.Size(338, 21);
            this.axTextBox2.TabIndex = 127;
            this.axTextBox2.Tag = null;
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel4.Location = new System.Drawing.Point(192, 17);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(114, 21);
            this.axLabel4.TabIndex = 126;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Exdel File";
            // 
            // grd05
            // 
            this.grd05.AllowHeaderMerging = false;
            this.grd05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd05.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd05.EnabledActionFlag = true;
            this.grd05.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd05.LastRowAdd = false;
            this.grd05.Location = new System.Drawing.Point(7, 73);
            this.grd05.Name = "grd05";
            this.grd05.OriginalFormat = null;
            this.grd05.PopMenuVisible = true;
            this.grd05.Rows.DefaultSize = 18;
            this.grd05.Size = new System.Drawing.Size(996, 504);
            this.grd05.StyleInfo = resources.GetString("grd05.StyleInfo");
            this.grd05.TabIndex = 125;
            this.grd05.UseCustomHighlight = true;
            // 
            // ZSD02120
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cdx01_VINCD);
            this.Controls.Add(this.lbl01_VINCD);
            this.Controls.Add(this.axTextBox1);
            this.Controls.Add(this.axLabel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txt01_PARTNO);
            this.Controls.Add(this.lbl01_PARTNO);
            this.Controls.Add(this.lbl01_CUSTCD);
            this.Controls.Add(this.cdx01_CUSTCD);
            this.Controls.Add(this.axDateEdit1);
            this.Controls.Add(this.axLabel2);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Name = "ZSD02120";
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.axDateEdit1, 0);
            this.Controls.SetChildIndex(this.cdx01_CUSTCD, 0);
            this.Controls.SetChildIndex(this.lbl01_CUSTCD, 0);
            this.Controls.SetChildIndex(this.lbl01_PARTNO, 0);
            this.Controls.SetChildIndex(this.txt01_PARTNO, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.axLabel1, 0);
            this.Controls.SetChildIndex(this.axTextBox1, 0);
            this.Controls.SetChildIndex(this.lbl01_VINCD, 0);
            this.Controls.SetChildIndex(this.cdx01_VINCD, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxDateEdit axDateEdit1;
        private DEV.Utility.Controls.AxLabel lbl01_CUSTCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_CUSTCD;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private System.Windows.Forms.SaveFileDialog sfdExcel;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.CheckBox checkBox1;
        private DEV.Utility.Controls.AxButton axButton2;
        private DEV.Utility.Controls.AxTextBox axTextBox1;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxCheckBox axCheckBox1;
        private DEV.Utility.Controls.AxButton axButton1;
        private DEV.Utility.Controls.AxTextBox axTextBox2;
        private DEV.Utility.Controls.AxLabel axLabel4;
        private DEV.Utility.Controls.AxFlexGrid grd05;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;

    }
}
