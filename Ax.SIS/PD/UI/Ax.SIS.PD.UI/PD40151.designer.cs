namespace Ax.SIS.PD.UI
{
    partial class PD40151
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40151));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.dtp01_INSPEC_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl06_PROD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_ALCCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl05_ALC = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl04_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl03_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_PROD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ALCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_ALC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_INSTALL_POS);
            this.groupBox1.Controls.Add(this.dtp01_INSPEC_SDATE);
            this.groupBox1.Controls.Add(this.lbl06_PROD_DATE);
            this.groupBox1.Controls.Add(this.txt01_ALCCD);
            this.groupBox1.Controls.Add(this.lbl05_ALC);
            this.groupBox1.Controls.Add(this.txt01_LOTNO);
            this.groupBox1.Controls.Add(this.lbl04_LOTNO);
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.lbl03_POSTITLE);
            this.groupBox1.Controls.Add(this.lbl02_LINECD);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 92);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_INSTALL_POS
            // 
            this.cbo01_INSTALL_POS.AddItemSeparator = ';';
            this.cbo01_INSTALL_POS.Caption = "";
            this.cbo01_INSTALL_POS.CaptionHeight = 17;
            this.cbo01_INSTALL_POS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbo01_INSTALL_POS.ColumnCaptionHeight = 18;
            this.cbo01_INSTALL_POS.ColumnFooterHeight = 18;
            this.cbo01_INSTALL_POS.ContentHeight = 16;
            this.cbo01_INSTALL_POS.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbo01_INSTALL_POS.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbo01_INSTALL_POS.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo01_INSTALL_POS.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbo01_INSTALL_POS.EditorHeight = 16;
            this.cbo01_INSTALL_POS.Images.Add(((System.Drawing.Image)(resources.GetObject("cbo01_INSTALL_POS.Images"))));
            this.cbo01_INSTALL_POS.ItemHeight = 15;
            this.cbo01_INSTALL_POS.Location = new System.Drawing.Point(151, 39);
            this.cbo01_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbo01_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbo01_INSTALL_POS.MaxLength = 32767;
            this.cbo01_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbo01_INSTALL_POS.Name = "cbo01_INSTALL_POS";
            this.cbo01_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbo01_INSTALL_POS.Size = new System.Drawing.Size(130, 22);
            this.cbo01_INSTALL_POS.TabIndex = 98;
            this.cbo01_INSTALL_POS.PropBag = resources.GetString("cbo01_INSTALL_POS.PropBag");
            // 
            // dtp01_INSPEC_SDATE
            // 
            this.dtp01_INSPEC_SDATE.CustomFormat = "yyyy-MM";
            this.dtp01_INSPEC_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_INSPEC_SDATE.Location = new System.Drawing.Point(151, 65);
            this.dtp01_INSPEC_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_INSPEC_SDATE.Name = "dtp01_INSPEC_SDATE";
            this.dtp01_INSPEC_SDATE.OriginalFormat = "";
            this.dtp01_INSPEC_SDATE.Size = new System.Drawing.Size(80, 21);
            this.dtp01_INSPEC_SDATE.TabIndex = 95;
            // 
            // lbl06_PROD_DATE
            // 
            this.lbl06_PROD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl06_PROD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl06_PROD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl06_PROD_DATE.Location = new System.Drawing.Point(6, 65);
            this.lbl06_PROD_DATE.Name = "lbl06_PROD_DATE";
            this.lbl06_PROD_DATE.Size = new System.Drawing.Size(140, 21);
            this.lbl06_PROD_DATE.TabIndex = 88;
            this.lbl06_PROD_DATE.Tag = null;
            this.lbl06_PROD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl06_PROD_DATE.Value = "생산일자";
            // 
            // txt01_ALCCD
            // 
            this.txt01_ALCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_ALCCD.Location = new System.Drawing.Point(723, 41);
            this.txt01_ALCCD.Name = "txt01_ALCCD";
            this.txt01_ALCCD.Size = new System.Drawing.Size(100, 21);
            this.txt01_ALCCD.TabIndex = 21;
            this.txt01_ALCCD.Tag = null;
            // 
            // lbl05_ALC
            // 
            this.lbl05_ALC.AutoFontSizeMaxValue = 9F;
            this.lbl05_ALC.AutoFontSizeMinValue = 9F;
            this.lbl05_ALC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl05_ALC.Location = new System.Drawing.Point(579, 40);
            this.lbl05_ALC.Name = "lbl05_ALC";
            this.lbl05_ALC.Size = new System.Drawing.Size(140, 21);
            this.lbl05_ALC.TabIndex = 20;
            this.lbl05_ALC.Tag = null;
            this.lbl05_ALC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl05_ALC.Value = "ALC";
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_LOTNO.Location = new System.Drawing.Point(431, 41);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(142, 21);
            this.txt01_LOTNO.TabIndex = 19;
            this.txt01_LOTNO.Tag = null;
            // 
            // lbl04_LOTNO
            // 
            this.lbl04_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lbl04_LOTNO.AutoFontSizeMinValue = 9F;
            this.lbl04_LOTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl04_LOTNO.Location = new System.Drawing.Point(287, 40);
            this.lbl04_LOTNO.Name = "lbl04_LOTNO";
            this.lbl04_LOTNO.Size = new System.Drawing.Size(140, 21);
            this.lbl04_LOTNO.TabIndex = 18;
            this.lbl04_LOTNO.Tag = null;
            this.lbl04_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl04_LOTNO.Value = "LOTNO";
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(431, 14);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(142, 21);
            this.cdx01_LINECD.TabIndex = 14;
            this.cdx01_LINECD.Tag = null;
            // 
            // lbl03_POSTITLE
            // 
            this.lbl03_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl03_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl03_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_POSTITLE.Location = new System.Drawing.Point(6, 40);
            this.lbl03_POSTITLE.Name = "lbl03_POSTITLE";
            this.lbl03_POSTITLE.Size = new System.Drawing.Size(140, 21);
            this.lbl03_POSTITLE.TabIndex = 13;
            this.lbl03_POSTITLE.Tag = null;
            this.lbl03_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl03_POSTITLE.Value = "장착위치";
            // 
            // lbl02_LINECD
            // 
            this.lbl02_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl02_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl02_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_LINECD.Location = new System.Drawing.Point(287, 14);
            this.lbl02_LINECD.Name = "lbl02_LINECD";
            this.lbl02_LINECD.Size = new System.Drawing.Size(140, 21);
            this.lbl02_LINECD.TabIndex = 10;
            this.lbl02_LINECD.Tag = null;
            this.lbl02_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_LINECD.Value = "완제품 Line";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(151, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(140, 21);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 126);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 642);
            this.grd01.TabIndex = 9;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD40151
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD40151";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_PROD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ALCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_ALC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_POSTITLE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_LINECD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ALCCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl05_ALC;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl04_LOTNO;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl06_PROD_DATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_INSPEC_SDATE;
        private Ax.DEV.Utility.Controls.AxComboList cbo01_INSTALL_POS;
    }
}
