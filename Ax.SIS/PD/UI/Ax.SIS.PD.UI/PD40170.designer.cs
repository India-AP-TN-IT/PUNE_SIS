namespace Ax.SIS.PD.UI
{
    partial class PD40170
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40170));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_ITEMCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ITEMCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_OPTION2_PD40170 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_OPTION1_PD40170 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.dtp01_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.AxDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.AxDockingTab1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 734);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd01);
            this.panel2.Location = new System.Drawing.Point(280, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 248);
            this.panel2.TabIndex = 15;
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
            this.grd01.Size = new System.Drawing.Size(357, 248);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cdx01_LINECD);
            this.panel1.Controls.Add(this.lbl01_INSTALL_POS);
            this.panel1.Controls.Add(this.cbo01_INSTALL_POS);
            this.panel1.Controls.Add(this.cdx01_ITEMCD);
            this.panel1.Controls.Add(this.cdx01_VINCD);
            this.panel1.Controls.Add(this.lbl01_VINCD);
            this.panel1.Controls.Add(this.lbl01_ITEMCD);
            this.panel1.Controls.Add(this.lbl01_LINECD);
            this.panel1.Controls.Add(this.chk01_OPTION2_PD40170);
            this.panel1.Controls.Add(this.cbo01_PRDT_DIV);
            this.panel1.Controls.Add(this.lbl01_PRDT_DIV);
            this.panel1.Controls.Add(this.chk01_OPTION1_PD40170);
            this.panel1.Controls.Add(this.dtp01_BEG_DATE);
            this.panel1.Controls.Add(this.lbl01_STD_DATE);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 714);
            this.panel1.TabIndex = 13;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 40;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(14, 252);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_LINECD.TabIndex = 100;
            this.cdx01_LINECD.Tag = null;
            // 
            // lbl01_INSTALL_POS
            // 
            this.lbl01_INSTALL_POS.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSTALL_POS.AutoFontSizeMinValue = 9F;
            this.lbl01_INSTALL_POS.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_INSTALL_POS.Location = new System.Drawing.Point(14, 281);
            this.lbl01_INSTALL_POS.Name = "lbl01_INSTALL_POS";
            this.lbl01_INSTALL_POS.Size = new System.Drawing.Size(200, 20);
            this.lbl01_INSTALL_POS.TabIndex = 99;
            this.lbl01_INSTALL_POS.Tag = null;
            this.lbl01_INSTALL_POS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_INSTALL_POS.Value = "장착위치";
            // 
            // cbo01_INSTALL_POS
            // 
            this.cbo01_INSTALL_POS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INSTALL_POS.FormattingEnabled = true;
            this.cbo01_INSTALL_POS.Location = new System.Drawing.Point(14, 302);
            this.cbo01_INSTALL_POS.Name = "cbo01_INSTALL_POS";
            this.cbo01_INSTALL_POS.Size = new System.Drawing.Size(200, 23);
            this.cbo01_INSTALL_POS.TabIndex = 98;
            // 
            // cdx01_ITEMCD
            // 
            this.cdx01_ITEMCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdx01_ITEMCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_ITEMCD.CodeParameterName = "CODE";
            this.cdx01_ITEMCD.CodeTextBoxReadOnly = false;
            this.cdx01_ITEMCD.CodeTextBoxVisible = true;
            this.cdx01_ITEMCD.CodeTextBoxWidth = 40;
            this.cdx01_ITEMCD.HEPopupHelper = null;
            this.cdx01_ITEMCD.Location = new System.Drawing.Point(14, 408);
            this.cdx01_ITEMCD.Name = "cdx01_ITEMCD";
            this.cdx01_ITEMCD.NameParameterName = "NAME";
            this.cdx01_ITEMCD.NameTextBoxReadOnly = false;
            this.cdx01_ITEMCD.NameTextBoxVisible = true;
            this.cdx01_ITEMCD.PopupButtonReadOnly = false;
            this.cdx01_ITEMCD.PopupTitle = "";
            this.cdx01_ITEMCD.PrefixCode = "";
            this.cdx01_ITEMCD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_ITEMCD.TabIndex = 97;
            this.cdx01_ITEMCD.Tag = null;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(14, 354);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_VINCD.TabIndex = 96;
            this.cdx01_VINCD.Tag = null;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VINCD.Location = new System.Drawing.Point(14, 333);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(200, 20);
            this.lbl01_VINCD.TabIndex = 95;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VINCD.Value = "차종";
            // 
            // lbl01_ITEMCD
            // 
            this.lbl01_ITEMCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ITEMCD.AutoFontSizeMinValue = 9F;
            this.lbl01_ITEMCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_ITEMCD.Location = new System.Drawing.Point(14, 387);
            this.lbl01_ITEMCD.Name = "lbl01_ITEMCD";
            this.lbl01_ITEMCD.Size = new System.Drawing.Size(200, 20);
            this.lbl01_ITEMCD.TabIndex = 94;
            this.lbl01_ITEMCD.Tag = null;
            this.lbl01_ITEMCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ITEMCD.Value = "품목";
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_LINECD.Location = new System.Drawing.Point(14, 229);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(200, 20);
            this.lbl01_LINECD.TabIndex = 92;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_LINECD.Value = "대상 LINE";
            // 
            // chk01_OPTION2_PD40170
            // 
            this.chk01_OPTION2_PD40170.AutoSize = true;
            this.chk01_OPTION2_PD40170.Location = new System.Drawing.Point(14, 199);
            this.chk01_OPTION2_PD40170.Name = "chk01_OPTION2_PD40170";
            this.chk01_OPTION2_PD40170.Size = new System.Drawing.Size(106, 19);
            this.chk01_OPTION2_PD40170.TabIndex = 91;
            this.chk01_OPTION2_PD40170.Text = "D+1~D+4 계획";
            this.chk01_OPTION2_PD40170.UseVisualStyleBackColor = true;
            // 
            // cbo01_PRDT_DIV
            // 
            this.cbo01_PRDT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRDT_DIV.FormattingEnabled = true;
            this.cbo01_PRDT_DIV.Location = new System.Drawing.Point(14, 142);
            this.cbo01_PRDT_DIV.Name = "cbo01_PRDT_DIV";
            this.cbo01_PRDT_DIV.Size = new System.Drawing.Size(200, 23);
            this.cbo01_PRDT_DIV.TabIndex = 90;
            this.cbo01_PRDT_DIV.SelectedIndexChanged += new System.EventHandler(this.cbo01_PRDT_DIV_SelectedIndexChanged);
            // 
            // lbl01_PRDT_DIV
            // 
            this.lbl01_PRDT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRDT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PRDT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PRDT_DIV.Location = new System.Drawing.Point(14, 121);
            this.lbl01_PRDT_DIV.Name = "lbl01_PRDT_DIV";
            this.lbl01_PRDT_DIV.Size = new System.Drawing.Size(200, 20);
            this.lbl01_PRDT_DIV.TabIndex = 89;
            this.lbl01_PRDT_DIV.Tag = null;
            this.lbl01_PRDT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PRDT_DIV.Value = "제품구분";
            // 
            // chk01_OPTION1_PD40170
            // 
            this.chk01_OPTION1_PD40170.AutoSize = true;
            this.chk01_OPTION1_PD40170.Location = new System.Drawing.Point(14, 177);
            this.chk01_OPTION1_PD40170.Name = "chk01_OPTION1_PD40170";
            this.chk01_OPTION1_PD40170.Size = new System.Drawing.Size(101, 19);
            this.chk01_OPTION1_PD40170.TabIndex = 8;
            this.chk01_OPTION1_PD40170.Text = "시간대별 실적";
            this.chk01_OPTION1_PD40170.UseVisualStyleBackColor = true;
            // 
            // dtp01_BEG_DATE
            // 
            this.dtp01_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_DATE.Location = new System.Drawing.Point(14, 89);
            this.dtp01_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_BEG_DATE.Name = "dtp01_BEG_DATE";
            this.dtp01_BEG_DATE.OriginalFormat = "";
            this.dtp01_BEG_DATE.Size = new System.Drawing.Size(200, 21);
            this.dtp01_BEG_DATE.TabIndex = 5;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(14, 68);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(200, 20);
            this.lbl01_STD_DATE.TabIndex = 4;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_STD_DATE.Value = "기준일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(200, 23);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_PRDT_DIV_SelectedIndexChanged);
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(14, 16);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(200, 20);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // AxDockingTab1
            // 
            this.AxDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.AxDockingTab1.Name = "AxDockingTab1";
            this.AxDockingTab1.PanelHeight = 714;
            this.AxDockingTab1.PanelWidth = 542;
            this.AxDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.AxDockingTab1.TabIndex = 14;
            // 
            // PD40170
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "PD40170";
            this.Load += new System.EventHandler(this.PD40170_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxCheckBox chk01_OPTION1_PD40170;
        private DEV.Utility.Controls.AxDateEdit dtp01_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxDockingTab AxDockingTab1;
        private DEV.Utility.Controls.AxCheckBox chk01_OPTION2_PD40170;
        private DEV.Utility.Controls.AxComboBox cbo01_PRDT_DIV;
        private DEV.Utility.Controls.AxLabel lbl01_PRDT_DIV;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxCodeBox cdx01_ITEMCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_ITEMCD;
        private DEV.Utility.Controls.AxLabel lbl01_INSTALL_POS;
        private DEV.Utility.Controls.AxComboBox cbo01_INSTALL_POS;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
    }
}
