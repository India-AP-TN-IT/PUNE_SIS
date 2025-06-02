namespace Ax.SIS.PD.UI
{
    partial class PD40460
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
            this.grp01_PD40460_001 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.rdo01_LOSS = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_NORMAL_IN_QTY = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn03_INV_CLEAR = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl01_INV_STATUS = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grp01_PD40460_002 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grp01_PD40460_001.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INV_STATUS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            this.grp01_PD40460_002.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD40460_001
            // 
            this.grp01_PD40460_001.Controls.Add(this.grd01);
            this.grp01_PD40460_001.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp01_PD40460_001.Location = new System.Drawing.Point(0, 0);
            this.grp01_PD40460_001.Name = "grp01_PD40460_001";
            this.grp01_PD40460_001.Size = new System.Drawing.Size(644, 694);
            this.grp01_PD40460_001.TabIndex = 8;
            this.grp01_PD40460_001.TabStop = false;
            this.grp01_PD40460_001.Text = "자재바코드 각인이력";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(638, 674);
            this.grd01.TabIndex = 102;
            this.grd01.UseCustomHighlight = true;
            // 
            // rdo01_LOSS
            // 
            this.rdo01_LOSS.AutoSize = true;
            this.rdo01_LOSS.Location = new System.Drawing.Point(192, 15);
            this.rdo01_LOSS.Name = "rdo01_LOSS";
            this.rdo01_LOSS.Size = new System.Drawing.Size(59, 16);
            this.rdo01_LOSS.TabIndex = 101;
            this.rdo01_LOSS.Text = "손망실";
            this.rdo01_LOSS.UseVisualStyleBackColor = true;
            this.rdo01_LOSS.Click += new System.EventHandler(this.rdo01_NOMAL_QTY_Click);
            // 
            // rdo01_NORMAL_IN_QTY
            // 
            this.rdo01_NORMAL_IN_QTY.AutoSize = true;
            this.rdo01_NORMAL_IN_QTY.Location = new System.Drawing.Point(112, 15);
            this.rdo01_NORMAL_IN_QTY.Name = "rdo01_NORMAL_IN_QTY";
            this.rdo01_NORMAL_IN_QTY.Size = new System.Drawing.Size(81, 16);
            this.rdo01_NORMAL_IN_QTY.TabIndex = 100;
            this.rdo01_NORMAL_IN_QTY.Text = "정상입고 /";
            this.rdo01_NORMAL_IN_QTY.UseVisualStyleBackColor = true;
            this.rdo01_NORMAL_IN_QTY.Click += new System.EventHandler(this.rdo01_NOMAL_QTY_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo01_LOSS);
            this.groupBox1.Controls.Add(this.btn03_INV_CLEAR);
            this.groupBox1.Controls.Add(this.rdo01_NORMAL_IN_QTY);
            this.groupBox1.Controls.Add(this.lbl01_INV_STATUS);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btn03_INV_CLEAR
            // 
            this.btn03_INV_CLEAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn03_INV_CLEAR.Location = new System.Drawing.Point(943, 12);
            this.btn03_INV_CLEAR.Name = "btn03_INV_CLEAR";
            this.btn03_INV_CLEAR.Size = new System.Drawing.Size(75, 23);
            this.btn03_INV_CLEAR.TabIndex = 99;
            this.btn03_INV_CLEAR.Text = "창고초기화";
            this.btn03_INV_CLEAR.UseVisualStyleBackColor = true;
            this.btn03_INV_CLEAR.Click += new System.EventHandler(this.btn03_SAVE_Click);
            // 
            // lbl01_INV_STATUS
            // 
            this.lbl01_INV_STATUS.AutoFontSizeMaxValue = 9F;
            this.lbl01_INV_STATUS.AutoFontSizeMinValue = 9F;
            this.lbl01_INV_STATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INV_STATUS.Location = new System.Drawing.Point(6, 13);
            this.lbl01_INV_STATUS.Name = "lbl01_INV_STATUS";
            this.lbl01_INV_STATUS.Size = new System.Drawing.Size(100, 21);
            this.lbl01_INV_STATUS.TabIndex = 54;
            this.lbl01_INV_STATUS.Tag = null;
            this.lbl01_INV_STATUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INV_STATUS.Value = "재고상태";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(6, 12);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 103;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            this.lbl01_BIZNM.Visible = false;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(6, 13);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 102;
            this.cbo01_BIZCD.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grp01_PD40460_002);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.grp01_PD40460_001);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 694);
            this.panel1.TabIndex = 9;
            // 
            // grp01_PD40460_002
            // 
            this.grp01_PD40460_002.Controls.Add(this.grd02);
            this.grp01_PD40460_002.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD40460_002.Location = new System.Drawing.Point(649, 0);
            this.grp01_PD40460_002.Name = "grp01_PD40460_002";
            this.grp01_PD40460_002.Size = new System.Drawing.Size(375, 694);
            this.grp01_PD40460_002.TabIndex = 10;
            this.grp01_PD40460_002.TabStop = false;
            this.grp01_PD40460_002.Text = "P/NO별 재고수량";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(369, 674);
            this.grd02.TabIndex = 1;
            this.grd02.UseCustomHighlight = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(644, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 694);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // PD40460
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD40460";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.grp01_PD40460_001.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INV_STATUS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grp01_PD40460_002.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD40460_001;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INV_STATUS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grp01_PD40460_002;
        private System.Windows.Forms.Splitter splitter1;
        private Ax.DEV.Utility.Controls.AxButton btn03_INV_CLEAR;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_LOSS;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_NORMAL_IN_QTY;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
    }
}
