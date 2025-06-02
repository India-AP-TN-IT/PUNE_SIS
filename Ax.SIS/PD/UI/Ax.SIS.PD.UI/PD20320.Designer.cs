namespace Ax.SIS.PD.UI
{
    partial class PD20320
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20320));
            this.grp01_CALL_HISTORY = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.chk01_AUTO_INSERT = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk01_GRID_MERGE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_CALL_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_4M = new Ax.DEV.Utility.Controls.AxComboBox();
            this.dtp01_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl01_MGRT_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_EMPINFO = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.heSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.grp01_CALL_HISTORY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CALL_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MGRT_NM)).BeginInit();
            this.grp01_EMPINFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp01_CALL_HISTORY
            // 
            this.grp01_CALL_HISTORY.Controls.Add(this.grd01);
            this.grp01_CALL_HISTORY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_CALL_HISTORY.Location = new System.Drawing.Point(336, 34);
            this.grp01_CALL_HISTORY.Name = "grp01_CALL_HISTORY";
            this.grp01_CALL_HISTORY.Size = new System.Drawing.Size(688, 734);
            this.grp01_CALL_HISTORY.TabIndex = 8;
            this.grp01_CALL_HISTORY.TabStop = false;
            this.grp01_CALL_HISTORY.Text = "공정불량 호출이력 리스트";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(682, 714);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.cbl01_LINECD);
            this.groupBox1.Controls.Add(this.chk01_AUTO_INSERT);
            this.groupBox1.Controls.Add(this.chk01_GRID_MERGE);
            this.groupBox1.Controls.Add(this.lbl01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_CALL_DATE);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.dtp01_SDATE);
            this.groupBox1.Controls.Add(this.cbo01_4M);
            this.groupBox1.Controls.Add(this.dtp01_EDATE);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbl01_MGRT_NM);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 239);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 80;
            // 
            // cbl01_LINECD
            // 
            this.cbl01_LINECD.AddItemSeparator = ';';
            this.cbl01_LINECD.Caption = "";
            this.cbl01_LINECD.CaptionHeight = 17;
            this.cbl01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_LINECD.ColumnCaptionHeight = 18;
            this.cbl01_LINECD.ColumnFooterHeight = 18;
            this.cbl01_LINECD.ContentHeight = 16;
            this.cbl01_LINECD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_LINECD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_LINECD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_LINECD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_LINECD.EditorHeight = 16;
            this.cbl01_LINECD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_LINECD.Images"))));
            this.cbl01_LINECD.ItemHeight = 15;
            this.cbl01_LINECD.Location = new System.Drawing.Point(112, 94);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(201, 22);
            this.cbl01_LINECD.TabIndex = 79;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // chk01_AUTO_INSERT
            // 
            this.chk01_AUTO_INSERT.AutoSize = true;
            this.chk01_AUTO_INSERT.Checked = true;
            this.chk01_AUTO_INSERT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_AUTO_INSERT.Location = new System.Drawing.Point(6, 204);
            this.chk01_AUTO_INSERT.Name = "chk01_AUTO_INSERT";
            this.chk01_AUTO_INSERT.Size = new System.Drawing.Size(136, 16);
            this.chk01_AUTO_INSERT.TabIndex = 78;
            this.chk01_AUTO_INSERT.Text = "조치완료일 자동입력";
            this.chk01_AUTO_INSERT.UseVisualStyleBackColor = true;
            // 
            // chk01_GRID_MERGE
            // 
            this.chk01_GRID_MERGE.AutoSize = true;
            this.chk01_GRID_MERGE.Checked = true;
            this.chk01_GRID_MERGE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_GRID_MERGE.Location = new System.Drawing.Point(6, 182);
            this.chk01_GRID_MERGE.Name = "chk01_GRID_MERGE";
            this.chk01_GRID_MERGE.Size = new System.Drawing.Size(75, 16);
            this.chk01_GRID_MERGE.TabIndex = 77;
            this.chk01_GRID_MERGE.Text = "Grid 병합";
            this.chk01_GRID_MERGE.UseVisualStyleBackColor = true;
            this.chk01_GRID_MERGE.CheckedChanged += new System.EventHandler(this.chk01_GRID_MERGE_CheckedChanged);
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(6, 95);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINECD.TabIndex = 69;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "라인코드";
            // 
            // lbl01_CALL_DATE
            // 
            this.lbl01_CALL_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CALL_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_CALL_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CALL_DATE.Location = new System.Drawing.Point(6, 43);
            this.lbl01_CALL_DATE.Name = "lbl01_CALL_DATE";
            this.lbl01_CALL_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CALL_DATE.TabIndex = 54;
            this.lbl01_CALL_DATE.Tag = null;
            this.lbl01_CALL_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CALL_DATE.Value = "호출일자";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 17);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 65;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // dtp01_SDATE
            // 
            this.dtp01_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_SDATE.Location = new System.Drawing.Point(112, 43);
            this.dtp01_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_SDATE.Name = "dtp01_SDATE";
            this.dtp01_SDATE.OriginalFormat = "";
            this.dtp01_SDATE.Size = new System.Drawing.Size(88, 21);
            this.dtp01_SDATE.TabIndex = 62;
            // 
            // cbo01_4M
            // 
            this.cbo01_4M.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_4M.FormattingEnabled = true;
            this.cbo01_4M.Location = new System.Drawing.Point(112, 121);
            this.cbo01_4M.Name = "cbo01_4M";
            this.cbo01_4M.Size = new System.Drawing.Size(201, 20);
            this.cbo01_4M.TabIndex = 68;
            // 
            // dtp01_EDATE
            // 
            this.dtp01_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_EDATE.Location = new System.Drawing.Point(226, 43);
            this.dtp01_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_EDATE.Name = "dtp01_EDATE";
            this.dtp01_EDATE.OriginalFormat = "";
            this.dtp01_EDATE.Size = new System.Drawing.Size(87, 21);
            this.dtp01_EDATE.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "~";
            // 
            // lbl01_MGRT_NM
            // 
            this.lbl01_MGRT_NM.AutoFontSizeMaxValue = 9F;
            this.lbl01_MGRT_NM.AutoFontSizeMinValue = 9F;
            this.lbl01_MGRT_NM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MGRT_NM.Location = new System.Drawing.Point(6, 121);
            this.lbl01_MGRT_NM.Name = "lbl01_MGRT_NM";
            this.lbl01_MGRT_NM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MGRT_NM.TabIndex = 67;
            this.lbl01_MGRT_NM.Tag = null;
            this.lbl01_MGRT_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MGRT_NM.Value = "조치구분";
            // 
            // grp01_EMPINFO
            // 
            this.grp01_EMPINFO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_EMPINFO.Controls.Add(this.grd02);
            this.grp01_EMPINFO.Location = new System.Drawing.Point(3, 249);
            this.grp01_EMPINFO.Name = "grp01_EMPINFO";
            this.grp01_EMPINFO.Size = new System.Drawing.Size(324, 1122);
            this.grp01_EMPINFO.TabIndex = 9;
            this.grp01_EMPINFO.TabStop = false;
            this.grp01_EMPINFO.Text = "사원정보 리스트";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(318, 1102);
            this.grd02.TabIndex = 9;
            this.grd02.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grp01_EMPINFO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 734);
            this.panel1.TabIndex = 10;
            // 
            // heSplitter1
            // 
            this.heSplitter1.BackColor = System.Drawing.Color.White;
            this.heSplitter1.Location = new System.Drawing.Point(331, 34);
            this.heSplitter1.Name = "heSplitter1";
            this.heSplitter1.Size = new System.Drawing.Size(5, 734);
            this.heSplitter1.TabIndex = 11;
            this.heSplitter1.TabStop = false;
            // 
            // PD20320
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_CALL_HISTORY);
            this.Controls.Add(this.heSplitter1);
            this.Controls.Add(this.panel1);
            this.Name = "PD20320";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.heSplitter1, 0);
            this.Controls.SetChildIndex(this.grp01_CALL_HISTORY, 0);
            this.grp01_CALL_HISTORY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CALL_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MGRT_NM)).EndInit();
            this.grp01_EMPINFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_CALL_HISTORY;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CALL_DATE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_4M;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MGRT_NM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_AUTO_INSERT;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_GRID_MERGE;
        private System.Windows.Forms.GroupBox grp01_EMPINFO;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
    }
}
