namespace Ax.SIS.PD.UI
{
    partial class PD64110
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
            this.grp01 = new System.Windows.Forms.GroupBox();
            this.btn01_FILE_UPLOAD2 = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_EXCEL_DOWN = new Ax.DEV.Utility.Controls.AxButton();
            this.cdx01_STR_LOC = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_STR_LOC = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_PROCESS_SAP = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_CREATE_END_INV = new Ax.DEV.Utility.Controls.AxButton();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_END_INV_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_STD1_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grp01_CHNG_HISTORY = new System.Windows.Forms.GroupBox();
            this.grd01_2 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grdExcel = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.grp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_STR_LOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_END_INV_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.grp01_CHNG_HISTORY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01
            // 
            this.grp01.BackColor = System.Drawing.SystemColors.Window;
            this.grp01.Controls.Add(this.btn01_FILE_UPLOAD2);
            this.grp01.Controls.Add(this.btn01_EXCEL_DOWN);
            this.grp01.Controls.Add(this.cdx01_STR_LOC);
            this.grp01.Controls.Add(this.lbl01_STR_LOC);
            this.grp01.Controls.Add(this.btn01_PROCESS_SAP);
            this.grp01.Controls.Add(this.btn01_CREATE_END_INV);
            this.grp01.Controls.Add(this.cdx01_LINECD);
            this.grp01.Controls.Add(this.lbl01_LINECD);
            this.grp01.Controls.Add(this.dte01_STD_DATE);
            this.grp01.Controls.Add(this.lbl01_END_INV_STD_DATE);
            this.grp01.Controls.Add(this.cbo01_BIZCD);
            this.grp01.Controls.Add(this.lbl01_BIZNM);
            this.grp01.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01.Location = new System.Drawing.Point(0, 34);
            this.grp01.Name = "grp01";
            this.grp01.Size = new System.Drawing.Size(1024, 99);
            this.grp01.TabIndex = 8;
            this.grp01.TabStop = false;
            // 
            // btn01_FILE_UPLOAD2
            // 
            this.btn01_FILE_UPLOAD2.Location = new System.Drawing.Point(733, 68);
            this.btn01_FILE_UPLOAD2.Name = "btn01_FILE_UPLOAD2";
            this.btn01_FILE_UPLOAD2.Size = new System.Drawing.Size(139, 23);
            this.btn01_FILE_UPLOAD2.TabIndex = 50;
            this.btn01_FILE_UPLOAD2.Text = "업로드";
            this.btn01_FILE_UPLOAD2.UseVisualStyleBackColor = true;
            this.btn01_FILE_UPLOAD2.Click += new System.EventHandler(this.btn01_FILE_UPLOAD2_Click);
            // 
            // btn01_EXCEL_DOWN
            // 
            this.btn01_EXCEL_DOWN.Location = new System.Drawing.Point(877, 68);
            this.btn01_EXCEL_DOWN.Name = "btn01_EXCEL_DOWN";
            this.btn01_EXCEL_DOWN.Size = new System.Drawing.Size(141, 23);
            this.btn01_EXCEL_DOWN.TabIndex = 49;
            this.btn01_EXCEL_DOWN.Text = "Excel 양식받기";
            this.btn01_EXCEL_DOWN.UseVisualStyleBackColor = true;
            this.btn01_EXCEL_DOWN.Click += new System.EventHandler(this.btn01_EXCEL_DOWN_Click);
            // 
            // cdx01_STR_LOC
            // 
            this.cdx01_STR_LOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_STR_LOC.CodeParameterName = "CODE";
            this.cdx01_STR_LOC.CodeTextBoxReadOnly = false;
            this.cdx01_STR_LOC.CodeTextBoxVisible = true;
            this.cdx01_STR_LOC.CodeTextBoxWidth = 50;
            this.cdx01_STR_LOC.HEPopupHelper = null;
            this.cdx01_STR_LOC.Location = new System.Drawing.Point(503, 42);
            this.cdx01_STR_LOC.Name = "cdx01_STR_LOC";
            this.cdx01_STR_LOC.NameParameterName = "NAME";
            this.cdx01_STR_LOC.NameTextBoxReadOnly = false;
            this.cdx01_STR_LOC.NameTextBoxVisible = true;
            this.cdx01_STR_LOC.PopupButtonReadOnly = false;
            this.cdx01_STR_LOC.PopupTitle = "";
            this.cdx01_STR_LOC.PrefixCode = "";
            this.cdx01_STR_LOC.Size = new System.Drawing.Size(232, 21);
            this.cdx01_STR_LOC.TabIndex = 48;
            this.cdx01_STR_LOC.Tag = null;
            this.cdx01_STR_LOC.ButtonClickBefore += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_STR_LOC_ButtonClickBefore);
            // 
            // lbl01_STR_LOC
            // 
            this.lbl01_STR_LOC.AutoFontSizeMaxValue = 9F;
            this.lbl01_STR_LOC.AutoFontSizeMinValue = 9F;
            this.lbl01_STR_LOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STR_LOC.Location = new System.Drawing.Point(397, 42);
            this.lbl01_STR_LOC.Name = "lbl01_STR_LOC";
            this.lbl01_STR_LOC.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STR_LOC.TabIndex = 47;
            this.lbl01_STR_LOC.Tag = null;
            this.lbl01_STR_LOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STR_LOC.Value = "품번";
            // 
            // btn01_PROCESS_SAP
            // 
            this.btn01_PROCESS_SAP.Location = new System.Drawing.Point(155, 68);
            this.btn01_PROCESS_SAP.Name = "btn01_PROCESS_SAP";
            this.btn01_PROCESS_SAP.Size = new System.Drawing.Size(140, 24);
            this.btn01_PROCESS_SAP.TabIndex = 15;
            this.btn01_PROCESS_SAP.Text = "SAP처리";
            this.btn01_PROCESS_SAP.UseVisualStyleBackColor = true;
            this.btn01_PROCESS_SAP.Click += new System.EventHandler(this.btn01_PROCESS_SAP_Click);
            // 
            // btn01_CREATE_END_INV
            // 
            this.btn01_CREATE_END_INV.Location = new System.Drawing.Point(9, 68);
            this.btn01_CREATE_END_INV.Name = "btn01_CREATE_END_INV";
            this.btn01_CREATE_END_INV.Size = new System.Drawing.Size(140, 24);
            this.btn01_CREATE_END_INV.TabIndex = 15;
            this.btn01_CREATE_END_INV.Text = "기초재고 생성";
            this.btn01_CREATE_END_INV.UseVisualStyleBackColor = true;
            this.btn01_CREATE_END_INV.Click += new System.EventHandler(this.btn01_CREATE_END_INV_Click);
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(135, 42);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(256, 21);
            this.cdx01_LINECD.TabIndex = 14;
            this.cdx01_LINECD.Tag = null;
            this.cdx01_LINECD.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_LINECD_ButtonClickAfter);
            this.cdx01_LINECD.ButtonClickBefore += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_LINECD_ButtonClickBefore);
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(9, 42);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(120, 21);
            this.lbl01_LINECD.TabIndex = 10;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "Line";
            // 
            // dte01_STD_DATE
            // 
            this.dte01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_STD_DATE.Location = new System.Drawing.Point(397, 15);
            this.dte01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_STD_DATE.Name = "dte01_STD_DATE";
            this.dte01_STD_DATE.OriginalFormat = "";
            this.dte01_STD_DATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_STD_DATE.TabIndex = 6;
            // 
            // lbl01_END_INV_STD_DATE
            // 
            this.lbl01_END_INV_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_END_INV_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_END_INV_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_END_INV_STD_DATE.Location = new System.Drawing.Point(271, 16);
            this.lbl01_END_INV_STD_DATE.Name = "lbl01_END_INV_STD_DATE";
            this.lbl01_END_INV_STD_DATE.Size = new System.Drawing.Size(120, 21);
            this.lbl01_END_INV_STD_DATE.TabIndex = 2;
            this.lbl01_END_INV_STD_DATE.Tag = null;
            this.lbl01_END_INV_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_END_INV_STD_DATE.Value = "기말재고 반영일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(135, 16);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(9, 16);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(120, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // dte01_STD1_DATE
            // 
            this.dte01_STD1_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_STD1_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_STD1_DATE.Location = new System.Drawing.Point(112, 39);
            this.dte01_STD1_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_STD1_DATE.Name = "dte01_STD1_DATE";
            this.dte01_STD1_DATE.OriginalFormat = "";
            this.dte01_STD1_DATE.Size = new System.Drawing.Size(130, 21);
            this.dte01_STD1_DATE.TabIndex = 6;
            // 
            // axButton1
            // 
            this.axButton1.Location = new System.Drawing.Point(385, 101);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(140, 39);
            this.axButton1.TabIndex = 15;
            this.axButton1.Text = "기말재고 생성";
            this.axButton1.UseVisualStyleBackColor = true;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 133);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 470);
            this.grd01.TabIndex = 9;
            this.grd01.UseCustomHighlight = true;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.White;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 603);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1024, 5);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // grp01_CHNG_HISTORY
            // 
            this.grp01_CHNG_HISTORY.Controls.Add(this.grd01_2);
            this.grp01_CHNG_HISTORY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_CHNG_HISTORY.Location = new System.Drawing.Point(0, 608);
            this.grp01_CHNG_HISTORY.Name = "grp01_CHNG_HISTORY";
            this.grp01_CHNG_HISTORY.Size = new System.Drawing.Size(1024, 160);
            this.grp01_CHNG_HISTORY.TabIndex = 11;
            this.grp01_CHNG_HISTORY.TabStop = false;
            this.grp01_CHNG_HISTORY.Text = "조정이력";
            // 
            // grd01_2
            // 
            this.grd01_2.AllowHeaderMerging = false;
            this.grd01_2.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_2.EnabledActionFlag = true;
            this.grd01_2.LastRowAdd = false;
            this.grd01_2.Location = new System.Drawing.Point(3, 17);
            this.grd01_2.Name = "grd01_2";
            this.grd01_2.OriginalFormat = null;
            this.grd01_2.PopMenuVisible = true;
            this.grd01_2.Rows.DefaultSize = 18;
            this.grd01_2.Size = new System.Drawing.Size(1018, 140);
            this.grd01_2.TabIndex = 2;
            this.grd01_2.UseCustomHighlight = true;
            // 
            // grdExcel
            // 
            this.grdExcel.AllowHeaderMerging = false;
            this.grdExcel.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grdExcel.EnabledActionFlag = true;
            this.grdExcel.LastRowAdd = false;
            this.grdExcel.Location = new System.Drawing.Point(359, 290);
            this.grdExcel.Name = "grdExcel";
            this.grdExcel.OriginalFormat = null;
            this.grdExcel.PopMenuVisible = true;
            this.grdExcel.Rows.DefaultSize = 18;
            this.grdExcel.Size = new System.Drawing.Size(306, 188);
            this.grdExcel.TabIndex = 12;
            this.grdExcel.UseCustomHighlight = true;
            this.grdExcel.Visible = false;
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel 97 - 2003 통합 문서|*.xls|Excel 통합 문서|*.xlsx";
            // 
            // PD64110
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grdExcel);
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grp01_CHNG_HISTORY);
            this.Controls.Add(this.grp01);
            this.Name = "PD64110";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grp01, 0);
            this.Controls.SetChildIndex(this.grp01_CHNG_HISTORY, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.Controls.SetChildIndex(this.grdExcel, 0);
            this.grp01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_STR_LOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_END_INV_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.grp01_CHNG_HISTORY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxDateEdit dte01_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_END_INV_STD_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxButton btn01_PROCESS_SAP;
        private DEV.Utility.Controls.AxButton btn01_CREATE_END_INV;
        
        private DEV.Utility.Controls.AxDateEdit dte01_STD1_DATE;
        private DEV.Utility.Controls.AxButton axButton1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox grp01_CHNG_HISTORY;
        private DEV.Utility.Controls.AxFlexGrid grd01_2;
        private DEV.Utility.Controls.AxCodeBox cdx01_STR_LOC;
        private DEV.Utility.Controls.AxLabel lbl01_STR_LOC;
        private DEV.Utility.Controls.AxButton btn01_FILE_UPLOAD2;
        private DEV.Utility.Controls.AxButton btn01_EXCEL_DOWN;
        private DEV.Utility.Controls.AxFlexGrid grdExcel;
        private System.Windows.Forms.SaveFileDialog sfdExcel;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
    }
}
