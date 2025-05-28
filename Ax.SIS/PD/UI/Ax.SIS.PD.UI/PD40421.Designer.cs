namespace Ax.SIS.PD.UI
{
    partial class PD40421
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40421));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_MPNO_SUBPNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt_MPNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_MPNO_SUBLOT = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PROD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt_MPNO_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.dtp01_START = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lb01_MAT_PARTENO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt_MAT_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lb_MAT_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_END = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.txt_MAT_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lb01_ASSY_HLOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MPNO_SUBPNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MPNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MPNO_SUBLOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MPNO_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb01_MAT_PARTENO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MAT_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_MAT_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MAT_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb01_ASSY_HLOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOTNO)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(278, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(746, 731);
            this.panel3.TabIndex = 3;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = false;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(746, 731);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbl01_LINECD);
            this.panel2.Controls.Add(this.lbl01_LINECD);
            this.panel2.Controls.Add(this.heLabel1);
            this.panel2.Controls.Add(this.lbl01_MPNO_SUBPNO);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.txt_MPNO);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_MPNO_SUBLOT);
            this.panel2.Controls.Add(this.lbl01_PROD_DATE);
            this.panel2.Controls.Add(this.txt_MPNO_LOTNO);
            this.panel2.Controls.Add(this.dtp01_START);
            this.panel2.Controls.Add(this.lb01_MAT_PARTENO);
            this.panel2.Controls.Add(this.txt_MAT_PARTNO);
            this.panel2.Controls.Add(this.lb_MAT_LOTNO);
            this.panel2.Controls.Add(this.dtp01_END);
            this.panel2.Controls.Add(this.txt_MAT_LOTNO);
            this.panel2.Controls.Add(this.lb01_ASSY_HLOTNO);
            this.panel2.Controls.Add(this.txt_LOTNO);
            this.panel2.Location = new System.Drawing.Point(3, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 708);
            this.panel2.TabIndex = 2;
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
            this.cbl01_LINECD.Location = new System.Drawing.Point(13, 126);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_LINECD.TabIndex = 97;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_LINECD.Location = new System.Drawing.Point(13, 100);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(226, 12);
            this.lbl01_LINECD.TabIndex = 96;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_LINECD.Value = "라인코드";
            // 
            // heLabel1
            // 
            this.heLabel1.AutoFontSizeMaxValue = 9F;
            this.heLabel1.AutoFontSizeMinValue = 9F;
            this.heLabel1.AutoSize = true;
            this.heLabel1.BackColor = System.Drawing.Color.White;
            this.heLabel1.Location = new System.Drawing.Point(120, 80);
            this.heLabel1.Name = "heLabel1";
            this.heLabel1.Size = new System.Drawing.Size(56, 12);
            this.heLabel1.TabIndex = 69;
            this.heLabel1.Tag = null;
            this.heLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel1.Value = "~";
            // 
            // lbl01_MPNO_SUBPNO
            // 
            this.lbl01_MPNO_SUBPNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_MPNO_SUBPNO.AutoFontSizeMinValue = 9F;
            this.lbl01_MPNO_SUBPNO.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_MPNO_SUBPNO.Location = new System.Drawing.Point(13, 367);
            this.lbl01_MPNO_SUBPNO.Name = "lbl01_MPNO_SUBPNO";
            this.lbl01_MPNO_SUBPNO.Size = new System.Drawing.Size(226, 12);
            this.lbl01_MPNO_SUBPNO.TabIndex = 67;
            this.lbl01_MPNO_SUBPNO.Tag = null;
            this.lbl01_MPNO_SUBPNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_MPNO_SUBPNO.Value = "SUB 자재 P/NO";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZNM2.TabIndex = 50;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // txt_MPNO
            // 
            this.txt_MPNO.Location = new System.Drawing.Point(13, 382);
            this.txt_MPNO.Name = "txt_MPNO";
            this.txt_MPNO.Size = new System.Drawing.Size(226, 21);
            this.txt_MPNO.TabIndex = 68;
            this.txt_MPNO.Tag = null;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 28);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 51;
            // 
            // lbl01_MPNO_SUBLOT
            // 
            this.lbl01_MPNO_SUBLOT.AutoFontSizeMaxValue = 9F;
            this.lbl01_MPNO_SUBLOT.AutoFontSizeMinValue = 9F;
            this.lbl01_MPNO_SUBLOT.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_MPNO_SUBLOT.Location = new System.Drawing.Point(13, 315);
            this.lbl01_MPNO_SUBLOT.Name = "lbl01_MPNO_SUBLOT";
            this.lbl01_MPNO_SUBLOT.Size = new System.Drawing.Size(226, 12);
            this.lbl01_MPNO_SUBLOT.TabIndex = 65;
            this.lbl01_MPNO_SUBLOT.Tag = null;
            this.lbl01_MPNO_SUBLOT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_MPNO_SUBLOT.Value = "SUB 자재 LOT";
            // 
            // lbl01_PROD_DATE
            // 
            this.lbl01_PROD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PROD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_PROD_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PROD_DATE.Location = new System.Drawing.Point(13, 61);
            this.lbl01_PROD_DATE.Name = "lbl01_PROD_DATE";
            this.lbl01_PROD_DATE.Size = new System.Drawing.Size(226, 12);
            this.lbl01_PROD_DATE.TabIndex = 52;
            this.lbl01_PROD_DATE.Tag = null;
            this.lbl01_PROD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PROD_DATE.Value = "생산일자";
            // 
            // txt_MPNO_LOTNO
            // 
            this.txt_MPNO_LOTNO.Location = new System.Drawing.Point(13, 330);
            this.txt_MPNO_LOTNO.Name = "txt_MPNO_LOTNO";
            this.txt_MPNO_LOTNO.Size = new System.Drawing.Size(226, 21);
            this.txt_MPNO_LOTNO.TabIndex = 66;
            this.txt_MPNO_LOTNO.Tag = null;
            // 
            // dtp01_START
            // 
            this.dtp01_START.CustomFormat = "yyyy-MM-dd";
            this.dtp01_START.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_START.Location = new System.Drawing.Point(13, 76);
            this.dtp01_START.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_START.Name = "dtp01_START";
            this.dtp01_START.OriginalFormat = "";
            this.dtp01_START.Size = new System.Drawing.Size(100, 21);
            this.dtp01_START.TabIndex = 53;
            // 
            // lb01_MAT_PARTENO
            // 
            this.lb01_MAT_PARTENO.AutoFontSizeMaxValue = 9F;
            this.lb01_MAT_PARTENO.AutoFontSizeMinValue = 9F;
            this.lb01_MAT_PARTENO.BackColor = System.Drawing.Color.Transparent;
            this.lb01_MAT_PARTENO.Location = new System.Drawing.Point(13, 263);
            this.lb01_MAT_PARTENO.Name = "lb01_MAT_PARTENO";
            this.lb01_MAT_PARTENO.Size = new System.Drawing.Size(226, 12);
            this.lb01_MAT_PARTENO.TabIndex = 63;
            this.lb01_MAT_PARTENO.Tag = null;
            this.lb01_MAT_PARTENO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb01_MAT_PARTENO.Value = "자재 P/NO";
            // 
            // txt_MAT_PARTNO
            // 
            this.txt_MAT_PARTNO.Location = new System.Drawing.Point(13, 278);
            this.txt_MAT_PARTNO.Name = "txt_MAT_PARTNO";
            this.txt_MAT_PARTNO.Size = new System.Drawing.Size(226, 21);
            this.txt_MAT_PARTNO.TabIndex = 64;
            this.txt_MAT_PARTNO.Tag = null;
            // 
            // lb_MAT_LOTNO
            // 
            this.lb_MAT_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lb_MAT_LOTNO.AutoFontSizeMinValue = 9F;
            this.lb_MAT_LOTNO.BackColor = System.Drawing.Color.Transparent;
            this.lb_MAT_LOTNO.Location = new System.Drawing.Point(13, 211);
            this.lb_MAT_LOTNO.Name = "lb_MAT_LOTNO";
            this.lb_MAT_LOTNO.Size = new System.Drawing.Size(226, 12);
            this.lb_MAT_LOTNO.TabIndex = 61;
            this.lb_MAT_LOTNO.Tag = null;
            this.lb_MAT_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_MAT_LOTNO.Value = "자재 LOT NO";
            // 
            // dtp01_END
            // 
            this.dtp01_END.CustomFormat = "yyyy-MM-dd";
            this.dtp01_END.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_END.Location = new System.Drawing.Point(139, 76);
            this.dtp01_END.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_END.Name = "dtp01_END";
            this.dtp01_END.OriginalFormat = "";
            this.dtp01_END.Size = new System.Drawing.Size(100, 21);
            this.dtp01_END.TabIndex = 56;
            // 
            // txt_MAT_LOTNO
            // 
            this.txt_MAT_LOTNO.Location = new System.Drawing.Point(13, 226);
            this.txt_MAT_LOTNO.Name = "txt_MAT_LOTNO";
            this.txt_MAT_LOTNO.Size = new System.Drawing.Size(226, 21);
            this.txt_MAT_LOTNO.TabIndex = 62;
            this.txt_MAT_LOTNO.Tag = null;
            // 
            // lb01_ASSY_HLOTNO
            // 
            this.lb01_ASSY_HLOTNO.AutoFontSizeMaxValue = 9F;
            this.lb01_ASSY_HLOTNO.AutoFontSizeMinValue = 9F;
            this.lb01_ASSY_HLOTNO.BackColor = System.Drawing.Color.Transparent;
            this.lb01_ASSY_HLOTNO.Location = new System.Drawing.Point(13, 159);
            this.lb01_ASSY_HLOTNO.Name = "lb01_ASSY_HLOTNO";
            this.lb01_ASSY_HLOTNO.Size = new System.Drawing.Size(226, 12);
            this.lb01_ASSY_HLOTNO.TabIndex = 59;
            this.lb01_ASSY_HLOTNO.Tag = null;
            this.lb01_ASSY_HLOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb01_ASSY_HLOTNO.Value = "완제품 LOT NO";
            // 
            // txt_LOTNO
            // 
            this.txt_LOTNO.Location = new System.Drawing.Point(13, 174);
            this.txt_LOTNO.Name = "txt_LOTNO";
            this.txt_LOTNO.Size = new System.Drawing.Size(226, 21);
            this.txt_LOTNO.TabIndex = 60;
            this.txt_LOTNO.Tag = null;
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 1;
            // 
            // PD40421
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "PD40421";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MPNO_SUBPNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MPNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MPNO_SUBLOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MPNO_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb01_MAT_PARTENO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MAT_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_MAT_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MAT_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb01_ASSY_HLOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOTNO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel heLabel1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MPNO_SUBPNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxTextBox txt_MPNO;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MPNO_SUBLOT;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PROD_DATE;
        private Ax.DEV.Utility.Controls.AxTextBox txt_MPNO_LOTNO;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_START;
        private Ax.DEV.Utility.Controls.AxLabel lb01_MAT_PARTENO;
        private Ax.DEV.Utility.Controls.AxTextBox txt_MAT_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lb_MAT_LOTNO;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_END;
        private Ax.DEV.Utility.Controls.AxTextBox txt_MAT_LOTNO;
        private Ax.DEV.Utility.Controls.AxLabel lb01_ASSY_HLOTNO;
        private Ax.DEV.Utility.Controls.AxTextBox txt_LOTNO;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINECD;
    }
}
