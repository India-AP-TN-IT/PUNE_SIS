namespace Ax.SIS.BM.BM00.UI
{
    partial class BM20710P2
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
            this.txt01_LINENM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_LINENM = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.btn01_Inquery = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_LINECD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINENM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINENM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINECD)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            this.SuspendLayout();
            // 
            // txt01_LINENM
            // 
            this.txt01_LINENM.Location = new System.Drawing.Point(97, 30);
            this.txt01_LINENM.Name = "txt01_LINENM";
            this.txt01_LINENM.Size = new System.Drawing.Size(295, 21);
            this.txt01_LINENM.TabIndex = 11;
            this.txt01_LINENM.Tag = null;
            // 
            // lbl01_LINENM
            // 
            this.lbl01_LINENM.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINENM.AutoFontSizeMinValue = 9F;
            this.lbl01_LINENM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINENM.Location = new System.Drawing.Point(3, 30);
            this.lbl01_LINENM.Name = "lbl01_LINENM";
            this.lbl01_LINENM.Size = new System.Drawing.Size(88, 21);
            this.lbl01_LINENM.TabIndex = 10;
            this.lbl01_LINENM.Tag = null;
            this.lbl01_LINENM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINENM.Value = "LINE NAME";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 58);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(520, 372);
            this.grd01.TabIndex = 7;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // btn01_Inquery
            // 
            this.btn01_Inquery.Location = new System.Drawing.Point(398, 3);
            this.btn01_Inquery.Name = "btn01_Inquery";
            this.btn01_Inquery.Size = new System.Drawing.Size(75, 20);
            this.btn01_Inquery.TabIndex = 9;
            this.btn01_Inquery.Text = "Query";
            this.btn01_Inquery.UseVisualStyleBackColor = true;
            this.btn01_Inquery.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // txt01_LINECD
            // 
            this.txt01_LINECD.Location = new System.Drawing.Point(97, 3);
            this.txt01_LINECD.Name = "txt01_LINECD";
            this.txt01_LINECD.Size = new System.Drawing.Size(79, 21);
            this.txt01_LINECD.TabIndex = 6;
            this.txt01_LINECD.Tag = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt01_LINENM);
            this.panel1.Controls.Add(this.lbl01_LINENM);
            this.panel1.Controls.Add(this.btn01_Inquery);
            this.panel1.Controls.Add(this.txt01_LINECD);
            this.panel1.Controls.Add(this.lbl01_LINECD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 58);
            this.panel1.TabIndex = 6;
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(3, 3);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(88, 21);
            this.lbl01_LINECD.TabIndex = 5;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "LINE CODE";
            // 
            // BM20710P2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.panel1);
            this.Name = "BM20710P2";
            this.Size = new System.Drawing.Size(520, 430);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINENM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINENM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINECD)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxTextBox txt01_LINENM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINENM;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxButton btn01_Inquery;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LINECD;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINECD;
    }
}
