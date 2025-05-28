namespace Ax.SIS.XM.UI
{
	partial class XM20003
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
            this.pnl02 = new System.Windows.Forms.Panel();
            this.pnl04 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.pnl03 = new System.Windows.Forms.Panel();
            this.lbl01_GROUPNAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.heSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.pnl01 = new System.Windows.Forms.Panel();
            this.tv01_GROUP = new System.Windows.Forms.TreeView();
            this.gbx02 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.btn01_MENUADD = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_MENUDELETE = new C1.Win.C1Input.C1Button();
            this.btn01_MENUADD_ = new C1.Win.C1Input.C1Button();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heSplitter2 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.gbx01.SuspendLayout();
            this.pnl02.SuspendLayout();
            this.pnl04.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.pnl03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_GROUPNAME)).BeginInit();
            this.pnl01.SuspendLayout();
            this.gbx02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.groupbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(900, 34);
            // 
            // gbx01
            // 
            this.gbx01.Controls.Add(this.pnl02);
            this.gbx01.Controls.Add(this.panel1);
            this.gbx01.Controls.Add(this.heSplitter1);
            this.gbx01.Controls.Add(this.pnl01);
            this.gbx01.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx01.Location = new System.Drawing.Point(0, 81);
            this.gbx01.Name = "gbx01";
            this.gbx01.Size = new System.Drawing.Size(900, 303);
            this.gbx01.TabIndex = 1;
            this.gbx01.TabStop = false;
            // 
            // pnl02
            // 
            this.pnl02.Controls.Add(this.pnl04);
            this.pnl02.Controls.Add(this.pnl03);
            this.pnl02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl02.Location = new System.Drawing.Point(326, 17);
            this.pnl02.Name = "pnl02";
            this.pnl02.Size = new System.Drawing.Size(571, 283);
            this.pnl02.TabIndex = 2;
            // 
            // pnl04
            // 
            this.pnl04.Controls.Add(this.grd01);
            this.pnl04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl04.Location = new System.Drawing.Point(0, 32);
            this.pnl04.Name = "pnl04";
            this.pnl04.Size = new System.Drawing.Size(571, 251);
            this.pnl04.TabIndex = 4;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(571, 251);
            this.grd01.TabIndex = 3;
            this.grd01.UseCustomHighlight = true;
            this.grd01.SelChange += new System.EventHandler(this.grd01_SelChange);
            // 
            // pnl03
            // 
            this.pnl03.Controls.Add(this.lbl01_GROUPNAME);
            this.pnl03.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl03.Location = new System.Drawing.Point(0, 0);
            this.pnl03.Name = "pnl03";
            this.pnl03.Size = new System.Drawing.Size(571, 32);
            this.pnl03.TabIndex = 3;
            // 
            // lbl01_GROUPNAME
            // 
            this.lbl01_GROUPNAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_GROUPNAME.AutoFontSizeMinValue = 9F;
            this.lbl01_GROUPNAME.AutoSize = true;
            this.lbl01_GROUPNAME.BackColor = System.Drawing.Color.White;
            this.lbl01_GROUPNAME.Location = new System.Drawing.Point(9, 11);
            this.lbl01_GROUPNAME.Name = "lbl01_GROUPNAME";
            this.lbl01_GROUPNAME.Size = new System.Drawing.Size(114, 12);
            this.lbl01_GROUPNAME.TabIndex = 34;
            this.lbl01_GROUPNAME.Tag = null;
            this.lbl01_GROUPNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_GROUPNAME.Value = "그룹명 : ";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(318, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 283);
            this.panel1.TabIndex = 1;
            // 
            // heSplitter1
            // 
            this.heSplitter1.Location = new System.Drawing.Point(315, 17);
            this.heSplitter1.Name = "heSplitter1";
            this.heSplitter1.Size = new System.Drawing.Size(3, 283);
            this.heSplitter1.TabIndex = 35;
            this.heSplitter1.TabStop = false;
            // 
            // pnl01
            // 
            this.pnl01.Controls.Add(this.tv01_GROUP);
            this.pnl01.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl01.Location = new System.Drawing.Point(3, 17);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(312, 283);
            this.pnl01.TabIndex = 1;
            // 
            // tv01_GROUP
            // 
            this.tv01_GROUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv01_GROUP.Location = new System.Drawing.Point(0, 0);
            this.tv01_GROUP.Name = "tv01_GROUP";
            this.tv01_GROUP.Size = new System.Drawing.Size(312, 283);
            this.tv01_GROUP.TabIndex = 0;
            this.tv01_GROUP.DoubleClick += new System.EventHandler(this.tv01_GROUP_DoubleClick);
            // 
            // gbx02
            // 
            this.gbx02.Controls.Add(this.grd02);
            this.gbx02.Controls.Add(this.btn01_MENUADD);
            this.gbx02.Controls.Add(this.btn01_MENUDELETE);
            this.gbx02.Controls.Add(this.btn01_MENUADD_);
            this.gbx02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx02.Location = new System.Drawing.Point(0, 387);
            this.gbx02.Name = "gbx02";
            this.gbx02.Size = new System.Drawing.Size(900, 213);
            this.gbx02.TabIndex = 2;
            this.gbx02.TabStop = false;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 55);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(894, 155);
            this.grd02.TabIndex = 32;
            this.grd02.UseCustomHighlight = true;
            // 
            // btn01_MENUADD
            // 
            this.btn01_MENUADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_MENUADD.Location = new System.Drawing.Point(793, 17);
            this.btn01_MENUADD.Name = "btn01_MENUADD";
            this.btn01_MENUADD.Size = new System.Drawing.Size(104, 32);
            this.btn01_MENUADD.TabIndex = 31;
            this.btn01_MENUADD.Text = "메뉴추가_";
            this.btn01_MENUADD.UseVisualStyleBackColor = true;
            this.btn01_MENUADD.Click += new System.EventHandler(this.btn01_MENUADD_Click);
            // 
            // btn01_MENUDELETE
            // 
            this.btn01_MENUDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_MENUDELETE.Location = new System.Drawing.Point(431, 17);
            this.btn01_MENUDELETE.Name = "btn01_MENUDELETE";
            this.btn01_MENUDELETE.Size = new System.Drawing.Size(103, 32);
            this.btn01_MENUDELETE.TabIndex = 4;
            this.btn01_MENUDELETE.UseVisualStyleBackColor = true;
            this.btn01_MENUDELETE.Visible = false;
            this.btn01_MENUDELETE.Click += new System.EventHandler(this.btn01_MENUDELETE_Click);
            // 
            // btn01_MENUADD_
            // 
            this.btn01_MENUADD_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_MENUADD_.Location = new System.Drawing.Point(322, 17);
            this.btn01_MENUADD_.Name = "btn01_MENUADD_";
            this.btn01_MENUADD_.Size = new System.Drawing.Size(103, 32);
            this.btn01_MENUADD_.TabIndex = 3;
            this.btn01_MENUADD_.UseVisualStyleBackColor = true;
            this.btn01_MENUADD_.Visible = false;
            this.btn01_MENUADD_.Click += new System.EventHandler(this.btn01_MENUADD_Click);
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.cbo01_SYSTEMCODE);
            this.groupbox1.Controls.Add(this.lbl01_SYSTEMCODE);
            this.groupbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupbox1.Location = new System.Drawing.Point(0, 34);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(900, 47);
            this.groupbox1.TabIndex = 19;
            this.groupbox1.TabStop = false;
            // 
            // cbo01_SYSTEMCODE
            // 
            this.cbo01_SYSTEMCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SYSTEMCODE.FormattingEnabled = true;
            this.cbo01_SYSTEMCODE.Location = new System.Drawing.Point(117, 17);
            this.cbo01_SYSTEMCODE.Name = "cbo01_SYSTEMCODE";
            this.cbo01_SYSTEMCODE.Size = new System.Drawing.Size(140, 20);
            this.cbo01_SYSTEMCODE.TabIndex = 33;
            // 
            // lbl01_SYSTEMCODE
            // 
            this.lbl01_SYSTEMCODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_SYSTEMCODE.AutoFontSizeMinValue = 9F;
            this.lbl01_SYSTEMCODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SYSTEMCODE.Location = new System.Drawing.Point(11, 17);
            this.lbl01_SYSTEMCODE.Name = "lbl01_SYSTEMCODE";
            this.lbl01_SYSTEMCODE.Size = new System.Drawing.Size(100, 20);
            this.lbl01_SYSTEMCODE.TabIndex = 32;
            this.lbl01_SYSTEMCODE.Tag = null;
            this.lbl01_SYSTEMCODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SYSTEMCODE.Value = "시스템_";
            // 
            // heSplitter2
            // 
            this.heSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.heSplitter2.Location = new System.Drawing.Point(0, 384);
            this.heSplitter2.Name = "heSplitter2";
            this.heSplitter2.Size = new System.Drawing.Size(900, 3);
            this.heSplitter2.TabIndex = 36;
            this.heSplitter2.TabStop = false;
            // 
            // XM20003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbx02);
            this.Controls.Add(this.heSplitter2);
            this.Controls.Add(this.gbx01);
            this.Controls.Add(this.groupbox1);
            this.Name = "XM20003";
            this.Size = new System.Drawing.Size(900, 600);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupbox1, 0);
            this.Controls.SetChildIndex(this.gbx01, 0);
            this.Controls.SetChildIndex(this.heSplitter2, 0);
            this.Controls.SetChildIndex(this.gbx02, 0);
            this.gbx01.ResumeLayout(false);
            this.pnl02.ResumeLayout(false);
            this.pnl04.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.pnl03.ResumeLayout(false);
            this.pnl03.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_GROUPNAME)).EndInit();
            this.pnl01.ResumeLayout(false);
            this.gbx02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.groupbox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbx01;
		private System.Windows.Forms.GroupBox gbx02;
		private C1.Win.C1Input.C1Button btn01_MENUADD_;
		private C1.Win.C1Input.C1Button btn01_MENUDELETE;
		private System.Windows.Forms.TreeView tv01_GROUP;
		private System.Windows.Forms.Panel pnl01;
		private System.Windows.Forms.Panel pnl02;
        private System.Windows.Forms.Panel pnl04;
        private System.Windows.Forms.Panel pnl03;
        private System.Windows.Forms.GroupBox groupbox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter1;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_GROUPNAME;
        private Ax.DEV.Utility.Controls.AxButton btn01_MENUADD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.Panel panel1;
	}
}
