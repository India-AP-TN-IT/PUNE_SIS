namespace Ax.SIS.PD.UI
{
    partial class PD20130
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
            this.grp01_ET_GRP_INFO = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt01_ET_GRPNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_ET_GRP_CDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_ET_GRPCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_ET_GRP_CD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_ET_GRP_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_GRPNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_ET_GRP_CDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_GRPCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ET_GRP_CD)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_ET_GRP_INFO
            // 
            this.grp01_ET_GRP_INFO.Controls.Add(this.grd01);
            this.grp01_ET_GRP_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_ET_GRP_INFO.Location = new System.Drawing.Point(0, 74);
            this.grp01_ET_GRP_INFO.Name = "grp01_ET_GRP_INFO";
            this.grp01_ET_GRP_INFO.Size = new System.Drawing.Size(1024, 694);
            this.grp01_ET_GRP_INFO.TabIndex = 8;
            this.grp01_ET_GRP_INFO.TabStop = false;
            this.grp01_ET_GRP_INFO.Text = "통전 검사 항목 그룹 정보";
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt01_ET_GRPNM);
            this.groupBox1.Controls.Add(this.lbl02_ET_GRP_CDNM);
            this.groupBox1.Controls.Add(this.txt01_ET_GRPCD);
            this.groupBox1.Controls.Add(this.lbl01_ET_GRP_CD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txt01_ET_GRPNM
            // 
            this.txt01_ET_GRPNM.Location = new System.Drawing.Point(404, 12);
            this.txt01_ET_GRPNM.Name = "txt01_ET_GRPNM";
            this.txt01_ET_GRPNM.Size = new System.Drawing.Size(173, 21);
            this.txt01_ET_GRPNM.TabIndex = 68;
            this.txt01_ET_GRPNM.Tag = null;
            // 
            // lbl02_ET_GRP_CDNM
            // 
            this.lbl02_ET_GRP_CDNM.AutoFontSizeMaxValue = 9F;
            this.lbl02_ET_GRP_CDNM.AutoFontSizeMinValue = 9F;
            this.lbl02_ET_GRP_CDNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_ET_GRP_CDNM.Location = new System.Drawing.Point(258, 12);
            this.lbl02_ET_GRP_CDNM.Name = "lbl02_ET_GRP_CDNM";
            this.lbl02_ET_GRP_CDNM.Size = new System.Drawing.Size(140, 21);
            this.lbl02_ET_GRP_CDNM.TabIndex = 67;
            this.lbl02_ET_GRP_CDNM.Tag = null;
            this.lbl02_ET_GRP_CDNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_ET_GRP_CDNM.Value = "통전 그룹명";
            // 
            // txt01_ET_GRPCD
            // 
            this.txt01_ET_GRPCD.Location = new System.Drawing.Point(152, 12);
            this.txt01_ET_GRPCD.Name = "txt01_ET_GRPCD";
            this.txt01_ET_GRPCD.Size = new System.Drawing.Size(100, 21);
            this.txt01_ET_GRPCD.TabIndex = 66;
            this.txt01_ET_GRPCD.Tag = null;
            // 
            // lbl01_ET_GRP_CD
            // 
            this.lbl01_ET_GRP_CD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ET_GRP_CD.AutoFontSizeMinValue = 9F;
            this.lbl01_ET_GRP_CD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ET_GRP_CD.Location = new System.Drawing.Point(6, 12);
            this.lbl01_ET_GRP_CD.Name = "lbl01_ET_GRP_CD";
            this.lbl01_ET_GRP_CD.Size = new System.Drawing.Size(140, 21);
            this.lbl01_ET_GRP_CD.TabIndex = 65;
            this.lbl01_ET_GRP_CD.Tag = null;
            this.lbl01_ET_GRP_CD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ET_GRP_CD.Value = "통전 그룹 코드";
            // 
            // PD20130
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_ET_GRP_INFO);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20130";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_ET_GRP_INFO, 0);
            this.grp01_ET_GRP_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_GRPNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_ET_GRP_CDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_GRPCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ET_GRP_CD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_ET_GRP_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ET_GRP_CD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ET_GRPNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_ET_GRP_CDNM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ET_GRPCD;
    }
}
