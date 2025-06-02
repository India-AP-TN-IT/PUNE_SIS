namespace Ax.SIS.QA.QA00.UI
{
    partial class QA20042
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
            this.txt01_APPLI_PART = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_APPLI_PART = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.txt02_APPLI_PART = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo02_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_APPLI_PART = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01_QA20042 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_APPLI_PART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLI_PART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_APPLI_PART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_APPLI_PART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20042)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt01_APPLI_PART
            // 
            this.txt01_APPLI_PART.Location = new System.Drawing.Point(348, 17);
            this.txt01_APPLI_PART.Name = "txt01_APPLI_PART";
            this.txt01_APPLI_PART.Size = new System.Drawing.Size(229, 21);
            this.txt01_APPLI_PART.TabIndex = 2;
            this.txt01_APPLI_PART.Tag = null;
            // 
            // lbl01_APPLI_PART
            // 
            this.lbl01_APPLI_PART.AutoFontSizeMaxValue = 9F;
            this.lbl01_APPLI_PART.AutoFontSizeMinValue = 9F;
            this.lbl01_APPLI_PART.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_APPLI_PART.Location = new System.Drawing.Point(245, 17);
            this.lbl01_APPLI_PART.Name = "lbl01_APPLI_PART";
            this.lbl01_APPLI_PART.Size = new System.Drawing.Size(100, 21);
            this.lbl01_APPLI_PART.TabIndex = 2;
            this.lbl01_APPLI_PART.Tag = null;
            this.lbl01_APPLI_PART.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_APPLI_PART.Value = "원인부품";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(120, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(122, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(17, 17);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.txt02_APPLI_PART);
            this.groupBox_main.Controls.Add(this.cbo02_BIZCD);
            this.groupBox_main.Controls.Add(this.lbl02_APPLI_PART);
            this.groupBox_main.Controls.Add(this.lbl02_BIZNM2);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_main.Location = new System.Drawing.Point(0, 716);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(1024, 52);
            this.groupBox_main.TabIndex = 2;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "타사품 정보";
            // 
            // txt02_APPLI_PART
            // 
            this.txt02_APPLI_PART.Location = new System.Drawing.Point(371, 17);
            this.txt02_APPLI_PART.Name = "txt02_APPLI_PART";
            this.txt02_APPLI_PART.Size = new System.Drawing.Size(141, 21);
            this.txt02_APPLI_PART.TabIndex = 4;
            this.txt02_APPLI_PART.Tag = null;
            // 
            // cbo02_BIZCD
            // 
            this.cbo02_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_BIZCD.FormattingEnabled = true;
            this.cbo02_BIZCD.Location = new System.Drawing.Point(124, 17);
            this.cbo02_BIZCD.Name = "cbo02_BIZCD";
            this.cbo02_BIZCD.Size = new System.Drawing.Size(141, 20);
            this.cbo02_BIZCD.TabIndex = 3;
            // 
            // lbl02_APPLI_PART
            // 
            this.lbl02_APPLI_PART.AutoFontSizeMaxValue = 9F;
            this.lbl02_APPLI_PART.AutoFontSizeMinValue = 9F;
            this.lbl02_APPLI_PART.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_APPLI_PART.Location = new System.Drawing.Point(268, 17);
            this.lbl02_APPLI_PART.Name = "lbl02_APPLI_PART";
            this.lbl02_APPLI_PART.Size = new System.Drawing.Size(100, 21);
            this.lbl02_APPLI_PART.TabIndex = 6;
            this.lbl02_APPLI_PART.Tag = null;
            this.lbl02_APPLI_PART.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_APPLI_PART.Value = "원인부품";
            // 
            // lbl02_BIZNM2
            // 
            this.lbl02_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl02_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl02_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_BIZNM2.Location = new System.Drawing.Point(21, 17);
            this.lbl02_BIZNM2.Name = "lbl02_BIZNM2";
            this.lbl02_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl02_BIZNM2.TabIndex = 5;
            this.lbl02_BIZNM2.Tag = null;
            this.lbl02_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_BIZNM2.Value = "사업장";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA20042);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 635);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "타사품 목록";
            // 
            // grd01_QA20042
            // 
            this.grd01_QA20042.AllowHeaderMerging = false;
            this.grd01_QA20042.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA20042.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA20042.EnabledActionFlag = true;
            this.grd01_QA20042.LastRowAdd = false;
            this.grd01_QA20042.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA20042.Name = "grd01_QA20042";
            this.grd01_QA20042.OriginalFormat = null;
            this.grd01_QA20042.PopMenuVisible = true;
            this.grd01_QA20042.Rows.DefaultSize = 18;
            this.grd01_QA20042.Size = new System.Drawing.Size(1018, 615);
            this.grd01_QA20042.TabIndex = 0;
            this.grd01_QA20042.UseCustomHighlight = true;
            this.grd01_QA20042.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA20042_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt01_APPLI_PART);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.lbl01_APPLI_PART);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 47);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // QA20042
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_main);
            this.Name = "QA20042";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox_main, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_APPLI_PART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLI_PART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.groupBox_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt02_APPLI_PART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_APPLI_PART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20042)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_main;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_APPLI_PART;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_APPLI_PART;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_APPLI_PART;
        private Ax.DEV.Utility.Controls.AxComboBox cbo02_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_APPLI_PART;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_BIZNM2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA20042;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
