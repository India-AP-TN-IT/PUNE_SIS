namespace Ax.SIS.BM.BM00.UI
{
    partial class BM50020
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.heTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Controls.Add(this.heLabel2);
            this.groupBox1.Controls.Add(this.heLabel1);
            this.groupBox1.Controls.Add(this.heTextBox2);
            this.groupBox1.Controls.Add(this.heTextBox1);
            this.groupBox1.Controls.Add(this.cbo01_CORCD);
            this.groupBox1.Controls.Add(this.lbl01_CORCD);
            this.groupBox1.Location = new System.Drawing.Point(3, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1018, 83);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(436, 20);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 26;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(334, 20);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(100, 20);
            this.lbl01_BIZCD.TabIndex = 25;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "연관사업장";
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.heLabel2.Location = new System.Drawing.Point(360, 47);
            this.heLabel2.Name = "heLabel2";
            this.heLabel2.Size = new System.Drawing.Size(134, 21);
            this.heLabel2.TabIndex = 24;
            this.heLabel2.Tag = null;
            this.heLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel2.Value = "Vehicle";
            // 
            // heLabel1
            // 
            this.heLabel1.AutoFontSizeMaxValue = 9F;
            this.heLabel1.AutoFontSizeMinValue = 9F;
            this.heLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.heLabel1.Location = new System.Drawing.Point(6, 47);
            this.heLabel1.Name = "heLabel1";
            this.heLabel1.Size = new System.Drawing.Size(134, 21);
            this.heLabel1.TabIndex = 23;
            this.heLabel1.Tag = null;
            this.heLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel1.Value = "MODEL";
            // 
            // heTextBox2
            // 
            this.heTextBox2.Location = new System.Drawing.Point(498, 47);
            this.heTextBox2.Name = "heTextBox2";
            this.heTextBox2.Size = new System.Drawing.Size(209, 21);
            this.heTextBox2.TabIndex = 22;
            this.heTextBox2.Tag = null;
            // 
            // heTextBox1
            // 
            this.heTextBox1.Location = new System.Drawing.Point(143, 47);
            this.heTextBox1.Name = "heTextBox1";
            this.heTextBox1.Size = new System.Drawing.Size(209, 21);
            this.heTextBox1.TabIndex = 21;
            this.heTextBox1.Tag = null;
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(143, 21);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(158, 20);
            this.cbo01_CORCD.TabIndex = 9;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(6, 20);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(134, 21);
            this.lbl01_CORCD.TabIndex = 10;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "법인";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 129);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 627);
            this.grd01.TabIndex = 83;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_MouseDoubleClick);
            // 
            // BM50020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "BM50020";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private Ax.DEV.Utility.Controls.AxLabel heLabel2;
        private Ax.DEV.Utility.Controls.AxLabel heLabel1;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox2;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;

    }
}
