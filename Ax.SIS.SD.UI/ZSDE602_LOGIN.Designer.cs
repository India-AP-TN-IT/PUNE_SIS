namespace Ax.SIS.SD.UI
{
    partial class ZSDE602_LOGIN
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
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.btnCancel = new Ax.DEV.Utility.Controls.AxButton();
            this.btnOK = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl01_Password = new Ax.DEV.Utility.Controls.AxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Password)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(133, 21);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(165, 20);
            this.Txt_Password.TabIndex = 87;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Moccasin;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(160, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Moccasin;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(50, 64);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 23);
            this.btnOK.TabIndex = 80;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.axButton2_Click);
            // 
            // lbl01_Password
            // 
            this.lbl01_Password.AutoFontSizeMaxValue = 9F;
            this.lbl01_Password.AutoFontSizeMinValue = 9F;
            this.lbl01_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_Password.Location = new System.Drawing.Point(12, 21);
            this.lbl01_Password.Name = "lbl01_Password";
            this.lbl01_Password.Size = new System.Drawing.Size(110, 21);
            this.lbl01_Password.TabIndex = 40;
            this.lbl01_Password.Tag = null;
            this.lbl01_Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_Password.Value = "Password";
            // 
            // ZSDE602_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 103);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbl01_Password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ZSDE602_LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN FOR IRN CANCELLATION";
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Password)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_Password;
        private DEV.Utility.Controls.AxButton btnOK;
        private DEV.Utility.Controls.AxButton btnCancel;
        private System.Windows.Forms.TextBox Txt_Password;
    }
}