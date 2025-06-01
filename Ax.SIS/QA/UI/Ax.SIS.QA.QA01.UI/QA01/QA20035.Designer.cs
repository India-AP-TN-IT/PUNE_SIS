namespace Ax.SIS.QA.QA01.UI
{
    partial class QA20035
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
            this.txt01_INSPECT_EMPNO_EMPNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.chk01_RENEW_LICENSE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo01_LICENSECD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INSPECT_EMPNO_EMPNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LICENCE_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox_QA20035_MSG1 = new System.Windows.Forms.GroupBox();
            this.dte02_NEXT_RENEWAL_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl02_NEXT_RENEWAL_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte02_CERT_YEAR = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl02_CERT_YEAR = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte02_RENEWAL_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl02_RENEWAL_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn02_ALL_UPDATE = new Ax.DEV.Utility.Controls.AxButton();
            this.dte02_RENEW_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl02_ACC_EXP_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox3_QA20035_MSG2 = new System.Windows.Forms.GroupBox();
            this.grd01_QA20035 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_CERT_YEAR = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CERT_YEAR = new Ax.DEV.Utility.Controls.AxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPECT_EMPNO_EMPNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_EMPNO_EMPNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LICENCE_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.groupBox_QA20035_MSG1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NEXT_RENEWAL_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_CERT_YEAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_RENEWAL_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_ACC_EXP_DATE)).BeginInit();
            this.groupBox3_QA20035_MSG2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20035)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CERT_YEAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CERT_YEAR)).BeginInit();
            this.SuspendLayout();
            // 
            // txt01_INSPECT_EMPNO_EMPNM
            // 
            this.txt01_INSPECT_EMPNO_EMPNM.Location = new System.Drawing.Point(630, 17);
            this.txt01_INSPECT_EMPNO_EMPNM.Name = "txt01_INSPECT_EMPNO_EMPNM";
            this.txt01_INSPECT_EMPNO_EMPNM.Size = new System.Drawing.Size(93, 21);
            this.txt01_INSPECT_EMPNO_EMPNM.TabIndex = 5;
            this.txt01_INSPECT_EMPNO_EMPNM.Tag = null;
            // 
            // chk01_RENEW_LICENSE
            // 
            this.chk01_RENEW_LICENSE.AutoSize = true;
            this.chk01_RENEW_LICENSE.Location = new System.Drawing.Point(940, 38);
            this.chk01_RENEW_LICENSE.Name = "chk01_RENEW_LICENSE";
            this.chk01_RENEW_LICENSE.Size = new System.Drawing.Size(84, 16);
            this.chk01_RENEW_LICENSE.TabIndex = 4;
            this.chk01_RENEW_LICENSE.Text = "갱신대상자";
            this.chk01_RENEW_LICENSE.UseVisualStyleBackColor = true;
            this.chk01_RENEW_LICENSE.Visible = false;
            // 
            // cbo01_LICENSECD
            // 
            this.cbo01_LICENSECD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_LICENSECD.FormattingEnabled = true;
            this.cbo01_LICENSECD.Location = new System.Drawing.Point(340, 17);
            this.cbo01_LICENSECD.Name = "cbo01_LICENSECD";
            this.cbo01_LICENSECD.Size = new System.Drawing.Size(154, 20);
            this.cbo01_LICENSECD.TabIndex = 2;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(113, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(120, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_INSPECT_EMPNO_EMPNM
            // 
            this.lbl01_INSPECT_EMPNO_EMPNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPECT_EMPNO_EMPNM.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPECT_EMPNO_EMPNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INSPECT_EMPNO_EMPNM.Location = new System.Drawing.Point(500, 17);
            this.lbl01_INSPECT_EMPNO_EMPNM.Name = "lbl01_INSPECT_EMPNO_EMPNM";
            this.lbl01_INSPECT_EMPNO_EMPNM.Size = new System.Drawing.Size(126, 21);
            this.lbl01_INSPECT_EMPNO_EMPNM.TabIndex = 2;
            this.lbl01_INSPECT_EMPNO_EMPNM.Tag = null;
            this.lbl01_INSPECT_EMPNO_EMPNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSPECT_EMPNO_EMPNM.Value = "검사원 사번/명";
            // 
            // lbl01_LICENCE_NM
            // 
            this.lbl01_LICENCE_NM.AutoFontSizeMaxValue = 9F;
            this.lbl01_LICENCE_NM.AutoFontSizeMinValue = 9F;
            this.lbl01_LICENCE_NM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LICENCE_NM.Location = new System.Drawing.Point(237, 17);
            this.lbl01_LICENCE_NM.Name = "lbl01_LICENCE_NM";
            this.lbl01_LICENCE_NM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LICENCE_NM.TabIndex = 1;
            this.lbl01_LICENCE_NM.Tag = null;
            this.lbl01_LICENCE_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LICENCE_NM.Value = "자격증명";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(10, 17);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장명";
            // 
            // groupBox_QA20035_MSG1
            // 
            this.groupBox_QA20035_MSG1.Controls.Add(this.dte02_NEXT_RENEWAL_DATE);
            this.groupBox_QA20035_MSG1.Controls.Add(this.lbl02_NEXT_RENEWAL_DATE);
            this.groupBox_QA20035_MSG1.Controls.Add(this.dte02_CERT_YEAR);
            this.groupBox_QA20035_MSG1.Controls.Add(this.lbl02_CERT_YEAR);
            this.groupBox_QA20035_MSG1.Controls.Add(this.dte02_RENEWAL_DATE);
            this.groupBox_QA20035_MSG1.Controls.Add(this.lbl02_RENEWAL_DATE);
            this.groupBox_QA20035_MSG1.Controls.Add(this.btn02_ALL_UPDATE);
            this.groupBox_QA20035_MSG1.Controls.Add(this.dte02_RENEW_DATE);
            this.groupBox_QA20035_MSG1.Controls.Add(this.lbl02_ACC_EXP_DATE);
            this.groupBox_QA20035_MSG1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_QA20035_MSG1.Location = new System.Drawing.Point(0, 87);
            this.groupBox_QA20035_MSG1.Name = "groupBox_QA20035_MSG1";
            this.groupBox_QA20035_MSG1.Size = new System.Drawing.Size(1024, 48);
            this.groupBox_QA20035_MSG1.TabIndex = 3;
            this.groupBox_QA20035_MSG1.TabStop = false;
            this.groupBox_QA20035_MSG1.Text = "검사원 자격 입력 정보";
            // 
            // dte02_NEXT_RENEWAL_DATE
            // 
            this.dte02_NEXT_RENEWAL_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte02_NEXT_RENEWAL_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte02_NEXT_RENEWAL_DATE.Location = new System.Drawing.Point(803, 16);
            this.dte02_NEXT_RENEWAL_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte02_NEXT_RENEWAL_DATE.Name = "dte02_NEXT_RENEWAL_DATE";
            this.dte02_NEXT_RENEWAL_DATE.OriginalFormat = "";
            this.dte02_NEXT_RENEWAL_DATE.Size = new System.Drawing.Size(110, 21);
            this.dte02_NEXT_RENEWAL_DATE.TabIndex = 36;
            // 
            // lbl02_NEXT_RENEWAL_DATE
            // 
            this.lbl02_NEXT_RENEWAL_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_NEXT_RENEWAL_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_NEXT_RENEWAL_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_NEXT_RENEWAL_DATE.Location = new System.Drawing.Point(698, 16);
            this.lbl02_NEXT_RENEWAL_DATE.Name = "lbl02_NEXT_RENEWAL_DATE";
            this.lbl02_NEXT_RENEWAL_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_NEXT_RENEWAL_DATE.TabIndex = 35;
            this.lbl02_NEXT_RENEWAL_DATE.Tag = null;
            this.lbl02_NEXT_RENEWAL_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_NEXT_RENEWAL_DATE.Value = "차기 갱신일자";
            // 
            // dte02_CERT_YEAR
            // 
            this.dte02_CERT_YEAR.CustomFormat = "yyyy";
            this.dte02_CERT_YEAR.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte02_CERT_YEAR.Location = new System.Drawing.Point(393, 16);
            this.dte02_CERT_YEAR.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte02_CERT_YEAR.Name = "dte02_CERT_YEAR";
            this.dte02_CERT_YEAR.OriginalFormat = "";
            this.dte02_CERT_YEAR.Size = new System.Drawing.Size(80, 21);
            this.dte02_CERT_YEAR.TabIndex = 34;
            // 
            // lbl02_CERT_YEAR
            // 
            this.lbl02_CERT_YEAR.AutoFontSizeMaxValue = 9F;
            this.lbl02_CERT_YEAR.AutoFontSizeMinValue = 9F;
            this.lbl02_CERT_YEAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_CERT_YEAR.Location = new System.Drawing.Point(290, 16);
            this.lbl02_CERT_YEAR.Name = "lbl02_CERT_YEAR";
            this.lbl02_CERT_YEAR.Size = new System.Drawing.Size(100, 21);
            this.lbl02_CERT_YEAR.TabIndex = 33;
            this.lbl02_CERT_YEAR.Tag = null;
            this.lbl02_CERT_YEAR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_CERT_YEAR.Value = "승인대상년도";
            // 
            // dte02_RENEWAL_DATE
            // 
            this.dte02_RENEWAL_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte02_RENEWAL_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte02_RENEWAL_DATE.Location = new System.Drawing.Point(173, 16);
            this.dte02_RENEWAL_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte02_RENEWAL_DATE.Name = "dte02_RENEWAL_DATE";
            this.dte02_RENEWAL_DATE.OriginalFormat = "";
            this.dte02_RENEWAL_DATE.Size = new System.Drawing.Size(110, 21);
            this.dte02_RENEWAL_DATE.TabIndex = 11;
            // 
            // lbl02_RENEWAL_DATE
            // 
            this.lbl02_RENEWAL_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_RENEWAL_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_RENEWAL_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_RENEWAL_DATE.Location = new System.Drawing.Point(10, 16);
            this.lbl02_RENEWAL_DATE.Name = "lbl02_RENEWAL_DATE";
            this.lbl02_RENEWAL_DATE.Size = new System.Drawing.Size(159, 21);
            this.lbl02_RENEWAL_DATE.TabIndex = 10;
            this.lbl02_RENEWAL_DATE.Tag = null;
            this.lbl02_RENEWAL_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_RENEWAL_DATE.Value = "승인/갱신일자";
            // 
            // btn02_ALL_UPDATE
            // 
            this.btn02_ALL_UPDATE.Location = new System.Drawing.Point(921, 16);
            this.btn02_ALL_UPDATE.Name = "btn02_ALL_UPDATE";
            this.btn02_ALL_UPDATE.Size = new System.Drawing.Size(97, 23);
            this.btn02_ALL_UPDATE.TabIndex = 2;
            this.btn02_ALL_UPDATE.Text = "일괄변경";
            this.btn02_ALL_UPDATE.UseVisualStyleBackColor = true;
            this.btn02_ALL_UPDATE.Click += new System.EventHandler(this.btn02_ALL_CHANGE_Click);
            // 
            // dte02_RENEW_DATE
            // 
            this.dte02_RENEW_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte02_RENEW_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte02_RENEW_DATE.Location = new System.Drawing.Point(582, 16);
            this.dte02_RENEW_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte02_RENEW_DATE.Name = "dte02_RENEW_DATE";
            this.dte02_RENEW_DATE.OriginalFormat = "";
            this.dte02_RENEW_DATE.Size = new System.Drawing.Size(110, 21);
            this.dte02_RENEW_DATE.TabIndex = 1;
            // 
            // lbl02_ACC_EXP_DATE
            // 
            this.lbl02_ACC_EXP_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_ACC_EXP_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_ACC_EXP_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_ACC_EXP_DATE.Location = new System.Drawing.Point(479, 16);
            this.lbl02_ACC_EXP_DATE.Name = "lbl02_ACC_EXP_DATE";
            this.lbl02_ACC_EXP_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_ACC_EXP_DATE.TabIndex = 0;
            this.lbl02_ACC_EXP_DATE.Tag = null;
            this.lbl02_ACC_EXP_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_ACC_EXP_DATE.Value = "승인 만료일자";
            // 
            // groupBox3_QA20035_MSG2
            // 
            this.groupBox3_QA20035_MSG2.Controls.Add(this.grd01_QA20035);
            this.groupBox3_QA20035_MSG2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3_QA20035_MSG2.Location = new System.Drawing.Point(0, 135);
            this.groupBox3_QA20035_MSG2.Name = "groupBox3_QA20035_MSG2";
            this.groupBox3_QA20035_MSG2.Size = new System.Drawing.Size(1024, 633);
            this.groupBox3_QA20035_MSG2.TabIndex = 4;
            this.groupBox3_QA20035_MSG2.TabStop = false;
            this.groupBox3_QA20035_MSG2.Text = "검사원 자격 목록 (경력은 인증일 또는 갱신일 변경시 자동 계산 됩니다.)";
            // 
            // grd01_QA20035
            // 
            this.grd01_QA20035.AllowHeaderMerging = false;
            this.grd01_QA20035.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA20035.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA20035.EnabledActionFlag = true;
            this.grd01_QA20035.LastRowAdd = false;
            this.grd01_QA20035.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA20035.Name = "grd01_QA20035";
            this.grd01_QA20035.OriginalFormat = null;
            this.grd01_QA20035.PopMenuVisible = true;
            this.grd01_QA20035.Rows.DefaultSize = 18;
            this.grd01_QA20035.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.grd01_QA20035.Size = new System.Drawing.Size(1018, 613);
            this.grd01_QA20035.TabIndex = 2;
            this.grd01_QA20035.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_PLANT_DIV);
            this.groupBox1.Controls.Add(this.lbl01_PLANT_DIV);
            this.groupBox1.Controls.Add(this.txt01_CERT_YEAR);
            this.groupBox1.Controls.Add(this.lbl01_CERT_YEAR);
            this.groupBox1.Controls.Add(this.chk01_RENEW_LICENSE);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Controls.Add(this.txt01_INSPECT_EMPNO_EMPNM);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_INSPECT_EMPNO_EMPNM);
            this.groupBox1.Controls.Add(this.lbl01_LICENCE_NM);
            this.groupBox1.Controls.Add(this.cbo01_LICENSECD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 53);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(1021, 17);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(89, 20);
            this.cbo01_PLANT_DIV.TabIndex = 41;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(916, 17);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(102, 21);
            this.lbl01_PLANT_DIV.TabIndex = 40;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // txt01_CERT_YEAR
            // 
            this.txt01_CERT_YEAR.Location = new System.Drawing.Point(823, 17);
            this.txt01_CERT_YEAR.Name = "txt01_CERT_YEAR";
            this.txt01_CERT_YEAR.Size = new System.Drawing.Size(87, 21);
            this.txt01_CERT_YEAR.TabIndex = 39;
            this.txt01_CERT_YEAR.Tag = null;
            // 
            // lbl01_CERT_YEAR
            // 
            this.lbl01_CERT_YEAR.AutoFontSizeMaxValue = 9F;
            this.lbl01_CERT_YEAR.AutoFontSizeMinValue = 9F;
            this.lbl01_CERT_YEAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CERT_YEAR.Location = new System.Drawing.Point(729, 17);
            this.lbl01_CERT_YEAR.Name = "lbl01_CERT_YEAR";
            this.lbl01_CERT_YEAR.Size = new System.Drawing.Size(90, 21);
            this.lbl01_CERT_YEAR.TabIndex = 38;
            this.lbl01_CERT_YEAR.Tag = null;
            this.lbl01_CERT_YEAR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CERT_YEAR.Value = "승인대상년도";
            // 
            // QA20035
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3_QA20035_MSG2);
            this.Controls.Add(this.groupBox_QA20035_MSG1);
            this.Controls.Add(this.groupBox1);
            this.Name = "QA20035";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox_QA20035_MSG1, 0);
            this.Controls.SetChildIndex(this.groupBox3_QA20035_MSG2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPECT_EMPNO_EMPNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_EMPNO_EMPNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LICENCE_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.groupBox_QA20035_MSG1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NEXT_RENEWAL_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_CERT_YEAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_RENEWAL_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_ACC_EXP_DATE)).EndInit();
            this.groupBox3_QA20035_MSG2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20035)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CERT_YEAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CERT_YEAR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxComboBox cbo01_LICENSECD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPECT_EMPNO_EMPNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LICENCE_NM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private System.Windows.Forms.GroupBox groupBox_QA20035_MSG1;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_ACC_EXP_DATE;
        private System.Windows.Forms.GroupBox groupBox3_QA20035_MSG2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA20035;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_RENEW_LICENSE;
        private Ax.DEV.Utility.Controls.AxButton btn02_ALL_UPDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dte02_RENEW_DATE;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_INSPECT_EMPNO_EMPNM;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_CERT_YEAR;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CERT_YEAR;
        private Ax.DEV.Utility.Controls.AxDateEdit dte02_RENEWAL_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_RENEWAL_DATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dte02_CERT_YEAR;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_CERT_YEAR;
        private Ax.DEV.Utility.Controls.AxDateEdit dte02_NEXT_RENEWAL_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_NEXT_RENEWAL_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
    }
}
