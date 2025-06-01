namespace Ax.SIS.QA.QA01.UI
{
    partial class QA30224
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
            this.grd01_QA30224 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_RCV_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_RCV_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CUSTCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_CUSTCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_RTN_AREA = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt01_PARTNO_PARTNONM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO_PARTNONM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_RTN_AREA = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_GUBUN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30224)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNONM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PARTNONM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RTN_AREA)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA30224);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 601);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // grd01_QA30224
            // 
            this.grd01_QA30224.AllowHeaderMerging = false;
            this.grd01_QA30224.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA30224.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30224.EnabledActionFlag = true;
            this.grd01_QA30224.LastRowAdd = false;
            this.grd01_QA30224.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30224.Name = "grd01_QA30224";
            this.grd01_QA30224.OriginalFormat = null;
            this.grd01_QA30224.PopMenuVisible = true;
            this.grd01_QA30224.Rows.DefaultSize = 18;
            this.grd01_QA30224.Size = new System.Drawing.Size(554, 581);
            this.grd01_QA30224.TabIndex = 0;
            this.grd01_QA30224.UseCustomHighlight = true;
            this.grd01_QA30224.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA30224_MouseDoubleClick);
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(118, 102);
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
            this.dte01_RCV_DATE_TO.Location = new System.Drawing.Point(148, 97);
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
            this.dte01_RCV_DATE_FROM.Location = new System.Drawing.Point(14, 97);
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
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.lbl01_CUSTCD);
            this.panel1.Controls.Add(this.cdx01_CUSTCD);
            this.panel1.Controls.Add(this.cbo01_RTN_AREA);
            this.panel1.Controls.Add(this.txt01_PARTNO_PARTNONM);
            this.panel1.Controls.Add(this.lbl01_PARTNO_PARTNONM);
            this.panel1.Controls.Add(this.lbl01_RTN_AREA);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.cbo01_GUBUN);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_FROM);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_TO);
            this.panel1.Controls.Add(this.heLabel2);
            this.panel1.Location = new System.Drawing.Point(3, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 374);
            this.panel1.TabIndex = 12;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 268);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(234, 16);
            this.lbl01_PLANT_DIV.TabIndex = 56;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(14, 287);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(234, 20);
            this.cbo01_PLANT_DIV.TabIndex = 55;
            // 
            // lbl01_CUSTCD
            // 
            this.lbl01_CUSTCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CUSTCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CUSTCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_CUSTCD.Location = new System.Drawing.Point(14, 124);
            this.lbl01_CUSTCD.Name = "lbl01_CUSTCD";
            this.lbl01_CUSTCD.Size = new System.Drawing.Size(234, 16);
            this.lbl01_CUSTCD.TabIndex = 54;
            this.lbl01_CUSTCD.Tag = null;
            this.lbl01_CUSTCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_CUSTCD.Value = "고객사";
            // 
            // cdx01_CUSTCD
            // 
            this.cdx01_CUSTCD.CodeParameterName = "CODE";
            this.cdx01_CUSTCD.CodeTextBoxReadOnly = false;
            this.cdx01_CUSTCD.CodeTextBoxVisible = true;
            this.cdx01_CUSTCD.CodeTextBoxWidth = 70;
            this.cdx01_CUSTCD.HEPopupHelper = null;
            this.cdx01_CUSTCD.Location = new System.Drawing.Point(14, 143);
            this.cdx01_CUSTCD.Name = "cdx01_CUSTCD";
            this.cdx01_CUSTCD.NameParameterName = "NAME";
            this.cdx01_CUSTCD.NameTextBoxReadOnly = false;
            this.cdx01_CUSTCD.NameTextBoxVisible = true;
            this.cdx01_CUSTCD.PopupButtonReadOnly = false;
            this.cdx01_CUSTCD.PopupTitle = "";
            this.cdx01_CUSTCD.PrefixCode = "";
            this.cdx01_CUSTCD.Size = new System.Drawing.Size(234, 21);
            this.cdx01_CUSTCD.TabIndex = 53;
            this.cdx01_CUSTCD.Tag = null;
            // 
            // cbo01_RTN_AREA
            // 
            this.cbo01_RTN_AREA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_RTN_AREA.FormattingEnabled = true;
            this.cbo01_RTN_AREA.Location = new System.Drawing.Point(14, 189);
            this.cbo01_RTN_AREA.Name = "cbo01_RTN_AREA";
            this.cbo01_RTN_AREA.Size = new System.Drawing.Size(234, 20);
            this.cbo01_RTN_AREA.TabIndex = 52;
            // 
            // txt01_PARTNO_PARTNONM
            // 
            this.txt01_PARTNO_PARTNONM.Location = new System.Drawing.Point(14, 234);
            this.txt01_PARTNO_PARTNONM.Name = "txt01_PARTNO_PARTNONM";
            this.txt01_PARTNO_PARTNONM.Size = new System.Drawing.Size(234, 21);
            this.txt01_PARTNO_PARTNONM.TabIndex = 18;
            this.txt01_PARTNO_PARTNONM.Tag = null;
            // 
            // lbl01_PARTNO_PARTNONM
            // 
            this.lbl01_PARTNO_PARTNONM.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO_PARTNONM.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO_PARTNONM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PARTNO_PARTNONM.Location = new System.Drawing.Point(14, 215);
            this.lbl01_PARTNO_PARTNONM.Name = "lbl01_PARTNO_PARTNONM";
            this.lbl01_PARTNO_PARTNONM.Size = new System.Drawing.Size(234, 16);
            this.lbl01_PARTNO_PARTNONM.TabIndex = 0;
            this.lbl01_PARTNO_PARTNONM.Tag = null;
            this.lbl01_PARTNO_PARTNONM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO_PARTNONM.Value = "품번/품명";
            // 
            // lbl01_RTN_AREA
            // 
            this.lbl01_RTN_AREA.AutoFontSizeMaxValue = 9F;
            this.lbl01_RTN_AREA.AutoFontSizeMinValue = 9F;
            this.lbl01_RTN_AREA.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_RTN_AREA.Location = new System.Drawing.Point(14, 170);
            this.lbl01_RTN_AREA.Name = "lbl01_RTN_AREA";
            this.lbl01_RTN_AREA.Size = new System.Drawing.Size(234, 16);
            this.lbl01_RTN_AREA.TabIndex = 0;
            this.lbl01_RTN_AREA.Tag = null;
            this.lbl01_RTN_AREA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_RTN_AREA.Value = "발생장소";
            // 
            // cbo01_GUBUN
            // 
            this.cbo01_GUBUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_GUBUN.FormattingEnabled = true;
            this.cbo01_GUBUN.Location = new System.Drawing.Point(14, 71);
            this.cbo01_GUBUN.Name = "cbo01_GUBUN";
            this.cbo01_GUBUN.Size = new System.Drawing.Size(100, 20);
            this.cbo01_GUBUN.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(318, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 601);
            this.panel2.TabIndex = 13;
            // 
            // QA30224
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30224";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30224)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNONM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PARTNONM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RTN_AREA)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30224;
        private Ax.DEV.Utility.Controls.AxLabel heLabel2;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_TO;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO_PARTNONM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_RTN_AREA;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO_PARTNONM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_RTN_AREA;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_GUBUN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CUSTCD;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_CUSTCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
