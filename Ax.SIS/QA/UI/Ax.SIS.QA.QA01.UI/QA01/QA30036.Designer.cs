namespace Ax.SIS.QA.QA01.UI
{
    partial class QA30036
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QA30036));
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.grd01_QA30036 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_CERT_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_CERT_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_CERT_YEAR = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_INSPECT_EMPNO_EMPNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.chk01_RENEW_LICENSE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo01_LICENSECD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INSPECT_EMPNO_EMPNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LICENCE_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30036)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CERT_YEAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPECT_EMPNO_EMPNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_EMPNO_EMPNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LICENCE_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.grd01_QA30036);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_main.Location = new System.Drawing.Point(0, 0);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(275, 424);
            this.groupBox_main.TabIndex = 6;
            this.groupBox_main.TabStop = false;
            // 
            // grd01_QA30036
            // 
            this.grd01_QA30036.AllowHeaderMerging = false;
            this.grd01_QA30036.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA30036.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30036.EnabledActionFlag = true;
            this.grd01_QA30036.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01_QA30036.LastRowAdd = false;
            this.grd01_QA30036.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30036.Name = "grd01_QA30036";
            this.grd01_QA30036.OriginalFormat = null;
            this.grd01_QA30036.PopMenuVisible = true;
            this.grd01_QA30036.Rows.DefaultSize = 18;
            this.grd01_QA30036.Size = new System.Drawing.Size(269, 404);
            this.grd01_QA30036.StyleInfo = resources.GetString("grd01_QA30036.StyleInfo");
            this.grd01_QA30036.TabIndex = 2;
            this.grd01_QA30036.UseCustomHighlight = true;
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(119, 88);
            this.heLabel2.Name = "heLabel2";
            this.heLabel2.Size = new System.Drawing.Size(59, 15);
            this.heLabel2.TabIndex = 9;
            this.heLabel2.Tag = null;
            this.heLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel2.Value = "~";
            // 
            // dte01_CERT_DATE_TO
            // 
            this.dte01_CERT_DATE_TO.CustomFormat = "yyyy";
            this.dte01_CERT_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_CERT_DATE_TO.Location = new System.Drawing.Point(142, 84);
            this.dte01_CERT_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_CERT_DATE_TO.Name = "dte01_CERT_DATE_TO";
            this.dte01_CERT_DATE_TO.OriginalFormat = "";
            this.dte01_CERT_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_CERT_DATE_TO.TabIndex = 8;
            // 
            // dte01_CERT_DATE_FROM
            // 
            this.dte01_CERT_DATE_FROM.CustomFormat = "yyyy";
            this.dte01_CERT_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_CERT_DATE_FROM.Location = new System.Drawing.Point(14, 84);
            this.dte01_CERT_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_CERT_DATE_FROM.Name = "dte01_CERT_DATE_FROM";
            this.dte01_CERT_DATE_FROM.OriginalFormat = "";
            this.dte01_CERT_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_CERT_DATE_FROM.TabIndex = 7;
            // 
            // lbl01_CERT_YEAR
            // 
            this.lbl01_CERT_YEAR.AutoFontSizeMaxValue = 9F;
            this.lbl01_CERT_YEAR.AutoFontSizeMinValue = 9F;
            this.lbl01_CERT_YEAR.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_CERT_YEAR.Location = new System.Drawing.Point(14, 65);
            this.lbl01_CERT_YEAR.Name = "lbl01_CERT_YEAR";
            this.lbl01_CERT_YEAR.Size = new System.Drawing.Size(247, 15);
            this.lbl01_CERT_YEAR.TabIndex = 6;
            this.lbl01_CERT_YEAR.Tag = null;
            this.lbl01_CERT_YEAR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_CERT_YEAR.Value = "승인대상년도";
            // 
            // txt01_INSPECT_EMPNO_EMPNM
            // 
            this.txt01_INSPECT_EMPNO_EMPNM.Location = new System.Drawing.Point(14, 179);
            this.txt01_INSPECT_EMPNO_EMPNM.Name = "txt01_INSPECT_EMPNO_EMPNM";
            this.txt01_INSPECT_EMPNO_EMPNM.Size = new System.Drawing.Size(247, 21);
            this.txt01_INSPECT_EMPNO_EMPNM.TabIndex = 5;
            this.txt01_INSPECT_EMPNO_EMPNM.Tag = null;
            // 
            // chk01_RENEW_LICENSE
            // 
            this.chk01_RENEW_LICENSE.AutoSize = true;
            this.chk01_RENEW_LICENSE.Location = new System.Drawing.Point(14, 206);
            this.chk01_RENEW_LICENSE.Name = "chk01_RENEW_LICENSE";
            this.chk01_RENEW_LICENSE.Size = new System.Drawing.Size(86, 19);
            this.chk01_RENEW_LICENSE.TabIndex = 4;
            this.chk01_RENEW_LICENSE.Text = "갱신대상자";
            this.chk01_RENEW_LICENSE.UseVisualStyleBackColor = true;
            this.chk01_RENEW_LICENSE.Visible = false;
            // 
            // cbo01_LICENSECD
            // 
            this.cbo01_LICENSECD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_LICENSECD.FormattingEnabled = true;
            this.cbo01_LICENSECD.Location = new System.Drawing.Point(14, 132);
            this.cbo01_LICENSECD.Name = "cbo01_LICENSECD";
            this.cbo01_LICENSECD.Size = new System.Drawing.Size(247, 23);
            this.cbo01_LICENSECD.TabIndex = 2;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(247, 23);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_INSPECT_EMPNO_EMPNM
            // 
            this.lbl01_INSPECT_EMPNO_EMPNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPECT_EMPNO_EMPNM.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPECT_EMPNO_EMPNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_INSPECT_EMPNO_EMPNM.Location = new System.Drawing.Point(14, 161);
            this.lbl01_INSPECT_EMPNO_EMPNM.Name = "lbl01_INSPECT_EMPNO_EMPNM";
            this.lbl01_INSPECT_EMPNO_EMPNM.Size = new System.Drawing.Size(247, 14);
            this.lbl01_INSPECT_EMPNO_EMPNM.TabIndex = 2;
            this.lbl01_INSPECT_EMPNO_EMPNM.Tag = null;
            this.lbl01_INSPECT_EMPNO_EMPNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_INSPECT_EMPNO_EMPNM.Value = "검사원 사번/명";
            // 
            // lbl01_LICENCE_NM
            // 
            this.lbl01_LICENCE_NM.AutoFontSizeMaxValue = 9F;
            this.lbl01_LICENCE_NM.AutoFontSizeMinValue = 9F;
            this.lbl01_LICENCE_NM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_LICENCE_NM.Location = new System.Drawing.Point(14, 114);
            this.lbl01_LICENCE_NM.Name = "lbl01_LICENCE_NM";
            this.lbl01_LICENCE_NM.Size = new System.Drawing.Size(247, 14);
            this.lbl01_LICENCE_NM.TabIndex = 1;
            this.lbl01_LICENCE_NM.Tag = null;
            this.lbl01_LICENCE_NM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_LICENCE_NM.Value = "자격증명";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(14, 19);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(247, 14);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "사업장명";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 377;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.dte01_CERT_DATE_TO);
            this.panel1.Controls.Add(this.chk01_RENEW_LICENSE);
            this.panel1.Controls.Add(this.txt01_INSPECT_EMPNO_EMPNM);
            this.panel1.Controls.Add(this.heLabel2);
            this.panel1.Controls.Add(this.lbl01_INSPECT_EMPNO_EMPNM);
            this.panel1.Controls.Add(this.cbo01_LICENSECD);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_LICENCE_NM);
            this.panel1.Controls.Add(this.dte01_CERT_DATE_FROM);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.lbl01_CERT_YEAR);
            this.panel1.Location = new System.Drawing.Point(34, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 424);
            this.panel1.TabIndex = 8;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 231);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(247, 14);
            this.lbl01_PLANT_DIV.TabIndex = 16;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(14, 249);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(247, 23);
            this.cbo01_PLANT_DIV.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox_main);
            this.panel2.Location = new System.Drawing.Point(325, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 424);
            this.panel2.TabIndex = 9;
            // 
            // QA30036
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30036";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30036)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CERT_YEAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPECT_EMPNO_EMPNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_EMPNO_EMPNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LICENCE_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30036;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_RENEW_LICENSE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_LICENSECD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPECT_EMPNO_EMPNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LICENCE_NM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_INSPECT_EMPNO_EMPNM;
        private Ax.DEV.Utility.Controls.AxLabel heLabel2;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_CERT_DATE_TO;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_CERT_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CERT_YEAR;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
