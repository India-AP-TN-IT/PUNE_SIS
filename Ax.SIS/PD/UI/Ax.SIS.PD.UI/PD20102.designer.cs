namespace Ax.SIS.PD.UI
{
    partial class PD20102
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn01_DOWN = new Ax.DEV.Utility.Controls.AxButton();
            this.dtp01_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_APPLY_END_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_APPLY_BEG_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PRDTDIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.btn01_EXCEL_LOAD = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_EXCEL_FILE = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_EXCEL_FILE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo01_EXCEL_SHEET = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_EXCEL_SHEET = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_EXCEL = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_END_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_BEG_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDTDIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EXCEL_FILE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXCEL_SHEET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXCEL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn01_DOWN);
            this.groupBox2.Controls.Add(this.dtp01_END_DATE);
            this.groupBox2.Controls.Add(this.dtp01_BEG_DATE);
            this.groupBox2.Controls.Add(this.lbl01_APPLY_END_DATE);
            this.groupBox2.Controls.Add(this.lbl01_APPLY_BEG_DATE);
            this.groupBox2.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox2.Controls.Add(this.cbo01_BIZCD);
            this.groupBox2.Controls.Add(this.lbl01_PRDTDIV);
            this.groupBox2.Controls.Add(this.cbo01_PRDT_DIV);
            this.groupBox2.Controls.Add(this.btn01_EXCEL_LOAD);
            this.groupBox2.Controls.Add(this.btn01_EXCEL_FILE);
            this.groupBox2.Controls.Add(this.txt01_EXCEL_FILE);
            this.groupBox2.Controls.Add(this.cbo01_EXCEL_SHEET);
            this.groupBox2.Controls.Add(this.lbl01_EXCEL_SHEET);
            this.groupBox2.Controls.Add(this.lbl01_EXCEL);
            this.groupBox2.Controls.Add(this.cdx01_VINCD);
            this.groupBox2.Controls.Add(this.lbl01_VINCD);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 128);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // btn01_DOWN
            // 
            this.btn01_DOWN.Location = new System.Drawing.Point(792, 69);
            this.btn01_DOWN.Name = "btn01_DOWN";
            this.btn01_DOWN.Size = new System.Drawing.Size(110, 23);
            this.btn01_DOWN.TabIndex = 81;
            this.btn01_DOWN.Text = "엑셀양식다운로드";
            this.btn01_DOWN.UseVisualStyleBackColor = true;
            this.btn01_DOWN.Click += new System.EventHandler(this.btn01_EXCEL_DOWN_Click);
            // 
            // dtp01_END_DATE
            // 
            this.dtp01_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_END_DATE.Location = new System.Drawing.Point(636, 43);
            this.dtp01_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_END_DATE.Name = "dtp01_END_DATE";
            this.dtp01_END_DATE.OriginalFormat = "";
            this.dtp01_END_DATE.Size = new System.Drawing.Size(150, 21);
            this.dtp01_END_DATE.TabIndex = 80;
            // 
            // dtp01_BEG_DATE
            // 
            this.dtp01_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_DATE.Location = new System.Drawing.Point(374, 43);
            this.dtp01_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_BEG_DATE.Name = "dtp01_BEG_DATE";
            this.dtp01_BEG_DATE.OriginalFormat = "";
            this.dtp01_BEG_DATE.Size = new System.Drawing.Size(150, 21);
            this.dtp01_BEG_DATE.TabIndex = 79;
            // 
            // lbl01_APPLY_END_DATE
            // 
            this.lbl01_APPLY_END_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_APPLY_END_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_APPLY_END_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_APPLY_END_DATE.Location = new System.Drawing.Point(530, 43);
            this.lbl01_APPLY_END_DATE.Name = "lbl01_APPLY_END_DATE";
            this.lbl01_APPLY_END_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_APPLY_END_DATE.TabIndex = 78;
            this.lbl01_APPLY_END_DATE.Tag = null;
            this.lbl01_APPLY_END_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_APPLY_END_DATE.Value = "적용종료일";
            // 
            // lbl01_APPLY_BEG_DATE
            // 
            this.lbl01_APPLY_BEG_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_APPLY_BEG_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_APPLY_BEG_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_APPLY_BEG_DATE.Location = new System.Drawing.Point(268, 43);
            this.lbl01_APPLY_BEG_DATE.Name = "lbl01_APPLY_BEG_DATE";
            this.lbl01_APPLY_BEG_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_APPLY_BEG_DATE.TabIndex = 77;
            this.lbl01_APPLY_BEG_DATE.Tag = null;
            this.lbl01_APPLY_BEG_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_APPLY_BEG_DATE.Value = "적용시작일";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 18);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 76;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 19);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(150, 20);
            this.cbo01_BIZCD.TabIndex = 75;
            // 
            // lbl01_PRDTDIV
            // 
            this.lbl01_PRDTDIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRDTDIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PRDTDIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRDTDIV.Location = new System.Drawing.Point(6, 43);
            this.lbl01_PRDTDIV.Name = "lbl01_PRDTDIV";
            this.lbl01_PRDTDIV.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PRDTDIV.TabIndex = 70;
            this.lbl01_PRDTDIV.Tag = null;
            this.lbl01_PRDTDIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PRDTDIV.Value = "제품구분";
            // 
            // cbo01_PRDT_DIV
            // 
            this.cbo01_PRDT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRDT_DIV.FormattingEnabled = true;
            this.cbo01_PRDT_DIV.Location = new System.Drawing.Point(112, 44);
            this.cbo01_PRDT_DIV.Name = "cbo01_PRDT_DIV";
            this.cbo01_PRDT_DIV.Size = new System.Drawing.Size(150, 20);
            this.cbo01_PRDT_DIV.TabIndex = 69;
            // 
            // btn01_EXCEL_LOAD
            // 
            this.btn01_EXCEL_LOAD.Location = new System.Drawing.Point(676, 96);
            this.btn01_EXCEL_LOAD.Name = "btn01_EXCEL_LOAD";
            this.btn01_EXCEL_LOAD.Size = new System.Drawing.Size(110, 23);
            this.btn01_EXCEL_LOAD.TabIndex = 32;
            this.btn01_EXCEL_LOAD.Text = "시트내용읽기";
            this.btn01_EXCEL_LOAD.UseVisualStyleBackColor = true;
            this.btn01_EXCEL_LOAD.Click += new System.EventHandler(this.btn01_EXCEL_LOAD_Click);
            // 
            // btn01_EXCEL_FILE
            // 
            this.btn01_EXCEL_FILE.Location = new System.Drawing.Point(676, 68);
            this.btn01_EXCEL_FILE.Name = "btn01_EXCEL_FILE";
            this.btn01_EXCEL_FILE.Size = new System.Drawing.Size(110, 23);
            this.btn01_EXCEL_FILE.TabIndex = 31;
            this.btn01_EXCEL_FILE.Text = "Excel 파일찾기";
            this.btn01_EXCEL_FILE.UseVisualStyleBackColor = true;
            this.btn01_EXCEL_FILE.Click += new System.EventHandler(this.btn01_EXCEL_FILE_Click);
            // 
            // txt01_EXCEL_FILE
            // 
            this.txt01_EXCEL_FILE.Location = new System.Drawing.Point(112, 69);
            this.txt01_EXCEL_FILE.Name = "txt01_EXCEL_FILE";
            this.txt01_EXCEL_FILE.Size = new System.Drawing.Size(558, 21);
            this.txt01_EXCEL_FILE.TabIndex = 30;
            this.txt01_EXCEL_FILE.Tag = null;
            // 
            // cbo01_EXCEL_SHEET
            // 
            this.cbo01_EXCEL_SHEET.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_EXCEL_SHEET.FormattingEnabled = true;
            this.cbo01_EXCEL_SHEET.Location = new System.Drawing.Point(112, 97);
            this.cbo01_EXCEL_SHEET.Name = "cbo01_EXCEL_SHEET";
            this.cbo01_EXCEL_SHEET.Size = new System.Drawing.Size(558, 20);
            this.cbo01_EXCEL_SHEET.TabIndex = 29;
            // 
            // lbl01_EXCEL_SHEET
            // 
            this.lbl01_EXCEL_SHEET.AutoFontSizeMaxValue = 9F;
            this.lbl01_EXCEL_SHEET.AutoFontSizeMinValue = 9F;
            this.lbl01_EXCEL_SHEET.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EXCEL_SHEET.Location = new System.Drawing.Point(6, 97);
            this.lbl01_EXCEL_SHEET.Name = "lbl01_EXCEL_SHEET";
            this.lbl01_EXCEL_SHEET.Size = new System.Drawing.Size(100, 21);
            this.lbl01_EXCEL_SHEET.TabIndex = 28;
            this.lbl01_EXCEL_SHEET.Tag = null;
            this.lbl01_EXCEL_SHEET.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EXCEL_SHEET.Value = "Excel Sheet";
            // 
            // lbl01_EXCEL
            // 
            this.lbl01_EXCEL.AutoFontSizeMaxValue = 9F;
            this.lbl01_EXCEL.AutoFontSizeMinValue = 9F;
            this.lbl01_EXCEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EXCEL.Location = new System.Drawing.Point(6, 69);
            this.lbl01_EXCEL.Name = "lbl01_EXCEL";
            this.lbl01_EXCEL.Size = new System.Drawing.Size(100, 21);
            this.lbl01_EXCEL.TabIndex = 27;
            this.lbl01_EXCEL.Tag = null;
            this.lbl01_EXCEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EXCEL.Value = "Excel File";
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(374, 17);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(150, 21);
            this.cdx01_VINCD.TabIndex = 23;
            this.cdx01_VINCD.Tag = null;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(268, 17);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VINCD.TabIndex = 7;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "차종코드";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.splitter1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 606);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd02);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 420);
            this.panel2.TabIndex = 1;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(1018, 420);
            this.grd02.TabIndex = 0;
            this.grd02.UseCustomHighlight = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 178);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1018, 5);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grd01);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 161);
            this.panel1.TabIndex = 0;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 161);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel 통합 문서|*.xlsx|Excel 97 - 2003 통합 문서|*.xls";
            // 
            // PD20102
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "PD20102";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_END_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_BEG_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDTDIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EXCEL_FILE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXCEL_SHEET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXCEL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DEV.Utility.Controls.AxLabel lbl01_PRDTDIV;
        private DEV.Utility.Controls.AxComboBox cbo01_PRDT_DIV;
        private DEV.Utility.Controls.AxButton btn01_EXCEL_LOAD;
        private DEV.Utility.Controls.AxButton btn01_EXCEL_FILE;
        private DEV.Utility.Controls.AxTextBox txt01_EXCEL_FILE;
        private DEV.Utility.Controls.AxComboBox cbo01_EXCEL_SHEET;
        private DEV.Utility.Controls.AxLabel lbl01_EXCEL_SHEET;
        private DEV.Utility.Controls.AxLabel lbl01_EXCEL;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxDateEdit dtp01_END_DATE;
        private DEV.Utility.Controls.AxDateEdit dtp01_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_APPLY_END_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_APPLY_BEG_DATE;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private DEV.Utility.Controls.AxButton btn01_DOWN;
    }
}
