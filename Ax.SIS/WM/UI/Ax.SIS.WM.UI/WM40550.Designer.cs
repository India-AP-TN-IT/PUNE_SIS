namespace Ax.SIS.WM.UI
{
    partial class WM40550
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
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl03_Wave = new System.Windows.Forms.Label();
            this.dtp01_PROD_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_PROD_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STOCK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cdx01_PARTNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STOCK_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).BeginInit();
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
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.lbl03_Wave);
            this.panel2.Controls.Add(this.dtp01_PROD_EDATE);
            this.panel2.Controls.Add(this.dtp01_PROD_SDATE);
            this.panel2.Controls.Add(this.lbl01_STOCK_DATE);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(6, 131);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_PARTNO.TabIndex = 122;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(6, 105);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(226, 23);
            this.lbl01_PARTNO.TabIndex = 121;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "Part no";
            // 
            // lbl03_Wave
            // 
            this.lbl03_Wave.AutoSize = true;
            this.lbl03_Wave.Location = new System.Drawing.Point(110, 83);
            this.lbl03_Wave.Name = "lbl03_Wave";
            this.lbl03_Wave.Size = new System.Drawing.Size(14, 12);
            this.lbl03_Wave.TabIndex = 117;
            this.lbl03_Wave.Text = "~";
            // 
            // dtp01_PROD_EDATE
            // 
            this.dtp01_PROD_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_PROD_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_PROD_EDATE.Location = new System.Drawing.Point(130, 81);
            this.dtp01_PROD_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_PROD_EDATE.Name = "dtp01_PROD_EDATE";
            this.dtp01_PROD_EDATE.OriginalFormat = "";
            this.dtp01_PROD_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_PROD_EDATE.TabIndex = 116;
            // 
            // dtp01_PROD_SDATE
            // 
            this.dtp01_PROD_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_PROD_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_PROD_SDATE.Location = new System.Drawing.Point(6, 81);
            this.dtp01_PROD_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_PROD_SDATE.Name = "dtp01_PROD_SDATE";
            this.dtp01_PROD_SDATE.OriginalFormat = "";
            this.dtp01_PROD_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_PROD_SDATE.TabIndex = 115;
            // 
            // lbl01_STOCK_DATE
            // 
            this.lbl01_STOCK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STOCK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STOCK_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STOCK_DATE.Location = new System.Drawing.Point(6, 55);
            this.lbl01_STOCK_DATE.Name = "lbl01_STOCK_DATE";
            this.lbl01_STOCK_DATE.Size = new System.Drawing.Size(226, 23);
            this.lbl01_STOCK_DATE.TabIndex = 114;
            this.lbl01_STOCK_DATE.Tag = null;
            this.lbl01_STOCK_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_STOCK_DATE.Value = "입고일자";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 6);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(226, 23);
            this.lbl01_BIZNM2.TabIndex = 113;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(6, 32);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 112;
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
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.grd01);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(742, 736);
            this.panel4.TabIndex = 26;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 5);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 731);
            this.grd01.TabIndex = 37;
            this.grd01.UseCustomHighlight = true;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(742, 5);
            this.panel5.TabIndex = 36;
            // 
            // cdx01_PARTNO
            // 
            this.cdx01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_PARTNO.CodeParameterName = "CODE";
            this.cdx01_PARTNO.CodeTextBoxReadOnly = false;
            this.cdx01_PARTNO.CodeTextBoxVisible = true;
            this.cdx01_PARTNO.CodeTextBoxWidth = 40;
            this.cdx01_PARTNO.HEPopupHelper = null;
            this.cdx01_PARTNO.Location = new System.Drawing.Point(30, 0);
            this.cdx01_PARTNO.Name = "cdx01_PARTNO";
            this.cdx01_PARTNO.NameParameterName = "NAME";
            this.cdx01_PARTNO.NameTextBoxReadOnly = false;
            this.cdx01_PARTNO.NameTextBoxVisible = true;
            this.cdx01_PARTNO.PopupButtonReadOnly = false;
            this.cdx01_PARTNO.PopupTitle = "";
            this.cdx01_PARTNO.PrefixCode = "";
            this.cdx01_PARTNO.Size = new System.Drawing.Size(207, 21);
            this.cdx01_PARTNO.TabIndex = 36;
            this.cdx01_PARTNO.Tag = null;
            // 
            // WM40550
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cdx01_PARTNO);
            this.Name = "WM40550";
            this.Controls.SetChildIndex(this.cdx01_PARTNO, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STOCK_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Panel panel5;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_PARTNO;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private System.Windows.Forms.Label lbl03_Wave;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_PROD_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_PROD_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_STOCK_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
    }
}
