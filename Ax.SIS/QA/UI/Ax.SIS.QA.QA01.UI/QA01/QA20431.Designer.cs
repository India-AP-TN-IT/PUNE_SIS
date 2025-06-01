namespace Ax.SIS.QA.QA01.UI
{
    partial class QA20431
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grd03_QA20431 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd02_QA20431 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd01_QA20431 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.btn01_CANCEL_NOTIFY = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_NOTIFY_VENDOR = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_DOWN_SUMMARY = new Ax.DEV.Utility.Controls.AxButton();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_COOPER_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_PROC_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_DOCRPT_YYMM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn01_DOWN_DETAIL = new Ax.DEV.Utility.Controls.AxButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03_QA20431)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA20431)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20431)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COOPER_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOCRPT_YYMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grd03_QA20431);
            this.groupBox4.Controls.Add(this.grd02_QA20431);
            this.groupBox4.Controls.Add(this.grd01_QA20431);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(118, 413);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // grd03_QA20431
            // 
            this.grd03_QA20431.AllowHeaderMerging = false;
            this.grd03_QA20431.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd03_QA20431.EnabledActionFlag = true;
            this.grd03_QA20431.LastRowAdd = false;
            this.grd03_QA20431.Location = new System.Drawing.Point(303, 95);
            this.grd03_QA20431.Name = "grd03_QA20431";
            this.grd03_QA20431.OriginalFormat = null;
            this.grd03_QA20431.PopMenuVisible = true;
            this.grd03_QA20431.Rows.DefaultSize = 18;
            this.grd03_QA20431.Size = new System.Drawing.Size(240, 150);
            this.grd03_QA20431.TabIndex = 2;
            this.grd03_QA20431.UseCustomHighlight = true;
            this.grd03_QA20431.Visible = false;
            // 
            // grd02_QA20431
            // 
            this.grd02_QA20431.AllowHeaderMerging = false;
            this.grd02_QA20431.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd02_QA20431.EnabledActionFlag = true;
            this.grd02_QA20431.LastRowAdd = false;
            this.grd02_QA20431.Location = new System.Drawing.Point(203, 95);
            this.grd02_QA20431.Name = "grd02_QA20431";
            this.grd02_QA20431.OriginalFormat = null;
            this.grd02_QA20431.PopMenuVisible = true;
            this.grd02_QA20431.Rows.DefaultSize = 18;
            this.grd02_QA20431.Size = new System.Drawing.Size(240, 150);
            this.grd02_QA20431.TabIndex = 1;
            this.grd02_QA20431.UseCustomHighlight = true;
            this.grd02_QA20431.Visible = false;
            // 
            // grd01_QA20431
            // 
            this.grd01_QA20431.AllowHeaderMerging = false;
            this.grd01_QA20431.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA20431.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA20431.EnabledActionFlag = true;
            this.grd01_QA20431.LastRowAdd = false;
            this.grd01_QA20431.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA20431.Name = "grd01_QA20431";
            this.grd01_QA20431.OriginalFormat = null;
            this.grd01_QA20431.PopMenuVisible = true;
            this.grd01_QA20431.Rows.DefaultSize = 18;
            this.grd01_QA20431.Size = new System.Drawing.Size(112, 393);
            this.grd01_QA20431.TabIndex = 0;
            this.grd01_QA20431.UseCustomHighlight = true;
            this.grd01_QA20431.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA20431_MouseClick);
            // 
            // btn01_CANCEL_NOTIFY
            // 
            this.btn01_CANCEL_NOTIFY.Location = new System.Drawing.Point(16, 216);
            this.btn01_CANCEL_NOTIFY.Name = "btn01_CANCEL_NOTIFY";
            this.btn01_CANCEL_NOTIFY.Size = new System.Drawing.Size(250, 23);
            this.btn01_CANCEL_NOTIFY.TabIndex = 27;
            this.btn01_CANCEL_NOTIFY.Text = "통보취소";
            this.btn01_CANCEL_NOTIFY.UseVisualStyleBackColor = true;
            this.btn01_CANCEL_NOTIFY.Click += new System.EventHandler(this.btn01_CANCEL_NOTIFY_Click);
            // 
            // btn01_NOTIFY_VENDOR
            // 
            this.btn01_NOTIFY_VENDOR.Location = new System.Drawing.Point(16, 187);
            this.btn01_NOTIFY_VENDOR.Name = "btn01_NOTIFY_VENDOR";
            this.btn01_NOTIFY_VENDOR.Size = new System.Drawing.Size(250, 23);
            this.btn01_NOTIFY_VENDOR.TabIndex = 26;
            this.btn01_NOTIFY_VENDOR.Text = "업체통보";
            this.btn01_NOTIFY_VENDOR.UseVisualStyleBackColor = true;
            this.btn01_NOTIFY_VENDOR.Click += new System.EventHandler(this.btn01_NOTIFY_VENDOR_Click);
            // 
            // btn01_DOWN_SUMMARY
            // 
            this.btn01_DOWN_SUMMARY.Location = new System.Drawing.Point(16, 158);
            this.btn01_DOWN_SUMMARY.Name = "btn01_DOWN_SUMMARY";
            this.btn01_DOWN_SUMMARY.Size = new System.Drawing.Size(122, 23);
            this.btn01_DOWN_SUMMARY.TabIndex = 25;
            this.btn01_DOWN_SUMMARY.Text = "요약 다운로드";
            this.btn01_DOWN_SUMMARY.UseVisualStyleBackColor = true;
            this.btn01_DOWN_SUMMARY.Click += new System.EventHandler(this.btn01_DOWN_Click);
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = false;
            this.cdx01_VENDCD.CodeTextBoxWidth = 40;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(16, 131);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(250, 21);
            this.cdx01_VENDCD.TabIndex = 22;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_COOPER_NM
            // 
            this.lbl01_COOPER_NM.AutoFontSizeMaxValue = 9F;
            this.lbl01_COOPER_NM.AutoFontSizeMinValue = 9F;
            this.lbl01_COOPER_NM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_COOPER_NM.Location = new System.Drawing.Point(16, 116);
            this.lbl01_COOPER_NM.Name = "lbl01_COOPER_NM";
            this.lbl01_COOPER_NM.Size = new System.Drawing.Size(250, 12);
            this.lbl01_COOPER_NM.TabIndex = 21;
            this.lbl01_COOPER_NM.Tag = null;
            this.lbl01_COOPER_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_COOPER_NM.Value = "협력사";
            // 
            // dte01_PROC_DATE
            // 
            this.dte01_PROC_DATE.Checked = false;
            this.dte01_PROC_DATE.CustomFormat = "yyyy-MM";
            this.dte01_PROC_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_PROC_DATE.Location = new System.Drawing.Point(16, 83);
            this.dte01_PROC_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_PROC_DATE.Name = "dte01_PROC_DATE";
            this.dte01_PROC_DATE.OriginalFormat = "";
            this.dte01_PROC_DATE.Size = new System.Drawing.Size(250, 21);
            this.dte01_PROC_DATE.TabIndex = 12;
            // 
            // lbl01_DOCRPT_YYMM
            // 
            this.lbl01_DOCRPT_YYMM.AutoFontSizeMaxValue = 9F;
            this.lbl01_DOCRPT_YYMM.AutoFontSizeMinValue = 9F;
            this.lbl01_DOCRPT_YYMM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DOCRPT_YYMM.Location = new System.Drawing.Point(16, 68);
            this.lbl01_DOCRPT_YYMM.Name = "lbl01_DOCRPT_YYMM";
            this.lbl01_DOCRPT_YYMM.Size = new System.Drawing.Size(250, 12);
            this.lbl01_DOCRPT_YYMM.TabIndex = 6;
            this.lbl01_DOCRPT_YYMM.Tag = null;
            this.lbl01_DOCRPT_YYMM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DOCRPT_YYMM.Value = "통보서 년월";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(16, 36);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(250, 20);
            this.cbo01_BIZCD.TabIndex = 5;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(16, 21);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(250, 12);
            this.lbl01_BIZNM2.TabIndex = 4;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn01_CANCEL_NOTIFY);
            this.panel1.Controls.Add(this.btn01_NOTIFY_VENDOR);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.btn01_DOWN_DETAIL);
            this.panel1.Controls.Add(this.btn01_DOWN_SUMMARY);
            this.panel1.Controls.Add(this.cdx01_VENDCD);
            this.panel1.Controls.Add(this.dte01_PROC_DATE);
            this.panel1.Controls.Add(this.lbl01_COOPER_NM);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Controls.Add(this.lbl01_DOCRPT_YYMM);
            this.panel1.Location = new System.Drawing.Point(22, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 427);
            this.panel1.TabIndex = 17;
            // 
            // btn01_DOWN_DETAIL
            // 
            this.btn01_DOWN_DETAIL.Location = new System.Drawing.Point(144, 158);
            this.btn01_DOWN_DETAIL.Name = "btn01_DOWN_DETAIL";
            this.btn01_DOWN_DETAIL.Size = new System.Drawing.Size(122, 23);
            this.btn01_DOWN_DETAIL.TabIndex = 25;
            this.btn01_DOWN_DETAIL.Text = "세부 다운로드";
            this.btn01_DOWN_DETAIL.UseVisualStyleBackColor = true;
            this.btn01_DOWN_DETAIL.Click += new System.EventHandler(this.btn01_DOWN2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Location = new System.Drawing.Point(311, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 413);
            this.panel2.TabIndex = 18;
            // 
            // QA20431
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA20431";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03_QA20431)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA20431)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20431)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COOPER_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOCRPT_YYMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA20431;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_COOPER_NM;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_PROC_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DOCRPT_YYMM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxButton btn01_NOTIFY_VENDOR;
        private Ax.DEV.Utility.Controls.AxButton btn01_DOWN_SUMMARY;
        private Ax.DEV.Utility.Controls.AxButton btn01_CANCEL_NOTIFY;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02_QA20431;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03_QA20431;
        private Ax.DEV.Utility.Controls.AxButton btn01_DOWN_DETAIL;
    }
}
