namespace Ax.SIS.WM.UI
{
    partial class WM20480
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
            this.txt01_CARPLATENO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CARPLATENO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_TRKNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_TRKNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.txt01_DRIVER = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_DRIVER = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CARPLATENO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CARPLATENO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TRKNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TRKNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DRIVER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DRIVER)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt01_DRIVER);
            this.groupBox1.Controls.Add(this.lbl01_DRIVER);
            this.groupBox1.Controls.Add(this.txt01_CARPLATENO);
            this.groupBox1.Controls.Add(this.lbl01_CARPLATENO);
            this.groupBox1.Controls.Add(this.txt01_TRKNO);
            this.groupBox1.Controls.Add(this.lbl01_TRKNO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txt01_CARPLATENO
            // 
            this.txt01_CARPLATENO.Location = new System.Drawing.Point(450, 17);
            this.txt01_CARPLATENO.Name = "txt01_CARPLATENO";
            this.txt01_CARPLATENO.Size = new System.Drawing.Size(158, 21);
            this.txt01_CARPLATENO.TabIndex = 80;
            this.txt01_CARPLATENO.Tag = null;
            this.txt01_CARPLATENO.Value = "";
            this.txt01_CARPLATENO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // lbl01_CARPLATENO
            // 
            this.lbl01_CARPLATENO.AutoFontSizeMaxValue = 9F;
            this.lbl01_CARPLATENO.AutoFontSizeMinValue = 9F;
            this.lbl01_CARPLATENO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CARPLATENO.Location = new System.Drawing.Point(310, 17);
            this.lbl01_CARPLATENO.Name = "lbl01_CARPLATENO";
            this.lbl01_CARPLATENO.Size = new System.Drawing.Size(134, 21);
            this.lbl01_CARPLATENO.TabIndex = 79;
            this.lbl01_CARPLATENO.Tag = null;
            this.lbl01_CARPLATENO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CARPLATENO.Value = "Car Plate No";
            // 
            // txt01_TRKNO
            // 
            this.txt01_TRKNO.Location = new System.Drawing.Point(146, 17);
            this.txt01_TRKNO.Name = "txt01_TRKNO";
            this.txt01_TRKNO.Size = new System.Drawing.Size(158, 21);
            this.txt01_TRKNO.TabIndex = 78;
            this.txt01_TRKNO.Tag = null;
            this.txt01_TRKNO.Value = "";
            this.txt01_TRKNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // lbl01_TRKNO
            // 
            this.lbl01_TRKNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_TRKNO.AutoFontSizeMinValue = 9F;
            this.lbl01_TRKNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_TRKNO.Location = new System.Drawing.Point(6, 17);
            this.lbl01_TRKNO.Name = "lbl01_TRKNO";
            this.lbl01_TRKNO.Size = new System.Drawing.Size(134, 21);
            this.lbl01_TRKNO.TabIndex = 77;
            this.lbl01_TRKNO.Tag = null;
            this.lbl01_TRKNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_TRKNO.Value = "Truck Code";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AutoClipboard = true;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 83);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 685);
            this.grd01.TabIndex = 12;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // txt01_DRIVER
            // 
            this.txt01_DRIVER.Location = new System.Drawing.Point(755, 17);
            this.txt01_DRIVER.Name = "txt01_DRIVER";
            this.txt01_DRIVER.Size = new System.Drawing.Size(158, 21);
            this.txt01_DRIVER.TabIndex = 82;
            this.txt01_DRIVER.Tag = null;
            this.txt01_DRIVER.Value = "";
            this.txt01_DRIVER.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // lbl01_DRIVER
            // 
            this.lbl01_DRIVER.AutoFontSizeMaxValue = 9F;
            this.lbl01_DRIVER.AutoFontSizeMinValue = 9F;
            this.lbl01_DRIVER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DRIVER.Location = new System.Drawing.Point(615, 17);
            this.lbl01_DRIVER.Name = "lbl01_DRIVER";
            this.lbl01_DRIVER.Size = new System.Drawing.Size(134, 21);
            this.lbl01_DRIVER.TabIndex = 81;
            this.lbl01_DRIVER.Tag = null;
            this.lbl01_DRIVER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DRIVER.Value = "Driver Name";
            // 
            // WM20480
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "WM20480";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CARPLATENO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CARPLATENO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TRKNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TRKNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DRIVER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DRIVER)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxTextBox txt01_CARPLATENO;
        private DEV.Utility.Controls.AxLabel lbl01_CARPLATENO;
        private DEV.Utility.Controls.AxTextBox txt01_TRKNO;
        private DEV.Utility.Controls.AxLabel lbl01_TRKNO;
        private DEV.Utility.Controls.AxTextBox txt01_DRIVER;
        private DEV.Utility.Controls.AxLabel lbl01_DRIVER;
    }
}
