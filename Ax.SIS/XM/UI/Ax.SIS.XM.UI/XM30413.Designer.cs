namespace Ax.SIS.XM.UI
{
	partial class XM30413
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
            this.gbx02 = new System.Windows.Forms.GroupBox();
            this.lbl01_XM30413_MSG1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.rdo01_TEST = new System.Windows.Forms.RadioButton();
            this.rdo01_ZMMT0360 = new System.Windows.Forms.RadioButton();
            this.gbx02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_XM30413_MSG1)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(900, 34);
            // 
            // gbx02
            // 
            this.gbx02.AutoSize = true;
            this.gbx02.Controls.Add(this.lbl01_XM30413_MSG1);
            this.gbx02.Controls.Add(this.rdo01_TEST);
            this.gbx02.Controls.Add(this.rdo01_ZMMT0360);
            this.gbx02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx02.Location = new System.Drawing.Point(0, 34);
            this.gbx02.Name = "gbx02";
            this.gbx02.Size = new System.Drawing.Size(900, 566);
            this.gbx02.TabIndex = 2;
            this.gbx02.TabStop = false;
            // 
            // lbl01_XM30413_MSG1
            // 
            this.lbl01_XM30413_MSG1.AutoFontSizeMaxValue = 9F;
            this.lbl01_XM30413_MSG1.AutoFontSizeMinValue = 9F;
            this.lbl01_XM30413_MSG1.AutoSize = true;
            this.lbl01_XM30413_MSG1.BackColor = System.Drawing.Color.White;
            this.lbl01_XM30413_MSG1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl01_XM30413_MSG1.Location = new System.Drawing.Point(10, 17);
            this.lbl01_XM30413_MSG1.Name = "lbl01_XM30413_MSG1";
            this.lbl01_XM30413_MSG1.Size = new System.Drawing.Size(135, 15);
            this.lbl01_XM30413_MSG1.TabIndex = 33;
            this.lbl01_XM30413_MSG1.Tag = null;
            this.lbl01_XM30413_MSG1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_XM30413_MSG1.Value = "I/F 하고자 하는 항목을 선택하신 후, 상단의 \'처리\' 버튼을 눌러 처리하시기 바랍니다.";
            // 
            // rdo01_TEST
            // 
            this.rdo01_TEST.AutoSize = true;
            this.rdo01_TEST.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.rdo01_TEST.Location = new System.Drawing.Point(10, 75);
            this.rdo01_TEST.Name = "rdo01_TEST";
            this.rdo01_TEST.Size = new System.Drawing.Size(61, 19);
            this.rdo01_TEST.TabIndex = 26;
            this.rdo01_TEST.Text = "테스트";
            this.rdo01_TEST.UseVisualStyleBackColor = true;
            this.rdo01_TEST.Visible = false;
            // 
            // rdo01_ZMMT0360
            // 
            this.rdo01_ZMMT0360.AutoSize = true;
            this.rdo01_ZMMT0360.Checked = true;
            this.rdo01_ZMMT0360.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.rdo01_ZMMT0360.Location = new System.Drawing.Point(10, 44);
            this.rdo01_ZMMT0360.Name = "rdo01_ZMMT0360";
            this.rdo01_ZMMT0360.Size = new System.Drawing.Size(258, 19);
            this.rdo01_ZMMT0360.TabIndex = 25;
            this.rdo01_ZMMT0360.TabStop = true;
            this.rdo01_ZMMT0360.Text = "[ZMMT0360] 일별 자재소요계획 SCM 전송";
            this.rdo01_ZMMT0360.UseVisualStyleBackColor = true;
            // 
            // XM30413
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbx02);
            this.Name = "XM30413";
            this.Size = new System.Drawing.Size(900, 600);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.gbx02, 0);
            this.gbx02.ResumeLayout(false);
            this.gbx02.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_XM30413_MSG1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.GroupBox gbx02;
        private DEV.Utility.Controls.AxLabel lbl01_XM30413_MSG1;
        private System.Windows.Forms.RadioButton rdo01_TEST;
        private System.Windows.Forms.RadioButton rdo01_ZMMT0360;
	}
}
