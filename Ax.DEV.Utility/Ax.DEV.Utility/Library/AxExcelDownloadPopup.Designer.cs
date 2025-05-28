namespace Ax.DEV.Utility.Library
{
	partial class AxExcelDownloadPopup
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
            this.pnl01 = new System.Windows.Forms.Panel();
            this.btn01_CLOSE = new C1.Win.C1Input.C1Button();
            this.btn01_EXCEL = new C1.Win.C1Input.C1Button();
            this.lbl01_EXCEL_DESC = new C1.Win.C1Input.C1Label();
            this.flp01 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXCEL_DESC)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl01
            // 
            this.pnl01.Controls.Add(this.btn01_CLOSE);
            this.pnl01.Controls.Add(this.btn01_EXCEL);
            this.pnl01.Controls.Add(this.lbl01_EXCEL_DESC);
            this.pnl01.Controls.Add(this.flp01);
            this.pnl01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl01.Location = new System.Drawing.Point(0, 0);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(296, 200);
            this.pnl01.TabIndex = 0;
            // 
            // btn01_CLOSE
            // 
            this.btn01_CLOSE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn01_CLOSE.Location = new System.Drawing.Point(150, 154);
            this.btn01_CLOSE.Name = "btn01_CLOSE";
            this.btn01_CLOSE.Size = new System.Drawing.Size(92, 23);
            this.btn01_CLOSE.TabIndex = 3;
            this.btn01_CLOSE.Text = "취소";
            this.btn01_CLOSE.UseVisualStyleBackColor = true;
            // 
            // btn01_EXCEL
            // 
            this.btn01_EXCEL.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn01_EXCEL.Location = new System.Drawing.Point(53, 154);
            this.btn01_EXCEL.Name = "btn01_EXCEL";
            this.btn01_EXCEL.Size = new System.Drawing.Size(92, 23);
            this.btn01_EXCEL.TabIndex = 2;
            this.btn01_EXCEL.Text = "다운로드";
            this.btn01_EXCEL.UseVisualStyleBackColor = true;
            // 
            // lbl01_EXCEL_DESC
            // 
            this.lbl01_EXCEL_DESC.AutoSize = true;
            this.lbl01_EXCEL_DESC.Location = new System.Drawing.Point(23, 18);
            this.lbl01_EXCEL_DESC.Name = "lbl01_EXCEL_DESC";
            this.lbl01_EXCEL_DESC.Size = new System.Drawing.Size(115, 12);
            this.lbl01_EXCEL_DESC.TabIndex = 1;
            this.lbl01_EXCEL_DESC.Tag = null;
            this.lbl01_EXCEL_DESC.Value = "다운로드할 그리드를 선택하세요.";
            // 
            // flp01
            // 
            this.flp01.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp01.Location = new System.Drawing.Point(23, 40);
            this.flp01.Name = "flp01";
            this.flp01.Size = new System.Drawing.Size(249, 94);
            this.flp01.TabIndex = 0;
            // 
            // AxExcelDownloadPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(296, 200);
            this.Controls.Add(this.pnl01);
            this.Name = "AxExcelDownloadPopup";
            this.Text = "AxExcelDownloadPopup";
            this.pnl01.ResumeLayout(false);
            this.pnl01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EXCEL_DESC)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnl01;
		private C1.Win.C1Input.C1Label lbl01_EXCEL_DESC;
		private System.Windows.Forms.FlowLayoutPanel flp01;
		private C1.Win.C1Input.C1Button btn01_CLOSE;
		private C1.Win.C1Input.C1Button btn01_EXCEL;
	}
}