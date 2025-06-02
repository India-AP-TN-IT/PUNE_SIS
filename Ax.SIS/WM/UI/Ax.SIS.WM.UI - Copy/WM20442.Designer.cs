namespace Ax.SIS.WM.UI
{
    partial class WM20442
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
            this.cbo01_AREACD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_AREACD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_USE_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_USE_YN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ZONECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_ZONECD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_ZONENM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_ZONENM = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01_INSPEC_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREACD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USE_YN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ZONECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ZONECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ZONENM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ZONENM)).BeginInit();
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
            this.grd01_INSPEC_INFO.Text = "Zone Master";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_AREACD);
            this.groupBox1.Controls.Add(this.lbl01_AREACD);
            this.groupBox1.Controls.Add(this.cbo01_USE_YN);
            this.groupBox1.Controls.Add(this.lbl01_USE_YN);
            this.groupBox1.Controls.Add(this.lbl01_ZONECD);
            this.groupBox1.Controls.Add(this.txt01_ZONECD);
            this.groupBox1.Controls.Add(this.txt01_ZONENM);
            this.groupBox1.Controls.Add(this.lbl01_ZONENM);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_AREACD
            // 
            this.cbo01_AREACD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_AREACD.FormattingEnabled = true;
            this.cbo01_AREACD.Location = new System.Drawing.Point(113, 13);
            this.cbo01_AREACD.Name = "cbo01_AREACD";
            this.cbo01_AREACD.Size = new System.Drawing.Size(167, 20);
            this.cbo01_AREACD.TabIndex = 99;
            // 
            // lbl01_AREACD
            // 
            this.lbl01_AREACD.AutoFontSizeMaxValue = 9F;
            this.lbl01_AREACD.AutoFontSizeMinValue = 9F;
            this.lbl01_AREACD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_AREACD.Location = new System.Drawing.Point(7, 13);
            this.lbl01_AREACD.Name = "lbl01_AREACD";
            this.lbl01_AREACD.Size = new System.Drawing.Size(102, 21);
            this.lbl01_AREACD.TabIndex = 98;
            this.lbl01_AREACD.Tag = null;
            this.lbl01_AREACD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_AREACD.Value = "차종";
            // 
            // cbo01_USE_YN
            // 
            this.cbo01_USE_YN.DisplayMember = "Y";
            this.cbo01_USE_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_USE_YN.FormattingEnabled = true;
            this.cbo01_USE_YN.Location = new System.Drawing.Point(926, 14);
            this.cbo01_USE_YN.Name = "cbo01_USE_YN";
            this.cbo01_USE_YN.Size = new System.Drawing.Size(89, 20);
            this.cbo01_USE_YN.TabIndex = 72;
            // 
            // lbl01_USE_YN
            // 
            this.lbl01_USE_YN.AutoFontSizeMaxValue = 9F;
            this.lbl01_USE_YN.AutoFontSizeMinValue = 9F;
            this.lbl01_USE_YN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_USE_YN.Location = new System.Drawing.Point(820, 13);
            this.lbl01_USE_YN.Name = "lbl01_USE_YN";
            this.lbl01_USE_YN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_USE_YN.TabIndex = 71;
            this.lbl01_USE_YN.Tag = null;
            this.lbl01_USE_YN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_USE_YN.Value = "사용유무";
            // 
            // lbl01_ZONECD
            // 
            this.lbl01_ZONECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ZONECD.AutoFontSizeMinValue = 9F;
            this.lbl01_ZONECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ZONECD.Location = new System.Drawing.Point(288, 12);
            this.lbl01_ZONECD.Name = "lbl01_ZONECD";
            this.lbl01_ZONECD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_ZONECD.TabIndex = 69;
            this.lbl01_ZONECD.Tag = null;
            this.lbl01_ZONECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ZONECD.Value = "Area 코드";
            // 
            // txt01_ZONECD
            // 
            this.txt01_ZONECD.Location = new System.Drawing.Point(393, 13);
            this.txt01_ZONECD.Name = "txt01_ZONECD";
            this.txt01_ZONECD.Size = new System.Drawing.Size(148, 21);
            this.txt01_ZONECD.TabIndex = 68;
            this.txt01_ZONECD.Tag = null;
            // 
            // txt01_ZONENM
            // 
            this.txt01_ZONENM.Location = new System.Drawing.Point(653, 13);
            this.txt01_ZONENM.Name = "txt01_ZONENM";
            this.txt01_ZONENM.Size = new System.Drawing.Size(163, 21);
            this.txt01_ZONENM.TabIndex = 66;
            this.txt01_ZONENM.Tag = null;
            this.txt01_ZONENM.Visible = false;
            // 
            // lbl01_ZONENM
            // 
            this.lbl01_ZONENM.AutoFontSizeMaxValue = 9F;
            this.lbl01_ZONENM.AutoFontSizeMinValue = 9F;
            this.lbl01_ZONENM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ZONENM.Location = new System.Drawing.Point(547, 13);
            this.lbl01_ZONENM.Name = "lbl01_ZONENM";
            this.lbl01_ZONENM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_ZONENM.TabIndex = 65;
            this.lbl01_ZONENM.Tag = null;
            this.lbl01_ZONENM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ZONENM.Value = "Area 명";
            this.lbl01_ZONENM.Visible = false;
            // 
            // WM20442
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01_INSPEC_INFO);
            this.Controls.Add(this.groupBox1);
            this.Name = "WM20442";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01_INSPEC_INFO, 0);
            this.grd01_INSPEC_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREACD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USE_YN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ZONECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ZONECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ZONENM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ZONENM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grd01_INSPEC_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ZONENM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ZONECD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ZONENM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ZONECD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_USE_YN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_USE_YN;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_AREACD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_AREACD;
    }
}
