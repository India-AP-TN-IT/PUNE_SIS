namespace Ax.SIS.QA.QA01.UI
{
    partial class QA50418
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd01_QA50418 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lbl01_QA50418_MSG = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_CANCEL_NOTIFY = new Ax.DEV.Utility.Controls.AxButton();
            this.cbo01_OCCUR_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.dte01_DOC_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.heLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_DOC_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_OCCUR_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_COOPER_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DOC_DATE2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.btn01_NOTIFY_VENDOR = new Ax.DEV.Utility.Controls.AxButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA50418)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA50418_MSG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COOPER_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOC_DATE2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01_QA50418);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 287);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // grd01_QA50418
            // 
            this.grd01_QA50418.AllowHeaderMerging = false;
            this.grd01_QA50418.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA50418.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA50418.EnabledActionFlag = true;
            this.grd01_QA50418.LastRowAdd = false;
            this.grd01_QA50418.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA50418.Name = "grd01_QA50418";
            this.grd01_QA50418.OriginalFormat = null;
            this.grd01_QA50418.PopMenuVisible = true;
            this.grd01_QA50418.Rows.DefaultSize = 18;
            this.grd01_QA50418.Size = new System.Drawing.Size(272, 267);
            this.grd01_QA50418.TabIndex = 0;
            this.grd01_QA50418.UseCustomHighlight = true;
            this.grd01_QA50418.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA50418_MouseDoubleClick);
            // 
            // lbl01_QA50418_MSG
            // 
            this.lbl01_QA50418_MSG.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA50418_MSG.AutoFontSizeMinValue = 9F;
            this.lbl01_QA50418_MSG.AutoSize = true;
            this.lbl01_QA50418_MSG.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_QA50418_MSG.Location = new System.Drawing.Point(14, 212);
            this.lbl01_QA50418_MSG.Name = "lbl01_QA50418_MSG";
            this.lbl01_QA50418_MSG.Size = new System.Drawing.Size(117, 12);
            this.lbl01_QA50418_MSG.TabIndex = 20;
            this.lbl01_QA50418_MSG.Tag = null;
            this.lbl01_QA50418_MSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_QA50418_MSG.Value = "(더블클릭시 업체확인서 조회)";
            // 
            // btn01_CANCEL_NOTIFY
            // 
            this.btn01_CANCEL_NOTIFY.Location = new System.Drawing.Point(12, 328);
            this.btn01_CANCEL_NOTIFY.Name = "btn01_CANCEL_NOTIFY";
            this.btn01_CANCEL_NOTIFY.Size = new System.Drawing.Size(249, 23);
            this.btn01_CANCEL_NOTIFY.TabIndex = 18;
            this.btn01_CANCEL_NOTIFY.Text = "통보취소";
            this.btn01_CANCEL_NOTIFY.UseVisualStyleBackColor = true;
            this.btn01_CANCEL_NOTIFY.Click += new System.EventHandler(this.btn01_CANCEL_NOTIFY_Click);
            // 
            // cbo01_OCCUR_DIV
            // 
            this.cbo01_OCCUR_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_OCCUR_DIV.FormattingEnabled = true;
            this.cbo01_OCCUR_DIV.Location = new System.Drawing.Point(14, 132);
            this.cbo01_OCCUR_DIV.Name = "cbo01_OCCUR_DIV";
            this.cbo01_OCCUR_DIV.Size = new System.Drawing.Size(247, 20);
            this.cbo01_OCCUR_DIV.TabIndex = 15;
            // 
            // dte01_DOC_DATE_TO
            // 
            this.dte01_DOC_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_DOC_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DOC_DATE_TO.Location = new System.Drawing.Point(161, 83);
            this.dte01_DOC_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DOC_DATE_TO.Name = "dte01_DOC_DATE_TO";
            this.dte01_DOC_DATE_TO.OriginalFormat = "";
            this.dte01_DOC_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_DOC_DATE_TO.TabIndex = 14;
            // 
            // heLabel1
            // 
            this.heLabel1.AutoFontSizeMaxValue = 9F;
            this.heLabel1.AutoFontSizeMinValue = 9F;
            this.heLabel1.AutoSize = true;
            this.heLabel1.BackColor = System.Drawing.Color.Transparent;
            this.heLabel1.Location = new System.Drawing.Point(120, 89);
            this.heLabel1.Name = "heLabel1";
            this.heLabel1.Size = new System.Drawing.Size(56, 12);
            this.heLabel1.TabIndex = 13;
            this.heLabel1.Tag = null;
            this.heLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel1.Value = "~";
            // 
            // dte01_DOC_DATE_FROM
            // 
            this.dte01_DOC_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_DOC_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DOC_DATE_FROM.Location = new System.Drawing.Point(14, 84);
            this.dte01_DOC_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DOC_DATE_FROM.Name = "dte01_DOC_DATE_FROM";
            this.dte01_DOC_DATE_FROM.OriginalFormat = "";
            this.dte01_DOC_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_DOC_DATE_FROM.TabIndex = 12;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = false;
            this.cdx01_VENDCD.CodeTextBoxWidth = 40;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(14, 179);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(247, 21);
            this.cdx01_VENDCD.TabIndex = 10;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_OCCUR_DIV
            // 
            this.lbl01_OCCUR_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_OCCUR_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_OCCUR_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_OCCUR_DIV.Location = new System.Drawing.Point(14, 117);
            this.lbl01_OCCUR_DIV.Name = "lbl01_OCCUR_DIV";
            this.lbl01_OCCUR_DIV.Size = new System.Drawing.Size(247, 12);
            this.lbl01_OCCUR_DIV.TabIndex = 8;
            this.lbl01_OCCUR_DIV.Tag = null;
            this.lbl01_OCCUR_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_OCCUR_DIV.Value = "발생구분";
            // 
            // lbl01_COOPER_NM
            // 
            this.lbl01_COOPER_NM.AutoFontSizeMaxValue = 9F;
            this.lbl01_COOPER_NM.AutoFontSizeMinValue = 9F;
            this.lbl01_COOPER_NM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_COOPER_NM.Location = new System.Drawing.Point(14, 164);
            this.lbl01_COOPER_NM.Name = "lbl01_COOPER_NM";
            this.lbl01_COOPER_NM.Size = new System.Drawing.Size(247, 12);
            this.lbl01_COOPER_NM.TabIndex = 7;
            this.lbl01_COOPER_NM.Tag = null;
            this.lbl01_COOPER_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_COOPER_NM.Value = "협력사";
            // 
            // lbl01_DOC_DATE2
            // 
            this.lbl01_DOC_DATE2.AutoFontSizeMaxValue = 9F;
            this.lbl01_DOC_DATE2.AutoFontSizeMinValue = 9F;
            this.lbl01_DOC_DATE2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DOC_DATE2.Location = new System.Drawing.Point(14, 69);
            this.lbl01_DOC_DATE2.Name = "lbl01_DOC_DATE2";
            this.lbl01_DOC_DATE2.Size = new System.Drawing.Size(247, 12);
            this.lbl01_DOC_DATE2.TabIndex = 6;
            this.lbl01_DOC_DATE2.Tag = null;
            this.lbl01_DOC_DATE2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DOC_DATE2.Value = "작성기간";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(247, 20);
            this.cbo01_BIZCD.TabIndex = 5;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(14, 22);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(247, 12);
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
            this.heDockingTab1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.btn01_NOTIFY_VENDOR);
            this.panel1.Controls.Add(this.dte01_DOC_DATE_TO);
            this.panel1.Controls.Add(this.btn01_CANCEL_NOTIFY);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_QA50418_MSG);
            this.panel1.Controls.Add(this.dte01_DOC_DATE_FROM);
            this.panel1.Controls.Add(this.cdx01_VENDCD);
            this.panel1.Controls.Add(this.cbo01_OCCUR_DIV);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Controls.Add(this.lbl01_DOC_DATE2);
            this.panel1.Controls.Add(this.heLabel1);
            this.panel1.Controls.Add(this.lbl01_OCCUR_DIV);
            this.panel1.Controls.Add(this.lbl01_COOPER_NM);
            this.panel1.Location = new System.Drawing.Point(22, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 552);
            this.panel1.TabIndex = 10;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 239);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(247, 12);
            this.lbl01_PLANT_DIV.TabIndex = 26;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(13, 254);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(248, 20);
            this.cbo01_PLANT_DIV.TabIndex = 25;
            // 
            // btn01_NOTIFY_VENDOR
            // 
            this.btn01_NOTIFY_VENDOR.Location = new System.Drawing.Point(12, 299);
            this.btn01_NOTIFY_VENDOR.Name = "btn01_NOTIFY_VENDOR";
            this.btn01_NOTIFY_VENDOR.Size = new System.Drawing.Size(249, 23);
            this.btn01_NOTIFY_VENDOR.TabIndex = 24;
            this.btn01_NOTIFY_VENDOR.Text = "업체통보";
            this.btn01_NOTIFY_VENDOR.UseVisualStyleBackColor = true;
            this.btn01_NOTIFY_VENDOR.Click += new System.EventHandler(this.btn01_NOTIFY_VENDOR_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(331, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 287);
            this.panel2.TabIndex = 11;
            // 
            // QA50418
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA50418";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA50418)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA50418_MSG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COOPER_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOC_DATE2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA50418;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_DOC_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OCCUR_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_COOPER_NM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DOC_DATE2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA50418_MSG;
        private Ax.DEV.Utility.Controls.AxButton btn01_CANCEL_NOTIFY;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_OCCUR_DIV;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_DOC_DATE_TO;
        private Ax.DEV.Utility.Controls.AxLabel heLabel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxButton btn01_NOTIFY_VENDOR;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
