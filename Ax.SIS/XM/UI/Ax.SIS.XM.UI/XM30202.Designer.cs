namespace Ax.SIS.XM.UI
{
	partial class XM30202
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
            this.cbo01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.dtp01_ENDDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_STARTDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_ACTIONLOG_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SPLIT = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_SEARCHPERIOD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ACTIONLOGTYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.gbx02 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.gbx01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SPLIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCHPERIOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ACTIONLOGTYPE)).BeginInit();
            this.gbx02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(900, 34);
            // 
            // gbx01
            // 
            this.gbx01.Controls.Add(this.cbo01_SYSTEMCODE);
            this.gbx01.Controls.Add(this.lbl01_SYSTEMCODE);
            this.gbx01.Controls.Add(this.heButton1);
            this.gbx01.Controls.Add(this.dtp01_ENDDATE);
            this.gbx01.Controls.Add(this.dtp01_STARTDATE);
            this.gbx01.Controls.Add(this.cbo01_ACTIONLOG_TYPE);
            this.gbx01.Controls.Add(this.lbl01_SPLIT);
            this.gbx01.Controls.Add(this.lbl01_SEARCHPERIOD);
            this.gbx01.Controls.Add(this.lbl01_ACTIONLOGTYPE);
            this.gbx01.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx01.Location = new System.Drawing.Point(0, 34);
            this.gbx01.Name = "gbx01";
            this.gbx01.Size = new System.Drawing.Size(900, 50);
            this.gbx01.TabIndex = 1;
            this.gbx01.TabStop = false;
            // 
            // cbo01_SYSTEMCODE
            // 
            this.cbo01_SYSTEMCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SYSTEMCODE.FormattingEnabled = true;
            this.cbo01_SYSTEMCODE.Location = new System.Drawing.Point(116, 18);
            this.cbo01_SYSTEMCODE.Name = "cbo01_SYSTEMCODE";
            this.cbo01_SYSTEMCODE.Size = new System.Drawing.Size(140, 20);
            this.cbo01_SYSTEMCODE.TabIndex = 42;
            // 
            // lbl01_SYSTEMCODE
            // 
            this.lbl01_SYSTEMCODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_SYSTEMCODE.AutoFontSizeMinValue = 9F;
            this.lbl01_SYSTEMCODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SYSTEMCODE.Location = new System.Drawing.Point(10, 18);
            this.lbl01_SYSTEMCODE.Name = "lbl01_SYSTEMCODE";
            this.lbl01_SYSTEMCODE.Size = new System.Drawing.Size(100, 20);
            this.lbl01_SYSTEMCODE.TabIndex = 41;
            this.lbl01_SYSTEMCODE.Tag = null;
            this.lbl01_SYSTEMCODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SYSTEMCODE.Value = "시스템_";
            // 
            // heButton1
            // 
            this.heButton1.Location = new System.Drawing.Point(1107, 17);
            this.heButton1.Name = "heButton1";
            this.heButton1.Size = new System.Drawing.Size(102, 21);
            this.heButton1.TabIndex = 36;
            this.heButton1.Text = "test";
            this.heButton1.UseVisualStyleBackColor = true;
            this.heButton1.Click += new System.EventHandler(this.heButton1_Click);
            // 
            // dtp01_ENDDATE
            // 
            this.dtp01_ENDDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_ENDDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_ENDDATE.Location = new System.Drawing.Point(892, 18);
            this.dtp01_ENDDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_ENDDATE.Name = "dtp01_ENDDATE";
            this.dtp01_ENDDATE.OriginalFormat = "";
            this.dtp01_ENDDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_ENDDATE.TabIndex = 35;
            // 
            // dtp01_STARTDATE
            // 
            this.dtp01_STARTDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STARTDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STARTDATE.Location = new System.Drawing.Point(766, 18);
            this.dtp01_STARTDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STARTDATE.Name = "dtp01_STARTDATE";
            this.dtp01_STARTDATE.OriginalFormat = "";
            this.dtp01_STARTDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_STARTDATE.TabIndex = 35;
            // 
            // cbo01_ACTIONLOG_TYPE
            // 
            this.cbo01_ACTIONLOG_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_ACTIONLOG_TYPE.FormattingEnabled = true;
            this.cbo01_ACTIONLOG_TYPE.Location = new System.Drawing.Point(408, 18);
            this.cbo01_ACTIONLOG_TYPE.Name = "cbo01_ACTIONLOG_TYPE";
            this.cbo01_ACTIONLOG_TYPE.Size = new System.Drawing.Size(206, 20);
            this.cbo01_ACTIONLOG_TYPE.TabIndex = 34;
            // 
            // lbl01_SPLIT
            // 
            this.lbl01_SPLIT.AutoFontSizeMaxValue = 9F;
            this.lbl01_SPLIT.AutoFontSizeMinValue = 9F;
            this.lbl01_SPLIT.AutoSize = true;
            this.lbl01_SPLIT.BackColor = System.Drawing.Color.White;
            this.lbl01_SPLIT.Location = new System.Drawing.Point(872, 22);
            this.lbl01_SPLIT.Name = "lbl01_SPLIT";
            this.lbl01_SPLIT.Size = new System.Drawing.Size(70, 12);
            this.lbl01_SPLIT.TabIndex = 32;
            this.lbl01_SPLIT.Tag = null;
            this.lbl01_SPLIT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SPLIT.Value = "~";
            // 
            // lbl01_SEARCHPERIOD
            // 
            this.lbl01_SEARCHPERIOD.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCHPERIOD.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCHPERIOD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SEARCHPERIOD.Location = new System.Drawing.Point(620, 18);
            this.lbl01_SEARCHPERIOD.Name = "lbl01_SEARCHPERIOD";
            this.lbl01_SEARCHPERIOD.Size = new System.Drawing.Size(140, 20);
            this.lbl01_SEARCHPERIOD.TabIndex = 32;
            this.lbl01_SEARCHPERIOD.Tag = null;
            this.lbl01_SEARCHPERIOD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SEARCHPERIOD.Value = "검색기간";
            // 
            // lbl01_ACTIONLOGTYPE
            // 
            this.lbl01_ACTIONLOGTYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_ACTIONLOGTYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_ACTIONLOGTYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ACTIONLOGTYPE.Location = new System.Drawing.Point(262, 18);
            this.lbl01_ACTIONLOGTYPE.Name = "lbl01_ACTIONLOGTYPE";
            this.lbl01_ACTIONLOGTYPE.Size = new System.Drawing.Size(140, 20);
            this.lbl01_ACTIONLOGTYPE.TabIndex = 32;
            this.lbl01_ACTIONLOGTYPE.Tag = null;
            this.lbl01_ACTIONLOGTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ACTIONLOGTYPE.Value = "액션로그유형";
            // 
            // gbx02
            // 
            this.gbx02.AutoSize = true;
            this.gbx02.Controls.Add(this.grd01);
            this.gbx02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx02.Location = new System.Drawing.Point(0, 84);
            this.gbx02.Name = "gbx02";
            this.gbx02.Size = new System.Drawing.Size(900, 516);
            this.gbx02.TabIndex = 2;
            this.gbx02.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(894, 496);
            this.grd01.TabIndex = 4;
            this.grd01.UseCustomHighlight = true;
            // 
            // XM30202
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbx02);
            this.Controls.Add(this.gbx01);
            this.Name = "XM30202";
            this.Size = new System.Drawing.Size(900, 600);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.gbx01, 0);
            this.Controls.SetChildIndex(this.gbx02, 0);
            this.gbx01.ResumeLayout(false);
            this.gbx01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SPLIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCHPERIOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ACTIONLOGTYPE)).EndInit();
            this.gbx02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbx01;
        private System.Windows.Forms.GroupBox gbx02;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SEARCHPERIOD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ACTIONLOGTYPE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_ACTIONLOG_TYPE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_ENDDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_STARTDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SPLIT;
        private Ax.DEV.Utility.Controls.AxButton heButton1;
        private DEV.Utility.Controls.AxComboBox cbo01_SYSTEMCODE;
        private DEV.Utility.Controls.AxLabel lbl01_SYSTEMCODE;
	}
}
