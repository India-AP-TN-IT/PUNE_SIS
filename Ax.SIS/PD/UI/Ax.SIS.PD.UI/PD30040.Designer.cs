namespace Ax.SIS.PD.UI
{
    partial class PD30040
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD30040));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_RESINLOTNOTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_INPUT_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpg01_SEMI_SEARCH = new System.Windows.Forms.TabPage();
            this.grp01_PD30040_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_PD30040_GRP_2 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tpg01_RESIN_LOT_SEARCH = new System.Windows.Forms.TabPage();
            this.grp01_PD30040_GRP_3 = new System.Windows.Forms.GroupBox();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_PD30040_GRP_4 = new System.Windows.Forms.GroupBox();
            this.grd04 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RESINLOTNOTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INPUT_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpg01_SEMI_SEARCH.SuspendLayout();
            this.grp01_PD30040_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.grp01_PD30040_GRP_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.tpg01_RESIN_LOT_SEARCH.SuspendLayout();
            this.grp01_PD30040_GRP_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.grp01_PD30040_GRP_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbl01_LINECD);
            this.panel2.Controls.Add(this.txt01_LOTNO);
            this.panel2.Controls.Add(this.lbl01_RESINLOTNOTITLE);
            this.panel2.Controls.Add(this.lbl01_LINE);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp01_EDATE);
            this.panel2.Controls.Add(this.dtp01_SDATE);
            this.panel2.Controls.Add(this.lbl01_INPUT_DATE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZCD);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(13, 183);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_LINECD.TabIndex = 89;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_LOTNO.Location = new System.Drawing.Point(13, 232);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_LOTNO.TabIndex = 88;
            this.txt01_LOTNO.Tag = null;
            // 
            // lbl01_RESINLOTNOTITLE
            // 
            this.lbl01_RESINLOTNOTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_RESINLOTNOTITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_RESINLOTNOTITLE.AutoSize = true;
            this.lbl01_RESINLOTNOTITLE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_RESINLOTNOTITLE.Location = new System.Drawing.Point(13, 217);
            this.lbl01_RESINLOTNOTITLE.Name = "lbl01_RESINLOTNOTITLE";
            this.lbl01_RESINLOTNOTITLE.Size = new System.Drawing.Size(148, 12);
            this.lbl01_RESINLOTNOTITLE.TabIndex = 87;
            this.lbl01_RESINLOTNOTITLE.Tag = null;
            this.lbl01_RESINLOTNOTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_RESINLOTNOTITLE.Value = "수지Lot";
            // 
            // lbl01_LINE
            // 
            this.lbl01_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINE.AutoFontSizeMinValue = 9F;
            this.lbl01_LINE.AutoSize = true;
            this.lbl01_LINE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_LINE.Location = new System.Drawing.Point(13, 168);
            this.lbl01_LINE.Name = "lbl01_LINE";
            this.lbl01_LINE.Size = new System.Drawing.Size(63, 12);
            this.lbl01_LINE.TabIndex = 73;
            this.lbl01_LINE.Tag = null;
            this.lbl01_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINE.Value = "라인";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "~";
            // 
            // dtp01_EDATE
            // 
            this.dtp01_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_EDATE.Location = new System.Drawing.Point(139, 88);
            this.dtp01_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_EDATE.Name = "dtp01_EDATE";
            this.dtp01_EDATE.OriginalFormat = "";
            this.dtp01_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_EDATE.TabIndex = 10;
            // 
            // dtp01_SDATE
            // 
            this.dtp01_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_SDATE.Location = new System.Drawing.Point(13, 88);
            this.dtp01_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_SDATE.Name = "dtp01_SDATE";
            this.dtp01_SDATE.OriginalFormat = "";
            this.dtp01_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_SDATE.TabIndex = 9;
            // 
            // lbl01_INPUT_DATE
            // 
            this.lbl01_INPUT_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_INPUT_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_INPUT_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_INPUT_DATE.Location = new System.Drawing.Point(13, 73);
            this.lbl01_INPUT_DATE.Name = "lbl01_INPUT_DATE";
            this.lbl01_INPUT_DATE.Size = new System.Drawing.Size(100, 12);
            this.lbl01_INPUT_DATE.TabIndex = 8;
            this.lbl01_INPUT_DATE.Tag = null;
            this.lbl01_INPUT_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_INPUT_DATE.Value = "투입일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 7;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZCD.Location = new System.Drawing.Point(13, 26);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(100, 12);
            this.lbl01_BIZCD.TabIndex = 6;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BIZCD.Value = "사업장코드";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpg01_SEMI_SEARCH);
            this.tabControl1.Controls.Add(this.tpg01_RESIN_LOT_SEARCH);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 736);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpg01_SEMI_SEARCH
            // 
            this.tpg01_SEMI_SEARCH.Controls.Add(this.grp01_PD30040_GRP_1);
            this.tpg01_SEMI_SEARCH.Controls.Add(this.grp01_PD30040_GRP_2);
            this.tpg01_SEMI_SEARCH.Location = new System.Drawing.Point(4, 22);
            this.tpg01_SEMI_SEARCH.Name = "tpg01_SEMI_SEARCH";
            this.tpg01_SEMI_SEARCH.Padding = new System.Windows.Forms.Padding(3);
            this.tpg01_SEMI_SEARCH.Size = new System.Drawing.Size(734, 710);
            this.tpg01_SEMI_SEARCH.TabIndex = 0;
            this.tpg01_SEMI_SEARCH.Text = "반제품 조회";
            this.tpg01_SEMI_SEARCH.UseVisualStyleBackColor = true;
            // 
            // grp01_PD30040_GRP_1
            // 
            this.grp01_PD30040_GRP_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp01_PD30040_GRP_1.Controls.Add(this.grd01);
            this.grp01_PD30040_GRP_1.Location = new System.Drawing.Point(6, 6);
            this.grp01_PD30040_GRP_1.Name = "grp01_PD30040_GRP_1";
            this.grp01_PD30040_GRP_1.Size = new System.Drawing.Size(467, 698);
            this.grp01_PD30040_GRP_1.TabIndex = 3;
            this.grp01_PD30040_GRP_1.TabStop = false;
            this.grp01_PD30040_GRP_1.Text = "반제품 리스트";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(461, 678);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // grp01_PD30040_GRP_2
            // 
            this.grp01_PD30040_GRP_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD30040_GRP_2.Controls.Add(this.grd02);
            this.grp01_PD30040_GRP_2.Location = new System.Drawing.Point(479, 6);
            this.grp01_PD30040_GRP_2.Name = "grp01_PD30040_GRP_2";
            this.grp01_PD30040_GRP_2.Size = new System.Drawing.Size(249, 698);
            this.grp01_PD30040_GRP_2.TabIndex = 4;
            this.grp01_PD30040_GRP_2.TabStop = false;
            this.grp01_PD30040_GRP_2.Text = "반제품 상세리스트";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(243, 678);
            this.grd02.TabIndex = 3;
            this.grd02.UseCustomHighlight = true;
            this.grd02.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.grd02_AfterDataRefresh);
            // 
            // tpg01_RESIN_LOT_SEARCH
            // 
            this.tpg01_RESIN_LOT_SEARCH.Controls.Add(this.grp01_PD30040_GRP_3);
            this.tpg01_RESIN_LOT_SEARCH.Controls.Add(this.grp01_PD30040_GRP_4);
            this.tpg01_RESIN_LOT_SEARCH.Location = new System.Drawing.Point(4, 22);
            this.tpg01_RESIN_LOT_SEARCH.Name = "tpg01_RESIN_LOT_SEARCH";
            this.tpg01_RESIN_LOT_SEARCH.Padding = new System.Windows.Forms.Padding(3);
            this.tpg01_RESIN_LOT_SEARCH.Size = new System.Drawing.Size(734, 710);
            this.tpg01_RESIN_LOT_SEARCH.TabIndex = 1;
            this.tpg01_RESIN_LOT_SEARCH.Text = "수지Lot 조회";
            this.tpg01_RESIN_LOT_SEARCH.UseVisualStyleBackColor = true;
            // 
            // grp01_PD30040_GRP_3
            // 
            this.grp01_PD30040_GRP_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp01_PD30040_GRP_3.Controls.Add(this.grd03);
            this.grp01_PD30040_GRP_3.Location = new System.Drawing.Point(6, 6);
            this.grp01_PD30040_GRP_3.Name = "grp01_PD30040_GRP_3";
            this.grp01_PD30040_GRP_3.Size = new System.Drawing.Size(467, 698);
            this.grp01_PD30040_GRP_3.TabIndex = 5;
            this.grp01_PD30040_GRP_3.TabStop = false;
            this.grp01_PD30040_GRP_3.Text = "수지Lot 리스트";
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03.EnabledActionFlag = true;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 17);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(461, 678);
            this.grd03.TabIndex = 2;
            this.grd03.UseCustomHighlight = true;
            this.grd03.DoubleClick += new System.EventHandler(this.grd03_DoubleClick);
            // 
            // grp01_PD30040_GRP_4
            // 
            this.grp01_PD30040_GRP_4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD30040_GRP_4.Controls.Add(this.grd04);
            this.grp01_PD30040_GRP_4.Location = new System.Drawing.Point(479, 6);
            this.grp01_PD30040_GRP_4.Name = "grp01_PD30040_GRP_4";
            this.grp01_PD30040_GRP_4.Size = new System.Drawing.Size(249, 698);
            this.grp01_PD30040_GRP_4.TabIndex = 6;
            this.grp01_PD30040_GRP_4.TabStop = false;
            this.grp01_PD30040_GRP_4.Text = "수지Lot 상세리스트";
            // 
            // grd04
            // 
            this.grd04.AllowHeaderMerging = false;
            this.grd04.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd04.EnabledActionFlag = true;
            this.grd04.LastRowAdd = false;
            this.grd04.Location = new System.Drawing.Point(3, 17);
            this.grd04.Name = "grd04";
            this.grd04.OriginalFormat = null;
            this.grd04.PopMenuVisible = true;
            this.grd04.Rows.DefaultSize = 18;
            this.grd04.Size = new System.Drawing.Size(243, 678);
            this.grd04.TabIndex = 3;
            this.grd04.UseCustomHighlight = true;
            this.grd04.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.grd04_AfterDataRefresh);
            // 
            // PD30040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD30040";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RESINLOTNOTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INPUT_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpg01_SEMI_SEARCH.ResumeLayout(false);
            this.grp01_PD30040_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.grp01_PD30040_GRP_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.tpg01_RESIN_LOT_SEARCH.ResumeLayout(false);
            this.grp01_PD30040_GRP_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.grp01_PD30040_GRP_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INPUT_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_EDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINE;
        private System.Windows.Forms.GroupBox grp01_PD30040_GRP_2;
        private System.Windows.Forms.GroupBox grp01_PD30040_GRP_1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_RESINLOTNOTITLE;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpg01_SEMI_SEARCH;
        private System.Windows.Forms.TabPage tpg01_RESIN_LOT_SEARCH;
        private System.Windows.Forms.GroupBox grp01_PD30040_GRP_3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03;
        private System.Windows.Forms.GroupBox grp01_PD30040_GRP_4;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd04;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
    }
}
