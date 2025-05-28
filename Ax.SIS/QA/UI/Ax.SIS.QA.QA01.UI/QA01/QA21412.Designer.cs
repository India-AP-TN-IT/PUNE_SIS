namespace Ax.SIS.QA.QA01.UI
{
    partial class QA21412
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.groupBox_excel = new System.Windows.Forms.GroupBox();
            this.lbl01_EXCEL = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_EXCEL_DOWN = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_EXCEL_SELECT = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_FILE_UPLOAD = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_EXCEL = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_REMARK = new Ax.DEV.Utility.Controls.AxTextBox();
            this.nme02_SAL_QTY = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.cbo02_VINCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_VIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_PROD_CUST2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte02_SAL_MONTH = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo02_PROD_CUST = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_SAL_MONTH = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_SAL_QTY2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_REMARK = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo02_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_SAL_MONTH = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_SAL_MONTH = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PROD_CUST = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PROD_CUST2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_VINCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_VIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ofd01_FILE = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.groupBox_main.SuspendLayout();
            this.groupBox_excel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXCEL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EXCEL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_REMARK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_SAL_QTY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_VIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PROD_CUST2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SAL_MONTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SAL_QTY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_REMARK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SAL_MONTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROD_CUST2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01);
            this.groupBox3.Controls.Add(this.grd02);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 557);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "판매 대수 목록";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 537);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(736, 380);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(192, 76);
            this.grd02.TabIndex = 10;
            this.grd02.UseCustomHighlight = true;
            this.grd02.Visible = false;
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.groupBox_excel);
            this.groupBox_main.Controls.Add(this.txt02_REMARK);
            this.groupBox_main.Controls.Add(this.nme02_SAL_QTY);
            this.groupBox_main.Controls.Add(this.cbo02_VINCD);
            this.groupBox_main.Controls.Add(this.lbl02_VIN);
            this.groupBox_main.Controls.Add(this.lbl02_PROD_CUST2);
            this.groupBox_main.Controls.Add(this.dte02_SAL_MONTH);
            this.groupBox_main.Controls.Add(this.cbo02_PROD_CUST);
            this.groupBox_main.Controls.Add(this.lbl02_SAL_MONTH);
            this.groupBox_main.Controls.Add(this.lbl02_SAL_QTY2);
            this.groupBox_main.Controls.Add(this.lbl02_REMARK);
            this.groupBox_main.Controls.Add(this.cbo02_BIZCD);
            this.groupBox_main.Controls.Add(this.lbl02_BIZNM);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_main.Location = new System.Drawing.Point(0, 638);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(1024, 130);
            this.groupBox_main.TabIndex = 7;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "판매 대수 정보";
            // 
            // groupBox_excel
            // 
            this.groupBox_excel.Controls.Add(this.lbl01_EXCEL);
            this.groupBox_excel.Controls.Add(this.btn01_EXCEL_DOWN);
            this.groupBox_excel.Controls.Add(this.btn01_EXCEL_SELECT);
            this.groupBox_excel.Controls.Add(this.btn01_FILE_UPLOAD);
            this.groupBox_excel.Controls.Add(this.txt01_EXCEL);
            this.groupBox_excel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_excel.Location = new System.Drawing.Point(3, 76);
            this.groupBox_excel.Name = "groupBox_excel";
            this.groupBox_excel.Size = new System.Drawing.Size(1018, 51);
            this.groupBox_excel.TabIndex = 39;
            this.groupBox_excel.TabStop = false;
            this.groupBox_excel.Text = "Excel 등록";
            // 
            // lbl01_EXCEL
            // 
            this.lbl01_EXCEL.AutoFontSizeMaxValue = 9F;
            this.lbl01_EXCEL.AutoFontSizeMinValue = 9F;
            this.lbl01_EXCEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EXCEL.Location = new System.Drawing.Point(10, 20);
            this.lbl01_EXCEL.Name = "lbl01_EXCEL";
            this.lbl01_EXCEL.Size = new System.Drawing.Size(90, 21);
            this.lbl01_EXCEL.TabIndex = 2;
            this.lbl01_EXCEL.Tag = null;
            this.lbl01_EXCEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EXCEL.Value = "Excel File";
            // 
            // btn01_EXCEL_DOWN
            // 
            this.btn01_EXCEL_DOWN.Location = new System.Drawing.Point(662, 20);
            this.btn01_EXCEL_DOWN.Name = "btn01_EXCEL_DOWN";
            this.btn01_EXCEL_DOWN.Size = new System.Drawing.Size(145, 23);
            this.btn01_EXCEL_DOWN.TabIndex = 5;
            this.btn01_EXCEL_DOWN.Text = "업로드 양식 다운로드";
            this.btn01_EXCEL_DOWN.UseVisualStyleBackColor = true;
            this.btn01_EXCEL_DOWN.Click += new System.EventHandler(this.btn01_EXCEL_DOWN_Click);
            // 
            // btn01_EXCEL_SELECT
            // 
            this.btn01_EXCEL_SELECT.Location = new System.Drawing.Point(451, 20);
            this.btn01_EXCEL_SELECT.Name = "btn01_EXCEL_SELECT";
            this.btn01_EXCEL_SELECT.Size = new System.Drawing.Size(99, 23);
            this.btn01_EXCEL_SELECT.TabIndex = 5;
            this.btn01_EXCEL_SELECT.Text = "엑셀파일선택";
            this.btn01_EXCEL_SELECT.UseVisualStyleBackColor = true;
            this.btn01_EXCEL_SELECT.Click += new System.EventHandler(this.btn01_EXCEL_SELECT_Click);
            // 
            // btn01_FILE_UPLOAD
            // 
            this.btn01_FILE_UPLOAD.Location = new System.Drawing.Point(556, 20);
            this.btn01_FILE_UPLOAD.Name = "btn01_FILE_UPLOAD";
            this.btn01_FILE_UPLOAD.Size = new System.Drawing.Size(100, 23);
            this.btn01_FILE_UPLOAD.TabIndex = 9;
            this.btn01_FILE_UPLOAD.Text = "파일 업로드";
            this.btn01_FILE_UPLOAD.UseVisualStyleBackColor = true;
            this.btn01_FILE_UPLOAD.Click += new System.EventHandler(this.btn01_FILE_UPLOAD_Click);
            // 
            // txt01_EXCEL
            // 
            this.txt01_EXCEL.Location = new System.Drawing.Point(106, 20);
            this.txt01_EXCEL.Name = "txt01_EXCEL";
            this.txt01_EXCEL.Size = new System.Drawing.Size(339, 21);
            this.txt01_EXCEL.TabIndex = 8;
            this.txt01_EXCEL.Tag = null;
            // 
            // txt02_REMARK
            // 
            this.txt02_REMARK.Location = new System.Drawing.Point(679, 42);
            this.txt02_REMARK.Name = "txt02_REMARK";
            this.txt02_REMARK.Size = new System.Drawing.Size(532, 21);
            this.txt02_REMARK.TabIndex = 38;
            this.txt02_REMARK.Tag = null;
            // 
            // nme02_SAL_QTY
            // 
            this.nme02_SAL_QTY.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.StandardNumber;
            this.nme02_SAL_QTY.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_SAL_QTY.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.StandardNumber;
            this.nme02_SAL_QTY.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_SAL_QTY.EmptyAsNull = true;
            this.nme02_SAL_QTY.Location = new System.Drawing.Point(455, 42);
            this.nme02_SAL_QTY.Name = "nme02_SAL_QTY";
            this.nme02_SAL_QTY.NullText = "0";
            this.nme02_SAL_QTY.Size = new System.Drawing.Size(115, 21);
            this.nme02_SAL_QTY.TabIndex = 37;
            this.nme02_SAL_QTY.Tag = null;
            this.nme02_SAL_QTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme02_SAL_QTY.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // cbo02_VINCD
            // 
            this.cbo02_VINCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_VINCD.FormattingEnabled = true;
            this.cbo02_VINCD.Location = new System.Drawing.Point(113, 42);
            this.cbo02_VINCD.Name = "cbo02_VINCD";
            this.cbo02_VINCD.Size = new System.Drawing.Size(197, 20);
            this.cbo02_VINCD.TabIndex = 32;
            // 
            // lbl02_VIN
            // 
            this.lbl02_VIN.AutoFontSizeMaxValue = 9F;
            this.lbl02_VIN.AutoFontSizeMinValue = 9F;
            this.lbl02_VIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_VIN.Location = new System.Drawing.Point(10, 42);
            this.lbl02_VIN.Name = "lbl02_VIN";
            this.lbl02_VIN.Size = new System.Drawing.Size(100, 21);
            this.lbl02_VIN.TabIndex = 31;
            this.lbl02_VIN.Tag = null;
            this.lbl02_VIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_VIN.Value = "차종";
            // 
            // lbl02_PROD_CUST2
            // 
            this.lbl02_PROD_CUST2.AutoFontSizeMaxValue = 9F;
            this.lbl02_PROD_CUST2.AutoFontSizeMinValue = 9F;
            this.lbl02_PROD_CUST2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_PROD_CUST2.Location = new System.Drawing.Point(576, 15);
            this.lbl02_PROD_CUST2.Name = "lbl02_PROD_CUST2";
            this.lbl02_PROD_CUST2.Size = new System.Drawing.Size(100, 21);
            this.lbl02_PROD_CUST2.TabIndex = 33;
            this.lbl02_PROD_CUST2.Tag = null;
            this.lbl02_PROD_CUST2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_PROD_CUST2.Value = "생산처";
            // 
            // dte02_SAL_MONTH
            // 
            this.dte02_SAL_MONTH.CustomFormat = "yyyy-MM";
            this.dte02_SAL_MONTH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte02_SAL_MONTH.Location = new System.Drawing.Point(455, 16);
            this.dte02_SAL_MONTH.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte02_SAL_MONTH.Name = "dte02_SAL_MONTH";
            this.dte02_SAL_MONTH.OriginalFormat = "";
            this.dte02_SAL_MONTH.Size = new System.Drawing.Size(80, 21);
            this.dte02_SAL_MONTH.TabIndex = 36;
            // 
            // cbo02_PROD_CUST
            // 
            this.cbo02_PROD_CUST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_PROD_CUST.FormattingEnabled = true;
            this.cbo02_PROD_CUST.Location = new System.Drawing.Point(679, 15);
            this.cbo02_PROD_CUST.Name = "cbo02_PROD_CUST";
            this.cbo02_PROD_CUST.Size = new System.Drawing.Size(233, 20);
            this.cbo02_PROD_CUST.TabIndex = 34;
            // 
            // lbl02_SAL_MONTH
            // 
            this.lbl02_SAL_MONTH.AutoFontSizeMaxValue = 9F;
            this.lbl02_SAL_MONTH.AutoFontSizeMinValue = 9F;
            this.lbl02_SAL_MONTH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_SAL_MONTH.Location = new System.Drawing.Point(352, 15);
            this.lbl02_SAL_MONTH.Name = "lbl02_SAL_MONTH";
            this.lbl02_SAL_MONTH.Size = new System.Drawing.Size(100, 21);
            this.lbl02_SAL_MONTH.TabIndex = 35;
            this.lbl02_SAL_MONTH.Tag = null;
            this.lbl02_SAL_MONTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_SAL_MONTH.Value = "판매년월";
            // 
            // lbl02_SAL_QTY2
            // 
            this.lbl02_SAL_QTY2.AutoFontSizeMaxValue = 9F;
            this.lbl02_SAL_QTY2.AutoFontSizeMinValue = 9F;
            this.lbl02_SAL_QTY2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_SAL_QTY2.Location = new System.Drawing.Point(352, 42);
            this.lbl02_SAL_QTY2.Name = "lbl02_SAL_QTY2";
            this.lbl02_SAL_QTY2.Size = new System.Drawing.Size(100, 21);
            this.lbl02_SAL_QTY2.TabIndex = 30;
            this.lbl02_SAL_QTY2.Tag = null;
            this.lbl02_SAL_QTY2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_SAL_QTY2.Value = "판매대수";
            // 
            // lbl02_REMARK
            // 
            this.lbl02_REMARK.AutoFontSizeMaxValue = 9F;
            this.lbl02_REMARK.AutoFontSizeMinValue = 9F;
            this.lbl02_REMARK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_REMARK.Location = new System.Drawing.Point(576, 42);
            this.lbl02_REMARK.Name = "lbl02_REMARK";
            this.lbl02_REMARK.Size = new System.Drawing.Size(100, 21);
            this.lbl02_REMARK.TabIndex = 30;
            this.lbl02_REMARK.Tag = null;
            this.lbl02_REMARK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_REMARK.Value = "비고";
            // 
            // cbo02_BIZCD
            // 
            this.cbo02_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_BIZCD.FormattingEnabled = true;
            this.cbo02_BIZCD.Location = new System.Drawing.Point(113, 17);
            this.cbo02_BIZCD.Name = "cbo02_BIZCD";
            this.cbo02_BIZCD.Size = new System.Drawing.Size(233, 20);
            this.cbo02_BIZCD.TabIndex = 4;
            // 
            // lbl02_BIZNM
            // 
            this.lbl02_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl02_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl02_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_BIZNM.Location = new System.Drawing.Point(10, 17);
            this.lbl02_BIZNM.Name = "lbl02_BIZNM";
            this.lbl02_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl02_BIZNM.TabIndex = 4;
            this.lbl02_BIZNM.Tag = null;
            this.lbl02_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_BIZNM.Value = "사업장";
            // 
            // dte01_SAL_MONTH
            // 
            this.dte01_SAL_MONTH.CustomFormat = "yyyy-MM";
            this.dte01_SAL_MONTH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_SAL_MONTH.Location = new System.Drawing.Point(304, 17);
            this.dte01_SAL_MONTH.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_SAL_MONTH.Name = "dte01_SAL_MONTH";
            this.dte01_SAL_MONTH.OriginalFormat = "";
            this.dte01_SAL_MONTH.Size = new System.Drawing.Size(80, 21);
            this.dte01_SAL_MONTH.TabIndex = 9;
            // 
            // lbl01_SAL_MONTH
            // 
            this.lbl01_SAL_MONTH.AutoFontSizeMaxValue = 9F;
            this.lbl01_SAL_MONTH.AutoFontSizeMinValue = 9F;
            this.lbl01_SAL_MONTH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SAL_MONTH.Location = new System.Drawing.Point(208, 17);
            this.lbl01_SAL_MONTH.Name = "lbl01_SAL_MONTH";
            this.lbl01_SAL_MONTH.Size = new System.Drawing.Size(90, 21);
            this.lbl01_SAL_MONTH.TabIndex = 8;
            this.lbl01_SAL_MONTH.Tag = null;
            this.lbl01_SAL_MONTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SAL_MONTH.Value = "판매년월";
            // 
            // cbo01_PROD_CUST
            // 
            this.cbo01_PROD_CUST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PROD_CUST.FormattingEnabled = true;
            this.cbo01_PROD_CUST.Location = new System.Drawing.Point(486, 17);
            this.cbo01_PROD_CUST.Name = "cbo01_PROD_CUST";
            this.cbo01_PROD_CUST.Size = new System.Drawing.Size(233, 20);
            this.cbo01_PROD_CUST.TabIndex = 7;
            // 
            // lbl01_PROD_CUST2
            // 
            this.lbl01_PROD_CUST2.AutoFontSizeMaxValue = 9F;
            this.lbl01_PROD_CUST2.AutoFontSizeMinValue = 9F;
            this.lbl01_PROD_CUST2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PROD_CUST2.Location = new System.Drawing.Point(390, 17);
            this.lbl01_PROD_CUST2.Name = "lbl01_PROD_CUST2";
            this.lbl01_PROD_CUST2.Size = new System.Drawing.Size(90, 21);
            this.lbl01_PROD_CUST2.TabIndex = 6;
            this.lbl01_PROD_CUST2.Tag = null;
            this.lbl01_PROD_CUST2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PROD_CUST2.Value = "생산처";
            // 
            // cbo01_VINCD
            // 
            this.cbo01_VINCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_VINCD.FormattingEnabled = true;
            this.cbo01_VINCD.Location = new System.Drawing.Point(821, 17);
            this.cbo01_VINCD.Name = "cbo01_VINCD";
            this.cbo01_VINCD.Size = new System.Drawing.Size(197, 20);
            this.cbo01_VINCD.TabIndex = 2;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(104, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(98, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_VIN
            // 
            this.lbl01_VIN.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIN.AutoFontSizeMinValue = 9F;
            this.lbl01_VIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VIN.Location = new System.Drawing.Point(725, 17);
            this.lbl01_VIN.Name = "lbl01_VIN";
            this.lbl01_VIN.Size = new System.Drawing.Size(90, 21);
            this.lbl01_VIN.TabIndex = 1;
            this.lbl01_VIN.Tag = null;
            this.lbl01_VIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VIN.Value = "차종";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(8, 17);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(90, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.cbo01_VINCD);
            this.groupBox1.Controls.Add(this.lbl01_VIN);
            this.groupBox1.Controls.Add(this.lbl01_PROD_CUST2);
            this.groupBox1.Controls.Add(this.dte01_SAL_MONTH);
            this.groupBox1.Controls.Add(this.cbo01_PROD_CUST);
            this.groupBox1.Controls.Add(this.lbl01_SAL_MONTH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 47);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // ofd01_FILE
            // 
            this.ofd01_FILE.FileName = "openFileDialog1";
            // 
            // QA21412
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_main);
            this.Name = "QA21412";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox_main, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_excel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXCEL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EXCEL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_REMARK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_SAL_QTY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_VIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PROD_CUST2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SAL_MONTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SAL_QTY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_REMARK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SAL_MONTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROD_CUST2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxComboBox cbo02_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_BIZNM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_VINCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VIN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_SAL_MONTH;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SAL_MONTH;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PROD_CUST;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PROD_CUST2;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_REMARK;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo02_VINCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_VIN;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_PROD_CUST2;
        private Ax.DEV.Utility.Controls.AxDateEdit dte02_SAL_MONTH;
        private Ax.DEV.Utility.Controls.AxComboBox cbo02_PROD_CUST;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_SAL_MONTH;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_REMARK;
        private Ax.DEV.Utility.Controls.AxNumericEdit nme02_SAL_QTY;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_SAL_QTY2;
        private System.Windows.Forms.GroupBox groupBox_excel;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_EXCEL;
        private Ax.DEV.Utility.Controls.AxButton btn01_EXCEL_DOWN;
        private Ax.DEV.Utility.Controls.AxButton btn01_EXCEL_SELECT;
        private Ax.DEV.Utility.Controls.AxButton btn01_FILE_UPLOAD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_EXCEL;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog ofd01_FILE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
    }
}
