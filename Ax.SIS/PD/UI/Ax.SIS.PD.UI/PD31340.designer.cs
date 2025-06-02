namespace Ax.SIS.PD.UI
{
    partial class PD31340
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD31340));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk01_PROD_PLAN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo01_CRT_DATE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PD31340_RANGE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PD31340_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_PD31340_OPTION1 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.dtp01_PLAN_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PD31340_RANGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PD31340_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.axDockingTab1);
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
            this.panel1.Controls.Add(this.chk01_PROD_PLAN);
            this.panel1.Controls.Add(this.cbo01_CRT_DATE);
            this.panel1.Controls.Add(this.lbl01_PD31340_RANGE);
            this.panel1.Controls.Add(this.cdx01_LINECD);
            this.panel1.Controls.Add(this.cdx01_VINCD);
            this.panel1.Controls.Add(this.lbl01_VIN);
            this.panel1.Controls.Add(this.lbl01_PD31340_LINE);
            this.panel1.Controls.Add(this.chk01_PD31340_OPTION1);
            this.panel1.Controls.Add(this.dtp01_PLAN_DATE);
            this.panel1.Controls.Add(this.lbl01_STD_DATE);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 714);
            this.panel1.TabIndex = 13;
            // 
            // chk01_PROD_PLAN
            // 
            this.chk01_PROD_PLAN.AutoSize = true;
            this.chk01_PROD_PLAN.Location = new System.Drawing.Point(13, 277);
            this.chk01_PROD_PLAN.Name = "chk01_PROD_PLAN";
            this.chk01_PROD_PLAN.Size = new System.Drawing.Size(77, 19);
            this.chk01_PROD_PLAN.TabIndex = 102;
            this.chk01_PROD_PLAN.Text = "생산 계획";
            this.chk01_PROD_PLAN.UseVisualStyleBackColor = true;
            // 
            // cbo01_CRT_DATE
            // 
            this.cbo01_CRT_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo01_CRT_DATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CRT_DATE.FormattingEnabled = true;
            this.cbo01_CRT_DATE.Location = new System.Drawing.Point(13, 225);
            this.cbo01_CRT_DATE.Name = "cbo01_CRT_DATE";
            this.cbo01_CRT_DATE.Size = new System.Drawing.Size(200, 23);
            this.cbo01_CRT_DATE.TabIndex = 101;
            // 
            // lbl01_PD31340_RANGE
            // 
            this.lbl01_PD31340_RANGE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PD31340_RANGE.AutoFontSizeMinValue = 9F;
            this.lbl01_PD31340_RANGE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PD31340_RANGE.Location = new System.Drawing.Point(13, 210);
            this.lbl01_PD31340_RANGE.Name = "lbl01_PD31340_RANGE";
            this.lbl01_PD31340_RANGE.Size = new System.Drawing.Size(200, 12);
            this.lbl01_PD31340_RANGE.TabIndex = 100;
            this.lbl01_PD31340_RANGE.Tag = null;
            this.lbl01_PD31340_RANGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PD31340_RANGE.Value = "과부족구간";
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(13, 127);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_LINECD.TabIndex = 97;
            this.cdx01_LINECD.Tag = null;
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
            this.cdx01_VINCD.Location = new System.Drawing.Point(13, 176);
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
            // lbl01_VIN
            // 
            this.lbl01_VIN.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIN.AutoFontSizeMinValue = 9F;
            this.lbl01_VIN.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VIN.Location = new System.Drawing.Point(13, 161);
            this.lbl01_VIN.Name = "lbl01_VIN";
            this.lbl01_VIN.Size = new System.Drawing.Size(200, 12);
            this.lbl01_VIN.TabIndex = 95;
            this.lbl01_VIN.Tag = null;
            this.lbl01_VIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VIN.Value = "차종";
            // 
            // lbl01_PD31340_LINE
            // 
            this.lbl01_PD31340_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PD31340_LINE.AutoFontSizeMinValue = 9F;
            this.lbl01_PD31340_LINE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PD31340_LINE.Location = new System.Drawing.Point(13, 112);
            this.lbl01_PD31340_LINE.Name = "lbl01_PD31340_LINE";
            this.lbl01_PD31340_LINE.Size = new System.Drawing.Size(200, 12);
            this.lbl01_PD31340_LINE.TabIndex = 92;
            this.lbl01_PD31340_LINE.Tag = null;
            this.lbl01_PD31340_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PD31340_LINE.Value = "대상 LINE";
            // 
            // chk01_PD31340_OPTION1
            // 
            this.chk01_PD31340_OPTION1.AutoSize = true;
            this.chk01_PD31340_OPTION1.Location = new System.Drawing.Point(13, 255);
            this.chk01_PD31340_OPTION1.Name = "chk01_PD31340_OPTION1";
            this.chk01_PD31340_OPTION1.Size = new System.Drawing.Size(106, 19);
            this.chk01_PD31340_OPTION1.TabIndex = 8;
            this.chk01_PD31340_OPTION1.Text = "D+2~D+3 계획";
            this.chk01_PD31340_OPTION1.UseVisualStyleBackColor = true;
            // 
            // dtp01_PLAN_DATE
            // 
            this.dtp01_PLAN_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp01_PLAN_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_PLAN_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_PLAN_DATE.Location = new System.Drawing.Point(13, 78);
            this.dtp01_PLAN_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_PLAN_DATE.Name = "dtp01_PLAN_DATE";
            this.dtp01_PLAN_DATE.OriginalFormat = "";
            this.dtp01_PLAN_DATE.Size = new System.Drawing.Size(200, 21);
            this.dtp01_PLAN_DATE.TabIndex = 5;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(13, 63);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(200, 12);
            this.lbl01_STD_DATE.TabIndex = 4;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_STD_DATE.Value = "기준일자";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 30);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(200, 23);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 15);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(200, 12);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // axDockingTab1
            // 
            this.axDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.axDockingTab1.Name = "axDockingTab1";
            this.axDockingTab1.PanelHeight = 714;
            this.axDockingTab1.PanelWidth = 426;
            this.axDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.axDockingTab1.TabIndex = 14;
            // 
            // PD31340
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "PD31340";
            this.Load += new System.EventHandler(this.PD31340_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PD31340_RANGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PD31340_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxDockingTab axDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_VIN;
        private DEV.Utility.Controls.AxLabel lbl01_PD31340_LINE;
        private DEV.Utility.Controls.AxCheckBox chk01_PD31340_OPTION1;
        private DEV.Utility.Controls.AxDateEdit dtp01_PLAN_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_CRT_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_PD31340_RANGE;
        private DEV.Utility.Controls.AxCheckBox chk01_PROD_PLAN;
    }
}
