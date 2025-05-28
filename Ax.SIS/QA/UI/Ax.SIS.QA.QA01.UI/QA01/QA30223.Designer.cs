namespace Ax.SIS.QA.QA01.UI
{
    partial class QA30223
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd01_QA30223 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.txt01_PARTNO_PARTNONM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_RET_PARTNO_PARTNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_RTN_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_JOB_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_JOB_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_RET_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ITEM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_ITEMCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CUST_PLANT = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_CUST_PLANT = new Ax.DEV.Utility.Controls.AxLabel();
            this.heLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_RTN_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_RTN_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cdx01_SAL_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_CUSTNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_OCCUR_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30223)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNONM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RET_PARTNO_PARTNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_JOB_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RET_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUST_PLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_SAL_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01_QA30223);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 259);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // grd01_QA30223
            // 
            this.grd01_QA30223.AllowHeaderMerging = false;
            this.grd01_QA30223.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA30223.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30223.EnabledActionFlag = true;
            this.grd01_QA30223.LastRowAdd = false;
            this.grd01_QA30223.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30223.Name = "grd01_QA30223";
            this.grd01_QA30223.OriginalFormat = null;
            this.grd01_QA30223.PopMenuVisible = true;
            this.grd01_QA30223.Rows.DefaultSize = 18;
            this.grd01_QA30223.Size = new System.Drawing.Size(403, 239);
            this.grd01_QA30223.TabIndex = 0;
            this.grd01_QA30223.UseCustomHighlight = true;
            this.grd01_QA30223.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA30223_MouseDoubleClick);
            // 
            // txt01_PARTNO_PARTNONM
            // 
            this.txt01_PARTNO_PARTNONM.Location = new System.Drawing.Point(13, 413);
            this.txt01_PARTNO_PARTNONM.Name = "txt01_PARTNO_PARTNONM";
            this.txt01_PARTNO_PARTNONM.Size = new System.Drawing.Size(245, 21);
            this.txt01_PARTNO_PARTNONM.TabIndex = 53;
            this.txt01_PARTNO_PARTNONM.Tag = null;
            // 
            // lbl01_RET_PARTNO_PARTNM
            // 
            this.lbl01_RET_PARTNO_PARTNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_RET_PARTNO_PARTNM.AutoFontSizeMinValue = 9F;
            this.lbl01_RET_PARTNO_PARTNM.AutoSize = true;
            this.lbl01_RET_PARTNO_PARTNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_RET_PARTNO_PARTNM.Location = new System.Drawing.Point(13, 398);
            this.lbl01_RET_PARTNO_PARTNM.Name = "lbl01_RET_PARTNO_PARTNM";
            this.lbl01_RET_PARTNO_PARTNM.Size = new System.Drawing.Size(174, 12);
            this.lbl01_RET_PARTNO_PARTNM.TabIndex = 52;
            this.lbl01_RET_PARTNO_PARTNM.Tag = null;
            this.lbl01_RET_PARTNO_PARTNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_RET_PARTNO_PARTNM.Value = "반송품번/품명";
            // 
            // cbo01_RTN_DIV
            // 
            this.cbo01_RTN_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_RTN_DIV.FormattingEnabled = true;
            this.cbo01_RTN_DIV.Location = new System.Drawing.Point(13, 319);
            this.cbo01_RTN_DIV.Name = "cbo01_RTN_DIV";
            this.cbo01_RTN_DIV.Size = new System.Drawing.Size(245, 20);
            this.cbo01_RTN_DIV.TabIndex = 51;
            // 
            // cbo01_JOB_TYPE
            // 
            this.cbo01_JOB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_JOB_TYPE.FormattingEnabled = true;
            this.cbo01_JOB_TYPE.Location = new System.Drawing.Point(13, 366);
            this.cbo01_JOB_TYPE.Name = "cbo01_JOB_TYPE";
            this.cbo01_JOB_TYPE.Size = new System.Drawing.Size(245, 20);
            this.cbo01_JOB_TYPE.TabIndex = 49;
            // 
            // lbl01_JOB_TYPE
            // 
            this.lbl01_JOB_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_JOB_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_JOB_TYPE.AutoSize = true;
            this.lbl01_JOB_TYPE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_JOB_TYPE.Location = new System.Drawing.Point(13, 349);
            this.lbl01_JOB_TYPE.Name = "lbl01_JOB_TYPE";
            this.lbl01_JOB_TYPE.Size = new System.Drawing.Size(97, 12);
            this.lbl01_JOB_TYPE.TabIndex = 48;
            this.lbl01_JOB_TYPE.Tag = null;
            this.lbl01_JOB_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_JOB_TYPE.Value = "업무유형";
            // 
            // lbl01_RET_DIV
            // 
            this.lbl01_RET_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_RET_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_RET_DIV.AutoSize = true;
            this.lbl01_RET_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_RET_DIV.Location = new System.Drawing.Point(13, 304);
            this.lbl01_RET_DIV.Name = "lbl01_RET_DIV";
            this.lbl01_RET_DIV.Size = new System.Drawing.Size(85, 12);
            this.lbl01_RET_DIV.TabIndex = 46;
            this.lbl01_RET_DIV.Tag = null;
            this.lbl01_RET_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_RET_DIV.Value = "반송유형";
            // 
            // lbl01_ITEM
            // 
            this.lbl01_ITEM.AutoFontSizeMaxValue = 9F;
            this.lbl01_ITEM.AutoFontSizeMinValue = 9F;
            this.lbl01_ITEM.AutoSize = true;
            this.lbl01_ITEM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_ITEM.Location = new System.Drawing.Point(13, 257);
            this.lbl01_ITEM.Name = "lbl01_ITEM";
            this.lbl01_ITEM.Size = new System.Drawing.Size(66, 12);
            this.lbl01_ITEM.TabIndex = 44;
            this.lbl01_ITEM.Tag = null;
            this.lbl01_ITEM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ITEM.Value = "품목";
            // 
            // cdx01_ITEMCD
            // 
            this.cdx01_ITEMCD.CodeParameterName = "CODE";
            this.cdx01_ITEMCD.CodeTextBoxReadOnly = false;
            this.cdx01_ITEMCD.CodeTextBoxVisible = false;
            this.cdx01_ITEMCD.CodeTextBoxWidth = 40;
            this.cdx01_ITEMCD.HEPopupHelper = null;
            this.cdx01_ITEMCD.Location = new System.Drawing.Point(13, 272);
            this.cdx01_ITEMCD.Name = "cdx01_ITEMCD";
            this.cdx01_ITEMCD.NameParameterName = "NAME";
            this.cdx01_ITEMCD.NameTextBoxReadOnly = false;
            this.cdx01_ITEMCD.NameTextBoxVisible = true;
            this.cdx01_ITEMCD.PopupButtonReadOnly = false;
            this.cdx01_ITEMCD.PopupTitle = "";
            this.cdx01_ITEMCD.PrefixCode = "";
            this.cdx01_ITEMCD.Size = new System.Drawing.Size(245, 21);
            this.cdx01_ITEMCD.TabIndex = 43;
            this.cdx01_ITEMCD.Tag = null;
            this.cdx01_ITEMCD.ButtonClickBefore += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_ITEMCD_ButtonClickBefore);
            // 
            // lbl01_VIN
            // 
            this.lbl01_VIN.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIN.AutoFontSizeMinValue = 9F;
            this.lbl01_VIN.AutoSize = true;
            this.lbl01_VIN.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VIN.Location = new System.Drawing.Point(13, 209);
            this.lbl01_VIN.Name = "lbl01_VIN";
            this.lbl01_VIN.Size = new System.Drawing.Size(56, 12);
            this.lbl01_VIN.TabIndex = 42;
            this.lbl01_VIN.Tag = null;
            this.lbl01_VIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VIN.Value = "차종";
            // 
            // cbo01_CUST_PLANT
            // 
            this.cbo01_CUST_PLANT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CUST_PLANT.FormattingEnabled = true;
            this.cbo01_CUST_PLANT.Location = new System.Drawing.Point(13, 177);
            this.cbo01_CUST_PLANT.Name = "cbo01_CUST_PLANT";
            this.cbo01_CUST_PLANT.Size = new System.Drawing.Size(245, 20);
            this.cbo01_CUST_PLANT.TabIndex = 41;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = false;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(13, 224);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(245, 21);
            this.cdx01_VINCD.TabIndex = 40;
            this.cdx01_VINCD.Tag = null;
            // 
            // lbl01_CUST_PLANT
            // 
            this.lbl01_CUST_PLANT.AutoFontSizeMaxValue = 9F;
            this.lbl01_CUST_PLANT.AutoFontSizeMinValue = 9F;
            this.lbl01_CUST_PLANT.AutoSize = true;
            this.lbl01_CUST_PLANT.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_CUST_PLANT.Location = new System.Drawing.Point(13, 162);
            this.lbl01_CUST_PLANT.Name = "lbl01_CUST_PLANT";
            this.lbl01_CUST_PLANT.Size = new System.Drawing.Size(115, 12);
            this.lbl01_CUST_PLANT.TabIndex = 39;
            this.lbl01_CUST_PLANT.Tag = null;
            this.lbl01_CUST_PLANT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CUST_PLANT.Value = "고객공장";
            // 
            // heLabel1
            // 
            this.heLabel1.AutoFontSizeMaxValue = 9F;
            this.heLabel1.AutoFontSizeMinValue = 9F;
            this.heLabel1.AutoSize = true;
            this.heLabel1.BackColor = System.Drawing.Color.Transparent;
            this.heLabel1.Location = new System.Drawing.Point(119, 85);
            this.heLabel1.Name = "heLabel1";
            this.heLabel1.Size = new System.Drawing.Size(56, 12);
            this.heLabel1.TabIndex = 38;
            this.heLabel1.Tag = null;
            this.heLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel1.Value = "~";
            // 
            // dte01_RTN_DATE_TO
            // 
            this.dte01_RTN_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_RTN_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RTN_DATE_TO.Location = new System.Drawing.Point(146, 81);
            this.dte01_RTN_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RTN_DATE_TO.Name = "dte01_RTN_DATE_TO";
            this.dte01_RTN_DATE_TO.OriginalFormat = "";
            this.dte01_RTN_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_RTN_DATE_TO.TabIndex = 37;
            // 
            // dte01_RTN_DATE_FROM
            // 
            this.dte01_RTN_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_RTN_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RTN_DATE_FROM.Location = new System.Drawing.Point(13, 81);
            this.dte01_RTN_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RTN_DATE_FROM.Name = "dte01_RTN_DATE_FROM";
            this.dte01_RTN_DATE_FROM.OriginalFormat = "";
            this.dte01_RTN_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_RTN_DATE_FROM.TabIndex = 36;
            // 
            // cdx01_SAL_VENDCD
            // 
            this.cdx01_SAL_VENDCD.CodeParameterName = "CODE";
            this.cdx01_SAL_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_SAL_VENDCD.CodeTextBoxVisible = false;
            this.cdx01_SAL_VENDCD.CodeTextBoxWidth = 40;
            this.cdx01_SAL_VENDCD.HEPopupHelper = null;
            this.cdx01_SAL_VENDCD.Location = new System.Drawing.Point(13, 129);
            this.cdx01_SAL_VENDCD.Name = "cdx01_SAL_VENDCD";
            this.cdx01_SAL_VENDCD.NameParameterName = "NAME";
            this.cdx01_SAL_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_SAL_VENDCD.NameTextBoxVisible = true;
            this.cdx01_SAL_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_SAL_VENDCD.PopupTitle = "";
            this.cdx01_SAL_VENDCD.PrefixCode = "";
            this.cdx01_SAL_VENDCD.Size = new System.Drawing.Size(245, 21);
            this.cdx01_SAL_VENDCD.TabIndex = 35;
            this.cdx01_SAL_VENDCD.Tag = null;
            this.cdx01_SAL_VENDCD.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_SAL_VENDCD_ButtonClickAfter);
            // 
            // lbl01_CUSTNM
            // 
            this.lbl01_CUSTNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_CUSTNM.AutoFontSizeMinValue = 9F;
            this.lbl01_CUSTNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_CUSTNM.Location = new System.Drawing.Point(13, 114);
            this.lbl01_CUSTNM.Name = "lbl01_CUSTNM";
            this.lbl01_CUSTNM.Size = new System.Drawing.Size(100, 16);
            this.lbl01_CUSTNM.TabIndex = 33;
            this.lbl01_CUSTNM.Tag = null;
            this.lbl01_CUSTNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_CUSTNM.Value = "고객사";
            // 
            // lbl01_OCCUR_DATE
            // 
            this.lbl01_OCCUR_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_OCCUR_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_OCCUR_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_OCCUR_DATE.Location = new System.Drawing.Point(13, 66);
            this.lbl01_OCCUR_DATE.Name = "lbl01_OCCUR_DATE";
            this.lbl01_OCCUR_DATE.Size = new System.Drawing.Size(100, 16);
            this.lbl01_OCCUR_DATE.TabIndex = 32;
            this.lbl01_OCCUR_DATE.Tag = null;
            this.lbl01_OCCUR_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_OCCUR_DATE.Value = "발생일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 34);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(245, 20);
            this.cbo01_BIZCD.TabIndex = 31;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(13, 19);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 16);
            this.lbl01_BIZNM.TabIndex = 30;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.txt01_PARTNO_PARTNONM);
            this.panel1.Controls.Add(this.lbl01_RET_PARTNO_PARTNM);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.cbo01_JOB_TYPE);
            this.panel1.Controls.Add(this.cbo01_RTN_DIV);
            this.panel1.Controls.Add(this.lbl01_JOB_TYPE);
            this.panel1.Controls.Add(this.dte01_RTN_DATE_FROM);
            this.panel1.Controls.Add(this.dte01_RTN_DATE_TO);
            this.panel1.Controls.Add(this.lbl01_RET_DIV);
            this.panel1.Controls.Add(this.lbl01_ITEM);
            this.panel1.Controls.Add(this.cdx01_ITEMCD);
            this.panel1.Controls.Add(this.cdx01_SAL_VENDCD);
            this.panel1.Controls.Add(this.lbl01_VIN);
            this.panel1.Controls.Add(this.cdx01_VINCD);
            this.panel1.Controls.Add(this.lbl01_CUST_PLANT);
            this.panel1.Controls.Add(this.cbo01_CUST_PLANT);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.lbl01_OCCUR_DATE);
            this.panel1.Controls.Add(this.heLabel1);
            this.panel1.Controls.Add(this.lbl01_CUSTNM);
            this.panel1.Location = new System.Drawing.Point(18, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 551);
            this.panel1.TabIndex = 9;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(13, 447);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(100, 16);
            this.lbl01_PLANT_DIV.TabIndex = 58;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(13, 466);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(245, 20);
            this.cbo01_PLANT_DIV.TabIndex = 57;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(297, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 259);
            this.panel2.TabIndex = 10;
            // 
            // QA30223
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30223";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30223)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNONM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RET_PARTNO_PARTNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_JOB_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RET_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUST_PLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_SAL_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30223;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO_PARTNONM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_RET_PARTNO_PARTNM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_RTN_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_JOB_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_JOB_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_RET_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ITEM;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_ITEMCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VIN;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_CUST_PLANT;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CUST_PLANT;
        private Ax.DEV.Utility.Controls.AxLabel heLabel1;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RTN_DATE_TO;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RTN_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_SAL_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CUSTNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OCCUR_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
