namespace Ax.SIS.WM.UI
{
    partial class WM20441
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
            this.cbo01_WHCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_WHCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_AREANM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo01_USE_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_AREACD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_AREACD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_USE_YN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_AREANM = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01_INSPEC_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WHCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_AREANM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREACD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_AREACD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USE_YN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREANM)).BeginInit();
            this.SuspendLayout();
            // 
            // grd01_INSPEC_INFO
            // 
            this.grd01_INSPEC_INFO.Controls.Add(this.grd01);
            this.grd01_INSPEC_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_INSPEC_INFO.Location = new System.Drawing.Point(0, 74);
            this.grd01_INSPEC_INFO.Name = "grd01_INSPEC_INFO";
            this.grd01_INSPEC_INFO.Size = new System.Drawing.Size(1024, 694);
            this.grd01_INSPEC_INFO.TabIndex = 8;
            this.grd01_INSPEC_INFO.TabStop = false;
            this.grd01_INSPEC_INFO.Text = "Area Master";
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
            this.grd01.Size = new System.Drawing.Size(1018, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_CellChanged);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_WHCD);
            this.groupBox1.Controls.Add(this.lbl01_WHCD);
            this.groupBox1.Controls.Add(this.txt01_AREANM);
            this.groupBox1.Controls.Add(this.cbo01_USE_YN);
            this.groupBox1.Controls.Add(this.lbl01_AREACD);
            this.groupBox1.Controls.Add(this.txt01_AREACD);
            this.groupBox1.Controls.Add(this.lbl01_USE_YN);
            this.groupBox1.Controls.Add(this.lbl01_AREANM);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_WHCD
            // 
            this.cbo01_WHCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_WHCD.FormattingEnabled = true;
            this.cbo01_WHCD.Location = new System.Drawing.Point(116, 13);
            this.cbo01_WHCD.Name = "cbo01_WHCD";
            this.cbo01_WHCD.Size = new System.Drawing.Size(173, 20);
            this.cbo01_WHCD.TabIndex = 95;
            // 
            // lbl01_WHCD
            // 
            this.lbl01_WHCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_WHCD.AutoFontSizeMinValue = 9F;
            this.lbl01_WHCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WHCD.Location = new System.Drawing.Point(10, 13);
            this.lbl01_WHCD.Name = "lbl01_WHCD";
            this.lbl01_WHCD.Size = new System.Drawing.Size(102, 21);
            this.lbl01_WHCD.TabIndex = 94;
            this.lbl01_WHCD.Tag = null;
            this.lbl01_WHCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WHCD.Value = "차종";
            // 
            // txt01_AREANM
            // 
            this.txt01_AREANM.Location = new System.Drawing.Point(662, 14);
            this.txt01_AREANM.Name = "txt01_AREANM";
            this.txt01_AREANM.Size = new System.Drawing.Size(163, 21);
            this.txt01_AREANM.TabIndex = 71;
            this.txt01_AREANM.Tag = null;
            this.txt01_AREANM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // cbo01_USE_YN
            // 
            this.cbo01_USE_YN.DisplayMember = "Y";
            this.cbo01_USE_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_USE_YN.FormattingEnabled = true;
            this.cbo01_USE_YN.Location = new System.Drawing.Point(939, 12);
            this.cbo01_USE_YN.Name = "cbo01_USE_YN";
            this.cbo01_USE_YN.Size = new System.Drawing.Size(78, 20);
            this.cbo01_USE_YN.TabIndex = 70;
            // 
            // lbl01_AREACD
            // 
            this.lbl01_AREACD.AutoFontSizeMaxValue = 9F;
            this.lbl01_AREACD.AutoFontSizeMinValue = 9F;
            this.lbl01_AREACD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_AREACD.Location = new System.Drawing.Point(297, 12);
            this.lbl01_AREACD.Name = "lbl01_AREACD";
            this.lbl01_AREACD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_AREACD.TabIndex = 69;
            this.lbl01_AREACD.Tag = null;
            this.lbl01_AREACD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_AREACD.Value = "Area 코드";
            // 
            // txt01_AREACD
            // 
            this.txt01_AREACD.Location = new System.Drawing.Point(402, 13);
            this.txt01_AREACD.Name = "txt01_AREACD";
            this.txt01_AREACD.Size = new System.Drawing.Size(148, 21);
            this.txt01_AREACD.TabIndex = 68;
            this.txt01_AREACD.Tag = null;
            this.txt01_AREACD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // lbl01_USE_YN
            // 
            this.lbl01_USE_YN.AutoFontSizeMaxValue = 9F;
            this.lbl01_USE_YN.AutoFontSizeMinValue = 9F;
            this.lbl01_USE_YN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_USE_YN.Location = new System.Drawing.Point(836, 12);
            this.lbl01_USE_YN.Name = "lbl01_USE_YN";
            this.lbl01_USE_YN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_USE_YN.TabIndex = 67;
            this.lbl01_USE_YN.Tag = null;
            this.lbl01_USE_YN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_USE_YN.Value = "사용유무";
            // 
            // lbl01_AREANM
            // 
            this.lbl01_AREANM.AutoFontSizeMaxValue = 9F;
            this.lbl01_AREANM.AutoFontSizeMinValue = 9F;
            this.lbl01_AREANM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_AREANM.Location = new System.Drawing.Point(559, 13);
            this.lbl01_AREANM.Name = "lbl01_AREANM";
            this.lbl01_AREANM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_AREANM.TabIndex = 65;
            this.lbl01_AREANM.Tag = null;
            this.lbl01_AREANM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_AREANM.Value = "Area 명";
            // 
            // WM20441
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01_INSPEC_INFO);
            this.Controls.Add(this.groupBox1);
            this.Name = "WM20441";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01_INSPEC_INFO, 0);
            this.grd01_INSPEC_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WHCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_AREANM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREACD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_AREACD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USE_YN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREANM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grd01_INSPEC_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_AREANM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_AREACD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_USE_YN;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_WHNM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_USE_YN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_AREACD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_AREANM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_WHCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_WHCD;
    }
}
