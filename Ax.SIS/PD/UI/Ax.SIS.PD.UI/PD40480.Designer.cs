namespace Ax.SIS.PD.UI
{
    partial class PD40480
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
            this.heTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_SQL = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.heTextBox1);
            this.panel1.Controls.Add(this.lbl01_SQL);
            this.panel1.Controls.Add(this.grd01);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // heTextBox1
            // 
            this.heTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heTextBox1.Location = new System.Drawing.Point(3, 18);
            this.heTextBox1.Multiline = true;
            this.heTextBox1.Name = "heTextBox1";
            this.heTextBox1.Size = new System.Drawing.Size(1018, 125);
            this.heTextBox1.TabIndex = 5;
            this.heTextBox1.Tag = null;
            // 
            // lbl01_SQL
            // 
            this.lbl01_SQL.AutoFontSizeMaxValue = 9F;
            this.lbl01_SQL.AutoFontSizeMinValue = 9F;
            this.lbl01_SQL.AutoSize = true;
            this.lbl01_SQL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SQL.Location = new System.Drawing.Point(3, 3);
            this.lbl01_SQL.Name = "lbl01_SQL";
            this.lbl01_SQL.Size = new System.Drawing.Size(60, 12);
            this.lbl01_SQL.TabIndex = 4;
            this.lbl01_SQL.Tag = null;
            this.lbl01_SQL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SQL.Value = "SQL";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 149);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 582);
            this.grd01.TabIndex = 3;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD40480
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "PD40480";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SQL;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
    }
}
