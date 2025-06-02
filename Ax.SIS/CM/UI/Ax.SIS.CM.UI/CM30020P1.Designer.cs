namespace Ax.SIS.CM.UI
{
    partial class CM30020P1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn01_INQUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_NAME_KOR = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_NAME_KOR = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_EMPNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_EMPNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NAME_KOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NAME_KOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EMPNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EMPNO)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 482);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AutoGenerateColumns = false;
            this.grd01.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 1;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(506, 462);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn01_INQUERY);
            this.groupBox1.Controls.Add(this.txt01_NAME_KOR);
            this.groupBox1.Controls.Add(this.lbl01_NAME_KOR);
            this.groupBox1.Controls.Add(this.txt01_EMPNO);
            this.groupBox1.Controls.Add(this.lbl01_EMPNO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btn01_INQUERY
            // 
            this.btn01_INQUERY.Location = new System.Drawing.Point(430, 12);
            this.btn01_INQUERY.Name = "btn01_INQUERY";
            this.btn01_INQUERY.Size = new System.Drawing.Size(75, 23);
            this.btn01_INQUERY.TabIndex = 6;
            this.btn01_INQUERY.Text = "조회";
            this.btn01_INQUERY.UseVisualStyleBackColor = true;
            this.btn01_INQUERY.Click += new System.EventHandler(this.btn01_INQUERY_Click);
            // 
            // txt01_NAME_KOR
            // 
            this.txt01_NAME_KOR.Location = new System.Drawing.Point(324, 14);
            this.txt01_NAME_KOR.Name = "txt01_NAME_KOR";
            this.txt01_NAME_KOR.Size = new System.Drawing.Size(100, 21);
            this.txt01_NAME_KOR.TabIndex = 4;
            this.txt01_NAME_KOR.Tag = null;
            // 
            // lbl01_NAME_KOR
            // 
            this.lbl01_NAME_KOR.AutoFontSizeMaxValue = 9F;
            this.lbl01_NAME_KOR.AutoFontSizeMinValue = 9F;
            this.lbl01_NAME_KOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_NAME_KOR.Location = new System.Drawing.Point(218, 13);
            this.lbl01_NAME_KOR.Name = "lbl01_NAME_KOR";
            this.lbl01_NAME_KOR.Size = new System.Drawing.Size(100, 21);
            this.lbl01_NAME_KOR.TabIndex = 3;
            this.lbl01_NAME_KOR.Tag = null;
            this.lbl01_NAME_KOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_NAME_KOR.Value = "성명";
            // 
            // txt01_EMPNO
            // 
            this.txt01_EMPNO.Location = new System.Drawing.Point(112, 14);
            this.txt01_EMPNO.Name = "txt01_EMPNO";
            this.txt01_EMPNO.Size = new System.Drawing.Size(100, 21);
            this.txt01_EMPNO.TabIndex = 2;
            this.txt01_EMPNO.Tag = null;
            // 
            // lbl01_EMPNO
            // 
            this.lbl01_EMPNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_EMPNO.AutoFontSizeMinValue = 9F;
            this.lbl01_EMPNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EMPNO.Location = new System.Drawing.Point(6, 13);
            this.lbl01_EMPNO.Name = "lbl01_EMPNO";
            this.lbl01_EMPNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_EMPNO.TabIndex = 1;
            this.lbl01_EMPNO.Tag = null;
            this.lbl01_EMPNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EMPNO.Value = "사번";
            // 
            // CM30020P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CM30020P1";
            this.Size = new System.Drawing.Size(512, 522);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NAME_KOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NAME_KOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EMPNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EMPNO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxButton btn01_INQUERY;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_NAME_KOR;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_NAME_KOR;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_EMPNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_EMPNO;
    }
}
