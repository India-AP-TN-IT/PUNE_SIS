namespace Ax.SIS.XM.UI
{
    partial class XM30303
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_MODULE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SUBCODE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_CODE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_EXCLUDE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.rdo01_XM30303_RDO_2 = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.cdx01_SEARCH = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.rdo01_XM30303_RDO_1 = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.lbl01_SPLIT = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_LOG_YMD = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbp01_XM30303_TAB_1 = new System.Windows.Forms.TabPage();
            this.tbp01_XM30303_TAB_2 = new System.Windows.Forms.TabPage();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MODULE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_SEARCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SPLIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOG_YMD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbp01_XM30303_TAB_1.SuspendLayout();
            this.tbp01_XM30303_TAB_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(950, 34);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_MODULE);
            this.groupBox1.Controls.Add(this.cbo01_SUBCODE);
            this.groupBox1.Controls.Add(this.cbo01_CODE);
            this.groupBox1.Controls.Add(this.cbo01_SYSTEMCODE);
            this.groupBox1.Controls.Add(this.lbl01_SYSTEMCODE);
            this.groupBox1.Controls.Add(this.chk01_EXCLUDE);
            this.groupBox1.Controls.Add(this.rdo01_XM30303_RDO_2);
            this.groupBox1.Controls.Add(this.cdx01_SEARCH);
            this.groupBox1.Controls.Add(this.rdo01_XM30303_RDO_1);
            this.groupBox1.Controls.Add(this.lbl01_SPLIT);
            this.groupBox1.Controls.Add(this.dte01_EDATE);
            this.groupBox1.Controls.Add(this.lbl01_LOG_YMD);
            this.groupBox1.Controls.Add(this.dte01_SDATE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 75);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_MODULE
            // 
            this.lbl01_MODULE.AutoFontSizeMaxValue = 9F;
            this.lbl01_MODULE.AutoFontSizeMinValue = 9F;
            this.lbl01_MODULE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MODULE.Location = new System.Drawing.Point(262, 44);
            this.lbl01_MODULE.Name = "lbl01_MODULE";
            this.lbl01_MODULE.Size = new System.Drawing.Size(100, 20);
            this.lbl01_MODULE.TabIndex = 2;
            this.lbl01_MODULE.Tag = null;
            this.lbl01_MODULE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MODULE.Value = "모듈종류";
            // 
            // cbo01_SUBCODE
            // 
            this.cbo01_SUBCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SUBCODE.FormattingEnabled = true;
            this.cbo01_SUBCODE.Location = new System.Drawing.Point(496, 44);
            this.cbo01_SUBCODE.Name = "cbo01_SUBCODE";
            this.cbo01_SUBCODE.Size = new System.Drawing.Size(122, 20);
            this.cbo01_SUBCODE.TabIndex = 3;
            // 
            // cbo01_CODE
            // 
            this.cbo01_CODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CODE.FormattingEnabled = true;
            this.cbo01_CODE.Location = new System.Drawing.Point(368, 44);
            this.cbo01_CODE.Name = "cbo01_CODE";
            this.cbo01_CODE.Size = new System.Drawing.Size(122, 20);
            this.cbo01_CODE.TabIndex = 3;
            this.cbo01_CODE.SelectedIndexChanged += new System.EventHandler(this.cbo01_CODE_SelectedIndexChanged);
            // 
            // cbo01_SYSTEMCODE
            // 
            this.cbo01_SYSTEMCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SYSTEMCODE.FormattingEnabled = true;
            this.cbo01_SYSTEMCODE.Location = new System.Drawing.Point(115, 44);
            this.cbo01_SYSTEMCODE.Name = "cbo01_SYSTEMCODE";
            this.cbo01_SYSTEMCODE.Size = new System.Drawing.Size(140, 20);
            this.cbo01_SYSTEMCODE.TabIndex = 37;
            this.cbo01_SYSTEMCODE.SelectedIndexChanged += new System.EventHandler(this.cbo01_SYSTEMCODE_SelectedIndexChanged);
            // 
            // lbl01_SYSTEMCODE
            // 
            this.lbl01_SYSTEMCODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_SYSTEMCODE.AutoFontSizeMinValue = 9F;
            this.lbl01_SYSTEMCODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SYSTEMCODE.Location = new System.Drawing.Point(10, 44);
            this.lbl01_SYSTEMCODE.Name = "lbl01_SYSTEMCODE";
            this.lbl01_SYSTEMCODE.Size = new System.Drawing.Size(100, 20);
            this.lbl01_SYSTEMCODE.TabIndex = 36;
            this.lbl01_SYSTEMCODE.Tag = null;
            this.lbl01_SYSTEMCODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SYSTEMCODE.Value = "시스템_";
            // 
            // chk01_EXCLUDE
            // 
            this.chk01_EXCLUDE.AutoSize = true;
            this.chk01_EXCLUDE.Location = new System.Drawing.Point(887, 20);
            this.chk01_EXCLUDE.Name = "chk01_EXCLUDE";
            this.chk01_EXCLUDE.Size = new System.Drawing.Size(84, 16);
            this.chk01_EXCLUDE.TabIndex = 13;
            this.chk01_EXCLUDE.Text = "미사용제외";
            this.chk01_EXCLUDE.UseVisualStyleBackColor = true;
            this.chk01_EXCLUDE.CheckedChanged += new System.EventHandler(this.chk01_EXCLUDE_CheckedChanged);
            // 
            // rdo01_XM30303_RDO_2
            // 
            this.rdo01_XM30303_RDO_2.AutoSize = true;
            this.rdo01_XM30303_RDO_2.Location = new System.Drawing.Point(487, 18);
            this.rdo01_XM30303_RDO_2.Name = "rdo01_XM30303_RDO_2";
            this.rdo01_XM30303_RDO_2.Size = new System.Drawing.Size(71, 16);
            this.rdo01_XM30303_RDO_2.TabIndex = 12;
            this.rdo01_XM30303_RDO_2.TabStop = true;
            this.rdo01_XM30303_RDO_2.Text = "파트검색";
            this.rdo01_XM30303_RDO_2.UseVisualStyleBackColor = true;
            this.rdo01_XM30303_RDO_2.CheckedChanged += new System.EventHandler(this.rdo01_PARTNO_CheckedChanged);
            // 
            // cdx01_SEARCH
            // 
            this.cdx01_SEARCH.CodeParameterName = "CODE";
            this.cdx01_SEARCH.CodeTextBoxReadOnly = false;
            this.cdx01_SEARCH.CodeTextBoxVisible = true;
            this.cdx01_SEARCH.CodeTextBoxWidth = 70;
            this.cdx01_SEARCH.HEPopupHelper = null;
            this.cdx01_SEARCH.Location = new System.Drawing.Point(588, 16);
            this.cdx01_SEARCH.Name = "cdx01_SEARCH";
            this.cdx01_SEARCH.NameParameterName = "NAME";
            this.cdx01_SEARCH.NameTextBoxReadOnly = false;
            this.cdx01_SEARCH.NameTextBoxVisible = true;
            this.cdx01_SEARCH.PopupButtonReadOnly = false;
            this.cdx01_SEARCH.PopupTitle = "";
            this.cdx01_SEARCH.PrefixCode = "";
            this.cdx01_SEARCH.Size = new System.Drawing.Size(292, 21);
            this.cdx01_SEARCH.TabIndex = 10;
            this.cdx01_SEARCH.Tag = null;
            // 
            // rdo01_XM30303_RDO_1
            // 
            this.rdo01_XM30303_RDO_1.AutoSize = true;
            this.rdo01_XM30303_RDO_1.Checked = true;
            this.rdo01_XM30303_RDO_1.Location = new System.Drawing.Point(406, 19);
            this.rdo01_XM30303_RDO_1.Name = "rdo01_XM30303_RDO_1";
            this.rdo01_XM30303_RDO_1.Size = new System.Drawing.Size(71, 16);
            this.rdo01_XM30303_RDO_1.TabIndex = 8;
            this.rdo01_XM30303_RDO_1.TabStop = true;
            this.rdo01_XM30303_RDO_1.Text = "사번검색";
            this.rdo01_XM30303_RDO_1.UseVisualStyleBackColor = true;
            this.rdo01_XM30303_RDO_1.CheckedChanged += new System.EventHandler(this.rdo01_EMPNO_CheckedChanged);
            // 
            // lbl01_SPLIT
            // 
            this.lbl01_SPLIT.AutoFontSizeMaxValue = 9F;
            this.lbl01_SPLIT.AutoFontSizeMinValue = 9F;
            this.lbl01_SPLIT.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SPLIT.Location = new System.Drawing.Point(225, 18);
            this.lbl01_SPLIT.Name = "lbl01_SPLIT";
            this.lbl01_SPLIT.Size = new System.Drawing.Size(24, 20);
            this.lbl01_SPLIT.TabIndex = 7;
            this.lbl01_SPLIT.Tag = null;
            this.lbl01_SPLIT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SPLIT.Value = "-";
            // 
            // dte01_EDATE
            // 
            this.dte01_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_EDATE.Location = new System.Drawing.Point(255, 17);
            this.dte01_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_EDATE.Name = "dte01_EDATE";
            this.dte01_EDATE.OriginalFormat = "";
            this.dte01_EDATE.Size = new System.Drawing.Size(105, 21);
            this.dte01_EDATE.TabIndex = 6;
            // 
            // lbl01_LOG_YMD
            // 
            this.lbl01_LOG_YMD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOG_YMD.AutoFontSizeMinValue = 9F;
            this.lbl01_LOG_YMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LOG_YMD.Location = new System.Drawing.Point(10, 17);
            this.lbl01_LOG_YMD.Name = "lbl01_LOG_YMD";
            this.lbl01_LOG_YMD.Size = new System.Drawing.Size(100, 20);
            this.lbl01_LOG_YMD.TabIndex = 5;
            this.lbl01_LOG_YMD.Tag = null;
            this.lbl01_LOG_YMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LOG_YMD.Value = "조회일자";
            // 
            // dte01_SDATE
            // 
            this.dte01_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_SDATE.Location = new System.Drawing.Point(115, 17);
            this.dte01_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_SDATE.Name = "dte01_SDATE";
            this.dte01_SDATE.OriginalFormat = "";
            this.dte01_SDATE.Size = new System.Drawing.Size(105, 21);
            this.dte01_SDATE.TabIndex = 4;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 3);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(936, 459);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbp01_XM30303_TAB_1);
            this.tabControl1.Controls.Add(this.tbp01_XM30303_TAB_2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 109);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 491);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbp01_XM30303_TAB_1
            // 
            this.tbp01_XM30303_TAB_1.Controls.Add(this.grd01);
            this.tbp01_XM30303_TAB_1.Location = new System.Drawing.Point(4, 22);
            this.tbp01_XM30303_TAB_1.Name = "tbp01_XM30303_TAB_1";
            this.tbp01_XM30303_TAB_1.Padding = new System.Windows.Forms.Padding(3);
            this.tbp01_XM30303_TAB_1.Size = new System.Drawing.Size(942, 465);
            this.tbp01_XM30303_TAB_1.TabIndex = 0;
            this.tbp01_XM30303_TAB_1.Text = "메뉴 목록";
            this.tbp01_XM30303_TAB_1.UseVisualStyleBackColor = true;
            // 
            // tbp01_XM30303_TAB_2
            // 
            this.tbp01_XM30303_TAB_2.Controls.Add(this.grd02);
            this.tbp01_XM30303_TAB_2.Location = new System.Drawing.Point(4, 22);
            this.tbp01_XM30303_TAB_2.Name = "tbp01_XM30303_TAB_2";
            this.tbp01_XM30303_TAB_2.Padding = new System.Windows.Forms.Padding(3);
            this.tbp01_XM30303_TAB_2.Size = new System.Drawing.Size(942, 465);
            this.tbp01_XM30303_TAB_2.TabIndex = 1;
            this.tbp01_XM30303_TAB_2.Text = "사용자별 조회";
            this.tbp01_XM30303_TAB_2.UseVisualStyleBackColor = true;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 3);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(936, 459);
            this.grd02.TabIndex = 2;
            this.grd02.UseCustomHighlight = true;
            // 
            // XM30303
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "XM30303";
            this.Size = new System.Drawing.Size(950, 600);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MODULE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_SEARCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SPLIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOG_YMD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbp01_XM30303_TAB_1.ResumeLayout(false);
            this.tbp01_XM30303_TAB_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_CODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MODULE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SPLIT;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_EDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LOG_YMD;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_SDATE;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_XM30303_RDO_1;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_SEARCH;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_XM30303_RDO_2;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_EXCLUDE;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbp01_XM30303_TAB_1;
        private System.Windows.Forms.TabPage tbp01_XM30303_TAB_2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SUBCODE;


    }
}
