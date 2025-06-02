namespace Ax.SIS.PD.UI
{
    partial class PD20340
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20340));
            this.grp01_EMPLIST = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk01_GRID_MERGE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo01_PDA_SMS_GROUP = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PDA_SMS_GROUP = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SMS_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SMS_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PDA_SMS_TARGET = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbl02_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.btn02_SAVE = new Ax.DEV.Utility.Controls.AxButton();
            this.btn02_INQUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.txt02_NAME_KOR = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_HR_NAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_DEPART = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_EMPLIST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PDA_SMS_GROUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SMS_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.grp01_PDA_SMS_TARGET.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NAME_KOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_HR_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DEPART)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_EMPLIST
            // 
            this.grp01_EMPLIST.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp01_EMPLIST.Controls.Add(this.grd01);
            this.grp01_EMPLIST.Location = new System.Drawing.Point(0, 156);
            this.grp01_EMPLIST.Name = "grp01_EMPLIST";
            this.grp01_EMPLIST.Size = new System.Drawing.Size(505, 609);
            this.grp01_EMPLIST.TabIndex = 8;
            this.grp01_EMPLIST.TabStop = false;
            this.grp01_EMPLIST.Text = "전체 사원";
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
            this.grd01.Size = new System.Drawing.Size(499, 589);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chk01_GRID_MERGE);
            this.groupBox1.Controls.Add(this.cbo01_PDA_SMS_GROUP);
            this.groupBox1.Controls.Add(this.lbl01_PDA_SMS_GROUP);
            this.groupBox1.Controls.Add(this.cbo01_SMS_TYPE);
            this.groupBox1.Controls.Add(this.lbl01_SMS_TYPE);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // chk01_GRID_MERGE
            // 
            this.chk01_GRID_MERGE.AutoSize = true;
            this.chk01_GRID_MERGE.Location = new System.Drawing.Point(843, 14);
            this.chk01_GRID_MERGE.Name = "chk01_GRID_MERGE";
            this.chk01_GRID_MERGE.Size = new System.Drawing.Size(88, 16);
            this.chk01_GRID_MERGE.TabIndex = 71;
            this.chk01_GRID_MERGE.Text = "그리드 병합";
            this.chk01_GRID_MERGE.UseVisualStyleBackColor = true;
            this.chk01_GRID_MERGE.CheckedChanged += new System.EventHandler(this.chk01_MERGE_CheckedChanged);
            // 
            // cbo01_PDA_SMS_GROUP
            // 
            this.cbo01_PDA_SMS_GROUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PDA_SMS_GROUP.FormattingEnabled = true;
            this.cbo01_PDA_SMS_GROUP.Location = new System.Drawing.Point(660, 12);
            this.cbo01_PDA_SMS_GROUP.Name = "cbo01_PDA_SMS_GROUP";
            this.cbo01_PDA_SMS_GROUP.Size = new System.Drawing.Size(177, 20);
            this.cbo01_PDA_SMS_GROUP.TabIndex = 70;
            // 
            // lbl01_PDA_SMS_GROUP
            // 
            this.lbl01_PDA_SMS_GROUP.AutoFontSizeMaxValue = 9F;
            this.lbl01_PDA_SMS_GROUP.AutoFontSizeMinValue = 9F;
            this.lbl01_PDA_SMS_GROUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PDA_SMS_GROUP.Location = new System.Drawing.Point(554, 12);
            this.lbl01_PDA_SMS_GROUP.Name = "lbl01_PDA_SMS_GROUP";
            this.lbl01_PDA_SMS_GROUP.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PDA_SMS_GROUP.TabIndex = 69;
            this.lbl01_PDA_SMS_GROUP.Tag = null;
            this.lbl01_PDA_SMS_GROUP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PDA_SMS_GROUP.Value = "호출 그룹";
            // 
            // cbo01_SMS_TYPE
            // 
            this.cbo01_SMS_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SMS_TYPE.FormattingEnabled = true;
            this.cbo01_SMS_TYPE.Location = new System.Drawing.Point(345, 12);
            this.cbo01_SMS_TYPE.Name = "cbo01_SMS_TYPE";
            this.cbo01_SMS_TYPE.Size = new System.Drawing.Size(203, 20);
            this.cbo01_SMS_TYPE.TabIndex = 68;
            this.cbo01_SMS_TYPE.SelectedIndexChanged += new System.EventHandler(this.cbo01_SMS_TYPE_SelectedIndexChanged);
            // 
            // lbl01_SMS_TYPE
            // 
            this.lbl01_SMS_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_SMS_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_SMS_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SMS_TYPE.Location = new System.Drawing.Point(239, 12);
            this.lbl01_SMS_TYPE.Name = "lbl01_SMS_TYPE";
            this.lbl01_SMS_TYPE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SMS_TYPE.TabIndex = 67;
            this.lbl01_SMS_TYPE.Tag = null;
            this.lbl01_SMS_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SMS_TYPE.Value = "호출 업무";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 12);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 66;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 12);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 65;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // grp01_PDA_SMS_TARGET
            // 
            this.grp01_PDA_SMS_TARGET.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PDA_SMS_TARGET.Controls.Add(this.grd02);
            this.grp01_PDA_SMS_TARGET.Location = new System.Drawing.Point(511, 80);
            this.grp01_PDA_SMS_TARGET.Name = "grp01_PDA_SMS_TARGET";
            this.grp01_PDA_SMS_TARGET.Size = new System.Drawing.Size(513, 685);
            this.grp01_PDA_SMS_TARGET.TabIndex = 9;
            this.grp01_PDA_SMS_TARGET.TabStop = false;
            this.grp01_PDA_SMS_TARGET.Text = "PDA - SMS 호출 대상";
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
            this.grd02.Size = new System.Drawing.Size(507, 665);
            this.grd02.TabIndex = 9;
            this.grd02.UseCustomHighlight = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbl02_LINECD);
            this.groupBox4.Controls.Add(this.btn02_SAVE);
            this.groupBox4.Controls.Add(this.btn02_INQUERY);
            this.groupBox4.Controls.Add(this.txt02_NAME_KOR);
            this.groupBox4.Controls.Add(this.lbl02_HR_NAME);
            this.groupBox4.Controls.Add(this.lbl02_DEPART);
            this.groupBox4.Location = new System.Drawing.Point(0, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(502, 70);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // cbl02_LINECD
            // 
            this.cbl02_LINECD.AddItemSeparator = ';';
            this.cbl02_LINECD.Caption = "";
            this.cbl02_LINECD.CaptionHeight = 17;
            this.cbl02_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl02_LINECD.ColumnCaptionHeight = 18;
            this.cbl02_LINECD.ColumnFooterHeight = 18;
            this.cbl02_LINECD.ContentHeight = 16;
            this.cbl02_LINECD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl02_LINECD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl02_LINECD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl02_LINECD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl02_LINECD.EditorHeight = 16;
            this.cbl02_LINECD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl02_LINECD.Images"))));
            this.cbl02_LINECD.ItemHeight = 15;
            this.cbl02_LINECD.Location = new System.Drawing.Point(112, 16);
            this.cbl02_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl02_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl02_LINECD.MaxLength = 32767;
            this.cbl02_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl02_LINECD.Name = "cbl02_LINECD";
            this.cbl02_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl02_LINECD.Size = new System.Drawing.Size(203, 22);
            this.cbl02_LINECD.TabIndex = 78;
            this.cbl02_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl02_LINECD_BeforeOpen);
            this.cbl02_LINECD.PropBag = resources.GetString("cbl02_LINECD.PropBag");
            // 
            // btn02_SAVE
            // 
            this.btn02_SAVE.Location = new System.Drawing.Point(421, 41);
            this.btn02_SAVE.Name = "btn02_SAVE";
            this.btn02_SAVE.Size = new System.Drawing.Size(75, 23);
            this.btn02_SAVE.TabIndex = 77;
            this.btn02_SAVE.Text = "등록_";
            this.btn02_SAVE.UseVisualStyleBackColor = true;
            this.btn02_SAVE.Click += new System.EventHandler(this.btn02_SAV_Click);
            // 
            // btn02_INQUERY
            // 
            this.btn02_INQUERY.Location = new System.Drawing.Point(421, 16);
            this.btn02_INQUERY.Name = "btn02_INQUERY";
            this.btn02_INQUERY.Size = new System.Drawing.Size(75, 23);
            this.btn02_INQUERY.TabIndex = 76;
            this.btn02_INQUERY.Text = "조회_";
            this.btn02_INQUERY.UseVisualStyleBackColor = true;
            this.btn02_INQUERY.Click += new System.EventHandler(this.btn02_INQ_Click);
            // 
            // txt02_NAME_KOR
            // 
            this.txt02_NAME_KOR.Location = new System.Drawing.Point(112, 42);
            this.txt02_NAME_KOR.Name = "txt02_NAME_KOR";
            this.txt02_NAME_KOR.Size = new System.Drawing.Size(203, 21);
            this.txt02_NAME_KOR.TabIndex = 75;
            this.txt02_NAME_KOR.Tag = null;
            // 
            // lbl02_HR_NAME
            // 
            this.lbl02_HR_NAME.AutoFontSizeMaxValue = 9F;
            this.lbl02_HR_NAME.AutoFontSizeMinValue = 9F;
            this.lbl02_HR_NAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_HR_NAME.Location = new System.Drawing.Point(6, 42);
            this.lbl02_HR_NAME.Name = "lbl02_HR_NAME";
            this.lbl02_HR_NAME.Size = new System.Drawing.Size(100, 21);
            this.lbl02_HR_NAME.TabIndex = 74;
            this.lbl02_HR_NAME.Tag = null;
            this.lbl02_HR_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_HR_NAME.Value = "이름";
            // 
            // lbl02_DEPART
            // 
            this.lbl02_DEPART.AutoFontSizeMaxValue = 9F;
            this.lbl02_DEPART.AutoFontSizeMinValue = 9F;
            this.lbl02_DEPART.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_DEPART.Location = new System.Drawing.Point(6, 17);
            this.lbl02_DEPART.Name = "lbl02_DEPART";
            this.lbl02_DEPART.Size = new System.Drawing.Size(100, 21);
            this.lbl02_DEPART.TabIndex = 72;
            this.lbl02_DEPART.Tag = null;
            this.lbl02_DEPART.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_DEPART.Value = "부서";
            // 
            // PD20340
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grp01_PDA_SMS_TARGET);
            this.Controls.Add(this.grp01_EMPLIST);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20340";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_EMPLIST, 0);
            this.Controls.SetChildIndex(this.grp01_PDA_SMS_TARGET, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.grp01_EMPLIST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PDA_SMS_GROUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SMS_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.grp01_PDA_SMS_TARGET.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NAME_KOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_HR_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DEPART)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_EMPLIST;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_GRID_MERGE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PDA_SMS_GROUP;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PDA_SMS_GROUP;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SMS_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SMS_TYPE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private System.Windows.Forms.GroupBox grp01_PDA_SMS_TARGET;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.GroupBox groupBox4;
        private Ax.DEV.Utility.Controls.AxButton btn02_SAVE;
        private Ax.DEV.Utility.Controls.AxButton btn02_INQUERY;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_NAME_KOR;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_HR_NAME;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_DEPART;
        private Ax.DEV.Utility.Controls.AxComboList cbl02_LINECD;
    }
}
