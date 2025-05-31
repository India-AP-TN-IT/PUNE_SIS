namespace Ax.SIS.PD.UI
{
    partial class PD60040
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
            this.lbl01_RESTANK = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_RESTANK = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_WORK_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_WORK_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_WORK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RESTANK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DATE)).BeginInit();
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
            this.panel2.Controls.Add(this.lbl01_RESTANK);
            this.panel2.Controls.Add(this.cbo01_RESTANK);
            this.panel2.Controls.Add(this.lbl01_BIZCD);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp01_WORK_EDATE);
            this.panel2.Controls.Add(this.dtp01_WORK_SDATE);
            this.panel2.Controls.Add(this.lbl01_WORK_DATE);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_RESTANK
            // 
            this.lbl01_RESTANK.AutoFontSizeMaxValue = 9F;
            this.lbl01_RESTANK.AutoFontSizeMinValue = 9F;
            this.lbl01_RESTANK.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_RESTANK.Location = new System.Drawing.Point(13, 119);
            this.lbl01_RESTANK.Name = "lbl01_RESTANK";
            this.lbl01_RESTANK.Size = new System.Drawing.Size(226, 12);
            this.lbl01_RESTANK.TabIndex = 86;
            this.lbl01_RESTANK.Tag = null;
            this.lbl01_RESTANK.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_RESTANK.Value = "수지 탱크";
            // 
            // cbo01_RESTANK
            // 
            this.cbo01_RESTANK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_RESTANK.FormattingEnabled = true;
            this.cbo01_RESTANK.Location = new System.Drawing.Point(13, 134);
            this.cbo01_RESTANK.Name = "cbo01_RESTANK";
            this.cbo01_RESTANK.Size = new System.Drawing.Size(226, 20);
            this.cbo01_RESTANK.TabIndex = 85;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZCD.Location = new System.Drawing.Point(13, 20);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZCD.TabIndex = 84;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BIZCD.Value = "사업장코드";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 35);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 83;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 82;
            this.label1.Text = "~";
            // 
            // dtp01_WORK_EDATE
            // 
            this.dtp01_WORK_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_WORK_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_WORK_EDATE.Location = new System.Drawing.Point(139, 84);
            this.dtp01_WORK_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_WORK_EDATE.Name = "dtp01_WORK_EDATE";
            this.dtp01_WORK_EDATE.OriginalFormat = "";
            this.dtp01_WORK_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_WORK_EDATE.TabIndex = 81;
            // 
            // dtp01_WORK_SDATE
            // 
            this.dtp01_WORK_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_WORK_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_WORK_SDATE.Location = new System.Drawing.Point(13, 84);
            this.dtp01_WORK_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_WORK_SDATE.Name = "dtp01_WORK_SDATE";
            this.dtp01_WORK_SDATE.OriginalFormat = "";
            this.dtp01_WORK_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_WORK_SDATE.TabIndex = 80;
            // 
            // lbl01_WORK_DATE
            // 
            this.lbl01_WORK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_WORK_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_WORK_DATE.Location = new System.Drawing.Point(13, 69);
            this.lbl01_WORK_DATE.Name = "lbl01_WORK_DATE";
            this.lbl01_WORK_DATE.Size = new System.Drawing.Size(226, 12);
            this.lbl01_WORK_DATE.TabIndex = 79;
            this.lbl01_WORK_DATE.Tag = null;
            this.lbl01_WORK_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_WORK_DATE.Value = "작업일자";
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
            // 
            // PD60040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD60040";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RESTANK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DATE)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_WORK_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_WORK_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_WORK_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_RESTANK;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_RESTANK;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;



    }
}
