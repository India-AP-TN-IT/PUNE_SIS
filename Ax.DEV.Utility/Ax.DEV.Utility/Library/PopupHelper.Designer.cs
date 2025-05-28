namespace Ax.DEV.Utility.Library
{
    partial class PopupHelper
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn01_NEW = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_CLS = new Ax.DEV.Utility.Controls.AxButton();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn01_NEW);
            this.panel2.Controls.Add(this.btn01_CLS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 30);
            this.panel2.TabIndex = 1;
            // 
            // btn01_NEW
            // 
            this.btn01_NEW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_NEW.Location = new System.Drawing.Point(116, 3);
            this.btn01_NEW.Name = "btn01_NEW";
            this.btn01_NEW.Size = new System.Drawing.Size(75, 23);
            this.btn01_NEW.TabIndex = 1;
            this.btn01_NEW.Text = "Reset";
            this.btn01_NEW.UseVisualStyleBackColor = true;
            this.btn01_NEW.Click += new System.EventHandler(this.btn01_NEW_Click);
            // 
            // btn01_CLS
            // 
            this.btn01_CLS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_CLS.Location = new System.Drawing.Point(197, 3);
            this.btn01_CLS.Name = "btn01_CLS";
            this.btn01_CLS.Size = new System.Drawing.Size(75, 23);
            this.btn01_CLS.TabIndex = 0;
            this.btn01_CLS.Text = "Close";
            this.btn01_CLS.UseVisualStyleBackColor = true;
            this.btn01_CLS.Click += new System.EventHandler(this.btn01_CLS_Click);
            // 
            // PopupHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.panel2);
            this.Name = "PopupHelper";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxButton btn01_NEW;
        private DEV.Utility.Controls.AxButton btn01_CLS;        

    }
}