namespace Ax.SIS.CM.UI
{
    partial class CM80020
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
            this.chk01_SHOWLEFTMENUID = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk01_SHOWTOPMENU = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_PT = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_FONTSETTING = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_FONTSIZE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_FONTFAMILY = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_SHOWLEFTMENUID = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_SHOWTOPMENU = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_FONTSIZE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_FONTFAMILY = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_FONTSIZE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_FONTFAMILY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SHOWLEFTMENUID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SHOWTOPMENU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_FONTSIZE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_FONTFAMILY)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk01_SHOWLEFTMENUID);
            this.panel1.Controls.Add(this.chk01_SHOWTOPMENU);
            this.panel1.Controls.Add(this.lbl01_PT);
            this.panel1.Controls.Add(this.btn01_FONTSETTING);
            this.panel1.Controls.Add(this.txt01_FONTSIZE);
            this.panel1.Controls.Add(this.txt01_FONTFAMILY);
            this.panel1.Controls.Add(this.lbl01_SHOWLEFTMENUID);
            this.panel1.Controls.Add(this.lbl01_SHOWTOPMENU);
            this.panel1.Controls.Add(this.lbl01_FONTSIZE);
            this.panel1.Controls.Add(this.lbl01_FONTFAMILY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 2;
            // 
            // chk01_SHOWLEFTMENUID
            // 
            this.chk01_SHOWLEFTMENUID.AutoSize = true;
            this.chk01_SHOWLEFTMENUID.Location = new System.Drawing.Point(222, 110);
            this.chk01_SHOWLEFTMENUID.Name = "chk01_SHOWLEFTMENUID";
            this.chk01_SHOWLEFTMENUID.Size = new System.Drawing.Size(102, 16);
            this.chk01_SHOWLEFTMENUID.TabIndex = 9;
            this.chk01_SHOWLEFTMENUID.Text = "heCheckBox2";
            this.chk01_SHOWLEFTMENUID.UseVisualStyleBackColor = true;
            // 
            // chk01_SHOWTOPMENU
            // 
            this.chk01_SHOWTOPMENU.AutoSize = true;
            this.chk01_SHOWTOPMENU.Location = new System.Drawing.Point(222, 83);
            this.chk01_SHOWTOPMENU.Name = "chk01_SHOWTOPMENU";
            this.chk01_SHOWTOPMENU.Size = new System.Drawing.Size(102, 16);
            this.chk01_SHOWTOPMENU.TabIndex = 8;
            this.chk01_SHOWTOPMENU.Text = "heCheckBox1";
            this.chk01_SHOWTOPMENU.UseVisualStyleBackColor = true;
            // 
            // lbl01_PT
            // 
            this.lbl01_PT.AutoFontSizeMaxValue = 9F;
            this.lbl01_PT.AutoFontSizeMinValue = 9F;
            this.lbl01_PT.AutoSize = true;
            this.lbl01_PT.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PT.Location = new System.Drawing.Point(372, 58);
            this.lbl01_PT.Name = "lbl01_PT";
            this.lbl01_PT.Size = new System.Drawing.Size(52, 12);
            this.lbl01_PT.TabIndex = 7;
            this.lbl01_PT.Tag = null;
            this.lbl01_PT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn01_FONTSETTING
            // 
            this.btn01_FONTSETTING.Location = new System.Drawing.Point(406, 26);
            this.btn01_FONTSETTING.Name = "btn01_FONTSETTING";
            this.btn01_FONTSETTING.Size = new System.Drawing.Size(75, 23);
            this.btn01_FONTSETTING.TabIndex = 6;
            this.btn01_FONTSETTING.Text = "heButton1";
            this.btn01_FONTSETTING.UseVisualStyleBackColor = true;
            this.btn01_FONTSETTING.Click += new System.EventHandler(this.btn01_FONTSETTING_Click);
            // 
            // txt01_FONTSIZE
            // 
            this.txt01_FONTSIZE.Location = new System.Drawing.Point(222, 54);
            this.txt01_FONTSIZE.Name = "txt01_FONTSIZE";
            this.txt01_FONTSIZE.Size = new System.Drawing.Size(144, 21);
            this.txt01_FONTSIZE.TabIndex = 5;
            this.txt01_FONTSIZE.Tag = null;
            // 
            // txt01_FONTFAMILY
            // 
            this.txt01_FONTFAMILY.Location = new System.Drawing.Point(222, 27);
            this.txt01_FONTFAMILY.Name = "txt01_FONTFAMILY";
            this.txt01_FONTFAMILY.Size = new System.Drawing.Size(178, 21);
            this.txt01_FONTFAMILY.TabIndex = 4;
            this.txt01_FONTFAMILY.Tag = null;
            // 
            // lbl01_SHOWLEFTMENUID
            // 
            this.lbl01_SHOWLEFTMENUID.AutoFontSizeMaxValue = 9F;
            this.lbl01_SHOWLEFTMENUID.AutoFontSizeMinValue = 9F;
            this.lbl01_SHOWLEFTMENUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SHOWLEFTMENUID.Location = new System.Drawing.Point(36, 106);
            this.lbl01_SHOWLEFTMENUID.Name = "lbl01_SHOWLEFTMENUID";
            this.lbl01_SHOWLEFTMENUID.Size = new System.Drawing.Size(180, 23);
            this.lbl01_SHOWLEFTMENUID.TabIndex = 3;
            this.lbl01_SHOWLEFTMENUID.Tag = null;
            this.lbl01_SHOWLEFTMENUID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl01_SHOWTOPMENU
            // 
            this.lbl01_SHOWTOPMENU.AutoFontSizeMaxValue = 9F;
            this.lbl01_SHOWTOPMENU.AutoFontSizeMinValue = 9F;
            this.lbl01_SHOWTOPMENU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SHOWTOPMENU.Location = new System.Drawing.Point(36, 79);
            this.lbl01_SHOWTOPMENU.Name = "lbl01_SHOWTOPMENU";
            this.lbl01_SHOWTOPMENU.Size = new System.Drawing.Size(180, 23);
            this.lbl01_SHOWTOPMENU.TabIndex = 2;
            this.lbl01_SHOWTOPMENU.Tag = null;
            this.lbl01_SHOWTOPMENU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl01_FONTSIZE
            // 
            this.lbl01_FONTSIZE.AutoFontSizeMaxValue = 9F;
            this.lbl01_FONTSIZE.AutoFontSizeMinValue = 9F;
            this.lbl01_FONTSIZE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_FONTSIZE.Location = new System.Drawing.Point(36, 52);
            this.lbl01_FONTSIZE.Name = "lbl01_FONTSIZE";
            this.lbl01_FONTSIZE.Size = new System.Drawing.Size(180, 23);
            this.lbl01_FONTSIZE.TabIndex = 1;
            this.lbl01_FONTSIZE.Tag = null;
            this.lbl01_FONTSIZE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl01_FONTFAMILY
            // 
            this.lbl01_FONTFAMILY.AutoFontSizeMaxValue = 9F;
            this.lbl01_FONTFAMILY.AutoFontSizeMinValue = 9F;
            this.lbl01_FONTFAMILY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_FONTFAMILY.Location = new System.Drawing.Point(36, 25);
            this.lbl01_FONTFAMILY.Name = "lbl01_FONTFAMILY";
            this.lbl01_FONTFAMILY.Size = new System.Drawing.Size(180, 23);
            this.lbl01_FONTFAMILY.TabIndex = 0;
            this.lbl01_FONTFAMILY.Tag = null;
            this.lbl01_FONTFAMILY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CM80020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "CM80020";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_FONTSIZE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_FONTFAMILY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SHOWLEFTMENUID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SHOWTOPMENU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_FONTSIZE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_FONTFAMILY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_SHOWLEFTMENUID;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_SHOWTOPMENU;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PT;
        private Ax.DEV.Utility.Controls.AxButton btn01_FONTSETTING;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_FONTSIZE;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_FONTFAMILY;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SHOWLEFTMENUID;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SHOWTOPMENU;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_FONTSIZE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_FONTFAMILY;
    }
}
