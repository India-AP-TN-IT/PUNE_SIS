namespace Ax.SIS.XM.UI
{
	partial class XM20002
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
            this.pnl01 = new System.Windows.Forms.Panel();
            this.pnl03 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.pnl02 = new System.Windows.Forms.Panel();
            this.lbl01_GROUPNAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_MENUDELETE = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_MENUADD = new Ax.DEV.Utility.Controls.AxButton();
            this.heSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.pnl04 = new System.Windows.Forms.Panel();
            this.tv01_GROUP = new System.Windows.Forms.TreeView();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.gbx01.SuspendLayout();
            this.pnl01.SuspendLayout();
            this.pnl03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.pnl02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_GROUPNAME)).BeginInit();
            this.pnl04.SuspendLayout();
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
            this.gbx01.Controls.Add(this.pnl01);
            this.gbx01.Controls.Add(this.heSplitter1);
            this.gbx01.Controls.Add(this.pnl04);
            this.gbx01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx01.Location = new System.Drawing.Point(0, 81);
            this.gbx01.Name = "gbx01";
            this.gbx01.Size = new System.Drawing.Size(900, 519);
            this.gbx01.TabIndex = 1;
            this.gbx01.TabStop = false;
            // 
            // pnl01
            // 
            this.pnl01.Controls.Add(this.pnl03);
            this.pnl01.Controls.Add(this.pnl02);
            this.pnl01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl01.Location = new System.Drawing.Point(260, 17);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(637, 499);
            this.pnl01.TabIndex = 1;
            // 
            // pnl03
            // 
            this.pnl03.Controls.Add(this.grd01);
            this.pnl03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl03.Location = new System.Drawing.Point(0, 38);
            this.pnl03.Name = "pnl03";
            this.pnl03.Size = new System.Drawing.Size(637, 461);
            this.pnl03.TabIndex = 1;
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
            this.grd01.Size = new System.Drawing.Size(637, 461);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            // 
            // pnl02
            // 
            this.pnl02.Controls.Add(this.lbl01_GROUPNAME);
            this.pnl02.Controls.Add(this.btn01_MENUDELETE);
            this.pnl02.Controls.Add(this.btn01_MENUADD);
            this.pnl02.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl02.Location = new System.Drawing.Point(0, 0);
            this.pnl02.Name = "pnl02";
            this.pnl02.Size = new System.Drawing.Size(637, 38);
            this.pnl02.TabIndex = 0;
            // 
            // lbl01_GROUPNAME
            // 
            this.lbl01_GROUPNAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_GROUPNAME.AutoFontSizeMinValue = 9F;
            this.lbl01_GROUPNAME.AutoSize = true;
            this.lbl01_GROUPNAME.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_GROUPNAME.Location = new System.Drawing.Point(9, 13);
            this.lbl01_GROUPNAME.Name = "lbl01_GROUPNAME";
            this.lbl01_GROUPNAME.Size = new System.Drawing.Size(114, 12);
            this.lbl01_GROUPNAME.TabIndex = 33;
            this.lbl01_GROUPNAME.Tag = null;
            this.lbl01_GROUPNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_GROUPNAME.Value = "그룹명 : ";
            // 
            // btn01_MENUDELETE
            // 
            this.btn01_MENUDELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_MENUDELETE.Location = new System.Drawing.Point(305, 9);
            this.btn01_MENUDELETE.Name = "btn01_MENUDELETE";
            this.btn01_MENUDELETE.Size = new System.Drawing.Size(104, 22);
            this.btn01_MENUDELETE.TabIndex = 30;
            this.btn01_MENUDELETE.Text = "메뉴삭제_";
            this.btn01_MENUDELETE.UseVisualStyleBackColor = true;
            this.btn01_MENUDELETE.Visible = false;
            this.btn01_MENUDELETE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Silver;
            this.btn01_MENUDELETE.Click += new System.EventHandler(this.btn01_MENUDELETE_Click);
            // 
            // btn01_MENUADD
            // 
            this.btn01_MENUADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_MENUADD.Location = new System.Drawing.Point(526, 9);
            this.btn01_MENUADD.Name = "btn01_MENUADD";
            this.btn01_MENUADD.Size = new System.Drawing.Size(104, 22);
            this.btn01_MENUADD.TabIndex = 30;
            this.btn01_MENUADD.Text = "메뉴추가_";
            this.btn01_MENUADD.UseVisualStyleBackColor = true;
            this.btn01_MENUADD.Click += new System.EventHandler(this.btn01_ADD_Click);
            // 
            // heSplitter1
            // 
            this.heSplitter1.Location = new System.Drawing.Point(257, 17);
            this.heSplitter1.Name = "heSplitter1";
            this.heSplitter1.Size = new System.Drawing.Size(3, 499);
            this.heSplitter1.TabIndex = 34;
            this.heSplitter1.TabStop = false;
            // 
            // pnl04
            // 
            this.pnl04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl04.Controls.Add(this.tv01_GROUP);
            this.pnl04.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl04.Location = new System.Drawing.Point(3, 17);
            this.pnl04.Name = "pnl04";
            this.pnl04.Size = new System.Drawing.Size(254, 499);
            this.pnl04.TabIndex = 2;
            // 
            // tv01_GROUP
            // 
            this.tv01_GROUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv01_GROUP.Location = new System.Drawing.Point(0, 0);
            this.tv01_GROUP.Name = "tv01_GROUP";
            this.tv01_GROUP.Size = new System.Drawing.Size(252, 497);
            this.tv01_GROUP.TabIndex = 0;
            this.tv01_GROUP.DoubleClick += new System.EventHandler(this.tv01_GROUP_DoubleClick);
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.cbo01_SYSTEMCODE);
            this.groupbox1.Controls.Add(this.lbl01_SYSTEMCODE);
            this.groupbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupbox1.Location = new System.Drawing.Point(0, 34);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(900, 47);
            this.groupbox1.TabIndex = 18;
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
            this.cbo01_SYSTEMCODE.SelectedIndexChanged += new System.EventHandler(this.cbo01_SYSTEMCODE_SelectedIndexChanged);
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
            // XM20002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbx01);
            this.Controls.Add(this.groupbox1);
            this.Name = "XM20002";
            this.Size = new System.Drawing.Size(900, 600);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupbox1, 0);
            this.Controls.SetChildIndex(this.gbx01, 0);
            this.gbx01.ResumeLayout(false);
            this.pnl01.ResumeLayout(false);
            this.pnl03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.pnl02.ResumeLayout(false);
            this.pnl02.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_GROUPNAME)).EndInit();
            this.pnl04.ResumeLayout(false);
            this.groupbox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbx01;
		private System.Windows.Forms.Panel pnl01;
        private System.Windows.Forms.Panel pnl03;
        private System.Windows.Forms.Panel pnl02;
        private System.Windows.Forms.Panel pnl04;
        private System.Windows.Forms.TreeView tv01_GROUP;
        private System.Windows.Forms.GroupBox groupbox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxButton btn01_MENUADD;
        private Ax.DEV.Utility.Controls.AxButton btn01_MENUDELETE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_GROUPNAME;
	}
}
