namespace Ax.SIS.PD.UI
{
    partial class PD30202
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpg01 = new System.Windows.Forms.TabPage();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tpg02 = new System.Windows.Forms.TabPage();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tpg03 = new System.Windows.Forms.TabPage();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_PAC = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PAC = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_PGN = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PGN = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_PLAN_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_PLAN_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grd04 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpg01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.tpg02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.tpg03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLAN_DATE)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).BeginInit();
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
            this.panelMain.Controls.Add(this.tabControl1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1242, 675);
            this.panelMain.TabIndex = 56;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpg01);
            this.tabControl1.Controls.Add(this.tpg02);
            this.tabControl1.Controls.Add(this.tpg03);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1242, 675);
            this.tabControl1.TabIndex = 1;
            // 
            // tpg01
            // 
            this.tpg01.Controls.Add(this.grd01);
            this.tpg01.Location = new System.Drawing.Point(4, 22);
            this.tpg01.Name = "tpg01";
            this.tpg01.Size = new System.Drawing.Size(1234, 649);
            this.tpg01.TabIndex = 0;
            this.tpg01.Text = "Cust Plan";
            this.tpg01.UseVisualStyleBackColor = true;
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
            this.grd01.Size = new System.Drawing.Size(1234, 649);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            // 
            // tpg02
            // 
            this.tpg02.Controls.Add(this.grd02);
            this.tpg02.Location = new System.Drawing.Point(4, 22);
            this.tpg02.Name = "tpg02";
            this.tpg02.Size = new System.Drawing.Size(1234, 649);
            this.tpg02.TabIndex = 1;
            this.tpg02.Text = "Our Plan";
            this.tpg02.UseVisualStyleBackColor = true;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(1234, 649);
            this.grd02.TabIndex = 1;
            this.grd02.UseCustomHighlight = true;
            // 
            // tpg03
            // 
            this.tpg03.Controls.Add(this.grd03);
            this.tpg03.Location = new System.Drawing.Point(4, 22);
            this.tpg03.Name = "tpg03";
            this.tpg03.Padding = new System.Windows.Forms.Padding(3);
            this.tpg03.Size = new System.Drawing.Size(1234, 649);
            this.tpg03.TabIndex = 2;
            this.tpg03.Text = "Rare Item Order";
            this.tpg03.UseVisualStyleBackColor = true;
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03.EnabledActionFlag = true;
            this.grd03.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 3);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(1228, 643);
            this.grd03.TabIndex = 2;
            this.grd03.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_PAC);
            this.groupBox1.Controls.Add(this.txt01_PAC);
            this.groupBox1.Controls.Add(this.txt01_PGN);
            this.groupBox1.Controls.Add(this.txt01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_PGN);
            this.groupBox1.Controls.Add(this.dte01_PLAN_DATE);
            this.groupBox1.Controls.Add(this.lbl01_PLAN_DATE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1242, 59);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_PAC
            // 
            this.lbl01_PAC.AutoFontSizeMaxValue = 9F;
            this.lbl01_PAC.AutoFontSizeMinValue = 9F;
            this.lbl01_PAC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PAC.Location = new System.Drawing.Point(441, 22);
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
            this.txt01_PAC.Location = new System.Drawing.Point(547, 22);
            this.txt01_PAC.Name = "txt01_PAC";
            this.txt01_PAC.Size = new System.Drawing.Size(100, 21);
            this.txt01_PAC.TabIndex = 42;
            this.txt01_PAC.Tag = null;
            // 
            // txt01_PGN
            // 
            this.txt01_PGN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PGN.Location = new System.Drawing.Point(333, 22);
            this.txt01_PGN.Name = "txt01_PGN";
            this.txt01_PGN.Size = new System.Drawing.Size(100, 21);
            this.txt01_PGN.TabIndex = 42;
            this.txt01_PGN.Tag = null;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(760, 22);
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
            this.lbl01_PARTNO.Location = new System.Drawing.Point(655, 22);
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
            this.lbl01_PGN.Location = new System.Drawing.Point(227, 22);
            this.lbl01_PGN.Name = "lbl01_PGN";
            this.lbl01_PGN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PGN.TabIndex = 10;
            this.lbl01_PGN.Tag = null;
            this.lbl01_PGN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PGN.Value = "PGN";
            // 
            // dte01_PLAN_DATE
            // 
            this.dte01_PLAN_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_PLAN_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_PLAN_DATE.Location = new System.Drawing.Point(117, 22);
            this.dte01_PLAN_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_PLAN_DATE.Name = "dte01_PLAN_DATE";
            this.dte01_PLAN_DATE.OriginalFormat = "";
            this.dte01_PLAN_DATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_PLAN_DATE.TabIndex = 6;
            // 
            // lbl01_PLAN_DATE
            // 
            this.lbl01_PLAN_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLAN_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_PLAN_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PLAN_DATE.Location = new System.Drawing.Point(11, 22);
            this.lbl01_PLAN_DATE.Name = "lbl01_PLAN_DATE";
            this.lbl01_PLAN_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PLAN_DATE.TabIndex = 2;
            this.lbl01_PLAN_DATE.Tag = null;
            this.lbl01_PLAN_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PLAN_DATE.Value = "PLAN DATE";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grd04);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1234, 649);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Webportal Plan/Sequencing DIFF";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grd04
            // 
            this.grd04.AllowHeaderMerging = false;
            this.grd04.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd04.EnabledActionFlag = true;
            this.grd04.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd04.LastRowAdd = false;
            this.grd04.Location = new System.Drawing.Point(3, 3);
            this.grd04.Name = "grd04";
            this.grd04.OriginalFormat = null;
            this.grd04.PopMenuVisible = true;
            this.grd04.Rows.DefaultSize = 18;
            this.grd04.Size = new System.Drawing.Size(1228, 643);
            this.grd04.TabIndex = 3;
            this.grd04.UseCustomHighlight = true;
            // 
            // PD30202
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD30202";
            this.Size = new System.Drawing.Size(1242, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpg01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.tpg02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.tpg03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLAN_DATE)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog sfdExcel;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxLabel lbl01_PAC;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PGN;
        private DEV.Utility.Controls.AxDateEdit dte01_PLAN_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_PLAN_DATE;
        private DEV.Utility.Controls.AxTextBox txt01_PAC;
        private DEV.Utility.Controls.AxTextBox txt01_PGN;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpg01;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.TabPage tpg02;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.TabPage tpg03;
        private DEV.Utility.Controls.AxFlexGrid grd03;
        private System.Windows.Forms.TabPage tabPage1;
        private DEV.Utility.Controls.AxFlexGrid grd04;
    }
}
