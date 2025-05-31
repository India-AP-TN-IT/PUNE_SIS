namespace Ax.SIS.PD.UI
{
    partial class PD40400
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
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_BODYNO = new System.Windows.Forms.TextBox();
            this.lbl03_BODYNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl02_SUBMIT_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grp02_PD40400_1 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_BODYNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SUBMIT_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel3.SuspendLayout();
            this.grp02_PD40400_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
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
            this.panel2.Controls.Add(this.axButton1);
            this.panel2.Controls.Add(this.txt01_BODYNO);
            this.panel2.Controls.Add(this.lbl03_BODYNO);
            this.panel2.Controls.Add(this.dtp01_SDATE);
            this.panel2.Controls.Add(this.lbl02_SUBMIT_DATE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // axButton1
            // 
            this.axButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.axButton1.Location = new System.Drawing.Point(13, 666);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(164, 41);
            this.axButton1.TabIndex = 75;
            this.axButton1.Text = "Force Omission Process";
            this.axButton1.UseVisualStyleBackColor = true;
            this.axButton1.Click += new System.EventHandler(this.axButton1_Click);
            // 
            // txt01_BODYNO
            // 
            this.txt01_BODYNO.Location = new System.Drawing.Point(13, 151);
            this.txt01_BODYNO.Name = "txt01_BODYNO";
            this.txt01_BODYNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_BODYNO.TabIndex = 74;
            // 
            // lbl03_BODYNO
            // 
            this.lbl03_BODYNO.AutoFontSizeMaxValue = 9F;
            this.lbl03_BODYNO.AutoFontSizeMinValue = 9F;
            this.lbl03_BODYNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_BODYNO.Location = new System.Drawing.Point(13, 129);
            this.lbl03_BODYNO.Name = "lbl03_BODYNO";
            this.lbl03_BODYNO.Size = new System.Drawing.Size(226, 21);
            this.lbl03_BODYNO.TabIndex = 73;
            this.lbl03_BODYNO.Tag = null;
            this.lbl03_BODYNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl03_BODYNO.Value = "BODY";
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
            // lbl02_SUBMIT_DATE
            // 
            this.lbl02_SUBMIT_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_SUBMIT_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_SUBMIT_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_SUBMIT_DATE.Location = new System.Drawing.Point(13, 66);
            this.lbl02_SUBMIT_DATE.Name = "lbl02_SUBMIT_DATE";
            this.lbl02_SUBMIT_DATE.Size = new System.Drawing.Size(226, 21);
            this.lbl02_SUBMIT_DATE.TabIndex = 8;
            this.lbl02_SUBMIT_DATE.Tag = null;
            this.lbl02_SUBMIT_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl02_SUBMIT_DATE.Value = "전송일자";
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
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 18);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(226, 21);
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
            this.panel3.Controls.Add(this.grp02_PD40400_1);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 2;
            // 
            // grp02_PD40400_1
            // 
            this.grp02_PD40400_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp02_PD40400_1.Controls.Add(this.grd02);
            this.grp02_PD40400_1.Location = new System.Drawing.Point(3, 8);
            this.grp02_PD40400_1.Name = "grp02_PD40400_1";
            this.grp02_PD40400_1.Size = new System.Drawing.Size(736, 725);
            this.grp02_PD40400_1.TabIndex = 4;
            this.grp02_PD40400_1.TabStop = false;
            this.grp02_PD40400_1.Text = "완성차LOT전송정보";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(730, 705);
            this.grd02.TabIndex = 3;
            this.grd02.UseCustomHighlight = true;
            this.grd02.DoubleClick += new System.EventHandler(this.grd02_DoubleClick);
            // 
            // PD40400
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD40400";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_BODYNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SUBMIT_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.grp02_PD40400_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_SUBMIT_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_BODYNO;
        private System.Windows.Forms.GroupBox grp02_PD40400_1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.TextBox txt01_BODYNO;
        private DEV.Utility.Controls.AxButton axButton1;
    }
}
