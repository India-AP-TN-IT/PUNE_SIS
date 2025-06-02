namespace Ax.SIS.XM.UI
{
	partial class XM20006
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
            this.gbx01 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.cbo00_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl00_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.gbx01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl00_SYSTEMCODE)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(900, 34);
            // 
            // gbx01
            // 
            this.gbx01.Controls.Add(this.grd01);
            this.gbx01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx01.Location = new System.Drawing.Point(0, 81);
            this.gbx01.Name = "gbx01";
            this.gbx01.Size = new System.Drawing.Size(900, 519);
            this.gbx01.TabIndex = 1;
            this.gbx01.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(894, 499);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.cbo00_SYSTEMCODE);
            this.groupbox1.Controls.Add(this.lbl00_SYSTEMCODE);
            this.groupbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupbox1.Location = new System.Drawing.Point(0, 34);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(900, 47);
            this.groupbox1.TabIndex = 20;
            this.groupbox1.TabStop = false;
            // 
            // cbo00_SYSTEMCODE
            // 
            this.cbo00_SYSTEMCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo00_SYSTEMCODE.FormattingEnabled = true;
            this.cbo00_SYSTEMCODE.Location = new System.Drawing.Point(117, 17);
            this.cbo00_SYSTEMCODE.Name = "cbo00_SYSTEMCODE";
            this.cbo00_SYSTEMCODE.Size = new System.Drawing.Size(140, 20);
            this.cbo00_SYSTEMCODE.TabIndex = 33;
            // 
            // lbl00_SYSTEMCODE
            // 
            this.lbl00_SYSTEMCODE.AutoFontSizeMaxValue = 9F;
            this.lbl00_SYSTEMCODE.AutoFontSizeMinValue = 9F;
            this.lbl00_SYSTEMCODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl00_SYSTEMCODE.Location = new System.Drawing.Point(11, 17);
            this.lbl00_SYSTEMCODE.Name = "lbl00_SYSTEMCODE";
            this.lbl00_SYSTEMCODE.Size = new System.Drawing.Size(100, 20);
            this.lbl00_SYSTEMCODE.TabIndex = 32;
            this.lbl00_SYSTEMCODE.Tag = null;
            this.lbl00_SYSTEMCODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl00_SYSTEMCODE.Value = "시스템_";
            // 
            // XM20006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbx01);
            this.Controls.Add(this.groupbox1);
            this.Name = "XM20006";
            this.Size = new System.Drawing.Size(900, 600);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupbox1, 0);
            this.Controls.SetChildIndex(this.gbx01, 0);
            this.gbx01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupbox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl00_SYSTEMCODE)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.GroupBox gbx01;
        private System.Windows.Forms.GroupBox groupbox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo00_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl00_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
	}
}
