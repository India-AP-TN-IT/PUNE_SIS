namespace Ax.SIS.TM.UI
{
    partial class TM20300P1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM20300P1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PROCNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PROCNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PROCCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_Inquery = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_PROCCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROCNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PROCNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PROCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PROCNM);
            this.panel1.Controls.Add(this.txt01_PROCNM);
            this.panel1.Controls.Add(this.lbl01_PROCCD);
            this.panel1.Controls.Add(this.btn01_Inquery);
            this.panel1.Controls.Add(this.txt01_PROCCD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 56);
            this.panel1.TabIndex = 0;
            // 
            // lbl01_PROCNM
            // 
            this.lbl01_PROCNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_PROCNM.AutoFontSizeMinValue = 9F;
            this.lbl01_PROCNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PROCNM.Location = new System.Drawing.Point(3, 30);
            this.lbl01_PROCNM.Name = "lbl01_PROCNM";
            this.lbl01_PROCNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PROCNM.TabIndex = 58;
            this.lbl01_PROCNM.Tag = null;
            this.lbl01_PROCNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PROCNM.Value = "Name";
            // 
            // txt01_PROCNM
            // 
            this.txt01_PROCNM.Location = new System.Drawing.Point(109, 30);
            this.txt01_PROCNM.Name = "txt01_PROCNM";
            this.txt01_PROCNM.Size = new System.Drawing.Size(307, 21);
            this.txt01_PROCNM.TabIndex = 57;
            this.txt01_PROCNM.Tag = null;
            // 
            // lbl01_PROCCD
            // 
            this.lbl01_PROCCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_PROCCD.AutoFontSizeMinValue = 9F;
            this.lbl01_PROCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PROCCD.Location = new System.Drawing.Point(3, 3);
            this.lbl01_PROCCD.Name = "lbl01_PROCCD";
            this.lbl01_PROCCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PROCCD.TabIndex = 56;
            this.lbl01_PROCCD.Tag = null;
            this.lbl01_PROCCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PROCCD.Value = "Code";
            // 
            // btn01_Inquery
            // 
            this.btn01_Inquery.Location = new System.Drawing.Point(425, 3);
            this.btn01_Inquery.Name = "btn01_Inquery";
            this.btn01_Inquery.Size = new System.Drawing.Size(75, 20);
            this.btn01_Inquery.TabIndex = 9;
            this.btn01_Inquery.Text = "Query";
            this.btn01_Inquery.UseVisualStyleBackColor = true;
            this.btn01_Inquery.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // txt01_PROCCD
            // 
            this.txt01_PROCCD.Location = new System.Drawing.Point(109, 3);
            this.txt01_PROCCD.Name = "txt01_PROCCD";
            this.txt01_PROCCD.Size = new System.Drawing.Size(307, 21);
            this.txt01_PROCCD.TabIndex = 6;
            this.txt01_PROCCD.Tag = null;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 56);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(519, 344);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // TM20300P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.panel1);
            this.Name = "TM20300P1";
            this.Size = new System.Drawing.Size(519, 400);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROCNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PROCNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PROCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxButton btn01_Inquery;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PROCCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PROCCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PROCNM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PROCNM;

    }
}
