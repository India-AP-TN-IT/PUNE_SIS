namespace Ax.SIS.QA.QA00.UI
{
    partial class QA30126
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
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.grd01_QA30126 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cbo01_DEFTYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_DEFTYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO_PARTNONM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_QA30126_MSG1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PARTNO_PARTNONM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_IMPUT_VENDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_RCV_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_IMPUT_DIVCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_IMPUT_DIVCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_RCV_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_OCCUR_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30126)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEFTYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNONM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA30126_MSG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PARTNONM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_VENDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_DIVCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.grd01_QA30126);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_main.Location = new System.Drawing.Point(0, 0);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(275, 461);
            this.groupBox_main.TabIndex = 18;
            this.groupBox_main.TabStop = false;
            // 
            // grd01_QA30126
            // 
            this.grd01_QA30126.AllowHeaderMerging = false;
            this.grd01_QA30126.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA30126.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30126.EnabledActionFlag = true;
            this.grd01_QA30126.LastRowAdd = false;
            this.grd01_QA30126.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30126.Name = "grd01_QA30126";
            this.grd01_QA30126.OriginalFormat = null;
            this.grd01_QA30126.PopMenuVisible = true;
            this.grd01_QA30126.Rows.DefaultSize = 18;
            this.grd01_QA30126.Size = new System.Drawing.Size(269, 441);
            this.grd01_QA30126.TabIndex = 0;
            this.grd01_QA30126.UseCustomHighlight = true;
            this.grd01_QA30126.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA30126_MouseDoubleClick);
            // 
            // cbo01_DEFTYPE
            // 
            this.cbo01_DEFTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DEFTYPE.FormattingEnabled = true;
            this.cbo01_DEFTYPE.Location = new System.Drawing.Point(13, 80);
            this.cbo01_DEFTYPE.Name = "cbo01_DEFTYPE";
            this.cbo01_DEFTYPE.Size = new System.Drawing.Size(251, 20);
            this.cbo01_DEFTYPE.TabIndex = 21;
            // 
            // lbl01_DEFTYPE
            // 
            this.lbl01_DEFTYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DEFTYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_DEFTYPE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DEFTYPE.Location = new System.Drawing.Point(13, 65);
            this.lbl01_DEFTYPE.Name = "lbl01_DEFTYPE";
            this.lbl01_DEFTYPE.Size = new System.Drawing.Size(251, 12);
            this.lbl01_DEFTYPE.TabIndex = 20;
            this.lbl01_DEFTYPE.Tag = null;
            this.lbl01_DEFTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DEFTYPE.Value = "불량구분";
            // 
            // txt01_PARTNO_PARTNONM
            // 
            this.txt01_PARTNO_PARTNONM.Location = new System.Drawing.Point(13, 270);
            this.txt01_PARTNO_PARTNONM.Name = "txt01_PARTNO_PARTNONM";
            this.txt01_PARTNO_PARTNONM.Size = new System.Drawing.Size(251, 21);
            this.txt01_PARTNO_PARTNONM.TabIndex = 19;
            this.txt01_PARTNO_PARTNONM.Tag = null;
            // 
            // lbl01_QA30126_MSG1
            // 
            this.lbl01_QA30126_MSG1.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA30126_MSG1.AutoFontSizeMinValue = 9F;
            this.lbl01_QA30126_MSG1.AutoSize = true;
            this.lbl01_QA30126_MSG1.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_QA30126_MSG1.Location = new System.Drawing.Point(13, 347);
            this.lbl01_QA30126_MSG1.Name = "lbl01_QA30126_MSG1";
            this.lbl01_QA30126_MSG1.Size = new System.Drawing.Size(123, 12);
            this.lbl01_QA30126_MSG1.TabIndex = 18;
            this.lbl01_QA30126_MSG1.Tag = null;
            this.lbl01_QA30126_MSG1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_QA30126_MSG1.Value = "(더블클릭시 상세조회가 가능합니다.)";
            // 
            // lbl01_PARTNO_PARTNONM
            // 
            this.lbl01_PARTNO_PARTNONM.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO_PARTNONM.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO_PARTNONM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PARTNO_PARTNONM.Location = new System.Drawing.Point(13, 255);
            this.lbl01_PARTNO_PARTNONM.Name = "lbl01_PARTNO_PARTNONM";
            this.lbl01_PARTNO_PARTNONM.Size = new System.Drawing.Size(251, 12);
            this.lbl01_PARTNO_PARTNONM.TabIndex = 13;
            this.lbl01_PARTNO_PARTNONM.Tag = null;
            this.lbl01_PARTNO_PARTNONM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO_PARTNONM.Value = "품번/품명";
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = false;
            this.cdx01_VENDCD.CodeTextBoxWidth = 40;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(13, 175);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(251, 21);
            this.cdx01_VENDCD.TabIndex = 12;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_IMPUT_VENDNM
            // 
            this.lbl01_IMPUT_VENDNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_IMPUT_VENDNM.AutoFontSizeMinValue = 9F;
            this.lbl01_IMPUT_VENDNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_IMPUT_VENDNM.Location = new System.Drawing.Point(13, 160);
            this.lbl01_IMPUT_VENDNM.Name = "lbl01_IMPUT_VENDNM";
            this.lbl01_IMPUT_VENDNM.Size = new System.Drawing.Size(251, 12);
            this.lbl01_IMPUT_VENDNM.TabIndex = 11;
            this.lbl01_IMPUT_VENDNM.Tag = null;
            this.lbl01_IMPUT_VENDNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_IMPUT_VENDNM.Value = "귀책업체";
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(132, 131);
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
            this.dte01_RCV_DATE_TO.Location = new System.Drawing.Point(154, 125);
            this.dte01_RCV_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RCV_DATE_TO.Name = "dte01_RCV_DATE_TO";
            this.dte01_RCV_DATE_TO.OriginalFormat = "";
            this.dte01_RCV_DATE_TO.Size = new System.Drawing.Size(110, 21);
            this.dte01_RCV_DATE_TO.TabIndex = 9;
            // 
            // cbo01_IMPUT_DIVCD
            // 
            this.cbo01_IMPUT_DIVCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_IMPUT_DIVCD.FormattingEnabled = true;
            this.cbo01_IMPUT_DIVCD.Location = new System.Drawing.Point(13, 223);
            this.cbo01_IMPUT_DIVCD.Name = "cbo01_IMPUT_DIVCD";
            this.cbo01_IMPUT_DIVCD.Size = new System.Drawing.Size(251, 20);
            this.cbo01_IMPUT_DIVCD.TabIndex = 8;
            // 
            // lbl01_IMPUT_DIVCD
            // 
            this.lbl01_IMPUT_DIVCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_IMPUT_DIVCD.AutoFontSizeMinValue = 9F;
            this.lbl01_IMPUT_DIVCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_IMPUT_DIVCD.Location = new System.Drawing.Point(13, 208);
            this.lbl01_IMPUT_DIVCD.Name = "lbl01_IMPUT_DIVCD";
            this.lbl01_IMPUT_DIVCD.Size = new System.Drawing.Size(251, 12);
            this.lbl01_IMPUT_DIVCD.TabIndex = 7;
            this.lbl01_IMPUT_DIVCD.Tag = null;
            this.lbl01_IMPUT_DIVCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_IMPUT_DIVCD.Value = "귀책구분";
            // 
            // dte01_RCV_DATE_FROM
            // 
            this.dte01_RCV_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_RCV_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_RCV_DATE_FROM.Location = new System.Drawing.Point(13, 127);
            this.dte01_RCV_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_RCV_DATE_FROM.Name = "dte01_RCV_DATE_FROM";
            this.dte01_RCV_DATE_FROM.OriginalFormat = "";
            this.dte01_RCV_DATE_FROM.Size = new System.Drawing.Size(110, 21);
            this.dte01_RCV_DATE_FROM.TabIndex = 6;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 33);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(251, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_OCCUR_DATE
            // 
            this.lbl01_OCCUR_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_OCCUR_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_OCCUR_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_OCCUR_DATE.Location = new System.Drawing.Point(13, 112);
            this.lbl01_OCCUR_DATE.Name = "lbl01_OCCUR_DATE";
            this.lbl01_OCCUR_DATE.Size = new System.Drawing.Size(251, 12);
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
            this.lbl01_BIZNM.Location = new System.Drawing.Point(13, 18);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(251, 12);
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
            this.heDockingTab1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_TO);
            this.panel1.Controls.Add(this.lbl01_QA30126_MSG1);
            this.panel1.Controls.Add(this.txt01_PARTNO_PARTNONM);
            this.panel1.Controls.Add(this.cbo01_DEFTYPE);
            this.panel1.Controls.Add(this.cbo01_IMPUT_DIVCD);
            this.panel1.Controls.Add(this.cdx01_VENDCD);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.heLabel2);
            this.panel1.Controls.Add(this.dte01_RCV_DATE_FROM);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.lbl01_PARTNO_PARTNONM);
            this.panel1.Controls.Add(this.lbl01_DEFTYPE);
            this.panel1.Controls.Add(this.lbl01_IMPUT_DIVCD);
            this.panel1.Controls.Add(this.lbl01_IMPUT_VENDNM);
            this.panel1.Controls.Add(this.lbl01_OCCUR_DATE);
            this.panel1.Location = new System.Drawing.Point(29, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 461);
            this.panel1.TabIndex = 20;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(13, 303);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(251, 12);
            this.lbl01_PLANT_DIV.TabIndex = 23;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(13, 317);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(251, 20);
            this.cbo01_PLANT_DIV.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox_main);
            this.panel2.Location = new System.Drawing.Point(310, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 461);
            this.panel2.TabIndex = 21;
            // 
            // QA30126
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30126";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30126)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEFTYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNONM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA30126_MSG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PARTNONM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_VENDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_DIVCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30126;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO_PARTNONM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA30126_MSG1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO_PARTNONM;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_IMPUT_VENDNM;
        private Ax.DEV.Utility.Controls.AxLabel heLabel2;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_TO;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_IMPUT_DIVCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_IMPUT_DIVCD;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_RCV_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OCCUR_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_DEFTYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DEFTYPE;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
