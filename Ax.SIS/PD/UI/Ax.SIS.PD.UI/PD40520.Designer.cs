namespace Ax.SIS.PD.UI
{
    partial class PD40520
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
            this.grp01_PD40520_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk01_PD40520_CHK_1 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INPUT_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_INSPEC_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_INSPEC_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.txt01_MOLDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MOLDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD40520_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INPUT_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD40520_GRP_1
            // 
            this.grp01_PD40520_GRP_1.Controls.Add(this.grd01);
            this.grp01_PD40520_GRP_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD40520_GRP_1.Location = new System.Drawing.Point(0, 74);
            this.grp01_PD40520_GRP_1.Name = "grp01_PD40520_GRP_1";
            this.grp01_PD40520_GRP_1.Size = new System.Drawing.Size(1024, 694);
            this.grp01_PD40520_GRP_1.TabIndex = 8;
            this.grp01_PD40520_GRP_1.TabStop = false;
            this.grp01_PD40520_GRP_1.Text = "금형투입 정보";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk01_PD40520_CHK_1);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_INPUT_DATE);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp01_INSPEC_EDATE);
            this.groupBox1.Controls.Add(this.dtp01_INSPEC_SDATE);
            this.groupBox1.Controls.Add(this.txt01_MOLDNO);
            this.groupBox1.Controls.Add(this.lbl01_MOLDNO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // chk01_PD40520_CHK_1
            // 
            this.chk01_PD40520_CHK_1.AutoSize = true;
            this.chk01_PD40520_CHK_1.Location = new System.Drawing.Point(241, 16);
            this.chk01_PD40520_CHK_1.Name = "chk01_PD40520_CHK_1";
            this.chk01_PD40520_CHK_1.Size = new System.Drawing.Size(118, 16);
            this.chk01_PD40520_CHK_1.TabIndex = 101;
            this.chk01_PD40520_CHK_1.Text = "미추출(현재투입)";
            this.chk01_PD40520_CHK_1.UseVisualStyleBackColor = true;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(6, 13);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(85, 21);
            this.lbl01_BIZCD.TabIndex = 100;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "사업장코드";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(94, 12);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(123, 20);
            this.cbo01_BIZCD.TabIndex = 99;
            // 
            // lbl01_INPUT_DATE
            // 
            this.lbl01_INPUT_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_INPUT_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_INPUT_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INPUT_DATE.Location = new System.Drawing.Point(406, 11);
            this.lbl01_INPUT_DATE.Name = "lbl01_INPUT_DATE";
            this.lbl01_INPUT_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_INPUT_DATE.TabIndex = 98;
            this.lbl01_INPUT_DATE.Tag = null;
            this.lbl01_INPUT_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INPUT_DATE.Value = "투입일자";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 97;
            this.label1.Text = "~";
            // 
            // dtp01_INSPEC_EDATE
            // 
            this.dtp01_INSPEC_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_INSPEC_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_INSPEC_EDATE.Location = new System.Drawing.Point(634, 12);
            this.dtp01_INSPEC_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_INSPEC_EDATE.Name = "dtp01_INSPEC_EDATE";
            this.dtp01_INSPEC_EDATE.OriginalFormat = "";
            this.dtp01_INSPEC_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_INSPEC_EDATE.TabIndex = 96;
            // 
            // dtp01_INSPEC_SDATE
            // 
            this.dtp01_INSPEC_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_INSPEC_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_INSPEC_SDATE.Location = new System.Drawing.Point(510, 12);
            this.dtp01_INSPEC_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_INSPEC_SDATE.Name = "dtp01_INSPEC_SDATE";
            this.dtp01_INSPEC_SDATE.OriginalFormat = "";
            this.dtp01_INSPEC_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_INSPEC_SDATE.TabIndex = 95;
            // 
            // txt01_MOLDNO
            // 
            this.txt01_MOLDNO.Location = new System.Drawing.Point(854, 12);
            this.txt01_MOLDNO.Name = "txt01_MOLDNO";
            this.txt01_MOLDNO.Size = new System.Drawing.Size(146, 21);
            this.txt01_MOLDNO.TabIndex = 66;
            this.txt01_MOLDNO.Tag = null;
            // 
            // lbl01_MOLDNO
            // 
            this.lbl01_MOLDNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_MOLDNO.AutoFontSizeMinValue = 9F;
            this.lbl01_MOLDNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MOLDNO.Location = new System.Drawing.Point(751, 12);
            this.lbl01_MOLDNO.Name = "lbl01_MOLDNO";
            this.lbl01_MOLDNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MOLDNO.TabIndex = 65;
            this.lbl01_MOLDNO.Tag = null;
            this.lbl01_MOLDNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MOLDNO.Value = "금형번호";
            // 
            // PD40520
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD40520_GRP_1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD40520";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD40520_GRP_1, 0);
            this.grp01_PD40520_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INPUT_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD40520_GRP_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MOLDNO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_MOLDNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INPUT_DATE;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_INSPEC_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_INSPEC_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_PD40520_CHK_1;
    }
}
