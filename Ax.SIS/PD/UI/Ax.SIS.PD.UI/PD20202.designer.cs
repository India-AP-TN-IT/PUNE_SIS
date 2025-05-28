namespace Ax.SIS.PD.UI
{
    partial class PD20202
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
            this.grp01_INQUERY = new System.Windows.Forms.GroupBox();
            this.lbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grp01_REGIST = new System.Windows.Forms.GroupBox();
            this.txt01_SEQ = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.lbl01_SEQ = new Ax.DEV.Utility.Controls.AxLabel();
            this.nme01_WIDTH = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.lbl02_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo02_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx02_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl02_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_COLUMN_ID = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_ALIGN = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_ALIGN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_WIDTH = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_COLUMNID = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_INQUERY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grp01_REGIST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme01_WIDTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx02_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_COLUMN_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALIGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WIDTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COLUMNID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_INQUERY
            // 
            this.grp01_INQUERY.Controls.Add(this.lbl01_INSTALL_POS);
            this.grp01_INQUERY.Controls.Add(this.cbo01_INSTALL_POS);
            this.grp01_INQUERY.Controls.Add(this.cdx01_LINECD);
            this.grp01_INQUERY.Controls.Add(this.cbo01_BIZCD);
            this.grp01_INQUERY.Controls.Add(this.lbl01_LINECD);
            this.grp01_INQUERY.Controls.Add(this.lbl01_BIZNM2);
            this.grp01_INQUERY.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_INQUERY.Location = new System.Drawing.Point(0, 34);
            this.grp01_INQUERY.Name = "grp01_INQUERY";
            this.grp01_INQUERY.Size = new System.Drawing.Size(1024, 50);
            this.grp01_INQUERY.TabIndex = 11;
            this.grp01_INQUERY.TabStop = false;
            this.grp01_INQUERY.Text = "조회";
            // 
            // lbl01_INSTALL_POS
            // 
            this.lbl01_INSTALL_POS.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSTALL_POS.AutoFontSizeMinValue = 9F;
            this.lbl01_INSTALL_POS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INSTALL_POS.Location = new System.Drawing.Point(552, 15);
            this.lbl01_INSTALL_POS.Name = "lbl01_INSTALL_POS";
            this.lbl01_INSTALL_POS.Size = new System.Drawing.Size(100, 21);
            this.lbl01_INSTALL_POS.TabIndex = 76;
            this.lbl01_INSTALL_POS.Tag = null;
            this.lbl01_INSTALL_POS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSTALL_POS.Value = "장착위치";
            // 
            // cbo01_INSTALL_POS
            // 
            this.cbo01_INSTALL_POS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INSTALL_POS.FormattingEnabled = true;
            this.cbo01_INSTALL_POS.Location = new System.Drawing.Point(658, 16);
            this.cbo01_INSTALL_POS.Name = "cbo01_INSTALL_POS";
            this.cbo01_INSTALL_POS.Size = new System.Drawing.Size(89, 20);
            this.cbo01_INSTALL_POS.TabIndex = 75;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(354, 17);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(192, 21);
            this.cdx01_LINECD.TabIndex = 23;
            this.cdx01_LINECD.Tag = null;
            this.cdx01_LINECD.ButtonClickBefore += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_LINECD_ButtonClickBefore);
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 21;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_SAUP_SelectedIndexChanged);
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(248, 17);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINECD.TabIndex = 7;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "라인코드";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 17);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 1;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 684);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grp01_REGIST);
            this.panel1.Controls.Add(this.grd01);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 664);
            this.panel1.TabIndex = 0;
            // 
            // grp01_REGIST
            // 
            this.grp01_REGIST.Controls.Add(this.txt01_SEQ);
            this.grp01_REGIST.Controls.Add(this.lbl01_SEQ);
            this.grp01_REGIST.Controls.Add(this.nme01_WIDTH);
            this.grp01_REGIST.Controls.Add(this.lbl02_POSTITLE);
            this.grp01_REGIST.Controls.Add(this.cbo02_INSTALL_POS);
            this.grp01_REGIST.Controls.Add(this.cdx02_LINECD);
            this.grp01_REGIST.Controls.Add(this.lbl02_LINECD);
            this.grp01_REGIST.Controls.Add(this.txt01_COLUMN_ID);
            this.grp01_REGIST.Controls.Add(this.lbl01_ALIGN);
            this.grp01_REGIST.Controls.Add(this.cbo01_ALIGN);
            this.grp01_REGIST.Controls.Add(this.lbl01_WIDTH);
            this.grp01_REGIST.Controls.Add(this.lbl01_COLUMNID);
            this.grp01_REGIST.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_REGIST.Location = new System.Drawing.Point(445, 0);
            this.grp01_REGIST.Name = "grp01_REGIST";
            this.grp01_REGIST.Size = new System.Drawing.Size(573, 664);
            this.grp01_REGIST.TabIndex = 13;
            this.grp01_REGIST.TabStop = false;
            this.grp01_REGIST.Text = "등록";
            // 
            // txt01_SEQ
            // 
            this.txt01_SEQ.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txt01_SEQ.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txt01_SEQ.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.txt01_SEQ.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txt01_SEQ.EmptyAsNull = true;
            this.txt01_SEQ.FormatType = C1.Win.C1Input.FormatTypeEnum.Integer;
            this.txt01_SEQ.Location = new System.Drawing.Point(152, 214);
            this.txt01_SEQ.Name = "txt01_SEQ";
            this.txt01_SEQ.NullText = "0";
            this.txt01_SEQ.Size = new System.Drawing.Size(89, 21);
            this.txt01_SEQ.TabIndex = 111;
            this.txt01_SEQ.Tag = null;
            this.txt01_SEQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt01_SEQ.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // lbl01_SEQ
            // 
            this.lbl01_SEQ.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEQ.AutoFontSizeMinValue = 9F;
            this.lbl01_SEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SEQ.Location = new System.Drawing.Point(6, 213);
            this.lbl01_SEQ.Name = "lbl01_SEQ";
            this.lbl01_SEQ.Size = new System.Drawing.Size(140, 21);
            this.lbl01_SEQ.TabIndex = 110;
            this.lbl01_SEQ.Tag = null;
            this.lbl01_SEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SEQ.Value = "SEQ";
            // 
            // nme01_WIDTH
            // 
            this.nme01_WIDTH.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.StandardNumber;
            this.nme01_WIDTH.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme01_WIDTH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.StandardNumber;
            this.nme01_WIDTH.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme01_WIDTH.EmptyAsNull = true;
            this.nme01_WIDTH.Location = new System.Drawing.Point(152, 141);
            this.nme01_WIDTH.Name = "nme01_WIDTH";
            this.nme01_WIDTH.NullText = "0";
            this.nme01_WIDTH.Size = new System.Drawing.Size(89, 21);
            this.nme01_WIDTH.TabIndex = 109;
            this.nme01_WIDTH.Tag = null;
            this.nme01_WIDTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme01_WIDTH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // lbl02_POSTITLE
            // 
            this.lbl02_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl02_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl02_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_POSTITLE.Location = new System.Drawing.Point(6, 71);
            this.lbl02_POSTITLE.Name = "lbl02_POSTITLE";
            this.lbl02_POSTITLE.Size = new System.Drawing.Size(140, 21);
            this.lbl02_POSTITLE.TabIndex = 108;
            this.lbl02_POSTITLE.Tag = null;
            this.lbl02_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_POSTITLE.Value = "장착위치";
            // 
            // cbo02_INSTALL_POS
            // 
            this.cbo02_INSTALL_POS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_INSTALL_POS.FormattingEnabled = true;
            this.cbo02_INSTALL_POS.Location = new System.Drawing.Point(152, 72);
            this.cbo02_INSTALL_POS.Name = "cbo02_INSTALL_POS";
            this.cbo02_INSTALL_POS.Size = new System.Drawing.Size(89, 20);
            this.cbo02_INSTALL_POS.TabIndex = 107;
            // 
            // cdx02_LINECD
            // 
            this.cdx02_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx02_LINECD.CodeParameterName = "CODE";
            this.cdx02_LINECD.CodeTextBoxReadOnly = false;
            this.cdx02_LINECD.CodeTextBoxVisible = true;
            this.cdx02_LINECD.CodeTextBoxWidth = 50;
            this.cdx02_LINECD.HEPopupHelper = null;
            this.cdx02_LINECD.Location = new System.Drawing.Point(152, 35);
            this.cdx02_LINECD.Name = "cdx02_LINECD";
            this.cdx02_LINECD.NameParameterName = "NAME";
            this.cdx02_LINECD.NameTextBoxReadOnly = false;
            this.cdx02_LINECD.NameTextBoxVisible = true;
            this.cdx02_LINECD.PopupButtonReadOnly = false;
            this.cdx02_LINECD.PopupTitle = "";
            this.cdx02_LINECD.PrefixCode = "";
            this.cdx02_LINECD.Size = new System.Drawing.Size(192, 21);
            this.cdx02_LINECD.TabIndex = 106;
            this.cdx02_LINECD.Tag = null;
            this.cdx02_LINECD.ButtonClickBefore += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx02_LINECD_ButtonClickBefore);
            // 
            // lbl02_LINECD
            // 
            this.lbl02_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl02_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl02_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_LINECD.Location = new System.Drawing.Point(6, 35);
            this.lbl02_LINECD.Name = "lbl02_LINECD";
            this.lbl02_LINECD.Size = new System.Drawing.Size(140, 21);
            this.lbl02_LINECD.TabIndex = 105;
            this.lbl02_LINECD.Tag = null;
            this.lbl02_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_LINECD.Value = "라인코드";
            // 
            // txt01_COLUMN_ID
            // 
            this.txt01_COLUMN_ID.Location = new System.Drawing.Point(152, 105);
            this.txt01_COLUMN_ID.Name = "txt01_COLUMN_ID";
            this.txt01_COLUMN_ID.Size = new System.Drawing.Size(162, 21);
            this.txt01_COLUMN_ID.TabIndex = 103;
            this.txt01_COLUMN_ID.Tag = null;
            // 
            // lbl01_ALIGN
            // 
            this.lbl01_ALIGN.AutoFontSizeMaxValue = 9F;
            this.lbl01_ALIGN.AutoFontSizeMinValue = 9F;
            this.lbl01_ALIGN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ALIGN.Location = new System.Drawing.Point(6, 178);
            this.lbl01_ALIGN.Name = "lbl01_ALIGN";
            this.lbl01_ALIGN.Size = new System.Drawing.Size(140, 21);
            this.lbl01_ALIGN.TabIndex = 76;
            this.lbl01_ALIGN.Tag = null;
            this.lbl01_ALIGN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ALIGN.Value = "정렬위치";
            // 
            // cbo01_ALIGN
            // 
            this.cbo01_ALIGN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_ALIGN.FormattingEnabled = true;
            this.cbo01_ALIGN.Location = new System.Drawing.Point(152, 179);
            this.cbo01_ALIGN.Name = "cbo01_ALIGN";
            this.cbo01_ALIGN.Size = new System.Drawing.Size(89, 20);
            this.cbo01_ALIGN.TabIndex = 75;
            // 
            // lbl01_WIDTH
            // 
            this.lbl01_WIDTH.AutoFontSizeMaxValue = 9F;
            this.lbl01_WIDTH.AutoFontSizeMinValue = 9F;
            this.lbl01_WIDTH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WIDTH.Location = new System.Drawing.Point(6, 140);
            this.lbl01_WIDTH.Name = "lbl01_WIDTH";
            this.lbl01_WIDTH.Size = new System.Drawing.Size(140, 21);
            this.lbl01_WIDTH.TabIndex = 7;
            this.lbl01_WIDTH.Tag = null;
            this.lbl01_WIDTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WIDTH.Value = "넓이";
            // 
            // lbl01_COLUMNID
            // 
            this.lbl01_COLUMNID.AutoFontSizeMaxValue = 9F;
            this.lbl01_COLUMNID.AutoFontSizeMinValue = 9F;
            this.lbl01_COLUMNID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_COLUMNID.Location = new System.Drawing.Point(6, 104);
            this.lbl01_COLUMNID.Name = "lbl01_COLUMNID";
            this.lbl01_COLUMNID.Size = new System.Drawing.Size(140, 21);
            this.lbl01_COLUMNID.TabIndex = 1;
            this.lbl01_COLUMNID.Tag = null;
            this.lbl01_COLUMNID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_COLUMNID.Value = "컬럼ID";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Left;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(445, 664);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // PD20202
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp01_INQUERY);
            this.Name = "PD20202";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grp01_INQUERY, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grp01_INQUERY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grp01_REGIST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme01_WIDTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx02_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_COLUMN_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALIGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WIDTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COLUMNID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_INQUERY;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxComboBox cbo01_INSTALL_POS;
        private DEV.Utility.Controls.AxLabel lbl01_INSTALL_POS;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox grp01_REGIST;
        private DEV.Utility.Controls.AxLabel lbl01_ALIGN;
        private DEV.Utility.Controls.AxComboBox cbo01_ALIGN;
        private DEV.Utility.Controls.AxLabel lbl01_WIDTH;
        private DEV.Utility.Controls.AxLabel lbl01_COLUMNID;
        private DEV.Utility.Controls.AxLabel lbl02_POSTITLE;
        private DEV.Utility.Controls.AxComboBox cbo02_INSTALL_POS;
        private DEV.Utility.Controls.AxCodeBox cdx02_LINECD;
        private DEV.Utility.Controls.AxLabel lbl02_LINECD;
        private DEV.Utility.Controls.AxNumericEdit nme01_WIDTH;
        private DEV.Utility.Controls.AxTextBox txt01_COLUMN_ID;
        private DEV.Utility.Controls.AxNumericEdit txt01_SEQ;
        private DEV.Utility.Controls.AxLabel lbl01_SEQ;
    }
}
