namespace Ax.SIS.PD.UI
{
    partial class PD20115
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20115));
            this.grpbox1_STANDARD_INFO = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl01_PROCCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PROCCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grpbox1_STANDARD_INFO_DETAIL = new System.Windows.Forms.GroupBox();
            this.cbl02_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl02_PROCCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl02_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.btn02_CONFIRM = new Ax.DEV.Utility.Controls.AxButton();
            this.btn02_REGIST = new Ax.DEV.Utility.Controls.AxButton();
            this.txt02_FILE_NAME = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_FILE_NAME5 = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_FILE_SIZE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_DISP_SEQ = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_INSTALL_POS = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_FILE_SIZE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_PRINT_SEQ = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_PROCCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grpbox1_STANDARD_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_PROCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).BeginInit();
            this.grpbox1_STANDARD_INFO_DETAIL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_PROCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_FILE_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_FILE_NAME5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_FILE_SIZE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DISP_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_FILE_SIZE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PRINT_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PROCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINECD)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbox1_STANDARD_INFO
            // 
            this.grpbox1_STANDARD_INFO.Controls.Add(this.grd01);
            this.grpbox1_STANDARD_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbox1_STANDARD_INFO.Location = new System.Drawing.Point(0, 74);
            this.grpbox1_STANDARD_INFO.Name = "grpbox1_STANDARD_INFO";
            this.grpbox1_STANDARD_INFO.Size = new System.Drawing.Size(1024, 574);
            this.grpbox1_STANDARD_INFO.TabIndex = 8;
            this.grpbox1_STANDARD_INFO.TabStop = false;
            this.grpbox1_STANDARD_INFO.Text = "공정별 작업표준서 정보";
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
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 554);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbl01_INSTALL_POS);
            this.groupBox1.Controls.Add(this.cbl01_PROCCD);
            this.groupBox1.Controls.Add(this.cbl01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_INSTALL_POS);
            this.groupBox1.Controls.Add(this.lbl01_PROCCD);
            this.groupBox1.Controls.Add(this.lbl01_LINE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbl01_INSTALL_POS
            // 
            this.cbl01_INSTALL_POS.AddItemSeparator = ';';
            this.cbl01_INSTALL_POS.Caption = "";
            this.cbl01_INSTALL_POS.CaptionHeight = 17;
            this.cbl01_INSTALL_POS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_INSTALL_POS.ColumnCaptionHeight = 18;
            this.cbl01_INSTALL_POS.ColumnFooterHeight = 18;
            this.cbl01_INSTALL_POS.ContentHeight = 16;
            this.cbl01_INSTALL_POS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_INSTALL_POS.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_INSTALL_POS.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_INSTALL_POS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_INSTALL_POS.EditorHeight = 16;
            this.cbl01_INSTALL_POS.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_INSTALL_POS.Images"))));
            this.cbl01_INSTALL_POS.ItemHeight = 15;
            this.cbl01_INSTALL_POS.Location = new System.Drawing.Point(717, 11);
            this.cbl01_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl01_INSTALL_POS.MaxLength = 32767;
            this.cbl01_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INSTALL_POS.Name = "cbl01_INSTALL_POS";
            this.cbl01_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INSTALL_POS.Size = new System.Drawing.Size(161, 22);
            this.cbl01_INSTALL_POS.TabIndex = 72;
            this.cbl01_INSTALL_POS.PropBag = resources.GetString("cbl01_INSTALL_POS.PropBag");
            // 
            // cbl01_PROCCD
            // 
            this.cbl01_PROCCD.AddItemSeparator = ';';
            this.cbl01_PROCCD.Caption = "";
            this.cbl01_PROCCD.CaptionHeight = 17;
            this.cbl01_PROCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_PROCCD.ColumnCaptionHeight = 18;
            this.cbl01_PROCCD.ColumnFooterHeight = 18;
            this.cbl01_PROCCD.ContentHeight = 16;
            this.cbl01_PROCCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_PROCCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_PROCCD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_PROCCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_PROCCD.EditorHeight = 16;
            this.cbl01_PROCCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_PROCCD.Images"))));
            this.cbl01_PROCCD.ItemHeight = 15;
            this.cbl01_PROCCD.Location = new System.Drawing.Point(444, 11);
            this.cbl01_PROCCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_PROCCD.MaxDropDownItems = ((short)(5));
            this.cbl01_PROCCD.MaxLength = 32767;
            this.cbl01_PROCCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_PROCCD.Name = "cbl01_PROCCD";
            this.cbl01_PROCCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_PROCCD.Size = new System.Drawing.Size(161, 22);
            this.cbl01_PROCCD.TabIndex = 71;
            this.cbl01_PROCCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_PROCCD_BeforeOpen);
            this.cbl01_PROCCD.PropBag = resources.GetString("cbl01_PROCCD.PropBag");
            // 
            // cbl01_LINECD
            // 
            this.cbl01_LINECD.AddItemSeparator = ';';
            this.cbl01_LINECD.Caption = "";
            this.cbl01_LINECD.CaptionHeight = 17;
            this.cbl01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_LINECD.ColumnCaptionHeight = 18;
            this.cbl01_LINECD.ColumnFooterHeight = 18;
            this.cbl01_LINECD.ContentHeight = 16;
            this.cbl01_LINECD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_LINECD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_LINECD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_LINECD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_LINECD.EditorHeight = 16;
            this.cbl01_LINECD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_LINECD.Images"))));
            this.cbl01_LINECD.ItemHeight = 15;
            this.cbl01_LINECD.Location = new System.Drawing.Point(112, 11);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(220, 22);
            this.cbl01_LINECD.TabIndex = 70;
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // lbl01_INSTALL_POS
            // 
            this.lbl01_INSTALL_POS.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSTALL_POS.AutoFontSizeMinValue = 9F;
            this.lbl01_INSTALL_POS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INSTALL_POS.Location = new System.Drawing.Point(611, 12);
            this.lbl01_INSTALL_POS.Name = "lbl01_INSTALL_POS";
            this.lbl01_INSTALL_POS.Size = new System.Drawing.Size(100, 21);
            this.lbl01_INSTALL_POS.TabIndex = 69;
            this.lbl01_INSTALL_POS.Tag = null;
            this.lbl01_INSTALL_POS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSTALL_POS.Value = "장착위치";
            // 
            // lbl01_PROCCD
            // 
            this.lbl01_PROCCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_PROCCD.AutoFontSizeMinValue = 9F;
            this.lbl01_PROCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PROCCD.Location = new System.Drawing.Point(338, 12);
            this.lbl01_PROCCD.Name = "lbl01_PROCCD";
            this.lbl01_PROCCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PROCCD.TabIndex = 67;
            this.lbl01_PROCCD.Tag = null;
            this.lbl01_PROCCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PROCCD.Value = "공정";
            // 
            // lbl01_LINE
            // 
            this.lbl01_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINE.AutoFontSizeMinValue = 9F;
            this.lbl01_LINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINE.Location = new System.Drawing.Point(6, 12);
            this.lbl01_LINE.Name = "lbl01_LINE";
            this.lbl01_LINE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINE.TabIndex = 65;
            this.lbl01_LINE.Tag = null;
            this.lbl01_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINE.Value = "라인";
            // 
            // grpbox1_STANDARD_INFO_DETAIL
            // 
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.cbl02_INSTALL_POS);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.cbl02_PROCCD);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.cbl02_LINECD);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.btn02_CONFIRM);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.btn02_REGIST);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.txt02_FILE_NAME);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.lbl02_FILE_NAME5);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.txt02_FILE_SIZE);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.txt02_DISP_SEQ);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.lbl02_INSTALL_POS);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.lbl02_FILE_SIZE);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.lbl02_PRINT_SEQ);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.lbl02_PROCCD);
            this.grpbox1_STANDARD_INFO_DETAIL.Controls.Add(this.lbl02_LINECD);
            this.grpbox1_STANDARD_INFO_DETAIL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpbox1_STANDARD_INFO_DETAIL.Location = new System.Drawing.Point(0, 648);
            this.grpbox1_STANDARD_INFO_DETAIL.Name = "grpbox1_STANDARD_INFO_DETAIL";
            this.grpbox1_STANDARD_INFO_DETAIL.Size = new System.Drawing.Size(1024, 120);
            this.grpbox1_STANDARD_INFO_DETAIL.TabIndex = 9;
            this.grpbox1_STANDARD_INFO_DETAIL.TabStop = false;
            this.grpbox1_STANDARD_INFO_DETAIL.Text = "공정별 작업표준서 상세정보";
            // 
            // cbl02_INSTALL_POS
            // 
            this.cbl02_INSTALL_POS.AddItemSeparator = ';';
            this.cbl02_INSTALL_POS.Caption = "";
            this.cbl02_INSTALL_POS.CaptionHeight = 17;
            this.cbl02_INSTALL_POS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl02_INSTALL_POS.ColumnCaptionHeight = 18;
            this.cbl02_INSTALL_POS.ColumnFooterHeight = 18;
            this.cbl02_INSTALL_POS.ContentHeight = 16;
            this.cbl02_INSTALL_POS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl02_INSTALL_POS.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl02_INSTALL_POS.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl02_INSTALL_POS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl02_INSTALL_POS.EditorHeight = 16;
            this.cbl02_INSTALL_POS.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl02_INSTALL_POS.Images"))));
            this.cbl02_INSTALL_POS.ItemHeight = 15;
            this.cbl02_INSTALL_POS.Location = new System.Drawing.Point(316, 66);
            this.cbl02_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl02_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl02_INSTALL_POS.MaxLength = 32767;
            this.cbl02_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl02_INSTALL_POS.Name = "cbl02_INSTALL_POS";
            this.cbl02_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl02_INSTALL_POS.Size = new System.Drawing.Size(176, 22);
            this.cbl02_INSTALL_POS.TabIndex = 84;
            this.cbl02_INSTALL_POS.PropBag = resources.GetString("cbl02_INSTALL_POS.PropBag");
            // 
            // cbl02_PROCCD
            // 
            this.cbl02_PROCCD.AddItemSeparator = ';';
            this.cbl02_PROCCD.Caption = "";
            this.cbl02_PROCCD.CaptionHeight = 17;
            this.cbl02_PROCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl02_PROCCD.ColumnCaptionHeight = 18;
            this.cbl02_PROCCD.ColumnFooterHeight = 18;
            this.cbl02_PROCCD.ContentHeight = 16;
            this.cbl02_PROCCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl02_PROCCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl02_PROCCD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl02_PROCCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl02_PROCCD.EditorHeight = 16;
            this.cbl02_PROCCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl02_PROCCD.Images"))));
            this.cbl02_PROCCD.ItemHeight = 15;
            this.cbl02_PROCCD.Location = new System.Drawing.Point(316, 41);
            this.cbl02_PROCCD.MatchEntryTimeout = ((long)(2000));
            this.cbl02_PROCCD.MaxDropDownItems = ((short)(5));
            this.cbl02_PROCCD.MaxLength = 32767;
            this.cbl02_PROCCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl02_PROCCD.Name = "cbl02_PROCCD";
            this.cbl02_PROCCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl02_PROCCD.Size = new System.Drawing.Size(176, 22);
            this.cbl02_PROCCD.TabIndex = 83;
            this.cbl02_PROCCD.PropBag = resources.GetString("cbl02_PROCCD.PropBag");
            // 
            // cbl02_LINECD
            // 
            this.cbl02_LINECD.AddItemSeparator = ';';
            this.cbl02_LINECD.Caption = "";
            this.cbl02_LINECD.CaptionHeight = 17;
            this.cbl02_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl02_LINECD.ColumnCaptionHeight = 18;
            this.cbl02_LINECD.ColumnFooterHeight = 18;
            this.cbl02_LINECD.ContentHeight = 16;
            this.cbl02_LINECD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl02_LINECD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl02_LINECD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl02_LINECD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl02_LINECD.EditorHeight = 16;
            this.cbl02_LINECD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl02_LINECD.Images"))));
            this.cbl02_LINECD.ItemHeight = 15;
            this.cbl02_LINECD.Location = new System.Drawing.Point(112, 16);
            this.cbl02_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl02_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl02_LINECD.MaxLength = 32767;
            this.cbl02_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl02_LINECD.Name = "cbl02_LINECD";
            this.cbl02_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl02_LINECD.Size = new System.Drawing.Size(380, 22);
            this.cbl02_LINECD.TabIndex = 82;
            this.cbl02_LINECD.SelectedValueChanged += new System.EventHandler(this.cbl02_LINECD_SelectedValueChanged);
            this.cbl02_LINECD.PropBag = resources.GetString("cbl02_LINECD.PropBag");
            // 
            // btn02_CONFIRM
            // 
            this.btn02_CONFIRM.Location = new System.Drawing.Point(455, 91);
            this.btn02_CONFIRM.Name = "btn02_CONFIRM";
            this.btn02_CONFIRM.Size = new System.Drawing.Size(37, 23);
            this.btn02_CONFIRM.TabIndex = 81;
            this.btn02_CONFIRM.Text = "확인";
            this.btn02_CONFIRM.UseVisualStyleBackColor = true;
            this.btn02_CONFIRM.Click += new System.EventHandler(this.btn02_DWN_Click);
            // 
            // btn02_REGIST
            // 
            this.btn02_REGIST.Location = new System.Drawing.Point(412, 91);
            this.btn02_REGIST.Name = "btn02_REGIST";
            this.btn02_REGIST.Size = new System.Drawing.Size(37, 23);
            this.btn02_REGIST.TabIndex = 79;
            this.btn02_REGIST.Text = "등록";
            this.btn02_REGIST.UseVisualStyleBackColor = true;
            this.btn02_REGIST.Click += new System.EventHandler(this.btn02_REG_Click);
            // 
            // txt02_FILE_NAME
            // 
            this.txt02_FILE_NAME.Location = new System.Drawing.Point(112, 92);
            this.txt02_FILE_NAME.Name = "txt02_FILE_NAME";
            this.txt02_FILE_NAME.Size = new System.Drawing.Size(294, 21);
            this.txt02_FILE_NAME.TabIndex = 78;
            this.txt02_FILE_NAME.Tag = null;
            // 
            // lbl02_FILE_NAME5
            // 
            this.lbl02_FILE_NAME5.AutoFontSizeMaxValue = 9F;
            this.lbl02_FILE_NAME5.AutoFontSizeMinValue = 9F;
            this.lbl02_FILE_NAME5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_FILE_NAME5.Location = new System.Drawing.Point(6, 92);
            this.lbl02_FILE_NAME5.Name = "lbl02_FILE_NAME5";
            this.lbl02_FILE_NAME5.Size = new System.Drawing.Size(100, 21);
            this.lbl02_FILE_NAME5.TabIndex = 77;
            this.lbl02_FILE_NAME5.Tag = null;
            this.lbl02_FILE_NAME5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_FILE_NAME5.Value = "파일명";
            // 
            // txt02_FILE_SIZE
            // 
            this.txt02_FILE_SIZE.Location = new System.Drawing.Point(112, 67);
            this.txt02_FILE_SIZE.Name = "txt02_FILE_SIZE";
            this.txt02_FILE_SIZE.Size = new System.Drawing.Size(92, 21);
            this.txt02_FILE_SIZE.TabIndex = 76;
            this.txt02_FILE_SIZE.Tag = null;
            // 
            // txt02_DISP_SEQ
            // 
            this.txt02_DISP_SEQ.Location = new System.Drawing.Point(112, 42);
            this.txt02_DISP_SEQ.MaxLength = 2;
            this.txt02_DISP_SEQ.Name = "txt02_DISP_SEQ";
            this.txt02_DISP_SEQ.Size = new System.Drawing.Size(92, 21);
            this.txt02_DISP_SEQ.TabIndex = 74;
            this.txt02_DISP_SEQ.Tag = null;
            this.txt02_DISP_SEQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl02_INSTALL_POS
            // 
            this.lbl02_INSTALL_POS.AutoFontSizeMaxValue = 9F;
            this.lbl02_INSTALL_POS.AutoFontSizeMinValue = 9F;
            this.lbl02_INSTALL_POS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_INSTALL_POS.Location = new System.Drawing.Point(210, 67);
            this.lbl02_INSTALL_POS.Name = "lbl02_INSTALL_POS";
            this.lbl02_INSTALL_POS.Size = new System.Drawing.Size(100, 21);
            this.lbl02_INSTALL_POS.TabIndex = 71;
            this.lbl02_INSTALL_POS.Tag = null;
            this.lbl02_INSTALL_POS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_INSTALL_POS.Value = "장착위치";
            // 
            // lbl02_FILE_SIZE
            // 
            this.lbl02_FILE_SIZE.AutoFontSizeMaxValue = 9F;
            this.lbl02_FILE_SIZE.AutoFontSizeMinValue = 9F;
            this.lbl02_FILE_SIZE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_FILE_SIZE.Location = new System.Drawing.Point(6, 67);
            this.lbl02_FILE_SIZE.Name = "lbl02_FILE_SIZE";
            this.lbl02_FILE_SIZE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_FILE_SIZE.TabIndex = 70;
            this.lbl02_FILE_SIZE.Tag = null;
            this.lbl02_FILE_SIZE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_FILE_SIZE.Value = "파일크기";
            // 
            // lbl02_PRINT_SEQ
            // 
            this.lbl02_PRINT_SEQ.AutoFontSizeMaxValue = 9F;
            this.lbl02_PRINT_SEQ.AutoFontSizeMinValue = 9F;
            this.lbl02_PRINT_SEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_PRINT_SEQ.Location = new System.Drawing.Point(6, 42);
            this.lbl02_PRINT_SEQ.Name = "lbl02_PRINT_SEQ";
            this.lbl02_PRINT_SEQ.Size = new System.Drawing.Size(100, 21);
            this.lbl02_PRINT_SEQ.TabIndex = 69;
            this.lbl02_PRINT_SEQ.Tag = null;
            this.lbl02_PRINT_SEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_PRINT_SEQ.Value = "출력순서";
            // 
            // lbl02_PROCCD
            // 
            this.lbl02_PROCCD.AutoFontSizeMaxValue = 9F;
            this.lbl02_PROCCD.AutoFontSizeMinValue = 9F;
            this.lbl02_PROCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_PROCCD.Location = new System.Drawing.Point(210, 42);
            this.lbl02_PROCCD.Name = "lbl02_PROCCD";
            this.lbl02_PROCCD.Size = new System.Drawing.Size(100, 21);
            this.lbl02_PROCCD.TabIndex = 68;
            this.lbl02_PROCCD.Tag = null;
            this.lbl02_PROCCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_PROCCD.Value = "공정";
            // 
            // lbl02_LINECD
            // 
            this.lbl02_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl02_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl02_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_LINECD.Location = new System.Drawing.Point(6, 17);
            this.lbl02_LINECD.Name = "lbl02_LINECD";
            this.lbl02_LINECD.Size = new System.Drawing.Size(100, 21);
            this.lbl02_LINECD.TabIndex = 67;
            this.lbl02_LINECD.Tag = null;
            this.lbl02_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_LINECD.Value = "라인";
            // 
            // PD20115
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grpbox1_STANDARD_INFO);
            this.Controls.Add(this.grpbox1_STANDARD_INFO_DETAIL);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20115";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpbox1_STANDARD_INFO_DETAIL, 0);
            this.Controls.SetChildIndex(this.grpbox1_STANDARD_INFO, 0);
            this.grpbox1_STANDARD_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_PROCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).EndInit();
            this.grpbox1_STANDARD_INFO_DETAIL.ResumeLayout(false);
            this.grpbox1_STANDARD_INFO_DETAIL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_PROCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_FILE_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_FILE_NAME5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_FILE_SIZE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DISP_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_FILE_SIZE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PRINT_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PROCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINECD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbox1_STANDARD_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PROCCD;
        private System.Windows.Forms.GroupBox grpbox1_STANDARD_INFO_DETAIL;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_FILE_NAME;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_FILE_NAME5;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_FILE_SIZE;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_DISP_SEQ;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_FILE_SIZE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_PRINT_SEQ;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_PROCCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_LINECD;
        private Ax.DEV.Utility.Controls.AxButton btn02_CONFIRM;
        private Ax.DEV.Utility.Controls.AxButton btn02_REGIST;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_PROCCD;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxComboList cbl02_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxComboList cbl02_PROCCD;
        private Ax.DEV.Utility.Controls.AxComboList cbl02_LINECD;
    }
}
