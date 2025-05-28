namespace Ax.SIS.PD.UI
{
    partial class PD25310
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD25310));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlLOCK = new System.Windows.Forms.Panel();
            this.lbl01_CONTACT_MANAGER = new System.Windows.Forms.Label();
            this.lbl01_NOT_ALLOW_MODIFY = new System.Windows.Forms.Label();
            this.btn01_PM25110_BTN1 = new Ax.DEV.Utility.Controls.AxButton();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_SHIFT = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_DAY_NGT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_WORKDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_WORKDATE2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_WORK_LINENM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtn01_CUR_DOWN_MM21021 = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rbtn01_CUR_RIGHT_MM21021 = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.AxSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cdx02_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.btn01_PM25110_BTN2 = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl02_LINE3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cdx03_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.groupBox1.SuspendLayout();
            this.pnlLOCK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DAY_NGT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORKDATE2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_LINENM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx02_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINE3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx03_LINECD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlLOCK);
            this.groupBox1.Controls.Add(this.btn01_PM25110_BTN1);
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.cbo01_SHIFT);
            this.groupBox1.Controls.Add(this.lbl01_DAY_NGT_DIV);
            this.groupBox1.Controls.Add(this.dtp01_WORKDATE);
            this.groupBox1.Controls.Add(this.lbl01_WORKDATE2);
            this.groupBox1.Controls.Add(this.lbl01_WORK_LINENM2);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 78);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // pnlLOCK
            // 
            this.pnlLOCK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLOCK.BackColor = System.Drawing.Color.Red;
            this.pnlLOCK.Controls.Add(this.lbl01_CONTACT_MANAGER);
            this.pnlLOCK.Controls.Add(this.lbl01_NOT_ALLOW_MODIFY);
            this.pnlLOCK.Location = new System.Drawing.Point(692, 17);
            this.pnlLOCK.Name = "pnlLOCK";
            this.pnlLOCK.Size = new System.Drawing.Size(326, 55);
            this.pnlLOCK.TabIndex = 65;
            this.pnlLOCK.Visible = false;
            // 
            // lbl01_CONTACT_MANAGER
            // 
            this.lbl01_CONTACT_MANAGER.AutoSize = true;
            this.lbl01_CONTACT_MANAGER.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl01_CONTACT_MANAGER.ForeColor = System.Drawing.Color.White;
            this.lbl01_CONTACT_MANAGER.Location = new System.Drawing.Point(12, 27);
            this.lbl01_CONTACT_MANAGER.Name = "lbl01_CONTACT_MANAGER";
            this.lbl01_CONTACT_MANAGER.Size = new System.Drawing.Size(342, 21);
            this.lbl01_CONTACT_MANAGER.TabIndex = 0;
            this.lbl01_CONTACT_MANAGER.Text = "생산관리 담당자에게 문의하세요.";
            // 
            // lbl01_NOT_ALLOW_MODIFY
            // 
            this.lbl01_NOT_ALLOW_MODIFY.AutoSize = true;
            this.lbl01_NOT_ALLOW_MODIFY.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl01_NOT_ALLOW_MODIFY.ForeColor = System.Drawing.Color.White;
            this.lbl01_NOT_ALLOW_MODIFY.Location = new System.Drawing.Point(12, 5);
            this.lbl01_NOT_ALLOW_MODIFY.Name = "lbl01_NOT_ALLOW_MODIFY";
            this.lbl01_NOT_ALLOW_MODIFY.Size = new System.Drawing.Size(210, 21);
            this.lbl01_NOT_ALLOW_MODIFY.TabIndex = 0;
            this.lbl01_NOT_ALLOW_MODIFY.Text = "수정할 수 없습니다.";
            // 
            // btn01_PM25110_BTN1
            // 
            this.btn01_PM25110_BTN1.Location = new System.Drawing.Point(911, 17);
            this.btn01_PM25110_BTN1.Name = "btn01_PM25110_BTN1";
            this.btn01_PM25110_BTN1.Size = new System.Drawing.Size(107, 23);
            this.btn01_PM25110_BTN1.TabIndex = 63;
            this.btn01_PM25110_BTN1.Text = "선택영역 Clear";
            this.btn01_PM25110_BTN1.UseVisualStyleBackColor = true;
            this.btn01_PM25110_BTN1.Visible = false;
            this.btn01_PM25110_BTN1.Click += new System.EventHandler(this.btn01_Clear_Click);
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 60;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(357, 19);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(326, 21);
            this.cdx01_LINECD.TabIndex = 59;
            this.cdx01_LINECD.Tag = null;
            this.cdx01_LINECD.ValueChanged += new System.EventHandler(this.cdx01_LINECD_ValueChanged);
            // 
            // cbo01_SHIFT
            // 
            this.cbo01_SHIFT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SHIFT.FormattingEnabled = true;
            this.cbo01_SHIFT.Location = new System.Drawing.Point(357, 47);
            this.cbo01_SHIFT.Name = "cbo01_SHIFT";
            this.cbo01_SHIFT.Size = new System.Drawing.Size(130, 20);
            this.cbo01_SHIFT.TabIndex = 58;
            this.cbo01_SHIFT.SelectedValueChanged += new System.EventHandler(this.cbo01_SHIFT_SelectedValueChanged);
            // 
            // lbl01_DAY_NGT_DIV
            // 
            this.lbl01_DAY_NGT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_DAY_NGT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_DAY_NGT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DAY_NGT_DIV.Location = new System.Drawing.Point(251, 46);
            this.lbl01_DAY_NGT_DIV.Name = "lbl01_DAY_NGT_DIV";
            this.lbl01_DAY_NGT_DIV.Size = new System.Drawing.Size(100, 21);
            this.lbl01_DAY_NGT_DIV.TabIndex = 57;
            this.lbl01_DAY_NGT_DIV.Tag = null;
            this.lbl01_DAY_NGT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DAY_NGT_DIV.Value = "주야";
            // 
            // dtp01_WORKDATE
            // 
            this.dtp01_WORKDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_WORKDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_WORKDATE.Location = new System.Drawing.Point(115, 46);
            this.dtp01_WORKDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_WORKDATE.Name = "dtp01_WORKDATE";
            this.dtp01_WORKDATE.OriginalFormat = "";
            this.dtp01_WORKDATE.Size = new System.Drawing.Size(130, 21);
            this.dtp01_WORKDATE.TabIndex = 56;
            this.dtp01_WORKDATE.ValueChanged += new System.EventHandler(this.dtp01_WORKDATE_ValueChanged);
            // 
            // lbl01_WORKDATE2
            // 
            this.lbl01_WORKDATE2.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORKDATE2.AutoFontSizeMinValue = 9F;
            this.lbl01_WORKDATE2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WORKDATE2.Location = new System.Drawing.Point(9, 46);
            this.lbl01_WORKDATE2.Name = "lbl01_WORKDATE2";
            this.lbl01_WORKDATE2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_WORKDATE2.TabIndex = 55;
            this.lbl01_WORKDATE2.Tag = null;
            this.lbl01_WORKDATE2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WORKDATE2.Value = "근무일자";
            // 
            // lbl01_WORK_LINENM2
            // 
            this.lbl01_WORK_LINENM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORK_LINENM2.AutoFontSizeMinValue = 9F;
            this.lbl01_WORK_LINENM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WORK_LINENM2.Location = new System.Drawing.Point(251, 20);
            this.lbl01_WORK_LINENM2.Name = "lbl01_WORK_LINENM2";
            this.lbl01_WORK_LINENM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_WORK_LINENM2.TabIndex = 53;
            this.lbl01_WORK_LINENM2.Tag = null;
            this.lbl01_WORK_LINENM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WORK_LINENM2.Value = "작업라인";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(9, 19);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 52;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(115, 20);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 51;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbtn01_CUR_DOWN_MM21021);
            this.panel1.Controls.Add(this.rbtn01_CUR_RIGHT_MM21021);
            this.panel1.Location = new System.Drawing.Point(539, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 46);
            this.panel1.TabIndex = 64;
            // 
            // rbtn01_CUR_DOWN_MM21021
            // 
            this.rbtn01_CUR_DOWN_MM21021.AutoSize = true;
            this.rbtn01_CUR_DOWN_MM21021.Location = new System.Drawing.Point(13, 25);
            this.rbtn01_CUR_DOWN_MM21021.Name = "rbtn01_CUR_DOWN_MM21021";
            this.rbtn01_CUR_DOWN_MM21021.Size = new System.Drawing.Size(115, 16);
            this.rbtn01_CUR_DOWN_MM21021.TabIndex = 0;
            this.rbtn01_CUR_DOWN_MM21021.Text = "아래쪽 커서 이동";
            this.rbtn01_CUR_DOWN_MM21021.UseVisualStyleBackColor = true;
            this.rbtn01_CUR_DOWN_MM21021.Click += new System.EventHandler(this.rbtn01_CUR_DOWN_Click);
            // 
            // rbtn01_CUR_RIGHT_MM21021
            // 
            this.rbtn01_CUR_RIGHT_MM21021.AutoSize = true;
            this.rbtn01_CUR_RIGHT_MM21021.Checked = true;
            this.rbtn01_CUR_RIGHT_MM21021.Location = new System.Drawing.Point(13, 3);
            this.rbtn01_CUR_RIGHT_MM21021.Name = "rbtn01_CUR_RIGHT_MM21021";
            this.rbtn01_CUR_RIGHT_MM21021.Size = new System.Drawing.Size(115, 16);
            this.rbtn01_CUR_RIGHT_MM21021.TabIndex = 0;
            this.rbtn01_CUR_RIGHT_MM21021.TabStop = true;
            this.rbtn01_CUR_RIGHT_MM21021.Text = "오른쪽 커서 이동";
            this.rbtn01_CUR_RIGHT_MM21021.UseVisualStyleBackColor = true;
            this.rbtn01_CUR_RIGHT_MM21021.Click += new System.EventHandler(this.rbtn01_CUR_RIGHT_Click);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Top;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 112);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 295);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 17;
            this.grd01.UseCustomHighlight = true;
            // 
            // AxSplitter1
            // 
            this.AxSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.AxSplitter1.Location = new System.Drawing.Point(0, 407);
            this.AxSplitter1.Name = "AxSplitter1";
            this.AxSplitter1.Size = new System.Drawing.Size(1024, 10);
            this.AxSplitter1.TabIndex = 20;
            this.AxSplitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.cdx02_LINECD);
            this.groupBox2.Controls.Add(this.btn01_PM25110_BTN2);
            this.groupBox2.Controls.Add(this.lbl02_LINE3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 417);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 52);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // cdx02_LINECD
            // 
            this.cdx02_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx02_LINECD.CodeParameterName = "CODE";
            this.cdx02_LINECD.CodeTextBoxReadOnly = false;
            this.cdx02_LINECD.CodeTextBoxVisible = true;
            this.cdx02_LINECD.CodeTextBoxWidth = 60;
            this.cdx02_LINECD.HEPopupHelper = null;
            this.cdx02_LINECD.Location = new System.Drawing.Point(115, 19);
            this.cdx02_LINECD.Name = "cdx02_LINECD";
            this.cdx02_LINECD.NameParameterName = "NAME";
            this.cdx02_LINECD.NameTextBoxReadOnly = false;
            this.cdx02_LINECD.NameTextBoxVisible = true;
            this.cdx02_LINECD.PopupButtonReadOnly = false;
            this.cdx02_LINECD.PopupTitle = "";
            this.cdx02_LINECD.PrefixCode = "";
            this.cdx02_LINECD.Size = new System.Drawing.Size(418, 21);
            this.cdx02_LINECD.TabIndex = 62;
            this.cdx02_LINECD.Tag = null;
            this.cdx02_LINECD.ValueChanged += new System.EventHandler(this.cdx02_LINECD_ValueChanged);
            // 
            // btn01_PM25110_BTN2
            // 
            this.btn01_PM25110_BTN2.Location = new System.Drawing.Point(539, 17);
            this.btn01_PM25110_BTN2.Name = "btn01_PM25110_BTN2";
            this.btn01_PM25110_BTN2.Size = new System.Drawing.Size(115, 23);
            this.btn01_PM25110_BTN2.TabIndex = 61;
            this.btn01_PM25110_BTN2.Text = "선택 작업자 등록";
            this.btn01_PM25110_BTN2.UseVisualStyleBackColor = true;
            this.btn01_PM25110_BTN2.Visible = false;
            this.btn01_PM25110_BTN2.Click += new System.EventHandler(this.btn01_ADD_Click);
            // 
            // lbl02_LINE3
            // 
            this.lbl02_LINE3.AutoFontSizeMaxValue = 9F;
            this.lbl02_LINE3.AutoFontSizeMinValue = 9F;
            this.lbl02_LINE3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_LINE3.Location = new System.Drawing.Point(9, 19);
            this.lbl02_LINE3.Name = "lbl02_LINE3";
            this.lbl02_LINE3.Size = new System.Drawing.Size(100, 21);
            this.lbl02_LINE3.TabIndex = 59;
            this.lbl02_LINE3.Tag = null;
            this.lbl02_LINE3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_LINE3.Value = "소속라인";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 469);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(1024, 299);
            this.grd02.TabIndex = 22;
            this.grd02.UseCustomHighlight = true;
            this.grd02.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd02_AfterEdit);
            this.grd02.DoubleClick += new System.EventHandler(this.grd02_DoubleClick);
            this.grd02.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grd02_KeyDown);
            this.grd02.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseClick);
            this.grd02.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseMove);
            // 
            // cdx03_LINECD
            // 
            this.cdx03_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx03_LINECD.CodeParameterName = "CODE";
            this.cdx03_LINECD.CodeTextBoxReadOnly = false;
            this.cdx03_LINECD.CodeTextBoxVisible = true;
            this.cdx03_LINECD.CodeTextBoxWidth = 60;
            this.cdx03_LINECD.HEPopupHelper = null;
            this.cdx03_LINECD.Location = new System.Drawing.Point(357, 489);
            this.cdx03_LINECD.Name = "cdx03_LINECD";
            this.cdx03_LINECD.NameParameterName = "NAME";
            this.cdx03_LINECD.NameTextBoxReadOnly = false;
            this.cdx03_LINECD.NameTextBoxVisible = true;
            this.cdx03_LINECD.PopupButtonReadOnly = false;
            this.cdx03_LINECD.PopupTitle = "";
            this.cdx03_LINECD.PrefixCode = "";
            this.cdx03_LINECD.Size = new System.Drawing.Size(418, 21);
            this.cdx03_LINECD.TabIndex = 63;
            this.cdx03_LINECD.Tag = null;
            this.cdx03_LINECD.Visible = false;
            // 
            // PD25310
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cdx03_LINECD);
            this.Controls.Add(this.grd02);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.AxSplitter1);
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD25310";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.Controls.SetChildIndex(this.AxSplitter1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.grd02, 0);
            this.Controls.SetChildIndex(this.cdx03_LINECD, 0);
            this.groupBox1.ResumeLayout(false);
            this.pnlLOCK.ResumeLayout(false);
            this.pnlLOCK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DAY_NGT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORKDATE2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_LINENM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx02_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINE3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx03_LINECD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxComboBox cbo01_SHIFT;
        private DEV.Utility.Controls.AxLabel lbl01_DAY_NGT_DIV;
        private DEV.Utility.Controls.AxDateEdit dtp01_WORKDATE;
        private DEV.Utility.Controls.AxLabel lbl01_WORKDATE2;
        private DEV.Utility.Controls.AxLabel lbl01_WORK_LINENM2;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxSplitter AxSplitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DEV.Utility.Controls.AxCodeBox cdx02_LINECD;
        private DEV.Utility.Controls.AxButton btn01_PM25110_BTN2;
        private DEV.Utility.Controls.AxLabel lbl02_LINE3;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private DEV.Utility.Controls.AxButton btn01_PM25110_BTN1;
        private DEV.Utility.Controls.AxCodeBox cdx03_LINECD;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxRadioButton rbtn01_CUR_DOWN_MM21021;
        private DEV.Utility.Controls.AxRadioButton rbtn01_CUR_RIGHT_MM21021;
        private System.Windows.Forms.Panel pnlLOCK;
        private System.Windows.Forms.Label lbl01_CONTACT_MANAGER;
        private System.Windows.Forms.Label lbl01_NOT_ALLOW_MODIFY;
    }
}
