namespace Ax.SIS.PD.UI
{
    partial class PD40020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40020));
            this.grp01_PD40020 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbo01_FREASONCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl03_CLS_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_ALL_CHK = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl02_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD40020.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_CLS_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD40020
            // 
            this.grp01_PD40020.Controls.Add(this.grd01);
            this.grp01_PD40020.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD40020.Location = new System.Drawing.Point(0, 74);
            this.grp01_PD40020.Name = "grp01_PD40020";
            this.grp01_PD40020.Size = new System.Drawing.Size(1024, 694);
            this.grp01_PD40020.TabIndex = 8;
            this.grp01_PD40020.TabStop = false;
            this.grp01_PD40020.Text = "장기재고 리스트";
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
            this.grd01.Size = new System.Drawing.Size(1018, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbl01_INSTALL_POS);
            this.groupBox1.Controls.Add(this.cbo01_FREASONCD);
            this.groupBox1.Controls.Add(this.cbl01_LINECD);
            this.groupBox1.Controls.Add(this.lbl03_CLS_TYPE);
            this.groupBox1.Controls.Add(this.chk01_ALL_CHK);
            this.groupBox1.Controls.Add(this.lbl02_POSTITLE);
            this.groupBox1.Controls.Add(this.lbl01_LINE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
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
            this.cbl01_INSTALL_POS.Location = new System.Drawing.Point(493, 13);
            this.cbl01_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl01_INSTALL_POS.MaxLength = 32767;
            this.cbl01_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INSTALL_POS.Name = "cbl01_INSTALL_POS";
            this.cbl01_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INSTALL_POS.Size = new System.Drawing.Size(218, 22);
            this.cbl01_INSTALL_POS.TabIndex = 98;
            this.cbl01_INSTALL_POS.PropBag = resources.GetString("cbl01_INSTALL_POS.PropBag");
            // 
            // cbo01_FREASONCD
            // 
            this.cbo01_FREASONCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_FREASONCD.FormattingEnabled = true;
            this.cbo01_FREASONCD.Location = new System.Drawing.Point(939, 14);
            this.cbo01_FREASONCD.Name = "cbo01_FREASONCD";
            this.cbo01_FREASONCD.Size = new System.Drawing.Size(141, 20);
            this.cbo01_FREASONCD.TabIndex = 92;
            this.cbo01_FREASONCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_FREASONCD_SelectedIndexChanged);
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(150, 13);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(193, 22);
            this.cbl01_LINECD.TabIndex = 97;
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // lbl03_CLS_TYPE
            // 
            this.lbl03_CLS_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl03_CLS_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl03_CLS_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_CLS_TYPE.Location = new System.Drawing.Point(795, 14);
            this.lbl03_CLS_TYPE.Name = "lbl03_CLS_TYPE";
            this.lbl03_CLS_TYPE.Size = new System.Drawing.Size(140, 21);
            this.lbl03_CLS_TYPE.TabIndex = 91;
            this.lbl03_CLS_TYPE.Tag = null;
            this.lbl03_CLS_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl03_CLS_TYPE.Value = "해제사유";
            // 
            // chk01_ALL_CHK
            // 
            this.chk01_ALL_CHK.AutoSize = true;
            this.chk01_ALL_CHK.Location = new System.Drawing.Point(717, 16);
            this.chk01_ALL_CHK.Name = "chk01_ALL_CHK";
            this.chk01_ALL_CHK.Size = new System.Drawing.Size(76, 16);
            this.chk01_ALL_CHK.TabIndex = 90;
            this.chk01_ALL_CHK.Text = "전체 선택";
            this.chk01_ALL_CHK.UseVisualStyleBackColor = true;
            this.chk01_ALL_CHK.CheckedChanged += new System.EventHandler(this.chk01_SELECTED_CheckedChanged);
            // 
            // lbl02_POSTITLE
            // 
            this.lbl02_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl02_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl02_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_POSTITLE.Location = new System.Drawing.Point(349, 14);
            this.lbl02_POSTITLE.Name = "lbl02_POSTITLE";
            this.lbl02_POSTITLE.Size = new System.Drawing.Size(140, 21);
            this.lbl02_POSTITLE.TabIndex = 81;
            this.lbl02_POSTITLE.Tag = null;
            this.lbl02_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_POSTITLE.Value = "장착위치";
            // 
            // lbl01_LINE
            // 
            this.lbl01_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINE.AutoFontSizeMinValue = 9F;
            this.lbl01_LINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINE.Location = new System.Drawing.Point(6, 14);
            this.lbl01_LINE.Name = "lbl01_LINE";
            this.lbl01_LINE.Size = new System.Drawing.Size(140, 21);
            this.lbl01_LINE.TabIndex = 54;
            this.lbl01_LINE.Tag = null;
            this.lbl01_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINE.Value = "라인";
            // 
            // PD40020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD40020);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD40020";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD40020, 0);
            this.grp01_PD40020.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_CLS_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD40020;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_POSTITLE;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_ALL_CHK;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_CLS_TYPE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_FREASONCD;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
    }
}
