namespace Ax.SIS.PD.UI
{
    partial class PD40430
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
            this.lbl01_PD40430_LB01 = new System.Windows.Forms.Label();
            this.chk01_PD40430_CHK01 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.dtp01_INSPEC_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_OUT_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OUT_DATE)).BeginInit();
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
            this.panel2.Controls.Add(this.lbl01_PD40430_LB01);
            this.panel2.Controls.Add(this.chk01_PD40430_CHK01);
            this.panel2.Controls.Add(this.dtp01_INSPEC_SDATE);
            this.panel2.Controls.Add(this.lbl01_OUT_DATE);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_PD40430_LB01
            // 
            this.lbl01_PD40430_LB01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl01_PD40430_LB01.Location = new System.Drawing.Point(8, 128);
            this.lbl01_PD40430_LB01.Name = "lbl01_PD40430_LB01";
            this.lbl01_PD40430_LB01.Size = new System.Drawing.Size(144, 88);
            this.lbl01_PD40430_LB01.TabIndex = 94;
            this.lbl01_PD40430_LB01.Text = "******투입상태******\r\n\r\n1) Y : 정상출고\r\n2) H : 파견자 대체\r\n3) X : 시차결품\r\n4) D : 삭제";
            // 
            // chk01_PD40430_CHK01
            // 
            this.chk01_PD40430_CHK01.AutoSize = true;
            this.chk01_PD40430_CHK01.Checked = true;
            this.chk01_PD40430_CHK01.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_PD40430_CHK01.Location = new System.Drawing.Point(10, 89);
            this.chk01_PD40430_CHK01.Name = "chk01_PD40430_CHK01";
            this.chk01_PD40430_CHK01.Size = new System.Drawing.Size(88, 16);
            this.chk01_PD40430_CHK01.TabIndex = 93;
            this.chk01_PD40430_CHK01.Text = "오류만 조회";
            this.chk01_PD40430_CHK01.UseVisualStyleBackColor = true;
            // 
            // dtp01_INSPEC_SDATE
            // 
            this.dtp01_INSPEC_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_INSPEC_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_INSPEC_SDATE.Location = new System.Drawing.Point(10, 45);
            this.dtp01_INSPEC_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_INSPEC_SDATE.Name = "dtp01_INSPEC_SDATE";
            this.dtp01_INSPEC_SDATE.OriginalFormat = "";
            this.dtp01_INSPEC_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_INSPEC_SDATE.TabIndex = 92;
            // 
            // lbl01_OUT_DATE
            // 
            this.lbl01_OUT_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_OUT_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_OUT_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_OUT_DATE.Location = new System.Drawing.Point(3, 18);
            this.lbl01_OUT_DATE.Name = "lbl01_OUT_DATE";
            this.lbl01_OUT_DATE.Size = new System.Drawing.Size(100, 23);
            this.lbl01_OUT_DATE.TabIndex = 91;
            this.lbl01_OUT_DATE.Tag = null;
            this.lbl01_OUT_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_OUT_DATE.Value = "출고일자";
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
            // PD40430
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD40430";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OUT_DATE)).EndInit();
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
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_INSPEC_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OUT_DATE;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_PD40430_CHK01;
        private System.Windows.Forms.Label lbl01_PD40430_LB01;



    }
}
