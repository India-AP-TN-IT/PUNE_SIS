namespace Ax.SIS.SD.UI
{
    partial class ZSD02620
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZSD02620));
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbl01_CustPLANT = new Ax.DEV.Utility.Controls.AxComboList();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_CORNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.Dat_ST_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.Txt_ORDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel5 = new Ax.DEV.Utility.Controls.AxLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustPLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ORDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cbl01_CustPLANT);
            this.panel5.Controls.Add(this.axLabel3);
            this.panel5.Controls.Add(this.lbl01_CORNM);
            this.panel5.Controls.Add(this.cbo01_CORCD);
            this.panel5.Controls.Add(this.lbl01_BIZNM);
            this.panel5.Controls.Add(this.cbo01_BIZCD);
            this.panel5.Location = new System.Drawing.Point(3, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1018, 37);
            this.panel5.TabIndex = 152;
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
            this.cbl01_CustPLANT.Location = new System.Drawing.Point(767, 6);
            this.cbl01_CustPLANT.MatchEntryTimeout = ((long)(2000));
            this.cbl01_CustPLANT.MaxDropDownItems = ((short)(5));
            this.cbl01_CustPLANT.MaxLength = 32767;
            this.cbl01_CustPLANT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_CustPLANT.Name = "cbl01_CustPLANT";
            this.cbl01_CustPLANT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_CustPLANT.Size = new System.Drawing.Size(232, 22);
            this.cbl01_CustPLANT.TabIndex = 162;
            this.cbl01_CustPLANT.PropBag = resources.GetString("cbl01_CustPLANT.PropBag");
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(632, 8);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(129, 21);
            this.axLabel3.TabIndex = 161;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "C/PLANT";
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
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(158, 5);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(130, 23);
            this.cbo01_CORCD.TabIndex = 35;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(295, 8);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(112, 21);
            this.lbl01_BIZNM.TabIndex = 36;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "Business Name";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(410, 6);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(213, 23);
            this.cbo01_BIZCD.TabIndex = 37;
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel4.Location = new System.Drawing.Point(360, 78);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(144, 21);
            this.axLabel4.TabIndex = 155;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Delivery Date";
            // 
            // Dat_ST_DATE
            // 
            this.Dat_ST_DATE.CustomFormat = "yyyy-MM-dd";
            this.Dat_ST_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dat_ST_DATE.Location = new System.Drawing.Point(510, 78);
            this.Dat_ST_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.Dat_ST_DATE.Name = "Dat_ST_DATE";
            this.Dat_ST_DATE.OriginalFormat = "";
            this.Dat_ST_DATE.Size = new System.Drawing.Size(108, 21);
            this.Dat_ST_DATE.TabIndex = 156;
            // 
            // Txt_ORDNO
            // 
            this.Txt_ORDNO.Location = new System.Drawing.Point(159, 79);
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
            this.axLabel5.Location = new System.Drawing.Point(9, 79);
            this.axLabel5.Name = "axLabel5";
            this.axLabel5.Size = new System.Drawing.Size(144, 21);
            this.axLabel5.TabIndex = 159;
            this.axLabel5.Tag = null;
            this.axLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel5.Value = "Invoice NO.";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 106);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grd01);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grd02);
            this.splitContainer1.Size = new System.Drawing.Size(1007, 719);
            this.splitContainer1.SplitterDistance = 487;
            this.splitContainer1.TabIndex = 161;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = false;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1007, 487);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 19;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = false;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(1007, 228);
            this.grd02.StyleInfo = resources.GetString("grd02.StyleInfo");
            this.grd02.TabIndex = 20;
            this.grd02.UseCustomHighlight = true;
            // 
            // ZSD02620
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Txt_ORDNO);
            this.Controls.Add(this.axLabel5);
            this.Controls.Add(this.Dat_ST_DATE);
            this.Controls.Add(this.axLabel4);
            this.Controls.Add(this.panel5);
            this.Name = "ZSD02620";
            this.Size = new System.Drawing.Size(1024, 828);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.axLabel4, 0);
            this.Controls.SetChildIndex(this.Dat_ST_DATE, 0);
            this.Controls.SetChildIndex(this.axLabel5, 0);
            this.Controls.SetChildIndex(this.Txt_ORDNO, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustPLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ORDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private DEV.Utility.Controls.AxLabel lbl01_CORNM;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel axLabel4;
        private DEV.Utility.Controls.AxDateEdit Dat_ST_DATE;
        private DEV.Utility.Controls.AxTextBox Txt_ORDNO;
        private DEV.Utility.Controls.AxLabel axLabel5;
        private DEV.Utility.Controls.AxComboList cbl01_CustPLANT;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxFlexGrid grd02;
    }
}
