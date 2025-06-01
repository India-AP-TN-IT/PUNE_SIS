namespace Ax.SIS.PD.UI
{
    partial class PD20410
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20410));
            this.grp01_PD20410_GRP1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_VINCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_VIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_YYYY = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_YYYY = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CHK_SEQ = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INSP_SEQ = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grp01_PD20410_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_YYYY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSP_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp01_PD20410_GRP1
            // 
            this.grp01_PD20410_GRP1.Controls.Add(this.grd01);
            this.grp01_PD20410_GRP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD20410_GRP1.Location = new System.Drawing.Point(0, 209);
            this.grp01_PD20410_GRP1.Name = "grp01_PD20410_GRP1";
            this.grp01_PD20410_GRP1.Size = new System.Drawing.Size(1024, 559);
            this.grp01_PD20410_GRP1.TabIndex = 8;
            this.grp01_PD20410_GRP1.TabStop = false;
            this.grp01_PD20410_GRP1.Text = "PALET 관리 정보( ○ : 양호, X : 수리필요, ◎ : 수리완료)";
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
            this.grd01.Size = new System.Drawing.Size(1018, 539);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbl01_INSTALL_POS);
            this.groupBox1.Controls.Add(this.lbl01_POSTITLE);
            this.groupBox1.Controls.Add(this.cbl01_VINCD);
            this.groupBox1.Controls.Add(this.lbl01_VIN);
            this.groupBox1.Controls.Add(this.dte01_YYYY);
            this.groupBox1.Controls.Add(this.lbl01_YYYY);
            this.groupBox1.Controls.Add(this.cbo01_TYPE);
            this.groupBox1.Controls.Add(this.lbl01_TYPE);
            this.groupBox1.Controls.Add(this.cbo01_CHK_SEQ);
            this.groupBox1.Controls.Add(this.lbl01_INSP_SEQ);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 72);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbl01_INSTALL_POS
            // 
            this.cbl01_INSTALL_POS.AddItemSeparator = ';';
            this.cbl01_INSTALL_POS.Caption = "";
            this.cbl01_INSTALL_POS.CaptionHeight = 17;
            this.cbl01_INSTALL_POS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_INSTALL_POS.ColumnCaptionHeight = 18;
            this.cbl01_INSTALL_POS.ColumnFooterHeight = 18;
            this.cbl01_INSTALL_POS.ContentHeight = 16;
            this.cbl01_INSTALL_POS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_INSTALL_POS.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_INSTALL_POS.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_INSTALL_POS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_INSTALL_POS.EditorHeight = 16;
            this.cbl01_INSTALL_POS.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_INSTALL_POS.Images"))));
            this.cbl01_INSTALL_POS.ItemHeight = 15;
            this.cbl01_INSTALL_POS.Location = new System.Drawing.Point(618, 39);
            this.cbl01_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl01_INSTALL_POS.MaxLength = 32767;
            this.cbl01_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INSTALL_POS.Name = "cbl01_INSTALL_POS";
            this.cbl01_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INSTALL_POS.Size = new System.Drawing.Size(121, 22);
            this.cbl01_INSTALL_POS.TabIndex = 91;
            this.cbl01_INSTALL_POS.SelectedValueChanged += new System.EventHandler(this.cbl01_INSTALL_POS_SelectedValueChanged);
            this.cbl01_INSTALL_POS.PropBag = resources.GetString("cbl01_INSTALL_POS.PropBag");
            // 
            // lbl01_POSTITLE
            // 
            this.lbl01_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_POSTITLE.Location = new System.Drawing.Point(512, 40);
            this.lbl01_POSTITLE.Name = "lbl01_POSTITLE";
            this.lbl01_POSTITLE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_POSTITLE.TabIndex = 90;
            this.lbl01_POSTITLE.Tag = null;
            this.lbl01_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_POSTITLE.Value = "위치";
            // 
            // cbl01_VINCD
            // 
            this.cbl01_VINCD.AddItemSeparator = ';';
            this.cbl01_VINCD.Caption = "";
            this.cbl01_VINCD.CaptionHeight = 17;
            this.cbl01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_VINCD.ColumnCaptionHeight = 18;
            this.cbl01_VINCD.ColumnFooterHeight = 18;
            this.cbl01_VINCD.ContentHeight = 16;
            this.cbl01_VINCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_VINCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_VINCD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_VINCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_VINCD.EditorHeight = 16;
            this.cbl01_VINCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_VINCD.Images"))));
            this.cbl01_VINCD.ItemHeight = 15;
            this.cbl01_VINCD.Location = new System.Drawing.Point(349, 39);
            this.cbl01_VINCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_VINCD.MaxDropDownItems = ((short)(5));
            this.cbl01_VINCD.MaxLength = 32767;
            this.cbl01_VINCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_VINCD.Name = "cbl01_VINCD";
            this.cbl01_VINCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_VINCD.Size = new System.Drawing.Size(156, 22);
            this.cbl01_VINCD.TabIndex = 89;
            this.cbl01_VINCD.SelectedValueChanged += new System.EventHandler(this.cbl01_VINCD_SelectedValueChanged);
            this.cbl01_VINCD.PropBag = resources.GetString("cbl01_VINCD.PropBag");
            // 
            // lbl01_VIN
            // 
            this.lbl01_VIN.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIN.AutoFontSizeMinValue = 9F;
            this.lbl01_VIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VIN.Location = new System.Drawing.Point(246, 40);
            this.lbl01_VIN.Name = "lbl01_VIN";
            this.lbl01_VIN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VIN.TabIndex = 65;
            this.lbl01_VIN.Tag = null;
            this.lbl01_VIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VIN.Value = "차종";
            // 
            // dte01_YYYY
            // 
            this.dte01_YYYY.CustomFormat = "yyyy";
            this.dte01_YYYY.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_YYYY.Location = new System.Drawing.Point(349, 12);
            this.dte01_YYYY.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_YYYY.Name = "dte01_YYYY";
            this.dte01_YYYY.OriginalFormat = "";
            this.dte01_YYYY.Size = new System.Drawing.Size(121, 21);
            this.dte01_YYYY.TabIndex = 64;
            this.dte01_YYYY.ValueChanged += new System.EventHandler(this.dte01_JOB_DATE_ValueChanged);
            // 
            // lbl01_YYYY
            // 
            this.lbl01_YYYY.AutoFontSizeMaxValue = 9F;
            this.lbl01_YYYY.AutoFontSizeMinValue = 9F;
            this.lbl01_YYYY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_YYYY.Location = new System.Drawing.Point(246, 14);
            this.lbl01_YYYY.Name = "lbl01_YYYY";
            this.lbl01_YYYY.Size = new System.Drawing.Size(100, 21);
            this.lbl01_YYYY.TabIndex = 63;
            this.lbl01_YYYY.Tag = null;
            this.lbl01_YYYY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_YYYY.Value = "년도";
            // 
            // cbo01_TYPE
            // 
            this.cbo01_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_TYPE.FormattingEnabled = true;
            this.cbo01_TYPE.Location = new System.Drawing.Point(110, 40);
            this.cbo01_TYPE.Name = "cbo01_TYPE";
            this.cbo01_TYPE.Size = new System.Drawing.Size(128, 20);
            this.cbo01_TYPE.TabIndex = 60;
            this.cbo01_TYPE.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // lbl01_TYPE
            // 
            this.lbl01_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_TYPE.Location = new System.Drawing.Point(6, 40);
            this.lbl01_TYPE.Name = "lbl01_TYPE";
            this.lbl01_TYPE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_TYPE.TabIndex = 59;
            this.lbl01_TYPE.Tag = null;
            this.lbl01_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_TYPE.Value = "구분";
            // 
            // cbo01_CHK_SEQ
            // 
            this.cbo01_CHK_SEQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CHK_SEQ.FormattingEnabled = true;
            this.cbo01_CHK_SEQ.Location = new System.Drawing.Point(618, 13);
            this.cbo01_CHK_SEQ.Name = "cbo01_CHK_SEQ";
            this.cbo01_CHK_SEQ.Size = new System.Drawing.Size(121, 20);
            this.cbo01_CHK_SEQ.TabIndex = 56;
            this.cbo01_CHK_SEQ.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // lbl01_INSP_SEQ
            // 
            this.lbl01_INSP_SEQ.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSP_SEQ.AutoFontSizeMinValue = 9F;
            this.lbl01_INSP_SEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INSP_SEQ.Location = new System.Drawing.Point(512, 13);
            this.lbl01_INSP_SEQ.Name = "lbl01_INSP_SEQ";
            this.lbl01_INSP_SEQ.Size = new System.Drawing.Size(100, 21);
            this.lbl01_INSP_SEQ.TabIndex = 55;
            this.lbl01_INSP_SEQ.Tag = null;
            this.lbl01_INSP_SEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSP_SEQ.Value = "점검차수";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(6, 14);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 54;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(110, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(128, 20);
            this.cbo01_BIZCD.TabIndex = 53;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Left;
            this.grd02.EnabledActionFlag = true;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(502, 80);
            this.grd02.TabIndex = 90;
            this.grd02.UseCustomHighlight = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd02);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 206);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1024, 3);
            this.splitter1.TabIndex = 91;
            this.splitter1.TabStop = false;
            // 
            // PD20410
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD20410_GRP1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20410";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.grp01_PD20410_GRP1, 0);
            this.grp01_PD20410_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_YYYY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSP_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD20410_GRP1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_TYPE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_CHK_SEQ;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSP_SEQ;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_YYYY;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_YYYY;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VIN;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_VINCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Splitter splitter1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_POSTITLE;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSTALL_POS;
    }
}
