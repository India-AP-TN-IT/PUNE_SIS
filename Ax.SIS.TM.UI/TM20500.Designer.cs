namespace Ax.SIS.TM.UI
{
    partial class TM20500
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM20500));
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cdx01_AREA = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cdx01_DOCCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.Chk_DocEdit = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.grd04 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.Lbl_DocSelected = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cdx01_GRPCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd05 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.ChkGRPEdit = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.grd06 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lblSelectedGrp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_AREA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_DOCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_GRPCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd06)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 32);
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(447, 35);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_BIZCD.TabIndex = 75;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(307, 35);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(134, 20);
            this.lbl01_BIZCD.TabIndex = 74;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(143, 35);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_CORCD.TabIndex = 73;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(3, 35);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(134, 21);
            this.lbl01_CORCD.TabIndex = 72;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "Corporation";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 33);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(998, 606);
            this.grd02.StyleInfo = resources.GetString("grd02.StyleInfo");
            this.grd02.TabIndex = 130;
            this.grd02.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cdx01_AREA);
            this.panel1.Controls.Add(this.axLabel1);
            this.panel1.Controls.Add(this.grd02);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 642);
            this.panel1.TabIndex = 134;
            // 
            // cdx01_AREA
            // 
            this.cdx01_AREA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_AREA.CodeParameterName = "CODE";
            this.cdx01_AREA.CodeTextBoxReadOnly = false;
            this.cdx01_AREA.CodeTextBoxVisible = true;
            this.cdx01_AREA.CodeTextBoxWidth = 60;
            this.cdx01_AREA.HEPopupHelper = null;
            this.cdx01_AREA.Location = new System.Drawing.Point(169, 6);
            this.cdx01_AREA.Name = "cdx01_AREA";
            this.cdx01_AREA.NameParameterName = "NAME";
            this.cdx01_AREA.NameTextBoxReadOnly = false;
            this.cdx01_AREA.NameTextBoxVisible = true;
            this.cdx01_AREA.PopupButtonReadOnly = false;
            this.cdx01_AREA.PopupTitle = "";
            this.cdx01_AREA.PrefixCode = "";
            this.cdx01_AREA.Size = new System.Drawing.Size(278, 21);
            this.cdx01_AREA.TabIndex = 152;
            this.cdx01_AREA.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(3, 5);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(160, 21);
            this.axLabel1.TabIndex = 151;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Location";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1018, 676);
            this.tabControl1.TabIndex = 135;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1010, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Location";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1010, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Document/CheckList";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cdx01_DOCCD);
            this.panel2.Controls.Add(this.axLabel2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.grd03);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.Chk_DocEdit);
            this.panel2.Controls.Add(this.grd04);
            this.panel2.Controls.Add(this.Lbl_DocSelected);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 642);
            this.panel2.TabIndex = 135;
            // 
            // cdx01_DOCCD
            // 
            this.cdx01_DOCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_DOCCD.CodeParameterName = "CODE";
            this.cdx01_DOCCD.CodeTextBoxReadOnly = false;
            this.cdx01_DOCCD.CodeTextBoxVisible = true;
            this.cdx01_DOCCD.CodeTextBoxWidth = 60;
            this.cdx01_DOCCD.HEPopupHelper = null;
            this.cdx01_DOCCD.Location = new System.Drawing.Point(168, 3);
            this.cdx01_DOCCD.Name = "cdx01_DOCCD";
            this.cdx01_DOCCD.NameParameterName = "NAME";
            this.cdx01_DOCCD.NameTextBoxReadOnly = false;
            this.cdx01_DOCCD.NameTextBoxVisible = true;
            this.cdx01_DOCCD.PopupButtonReadOnly = false;
            this.cdx01_DOCCD.PopupTitle = "";
            this.cdx01_DOCCD.PrefixCode = "";
            this.cdx01_DOCCD.Size = new System.Drawing.Size(278, 21);
            this.cdx01_DOCCD.TabIndex = 150;
            this.cdx01_DOCCD.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(2, 2);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(160, 21);
            this.axLabel2.TabIndex = 149;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Document";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(747, 411);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 228);
            this.pictureBox1.TabIndex = 134;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd03.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd03.EnabledActionFlag = true;
            this.grd03.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 26);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(998, 256);
            this.grd03.StyleInfo = resources.GetString("grd03.StyleInfo");
            this.grd03.TabIndex = 127;
            this.grd03.UseCustomHighlight = true;
            this.grd03.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GRD_DblClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 131;
            this.label3.Text = "Selected Document : ";
            // 
            // Chk_DocEdit
            // 
            this.Chk_DocEdit.AutoSize = true;
            this.Chk_DocEdit.Location = new System.Drawing.Point(513, 2);
            this.Chk_DocEdit.Name = "Chk_DocEdit";
            this.Chk_DocEdit.Size = new System.Drawing.Size(82, 19);
            this.Chk_DocEdit.TabIndex = 133;
            this.Chk_DocEdit.Text = "Edit Mode";
            this.Chk_DocEdit.UseVisualStyleBackColor = true;
            this.Chk_DocEdit.CheckedChanged += new System.EventHandler(this.ChkEdit_CheckedChanged);
            // 
            // grd04
            // 
            this.grd04.AllowHeaderMerging = false;
            this.grd04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd04.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd04.EnabledActionFlag = true;
            this.grd04.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd04.LastRowAdd = false;
            this.grd04.Location = new System.Drawing.Point(3, 303);
            this.grd04.Name = "grd04";
            this.grd04.OriginalFormat = null;
            this.grd04.PopMenuVisible = true;
            this.grd04.Rows.DefaultSize = 18;
            this.grd04.Size = new System.Drawing.Size(987, 336);
            this.grd04.StyleInfo = resources.GetString("grd04.StyleInfo");
            this.grd04.TabIndex = 130;
            this.grd04.UseCustomHighlight = true;
            this.grd04.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd04_MouseDoubleClick);
            // 
            // Lbl_DocSelected
            // 
            this.Lbl_DocSelected.AutoSize = true;
            this.Lbl_DocSelected.ForeColor = System.Drawing.Color.Red;
            this.Lbl_DocSelected.Location = new System.Drawing.Point(133, 285);
            this.Lbl_DocSelected.Name = "Lbl_DocSelected";
            this.Lbl_DocSelected.Size = new System.Drawing.Size(92, 15);
            this.Lbl_DocSelected.TabIndex = 132;
            this.Lbl_DocSelected.Text = "Selected Area : ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cdx01_GRPCD);
            this.tabPage3.Controls.Add(this.axLabel3);
            this.tabPage3.Controls.Add(this.grd05);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.ChkGRPEdit);
            this.tabPage3.Controls.Add(this.grd06);
            this.tabPage3.Controls.Add(this.lblSelectedGrp);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1010, 648);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Group/Member";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cdx01_GRPCD
            // 
            this.cdx01_GRPCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_GRPCD.CodeParameterName = "CODE";
            this.cdx01_GRPCD.CodeTextBoxReadOnly = false;
            this.cdx01_GRPCD.CodeTextBoxVisible = true;
            this.cdx01_GRPCD.CodeTextBoxWidth = 60;
            this.cdx01_GRPCD.HEPopupHelper = null;
            this.cdx01_GRPCD.Location = new System.Drawing.Point(172, 8);
            this.cdx01_GRPCD.Name = "cdx01_GRPCD";
            this.cdx01_GRPCD.NameParameterName = "NAME";
            this.cdx01_GRPCD.NameTextBoxReadOnly = false;
            this.cdx01_GRPCD.NameTextBoxVisible = true;
            this.cdx01_GRPCD.PopupButtonReadOnly = false;
            this.cdx01_GRPCD.PopupTitle = "";
            this.cdx01_GRPCD.PrefixCode = "";
            this.cdx01_GRPCD.Size = new System.Drawing.Size(278, 21);
            this.cdx01_GRPCD.TabIndex = 159;
            this.cdx01_GRPCD.Tag = null;
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(6, 7);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(160, 21);
            this.axLabel3.TabIndex = 158;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "Group";
            // 
            // grd05
            // 
            this.grd05.AllowHeaderMerging = false;
            this.grd05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd05.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd05.EnabledActionFlag = true;
            this.grd05.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd05.LastRowAdd = false;
            this.grd05.Location = new System.Drawing.Point(6, 30);
            this.grd05.Name = "grd05";
            this.grd05.OriginalFormat = null;
            this.grd05.PopMenuVisible = true;
            this.grd05.Rows.DefaultSize = 18;
            this.grd05.Size = new System.Drawing.Size(998, 296);
            this.grd05.StyleInfo = resources.GetString("grd05.StyleInfo");
            this.grd05.TabIndex = 153;
            this.grd05.UseCustomHighlight = true;
            this.grd05.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GRD_DblClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 155;
            this.label4.Text = "Selected Group : ";
            // 
            // ChkGRPEdit
            // 
            this.ChkGRPEdit.AutoSize = true;
            this.ChkGRPEdit.Location = new System.Drawing.Point(473, 8);
            this.ChkGRPEdit.Name = "ChkGRPEdit";
            this.ChkGRPEdit.Size = new System.Drawing.Size(82, 19);
            this.ChkGRPEdit.TabIndex = 157;
            this.ChkGRPEdit.Text = "Edit Mode";
            this.ChkGRPEdit.UseVisualStyleBackColor = true;
            this.ChkGRPEdit.CheckedChanged += new System.EventHandler(this.ChkEdit_CheckedChanged);
            // 
            // grd06
            // 
            this.grd06.AllowHeaderMerging = false;
            this.grd06.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd06.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd06.EnabledActionFlag = true;
            this.grd06.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd06.LastRowAdd = false;
            this.grd06.Location = new System.Drawing.Point(6, 350);
            this.grd06.Name = "grd06";
            this.grd06.OriginalFormat = null;
            this.grd06.PopMenuVisible = true;
            this.grd06.Rows.DefaultSize = 18;
            this.grd06.Size = new System.Drawing.Size(998, 294);
            this.grd06.StyleInfo = resources.GetString("grd06.StyleInfo");
            this.grd06.TabIndex = 154;
            this.grd06.UseCustomHighlight = true;
            // 
            // lblSelectedGrp
            // 
            this.lblSelectedGrp.AutoSize = true;
            this.lblSelectedGrp.ForeColor = System.Drawing.Color.Red;
            this.lblSelectedGrp.Location = new System.Drawing.Point(113, 329);
            this.lblSelectedGrp.Name = "lblSelectedGrp";
            this.lblSelectedGrp.Size = new System.Drawing.Size(92, 15);
            this.lblSelectedGrp.TabIndex = 156;
            this.lblSelectedGrp.Text = "Selected Area : ";
            // 
            // TM20500
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.cbo01_CORCD);
            this.Controls.Add(this.lbl01_CORCD);
            this.Name = "TM20500";
            this.Controls.SetChildIndex(this.lbl01_CORCD, 0);
            this.Controls.SetChildIndex(this.cbo01_CORCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_AREA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_DOCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_GRPCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd06)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd03;
        private System.Windows.Forms.Label label3;
        private DEV.Utility.Controls.AxCheckBox Chk_DocEdit;
        private DEV.Utility.Controls.AxFlexGrid grd04;
        private System.Windows.Forms.Label Lbl_DocSelected;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DEV.Utility.Controls.AxCodeBox cdx01_AREA;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxCodeBox cdx01_DOCCD;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private System.Windows.Forms.TabPage tabPage3;
        private DEV.Utility.Controls.AxCodeBox cdx01_GRPCD;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxFlexGrid grd05;
        private System.Windows.Forms.Label label4;
        private DEV.Utility.Controls.AxCheckBox ChkGRPEdit;
        private DEV.Utility.Controls.AxFlexGrid grd06;
        private System.Windows.Forms.Label lblSelectedGrp;


    }
}
