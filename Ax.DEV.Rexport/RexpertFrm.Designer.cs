namespace Ax.DEV.Rexport
{
    partial class RexpertFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RexpertFrm));
            this.axRexViewerCtrl301 = new AxClipsoft.AxRexViewerCtrl30();
            ((System.ComponentModel.ISupportInitialize)(this.axRexViewerCtrl301)).BeginInit();
            this.SuspendLayout();
            // 
            // axRexViewerCtrl301
            // 
            this.axRexViewerCtrl301.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axRexViewerCtrl301.Enabled = true;
            this.axRexViewerCtrl301.Location = new System.Drawing.Point(0, 0);
            this.axRexViewerCtrl301.Name = "axRexViewerCtrl301";
            this.axRexViewerCtrl301.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRexViewerCtrl301.OcxState")));
            this.axRexViewerCtrl301.Size = new System.Drawing.Size(515, 457);
            this.axRexViewerCtrl301.TabIndex = 1;
            // 
            // RexpertFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 457);
            this.Controls.Add(this.axRexViewerCtrl301);
            this.Name = "RexpertFrm";
            this.Text = "RexpertFrm";
            ((System.ComponentModel.ISupportInitialize)(this.axRexViewerCtrl301)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxClipsoft.AxRexViewerCtrl30 axRexViewerCtrl301;
    }
}