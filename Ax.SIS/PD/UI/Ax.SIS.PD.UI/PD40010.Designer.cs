namespace Ax.SIS.PD.UI
{
    partial class PD40010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40010));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl05_wave = new System.Windows.Forms.Label();
            this.dtp01_INSPEC_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_INSPEC_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl04_INSPEC_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl03_DIVISION = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CHK_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_INSPEC_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_DIVISION)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).BeginInit();
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
            this.panel2.Controls.Add(this.lbl05_wave);
            this.panel2.Controls.Add(this.dtp01_INSPEC_EDATE);
            this.panel2.Controls.Add(this.dtp01_INSPEC_SDATE);
            this.panel2.Controls.Add(this.lbl04_INSPEC_DATE);
            this.panel2.Controls.Add(this.lbl03_DIVISION);
            this.panel2.Controls.Add(this.cbo01_CHK_TYPE);
            this.panel2.Controls.Add(this.lbl02_POSTITLE);
            this.panel2.Controls.Add(this.lbl01_LINE);
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
            this.cbl01_INSTALL_POS.Location = new System.Drawing.Point(16, 83);
            this.cbl01_INSTALL_POS.MatchEntryTimeout = ((long)(2000));
            this.cbl01_INSTALL_POS.MaxDropDownItems = ((short)(5));
            this.cbl01_INSTALL_POS.MaxLength = 32767;
            this.cbl01_INSTALL_POS.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_INSTALL_POS.Name = "cbl01_INSTALL_POS";
            this.cbl01_INSTALL_POS.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_INSTALL_POS.Size = new System.Drawing.Size(226, 22);
            this.cbl01_INSTALL_POS.TabIndex = 96;
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(16, 32);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_LINECD.TabIndex = 95;
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // lbl05_wave
            // 
            this.lbl05_wave.AutoSize = true;
            this.lbl05_wave.Location = new System.Drawing.Point(122, 187);
            this.lbl05_wave.Name = "lbl05_wave";
            this.lbl05_wave.Size = new System.Drawing.Size(14, 12);
            this.lbl05_wave.TabIndex = 94;
            this.lbl05_wave.Text = "~";
            // 
            // dtp01_INSPEC_EDATE
            // 
            this.dtp01_INSPEC_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_INSPEC_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_INSPEC_EDATE.Location = new System.Drawing.Point(142, 183);
            this.dtp01_INSPEC_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_INSPEC_EDATE.Name = "dtp01_INSPEC_EDATE";
            this.dtp01_INSPEC_EDATE.OriginalFormat = "";
            this.dtp01_INSPEC_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_INSPEC_EDATE.TabIndex = 93;
            // 
            // dtp01_INSPEC_SDATE
            // 
            this.dtp01_INSPEC_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_INSPEC_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_INSPEC_SDATE.Location = new System.Drawing.Point(16, 183);
            this.dtp01_INSPEC_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_INSPEC_SDATE.Name = "dtp01_INSPEC_SDATE";
            this.dtp01_INSPEC_SDATE.OriginalFormat = "";
            this.dtp01_INSPEC_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_INSPEC_SDATE.TabIndex = 92;
            // 
            // lbl04_INSPEC_DATE
            // 
            this.lbl04_INSPEC_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl04_INSPEC_DATE.AutoFontSizeMinValue = 9F;
            this.lbl04_INSPEC_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl04_INSPEC_DATE.Location = new System.Drawing.Point(16, 161);
            this.lbl04_INSPEC_DATE.Name = "lbl04_INSPEC_DATE";
            this.lbl04_INSPEC_DATE.Size = new System.Drawing.Size(226, 21);
            this.lbl04_INSPEC_DATE.TabIndex = 91;
            this.lbl04_INSPEC_DATE.Tag = null;
            this.lbl04_INSPEC_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl04_INSPEC_DATE.Value = "기준일";
            // 
            // lbl03_DIVISION
            // 
            this.lbl03_DIVISION.AutoFontSizeMaxValue = 9F;
            this.lbl03_DIVISION.AutoFontSizeMinValue = 9F;
            this.lbl03_DIVISION.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_DIVISION.Location = new System.Drawing.Point(16, 112);
            this.lbl03_DIVISION.Name = "lbl03_DIVISION";
            this.lbl03_DIVISION.Size = new System.Drawing.Size(226, 21);
            this.lbl03_DIVISION.TabIndex = 90;
            this.lbl03_DIVISION.Tag = null;
            this.lbl03_DIVISION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl03_DIVISION.Value = "구분";
            // 
            // cbo01_CHK_TYPE
            // 
            this.cbo01_CHK_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CHK_TYPE.FormattingEnabled = true;
            this.cbo01_CHK_TYPE.Location = new System.Drawing.Point(16, 134);
            this.cbo01_CHK_TYPE.Name = "cbo01_CHK_TYPE";
            this.cbo01_CHK_TYPE.Size = new System.Drawing.Size(226, 20);
            this.cbo01_CHK_TYPE.TabIndex = 89;
            // 
            // lbl02_POSTITLE
            // 
            this.lbl02_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl02_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl02_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_POSTITLE.Location = new System.Drawing.Point(16, 61);
            this.lbl02_POSTITLE.Name = "lbl02_POSTITLE";
            this.lbl02_POSTITLE.Size = new System.Drawing.Size(226, 21);
            this.lbl02_POSTITLE.TabIndex = 88;
            this.lbl02_POSTITLE.Tag = null;
            this.lbl02_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_POSTITLE.Value = "장착위치";
            // 
            // lbl01_LINE
            // 
            this.lbl01_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINE.AutoFontSizeMinValue = 9F;
            this.lbl01_LINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINE.Location = new System.Drawing.Point(16, 10);
            this.lbl01_LINE.Name = "lbl01_LINE";
            this.lbl01_LINE.Size = new System.Drawing.Size(226, 21);
            this.lbl01_LINE.TabIndex = 86;
            this.lbl01_LINE.Tag = null;
            this.lbl01_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_LINE.Value = "라인";
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
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
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
            // PD40010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD40010";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_INSPEC_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_DIVISION)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).EndInit();
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
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINE;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_DIVISION;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_CHK_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_POSTITLE;
        private System.Windows.Forms.Label lbl05_wave;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_INSPEC_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_INSPEC_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl04_INSPEC_DATE;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_INSTALL_POS;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;



    }
}
