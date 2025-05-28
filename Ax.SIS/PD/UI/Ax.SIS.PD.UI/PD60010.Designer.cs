namespace Ax.SIS.PD.UI
{
    partial class PD60010
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
            this.txt01_MIXNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MIXNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_WORKDATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MIXNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MIXNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORKDATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
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
            this.panel2.Controls.Add(this.chk01_GRID_MERGE);
            this.panel2.Controls.Add(this.txt01_MIXNO);
            this.panel2.Controls.Add(this.lbl01_MIXNO);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp01_EDATE);
            this.panel2.Controls.Add(this.dtp01_SDATE);
            this.panel2.Controls.Add(this.lbl01_WORKDATE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZCD);
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
            this.chk01_GRID_MERGE.Location = new System.Drawing.Point(14, 187);
            this.chk01_GRID_MERGE.Name = "chk01_GRID_MERGE";
            this.chk01_GRID_MERGE.Size = new System.Drawing.Size(88, 16);
            this.chk01_GRID_MERGE.TabIndex = 76;
            this.chk01_GRID_MERGE.Text = "그리드 병합";
            this.chk01_GRID_MERGE.UseVisualStyleBackColor = true;
            this.chk01_GRID_MERGE.CheckedChanged += new System.EventHandler(this.chk01_GRID_MERGE_CheckedChanged);
            // 
            // txt01_MIXNO
            // 
            this.txt01_MIXNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_MIXNO.Location = new System.Drawing.Point(13, 160);
            this.txt01_MIXNO.Name = "txt01_MIXNO";
            this.txt01_MIXNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_MIXNO.TabIndex = 74;
            this.txt01_MIXNO.Tag = null;
            // 
            // lbl01_MIXNO
            // 
            this.lbl01_MIXNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_MIXNO.AutoFontSizeMinValue = 9F;
            this.lbl01_MIXNO.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_MIXNO.Location = new System.Drawing.Point(13, 145);
            this.lbl01_MIXNO.Name = "lbl01_MIXNO";
            this.lbl01_MIXNO.Size = new System.Drawing.Size(226, 12);
            this.lbl01_MIXNO.TabIndex = 73;
            this.lbl01_MIXNO.Tag = null;
            this.lbl01_MIXNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_MIXNO.Value = "믹서 호기";
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
            // lbl01_WORKDATE
            // 
            this.lbl01_WORKDATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORKDATE.AutoFontSizeMinValue = 9F;
            this.lbl01_WORKDATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_WORKDATE.Location = new System.Drawing.Point(13, 73);
            this.lbl01_WORKDATE.Name = "lbl01_WORKDATE";
            this.lbl01_WORKDATE.Size = new System.Drawing.Size(226, 12);
            this.lbl01_WORKDATE.TabIndex = 8;
            this.lbl01_WORKDATE.Tag = null;
            this.lbl01_WORKDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_WORKDATE.Value = "작업일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 7;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZCD.Location = new System.Drawing.Point(13, 26);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZCD.TabIndex = 6;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZCD.Value = "사업장코드";
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
            // 
            // PD60010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD60010";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MIXNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MIXNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORKDATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
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
        private Ax.DEV.Utility.Controls.AxLabel lbl01_WORKDATE;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_EDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MIXNO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_MIXNO;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_GRID_MERGE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
    }
}
