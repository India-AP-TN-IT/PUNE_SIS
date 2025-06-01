namespace Ax.SIS.QA.QA00.UI
{
    partial class QA30118
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
            this.dte01_FROM_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INSPECT_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_MAT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_MAT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VEND = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_TO_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dte01_FROM_DATE
            // 
            this.dte01_FROM_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_FROM_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_FROM_DATE.Location = new System.Drawing.Point(14, 139);
            this.dte01_FROM_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_FROM_DATE.Name = "dte01_FROM_DATE";
            this.dte01_FROM_DATE.OriginalFormat = "";
            this.dte01_FROM_DATE.Size = new System.Drawing.Size(110, 21);
            this.dte01_FROM_DATE.TabIndex = 6;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(234, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_INSPECT_DATE
            // 
            this.lbl01_INSPECT_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPECT_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPECT_DATE.BackColor = System.Drawing.Color.White;
            this.lbl01_INSPECT_DATE.Location = new System.Drawing.Point(14, 115);
            this.lbl01_INSPECT_DATE.Name = "lbl01_INSPECT_DATE";
            this.lbl01_INSPECT_DATE.Size = new System.Drawing.Size(234, 21);
            this.lbl01_INSPECT_DATE.TabIndex = 1;
            this.lbl01_INSPECT_DATE.Tag = null;
            this.lbl01_INSPECT_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_INSPECT_DATE.Value = "Inspect Date";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.White;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(14, 16);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(234, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "Business Name";
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
            this.panel1.Controls.Add(this.lbl01_MAT_DIV);
            this.panel1.Controls.Add(this.cbo01_MAT_DIV);
            this.panel1.Controls.Add(this.cdx01_VENDCD);
            this.panel1.Controls.Add(this.lbl01_VEND);
            this.panel1.Controls.Add(this.dte01_TO_DATE);
            this.panel1.Controls.Add(this.txt01_PARTNO);
            this.panel1.Controls.Add(this.lbl01_PARTNO);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_INSPECT_DATE);
            this.panel1.Controls.Add(this.dte01_FROM_DATE);
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
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.White;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 259);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(234, 21);
            this.lbl01_PLANT_DIV.TabIndex = 21;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(14, 283);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(233, 20);
            this.cbo01_PLANT_DIV.TabIndex = 20;
            // 
            // lbl01_MAT_DIV
            // 
            this.lbl01_MAT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_MAT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_MAT_DIV.BackColor = System.Drawing.Color.White;
            this.lbl01_MAT_DIV.Location = new System.Drawing.Point(14, 212);
            this.lbl01_MAT_DIV.Name = "lbl01_MAT_DIV";
            this.lbl01_MAT_DIV.Size = new System.Drawing.Size(234, 21);
            this.lbl01_MAT_DIV.TabIndex = 18;
            this.lbl01_MAT_DIV.Tag = null;
            this.lbl01_MAT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_MAT_DIV.Value = "MAT_DIV";
            // 
            // cbo01_MAT_DIV
            // 
            this.cbo01_MAT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_MAT_DIV.FormattingEnabled = true;
            this.cbo01_MAT_DIV.Location = new System.Drawing.Point(14, 236);
            this.cbo01_MAT_DIV.Name = "cbo01_MAT_DIV";
            this.cbo01_MAT_DIV.Size = new System.Drawing.Size(234, 20);
            this.cbo01_MAT_DIV.TabIndex = 19;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 50;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(14, 89);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(234, 21);
            this.cdx01_VENDCD.TabIndex = 17;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_VEND
            // 
            this.lbl01_VEND.AutoFontSizeMaxValue = 9F;
            this.lbl01_VEND.AutoFontSizeMinValue = 9F;
            this.lbl01_VEND.BackColor = System.Drawing.Color.White;
            this.lbl01_VEND.Location = new System.Drawing.Point(14, 65);
            this.lbl01_VEND.Name = "lbl01_VEND";
            this.lbl01_VEND.Size = new System.Drawing.Size(234, 20);
            this.lbl01_VEND.TabIndex = 16;
            this.lbl01_VEND.Tag = null;
            this.lbl01_VEND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VEND.Value = "업체";
            // 
            // dte01_TO_DATE
            // 
            this.dte01_TO_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_TO_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_TO_DATE.Location = new System.Drawing.Point(138, 139);
            this.dte01_TO_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_TO_DATE.Name = "dte01_TO_DATE";
            this.dte01_TO_DATE.OriginalFormat = "";
            this.dte01_TO_DATE.Size = new System.Drawing.Size(110, 21);
            this.dte01_TO_DATE.TabIndex = 14;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(14, 188);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(234, 21);
            this.txt01_PARTNO.TabIndex = 13;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.White;
            this.lbl01_PARTNO.Location = new System.Drawing.Point(14, 164);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(234, 21);
            this.lbl01_PARTNO.TabIndex = 12;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "Partno";
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(124, 145);
            this.heLabel2.Name = "heLabel2";
            this.heLabel2.Size = new System.Drawing.Size(56, 12);
            this.heLabel2.TabIndex = 15;
            this.heLabel2.Tag = null;
            this.heLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel2.Value = "~";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 601);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(554, 581);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(318, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 601);
            this.panel2.TabIndex = 13;
            // 
            // QA30118
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30118";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxDateEdit dte01_FROM_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_INSPECT_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxDateEdit dte01_TO_DATE;
        private DEV.Utility.Controls.AxLabel heLabel2;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxLabel lbl01_VEND;
        private System.Windows.Forms.GroupBox groupBox3;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxLabel lbl01_MAT_DIV;
        private DEV.Utility.Controls.AxComboBox cbo01_MAT_DIV;
        private DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
