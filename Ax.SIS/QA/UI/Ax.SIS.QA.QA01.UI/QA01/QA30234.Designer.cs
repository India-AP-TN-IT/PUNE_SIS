namespace Ax.SIS.QA.QA01.UI
{
    partial class QA30234
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01_QA30234 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.chk01_DEFECT_DESC_SEARCH = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_RCV_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_RCV_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_REG_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn01_CUSTOMER_MGMT = new Ax.DEV.Utility.Controls.AxButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grd02_QA30234 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30234)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_REG_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA30234)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA30234);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 335);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // grd01_QA30234
            // 
            this.grd01_QA30234.AllowHeaderMerging = false;
            this.grd01_QA30234.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA30234.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30234.EnabledActionFlag = true;
            this.grd01_QA30234.LastRowAdd = false;
            this.grd01_QA30234.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30234.Name = "grd01_QA30234";
            this.grd01_QA30234.OriginalFormat = null;
            this.grd01_QA30234.PopMenuVisible = true;
            this.grd01_QA30234.Rows.DefaultSize = 18;
            this.grd01_QA30234.Size = new System.Drawing.Size(554, 315);
            this.grd01_QA30234.TabIndex = 0;
            this.grd01_QA30234.UseCustomHighlight = true;
            this.grd01_QA30234.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA30234_MouseDoubleClick);
            // 
            // chk01_DEFECT_DESC_SEARCH
            // 
            this.chk01_DEFECT_DESC_SEARCH.AutoSize = true;
            this.chk01_DEFECT_DESC_SEARCH.Location = new System.Drawing.Point(14, 113);
            this.chk01_DEFECT_DESC_SEARCH.Name = "chk01_DEFECT_DESC_SEARCH";
            this.chk01_DEFECT_DESC_SEARCH.Size = new System.Drawing.Size(116, 16);
            this.chk01_DEFECT_DESC_SEARCH.TabIndex = 16;
            this.chk01_DEFECT_DESC_SEARCH.Text = "불량 내역만 조회";
            this.chk01_DEFECT_DESC_SEARCH.UseVisualStyleBackColor = true;
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(118, 83);
            this.heLabel2.Name = "heLabel2";
            this.heLabel2.Size = new System.Drawing.Size(56, 12);
            this.heLabel2.TabIndex = 10;
            this.heLabel2.Tag = null;
            this.heLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel2.Value = "~";
            // 
            // dte01_RCV_DATE_TO
            // 
            this.dte01_RCV_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_RCV_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RCV_DATE_TO.Location = new System.Drawing.Point(148, 78);
            this.dte01_RCV_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RCV_DATE_TO.Name = "dte01_RCV_DATE_TO";
            this.dte01_RCV_DATE_TO.OriginalFormat = "";
            this.dte01_RCV_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_RCV_DATE_TO.TabIndex = 9;
            // 
            // dte01_RCV_DATE_FROM
            // 
            this.dte01_RCV_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_RCV_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RCV_DATE_FROM.Location = new System.Drawing.Point(14, 78);
            this.dte01_RCV_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RCV_DATE_FROM.Name = "dte01_RCV_DATE_FROM";
            this.dte01_RCV_DATE_FROM.OriginalFormat = "";
            this.dte01_RCV_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_RCV_DATE_FROM.TabIndex = 6;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 35);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(234, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_REG_DATE
            // 
            this.lbl01_REG_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_REG_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_REG_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_REG_DATE.Location = new System.Drawing.Point(14, 59);
            this.lbl01_REG_DATE.Name = "lbl01_REG_DATE";
            this.lbl01_REG_DATE.Size = new System.Drawing.Size(234, 16);
            this.lbl01_REG_DATE.TabIndex = 1;
            this.lbl01_REG_DATE.Tag = null;
            this.lbl01_REG_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_REG_DATE.Value = "등록일자";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(14, 16);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(234, 16);
            this.lbl01_BIZNM.TabIndex = 0;
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
            this.heDockingTab1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn01_CUSTOMER_MGMT);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.chk01_DEFECT_DESC_SEARCH);
            this.panel1.Controls.Add(this.lbl01_REG_DATE);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_FROM);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_TO);
            this.panel1.Controls.Add(this.heLabel2);
            this.panel1.Location = new System.Drawing.Point(3, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 374);
            this.panel1.TabIndex = 12;
            // 
            // btn01_CUSTOMER_MGMT
            // 
            this.btn01_CUSTOMER_MGMT.Location = new System.Drawing.Point(14, 150);
            this.btn01_CUSTOMER_MGMT.Name = "btn01_CUSTOMER_MGMT";
            this.btn01_CUSTOMER_MGMT.Size = new System.Drawing.Size(234, 28);
            this.btn01_CUSTOMER_MGMT.TabIndex = 24;
            this.btn01_CUSTOMER_MGMT.Text = "대상 고객 관리";
            this.btn01_CUSTOMER_MGMT.UseVisualStyleBackColor = true;
            this.btn01_CUSTOMER_MGMT.Click += new System.EventHandler(this.btn01_CUSTOMER_MGMT_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(318, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 601);
            this.panel2.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grd02_QA30234);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 266);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // grd02_QA30234
            // 
            this.grd02_QA30234.AllowHeaderMerging = false;
            this.grd02_QA30234.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd02_QA30234.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02_QA30234.EnabledActionFlag = true;
            this.grd02_QA30234.LastRowAdd = false;
            this.grd02_QA30234.Location = new System.Drawing.Point(3, 17);
            this.grd02_QA30234.Name = "grd02_QA30234";
            this.grd02_QA30234.OriginalFormat = null;
            this.grd02_QA30234.PopMenuVisible = true;
            this.grd02_QA30234.Rows.DefaultSize = 18;
            this.grd02_QA30234.Size = new System.Drawing.Size(554, 246);
            this.grd02_QA30234.TabIndex = 0;
            this.grd02_QA30234.UseCustomHighlight = true;
            // 
            // QA30234
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30234";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30234)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_REG_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA30234)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30234;
        private Ax.DEV.Utility.Controls.AxLabel heLabel2;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_TO;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_REG_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_DEFECT_DESC_SEARCH;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02_QA30234;
        private DEV.Utility.Controls.AxButton btn01_CUSTOMER_MGMT;
    }
}
