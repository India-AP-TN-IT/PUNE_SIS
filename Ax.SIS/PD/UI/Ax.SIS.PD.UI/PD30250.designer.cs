namespace Ax.SIS.PD.UI
{
    partial class PD30250
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_ORDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_ORDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_DASH = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_DASH = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_DELI_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_BIZ_PLAN_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_DELI_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_BIZ_PLAN_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_JOB_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_DELI_DATE03 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_JOBTYPETITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PLAN_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ORDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ORDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DASH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_DATE03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_JOBTYPETITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLAN_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl01_LINECD);
            this.panel2.Controls.Add(this.cdx01_LINECD);
            this.panel2.Controls.Add(this.lbl01_ORDNO);
            this.panel2.Controls.Add(this.txt01_ORDNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO3);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_DASH);
            this.panel2.Controls.Add(this.lbl02_DASH);
            this.panel2.Controls.Add(this.dte01_DELI_EDATE);
            this.panel2.Controls.Add(this.dte01_BIZ_PLAN_EDATE);
            this.panel2.Controls.Add(this.dte01_DELI_SDATE);
            this.panel2.Controls.Add(this.dte01_BIZ_PLAN_SDATE);
            this.panel2.Controls.Add(this.cbo01_JOB_TYPE);
            this.panel2.Controls.Add(this.lbl01_DELI_DATE03);
            this.panel2.Controls.Add(this.lbl01_JOBTYPETITLE);
            this.panel2.Controls.Add(this.lbl01_PLAN_DATE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_LINECD.Location = new System.Drawing.Point(4, 54);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(145, 22);
            this.lbl01_LINECD.TabIndex = 68;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_LINECD.Value = "기준일자";
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(4, 79);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(266, 21);
            this.cdx01_LINECD.TabIndex = 67;
            this.cdx01_LINECD.Tag = null;
            // 
            // lbl01_ORDNO
            // 
            this.lbl01_ORDNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_ORDNO.AutoFontSizeMinValue = 9F;
            this.lbl01_ORDNO.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_ORDNO.Location = new System.Drawing.Point(4, 201);
            this.lbl01_ORDNO.Name = "lbl01_ORDNO";
            this.lbl01_ORDNO.Size = new System.Drawing.Size(100, 23);
            this.lbl01_ORDNO.TabIndex = 65;
            this.lbl01_ORDNO.Tag = null;
            this.lbl01_ORDNO.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_ORDNO.Value = "출고유형";
            // 
            // txt01_ORDNO
            // 
            this.txt01_ORDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_ORDNO.Location = new System.Drawing.Point(4, 227);
            this.txt01_ORDNO.Name = "txt01_ORDNO";
            this.txt01_ORDNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_ORDNO.TabIndex = 64;
            this.txt01_ORDNO.Tag = null;
            // 
            // lbl01_PARTNO3
            // 
            this.lbl01_PARTNO3.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO3.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO3.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PARTNO3.Location = new System.Drawing.Point(4, 250);
            this.lbl01_PARTNO3.Name = "lbl01_PARTNO3";
            this.lbl01_PARTNO3.Size = new System.Drawing.Size(100, 23);
            this.lbl01_PARTNO3.TabIndex = 65;
            this.lbl01_PARTNO3.Tag = null;
            this.lbl01_PARTNO3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_PARTNO3.Value = "출고유형";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(4, 276);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_PARTNO.TabIndex = 64;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_DASH
            // 
            this.lbl01_DASH.AutoFontSizeMaxValue = 9F;
            this.lbl01_DASH.AutoFontSizeMinValue = 9F;
            this.lbl01_DASH.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DASH.Location = new System.Drawing.Point(120, 177);
            this.lbl01_DASH.Name = "lbl01_DASH";
            this.lbl01_DASH.Size = new System.Drawing.Size(29, 21);
            this.lbl01_DASH.TabIndex = 63;
            this.lbl01_DASH.Tag = null;
            this.lbl01_DASH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DASH.Value = "-";
            // 
            // lbl02_DASH
            // 
            this.lbl02_DASH.AutoFontSizeMaxValue = 9F;
            this.lbl02_DASH.AutoFontSizeMinValue = 9F;
            this.lbl02_DASH.BackColor = System.Drawing.Color.Transparent;
            this.lbl02_DASH.Location = new System.Drawing.Point(119, 128);
            this.lbl02_DASH.Name = "lbl02_DASH";
            this.lbl02_DASH.Size = new System.Drawing.Size(29, 21);
            this.lbl02_DASH.TabIndex = 63;
            this.lbl02_DASH.Tag = null;
            this.lbl02_DASH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_DASH.Value = "-";
            // 
            // dte01_DELI_EDATE
            // 
            this.dte01_DELI_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_DELI_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DELI_EDATE.Location = new System.Drawing.Point(155, 177);
            this.dte01_DELI_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DELI_EDATE.Name = "dte01_DELI_EDATE";
            this.dte01_DELI_EDATE.OriginalFormat = "";
            this.dte01_DELI_EDATE.Size = new System.Drawing.Size(110, 21);
            this.dte01_DELI_EDATE.TabIndex = 62;
            // 
            // dte01_BIZ_PLAN_EDATE
            // 
            this.dte01_BIZ_PLAN_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_BIZ_PLAN_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_BIZ_PLAN_EDATE.Location = new System.Drawing.Point(154, 128);
            this.dte01_BIZ_PLAN_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_BIZ_PLAN_EDATE.Name = "dte01_BIZ_PLAN_EDATE";
            this.dte01_BIZ_PLAN_EDATE.OriginalFormat = "";
            this.dte01_BIZ_PLAN_EDATE.Size = new System.Drawing.Size(110, 21);
            this.dte01_BIZ_PLAN_EDATE.TabIndex = 62;
            // 
            // dte01_DELI_SDATE
            // 
            this.dte01_DELI_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_DELI_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DELI_SDATE.Location = new System.Drawing.Point(4, 177);
            this.dte01_DELI_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DELI_SDATE.Name = "dte01_DELI_SDATE";
            this.dte01_DELI_SDATE.OriginalFormat = "";
            this.dte01_DELI_SDATE.Size = new System.Drawing.Size(110, 21);
            this.dte01_DELI_SDATE.TabIndex = 61;
            // 
            // dte01_BIZ_PLAN_SDATE
            // 
            this.dte01_BIZ_PLAN_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_BIZ_PLAN_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_BIZ_PLAN_SDATE.Location = new System.Drawing.Point(3, 128);
            this.dte01_BIZ_PLAN_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_BIZ_PLAN_SDATE.Name = "dte01_BIZ_PLAN_SDATE";
            this.dte01_BIZ_PLAN_SDATE.OriginalFormat = "";
            this.dte01_BIZ_PLAN_SDATE.Size = new System.Drawing.Size(110, 21);
            this.dte01_BIZ_PLAN_SDATE.TabIndex = 61;
            // 
            // cbo01_JOB_TYPE
            // 
            this.cbo01_JOB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_JOB_TYPE.FormattingEnabled = true;
            this.cbo01_JOB_TYPE.Location = new System.Drawing.Point(4, 326);
            this.cbo01_JOB_TYPE.Name = "cbo01_JOB_TYPE";
            this.cbo01_JOB_TYPE.Size = new System.Drawing.Size(261, 20);
            this.cbo01_JOB_TYPE.TabIndex = 41;
            // 
            // lbl01_DELI_DATE03
            // 
            this.lbl01_DELI_DATE03.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELI_DATE03.AutoFontSizeMinValue = 9F;
            this.lbl01_DELI_DATE03.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DELI_DATE03.Location = new System.Drawing.Point(4, 152);
            this.lbl01_DELI_DATE03.Name = "lbl01_DELI_DATE03";
            this.lbl01_DELI_DATE03.Size = new System.Drawing.Size(145, 22);
            this.lbl01_DELI_DATE03.TabIndex = 36;
            this.lbl01_DELI_DATE03.Tag = null;
            this.lbl01_DELI_DATE03.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_DELI_DATE03.Value = "납기일자";
            // 
            // lbl01_JOBTYPETITLE
            // 
            this.lbl01_JOBTYPETITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_JOBTYPETITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_JOBTYPETITLE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_JOBTYPETITLE.Location = new System.Drawing.Point(4, 300);
            this.lbl01_JOBTYPETITLE.Name = "lbl01_JOBTYPETITLE";
            this.lbl01_JOBTYPETITLE.Size = new System.Drawing.Size(100, 23);
            this.lbl01_JOBTYPETITLE.TabIndex = 40;
            this.lbl01_JOBTYPETITLE.Tag = null;
            this.lbl01_JOBTYPETITLE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_JOBTYPETITLE.Value = "제품유형";
            // 
            // lbl01_PLAN_DATE
            // 
            this.lbl01_PLAN_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLAN_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_PLAN_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLAN_DATE.Location = new System.Drawing.Point(3, 103);
            this.lbl01_PLAN_DATE.Name = "lbl01_PLAN_DATE";
            this.lbl01_PLAN_DATE.Size = new System.Drawing.Size(145, 22);
            this.lbl01_PLAN_DATE.TabIndex = 36;
            this.lbl01_PLAN_DATE.Tag = null;
            this.lbl01_PLAN_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_PLAN_DATE.Value = "기준일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(3, 29);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(125, 20);
            this.cbo01_BIZCD.TabIndex = 33;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(3, 3);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 23);
            this.lbl01_BIZNM2.TabIndex = 32;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 2;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 736);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD30250
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD30250";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ORDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ORDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DASH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_DATE03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_JOBTYPETITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLAN_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxComboBox cbo01_JOB_TYPE;
        private DEV.Utility.Controls.AxLabel lbl01_JOBTYPETITLE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxLabel lbl02_DASH;
        private DEV.Utility.Controls.AxDateEdit dte01_BIZ_PLAN_EDATE;
        private DEV.Utility.Controls.AxDateEdit dte01_BIZ_PLAN_SDATE;
        private DEV.Utility.Controls.AxLabel lbl01_PLAN_DATE;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_ORDNO;
        private DEV.Utility.Controls.AxTextBox txt01_ORDNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO3;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_DASH;
        private DEV.Utility.Controls.AxDateEdit dte01_DELI_EDATE;
        private DEV.Utility.Controls.AxDateEdit dte01_DELI_SDATE;
        private DEV.Utility.Controls.AxLabel lbl01_DELI_DATE03;
        
    }
}
