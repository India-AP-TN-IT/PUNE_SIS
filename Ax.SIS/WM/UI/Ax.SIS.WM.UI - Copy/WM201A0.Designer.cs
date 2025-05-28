namespace Ax.SIS.WM.UI
{
    partial class WM201A0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WM201A0));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt01_END_LODTBL_NO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_ST_LODTBL_NO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_LODTBL_NO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_VINCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_GRID_MERGE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.c1Report1 = new C1.C1Report.C1Report();
            this.c1PrintPreviewDialog1 = new C1.Win.C1Preview.C1PrintPreviewDialog();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_END_LODTBL_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ST_LODTBL_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LODTBL_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1PrintPreviewDialog1.PrintPreviewControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewPane)).BeginInit();
            this.c1PrintPreviewDialog1.PrintPreviewControl.SuspendLayout();
            this.c1PrintPreviewDialog1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Load += new System.EventHandler(this._buttonsControl_Load);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 654);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 634);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt01_END_LODTBL_NO);
            this.groupBox1.Controls.Add(this.txt01_ST_LODTBL_NO);
            this.groupBox1.Controls.Add(this.lbl01_LODTBL_NO);
            this.groupBox1.Controls.Add(this.lbl01_PRDT_DIV);
            this.groupBox1.Controls.Add(this.cbo01_PRDT_DIV);
            this.groupBox1.Controls.Add(this.cbo01_VINCD);
            this.groupBox1.Controls.Add(this.lbl01_VINCD);
            this.groupBox1.Controls.Add(this.chk01_GRID_MERGE);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.cbo01_CORCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_CORCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 80);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(348, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 103;
            this.label2.Text = "(YYMM9999)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(219, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 102;
            this.label1.Text = "~";
            // 
            // txt01_END_LODTBL_NO
            // 
            this.txt01_END_LODTBL_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_END_LODTBL_NO.Location = new System.Drawing.Point(235, 47);
            this.txt01_END_LODTBL_NO.Name = "txt01_END_LODTBL_NO";
            this.txt01_END_LODTBL_NO.Size = new System.Drawing.Size(109, 21);
            this.txt01_END_LODTBL_NO.TabIndex = 98;
            this.txt01_END_LODTBL_NO.Tag = null;
            // 
            // txt01_ST_LODTBL_NO
            // 
            this.txt01_ST_LODTBL_NO.Location = new System.Drawing.Point(109, 47);
            this.txt01_ST_LODTBL_NO.Name = "txt01_ST_LODTBL_NO";
            this.txt01_ST_LODTBL_NO.Size = new System.Drawing.Size(109, 21);
            this.txt01_ST_LODTBL_NO.TabIndex = 97;
            this.txt01_ST_LODTBL_NO.Tag = null;
            // 
            // lbl01_LODTBL_NO
            // 
            this.lbl01_LODTBL_NO.AutoFontSizeMaxValue = 9F;
            this.lbl01_LODTBL_NO.AutoFontSizeMinValue = 9F;
            this.lbl01_LODTBL_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LODTBL_NO.Location = new System.Drawing.Point(6, 46);
            this.lbl01_LODTBL_NO.Name = "lbl01_LODTBL_NO";
            this.lbl01_LODTBL_NO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LODTBL_NO.TabIndex = 96;
            this.lbl01_LODTBL_NO.Tag = null;
            this.lbl01_LODTBL_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LODTBL_NO.Value = "법인";
            // 
            // lbl01_PRDT_DIV
            // 
            this.lbl01_PRDT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRDT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PRDT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRDT_DIV.Location = new System.Drawing.Point(716, 11);
            this.lbl01_PRDT_DIV.Name = "lbl01_PRDT_DIV";
            this.lbl01_PRDT_DIV.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PRDT_DIV.TabIndex = 95;
            this.lbl01_PRDT_DIV.Tag = null;
            this.lbl01_PRDT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PRDT_DIV.Value = "제품구분";
            // 
            // cbo01_PRDT_DIV
            // 
            this.cbo01_PRDT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRDT_DIV.FormattingEnabled = true;
            this.cbo01_PRDT_DIV.Location = new System.Drawing.Point(819, 11);
            this.cbo01_PRDT_DIV.Name = "cbo01_PRDT_DIV";
            this.cbo01_PRDT_DIV.Size = new System.Drawing.Size(104, 23);
            this.cbo01_PRDT_DIV.TabIndex = 94;
            // 
            // cbo01_VINCD
            // 
            this.cbo01_VINCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_VINCD.FormattingEnabled = true;
            this.cbo01_VINCD.Location = new System.Drawing.Point(592, 12);
            this.cbo01_VINCD.Name = "cbo01_VINCD";
            this.cbo01_VINCD.Size = new System.Drawing.Size(115, 23);
            this.cbo01_VINCD.TabIndex = 93;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(486, 12);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(102, 21);
            this.lbl01_VINCD.TabIndex = 91;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "차종";
            // 
            // chk01_GRID_MERGE
            // 
            this.chk01_GRID_MERGE.AutoSize = true;
            this.chk01_GRID_MERGE.Checked = true;
            this.chk01_GRID_MERGE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_GRID_MERGE.Location = new System.Drawing.Point(486, 50);
            this.chk01_GRID_MERGE.Name = "chk01_GRID_MERGE";
            this.chk01_GRID_MERGE.Size = new System.Drawing.Size(89, 19);
            this.chk01_GRID_MERGE.TabIndex = 70;
            this.chk01_GRID_MERGE.Text = "그리드 병합";
            this.chk01_GRID_MERGE.UseVisualStyleBackColor = true;
            this.chk01_GRID_MERGE.CheckedChanged += new System.EventHandler(this.chk01_GRID_MERGE_CheckedChanged);
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(334, 12);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(140, 23);
            this.cbo01_BIZCD.TabIndex = 69;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(109, 12);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(112, 23);
            this.cbo01_CORCD.TabIndex = 68;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(231, 12);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZCD.TabIndex = 67;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "사업장";
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(6, 12);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CORCD.TabIndex = 65;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "법인";
            // 
            // c1Report1
            // 
            this.c1Report1.ReportDefinition = resources.GetString("c1Report1.ReportDefinition");
            this.c1Report1.ReportName = "WM201A0";
            // 
            // c1PrintPreviewDialog1
            // 
            this.c1PrintPreviewDialog1.ClientSize = new System.Drawing.Size(716, 521);
            this.c1PrintPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("c1PrintPreviewDialog1.Icon")));
            this.c1PrintPreviewDialog1.Name = "C1PrintPreviewDialog";
            // 
            // c1PrintPreviewDialog1.PrintPreviewControl
            // 
            // 
            // c1PrintPreviewDialog1.PrintPreviewControl.OutlineView
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewOutlineView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewOutlineView.LineColor = System.Drawing.Color.Empty;
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewOutlineView.Location = new System.Drawing.Point(0, 0);
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewOutlineView.Name = "OutlineView";
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewOutlineView.Size = new System.Drawing.Size(162, 527);
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewOutlineView.TabIndex = 0;
            // 
            // c1PrintPreviewDialog1.PrintPreviewControl.PreviewPane
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewPane.IntegrateExternalTools = true;
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewPane.TabIndex = 0;
            // 
            // c1PrintPreviewDialog1.PrintPreviewControl.PreviewTextSearchPanel
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewTextSearchPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewTextSearchPanel.Location = new System.Drawing.Point(516, 0);
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewTextSearchPanel.MinimumSize = new System.Drawing.Size(200, 240);
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewTextSearchPanel.Name = "PreviewTextSearchPanel";
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewTextSearchPanel.Size = new System.Drawing.Size(200, 496);
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewTextSearchPanel.TabIndex = 0;
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewTextSearchPanel.Visible = false;
            // 
            // c1PrintPreviewDialog1.PrintPreviewControl.ThumbnailView
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewThumbnailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewThumbnailView.Location = new System.Drawing.Point(0, 0);
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewThumbnailView.Name = "ThumbnailView";
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewThumbnailView.Size = new System.Drawing.Size(165, 464);
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewThumbnailView.TabIndex = 0;
            this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewThumbnailView.UseImageAsThumbnail = false;
            this.c1PrintPreviewDialog1.PrintPreviewControl.Text = "c1PrintPreviewControl1";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Open.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Open.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Open.Name = "btnFileOpen";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Open.Size = new System.Drawing.Size(32, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Open.Tag = "C1PreviewActionEnum.FileOpen";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Open.ToolTipText = "Open File";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.PageSetup.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.PageSetup.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.PageSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.PageSetup.Name = "btnPageSetup";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.PageSetup.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.PageSetup.Tag = "C1PreviewActionEnum.PageSetup";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.PageSetup.ToolTipText = "Page Setup";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Print.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Print.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Print.Name = "btnPrint";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Print.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Print.Tag = "C1PreviewActionEnum.Print";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Print.ToolTipText = "Print";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Reflow.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Reflow.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Reflow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Reflow.Name = "btnReflow";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Reflow.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Reflow.Tag = "C1PreviewActionEnum.Reflow";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Reflow.ToolTipText = "Reflow";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Save.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Save.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Save.Name = "btnFileSave";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Save.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Save.Tag = "C1PreviewActionEnum.FileSave";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.File.Save.ToolTipText = "Save File";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoFirst.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoFirst.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoFirst.Name = "btnGoFirst";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoFirst.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoFirst.Tag = "C1PreviewActionEnum.GoFirst";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoFirst.ToolTipText = "Go To First Page";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoLast.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoLast.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoLast.Name = "btnGoLast";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoLast.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoLast.Tag = "C1PreviewActionEnum.GoLast";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoLast.ToolTipText = "Go To Last Page";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoNext.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoNext.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoNext.Name = "btnGoNext";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoNext.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoNext.Tag = "C1PreviewActionEnum.GoNext";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoNext.ToolTipText = "Go To Next Page";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoPrev.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoPrev.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoPrev.Name = "btnGoPrev";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoPrev.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoPrev.Tag = "C1PreviewActionEnum.GoPrev";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.GoPrev.ToolTipText = "Go To Previous Page";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryNext.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryNext.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryNext.Name = "btnHistoryNext";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryNext.Size = new System.Drawing.Size(32, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryNext.Tag = "C1PreviewActionEnum.HistoryNext";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryNext.ToolTipText = "Next View";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryPrev.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryPrev.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryPrev.Name = "btnHistoryPrev";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryPrev.Size = new System.Drawing.Size(32, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryPrev.Tag = "C1PreviewActionEnum.HistoryPrev";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.HistoryPrev.ToolTipText = "Previous View";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.LblOfPages.Name = "lblOfPages";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.LblOfPages.Size = new System.Drawing.Size(27, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.LblOfPages.Tag = "C1PreviewActionEnum.GoPageCount";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.LblOfPages.Text = "of 0";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.LblPage.Name = "lblPage";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.LblPage.Size = new System.Drawing.Size(33, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.LblPage.Tag = "C1PreviewActionEnum.GoPageLabel";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.LblPage.Text = "Page";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.PageNo.Name = "txtPageNo";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.PageNo.Size = new System.Drawing.Size(34, 25);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.PageNo.Tag = "C1PreviewActionEnum.GoPageNumber";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.PageNo.Text = "1";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Navigation.ToolTipPageNo = null;
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.Checked = true;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.Name = "btnPageContinuous";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.Tag = "C1PreviewActionEnum.PageContinuous";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Continuous.ToolTipText = "Continuous View";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Facing.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Facing.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Facing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Facing.Name = "btnPageFacing";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Facing.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Facing.Tag = "C1PreviewActionEnum.PageFacing";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Facing.ToolTipText = "Pages Facing View";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.FacingContinuous.Name = "btnPageFacingContinuous";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.FacingContinuous.Size = new System.Drawing.Size(23, 22);
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Single.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Single.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Single.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Single.Name = "btnPageSingle";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Single.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Single.Tag = "C1PreviewActionEnum.PageSingle";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.Single.ToolTipText = "Single Page View";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Page.ToolTipViewFacingContinuous = "";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Find.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Find.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Find.Name = "btnFind";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Find.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Find.Tag = "C1PreviewActionEnum.Find";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Find.ToolTipText = "Find Text";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.Checked = true;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.Name = "btnHandTool";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.Tag = "C1PreviewActionEnum.HandTool";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.Hand.ToolTipText = "Hand Tool";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.SelectText.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.SelectText.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.SelectText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.SelectText.Name = "btnSelectTextTool";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.SelectText.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.SelectText.Tag = "C1PreviewActionEnum.SelectTextTool";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Text.SelectText.ToolTipText = "Text Select Tool";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.DropZoomFactor.Name = "dropZoomFactor";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.DropZoomFactor.Size = new System.Drawing.Size(13, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.DropZoomFactor.Tag = "C1PreviewActionEnum.ZoomFactor";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ToolTipToolZoomIn = null;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ToolTipToolZoomOut = null;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ToolTipZoomFactor = null;
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomFactor.Name = "txtZoomFactor";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomFactor.Size = new System.Drawing.Size(34, 25);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomFactor.Tag = "C1PreviewActionEnum.ZoomFactor";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomFactor.Text = "100%";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomIn.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomIn.Name = "btnZoomIn";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomIn.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomIn.Tag = "C1PreviewActionEnum.ZoomIn";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomIn.ToolTipText = "Zoom In";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomInTool.Name = "itemZoomInTool";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomInTool.Size = new System.Drawing.Size(67, 22);
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOut.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOut.Name = "btnZoomOut";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOut.Size = new System.Drawing.Size(23, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOut.Tag = "C1PreviewActionEnum.ZoomOut";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOut.ToolTipText = "Zoom Out";
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOutTool.Name = "itemZoomOutTool";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOutTool.Size = new System.Drawing.Size(67, 22);
            // 
            // 
            // 
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomInTool,
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomOutTool});
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomTool.Image = ((System.Drawing.Image)(resources.GetObject("c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomTool.Image")));
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomTool.Name = "btnZoomTool";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomTool.Size = new System.Drawing.Size(32, 22);
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomTool.Tag = "C1PreviewActionEnum.ZoomInTool";
            this.c1PrintPreviewDialog1.PrintPreviewControl.ToolBars.Zoom.ZoomTool.ToolTipText = "Zoom In Tool";
            this.c1PrintPreviewDialog1.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Auto;
            this.c1PrintPreviewDialog1.Text = "c1PrintPreviewDialog1";
            // 
            // WM201A0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "WM201A0";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_END_LODTBL_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ST_LODTBL_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LODTBL_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1PrintPreviewDialog1.PrintPreviewControl.PreviewPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1PrintPreviewDialog1.PrintPreviewControl)).EndInit();
            this.c1PrintPreviewDialog1.PrintPreviewControl.ResumeLayout(false);
            this.c1PrintPreviewDialog1.PrintPreviewControl.PerformLayout();
            this.c1PrintPreviewDialog1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_GRID_MERGE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_VINCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PRDT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PRDT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LODTBL_NO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_END_LODTBL_NO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ST_LODTBL_NO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private C1.C1Report.C1Report c1Report1;
        private C1.Win.C1Preview.C1PrintPreviewDialog c1PrintPreviewDialog1;
    }
}
