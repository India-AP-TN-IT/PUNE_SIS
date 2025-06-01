namespace Ax.SIS.QA.QA00.UI
{
    partial class QA30116
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QA30116));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01_QA30116 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_IMPUT_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_RCV_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_JOB_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_JOB_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_RCV_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.txt01_PARTNO_PARTNONM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PARTNO_PARTNONM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_OCCUR_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_JOB_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNONM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PARTNONM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA30116);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 426);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // grd01_QA30116
            // 
            this.grd01_QA30116.AllowHeaderMerging = false;
            this.grd01_QA30116.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA30116.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30116.EnabledActionFlag = true;
            this.grd01_QA30116.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01_QA30116.LastRowAdd = false;
            this.grd01_QA30116.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30116.Name = "grd01_QA30116";
            this.grd01_QA30116.OriginalFormat = null;
            this.grd01_QA30116.PopMenuVisible = true;
            this.grd01_QA30116.Rows.DefaultSize = 18;
            this.grd01_QA30116.Size = new System.Drawing.Size(275, 406);
            this.grd01_QA30116.StyleInfo = resources.GetString("grd01_QA30116.StyleInfo");
            this.grd01_QA30116.TabIndex = 0;
            this.grd01_QA30116.UseCustomHighlight = true;
            this.grd01_QA30116.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA30116_MouseDoubleClick);
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = false;
            this.cdx01_VENDCD.CodeTextBoxWidth = 40;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(16, 130);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(233, 21);
            this.cdx01_VENDCD.TabIndex = 12;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_IMPUT_VENDCD
            // 
            this.lbl01_IMPUT_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_IMPUT_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_IMPUT_VENDCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_IMPUT_VENDCD.Location = new System.Drawing.Point(16, 112);
            this.lbl01_IMPUT_VENDCD.Name = "lbl01_IMPUT_VENDCD";
            this.lbl01_IMPUT_VENDCD.Size = new System.Drawing.Size(233, 14);
            this.lbl01_IMPUT_VENDCD.TabIndex = 11;
            this.lbl01_IMPUT_VENDCD.Tag = null;
            this.lbl01_IMPUT_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_IMPUT_VENDCD.Value = "귀책업체";
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(121, 86);
            this.heLabel2.Name = "heLabel2";
            this.heLabel2.Size = new System.Drawing.Size(59, 15);
            this.heLabel2.TabIndex = 10;
            this.heLabel2.Tag = null;
            this.heLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel2.Value = "~";
            // 
            // dte01_RCV_DATE_TO
            // 
            this.dte01_RCV_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_RCV_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RCV_DATE_TO.Location = new System.Drawing.Point(150, 82);
            this.dte01_RCV_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RCV_DATE_TO.Name = "dte01_RCV_DATE_TO";
            this.dte01_RCV_DATE_TO.OriginalFormat = "";
            this.dte01_RCV_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_RCV_DATE_TO.TabIndex = 9;
            // 
            // cbo01_JOB_TYPE
            // 
            this.cbo01_JOB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_JOB_TYPE.FormattingEnabled = true;
            this.cbo01_JOB_TYPE.Location = new System.Drawing.Point(16, 178);
            this.cbo01_JOB_TYPE.Name = "cbo01_JOB_TYPE";
            this.cbo01_JOB_TYPE.Size = new System.Drawing.Size(233, 23);
            this.cbo01_JOB_TYPE.TabIndex = 8;
            // 
            // lbl01_JOB_TYPE
            // 
            this.lbl01_JOB_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_JOB_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_JOB_TYPE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_JOB_TYPE.Location = new System.Drawing.Point(16, 160);
            this.lbl01_JOB_TYPE.Name = "lbl01_JOB_TYPE";
            this.lbl01_JOB_TYPE.Size = new System.Drawing.Size(233, 14);
            this.lbl01_JOB_TYPE.TabIndex = 7;
            this.lbl01_JOB_TYPE.Tag = null;
            this.lbl01_JOB_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_JOB_TYPE.Value = "업무유형";
            // 
            // dte01_RCV_DATE_FROM
            // 
            this.dte01_RCV_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_RCV_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RCV_DATE_FROM.Location = new System.Drawing.Point(16, 82);
            this.dte01_RCV_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RCV_DATE_FROM.Name = "dte01_RCV_DATE_FROM";
            this.dte01_RCV_DATE_FROM.OriginalFormat = "";
            this.dte01_RCV_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_RCV_DATE_FROM.TabIndex = 6;
            // 
            // txt01_PARTNO_PARTNONM
            // 
            this.txt01_PARTNO_PARTNONM.Location = new System.Drawing.Point(16, 225);
            this.txt01_PARTNO_PARTNONM.Name = "txt01_PARTNO_PARTNONM";
            this.txt01_PARTNO_PARTNONM.Size = new System.Drawing.Size(233, 21);
            this.txt01_PARTNO_PARTNONM.TabIndex = 5;
            this.txt01_PARTNO_PARTNONM.Tag = null;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(16, 35);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(233, 23);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_PARTNO_PARTNONM
            // 
            this.lbl01_PARTNO_PARTNONM.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO_PARTNONM.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO_PARTNONM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PARTNO_PARTNONM.Location = new System.Drawing.Point(16, 207);
            this.lbl01_PARTNO_PARTNONM.Name = "lbl01_PARTNO_PARTNONM";
            this.lbl01_PARTNO_PARTNONM.Size = new System.Drawing.Size(233, 14);
            this.lbl01_PARTNO_PARTNONM.TabIndex = 4;
            this.lbl01_PARTNO_PARTNONM.Tag = null;
            this.lbl01_PARTNO_PARTNONM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO_PARTNONM.Value = "품번/품명";
            // 
            // lbl01_OCCUR_DATE
            // 
            this.lbl01_OCCUR_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_OCCUR_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_OCCUR_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_OCCUR_DATE.Location = new System.Drawing.Point(16, 64);
            this.lbl01_OCCUR_DATE.Name = "lbl01_OCCUR_DATE";
            this.lbl01_OCCUR_DATE.Size = new System.Drawing.Size(233, 14);
            this.lbl01_OCCUR_DATE.TabIndex = 1;
            this.lbl01_OCCUR_DATE.Tag = null;
            this.lbl01_OCCUR_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_OCCUR_DATE.Value = "발생일자";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(16, 17);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(233, 14);
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
            this.heDockingTab1.PanelWidth = 377;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.txt01_PARTNO_PARTNONM);
            this.panel1.Controls.Add(this.cbo01_JOB_TYPE);
            this.panel1.Controls.Add(this.lbl01_PARTNO_PARTNONM);
            this.panel1.Controls.Add(this.cdx01_VENDCD);
            this.panel1.Controls.Add(this.lbl01_JOB_TYPE);
            this.panel1.Controls.Add(this.lbl01_IMPUT_VENDCD);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_TO);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_FROM);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.heLabel2);
            this.panel1.Controls.Add(this.lbl01_OCCUR_DATE);
            this.panel1.Location = new System.Drawing.Point(28, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 426);
            this.panel1.TabIndex = 10;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(16, 254);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(233, 14);
            this.lbl01_PLANT_DIV.TabIndex = 14;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(16, 272);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(233, 23);
            this.cbo01_PLANT_DIV.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(315, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 426);
            this.panel2.TabIndex = 11;
            // 
            // QA30116
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30116";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_JOB_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNONM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PARTNONM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30116;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO_PARTNONM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO_PARTNONM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OCCUR_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxLabel heLabel2;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_TO;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_JOB_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_JOB_TYPE;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_IMPUT_VENDCD;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
