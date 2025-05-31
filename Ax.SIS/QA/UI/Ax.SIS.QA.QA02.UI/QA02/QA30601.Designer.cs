namespace Ax.SIS.QA.QA02.UI
{
    partial class QA30601
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
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_INSPECT_CLASSCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.dte01_OCCUR_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_OCCUR_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_ATN_QUITT_TERM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA_INSPECT_BASECODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_QA30601 = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01_QA30601 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.grd02_QA30601 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_INSPECT_CLASSCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ATN_QUITT_TERM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA_INSPECT_BASECODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_QA30601)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30601)).BeginInit();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA30601)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.cdx01_INSPECT_CLASSCD);
            this.panel1.Controls.Add(this.dte01_OCCUR_END_DATE);
            this.panel1.Controls.Add(this.dte01_OCCUR_BEG_DATE);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_ATN_QUITT_TERM);
            this.panel1.Controls.Add(this.lbl01_QA_INSPECT_BASECODE);
            this.panel1.Controls.Add(this.lbl02_QA30601);
            this.panel1.Location = new System.Drawing.Point(1, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 715);
            this.panel1.TabIndex = 11;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.White;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 167);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(237, 12);
            this.lbl01_PLANT_DIV.TabIndex = 79;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(14, 182);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(237, 20);
            this.cbo01_PLANT_DIV.TabIndex = 78;
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
            this.cdx01_INSPECT_CLASSCD.TabIndex = 14;
            this.cdx01_INSPECT_CLASSCD.Tag = null;
            // 
            // dte01_OCCUR_END_DATE
            // 
            this.dte01_OCCUR_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_OCCUR_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_OCCUR_END_DATE.Location = new System.Drawing.Point(151, 84);
            this.dte01_OCCUR_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_OCCUR_END_DATE.Name = "dte01_OCCUR_END_DATE";
            this.dte01_OCCUR_END_DATE.OriginalFormat = "";
            this.dte01_OCCUR_END_DATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_OCCUR_END_DATE.TabIndex = 12;
            // 
            // dte01_OCCUR_BEG_DATE
            // 
            this.dte01_OCCUR_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_OCCUR_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_OCCUR_BEG_DATE.Location = new System.Drawing.Point(14, 84);
            this.dte01_OCCUR_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_OCCUR_BEG_DATE.Name = "dte01_OCCUR_BEG_DATE";
            this.dte01_OCCUR_BEG_DATE.OriginalFormat = "";
            this.dte01_OCCUR_BEG_DATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_OCCUR_BEG_DATE.TabIndex = 11;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(14, 22);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(237, 12);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "사업장명";
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
            // lbl01_ATN_QUITT_TERM
            // 
            this.lbl01_ATN_QUITT_TERM.AutoFontSizeMaxValue = 9F;
            this.lbl01_ATN_QUITT_TERM.AutoFontSizeMinValue = 9F;
            this.lbl01_ATN_QUITT_TERM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_ATN_QUITT_TERM.Location = new System.Drawing.Point(14, 69);
            this.lbl01_ATN_QUITT_TERM.Name = "lbl01_ATN_QUITT_TERM";
            this.lbl01_ATN_QUITT_TERM.Size = new System.Drawing.Size(237, 12);
            this.lbl01_ATN_QUITT_TERM.TabIndex = 1;
            this.lbl01_ATN_QUITT_TERM.Tag = null;
            this.lbl01_ATN_QUITT_TERM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ATN_QUITT_TERM.Value = "조회기간";
            // 
            // lbl01_QA_INSPECT_BASECODE
            // 
            this.lbl01_QA_INSPECT_BASECODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA_INSPECT_BASECODE.AutoFontSizeMinValue = 9F;
            this.lbl01_QA_INSPECT_BASECODE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_QA_INSPECT_BASECODE.Location = new System.Drawing.Point(14, 117);
            this.lbl01_QA_INSPECT_BASECODE.Name = "lbl01_QA_INSPECT_BASECODE";
            this.lbl01_QA_INSPECT_BASECODE.Size = new System.Drawing.Size(237, 12);
            this.lbl01_QA_INSPECT_BASECODE.TabIndex = 2;
            this.lbl01_QA_INSPECT_BASECODE.Tag = null;
            this.lbl01_QA_INSPECT_BASECODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_QA_INSPECT_BASECODE.Value = "검사코드";
            // 
            // lbl02_QA30601
            // 
            this.lbl02_QA30601.AutoFontSizeMaxValue = 9F;
            this.lbl02_QA30601.AutoFontSizeMinValue = 9F;
            this.lbl02_QA30601.AutoSize = true;
            this.lbl02_QA30601.BackColor = System.Drawing.Color.Transparent;
            this.lbl02_QA30601.Location = new System.Drawing.Point(120, 88);
            this.lbl02_QA30601.Name = "lbl02_QA30601";
            this.lbl02_QA30601.Size = new System.Drawing.Size(83, 12);
            this.lbl02_QA30601.TabIndex = 13;
            this.lbl02_QA30601.Tag = null;
            this.lbl02_QA30601.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_QA30601.Value = "~";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox_main);
            this.panel2.Location = new System.Drawing.Point(332, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 703);
            this.panel2.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA30601);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(798, 524);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "공정 순회검사일보 목록";
            // 
            // grd01_QA30601
            // 
            this.grd01_QA30601.AllowHeaderMerging = false;
            this.grd01_QA30601.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders;
            this.grd01_QA30601.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01_QA30601.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30601.EnabledActionFlag = true;
            this.grd01_QA30601.LastRowAdd = false;
            this.grd01_QA30601.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30601.Name = "grd01_QA30601";
            this.grd01_QA30601.OriginalFormat = null;
            this.grd01_QA30601.PopMenuVisible = false;
            this.grd01_QA30601.Rows.DefaultSize = 18;
            this.grd01_QA30601.Size = new System.Drawing.Size(792, 504);
            this.grd01_QA30601.TabIndex = 0;
            this.grd01_QA30601.UseCustomHighlight = true;
            this.grd01_QA30601.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA30601_MouseDoubleClick);
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.grd02_QA30601);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_main.Location = new System.Drawing.Point(0, 524);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(798, 179);
            this.groupBox_main.TabIndex = 2;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "완제품 파견불량 현황";
            // 
            // grd02_QA30601
            // 
            this.grd02_QA30601.AllowHeaderMerging = false;
            this.grd02_QA30601.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders;
            this.grd02_QA30601.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02_QA30601.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02_QA30601.EnabledActionFlag = true;
            this.grd02_QA30601.LastRowAdd = false;
            this.grd02_QA30601.Location = new System.Drawing.Point(3, 17);
            this.grd02_QA30601.Name = "grd02_QA30601";
            this.grd02_QA30601.OriginalFormat = null;
            this.grd02_QA30601.PopMenuVisible = false;
            this.grd02_QA30601.Rows.DefaultSize = 18;
            this.grd02_QA30601.Size = new System.Drawing.Size(792, 159);
            this.grd02_QA30601.TabIndex = 1;
            this.grd02_QA30601.UseCustomHighlight = true;
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 10;
            // 
            // QA30601
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30601";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_INSPECT_CLASSCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ATN_QUITT_TERM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA_INSPECT_BASECODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_QA30601)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30601)).EndInit();
            this.groupBox_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA30601)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_OCCUR_END_DATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_OCCUR_BEG_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ATN_QUITT_TERM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA_INSPECT_BASECODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_QA30601;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30601;
        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02_QA30601;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_INSPECT_CLASSCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
