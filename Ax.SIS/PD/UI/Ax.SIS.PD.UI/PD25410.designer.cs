namespace Ax.SIS.PD.UI
{
    partial class PD25410
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
            this.dtp01_STD_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SAUP = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD25410_GRP1 = new System.Windows.Forms.GroupBox();
            this.txt02_CORCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_BIZCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_LOCK_TYPE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_LOCK_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_LOCK_STA = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo02_LOCK_STA = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt02_MENUID = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_MENUID = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_REMARK = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_AMDREASON = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp02_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            this.grp01_PD25410_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_LOCK_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LOCK_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LOCK_STA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_MENUID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MENUID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_REMARK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_AMDREASON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_STD_DATE)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp01_STD_DATE_TO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp01_STD_DATE);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Controls.Add(this.cbo01_SAUP);
            this.groupBox1.Controls.Add(this.lbl01_STD_DATE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 55);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // dtp01_STD_DATE_TO
            // 
            this.dtp01_STD_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STD_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STD_DATE_TO.Location = new System.Drawing.Point(507, 21);
            this.dtp01_STD_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STD_DATE_TO.Name = "dtp01_STD_DATE_TO";
            this.dtp01_STD_DATE_TO.OriginalFormat = "";
            this.dtp01_STD_DATE_TO.Size = new System.Drawing.Size(106, 21);
            this.dtp01_STD_DATE_TO.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "~";
            // 
            // dtp01_STD_DATE
            // 
            this.dtp01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STD_DATE.Location = new System.Drawing.Point(375, 21);
            this.dtp01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STD_DATE.Name = "dtp01_STD_DATE";
            this.dtp01_STD_DATE.OriginalFormat = "";
            this.dtp01_STD_DATE.Size = new System.Drawing.Size(106, 21);
            this.dtp01_STD_DATE.TabIndex = 69;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(7, 21);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 68;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // cbo01_SAUP
            // 
            this.cbo01_SAUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SAUP.FormattingEnabled = true;
            this.cbo01_SAUP.Location = new System.Drawing.Point(111, 21);
            this.cbo01_SAUP.Name = "cbo01_SAUP";
            this.cbo01_SAUP.Size = new System.Drawing.Size(152, 20);
            this.cbo01_SAUP.TabIndex = 67;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(269, 20);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STD_DATE.TabIndex = 48;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "기준일자";
            // 
            // grp01_PD25410_GRP1
            // 
            this.grp01_PD25410_GRP1.Controls.Add(this.txt02_CORCD);
            this.grp01_PD25410_GRP1.Controls.Add(this.txt02_BIZCD);
            this.grp01_PD25410_GRP1.Controls.Add(this.txt02_LOCK_TYPE);
            this.grp01_PD25410_GRP1.Controls.Add(this.lbl02_LOCK_TYPE);
            this.grp01_PD25410_GRP1.Controls.Add(this.lbl02_LOCK_STA);
            this.grp01_PD25410_GRP1.Controls.Add(this.cbo02_LOCK_STA);
            this.grp01_PD25410_GRP1.Controls.Add(this.txt02_MENUID);
            this.grp01_PD25410_GRP1.Controls.Add(this.lbl02_MENUID);
            this.grp01_PD25410_GRP1.Controls.Add(this.txt02_REMARK);
            this.grp01_PD25410_GRP1.Controls.Add(this.lbl02_AMDREASON);
            this.grp01_PD25410_GRP1.Controls.Add(this.lbl02_STD_DATE);
            this.grp01_PD25410_GRP1.Controls.Add(this.dtp02_STD_DATE);
            this.grp01_PD25410_GRP1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_PD25410_GRP1.Location = new System.Drawing.Point(0, 689);
            this.grp01_PD25410_GRP1.Name = "grp01_PD25410_GRP1";
            this.grp01_PD25410_GRP1.Size = new System.Drawing.Size(1024, 79);
            this.grp01_PD25410_GRP1.TabIndex = 9;
            this.grp01_PD25410_GRP1.TabStop = false;
            this.grp01_PD25410_GRP1.Text = "일별 마감 정보";
            // 
            // txt02_CORCD
            // 
            this.txt02_CORCD.Location = new System.Drawing.Point(928, 45);
            this.txt02_CORCD.Name = "txt02_CORCD";
            this.txt02_CORCD.Size = new System.Drawing.Size(31, 21);
            this.txt02_CORCD.TabIndex = 95;
            this.txt02_CORCD.Tag = null;
            this.txt02_CORCD.Visible = false;
            // 
            // txt02_BIZCD
            // 
            this.txt02_BIZCD.Location = new System.Drawing.Point(965, 45);
            this.txt02_BIZCD.Name = "txt02_BIZCD";
            this.txt02_BIZCD.Size = new System.Drawing.Size(31, 21);
            this.txt02_BIZCD.TabIndex = 94;
            this.txt02_BIZCD.Tag = null;
            this.txt02_BIZCD.Visible = false;
            // 
            // txt02_LOCK_TYPE
            // 
            this.txt02_LOCK_TYPE.Location = new System.Drawing.Point(908, 18);
            this.txt02_LOCK_TYPE.Name = "txt02_LOCK_TYPE";
            this.txt02_LOCK_TYPE.Size = new System.Drawing.Size(150, 21);
            this.txt02_LOCK_TYPE.TabIndex = 93;
            this.txt02_LOCK_TYPE.Tag = null;
            // 
            // lbl02_LOCK_TYPE
            // 
            this.lbl02_LOCK_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl02_LOCK_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl02_LOCK_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_LOCK_TYPE.Location = new System.Drawing.Point(802, 17);
            this.lbl02_LOCK_TYPE.Name = "lbl02_LOCK_TYPE";
            this.lbl02_LOCK_TYPE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_LOCK_TYPE.TabIndex = 92;
            this.lbl02_LOCK_TYPE.Tag = null;
            this.lbl02_LOCK_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_LOCK_TYPE.Value = "업무";
            // 
            // lbl02_LOCK_STA
            // 
            this.lbl02_LOCK_STA.AutoFontSizeMaxValue = 9F;
            this.lbl02_LOCK_STA.AutoFontSizeMinValue = 9F;
            this.lbl02_LOCK_STA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_LOCK_STA.Location = new System.Drawing.Point(269, 17);
            this.lbl02_LOCK_STA.Name = "lbl02_LOCK_STA";
            this.lbl02_LOCK_STA.Size = new System.Drawing.Size(100, 21);
            this.lbl02_LOCK_STA.TabIndex = 91;
            this.lbl02_LOCK_STA.Tag = null;
            this.lbl02_LOCK_STA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_LOCK_STA.Value = "잠금구분";
            // 
            // cbo02_LOCK_STA
            // 
            this.cbo02_LOCK_STA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_LOCK_STA.FormattingEnabled = true;
            this.cbo02_LOCK_STA.Location = new System.Drawing.Point(375, 18);
            this.cbo02_LOCK_STA.Name = "cbo02_LOCK_STA";
            this.cbo02_LOCK_STA.Size = new System.Drawing.Size(151, 20);
            this.cbo02_LOCK_STA.TabIndex = 90;
            // 
            // txt02_MENUID
            // 
            this.txt02_MENUID.Location = new System.Drawing.Point(644, 18);
            this.txt02_MENUID.Name = "txt02_MENUID";
            this.txt02_MENUID.Size = new System.Drawing.Size(150, 21);
            this.txt02_MENUID.TabIndex = 89;
            this.txt02_MENUID.Tag = null;
            // 
            // lbl02_MENUID
            // 
            this.lbl02_MENUID.AutoFontSizeMaxValue = 9F;
            this.lbl02_MENUID.AutoFontSizeMinValue = 9F;
            this.lbl02_MENUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_MENUID.Location = new System.Drawing.Point(538, 17);
            this.lbl02_MENUID.Name = "lbl02_MENUID";
            this.lbl02_MENUID.Size = new System.Drawing.Size(100, 21);
            this.lbl02_MENUID.TabIndex = 88;
            this.lbl02_MENUID.Tag = null;
            this.lbl02_MENUID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_MENUID.Value = "변경사유";
            // 
            // txt02_REMARK
            // 
            this.txt02_REMARK.Location = new System.Drawing.Point(112, 48);
            this.txt02_REMARK.Name = "txt02_REMARK";
            this.txt02_REMARK.Size = new System.Drawing.Size(412, 21);
            this.txt02_REMARK.TabIndex = 89;
            this.txt02_REMARK.Tag = null;
            // 
            // lbl02_AMDREASON
            // 
            this.lbl02_AMDREASON.AutoFontSizeMaxValue = 9F;
            this.lbl02_AMDREASON.AutoFontSizeMinValue = 9F;
            this.lbl02_AMDREASON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_AMDREASON.Location = new System.Drawing.Point(6, 47);
            this.lbl02_AMDREASON.Name = "lbl02_AMDREASON";
            this.lbl02_AMDREASON.Size = new System.Drawing.Size(100, 21);
            this.lbl02_AMDREASON.TabIndex = 88;
            this.lbl02_AMDREASON.Tag = null;
            this.lbl02_AMDREASON.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_AMDREASON.Value = "변경사유";
            // 
            // lbl02_STD_DATE
            // 
            this.lbl02_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_STD_DATE.Location = new System.Drawing.Point(6, 17);
            this.lbl02_STD_DATE.Name = "lbl02_STD_DATE";
            this.lbl02_STD_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_STD_DATE.TabIndex = 82;
            this.lbl02_STD_DATE.Tag = null;
            this.lbl02_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_STD_DATE.Value = "기준일자";
            // 
            // dtp02_STD_DATE
            // 
            this.dtp02_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp02_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp02_STD_DATE.Location = new System.Drawing.Point(112, 17);
            this.dtp02_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp02_STD_DATE.Name = "dtp02_STD_DATE";
            this.dtp02_STD_DATE.OriginalFormat = "";
            this.dtp02_STD_DATE.Size = new System.Drawing.Size(150, 21);
            this.dtp02_STD_DATE.TabIndex = 84;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd02);
            this.groupBox3.Controls.Add(this.splitter1);
            this.groupBox3.Controls.Add(this.grd01);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 600);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(974, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(47, 580);
            this.grd02.TabIndex = 10;
            this.grd02.UseCustomHighlight = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(971, 17);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 580);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Left;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(968, 580);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // axDateEdit1
            // 
            this.axDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit1.Location = new System.Drawing.Point(507, 21);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(106, 21);
            this.axDateEdit1.TabIndex = 72;
            // 
            // PD25410
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp01_PD25410_GRP1);
            this.Name = "PD25410";
            this.Controls.SetChildIndex(this.grp01_PD25410_GRP1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            this.grp01_PD25410_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt02_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_LOCK_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LOCK_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LOCK_STA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_MENUID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MENUID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_REMARK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_AMDREASON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_STD_DATE)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private System.Windows.Forms.GroupBox grp01_PD25410_GRP1;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxComboBox cbo01_SAUP;
        private DEV.Utility.Controls.AxDateEdit dtp01_STD_DATE;
        private System.Windows.Forms.GroupBox groupBox3;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxTextBox txt02_REMARK;
        private DEV.Utility.Controls.AxLabel lbl02_AMDREASON;
        private DEV.Utility.Controls.AxLabel lbl02_STD_DATE;
        private DEV.Utility.Controls.AxDateEdit dtp02_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl02_LOCK_STA;
        private DEV.Utility.Controls.AxComboBox cbo02_LOCK_STA;
        private DEV.Utility.Controls.AxTextBox txt02_MENUID;
        private DEV.Utility.Controls.AxLabel lbl02_MENUID;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.Splitter splitter1;
        private DEV.Utility.Controls.AxDateEdit dtp01_STD_DATE_TO;
        private System.Windows.Forms.Label label1;
        private DEV.Utility.Controls.AxDateEdit axDateEdit1;
        private DEV.Utility.Controls.AxTextBox txt02_LOCK_TYPE;
        private DEV.Utility.Controls.AxLabel lbl02_LOCK_TYPE;
        private DEV.Utility.Controls.AxTextBox txt02_CORCD;
        private DEV.Utility.Controls.AxTextBox txt02_BIZCD;

    }
}
