namespace Ax.SIS.QA.QA02.UI
{
    partial class QA20910
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
            this.tab01_main = new System.Windows.Forms.TabControl();
            this.tpg01_DIRE_PART_UCOST = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel8 = new System.Windows.Forms.Panel();
            this.grp01_SEARCH = new System.Windows.Forms.GroupBox();
            this.btn01_LASTMONTH_BASE_SAVE = new Ax.DEV.Utility.Controls.AxButton();
            this.dte01_YYYYMM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_SEARCH_MONTH = new Ax.DEV.Utility.Controls.AxLabel();
            this.pnl11_WORK_RATE = new System.Windows.Forms.Panel();
            this.rdo01_ALL = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_EXIST = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_NOT_EXIST = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.cdx01_PARTNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_UCOST_YN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA20910_MSG1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.tab01_main.SuspendLayout();
            this.tpg01_DIRE_PART_UCOST.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel8.SuspendLayout();
            this.grp01_SEARCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_MONTH)).BeginInit();
            this.pnl11_WORK_RATE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_UCOST_YN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20910_MSG1)).BeginInit();
            this.SuspendLayout();
            // 
            // tab01_main
            // 
            this.tab01_main.Controls.Add(this.tpg01_DIRE_PART_UCOST);
            this.tab01_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab01_main.Location = new System.Drawing.Point(0, 34);
            this.tab01_main.Name = "tab01_main";
            this.tab01_main.SelectedIndex = 0;
            this.tab01_main.Size = new System.Drawing.Size(1024, 734);
            this.tab01_main.TabIndex = 3;
            this.tab01_main.SelectedIndexChanged += new System.EventHandler(this.tab01_SelectedIndexChanged);
            this.tab01_main.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tab01_main_Selecting);
            // 
            // tpg01_DIRE_PART_UCOST
            // 
            this.tpg01_DIRE_PART_UCOST.Controls.Add(this.panel7);
            this.tpg01_DIRE_PART_UCOST.Controls.Add(this.panel8);
            this.tpg01_DIRE_PART_UCOST.Location = new System.Drawing.Point(4, 22);
            this.tpg01_DIRE_PART_UCOST.Name = "tpg01_DIRE_PART_UCOST";
            this.tpg01_DIRE_PART_UCOST.Padding = new System.Windows.Forms.Padding(3);
            this.tpg01_DIRE_PART_UCOST.Size = new System.Drawing.Size(1016, 708);
            this.tpg01_DIRE_PART_UCOST.TabIndex = 3;
            this.tpg01_DIRE_PART_UCOST.Text = "직거래부품단가";
            this.tpg01_DIRE_PART_UCOST.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.grd01);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 70);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1010, 635);
            this.panel7.TabIndex = 4;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1010, 635);
            this.grd01.TabIndex = 24;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowCanceled += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowCanceled);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.grp01_SEARCH);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1010, 67);
            this.panel8.TabIndex = 7;
            // 
            // grp01_SEARCH
            // 
            this.grp01_SEARCH.Controls.Add(this.btn01_LASTMONTH_BASE_SAVE);
            this.grp01_SEARCH.Controls.Add(this.dte01_YYYYMM);
            this.grp01_SEARCH.Controls.Add(this.lbl01_SEARCH_MONTH);
            this.grp01_SEARCH.Controls.Add(this.pnl11_WORK_RATE);
            this.grp01_SEARCH.Controls.Add(this.cdx01_PARTNO);
            this.grp01_SEARCH.Controls.Add(this.lbl01_UCOST_YN);
            this.grp01_SEARCH.Controls.Add(this.lbl01_PARTNO);
            this.grp01_SEARCH.Controls.Add(this.lbl01_QA20910_MSG1);
            this.grp01_SEARCH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_SEARCH.Location = new System.Drawing.Point(0, 0);
            this.grp01_SEARCH.Name = "grp01_SEARCH";
            this.grp01_SEARCH.Size = new System.Drawing.Size(1010, 67);
            this.grp01_SEARCH.TabIndex = 2;
            this.grp01_SEARCH.TabStop = false;
            // 
            // btn01_LASTMONTH_BASE_SAVE
            // 
            this.btn01_LASTMONTH_BASE_SAVE.Location = new System.Drawing.Point(342, 38);
            this.btn01_LASTMONTH_BASE_SAVE.Name = "btn01_LASTMONTH_BASE_SAVE";
            this.btn01_LASTMONTH_BASE_SAVE.Size = new System.Drawing.Size(183, 23);
            this.btn01_LASTMONTH_BASE_SAVE.TabIndex = 287;
            this.btn01_LASTMONTH_BASE_SAVE.Text = "전월기준 단가데이터 등록";
            this.btn01_LASTMONTH_BASE_SAVE.UseVisualStyleBackColor = true;
            this.btn01_LASTMONTH_BASE_SAVE.Click += new System.EventHandler(this.btn01_Click);
            // 
            // dte01_YYYYMM
            // 
            this.dte01_YYYYMM.CustomFormat = "yyyy-MM";
            this.dte01_YYYYMM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_YYYYMM.Location = new System.Drawing.Point(447, 13);
            this.dte01_YYYYMM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_YYYYMM.Name = "dte01_YYYYMM";
            this.dte01_YYYYMM.OriginalFormat = "";
            this.dte01_YYYYMM.Size = new System.Drawing.Size(76, 21);
            this.dte01_YYYYMM.TabIndex = 286;
            this.dte01_YYYYMM.CloseUp += new System.EventHandler(this.dte01_CloseUp);
            this.dte01_YYYYMM.ValueChanged += new System.EventHandler(this.dte01_ValueChanged);
            this.dte01_YYYYMM.DropDown += new System.EventHandler(this.dte01_DropDown);
            // 
            // lbl01_SEARCH_MONTH
            // 
            this.lbl01_SEARCH_MONTH.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCH_MONTH.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCH_MONTH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SEARCH_MONTH.Location = new System.Drawing.Point(341, 13);
            this.lbl01_SEARCH_MONTH.Name = "lbl01_SEARCH_MONTH";
            this.lbl01_SEARCH_MONTH.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SEARCH_MONTH.TabIndex = 285;
            this.lbl01_SEARCH_MONTH.Tag = null;
            this.lbl01_SEARCH_MONTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SEARCH_MONTH.Value = "조회연월";
            // 
            // pnl11_WORK_RATE
            // 
            this.pnl11_WORK_RATE.Controls.Add(this.rdo01_ALL);
            this.pnl11_WORK_RATE.Controls.Add(this.rdo01_EXIST);
            this.pnl11_WORK_RATE.Controls.Add(this.rdo01_NOT_EXIST);
            this.pnl11_WORK_RATE.Location = new System.Drawing.Point(112, 39);
            this.pnl11_WORK_RATE.Name = "pnl11_WORK_RATE";
            this.pnl11_WORK_RATE.Size = new System.Drawing.Size(224, 21);
            this.pnl11_WORK_RATE.TabIndex = 284;
            // 
            // rdo01_ALL
            // 
            this.rdo01_ALL.ForeColor = System.Drawing.Color.Black;
            this.rdo01_ALL.Location = new System.Drawing.Point(3, 2);
            this.rdo01_ALL.Name = "rdo01_ALL";
            this.rdo01_ALL.Size = new System.Drawing.Size(47, 16);
            this.rdo01_ALL.TabIndex = 104;
            this.rdo01_ALL.Tag = "";
            this.rdo01_ALL.Text = "전체";
            this.rdo01_ALL.UseVisualStyleBackColor = true;
            this.rdo01_ALL.CheckedChanged += new System.EventHandler(this.rdo01_CheckedChanged);
            // 
            // rdo01_EXIST
            // 
            this.rdo01_EXIST.ForeColor = System.Drawing.Color.Black;
            this.rdo01_EXIST.Location = new System.Drawing.Point(56, 2);
            this.rdo01_EXIST.Name = "rdo01_EXIST";
            this.rdo01_EXIST.Size = new System.Drawing.Size(37, 16);
            this.rdo01_EXIST.TabIndex = 105;
            this.rdo01_EXIST.Tag = "Y";
            this.rdo01_EXIST.Text = "유";
            this.rdo01_EXIST.UseVisualStyleBackColor = true;
            this.rdo01_EXIST.CheckedChanged += new System.EventHandler(this.rdo01_CheckedChanged);
            // 
            // rdo01_NOT_EXIST
            // 
            this.rdo01_NOT_EXIST.Checked = true;
            this.rdo01_NOT_EXIST.ForeColor = System.Drawing.Color.Black;
            this.rdo01_NOT_EXIST.Location = new System.Drawing.Point(99, 2);
            this.rdo01_NOT_EXIST.Name = "rdo01_NOT_EXIST";
            this.rdo01_NOT_EXIST.Size = new System.Drawing.Size(37, 16);
            this.rdo01_NOT_EXIST.TabIndex = 106;
            this.rdo01_NOT_EXIST.TabStop = true;
            this.rdo01_NOT_EXIST.Tag = "N";
            this.rdo01_NOT_EXIST.Text = "무";
            this.rdo01_NOT_EXIST.UseVisualStyleBackColor = true;
            this.rdo01_NOT_EXIST.CheckedChanged += new System.EventHandler(this.rdo01_CheckedChanged);
            // 
            // cdx01_PARTNO
            // 
            this.cdx01_PARTNO.CodeParameterName = "CODE";
            this.cdx01_PARTNO.CodeTextBoxReadOnly = false;
            this.cdx01_PARTNO.CodeTextBoxVisible = true;
            this.cdx01_PARTNO.CodeTextBoxWidth = 60;
            this.cdx01_PARTNO.HEPopupHelper = null;
            this.cdx01_PARTNO.Location = new System.Drawing.Point(112, 13);
            this.cdx01_PARTNO.Name = "cdx01_PARTNO";
            this.cdx01_PARTNO.NameParameterName = "NAME";
            this.cdx01_PARTNO.NameTextBoxReadOnly = false;
            this.cdx01_PARTNO.NameTextBoxVisible = true;
            this.cdx01_PARTNO.PopupButtonReadOnly = false;
            this.cdx01_PARTNO.PopupTitle = "";
            this.cdx01_PARTNO.PrefixCode = "";
            this.cdx01_PARTNO.Size = new System.Drawing.Size(223, 21);
            this.cdx01_PARTNO.TabIndex = 283;
            this.cdx01_PARTNO.Tag = null;
            this.cdx01_PARTNO.Value = "";
            this.cdx01_PARTNO.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_ButtonClickAfter);
            this.cdx01_PARTNO.ValueChanged += new System.EventHandler(this.cdx01_ValueChanged);
            // 
            // lbl01_UCOST_YN
            // 
            this.lbl01_UCOST_YN.AutoFontSizeMaxValue = 9F;
            this.lbl01_UCOST_YN.AutoFontSizeMinValue = 9F;
            this.lbl01_UCOST_YN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_UCOST_YN.Location = new System.Drawing.Point(6, 39);
            this.lbl01_UCOST_YN.Name = "lbl01_UCOST_YN";
            this.lbl01_UCOST_YN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_UCOST_YN.TabIndex = 267;
            this.lbl01_UCOST_YN.Tag = null;
            this.lbl01_UCOST_YN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_UCOST_YN.Value = "단가유무";
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(6, 13);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PARTNO.TabIndex = 117;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "품번";
            // 
            // lbl01_QA20910_MSG1
            // 
            this.lbl01_QA20910_MSG1.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA20910_MSG1.AutoFontSizeMinValue = 9F;
            this.lbl01_QA20910_MSG1.BackColor = System.Drawing.Color.White;
            this.lbl01_QA20910_MSG1.ForeColor = System.Drawing.Color.Red;
            this.lbl01_QA20910_MSG1.Location = new System.Drawing.Point(529, 44);
            this.lbl01_QA20910_MSG1.Name = "lbl01_QA20910_MSG1";
            this.lbl01_QA20910_MSG1.Size = new System.Drawing.Size(475, 11);
            this.lbl01_QA20910_MSG1.TabIndex = 90;
            this.lbl01_QA20910_MSG1.Tag = null;
            this.lbl01_QA20910_MSG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_QA20910_MSG1.Value = "조회연월보다 전에 등록된 데이터중 최근 단가데이터를 기준연월 데이터에 등록합니다.";
            // 
            // QA20910
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tab01_main);
            this.Name = "QA20910";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.tab01_main, 0);
            this.tab01_main.ResumeLayout(false);
            this.tpg01_DIRE_PART_UCOST.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel8.ResumeLayout(false);
            this.grp01_SEARCH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_MONTH)).EndInit();
            this.pnl11_WORK_RATE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_UCOST_YN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20910_MSG1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab01_main;
        private Ax.DEV.Utility.Controls.AxLabel lbl21_WORK_DIV;
        private System.Windows.Forms.TabPage tpg01_DIRE_PART_UCOST;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.GroupBox grp01_SEARCH;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_UCOST_YN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA20910_MSG1;
        private System.Windows.Forms.Panel panel7;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_PARTNO;
        private System.Windows.Forms.Panel pnl11_WORK_RATE;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_ALL;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_EXIST;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_NOT_EXIST;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_YYYYMM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SEARCH_MONTH;
        private Ax.DEV.Utility.Controls.AxButton btn01_LASTMONTH_BASE_SAVE;

    }
}
