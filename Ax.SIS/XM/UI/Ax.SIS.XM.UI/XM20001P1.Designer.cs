namespace Ax.SIS.XM.UI
{
    partial class XM20001P1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt03_USERID = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl03_USERID = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn03_CONFIRM = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl01_OPTION = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_XM20001P1_CHK_1 = new Ax.DEV.Utility.Controls.AxCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt03_USERID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_USERID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OPTION)).BeginInit();
            this.SuspendLayout();
            // 
            // txt03_USERID
            // 
            this.txt03_USERID.Location = new System.Drawing.Point(118, 18);
            this.txt03_USERID.Name = "txt03_USERID";
            this.txt03_USERID.Size = new System.Drawing.Size(92, 21);
            this.txt03_USERID.TabIndex = 19;
            this.txt03_USERID.Tag = null;
            this.txt03_USERID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt03_USERID_KeyDown);
            // 
            // lbl03_USERID
            // 
            this.lbl03_USERID.AutoFontSizeMaxValue = 9F;
            this.lbl03_USERID.AutoFontSizeMinValue = 9F;
            this.lbl03_USERID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_USERID.Location = new System.Drawing.Point(12, 18);
            this.lbl03_USERID.Name = "lbl03_USERID";
            this.lbl03_USERID.Size = new System.Drawing.Size(100, 20);
            this.lbl03_USERID.TabIndex = 18;
            this.lbl03_USERID.Tag = null;
            this.lbl03_USERID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl03_USERID.Value = "사용자ID_";
            // 
            // btn03_CONFIRM
            // 
            this.btn03_CONFIRM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn03_CONFIRM.Location = new System.Drawing.Point(355, 18);
            this.btn03_CONFIRM.Name = "btn03_CONFIRM";
            this.btn03_CONFIRM.Size = new System.Drawing.Size(52, 20);
            this.btn03_CONFIRM.TabIndex = 30;
            this.btn03_CONFIRM.Text = "확인_";
            this.btn03_CONFIRM.UseVisualStyleBackColor = true;
            this.btn03_CONFIRM.Click += new System.EventHandler(this.btn03_CONFIRM_Click);
            // 
            // lbl01_OPTION
            // 
            this.lbl01_OPTION.AutoFontSizeMaxValue = 9F;
            this.lbl01_OPTION.AutoFontSizeMinValue = 9F;
            this.lbl01_OPTION.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_OPTION.Location = new System.Drawing.Point(12, 46);
            this.lbl01_OPTION.Name = "lbl01_OPTION";
            this.lbl01_OPTION.Size = new System.Drawing.Size(100, 20);
            this.lbl01_OPTION.TabIndex = 31;
            this.lbl01_OPTION.Tag = null;
            this.lbl01_OPTION.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_OPTION.Value = "대상자 권한삭제_";
            // 
            // chk01_XM20001P1_CHK_1
            // 
            this.chk01_XM20001P1_CHK_1.AutoSize = true;
            this.chk01_XM20001P1_CHK_1.Checked = true;
            this.chk01_XM20001P1_CHK_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_XM20001P1_CHK_1.Location = new System.Drawing.Point(118, 49);
            this.chk01_XM20001P1_CHK_1.Name = "chk01_XM20001P1_CHK_1";
            this.chk01_XM20001P1_CHK_1.Size = new System.Drawing.Size(290, 16);
            this.chk01_XM20001P1_CHK_1.TabIndex = 32;
            this.chk01_XM20001P1_CHK_1.Text = "_체크하면 대상자의 기존권한이 모두 삭제됩니다.";
            this.chk01_XM20001P1_CHK_1.UseVisualStyleBackColor = true;
            // 
            // XM20001P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.chk01_XM20001P1_CHK_1);
            this.Controls.Add(this.lbl01_OPTION);
            this.Controls.Add(this.btn03_CONFIRM);
            this.Controls.Add(this.txt03_USERID);
            this.Controls.Add(this.lbl03_USERID);
            this.Name = "XM20001P1";
            this.Size = new System.Drawing.Size(416, 100);
            ((System.ComponentModel.ISupportInitialize)(this.txt03_USERID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_USERID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OPTION)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxTextBox txt03_USERID;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_USERID;
        private Ax.DEV.Utility.Controls.AxButton btn03_CONFIRM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OPTION;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_XM20001P1_CHK_1;
    }
}