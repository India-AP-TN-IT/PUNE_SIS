namespace Ax.SIS.QA.QA00.UI
{
    partial class QA30111
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QA30111));
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.grd04_QA30111 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd03_QA30111 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd02_QA30111 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd01_QA30111 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.dte01_PROC_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_PROC_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_OCCUR_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SELECT_GUBN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SELECT_GUBN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox_detail = new System.Windows.Forms.GroupBox();
            this.grd08_QA30111 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd07_QA30111 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd06_QA30111 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd05_QA30111 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd04_QA30111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03_QA30111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA30111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SELECT_GUBN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.groupBox_detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd08_QA30111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd07_QA30111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd06_QA30111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05_QA30111)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.grd04_QA30111);
            this.groupBox_main.Controls.Add(this.grd03_QA30111);
            this.groupBox_main.Controls.Add(this.grd02_QA30111);
            this.groupBox_main.Controls.Add(this.grd01_QA30111);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_main.Location = new System.Drawing.Point(0, 0);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(275, 310);
            this.groupBox_main.TabIndex = 6;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "집계데이터";
            // 
            // grd04_QA30111
            // 
            this.grd04_QA30111.AllowHeaderMerging = false;
            this.grd04_QA30111.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd04_QA30111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd04_QA30111.EnabledActionFlag = true;
            this.grd04_QA30111.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd04_QA30111.LastRowAdd = false;
            this.grd04_QA30111.Location = new System.Drawing.Point(3, 17);
            this.grd04_QA30111.Name = "grd04_QA30111";
            this.grd04_QA30111.OriginalFormat = null;
            this.grd04_QA30111.PopMenuVisible = false;
            this.grd04_QA30111.Rows.DefaultSize = 18;
            this.grd04_QA30111.Size = new System.Drawing.Size(269, 290);
            this.grd04_QA30111.StyleInfo = resources.GetString("grd04_QA30111.StyleInfo");
            this.grd04_QA30111.TabIndex = 3;
            this.grd04_QA30111.UseCustomHighlight = true;
            this.grd04_QA30111.Visible = false;
            this.grd04_QA30111.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDoubleClick);
            // 
            // grd03_QA30111
            // 
            this.grd03_QA30111.AllowHeaderMerging = false;
            this.grd03_QA30111.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd03_QA30111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03_QA30111.EnabledActionFlag = true;
            this.grd03_QA30111.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03_QA30111.LastRowAdd = false;
            this.grd03_QA30111.Location = new System.Drawing.Point(3, 17);
            this.grd03_QA30111.Name = "grd03_QA30111";
            this.grd03_QA30111.OriginalFormat = null;
            this.grd03_QA30111.PopMenuVisible = false;
            this.grd03_QA30111.Rows.DefaultSize = 18;
            this.grd03_QA30111.Size = new System.Drawing.Size(269, 290);
            this.grd03_QA30111.StyleInfo = resources.GetString("grd03_QA30111.StyleInfo");
            this.grd03_QA30111.TabIndex = 2;
            this.grd03_QA30111.UseCustomHighlight = true;
            this.grd03_QA30111.Visible = false;
            this.grd03_QA30111.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDoubleClick);
            // 
            // grd02_QA30111
            // 
            this.grd02_QA30111.AllowHeaderMerging = false;
            this.grd02_QA30111.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd02_QA30111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02_QA30111.EnabledActionFlag = true;
            this.grd02_QA30111.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02_QA30111.LastRowAdd = false;
            this.grd02_QA30111.Location = new System.Drawing.Point(3, 17);
            this.grd02_QA30111.Name = "grd02_QA30111";
            this.grd02_QA30111.OriginalFormat = null;
            this.grd02_QA30111.PopMenuVisible = false;
            this.grd02_QA30111.Rows.DefaultSize = 18;
            this.grd02_QA30111.Size = new System.Drawing.Size(269, 290);
            this.grd02_QA30111.StyleInfo = resources.GetString("grd02_QA30111.StyleInfo");
            this.grd02_QA30111.TabIndex = 1;
            this.grd02_QA30111.UseCustomHighlight = true;
            this.grd02_QA30111.Visible = false;
            this.grd02_QA30111.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDoubleClick);
            // 
            // grd01_QA30111
            // 
            this.grd01_QA30111.AllowHeaderMerging = false;
            this.grd01_QA30111.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA30111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30111.EnabledActionFlag = true;
            this.grd01_QA30111.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01_QA30111.LastRowAdd = false;
            this.grd01_QA30111.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30111.Name = "grd01_QA30111";
            this.grd01_QA30111.OriginalFormat = null;
            this.grd01_QA30111.PopMenuVisible = false;
            this.grd01_QA30111.Rows.DefaultSize = 18;
            this.grd01_QA30111.Size = new System.Drawing.Size(269, 290);
            this.grd01_QA30111.StyleInfo = resources.GetString("grd01_QA30111.StyleInfo");
            this.grd01_QA30111.TabIndex = 0;
            this.grd01_QA30111.UseCustomHighlight = true;
            this.grd01_QA30111.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDoubleClick);
            // 
            // dte01_PROC_DATE_TO
            // 
            this.dte01_PROC_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_PROC_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_PROC_DATE_TO.Location = new System.Drawing.Point(162, 132);
            this.dte01_PROC_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_PROC_DATE_TO.Name = "dte01_PROC_DATE_TO";
            this.dte01_PROC_DATE_TO.OriginalFormat = "";
            this.dte01_PROC_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_PROC_DATE_TO.TabIndex = 6;
            // 
            // dte01_PROC_DATE_FROM
            // 
            this.dte01_PROC_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_PROC_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_PROC_DATE_FROM.Location = new System.Drawing.Point(17, 132);
            this.dte01_PROC_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_PROC_DATE_FROM.Name = "dte01_PROC_DATE_FROM";
            this.dte01_PROC_DATE_FROM.OriginalFormat = "";
            this.dte01_PROC_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_PROC_DATE_FROM.TabIndex = 5;
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(130, 136);
            this.heLabel2.Name = "heLabel2";
            this.heLabel2.Size = new System.Drawing.Size(59, 15);
            this.heLabel2.TabIndex = 4;
            this.heLabel2.Tag = null;
            this.heLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel2.Value = "~";
            // 
            // lbl01_OCCUR_DATE
            // 
            this.lbl01_OCCUR_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_OCCUR_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_OCCUR_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_OCCUR_DATE.Location = new System.Drawing.Point(17, 114);
            this.lbl01_OCCUR_DATE.Name = "lbl01_OCCUR_DATE";
            this.lbl01_OCCUR_DATE.Size = new System.Drawing.Size(245, 14);
            this.lbl01_OCCUR_DATE.TabIndex = 3;
            this.lbl01_OCCUR_DATE.Tag = null;
            this.lbl01_OCCUR_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_OCCUR_DATE.Value = "발생일자";
            // 
            // cbo01_SELECT_GUBN
            // 
            this.cbo01_SELECT_GUBN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SELECT_GUBN.FormattingEnabled = true;
            this.cbo01_SELECT_GUBN.Location = new System.Drawing.Point(17, 84);
            this.cbo01_SELECT_GUBN.Name = "cbo01_SELECT_GUBN";
            this.cbo01_SELECT_GUBN.Size = new System.Drawing.Size(245, 23);
            this.cbo01_SELECT_GUBN.TabIndex = 2;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(17, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(245, 23);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_SELECT_GUBN
            // 
            this.lbl01_SELECT_GUBN.AutoFontSizeMaxValue = 9F;
            this.lbl01_SELECT_GUBN.AutoFontSizeMinValue = 9F;
            this.lbl01_SELECT_GUBN.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SELECT_GUBN.Location = new System.Drawing.Point(17, 66);
            this.lbl01_SELECT_GUBN.Name = "lbl01_SELECT_GUBN";
            this.lbl01_SELECT_GUBN.Size = new System.Drawing.Size(245, 15);
            this.lbl01_SELECT_GUBN.TabIndex = 1;
            this.lbl01_SELECT_GUBN.Tag = null;
            this.lbl01_SELECT_GUBN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_SELECT_GUBN.Value = "조회형태";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(17, 19);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(245, 14);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // groupBox_detail
            // 
            this.groupBox_detail.Controls.Add(this.grd08_QA30111);
            this.groupBox_detail.Controls.Add(this.grd07_QA30111);
            this.groupBox_detail.Controls.Add(this.grd06_QA30111);
            this.groupBox_detail.Controls.Add(this.grd05_QA30111);
            this.groupBox_detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_detail.Location = new System.Drawing.Point(0, 310);
            this.groupBox_detail.Name = "groupBox_detail";
            this.groupBox_detail.Size = new System.Drawing.Size(275, 145);
            this.groupBox_detail.TabIndex = 7;
            this.groupBox_detail.TabStop = false;
            // 
            // grd08_QA30111
            // 
            this.grd08_QA30111.AllowHeaderMerging = false;
            this.grd08_QA30111.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd08_QA30111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd08_QA30111.EnabledActionFlag = true;
            this.grd08_QA30111.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd08_QA30111.LastRowAdd = false;
            this.grd08_QA30111.Location = new System.Drawing.Point(3, 17);
            this.grd08_QA30111.Name = "grd08_QA30111";
            this.grd08_QA30111.OriginalFormat = null;
            this.grd08_QA30111.PopMenuVisible = false;
            this.grd08_QA30111.Rows.DefaultSize = 18;
            this.grd08_QA30111.Size = new System.Drawing.Size(269, 125);
            this.grd08_QA30111.StyleInfo = resources.GetString("grd08_QA30111.StyleInfo");
            this.grd08_QA30111.TabIndex = 3;
            this.grd08_QA30111.UseCustomHighlight = true;
            this.grd08_QA30111.Visible = false;
            // 
            // grd07_QA30111
            // 
            this.grd07_QA30111.AllowHeaderMerging = false;
            this.grd07_QA30111.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd07_QA30111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd07_QA30111.EnabledActionFlag = true;
            this.grd07_QA30111.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd07_QA30111.LastRowAdd = false;
            this.grd07_QA30111.Location = new System.Drawing.Point(3, 17);
            this.grd07_QA30111.Name = "grd07_QA30111";
            this.grd07_QA30111.OriginalFormat = null;
            this.grd07_QA30111.PopMenuVisible = false;
            this.grd07_QA30111.Rows.DefaultSize = 18;
            this.grd07_QA30111.Size = new System.Drawing.Size(269, 125);
            this.grd07_QA30111.StyleInfo = resources.GetString("grd07_QA30111.StyleInfo");
            this.grd07_QA30111.TabIndex = 2;
            this.grd07_QA30111.UseCustomHighlight = true;
            this.grd07_QA30111.Visible = false;
            // 
            // grd06_QA30111
            // 
            this.grd06_QA30111.AllowHeaderMerging = false;
            this.grd06_QA30111.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd06_QA30111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd06_QA30111.EnabledActionFlag = true;
            this.grd06_QA30111.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd06_QA30111.LastRowAdd = false;
            this.grd06_QA30111.Location = new System.Drawing.Point(3, 17);
            this.grd06_QA30111.Name = "grd06_QA30111";
            this.grd06_QA30111.OriginalFormat = null;
            this.grd06_QA30111.PopMenuVisible = false;
            this.grd06_QA30111.Rows.DefaultSize = 18;
            this.grd06_QA30111.Size = new System.Drawing.Size(269, 125);
            this.grd06_QA30111.StyleInfo = resources.GetString("grd06_QA30111.StyleInfo");
            this.grd06_QA30111.TabIndex = 1;
            this.grd06_QA30111.UseCustomHighlight = true;
            this.grd06_QA30111.Visible = false;
            // 
            // grd05_QA30111
            // 
            this.grd05_QA30111.AllowHeaderMerging = false;
            this.grd05_QA30111.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd05_QA30111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd05_QA30111.EnabledActionFlag = true;
            this.grd05_QA30111.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd05_QA30111.LastRowAdd = false;
            this.grd05_QA30111.Location = new System.Drawing.Point(3, 17);
            this.grd05_QA30111.Name = "grd05_QA30111";
            this.grd05_QA30111.OriginalFormat = null;
            this.grd05_QA30111.PopMenuVisible = false;
            this.grd05_QA30111.Rows.DefaultSize = 18;
            this.grd05_QA30111.Size = new System.Drawing.Size(269, 125);
            this.grd05_QA30111.StyleInfo = resources.GetString("grd05_QA30111.StyleInfo");
            this.grd05_QA30111.TabIndex = 0;
            this.grd05_QA30111.UseCustomHighlight = true;
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 377;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.dte01_PROC_DATE_TO);
            this.panel1.Controls.Add(this.dte01_PROC_DATE_FROM);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.heLabel2);
            this.panel1.Controls.Add(this.lbl01_OCCUR_DATE);
            this.panel1.Controls.Add(this.cbo01_SELECT_GUBN);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.lbl01_SELECT_GUBN);
            this.panel1.Location = new System.Drawing.Point(29, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 455);
            this.panel1.TabIndex = 9;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(17, 164);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(245, 14);
            this.lbl01_PLANT_DIV.TabIndex = 10;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(17, 182);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(245, 23);
            this.cbo01_PLANT_DIV.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox_detail);
            this.panel2.Controls.Add(this.groupBox_main);
            this.panel2.Location = new System.Drawing.Point(312, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 455);
            this.panel2.TabIndex = 10;
            // 
            // QA30111
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30111";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd04_QA30111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03_QA30111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA30111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SELECT_GUBN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.groupBox_detail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd08_QA30111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd07_QA30111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd06_QA30111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05_QA30111)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30111;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SELECT_GUBN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd04_QA30111;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03_QA30111;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02_QA30111;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_PROC_DATE_TO;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_PROC_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxLabel heLabel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OCCUR_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SELECT_GUBN;
        private System.Windows.Forms.GroupBox groupBox_detail;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd08_QA30111;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd07_QA30111;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd06_QA30111;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd05_QA30111;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
