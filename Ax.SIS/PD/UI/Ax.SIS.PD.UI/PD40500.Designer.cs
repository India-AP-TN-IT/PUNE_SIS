namespace Ax.SIS.PD.UI
{
    partial class PD40500
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40500));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.heDateEdit2 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.heDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_DD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl02_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl02_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl03_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_COR = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.heTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.heTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MGRT_CNTT = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ODD_REASON = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COR)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MGRT_CNTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ODD_REASON)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Location = new System.Drawing.Point(254, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 537);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
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
            this.grd01.Size = new System.Drawing.Size(764, 517);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.SelChange += new System.EventHandler(this.grd01_SelChange);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.heDateEdit2);
            this.groupBox1.Controls.Add(this.heDateEdit1);
            this.groupBox1.Controls.Add(this.lbl01_DD);
            this.groupBox1.Controls.Add(this.cbl01_LINECD);
            this.groupBox1.Controls.Add(this.lbl02_LINE);
            this.groupBox1.Controls.Add(this.cbl02_INSTALL_POS);
            this.groupBox1.Controls.Add(this.lbl03_POSTITLE);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.cbo01_CORCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.lbl01_COR);
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 731);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 109;
            this.label1.Text = "~";
            // 
            // heDateEdit2
            // 
            this.heDateEdit2.CustomFormat = "yyyy-MM-dd";
            this.heDateEdit2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.heDateEdit2.Location = new System.Drawing.Point(132, 89);
            this.heDateEdit2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.heDateEdit2.Name = "heDateEdit2";
            this.heDateEdit2.OriginalFormat = "";
            this.heDateEdit2.Size = new System.Drawing.Size(103, 21);
            this.heDateEdit2.TabIndex = 108;
            // 
            // heDateEdit1
            // 
            this.heDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.heDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.heDateEdit1.Location = new System.Drawing.Point(8, 89);
            this.heDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.heDateEdit1.Name = "heDateEdit1";
            this.heDateEdit1.OriginalFormat = "";
            this.heDateEdit1.Size = new System.Drawing.Size(103, 21);
            this.heDateEdit1.TabIndex = 107;
            // 
            // lbl01_DD
            // 
            this.lbl01_DD.AutoFontSizeMaxValue = 9F;
            this.lbl01_DD.AutoFontSizeMinValue = 9F;
            this.lbl01_DD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DD.Location = new System.Drawing.Point(6, 65);
            this.lbl01_DD.Name = "lbl01_DD";
            this.lbl01_DD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_DD.TabIndex = 106;
            this.lbl01_DD.Tag = null;
            this.lbl01_DD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DD.Value = "일자";
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(8, 155);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(227, 22);
            this.cbl01_LINECD.TabIndex = 105;
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // lbl02_LINE
            // 
            this.lbl02_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl02_LINE.AutoFontSizeMinValue = 9F;
            this.lbl02_LINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_LINE.Location = new System.Drawing.Point(8, 130);
            this.lbl02_LINE.Name = "lbl02_LINE";
            this.lbl02_LINE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_LINE.TabIndex = 104;
            this.lbl02_LINE.Tag = null;
            this.lbl02_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_LINE.Value = "라인";
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
            this.cbl02_INSTALL_POS.Location = new System.Drawing.Point(114, 179);
            this.cbl02_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl02_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl02_INSTALL_POS.MaxLength = 32767;
            this.cbl02_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl02_INSTALL_POS.Name = "cbl02_INSTALL_POS";
            this.cbl02_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl02_INSTALL_POS.Size = new System.Drawing.Size(120, 22);
            this.cbl02_INSTALL_POS.TabIndex = 103;
            this.cbl02_INSTALL_POS.PropBag = resources.GetString("cbl02_INSTALL_POS.PropBag");
            // 
            // lbl03_POSTITLE
            // 
            this.lbl03_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl03_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl03_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_POSTITLE.Location = new System.Drawing.Point(8, 180);
            this.lbl03_POSTITLE.Name = "lbl03_POSTITLE";
            this.lbl03_POSTITLE.Size = new System.Drawing.Size(100, 21);
            this.lbl03_POSTITLE.TabIndex = 102;
            this.lbl03_POSTITLE.Tag = null;
            this.lbl03_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl03_POSTITLE.Value = "장착위치";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(114, 38);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 69;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(114, 12);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_CORCD.TabIndex = 68;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 38);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 67;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // lbl01_COR
            // 
            this.lbl01_COR.AutoFontSizeMaxValue = 9F;
            this.lbl01_COR.AutoFontSizeMinValue = 9F;
            this.lbl01_COR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_COR.Location = new System.Drawing.Point(6, 12);
            this.lbl01_COR.Name = "lbl01_COR";
            this.lbl01_COR.Size = new System.Drawing.Size(100, 21);
            this.lbl01_COR.TabIndex = 65;
            this.lbl01_COR.Tag = null;
            this.lbl01_COR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_COR.Value = "법인";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.heTextBox2);
            this.groupBox3.Controls.Add(this.heTextBox1);
            this.groupBox3.Controls.Add(this.lbl01_MGRT_CNTT);
            this.groupBox3.Controls.Add(this.lbl01_ODD_REASON);
            this.groupBox3.Location = new System.Drawing.Point(257, 577);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(767, 188);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // heTextBox2
            // 
            this.heTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heTextBox2.Location = new System.Drawing.Point(113, 79);
            this.heTextBox2.Multiline = true;
            this.heTextBox2.Name = "heTextBox2";
            this.heTextBox2.Size = new System.Drawing.Size(648, 103);
            this.heTextBox2.TabIndex = 69;
            this.heTextBox2.Tag = null;
            // 
            // heTextBox1
            // 
            this.heTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heTextBox1.Location = new System.Drawing.Point(113, 12);
            this.heTextBox1.Multiline = true;
            this.heTextBox1.Name = "heTextBox1";
            this.heTextBox1.Size = new System.Drawing.Size(648, 61);
            this.heTextBox1.TabIndex = 68;
            this.heTextBox1.Tag = null;
            // 
            // lbl01_MGRT_CNTT
            // 
            this.lbl01_MGRT_CNTT.AutoFontSizeMaxValue = 9F;
            this.lbl01_MGRT_CNTT.AutoFontSizeMinValue = 9F;
            this.lbl01_MGRT_CNTT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MGRT_CNTT.Location = new System.Drawing.Point(6, 77);
            this.lbl01_MGRT_CNTT.Name = "lbl01_MGRT_CNTT";
            this.lbl01_MGRT_CNTT.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MGRT_CNTT.TabIndex = 67;
            this.lbl01_MGRT_CNTT.Tag = null;
            this.lbl01_MGRT_CNTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MGRT_CNTT.Value = "조치내용";
            // 
            // lbl01_ODD_REASON
            // 
            this.lbl01_ODD_REASON.AutoFontSizeMaxValue = 9F;
            this.lbl01_ODD_REASON.AutoFontSizeMinValue = 9F;
            this.lbl01_ODD_REASON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ODD_REASON.Location = new System.Drawing.Point(6, 12);
            this.lbl01_ODD_REASON.Name = "lbl01_ODD_REASON";
            this.lbl01_ODD_REASON.Size = new System.Drawing.Size(100, 21);
            this.lbl01_ODD_REASON.TabIndex = 65;
            this.lbl01_ODD_REASON.Tag = null;
            this.lbl01_ODD_REASON.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ODD_REASON.Value = "원인";
            // 
            // PD40500
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD40500";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl02_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COR)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MGRT_CNTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ODD_REASON)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_COR;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_LINE;
        private Ax.DEV.Utility.Controls.AxComboList cbl02_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_POSTITLE;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MGRT_CNTT;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ODD_REASON;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox2;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox1;
        private Ax.DEV.Utility.Controls.AxDateEdit heDateEdit1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DD;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit heDateEdit2;
    }
}
