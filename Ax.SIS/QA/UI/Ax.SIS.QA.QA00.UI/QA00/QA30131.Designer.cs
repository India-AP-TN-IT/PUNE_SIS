namespace Ax.SIS.QA.QA00.UI
{
    partial class QA30131
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
            this.grd01_QA30131 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd02_QA30131 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cdx01_INSPECT_CLASSCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_QA_INSPECT_BASECODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_CONV_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_SELECT_GUBN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_INSPECT_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO_PARTNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO_PARTNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_CONV_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_SELECT_GUBN = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_INSPECT_YN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA30131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_INSPECT_CLASSCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA_INSPECT_BASECODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PARTNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CONV_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SELECT_GUBN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_YN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.QueryClick += new System.EventHandler(this.BtnQuery_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA30131);
            this.groupBox3.Controls.Add(this.grd02_QA30131);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 556);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // grd01_QA30131
            // 
            this.grd01_QA30131.AllowHeaderMerging = false;
            this.grd01_QA30131.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA30131.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30131.EnabledActionFlag = true;
            this.grd01_QA30131.LastRowAdd = false;
            this.grd01_QA30131.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30131.Name = "grd01_QA30131";
            this.grd01_QA30131.OriginalFormat = null;
            this.grd01_QA30131.PopMenuVisible = true;
            this.grd01_QA30131.Rows.DefaultSize = 18;
            this.grd01_QA30131.Size = new System.Drawing.Size(269, 536);
            this.grd01_QA30131.TabIndex = 2;
            this.grd01_QA30131.UseCustomHighlight = true;
            // 
            // grd02_QA30131
            // 
            this.grd02_QA30131.AllowHeaderMerging = false;
            this.grd02_QA30131.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd02_QA30131.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02_QA30131.EnabledActionFlag = true;
            this.grd02_QA30131.LastRowAdd = false;
            this.grd02_QA30131.Location = new System.Drawing.Point(3, 17);
            this.grd02_QA30131.Name = "grd02_QA30131";
            this.grd02_QA30131.OriginalFormat = null;
            this.grd02_QA30131.PopMenuVisible = true;
            this.grd02_QA30131.Rows.DefaultSize = 18;
            this.grd02_QA30131.Size = new System.Drawing.Size(269, 536);
            this.grd02_QA30131.TabIndex = 3;
            this.grd02_QA30131.UseCustomHighlight = true;
            this.grd02_QA30131.Visible = false;
            // 
            // cdx01_INSPECT_CLASSCD
            // 
            this.cdx01_INSPECT_CLASSCD.CodeParameterName = "CODE";
            this.cdx01_INSPECT_CLASSCD.CodeTextBoxReadOnly = false;
            this.cdx01_INSPECT_CLASSCD.CodeTextBoxVisible = false;
            this.cdx01_INSPECT_CLASSCD.CodeTextBoxWidth = 40;
            this.cdx01_INSPECT_CLASSCD.HEPopupHelper = null;
            this.cdx01_INSPECT_CLASSCD.Location = new System.Drawing.Point(14, 130);
            this.cdx01_INSPECT_CLASSCD.Name = "cdx01_INSPECT_CLASSCD";
            this.cdx01_INSPECT_CLASSCD.NameParameterName = "NAME";
            this.cdx01_INSPECT_CLASSCD.NameTextBoxReadOnly = false;
            this.cdx01_INSPECT_CLASSCD.NameTextBoxVisible = true;
            this.cdx01_INSPECT_CLASSCD.PopupButtonReadOnly = false;
            this.cdx01_INSPECT_CLASSCD.PopupTitle = "";
            this.cdx01_INSPECT_CLASSCD.PrefixCode = "";
            this.cdx01_INSPECT_CLASSCD.Size = new System.Drawing.Size(249, 21);
            this.cdx01_INSPECT_CLASSCD.TabIndex = 18;
            this.cdx01_INSPECT_CLASSCD.Tag = null;
            // 
            // lbl01_QA_INSPECT_BASECODE
            // 
            this.lbl01_QA_INSPECT_BASECODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA_INSPECT_BASECODE.AutoFontSizeMinValue = 9F;
            this.lbl01_QA_INSPECT_BASECODE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_QA_INSPECT_BASECODE.Location = new System.Drawing.Point(14, 115);
            this.lbl01_QA_INSPECT_BASECODE.Name = "lbl01_QA_INSPECT_BASECODE";
            this.lbl01_QA_INSPECT_BASECODE.Size = new System.Drawing.Size(249, 12);
            this.lbl01_QA_INSPECT_BASECODE.TabIndex = 17;
            this.lbl01_QA_INSPECT_BASECODE.Tag = null;
            this.lbl01_QA_INSPECT_BASECODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_QA_INSPECT_BASECODE.Value = "검사코드";
            // 
            // dte01_CONV_DATE
            // 
            this.dte01_CONV_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_CONV_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_CONV_DATE.Location = new System.Drawing.Point(14, 272);
            this.dte01_CONV_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_CONV_DATE.Name = "dte01_CONV_DATE";
            this.dte01_CONV_DATE.OriginalFormat = "";
            this.dte01_CONV_DATE.Size = new System.Drawing.Size(249, 21);
            this.dte01_CONV_DATE.TabIndex = 16;
            // 
            // cbo01_SELECT_GUBN
            // 
            this.cbo01_SELECT_GUBN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SELECT_GUBN.FormattingEnabled = true;
            this.cbo01_SELECT_GUBN.Location = new System.Drawing.Point(14, 225);
            this.cbo01_SELECT_GUBN.Name = "cbo01_SELECT_GUBN";
            this.cbo01_SELECT_GUBN.Size = new System.Drawing.Size(249, 20);
            this.cbo01_SELECT_GUBN.TabIndex = 15;
            this.cbo01_SELECT_GUBN.SelectedIndexChanged += new System.EventHandler(this.cbo01_SELECT_GUBN_SelectedIndexChanged);
            // 
            // cbo01_INSPECT_YN
            // 
            this.cbo01_INSPECT_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INSPECT_YN.FormattingEnabled = true;
            this.cbo01_INSPECT_YN.Location = new System.Drawing.Point(14, 178);
            this.cbo01_INSPECT_YN.Name = "cbo01_INSPECT_YN";
            this.cbo01_INSPECT_YN.Size = new System.Drawing.Size(249, 20);
            this.cbo01_INSPECT_YN.TabIndex = 14;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = false;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(14, 82);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(249, 21);
            this.cdx01_VINCD.TabIndex = 13;
            this.cdx01_VINCD.Tag = null;
            this.cdx01_VINCD.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_VINCD_ButtonClickAfter);
            this.cdx01_VINCD.CodeBoxBindingAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_VINCD_CodeBoxBindingAfter);
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VINCD.Location = new System.Drawing.Point(14, 67);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(249, 12);
            this.lbl01_VINCD.TabIndex = 12;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VINCD.Value = "차종";
            // 
            // txt01_PARTNO_PARTNM
            // 
            this.txt01_PARTNO_PARTNM.Location = new System.Drawing.Point(14, 320);
            this.txt01_PARTNO_PARTNM.Name = "txt01_PARTNO_PARTNM";
            this.txt01_PARTNO_PARTNM.Size = new System.Drawing.Size(249, 21);
            this.txt01_PARTNO_PARTNM.TabIndex = 11;
            this.txt01_PARTNO_PARTNM.Tag = null;
            // 
            // lbl01_PARTNO_PARTNM
            // 
            this.lbl01_PARTNO_PARTNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO_PARTNM.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO_PARTNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PARTNO_PARTNM.Location = new System.Drawing.Point(14, 305);
            this.lbl01_PARTNO_PARTNM.Name = "lbl01_PARTNO_PARTNM";
            this.lbl01_PARTNO_PARTNM.Size = new System.Drawing.Size(249, 12);
            this.lbl01_PARTNO_PARTNM.TabIndex = 10;
            this.lbl01_PARTNO_PARTNM.Tag = null;
            this.lbl01_PARTNO_PARTNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO_PARTNM.Value = "품번/품명";
            // 
            // lbl01_CONV_DATE
            // 
            this.lbl01_CONV_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CONV_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_CONV_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_CONV_DATE.Location = new System.Drawing.Point(14, 257);
            this.lbl01_CONV_DATE.Name = "lbl01_CONV_DATE";
            this.lbl01_CONV_DATE.Size = new System.Drawing.Size(249, 12);
            this.lbl01_CONV_DATE.TabIndex = 6;
            this.lbl01_CONV_DATE.Tag = null;
            this.lbl01_CONV_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_CONV_DATE.Value = "전환일자";
            // 
            // lbl01_SELECT_GUBN
            // 
            this.lbl01_SELECT_GUBN.AutoFontSizeMaxValue = 9F;
            this.lbl01_SELECT_GUBN.AutoFontSizeMinValue = 9F;
            this.lbl01_SELECT_GUBN.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SELECT_GUBN.Location = new System.Drawing.Point(14, 210);
            this.lbl01_SELECT_GUBN.Name = "lbl01_SELECT_GUBN";
            this.lbl01_SELECT_GUBN.Size = new System.Drawing.Size(249, 12);
            this.lbl01_SELECT_GUBN.TabIndex = 4;
            this.lbl01_SELECT_GUBN.Tag = null;
            this.lbl01_SELECT_GUBN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_SELECT_GUBN.Value = "조회형태";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 35);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(249, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_INSPECT_YN
            // 
            this.lbl01_INSPECT_YN.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPECT_YN.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPECT_YN.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_INSPECT_YN.Location = new System.Drawing.Point(14, 163);
            this.lbl01_INSPECT_YN.Name = "lbl01_INSPECT_YN";
            this.lbl01_INSPECT_YN.Size = new System.Drawing.Size(249, 12);
            this.lbl01_INSPECT_YN.TabIndex = 2;
            this.lbl01_INSPECT_YN.Tag = null;
            this.lbl01_INSPECT_YN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_INSPECT_YN.Value = "검사여부";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(14, 20);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(249, 12);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.txt01_PARTNO_PARTNM);
            this.panel1.Controls.Add(this.dte01_CONV_DATE);
            this.panel1.Controls.Add(this.lbl01_PARTNO_PARTNM);
            this.panel1.Controls.Add(this.cdx01_INSPECT_CLASSCD);
            this.panel1.Controls.Add(this.cbo01_SELECT_GUBN);
            this.panel1.Controls.Add(this.lbl01_CONV_DATE);
            this.panel1.Controls.Add(this.cbo01_INSPECT_YN);
            this.panel1.Controls.Add(this.lbl01_QA_INSPECT_BASECODE);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_SELECT_GUBN);
            this.panel1.Controls.Add(this.lbl01_VINCD);
            this.panel1.Controls.Add(this.cdx01_VINCD);
            this.panel1.Controls.Add(this.lbl01_INSPECT_YN);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Location = new System.Drawing.Point(21, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 556);
            this.panel1.TabIndex = 12;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 353);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(249, 12);
            this.lbl01_PLANT_DIV.TabIndex = 20;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(14, 368);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(249, 20);
            this.cbo01_PLANT_DIV.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(302, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 556);
            this.panel2.TabIndex = 13;
            // 
            // QA30131
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30131";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA30131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_INSPECT_CLASSCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA_INSPECT_BASECODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO_PARTNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PARTNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CONV_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SELECT_GUBN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_YN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30131;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO_PARTNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO_PARTNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CONV_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SELECT_GUBN;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPECT_YN;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_INSPECT_CLASSCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA_INSPECT_BASECODE;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_CONV_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SELECT_GUBN;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_INSPECT_YN;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02_QA30131;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
