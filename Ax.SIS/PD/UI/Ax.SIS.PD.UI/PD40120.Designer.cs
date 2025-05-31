namespace Ax.SIS.PD.UI
{
    partial class PD40120
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40120));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl06_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl05_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl04_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl03_Wave = new System.Windows.Forms.Label();
            this.dtp01_RSLT_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_RSLT_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl02_WORK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_WORK_DATE)).BeginInit();
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
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbl01_INSTALL_POS);
            this.panel2.Controls.Add(this.cbl01_LINECD);
            this.panel2.Controls.Add(this.txt01_LOTNO);
            this.panel2.Controls.Add(this.lbl06_LOTNO);
            this.panel2.Controls.Add(this.lbl05_POSTITLE);
            this.panel2.Controls.Add(this.lbl04_LINE);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl03_Wave);
            this.panel2.Controls.Add(this.dtp01_RSLT_EDATE);
            this.panel2.Controls.Add(this.dtp01_RSLT_SDATE);
            this.panel2.Controls.Add(this.lbl02_WORK_DATE);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
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
            this.cbl01_INSTALL_POS.Location = new System.Drawing.Point(13, 187);
            this.cbl01_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl01_INSTALL_POS.MaxLength = 32767;
            this.cbl01_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INSTALL_POS.Name = "cbl01_INSTALL_POS";
            this.cbl01_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INSTALL_POS.Size = new System.Drawing.Size(226, 22);
            this.cbl01_INSTALL_POS.TabIndex = 92;
            this.cbl01_INSTALL_POS.PropBag = resources.GetString("cbl01_INSTALL_POS.PropBag");
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(13, 136);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_LINECD.TabIndex = 91;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.Location = new System.Drawing.Point(13, 238);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_LOTNO.TabIndex = 90;
            this.txt01_LOTNO.Tag = null;
            // 
            // lbl06_LOTNO
            // 
            this.lbl06_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lbl06_LOTNO.AutoFontSizeMinValue = 9F;
            this.lbl06_LOTNO.BackColor = System.Drawing.Color.Transparent;
            this.lbl06_LOTNO.Location = new System.Drawing.Point(13, 223);
            this.lbl06_LOTNO.Name = "lbl06_LOTNO";
            this.lbl06_LOTNO.Size = new System.Drawing.Size(226, 12);
            this.lbl06_LOTNO.TabIndex = 89;
            this.lbl06_LOTNO.Tag = null;
            this.lbl06_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl06_LOTNO.Value = "Lot No";
            // 
            // lbl05_POSTITLE
            // 
            this.lbl05_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl05_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl05_POSTITLE.BackColor = System.Drawing.Color.Transparent;
            this.lbl05_POSTITLE.Location = new System.Drawing.Point(13, 172);
            this.lbl05_POSTITLE.Name = "lbl05_POSTITLE";
            this.lbl05_POSTITLE.Size = new System.Drawing.Size(226, 12);
            this.lbl05_POSTITLE.TabIndex = 88;
            this.lbl05_POSTITLE.Tag = null;
            this.lbl05_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl05_POSTITLE.Value = "장착위치";
            // 
            // lbl04_LINE
            // 
            this.lbl04_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl04_LINE.AutoFontSizeMinValue = 9F;
            this.lbl04_LINE.BackColor = System.Drawing.Color.Transparent;
            this.lbl04_LINE.Location = new System.Drawing.Point(13, 121);
            this.lbl04_LINE.Name = "lbl04_LINE";
            this.lbl04_LINE.Size = new System.Drawing.Size(226, 12);
            this.lbl04_LINE.TabIndex = 86;
            this.lbl04_LINE.Tag = null;
            this.lbl04_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl04_LINE.Value = "라인";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 22);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZNM2.TabIndex = 84;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 83;
            // 
            // lbl03_Wave
            // 
            this.lbl03_Wave.AutoSize = true;
            this.lbl03_Wave.Location = new System.Drawing.Point(119, 90);
            this.lbl03_Wave.Name = "lbl03_Wave";
            this.lbl03_Wave.Size = new System.Drawing.Size(14, 12);
            this.lbl03_Wave.TabIndex = 82;
            this.lbl03_Wave.Text = "~";
            // 
            // dtp01_RSLT_EDATE
            // 
            this.dtp01_RSLT_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_RSLT_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_RSLT_EDATE.Location = new System.Drawing.Point(139, 86);
            this.dtp01_RSLT_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_RSLT_EDATE.Name = "dtp01_RSLT_EDATE";
            this.dtp01_RSLT_EDATE.OriginalFormat = "";
            this.dtp01_RSLT_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_RSLT_EDATE.TabIndex = 81;
            // 
            // dtp01_RSLT_SDATE
            // 
            this.dtp01_RSLT_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_RSLT_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_RSLT_SDATE.Location = new System.Drawing.Point(13, 86);
            this.dtp01_RSLT_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_RSLT_SDATE.Name = "dtp01_RSLT_SDATE";
            this.dtp01_RSLT_SDATE.OriginalFormat = "";
            this.dtp01_RSLT_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_RSLT_SDATE.TabIndex = 80;
            // 
            // lbl02_WORK_DATE
            // 
            this.lbl02_WORK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_WORK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_WORK_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl02_WORK_DATE.Location = new System.Drawing.Point(13, 71);
            this.lbl02_WORK_DATE.Name = "lbl02_WORK_DATE";
            this.lbl02_WORK_DATE.Size = new System.Drawing.Size(226, 12);
            this.lbl02_WORK_DATE.TabIndex = 79;
            this.lbl02_WORK_DATE.Tag = null;
            this.lbl02_WORK_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_WORK_DATE.Value = "작업일자";
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
            this.panel3.TabIndex = 4;
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
            // PD40120
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD40120";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl06_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl05_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_WORK_DATE)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Label lbl03_Wave;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_RSLT_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_RSLT_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_WORK_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl04_LINE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl05_POSTITLE;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl06_LOTNO;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;



    }
}
