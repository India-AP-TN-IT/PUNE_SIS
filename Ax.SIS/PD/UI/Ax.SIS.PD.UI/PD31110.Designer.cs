namespace Ax.SIS.PD.UI
{
    partial class PD31110
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo01_INOUT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INOUT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dte01_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STARTDATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INOUT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STARTDATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.heDockingTab1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 734);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd01);
            this.panel2.Location = new System.Drawing.Point(280, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 716);
            this.panel2.TabIndex = 15;
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
            this.grd01.Size = new System.Drawing.Size(738, 716);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo01_INOUT_DIV);
            this.panel1.Controls.Add(this.lbl01_INOUT_DIV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dte01_END_DATE);
            this.panel1.Controls.Add(this.dte01_BEG_DATE);
            this.panel1.Controls.Add(this.lbl01_STARTDATE);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 714);
            this.panel1.TabIndex = 14;
            // 
            // cbo01_INOUT_DIV
            // 
            this.cbo01_INOUT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INOUT_DIV.FormattingEnabled = true;
            this.cbo01_INOUT_DIV.Location = new System.Drawing.Point(13, 154);
            this.cbo01_INOUT_DIV.Name = "cbo01_INOUT_DIV";
            this.cbo01_INOUT_DIV.Size = new System.Drawing.Size(200, 20);
            this.cbo01_INOUT_DIV.TabIndex = 14;
            // 
            // lbl01_INOUT_DIV
            // 
            this.lbl01_INOUT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_INOUT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_INOUT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INOUT_DIV.Location = new System.Drawing.Point(13, 132);
            this.lbl01_INOUT_DIV.Name = "lbl01_INOUT_DIV";
            this.lbl01_INOUT_DIV.Size = new System.Drawing.Size(200, 20);
            this.lbl01_INOUT_DIV.TabIndex = 13;
            this.lbl01_INOUT_DIV.Tag = null;
            this.lbl01_INOUT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_INOUT_DIV.Value = "입출고구분";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "~";
            // 
            // dte01_END_DATE
            // 
            this.dte01_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_END_DATE.Location = new System.Drawing.Point(123, 99);
            this.dte01_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_END_DATE.Name = "dte01_END_DATE";
            this.dte01_END_DATE.OriginalFormat = "";
            this.dte01_END_DATE.Size = new System.Drawing.Size(90, 21);
            this.dte01_END_DATE.TabIndex = 6;
            // 
            // dte01_BEG_DATE
            // 
            this.dte01_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_BEG_DATE.Location = new System.Drawing.Point(13, 98);
            this.dte01_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_BEG_DATE.Name = "dte01_BEG_DATE";
            this.dte01_BEG_DATE.OriginalFormat = "";
            this.dte01_BEG_DATE.Size = new System.Drawing.Size(92, 21);
            this.dte01_BEG_DATE.TabIndex = 5;
            // 
            // lbl01_STARTDATE
            // 
            this.lbl01_STARTDATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STARTDATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STARTDATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STARTDATE.Location = new System.Drawing.Point(13, 76);
            this.lbl01_STARTDATE.Name = "lbl01_STARTDATE";
            this.lbl01_STARTDATE.Size = new System.Drawing.Size(200, 20);
            this.lbl01_STARTDATE.TabIndex = 4;
            this.lbl01_STARTDATE.Tag = null;
            this.lbl01_STARTDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_STARTDATE.Value = "시작일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 48);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(200, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 26);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(200, 20);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.heDockingTab1.Margin = new System.Windows.Forms.Padding(4);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 714;
            this.heDockingTab1.PanelWidth = 230;
            this.heDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.heDockingTab1.TabIndex = 0;
            // 
            // PD31110
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "PD31110";
            this.Load += new System.EventHandler(this.PD31110_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INOUT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STARTDATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_BEG_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_STARTDATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_END_DATE;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_INOUT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INOUT_DIV;
    }
}
