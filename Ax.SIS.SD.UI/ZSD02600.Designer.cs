namespace Ax.SIS.SD.UI
{
    partial class ZSD02600
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZSD02600));
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.grp01 = new System.Windows.Forms.GroupBox();
            this.Chk_AutoDel = new System.Windows.Forms.CheckBox();
            this.btn01_FILE_READ = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_FILE_FIND = new Ax.DEV.Utility.Controls.AxButton();
            this.txt_FILE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl_FIEL = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Web = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lbl_PARTNO = new System.Windows.Forms.Label();
            this.Lbl_ZHSNSAC = new System.Windows.Forms.Label();
            this.Lbl_EBELN = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EBELN = new System.Windows.Forms.Label();
            this.btn01_FILE_SAVE = new Ax.DEV.Utility.Controls.AxButton();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.Lbl_InvCount = new System.Windows.Forms.Label();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.Txt_Car = new System.Windows.Forms.TextBox();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbl01_CustPLANT = new Ax.DEV.Utility.Controls.AxComboList();
            this.axLabel5 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel6 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RD_ERR = new System.Windows.Forms.RadioButton();
            this.Chk_car = new System.Windows.Forms.CheckBox();
            this.RD_AF = new System.Windows.Forms.RadioButton();
            this.RD_NF = new System.Windows.Forms.RadioButton();
            this.RD_ALL = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            this.grp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FILE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_FIEL)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustPLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel6)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.axLabel2.Location = new System.Drawing.Point(283, 43);
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
            this.axDateEdit1.Location = new System.Drawing.Point(429, 42);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(100, 21);
            this.axDateEdit1.TabIndex = 119;
            // 
            // grp01
            // 
            this.grp01.Controls.Add(this.Chk_AutoDel);
            this.grp01.Controls.Add(this.btn01_FILE_READ);
            this.grp01.Controls.Add(this.btn01_FILE_FIND);
            this.grp01.Controls.Add(this.txt_FILE);
            this.grp01.Controls.Add(this.lbl_FIEL);
            this.grp01.Location = new System.Drawing.Point(17, 97);
            this.grp01.Name = "grp01";
            this.grp01.Size = new System.Drawing.Size(1004, 48);
            this.grp01.TabIndex = 140;
            this.grp01.TabStop = false;
            // 
            // Chk_AutoDel
            // 
            this.Chk_AutoDel.AutoSize = true;
            this.Chk_AutoDel.Checked = true;
            this.Chk_AutoDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_AutoDel.Location = new System.Drawing.Point(909, 20);
            this.Chk_AutoDel.Name = "Chk_AutoDel";
            this.Chk_AutoDel.Size = new System.Drawing.Size(72, 19);
            this.Chk_AutoDel.TabIndex = 143;
            this.Chk_AutoDel.Text = "A/Delete";
            this.Chk_AutoDel.UseVisualStyleBackColor = true;
            // 
            // btn01_FILE_READ
            // 
            this.btn01_FILE_READ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_FILE_READ.Location = new System.Drawing.Point(713, 17);
            this.btn01_FILE_READ.Name = "btn01_FILE_READ";
            this.btn01_FILE_READ.Size = new System.Drawing.Size(82, 23);
            this.btn01_FILE_READ.TabIndex = 141;
            this.btn01_FILE_READ.Text = "READ";
            this.btn01_FILE_READ.UseVisualStyleBackColor = true;
            this.btn01_FILE_READ.Visible = false;
            this.btn01_FILE_READ.Click += new System.EventHandler(this.btn01_FILE_READ_Click);
            // 
            // btn01_FILE_FIND
            // 
            this.btn01_FILE_FIND.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_FILE_FIND.Location = new System.Drawing.Point(801, 17);
            this.btn01_FILE_FIND.Name = "btn01_FILE_FIND";
            this.btn01_FILE_FIND.Size = new System.Drawing.Size(83, 23);
            this.btn01_FILE_FIND.TabIndex = 142;
            this.btn01_FILE_FIND.Text = "FIND";
            this.btn01_FILE_FIND.UseVisualStyleBackColor = true;
            this.btn01_FILE_FIND.Click += new System.EventHandler(this.btn01_FILE_FIND_Click);
            // 
            // txt_FILE
            // 
            this.txt_FILE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FILE.Location = new System.Drawing.Point(114, 18);
            this.txt_FILE.Name = "txt_FILE";
            this.txt_FILE.Size = new System.Drawing.Size(593, 21);
            this.txt_FILE.TabIndex = 140;
            this.txt_FILE.Tag = null;
            // 
            // lbl_FIEL
            // 
            this.lbl_FIEL.AutoFontSizeMaxValue = 9F;
            this.lbl_FIEL.AutoFontSizeMinValue = 9F;
            this.lbl_FIEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl_FIEL.Location = new System.Drawing.Point(3, 18);
            this.lbl_FIEL.Name = "lbl_FIEL";
            this.lbl_FIEL.Size = new System.Drawing.Size(105, 21);
            this.lbl_FIEL.TabIndex = 139;
            this.lbl_FIEL.Tag = null;
            this.lbl_FIEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FIEL.Value = "FILE";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Lbl_Web);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btn01_FILE_SAVE);
            this.groupBox1.Controls.Add(this.grd02);
            this.groupBox1.Controls.Add(this.Lbl_InvCount);
            this.groupBox1.Controls.Add(this.axLabel1);
            this.groupBox1.Location = new System.Drawing.Point(588, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 614);
            this.groupBox1.TabIndex = 141;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PDF Invoice Information";
            // 
            // Lbl_Web
            // 
            this.Lbl_Web.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Web.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Web.Location = new System.Drawing.Point(6, 484);
            this.Lbl_Web.Name = "Lbl_Web";
            this.Lbl_Web.Size = new System.Drawing.Size(421, 17);
            this.Lbl_Web.TabIndex = 146;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Lbl_PARTNO);
            this.panel1.Controls.Add(this.Lbl_ZHSNSAC);
            this.panel1.Controls.Add(this.Lbl_EBELN);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.EBELN);
            this.panel1.Location = new System.Drawing.Point(6, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 104);
            this.panel1.TabIndex = 145;
            // 
            // Lbl_PARTNO
            // 
            this.Lbl_PARTNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_PARTNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_PARTNO.Location = new System.Drawing.Point(74, 65);
            this.Lbl_PARTNO.Name = "Lbl_PARTNO";
            this.Lbl_PARTNO.Size = new System.Drawing.Size(305, 19);
            this.Lbl_PARTNO.TabIndex = 144;
            this.Lbl_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_ZHSNSAC
            // 
            this.Lbl_ZHSNSAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_ZHSNSAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_ZHSNSAC.Location = new System.Drawing.Point(74, 35);
            this.Lbl_ZHSNSAC.Name = "Lbl_ZHSNSAC";
            this.Lbl_ZHSNSAC.Size = new System.Drawing.Size(305, 19);
            this.Lbl_ZHSNSAC.TabIndex = 143;
            this.Lbl_ZHSNSAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_EBELN
            // 
            this.Lbl_EBELN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_EBELN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_EBELN.Location = new System.Drawing.Point(74, 5);
            this.Lbl_EBELN.Name = "Lbl_EBELN";
            this.Lbl_EBELN.Size = new System.Drawing.Size(305, 19);
            this.Lbl_EBELN.TabIndex = 142;
            this.Lbl_EBELN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "MIP PNO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "HSN";
            // 
            // EBELN
            // 
            this.EBELN.AutoSize = true;
            this.EBELN.Location = new System.Drawing.Point(5, 5);
            this.EBELN.Name = "EBELN";
            this.EBELN.Size = new System.Drawing.Size(24, 15);
            this.EBELN.TabIndex = 0;
            this.EBELN.Text = "PO";
            // 
            // btn01_FILE_SAVE
            // 
            this.btn01_FILE_SAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_FILE_SAVE.BackColor = System.Drawing.Color.Yellow;
            this.btn01_FILE_SAVE.Location = new System.Drawing.Point(304, 20);
            this.btn01_FILE_SAVE.Name = "btn01_FILE_SAVE";
            this.btn01_FILE_SAVE.Size = new System.Drawing.Size(123, 35);
            this.btn01_FILE_SAVE.TabIndex = 144;
            this.btn01_FILE_SAVE.Text = "KIN I/F";
            this.btn01_FILE_SAVE.UseVisualStyleBackColor = false;
            this.btn01_FILE_SAVE.Click += new System.EventHandler(this.btn01_FILE_SAVE_Click);
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(6, 61);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(421, 420);
            this.grd02.StyleInfo = resources.GetString("grd02.StyleInfo");
            this.grd02.TabIndex = 143;
            this.grd02.UseCustomHighlight = true;
            this.grd02.DoubleClick += new System.EventHandler(this.grd02_DoubleClick);
            // 
            // Lbl_InvCount
            // 
            this.Lbl_InvCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_InvCount.Location = new System.Drawing.Point(206, 28);
            this.Lbl_InvCount.Name = "Lbl_InvCount";
            this.Lbl_InvCount.Size = new System.Drawing.Size(77, 19);
            this.Lbl_InvCount.TabIndex = 141;
            this.Lbl_InvCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(6, 28);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(194, 21);
            this.axLabel1.TabIndex = 140;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Invoice Count";
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.EnabledActionFlag = true;
            this.grd03.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd03.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(17, 191);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(565, 574);
            this.grd03.StyleInfo = resources.GetString("grd03.StyleInfo");
            this.grd03.TabIndex = 142;
            this.grd03.UseCustomHighlight = true;
            this.grd03.DoubleClick += new System.EventHandler(this.grd03_DoubleClick);
            // 
            // Txt_Car
            // 
            this.Txt_Car.Location = new System.Drawing.Point(128, 73);
            this.Txt_Car.Name = "Txt_Car";
            this.Txt_Car.Size = new System.Drawing.Size(165, 21);
            this.Txt_Car.TabIndex = 143;
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(17, 73);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(104, 21);
            this.axLabel3.TabIndex = 142;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "Truck No.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(406, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 21);
            this.textBox1.TabIndex = 145;
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel4.Location = new System.Drawing.Point(295, 73);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(104, 21);
            this.axLabel4.TabIndex = 144;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Invoice";
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(720, 42);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(278, 21);
            this.cdx01_VENDCD.TabIndex = 152;
            this.cdx01_VENDCD.Tag = null;
            // 
            // cbl01_CustPLANT
            // 
            this.cbl01_CustPLANT.AddItemSeparator = ';';
            this.cbl01_CustPLANT.Caption = "";
            this.cbl01_CustPLANT.CaptionHeight = 17;
            this.cbl01_CustPLANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_CustPLANT.ColumnCaptionHeight = 18;
            this.cbl01_CustPLANT.ColumnFooterHeight = 18;
            this.cbl01_CustPLANT.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbl01_CustPLANT.ContentHeight = 16;
            this.cbl01_CustPLANT.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_CustPLANT.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_CustPLANT.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_CustPLANT.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_CustPLANT.EditorHeight = 16;
            this.cbl01_CustPLANT.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_CustPLANT.Images"))));
            this.cbl01_CustPLANT.ItemHeight = 15;
            this.cbl01_CustPLANT.Location = new System.Drawing.Point(738, 69);
            this.cbl01_CustPLANT.MatchEntryTimeout = ((long)(2000));
            this.cbl01_CustPLANT.MaxDropDownItems = ((short)(5));
            this.cbl01_CustPLANT.MaxLength = 32767;
            this.cbl01_CustPLANT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_CustPLANT.Name = "cbl01_CustPLANT";
            this.cbl01_CustPLANT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_CustPLANT.Size = new System.Drawing.Size(260, 22);
            this.cbl01_CustPLANT.TabIndex = 151;
            this.cbl01_CustPLANT.PropBag = resources.GetString("cbl01_CustPLANT.PropBag");
            // 
            // axLabel5
            // 
            this.axLabel5.AutoFontSizeMaxValue = 9F;
            this.axLabel5.AutoFontSizeMinValue = 9F;
            this.axLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel5.Location = new System.Drawing.Point(577, 71);
            this.axLabel5.Name = "axLabel5";
            this.axLabel5.Size = new System.Drawing.Size(155, 21);
            this.axLabel5.TabIndex = 150;
            this.axLabel5.Tag = null;
            this.axLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel5.Value = "C/PLANT";
            // 
            // axLabel6
            // 
            this.axLabel6.AutoFontSizeMaxValue = 9F;
            this.axLabel6.AutoFontSizeMinValue = 9F;
            this.axLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel6.Location = new System.Drawing.Point(545, 41);
            this.axLabel6.Name = "axLabel6";
            this.axLabel6.Size = new System.Drawing.Size(169, 21);
            this.axLabel6.TabIndex = 149;
            this.axLabel6.Tag = null;
            this.axLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel6.Value = "Customer";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RD_ERR);
            this.groupBox2.Controls.Add(this.Chk_car);
            this.groupBox2.Controls.Add(this.RD_AF);
            this.groupBox2.Controls.Add(this.RD_NF);
            this.groupBox2.Controls.Add(this.RD_ALL);
            this.groupBox2.Location = new System.Drawing.Point(15, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 37);
            this.groupBox2.TabIndex = 153;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Condition";
            // 
            // RD_ERR
            // 
            this.RD_ERR.AutoSize = true;
            this.RD_ERR.ForeColor = System.Drawing.Color.Red;
            this.RD_ERR.Location = new System.Drawing.Point(213, 12);
            this.RD_ERR.Name = "RD_ERR";
            this.RD_ERR.Size = new System.Drawing.Size(95, 19);
            this.RD_ERR.TabIndex = 4;
            this.RD_ERR.Text = "ERRROR-I/F";
            this.RD_ERR.UseVisualStyleBackColor = true;
            this.RD_ERR.CheckedChanged += new System.EventHandler(this.RD_AF_CheckedChanged);
            // 
            // Chk_car
            // 
            this.Chk_car.AutoSize = true;
            this.Chk_car.Checked = true;
            this.Chk_car.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_car.Location = new System.Drawing.Point(418, 12);
            this.Chk_car.Name = "Chk_car";
            this.Chk_car.Size = new System.Drawing.Size(142, 19);
            this.Chk_car.TabIndex = 3;
            this.Chk_car.Text = "Base On Car / Invoice";
            this.Chk_car.UseVisualStyleBackColor = true;
            // 
            // RD_AF
            // 
            this.RD_AF.AutoSize = true;
            this.RD_AF.BackColor = System.Drawing.Color.Lime;
            this.RD_AF.Location = new System.Drawing.Point(316, 12);
            this.RD_AF.Name = "RD_AF";
            this.RD_AF.Size = new System.Drawing.Size(82, 19);
            this.RD_AF.TabIndex = 2;
            this.RD_AF.Text = "Already-I/F";
            this.RD_AF.UseVisualStyleBackColor = false;
            this.RD_AF.CheckedChanged += new System.EventHandler(this.RD_AF_CheckedChanged);
            // 
            // RD_NF
            // 
            this.RD_NF.AutoSize = true;
            this.RD_NF.Checked = true;
            this.RD_NF.Location = new System.Drawing.Point(142, 12);
            this.RD_NF.Name = "RD_NF";
            this.RD_NF.Size = new System.Drawing.Size(65, 19);
            this.RD_NF.TabIndex = 1;
            this.RD_NF.TabStop = true;
            this.RD_NF.Text = "Non-I/F";
            this.RD_NF.UseVisualStyleBackColor = true;
            this.RD_NF.CheckedChanged += new System.EventHandler(this.RD_AF_CheckedChanged);
            // 
            // RD_ALL
            // 
            this.RD_ALL.AutoSize = true;
            this.RD_ALL.Location = new System.Drawing.Point(90, 12);
            this.RD_ALL.Name = "RD_ALL";
            this.RD_ALL.Size = new System.Drawing.Size(38, 19);
            this.RD_ALL.TabIndex = 0;
            this.RD_ALL.Text = "All";
            this.RD_ALL.UseVisualStyleBackColor = true;
            this.RD_ALL.CheckedChanged += new System.EventHandler(this.RD_AF_CheckedChanged);
            // 
            // ZSD02600
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cdx01_VENDCD);
            this.Controls.Add(this.cbl01_CustPLANT);
            this.Controls.Add(this.axLabel5);
            this.Controls.Add(this.axLabel6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.axLabel4);
            this.Controls.Add(this.Txt_Car);
            this.Controls.Add(this.grd03);
            this.Controls.Add(this.axLabel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp01);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.axDateEdit1);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.axLabel2);
            this.Name = "ZSD02600";
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.axDateEdit1, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.grp01, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.axLabel3, 0);
            this.Controls.SetChildIndex(this.grd03, 0);
            this.Controls.SetChildIndex(this.Txt_Car, 0);
            this.Controls.SetChildIndex(this.axLabel4, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.axLabel6, 0);
            this.Controls.SetChildIndex(this.axLabel5, 0);
            this.Controls.SetChildIndex(this.cbl01_CustPLANT, 0);
            this.Controls.SetChildIndex(this.cdx01_VENDCD, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            this.grp01.ResumeLayout(false);
            this.grp01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FILE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_FIEL)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustPLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel6)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxDateEdit axDateEdit1;
        private System.Windows.Forms.GroupBox grp01;
        private DEV.Utility.Controls.AxButton btn01_FILE_READ;
        private DEV.Utility.Controls.AxButton btn01_FILE_FIND;
        private DEV.Utility.Controls.AxTextBox txt_FILE;
        private DEV.Utility.Controls.AxLabel lbl_FIEL;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private System.Windows.Forms.Label Lbl_InvCount;
        private DEV.Utility.Controls.AxFlexGrid grd03;
        private System.Windows.Forms.TextBox Txt_Car;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private System.Windows.Forms.TextBox textBox1;
        private DEV.Utility.Controls.AxLabel axLabel4;
        private DEV.Utility.Controls.AxButton btn01_FILE_SAVE;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxComboList cbl01_CustPLANT;
        private DEV.Utility.Controls.AxLabel axLabel5;
        private DEV.Utility.Controls.AxLabel axLabel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl_PARTNO;
        private System.Windows.Forms.Label Lbl_ZHSNSAC;
        private System.Windows.Forms.Label Lbl_EBELN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EBELN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RD_AF;
        private System.Windows.Forms.RadioButton RD_NF;
        private System.Windows.Forms.RadioButton RD_ALL;
        private System.Windows.Forms.CheckBox Chk_car;
        private System.Windows.Forms.CheckBox Chk_AutoDel;
        private System.Windows.Forms.Label Lbl_Web;
        private System.Windows.Forms.RadioButton RD_ERR;

    }
}
