namespace Ax.SIS.WM.UI
{
    partial class WM20550
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WM20550));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn01_COLLAPSE = new System.Windows.Forms.RadioButton();
            this.btn01_EXPAND_MID = new System.Windows.Forms.RadioButton();
            this.btn01_EXPAND_ALL = new System.Windows.Forms.RadioButton();
            this.lbl03_Wave = new System.Windows.Forms.Label();
            this.dtp01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_DELI_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_NOTENO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_BARCODE_NOTE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NOTENO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BARCODE_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORNM)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
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
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.lbl03_Wave);
            this.panel2.Controls.Add(this.dtp01_EDATE);
            this.panel2.Controls.Add(this.dtp01_SDATE);
            this.panel2.Controls.Add(this.lbl01_DELI_DATE);
            this.panel2.Controls.Add(this.cdx01_VENDCD);
            this.panel2.Controls.Add(this.lbl01_VENDCD);
            this.panel2.Controls.Add(this.txt01_LOTNO);
            this.panel2.Controls.Add(this.lbl01_LOTNO);
            this.panel2.Controls.Add(this.txt01_NOTENO);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_BARCODE_NOTE);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZNM);
            this.panel2.Controls.Add(this.cbo01_CORCD);
            this.panel2.Controls.Add(this.lbl01_CORNM);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn01_COLLAPSE);
            this.groupBox1.Controls.Add(this.btn01_EXPAND_MID);
            this.groupBox1.Controls.Add(this.btn01_EXPAND_ALL);
            this.groupBox1.Location = new System.Drawing.Point(5, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 95);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            // 
            // btn01_COLLAPSE
            // 
            this.btn01_COLLAPSE.AutoSize = true;
            this.btn01_COLLAPSE.Location = new System.Drawing.Point(6, 64);
            this.btn01_COLLAPSE.Name = "btn01_COLLAPSE";
            this.btn01_COLLAPSE.Size = new System.Drawing.Size(87, 19);
            this.btn01_COLLAPSE.TabIndex = 1;
            this.btn01_COLLAPSE.Text = "COLLAPSE";
            this.btn01_COLLAPSE.UseVisualStyleBackColor = true;
            // 
            // btn01_EXPAND_MID
            // 
            this.btn01_EXPAND_MID.AutoSize = true;
            this.btn01_EXPAND_MID.Location = new System.Drawing.Point(6, 42);
            this.btn01_EXPAND_MID.Name = "btn01_EXPAND_MID";
            this.btn01_EXPAND_MID.Size = new System.Drawing.Size(100, 19);
            this.btn01_EXPAND_MID.TabIndex = 0;
            this.btn01_EXPAND_MID.Text = "EXPAND MID";
            this.btn01_EXPAND_MID.UseVisualStyleBackColor = true;
            this.btn01_EXPAND_MID.CheckedChanged += new System.EventHandler(this.btn01_EXPAND_CheckedChanged);
            // 
            // btn01_EXPAND_ALL
            // 
            this.btn01_EXPAND_ALL.AutoSize = true;
            this.btn01_EXPAND_ALL.Checked = true;
            this.btn01_EXPAND_ALL.Location = new System.Drawing.Point(6, 20);
            this.btn01_EXPAND_ALL.Name = "btn01_EXPAND_ALL";
            this.btn01_EXPAND_ALL.Size = new System.Drawing.Size(98, 19);
            this.btn01_EXPAND_ALL.TabIndex = 0;
            this.btn01_EXPAND_ALL.TabStop = true;
            this.btn01_EXPAND_ALL.Text = "EXPAND ALL";
            this.btn01_EXPAND_ALL.UseVisualStyleBackColor = true;
            // 
            // lbl03_Wave
            // 
            this.lbl03_Wave.AutoSize = true;
            this.lbl03_Wave.Location = new System.Drawing.Point(128, 85);
            this.lbl03_Wave.Name = "lbl03_Wave";
            this.lbl03_Wave.Size = new System.Drawing.Size(14, 15);
            this.lbl03_Wave.TabIndex = 121;
            this.lbl03_Wave.Text = "~";
            // 
            // dtp01_EDATE
            // 
            this.dtp01_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_EDATE.Location = new System.Drawing.Point(146, 79);
            this.dtp01_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_EDATE.Name = "dtp01_EDATE";
            this.dtp01_EDATE.OriginalFormat = "";
            this.dtp01_EDATE.Size = new System.Drawing.Size(119, 21);
            this.dtp01_EDATE.TabIndex = 120;
            // 
            // dtp01_SDATE
            // 
            this.dtp01_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_SDATE.Location = new System.Drawing.Point(5, 79);
            this.dtp01_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_SDATE.Name = "dtp01_SDATE";
            this.dtp01_SDATE.OriginalFormat = "";
            this.dtp01_SDATE.Size = new System.Drawing.Size(119, 21);
            this.dtp01_SDATE.TabIndex = 119;
            // 
            // lbl01_DELI_DATE
            // 
            this.lbl01_DELI_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELI_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_DELI_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DELI_DATE.Location = new System.Drawing.Point(5, 53);
            this.lbl01_DELI_DATE.Name = "lbl01_DELI_DATE";
            this.lbl01_DELI_DATE.Size = new System.Drawing.Size(261, 23);
            this.lbl01_DELI_DATE.TabIndex = 118;
            this.lbl01_DELI_DATE.Tag = null;
            this.lbl01_DELI_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DELI_DATE.Value = "DELI_DATE";
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(5, 127);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(261, 21);
            this.cdx01_VENDCD.TabIndex = 78;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_VENDCD.Location = new System.Drawing.Point(5, 103);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(261, 21);
            this.lbl01_VENDCD.TabIndex = 79;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_VENDCD.Value = "Vender Code";
            this.lbl01_VENDCD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_LOTNO.Location = new System.Drawing.Point(4, 271);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_LOTNO.TabIndex = 67;
            this.txt01_LOTNO.Tag = null;
            // 
            // lbl01_LOTNO
            // 
            this.lbl01_LOTNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_LOTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LOTNO.Location = new System.Drawing.Point(4, 247);
            this.lbl01_LOTNO.Name = "lbl01_LOTNO";
            this.lbl01_LOTNO.Size = new System.Drawing.Size(261, 21);
            this.lbl01_LOTNO.TabIndex = 66;
            this.lbl01_LOTNO.Tag = null;
            this.lbl01_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LOTNO.Value = "_매출품번";
            // 
            // txt01_NOTENO
            // 
            this.txt01_NOTENO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_NOTENO.Location = new System.Drawing.Point(5, 175);
            this.txt01_NOTENO.Name = "txt01_NOTENO";
            this.txt01_NOTENO.Size = new System.Drawing.Size(261, 21);
            this.txt01_NOTENO.TabIndex = 51;
            this.txt01_NOTENO.Tag = null;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_PARTNO.Location = new System.Drawing.Point(5, 223);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_PARTNO.TabIndex = 51;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_BARCODE_NOTE
            // 
            this.lbl01_BARCODE_NOTE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_BARCODE_NOTE.AutoFontSizeMaxValue = 9F;
            this.lbl01_BARCODE_NOTE.AutoFontSizeMinValue = 9F;
            this.lbl01_BARCODE_NOTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BARCODE_NOTE.Location = new System.Drawing.Point(5, 151);
            this.lbl01_BARCODE_NOTE.Name = "lbl01_BARCODE_NOTE";
            this.lbl01_BARCODE_NOTE.Size = new System.Drawing.Size(261, 21);
            this.lbl01_BARCODE_NOTE.TabIndex = 50;
            this.lbl01_BARCODE_NOTE.Tag = null;
            this.lbl01_BARCODE_NOTE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BARCODE_NOTE.Value = "Note no";
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(5, 199);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.lbl01_PARTNO.TabIndex = 50;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "_매출품번";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(141, 30);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(125, 23);
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
            this.lbl01_BIZNM.Value = "_사업장명";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(5, 30);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(125, 23);
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
            this.lbl01_CORNM.Value = "_법인명";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 950;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 2;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 736);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 3;
            this.grd01.UseCustomHighlight = true;
            // 
            // WM20550
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "WM20550";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NOTENO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BARCODE_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORNM)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
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
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LOTNO;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_NOTENO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BARCODE_NOTE;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private System.Windows.Forms.Label lbl03_Wave;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DELI_DATE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton btn01_COLLAPSE;
        private System.Windows.Forms.RadioButton btn01_EXPAND_ALL;
        private System.Windows.Forms.RadioButton btn01_EXPAND_MID;
    }
}
