namespace Ax.SIS.QA.QA00.UI
{
    partial class QA20023
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
            this.grd01_QA20023 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.txt01_DEFPOSCD_DEFPOSNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_DEFPOSCD_DEFPOSNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.chk02_DTRIM_USE_YN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk02_INJECTION_USE_YN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk02_USEYN2 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.nme02_SORT_SEQ = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.txt02_DEFPOSNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_DEFPOSCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_SORT_SEQ = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_DEFPOSNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_DEFPOSCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_DTRIM_USE_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_DTRIM_USE_YN = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_INJECTION_USE_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INJECTION_USE_YN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_USE_YN3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_USE_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20023)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DEFPOSCD_DEFPOSNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEFPOSCD_DEFPOSNM)).BeginInit();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_SORT_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DEFPOSNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DEFPOSCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SORT_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DEFPOSNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DEFPOSCD)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DTRIM_USE_YN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INJECTION_USE_YN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USE_YN3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA20023);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 622);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "불량부위별 코드 목록";
            // 
            // grd01_QA20023
            // 
            this.grd01_QA20023.AllowHeaderMerging = false;
            this.grd01_QA20023.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA20023.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA20023.EnabledActionFlag = true;
            this.grd01_QA20023.LastRowAdd = false;
            this.grd01_QA20023.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA20023.Name = "grd01_QA20023";
            this.grd01_QA20023.OriginalFormat = null;
            this.grd01_QA20023.PopMenuVisible = true;
            this.grd01_QA20023.Rows.DefaultSize = 18;
            this.grd01_QA20023.Size = new System.Drawing.Size(1018, 602);
            this.grd01_QA20023.TabIndex = 0;
            this.grd01_QA20023.UseCustomHighlight = true;
            this.grd01_QA20023.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA20023_MouseDoubleClick);
            // 
            // txt01_DEFPOSCD_DEFPOSNM
            // 
            this.txt01_DEFPOSCD_DEFPOSNM.Location = new System.Drawing.Point(181, 17);
            this.txt01_DEFPOSCD_DEFPOSNM.Name = "txt01_DEFPOSCD_DEFPOSNM";
            this.txt01_DEFPOSCD_DEFPOSNM.Size = new System.Drawing.Size(152, 21);
            this.txt01_DEFPOSCD_DEFPOSNM.TabIndex = 2;
            this.txt01_DEFPOSCD_DEFPOSNM.Tag = null;
            // 
            // lbl01_DEFPOSCD_DEFPOSNM
            // 
            this.lbl01_DEFPOSCD_DEFPOSNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_DEFPOSCD_DEFPOSNM.AutoFontSizeMinValue = 9F;
            this.lbl01_DEFPOSCD_DEFPOSNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DEFPOSCD_DEFPOSNM.Location = new System.Drawing.Point(8, 17);
            this.lbl01_DEFPOSCD_DEFPOSNM.Name = "lbl01_DEFPOSCD_DEFPOSNM";
            this.lbl01_DEFPOSCD_DEFPOSNM.Size = new System.Drawing.Size(170, 21);
            this.lbl01_DEFPOSCD_DEFPOSNM.TabIndex = 2;
            this.lbl01_DEFPOSCD_DEFPOSNM.Tag = null;
            this.lbl01_DEFPOSCD_DEFPOSNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DEFPOSCD_DEFPOSNM.Value = "부위코드 / 코드명";
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.chk02_DTRIM_USE_YN);
            this.groupBox_main.Controls.Add(this.chk02_INJECTION_USE_YN);
            this.groupBox_main.Controls.Add(this.chk02_USEYN2);
            this.groupBox_main.Controls.Add(this.nme02_SORT_SEQ);
            this.groupBox_main.Controls.Add(this.txt02_DEFPOSNM);
            this.groupBox_main.Controls.Add(this.txt02_DEFPOSCD);
            this.groupBox_main.Controls.Add(this.lbl02_SORT_SEQ);
            this.groupBox_main.Controls.Add(this.lbl02_DEFPOSNM);
            this.groupBox_main.Controls.Add(this.lbl02_DEFPOSCD);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_main.Location = new System.Drawing.Point(0, 703);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(1024, 65);
            this.groupBox_main.TabIndex = 11;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "불량부위별 코드 정보";
            // 
            // chk02_DTRIM_USE_YN
            // 
            this.chk02_DTRIM_USE_YN.AutoSize = true;
            this.chk02_DTRIM_USE_YN.Location = new System.Drawing.Point(719, 41);
            this.chk02_DTRIM_USE_YN.Name = "chk02_DTRIM_USE_YN";
            this.chk02_DTRIM_USE_YN.Size = new System.Drawing.Size(124, 16);
            this.chk02_DTRIM_USE_YN.TabIndex = 22;
            this.chk02_DTRIM_USE_YN.Text = "조립공정 적용여부";
            this.chk02_DTRIM_USE_YN.UseVisualStyleBackColor = true;
            // 
            // chk02_INJECTION_USE_YN
            // 
            this.chk02_INJECTION_USE_YN.AutoSize = true;
            this.chk02_INJECTION_USE_YN.Location = new System.Drawing.Point(793, 19);
            this.chk02_INJECTION_USE_YN.Name = "chk02_INJECTION_USE_YN";
            this.chk02_INJECTION_USE_YN.Size = new System.Drawing.Size(124, 16);
            this.chk02_INJECTION_USE_YN.TabIndex = 21;
            this.chk02_INJECTION_USE_YN.Text = "사출불량 적용여부";
            this.chk02_INJECTION_USE_YN.UseVisualStyleBackColor = true;
            // 
            // chk02_USEYN2
            // 
            this.chk02_USEYN2.AutoSize = true;
            this.chk02_USEYN2.Location = new System.Drawing.Point(719, 19);
            this.chk02_USEYN2.Name = "chk02_USEYN2";
            this.chk02_USEYN2.Size = new System.Drawing.Size(48, 16);
            this.chk02_USEYN2.TabIndex = 6;
            this.chk02_USEYN2.Text = "사용";
            this.chk02_USEYN2.UseVisualStyleBackColor = true;
            // 
            // nme02_SORT_SEQ
            // 
            this.nme02_SORT_SEQ.DisplayFormat.CustomFormat = "###,###,###,###,###,##0";
            this.nme02_SORT_SEQ.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_SORT_SEQ.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_SORT_SEQ.EditFormat.CustomFormat = "###,###,###,###,###,##0";
            this.nme02_SORT_SEQ.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_SORT_SEQ.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_SORT_SEQ.EmptyAsNull = true;
            this.nme02_SORT_SEQ.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_SORT_SEQ.Location = new System.Drawing.Point(613, 17);
            this.nme02_SORT_SEQ.Name = "nme02_SORT_SEQ";
            this.nme02_SORT_SEQ.NullText = "0";
            this.nme02_SORT_SEQ.Size = new System.Drawing.Size(100, 21);
            this.nme02_SORT_SEQ.TabIndex = 5;
            this.nme02_SORT_SEQ.Tag = null;
            this.nme02_SORT_SEQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme02_SORT_SEQ.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // txt02_DEFPOSNM
            // 
            this.txt02_DEFPOSNM.Location = new System.Drawing.Point(320, 17);
            this.txt02_DEFPOSNM.Name = "txt02_DEFPOSNM";
            this.txt02_DEFPOSNM.Size = new System.Drawing.Size(184, 21);
            this.txt02_DEFPOSNM.TabIndex = 4;
            this.txt02_DEFPOSNM.Tag = null;
            // 
            // txt02_DEFPOSCD
            // 
            this.txt02_DEFPOSCD.Location = new System.Drawing.Point(111, 17);
            this.txt02_DEFPOSCD.Name = "txt02_DEFPOSCD";
            this.txt02_DEFPOSCD.Size = new System.Drawing.Size(100, 21);
            this.txt02_DEFPOSCD.TabIndex = 3;
            this.txt02_DEFPOSCD.Tag = null;
            // 
            // lbl02_SORT_SEQ
            // 
            this.lbl02_SORT_SEQ.AutoFontSizeMaxValue = 9F;
            this.lbl02_SORT_SEQ.AutoFontSizeMinValue = 9F;
            this.lbl02_SORT_SEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_SORT_SEQ.Location = new System.Drawing.Point(510, 17);
            this.lbl02_SORT_SEQ.Name = "lbl02_SORT_SEQ";
            this.lbl02_SORT_SEQ.Size = new System.Drawing.Size(100, 21);
            this.lbl02_SORT_SEQ.TabIndex = 14;
            this.lbl02_SORT_SEQ.Tag = null;
            this.lbl02_SORT_SEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_SORT_SEQ.Value = "정렬순서";
            // 
            // lbl02_DEFPOSNM
            // 
            this.lbl02_DEFPOSNM.AutoFontSizeMaxValue = 9F;
            this.lbl02_DEFPOSNM.AutoFontSizeMinValue = 9F;
            this.lbl02_DEFPOSNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_DEFPOSNM.Location = new System.Drawing.Point(217, 17);
            this.lbl02_DEFPOSNM.Name = "lbl02_DEFPOSNM";
            this.lbl02_DEFPOSNM.Size = new System.Drawing.Size(100, 21);
            this.lbl02_DEFPOSNM.TabIndex = 13;
            this.lbl02_DEFPOSNM.Tag = null;
            this.lbl02_DEFPOSNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_DEFPOSNM.Value = "부위명";
            // 
            // lbl02_DEFPOSCD
            // 
            this.lbl02_DEFPOSCD.AutoFontSizeMaxValue = 9F;
            this.lbl02_DEFPOSCD.AutoFontSizeMinValue = 9F;
            this.lbl02_DEFPOSCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_DEFPOSCD.Location = new System.Drawing.Point(8, 17);
            this.lbl02_DEFPOSCD.Name = "lbl02_DEFPOSCD";
            this.lbl02_DEFPOSCD.Size = new System.Drawing.Size(100, 21);
            this.lbl02_DEFPOSCD.TabIndex = 12;
            this.lbl02_DEFPOSCD.Tag = null;
            this.lbl02_DEFPOSCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_DEFPOSCD.Value = "부위코드";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_DTRIM_USE_YN);
            this.groupBox1.Controls.Add(this.lbl01_DTRIM_USE_YN);
            this.groupBox1.Controls.Add(this.cbo01_INJECTION_USE_YN);
            this.groupBox1.Controls.Add(this.lbl01_INJECTION_USE_YN);
            this.groupBox1.Controls.Add(this.lbl01_USE_YN3);
            this.groupBox1.Controls.Add(this.cbo01_USE_YN);
            this.groupBox1.Controls.Add(this.txt01_DEFPOSCD_DEFPOSNM);
            this.groupBox1.Controls.Add(this.lbl01_DEFPOSCD_DEFPOSNM);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 47);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_DTRIM_USE_YN
            // 
            this.cbo01_DTRIM_USE_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DTRIM_USE_YN.FormattingEnabled = true;
            this.cbo01_DTRIM_USE_YN.Location = new System.Drawing.Point(994, 17);
            this.cbo01_DTRIM_USE_YN.Name = "cbo01_DTRIM_USE_YN";
            this.cbo01_DTRIM_USE_YN.Size = new System.Drawing.Size(70, 20);
            this.cbo01_DTRIM_USE_YN.TabIndex = 19;
            // 
            // lbl01_DTRIM_USE_YN
            // 
            this.lbl01_DTRIM_USE_YN.AutoFontSizeMaxValue = 9F;
            this.lbl01_DTRIM_USE_YN.AutoFontSizeMinValue = 9F;
            this.lbl01_DTRIM_USE_YN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DTRIM_USE_YN.Location = new System.Drawing.Point(785, 17);
            this.lbl01_DTRIM_USE_YN.Name = "lbl01_DTRIM_USE_YN";
            this.lbl01_DTRIM_USE_YN.Size = new System.Drawing.Size(205, 21);
            this.lbl01_DTRIM_USE_YN.TabIndex = 18;
            this.lbl01_DTRIM_USE_YN.Tag = null;
            this.lbl01_DTRIM_USE_YN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DTRIM_USE_YN.Value = "조립공정 적용여부";
            // 
            // cbo01_INJECTION_USE_YN
            // 
            this.cbo01_INJECTION_USE_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INJECTION_USE_YN.FormattingEnabled = true;
            this.cbo01_INJECTION_USE_YN.Location = new System.Drawing.Point(712, 17);
            this.cbo01_INJECTION_USE_YN.Name = "cbo01_INJECTION_USE_YN";
            this.cbo01_INJECTION_USE_YN.Size = new System.Drawing.Size(70, 20);
            this.cbo01_INJECTION_USE_YN.TabIndex = 17;
            // 
            // lbl01_INJECTION_USE_YN
            // 
            this.lbl01_INJECTION_USE_YN.AutoFontSizeMaxValue = 9F;
            this.lbl01_INJECTION_USE_YN.AutoFontSizeMinValue = 9F;
            this.lbl01_INJECTION_USE_YN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INJECTION_USE_YN.Location = new System.Drawing.Point(489, 17);
            this.lbl01_INJECTION_USE_YN.Name = "lbl01_INJECTION_USE_YN";
            this.lbl01_INJECTION_USE_YN.Size = new System.Drawing.Size(219, 21);
            this.lbl01_INJECTION_USE_YN.TabIndex = 16;
            this.lbl01_INJECTION_USE_YN.Tag = null;
            this.lbl01_INJECTION_USE_YN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INJECTION_USE_YN.Value = "사출불량 적용여부";
            // 
            // lbl01_USE_YN3
            // 
            this.lbl01_USE_YN3.AutoFontSizeMaxValue = 9F;
            this.lbl01_USE_YN3.AutoFontSizeMinValue = 9F;
            this.lbl01_USE_YN3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_USE_YN3.Location = new System.Drawing.Point(335, 17);
            this.lbl01_USE_YN3.Name = "lbl01_USE_YN3";
            this.lbl01_USE_YN3.Size = new System.Drawing.Size(77, 21);
            this.lbl01_USE_YN3.TabIndex = 14;
            this.lbl01_USE_YN3.Tag = null;
            this.lbl01_USE_YN3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_USE_YN3.Value = "사용유무";
            // 
            // cbo01_USE_YN
            // 
            this.cbo01_USE_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_USE_YN.FormattingEnabled = true;
            this.cbo01_USE_YN.Location = new System.Drawing.Point(416, 17);
            this.cbo01_USE_YN.Name = "cbo01_USE_YN";
            this.cbo01_USE_YN.Size = new System.Drawing.Size(70, 20);
            this.cbo01_USE_YN.TabIndex = 13;
            // 
            // QA20023
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_main);
            this.Name = "QA20023";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox_main, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20023)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DEFPOSCD_DEFPOSNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEFPOSCD_DEFPOSNM)).EndInit();
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_SORT_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DEFPOSNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_DEFPOSCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SORT_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DEFPOSNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DEFPOSCD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DTRIM_USE_YN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INJECTION_USE_YN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USE_YN3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA20023;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_DEFPOSCD_DEFPOSNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DEFPOSCD_DEFPOSNM;
        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxCheckBox chk02_USEYN2;
        private Ax.DEV.Utility.Controls.AxNumericEdit nme02_SORT_SEQ;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_DEFPOSNM;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_DEFPOSCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_SORT_SEQ;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_DEFPOSNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_DEFPOSCD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_USE_YN3;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_USE_YN;
        private Ax.DEV.Utility.Controls.AxCheckBox chk02_DTRIM_USE_YN;
        private Ax.DEV.Utility.Controls.AxCheckBox chk02_INJECTION_USE_YN;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_DTRIM_USE_YN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DTRIM_USE_YN;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_INJECTION_USE_YN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INJECTION_USE_YN;
    }
}
