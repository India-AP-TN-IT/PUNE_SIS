namespace Ax.SIS.PD.UI
{
    partial class PD40390
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40390));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk01_OEM_YN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbl01_VINCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl02_VEHICLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.heTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl05_PARTNOTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl04_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_INSPEC_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_INSPEC_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl06_WORK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl03_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl07_PD40390_1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_VEHICLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_PARTNOTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_WORK_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_LINE)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl07_PD40390_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
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
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chk01_OEM_YN);
            this.panel2.Controls.Add(this.cbl01_VINCD);
            this.panel2.Controls.Add(this.lbl02_VEHICLE);
            this.panel2.Controls.Add(this.heTextBox2);
            this.panel2.Controls.Add(this.heTextBox1);
            this.panel2.Controls.Add(this.lbl05_PARTNOTITLE);
            this.panel2.Controls.Add(this.lbl04_LOTNO);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.cbl01_LINECD);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp01_INSPEC_EDATE);
            this.panel2.Controls.Add(this.dtp01_INSPEC_SDATE);
            this.panel2.Controls.Add(this.lbl06_WORK_DATE);
            this.panel2.Controls.Add(this.lbl03_LINE);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // chk01_OEM_YN
            // 
            this.chk01_OEM_YN.AutoSize = true;
            this.chk01_OEM_YN.Location = new System.Drawing.Point(16, 338);
            this.chk01_OEM_YN.Name = "chk01_OEM_YN";
            this.chk01_OEM_YN.Size = new System.Drawing.Size(92, 16);
            this.chk01_OEM_YN.TabIndex = 105;
            this.chk01_OEM_YN.Text = "OEM만 보기";
            this.chk01_OEM_YN.UseVisualStyleBackColor = true;
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
            this.cbl01_VINCD.Location = new System.Drawing.Point(16, 80);
            this.cbl01_VINCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_VINCD.MaxDropDownItems = ((short)(5));
            this.cbl01_VINCD.MaxLength = 32767;
            this.cbl01_VINCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_VINCD.Name = "cbl01_VINCD";
            this.cbl01_VINCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_VINCD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_VINCD.TabIndex = 104;
            this.cbl01_VINCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_VINCD_BeforeOpen);
            this.cbl01_VINCD.PropBag = resources.GetString("cbl01_VINCD.PropBag");
            // 
            // lbl02_VEHICLE
            // 
            this.lbl02_VEHICLE.AutoFontSizeMaxValue = 9F;
            this.lbl02_VEHICLE.AutoFontSizeMinValue = 9F;
            this.lbl02_VEHICLE.BackColor = System.Drawing.Color.Transparent;
            this.lbl02_VEHICLE.Location = new System.Drawing.Point(16, 65);
            this.lbl02_VEHICLE.Name = "lbl02_VEHICLE";
            this.lbl02_VEHICLE.Size = new System.Drawing.Size(226, 12);
            this.lbl02_VEHICLE.TabIndex = 103;
            this.lbl02_VEHICLE.Tag = null;
            this.lbl02_VEHICLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_VEHICLE.Value = "차종";
            // 
            // heTextBox2
            // 
            this.heTextBox2.Location = new System.Drawing.Point(16, 232);
            this.heTextBox2.Name = "heTextBox2";
            this.heTextBox2.Size = new System.Drawing.Size(226, 21);
            this.heTextBox2.TabIndex = 102;
            this.heTextBox2.Tag = null;
            // 
            // heTextBox1
            // 
            this.heTextBox1.Location = new System.Drawing.Point(16, 181);
            this.heTextBox1.Name = "heTextBox1";
            this.heTextBox1.Size = new System.Drawing.Size(226, 21);
            this.heTextBox1.TabIndex = 101;
            this.heTextBox1.Tag = null;
            // 
            // lbl05_PARTNOTITLE
            // 
            this.lbl05_PARTNOTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl05_PARTNOTITLE.AutoFontSizeMinValue = 9F;
            this.lbl05_PARTNOTITLE.BackColor = System.Drawing.Color.Transparent;
            this.lbl05_PARTNOTITLE.Location = new System.Drawing.Point(16, 217);
            this.lbl05_PARTNOTITLE.Name = "lbl05_PARTNOTITLE";
            this.lbl05_PARTNOTITLE.Size = new System.Drawing.Size(226, 12);
            this.lbl05_PARTNOTITLE.TabIndex = 100;
            this.lbl05_PARTNOTITLE.Tag = null;
            this.lbl05_PARTNOTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl05_PARTNOTITLE.Value = "품번";
            // 
            // lbl04_LOTNO
            // 
            this.lbl04_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lbl04_LOTNO.AutoFontSizeMinValue = 9F;
            this.lbl04_LOTNO.BackColor = System.Drawing.Color.Transparent;
            this.lbl04_LOTNO.Location = new System.Drawing.Point(16, 166);
            this.lbl04_LOTNO.Name = "lbl04_LOTNO";
            this.lbl04_LOTNO.Size = new System.Drawing.Size(226, 12);
            this.lbl04_LOTNO.TabIndex = 99;
            this.lbl04_LOTNO.Tag = null;
            this.lbl04_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl04_LOTNO.Value = "LOT NO";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(16, 17);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZNM2.TabIndex = 98;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(16, 32);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 97;
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(16, 130);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_LINECD.TabIndex = 95;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 94;
            this.label1.Text = "~";
            // 
            // dtp01_INSPEC_EDATE
            // 
            this.dtp01_INSPEC_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_INSPEC_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_INSPEC_EDATE.Location = new System.Drawing.Point(142, 283);
            this.dtp01_INSPEC_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_INSPEC_EDATE.Name = "dtp01_INSPEC_EDATE";
            this.dtp01_INSPEC_EDATE.OriginalFormat = "";
            this.dtp01_INSPEC_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_INSPEC_EDATE.TabIndex = 93;
            // 
            // dtp01_INSPEC_SDATE
            // 
            this.dtp01_INSPEC_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_INSPEC_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_INSPEC_SDATE.Location = new System.Drawing.Point(16, 283);
            this.dtp01_INSPEC_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_INSPEC_SDATE.Name = "dtp01_INSPEC_SDATE";
            this.dtp01_INSPEC_SDATE.OriginalFormat = "";
            this.dtp01_INSPEC_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_INSPEC_SDATE.TabIndex = 92;
            // 
            // lbl06_WORK_DATE
            // 
            this.lbl06_WORK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl06_WORK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl06_WORK_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl06_WORK_DATE.Location = new System.Drawing.Point(16, 268);
            this.lbl06_WORK_DATE.Name = "lbl06_WORK_DATE";
            this.lbl06_WORK_DATE.Size = new System.Drawing.Size(226, 12);
            this.lbl06_WORK_DATE.TabIndex = 91;
            this.lbl06_WORK_DATE.Tag = null;
            this.lbl06_WORK_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl06_WORK_DATE.Value = "작업일자";
            // 
            // lbl03_LINE
            // 
            this.lbl03_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl03_LINE.AutoFontSizeMinValue = 9F;
            this.lbl03_LINE.BackColor = System.Drawing.Color.Transparent;
            this.lbl03_LINE.Location = new System.Drawing.Point(16, 115);
            this.lbl03_LINE.Name = "lbl03_LINE";
            this.lbl03_LINE.Size = new System.Drawing.Size(226, 12);
            this.lbl03_LINE.TabIndex = 86;
            this.lbl03_LINE.Tag = null;
            this.lbl03_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl03_LINE.Value = "라인";
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
            this.panel3.Controls.Add(this.lbl07_PD40390_1);
            this.panel3.Controls.Add(this.grd02);
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 4;
            // 
            // lbl07_PD40390_1
            // 
            this.lbl07_PD40390_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl07_PD40390_1.AutoFontSizeMaxValue = 9F;
            this.lbl07_PD40390_1.AutoFontSizeMinValue = 9F;
            this.lbl07_PD40390_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl07_PD40390_1.Location = new System.Drawing.Point(3, 431);
            this.lbl07_PD40390_1.Name = "lbl07_PD40390_1";
            this.lbl07_PD40390_1.Size = new System.Drawing.Size(190, 23);
            this.lbl07_PD40390_1.TabIndex = 99;
            this.lbl07_PD40390_1.Tag = null;
            this.lbl07_PD40390_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl07_PD40390_1.Value = "통전검사내역";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 457);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(739, 276);
            this.grd02.TabIndex = 3;
            this.grd02.UseCustomHighlight = true;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 427);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // PD40390
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD40390";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_VEHICLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_PARTNOTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_WORK_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_LINE)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl07_PD40390_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_LINE;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_INSPEC_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_INSPEC_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl06_WORK_DATE;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox2;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl05_PARTNOTITLE;
        private Ax.DEV.Utility.Controls.AxLabel lbl04_LOTNO;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl07_PD40390_1;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_VINCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_VEHICLE;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_OEM_YN;



    }
}
