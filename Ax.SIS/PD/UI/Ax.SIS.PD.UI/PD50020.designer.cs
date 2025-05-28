namespace Ax.SIS.PD.UI
{
    partial class PD50020
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdExcel = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo01_EXL_SHEET = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_EXL_SHEET = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_EXCEL_DOWN = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_FILE_UPLOAD2 = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_EXL_FILE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_EXL_FILE = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExcel)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXL_SHEET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EXL_FILE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXL_FILE)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdExcel);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.axDockingTab1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 734);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // grdExcel
            // 
            this.grdExcel.AllowHeaderMerging = false;
            this.grdExcel.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grdExcel.EnabledActionFlag = true;
            this.grdExcel.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grdExcel.LastRowAdd = false;
            this.grdExcel.Location = new System.Drawing.Point(386, 543);
            this.grdExcel.Name = "grdExcel";
            this.grdExcel.OriginalFormat = null;
            this.grdExcel.PopMenuVisible = true;
            this.grdExcel.Rows.DefaultSize = 18;
            this.grdExcel.Size = new System.Drawing.Size(306, 188);
            this.grdExcel.TabIndex = 18;
            this.grdExcel.UseCustomHighlight = true;
            this.grdExcel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd01);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(320, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(701, 523);
            this.panel2.TabIndex = 15;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 59);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(701, 464);
            this.grd01.TabIndex = 11;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbo01_EXL_SHEET);
            this.groupBox2.Controls.Add(this.lbl01_EXL_SHEET);
            this.groupBox2.Controls.Add(this.btn01_EXCEL_DOWN);
            this.groupBox2.Controls.Add(this.btn01_FILE_UPLOAD2);
            this.groupBox2.Controls.Add(this.txt01_EXL_FILE);
            this.groupBox2.Controls.Add(this.lbl01_EXL_FILE);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 59);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // cbo01_EXL_SHEET
            // 
            this.cbo01_EXL_SHEET.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_EXL_SHEET.FormattingEnabled = true;
            this.cbo01_EXL_SHEET.Location = new System.Drawing.Point(117, 35);
            this.cbo01_EXL_SHEET.Name = "cbo01_EXL_SHEET";
            this.cbo01_EXL_SHEET.Size = new System.Drawing.Size(396, 20);
            this.cbo01_EXL_SHEET.TabIndex = 96;
            this.cbo01_EXL_SHEET.SelectedValueChanged += new System.EventHandler(this.cbo01_EXL_SHEET_SelectedValueChanged);
            // 
            // lbl01_EXL_SHEET
            // 
            this.lbl01_EXL_SHEET.AutoFontSizeMaxValue = 9F;
            this.lbl01_EXL_SHEET.AutoFontSizeMinValue = 9F;
            this.lbl01_EXL_SHEET.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EXL_SHEET.Location = new System.Drawing.Point(11, 35);
            this.lbl01_EXL_SHEET.Name = "lbl01_EXL_SHEET";
            this.lbl01_EXL_SHEET.Size = new System.Drawing.Size(100, 21);
            this.lbl01_EXL_SHEET.TabIndex = 94;
            this.lbl01_EXL_SHEET.Tag = null;
            this.lbl01_EXL_SHEET.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EXL_SHEET.Value = "Excel Sheet";
            // 
            // btn01_EXCEL_DOWN
            // 
            this.btn01_EXCEL_DOWN.Location = new System.Drawing.Point(519, 34);
            this.btn01_EXCEL_DOWN.Name = "btn01_EXCEL_DOWN";
            this.btn01_EXCEL_DOWN.Size = new System.Drawing.Size(126, 23);
            this.btn01_EXCEL_DOWN.TabIndex = 49;
            this.btn01_EXCEL_DOWN.Text = "Excel Form Down";
            this.btn01_EXCEL_DOWN.UseVisualStyleBackColor = true;
            this.btn01_EXCEL_DOWN.Click += new System.EventHandler(this.btn01_EXCEL_DOWN_Click);
            // 
            // btn01_FILE_UPLOAD2
            // 
            this.btn01_FILE_UPLOAD2.Location = new System.Drawing.Point(519, 9);
            this.btn01_FILE_UPLOAD2.Name = "btn01_FILE_UPLOAD2";
            this.btn01_FILE_UPLOAD2.Size = new System.Drawing.Size(126, 23);
            this.btn01_FILE_UPLOAD2.TabIndex = 48;
            this.btn01_FILE_UPLOAD2.Text = "Excel File Load";
            this.btn01_FILE_UPLOAD2.UseVisualStyleBackColor = true;
            this.btn01_FILE_UPLOAD2.Click += new System.EventHandler(this.btn01_FILE_UPLOAD2_Click);
            // 
            // txt01_EXL_FILE
            // 
            this.txt01_EXL_FILE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_EXL_FILE.Location = new System.Drawing.Point(117, 11);
            this.txt01_EXL_FILE.Name = "txt01_EXL_FILE";
            this.txt01_EXL_FILE.ReadOnly = true;
            this.txt01_EXL_FILE.Size = new System.Drawing.Size(396, 21);
            this.txt01_EXL_FILE.TabIndex = 42;
            this.txt01_EXL_FILE.Tag = null;
            // 
            // lbl01_EXL_FILE
            // 
            this.lbl01_EXL_FILE.AutoFontSizeMaxValue = 9F;
            this.lbl01_EXL_FILE.AutoFontSizeMinValue = 9F;
            this.lbl01_EXL_FILE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EXL_FILE.Location = new System.Drawing.Point(11, 11);
            this.lbl01_EXL_FILE.Name = "lbl01_EXL_FILE";
            this.lbl01_EXL_FILE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_EXL_FILE.TabIndex = 10;
            this.lbl01_EXL_FILE.Tag = null;
            this.lbl01_EXL_FILE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EXL_FILE.Value = "Exdel File";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cdx01_VENDCD);
            this.panel1.Controls.Add(this.lbl01_VENDCD);
            this.panel1.Controls.Add(this.dtp01_STD_DATE);
            this.panel1.Controls.Add(this.lbl01_STD_DATE);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 714);
            this.panel1.TabIndex = 13;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 50;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(13, 152);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_VENDCD.TabIndex = 96;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VENDCD.Location = new System.Drawing.Point(13, 137);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(200, 12);
            this.lbl01_VENDCD.TabIndex = 95;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VENDCD.Value = "Vendor Code";
            // 
            // dtp01_STD_DATE
            // 
            this.dtp01_STD_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STD_DATE.Location = new System.Drawing.Point(13, 88);
            this.dtp01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STD_DATE.Name = "dtp01_STD_DATE";
            this.dtp01_STD_DATE.OriginalFormat = "";
            this.dtp01_STD_DATE.Size = new System.Drawing.Size(200, 21);
            this.dtp01_STD_DATE.TabIndex = 5;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(13, 73);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(200, 12);
            this.lbl01_STD_DATE.TabIndex = 4;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_STD_DATE.Value = "Work Date";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 30);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(200, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 15);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(200, 12);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // axDockingTab1
            // 
            this.axDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.axDockingTab1.Name = "axDockingTab1";
            this.axDockingTab1.PanelHeight = 714;
            this.axDockingTab1.PanelWidth = 313;
            this.axDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.axDockingTab1.TabIndex = 14;
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel 97 - 2003 통합 문서|*.xls|Excel 통합 문서|*.xlsx";
            // 
            // PD50020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "PD50020";
            this.Load += new System.EventHandler(this.PD50020_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExcel)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXL_SHEET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EXL_FILE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXL_FILE)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxDockingTab axDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxDateEdit dtp01_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox2;
        private DEV.Utility.Controls.AxLabel lbl01_EXL_SHEET;
        private DEV.Utility.Controls.AxButton btn01_EXCEL_DOWN;
        private DEV.Utility.Controls.AxButton btn01_FILE_UPLOAD2;
        private DEV.Utility.Controls.AxTextBox txt01_EXL_FILE;
        private DEV.Utility.Controls.AxLabel lbl01_EXL_FILE;
        private System.Windows.Forms.SaveFileDialog sfdExcel;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private DEV.Utility.Controls.AxFlexGrid grdExcel;
        private DEV.Utility.Controls.AxComboBox cbo01_EXL_SHEET;
    }
}
