namespace Ax.SIS.XM.UI
{
	partial class XM20002P1
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
            this.tv01_MENU = new System.Windows.Forms.TreeView();
            this.btn01_CONFIRM = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_CANCEL = new Ax.DEV.Utility.Controls.AxButton();
            this.SuspendLayout();
            // 
            // tv01_MENU
            // 
            this.tv01_MENU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv01_MENU.CheckBoxes = true;
            this.tv01_MENU.FullRowSelect = true;
            this.tv01_MENU.ItemHeight = 18;
            this.tv01_MENU.Location = new System.Drawing.Point(12, 41);
            this.tv01_MENU.Name = "tv01_MENU";
            this.tv01_MENU.Size = new System.Drawing.Size(373, 398);
            this.tv01_MENU.TabIndex = 2;
            this.tv01_MENU.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv01_MENU_AfterCheck);
            // 
            // btn01_CONFIRM
            // 
            this.btn01_CONFIRM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_CONFIRM.Location = new System.Drawing.Point(171, 13);
            this.btn01_CONFIRM.Name = "btn01_CONFIRM";
            this.btn01_CONFIRM.Size = new System.Drawing.Size(104, 22);
            this.btn01_CONFIRM.TabIndex = 31;
            this.btn01_CONFIRM.Text = "확인_";
            this.btn01_CONFIRM.UseVisualStyleBackColor = true;
            this.btn01_CONFIRM.Click += new System.EventHandler(this.btn01_CONFIRM_Click);
            // 
            // btn01_CANCEL
            // 
            this.btn01_CANCEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_CANCEL.Location = new System.Drawing.Point(281, 13);
            this.btn01_CANCEL.Name = "btn01_CANCEL";
            this.btn01_CANCEL.Size = new System.Drawing.Size(104, 22);
            this.btn01_CANCEL.TabIndex = 32;
            this.btn01_CANCEL.Text = "취소_";
            this.btn01_CANCEL.UseVisualStyleBackColor = true;
            this.btn01_CANCEL.Click += new System.EventHandler(this.btn01_CANCEL_Click);
            // 
            // XM20002P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btn01_CANCEL);
            this.Controls.Add(this.btn01_CONFIRM);
            this.Controls.Add(this.tv01_MENU);
            this.Name = "XM20002P1";
            this.Size = new System.Drawing.Size(402, 484);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TreeView tv01_MENU;
        private Ax.DEV.Utility.Controls.AxButton btn01_CONFIRM;
        private Ax.DEV.Utility.Controls.AxButton btn01_CANCEL;
	}
}