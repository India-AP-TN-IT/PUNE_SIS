namespace Ax.SIS.SD.UI
{
    partial class ZSD02170
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZSD02170));
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbl01_CustPLANT = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_CORNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.Txt_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.Dat_ST_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.Txt_ORDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel5 = new Ax.DEV.Utility.Controls.AxLabel();
            this.Lbl_Total = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustPLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ORDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).BeginInit();
            this.SuspendLayout();
            // 
            // axButton1
            // 
            this.axButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.axButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.axButton1.Location = new System.Drawing.Point(708, 95);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(140, 33);
            this.axButton1.TabIndex = 151;
            this.axButton1.Text = "Excel File Load";
            this.axButton1.UseVisualStyleBackColor = false;
            this.axButton1.Click += new System.EventHandler(this.axButton1_Click);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 160);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = false;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 665);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 18;
            this.grd01.UseCustomHighlight = true;
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel|*.xlsx|Excel|*.xls";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cdx01_VENDCD);
            this.panel5.Controls.Add(this.cbl01_CustPLANT);
            this.panel5.Controls.Add(this.lbl01_CORNM);
            this.panel5.Controls.Add(this.axLabel3);
            this.panel5.Controls.Add(this.cbo01_CORCD);
            this.panel5.Controls.Add(this.lbl01_BIZNM);
            this.panel5.Controls.Add(this.axLabel2);
            this.panel5.Controls.Add(this.cbo01_BIZCD);
            this.panel5.Location = new System.Drawing.Point(3, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1018, 58);
            this.panel5.TabIndex = 152;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(169, 32);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(278, 21);
            this.cdx01_VENDCD.TabIndex = 148;
            this.cdx01_VENDCD.Tag = null;
            // 
            // cbl01_CustPLANT
            // 
            this.cbl01_CustPLANT.AddItemSeparator = ';';
            this.cbl01_CustPLANT.Caption = "";
            this.cbl01_CustPLANT.CaptionHeight = 17;
            this.cbl01_CustPLANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_CustPLANT.ColumnCaptionHeight = 18;
            this.cbl01_CustPLANT.ColumnFooterHeight = 18;
            this.cbl01_CustPLANT.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbl01_CustPLANT.ContentHeight = 16;
            this.cbl01_CustPLANT.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_CustPLANT.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_CustPLANT.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_CustPLANT.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_CustPLANT.EditorHeight = 16;
            this.cbl01_CustPLANT.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_CustPLANT.Images"))));
            this.cbl01_CustPLANT.ItemHeight = 15;
            this.cbl01_CustPLANT.Location = new System.Drawing.Point(681, 30);
            this.cbl01_CustPLANT.MatchEntryTimeout = ((long)(2000));
            this.cbl01_CustPLANT.MaxDropDownItems = ((short)(5));
            this.cbl01_CustPLANT.MaxLength = 32767;
            this.cbl01_CustPLANT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_CustPLANT.Name = "cbl01_CustPLANT";
            this.cbl01_CustPLANT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_CustPLANT.Size = new System.Drawing.Size(213, 22);
            this.cbl01_CustPLANT.TabIndex = 81;
            this.cbl01_CustPLANT.SelectedValueChanged += new System.EventHandler(this.cbl01_CustPLANT_SelectedValueChanged);
            this.cbl01_CustPLANT.PropBag = resources.GetString("cbl01_CustPLANT.PropBag");
            // 
            // lbl01_CORNM
            // 
            this.lbl01_CORNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORNM.AutoFontSizeMinValue = 9F;
            this.lbl01_CORNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORNM.Location = new System.Drawing.Point(3, 4);
            this.lbl01_CORNM.Name = "lbl01_CORNM";
            this.lbl01_CORNM.Size = new System.Drawing.Size(152, 21);
            this.lbl01_CORNM.TabIndex = 34;
            this.lbl01_CORNM.Tag = null;
            this.lbl01_CORNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORNM.Value = "Corporation Name";
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(462, 32);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(213, 21);
            this.axLabel3.TabIndex = 73;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "C/PLANT";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(158, 5);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(171, 23);
            this.cbo01_CORCD.TabIndex = 35;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(344, 8);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(137, 21);
            this.lbl01_BIZNM.TabIndex = 36;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "Business Name";
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(3, 31);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(169, 21);
            this.axLabel2.TabIndex = 72;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Customer";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(487, 6);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(213, 23);
            this.cbo01_BIZCD.TabIndex = 37;
            // 
            // Txt_PARTNO
            // 
            this.Txt_PARTNO.Location = new System.Drawing.Point(153, 106);
            this.Txt_PARTNO.Name = "Txt_PARTNO";
            this.Txt_PARTNO.Size = new System.Drawing.Size(182, 21);
            this.Txt_PARTNO.TabIndex = 154;
            this.Txt_PARTNO.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(3, 106);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(144, 21);
            this.axLabel1.TabIndex = 153;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Part No.";
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel4.Location = new System.Drawing.Point(360, 133);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(144, 21);
            this.axLabel4.TabIndex = 155;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Target Date";
            // 
            // Dat_ST_DATE
            // 
            this.Dat_ST_DATE.CustomFormat = "yyyy-MM-dd";
            this.Dat_ST_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dat_ST_DATE.Location = new System.Drawing.Point(510, 133);
            this.Dat_ST_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.Dat_ST_DATE.Name = "Dat_ST_DATE";
            this.Dat_ST_DATE.OriginalFormat = "";
            this.Dat_ST_DATE.Size = new System.Drawing.Size(108, 21);
            this.Dat_ST_DATE.TabIndex = 156;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(109, 133);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(224, 21);
            this.cdx01_VINCD.TabIndex = 158;
            this.cdx01_VINCD.Tag = null;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(6, 133);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VINCD.TabIndex = 157;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "CAR";
            // 
            // Txt_ORDNO
            // 
            this.Txt_ORDNO.Location = new System.Drawing.Point(510, 106);
            this.Txt_ORDNO.Name = "Txt_ORDNO";
            this.Txt_ORDNO.Size = new System.Drawing.Size(182, 21);
            this.Txt_ORDNO.TabIndex = 160;
            this.Txt_ORDNO.Tag = null;
            // 
            // axLabel5
            // 
            this.axLabel5.AutoFontSizeMaxValue = 9F;
            this.axLabel5.AutoFontSizeMinValue = 9F;
            this.axLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel5.Location = new System.Drawing.Point(360, 106);
            this.axLabel5.Name = "axLabel5";
            this.axLabel5.Size = new System.Drawing.Size(144, 21);
            this.axLabel5.TabIndex = 159;
            this.axLabel5.Tag = null;
            this.axLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel5.Value = "Order NO.";
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Total.ForeColor = System.Drawing.Color.Blue;
            this.Lbl_Total.Location = new System.Drawing.Point(638, 136);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(51, 16);
            this.Lbl_Total.TabIndex = 161;
            this.Lbl_Total.Text = "label1";
            // 
            // ZSD02170
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.Lbl_Total);
            this.Controls.Add(this.Txt_ORDNO);
            this.Controls.Add(this.axLabel5);
            this.Controls.Add(this.cdx01_VINCD);
            this.Controls.Add(this.lbl01_VINCD);
            this.Controls.Add(this.Dat_ST_DATE);
            this.Controls.Add(this.axLabel4);
            this.Controls.Add(this.Txt_PARTNO);
            this.Controls.Add(this.axLabel1);
            this.Controls.Add(this.axButton1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.grd01);
            this.Name = "ZSD02170";
            this.Size = new System.Drawing.Size(1024, 828);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.axButton1, 0);
            this.Controls.SetChildIndex(this.axLabel1, 0);
            this.Controls.SetChildIndex(this.Txt_PARTNO, 0);
            this.Controls.SetChildIndex(this.axLabel4, 0);
            this.Controls.SetChildIndex(this.Dat_ST_DATE, 0);
            this.Controls.SetChildIndex(this.lbl01_VINCD, 0);
            this.Controls.SetChildIndex(this.cdx01_VINCD, 0);
            this.Controls.SetChildIndex(this.axLabel5, 0);
            this.Controls.SetChildIndex(this.Txt_ORDNO, 0);
            this.Controls.SetChildIndex(this.Lbl_Total, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustPLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ORDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxButton axButton1;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.Panel panel5;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxComboList cbl01_CustPLANT;
        private DEV.Utility.Controls.AxLabel lbl01_CORNM;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxTextBox Txt_PARTNO;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxLabel axLabel4;
        private DEV.Utility.Controls.AxDateEdit Dat_ST_DATE;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private DEV.Utility.Controls.AxTextBox Txt_ORDNO;
        private DEV.Utility.Controls.AxLabel axLabel5;
        private System.Windows.Forms.Label Lbl_Total;
    }
}
