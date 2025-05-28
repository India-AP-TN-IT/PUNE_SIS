namespace Ax.SIS.PD.UI
{
    partial class ZPD23111
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZPD23111));
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grp01_CHNG_HISTORY = new System.Windows.Forms.GroupBox();
            this.grd01_2 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_DELI_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_TAGNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_TAGNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_CARSEQ = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CARSEQ = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_CARNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_FILE_UPLOAD2 = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_EXCEL_DOWN = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_ALCCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_ALCCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_SEARCH_OPT = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_RSLT = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.cbo01_DELI_TYPE = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbo01_CARNO = new Ax.DEV.Utility.Controls.AxComboList();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.grp01_CHNG_HISTORY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TAGNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TAGNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CARSEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CARSEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CARNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ALCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_OPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo01_DELI_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo01_CARNO)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd01);
            this.panel2.Controls.Add(this.grd02);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.grp01_CHNG_HISTORY);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 617);
            this.panel2.TabIndex = 1;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 452);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.ChangeEdit += new System.EventHandler(this.grd01_ChangeEdit);
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDoubleClick);
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(8, 244);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(422, 196);
            this.grd02.TabIndex = 4;
            this.grd02.UseCustomHighlight = true;
            this.grd02.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.White;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 452);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1024, 5);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // grp01_CHNG_HISTORY
            // 
            this.grp01_CHNG_HISTORY.Controls.Add(this.grd01_2);
            this.grp01_CHNG_HISTORY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_CHNG_HISTORY.Location = new System.Drawing.Point(0, 457);
            this.grp01_CHNG_HISTORY.Name = "grp01_CHNG_HISTORY";
            this.grp01_CHNG_HISTORY.Size = new System.Drawing.Size(1024, 160);
            this.grp01_CHNG_HISTORY.TabIndex = 3;
            this.grp01_CHNG_HISTORY.TabStop = false;
            this.grp01_CHNG_HISTORY.Text = "조정이력";
            // 
            // grd01_2
            // 
            this.grd01_2.AllowHeaderMerging = false;
            this.grd01_2.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_2.EnabledActionFlag = true;
            this.grd01_2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01_2.LastRowAdd = false;
            this.grd01_2.Location = new System.Drawing.Point(3, 17);
            this.grd01_2.Name = "grd01_2";
            this.grd01_2.OriginalFormat = null;
            this.grd01_2.PopMenuVisible = true;
            this.grd01_2.Rows.DefaultSize = 18;
            this.grd01_2.Size = new System.Drawing.Size(1018, 140);
            this.grd01_2.TabIndex = 2;
            this.grd01_2.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_CARNO);
            this.groupBox1.Controls.Add(this.cbo01_DELI_TYPE);
            this.groupBox1.Controls.Add(this.lbl01_DELI_TYPE);
            this.groupBox1.Controls.Add(this.txt01_TAGNO);
            this.groupBox1.Controls.Add(this.lbl01_TAGNO);
            this.groupBox1.Controls.Add(this.txt01_CARSEQ);
            this.groupBox1.Controls.Add(this.lbl01_CARSEQ);
            this.groupBox1.Controls.Add(this.lbl01_CARNO);
            this.groupBox1.Controls.Add(this.btn01_FILE_UPLOAD2);
            this.groupBox1.Controls.Add(this.btn01_EXCEL_DOWN);
            this.groupBox1.Controls.Add(this.txt01_ALCCD);
            this.groupBox1.Controls.Add(this.lbl01_ALCCD);
            this.groupBox1.Controls.Add(this.txt01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_SEARCH_OPT);
            this.groupBox1.Controls.Add(this.chk01_RSLT);
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_LINECD);
            this.groupBox1.Controls.Add(this.dte01_STD_DATE);
            this.groupBox1.Controls.Add(this.lbl01_STD_DATE);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 117);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_DELI_TYPE
            // 
            this.lbl01_DELI_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELI_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_DELI_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DELI_TYPE.Location = new System.Drawing.Point(6, 66);
            this.lbl01_DELI_TYPE.Name = "lbl01_DELI_TYPE";
            this.lbl01_DELI_TYPE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_DELI_TYPE.TabIndex = 52;
            this.lbl01_DELI_TYPE.Tag = null;
            this.lbl01_DELI_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DELI_TYPE.Value = "DELI. TYPE";
            // 
            // txt01_TAGNO
            // 
            this.txt01_TAGNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_TAGNO.Location = new System.Drawing.Point(109, 91);
            this.txt01_TAGNO.Name = "txt01_TAGNO";
            this.txt01_TAGNO.Size = new System.Drawing.Size(638, 21);
            this.txt01_TAGNO.TabIndex = 51;
            this.txt01_TAGNO.Tag = null;
            this.txt01_TAGNO.Value = "";
            // 
            // lbl01_TAGNO
            // 
            this.lbl01_TAGNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_TAGNO.AutoFontSizeMinValue = 9F;
            this.lbl01_TAGNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_TAGNO.Location = new System.Drawing.Point(5, 91);
            this.lbl01_TAGNO.Name = "lbl01_TAGNO";
            this.lbl01_TAGNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_TAGNO.TabIndex = 50;
            this.lbl01_TAGNO.Tag = null;
            this.lbl01_TAGNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_TAGNO.Value = "TAG";
            // 
            // txt01_CARSEQ
            // 
            this.txt01_CARSEQ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CARSEQ.Location = new System.Drawing.Point(602, 66);
            this.txt01_CARSEQ.Name = "txt01_CARSEQ";
            this.txt01_CARSEQ.Size = new System.Drawing.Size(145, 21);
            this.txt01_CARSEQ.TabIndex = 49;
            this.txt01_CARSEQ.Tag = null;
            // 
            // lbl01_CARSEQ
            // 
            this.lbl01_CARSEQ.AutoFontSizeMaxValue = 9F;
            this.lbl01_CARSEQ.AutoFontSizeMinValue = 9F;
            this.lbl01_CARSEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CARSEQ.Location = new System.Drawing.Point(500, 66);
            this.lbl01_CARSEQ.Name = "lbl01_CARSEQ";
            this.lbl01_CARSEQ.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CARSEQ.TabIndex = 48;
            this.lbl01_CARSEQ.Tag = null;
            this.lbl01_CARSEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CARSEQ.Value = "TRUCK SEQ";
            // 
            // lbl01_CARNO
            // 
            this.lbl01_CARNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_CARNO.AutoFontSizeMinValue = 9F;
            this.lbl01_CARNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CARNO.Location = new System.Drawing.Point(245, 65);
            this.lbl01_CARNO.Name = "lbl01_CARNO";
            this.lbl01_CARNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CARNO.TabIndex = 46;
            this.lbl01_CARNO.Tag = null;
            this.lbl01_CARNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CARNO.Value = "TRUCK NO";
            // 
            // btn01_FILE_UPLOAD2
            // 
            this.btn01_FILE_UPLOAD2.Location = new System.Drawing.Point(771, 60);
            this.btn01_FILE_UPLOAD2.Name = "btn01_FILE_UPLOAD2";
            this.btn01_FILE_UPLOAD2.Size = new System.Drawing.Size(126, 23);
            this.btn01_FILE_UPLOAD2.TabIndex = 45;
            this.btn01_FILE_UPLOAD2.Text = "업로드";
            this.btn01_FILE_UPLOAD2.UseVisualStyleBackColor = true;
            this.btn01_FILE_UPLOAD2.Click += new System.EventHandler(this.btn01_UPLOAD_Click);
            // 
            // btn01_EXCEL_DOWN
            // 
            this.btn01_EXCEL_DOWN.Location = new System.Drawing.Point(771, 89);
            this.btn01_EXCEL_DOWN.Name = "btn01_EXCEL_DOWN";
            this.btn01_EXCEL_DOWN.Size = new System.Drawing.Size(126, 23);
            this.btn01_EXCEL_DOWN.TabIndex = 45;
            this.btn01_EXCEL_DOWN.Text = "Excel 양식받기";
            this.btn01_EXCEL_DOWN.UseVisualStyleBackColor = true;
            this.btn01_EXCEL_DOWN.Click += new System.EventHandler(this.btn01_EXCEL_FORM_Click);
            // 
            // txt01_ALCCD
            // 
            this.txt01_ALCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_ALCCD.Location = new System.Drawing.Point(348, 40);
            this.txt01_ALCCD.Name = "txt01_ALCCD";
            this.txt01_ALCCD.Size = new System.Drawing.Size(142, 21);
            this.txt01_ALCCD.TabIndex = 44;
            this.txt01_ALCCD.Tag = null;
            // 
            // lbl01_ALCCD
            // 
            this.lbl01_ALCCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ALCCD.AutoFontSizeMinValue = 9F;
            this.lbl01_ALCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ALCCD.Location = new System.Drawing.Point(245, 41);
            this.lbl01_ALCCD.Name = "lbl01_ALCCD";
            this.lbl01_ALCCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_ALCCD.TabIndex = 43;
            this.lbl01_ALCCD.Tag = null;
            this.lbl01_ALCCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ALCCD.Value = "품번";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(109, 40);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(130, 21);
            this.txt01_PARTNO.TabIndex = 42;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(6, 41);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PARTNO.TabIndex = 41;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "품번";
            // 
            // lbl01_SEARCH_OPT
            // 
            this.lbl01_SEARCH_OPT.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCH_OPT.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCH_OPT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SEARCH_OPT.Location = new System.Drawing.Point(769, 15);
            this.lbl01_SEARCH_OPT.Name = "lbl01_SEARCH_OPT";
            this.lbl01_SEARCH_OPT.Size = new System.Drawing.Size(123, 21);
            this.lbl01_SEARCH_OPT.TabIndex = 40;
            this.lbl01_SEARCH_OPT.Tag = null;
            this.lbl01_SEARCH_OPT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SEARCH_OPT.Value = "조회구분";
            // 
            // chk01_RSLT
            // 
            this.chk01_RSLT.AutoSize = true;
            this.chk01_RSLT.Location = new System.Drawing.Point(898, 17);
            this.chk01_RSLT.Name = "chk01_RSLT";
            this.chk01_RSLT.Size = new System.Drawing.Size(48, 16);
            this.chk01_RSLT.TabIndex = 39;
            this.chk01_RSLT.Text = "실적";
            this.chk01_RSLT.UseVisualStyleBackColor = true;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(348, 14);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(397, 21);
            this.cdx01_LINECD.TabIndex = 14;
            this.cdx01_LINECD.Tag = null;
            this.cdx01_LINECD.ButtonClickBefore += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_LINECD_ButtonClickBefore);
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(245, 14);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINECD.TabIndex = 10;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "라인코드";
            // 
            // dte01_STD_DATE
            // 
            this.dte01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_STD_DATE.Location = new System.Drawing.Point(603, 41);
            this.dte01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_STD_DATE.Name = "dte01_STD_DATE";
            this.dte01_STD_DATE.OriginalFormat = "";
            this.dte01_STD_DATE.Size = new System.Drawing.Size(144, 21);
            this.dte01_STD_DATE.TabIndex = 6;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(500, 42);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STD_DATE.TabIndex = 2;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "기준일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(109, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel 97 - 2003 통합 문서|*.xls|Excel 통합 문서|*.xlsx";
            // 
            // cbo01_DELI_TYPE
            // 
            this.cbo01_DELI_TYPE.AddItemSeparator = ';';
            this.cbo01_DELI_TYPE.Caption = "";
            this.cbo01_DELI_TYPE.CaptionHeight = 17;
            this.cbo01_DELI_TYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbo01_DELI_TYPE.ColumnCaptionHeight = 18;
            this.cbo01_DELI_TYPE.ColumnFooterHeight = 18;
            this.cbo01_DELI_TYPE.ContentHeight = 16;
            this.cbo01_DELI_TYPE.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbo01_DELI_TYPE.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbo01_DELI_TYPE.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo01_DELI_TYPE.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbo01_DELI_TYPE.EditorHeight = 16;
            this.cbo01_DELI_TYPE.Images.Add(((System.Drawing.Image)(resources.GetObject("cbo01_DELI_TYPE.Images"))));
            this.cbo01_DELI_TYPE.ItemHeight = 15;
            this.cbo01_DELI_TYPE.Location = new System.Drawing.Point(109, 66);
            this.cbo01_DELI_TYPE.MatchEntryTimeout = ((long)(2000));
            this.cbo01_DELI_TYPE.MaxDropDownItems = ((short)(5));
            this.cbo01_DELI_TYPE.MaxLength = 32767;
            this.cbo01_DELI_TYPE.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbo01_DELI_TYPE.Name = "cbo01_DELI_TYPE";
            this.cbo01_DELI_TYPE.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbo01_DELI_TYPE.Size = new System.Drawing.Size(130, 22);
            this.cbo01_DELI_TYPE.TabIndex = 92;
            this.cbo01_DELI_TYPE.PropBag = resources.GetString("cbo01_DELI_TYPE.PropBag");
            // 
            // cbo01_CARNO
            // 
            this.cbo01_CARNO.AddItemSeparator = ';';
            this.cbo01_CARNO.Caption = "";
            this.cbo01_CARNO.CaptionHeight = 17;
            this.cbo01_CARNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbo01_CARNO.ColumnCaptionHeight = 18;
            this.cbo01_CARNO.ColumnFooterHeight = 18;
            this.cbo01_CARNO.ContentHeight = 16;
            this.cbo01_CARNO.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbo01_CARNO.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbo01_CARNO.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo01_CARNO.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbo01_CARNO.EditorHeight = 16;
            this.cbo01_CARNO.Images.Add(((System.Drawing.Image)(resources.GetObject("cbo01_CARNO.Images"))));
            this.cbo01_CARNO.ItemHeight = 15;
            this.cbo01_CARNO.Location = new System.Drawing.Point(348, 65);
            this.cbo01_CARNO.MatchEntryTimeout = ((long)(2000));
            this.cbo01_CARNO.MaxDropDownItems = ((short)(5));
            this.cbo01_CARNO.MaxLength = 32767;
            this.cbo01_CARNO.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbo01_CARNO.Name = "cbo01_CARNO";
            this.cbo01_CARNO.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbo01_CARNO.Size = new System.Drawing.Size(142, 22);
            this.cbo01_CARNO.TabIndex = 93;
            this.cbo01_CARNO.PropBag = resources.GetString("cbo01_CARNO.PropBag");
            // 
            // ZPD23111
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ZPD23111";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.grp01_CHNG_HISTORY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TAGNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TAGNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CARSEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CARSEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CARNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ALCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_OPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo01_DELI_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo01_CARNO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxLabel lbl01_ALCCD;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_SEARCH_OPT;
        private DEV.Utility.Controls.AxCheckBox chk01_RSLT;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxDateEdit dte01_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private System.Windows.Forms.Splitter splitter1;
        private DEV.Utility.Controls.AxFlexGrid grd01_2;
        private System.Windows.Forms.GroupBox grp01_CHNG_HISTORY;
        private DEV.Utility.Controls.AxButton btn01_FILE_UPLOAD2;
        private DEV.Utility.Controls.AxButton btn01_EXCEL_DOWN;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.SaveFileDialog sfdExcel;
        private DEV.Utility.Controls.AxTextBox txt01_CARSEQ;
        private DEV.Utility.Controls.AxLabel lbl01_CARSEQ;
        private DEV.Utility.Controls.AxLabel lbl01_CARNO;
        private DEV.Utility.Controls.AxTextBox txt01_ALCCD;
        private DEV.Utility.Controls.AxTextBox txt01_TAGNO;
        private DEV.Utility.Controls.AxLabel lbl01_TAGNO;
        private DEV.Utility.Controls.AxLabel lbl01_DELI_TYPE;
        private DEV.Utility.Controls.AxComboList cbo01_CARNO;
        private DEV.Utility.Controls.AxComboList cbo01_DELI_TYPE;
    }
}
