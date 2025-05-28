namespace Ax.SIS.CM.UI
{
    partial class CM30010P1
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
            this.lbl01_CODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_CODENAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_Inquery = new Ax.DEV.Utility.Controls.AxButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt01_CODENAME = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_CODE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODENAME)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODENAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl01_CODE
            // 
            this.lbl01_CODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CODE.AutoFontSizeMinValue = 9F;
            this.lbl01_CODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CODE.Location = new System.Drawing.Point(6, 17);
            this.lbl01_CODE.Name = "lbl01_CODE";
            this.lbl01_CODE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CODE.TabIndex = 1;
            this.lbl01_CODE.Tag = null;
            this.lbl01_CODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CODE.Value = "코드";
            // 
            // lbl01_CODENAME
            // 
            this.lbl01_CODENAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_CODENAME.AutoFontSizeMinValue = 9F;
            this.lbl01_CODENAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CODENAME.Location = new System.Drawing.Point(218, 17);
            this.lbl01_CODENAME.Name = "lbl01_CODENAME";
            this.lbl01_CODENAME.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CODENAME.TabIndex = 3;
            this.lbl01_CODENAME.Tag = null;
            this.lbl01_CODENAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CODENAME.Value = "명";
            // 
            // btn01_Inquery
            // 
            this.btn01_Inquery.Location = new System.Drawing.Point(530, 16);
            this.btn01_Inquery.Name = "btn01_Inquery";
            this.btn01_Inquery.Size = new System.Drawing.Size(75, 23);
            this.btn01_Inquery.TabIndex = 6;
            this.btn01_Inquery.Text = "조회";
            this.btn01_Inquery.UseVisualStyleBackColor = true;
            this.btn01_Inquery.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn01_Inquery);
            this.groupBox1.Controls.Add(this.txt01_CODENAME);
            this.groupBox1.Controls.Add(this.lbl01_CODENAME);
            this.groupBox1.Controls.Add(this.txt01_CODE);
            this.groupBox1.Controls.Add(this.lbl01_CODE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 48);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txt01_CODENAME
            // 
            this.txt01_CODENAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CODENAME.Location = new System.Drawing.Point(324, 17);
            this.txt01_CODENAME.Name = "txt01_CODENAME";
            this.txt01_CODENAME.Size = new System.Drawing.Size(200, 21);
            this.txt01_CODENAME.TabIndex = 4;
            this.txt01_CODENAME.Tag = null;
            this.txt01_CODENAME.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt01_CODENAME_KeyUp);
            // 
            // txt01_CODE
            // 
            this.txt01_CODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CODE.Location = new System.Drawing.Point(112, 17);
            this.txt01_CODE.Name = "txt01_CODE";
            this.txt01_CODE.Size = new System.Drawing.Size(100, 21);
            this.txt01_CODE.TabIndex = 2;
            this.txt01_CODE.Tag = null;
            this.txt01_CODE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt01_CODE_KeyUp);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AutoGenerateColumns = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(6, 14);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 1;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(598, 332);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(610, 352);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // CM30010P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CM30010P1";
            this.Size = new System.Drawing.Size(610, 400);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODENAME)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODENAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxLabel lbl01_CODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CODENAME;
        private Ax.DEV.Utility.Controls.AxButton btn01_Inquery;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_CODENAME;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_CODE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}
