namespace Ax.SIS.PD.UI
{
    partial class PD80030
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
            this.grp01_PD80010_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heSplitter2 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.grp01_PD80010_GRP_2 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.grp01_PD80030 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn01_COPY = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_CopyIP = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CopyIP = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LINECD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PC_NM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_PC_IP = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PC_IP = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PC_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1.SuspendLayout();
            this.grp01_PD80010_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.grp01_PD80010_GRP_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.grp01_PD80030.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CopyIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CopyIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_IP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_IP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_NM)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1210, 34);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.grp01_PD80010_GRP_1);
            this.panel1.Controls.Add(this.heSplitter2);
            this.panel1.Controls.Add(this.grp01_PD80010_GRP_2);
            this.panel1.Controls.Add(this.heSplitter1);
            this.panel1.Controls.Add(this.grp01_PD80030);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 734);
            this.panel1.TabIndex = 1;
            // 
            // grp01_PD80010_GRP_1
            // 
            this.grp01_PD80010_GRP_1.Controls.Add(this.grd03);
            this.grp01_PD80010_GRP_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD80010_GRP_1.Location = new System.Drawing.Point(736, 304);
            this.grp01_PD80010_GRP_1.Name = "grp01_PD80010_GRP_1";
            this.grp01_PD80010_GRP_1.Size = new System.Drawing.Size(474, 430);
            this.grp01_PD80010_GRP_1.TabIndex = 32;
            this.grp01_PD80010_GRP_1.TabStop = false;
            this.grp01_PD80010_GRP_1.Text = "INI 키 마스터 ";
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03.EnabledActionFlag = true;
            this.grd03.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 17);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(468, 410);
            this.grd03.TabIndex = 1;
            this.grd03.UseCustomHighlight = true;
            this.grd03.RowColChange += new System.EventHandler(this.grd03_RowColChange);
            // 
            // heSplitter2
            // 
            this.heSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.heSplitter2.Location = new System.Drawing.Point(736, 300);
            this.heSplitter2.Name = "heSplitter2";
            this.heSplitter2.Size = new System.Drawing.Size(474, 4);
            this.heSplitter2.TabIndex = 30;
            this.heSplitter2.TabStop = false;
            // 
            // grp01_PD80010_GRP_2
            // 
            this.grp01_PD80010_GRP_2.Controls.Add(this.grd02);
            this.grp01_PD80010_GRP_2.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_PD80010_GRP_2.Location = new System.Drawing.Point(736, 51);
            this.grp01_PD80010_GRP_2.Name = "grp01_PD80010_GRP_2";
            this.grp01_PD80010_GRP_2.Size = new System.Drawing.Size(474, 249);
            this.grp01_PD80010_GRP_2.TabIndex = 29;
            this.grp01_PD80010_GRP_2.TabStop = false;
            this.grp01_PD80010_GRP_2.Text = "INI 섹션 마스터";
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
            this.grd02.Size = new System.Drawing.Size(468, 229);
            this.grd02.TabIndex = 0;
            this.grd02.UseCustomHighlight = true;
            this.grd02.RowColChange += new System.EventHandler(this.grd02_RowColChange);
            this.grd02.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseDoubleClick);
            // 
            // heSplitter1
            // 
            this.heSplitter1.Location = new System.Drawing.Point(732, 51);
            this.heSplitter1.Name = "heSplitter1";
            this.heSplitter1.Size = new System.Drawing.Size(4, 683);
            this.heSplitter1.TabIndex = 26;
            this.heSplitter1.TabStop = false;
            // 
            // grp01_PD80030
            // 
            this.grp01_PD80030.Controls.Add(this.grd01);
            this.grp01_PD80030.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp01_PD80030.Location = new System.Drawing.Point(0, 51);
            this.grp01_PD80030.Name = "grp01_PD80030";
            this.grp01_PD80030.Size = new System.Drawing.Size(732, 683);
            this.grp01_PD80030.TabIndex = 25;
            this.grp01_PD80030.TabStop = false;
            this.grp01_PD80030.Text = "공정용 PC INI 관리";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(726, 663);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowColChange += new System.EventHandler(this.grd01_RowColChange);
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn01_COPY);
            this.groupBox1.Controls.Add(this.txt01_CopyIP);
            this.groupBox1.Controls.Add(this.lbl01_CopyIP);
            this.groupBox1.Controls.Add(this.txt01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_LINECD);
            this.groupBox1.Controls.Add(this.txt01_PC_NM);
            this.groupBox1.Controls.Add(this.txt01_PC_IP);
            this.groupBox1.Controls.Add(this.lbl01_PC_IP);
            this.groupBox1.Controls.Add(this.lbl01_PC_NM);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1210, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn01_COPY
            // 
            this.btn01_COPY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_COPY.Location = new System.Drawing.Point(1129, 16);
            this.btn01_COPY.Name = "btn01_COPY";
            this.btn01_COPY.Size = new System.Drawing.Size(75, 23);
            this.btn01_COPY.TabIndex = 108;
            this.btn01_COPY.Text = "COPY";
            this.btn01_COPY.UseVisualStyleBackColor = true;
            this.btn01_COPY.Click += new System.EventHandler(this.btn01_COPY_Click);
            // 
            // txt01_CopyIP
            // 
            this.txt01_CopyIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_CopyIP.Location = new System.Drawing.Point(986, 17);
            this.txt01_CopyIP.Name = "txt01_CopyIP";
            this.txt01_CopyIP.Size = new System.Drawing.Size(138, 21);
            this.txt01_CopyIP.TabIndex = 107;
            this.txt01_CopyIP.Tag = null;
            this.txt01_CopyIP.Value = "";
            // 
            // lbl01_CopyIP
            // 
            this.lbl01_CopyIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_CopyIP.AutoFontSizeMaxValue = 9F;
            this.lbl01_CopyIP.AutoFontSizeMinValue = 9F;
            this.lbl01_CopyIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CopyIP.Location = new System.Drawing.Point(883, 17);
            this.lbl01_CopyIP.Name = "lbl01_CopyIP";
            this.lbl01_CopyIP.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CopyIP.TabIndex = 106;
            this.lbl01_CopyIP.Tag = null;
            this.lbl01_CopyIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CopyIP.Value = "Copy IP";
            // 
            // txt01_LINECD
            // 
            this.txt01_LINECD.Location = new System.Drawing.Point(662, 17);
            this.txt01_LINECD.Name = "txt01_LINECD";
            this.txt01_LINECD.Size = new System.Drawing.Size(163, 21);
            this.txt01_LINECD.TabIndex = 104;
            this.txt01_LINECD.Tag = null;
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(556, 17);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINECD.TabIndex = 103;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "라인코드";
            // 
            // txt01_PC_NM
            // 
            this.txt01_PC_NM.Location = new System.Drawing.Point(112, 17);
            this.txt01_PC_NM.Name = "txt01_PC_NM";
            this.txt01_PC_NM.Size = new System.Drawing.Size(163, 21);
            this.txt01_PC_NM.TabIndex = 102;
            this.txt01_PC_NM.Tag = null;
            // 
            // txt01_PC_IP
            // 
            this.txt01_PC_IP.Location = new System.Drawing.Point(387, 17);
            this.txt01_PC_IP.Name = "txt01_PC_IP";
            this.txt01_PC_IP.Size = new System.Drawing.Size(163, 21);
            this.txt01_PC_IP.TabIndex = 101;
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
            this.lbl01_PC_IP.TabIndex = 100;
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
            this.lbl01_PC_NM.TabIndex = 99;
            this.lbl01_PC_NM.Tag = null;
            this.lbl01_PC_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PC_NM.Value = "컴퓨터명";
            // 
            // PD80030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "PD80030";
            this.Size = new System.Drawing.Size(1210, 768);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.panel1.ResumeLayout(false);
            this.grp01_PD80010_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.grp01_PD80010_GRP_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.grp01_PD80030.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CopyIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CopyIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_IP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_IP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_NM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PC_NM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PC_IP;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PC_IP;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PC_NM;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter1;
        private System.Windows.Forms.GroupBox grp01_PD80030;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox grp01_PD80010_GRP_2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter2;
        private System.Windows.Forms.GroupBox grp01_PD80010_GRP_1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxButton btn01_COPY;
        private DEV.Utility.Controls.AxTextBox txt01_CopyIP;
        private DEV.Utility.Controls.AxLabel lbl01_CopyIP;





    }
}
