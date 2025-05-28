namespace Ax.SIS.PD.UI
{
    partial class PD20350
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grp01_CHR_TEL = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cbo01_SMSTYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.chk01_GRID_MERGE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_SMS_TYPE_CODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_CALL_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grp01_CHR_TEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SMS_TYPE_CODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CALL_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grp01_CHR_TEL);
            this.panel2.Controls.Add(this.cbo01_SMSTYPE);
            this.panel2.Controls.Add(this.chk01_GRID_MERGE);
            this.panel2.Controls.Add(this.lbl01_SMS_TYPE_CODE);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp01_EDATE);
            this.panel2.Controls.Add(this.dtp01_SDATE);
            this.panel2.Controls.Add(this.lbl01_CALL_DATE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // grp01_CHR_TEL
            // 
            this.grp01_CHR_TEL.Controls.Add(this.grd02);
            this.grp01_CHR_TEL.Location = new System.Drawing.Point(13, 218);
            this.grp01_CHR_TEL.Name = "grp01_CHR_TEL";
            this.grp01_CHR_TEL.Size = new System.Drawing.Size(247, 283);
            this.grp01_CHR_TEL.TabIndex = 87;
            this.grp01_CHR_TEL.TabStop = false;
            this.grp01_CHR_TEL.Text = "연락처 목록";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(241, 263);
            this.grd02.TabIndex = 3;
            this.grd02.UseCustomHighlight = true;
            // 
            // cbo01_SMSTYPE
            // 
            this.cbo01_SMSTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SMSTYPE.FormattingEnabled = true;
            this.cbo01_SMSTYPE.Location = new System.Drawing.Point(13, 152);
            this.cbo01_SMSTYPE.Name = "cbo01_SMSTYPE";
            this.cbo01_SMSTYPE.Size = new System.Drawing.Size(226, 20);
            this.cbo01_SMSTYPE.TabIndex = 86;
            // 
            // chk01_GRID_MERGE
            // 
            this.chk01_GRID_MERGE.AutoSize = true;
            this.chk01_GRID_MERGE.Checked = true;
            this.chk01_GRID_MERGE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_GRID_MERGE.Location = new System.Drawing.Point(13, 178);
            this.chk01_GRID_MERGE.Name = "chk01_GRID_MERGE";
            this.chk01_GRID_MERGE.Size = new System.Drawing.Size(75, 16);
            this.chk01_GRID_MERGE.TabIndex = 76;
            this.chk01_GRID_MERGE.Text = "Grid 병합";
            this.chk01_GRID_MERGE.UseVisualStyleBackColor = true;
            this.chk01_GRID_MERGE.CheckedChanged += new System.EventHandler(this.chk01_GRID_MERGE_CheckedChanged);
            // 
            // lbl01_SMS_TYPE_CODE
            // 
            this.lbl01_SMS_TYPE_CODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_SMS_TYPE_CODE.AutoFontSizeMinValue = 9F;
            this.lbl01_SMS_TYPE_CODE.AutoSize = true;
            this.lbl01_SMS_TYPE_CODE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SMS_TYPE_CODE.Location = new System.Drawing.Point(13, 137);
            this.lbl01_SMS_TYPE_CODE.Name = "lbl01_SMS_TYPE_CODE";
            this.lbl01_SMS_TYPE_CODE.Size = new System.Drawing.Size(141, 12);
            this.lbl01_SMS_TYPE_CODE.TabIndex = 73;
            this.lbl01_SMS_TYPE_CODE.Tag = null;
            this.lbl01_SMS_TYPE_CODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SMS_TYPE_CODE.Value = "업무코드";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "~";
            // 
            // dtp01_EDATE
            // 
            this.dtp01_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_EDATE.Location = new System.Drawing.Point(139, 88);
            this.dtp01_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_EDATE.Name = "dtp01_EDATE";
            this.dtp01_EDATE.OriginalFormat = "";
            this.dtp01_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_EDATE.TabIndex = 10;
            // 
            // dtp01_SDATE
            // 
            this.dtp01_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_SDATE.Location = new System.Drawing.Point(13, 88);
            this.dtp01_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_SDATE.Name = "dtp01_SDATE";
            this.dtp01_SDATE.OriginalFormat = "";
            this.dtp01_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_SDATE.TabIndex = 9;
            // 
            // lbl01_CALL_DATE
            // 
            this.lbl01_CALL_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CALL_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_CALL_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_CALL_DATE.Location = new System.Drawing.Point(13, 73);
            this.lbl01_CALL_DATE.Name = "lbl01_CALL_DATE";
            this.lbl01_CALL_DATE.Size = new System.Drawing.Size(100, 12);
            this.lbl01_CALL_DATE.TabIndex = 8;
            this.lbl01_CALL_DATE.Tag = null;
            this.lbl01_CALL_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_CALL_DATE.Value = "호출일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 7;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 26);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 12);
            this.lbl01_BIZNM2.TabIndex = 6;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 2;
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
            this.grd01.Size = new System.Drawing.Size(742, 736);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // PD20350
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD20350";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grp01_CHR_TEL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SMS_TYPE_CODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CALL_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CALL_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_EDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SMS_TYPE_CODE;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_GRID_MERGE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SMSTYPE;
        private System.Windows.Forms.GroupBox grp01_CHR_TEL;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
    }
}
