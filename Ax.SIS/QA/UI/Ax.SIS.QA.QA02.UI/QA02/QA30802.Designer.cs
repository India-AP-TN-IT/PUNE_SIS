namespace Ax.SIS.QA.QA02.UI
{
    partial class QA30802
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QA30802));
            this.cbo01_USE_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grp01_QA30801_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.dte01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.grp01_QA30801_GRP_4 = new System.Windows.Forms.GroupBox();
            this.pnl03_MGT_OUT_COLOR = new System.Windows.Forms.Panel();
            this.pnl03_MGT_GOOD_COLOR = new System.Windows.Forms.Panel();
            this.pnl03_OBSERVED_COLOR = new System.Windows.Forms.Panel();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.grp01_QA30801_GRP_2 = new System.Windows.Forms.GroupBox();
            this.c1Chart1 = new C1.Win.C1Chart.C1Chart();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.heLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_USEYN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_VENDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_VIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_WRITE_MONTH = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_SAUP = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA30802_MSG = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            this.grp01_QA30801_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            this.grp01_QA30801_GRP_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.grp01_QA30801_GRP_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USEYN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WRITE_MONTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SAUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA30802_MSG)).BeginInit();
            this.SuspendLayout();
            // 
            // cbo01_USE_YN
            // 
            this.cbo01_USE_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_USE_YN.FormattingEnabled = true;
            this.cbo01_USE_YN.Location = new System.Drawing.Point(14, 220);
            this.cbo01_USE_YN.Name = "cbo01_USE_YN";
            this.cbo01_USE_YN.Size = new System.Drawing.Size(237, 20);
            this.cbo01_USE_YN.TabIndex = 4;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = false;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(14, 128);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(237, 21);
            this.cdx01_VINCD.TabIndex = 2;
            this.cdx01_VINCD.Tag = null;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(237, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // grp01_QA30801_GRP_1
            // 
            this.grp01_QA30801_GRP_1.Controls.Add(this.grd01);
            this.grp01_QA30801_GRP_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_QA30801_GRP_1.Location = new System.Drawing.Point(0, 0);
            this.grp01_QA30801_GRP_1.Name = "grp01_QA30801_GRP_1";
            this.grp01_QA30801_GRP_1.Size = new System.Drawing.Size(743, 228);
            this.grp01_QA30801_GRP_1.TabIndex = 3;
            this.grp01_QA30801_GRP_1.TabStop = false;
            this.grp01_QA30801_GRP_1.Text = "관리 ITEM 기준 목록";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(737, 208);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // dte01_SDATE
            // 
            this.dte01_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_SDATE.Location = new System.Drawing.Point(14, 82);
            this.dte01_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_SDATE.Name = "dte01_SDATE";
            this.dte01_SDATE.OriginalFormat = "";
            this.dte01_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_SDATE.TabIndex = 65;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = false;
            this.cdx01_VENDCD.CodeTextBoxWidth = 40;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(14, 174);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(237, 21);
            this.cdx01_VENDCD.TabIndex = 29;
            this.cdx01_VENDCD.Tag = null;
            // 
            // splitter5
            // 
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter5.Location = new System.Drawing.Point(0, 228);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(743, 4);
            this.splitter5.TabIndex = 68;
            this.splitter5.TabStop = false;
            // 
            // grp01_QA30801_GRP_4
            // 
            this.grp01_QA30801_GRP_4.Controls.Add(this.pnl03_MGT_OUT_COLOR);
            this.grp01_QA30801_GRP_4.Controls.Add(this.pnl03_MGT_GOOD_COLOR);
            this.grp01_QA30801_GRP_4.Controls.Add(this.pnl03_OBSERVED_COLOR);
            this.grp01_QA30801_GRP_4.Controls.Add(this.grd03);
            this.grp01_QA30801_GRP_4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_QA30801_GRP_4.Location = new System.Drawing.Point(0, 569);
            this.grp01_QA30801_GRP_4.Name = "grp01_QA30801_GRP_4";
            this.grp01_QA30801_GRP_4.Size = new System.Drawing.Size(743, 151);
            this.grp01_QA30801_GRP_4.TabIndex = 70;
            this.grp01_QA30801_GRP_4.TabStop = false;
            this.grp01_QA30801_GRP_4.Text = "이상발생 조치결과";
            // 
            // pnl03_MGT_OUT_COLOR
            // 
            this.pnl03_MGT_OUT_COLOR.BackColor = System.Drawing.Color.Silver;
            this.pnl03_MGT_OUT_COLOR.Location = new System.Drawing.Point(909, 67);
            this.pnl03_MGT_OUT_COLOR.Name = "pnl03_MGT_OUT_COLOR";
            this.pnl03_MGT_OUT_COLOR.Size = new System.Drawing.Size(70, 21);
            this.pnl03_MGT_OUT_COLOR.TabIndex = 67;
            this.pnl03_MGT_OUT_COLOR.Visible = false;
            // 
            // pnl03_MGT_GOOD_COLOR
            // 
            this.pnl03_MGT_GOOD_COLOR.BackColor = System.Drawing.Color.Silver;
            this.pnl03_MGT_GOOD_COLOR.Location = new System.Drawing.Point(909, 17);
            this.pnl03_MGT_GOOD_COLOR.Name = "pnl03_MGT_GOOD_COLOR";
            this.pnl03_MGT_GOOD_COLOR.Size = new System.Drawing.Size(70, 21);
            this.pnl03_MGT_GOOD_COLOR.TabIndex = 65;
            this.pnl03_MGT_GOOD_COLOR.Visible = false;
            // 
            // pnl03_OBSERVED_COLOR
            // 
            this.pnl03_OBSERVED_COLOR.BackColor = System.Drawing.Color.Silver;
            this.pnl03_OBSERVED_COLOR.Location = new System.Drawing.Point(909, 42);
            this.pnl03_OBSERVED_COLOR.Name = "pnl03_OBSERVED_COLOR";
            this.pnl03_OBSERVED_COLOR.Size = new System.Drawing.Size(70, 21);
            this.pnl03_OBSERVED_COLOR.TabIndex = 66;
            this.pnl03_OBSERVED_COLOR.Visible = false;
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03.EnabledActionFlag = true;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 17);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(737, 131);
            this.grd03.TabIndex = 2;
            this.grd03.UseCustomHighlight = true;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 565);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(743, 4);
            this.splitter4.TabIndex = 71;
            this.splitter4.TabStop = false;
            // 
            // grp01_QA30801_GRP_2
            // 
            this.grp01_QA30801_GRP_2.Controls.Add(this.c1Chart1);
            this.grp01_QA30801_GRP_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_QA30801_GRP_2.Location = new System.Drawing.Point(0, 232);
            this.grp01_QA30801_GRP_2.Name = "grp01_QA30801_GRP_2";
            this.grp01_QA30801_GRP_2.Size = new System.Drawing.Size(743, 333);
            this.grp01_QA30801_GRP_2.TabIndex = 74;
            this.grp01_QA30801_GRP_2.TabStop = false;
            this.grp01_QA30801_GRP_2.Text = "예방관리도";
            // 
            // c1Chart1
            // 
            this.c1Chart1.BackColor = System.Drawing.Color.White;
            this.c1Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1Chart1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.c1Chart1.Location = new System.Drawing.Point(3, 17);
            this.c1Chart1.Name = "c1Chart1";
            this.c1Chart1.PropBag = resources.GetString("c1Chart1.PropBag");
            this.c1Chart1.Size = new System.Drawing.Size(737, 313);
            this.c1Chart1.TabIndex = 0;
            this.c1Chart1.SizeChanged += new System.EventHandler(this.c1Chart1_SizeChanged);
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 75;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grp01_QA30801_GRP_2);
            this.panel1.Controls.Add(this.splitter4);
            this.panel1.Controls.Add(this.grp01_QA30801_GRP_4);
            this.panel1.Controls.Add(this.splitter5);
            this.panel1.Controls.Add(this.grp01_QA30801_GRP_1);
            this.panel1.Location = new System.Drawing.Point(281, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 720);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel2.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel2.Controls.Add(this.heLabel1);
            this.panel2.Controls.Add(this.lbl01_USEYN);
            this.panel2.Controls.Add(this.lbl01_VENDNM);
            this.panel2.Controls.Add(this.lbl01_VIN);
            this.panel2.Controls.Add(this.lbl01_WRITE_MONTH);
            this.panel2.Controls.Add(this.lbl01_SAUP);
            this.panel2.Controls.Add(this.lbl01_QA30802_MSG);
            this.panel2.Controls.Add(this.cbo01_USE_YN);
            this.panel2.Controls.Add(this.cdx01_VENDCD);
            this.panel2.Controls.Add(this.dte01_EDATE);
            this.panel2.Controls.Add(this.dte01_SDATE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.cdx01_VINCD);
            this.panel2.Location = new System.Drawing.Point(6, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 707);
            this.panel2.TabIndex = 76;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 292);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(237, 12);
            this.lbl01_PLANT_DIV.TabIndex = 71;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(14, 307);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(237, 20);
            this.cbo01_PLANT_DIV.TabIndex = 70;
            // 
            // heLabel1
            // 
            this.heLabel1.AutoFontSizeMaxValue = 9F;
            this.heLabel1.AutoFontSizeMinValue = 9F;
            this.heLabel1.AutoSize = true;
            this.heLabel1.BackColor = System.Drawing.Color.Transparent;
            this.heLabel1.Location = new System.Drawing.Point(125, 88);
            this.heLabel1.Name = "heLabel1";
            this.heLabel1.Size = new System.Drawing.Size(56, 12);
            this.heLabel1.TabIndex = 69;
            this.heLabel1.Tag = null;
            this.heLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel1.Value = "~";
            // 
            // lbl01_USEYN
            // 
            this.lbl01_USEYN.AutoFontSizeMaxValue = 9F;
            this.lbl01_USEYN.AutoFontSizeMinValue = 9F;
            this.lbl01_USEYN.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_USEYN.Location = new System.Drawing.Point(14, 205);
            this.lbl01_USEYN.Name = "lbl01_USEYN";
            this.lbl01_USEYN.Size = new System.Drawing.Size(237, 12);
            this.lbl01_USEYN.TabIndex = 68;
            this.lbl01_USEYN.Tag = null;
            this.lbl01_USEYN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_USEYN.Value = "사용여부";
            // 
            // lbl01_VENDNM
            // 
            this.lbl01_VENDNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDNM.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VENDNM.Location = new System.Drawing.Point(14, 159);
            this.lbl01_VENDNM.Name = "lbl01_VENDNM";
            this.lbl01_VENDNM.Size = new System.Drawing.Size(237, 12);
            this.lbl01_VENDNM.TabIndex = 68;
            this.lbl01_VENDNM.Tag = null;
            this.lbl01_VENDNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VENDNM.Value = "업체";
            // 
            // lbl01_VIN
            // 
            this.lbl01_VIN.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIN.AutoFontSizeMinValue = 9F;
            this.lbl01_VIN.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VIN.Location = new System.Drawing.Point(14, 113);
            this.lbl01_VIN.Name = "lbl01_VIN";
            this.lbl01_VIN.Size = new System.Drawing.Size(237, 12);
            this.lbl01_VIN.TabIndex = 68;
            this.lbl01_VIN.Tag = null;
            this.lbl01_VIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VIN.Value = "차종";
            // 
            // lbl01_WRITE_MONTH
            // 
            this.lbl01_WRITE_MONTH.AutoFontSizeMaxValue = 9F;
            this.lbl01_WRITE_MONTH.AutoFontSizeMinValue = 9F;
            this.lbl01_WRITE_MONTH.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_WRITE_MONTH.Location = new System.Drawing.Point(14, 67);
            this.lbl01_WRITE_MONTH.Name = "lbl01_WRITE_MONTH";
            this.lbl01_WRITE_MONTH.Size = new System.Drawing.Size(237, 12);
            this.lbl01_WRITE_MONTH.TabIndex = 68;
            this.lbl01_WRITE_MONTH.Tag = null;
            this.lbl01_WRITE_MONTH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_WRITE_MONTH.Value = "작성월";
            // 
            // lbl01_SAUP
            // 
            this.lbl01_SAUP.AutoFontSizeMaxValue = 9F;
            this.lbl01_SAUP.AutoFontSizeMinValue = 9F;
            this.lbl01_SAUP.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SAUP.Location = new System.Drawing.Point(14, 22);
            this.lbl01_SAUP.Name = "lbl01_SAUP";
            this.lbl01_SAUP.Size = new System.Drawing.Size(237, 12);
            this.lbl01_SAUP.TabIndex = 67;
            this.lbl01_SAUP.Tag = null;
            this.lbl01_SAUP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_SAUP.Value = "사업장";
            // 
            // lbl01_QA30802_MSG
            // 
            this.lbl01_QA30802_MSG.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA30802_MSG.AutoFontSizeMinValue = 9F;
            this.lbl01_QA30802_MSG.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_QA30802_MSG.Location = new System.Drawing.Point(14, 250);
            this.lbl01_QA30802_MSG.Name = "lbl01_QA30802_MSG";
            this.lbl01_QA30802_MSG.Size = new System.Drawing.Size(237, 35);
            this.lbl01_QA30802_MSG.TabIndex = 66;
            this.lbl01_QA30802_MSG.Tag = null;
            this.lbl01_QA30802_MSG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_QA30802_MSG.Value = "(더블클릭시 상세조회가 가능합니다.)";
            // 
            // dte01_EDATE
            // 
            this.dte01_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_EDATE.Location = new System.Drawing.Point(151, 82);
            this.dte01_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_EDATE.Name = "dte01_EDATE";
            this.dte01_EDATE.OriginalFormat = "";
            this.dte01_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_EDATE.TabIndex = 65;
            // 
            // QA30802
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30802";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            this.grp01_QA30801_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            this.grp01_QA30801_GRP_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.grp01_QA30801_GRP_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USEYN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WRITE_MONTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SAUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA30802_MSG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_QA30801_GRP_1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_USE_YN;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.GroupBox grp01_QA30801_GRP_4;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.GroupBox grp01_QA30801_GRP_2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_SDATE;
        private C1.Win.C1Chart.C1Chart c1Chart1;
        private System.Windows.Forms.Panel pnl03_MGT_OUT_COLOR;
        private System.Windows.Forms.Panel pnl03_MGT_GOOD_COLOR;
        private System.Windows.Forms.Panel pnl03_OBSERVED_COLOR;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_EDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA30802_MSG;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SAUP;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_WRITE_MONTH;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VIN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_USEYN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDNM;
        private Ax.DEV.Utility.Controls.AxLabel heLabel1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
