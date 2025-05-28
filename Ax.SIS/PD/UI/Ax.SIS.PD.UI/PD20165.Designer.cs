namespace Ax.SIS.PD.UI
{
    partial class PD20165
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20165));
            this.grp01_PD20165_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl02_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl02_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl03_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp02_PD20165_2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.btn02_ALL_COPY = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_SELECT_COPY = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl01_PD20165_NOTE_1 = new System.Windows.Forms.Label();
            this.btn03_SELECT_DEL = new Ax.DEV.Utility.Controls.AxButton();
            this.btn04_ALL_DEL = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl01_PD20165_NOTE_2 = new System.Windows.Forms.Label();
            this.lbl01_PD20165_NOTE_3 = new System.Windows.Forms.Label();
            this.lbl01_PD20165_NOTE_4 = new System.Windows.Forms.Label();
            this.lbl01_PD20165_NOTE_5 = new System.Windows.Forms.Label();
            this.grp01_PD20165_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_POSTITLE)).BeginInit();
            this.grp02_PD20165_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD20165_1
            // 
            this.grp01_PD20165_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp01_PD20165_1.Controls.Add(this.grd01);
            this.grp01_PD20165_1.Location = new System.Drawing.Point(3, 119);
            this.grp01_PD20165_1.Name = "grp01_PD20165_1";
            this.grp01_PD20165_1.Size = new System.Drawing.Size(405, 636);
            this.grp01_PD20165_1.TabIndex = 8;
            this.grp01_PD20165_1.TabStop = false;
            this.grp01_PD20165_1.Text = "공정정보";
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
            this.grd01.Size = new System.Drawing.Size(399, 616);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbl01_LINECD);
            this.groupBox1.Controls.Add(this.lbl02_LINE);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbl02_INSTALL_POS);
            this.groupBox1.Controls.Add(this.lbl03_POSTITLE);
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1021, 67);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(437, 10);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(202, 22);
            this.cbl01_LINECD.TabIndex = 101;
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // lbl02_LINE
            // 
            this.lbl02_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl02_LINE.AutoFontSizeMinValue = 9F;
            this.lbl02_LINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_LINE.Location = new System.Drawing.Point(291, 11);
            this.lbl02_LINE.Name = "lbl02_LINE";
            this.lbl02_LINE.Size = new System.Drawing.Size(140, 21);
            this.lbl02_LINE.TabIndex = 100;
            this.lbl02_LINE.Tag = null;
            this.lbl02_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_LINE.Value = "라인";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(155, 12);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 103;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(9, 12);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(140, 21);
            this.lbl01_BIZNM2.TabIndex = 102;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbl02_INSTALL_POS
            // 
            this.cbl02_INSTALL_POS.AddItemSeparator = ';';
            this.cbl02_INSTALL_POS.Caption = "";
            this.cbl02_INSTALL_POS.CaptionHeight = 17;
            this.cbl02_INSTALL_POS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl02_INSTALL_POS.ColumnCaptionHeight = 18;
            this.cbl02_INSTALL_POS.ColumnFooterHeight = 18;
            this.cbl02_INSTALL_POS.ContentHeight = 16;
            this.cbl02_INSTALL_POS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl02_INSTALL_POS.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl02_INSTALL_POS.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl02_INSTALL_POS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl02_INSTALL_POS.EditorHeight = 16;
            this.cbl02_INSTALL_POS.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl02_INSTALL_POS.Images"))));
            this.cbl02_INSTALL_POS.ItemHeight = 15;
            this.cbl02_INSTALL_POS.Location = new System.Drawing.Point(437, 39);
            this.cbl02_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl02_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl02_INSTALL_POS.MaxLength = 32767;
            this.cbl02_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl02_INSTALL_POS.Name = "cbl02_INSTALL_POS";
            this.cbl02_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl02_INSTALL_POS.Size = new System.Drawing.Size(120, 22);
            this.cbl02_INSTALL_POS.TabIndex = 97;
            this.cbl02_INSTALL_POS.PropBag = resources.GetString("cbl02_INSTALL_POS.PropBag");
            // 
            // lbl03_POSTITLE
            // 
            this.lbl03_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl03_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl03_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_POSTITLE.Location = new System.Drawing.Point(291, 40);
            this.lbl03_POSTITLE.Name = "lbl03_POSTITLE";
            this.lbl03_POSTITLE.Size = new System.Drawing.Size(140, 21);
            this.lbl03_POSTITLE.TabIndex = 96;
            this.lbl03_POSTITLE.Tag = null;
            this.lbl03_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl03_POSTITLE.Value = "장착위치";
            // 
            // grp02_PD20165_2
            // 
            this.grp02_PD20165_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp02_PD20165_2.Controls.Add(this.flowLayoutPanel1);
            this.grp02_PD20165_2.Controls.Add(this.grd02);
            this.grp02_PD20165_2.Location = new System.Drawing.Point(504, 119);
            this.grp02_PD20165_2.Name = "grp02_PD20165_2";
            this.grp02_PD20165_2.Size = new System.Drawing.Size(517, 571);
            this.grp02_PD20165_2.TabIndex = 9;
            this.grp02_PD20165_2.TabStop = false;
            this.grp02_PD20165_2.Text = "통전사양";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(505, 213);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 239);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(508, 326);
            this.grd02.TabIndex = 8;
            this.grd02.UseCustomHighlight = true;
            // 
            // btn02_ALL_COPY
            // 
            this.btn02_ALL_COPY.Location = new System.Drawing.Point(414, 201);
            this.btn02_ALL_COPY.Name = "btn02_ALL_COPY";
            this.btn02_ALL_COPY.Size = new System.Drawing.Size(71, 46);
            this.btn02_ALL_COPY.TabIndex = 94;
            this.btn02_ALL_COPY.Text = "▶▶\r\n전체복사";
            this.btn02_ALL_COPY.UseVisualStyleBackColor = true;
            this.btn02_ALL_COPY.Click += new System.EventHandler(this.btn02_BUP_Click);
            // 
            // btn01_SELECT_COPY
            // 
            this.btn01_SELECT_COPY.Location = new System.Drawing.Point(414, 149);
            this.btn01_SELECT_COPY.Name = "btn01_SELECT_COPY";
            this.btn01_SELECT_COPY.Size = new System.Drawing.Size(71, 46);
            this.btn01_SELECT_COPY.TabIndex = 95;
            this.btn01_SELECT_COPY.Text = "▶\r\n선택복사";
            this.btn01_SELECT_COPY.UseVisualStyleBackColor = true;
            this.btn01_SELECT_COPY.Click += new System.EventHandler(this.heButton1_Click);
            // 
            // lbl01_PD20165_NOTE_1
            // 
            this.lbl01_PD20165_NOTE_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl01_PD20165_NOTE_1.AutoSize = true;
            this.lbl01_PD20165_NOTE_1.ForeColor = System.Drawing.Color.Black;
            this.lbl01_PD20165_NOTE_1.Location = new System.Drawing.Point(502, 693);
            this.lbl01_PD20165_NOTE_1.Name = "lbl01_PD20165_NOTE_1";
            this.lbl01_PD20165_NOTE_1.Size = new System.Drawing.Size(79, 12);
            this.lbl01_PD20165_NOTE_1.TabIndex = 96;
            this.lbl01_PD20165_NOTE_1.Text = "* 선택복사시 ";
            // 
            // btn03_SELECT_DEL
            // 
            this.btn03_SELECT_DEL.Location = new System.Drawing.Point(414, 427);
            this.btn03_SELECT_DEL.Name = "btn03_SELECT_DEL";
            this.btn03_SELECT_DEL.Size = new System.Drawing.Size(71, 46);
            this.btn03_SELECT_DEL.TabIndex = 98;
            this.btn03_SELECT_DEL.Text = "◀\r\n선택삭제";
            this.btn03_SELECT_DEL.UseVisualStyleBackColor = true;
            this.btn03_SELECT_DEL.Click += new System.EventHandler(this.heButton2_Click);
            // 
            // btn04_ALL_DEL
            // 
            this.btn04_ALL_DEL.Location = new System.Drawing.Point(414, 479);
            this.btn04_ALL_DEL.Name = "btn04_ALL_DEL";
            this.btn04_ALL_DEL.Size = new System.Drawing.Size(71, 46);
            this.btn04_ALL_DEL.TabIndex = 97;
            this.btn04_ALL_DEL.Text = "◀◀\r\n전체삭제";
            this.btn04_ALL_DEL.UseVisualStyleBackColor = true;
            this.btn04_ALL_DEL.Click += new System.EventHandler(this.heButton3_Click);
            // 
            // lbl01_PD20165_NOTE_2
            // 
            this.lbl01_PD20165_NOTE_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl01_PD20165_NOTE_2.AutoSize = true;
            this.lbl01_PD20165_NOTE_2.ForeColor = System.Drawing.Color.Black;
            this.lbl01_PD20165_NOTE_2.Location = new System.Drawing.Point(502, 707);
            this.lbl01_PD20165_NOTE_2.Name = "lbl01_PD20165_NOTE_2";
            this.lbl01_PD20165_NOTE_2.Size = new System.Drawing.Size(244, 12);
            this.lbl01_PD20165_NOTE_2.TabIndex = 99;
            this.lbl01_PD20165_NOTE_2.Text = " 1) 화면 좌측의 [공정정보]에서 공정을 선택";
            // 
            // lbl01_PD20165_NOTE_3
            // 
            this.lbl01_PD20165_NOTE_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl01_PD20165_NOTE_3.AutoSize = true;
            this.lbl01_PD20165_NOTE_3.ForeColor = System.Drawing.Color.Black;
            this.lbl01_PD20165_NOTE_3.Location = new System.Drawing.Point(502, 721);
            this.lbl01_PD20165_NOTE_3.Name = "lbl01_PD20165_NOTE_3";
            this.lbl01_PD20165_NOTE_3.Size = new System.Drawing.Size(292, 12);
            this.lbl01_PD20165_NOTE_3.TabIndex = 100;
            this.lbl01_PD20165_NOTE_3.Text = " 2) 화면 우측상단의 [통전사양]버튼중 적정사양 선택";
            // 
            // lbl01_PD20165_NOTE_4
            // 
            this.lbl01_PD20165_NOTE_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl01_PD20165_NOTE_4.AutoSize = true;
            this.lbl01_PD20165_NOTE_4.ForeColor = System.Drawing.Color.Black;
            this.lbl01_PD20165_NOTE_4.Location = new System.Drawing.Point(502, 735);
            this.lbl01_PD20165_NOTE_4.Name = "lbl01_PD20165_NOTE_4";
            this.lbl01_PD20165_NOTE_4.Size = new System.Drawing.Size(510, 12);
            this.lbl01_PD20165_NOTE_4.TabIndex = 100;
            this.lbl01_PD20165_NOTE_4.Text = " 3) 화면 우측하단의 [통전사양] 그리드의 [공정코드] 혹은 [공정명]을 선택(초기는 비어있음)";
            // 
            // lbl01_PD20165_NOTE_5
            // 
            this.lbl01_PD20165_NOTE_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl01_PD20165_NOTE_5.AutoSize = true;
            this.lbl01_PD20165_NOTE_5.ForeColor = System.Drawing.Color.Black;
            this.lbl01_PD20165_NOTE_5.Location = new System.Drawing.Point(502, 749);
            this.lbl01_PD20165_NOTE_5.Name = "lbl01_PD20165_NOTE_5";
            this.lbl01_PD20165_NOTE_5.Size = new System.Drawing.Size(112, 12);
            this.lbl01_PD20165_NOTE_5.TabIndex = 100;
            this.lbl01_PD20165_NOTE_5.Text = " 4) [선택복사] 수행";
            // 
            // PD20165
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lbl01_PD20165_NOTE_5);
            this.Controls.Add(this.lbl01_PD20165_NOTE_4);
            this.Controls.Add(this.lbl01_PD20165_NOTE_3);
            this.Controls.Add(this.lbl01_PD20165_NOTE_2);
            this.Controls.Add(this.btn03_SELECT_DEL);
            this.Controls.Add(this.btn04_ALL_DEL);
            this.Controls.Add(this.lbl01_PD20165_NOTE_1);
            this.Controls.Add(this.btn01_SELECT_COPY);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp01_PD20165_1);
            this.Controls.Add(this.btn02_ALL_COPY);
            this.Controls.Add(this.grp02_PD20165_2);
            this.Name = "PD20165";
            this.Controls.SetChildIndex(this.grp02_PD20165_2, 0);
            this.Controls.SetChildIndex(this.btn02_ALL_COPY, 0);
            this.Controls.SetChildIndex(this.grp01_PD20165_1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.btn01_SELECT_COPY, 0);
            this.Controls.SetChildIndex(this.lbl01_PD20165_NOTE_1, 0);
            this.Controls.SetChildIndex(this.btn04_ALL_DEL, 0);
            this.Controls.SetChildIndex(this.btn03_SELECT_DEL, 0);
            this.Controls.SetChildIndex(this.lbl01_PD20165_NOTE_2, 0);
            this.Controls.SetChildIndex(this.lbl01_PD20165_NOTE_3, 0);
            this.Controls.SetChildIndex(this.lbl01_PD20165_NOTE_4, 0);
            this.Controls.SetChildIndex(this.lbl01_PD20165_NOTE_5, 0);
            this.grp01_PD20165_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_POSTITLE)).EndInit();
            this.grp02_PD20165_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD20165_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox grp02_PD20165_2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxComboList cbl02_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_POSTITLE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxButton btn02_ALL_COPY;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_LINE;
        private Ax.DEV.Utility.Controls.AxButton btn01_SELECT_COPY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbl01_PD20165_NOTE_1;
        private Ax.DEV.Utility.Controls.AxButton btn03_SELECT_DEL;
        private Ax.DEV.Utility.Controls.AxButton btn04_ALL_DEL;
        private System.Windows.Forms.Label lbl01_PD20165_NOTE_2;
        private System.Windows.Forms.Label lbl01_PD20165_NOTE_3;
        private System.Windows.Forms.Label lbl01_PD20165_NOTE_4;
        private System.Windows.Forms.Label lbl01_PD20165_NOTE_5;
    }
}
