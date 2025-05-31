namespace Ax.SIS.PD.UI
{
    partial class PD31350P1
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
            this.txt01_CONTNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CONTNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_CONTCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CONTCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CONTNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CONTNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CONTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CONTCD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 360);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
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
            this.grd01.Size = new System.Drawing.Size(604, 340);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn01_INQUERY);
            this.groupBox1.Controls.Add(this.txt01_CONTNM);
            this.groupBox1.Controls.Add(this.lbl01_CONTNM);
            this.groupBox1.Controls.Add(this.txt01_CONTCD);
            this.groupBox1.Controls.Add(this.lbl01_CONTCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 40);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // btn01_INQUERY
            // 
            this.btn01_INQUERY.Location = new System.Drawing.Point(530, 12);
            this.btn01_INQUERY.Name = "btn01_INQUERY";
            this.btn01_INQUERY.Size = new System.Drawing.Size(75, 23);
            this.btn01_INQUERY.TabIndex = 6;
            this.btn01_INQUERY.Text = "조회";
            this.btn01_INQUERY.UseVisualStyleBackColor = true;
            this.btn01_INQUERY.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // txt01_CONTNM
            // 
            this.txt01_CONTNM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CONTNM.Location = new System.Drawing.Point(324, 13);
            this.txt01_CONTNM.Name = "txt01_CONTNM";
            this.txt01_CONTNM.Size = new System.Drawing.Size(200, 21);
            this.txt01_CONTNM.TabIndex = 4;
            this.txt01_CONTNM.Tag = null;
            // 
            // lbl01_CONTNM
            // 
            this.lbl01_CONTNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_CONTNM.AutoFontSizeMinValue = 9F;
            this.lbl01_CONTNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CONTNM.Location = new System.Drawing.Point(218, 13);
            this.lbl01_CONTNM.Name = "lbl01_CONTNM";
            this.lbl01_CONTNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CONTNM.TabIndex = 3;
            this.lbl01_CONTNM.Tag = null;
            this.lbl01_CONTNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CONTNM.Value = "품명";
            // 
            // txt01_CONTCD
            // 
            this.txt01_CONTCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CONTCD.Location = new System.Drawing.Point(112, 13);
            this.txt01_CONTCD.Name = "txt01_CONTCD";
            this.txt01_CONTCD.Size = new System.Drawing.Size(100, 21);
            this.txt01_CONTCD.TabIndex = 2;
            this.txt01_CONTCD.Tag = null;
            // 
            // lbl01_CONTCD
            // 
            this.lbl01_CONTCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CONTCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CONTCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CONTCD.Location = new System.Drawing.Point(6, 13);
            this.lbl01_CONTCD.Name = "lbl01_CONTCD";
            this.lbl01_CONTCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CONTCD.TabIndex = 1;
            this.lbl01_CONTCD.Tag = null;
            this.lbl01_CONTCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CONTCD.Value = "품번";
            // 
            // PD31350P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD31350P1";
            this.Size = new System.Drawing.Size(610, 400);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CONTNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CONTNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CONTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CONTCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxButton btn01_INQUERY;
        private DEV.Utility.Controls.AxTextBox txt01_CONTNM;
        private DEV.Utility.Controls.AxLabel lbl01_CONTNM;
        private DEV.Utility.Controls.AxTextBox txt01_CONTCD;
        private DEV.Utility.Controls.AxLabel lbl01_CONTCD;
    }
}
