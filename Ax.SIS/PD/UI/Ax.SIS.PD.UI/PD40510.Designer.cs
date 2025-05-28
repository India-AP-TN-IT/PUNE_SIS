namespace Ax.SIS.PD.UI
{
    partial class PD40510
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40510));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt01_MOLDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MOLDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_INSPECT_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_BEG_INSPEC_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_END_INSPEC_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grp01_PD40510_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            this.panel3.SuspendLayout();
            this.grp01_PD40510_GRP_1.SuspendLayout();
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
            this.panel2.Controls.Add(this.txt01_MOLDNO);
            this.panel2.Controls.Add(this.lbl01_MOLDNO);
            this.panel2.Controls.Add(this.txt01_LOTNO);
            this.panel2.Controls.Add(this.lbl01_LOTNO);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.cbl01_INSTALL_POS);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl01_INSTALL_POS);
            this.panel2.Controls.Add(this.lbl01_INSPECT_DATE);
            this.panel2.Controls.Add(this.dtp01_BEG_INSPEC_DATE);
            this.panel2.Controls.Add(this.dtp01_END_INSPEC_DATE);
            this.panel2.Controls.Add(this.cbl01_LINECD);
            this.panel2.Controls.Add(this.lbl01_BIZCD);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_LINECD);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // txt01_MOLDNO
            // 
            this.txt01_MOLDNO.Location = new System.Drawing.Point(3, 334);
            this.txt01_MOLDNO.Name = "txt01_MOLDNO";
            this.txt01_MOLDNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_MOLDNO.TabIndex = 106;
            this.txt01_MOLDNO.Tag = null;
            // 
            // lbl01_MOLDNO
            // 
            this.lbl01_MOLDNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_MOLDNO.AutoFontSizeMinValue = 9F;
            this.lbl01_MOLDNO.BackColor = System.Drawing.Color.White;
            this.lbl01_MOLDNO.Location = new System.Drawing.Point(3, 308);
            this.lbl01_MOLDNO.Name = "lbl01_MOLDNO";
            this.lbl01_MOLDNO.Size = new System.Drawing.Size(100, 23);
            this.lbl01_MOLDNO.TabIndex = 105;
            this.lbl01_MOLDNO.Tag = null;
            this.lbl01_MOLDNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_MOLDNO.Value = "금형번호";
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.Location = new System.Drawing.Point(3, 279);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_LOTNO.TabIndex = 104;
            this.txt01_LOTNO.Tag = null;
            this.txt01_LOTNO.Visible = false;
            // 
            // lbl01_LOTNO
            // 
            this.lbl01_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_LOTNO.BackColor = System.Drawing.Color.White;
            this.lbl01_LOTNO.Location = new System.Drawing.Point(3, 253);
            this.lbl01_LOTNO.Name = "lbl01_LOTNO";
            this.lbl01_LOTNO.Size = new System.Drawing.Size(100, 23);
            this.lbl01_LOTNO.TabIndex = 103;
            this.lbl01_LOTNO.Tag = null;
            this.lbl01_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_LOTNO.Value = "LOT NO";
            this.lbl01_LOTNO.Visible = false;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(3, 229);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_PARTNO.TabIndex = 102;
            this.txt01_PARTNO.Tag = null;
            this.txt01_PARTNO.Visible = false;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.White;
            this.lbl01_PARTNO.Location = new System.Drawing.Point(3, 203);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(100, 23);
            this.lbl01_PARTNO.TabIndex = 101;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "PART NO";
            this.lbl01_PARTNO.Visible = false;
            // 
            // cbl01_INSTALL_POS
            // 
            this.cbl01_INSTALL_POS.AddItemSeparator = ';';
            this.cbl01_INSTALL_POS.Caption = "";
            this.cbl01_INSTALL_POS.CaptionHeight = 17;
            this.cbl01_INSTALL_POS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_INSTALL_POS.ColumnCaptionHeight = 18;
            this.cbl01_INSTALL_POS.ColumnFooterHeight = 18;
            this.cbl01_INSTALL_POS.ContentHeight = 16;
            this.cbl01_INSTALL_POS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_INSTALL_POS.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_INSTALL_POS.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_INSTALL_POS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_INSTALL_POS.EditorHeight = 16;
            this.cbl01_INSTALL_POS.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_INSTALL_POS.Images"))));
            this.cbl01_INSTALL_POS.ItemHeight = 15;
            this.cbl01_INSTALL_POS.Location = new System.Drawing.Point(3, 178);
            this.cbl01_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl01_INSTALL_POS.MaxLength = 32767;
            this.cbl01_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INSTALL_POS.Name = "cbl01_INSTALL_POS";
            this.cbl01_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INSTALL_POS.Size = new System.Drawing.Size(226, 22);
            this.cbl01_INSTALL_POS.TabIndex = 100;
            this.cbl01_INSTALL_POS.PropBag = resources.GetString("cbl01_INSTALL_POS.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "~";
            // 
            // lbl01_INSTALL_POS
            // 
            this.lbl01_INSTALL_POS.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSTALL_POS.AutoFontSizeMinValue = 9F;
            this.lbl01_INSTALL_POS.BackColor = System.Drawing.Color.White;
            this.lbl01_INSTALL_POS.Location = new System.Drawing.Point(3, 152);
            this.lbl01_INSTALL_POS.Name = "lbl01_INSTALL_POS";
            this.lbl01_INSTALL_POS.Size = new System.Drawing.Size(100, 23);
            this.lbl01_INSTALL_POS.TabIndex = 98;
            this.lbl01_INSTALL_POS.Tag = null;
            this.lbl01_INSTALL_POS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_INSTALL_POS.Value = "위치";
            // 
            // lbl01_INSPECT_DATE
            // 
            this.lbl01_INSPECT_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPECT_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPECT_DATE.BackColor = System.Drawing.Color.White;
            this.lbl01_INSPECT_DATE.Location = new System.Drawing.Point(3, 51);
            this.lbl01_INSPECT_DATE.Name = "lbl01_INSPECT_DATE";
            this.lbl01_INSPECT_DATE.Size = new System.Drawing.Size(100, 23);
            this.lbl01_INSPECT_DATE.TabIndex = 95;
            this.lbl01_INSPECT_DATE.Tag = null;
            this.lbl01_INSPECT_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_INSPECT_DATE.Value = "검사일자";
            // 
            // dtp01_BEG_INSPEC_DATE
            // 
            this.dtp01_BEG_INSPEC_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_INSPEC_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_INSPEC_DATE.Location = new System.Drawing.Point(3, 77);
            this.dtp01_BEG_INSPEC_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_BEG_INSPEC_DATE.Name = "dtp01_BEG_INSPEC_DATE";
            this.dtp01_BEG_INSPEC_DATE.OriginalFormat = "";
            this.dtp01_BEG_INSPEC_DATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_BEG_INSPEC_DATE.TabIndex = 96;
            // 
            // dtp01_END_INSPEC_DATE
            // 
            this.dtp01_END_INSPEC_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_END_INSPEC_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_END_INSPEC_DATE.Location = new System.Drawing.Point(129, 77);
            this.dtp01_END_INSPEC_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_END_INSPEC_DATE.Name = "dtp01_END_INSPEC_DATE";
            this.dtp01_END_INSPEC_DATE.OriginalFormat = "";
            this.dtp01_END_INSPEC_DATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_END_INSPEC_DATE.TabIndex = 97;
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(3, 127);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_LINECD.TabIndex = 94;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.White;
            this.lbl01_BIZCD.Location = new System.Drawing.Point(3, 2);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(100, 23);
            this.lbl01_BIZCD.TabIndex = 92;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZCD.Value = "사업장코드";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(3, 28);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 91;
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.White;
            this.lbl01_LINECD.Location = new System.Drawing.Point(3, 101);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 23);
            this.lbl01_LINECD.TabIndex = 93;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_LINECD.Value = "라인코드";
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
            this.panel3.Controls.Add(this.grp01_PD40510_GRP_1);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 4;
            // 
            // grp01_PD40510_GRP_1
            // 
            this.grp01_PD40510_GRP_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD40510_GRP_1.Controls.Add(this.grd01);
            this.grp01_PD40510_GRP_1.Location = new System.Drawing.Point(3, 8);
            this.grp01_PD40510_GRP_1.Name = "grp01_PD40510_GRP_1";
            this.grp01_PD40510_GRP_1.Size = new System.Drawing.Size(736, 725);
            this.grp01_PD40510_GRP_1.TabIndex = 3;
            this.grp01_PD40510_GRP_1.TabStop = false;
            this.grp01_PD40510_GRP_1.Text = "금형투입 집계";
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
            this.grd01.Size = new System.Drawing.Size(730, 705);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // PD40510
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD40510";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            this.panel3.ResumeLayout(false);
            this.grp01_PD40510_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox grp01_PD40510_GRP_1;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LOTNO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSTALL_POS;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPECT_DATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_BEG_INSPEC_DATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_END_INSPEC_DATE;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_MOLDNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MOLDNO;



    }
}
