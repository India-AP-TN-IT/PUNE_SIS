namespace Ax.SIS.WM.UI
{
    partial class WM20500
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
            this.lbl01_DOM_IMP_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_DOM_IMP_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl03_Wave = new System.Windows.Forms.Label();
            this.dtp01_PROD_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_PROD_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_WORK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOM_IMP_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DATE)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 28);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 740);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl01_DOM_IMP_DIV);
            this.panel2.Controls.Add(this.cbo01_DOM_IMP_DIV);
            this.panel2.Controls.Add(this.cbo01_PRDT_DIV);
            this.panel2.Controls.Add(this.lbl01_PRDT_DIV);
            this.panel2.Controls.Add(this.lbl03_Wave);
            this.panel2.Controls.Add(this.dtp01_PROD_EDATE);
            this.panel2.Controls.Add(this.dtp01_PROD_SDATE);
            this.panel2.Controls.Add(this.lbl01_WORK_DATE);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_DOM_IMP_DIV
            // 
            this.lbl01_DOM_IMP_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_DOM_IMP_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_DOM_IMP_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DOM_IMP_DIV.Location = new System.Drawing.Point(4, 97);
            this.lbl01_DOM_IMP_DIV.Name = "lbl01_DOM_IMP_DIV";
            this.lbl01_DOM_IMP_DIV.Size = new System.Drawing.Size(222, 21);
            this.lbl01_DOM_IMP_DIV.TabIndex = 131;
            this.lbl01_DOM_IMP_DIV.Tag = null;
            this.lbl01_DOM_IMP_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DOM_IMP_DIV.Value = "_공장구분";
            // 
            // cbo01_DOM_IMP_DIV
            // 
            this.cbo01_DOM_IMP_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DOM_IMP_DIV.FormattingEnabled = true;
            this.cbo01_DOM_IMP_DIV.Location = new System.Drawing.Point(4, 121);
            this.cbo01_DOM_IMP_DIV.Name = "cbo01_DOM_IMP_DIV";
            this.cbo01_DOM_IMP_DIV.Size = new System.Drawing.Size(222, 20);
            this.cbo01_DOM_IMP_DIV.TabIndex = 130;
            // 
            // cbo01_PRDT_DIV
            // 
            this.cbo01_PRDT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRDT_DIV.FormattingEnabled = true;
            this.cbo01_PRDT_DIV.Location = new System.Drawing.Point(3, 72);
            this.cbo01_PRDT_DIV.Name = "cbo01_PRDT_DIV";
            this.cbo01_PRDT_DIV.Size = new System.Drawing.Size(224, 20);
            this.cbo01_PRDT_DIV.TabIndex = 107;
            // 
            // lbl01_PRDT_DIV
            // 
            this.lbl01_PRDT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRDT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PRDT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRDT_DIV.Location = new System.Drawing.Point(3, 48);
            this.lbl01_PRDT_DIV.Name = "lbl01_PRDT_DIV";
            this.lbl01_PRDT_DIV.Size = new System.Drawing.Size(224, 21);
            this.lbl01_PRDT_DIV.TabIndex = 106;
            this.lbl01_PRDT_DIV.Tag = null;
            this.lbl01_PRDT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PRDT_DIV.Value = "제품구분";
            // 
            // lbl03_Wave
            // 
            this.lbl03_Wave.AutoSize = true;
            this.lbl03_Wave.Location = new System.Drawing.Point(109, 30);
            this.lbl03_Wave.Name = "lbl03_Wave";
            this.lbl03_Wave.Size = new System.Drawing.Size(14, 12);
            this.lbl03_Wave.TabIndex = 105;
            this.lbl03_Wave.Text = "~";
            // 
            // dtp01_PROD_EDATE
            // 
            this.dtp01_PROD_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_PROD_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_PROD_EDATE.Location = new System.Drawing.Point(127, 24);
            this.dtp01_PROD_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_PROD_EDATE.Name = "dtp01_PROD_EDATE";
            this.dtp01_PROD_EDATE.OriginalFormat = "";
            this.dtp01_PROD_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_PROD_EDATE.TabIndex = 104;
            // 
            // dtp01_PROD_SDATE
            // 
            this.dtp01_PROD_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_PROD_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_PROD_SDATE.Location = new System.Drawing.Point(3, 24);
            this.dtp01_PROD_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_PROD_SDATE.Name = "dtp01_PROD_SDATE";
            this.dtp01_PROD_SDATE.OriginalFormat = "";
            this.dtp01_PROD_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_PROD_SDATE.TabIndex = 103;
            // 
            // lbl01_WORK_DATE
            // 
            this.lbl01_WORK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_WORK_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WORK_DATE.Location = new System.Drawing.Point(3, 0);
            this.lbl01_WORK_DATE.Name = "lbl01_WORK_DATE";
            this.lbl01_WORK_DATE.Size = new System.Drawing.Size(224, 21);
            this.lbl01_WORK_DATE.TabIndex = 102;
            this.lbl01_WORK_DATE.Tag = null;
            this.lbl01_WORK_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_WORK_DATE.Value = "작업일자";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 740;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 740);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 3;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = true;
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
            // WM20500
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "WM20500";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOM_IMP_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DATE)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Label lbl03_Wave;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_PROD_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_PROD_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_WORK_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PRDT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PRDT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DOM_IMP_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_DOM_IMP_DIV;
    }
}
