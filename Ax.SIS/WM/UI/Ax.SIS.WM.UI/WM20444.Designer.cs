namespace Ax.SIS.WM.UI
{
    partial class WM20444
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
            this.grd01_INSPEC_INFO = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_CHYN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CHYN = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_POSITION = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_POSITION = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_MANAGER = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_MANAGER = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_DEVICENM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_DEVICENM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MAC = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_MAC = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grd01_INSPEC_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CHYN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_POSITION)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MANAGER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MANAGER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEVICENM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DEVICENM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MAC)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1377, 34);
            // 
            // grd01_INSPEC_INFO
            // 
            this.grd01_INSPEC_INFO.Controls.Add(this.grd01);
            this.grd01_INSPEC_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_INSPEC_INFO.Location = new System.Drawing.Point(0, 74);
            this.grd01_INSPEC_INFO.Name = "grd01_INSPEC_INFO";
            this.grd01_INSPEC_INFO.Size = new System.Drawing.Size(1377, 694);
            this.grd01_INSPEC_INFO.TabIndex = 8;
            this.grd01_INSPEC_INFO.TabStop = false;
            this.grd01_INSPEC_INFO.Text = "Location Master";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1371, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_CHYN);
            this.groupBox1.Controls.Add(this.lbl01_CHYN);
            this.groupBox1.Controls.Add(this.cbo01_POSITION);
            this.groupBox1.Controls.Add(this.lbl01_POSITION);
            this.groupBox1.Controls.Add(this.lbl01_MANAGER);
            this.groupBox1.Controls.Add(this.txt01_MANAGER);
            this.groupBox1.Controls.Add(this.lbl01_DEVICENM);
            this.groupBox1.Controls.Add(this.txt01_DEVICENM);
            this.groupBox1.Controls.Add(this.lbl01_MAC);
            this.groupBox1.Controls.Add(this.txt01_MAC);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1377, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_CHYN
            // 
            this.cbo01_CHYN.DisplayMember = "Y";
            this.cbo01_CHYN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CHYN.FormattingEnabled = true;
            this.cbo01_CHYN.Location = new System.Drawing.Point(879, 13);
            this.cbo01_CHYN.Name = "cbo01_CHYN";
            this.cbo01_CHYN.Size = new System.Drawing.Size(42, 20);
            this.cbo01_CHYN.TabIndex = 101;
            // 
            // lbl01_CHYN
            // 
            this.lbl01_CHYN.AutoFontSizeMaxValue = 9F;
            this.lbl01_CHYN.AutoFontSizeMinValue = 9F;
            this.lbl01_CHYN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CHYN.Location = new System.Drawing.Point(775, 13);
            this.lbl01_CHYN.Name = "lbl01_CHYN";
            this.lbl01_CHYN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CHYN.TabIndex = 100;
            this.lbl01_CHYN.Tag = null;
            this.lbl01_CHYN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CHYN.Value = "Charging YN";
            // 
            // cbo01_POSITION
            // 
            this.cbo01_POSITION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_POSITION.FormattingEnabled = true;
            this.cbo01_POSITION.Location = new System.Drawing.Point(701, 13);
            this.cbo01_POSITION.Name = "cbo01_POSITION";
            this.cbo01_POSITION.Size = new System.Drawing.Size(66, 20);
            this.cbo01_POSITION.TabIndex = 99;
            // 
            // lbl01_POSITION
            // 
            this.lbl01_POSITION.AutoFontSizeMaxValue = 9F;
            this.lbl01_POSITION.AutoFontSizeMinValue = 9F;
            this.lbl01_POSITION.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_POSITION.Location = new System.Drawing.Point(595, 13);
            this.lbl01_POSITION.Name = "lbl01_POSITION";
            this.lbl01_POSITION.Size = new System.Drawing.Size(102, 21);
            this.lbl01_POSITION.TabIndex = 98;
            this.lbl01_POSITION.Tag = null;
            this.lbl01_POSITION.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_POSITION.Value = "Position";
            // 
            // lbl01_MANAGER
            // 
            this.lbl01_MANAGER.AutoFontSizeMaxValue = 9F;
            this.lbl01_MANAGER.AutoFontSizeMinValue = 9F;
            this.lbl01_MANAGER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MANAGER.Location = new System.Drawing.Point(414, 13);
            this.lbl01_MANAGER.Name = "lbl01_MANAGER";
            this.lbl01_MANAGER.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MANAGER.TabIndex = 69;
            this.lbl01_MANAGER.Tag = null;
            this.lbl01_MANAGER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MANAGER.Value = "Manager";
            // 
            // txt01_MANAGER
            // 
            this.txt01_MANAGER.Location = new System.Drawing.Point(518, 13);
            this.txt01_MANAGER.Name = "txt01_MANAGER";
            this.txt01_MANAGER.Size = new System.Drawing.Size(69, 21);
            this.txt01_MANAGER.TabIndex = 68;
            this.txt01_MANAGER.Tag = null;
            this.txt01_MANAGER.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // lbl01_DEVICENM
            // 
            this.lbl01_DEVICENM.AutoFontSizeMaxValue = 9F;
            this.lbl01_DEVICENM.AutoFontSizeMinValue = 9F;
            this.lbl01_DEVICENM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DEVICENM.Location = new System.Drawing.Point(210, 13);
            this.lbl01_DEVICENM.Name = "lbl01_DEVICENM";
            this.lbl01_DEVICENM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_DEVICENM.TabIndex = 69;
            this.lbl01_DEVICENM.Tag = null;
            this.lbl01_DEVICENM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DEVICENM.Value = "Device Name";
            // 
            // txt01_DEVICENM
            // 
            this.txt01_DEVICENM.Location = new System.Drawing.Point(314, 13);
            this.txt01_DEVICENM.Name = "txt01_DEVICENM";
            this.txt01_DEVICENM.Size = new System.Drawing.Size(92, 21);
            this.txt01_DEVICENM.TabIndex = 68;
            this.txt01_DEVICENM.Tag = null;
            this.txt01_DEVICENM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // lbl01_MAC
            // 
            this.lbl01_MAC.AutoFontSizeMaxValue = 9F;
            this.lbl01_MAC.AutoFontSizeMinValue = 9F;
            this.lbl01_MAC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MAC.Location = new System.Drawing.Point(6, 13);
            this.lbl01_MAC.Name = "lbl01_MAC";
            this.lbl01_MAC.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MAC.TabIndex = 69;
            this.lbl01_MAC.Tag = null;
            this.lbl01_MAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MAC.Value = "Mac Address";
            // 
            // txt01_MAC
            // 
            this.txt01_MAC.Location = new System.Drawing.Point(110, 13);
            this.txt01_MAC.Name = "txt01_MAC";
            this.txt01_MAC.Size = new System.Drawing.Size(92, 21);
            this.txt01_MAC.TabIndex = 68;
            this.txt01_MAC.Tag = null;
            this.txt01_MAC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // WM20444
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01_INSPEC_INFO);
            this.Controls.Add(this.groupBox1);
            this.Name = "WM20444";
            this.Size = new System.Drawing.Size(1377, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01_INSPEC_INFO, 0);
            this.grd01_INSPEC_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CHYN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_POSITION)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MANAGER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MANAGER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEVICENM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DEVICENM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MAC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grd01_INSPEC_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_MAC;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MAC;
        private DEV.Utility.Controls.AxComboBox cbo01_POSITION;
        private DEV.Utility.Controls.AxLabel lbl01_POSITION;
        private DEV.Utility.Controls.AxComboBox cbo01_CHYN;
        private DEV.Utility.Controls.AxLabel lbl01_CHYN;
        private DEV.Utility.Controls.AxLabel lbl01_MANAGER;
        private DEV.Utility.Controls.AxTextBox txt01_MANAGER;
        private DEV.Utility.Controls.AxLabel lbl01_DEVICENM;
        private DEV.Utility.Controls.AxTextBox txt01_DEVICENM;        
    }
}
