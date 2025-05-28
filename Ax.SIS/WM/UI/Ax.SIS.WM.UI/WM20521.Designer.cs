namespace Ax.SIS.WM.UI
{
    partial class WM20521
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
            this.cdx01_PARTNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_DELI_NOTE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_STR_LOC = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_DELI_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DELI_NOTE = new Ax.DEV.Utility.Controls.AxLabel();
            this.df01_TO_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.df01_FROM_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl03_Wave = new System.Windows.Forms.Label();
            this.lbl01_PURC_PO_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PURC_ORG = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PURC_PO_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_PURC_ORG = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_STR_LOC = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btn02_PRINTA4 = new Ax.DEV.Utility.Controls.AxButton();
            this.btn02_PRINTTAG = new Ax.DEV.Utility.Controls.AxButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cbo01_PRINT_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_DELI_CNT = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_DELI_CNT = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_DELI_NOTE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_DELI_NOTE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo01_PRINT_SIZE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_TAG_SIZE = new Ax.DEV.Utility.Controls.AxLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DELI_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PURC_PO_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PURC_ORG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_STR_LOC)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DELI_CNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DELI_CNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DELI_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DELI_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_TAG_SIZE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Location = new System.Drawing.Point(3, 0);
            this._buttonsControl.Size = new System.Drawing.Size(1328, 28);
            // 
            // cdx01_PARTNO
            // 
            this.cdx01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_PARTNO.CodeParameterName = "CODE";
            this.cdx01_PARTNO.CodeTextBoxReadOnly = false;
            this.cdx01_PARTNO.CodeTextBoxVisible = true;
            this.cdx01_PARTNO.CodeTextBoxWidth = 40;
            this.cdx01_PARTNO.HEPopupHelper = null;
            this.cdx01_PARTNO.Location = new System.Drawing.Point(30, 0);
            this.cdx01_PARTNO.Name = "cdx01_PARTNO";
            this.cdx01_PARTNO.NameParameterName = "NAME";
            this.cdx01_PARTNO.NameTextBoxReadOnly = false;
            this.cdx01_PARTNO.NameTextBoxVisible = true;
            this.cdx01_PARTNO.PopupButtonReadOnly = false;
            this.cdx01_PARTNO.PopupTitle = "";
            this.cdx01_PARTNO.PrefixCode = "";
            this.cdx01_PARTNO.Size = new System.Drawing.Size(207, 21);
            this.cdx01_PARTNO.TabIndex = 36;
            this.cdx01_PARTNO.Tag = null;
            // 
            // txt01_DELI_NOTE
            // 
            this.txt01_DELI_NOTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_DELI_NOTE.Location = new System.Drawing.Point(838, 59);
            this.txt01_DELI_NOTE.Name = "txt01_DELI_NOTE";
            this.txt01_DELI_NOTE.Size = new System.Drawing.Size(138, 21);
            this.txt01_DELI_NOTE.TabIndex = 127;
            this.txt01_DELI_NOTE.Tag = null;
            // 
            // lbl01_STR_LOC
            // 
            this.lbl01_STR_LOC.AutoFontSizeMaxValue = 9F;
            this.lbl01_STR_LOC.AutoFontSizeMinValue = 9F;
            this.lbl01_STR_LOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STR_LOC.Location = new System.Drawing.Point(11, 59);
            this.lbl01_STR_LOC.Name = "lbl01_STR_LOC";
            this.lbl01_STR_LOC.Size = new System.Drawing.Size(101, 21);
            this.lbl01_STR_LOC.TabIndex = 126;
            this.lbl01_STR_LOC.Tag = null;
            this.lbl01_STR_LOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_STR_LOC.Value = "Storage Loc";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(340, 30);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(101, 21);
            this.lbl01_BIZNM2.TabIndex = 113;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "Business";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(447, 31);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(118, 20);
            this.cbo01_BIZCD.TabIndex = 112;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = false;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(438, 700);
            this.grd01.TabIndex = 129;
            this.grd01.UseCustomHighlight = true;
            this.grd01.SelChange += new System.EventHandler(this.grd01_Click);
            this.grd01.Click += new System.EventHandler(this.grd01_Click);
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_VENDCD.Location = new System.Drawing.Point(11, 31);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(101, 21);
            this.lbl01_VENDCD.TabIndex = 146;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VENDCD.Value = "Supplier Code";
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
            this.cdx01_VENDCD.Location = new System.Drawing.Point(118, 31);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(216, 21);
            this.cdx01_VENDCD.TabIndex = 145;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_DELI_DATE
            // 
            this.lbl01_DELI_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELI_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_DELI_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DELI_DATE.Location = new System.Drawing.Point(340, 59);
            this.lbl01_DELI_DATE.Name = "lbl01_DELI_DATE";
            this.lbl01_DELI_DATE.Size = new System.Drawing.Size(101, 21);
            this.lbl01_DELI_DATE.TabIndex = 148;
            this.lbl01_DELI_DATE.Tag = null;
            this.lbl01_DELI_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DELI_DATE.Value = "Deliv. Date";
            // 
            // lbl01_DELI_NOTE
            // 
            this.lbl01_DELI_NOTE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELI_NOTE.AutoFontSizeMinValue = 9F;
            this.lbl01_DELI_NOTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DELI_NOTE.Location = new System.Drawing.Point(680, 59);
            this.lbl01_DELI_NOTE.Name = "lbl01_DELI_NOTE";
            this.lbl01_DELI_NOTE.Size = new System.Drawing.Size(152, 21);
            this.lbl01_DELI_NOTE.TabIndex = 149;
            this.lbl01_DELI_NOTE.Tag = null;
            this.lbl01_DELI_NOTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DELI_NOTE.Value = "Deliv.Note No (%)";
            // 
            // df01_TO_DATE
            // 
            this.df01_TO_DATE.CustomFormat = "yyyy-MM-dd";
            this.df01_TO_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.df01_TO_DATE.Location = new System.Drawing.Point(571, 59);
            this.df01_TO_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.df01_TO_DATE.Name = "df01_TO_DATE";
            this.df01_TO_DATE.OriginalFormat = "";
            this.df01_TO_DATE.Size = new System.Drawing.Size(100, 21);
            this.df01_TO_DATE.TabIndex = 151;
            // 
            // df01_FROM_DATE
            // 
            this.df01_FROM_DATE.CustomFormat = "yyyy-MM-dd";
            this.df01_FROM_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.df01_FROM_DATE.Location = new System.Drawing.Point(447, 59);
            this.df01_FROM_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.df01_FROM_DATE.Name = "df01_FROM_DATE";
            this.df01_FROM_DATE.OriginalFormat = "";
            this.df01_FROM_DATE.Size = new System.Drawing.Size(100, 21);
            this.df01_FROM_DATE.TabIndex = 150;
            // 
            // lbl03_Wave
            // 
            this.lbl03_Wave.AutoSize = true;
            this.lbl03_Wave.Location = new System.Drawing.Point(551, 63);
            this.lbl03_Wave.Name = "lbl03_Wave";
            this.lbl03_Wave.Size = new System.Drawing.Size(14, 12);
            this.lbl03_Wave.TabIndex = 152;
            this.lbl03_Wave.Text = "~";
            // 
            // lbl01_PURC_PO_TYPE
            // 
            this.lbl01_PURC_PO_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PURC_PO_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_PURC_PO_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PURC_PO_TYPE.Location = new System.Drawing.Point(680, 31);
            this.lbl01_PURC_PO_TYPE.Name = "lbl01_PURC_PO_TYPE";
            this.lbl01_PURC_PO_TYPE.Size = new System.Drawing.Size(152, 21);
            this.lbl01_PURC_PO_TYPE.TabIndex = 153;
            this.lbl01_PURC_PO_TYPE.Tag = null;
            this.lbl01_PURC_PO_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PURC_PO_TYPE.Value = "Purchase P/O Type";
            // 
            // lbl01_PURC_ORG
            // 
            this.lbl01_PURC_ORG.AutoFontSizeMaxValue = 9F;
            this.lbl01_PURC_ORG.AutoFontSizeMinValue = 9F;
            this.lbl01_PURC_ORG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PURC_ORG.Location = new System.Drawing.Point(982, 31);
            this.lbl01_PURC_ORG.Name = "lbl01_PURC_ORG";
            this.lbl01_PURC_ORG.Size = new System.Drawing.Size(101, 21);
            this.lbl01_PURC_ORG.TabIndex = 154;
            this.lbl01_PURC_ORG.Tag = null;
            this.lbl01_PURC_ORG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PURC_ORG.Value = "Purchase Org.";
            // 
            // cbo01_PURC_PO_TYPE
            // 
            this.cbo01_PURC_PO_TYPE.BackColor = System.Drawing.Color.White;
            this.cbo01_PURC_PO_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PURC_PO_TYPE.FormattingEnabled = true;
            this.cbo01_PURC_PO_TYPE.Location = new System.Drawing.Point(838, 31);
            this.cbo01_PURC_PO_TYPE.Name = "cbo01_PURC_PO_TYPE";
            this.cbo01_PURC_PO_TYPE.Size = new System.Drawing.Size(138, 20);
            this.cbo01_PURC_PO_TYPE.TabIndex = 155;
            // 
            // cbo01_PURC_ORG
            // 
            this.cbo01_PURC_ORG.BackColor = System.Drawing.Color.White;
            this.cbo01_PURC_ORG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PURC_ORG.FormattingEnabled = true;
            this.cbo01_PURC_ORG.Location = new System.Drawing.Point(1089, 31);
            this.cbo01_PURC_ORG.Name = "cbo01_PURC_ORG";
            this.cbo01_PURC_ORG.Size = new System.Drawing.Size(92, 20);
            this.cbo01_PURC_ORG.TabIndex = 156;
            this.cbo01_PURC_ORG.SelectedIndexChanged += new System.EventHandler(this.cbo01_PURC_ORG_SelectedIndexChanged);
            // 
            // cdx01_STR_LOC
            // 
            this.cdx01_STR_LOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_STR_LOC.CodeParameterName = "CODE";
            this.cdx01_STR_LOC.CodeTextBoxReadOnly = false;
            this.cdx01_STR_LOC.CodeTextBoxVisible = true;
            this.cdx01_STR_LOC.CodeTextBoxWidth = 60;
            this.cdx01_STR_LOC.HEPopupHelper = null;
            this.cdx01_STR_LOC.Location = new System.Drawing.Point(118, 59);
            this.cdx01_STR_LOC.Name = "cdx01_STR_LOC";
            this.cdx01_STR_LOC.NameParameterName = "NAME";
            this.cdx01_STR_LOC.NameTextBoxReadOnly = false;
            this.cdx01_STR_LOC.NameTextBoxVisible = true;
            this.cdx01_STR_LOC.PopupButtonReadOnly = false;
            this.cdx01_STR_LOC.PopupTitle = "";
            this.cdx01_STR_LOC.PrefixCode = "";
            this.cdx01_STR_LOC.Size = new System.Drawing.Size(216, 21);
            this.cdx01_STR_LOC.TabIndex = 157;
            this.cdx01_STR_LOC.Tag = null;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 789);
            this.splitter1.TabIndex = 158;
            this.splitter1.TabStop = false;
            // 
            // btn02_PRINTA4
            // 
            this.btn02_PRINTA4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn02_PRINTA4.BackColor = System.Drawing.Color.Lime;
            this.btn02_PRINTA4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn02_PRINTA4.Location = new System.Drawing.Point(514, 5);
            this.btn02_PRINTA4.Name = "btn02_PRINTA4";
            this.btn02_PRINTA4.Size = new System.Drawing.Size(174, 56);
            this.btn02_PRINTA4.TabIndex = 125;
            this.btn02_PRINTA4.Text = "A4 Print";
            this.btn02_PRINTA4.UseVisualStyleBackColor = false;
            this.btn02_PRINTA4.Click += new System.EventHandler(this.btn01_PRINTA4_Click);
            // 
            // btn02_PRINTTAG
            // 
            this.btn02_PRINTTAG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn02_PRINTTAG.BackColor = System.Drawing.Color.Yellow;
            this.btn02_PRINTTAG.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn02_PRINTTAG.Location = new System.Drawing.Point(698, 5);
            this.btn02_PRINTTAG.Name = "btn02_PRINTTAG";
            this.btn02_PRINTTAG.Size = new System.Drawing.Size(171, 56);
            this.btn02_PRINTTAG.TabIndex = 149;
            this.btn02_PRINTTAG.Text = "Barcode Print";
            this.btn02_PRINTTAG.UseVisualStyleBackColor = false;
            this.btn02_PRINTTAG.Click += new System.EventHandler(this.btn01_PRINTTAG_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.grd02);
            this.panel1.Controls.Add(this.cbo01_PRINT_TYPE);
            this.panel1.Controls.Add(this.lbl02_DELI_CNT);
            this.panel1.Controls.Add(this.txt02_DELI_CNT);
            this.panel1.Controls.Add(this.lbl02_DELI_NOTE);
            this.panel1.Controls.Add(this.txt02_DELI_NOTE);
            this.panel1.Controls.Add(this.cbo01_PRINT_SIZE);
            this.panel1.Controls.Add(this.btn02_PRINTTAG);
            this.panel1.Controls.Add(this.lbl02_TAG_SIZE);
            this.panel1.Controls.Add(this.btn02_PRINTA4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 700);
            this.panel1.TabIndex = 128;
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
            this.grd02.Location = new System.Drawing.Point(3, 64);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = false;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(866, 631);
            this.grd02.TabIndex = 157;
            this.grd02.UseCustomHighlight = true;
            this.grd02.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseClick);
            // 
            // cbo01_PRINT_TYPE
            // 
            this.cbo01_PRINT_TYPE.DisplayMember = "Y";
            this.cbo01_PRINT_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRINT_TYPE.FormattingEnabled = true;
            this.cbo01_PRINT_TYPE.Location = new System.Drawing.Point(267, 38);
            this.cbo01_PRINT_TYPE.Name = "cbo01_PRINT_TYPE";
            this.cbo01_PRINT_TYPE.Size = new System.Drawing.Size(101, 20);
            this.cbo01_PRINT_TYPE.TabIndex = 156;
            // 
            // lbl02_DELI_CNT
            // 
            this.lbl02_DELI_CNT.AutoFontSizeMaxValue = 9F;
            this.lbl02_DELI_CNT.AutoFontSizeMinValue = 9F;
            this.lbl02_DELI_CNT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_DELI_CNT.Location = new System.Drawing.Point(266, 7);
            this.lbl02_DELI_CNT.Name = "lbl02_DELI_CNT";
            this.lbl02_DELI_CNT.Size = new System.Drawing.Size(101, 21);
            this.lbl02_DELI_CNT.TabIndex = 153;
            this.lbl02_DELI_CNT.Tag = null;
            this.lbl02_DELI_CNT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_DELI_CNT.Value = "Deliv.Note Seq";
            // 
            // txt02_DELI_CNT
            // 
            this.txt02_DELI_CNT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_DELI_CNT.Location = new System.Drawing.Point(373, 7);
            this.txt02_DELI_CNT.Name = "txt02_DELI_CNT";
            this.txt02_DELI_CNT.ReadOnly = true;
            this.txt02_DELI_CNT.Size = new System.Drawing.Size(55, 21);
            this.txt02_DELI_CNT.TabIndex = 152;
            this.txt02_DELI_CNT.Tag = null;
            // 
            // lbl02_DELI_NOTE
            // 
            this.lbl02_DELI_NOTE.AutoFontSizeMaxValue = 9F;
            this.lbl02_DELI_NOTE.AutoFontSizeMinValue = 9F;
            this.lbl02_DELI_NOTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_DELI_NOTE.Location = new System.Drawing.Point(7, 7);
            this.lbl02_DELI_NOTE.Name = "lbl02_DELI_NOTE";
            this.lbl02_DELI_NOTE.Size = new System.Drawing.Size(101, 21);
            this.lbl02_DELI_NOTE.TabIndex = 151;
            this.lbl02_DELI_NOTE.Tag = null;
            this.lbl02_DELI_NOTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_DELI_NOTE.Value = "Deliv.Note No";
            // 
            // txt02_DELI_NOTE
            // 
            this.txt02_DELI_NOTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_DELI_NOTE.Location = new System.Drawing.Point(114, 7);
            this.txt02_DELI_NOTE.Name = "txt02_DELI_NOTE";
            this.txt02_DELI_NOTE.ReadOnly = true;
            this.txt02_DELI_NOTE.Size = new System.Drawing.Size(138, 21);
            this.txt02_DELI_NOTE.TabIndex = 150;
            this.txt02_DELI_NOTE.Tag = null;
            this.txt02_DELI_NOTE.Value = "";
            // 
            // cbo01_PRINT_SIZE
            // 
            this.cbo01_PRINT_SIZE.BackColor = System.Drawing.Color.White;
            this.cbo01_PRINT_SIZE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRINT_SIZE.FormattingEnabled = true;
            this.cbo01_PRINT_SIZE.Location = new System.Drawing.Point(114, 38);
            this.cbo01_PRINT_SIZE.Name = "cbo01_PRINT_SIZE";
            this.cbo01_PRINT_SIZE.Size = new System.Drawing.Size(138, 20);
            this.cbo01_PRINT_SIZE.TabIndex = 155;
            // 
            // lbl02_TAG_SIZE
            // 
            this.lbl02_TAG_SIZE.AutoFontSizeMaxValue = 9F;
            this.lbl02_TAG_SIZE.AutoFontSizeMinValue = 9F;
            this.lbl02_TAG_SIZE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_TAG_SIZE.Location = new System.Drawing.Point(7, 38);
            this.lbl02_TAG_SIZE.Name = "lbl02_TAG_SIZE";
            this.lbl02_TAG_SIZE.Size = new System.Drawing.Size(101, 21);
            this.lbl02_TAG_SIZE.TabIndex = 153;
            this.lbl02_TAG_SIZE.Tag = null;
            this.lbl02_TAG_SIZE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_TAG_SIZE.Value = "TAG SIZE";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 86);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grd01);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1319, 700);
            this.splitContainer1.SplitterDistance = 438;
            this.splitContainer1.TabIndex = 159;
            // 
            // WM20521
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.cdx01_STR_LOC);
            this.Controls.Add(this.cbo01_PURC_ORG);
            this.Controls.Add(this.cbo01_PURC_PO_TYPE);
            this.Controls.Add(this.lbl01_PURC_ORG);
            this.Controls.Add(this.lbl01_PURC_PO_TYPE);
            this.Controls.Add(this.lbl03_Wave);
            this.Controls.Add(this.df01_TO_DATE);
            this.Controls.Add(this.df01_FROM_DATE);
            this.Controls.Add(this.lbl01_DELI_NOTE);
            this.Controls.Add(this.lbl01_DELI_DATE);
            this.Controls.Add(this.lbl01_VENDCD);
            this.Controls.Add(this.cdx01_VENDCD);
            this.Controls.Add(this.lbl01_STR_LOC);
            this.Controls.Add(this.txt01_DELI_NOTE);
            this.Controls.Add(this.cdx01_PARTNO);
            this.Controls.Add(this.lbl01_BIZNM2);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WM20521";
            this.Size = new System.Drawing.Size(1331, 789);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZNM2, 0);
            this.Controls.SetChildIndex(this.cdx01_PARTNO, 0);
            this.Controls.SetChildIndex(this.txt01_DELI_NOTE, 0);
            this.Controls.SetChildIndex(this.lbl01_STR_LOC, 0);
            this.Controls.SetChildIndex(this.cdx01_VENDCD, 0);
            this.Controls.SetChildIndex(this.lbl01_VENDCD, 0);
            this.Controls.SetChildIndex(this.lbl01_DELI_DATE, 0);
            this.Controls.SetChildIndex(this.lbl01_DELI_NOTE, 0);
            this.Controls.SetChildIndex(this.df01_FROM_DATE, 0);
            this.Controls.SetChildIndex(this.df01_TO_DATE, 0);
            this.Controls.SetChildIndex(this.lbl03_Wave, 0);
            this.Controls.SetChildIndex(this.lbl01_PURC_PO_TYPE, 0);
            this.Controls.SetChildIndex(this.lbl01_PURC_ORG, 0);
            this.Controls.SetChildIndex(this.cbo01_PURC_PO_TYPE, 0);
            this.Controls.SetChildIndex(this.cbo01_PURC_ORG, 0);
            this.Controls.SetChildIndex(this.cdx01_STR_LOC, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DELI_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PURC_PO_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PURC_ORG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_STR_LOC)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DELI_CNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DELI_CNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DELI_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DELI_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_TAG_SIZE)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_PARTNO;
        private DEV.Utility.Controls.AxTextBox txt01_DELI_NOTE;
        private DEV.Utility.Controls.AxLabel lbl01_STR_LOC;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxLabel lbl01_DELI_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_DELI_NOTE;
        private DEV.Utility.Controls.AxDateEdit df01_TO_DATE;
        private DEV.Utility.Controls.AxDateEdit df01_FROM_DATE;
        private System.Windows.Forms.Label lbl03_Wave;
        private DEV.Utility.Controls.AxLabel lbl01_PURC_PO_TYPE;
        private DEV.Utility.Controls.AxLabel lbl01_PURC_ORG;
        private DEV.Utility.Controls.AxComboBox cbo01_PURC_PO_TYPE;
        private DEV.Utility.Controls.AxComboBox cbo01_PURC_ORG;
        private DEV.Utility.Controls.AxCodeBox cdx01_STR_LOC;
        private System.Windows.Forms.Splitter splitter1;
        private DEV.Utility.Controls.AxButton btn02_PRINTA4;
        private DEV.Utility.Controls.AxButton btn02_PRINTTAG;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxLabel lbl02_DELI_CNT;
        private DEV.Utility.Controls.AxTextBox txt02_DELI_CNT;
        private DEV.Utility.Controls.AxLabel lbl02_DELI_NOTE;
        private DEV.Utility.Controls.AxTextBox txt02_DELI_NOTE;
        private DEV.Utility.Controls.AxComboBox cbo01_PRINT_SIZE;
        private DEV.Utility.Controls.AxLabel lbl02_TAG_SIZE;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DEV.Utility.Controls.AxComboBox cbo01_PRINT_TYPE;
        private DEV.Utility.Controls.AxFlexGrid grd02;
    }
}
