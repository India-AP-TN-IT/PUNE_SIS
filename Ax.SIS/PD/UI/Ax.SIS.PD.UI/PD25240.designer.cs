namespace Ax.SIS.PD.UI 
{
    partial class PD25240
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
            this.grp01_NON_OPR_LIST = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_NON_OPR_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_NON_OPRCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.chk01_WHOLE_MONTH = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.dtp01_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_OCCUR_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grp01_NON_OPRCD_INFO = new System.Windows.Forms.GroupBox();
            this.lbl01_IMPUT_DEPT = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_REP_DEPT = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_REMARK = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_NON_OPRNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_REMARK = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_NON_OPRNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_NON_OPR_LIST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NON_OPR_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.grp01_NON_OPRCD_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_DEPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_REP_DEPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_REMARK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NON_OPRNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_REMARK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NON_OPRNO)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_NON_OPR_LIST
            // 
            this.grp01_NON_OPR_LIST.Controls.Add(this.grd01);
            this.grp01_NON_OPR_LIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_NON_OPR_LIST.Location = new System.Drawing.Point(0, 83);
            this.grp01_NON_OPR_LIST.Name = "grp01_NON_OPR_LIST";
            this.grp01_NON_OPR_LIST.Size = new System.Drawing.Size(1024, 599);
            this.grp01_NON_OPR_LIST.TabIndex = 16;
            this.grp01_NON_OPR_LIST.TabStop = false;
            this.grp01_NON_OPR_LIST.Text = "비가동 발생 목록";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 579);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_NON_OPR_DIV);
            this.groupBox1.Controls.Add(this.cbo01_NON_OPRCD);
            this.groupBox1.Controls.Add(this.chk01_WHOLE_MONTH);
            this.groupBox1.Controls.Add(this.dtp01_BEG_DATE);
            this.groupBox1.Controls.Add(this.lbl01_OCCUR_DATE);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 49);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_NON_OPR_DIV
            // 
            this.lbl01_NON_OPR_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_NON_OPR_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_NON_OPR_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_NON_OPR_DIV.Location = new System.Drawing.Point(535, 17);
            this.lbl01_NON_OPR_DIV.Name = "lbl01_NON_OPR_DIV";
            this.lbl01_NON_OPR_DIV.Size = new System.Drawing.Size(100, 21);
            this.lbl01_NON_OPR_DIV.TabIndex = 88;
            this.lbl01_NON_OPR_DIV.Tag = null;
            this.lbl01_NON_OPR_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_NON_OPR_DIV.Value = "비가동구분";
            // 
            // cbo01_NON_OPRCD
            // 
            this.cbo01_NON_OPRCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_NON_OPRCD.FormattingEnabled = true;
            this.cbo01_NON_OPRCD.Location = new System.Drawing.Point(641, 18);
            this.cbo01_NON_OPRCD.Name = "cbo01_NON_OPRCD";
            this.cbo01_NON_OPRCD.Size = new System.Drawing.Size(200, 20);
            this.cbo01_NON_OPRCD.TabIndex = 87;
            // 
            // chk01_WHOLE_MONTH
            // 
            this.chk01_WHOLE_MONTH.AutoSize = true;
            this.chk01_WHOLE_MONTH.Location = new System.Drawing.Point(469, 19);
            this.chk01_WHOLE_MONTH.Name = "chk01_WHOLE_MONTH";
            this.chk01_WHOLE_MONTH.Size = new System.Drawing.Size(60, 16);
            this.chk01_WHOLE_MONTH.TabIndex = 85;
            this.chk01_WHOLE_MONTH.Text = "월전체";
            this.chk01_WHOLE_MONTH.UseVisualStyleBackColor = true;
            // 
            // dtp01_BEG_DATE
            // 
            this.dtp01_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_DATE.Location = new System.Drawing.Point(353, 17);
            this.dtp01_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_BEG_DATE.Name = "dtp01_BEG_DATE";
            this.dtp01_BEG_DATE.OriginalFormat = "";
            this.dtp01_BEG_DATE.Size = new System.Drawing.Size(101, 21);
            this.dtp01_BEG_DATE.TabIndex = 84;
            // 
            // lbl01_OCCUR_DATE
            // 
            this.lbl01_OCCUR_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_OCCUR_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_OCCUR_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_OCCUR_DATE.Location = new System.Drawing.Point(247, 17);
            this.lbl01_OCCUR_DATE.Name = "lbl01_OCCUR_DATE";
            this.lbl01_OCCUR_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_OCCUR_DATE.TabIndex = 55;
            this.lbl01_OCCUR_DATE.Tag = null;
            this.lbl01_OCCUR_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_OCCUR_DATE.Value = "발생일자";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(7, 17);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 52;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(111, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 51;
            // 
            // grp01_NON_OPRCD_INFO
            // 
            this.grp01_NON_OPRCD_INFO.Controls.Add(this.lbl01_IMPUT_DEPT);
            this.grp01_NON_OPRCD_INFO.Controls.Add(this.cdx01_REP_DEPT);
            this.grp01_NON_OPRCD_INFO.Controls.Add(this.txt01_REMARK);
            this.grp01_NON_OPRCD_INFO.Controls.Add(this.txt02_NON_OPRNO);
            this.grp01_NON_OPRCD_INFO.Controls.Add(this.lbl01_REMARK);
            this.grp01_NON_OPRCD_INFO.Controls.Add(this.lbl02_NON_OPRNO);
            this.grp01_NON_OPRCD_INFO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_NON_OPRCD_INFO.Location = new System.Drawing.Point(0, 682);
            this.grp01_NON_OPRCD_INFO.Name = "grp01_NON_OPRCD_INFO";
            this.grp01_NON_OPRCD_INFO.Size = new System.Drawing.Size(1024, 86);
            this.grp01_NON_OPRCD_INFO.TabIndex = 15;
            this.grp01_NON_OPRCD_INFO.TabStop = false;
            this.grp01_NON_OPRCD_INFO.Text = "비가동 코드 정보";
            // 
            // lbl01_IMPUT_DEPT
            // 
            this.lbl01_IMPUT_DEPT.AutoFontSizeMaxValue = 9F;
            this.lbl01_IMPUT_DEPT.AutoFontSizeMinValue = 9F;
            this.lbl01_IMPUT_DEPT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_IMPUT_DEPT.Location = new System.Drawing.Point(231, 33);
            this.lbl01_IMPUT_DEPT.Name = "lbl01_IMPUT_DEPT";
            this.lbl01_IMPUT_DEPT.Size = new System.Drawing.Size(100, 21);
            this.lbl01_IMPUT_DEPT.TabIndex = 69;
            this.lbl01_IMPUT_DEPT.Tag = null;
            this.lbl01_IMPUT_DEPT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_IMPUT_DEPT.Value = "귀책부서";
            // 
            // cdx01_REP_DEPT
            // 
            this.cdx01_REP_DEPT.CodeParameterName = "CODE";
            this.cdx01_REP_DEPT.CodeTextBoxReadOnly = false;
            this.cdx01_REP_DEPT.CodeTextBoxVisible = true;
            this.cdx01_REP_DEPT.CodeTextBoxWidth = 50;
            this.cdx01_REP_DEPT.HEPopupHelper = null;
            this.cdx01_REP_DEPT.Location = new System.Drawing.Point(337, 34);
            this.cdx01_REP_DEPT.Name = "cdx01_REP_DEPT";
            this.cdx01_REP_DEPT.NameParameterName = "NAME";
            this.cdx01_REP_DEPT.NameTextBoxReadOnly = false;
            this.cdx01_REP_DEPT.NameTextBoxVisible = true;
            this.cdx01_REP_DEPT.PopupButtonReadOnly = false;
            this.cdx01_REP_DEPT.PopupTitle = "";
            this.cdx01_REP_DEPT.PrefixCode = "";
            this.cdx01_REP_DEPT.Size = new System.Drawing.Size(165, 21);
            this.cdx01_REP_DEPT.TabIndex = 68;
            this.cdx01_REP_DEPT.Tag = null;
            // 
            // txt01_REMARK
            // 
            this.txt01_REMARK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_REMARK.Location = new System.Drawing.Point(614, 34);
            this.txt01_REMARK.Name = "txt01_REMARK";
            this.txt01_REMARK.Size = new System.Drawing.Size(244, 21);
            this.txt01_REMARK.TabIndex = 67;
            this.txt01_REMARK.Tag = null;
            // 
            // txt02_NON_OPRNO
            // 
            this.txt02_NON_OPRNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_NON_OPRNO.Enabled = false;
            this.txt02_NON_OPRNO.Location = new System.Drawing.Point(122, 34);
            this.txt02_NON_OPRNO.Name = "txt02_NON_OPRNO";
            this.txt02_NON_OPRNO.Size = new System.Drawing.Size(100, 21);
            this.txt02_NON_OPRNO.TabIndex = 64;
            this.txt02_NON_OPRNO.Tag = null;
            // 
            // lbl01_REMARK
            // 
            this.lbl01_REMARK.AutoFontSizeMaxValue = 9F;
            this.lbl01_REMARK.AutoFontSizeMinValue = 9F;
            this.lbl01_REMARK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_REMARK.Location = new System.Drawing.Point(508, 34);
            this.lbl01_REMARK.Name = "lbl01_REMARK";
            this.lbl01_REMARK.Size = new System.Drawing.Size(100, 21);
            this.lbl01_REMARK.TabIndex = 66;
            this.lbl01_REMARK.Tag = null;
            this.lbl01_REMARK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_REMARK.Value = "비고";
            // 
            // lbl02_NON_OPRNO
            // 
            this.lbl02_NON_OPRNO.AutoFontSizeMaxValue = 9F;
            this.lbl02_NON_OPRNO.AutoFontSizeMinValue = 9F;
            this.lbl02_NON_OPRNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_NON_OPRNO.Location = new System.Drawing.Point(18, 34);
            this.lbl02_NON_OPRNO.Name = "lbl02_NON_OPRNO";
            this.lbl02_NON_OPRNO.Size = new System.Drawing.Size(100, 21);
            this.lbl02_NON_OPRNO.TabIndex = 65;
            this.lbl02_NON_OPRNO.Tag = null;
            this.lbl02_NON_OPRNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_NON_OPRNO.Value = "비가동번호";
            // 
            // PD25240
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_NON_OPR_LIST);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp01_NON_OPRCD_INFO);
            this.Name = "PD25240";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grp01_NON_OPRCD_INFO, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_NON_OPR_LIST, 0);
            this.grp01_NON_OPR_LIST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NON_OPR_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCUR_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.grp01_NON_OPRCD_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_DEPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_REP_DEPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_REMARK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NON_OPRNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_REMARK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NON_OPRNO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_NON_OPR_LIST;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private System.Windows.Forms.GroupBox grp01_NON_OPRCD_INFO;
        private DEV.Utility.Controls.AxLabel lbl01_OCCUR_DATE;
        private DEV.Utility.Controls.AxTextBox txt01_REMARK;
        private DEV.Utility.Controls.AxTextBox txt02_NON_OPRNO;
        private DEV.Utility.Controls.AxLabel lbl01_REMARK;
        private DEV.Utility.Controls.AxLabel lbl02_NON_OPRNO;
        private DEV.Utility.Controls.AxDateEdit dtp01_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_IMPUT_DEPT;
        private DEV.Utility.Controls.AxCodeBox cdx01_REP_DEPT;
        private DEV.Utility.Controls.AxCheckBox chk01_WHOLE_MONTH;
        private DEV.Utility.Controls.AxComboBox cbo01_NON_OPRCD;
        private DEV.Utility.Controls.AxLabel lbl01_NON_OPR_DIV;
    }
}
