namespace Ax.SIS.BM.BM00.UI
{
    partial class BM30302
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
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk01_DATE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.btn01_FILE_UPLOAD2 = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl01_PAC = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PAC = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_PGN = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PGN = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_EO_EFF_IN = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_EO_EFF_IN = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EO_EFF_IN)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1242, 34);
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel 97 - 2003 통합 문서|*.xls|Excel 통합 문서|*.xlsx";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1242, 675);
            this.panel2.TabIndex = 9;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.grd01);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1242, 675);
            this.panelMain.TabIndex = 56;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1242, 675);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk01_DATE);
            this.groupBox1.Controls.Add(this.btn01_FILE_UPLOAD2);
            this.groupBox1.Controls.Add(this.lbl01_PAC);
            this.groupBox1.Controls.Add(this.txt01_PAC);
            this.groupBox1.Controls.Add(this.txt01_PGN);
            this.groupBox1.Controls.Add(this.txt01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_PGN);
            this.groupBox1.Controls.Add(this.dte01_EO_EFF_IN);
            this.groupBox1.Controls.Add(this.lbl01_EO_EFF_IN);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1242, 59);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // chk01_DATE
            // 
            this.chk01_DATE.AutoSize = true;
            this.chk01_DATE.Location = new System.Drawing.Point(661, 28);
            this.chk01_DATE.Name = "chk01_DATE";
            this.chk01_DATE.Size = new System.Drawing.Size(15, 14);
            this.chk01_DATE.TabIndex = 49;
            this.chk01_DATE.UseVisualStyleBackColor = true;
            this.chk01_DATE.Visible = false;
            // 
            // btn01_FILE_UPLOAD2
            // 
            this.btn01_FILE_UPLOAD2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_FILE_UPLOAD2.Location = new System.Drawing.Point(1097, 21);
            this.btn01_FILE_UPLOAD2.Name = "btn01_FILE_UPLOAD2";
            this.btn01_FILE_UPLOAD2.Size = new System.Drawing.Size(139, 23);
            this.btn01_FILE_UPLOAD2.TabIndex = 48;
            this.btn01_FILE_UPLOAD2.Text = "EXCEL LOAD";
            this.btn01_FILE_UPLOAD2.UseVisualStyleBackColor = true;
            this.btn01_FILE_UPLOAD2.Click += new System.EventHandler(this.btn01_FILE_UPLOAD2_Click);
            // 
            // lbl01_PAC
            // 
            this.lbl01_PAC.AutoFontSizeMaxValue = 9F;
            this.lbl01_PAC.AutoFontSizeMinValue = 9F;
            this.lbl01_PAC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PAC.Location = new System.Drawing.Point(225, 22);
            this.lbl01_PAC.Name = "lbl01_PAC";
            this.lbl01_PAC.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PAC.TabIndex = 45;
            this.lbl01_PAC.Tag = null;
            this.lbl01_PAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PAC.Value = "PAC";
            // 
            // txt01_PAC
            // 
            this.txt01_PAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PAC.Location = new System.Drawing.Point(331, 22);
            this.txt01_PAC.Name = "txt01_PAC";
            this.txt01_PAC.Size = new System.Drawing.Size(100, 21);
            this.txt01_PAC.TabIndex = 42;
            this.txt01_PAC.Tag = null;
            // 
            // txt01_PGN
            // 
            this.txt01_PGN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PGN.Location = new System.Drawing.Point(117, 22);
            this.txt01_PGN.Name = "txt01_PGN";
            this.txt01_PGN.Size = new System.Drawing.Size(100, 21);
            this.txt01_PGN.TabIndex = 42;
            this.txt01_PGN.Tag = null;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(544, 22);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(100, 21);
            this.txt01_PARTNO.TabIndex = 42;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(439, 22);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PARTNO.TabIndex = 41;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "PART NO";
            // 
            // lbl01_PGN
            // 
            this.lbl01_PGN.AutoFontSizeMaxValue = 9F;
            this.lbl01_PGN.AutoFontSizeMinValue = 9F;
            this.lbl01_PGN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PGN.Location = new System.Drawing.Point(11, 22);
            this.lbl01_PGN.Name = "lbl01_PGN";
            this.lbl01_PGN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PGN.TabIndex = 10;
            this.lbl01_PGN.Tag = null;
            this.lbl01_PGN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PGN.Value = "PGN";
            // 
            // dte01_EO_EFF_IN
            // 
            this.dte01_EO_EFF_IN.CustomFormat = "yyyy-MM-dd";
            this.dte01_EO_EFF_IN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_EO_EFF_IN.Location = new System.Drawing.Point(786, 21);
            this.dte01_EO_EFF_IN.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_EO_EFF_IN.Name = "dte01_EO_EFF_IN";
            this.dte01_EO_EFF_IN.OriginalFormat = "";
            this.dte01_EO_EFF_IN.Size = new System.Drawing.Size(100, 21);
            this.dte01_EO_EFF_IN.TabIndex = 6;
            this.dte01_EO_EFF_IN.Visible = false;
            // 
            // lbl01_EO_EFF_IN
            // 
            this.lbl01_EO_EFF_IN.AutoFontSizeMaxValue = 9F;
            this.lbl01_EO_EFF_IN.AutoFontSizeMinValue = 9F;
            this.lbl01_EO_EFF_IN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EO_EFF_IN.Location = new System.Drawing.Point(680, 21);
            this.lbl01_EO_EFF_IN.Name = "lbl01_EO_EFF_IN";
            this.lbl01_EO_EFF_IN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_EO_EFF_IN.TabIndex = 2;
            this.lbl01_EO_EFF_IN.Tag = null;
            this.lbl01_EO_EFF_IN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EO_EFF_IN.Value = "EFF DATE - IN";
            this.lbl01_EO_EFF_IN.Visible = false;
            // 
            // BM30302
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BM30302";
            this.Size = new System.Drawing.Size(1242, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EO_EFF_IN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog sfdExcel;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMain;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxButton btn01_FILE_UPLOAD2;
        private DEV.Utility.Controls.AxLabel lbl01_PAC;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PGN;
        private DEV.Utility.Controls.AxDateEdit dte01_EO_EFF_IN;
        private DEV.Utility.Controls.AxLabel lbl01_EO_EFF_IN;
        private DEV.Utility.Controls.AxTextBox txt01_PAC;
        private DEV.Utility.Controls.AxTextBox txt01_PGN;
        private DEV.Utility.Controls.AxCheckBox chk01_DATE;
    }
}
