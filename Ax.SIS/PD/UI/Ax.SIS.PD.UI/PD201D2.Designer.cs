namespace Ax.SIS.PD.UI
{
    partial class PD201D2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD201D2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grp01_SELECTED_PRDT = new System.Windows.Forms.GroupBox();
            this.btn01_APPLY_CANCEL = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_QM_APPLY = new Ax.DEV.Utility.Controls.AxButton();
            this.txt02_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl07_PARTNOTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_ALC = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl06_ALC = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl05_LOTNO_TITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl06_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl05_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl04_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_INSPECT_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_BEG_INSPEC_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_END_INSPEC_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl03_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grp01_PD201D2_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grp01_SELECTED_PRDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl07_PARTNOTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_ALC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_ALC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_LOTNO_TITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_INSPECT_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_LINE)).BeginInit();
            this.panel3.SuspendLayout();
            this.grp01_PD201D2_1.SuspendLayout();
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
            this.panel2.Controls.Add(this.grp01_SELECTED_PRDT);
            this.panel2.Controls.Add(this.txt01_LOTNO);
            this.panel2.Controls.Add(this.lbl06_LOTNO);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl05_PARTNO);
            this.panel2.Controls.Add(this.cbl01_INSTALL_POS);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl04_POSTITLE);
            this.panel2.Controls.Add(this.lbl02_INSPECT_DATE);
            this.panel2.Controls.Add(this.dtp01_BEG_INSPEC_DATE);
            this.panel2.Controls.Add(this.dtp01_END_INSPEC_DATE);
            this.panel2.Controls.Add(this.cbl01_LINECD);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl03_LINE);
            this.panel2.Location = new System.Drawing.Point(2, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // grp01_SELECTED_PRDT
            // 
            this.grp01_SELECTED_PRDT.Controls.Add(this.btn01_APPLY_CANCEL);
            this.grp01_SELECTED_PRDT.Controls.Add(this.btn01_QM_APPLY);
            this.grp01_SELECTED_PRDT.Controls.Add(this.txt02_PARTNO);
            this.grp01_SELECTED_PRDT.Controls.Add(this.lbl07_PARTNOTITLE);
            this.grp01_SELECTED_PRDT.Controls.Add(this.txt02_ALC);
            this.grp01_SELECTED_PRDT.Controls.Add(this.lbl06_ALC);
            this.grp01_SELECTED_PRDT.Controls.Add(this.txt02_LOTNO);
            this.grp01_SELECTED_PRDT.Controls.Add(this.lbl05_LOTNO_TITLE);
            this.grp01_SELECTED_PRDT.Location = new System.Drawing.Point(3, 324);
            this.grp01_SELECTED_PRDT.Name = "grp01_SELECTED_PRDT";
            this.grp01_SELECTED_PRDT.Size = new System.Drawing.Size(267, 180);
            this.grp01_SELECTED_PRDT.TabIndex = 105;
            this.grp01_SELECTED_PRDT.TabStop = false;
            this.grp01_SELECTED_PRDT.Text = "선택된제품";
            // 
            // btn01_APPLY_CANCEL
            // 
            this.btn01_APPLY_CANCEL.Location = new System.Drawing.Point(166, 138);
            this.btn01_APPLY_CANCEL.Name = "btn01_APPLY_CANCEL";
            this.btn01_APPLY_CANCEL.Size = new System.Drawing.Size(90, 30);
            this.btn01_APPLY_CANCEL.TabIndex = 118;
            this.btn01_APPLY_CANCEL.Text = "승인취소";
            this.btn01_APPLY_CANCEL.UseVisualStyleBackColor = true;
            this.btn01_APPLY_CANCEL.Visible = false;
            // 
            // btn01_QM_APPLY
            // 
            this.btn01_QM_APPLY.Location = new System.Drawing.Point(76, 138);
            this.btn01_QM_APPLY.Name = "btn01_QM_APPLY";
            this.btn01_QM_APPLY.Size = new System.Drawing.Size(84, 30);
            this.btn01_QM_APPLY.TabIndex = 117;
            this.btn01_QM_APPLY.Text = "승인";
            this.btn01_QM_APPLY.UseVisualStyleBackColor = true;
            this.btn01_QM_APPLY.Click += new System.EventHandler(this.btn01_APPLY_Click);
            // 
            // txt02_PARTNO
            // 
            this.txt02_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_PARTNO.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt02_PARTNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt02_PARTNO.Location = new System.Drawing.Point(110, 89);
            this.txt02_PARTNO.Multiline = true;
            this.txt02_PARTNO.Name = "txt02_PARTNO";
            this.txt02_PARTNO.ReadOnly = true;
            this.txt02_PARTNO.Size = new System.Drawing.Size(146, 30);
            this.txt02_PARTNO.TabIndex = 116;
            this.txt02_PARTNO.Tag = "7";
            this.txt02_PARTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt02_PARTNO.Value = "";
            // 
            // lbl07_PARTNOTITLE
            // 
            this.lbl07_PARTNOTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl07_PARTNOTITLE.AutoFontSizeMinValue = 9F;
            this.lbl07_PARTNOTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl07_PARTNOTITLE.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl07_PARTNOTITLE.Location = new System.Drawing.Point(10, 89);
            this.lbl07_PARTNOTITLE.Name = "lbl07_PARTNOTITLE";
            this.lbl07_PARTNOTITLE.Size = new System.Drawing.Size(94, 30);
            this.lbl07_PARTNOTITLE.TabIndex = 115;
            this.lbl07_PARTNOTITLE.Tag = null;
            this.lbl07_PARTNOTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl07_PARTNOTITLE.Value = "품번";
            // 
            // txt02_ALC
            // 
            this.txt02_ALC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_ALC.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt02_ALC.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt02_ALC.Location = new System.Drawing.Point(110, 55);
            this.txt02_ALC.Multiline = true;
            this.txt02_ALC.Name = "txt02_ALC";
            this.txt02_ALC.ReadOnly = true;
            this.txt02_ALC.Size = new System.Drawing.Size(146, 30);
            this.txt02_ALC.TabIndex = 114;
            this.txt02_ALC.Tag = "7";
            this.txt02_ALC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt02_ALC.Value = "";
            // 
            // lbl06_ALC
            // 
            this.lbl06_ALC.AutoFontSizeMaxValue = 9F;
            this.lbl06_ALC.AutoFontSizeMinValue = 9F;
            this.lbl06_ALC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl06_ALC.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl06_ALC.Location = new System.Drawing.Point(10, 55);
            this.lbl06_ALC.Name = "lbl06_ALC";
            this.lbl06_ALC.Size = new System.Drawing.Size(94, 30);
            this.lbl06_ALC.TabIndex = 113;
            this.lbl06_ALC.Tag = null;
            this.lbl06_ALC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl06_ALC.Value = "ALC";
            // 
            // txt02_LOTNO
            // 
            this.txt02_LOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_LOTNO.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt02_LOTNO.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt02_LOTNO.Location = new System.Drawing.Point(110, 21);
            this.txt02_LOTNO.Multiline = true;
            this.txt02_LOTNO.Name = "txt02_LOTNO";
            this.txt02_LOTNO.ReadOnly = true;
            this.txt02_LOTNO.Size = new System.Drawing.Size(146, 30);
            this.txt02_LOTNO.TabIndex = 112;
            this.txt02_LOTNO.Tag = "7";
            this.txt02_LOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt02_LOTNO.Value = "";
            // 
            // lbl05_LOTNO_TITLE
            // 
            this.lbl05_LOTNO_TITLE.AutoFontSizeMaxValue = 9F;
            this.lbl05_LOTNO_TITLE.AutoFontSizeMinValue = 9F;
            this.lbl05_LOTNO_TITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl05_LOTNO_TITLE.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl05_LOTNO_TITLE.Location = new System.Drawing.Point(10, 21);
            this.lbl05_LOTNO_TITLE.Name = "lbl05_LOTNO_TITLE";
            this.lbl05_LOTNO_TITLE.Size = new System.Drawing.Size(94, 30);
            this.lbl05_LOTNO_TITLE.TabIndex = 111;
            this.lbl05_LOTNO_TITLE.Tag = null;
            this.lbl05_LOTNO_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl05_LOTNO_TITLE.Value = "LOT";
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.Location = new System.Drawing.Point(14, 279);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_LOTNO.TabIndex = 104;
            this.txt01_LOTNO.Tag = null;
            // 
            // lbl06_LOTNO
            // 
            this.lbl06_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lbl06_LOTNO.AutoFontSizeMinValue = 9F;
            this.lbl06_LOTNO.BackColor = System.Drawing.Color.White;
            this.lbl06_LOTNO.Location = new System.Drawing.Point(14, 264);
            this.lbl06_LOTNO.Name = "lbl06_LOTNO";
            this.lbl06_LOTNO.Size = new System.Drawing.Size(226, 12);
            this.lbl06_LOTNO.TabIndex = 103;
            this.lbl06_LOTNO.Tag = null;
            this.lbl06_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl06_LOTNO.Value = "LOTNO";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(14, 229);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_PARTNO.TabIndex = 102;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl05_PARTNO
            // 
            this.lbl05_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl05_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl05_PARTNO.BackColor = System.Drawing.Color.White;
            this.lbl05_PARTNO.Location = new System.Drawing.Point(14, 214);
            this.lbl05_PARTNO.Name = "lbl05_PARTNO";
            this.lbl05_PARTNO.Size = new System.Drawing.Size(226, 12);
            this.lbl05_PARTNO.TabIndex = 101;
            this.lbl05_PARTNO.Tag = null;
            this.lbl05_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl05_PARTNO.Value = "PARTNO";
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
            this.cbl01_INSTALL_POS.Location = new System.Drawing.Point(14, 178);
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
            this.label1.Location = new System.Drawing.Point(120, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "~";
            // 
            // lbl04_POSTITLE
            // 
            this.lbl04_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl04_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl04_POSTITLE.BackColor = System.Drawing.Color.White;
            this.lbl04_POSTITLE.Location = new System.Drawing.Point(14, 163);
            this.lbl04_POSTITLE.Name = "lbl04_POSTITLE";
            this.lbl04_POSTITLE.Size = new System.Drawing.Size(226, 12);
            this.lbl04_POSTITLE.TabIndex = 98;
            this.lbl04_POSTITLE.Tag = null;
            this.lbl04_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl04_POSTITLE.Value = "장착위치";
            // 
            // lbl02_INSPECT_DATE
            // 
            this.lbl02_INSPECT_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_INSPECT_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_INSPECT_DATE.BackColor = System.Drawing.Color.White;
            this.lbl02_INSPECT_DATE.Location = new System.Drawing.Point(14, 62);
            this.lbl02_INSPECT_DATE.Name = "lbl02_INSPECT_DATE";
            this.lbl02_INSPECT_DATE.Size = new System.Drawing.Size(226, 12);
            this.lbl02_INSPECT_DATE.TabIndex = 95;
            this.lbl02_INSPECT_DATE.Tag = null;
            this.lbl02_INSPECT_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_INSPECT_DATE.Value = "검사일자";
            // 
            // dtp01_BEG_INSPEC_DATE
            // 
            this.dtp01_BEG_INSPEC_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_INSPEC_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_INSPEC_DATE.Location = new System.Drawing.Point(14, 77);
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
            this.dtp01_END_INSPEC_DATE.Location = new System.Drawing.Point(140, 77);
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(14, 127);
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
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.White;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(14, 13);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZNM2.TabIndex = 92;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 28);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 91;
            // 
            // lbl03_LINE
            // 
            this.lbl03_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl03_LINE.AutoFontSizeMinValue = 9F;
            this.lbl03_LINE.BackColor = System.Drawing.Color.White;
            this.lbl03_LINE.Location = new System.Drawing.Point(14, 112);
            this.lbl03_LINE.Name = "lbl03_LINE";
            this.lbl03_LINE.Size = new System.Drawing.Size(226, 12);
            this.lbl03_LINE.TabIndex = 93;
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
            this.panel3.Controls.Add(this.grp01_PD201D2_1);
            this.panel3.Location = new System.Drawing.Point(279, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 4;
            // 
            // grp01_PD201D2_1
            // 
            this.grp01_PD201D2_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD201D2_1.Controls.Add(this.grd01);
            this.grp01_PD201D2_1.Location = new System.Drawing.Point(3, 8);
            this.grp01_PD201D2_1.Name = "grp01_PD201D2_1";
            this.grp01_PD201D2_1.Size = new System.Drawing.Size(736, 725);
            this.grp01_PD201D2_1.TabIndex = 3;
            this.grp01_PD201D2_1.TabStop = false;
            this.grp01_PD201D2_1.Text = "초/중/종품";
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
            // PD201D2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD201D2";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grp01_SELECTED_PRDT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt02_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl07_PARTNOTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_ALC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_ALC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_LOTNO_TITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_INSPECT_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_LINE)).EndInit();
            this.panel3.ResumeLayout(false);
            this.grp01_PD201D2_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl06_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl05_PARTNO;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSTALL_POS;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxLabel lbl04_POSTITLE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_INSPECT_DATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_BEG_INSPEC_DATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_END_INSPEC_DATE;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_LINE;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grp01_PD201D2_1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private System.Windows.Forms.GroupBox grp01_SELECTED_PRDT;
        private Ax.DEV.Utility.Controls.AxButton btn01_APPLY_CANCEL;
        private Ax.DEV.Utility.Controls.AxButton btn01_QM_APPLY;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl07_PARTNOTITLE;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_ALC;
        private Ax.DEV.Utility.Controls.AxLabel lbl06_ALC;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl05_LOTNO_TITLE;




    }
}
