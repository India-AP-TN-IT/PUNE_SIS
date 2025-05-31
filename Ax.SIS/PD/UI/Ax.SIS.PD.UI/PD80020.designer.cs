namespace Ax.SIS.PD.UI
{
    partial class PD80020
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.grp01_PD80020_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd04 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heSplitter3 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grp01_LINECD = new System.Windows.Forms.GroupBox();
            this.btn01_SAVE = new Ax.DEV.Utility.Controls.AxButton();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heSplitter2 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.grp01_BIZCD = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.grp01_CORCD = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt01_PC_NM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_PC_IP = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PC_IP = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PC_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grp01_PD80020_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).BeginInit();
            this.panel2.SuspendLayout();
            this.grp01_LINECD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.grp01_BIZCD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.grp01_CORCD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_IP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_IP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_NM)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grp01_PD80020_GRP_1);
            this.panel3.Controls.Add(this.heSplitter3);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 687);
            this.panel3.TabIndex = 6;
            // 
            // grp01_PD80020_GRP_1
            // 
            this.grp01_PD80020_GRP_1.Controls.Add(this.grd04);
            this.grp01_PD80020_GRP_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD80020_GRP_1.Location = new System.Drawing.Point(358, 0);
            this.grp01_PD80020_GRP_1.Name = "grp01_PD80020_GRP_1";
            this.grp01_PD80020_GRP_1.Size = new System.Drawing.Size(666, 687);
            this.grp01_PD80020_GRP_1.TabIndex = 32;
            this.grp01_PD80020_GRP_1.TabStop = false;
            this.grp01_PD80020_GRP_1.Text = "공정용 PC 마스터";
            // 
            // grd04
            // 
            this.grd04.AllowHeaderMerging = false;
            this.grd04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd04.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd04.EnabledActionFlag = true;
            this.grd04.LastRowAdd = false;
            this.grd04.Location = new System.Drawing.Point(3, 17);
            this.grd04.Name = "grd04";
            this.grd04.OriginalFormat = null;
            this.grd04.PopMenuVisible = true;
            this.grd04.Rows.DefaultSize = 18;
            this.grd04.Size = new System.Drawing.Size(660, 667);
            this.grd04.TabIndex = 3;
            this.grd04.UseCustomHighlight = true;
            this.grd04.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd04_RowInserted);
            this.grd04.RowColChange += new System.EventHandler(this.grd04_RowColChange);
            this.grd04.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd04_BeforeEdit);
            this.grd04.SetupEditor += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd04_SetupEditor);
            // 
            // heSplitter3
            // 
            this.heSplitter3.Location = new System.Drawing.Point(354, 0);
            this.heSplitter3.Name = "heSplitter3";
            this.heSplitter3.Size = new System.Drawing.Size(4, 687);
            this.heSplitter3.TabIndex = 31;
            this.heSplitter3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grp01_LINECD);
            this.panel2.Controls.Add(this.heSplitter2);
            this.panel2.Controls.Add(this.grp01_BIZCD);
            this.panel2.Controls.Add(this.heSplitter1);
            this.panel2.Controls.Add(this.grp01_CORCD);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 687);
            this.panel2.TabIndex = 30;
            // 
            // grp01_LINECD
            // 
            this.grp01_LINECD.Controls.Add(this.btn01_SAVE);
            this.grp01_LINECD.Controls.Add(this.grd03);
            this.grp01_LINECD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_LINECD.Location = new System.Drawing.Point(0, 350);
            this.grp01_LINECD.Name = "grp01_LINECD";
            this.grp01_LINECD.Size = new System.Drawing.Size(354, 337);
            this.grp01_LINECD.TabIndex = 30;
            this.grp01_LINECD.TabStop = false;
            this.grp01_LINECD.Text = "라인코드";
            // 
            // btn01_SAVE
            // 
            this.btn01_SAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_SAVE.Location = new System.Drawing.Point(273, 15);
            this.btn01_SAVE.Name = "btn01_SAVE";
            this.btn01_SAVE.Size = new System.Drawing.Size(75, 23);
            this.btn01_SAVE.TabIndex = 99;
            this.btn01_SAVE.Text = "저장";
            this.btn01_SAVE.UseVisualStyleBackColor = true;
            this.btn01_SAVE.Click += new System.EventHandler(this.btn01_SAVE_Click);
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.EnabledActionFlag = true;
            this.grd03.ExtendLastCol = true;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 44);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(348, 290);
            this.grd03.TabIndex = 1;
            this.grd03.UseCustomHighlight = true;
            this.grd03.RowColChange += new System.EventHandler(this.grd03_RowColChange);
            this.grd03.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd03_MouseDoubleClick);
            // 
            // heSplitter2
            // 
            this.heSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.heSplitter2.Location = new System.Drawing.Point(0, 346);
            this.heSplitter2.Name = "heSplitter2";
            this.heSplitter2.Size = new System.Drawing.Size(354, 4);
            this.heSplitter2.TabIndex = 29;
            this.heSplitter2.TabStop = false;
            // 
            // grp01_BIZCD
            // 
            this.grp01_BIZCD.Controls.Add(this.grd02);
            this.grp01_BIZCD.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_BIZCD.Location = new System.Drawing.Point(0, 161);
            this.grp01_BIZCD.Name = "grp01_BIZCD";
            this.grp01_BIZCD.Size = new System.Drawing.Size(354, 185);
            this.grp01_BIZCD.TabIndex = 28;
            this.grp01_BIZCD.TabStop = false;
            this.grp01_BIZCD.Text = "사업장코드";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(348, 165);
            this.grd02.TabIndex = 0;
            this.grd02.UseCustomHighlight = true;
            this.grd02.RowColChange += new System.EventHandler(this.grd02_RowColChange);
            this.grd02.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseDoubleClick);
            // 
            // heSplitter1
            // 
            this.heSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.heSplitter1.Location = new System.Drawing.Point(0, 157);
            this.heSplitter1.Name = "heSplitter1";
            this.heSplitter1.Size = new System.Drawing.Size(354, 4);
            this.heSplitter1.TabIndex = 25;
            this.heSplitter1.TabStop = false;
            // 
            // grp01_CORCD
            // 
            this.grp01_CORCD.Controls.Add(this.grd01);
            this.grp01_CORCD.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_CORCD.Location = new System.Drawing.Point(0, 0);
            this.grp01_CORCD.Name = "grp01_CORCD";
            this.grp01_CORCD.Size = new System.Drawing.Size(354, 157);
            this.grp01_CORCD.TabIndex = 24;
            this.grp01_CORCD.TabStop = false;
            this.grp01_CORCD.Text = "법인코드";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(348, 137);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowColChange += new System.EventHandler(this.grd01_RowColChange);
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt01_PC_NM);
            this.groupBox1.Controls.Add(this.txt01_PC_IP);
            this.groupBox1.Controls.Add(this.lbl01_PC_IP);
            this.groupBox1.Controls.Add(this.lbl01_PC_NM);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txt01_PC_NM
            // 
            this.txt01_PC_NM.Location = new System.Drawing.Point(112, 17);
            this.txt01_PC_NM.Name = "txt01_PC_NM";
            this.txt01_PC_NM.Size = new System.Drawing.Size(163, 21);
            this.txt01_PC_NM.TabIndex = 98;
            this.txt01_PC_NM.Tag = null;
            // 
            // txt01_PC_IP
            // 
            this.txt01_PC_IP.Location = new System.Drawing.Point(387, 17);
            this.txt01_PC_IP.Name = "txt01_PC_IP";
            this.txt01_PC_IP.Size = new System.Drawing.Size(163, 21);
            this.txt01_PC_IP.TabIndex = 97;
            this.txt01_PC_IP.Tag = null;
            // 
            // lbl01_PC_IP
            // 
            this.lbl01_PC_IP.AutoFontSizeMaxValue = 9F;
            this.lbl01_PC_IP.AutoFontSizeMinValue = 9F;
            this.lbl01_PC_IP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PC_IP.Location = new System.Drawing.Point(281, 17);
            this.lbl01_PC_IP.Name = "lbl01_PC_IP";
            this.lbl01_PC_IP.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PC_IP.TabIndex = 96;
            this.lbl01_PC_IP.Tag = null;
            this.lbl01_PC_IP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PC_IP.Value = "컴퓨터 IP(%)";
            // 
            // lbl01_PC_NM
            // 
            this.lbl01_PC_NM.AutoFontSizeMaxValue = 9F;
            this.lbl01_PC_NM.AutoFontSizeMinValue = 9F;
            this.lbl01_PC_NM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PC_NM.Location = new System.Drawing.Point(6, 17);
            this.lbl01_PC_NM.Name = "lbl01_PC_NM";
            this.lbl01_PC_NM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PC_NM.TabIndex = 95;
            this.lbl01_PC_NM.Tag = null;
            this.lbl01_PC_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PC_NM.Value = "컴퓨터 명";
            // 
            // PD80020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "PD80020";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grp01_PD80020_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd04)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grp01_LINECD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.grp01_BIZCD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.grp01_CORCD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_IP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_IP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_NM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grp01_PD80020_GRP_1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd04;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grp01_LINECD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter2;
        private System.Windows.Forms.GroupBox grp01_BIZCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter1;
        private System.Windows.Forms.GroupBox grp01_CORCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PC_NM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PC_IP;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PC_IP;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PC_NM;
        private Ax.DEV.Utility.Controls.AxButton btn01_SAVE;






    }
}
