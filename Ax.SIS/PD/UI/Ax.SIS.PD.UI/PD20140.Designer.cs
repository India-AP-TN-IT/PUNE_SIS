namespace Ax.SIS.PD.UI
{
    partial class PD20140
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
            this.grp01_ET_GRP_INFO_DETAIL = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_ET_GRPCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_ET_GRP = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_ET_DTLNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl03_ET_DTLNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_ET_DTLCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_ET_DTLCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_ET_GRP_INFO_DETAIL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ET_GRP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_DTLNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_ET_DTLNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_DTLCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_ET_DTLCD)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_ET_GRP_INFO_DETAIL
            // 
            this.grp01_ET_GRP_INFO_DETAIL.Controls.Add(this.grd01);
            this.grp01_ET_GRP_INFO_DETAIL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_ET_GRP_INFO_DETAIL.Location = new System.Drawing.Point(0, 74);
            this.grp01_ET_GRP_INFO_DETAIL.Name = "grp01_ET_GRP_INFO_DETAIL";
            this.grp01_ET_GRP_INFO_DETAIL.Size = new System.Drawing.Size(1024, 694);
            this.grp01_ET_GRP_INFO_DETAIL.TabIndex = 8;
            this.grp01_ET_GRP_INFO_DETAIL.TabStop = false;
            this.grp01_ET_GRP_INFO_DETAIL.Text = "통전 검사 항목 - 상세 정보";
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
            this.groupBox1.Controls.Add(this.cbo01_ET_GRPCD);
            this.groupBox1.Controls.Add(this.lbl01_ET_GRP);
            this.groupBox1.Controls.Add(this.txt01_ET_DTLNM);
            this.groupBox1.Controls.Add(this.lbl03_ET_DTLNM);
            this.groupBox1.Controls.Add(this.txt01_ET_DTLCD);
            this.groupBox1.Controls.Add(this.lbl02_ET_DTLCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_ET_GRPCD
            // 
            this.cbo01_ET_GRPCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_ET_GRPCD.FormattingEnabled = true;
            this.cbo01_ET_GRPCD.Location = new System.Drawing.Point(152, 12);
            this.cbo01_ET_GRPCD.Name = "cbo01_ET_GRPCD";
            this.cbo01_ET_GRPCD.Size = new System.Drawing.Size(150, 20);
            this.cbo01_ET_GRPCD.TabIndex = 70;
            // 
            // lbl01_ET_GRP
            // 
            this.lbl01_ET_GRP.AutoFontSizeMaxValue = 9F;
            this.lbl01_ET_GRP.AutoFontSizeMinValue = 9F;
            this.lbl01_ET_GRP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ET_GRP.Location = new System.Drawing.Point(6, 12);
            this.lbl01_ET_GRP.Name = "lbl01_ET_GRP";
            this.lbl01_ET_GRP.Size = new System.Drawing.Size(140, 21);
            this.lbl01_ET_GRP.TabIndex = 69;
            this.lbl01_ET_GRP.Tag = null;
            this.lbl01_ET_GRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ET_GRP.Value = "통전 그룹";
            // 
            // txt01_ET_DTLNM
            // 
            this.txt01_ET_DTLNM.Location = new System.Drawing.Point(706, 12);
            this.txt01_ET_DTLNM.Name = "txt01_ET_DTLNM";
            this.txt01_ET_DTLNM.Size = new System.Drawing.Size(173, 21);
            this.txt01_ET_DTLNM.TabIndex = 68;
            this.txt01_ET_DTLNM.Tag = null;
            // 
            // lbl03_ET_DTLNM
            // 
            this.lbl03_ET_DTLNM.AutoFontSizeMaxValue = 9F;
            this.lbl03_ET_DTLNM.AutoFontSizeMinValue = 9F;
            this.lbl03_ET_DTLNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_ET_DTLNM.Location = new System.Drawing.Point(560, 12);
            this.lbl03_ET_DTLNM.Name = "lbl03_ET_DTLNM";
            this.lbl03_ET_DTLNM.Size = new System.Drawing.Size(140, 21);
            this.lbl03_ET_DTLNM.TabIndex = 67;
            this.lbl03_ET_DTLNM.Tag = null;
            this.lbl03_ET_DTLNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl03_ET_DTLNM.Value = "통전 상세명";
            // 
            // txt01_ET_DTLCD
            // 
            this.txt01_ET_DTLCD.Location = new System.Drawing.Point(454, 12);
            this.txt01_ET_DTLCD.Name = "txt01_ET_DTLCD";
            this.txt01_ET_DTLCD.Size = new System.Drawing.Size(100, 21);
            this.txt01_ET_DTLCD.TabIndex = 66;
            this.txt01_ET_DTLCD.Tag = null;
            // 
            // lbl02_ET_DTLCD
            // 
            this.lbl02_ET_DTLCD.AutoFontSizeMaxValue = 9F;
            this.lbl02_ET_DTLCD.AutoFontSizeMinValue = 9F;
            this.lbl02_ET_DTLCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_ET_DTLCD.Location = new System.Drawing.Point(308, 12);
            this.lbl02_ET_DTLCD.Name = "lbl02_ET_DTLCD";
            this.lbl02_ET_DTLCD.Size = new System.Drawing.Size(140, 21);
            this.lbl02_ET_DTLCD.TabIndex = 65;
            this.lbl02_ET_DTLCD.Tag = null;
            this.lbl02_ET_DTLCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_ET_DTLCD.Value = "통전 상세 코드";
            // 
            // PD20140
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_ET_GRP_INFO_DETAIL);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20140";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_ET_GRP_INFO_DETAIL, 0);
            this.grp01_ET_GRP_INFO_DETAIL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ET_GRP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_DTLNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_ET_DTLNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ET_DTLCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_ET_DTLCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_ET_GRP_INFO_DETAIL;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_ET_DTLCD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ET_DTLNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_ET_DTLNM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ET_DTLCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_ET_GRPCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ET_GRP;
    }
}
