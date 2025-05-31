namespace Ax.SIS.QA.QA00.UI
{
    partial class QA40123
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
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.dte01_RCV_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VENDER = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_RCV_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_SAUP = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_RCV_FROM_TO = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01_QA40123 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SAUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RCV_FROM_TO)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA40123)).BeginInit();
            this.SuspendLayout();
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_TO);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.cdx01_VENDCD);
            this.panel1.Controls.Add(this.lbl01_VENDER);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_FROM);
            this.panel1.Controls.Add(this.heLabel2);
            this.panel1.Controls.Add(this.lbl01_SAUP);
            this.panel1.Controls.Add(this.lbl01_RCV_FROM_TO);
            this.panel1.Location = new System.Drawing.Point(24, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 396);
            this.panel1.TabIndex = 26;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(15, 166);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(100, 12);
            this.lbl01_PLANT_DIV.TabIndex = 23;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(15, 180);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(250, 20);
            this.cbo01_PLANT_DIV.TabIndex = 22;
            // 
            // dte01_RCV_DATE_TO
            // 
            this.dte01_RCV_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_RCV_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RCV_DATE_TO.Location = new System.Drawing.Point(149, 84);
            this.dte01_RCV_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RCV_DATE_TO.Name = "dte01_RCV_DATE_TO";
            this.dte01_RCV_DATE_TO.OriginalFormat = "";
            this.dte01_RCV_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_RCV_DATE_TO.TabIndex = 9;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(15, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(250, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = false;
            this.cdx01_VENDCD.CodeTextBoxWidth = 40;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(15, 132);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(250, 21);
            this.cdx01_VENDCD.TabIndex = 12;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_VENDER
            // 
            this.lbl01_VENDER.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDER.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDER.AutoSize = true;
            this.lbl01_VENDER.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VENDER.Location = new System.Drawing.Point(15, 117);
            this.lbl01_VENDER.Name = "lbl01_VENDER";
            this.lbl01_VENDER.Size = new System.Drawing.Size(85, 12);
            this.lbl01_VENDER.TabIndex = 11;
            this.lbl01_VENDER.Tag = null;
            this.lbl01_VENDER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VENDER.Value = "협력사";
            // 
            // dte01_RCV_DATE_FROM
            // 
            this.dte01_RCV_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_RCV_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RCV_DATE_FROM.Location = new System.Drawing.Point(15, 84);
            this.dte01_RCV_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RCV_DATE_FROM.Name = "dte01_RCV_DATE_FROM";
            this.dte01_RCV_DATE_FROM.OriginalFormat = "";
            this.dte01_RCV_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_RCV_DATE_FROM.TabIndex = 6;
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(117, 88);
            this.heLabel2.Name = "heLabel2";
            this.heLabel2.Size = new System.Drawing.Size(56, 12);
            this.heLabel2.TabIndex = 10;
            this.heLabel2.Tag = null;
            this.heLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel2.Value = "~";
            // 
            // lbl01_SAUP
            // 
            this.lbl01_SAUP.AutoFontSizeMaxValue = 9F;
            this.lbl01_SAUP.AutoFontSizeMinValue = 9F;
            this.lbl01_SAUP.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SAUP.Location = new System.Drawing.Point(15, 22);
            this.lbl01_SAUP.Name = "lbl01_SAUP";
            this.lbl01_SAUP.Size = new System.Drawing.Size(100, 16);
            this.lbl01_SAUP.TabIndex = 0;
            this.lbl01_SAUP.Tag = null;
            this.lbl01_SAUP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_SAUP.Value = "사업장";
            // 
            // lbl01_RCV_FROM_TO
            // 
            this.lbl01_RCV_FROM_TO.AutoFontSizeMaxValue = 9F;
            this.lbl01_RCV_FROM_TO.AutoFontSizeMinValue = 9F;
            this.lbl01_RCV_FROM_TO.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_RCV_FROM_TO.Location = new System.Drawing.Point(15, 69);
            this.lbl01_RCV_FROM_TO.Name = "lbl01_RCV_FROM_TO";
            this.lbl01_RCV_FROM_TO.Size = new System.Drawing.Size(100, 16);
            this.lbl01_RCV_FROM_TO.TabIndex = 1;
            this.lbl01_RCV_FROM_TO.Tag = null;
            this.lbl01_RCV_FROM_TO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_RCV_FROM_TO.Value = "입고기간";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(371, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 396);
            this.panel2.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA40123);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 396);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // grd01_QA40123
            // 
            this.grd01_QA40123.AllowHeaderMerging = false;
            this.grd01_QA40123.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA40123.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA40123.EnabledActionFlag = true;
            this.grd01_QA40123.LastRowAdd = false;
            this.grd01_QA40123.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA40123.Name = "grd01_QA40123";
            this.grd01_QA40123.OriginalFormat = null;
            this.grd01_QA40123.PopMenuVisible = true;
            this.grd01_QA40123.Rows.DefaultSize = 18;
            this.grd01_QA40123.Size = new System.Drawing.Size(276, 376);
            this.grd01_QA40123.TabIndex = 0;
            this.grd01_QA40123.UseCustomHighlight = true;
            this.grd01_QA40123.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA40123_MouseClick);
            this.grd01_QA40123.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA40123_MouseDoubleClick);
            // 
            // QA40123
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA40123";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SAUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RCV_FROM_TO)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA40123)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_TO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SAUP;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_RCV_FROM_TO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDER;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxLabel heLabel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA40123;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;

    }
}
