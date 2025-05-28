namespace Ax.SIS.SD.UI
{
    partial class ZSD02740
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZSD02740));
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd05 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cbl01_CustPLANT = new Ax.DEV.Utility.Controls.AxComboList();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit2 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.grd06 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustPLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 32);
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(17, 45);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(85, 21);
            this.lbl01_BIZCD.TabIndex = 114;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Plant";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(105, 44);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(123, 23);
            this.cbo01_BIZCD.TabIndex = 113;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(238, 46);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(140, 21);
            this.axLabel2.TabIndex = 118;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "P.O DATE";
            // 
            // axDateEdit1
            // 
            this.axDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit1.Location = new System.Drawing.Point(384, 45);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(117, 21);
            this.axDateEdit1.TabIndex = 119;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(279, 78);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_PARTNO.TabIndex = 141;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(15, 78);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.lbl01_PARTNO.TabIndex = 140;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "Part No (%)";
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(667, 78);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(224, 21);
            this.cdx01_VINCD.TabIndex = 147;
            this.cdx01_VINCD.Tag = null;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(564, 78);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VINCD.TabIndex = 146;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "CAR";
            // 
            // grd05
            // 
            this.grd05.AllowHeaderMerging = false;
            this.grd05.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd05.EnabledActionFlag = true;
            this.grd05.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd05.LastRowAdd = false;
            this.grd05.Location = new System.Drawing.Point(0, 0);
            this.grd05.Name = "grd05";
            this.grd05.OriginalFormat = null;
            this.grd05.PopMenuVisible = true;
            this.grd05.Rows.DefaultSize = 18;
            this.grd05.Size = new System.Drawing.Size(1018, 199);
            this.grd05.StyleInfo = resources.GetString("grd05.StyleInfo");
            this.grd05.TabIndex = 125;
            this.grd05.UseCustomHighlight = true;
            this.grd05.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd05_MouseDoubleClick);
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
            this.cbl01_CustPLANT.Location = new System.Drawing.Point(234, 106);
            this.cbl01_CustPLANT.MatchEntryTimeout = ((long)(2000));
            this.cbl01_CustPLANT.MaxDropDownItems = ((short)(5));
            this.cbl01_CustPLANT.MaxLength = 32767;
            this.cbl01_CustPLANT.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_CustPLANT.Name = "cbl01_CustPLANT";
            this.cbl01_CustPLANT.ReadOnly = true;
            this.cbl01_CustPLANT.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_CustPLANT.Size = new System.Drawing.Size(213, 22);
            this.cbl01_CustPLANT.TabIndex = 149;
            this.cbl01_CustPLANT.PropBag = resources.GetString("cbl01_CustPLANT.PropBag");
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(15, 108);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(213, 21);
            this.axLabel3.TabIndex = 148;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "C/PLANT";
            // 
            // axTextBox1
            // 
            this.axTextBox1.Location = new System.Drawing.Point(649, 105);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(261, 21);
            this.axTextBox1.TabIndex = 151;
            this.axTextBox1.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(461, 105);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(184, 21);
            this.axLabel1.TabIndex = 150;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "ORDER NO (%)";
            // 
            // axDateEdit2
            // 
            this.axDateEdit2.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit2.Location = new System.Drawing.Point(524, 46);
            this.axDateEdit2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit2.Name = "axDateEdit2";
            this.axDateEdit2.OriginalFormat = "";
            this.axDateEdit2.Size = new System.Drawing.Size(117, 21);
            this.axDateEdit2.TabIndex = 152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 153;
            this.label1.Text = "~";
            // 
            // grd06
            // 
            this.grd06.AllowHeaderMerging = false;
            this.grd06.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd06.EnabledActionFlag = true;
            this.grd06.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd06.LastRowAdd = false;
            this.grd06.Location = new System.Drawing.Point(0, 0);
            this.grd06.Name = "grd06";
            this.grd06.OriginalFormat = null;
            this.grd06.PopMenuVisible = true;
            this.grd06.Rows.DefaultSize = 18;
            this.grd06.Size = new System.Drawing.Size(1018, 428);
            this.grd06.StyleInfo = resources.GetString("grd06.StyleInfo");
            this.grd06.TabIndex = 154;
            this.grd06.UseCustomHighlight = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 134);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grd05);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grd06);
            this.splitContainer1.Size = new System.Drawing.Size(1018, 631);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 155;
            // 
            // ZSD02740
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axDateEdit2);
            this.Controls.Add(this.axTextBox1);
            this.Controls.Add(this.axLabel1);
            this.Controls.Add(this.cbl01_CustPLANT);
            this.Controls.Add(this.axLabel3);
            this.Controls.Add(this.cdx01_VINCD);
            this.Controls.Add(this.lbl01_VINCD);
            this.Controls.Add(this.txt01_PARTNO);
            this.Controls.Add(this.lbl01_PARTNO);
            this.Controls.Add(this.axDateEdit1);
            this.Controls.Add(this.axLabel2);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Name = "ZSD02740";
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.axDateEdit1, 0);
            this.Controls.SetChildIndex(this.lbl01_PARTNO, 0);
            this.Controls.SetChildIndex(this.txt01_PARTNO, 0);
            this.Controls.SetChildIndex(this.lbl01_VINCD, 0);
            this.Controls.SetChildIndex(this.cdx01_VINCD, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.axLabel3, 0);
            this.Controls.SetChildIndex(this.cbl01_CustPLANT, 0);
            this.Controls.SetChildIndex(this.axLabel1, 0);
            this.Controls.SetChildIndex(this.axTextBox1, 0);
            this.Controls.SetChildIndex(this.axDateEdit2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_CustPLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd06)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxDateEdit axDateEdit1;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private DEV.Utility.Controls.AxFlexGrid grd05;
        private DEV.Utility.Controls.AxComboList cbl01_CustPLANT;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxTextBox axTextBox1;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxDateEdit axDateEdit2;
        private System.Windows.Forms.Label label1;
        private DEV.Utility.Controls.AxFlexGrid grd06;
        private System.Windows.Forms.SplitContainer splitContainer1;

    }
}
