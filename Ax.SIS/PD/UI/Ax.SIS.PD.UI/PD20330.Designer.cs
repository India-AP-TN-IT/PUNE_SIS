namespace Ax.SIS.PD.UI
{
    partial class PD20330
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
            this.chk01_GRID_MERGE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_WORK_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_WORK_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_CALL_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_MGRT_CD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_MANAGE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CHK = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SELECT_CALL = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_NON_OPR_DEF = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SELECT_DEF = new Ax.DEV.Utility.Controls.AxComboBox();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CALL_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MGRT_CD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CHK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NON_OPR_DEF)).BeginInit();
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
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chk01_GRID_MERGE);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp01_WORK_EDATE);
            this.panel2.Controls.Add(this.dtp01_WORK_SDATE);
            this.panel2.Controls.Add(this.lbl01_CALL_DATE);
            this.panel2.Controls.Add(this.lbl01_MGRT_CD);
            this.panel2.Controls.Add(this.cbo01_MANAGE);
            this.panel2.Controls.Add(this.lbl01_CHK);
            this.panel2.Controls.Add(this.cbo01_SELECT_CALL);
            this.panel2.Controls.Add(this.lbl01_NON_OPR_DEF);
            this.panel2.Controls.Add(this.cbo01_SELECT_DEF);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // chk01_GRID_MERGE
            // 
            this.chk01_GRID_MERGE.AutoSize = true;
            this.chk01_GRID_MERGE.Checked = true;
            this.chk01_GRID_MERGE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_GRID_MERGE.Location = new System.Drawing.Point(3, 260);
            this.chk01_GRID_MERGE.Name = "chk01_GRID_MERGE";
            this.chk01_GRID_MERGE.Size = new System.Drawing.Size(75, 16);
            this.chk01_GRID_MERGE.TabIndex = 97;
            this.chk01_GRID_MERGE.Text = "Grid 병합";
            this.chk01_GRID_MERGE.UseVisualStyleBackColor = true;
            this.chk01_GRID_MERGE.Visible = false;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(3, 11);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 23);
            this.lbl01_BIZNM2.TabIndex = 96;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(3, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 95;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 94;
            this.label1.Text = "~";
            // 
            // dtp01_WORK_EDATE
            // 
            this.dtp01_WORK_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_WORK_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_WORK_EDATE.Location = new System.Drawing.Point(129, 233);
            this.dtp01_WORK_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_WORK_EDATE.Name = "dtp01_WORK_EDATE";
            this.dtp01_WORK_EDATE.OriginalFormat = "";
            this.dtp01_WORK_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_WORK_EDATE.TabIndex = 93;
            // 
            // dtp01_WORK_SDATE
            // 
            this.dtp01_WORK_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_WORK_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_WORK_SDATE.Location = new System.Drawing.Point(3, 233);
            this.dtp01_WORK_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_WORK_SDATE.Name = "dtp01_WORK_SDATE";
            this.dtp01_WORK_SDATE.OriginalFormat = "";
            this.dtp01_WORK_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_WORK_SDATE.TabIndex = 92;
            // 
            // lbl01_CALL_DATE
            // 
            this.lbl01_CALL_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CALL_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_CALL_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_CALL_DATE.Location = new System.Drawing.Point(3, 207);
            this.lbl01_CALL_DATE.Name = "lbl01_CALL_DATE";
            this.lbl01_CALL_DATE.Size = new System.Drawing.Size(100, 23);
            this.lbl01_CALL_DATE.TabIndex = 91;
            this.lbl01_CALL_DATE.Tag = null;
            this.lbl01_CALL_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_CALL_DATE.Value = "호출일자";
            // 
            // lbl01_MGRT_CD
            // 
            this.lbl01_MGRT_CD.AutoFontSizeMaxValue = 9F;
            this.lbl01_MGRT_CD.AutoFontSizeMinValue = 9F;
            this.lbl01_MGRT_CD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_MGRT_CD.Location = new System.Drawing.Point(3, 158);
            this.lbl01_MGRT_CD.Name = "lbl01_MGRT_CD";
            this.lbl01_MGRT_CD.Size = new System.Drawing.Size(100, 23);
            this.lbl01_MGRT_CD.TabIndex = 90;
            this.lbl01_MGRT_CD.Tag = null;
            this.lbl01_MGRT_CD.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_MGRT_CD.Value = "조치 구분";
            // 
            // cbo01_MANAGE
            // 
            this.cbo01_MANAGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_MANAGE.FormattingEnabled = true;
            this.cbo01_MANAGE.Location = new System.Drawing.Point(3, 184);
            this.cbo01_MANAGE.Name = "cbo01_MANAGE";
            this.cbo01_MANAGE.Size = new System.Drawing.Size(226, 20);
            this.cbo01_MANAGE.TabIndex = 89;
            // 
            // lbl01_CHK
            // 
            this.lbl01_CHK.AutoFontSizeMaxValue = 9F;
            this.lbl01_CHK.AutoFontSizeMinValue = 9F;
            this.lbl01_CHK.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_CHK.Location = new System.Drawing.Point(3, 109);
            this.lbl01_CHK.Name = "lbl01_CHK";
            this.lbl01_CHK.Size = new System.Drawing.Size(100, 23);
            this.lbl01_CHK.TabIndex = 88;
            this.lbl01_CHK.Tag = null;
            this.lbl01_CHK.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_CHK.Value = "선택";
            // 
            // cbo01_SELECT_CALL
            // 
            this.cbo01_SELECT_CALL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SELECT_CALL.FormattingEnabled = true;
            this.cbo01_SELECT_CALL.Location = new System.Drawing.Point(3, 135);
            this.cbo01_SELECT_CALL.Name = "cbo01_SELECT_CALL";
            this.cbo01_SELECT_CALL.Size = new System.Drawing.Size(226, 20);
            this.cbo01_SELECT_CALL.TabIndex = 87;
            // 
            // lbl01_NON_OPR_DEF
            // 
            this.lbl01_NON_OPR_DEF.AutoFontSizeMaxValue = 9F;
            this.lbl01_NON_OPR_DEF.AutoFontSizeMinValue = 9F;
            this.lbl01_NON_OPR_DEF.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_NON_OPR_DEF.Location = new System.Drawing.Point(3, 60);
            this.lbl01_NON_OPR_DEF.Name = "lbl01_NON_OPR_DEF";
            this.lbl01_NON_OPR_DEF.Size = new System.Drawing.Size(100, 23);
            this.lbl01_NON_OPR_DEF.TabIndex = 86;
            this.lbl01_NON_OPR_DEF.Tag = null;
            this.lbl01_NON_OPR_DEF.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_NON_OPR_DEF.Value = "비가동/불량";
            // 
            // cbo01_SELECT_DEF
            // 
            this.cbo01_SELECT_DEF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SELECT_DEF.FormattingEnabled = true;
            this.cbo01_SELECT_DEF.Location = new System.Drawing.Point(3, 86);
            this.cbo01_SELECT_DEF.Name = "cbo01_SELECT_DEF";
            this.cbo01_SELECT_DEF.Size = new System.Drawing.Size(226, 20);
            this.cbo01_SELECT_DEF.TabIndex = 85;
            this.cbo01_SELECT_DEF.SelectedIndexChanged += new System.EventHandler(this.cbo01_SELECT_DEF_SelectedIndexChanged);
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
            this.panel3.TabIndex = 4;
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
            this.grd01.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.grd01_AfterDataRefresh);
            // 
            // PD20330
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD20330";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CALL_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MGRT_CD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CHK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NON_OPR_DEF)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_NON_OPR_DEF;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SELECT_DEF;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MGRT_CD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_MANAGE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CHK;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SELECT_CALL;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_WORK_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_WORK_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CALL_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_GRID_MERGE;



    }
}
