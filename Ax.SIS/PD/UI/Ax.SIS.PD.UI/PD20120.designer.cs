namespace Ax.SIS.PD.UI
{
    partial class PD20120
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
            this.lbl01_PARTNO_PER = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo01_OUT_DIRECT_DATE = new System.Windows.Forms.RadioButton();
            this.rdo01_OUT_DATE = new System.Windows.Forms.RadioButton();
            this.chk01_RESULT_INFO_SEARCH = new System.Windows.Forms.CheckBox();
            this.lbl01_OUTNO_PER = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_OUTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl03_Wave = new System.Windows.Forms.Label();
            this.dtp01_TO_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_FROM_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.AxDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.lbl01_ALCCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ITEMCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_ITEMCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chk01_SAP_YN = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OUTNO_PER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_OUTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ITEMCD)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl01_PARTNO_PER
            // 
            this.lbl01_PARTNO_PER.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO_PER.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO_PER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO_PER.Location = new System.Drawing.Point(12, 171);
            this.lbl01_PARTNO_PER.Name = "lbl01_PARTNO_PER";
            this.lbl01_PARTNO_PER.Size = new System.Drawing.Size(227, 20);
            this.lbl01_PARTNO_PER.TabIndex = 45;
            this.lbl01_PARTNO_PER.Tag = null;
            this.lbl01_PARTNO_PER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO_PER.Value = "Part No (%)";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(12, 192);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(227, 21);
            this.txt01_PARTNO.TabIndex = 7;
            this.txt01_PARTNO.Tag = null;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.AxDockingTab1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 734);
            this.groupBox3.TabIndex = 10;
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
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(354, 263);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.SetupEditor += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_SetupEditor);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdo01_OUT_DIRECT_DATE);
            this.panel1.Controls.Add(this.rdo01_OUT_DATE);
            this.panel1.Controls.Add(this.chk01_RESULT_INFO_SEARCH);
            this.panel1.Controls.Add(this.lbl01_OUTNO_PER);
            this.panel1.Controls.Add(this.txt01_OUTNO);
            this.panel1.Controls.Add(this.lbl03_Wave);
            this.panel1.Controls.Add(this.dtp01_TO_DATE);
            this.panel1.Controls.Add(this.dtp01_FROM_DATE);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_PARTNO_PER);
            this.panel1.Controls.Add(this.txt01_PARTNO);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 486);
            this.panel1.TabIndex = 12;
            // 
            // rdo01_OUT_DIRECT_DATE
            // 
            this.rdo01_OUT_DIRECT_DATE.AutoSize = true;
            this.rdo01_OUT_DIRECT_DATE.Checked = true;
            this.rdo01_OUT_DIRECT_DATE.Location = new System.Drawing.Point(13, 62);
            this.rdo01_OUT_DIRECT_DATE.Name = "rdo01_OUT_DIRECT_DATE";
            this.rdo01_OUT_DIRECT_DATE.Size = new System.Drawing.Size(95, 16);
            this.rdo01_OUT_DIRECT_DATE.TabIndex = 128;
            this.rdo01_OUT_DIRECT_DATE.TabStop = true;
            this.rdo01_OUT_DIRECT_DATE.Tag = "";
            this.rdo01_OUT_DIRECT_DATE.Text = "출하지시일자";
            this.rdo01_OUT_DIRECT_DATE.UseVisualStyleBackColor = true;
            // 
            // rdo01_OUT_DATE
            // 
            this.rdo01_OUT_DATE.AutoSize = true;
            this.rdo01_OUT_DATE.Location = new System.Drawing.Point(13, 80);
            this.rdo01_OUT_DATE.Name = "rdo01_OUT_DATE";
            this.rdo01_OUT_DATE.Size = new System.Drawing.Size(71, 16);
            this.rdo01_OUT_DATE.TabIndex = 127;
            this.rdo01_OUT_DATE.Tag = "";
            this.rdo01_OUT_DATE.Text = "출고일자";
            this.rdo01_OUT_DATE.UseVisualStyleBackColor = true;
            // 
            // chk01_RESULT_INFO_SEARCH
            // 
            this.chk01_RESULT_INFO_SEARCH.Location = new System.Drawing.Point(12, 219);
            this.chk01_RESULT_INFO_SEARCH.Name = "chk01_RESULT_INFO_SEARCH";
            this.chk01_RESULT_INFO_SEARCH.Size = new System.Drawing.Size(206, 19);
            this.chk01_RESULT_INFO_SEARCH.TabIndex = 15;
            this.chk01_RESULT_INFO_SEARCH.Text = "실적 정보 조회";
            this.chk01_RESULT_INFO_SEARCH.UseVisualStyleBackColor = true;
            // 
            // lbl01_OUTNO_PER
            // 
            this.lbl01_OUTNO_PER.AutoFontSizeMaxValue = 9F;
            this.lbl01_OUTNO_PER.AutoFontSizeMinValue = 9F;
            this.lbl01_OUTNO_PER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_OUTNO_PER.Location = new System.Drawing.Point(12, 124);
            this.lbl01_OUTNO_PER.Name = "lbl01_OUTNO_PER";
            this.lbl01_OUTNO_PER.Size = new System.Drawing.Size(226, 20);
            this.lbl01_OUTNO_PER.TabIndex = 126;
            this.lbl01_OUTNO_PER.Tag = null;
            this.lbl01_OUTNO_PER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_OUTNO_PER.Value = "출하번호(%)";
            // 
            // txt01_OUTNO
            // 
            this.txt01_OUTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_OUTNO.Location = new System.Drawing.Point(12, 145);
            this.txt01_OUTNO.Name = "txt01_OUTNO";
            this.txt01_OUTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_OUTNO.TabIndex = 125;
            this.txt01_OUTNO.Tag = null;
            // 
            // lbl03_Wave
            // 
            this.lbl03_Wave.AutoSize = true;
            this.lbl03_Wave.Location = new System.Drawing.Point(119, 102);
            this.lbl03_Wave.Name = "lbl03_Wave";
            this.lbl03_Wave.Size = new System.Drawing.Size(14, 12);
            this.lbl03_Wave.TabIndex = 86;
            this.lbl03_Wave.Text = "~";
            // 
            // dtp01_TO_DATE
            // 
            this.dtp01_TO_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_TO_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_TO_DATE.Location = new System.Drawing.Point(139, 98);
            this.dtp01_TO_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_TO_DATE.Name = "dtp01_TO_DATE";
            this.dtp01_TO_DATE.OriginalFormat = "";
            this.dtp01_TO_DATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_TO_DATE.TabIndex = 85;
            // 
            // dtp01_FROM_DATE
            // 
            this.dtp01_FROM_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_FROM_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_FROM_DATE.Location = new System.Drawing.Point(13, 98);
            this.dtp01_FROM_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_FROM_DATE.Name = "dtp01_FROM_DATE";
            this.dtp01_FROM_DATE.OriginalFormat = "";
            this.dtp01_FROM_DATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_FROM_DATE.TabIndex = 84;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(12, 15);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(227, 20);
            this.lbl01_BIZNM.TabIndex = 61;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(11, 36);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(227, 20);
            this.cbo01_BIZCD.TabIndex = 62;
            // 
            // AxDockingTab1
            // 
            this.AxDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.AxDockingTab1.Name = "AxDockingTab1";
            this.AxDockingTab1.PanelHeight = 714;
            this.AxDockingTab1.PanelWidth = 377;
            this.AxDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.AxDockingTab1.TabIndex = 13;
            // 
            // lbl01_ALCCD
            // 
            this.lbl01_ALCCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ALCCD.AutoFontSizeMinValue = 9F;
            this.lbl01_ALCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ALCCD.Location = new System.Drawing.Point(13, 115);
            this.lbl01_ALCCD.Name = "lbl01_ALCCD";
            this.lbl01_ALCCD.Size = new System.Drawing.Size(226, 20);
            this.lbl01_ALCCD.TabIndex = 60;
            this.lbl01_ALCCD.Tag = null;
            this.lbl01_ALCCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ALCCD.Value = "ALC";
            // 
            // lbl01_PRDT_DIV
            // 
            this.lbl01_PRDT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRDT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PRDT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRDT_DIV.Location = new System.Drawing.Point(11, 114);
            this.lbl01_PRDT_DIV.Name = "lbl01_PRDT_DIV";
            this.lbl01_PRDT_DIV.Size = new System.Drawing.Size(227, 20);
            this.lbl01_PRDT_DIV.TabIndex = 56;
            this.lbl01_PRDT_DIV.Tag = null;
            this.lbl01_PRDT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PRDT_DIV.Value = "제품구분";
            // 
            // lbl01_ITEMCD
            // 
            this.lbl01_ITEMCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ITEMCD.AutoFontSizeMinValue = 9F;
            this.lbl01_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ITEMCD.Location = new System.Drawing.Point(12, 303);
            this.lbl01_ITEMCD.Name = "lbl01_ITEMCD";
            this.lbl01_ITEMCD.Size = new System.Drawing.Size(200, 20);
            this.lbl01_ITEMCD.TabIndex = 47;
            this.lbl01_ITEMCD.Tag = null;
            this.lbl01_ITEMCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ITEMCD.Value = "품목";
            // 
            // cdx01_ITEMCD
            // 
            this.cdx01_ITEMCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_ITEMCD.CodeParameterName = "CODE";
            this.cdx01_ITEMCD.CodeTextBoxReadOnly = false;
            this.cdx01_ITEMCD.CodeTextBoxVisible = true;
            this.cdx01_ITEMCD.CodeTextBoxWidth = 40;
            this.cdx01_ITEMCD.HEPopupHelper = null;
            this.cdx01_ITEMCD.Location = new System.Drawing.Point(12, 324);
            this.cdx01_ITEMCD.Name = "cdx01_ITEMCD";
            this.cdx01_ITEMCD.NameParameterName = "NAME";
            this.cdx01_ITEMCD.NameTextBoxReadOnly = false;
            this.cdx01_ITEMCD.NameTextBoxVisible = true;
            this.cdx01_ITEMCD.PopupButtonReadOnly = false;
            this.cdx01_ITEMCD.PopupTitle = "";
            this.cdx01_ITEMCD.PrefixCode = "";
            this.cdx01_ITEMCD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_ITEMCD.TabIndex = 69;
            this.cdx01_ITEMCD.Tag = null;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(15, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(206, 36);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "SAP 출고구분\r\n(O1, O3, O4, O6)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chk01_SAP_YN
            // 
            this.chk01_SAP_YN.Location = new System.Drawing.Point(15, 12);
            this.chk01_SAP_YN.Name = "chk01_SAP_YN";
            this.chk01_SAP_YN.Size = new System.Drawing.Size(206, 36);
            this.chk01_SAP_YN.TabIndex = 15;
            this.chk01_SAP_YN.Text = "SAP 출고구분\r\n(O1, O3, O4, O6)";
            this.chk01_SAP_YN.UseVisualStyleBackColor = true;
            // 
            // PD20120
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Name = "PD20120";
            this.Load += new System.EventHandler(this.PD20120_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO_PER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OUTNO_PER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_OUTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ITEMCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_PARTNO_PER;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private System.Windows.Forms.GroupBox groupBox3;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxDockingTab AxDockingTab1;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private System.Windows.Forms.Label lbl03_Wave;
        private DEV.Utility.Controls.AxDateEdit dtp01_TO_DATE;
        private DEV.Utility.Controls.AxDateEdit dtp01_FROM_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_ALCCD;
        private DEV.Utility.Controls.AxLabel lbl01_PRDT_DIV;
        private DEV.Utility.Controls.AxLabel lbl01_ITEMCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_ITEMCD;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chk01_SAP_YN;
        private DEV.Utility.Controls.AxLabel lbl01_OUTNO_PER;
        private DEV.Utility.Controls.AxTextBox txt01_OUTNO;
        private System.Windows.Forms.CheckBox chk01_RESULT_INFO_SEARCH;
        private System.Windows.Forms.RadioButton rdo01_OUT_DIRECT_DATE;
        private System.Windows.Forms.RadioButton rdo01_OUT_DATE;
    }
}
