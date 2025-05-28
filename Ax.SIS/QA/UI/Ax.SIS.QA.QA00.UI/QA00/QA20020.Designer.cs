namespace Ax.SIS.QA.QA00.UI
{
    partial class QA20020
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
            this.txt01_DEFCD_DEFNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_DEFKINDCD_DEFKINDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01_QA20020 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_USE_YN3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_USE_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DEFCD_DEFNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEFKINDCD_DEFKINDNM)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20020)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USE_YN3)).BeginInit();
            this.SuspendLayout();
            // 
            // txt01_DEFCD_DEFNM
            // 
            this.txt01_DEFCD_DEFNM.Location = new System.Drawing.Point(177, 17);
            this.txt01_DEFCD_DEFNM.Name = "txt01_DEFCD_DEFNM";
            this.txt01_DEFCD_DEFNM.Size = new System.Drawing.Size(205, 21);
            this.txt01_DEFCD_DEFNM.TabIndex = 2;
            this.txt01_DEFCD_DEFNM.Tag = null;
            // 
            // lbl01_DEFKINDCD_DEFKINDNM
            // 
            this.lbl01_DEFKINDCD_DEFKINDNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_DEFKINDCD_DEFKINDNM.AutoFontSizeMinValue = 9F;
            this.lbl01_DEFKINDCD_DEFKINDNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DEFKINDCD_DEFKINDNM.Location = new System.Drawing.Point(10, 17);
            this.lbl01_DEFKINDCD_DEFKINDNM.Name = "lbl01_DEFKINDCD_DEFKINDNM";
            this.lbl01_DEFKINDCD_DEFKINDNM.Size = new System.Drawing.Size(161, 21);
            this.lbl01_DEFKINDCD_DEFKINDNM.TabIndex = 2;
            this.lbl01_DEFKINDCD_DEFKINDNM.Tag = null;
            this.lbl01_DEFKINDCD_DEFKINDNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DEFKINDCD_DEFKINDNM.Value = "불량유형코드 / 코드명";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA20020);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 686);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "불량유형 목록";
            // 
            // grd01_QA20020
            // 
            this.grd01_QA20020.AllowHeaderMerging = false;
            this.grd01_QA20020.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA20020.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA20020.EnabledActionFlag = true;
            this.grd01_QA20020.LastRowAdd = false;
            this.grd01_QA20020.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA20020.Name = "grd01_QA20020";
            this.grd01_QA20020.OriginalFormat = null;
            this.grd01_QA20020.PopMenuVisible = true;
            this.grd01_QA20020.Rows.DefaultSize = 18;
            this.grd01_QA20020.Size = new System.Drawing.Size(1018, 666);
            this.grd01_QA20020.TabIndex = 0;
            this.grd01_QA20020.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_USE_YN3);
            this.groupBox1.Controls.Add(this.cbo01_USE_YN);
            this.groupBox1.Controls.Add(this.txt01_DEFCD_DEFNM);
            this.groupBox1.Controls.Add(this.lbl01_DEFKINDCD_DEFKINDNM);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 48);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_USE_YN3
            // 
            this.lbl01_USE_YN3.AutoFontSizeMaxValue = 9F;
            this.lbl01_USE_YN3.AutoFontSizeMinValue = 9F;
            this.lbl01_USE_YN3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_USE_YN3.Location = new System.Drawing.Point(388, 17);
            this.lbl01_USE_YN3.Name = "lbl01_USE_YN3";
            this.lbl01_USE_YN3.Size = new System.Drawing.Size(100, 21);
            this.lbl01_USE_YN3.TabIndex = 12;
            this.lbl01_USE_YN3.Tag = null;
            this.lbl01_USE_YN3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_USE_YN3.Value = "사용유무";
            // 
            // cbo01_USE_YN
            // 
            this.cbo01_USE_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_USE_YN.FormattingEnabled = true;
            this.cbo01_USE_YN.Location = new System.Drawing.Point(494, 18);
            this.cbo01_USE_YN.Name = "cbo01_USE_YN";
            this.cbo01_USE_YN.Size = new System.Drawing.Size(114, 20);
            this.cbo01_USE_YN.TabIndex = 11;
            // 
            // QA20020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "QA20020";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DEFCD_DEFNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEFKINDCD_DEFKINDNM)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20020)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USE_YN3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxTextBox txt01_DEFCD_DEFNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DEFKINDCD_DEFKINDNM;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA20020;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_USE_YN3;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_USE_YN;



    }
}
