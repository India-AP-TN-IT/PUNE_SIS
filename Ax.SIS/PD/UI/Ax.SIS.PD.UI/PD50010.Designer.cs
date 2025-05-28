namespace Ax.SIS.PD.UI
{
    partial class PD50010
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_DELIVERY_NOTE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_DELIVERY_NOTE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_INVOICENO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_INVOICENO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DASH = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpg01_TOTAL1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01 = new System.Windows.Forms.GroupBox();
            this.btn01_FILE_SAVE = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_FILE_READ = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_FILE_FIND = new Ax.DEV.Utility.Controls.AxButton();
            this.txt_FILE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl_FIEL = new Ax.DEV.Utility.Controls.AxLabel();
            this.tpg01_DETAIL1 = new System.Windows.Forms.TabPage();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DELIVERY_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELIVERY_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INVOICENO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INVOICENO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORNM)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpg01_TOTAL1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.grp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FILE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_FIEL)).BeginInit();
            this.tpg01_DETAIL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
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
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.txt01_DELIVERY_NOTE);
            this.panel2.Controls.Add(this.lbl01_DELIVERY_NOTE);
            this.panel2.Controls.Add(this.txt01_INVOICENO);
            this.panel2.Controls.Add(this.lbl01_INVOICENO);
            this.panel2.Controls.Add(this.lbl01_DASH);
            this.panel2.Controls.Add(this.dte01_EDATE);
            this.panel2.Controls.Add(this.dte01_SDATE);
            this.panel2.Controls.Add(this.lbl01_STD_DATE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZNM);
            this.panel2.Controls.Add(this.cbo01_CORCD);
            this.panel2.Controls.Add(this.lbl01_CORNM);
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 710);
            this.panel2.TabIndex = 1;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(6, 265);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_PARTNO.TabIndex = 139;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(6, 241);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.lbl01_PARTNO.TabIndex = 138;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "Part No (%)";
            // 
            // txt01_DELIVERY_NOTE
            // 
            this.txt01_DELIVERY_NOTE.Location = new System.Drawing.Point(6, 143);
            this.txt01_DELIVERY_NOTE.Name = "txt01_DELIVERY_NOTE";
            this.txt01_DELIVERY_NOTE.Size = new System.Drawing.Size(261, 21);
            this.txt01_DELIVERY_NOTE.TabIndex = 137;
            this.txt01_DELIVERY_NOTE.Tag = null;
            // 
            // lbl01_DELIVERY_NOTE
            // 
            this.lbl01_DELIVERY_NOTE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELIVERY_NOTE.AutoFontSizeMinValue = 9F;
            this.lbl01_DELIVERY_NOTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DELIVERY_NOTE.Location = new System.Drawing.Point(6, 119);
            this.lbl01_DELIVERY_NOTE.Name = "lbl01_DELIVERY_NOTE";
            this.lbl01_DELIVERY_NOTE.Size = new System.Drawing.Size(261, 21);
            this.lbl01_DELIVERY_NOTE.TabIndex = 136;
            this.lbl01_DELIVERY_NOTE.Tag = null;
            this.lbl01_DELIVERY_NOTE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DELIVERY_NOTE.Value = "Delivery Note (%)";
            // 
            // txt01_INVOICENO
            // 
            this.txt01_INVOICENO.Location = new System.Drawing.Point(6, 202);
            this.txt01_INVOICENO.Name = "txt01_INVOICENO";
            this.txt01_INVOICENO.Size = new System.Drawing.Size(261, 21);
            this.txt01_INVOICENO.TabIndex = 135;
            this.txt01_INVOICENO.Tag = null;
            // 
            // lbl01_INVOICENO
            // 
            this.lbl01_INVOICENO.AutoFontSizeMaxValue = 9F;
            this.lbl01_INVOICENO.AutoFontSizeMinValue = 9F;
            this.lbl01_INVOICENO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INVOICENO.Location = new System.Drawing.Point(6, 178);
            this.lbl01_INVOICENO.Name = "lbl01_INVOICENO";
            this.lbl01_INVOICENO.Size = new System.Drawing.Size(261, 21);
            this.lbl01_INVOICENO.TabIndex = 134;
            this.lbl01_INVOICENO.Tag = null;
            this.lbl01_INVOICENO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INVOICENO.Value = "Invoice No (%)";
            // 
            // lbl01_DASH
            // 
            this.lbl01_DASH.AutoFontSizeMaxValue = 9F;
            this.lbl01_DASH.AutoFontSizeMinValue = 9F;
            this.lbl01_DASH.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DASH.Location = new System.Drawing.Point(111, 88);
            this.lbl01_DASH.Name = "lbl01_DASH";
            this.lbl01_DASH.Size = new System.Drawing.Size(49, 21);
            this.lbl01_DASH.TabIndex = 133;
            this.lbl01_DASH.Tag = null;
            this.lbl01_DASH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DASH.Value = "~";
            // 
            // dte01_EDATE
            // 
            this.dte01_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_EDATE.Location = new System.Drawing.Point(166, 86);
            this.dte01_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_EDATE.Name = "dte01_EDATE";
            this.dte01_EDATE.OriginalFormat = "";
            this.dte01_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_EDATE.TabIndex = 132;
            // 
            // dte01_SDATE
            // 
            this.dte01_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_SDATE.Location = new System.Drawing.Point(5, 86);
            this.dte01_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_SDATE.Name = "dte01_SDATE";
            this.dte01_SDATE.OriginalFormat = "";
            this.dte01_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_SDATE.TabIndex = 131;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(5, 62);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(261, 21);
            this.lbl01_STD_DATE.TabIndex = 128;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "Print Date";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(141, 30);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(125, 20);
            this.cbo01_BIZCD.TabIndex = 33;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(141, 6);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(125, 21);
            this.lbl01_BIZNM.TabIndex = 32;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "Business Name";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(5, 30);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(125, 20);
            this.cbo01_CORCD.TabIndex = 31;
            // 
            // lbl01_CORNM
            // 
            this.lbl01_CORNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORNM.AutoFontSizeMinValue = 9F;
            this.lbl01_CORNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORNM.Location = new System.Drawing.Point(5, 6);
            this.lbl01_CORNM.Name = "lbl01_CORNM";
            this.lbl01_CORNM.Size = new System.Drawing.Size(125, 21);
            this.lbl01_CORNM.TabIndex = 30;
            this.lbl01_CORNM.Tag = null;
            this.lbl01_CORNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORNM.Value = "Corporation Name";
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
            this.panel3.Location = new System.Drawing.Point(279, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 730);
            this.panel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpg01_TOTAL1);
            this.tabControl1.Controls.Add(this.tpg01_DETAIL1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 730);
            this.tabControl1.TabIndex = 0;
            // 
            // tpg01_TOTAL1
            // 
            this.tpg01_TOTAL1.Controls.Add(this.groupBox1);
            this.tpg01_TOTAL1.Controls.Add(this.grp01);
            this.tpg01_TOTAL1.Location = new System.Drawing.Point(4, 22);
            this.tpg01_TOTAL1.Name = "tpg01_TOTAL1";
            this.tpg01_TOTAL1.Size = new System.Drawing.Size(734, 704);
            this.tpg01_TOTAL1.TabIndex = 0;
            //Changed KMI to KIN
            this.tpg01_TOTAL1.Text = "KIN Delivery Note Upload";
            this.tpg01_TOTAL1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grd01);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 656);
            this.groupBox1.TabIndex = 140;
            this.groupBox1.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(728, 636);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // grp01
            // 
            this.grp01.Controls.Add(this.btn01_FILE_SAVE);
            this.grp01.Controls.Add(this.btn01_FILE_READ);
            this.grp01.Controls.Add(this.btn01_FILE_FIND);
            this.grp01.Controls.Add(this.txt_FILE);
            this.grp01.Controls.Add(this.lbl_FIEL);
            this.grp01.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01.Location = new System.Drawing.Point(0, 0);
            this.grp01.Name = "grp01";
            this.grp01.Size = new System.Drawing.Size(734, 48);
            this.grp01.TabIndex = 139;
            this.grp01.TabStop = false;
            // 
            // btn01_FILE_SAVE
            // 
            this.btn01_FILE_SAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_FILE_SAVE.Location = new System.Drawing.Point(620, 17);
            this.btn01_FILE_SAVE.Name = "btn01_FILE_SAVE";
            this.btn01_FILE_SAVE.Size = new System.Drawing.Size(108, 23);
            this.btn01_FILE_SAVE.TabIndex = 141;
            this.btn01_FILE_SAVE.Text = "SAVE";
            this.btn01_FILE_SAVE.UseVisualStyleBackColor = true;
            this.btn01_FILE_SAVE.Click += new System.EventHandler(this.btn01_FILE_SAVE_Click);
            // 
            // btn01_FILE_READ
            // 
            this.btn01_FILE_READ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_FILE_READ.Location = new System.Drawing.Point(443, 17);
            this.btn01_FILE_READ.Name = "btn01_FILE_READ";
            this.btn01_FILE_READ.Size = new System.Drawing.Size(82, 23);
            this.btn01_FILE_READ.TabIndex = 141;
            this.btn01_FILE_READ.Text = "READ";
            this.btn01_FILE_READ.UseVisualStyleBackColor = true;
            this.btn01_FILE_READ.Visible = false;
            this.btn01_FILE_READ.Click += new System.EventHandler(this.btn01_FILE_READ_Click);
            // 
            // btn01_FILE_FIND
            // 
            this.btn01_FILE_FIND.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_FILE_FIND.Location = new System.Drawing.Point(531, 17);
            this.btn01_FILE_FIND.Name = "btn01_FILE_FIND";
            this.btn01_FILE_FIND.Size = new System.Drawing.Size(83, 23);
            this.btn01_FILE_FIND.TabIndex = 142;
            this.btn01_FILE_FIND.Text = "FIND";
            this.btn01_FILE_FIND.UseVisualStyleBackColor = true;
            this.btn01_FILE_FIND.Click += new System.EventHandler(this.btn01_FILE_FIND_Click);
            // 
            // txt_FILE
            // 
            this.txt_FILE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FILE.Location = new System.Drawing.Point(114, 18);
            this.txt_FILE.Name = "txt_FILE";
            this.txt_FILE.Size = new System.Drawing.Size(411, 21);
            this.txt_FILE.TabIndex = 140;
            this.txt_FILE.Tag = null;
            // 
            // lbl_FIEL
            // 
            this.lbl_FIEL.AutoFontSizeMaxValue = 9F;
            this.lbl_FIEL.AutoFontSizeMinValue = 9F;
            this.lbl_FIEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl_FIEL.Location = new System.Drawing.Point(3, 18);
            this.lbl_FIEL.Name = "lbl_FIEL";
            this.lbl_FIEL.Size = new System.Drawing.Size(105, 21);
            this.lbl_FIEL.TabIndex = 139;
            this.lbl_FIEL.Tag = null;
            this.lbl_FIEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FIEL.Value = "FILE";
            // 
            // tpg01_DETAIL1
            // 
            this.tpg01_DETAIL1.Controls.Add(this.grd02);
            this.tpg01_DETAIL1.Location = new System.Drawing.Point(4, 22);
            this.tpg01_DETAIL1.Name = "tpg01_DETAIL1";
            this.tpg01_DETAIL1.Size = new System.Drawing.Size(734, 704);
            this.tpg01_DETAIL1.TabIndex = 1;
            this.tpg01_DETAIL1.Text = "SAP Compare";
            this.tpg01_DETAIL1.UseVisualStyleBackColor = true;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(734, 704);
            this.grd02.TabIndex = 1;
            this.grd02.UseCustomHighlight = true;
            // 
            // PD50010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD50010";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DELIVERY_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELIVERY_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INVOICENO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INVOICENO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORNM)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpg01_TOTAL1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.grp01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_FILE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_FIEL)).EndInit();
            this.tpg01_DETAIL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CORNM;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpg01_TOTAL1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.TabPage tpg01_DETAIL1;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private DEV.Utility.Controls.AxTextBox txt01_INVOICENO;
        private DEV.Utility.Controls.AxLabel lbl01_INVOICENO;
        private DEV.Utility.Controls.AxLabel lbl01_DASH;
        private DEV.Utility.Controls.AxDateEdit dte01_EDATE;
        private DEV.Utility.Controls.AxDateEdit dte01_SDATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxTextBox txt01_DELIVERY_NOTE;
        private DEV.Utility.Controls.AxLabel lbl01_DELIVERY_NOTE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grp01;
        private DEV.Utility.Controls.AxButton btn01_FILE_READ;
        private DEV.Utility.Controls.AxButton btn01_FILE_FIND;
        private DEV.Utility.Controls.AxTextBox txt_FILE;
        private DEV.Utility.Controls.AxLabel lbl_FIEL;
        private DEV.Utility.Controls.AxButton btn01_FILE_SAVE;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
    }
}
