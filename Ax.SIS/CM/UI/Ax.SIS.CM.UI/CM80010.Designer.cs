namespace Ax.SIS.CM.UI
{
    partial class CM80010
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
            this.txt01_CONFIRM_PASSWORD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CONFIRM_PASSWORD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_EXISTING_PASSWORD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_NEW_PASSWORD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_NEW_PASSWORD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_EXISTING_PASSWORD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CONFIRM_PASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CONFIRM_PASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXISTING_PASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NEW_PASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NEW_PASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EXISTING_PASSWORD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt01_CONFIRM_PASSWORD);
            this.panel1.Controls.Add(this.lbl01_CONFIRM_PASSWORD);
            this.panel1.Controls.Add(this.lbl01_EXISTING_PASSWORD);
            this.panel1.Controls.Add(this.txt01_NEW_PASSWORD);
            this.panel1.Controls.Add(this.lbl01_NEW_PASSWORD);
            this.panel1.Controls.Add(this.txt01_EXISTING_PASSWORD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 2;
            // 
            // txt01_CONFIRM_PASSWORD
            // 
            this.txt01_CONFIRM_PASSWORD.Location = new System.Drawing.Point(148, 65);
            this.txt01_CONFIRM_PASSWORD.Name = "txt01_CONFIRM_PASSWORD";
            this.txt01_CONFIRM_PASSWORD.PasswordChar = '*';
            this.txt01_CONFIRM_PASSWORD.Size = new System.Drawing.Size(142, 21);
            this.txt01_CONFIRM_PASSWORD.TabIndex = 7;
            this.txt01_CONFIRM_PASSWORD.Tag = null;
            // 
            // lbl01_CONFIRM_PASSWORD
            // 
            this.lbl01_CONFIRM_PASSWORD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CONFIRM_PASSWORD.AutoFontSizeMinValue = 9F;
            this.lbl01_CONFIRM_PASSWORD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CONFIRM_PASSWORD.Location = new System.Drawing.Point(16, 65);
            this.lbl01_CONFIRM_PASSWORD.Name = "lbl01_CONFIRM_PASSWORD";
            this.lbl01_CONFIRM_PASSWORD.Size = new System.Drawing.Size(126, 21);
            this.lbl01_CONFIRM_PASSWORD.TabIndex = 6;
            this.lbl01_CONFIRM_PASSWORD.Tag = null;
            this.lbl01_CONFIRM_PASSWORD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CONFIRM_PASSWORD.Value = "코드명";
            // 
            // lbl01_EXISTING_PASSWORD
            // 
            this.lbl01_EXISTING_PASSWORD.AutoFontSizeMaxValue = 9F;
            this.lbl01_EXISTING_PASSWORD.AutoFontSizeMinValue = 9F;
            this.lbl01_EXISTING_PASSWORD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EXISTING_PASSWORD.Location = new System.Drawing.Point(16, 15);
            this.lbl01_EXISTING_PASSWORD.Name = "lbl01_EXISTING_PASSWORD";
            this.lbl01_EXISTING_PASSWORD.Size = new System.Drawing.Size(126, 21);
            this.lbl01_EXISTING_PASSWORD.TabIndex = 5;
            this.lbl01_EXISTING_PASSWORD.Tag = null;
            this.lbl01_EXISTING_PASSWORD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EXISTING_PASSWORD.Value = "코드";
            // 
            // txt01_NEW_PASSWORD
            // 
            this.txt01_NEW_PASSWORD.Location = new System.Drawing.Point(148, 40);
            this.txt01_NEW_PASSWORD.Name = "txt01_NEW_PASSWORD";
            this.txt01_NEW_PASSWORD.PasswordChar = '*';
            this.txt01_NEW_PASSWORD.Size = new System.Drawing.Size(142, 21);
            this.txt01_NEW_PASSWORD.TabIndex = 4;
            this.txt01_NEW_PASSWORD.Tag = null;
            // 
            // lbl01_NEW_PASSWORD
            // 
            this.lbl01_NEW_PASSWORD.AutoFontSizeMaxValue = 9F;
            this.lbl01_NEW_PASSWORD.AutoFontSizeMinValue = 9F;
            this.lbl01_NEW_PASSWORD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_NEW_PASSWORD.Location = new System.Drawing.Point(16, 40);
            this.lbl01_NEW_PASSWORD.Name = "lbl01_NEW_PASSWORD";
            this.lbl01_NEW_PASSWORD.Size = new System.Drawing.Size(126, 21);
            this.lbl01_NEW_PASSWORD.TabIndex = 3;
            this.lbl01_NEW_PASSWORD.Tag = null;
            this.lbl01_NEW_PASSWORD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_NEW_PASSWORD.Value = "코드명";
            // 
            // txt01_EXISTING_PASSWORD
            // 
            this.txt01_EXISTING_PASSWORD.Location = new System.Drawing.Point(148, 15);
            this.txt01_EXISTING_PASSWORD.Name = "txt01_EXISTING_PASSWORD";
            this.txt01_EXISTING_PASSWORD.PasswordChar = '*';
            this.txt01_EXISTING_PASSWORD.Size = new System.Drawing.Size(142, 21);
            this.txt01_EXISTING_PASSWORD.TabIndex = 2;
            this.txt01_EXISTING_PASSWORD.Tag = null;
            // 
            // CM80010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "CM80010";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CONFIRM_PASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CONFIRM_PASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXISTING_PASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NEW_PASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NEW_PASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_EXISTING_PASSWORD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_NEW_PASSWORD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_NEW_PASSWORD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_EXISTING_PASSWORD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_EXISTING_PASSWORD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_CONFIRM_PASSWORD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CONFIRM_PASSWORD;
    }
}
