namespace Ax.SIS.PD.UI
{
    partial class PD20160
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20160));
            this.grp01_PD20160_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbl01_ITEMCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_ITEM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_VINCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.txt01_ET_SPECCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl03_ET_SPECCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_VEHICLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp02_PD20160_2 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp03_PD20160_3 = new System.Windows.Forms.GroupBox();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn03_ALL_UPLOAD = new Ax.DEV.Utility.Controls.AxButton();
            this.cbl02_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.btn01_QUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.btn02_SAVE = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl04_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD20160_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_SPECCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_ET_SPECCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_VEHICLE)).BeginInit();
            this.grp02_PD20160_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.grp03_PD20160_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD20160_1
            // 
            this.grp01_PD20160_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp01_PD20160_1.Controls.Add(this.grd01);
            this.grp01_PD20160_1.Location = new System.Drawing.Point(0, 145);
            this.grp01_PD20160_1.Name = "grp01_PD20160_1";
            this.grp01_PD20160_1.Size = new System.Drawing.Size(438, 617);
            this.grp01_PD20160_1.TabIndex = 8;
            this.grp01_PD20160_1.TabStop = false;
            this.grp01_PD20160_1.Text = "차종별 상세사양 정보";
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
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(432, 597);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbl01_ITEMCD);
            this.groupBox1.Controls.Add(this.lbl01_ITEM);
            this.groupBox1.Controls.Add(this.cbl01_VINCD);
            this.groupBox1.Controls.Add(this.txt01_ET_SPECCD);
            this.groupBox1.Controls.Add(this.lbl03_ET_SPECCD);
            this.groupBox1.Controls.Add(this.lbl02_VEHICLE);
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbl01_ITEMCD
            // 
            this.cbl01_ITEMCD.AddItemSeparator = ';';
            this.cbl01_ITEMCD.Caption = "";
            this.cbl01_ITEMCD.CaptionHeight = 17;
            this.cbl01_ITEMCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_ITEMCD.ColumnCaptionHeight = 18;
            this.cbl01_ITEMCD.ColumnFooterHeight = 18;
            this.cbl01_ITEMCD.ContentHeight = 16;
            this.cbl01_ITEMCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_ITEMCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_ITEMCD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_ITEMCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_ITEMCD.EditorHeight = 16;
            this.cbl01_ITEMCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_ITEMCD.Images"))));
            this.cbl01_ITEMCD.ItemHeight = 15;
            this.cbl01_ITEMCD.Location = new System.Drawing.Point(152, 39);
            this.cbl01_ITEMCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_ITEMCD.MaxDropDownItems = ((short)(5));
            this.cbl01_ITEMCD.MaxLength = 32767;
            this.cbl01_ITEMCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_ITEMCD.Name = "cbl01_ITEMCD";
            this.cbl01_ITEMCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_ITEMCD.Size = new System.Drawing.Size(161, 22);
            this.cbl01_ITEMCD.TabIndex = 92;
            this.cbl01_ITEMCD.SelectedValueChanged += new System.EventHandler(this.cbl01_ITEMCD_SelectedValueChanged);
            this.cbl01_ITEMCD.PropBag = resources.GetString("cbl01_ITEMCD.PropBag");
            // 
            // lbl01_ITEM
            // 
            this.lbl01_ITEM.AutoFontSizeMaxValue = 9F;
            this.lbl01_ITEM.AutoFontSizeMinValue = 9F;
            this.lbl01_ITEM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ITEM.Location = new System.Drawing.Point(7, 40);
            this.lbl01_ITEM.Name = "lbl01_ITEM";
            this.lbl01_ITEM.Size = new System.Drawing.Size(140, 21);
            this.lbl01_ITEM.TabIndex = 91;
            this.lbl01_ITEM.Tag = null;
            this.lbl01_ITEM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ITEM.Value = "ITEM";
            // 
            // cbl01_VINCD
            // 
            this.cbl01_VINCD.AddItemSeparator = ';';
            this.cbl01_VINCD.Caption = "";
            this.cbl01_VINCD.CaptionHeight = 17;
            this.cbl01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_VINCD.ColumnCaptionHeight = 18;
            this.cbl01_VINCD.ColumnFooterHeight = 18;
            this.cbl01_VINCD.ContentHeight = 16;
            this.cbl01_VINCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_VINCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_VINCD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_VINCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_VINCD.EditorHeight = 16;
            this.cbl01_VINCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_VINCD.Images"))));
            this.cbl01_VINCD.ItemHeight = 15;
            this.cbl01_VINCD.Location = new System.Drawing.Point(151, 13);
            this.cbl01_VINCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_VINCD.MaxDropDownItems = ((short)(5));
            this.cbl01_VINCD.MaxLength = 32767;
            this.cbl01_VINCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_VINCD.Name = "cbl01_VINCD";
            this.cbl01_VINCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_VINCD.Size = new System.Drawing.Size(163, 22);
            this.cbl01_VINCD.TabIndex = 90;
            this.cbl01_VINCD.SelectedValueChanged += new System.EventHandler(this.cbl01_VINCD_SelectedValueChanged);
            this.cbl01_VINCD.PropBag = resources.GetString("cbl01_VINCD.PropBag");
            // 
            // txt01_ET_SPECCD
            // 
            this.txt01_ET_SPECCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_ET_SPECCD.Location = new System.Drawing.Point(151, 68);
            this.txt01_ET_SPECCD.Name = "txt01_ET_SPECCD";
            this.txt01_ET_SPECCD.Size = new System.Drawing.Size(163, 21);
            this.txt01_ET_SPECCD.TabIndex = 89;
            this.txt01_ET_SPECCD.Tag = null;
            // 
            // lbl03_ET_SPECCD
            // 
            this.lbl03_ET_SPECCD.AutoFontSizeMaxValue = 9F;
            this.lbl03_ET_SPECCD.AutoFontSizeMinValue = 9F;
            this.lbl03_ET_SPECCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_ET_SPECCD.Location = new System.Drawing.Point(6, 68);
            this.lbl03_ET_SPECCD.Name = "lbl03_ET_SPECCD";
            this.lbl03_ET_SPECCD.Size = new System.Drawing.Size(140, 21);
            this.lbl03_ET_SPECCD.TabIndex = 88;
            this.lbl03_ET_SPECCD.Tag = null;
            this.lbl03_ET_SPECCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl03_ET_SPECCD.Value = "사양코드";
            // 
            // lbl02_VEHICLE
            // 
            this.lbl02_VEHICLE.AutoFontSizeMaxValue = 9F;
            this.lbl02_VEHICLE.AutoFontSizeMinValue = 9F;
            this.lbl02_VEHICLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_VEHICLE.Location = new System.Drawing.Point(6, 14);
            this.lbl02_VEHICLE.Name = "lbl02_VEHICLE";
            this.lbl02_VEHICLE.Size = new System.Drawing.Size(140, 21);
            this.lbl02_VEHICLE.TabIndex = 54;
            this.lbl02_VEHICLE.Tag = null;
            this.lbl02_VEHICLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_VEHICLE.Value = "차종";
            // 
            // grp02_PD20160_2
            // 
            this.grp02_PD20160_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp02_PD20160_2.Controls.Add(this.grd02);
            this.grp02_PD20160_2.Location = new System.Drawing.Point(444, 40);
            this.grp02_PD20160_2.Name = "grp02_PD20160_2";
            this.grp02_PD20160_2.Size = new System.Drawing.Size(577, 361);
            this.grp02_PD20160_2.TabIndex = 9;
            this.grp02_PD20160_2.TabStop = false;
            this.grp02_PD20160_2.Text = "차종별 사양표 정보";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(571, 341);
            this.grd02.TabIndex = 8;
            this.grd02.UseCustomHighlight = true;
            this.grd02.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseDoubleClick);
            // 
            // grp03_PD20160_3
            // 
            this.grp03_PD20160_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp03_PD20160_3.Controls.Add(this.grd03);
            this.grp03_PD20160_3.Controls.Add(this.panel1);
            this.grp03_PD20160_3.Location = new System.Drawing.Point(444, 407);
            this.grp03_PD20160_3.Name = "grp03_PD20160_3";
            this.grp03_PD20160_3.Size = new System.Drawing.Size(577, 358);
            this.grp03_PD20160_3.TabIndex = 10;
            this.grp03_PD20160_3.TabStop = false;
            this.grp03_PD20160_3.Text = "완제품 통전 사양 관리 정보";
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03.EnabledActionFlag = true;
            this.grd03.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd03.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 54);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(571, 301);
            this.grd03.TabIndex = 8;
            this.grd03.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn03_ALL_UPLOAD);
            this.panel1.Controls.Add(this.cbl02_INSTALL_POS);
            this.panel1.Controls.Add(this.btn01_QUERY);
            this.panel1.Controls.Add(this.btn02_SAVE);
            this.panel1.Controls.Add(this.lbl04_POSTITLE);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 37);
            this.panel1.TabIndex = 9;
            // 
            // btn03_ALL_UPLOAD
            // 
            this.btn03_ALL_UPLOAD.Location = new System.Drawing.Point(440, 8);
            this.btn03_ALL_UPLOAD.Name = "btn03_ALL_UPLOAD";
            this.btn03_ALL_UPLOAD.Size = new System.Drawing.Size(92, 23);
            this.btn03_ALL_UPLOAD.TabIndex = 93;
            this.btn03_ALL_UPLOAD.Text = "일괄업로드";
            this.btn03_ALL_UPLOAD.UseVisualStyleBackColor = true;
            this.btn03_ALL_UPLOAD.Click += new System.EventHandler(this.btn02_BUP_Click);
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
            this.cbl02_INSTALL_POS.Location = new System.Drawing.Point(152, 8);
            this.cbl02_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl02_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl02_INSTALL_POS.MaxLength = 32767;
            this.cbl02_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl02_INSTALL_POS.Name = "cbl02_INSTALL_POS";
            this.cbl02_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl02_INSTALL_POS.Size = new System.Drawing.Size(120, 22);
            this.cbl02_INSTALL_POS.TabIndex = 91;
            this.cbl02_INSTALL_POS.PropBag = resources.GetString("cbl02_INSTALL_POS.PropBag");
            // 
            // btn01_QUERY
            // 
            this.btn01_QUERY.Location = new System.Drawing.Point(278, 8);
            this.btn01_QUERY.Name = "btn01_QUERY";
            this.btn01_QUERY.Size = new System.Drawing.Size(75, 23);
            this.btn01_QUERY.TabIndex = 92;
            this.btn01_QUERY.Text = "조회";
            this.btn01_QUERY.UseVisualStyleBackColor = true;
            this.btn01_QUERY.Click += new System.EventHandler(this.btn02_INQ_Click);
            // 
            // btn02_SAVE
            // 
            this.btn02_SAVE.Location = new System.Drawing.Point(359, 8);
            this.btn02_SAVE.Name = "btn02_SAVE";
            this.btn02_SAVE.Size = new System.Drawing.Size(75, 23);
            this.btn02_SAVE.TabIndex = 91;
            this.btn02_SAVE.Text = "저장";
            this.btn02_SAVE.UseVisualStyleBackColor = true;
            this.btn02_SAVE.Click += new System.EventHandler(this.btn02_SAV_Click);
            // 
            // lbl04_POSTITLE
            // 
            this.lbl04_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl04_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl04_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl04_POSTITLE.Location = new System.Drawing.Point(6, 9);
            this.lbl04_POSTITLE.Name = "lbl04_POSTITLE";
            this.lbl04_POSTITLE.Size = new System.Drawing.Size(140, 21);
            this.lbl04_POSTITLE.TabIndex = 88;
            this.lbl04_POSTITLE.Tag = null;
            this.lbl04_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl04_POSTITLE.Value = "장착위치";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(151, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 105;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(140, 21);
            this.lbl01_BIZNM2.TabIndex = 104;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // PD20160
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.lbl01_BIZNM2);
            this.Controls.Add(this.grp03_PD20160_3);
            this.Controls.Add(this.grp02_PD20160_2);
            this.Controls.Add(this.grp01_PD20160_1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20160";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD20160_1, 0);
            this.Controls.SetChildIndex(this.grp02_PD20160_2, 0);
            this.Controls.SetChildIndex(this.grp03_PD20160_3, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZNM2, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.grp01_PD20160_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_SPECCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_ET_SPECCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_VEHICLE)).EndInit();
            this.grp02_PD20160_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.grp03_PD20160_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD20160_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_VEHICLE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ET_SPECCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_ET_SPECCD;
        private System.Windows.Forms.GroupBox grp02_PD20160_2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.GroupBox grp03_PD20160_3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxButton btn02_SAVE;
        private Ax.DEV.Utility.Controls.AxLabel lbl04_POSTITLE;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_VINCD;
        private Ax.DEV.Utility.Controls.AxComboList cbl02_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxButton btn01_QUERY;
        private Ax.DEV.Utility.Controls.AxButton btn03_ALL_UPLOAD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboList cbl01_ITEMCD;
        private DEV.Utility.Controls.AxLabel lbl01_ITEM;
    }
}
