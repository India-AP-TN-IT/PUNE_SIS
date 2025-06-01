namespace Ax.SIS.QA.QA02.UI
{
    partial class QA20602
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.grp01_QA20602_GRP1 = new System.Windows.Forms.GroupBox();
            this.grd01_QA20602 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_QA20602_GRP2 = new System.Windows.Forms.GroupBox();
            this.grd02_QA20602 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.dte01_OCCUR_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cdx01_INSPECT_CLASSCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.dte01_OCCUR_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SEARCH_DAY = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_INSPECCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel2.SuspendLayout();
            this.grp01_QA20602_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20602)).BeginInit();
            this.grp01_QA20602_GRP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA20602)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_INSPECT_CLASSCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_DAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grp01_QA20602_GRP1);
            this.panel2.Controls.Add(this.grp01_QA20602_GRP2);
            this.panel2.Location = new System.Drawing.Point(304, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 703);
            this.panel2.TabIndex = 9;
            // 
            // grp01_QA20602_GRP1
            // 
            this.grp01_QA20602_GRP1.Controls.Add(this.grd01_QA20602);
            this.grp01_QA20602_GRP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_QA20602_GRP1.Location = new System.Drawing.Point(0, 0);
            this.grp01_QA20602_GRP1.Name = "grp01_QA20602_GRP1";
            this.grp01_QA20602_GRP1.Size = new System.Drawing.Size(798, 524);
            this.grp01_QA20602_GRP1.TabIndex = 3;
            this.grp01_QA20602_GRP1.TabStop = false;
            this.grp01_QA20602_GRP1.Text = "공정 순회검사일보 품의 목록";
            // 
            // grd01_QA20602
            // 
            this.grd01_QA20602.AllowHeaderMerging = false;
            this.grd01_QA20602.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders;
            this.grd01_QA20602.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01_QA20602.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA20602.EnabledActionFlag = true;
            this.grd01_QA20602.LastRowAdd = false;
            this.grd01_QA20602.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA20602.Name = "grd01_QA20602";
            this.grd01_QA20602.OriginalFormat = null;
            this.grd01_QA20602.PopMenuVisible = false;
            this.grd01_QA20602.Rows.DefaultSize = 18;
            this.grd01_QA20602.Size = new System.Drawing.Size(792, 504);
            this.grd01_QA20602.TabIndex = 0;
            this.grd01_QA20602.UseCustomHighlight = true;
            this.grd01_QA20602.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA20602_MouseClick);
            this.grd01_QA20602.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA20602_MouseDoubleClick);
            // 
            // grp01_QA20602_GRP2
            // 
            this.grp01_QA20602_GRP2.Controls.Add(this.grd02_QA20602);
            this.grp01_QA20602_GRP2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_QA20602_GRP2.Location = new System.Drawing.Point(0, 524);
            this.grp01_QA20602_GRP2.Name = "grp01_QA20602_GRP2";
            this.grp01_QA20602_GRP2.Size = new System.Drawing.Size(798, 179);
            this.grp01_QA20602_GRP2.TabIndex = 2;
            this.grp01_QA20602_GRP2.TabStop = false;
            this.grp01_QA20602_GRP2.Text = "완제품 파견불량 현황";
            // 
            // grd02_QA20602
            // 
            this.grd02_QA20602.AllowHeaderMerging = false;
            this.grd02_QA20602.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders;
            this.grd02_QA20602.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02_QA20602.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02_QA20602.EnabledActionFlag = true;
            this.grd02_QA20602.LastRowAdd = false;
            this.grd02_QA20602.Location = new System.Drawing.Point(3, 17);
            this.grd02_QA20602.Name = "grd02_QA20602";
            this.grd02_QA20602.OriginalFormat = null;
            this.grd02_QA20602.PopMenuVisible = false;
            this.grd02_QA20602.Rows.DefaultSize = 18;
            this.grd02_QA20602.Size = new System.Drawing.Size(792, 159);
            this.grd02_QA20602.TabIndex = 1;
            this.grd02_QA20602.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.dte01_OCCUR_DATE_TO);
            this.panel1.Controls.Add(this.cdx01_INSPECT_CLASSCD);
            this.panel1.Controls.Add(this.dte01_OCCUR_DATE_FROM);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_SEARCH_DAY);
            this.panel1.Controls.Add(this.lbl01_INSPECCD);
            this.panel1.Controls.Add(this.heLabel1);
            this.panel1.Location = new System.Drawing.Point(1, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 715);
            this.panel1.TabIndex = 8;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.White;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 163);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(126, 15);
            this.lbl01_PLANT_DIV.TabIndex = 77;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(14, 181);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(237, 20);
            this.cbo01_PLANT_DIV.TabIndex = 76;
            // 
            // dte01_OCCUR_DATE_TO
            // 
            this.dte01_OCCUR_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_OCCUR_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_OCCUR_DATE_TO.Location = new System.Drawing.Point(133, 84);
            this.dte01_OCCUR_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_OCCUR_DATE_TO.Name = "dte01_OCCUR_DATE_TO";
            this.dte01_OCCUR_DATE_TO.OriginalFormat = "";
            this.dte01_OCCUR_DATE_TO.Size = new System.Drawing.Size(91, 21);
            this.dte01_OCCUR_DATE_TO.TabIndex = 18;
            // 
            // cdx01_INSPECT_CLASSCD
            // 
            this.cdx01_INSPECT_CLASSCD.CodeParameterName = "CODE";
            this.cdx01_INSPECT_CLASSCD.CodeTextBoxReadOnly = false;
            this.cdx01_INSPECT_CLASSCD.CodeTextBoxVisible = false;
            this.cdx01_INSPECT_CLASSCD.CodeTextBoxWidth = 40;
            this.cdx01_INSPECT_CLASSCD.HEPopupHelper = null;
            this.cdx01_INSPECT_CLASSCD.Location = new System.Drawing.Point(14, 132);
            this.cdx01_INSPECT_CLASSCD.Name = "cdx01_INSPECT_CLASSCD";
            this.cdx01_INSPECT_CLASSCD.NameParameterName = "NAME";
            this.cdx01_INSPECT_CLASSCD.NameTextBoxReadOnly = false;
            this.cdx01_INSPECT_CLASSCD.NameTextBoxVisible = true;
            this.cdx01_INSPECT_CLASSCD.PopupButtonReadOnly = false;
            this.cdx01_INSPECT_CLASSCD.PopupTitle = "";
            this.cdx01_INSPECT_CLASSCD.PrefixCode = "";
            this.cdx01_INSPECT_CLASSCD.Size = new System.Drawing.Size(237, 21);
            this.cdx01_INSPECT_CLASSCD.TabIndex = 17;
            this.cdx01_INSPECT_CLASSCD.Tag = null;
            // 
            // dte01_OCCUR_DATE_FROM
            // 
            this.dte01_OCCUR_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_OCCUR_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_OCCUR_DATE_FROM.Location = new System.Drawing.Point(14, 84);
            this.dte01_OCCUR_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_OCCUR_DATE_FROM.Name = "dte01_OCCUR_DATE_FROM";
            this.dte01_OCCUR_DATE_FROM.OriginalFormat = "";
            this.dte01_OCCUR_DATE_FROM.Size = new System.Drawing.Size(91, 21);
            this.dte01_OCCUR_DATE_FROM.TabIndex = 11;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.AutoSize = true;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(14, 22);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(81, 12);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(237, 20);
            this.cbo01_BIZCD.TabIndex = 6;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_SEARCH_DAY
            // 
            this.lbl01_SEARCH_DAY.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCH_DAY.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCH_DAY.AutoSize = true;
            this.lbl01_SEARCH_DAY.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SEARCH_DAY.Location = new System.Drawing.Point(14, 69);
            this.lbl01_SEARCH_DAY.Name = "lbl01_SEARCH_DAY";
            this.lbl01_SEARCH_DAY.Size = new System.Drawing.Size(115, 12);
            this.lbl01_SEARCH_DAY.TabIndex = 1;
            this.lbl01_SEARCH_DAY.Tag = null;
            this.lbl01_SEARCH_DAY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SEARCH_DAY.Value = "조회일자";
            // 
            // lbl01_INSPECCD
            // 
            this.lbl01_INSPECCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPECCD.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPECCD.AutoSize = true;
            this.lbl01_INSPECCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_INSPECCD.Location = new System.Drawing.Point(14, 117);
            this.lbl01_INSPECCD.Name = "lbl01_INSPECCD";
            this.lbl01_INSPECCD.Size = new System.Drawing.Size(98, 12);
            this.lbl01_INSPECCD.TabIndex = 2;
            this.lbl01_INSPECCD.Tag = null;
            this.lbl01_INSPECCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSPECCD.Value = "검사코드";
            // 
            // heLabel1
            // 
            this.heLabel1.AutoFontSizeMaxValue = 9F;
            this.heLabel1.AutoFontSizeMinValue = 9F;
            this.heLabel1.AutoSize = true;
            this.heLabel1.BackColor = System.Drawing.Color.Transparent;
            this.heLabel1.Location = new System.Drawing.Point(110, 88);
            this.heLabel1.Name = "heLabel1";
            this.heLabel1.Size = new System.Drawing.Size(56, 12);
            this.heLabel1.TabIndex = 19;
            this.heLabel1.Tag = null;
            this.heLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel1.Value = "~";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 7;
            // 
            // QA20602
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA20602";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel2.ResumeLayout(false);
            this.grp01_QA20602_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20602)).EndInit();
            this.grp01_QA20602_GRP2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA20602)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_INSPECT_CLASSCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_DAY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grp01_QA20602_GRP1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA20602;
        private System.Windows.Forms.GroupBox grp01_QA20602_GRP2;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SEARCH_DAY;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPECCD;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02_QA20602;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_OCCUR_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_INSPECT_CLASSCD;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_OCCUR_DATE_TO;
        private Ax.DEV.Utility.Controls.AxLabel heLabel1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;

    }
}
