namespace Ax.SIS.PD.UI
{
    partial class PD20020
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
            this.cbo01_INSPEC_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INSPEC_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_INSPEC_ITEMNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_INSPEC_ITEMNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_INSPEC_ITEMCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_INSPEC_ITEMCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01_INSPEC_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPEC_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPEC_ITEMNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPEC_ITEMNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPEC_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPEC_ITEMCD)).BeginInit();
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
            this.grd01_INSPEC_INFO.Text = "계측 항목 정보";
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
            this.groupBox1.Controls.Add(this.cbo01_INSPEC_DIV);
            this.groupBox1.Controls.Add(this.lbl01_INSPEC_DIV);
            this.groupBox1.Controls.Add(this.txt01_INSPEC_ITEMNM);
            this.groupBox1.Controls.Add(this.lbl01_INSPEC_ITEMNM);
            this.groupBox1.Controls.Add(this.txt01_INSPEC_ITEMCD);
            this.groupBox1.Controls.Add(this.lbl01_INSPEC_ITEMCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_INSPEC_DIV
            // 
            this.cbo01_INSPEC_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INSPEC_DIV.FormattingEnabled = true;
            this.cbo01_INSPEC_DIV.Location = new System.Drawing.Point(152, 12);
            this.cbo01_INSPEC_DIV.Name = "cbo01_INSPEC_DIV";
            this.cbo01_INSPEC_DIV.Size = new System.Drawing.Size(150, 20);
            this.cbo01_INSPEC_DIV.TabIndex = 70;
            // 
            // lbl01_INSPEC_DIV
            // 
            this.lbl01_INSPEC_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPEC_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPEC_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INSPEC_DIV.Location = new System.Drawing.Point(6, 12);
            this.lbl01_INSPEC_DIV.Name = "lbl01_INSPEC_DIV";
            this.lbl01_INSPEC_DIV.Size = new System.Drawing.Size(140, 21);
            this.lbl01_INSPEC_DIV.TabIndex = 69;
            this.lbl01_INSPEC_DIV.Tag = null;
            this.lbl01_INSPEC_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSPEC_DIV.Value = "계측 유형 코드";
            // 
            // txt01_INSPEC_ITEMNM
            // 
            this.txt01_INSPEC_ITEMNM.Location = new System.Drawing.Point(706, 12);
            this.txt01_INSPEC_ITEMNM.Name = "txt01_INSPEC_ITEMNM";
            this.txt01_INSPEC_ITEMNM.Size = new System.Drawing.Size(173, 21);
            this.txt01_INSPEC_ITEMNM.TabIndex = 68;
            this.txt01_INSPEC_ITEMNM.Tag = null;
            // 
            // lbl01_INSPEC_ITEMNM
            // 
            this.lbl01_INSPEC_ITEMNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPEC_ITEMNM.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPEC_ITEMNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INSPEC_ITEMNM.Location = new System.Drawing.Point(560, 12);
            this.lbl01_INSPEC_ITEMNM.Name = "lbl01_INSPEC_ITEMNM";
            this.lbl01_INSPEC_ITEMNM.Size = new System.Drawing.Size(140, 21);
            this.lbl01_INSPEC_ITEMNM.TabIndex = 67;
            this.lbl01_INSPEC_ITEMNM.Tag = null;
            this.lbl01_INSPEC_ITEMNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSPEC_ITEMNM.Value = "계측 항목 명칭";
            // 
            // txt01_INSPEC_ITEMCD
            // 
            this.txt01_INSPEC_ITEMCD.Location = new System.Drawing.Point(454, 12);
            this.txt01_INSPEC_ITEMCD.Name = "txt01_INSPEC_ITEMCD";
            this.txt01_INSPEC_ITEMCD.Size = new System.Drawing.Size(100, 21);
            this.txt01_INSPEC_ITEMCD.TabIndex = 66;
            this.txt01_INSPEC_ITEMCD.Tag = null;
            // 
            // lbl01_INSPEC_ITEMCD
            // 
            this.lbl01_INSPEC_ITEMCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPEC_ITEMCD.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPEC_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INSPEC_ITEMCD.Location = new System.Drawing.Point(308, 12);
            this.lbl01_INSPEC_ITEMCD.Name = "lbl01_INSPEC_ITEMCD";
            this.lbl01_INSPEC_ITEMCD.Size = new System.Drawing.Size(140, 21);
            this.lbl01_INSPEC_ITEMCD.TabIndex = 65;
            this.lbl01_INSPEC_ITEMCD.Tag = null;
            this.lbl01_INSPEC_ITEMCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSPEC_ITEMCD.Value = "계측 항목 코드";
            // 
            // PD20020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01_INSPEC_INFO);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20020";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01_INSPEC_INFO, 0);
            this.grd01_INSPEC_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPEC_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPEC_ITEMNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPEC_ITEMNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPEC_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPEC_ITEMCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grd01_INSPEC_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPEC_ITEMCD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_INSPEC_ITEMNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPEC_ITEMNM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_INSPEC_ITEMCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_INSPEC_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPEC_DIV;
    }
}
