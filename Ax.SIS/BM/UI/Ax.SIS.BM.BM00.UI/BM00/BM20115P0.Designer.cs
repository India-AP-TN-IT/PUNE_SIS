namespace Ax.SIS.BM.BM00.UI
{
    partial class BM20115P0
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_VENDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_VENDNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_Inquery = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_VENDCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_VENDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_VENDNM);
            this.panel1.Controls.Add(this.txt01_VENDNM);
            this.panel1.Controls.Add(this.lbl01_VENDCD);
            this.panel1.Controls.Add(this.btn01_Inquery);
            this.panel1.Controls.Add(this.txt01_VENDCD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 56);
            this.panel1.TabIndex = 6;
            // 
            // lbl01_VENDNM
            // 
            this.lbl01_VENDNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDNM.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDNM.Location = new System.Drawing.Point(3, 30);
            this.lbl01_VENDNM.Name = "lbl01_VENDNM";
            this.lbl01_VENDNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VENDNM.TabIndex = 58;
            this.lbl01_VENDNM.Tag = null;
            this.lbl01_VENDNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VENDNM.Value = "업체명";
            // 
            // txt01_VENDNM
            // 
            this.txt01_VENDNM.Location = new System.Drawing.Point(109, 30);
            this.txt01_VENDNM.Name = "txt01_VENDNM";
            this.txt01_VENDNM.Size = new System.Drawing.Size(307, 21);
            this.txt01_VENDNM.TabIndex = 57;
            this.txt01_VENDNM.Tag = null;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.Location = new System.Drawing.Point(3, 3);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VENDCD.TabIndex = 56;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VENDCD.Value = "업체코드";
            // 
            // btn01_Inquery
            // 
            this.btn01_Inquery.Location = new System.Drawing.Point(425, 3);
            this.btn01_Inquery.Name = "btn01_Inquery";
            this.btn01_Inquery.Size = new System.Drawing.Size(75, 20);
            this.btn01_Inquery.TabIndex = 9;
            this.btn01_Inquery.Text = "조회";
            this.btn01_Inquery.UseVisualStyleBackColor = true;
            this.btn01_Inquery.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // txt01_VENDCD
            // 
            this.txt01_VENDCD.Location = new System.Drawing.Point(109, 3);
            this.txt01_VENDCD.Name = "txt01_VENDCD";
            this.txt01_VENDCD.Size = new System.Drawing.Size(307, 21);
            this.txt01_VENDCD.TabIndex = 6;
            this.txt01_VENDCD.Tag = null;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 56);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(510, 337);
            this.grd01.TabIndex = 7;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // BM20115P0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.panel1);
            this.Name = "BM20115P0";
            this.Size = new System.Drawing.Size(510, 393);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_VENDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDNM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_VENDNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private Ax.DEV.Utility.Controls.AxButton btn01_Inquery;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_VENDCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
    }
}
