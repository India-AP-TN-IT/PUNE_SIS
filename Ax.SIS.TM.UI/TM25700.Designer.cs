namespace Ax.SIS.TM.UI
{
    partial class TM25700
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM25700));
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cdx01_DOCCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx_GRPCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx_LOCCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.axDateEdit2 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd04 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axLabel5 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit3 = new Ax.DEV.Utility.Controls.AxDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_DOCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx_GRPCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx_LOCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).BeginInit();
            this.SuspendLayout();
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(995, 290);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 128;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // cdx01_DOCCD
            // 
            this.cdx01_DOCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_DOCCD.CodeParameterName = "CODE";
            this.cdx01_DOCCD.CodeTextBoxReadOnly = false;
            this.cdx01_DOCCD.CodeTextBoxVisible = true;
            this.cdx01_DOCCD.CodeTextBoxWidth = 60;
            this.cdx01_DOCCD.HEPopupHelper = null;
            this.cdx01_DOCCD.Location = new System.Drawing.Point(172, 96);
            this.cdx01_DOCCD.Name = "cdx01_DOCCD";
            this.cdx01_DOCCD.NameParameterName = "NAME";
            this.cdx01_DOCCD.NameTextBoxReadOnly = false;
            this.cdx01_DOCCD.NameTextBoxVisible = true;
            this.cdx01_DOCCD.PopupButtonReadOnly = false;
            this.cdx01_DOCCD.PopupTitle = "";
            this.cdx01_DOCCD.PrefixCode = "";
            this.cdx01_DOCCD.Size = new System.Drawing.Size(278, 21);
            this.cdx01_DOCCD.TabIndex = 156;
            this.cdx01_DOCCD.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(6, 95);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(160, 21);
            this.axLabel2.TabIndex = 155;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Document";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(449, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_BIZCD.TabIndex = 160;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(309, 40);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(134, 20);
            this.lbl01_BIZCD.TabIndex = 159;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(145, 40);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_CORCD.TabIndex = 158;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(5, 40);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(134, 21);
            this.lbl01_CORCD.TabIndex = 157;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "Corporation";
            // 
            // cdx_GRPCD
            // 
            this.cdx_GRPCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx_GRPCD.CodeParameterName = "CODE";
            this.cdx_GRPCD.CodeTextBoxReadOnly = false;
            this.cdx_GRPCD.CodeTextBoxVisible = true;
            this.cdx_GRPCD.CodeTextBoxWidth = 60;
            this.cdx_GRPCD.HEPopupHelper = null;
            this.cdx_GRPCD.Location = new System.Drawing.Point(635, 96);
            this.cdx_GRPCD.Name = "cdx_GRPCD";
            this.cdx_GRPCD.NameParameterName = "NAME";
            this.cdx_GRPCD.NameTextBoxReadOnly = false;
            this.cdx_GRPCD.NameTextBoxVisible = true;
            this.cdx_GRPCD.PopupButtonReadOnly = false;
            this.cdx_GRPCD.PopupTitle = "";
            this.cdx_GRPCD.PrefixCode = "";
            this.cdx_GRPCD.Size = new System.Drawing.Size(278, 21);
            this.cdx_GRPCD.TabIndex = 162;
            this.cdx_GRPCD.Tag = null;
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(469, 95);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(160, 21);
            this.axLabel3.TabIndex = 161;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "Group";
            // 
            // cdx_LOCCD
            // 
            this.cdx_LOCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx_LOCCD.CodeParameterName = "CODE";
            this.cdx_LOCCD.CodeTextBoxReadOnly = false;
            this.cdx_LOCCD.CodeTextBoxVisible = true;
            this.cdx_LOCCD.CodeTextBoxWidth = 60;
            this.cdx_LOCCD.HEPopupHelper = null;
            this.cdx_LOCCD.Location = new System.Drawing.Point(172, 69);
            this.cdx_LOCCD.Name = "cdx_LOCCD";
            this.cdx_LOCCD.NameParameterName = "NAME";
            this.cdx_LOCCD.NameTextBoxReadOnly = false;
            this.cdx_LOCCD.NameTextBoxVisible = true;
            this.cdx_LOCCD.PopupButtonReadOnly = false;
            this.cdx_LOCCD.PopupTitle = "";
            this.cdx_LOCCD.PrefixCode = "";
            this.cdx_LOCCD.Size = new System.Drawing.Size(278, 21);
            this.cdx_LOCCD.TabIndex = 164;
            this.cdx_LOCCD.Tag = null;
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel4.Location = new System.Drawing.Point(6, 68);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(160, 21);
            this.axLabel4.TabIndex = 163;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Location";
            // 
            // axDateEdit1
            // 
            this.axDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit1.Location = new System.Drawing.Point(172, 4);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(100, 21);
            this.axDateEdit1.TabIndex = 165;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(6, 4);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(160, 21);
            this.axLabel1.TabIndex = 166;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Date";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 123);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1015, 642);
            this.tabControl1.TabIndex = 167;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.axDateEdit2);
            this.tabPage1.Controls.Add(this.axLabel1);
            this.tabPage1.Controls.Add(this.axDateEdit1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1007, 614);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Daily";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grd01);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grd02);
            this.splitContainer1.Size = new System.Drawing.Size(995, 580);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.TabIndex = 169;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(995, 286);
            this.grd02.StyleInfo = resources.GetString("grd02.StyleInfo");
            this.grd02.TabIndex = 129;
            this.grd02.UseCustomHighlight = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 168;
            this.label1.Text = "~";
            // 
            // axDateEdit2
            // 
            this.axDateEdit2.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit2.Location = new System.Drawing.Point(299, 4);
            this.axDateEdit2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit2.Name = "axDateEdit2";
            this.axDateEdit2.OriginalFormat = "";
            this.axDateEdit2.Size = new System.Drawing.Size(100, 21);
            this.axDateEdit2.TabIndex = 167;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Controls.Add(this.axLabel5);
            this.tabPage2.Controls.Add(this.axDateEdit3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1007, 614);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Month";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(6, 28);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grd03);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grd04);
            this.splitContainer2.Size = new System.Drawing.Size(995, 580);
            this.splitContainer2.SplitterDistance = 290;
            this.splitContainer2.TabIndex = 170;
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03.EnabledActionFlag = true;
            this.grd03.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(0, 0);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(995, 290);
            this.grd03.StyleInfo = resources.GetString("grd03.StyleInfo");
            this.grd03.TabIndex = 128;
            this.grd03.UseCustomHighlight = true;
            this.grd03.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd03_MouseDoubleClick);
            // 
            // grd04
            // 
            this.grd04.AllowHeaderMerging = false;
            this.grd04.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd04.EnabledActionFlag = true;
            this.grd04.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd04.LastRowAdd = false;
            this.grd04.Location = new System.Drawing.Point(0, 0);
            this.grd04.Name = "grd04";
            this.grd04.OriginalFormat = null;
            this.grd04.PopMenuVisible = true;
            this.grd04.Rows.DefaultSize = 18;
            this.grd04.Size = new System.Drawing.Size(995, 286);
            this.grd04.StyleInfo = resources.GetString("grd04.StyleInfo");
            this.grd04.TabIndex = 129;
            this.grd04.UseCustomHighlight = true;
            // 
            // axLabel5
            // 
            this.axLabel5.AutoFontSizeMaxValue = 9F;
            this.axLabel5.AutoFontSizeMinValue = 9F;
            this.axLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel5.Location = new System.Drawing.Point(6, 3);
            this.axLabel5.Name = "axLabel5";
            this.axLabel5.Size = new System.Drawing.Size(160, 21);
            this.axLabel5.TabIndex = 168;
            this.axLabel5.Tag = null;
            this.axLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel5.Value = "Date";
            // 
            // axDateEdit3
            // 
            this.axDateEdit3.CustomFormat = "yyyy-MM";
            this.axDateEdit3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit3.Location = new System.Drawing.Point(172, 3);
            this.axDateEdit3.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit3.Name = "axDateEdit3";
            this.axDateEdit3.OriginalFormat = "";
            this.axDateEdit3.Size = new System.Drawing.Size(100, 21);
            this.axDateEdit3.TabIndex = 167;
            // 
            // TM25700
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cdx_LOCCD);
            this.Controls.Add(this.axLabel4);
            this.Controls.Add(this.cdx_GRPCD);
            this.Controls.Add(this.axLabel3);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.cbo01_CORCD);
            this.Controls.Add(this.lbl01_CORCD);
            this.Controls.Add(this.cdx01_DOCCD);
            this.Controls.Add(this.axLabel2);
            this.Name = "TM25700";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.cdx01_DOCCD, 0);
            this.Controls.SetChildIndex(this.lbl01_CORCD, 0);
            this.Controls.SetChildIndex(this.cbo01_CORCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.axLabel3, 0);
            this.Controls.SetChildIndex(this.cdx_GRPCD, 0);
            this.Controls.SetChildIndex(this.axLabel4, 0);
            this.Controls.SetChildIndex(this.cdx_LOCCD, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_DOCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx_GRPCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx_LOCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxCodeBox cdx01_DOCCD;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private DEV.Utility.Controls.AxCodeBox cdx_GRPCD;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxCodeBox cdx_LOCCD;
        private DEV.Utility.Controls.AxLabel axLabel4;
        private DEV.Utility.Controls.AxDateEdit axDateEdit1;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private DEV.Utility.Controls.AxDateEdit axDateEdit2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private DEV.Utility.Controls.AxLabel axLabel5;
        private DEV.Utility.Controls.AxDateEdit axDateEdit3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DEV.Utility.Controls.AxFlexGrid grd03;
        private DEV.Utility.Controls.AxFlexGrid grd04;


    }
}
