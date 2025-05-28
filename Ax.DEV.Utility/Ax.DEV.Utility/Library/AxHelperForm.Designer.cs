namespace Ax.DEV.Utility.Library
{
	partial class AxHelperForm
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
            this.wbrHelp = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbrHelp
            // 
            this.wbrHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrHelp.Location = new System.Drawing.Point(0, 0);
            this.wbrHelp.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrHelp.Name = "wbrHelp";
            this.wbrHelp.Size = new System.Drawing.Size(589, 423);
            this.wbrHelp.TabIndex = 0;
            // 
            // AxHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(589, 423);
            this.Controls.Add(this.wbrHelp);
            this.Name = "AxHelperForm";
            this.Text = "도움말";
            this.Load += new System.EventHandler(this.AxHelperForm_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser wbrHelp;
	}
}