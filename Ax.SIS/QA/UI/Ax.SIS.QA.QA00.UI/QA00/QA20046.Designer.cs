namespace Ax.SIS.QA.QA00.UI
{
    partial class QA20046
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
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.txt02_YYYY = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_JOB_CODE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.nme02_GEN_RATE = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.nme02_PAY_AMT = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.nme02_EXP_RATE = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.cbo02_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_PAY_AMNT = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_GEN_RATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_EXP_RATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_JOB_CODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_YYYY = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_YYYY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_JOB_CODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_GEN_RATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_PAY_AMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_EXP_RATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PAY_AMNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_GEN_RATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_EXP_RATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_JOB_CODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_YYYY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(120, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(157, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(17, 17);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.txt02_YYYY);
            this.groupBox_main.Controls.Add(this.txt02_JOB_CODE);
            this.groupBox_main.Controls.Add(this.nme02_GEN_RATE);
            this.groupBox_main.Controls.Add(this.nme02_PAY_AMT);
            this.groupBox_main.Controls.Add(this.nme02_EXP_RATE);
            this.groupBox_main.Controls.Add(this.cbo02_BIZCD);
            this.groupBox_main.Controls.Add(this.lbl02_PAY_AMNT);
            this.groupBox_main.Controls.Add(this.lbl02_GEN_RATE);
            this.groupBox_main.Controls.Add(this.lbl02_EXP_RATE);
            this.groupBox_main.Controls.Add(this.lbl02_JOB_CODE);
            this.groupBox_main.Controls.Add(this.lbl02_YYYY);
            this.groupBox_main.Controls.Add(this.lbl02_BIZNM2);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_main.Location = new System.Drawing.Point(0, 670);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(1024, 98);
            this.groupBox_main.TabIndex = 2;
            this.groupBox_main.TabStop = false;
            // 
            // txt02_YYYY
            // 
            this.txt02_YYYY.Location = new System.Drawing.Point(136, 43);
            this.txt02_YYYY.Name = "txt02_YYYY";
            this.txt02_YYYY.Size = new System.Drawing.Size(141, 21);
            this.txt02_YYYY.TabIndex = 14;
            this.txt02_YYYY.Tag = null;
            // 
            // txt02_JOB_CODE
            // 
            this.txt02_JOB_CODE.Location = new System.Drawing.Point(136, 68);
            this.txt02_JOB_CODE.Name = "txt02_JOB_CODE";
            this.txt02_JOB_CODE.Size = new System.Drawing.Size(141, 21);
            this.txt02_JOB_CODE.TabIndex = 14;
            this.txt02_JOB_CODE.Tag = null;
            // 
            // nme02_GEN_RATE
            // 
            this.nme02_GEN_RATE.DisplayFormat.CustomFormat = "###,###,###,###,###,##0.00";
            this.nme02_GEN_RATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_GEN_RATE.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_GEN_RATE.EditFormat.CustomFormat = "###,###,###,###,###,##0.00";
            this.nme02_GEN_RATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_GEN_RATE.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_GEN_RATE.EmptyAsNull = true;
            this.nme02_GEN_RATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_GEN_RATE.Location = new System.Drawing.Point(406, 67);
            this.nme02_GEN_RATE.Name = "nme02_GEN_RATE";
            this.nme02_GEN_RATE.NullText = "0";
            this.nme02_GEN_RATE.Size = new System.Drawing.Size(141, 21);
            this.nme02_GEN_RATE.TabIndex = 12;
            this.nme02_GEN_RATE.Tag = null;
            this.nme02_GEN_RATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme02_GEN_RATE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // nme02_PAY_AMT
            // 
            this.nme02_PAY_AMT.DisplayFormat.CustomFormat = "###,###,###,###,###,##0";
            this.nme02_PAY_AMT.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_PAY_AMT.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_PAY_AMT.EditFormat.CustomFormat = "###,###,###,###,###,##0";
            this.nme02_PAY_AMT.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_PAY_AMT.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_PAY_AMT.EmptyAsNull = true;
            this.nme02_PAY_AMT.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_PAY_AMT.Location = new System.Drawing.Point(406, 19);
            this.nme02_PAY_AMT.Name = "nme02_PAY_AMT";
            this.nme02_PAY_AMT.NullText = "0";
            this.nme02_PAY_AMT.Size = new System.Drawing.Size(141, 21);
            this.nme02_PAY_AMT.TabIndex = 11;
            this.nme02_PAY_AMT.Tag = null;
            this.nme02_PAY_AMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme02_PAY_AMT.TrimStart = true;
            this.nme02_PAY_AMT.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // nme02_EXP_RATE
            // 
            this.nme02_EXP_RATE.DisplayFormat.CustomFormat = "###,###,###,###,###,##0.00";
            this.nme02_EXP_RATE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_EXP_RATE.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_EXP_RATE.EditFormat.CustomFormat = "###,###,###,###,###,##0.00";
            this.nme02_EXP_RATE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_EXP_RATE.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_EXP_RATE.EmptyAsNull = true;
            this.nme02_EXP_RATE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_EXP_RATE.Location = new System.Drawing.Point(406, 43);
            this.nme02_EXP_RATE.Name = "nme02_EXP_RATE";
            this.nme02_EXP_RATE.NullText = "0";
            this.nme02_EXP_RATE.Size = new System.Drawing.Size(141, 21);
            this.nme02_EXP_RATE.TabIndex = 11;
            this.nme02_EXP_RATE.Tag = null;
            this.nme02_EXP_RATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme02_EXP_RATE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // cbo02_BIZCD
            // 
            this.cbo02_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_BIZCD.FormattingEnabled = true;
            this.cbo02_BIZCD.Location = new System.Drawing.Point(136, 20);
            this.cbo02_BIZCD.Name = "cbo02_BIZCD";
            this.cbo02_BIZCD.Size = new System.Drawing.Size(141, 20);
            this.cbo02_BIZCD.TabIndex = 5;
            // 
            // lbl02_PAY_AMNT
            // 
            this.lbl02_PAY_AMNT.AutoFontSizeMaxValue = 9F;
            this.lbl02_PAY_AMNT.AutoFontSizeMinValue = 9F;
            this.lbl02_PAY_AMNT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_PAY_AMNT.Location = new System.Drawing.Point(283, 19);
            this.lbl02_PAY_AMNT.Name = "lbl02_PAY_AMNT";
            this.lbl02_PAY_AMNT.Size = new System.Drawing.Size(120, 21);
            this.lbl02_PAY_AMNT.TabIndex = 12;
            this.lbl02_PAY_AMNT.Tag = null;
            this.lbl02_PAY_AMNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_PAY_AMNT.Value = "임율비용";
            // 
            // lbl02_GEN_RATE
            // 
            this.lbl02_GEN_RATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_GEN_RATE.AutoFontSizeMinValue = 9F;
            this.lbl02_GEN_RATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_GEN_RATE.Location = new System.Drawing.Point(283, 67);
            this.lbl02_GEN_RATE.Name = "lbl02_GEN_RATE";
            this.lbl02_GEN_RATE.Size = new System.Drawing.Size(120, 21);
            this.lbl02_GEN_RATE.TabIndex = 13;
            this.lbl02_GEN_RATE.Tag = null;
            this.lbl02_GEN_RATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_GEN_RATE.Value = "일반관리비율";
            // 
            // lbl02_EXP_RATE
            // 
            this.lbl02_EXP_RATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_EXP_RATE.AutoFontSizeMinValue = 9F;
            this.lbl02_EXP_RATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_EXP_RATE.Location = new System.Drawing.Point(283, 43);
            this.lbl02_EXP_RATE.Name = "lbl02_EXP_RATE";
            this.lbl02_EXP_RATE.Size = new System.Drawing.Size(120, 21);
            this.lbl02_EXP_RATE.TabIndex = 12;
            this.lbl02_EXP_RATE.Tag = null;
            this.lbl02_EXP_RATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_EXP_RATE.Value = "간접경비율";
            // 
            // lbl02_JOB_CODE
            // 
            this.lbl02_JOB_CODE.AutoFontSizeMaxValue = 9F;
            this.lbl02_JOB_CODE.AutoFontSizeMinValue = 9F;
            this.lbl02_JOB_CODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_JOB_CODE.Location = new System.Drawing.Point(13, 68);
            this.lbl02_JOB_CODE.Name = "lbl02_JOB_CODE";
            this.lbl02_JOB_CODE.Size = new System.Drawing.Size(120, 21);
            this.lbl02_JOB_CODE.TabIndex = 7;
            this.lbl02_JOB_CODE.Tag = null;
            this.lbl02_JOB_CODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_JOB_CODE.Value = "업종코드";
            // 
            // lbl02_YYYY
            // 
            this.lbl02_YYYY.AutoFontSizeMaxValue = 9F;
            this.lbl02_YYYY.AutoFontSizeMinValue = 9F;
            this.lbl02_YYYY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_YYYY.Location = new System.Drawing.Point(13, 44);
            this.lbl02_YYYY.Name = "lbl02_YYYY";
            this.lbl02_YYYY.Size = new System.Drawing.Size(120, 21);
            this.lbl02_YYYY.TabIndex = 6;
            this.lbl02_YYYY.Tag = null;
            this.lbl02_YYYY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_YYYY.Value = "년도";
            // 
            // lbl02_BIZNM2
            // 
            this.lbl02_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl02_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl02_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_BIZNM2.Location = new System.Drawing.Point(13, 20);
            this.lbl02_BIZNM2.Name = "lbl02_BIZNM2";
            this.lbl02_BIZNM2.Size = new System.Drawing.Size(120, 21);
            this.lbl02_BIZNM2.TabIndex = 5;
            this.lbl02_BIZNM2.Tag = null;
            this.lbl02_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_BIZNM2.Value = "사업장";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 587);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
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
            this.grd01.Size = new System.Drawing.Size(1018, 567);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 49);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // QA20046
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_main);
            this.Name = "QA20046";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox_main, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.groupBox_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt02_YYYY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_JOB_CODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_GEN_RATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_PAY_AMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_EXP_RATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PAY_AMNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_GEN_RATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_EXP_RATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_JOB_CODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_YYYY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_main;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo02_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_GEN_RATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_EXP_RATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_JOB_CODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_YYYY;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_BIZNM2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxNumericEdit nme02_GEN_RATE;
        private Ax.DEV.Utility.Controls.AxNumericEdit nme02_EXP_RATE;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxTextBox txt02_YYYY;
        private DEV.Utility.Controls.AxTextBox txt02_JOB_CODE;
        private DEV.Utility.Controls.AxNumericEdit nme02_PAY_AMT;
        private DEV.Utility.Controls.AxLabel lbl02_PAY_AMNT;
    }
}
