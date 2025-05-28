namespace Ax.SIS.PD.UI
{
    partial class PD40310
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40310));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbl01_INSPEC_ITEMCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl01_INSPEC_DIV = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl01_PARTNO = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.rdo02_SASSYPNO = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_ASSYPNO = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.lbl06_INSPEC_ITEM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl05_INSPEC_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_MERGE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl03_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl04_ASSYPNO03 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_PROD_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl02_WORK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSPEC_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSPEC_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_INSPEC_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_INSPEC_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_ASSYPNO03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_WORK_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbl01_INSPEC_ITEMCD);
            this.panel2.Controls.Add(this.cbl01_INSPEC_DIV);
            this.panel2.Controls.Add(this.cbl01_PARTNO);
            this.panel2.Controls.Add(this.cbl01_LINECD);
            this.panel2.Controls.Add(this.rdo02_SASSYPNO);
            this.panel2.Controls.Add(this.rdo01_ASSYPNO);
            this.panel2.Controls.Add(this.lbl06_INSPEC_ITEM);
            this.panel2.Controls.Add(this.lbl05_INSPEC_DIV);
            this.panel2.Controls.Add(this.chk01_MERGE);
            this.panel2.Controls.Add(this.lbl03_LINE);
            this.panel2.Controls.Add(this.lbl04_ASSYPNO03);
            this.panel2.Controls.Add(this.dtp01_PROD_SDATE);
            this.panel2.Controls.Add(this.lbl02_WORK_DATE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // cbl01_INSPEC_ITEMCD
            // 
            this.cbl01_INSPEC_ITEMCD.AddItemSeparator = ';';
            this.cbl01_INSPEC_ITEMCD.Caption = "";
            this.cbl01_INSPEC_ITEMCD.CaptionHeight = 17;
            this.cbl01_INSPEC_ITEMCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_INSPEC_ITEMCD.ColumnCaptionHeight = 18;
            this.cbl01_INSPEC_ITEMCD.ColumnFooterHeight = 18;
            this.cbl01_INSPEC_ITEMCD.ContentHeight = 16;
            this.cbl01_INSPEC_ITEMCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_INSPEC_ITEMCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_INSPEC_ITEMCD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_INSPEC_ITEMCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_INSPEC_ITEMCD.EditorHeight = 16;
            this.cbl01_INSPEC_ITEMCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_INSPEC_ITEMCD.Images"))));
            this.cbl01_INSPEC_ITEMCD.ItemHeight = 15;
            this.cbl01_INSPEC_ITEMCD.Location = new System.Drawing.Point(13, 333);
            this.cbl01_INSPEC_ITEMCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INSPEC_ITEMCD.MaxDropDownItems = ((short)(5));
            this.cbl01_INSPEC_ITEMCD.MaxLength = 32767;
            this.cbl01_INSPEC_ITEMCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INSPEC_ITEMCD.Name = "cbl01_INSPEC_ITEMCD";
            this.cbl01_INSPEC_ITEMCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INSPEC_ITEMCD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_INSPEC_ITEMCD.TabIndex = 90;
            this.cbl01_INSPEC_ITEMCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_INSPEC_ITEMCD_BeforeOpen);
            this.cbl01_INSPEC_ITEMCD.PropBag = resources.GetString("cbl01_INSPEC_ITEMCD.PropBag");
            // 
            // cbl01_INSPEC_DIV
            // 
            this.cbl01_INSPEC_DIV.AddItemSeparator = ';';
            this.cbl01_INSPEC_DIV.Caption = "";
            this.cbl01_INSPEC_DIV.CaptionHeight = 17;
            this.cbl01_INSPEC_DIV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_INSPEC_DIV.ColumnCaptionHeight = 18;
            this.cbl01_INSPEC_DIV.ColumnFooterHeight = 18;
            this.cbl01_INSPEC_DIV.ContentHeight = 16;
            this.cbl01_INSPEC_DIV.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_INSPEC_DIV.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_INSPEC_DIV.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_INSPEC_DIV.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_INSPEC_DIV.EditorHeight = 16;
            this.cbl01_INSPEC_DIV.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_INSPEC_DIV.Images"))));
            this.cbl01_INSPEC_DIV.ItemHeight = 15;
            this.cbl01_INSPEC_DIV.Location = new System.Drawing.Point(13, 281);
            this.cbl01_INSPEC_DIV.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INSPEC_DIV.MaxDropDownItems = ((short)(5));
            this.cbl01_INSPEC_DIV.MaxLength = 32767;
            this.cbl01_INSPEC_DIV.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INSPEC_DIV.Name = "cbl01_INSPEC_DIV";
            this.cbl01_INSPEC_DIV.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INSPEC_DIV.Size = new System.Drawing.Size(226, 22);
            this.cbl01_INSPEC_DIV.TabIndex = 89;
            this.cbl01_INSPEC_DIV.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_INSPEC_DIV_BeforeOpen);
            this.cbl01_INSPEC_DIV.PropBag = resources.GetString("cbl01_INSPEC_DIV.PropBag");
            // 
            // cbl01_PARTNO
            // 
            this.cbl01_PARTNO.AddItemSeparator = ';';
            this.cbl01_PARTNO.Caption = "";
            this.cbl01_PARTNO.CaptionHeight = 17;
            this.cbl01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_PARTNO.ColumnCaptionHeight = 18;
            this.cbl01_PARTNO.ColumnFooterHeight = 18;
            this.cbl01_PARTNO.ContentHeight = 16;
            this.cbl01_PARTNO.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_PARTNO.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_PARTNO.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_PARTNO.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_PARTNO.EditorHeight = 16;
            this.cbl01_PARTNO.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_PARTNO.Images"))));
            this.cbl01_PARTNO.ItemHeight = 15;
            this.cbl01_PARTNO.Location = new System.Drawing.Point(13, 230);
            this.cbl01_PARTNO.MatchEntryTimeout = ((long)(2000));
            this.cbl01_PARTNO.MaxDropDownItems = ((short)(5));
            this.cbl01_PARTNO.MaxLength = 32767;
            this.cbl01_PARTNO.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_PARTNO.Name = "cbl01_PARTNO";
            this.cbl01_PARTNO.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_PARTNO.Size = new System.Drawing.Size(226, 22);
            this.cbl01_PARTNO.TabIndex = 88;
            this.cbl01_PARTNO.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_PARTNO_BeforeOpen);
            this.cbl01_PARTNO.PropBag = resources.GetString("cbl01_PARTNO.PropBag");
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(13, 183);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_LINECD.TabIndex = 87;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // rdo02_SASSYPNO
            // 
            this.rdo02_SASSYPNO.AutoSize = true;
            this.rdo02_SASSYPNO.Location = new System.Drawing.Point(94, 136);
            this.rdo02_SASSYPNO.Name = "rdo02_SASSYPNO";
            this.rdo02_SASSYPNO.Size = new System.Drawing.Size(59, 16);
            this.rdo02_SASSYPNO.TabIndex = 85;
            this.rdo02_SASSYPNO.TabStop = true;
            this.rdo02_SASSYPNO.Text = "반제품";
            this.rdo02_SASSYPNO.UseVisualStyleBackColor = true;
            // 
            // rdo01_ASSYPNO
            // 
            this.rdo01_ASSYPNO.AutoSize = true;
            this.rdo01_ASSYPNO.Checked = true;
            this.rdo01_ASSYPNO.Location = new System.Drawing.Point(13, 136);
            this.rdo01_ASSYPNO.Name = "rdo01_ASSYPNO";
            this.rdo01_ASSYPNO.Size = new System.Drawing.Size(59, 16);
            this.rdo01_ASSYPNO.TabIndex = 84;
            this.rdo01_ASSYPNO.TabStop = true;
            this.rdo01_ASSYPNO.Text = "완제품";
            this.rdo01_ASSYPNO.UseVisualStyleBackColor = true;
            // 
            // lbl06_INSPEC_ITEM
            // 
            this.lbl06_INSPEC_ITEM.AutoFontSizeMaxValue = 9F;
            this.lbl06_INSPEC_ITEM.AutoFontSizeMinValue = 9F;
            this.lbl06_INSPEC_ITEM.BackColor = System.Drawing.Color.Transparent;
            this.lbl06_INSPEC_ITEM.Location = new System.Drawing.Point(13, 318);
            this.lbl06_INSPEC_ITEM.Name = "lbl06_INSPEC_ITEM";
            this.lbl06_INSPEC_ITEM.Size = new System.Drawing.Size(226, 12);
            this.lbl06_INSPEC_ITEM.TabIndex = 82;
            this.lbl06_INSPEC_ITEM.Tag = null;
            this.lbl06_INSPEC_ITEM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl06_INSPEC_ITEM.Value = "계측항목";
            // 
            // lbl05_INSPEC_DIV
            // 
            this.lbl05_INSPEC_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl05_INSPEC_DIV.AutoFontSizeMinValue = 9F;
            this.lbl05_INSPEC_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl05_INSPEC_DIV.Location = new System.Drawing.Point(13, 266);
            this.lbl05_INSPEC_DIV.Name = "lbl05_INSPEC_DIV";
            this.lbl05_INSPEC_DIV.Size = new System.Drawing.Size(226, 12);
            this.lbl05_INSPEC_DIV.TabIndex = 80;
            this.lbl05_INSPEC_DIV.Tag = null;
            this.lbl05_INSPEC_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl05_INSPEC_DIV.Value = "계측유형";
            // 
            // chk01_MERGE
            // 
            this.chk01_MERGE.AutoSize = true;
            this.chk01_MERGE.Location = new System.Drawing.Point(13, 399);
            this.chk01_MERGE.Name = "chk01_MERGE";
            this.chk01_MERGE.Size = new System.Drawing.Size(106, 16);
            this.chk01_MERGE.TabIndex = 76;
            this.chk01_MERGE.Text = "chk01_MERGE";
            this.chk01_MERGE.UseVisualStyleBackColor = true;
            this.chk01_MERGE.CheckedChanged += new System.EventHandler(this.chk01_GRID_MERGE_CheckedChanged);
            // 
            // lbl03_LINE
            // 
            this.lbl03_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl03_LINE.AutoFontSizeMinValue = 9F;
            this.lbl03_LINE.BackColor = System.Drawing.Color.Transparent;
            this.lbl03_LINE.Location = new System.Drawing.Point(13, 168);
            this.lbl03_LINE.Name = "lbl03_LINE";
            this.lbl03_LINE.Size = new System.Drawing.Size(226, 12);
            this.lbl03_LINE.TabIndex = 73;
            this.lbl03_LINE.Tag = null;
            this.lbl03_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl03_LINE.Value = "라인";
            // 
            // lbl04_ASSYPNO03
            // 
            this.lbl04_ASSYPNO03.AutoFontSizeMaxValue = 9F;
            this.lbl04_ASSYPNO03.AutoFontSizeMinValue = 9F;
            this.lbl04_ASSYPNO03.BackColor = System.Drawing.Color.Transparent;
            this.lbl04_ASSYPNO03.Location = new System.Drawing.Point(13, 215);
            this.lbl04_ASSYPNO03.Name = "lbl04_ASSYPNO03";
            this.lbl04_ASSYPNO03.Size = new System.Drawing.Size(226, 12);
            this.lbl04_ASSYPNO03.TabIndex = 71;
            this.lbl04_ASSYPNO03.Tag = null;
            this.lbl04_ASSYPNO03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl04_ASSYPNO03.Value = "완제품 P/NO";
            // 
            // dtp01_PROD_SDATE
            // 
            this.dtp01_PROD_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_PROD_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_PROD_SDATE.Location = new System.Drawing.Point(13, 88);
            this.dtp01_PROD_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_PROD_SDATE.Name = "dtp01_PROD_SDATE";
            this.dtp01_PROD_SDATE.OriginalFormat = "";
            this.dtp01_PROD_SDATE.Size = new System.Drawing.Size(226, 21);
            this.dtp01_PROD_SDATE.TabIndex = 9;
            // 
            // lbl02_WORK_DATE
            // 
            this.lbl02_WORK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_WORK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_WORK_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl02_WORK_DATE.Location = new System.Drawing.Point(13, 73);
            this.lbl02_WORK_DATE.Name = "lbl02_WORK_DATE";
            this.lbl02_WORK_DATE.Size = new System.Drawing.Size(226, 12);
            this.lbl02_WORK_DATE.TabIndex = 8;
            this.lbl02_WORK_DATE.Tag = null;
            this.lbl02_WORK_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_WORK_DATE.Value = "작업일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 7;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 26);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZNM2.TabIndex = 6;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 2;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 736);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD40310
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD40310";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSPEC_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSPEC_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_INSPEC_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_INSPEC_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_ASSYPNO03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_WORK_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_PROD_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_WORK_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_LINE;
        private Ax.DEV.Utility.Controls.AxLabel lbl04_ASSYPNO03;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_MERGE;
        private Ax.DEV.Utility.Controls.AxLabel lbl06_INSPEC_ITEM;
        private Ax.DEV.Utility.Controls.AxLabel lbl05_INSPEC_DIV;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_ASSYPNO;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo02_SASSYPNO;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSPEC_ITEMCD;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSPEC_DIV;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_PARTNO;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
    }
}
