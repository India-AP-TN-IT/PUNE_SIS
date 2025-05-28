namespace Ax.SIS.WM.UI
{
    partial class WM20420
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
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo01_PRINT = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_REPRINT = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.cbo01_AREACD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_AREA = new Ax.DEV.Utility.Controls.AxLabel();
            this.Btn_Save1 = new Ax.DEV.Utility.Controls.AxButton();
            this.cbo01_PRINT_SEQ = new Ax.DEV.Utility.Controls.AxComboBox();
            this.dte01_REQ_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_PRINT_SEQ1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_REQ_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.gbxSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRINT_SEQ1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_REQ_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.groupBox1);
            this.gbxSearch.Controls.Add(this.cbo01_AREACD);
            this.gbxSearch.Controls.Add(this.lbl01_AREA);
            this.gbxSearch.Controls.Add(this.Btn_Save1);
            this.gbxSearch.Controls.Add(this.cbo01_PRINT_SEQ);
            this.gbxSearch.Controls.Add(this.dte01_REQ_DATE);
            this.gbxSearch.Controls.Add(this.lbl01_PRINT_SEQ1);
            this.gbxSearch.Controls.Add(this.lbl01_REQ_DATE);
            this.gbxSearch.Controls.Add(this.cbo01_BIZCD);
            this.gbxSearch.Controls.Add(this.lbl01_BIZNM);
            this.gbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearch.Location = new System.Drawing.Point(0, 34);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(1024, 75);
            this.gbxSearch.TabIndex = 0;
            this.gbxSearch.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo01_PRINT);
            this.groupBox1.Controls.Add(this.rdo01_REPRINT);
            this.groupBox1.Location = new System.Drawing.Point(257, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 30);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            // 
            // rdo01_PRINT
            // 
            this.rdo01_PRINT.AutoSize = true;
            this.rdo01_PRINT.Checked = true;
            this.rdo01_PRINT.Location = new System.Drawing.Point(39, 10);
            this.rdo01_PRINT.Name = "rdo01_PRINT";
            this.rdo01_PRINT.Size = new System.Drawing.Size(59, 16);
            this.rdo01_PRINT.TabIndex = 4;
            this.rdo01_PRINT.TabStop = true;
            this.rdo01_PRINT.Text = "PRINT";
            this.rdo01_PRINT.UseVisualStyleBackColor = true;
            this.rdo01_PRINT.CheckedChanged += new System.EventHandler(this.rdo01_PRINT_CheckedChanged);
            // 
            // rdo01_REPRINT
            // 
            this.rdo01_REPRINT.AutoSize = true;
            this.rdo01_REPRINT.Location = new System.Drawing.Point(132, 10);
            this.rdo01_REPRINT.Name = "rdo01_REPRINT";
            this.rdo01_REPRINT.Size = new System.Drawing.Size(75, 16);
            this.rdo01_REPRINT.TabIndex = 73;
            this.rdo01_REPRINT.Text = "REPRINT";
            this.rdo01_REPRINT.UseVisualStyleBackColor = true;
            this.rdo01_REPRINT.CheckedChanged += new System.EventHandler(this.rdo01_REPRINT_CheckedChanged);
            // 
            // cbo01_AREACD
            // 
            this.cbo01_AREACD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_AREACD.FormattingEnabled = true;
            this.cbo01_AREACD.Location = new System.Drawing.Point(600, 20);
            this.cbo01_AREACD.Name = "cbo01_AREACD";
            this.cbo01_AREACD.Size = new System.Drawing.Size(168, 20);
            this.cbo01_AREACD.TabIndex = 96;
            this.cbo01_AREACD.SelectedIndexChanged += new System.EventHandler(this.cbo01_AREACD_SelectedIndexChanged);
            // 
            // lbl01_AREA
            // 
            this.lbl01_AREA.AutoFontSizeMaxValue = 9F;
            this.lbl01_AREA.AutoFontSizeMinValue = 9F;
            this.lbl01_AREA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_AREA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_AREA.Location = new System.Drawing.Point(496, 20);
            this.lbl01_AREA.Name = "lbl01_AREA";
            this.lbl01_AREA.Size = new System.Drawing.Size(100, 21);
            this.lbl01_AREA.TabIndex = 95;
            this.lbl01_AREA.Tag = null;
            this.lbl01_AREA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_AREA.Value = "요청일자";
            this.lbl01_AREA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // Btn_Save1
            // 
            this.Btn_Save1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Save1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_Save1.Location = new System.Drawing.Point(944, 30);
            this.Btn_Save1.Name = "Btn_Save1";
            this.Btn_Save1.Size = new System.Drawing.Size(74, 23);
            this.Btn_Save1.TabIndex = 94;
            this.Btn_Save1.Text = "ADD SAVE";
            this.Btn_Save1.UseVisualStyleBackColor = false;
            this.Btn_Save1.Visible = false;
            this.Btn_Save1.Click += new System.EventHandler(this.Btn_Save1_Click);
            // 
            // cbo01_PRINT_SEQ
            // 
            this.cbo01_PRINT_SEQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRINT_SEQ.FormattingEnabled = true;
            this.cbo01_PRINT_SEQ.Location = new System.Drawing.Point(113, 50);
            this.cbo01_PRINT_SEQ.Name = "cbo01_PRINT_SEQ";
            this.cbo01_PRINT_SEQ.Size = new System.Drawing.Size(136, 20);
            this.cbo01_PRINT_SEQ.TabIndex = 6;
            this.cbo01_PRINT_SEQ.SelectedIndexChanged += new System.EventHandler(this.cbo01_PRINT_SEQ_SelectedIndexChanged);
            // 
            // dte01_REQ_DATE
            // 
            this.dte01_REQ_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_REQ_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_REQ_DATE.Location = new System.Drawing.Point(363, 21);
            this.dte01_REQ_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_REQ_DATE.Name = "dte01_REQ_DATE";
            this.dte01_REQ_DATE.OriginalFormat = "";
            this.dte01_REQ_DATE.Size = new System.Drawing.Size(126, 21);
            this.dte01_REQ_DATE.TabIndex = 2;
            this.dte01_REQ_DATE.CloseUp += new System.EventHandler(this.dte01_DELI_DATE_CloseUp);
            this.dte01_REQ_DATE.ValueChanged += new System.EventHandler(this.dte01_REQ_DATE_ValueChanged);
            this.dte01_REQ_DATE.Leave += new System.EventHandler(this.dte01_DELI_DATE_Leave);
            // 
            // lbl01_PRINT_SEQ1
            // 
            this.lbl01_PRINT_SEQ1.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRINT_SEQ1.AutoFontSizeMinValue = 9F;
            this.lbl01_PRINT_SEQ1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRINT_SEQ1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_PRINT_SEQ1.Location = new System.Drawing.Point(7, 49);
            this.lbl01_PRINT_SEQ1.Name = "lbl01_PRINT_SEQ1";
            this.lbl01_PRINT_SEQ1.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PRINT_SEQ1.TabIndex = 0;
            this.lbl01_PRINT_SEQ1.Tag = null;
            this.lbl01_PRINT_SEQ1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PRINT_SEQ1.Value = "발행차수";
            this.lbl01_PRINT_SEQ1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // lbl01_REQ_DATE
            // 
            this.lbl01_REQ_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_REQ_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_REQ_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_REQ_DATE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_REQ_DATE.Location = new System.Drawing.Point(257, 21);
            this.lbl01_REQ_DATE.Name = "lbl01_REQ_DATE";
            this.lbl01_REQ_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_REQ_DATE.TabIndex = 0;
            this.lbl01_REQ_DATE.Tag = null;
            this.lbl01_REQ_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_REQ_DATE.Value = "요청일자";
            this.lbl01_REQ_DATE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 22);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(137, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(6, 21);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장명";
            this.lbl01_BIZNM.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 5);
            this.panel1.TabIndex = 1;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 114);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 654);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_CellChanged);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // WM20420
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxSearch);
            this.Name = "WM20420";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.gbxSearch, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.gbxSearch.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRINT_SEQ1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_REQ_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private System.Windows.Forms.GroupBox gbxSearch;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_REQ_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PRINT_SEQ1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_REQ_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PRINT_SEQ;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxButton Btn_Save1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_AREACD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_AREA;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_PRINT;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_REPRINT;
    }
}
