namespace Ax.SIS.WM.UI
{
    partial class WM20513
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_Detail = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rd_Summary = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.dtp01_WORK_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_MAT_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_MAT_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DOM_IMP_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_DOM_IMP_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_WORK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAT_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOM_IMP_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DATE)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 28);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 740);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.lbl01_VENDCD);
            this.panel2.Controls.Add(this.cdx01_VENDCD);
            this.panel2.Controls.Add(this.dtp01_WORK_DATE);
            this.panel2.Controls.Add(this.cbo01_MAT_TYPE);
            this.panel2.Controls.Add(this.lbl01_MAT_TYPE);
            this.panel2.Controls.Add(this.lbl01_DOM_IMP_DIV);
            this.panel2.Controls.Add(this.cbo01_DOM_IMP_DIV);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_BIZCD);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_WORK_DATE);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_Detail);
            this.groupBox1.Controls.Add(this.rd_Summary);
            this.groupBox1.Location = new System.Drawing.Point(7, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 51);
            this.groupBox1.TabIndex = 145;
            this.groupBox1.TabStop = false;
            // 
            // rd_Detail
            // 
            this.rd_Detail.AutoSize = true;
            this.rd_Detail.Location = new System.Drawing.Point(129, 21);
            this.rd_Detail.Name = "rd_Detail";
            this.rd_Detail.Size = new System.Drawing.Size(54, 16);
            this.rd_Detail.TabIndex = 144;
            this.rd_Detail.Text = "Detail";
            this.rd_Detail.UseVisualStyleBackColor = true;
            // 
            // rd_Summary
            // 
            this.rd_Summary.AutoSize = true;
            this.rd_Summary.Checked = true;
            this.rd_Summary.Location = new System.Drawing.Point(16, 21);
            this.rd_Summary.Name = "rd_Summary";
            this.rd_Summary.Size = new System.Drawing.Size(78, 16);
            this.rd_Summary.TabIndex = 143;
            this.rd_Summary.TabStop = true;
            this.rd_Summary.Text = "Summary";
            this.rd_Summary.UseVisualStyleBackColor = true;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_VENDCD.Location = new System.Drawing.Point(6, 169);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(260, 21);
            this.lbl01_VENDCD.TabIndex = 144;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VENDCD.Value = "업체명";
            this.lbl01_VENDCD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(7, 195);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(258, 21);
            this.cdx01_VENDCD.TabIndex = 143;
            this.cdx01_VENDCD.Tag = null;
            // 
            // dtp01_WORK_DATE
            // 
            this.dtp01_WORK_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_WORK_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_WORK_DATE.Location = new System.Drawing.Point(7, 80);
            this.dtp01_WORK_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_WORK_DATE.Name = "dtp01_WORK_DATE";
            this.dtp01_WORK_DATE.OriginalFormat = "";
            this.dtp01_WORK_DATE.Size = new System.Drawing.Size(112, 21);
            this.dtp01_WORK_DATE.TabIndex = 140;
            // 
            // cbo01_MAT_TYPE
            // 
            this.cbo01_MAT_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_MAT_TYPE.FormattingEnabled = true;
            this.cbo01_MAT_TYPE.Location = new System.Drawing.Point(6, 292);
            this.cbo01_MAT_TYPE.Name = "cbo01_MAT_TYPE";
            this.cbo01_MAT_TYPE.Size = new System.Drawing.Size(257, 20);
            this.cbo01_MAT_TYPE.TabIndex = 139;
            // 
            // lbl01_MAT_TYPE
            // 
            this.lbl01_MAT_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_MAT_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_MAT_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MAT_TYPE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_MAT_TYPE.Location = new System.Drawing.Point(7, 271);
            this.lbl01_MAT_TYPE.Name = "lbl01_MAT_TYPE";
            this.lbl01_MAT_TYPE.Size = new System.Drawing.Size(256, 21);
            this.lbl01_MAT_TYPE.TabIndex = 138;
            this.lbl01_MAT_TYPE.Tag = null;
            this.lbl01_MAT_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_MAT_TYPE.Value = "자재유형";
            this.lbl01_MAT_TYPE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // lbl01_DOM_IMP_DIV
            // 
            this.lbl01_DOM_IMP_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_DOM_IMP_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_DOM_IMP_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DOM_IMP_DIV.Location = new System.Drawing.Point(5, 224);
            this.lbl01_DOM_IMP_DIV.Name = "lbl01_DOM_IMP_DIV";
            this.lbl01_DOM_IMP_DIV.Size = new System.Drawing.Size(259, 21);
            this.lbl01_DOM_IMP_DIV.TabIndex = 137;
            this.lbl01_DOM_IMP_DIV.Tag = null;
            this.lbl01_DOM_IMP_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DOM_IMP_DIV.Value = "_공장구분";
            // 
            // cbo01_DOM_IMP_DIV
            // 
            this.cbo01_DOM_IMP_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DOM_IMP_DIV.FormattingEnabled = true;
            this.cbo01_DOM_IMP_DIV.Location = new System.Drawing.Point(5, 245);
            this.cbo01_DOM_IMP_DIV.Name = "cbo01_DOM_IMP_DIV";
            this.cbo01_DOM_IMP_DIV.Size = new System.Drawing.Size(259, 20);
            this.cbo01_DOM_IMP_DIV.TabIndex = 136;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(5, 343);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_PARTNO.TabIndex = 125;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(5, 319);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.lbl01_PARTNO.TabIndex = 124;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "PART NO";
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(5, 6);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(261, 23);
            this.lbl01_BIZCD.TabIndex = 113;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZCD.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(5, 32);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(261, 20);
            this.cbo01_BIZCD.TabIndex = 112;
            // 
            // lbl01_WORK_DATE
            // 
            this.lbl01_WORK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_WORK_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WORK_DATE.Location = new System.Drawing.Point(5, 57);
            this.lbl01_WORK_DATE.Name = "lbl01_WORK_DATE";
            this.lbl01_WORK_DATE.Size = new System.Drawing.Size(261, 20);
            this.lbl01_WORK_DATE.TabIndex = 106;
            this.lbl01_WORK_DATE.Tag = null;
            this.lbl01_WORK_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_WORK_DATE.Value = "제품구분";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 740;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 740);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 3;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 736);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            // 
            // WM20513
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "WM20513";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAT_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOM_IMP_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DATE)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_WORK_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_MAT_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MAT_TYPE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_WORK_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DOM_IMP_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_DOM_IMP_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxRadioButton rd_Detail;
        private Ax.DEV.Utility.Controls.AxRadioButton rd_Summary;
    }
}
