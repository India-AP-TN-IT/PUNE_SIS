namespace Ax.SIS.QA.QA02.UI
{
    partial class QA20930
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
            this.tpg01_CLMD_RSLT_DOWN = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel8 = new System.Windows.Forms.Panel();
            this.grp01_SEARCH = new System.Windows.Forms.GroupBox();
            this.dte01_YYYYMM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_SEARCH_MONTH = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA20920_MSG2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA20920_MSG1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.tpg11_CLMD_RSLT_UP = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd11_excel = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd11 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grp11_SEARCH = new System.Windows.Forms.GroupBox();
            this.btn11_VAATZ_EXCELDOWN = new Ax.DEV.Utility.Controls.AxButton();
            this.dte11_YYYYMM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl11_SEARCH_MONTH = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl11_QA20920_MSG4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl11_QA20920_MSG3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.tab01_main.SuspendLayout();
            this.tpg01_CLMD_RSLT_DOWN.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel8.SuspendLayout();
            this.grp01_SEARCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_MONTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20920_MSG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20920_MSG1)).BeginInit();
            this.tpg11_CLMD_RSLT_UP.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd11_excel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd11)).BeginInit();
            this.panel1.SuspendLayout();
            this.grp11_SEARCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_SEARCH_MONTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_QA20920_MSG4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_QA20920_MSG3)).BeginInit();
            this.SuspendLayout();
            // 
            // tab01_main
            // 
            this.tab01_main.Controls.Add(this.tpg01_CLMD_RSLT_DOWN);
            this.tab01_main.Controls.Add(this.tpg11_CLMD_RSLT_UP);
            this.tab01_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab01_main.Location = new System.Drawing.Point(0, 34);
            this.tab01_main.Name = "tab01_main";
            this.tab01_main.SelectedIndex = 0;
            this.tab01_main.Size = new System.Drawing.Size(1024, 734);
            this.tab01_main.TabIndex = 3;
            this.tab01_main.SelectedIndexChanged += new System.EventHandler(this.tab01_SelectedIndexChanged);
            this.tab01_main.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tab01_main_Selecting);
            // 
            // tpg01_CLMD_RSLT_DOWN
            // 
            this.tpg01_CLMD_RSLT_DOWN.Controls.Add(this.panel7);
            this.tpg01_CLMD_RSLT_DOWN.Controls.Add(this.panel8);
            this.tpg01_CLMD_RSLT_DOWN.Location = new System.Drawing.Point(4, 22);
            this.tpg01_CLMD_RSLT_DOWN.Name = "tpg01_CLMD_RSLT_DOWN";
            this.tpg01_CLMD_RSLT_DOWN.Padding = new System.Windows.Forms.Padding(3);
            this.tpg01_CLMD_RSLT_DOWN.Size = new System.Drawing.Size(1016, 708);
            this.tpg01_CLMD_RSLT_DOWN.TabIndex = 3;
            this.tpg01_CLMD_RSLT_DOWN.Text = "클레임실적 다운로드";
            this.tpg01_CLMD_RSLT_DOWN.UseVisualStyleBackColor = true;
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
            this.grp01_SEARCH.Controls.Add(this.dte01_YYYYMM);
            this.grp01_SEARCH.Controls.Add(this.lbl01_SEARCH_MONTH);
            this.grp01_SEARCH.Controls.Add(this.lbl01_QA20920_MSG2);
            this.grp01_SEARCH.Controls.Add(this.lbl01_QA20920_MSG1);
            this.grp01_SEARCH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_SEARCH.Location = new System.Drawing.Point(0, 0);
            this.grp01_SEARCH.Name = "grp01_SEARCH";
            this.grp01_SEARCH.Size = new System.Drawing.Size(1010, 67);
            this.grp01_SEARCH.TabIndex = 2;
            this.grp01_SEARCH.TabStop = false;
            // 
            // dte01_YYYYMM
            // 
            this.dte01_YYYYMM.CustomFormat = "yyyy-MM";
            this.dte01_YYYYMM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_YYYYMM.Location = new System.Drawing.Point(112, 13);
            this.dte01_YYYYMM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_YYYYMM.Name = "dte01_YYYYMM";
            this.dte01_YYYYMM.OriginalFormat = "";
            this.dte01_YYYYMM.Size = new System.Drawing.Size(76, 21);
            this.dte01_YYYYMM.TabIndex = 268;
            this.dte01_YYYYMM.CloseUp += new System.EventHandler(this.dte01_CloseUp);
            this.dte01_YYYYMM.ValueChanged += new System.EventHandler(this.dte01_ValueChanged);
            this.dte01_YYYYMM.DropDown += new System.EventHandler(this.dte01_DropDown);
            // 
            // lbl01_SEARCH_MONTH
            // 
            this.lbl01_SEARCH_MONTH.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCH_MONTH.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCH_MONTH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SEARCH_MONTH.Location = new System.Drawing.Point(6, 13);
            this.lbl01_SEARCH_MONTH.Name = "lbl01_SEARCH_MONTH";
            this.lbl01_SEARCH_MONTH.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SEARCH_MONTH.TabIndex = 117;
            this.lbl01_SEARCH_MONTH.Tag = null;
            this.lbl01_SEARCH_MONTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SEARCH_MONTH.Value = "조회연월";
            // 
            // lbl01_QA20920_MSG2
            // 
            this.lbl01_QA20920_MSG2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_QA20920_MSG2.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA20920_MSG2.AutoFontSizeMinValue = 9F;
            this.lbl01_QA20920_MSG2.BackColor = System.Drawing.Color.White;
            this.lbl01_QA20920_MSG2.ForeColor = System.Drawing.Color.Red;
            this.lbl01_QA20920_MSG2.Location = new System.Drawing.Point(194, 24);
            this.lbl01_QA20920_MSG2.Name = "lbl01_QA20920_MSG2";
            this.lbl01_QA20920_MSG2.Size = new System.Drawing.Size(810, 11);
            this.lbl01_QA20920_MSG2.TabIndex = 91;
            this.lbl01_QA20920_MSG2.Tag = null;
            this.lbl01_QA20920_MSG2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_QA20920_MSG2.Value = "";
            // 
            // lbl01_QA20920_MSG1
            // 
            this.lbl01_QA20920_MSG1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_QA20920_MSG1.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA20920_MSG1.AutoFontSizeMinValue = 9F;
            this.lbl01_QA20920_MSG1.BackColor = System.Drawing.Color.White;
            this.lbl01_QA20920_MSG1.ForeColor = System.Drawing.Color.Red;
            this.lbl01_QA20920_MSG1.Location = new System.Drawing.Point(194, 10);
            this.lbl01_QA20920_MSG1.Name = "lbl01_QA20920_MSG1";
            this.lbl01_QA20920_MSG1.Size = new System.Drawing.Size(810, 11);
            this.lbl01_QA20920_MSG1.TabIndex = 90;
            this.lbl01_QA20920_MSG1.Tag = null;
            this.lbl01_QA20920_MSG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_QA20920_MSG1.Value = "";
            // 
            // tpg11_CLMD_RSLT_UP
            // 
            this.tpg11_CLMD_RSLT_UP.Controls.Add(this.panel2);
            this.tpg11_CLMD_RSLT_UP.Controls.Add(this.panel1);
            this.tpg11_CLMD_RSLT_UP.Location = new System.Drawing.Point(4, 22);
            this.tpg11_CLMD_RSLT_UP.Name = "tpg11_CLMD_RSLT_UP";
            this.tpg11_CLMD_RSLT_UP.Padding = new System.Windows.Forms.Padding(3);
            this.tpg11_CLMD_RSLT_UP.Size = new System.Drawing.Size(1016, 708);
            this.tpg11_CLMD_RSLT_UP.TabIndex = 4;
            this.tpg11_CLMD_RSLT_UP.Text = "클레임실적 업로드";
            this.tpg11_CLMD_RSLT_UP.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd11_excel);
            this.panel2.Controls.Add(this.grd11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1010, 635);
            this.panel2.TabIndex = 9;
            // 
            // grd11_excel
            // 
            this.grd11_excel.AllowHeaderMerging = false;
            this.grd11_excel.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd11_excel.EnabledActionFlag = true;
            this.grd11_excel.LastRowAdd = false;
            this.grd11_excel.Location = new System.Drawing.Point(905, 26);
            this.grd11_excel.Name = "grd11_excel";
            this.grd11_excel.OriginalFormat = null;
            this.grd11_excel.PopMenuVisible = true;
            this.grd11_excel.Rows.DefaultSize = 18;
            this.grd11_excel.Size = new System.Drawing.Size(61, 32);
            this.grd11_excel.TabIndex = 26;
            this.grd11_excel.UseCustomHighlight = true;
            this.grd11_excel.Visible = false;
            // 
            // grd11
            // 
            this.grd11.AllowHeaderMerging = false;
            this.grd11.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd11.EnabledActionFlag = true;
            this.grd11.LastRowAdd = false;
            this.grd11.Location = new System.Drawing.Point(0, 0);
            this.grd11.Name = "grd11";
            this.grd11.OriginalFormat = null;
            this.grd11.PopMenuVisible = true;
            this.grd11.Rows.DefaultSize = 18;
            this.grd11.Size = new System.Drawing.Size(1010, 635);
            this.grd11.TabIndex = 24;
            this.grd11.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grp11_SEARCH);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 67);
            this.panel1.TabIndex = 8;
            // 
            // grp11_SEARCH
            // 
            this.grp11_SEARCH.Controls.Add(this.btn11_VAATZ_EXCELDOWN);
            this.grp11_SEARCH.Controls.Add(this.dte11_YYYYMM);
            this.grp11_SEARCH.Controls.Add(this.lbl11_SEARCH_MONTH);
            this.grp11_SEARCH.Controls.Add(this.lbl11_QA20920_MSG4);
            this.grp11_SEARCH.Controls.Add(this.lbl11_QA20920_MSG3);
            this.grp11_SEARCH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp11_SEARCH.Location = new System.Drawing.Point(0, 0);
            this.grp11_SEARCH.Name = "grp11_SEARCH";
            this.grp11_SEARCH.Size = new System.Drawing.Size(1010, 67);
            this.grp11_SEARCH.TabIndex = 2;
            this.grp11_SEARCH.TabStop = false;
            // 
            // btn11_VAATZ_EXCELDOWN
            // 
            this.btn11_VAATZ_EXCELDOWN.ForeColor = System.Drawing.Color.Black;
            this.btn11_VAATZ_EXCELDOWN.Location = new System.Drawing.Point(5, 38);
            this.btn11_VAATZ_EXCELDOWN.Name = "btn11_VAATZ_EXCELDOWN";
            this.btn11_VAATZ_EXCELDOWN.Size = new System.Drawing.Size(195, 23);
            this.btn11_VAATZ_EXCELDOWN.TabIndex = 270;
            this.btn11_VAATZ_EXCELDOWN.Text = "바츠업로드데이터 엑셀다운로드";
            this.btn11_VAATZ_EXCELDOWN.UseVisualStyleBackColor = true;
            this.btn11_VAATZ_EXCELDOWN.Click += new System.EventHandler(this.btn11_EXCELDOWN_Click);
            // 
            // dte11_YYYYMM
            // 
            this.dte11_YYYYMM.CustomFormat = "yyyy-MM";
            this.dte11_YYYYMM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte11_YYYYMM.Location = new System.Drawing.Point(112, 13);
            this.dte11_YYYYMM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte11_YYYYMM.Name = "dte11_YYYYMM";
            this.dte11_YYYYMM.OriginalFormat = "";
            this.dte11_YYYYMM.Size = new System.Drawing.Size(76, 21);
            this.dte11_YYYYMM.TabIndex = 268;
            this.dte11_YYYYMM.CloseUp += new System.EventHandler(this.dte11_CloseUp);
            this.dte11_YYYYMM.ValueChanged += new System.EventHandler(this.dte11_ValueChanged);
            this.dte11_YYYYMM.DropDown += new System.EventHandler(this.dte11_DropDown);
            // 
            // lbl11_SEARCH_MONTH
            // 
            this.lbl11_SEARCH_MONTH.AutoFontSizeMaxValue = 9F;
            this.lbl11_SEARCH_MONTH.AutoFontSizeMinValue = 9F;
            this.lbl11_SEARCH_MONTH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl11_SEARCH_MONTH.Location = new System.Drawing.Point(6, 13);
            this.lbl11_SEARCH_MONTH.Name = "lbl11_SEARCH_MONTH";
            this.lbl11_SEARCH_MONTH.Size = new System.Drawing.Size(100, 21);
            this.lbl11_SEARCH_MONTH.TabIndex = 117;
            this.lbl11_SEARCH_MONTH.Tag = null;
            this.lbl11_SEARCH_MONTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl11_SEARCH_MONTH.Value = "조회연월";
            // 
            // lbl11_QA20920_MSG4
            // 
            this.lbl11_QA20920_MSG4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl11_QA20920_MSG4.AutoFontSizeMaxValue = 9F;
            this.lbl11_QA20920_MSG4.AutoFontSizeMinValue = 9F;
            this.lbl11_QA20920_MSG4.BackColor = System.Drawing.Color.White;
            this.lbl11_QA20920_MSG4.ForeColor = System.Drawing.Color.Red;
            this.lbl11_QA20920_MSG4.Location = new System.Drawing.Point(194, 24);
            this.lbl11_QA20920_MSG4.Name = "lbl11_QA20920_MSG4";
            this.lbl11_QA20920_MSG4.Size = new System.Drawing.Size(810, 11);
            this.lbl11_QA20920_MSG4.TabIndex = 91;
            this.lbl11_QA20920_MSG4.Tag = null;
            this.lbl11_QA20920_MSG4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl11_QA20920_MSG4.Value = "";
            // 
            // lbl11_QA20920_MSG3
            // 
            this.lbl11_QA20920_MSG3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl11_QA20920_MSG3.AutoFontSizeMaxValue = 9F;
            this.lbl11_QA20920_MSG3.AutoFontSizeMinValue = 9F;
            this.lbl11_QA20920_MSG3.BackColor = System.Drawing.Color.White;
            this.lbl11_QA20920_MSG3.ForeColor = System.Drawing.Color.Red;
            this.lbl11_QA20920_MSG3.Location = new System.Drawing.Point(194, 10);
            this.lbl11_QA20920_MSG3.Name = "lbl11_QA20920_MSG3";
            this.lbl11_QA20920_MSG3.Size = new System.Drawing.Size(810, 11);
            this.lbl11_QA20920_MSG3.TabIndex = 90;
            this.lbl11_QA20920_MSG3.Tag = null;
            this.lbl11_QA20920_MSG3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl11_QA20920_MSG3.Value = "";
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel 통합 문서|*.xlsx|Excel 97 - 2003 통합 문서|*.xls";
            // 
            // QA20930
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tab01_main);
            this.Name = "QA20930";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.tab01_main, 0);
            this.tab01_main.ResumeLayout(false);
            this.tpg01_CLMD_RSLT_DOWN.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel8.ResumeLayout(false);
            this.grp01_SEARCH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_MONTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20920_MSG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20920_MSG1)).EndInit();
            this.tpg11_CLMD_RSLT_UP.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd11_excel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd11)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grp11_SEARCH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_SEARCH_MONTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_QA20920_MSG4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_QA20920_MSG3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab01_main;
        private Ax.DEV.Utility.Controls.AxLabel lbl21_WORK_DIV;
        private System.Windows.Forms.TabPage tpg01_CLMD_RSLT_DOWN;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.GroupBox grp01_SEARCH;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SEARCH_MONTH;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA20920_MSG2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA20920_MSG1;
        private System.Windows.Forms.Panel panel7;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_YYYYMM;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.TabPage tpg11_CLMD_RSLT_UP;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grp11_SEARCH;
        private Ax.DEV.Utility.Controls.AxDateEdit dte11_YYYYMM;
        private Ax.DEV.Utility.Controls.AxLabel lbl11_SEARCH_MONTH;
        private Ax.DEV.Utility.Controls.AxLabel lbl11_QA20920_MSG4;
        private Ax.DEV.Utility.Controls.AxLabel lbl11_QA20920_MSG3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd11_excel;
        private Ax.DEV.Utility.Controls.AxButton btn11_VAATZ_EXCELDOWN;

    }
}
