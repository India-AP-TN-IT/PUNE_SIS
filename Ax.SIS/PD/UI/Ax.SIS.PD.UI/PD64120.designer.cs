namespace Ax.SIS.PD.UI
{
    partial class PD64120
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
            this.lbl01_ORDNO1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_ORDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cdx01_STR_LOC = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_STR_LOC = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_PROCESS_SAP = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_CREATE_END_INV = new Ax.DEV.Utility.Controls.AxButton();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ORDNO1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ORDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_STR_LOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01
            // 
            this.grp01.BackColor = System.Drawing.SystemColors.Window;
            this.grp01.Controls.Add(this.lbl01_ORDNO1);
            this.grp01.Controls.Add(this.txt01_ORDNO);
            this.grp01.Controls.Add(this.cdx01_STR_LOC);
            this.grp01.Controls.Add(this.lbl01_STR_LOC);
            this.grp01.Controls.Add(this.btn01_PROCESS_SAP);
            this.grp01.Controls.Add(this.btn01_CREATE_END_INV);
            this.grp01.Controls.Add(this.cdx01_LINECD);
            this.grp01.Controls.Add(this.lbl01_LINECD);
            this.grp01.Controls.Add(this.dte01_STD_DATE);
            this.grp01.Controls.Add(this.lbl01_STD_DATE);
            this.grp01.Controls.Add(this.cbo01_BIZCD);
            this.grp01.Controls.Add(this.lbl01_BIZNM2);
            this.grp01.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01.Location = new System.Drawing.Point(0, 34);
            this.grp01.Name = "grp01";
            this.grp01.Size = new System.Drawing.Size(1024, 99);
            this.grp01.TabIndex = 8;
            this.grp01.TabStop = false;
            // 
            // lbl01_ORDNO1
            // 
            this.lbl01_ORDNO1.AutoFontSizeMaxValue = 9F;
            this.lbl01_ORDNO1.AutoFontSizeMinValue = 9F;
            this.lbl01_ORDNO1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ORDNO1.Location = new System.Drawing.Point(503, 15);
            this.lbl01_ORDNO1.Name = "lbl01_ORDNO1";
            this.lbl01_ORDNO1.Size = new System.Drawing.Size(100, 21);
            this.lbl01_ORDNO1.TabIndex = 76;
            this.lbl01_ORDNO1.Tag = null;
            this.lbl01_ORDNO1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ORDNO1.Value = "오더번호";
            // 
            // txt01_ORDNO
            // 
            this.txt01_ORDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_ORDNO.Location = new System.Drawing.Point(609, 15);
            this.txt01_ORDNO.Name = "txt01_ORDNO";
            this.txt01_ORDNO.Size = new System.Drawing.Size(126, 21);
            this.txt01_ORDNO.TabIndex = 75;
            this.txt01_ORDNO.Tag = null;
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
            this.btn01_PROCESS_SAP.Text = "선택사항 SAP처리";
            this.btn01_PROCESS_SAP.UseVisualStyleBackColor = true;
            this.btn01_PROCESS_SAP.Click += new System.EventHandler(this.btn01_PROCESS_SAP_Click);
            // 
            // btn01_CREATE_END_INV
            // 
            this.btn01_CREATE_END_INV.Location = new System.Drawing.Point(9, 68);
            this.btn01_CREATE_END_INV.Name = "btn01_CREATE_END_INV";
            this.btn01_CREATE_END_INV.Size = new System.Drawing.Size(140, 24);
            this.btn01_CREATE_END_INV.TabIndex = 15;
            this.btn01_CREATE_END_INV.Text = "재고생성";
            this.btn01_CREATE_END_INV.UseVisualStyleBackColor = true;
            this.btn01_CREATE_END_INV.Click += new System.EventHandler(this.btn01_CREATE_INV_Click);
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
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(271, 16);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(120, 21);
            this.lbl01_STD_DATE.TabIndex = 2;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "기준일자";
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
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(9, 16);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(120, 21);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
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
            this.grd01.Size = new System.Drawing.Size(1024, 635);
            this.grd01.TabIndex = 9;
            this.grd01.UseCustomHighlight = true;
            this.grd01.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_BeforeEdit);
            this.grd01.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_CellChecked);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // PD64120
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.grp01);
            this.Name = "PD64120";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grp01, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.grp01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ORDNO1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ORDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_STR_LOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxDateEdit dte01_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxButton btn01_PROCESS_SAP;
        private DEV.Utility.Controls.AxButton btn01_CREATE_END_INV;
        
        
        private DEV.Utility.Controls.AxButton axButton1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxCodeBox cdx01_STR_LOC;
        private DEV.Utility.Controls.AxLabel lbl01_STR_LOC;
        private DEV.Utility.Controls.AxLabel lbl01_ORDNO1;
        private DEV.Utility.Controls.AxTextBox txt01_ORDNO;
    }
}
