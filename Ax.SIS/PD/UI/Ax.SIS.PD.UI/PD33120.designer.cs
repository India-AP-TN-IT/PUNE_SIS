namespace Ax.SIS.PD.UI
{
    partial class PD33120
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ALC = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_ALCCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_JOB_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.dtp01_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_JOB_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ALCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_JOB_TYPE)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.axDockingTab1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 734);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd01);
            this.panel2.Location = new System.Drawing.Point(303, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 263);
            this.panel2.TabIndex = 14;
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
            this.grd01.Size = new System.Drawing.Size(354, 263);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axLabel1);
            this.panel1.Controls.Add(this.lbl01_PARTNO);
            this.panel1.Controls.Add(this.lbl01_ALC);
            this.panel1.Controls.Add(this.txt01_PARTNO);
            this.panel1.Controls.Add(this.txt01_ALCCD);
            this.panel1.Controls.Add(this.cdx01_LINECD);
            this.panel1.Controls.Add(this.cbo01_JOB_TYPE);
            this.panel1.Controls.Add(this.dtp01_END_DATE);
            this.panel1.Controls.Add(this.dtp01_BEG_DATE);
            this.panel1.Controls.Add(this.lbl01_STD_DATE);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_LINECD);
            this.panel1.Controls.Add(this.lbl01_JOB_TYPE);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 486);
            this.panel1.TabIndex = 12;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.Transparent;
            this.axLabel1.Location = new System.Drawing.Point(107, 82);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(20, 12);
            this.axLabel1.TabIndex = 94;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.axLabel1.Value = "~";
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PARTNO.Location = new System.Drawing.Point(13, 159);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(204, 12);
            this.lbl01_PARTNO.TabIndex = 93;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "PARTNO";
            // 
            // lbl01_ALC
            // 
            this.lbl01_ALC.AutoFontSizeMaxValue = 9F;
            this.lbl01_ALC.AutoFontSizeMinValue = 9F;
            this.lbl01_ALC.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_ALC.Location = new System.Drawing.Point(13, 209);
            this.lbl01_ALC.Name = "lbl01_ALC";
            this.lbl01_ALC.Size = new System.Drawing.Size(204, 12);
            this.lbl01_ALC.TabIndex = 92;
            this.lbl01_ALC.Tag = null;
            this.lbl01_ALC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ALC.Value = "ALC";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(13, 174);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(204, 21);
            this.txt01_PARTNO.TabIndex = 91;
            this.txt01_PARTNO.Tag = null;
            // 
            // txt01_ALCCD
            // 
            this.txt01_ALCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_ALCCD.Location = new System.Drawing.Point(13, 225);
            this.txt01_ALCCD.Name = "txt01_ALCCD";
            this.txt01_ALCCD.Size = new System.Drawing.Size(204, 21);
            this.txt01_ALCCD.TabIndex = 90;
            this.txt01_ALCCD.Tag = null;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(13, 124);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(204, 21);
            this.cdx01_LINECD.TabIndex = 89;
            this.cdx01_LINECD.Tag = null;
            // 
            // cbo01_JOB_TYPE
            // 
            this.cbo01_JOB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_JOB_TYPE.FormattingEnabled = true;
            this.cbo01_JOB_TYPE.Location = new System.Drawing.Point(13, 276);
            this.cbo01_JOB_TYPE.Name = "cbo01_JOB_TYPE";
            this.cbo01_JOB_TYPE.Size = new System.Drawing.Size(204, 20);
            this.cbo01_JOB_TYPE.TabIndex = 86;
            // 
            // dtp01_END_DATE
            // 
            this.dtp01_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_END_DATE.Location = new System.Drawing.Point(127, 76);
            this.dtp01_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_END_DATE.Name = "dtp01_END_DATE";
            this.dtp01_END_DATE.OriginalFormat = "";
            this.dtp01_END_DATE.Size = new System.Drawing.Size(90, 21);
            this.dtp01_END_DATE.TabIndex = 85;
            // 
            // dtp01_BEG_DATE
            // 
            this.dtp01_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_DATE.Location = new System.Drawing.Point(13, 76);
            this.dtp01_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_BEG_DATE.Name = "dtp01_BEG_DATE";
            this.dtp01_BEG_DATE.OriginalFormat = "";
            this.dtp01_BEG_DATE.Size = new System.Drawing.Size(90, 21);
            this.dtp01_BEG_DATE.TabIndex = 83;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(13, 61);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(200, 12);
            this.lbl01_STD_DATE.TabIndex = 82;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_STD_DATE.Value = "일자 From";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(200, 12);
            this.lbl01_BIZNM2.TabIndex = 61;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 29);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(204, 20);
            this.cbo01_BIZCD.TabIndex = 62;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_LINECD.Location = new System.Drawing.Point(13, 109);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(204, 12);
            this.lbl01_LINECD.TabIndex = 58;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_LINECD.Value = "LINE";
            // 
            // lbl01_JOB_TYPE
            // 
            this.lbl01_JOB_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_JOB_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_JOB_TYPE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_JOB_TYPE.Location = new System.Drawing.Point(13, 261);
            this.lbl01_JOB_TYPE.Name = "lbl01_JOB_TYPE";
            this.lbl01_JOB_TYPE.Size = new System.Drawing.Size(204, 12);
            this.lbl01_JOB_TYPE.TabIndex = 56;
            this.lbl01_JOB_TYPE.Tag = null;
            this.lbl01_JOB_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_JOB_TYPE.Value = "업무유형";
            // 
            // axDockingTab1
            // 
            this.axDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.axDockingTab1.Name = "axDockingTab1";
            this.axDockingTab1.PanelHeight = 714;
            this.axDockingTab1.PanelWidth = 250;
            this.axDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.axDockingTab1.TabIndex = 13;
            // 
            // PD33120
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Name = "PD33120";
            this.Load += new System.EventHandler(this.PD33110_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ALCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_JOB_TYPE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_JOB_TYPE;
        private DEV.Utility.Controls.AxDockingTab axDockingTab1;
        private DEV.Utility.Controls.AxDateEdit dtp01_END_DATE;
        private DEV.Utility.Controls.AxDateEdit dtp01_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_JOB_TYPE;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxTextBox txt01_ALCCD;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_ALC;
        private DEV.Utility.Controls.AxLabel axLabel1;
    }
}
