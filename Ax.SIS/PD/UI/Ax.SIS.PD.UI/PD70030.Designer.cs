namespace Ax.SIS.PD.UI
{
    partial class PD70030
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD70030));
            this.txt01_STR_LOC = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_STR_LOC = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.label1 = new System.Windows.Forms.Label();
            this.txt01_PARTNO_PARTNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNOTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_PLAN_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_PLAN_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_SEARCH_DAY = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_STR_LOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_DAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt01_STR_LOC
            // 
            this.txt01_STR_LOC.Location = new System.Drawing.Point(731, 14);
            this.txt01_STR_LOC.Name = "txt01_STR_LOC";
            this.txt01_STR_LOC.Size = new System.Drawing.Size(123, 21);
            this.txt01_STR_LOC.TabIndex = 1;
            this.txt01_STR_LOC.Tag = null;
            // 
            // lbl01_STR_LOC
            // 
            this.lbl01_STR_LOC.AutoFontSizeMaxValue = 9F;
            this.lbl01_STR_LOC.AutoFontSizeMinValue = 9F;
            this.lbl01_STR_LOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STR_LOC.Location = new System.Drawing.Point(625, 14);
            this.lbl01_STR_LOC.Name = "lbl01_STR_LOC";
            this.lbl01_STR_LOC.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STR_LOC.TabIndex = 0;
            this.lbl01_STR_LOC.Tag = null;
            this.lbl01_STR_LOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STR_LOC.Value = "저장위치";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 660);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 640);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbl01_LINECD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt01_PARTNO_PARTNM);
            this.groupBox1.Controls.Add(this.lbl01_PARTNOTITLE);
            this.groupBox1.Controls.Add(this.lbl01_LINE);
            this.groupBox1.Controls.Add(this.dte01_PLAN_END_DATE);
            this.groupBox1.Controls.Add(this.dte01_PLAN_BEG_DATE);
            this.groupBox1.Controls.Add(this.lbl01_SEARCH_DAY);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.txt01_STR_LOC);
            this.groupBox1.Controls.Add(this.lbl01_STR_LOC);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(1024, 68);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(112, 40);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(169, 22);
            this.cbl01_LINECD.TabIndex = 91;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "~";
            // 
            // txt01_PARTNO_PARTNM
            // 
            this.txt01_PARTNO_PARTNM.Location = new System.Drawing.Point(391, 39);
            this.txt01_PARTNO_PARTNM.Name = "txt01_PARTNO_PARTNM";
            this.txt01_PARTNO_PARTNM.Size = new System.Drawing.Size(228, 21);
            this.txt01_PARTNO_PARTNM.TabIndex = 16;
            this.txt01_PARTNO_PARTNM.Tag = null;
            // 
            // lbl01_PARTNOTITLE
            // 
            this.lbl01_PARTNOTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNOTITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNOTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNOTITLE.Location = new System.Drawing.Point(287, 39);
            this.lbl01_PARTNOTITLE.Name = "lbl01_PARTNOTITLE";
            this.lbl01_PARTNOTITLE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PARTNOTITLE.TabIndex = 15;
            this.lbl01_PARTNOTITLE.Tag = null;
            this.lbl01_PARTNOTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNOTITLE.Value = "품번";
            // 
            // lbl01_LINE
            // 
            this.lbl01_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINE.AutoFontSizeMinValue = 9F;
            this.lbl01_LINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINE.Location = new System.Drawing.Point(7, 39);
            this.lbl01_LINE.Name = "lbl01_LINE";
            this.lbl01_LINE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINE.TabIndex = 11;
            this.lbl01_LINE.Tag = null;
            this.lbl01_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINE.Value = "라인코드/라인명";
            // 
            // dte01_PLAN_END_DATE
            // 
            this.dte01_PLAN_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_PLAN_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_PLAN_END_DATE.Location = new System.Drawing.Point(516, 14);
            this.dte01_PLAN_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_PLAN_END_DATE.Name = "dte01_PLAN_END_DATE";
            this.dte01_PLAN_END_DATE.OriginalFormat = "";
            this.dte01_PLAN_END_DATE.Size = new System.Drawing.Size(103, 21);
            this.dte01_PLAN_END_DATE.TabIndex = 9;
            // 
            // dte01_PLAN_BEG_DATE
            // 
            this.dte01_PLAN_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_PLAN_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_PLAN_BEG_DATE.Location = new System.Drawing.Point(391, 14);
            this.dte01_PLAN_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_PLAN_BEG_DATE.Name = "dte01_PLAN_BEG_DATE";
            this.dte01_PLAN_BEG_DATE.OriginalFormat = "";
            this.dte01_PLAN_BEG_DATE.Size = new System.Drawing.Size(103, 21);
            this.dte01_PLAN_BEG_DATE.TabIndex = 8;
            // 
            // lbl01_SEARCH_DAY
            // 
            this.lbl01_SEARCH_DAY.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCH_DAY.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCH_DAY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SEARCH_DAY.Location = new System.Drawing.Point(287, 14);
            this.lbl01_SEARCH_DAY.Name = "lbl01_SEARCH_DAY";
            this.lbl01_SEARCH_DAY.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SEARCH_DAY.TabIndex = 7;
            this.lbl01_SEARCH_DAY.Tag = null;
            this.lbl01_SEARCH_DAY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SEARCH_DAY.Value = "조회일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(169, 20);
            this.cbo01_BIZCD.TabIndex = 3;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(7, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 2;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장코드";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 762);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1024, 6);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // PD70030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Name = "PD70030";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_STR_LOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_DAY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxTextBox txt01_STR_LOC;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_STR_LOC;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxDateEdit dte01_PLAN_END_DATE;
        private DEV.Utility.Controls.AxDateEdit dte01_PLAN_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_SEARCH_DAY;
        private System.Windows.Forms.Label label1;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO_PARTNM;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNOTITLE;
        private DEV.Utility.Controls.AxLabel lbl01_LINE;
        private System.Windows.Forms.Splitter splitter1;
        private DEV.Utility.Controls.AxComboList cbl01_LINECD;
    }
}
