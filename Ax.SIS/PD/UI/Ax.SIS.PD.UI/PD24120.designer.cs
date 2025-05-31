namespace Ax.SIS.PD.UI
{
    partial class PD24120
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cdx01_STR_LOC = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_STR_LOC = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LOT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk01_SAP_YN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.rdo01_PD24120_RDO1 = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.txt01_ALCCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_ALCCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LOTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_LOTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_POSTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_STR_LOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOT_DIV)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ALCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_POSTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cdx01_STR_LOC);
            this.groupBox1.Controls.Add(this.lbl01_STR_LOC);
            this.groupBox1.Controls.Add(this.lbl01_LOT_DIV);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txt01_ALCCD);
            this.groupBox1.Controls.Add(this.lbl01_ALCCD);
            this.groupBox1.Controls.Add(this.txt01_LOTNO);
            this.groupBox1.Controls.Add(this.lbl01_LOTNO);
            this.groupBox1.Controls.Add(this.cbo01_INSTALL_POS);
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_POSTITLE);
            this.groupBox1.Controls.Add(this.lbl01_LINECD);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 92);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // cdx01_STR_LOC
            // 
            this.cdx01_STR_LOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_STR_LOC.CodeParameterName = "CODE";
            this.cdx01_STR_LOC.CodeTextBoxReadOnly = false;
            this.cdx01_STR_LOC.CodeTextBoxVisible = true;
            this.cdx01_STR_LOC.CodeTextBoxWidth = 50;
            this.cdx01_STR_LOC.HEPopupHelper = null;
            this.cdx01_STR_LOC.Location = new System.Drawing.Point(820, 40);
            this.cdx01_STR_LOC.Name = "cdx01_STR_LOC";
            this.cdx01_STR_LOC.NameParameterName = "NAME";
            this.cdx01_STR_LOC.NameTextBoxReadOnly = false;
            this.cdx01_STR_LOC.NameTextBoxVisible = true;
            this.cdx01_STR_LOC.PopupButtonReadOnly = false;
            this.cdx01_STR_LOC.PopupTitle = "";
            this.cdx01_STR_LOC.PrefixCode = "";
            this.cdx01_STR_LOC.Size = new System.Drawing.Size(233, 21);
            this.cdx01_STR_LOC.TabIndex = 90;
            this.cdx01_STR_LOC.Tag = null;
            this.cdx01_STR_LOC.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_STR_LOC_ButtonClickBefore);
            // 
            // lbl01_STR_LOC
            // 
            this.lbl01_STR_LOC.AutoFontSizeMaxValue = 9F;
            this.lbl01_STR_LOC.AutoFontSizeMinValue = 9F;
            this.lbl01_STR_LOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STR_LOC.Location = new System.Drawing.Point(714, 40);
            this.lbl01_STR_LOC.Name = "lbl01_STR_LOC";
            this.lbl01_STR_LOC.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STR_LOC.TabIndex = 89;
            this.lbl01_STR_LOC.Tag = null;
            this.lbl01_STR_LOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STR_LOC.Value = "품번";
            // 
            // lbl01_LOT_DIV
            // 
            this.lbl01_LOT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_LOT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LOT_DIV.Location = new System.Drawing.Point(6, 65);
            this.lbl01_LOT_DIV.Name = "lbl01_LOT_DIV";
            this.lbl01_LOT_DIV.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LOT_DIV.TabIndex = 88;
            this.lbl01_LOT_DIV.Tag = null;
            this.lbl01_LOT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LOT_DIV.Value = "LOT처리 구분";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk01_SAP_YN);
            this.panel1.Controls.Add(this.rdo01_PD24120_RDO1);
            this.panel1.Location = new System.Drawing.Point(112, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 20);
            this.panel1.TabIndex = 87;
            // 
            // chk01_SAP_YN
            // 
            this.chk01_SAP_YN.AutoSize = true;
            this.chk01_SAP_YN.Location = new System.Drawing.Point(250, 3);
            this.chk01_SAP_YN.Name = "chk01_SAP_YN";
            this.chk01_SAP_YN.Size = new System.Drawing.Size(104, 16);
            this.chk01_SAP_YN.TabIndex = 87;
            this.chk01_SAP_YN.Text = "SAP 처리 여부";
            this.chk01_SAP_YN.UseVisualStyleBackColor = true;
            // 
            // rdo01_PD24120_RDO1
            // 
            this.rdo01_PD24120_RDO1.AutoSize = true;
            this.rdo01_PD24120_RDO1.Location = new System.Drawing.Point(3, 3);
            this.rdo01_PD24120_RDO1.Name = "rdo01_PD24120_RDO1";
            this.rdo01_PD24120_RDO1.Size = new System.Drawing.Size(107, 16);
            this.rdo01_PD24120_RDO1.TabIndex = 86;
            this.rdo01_PD24120_RDO1.Text = "재고손망실처리";
            this.rdo01_PD24120_RDO1.UseVisualStyleBackColor = true;
            // 
            // txt01_ALCCD
            // 
            this.txt01_ALCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_ALCCD.Location = new System.Drawing.Point(608, 41);
            this.txt01_ALCCD.Name = "txt01_ALCCD";
            this.txt01_ALCCD.Size = new System.Drawing.Size(100, 21);
            this.txt01_ALCCD.TabIndex = 21;
            this.txt01_ALCCD.Tag = null;
            // 
            // lbl01_ALCCD
            // 
            this.lbl01_ALCCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ALCCD.AutoFontSizeMinValue = 9F;
            this.lbl01_ALCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ALCCD.Location = new System.Drawing.Point(502, 40);
            this.lbl01_ALCCD.Name = "lbl01_ALCCD";
            this.lbl01_ALCCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_ALCCD.TabIndex = 20;
            this.lbl01_ALCCD.Tag = null;
            this.lbl01_ALCCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ALCCD.Value = "ALC";
            // 
            // txt01_LOTNO
            // 
            this.txt01_LOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_LOTNO.Location = new System.Drawing.Point(354, 41);
            this.txt01_LOTNO.Name = "txt01_LOTNO";
            this.txt01_LOTNO.Size = new System.Drawing.Size(142, 21);
            this.txt01_LOTNO.TabIndex = 19;
            this.txt01_LOTNO.Tag = null;
            // 
            // lbl01_LOTNO
            // 
            this.lbl01_LOTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_LOTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LOTNO.Location = new System.Drawing.Point(248, 40);
            this.lbl01_LOTNO.Name = "lbl01_LOTNO";
            this.lbl01_LOTNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LOTNO.TabIndex = 18;
            this.lbl01_LOTNO.Tag = null;
            this.lbl01_LOTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LOTNO.Value = "LOTNO";
            // 
            // cbo01_INSTALL_POS
            // 
            this.cbo01_INSTALL_POS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INSTALL_POS.FormattingEnabled = true;
            this.cbo01_INSTALL_POS.Location = new System.Drawing.Point(112, 40);
            this.cbo01_INSTALL_POS.Name = "cbo01_INSTALL_POS";
            this.cbo01_INSTALL_POS.Size = new System.Drawing.Size(130, 20);
            this.cbo01_INSTALL_POS.TabIndex = 17;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(354, 14);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(354, 21);
            this.cdx01_LINECD.TabIndex = 14;
            this.cdx01_LINECD.Tag = null;
            this.cdx01_LINECD.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_LINECD_ButtonClickAfter);
            // 
            // lbl01_POSTITLE
            // 
            this.lbl01_POSTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_POSTITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_POSTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_POSTITLE.Location = new System.Drawing.Point(6, 40);
            this.lbl01_POSTITLE.Name = "lbl01_POSTITLE";
            this.lbl01_POSTITLE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_POSTITLE.TabIndex = 13;
            this.lbl01_POSTITLE.Tag = null;
            this.lbl01_POSTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_POSTITLE.Value = "장착위치";
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(248, 14);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINECD.TabIndex = 10;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "완제품 Line";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(6, 14);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 126);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 642);
            this.grd01.TabIndex = 9;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD24120
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD24120";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_STR_LOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STR_LOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOT_DIV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ALCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ALCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_POSTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxComboBox cbo01_INSTALL_POS;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_POSTITLE;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxTextBox txt01_ALCCD;
        private DEV.Utility.Controls.AxLabel lbl01_ALCCD;
        private DEV.Utility.Controls.AxTextBox txt01_LOTNO;
        private DEV.Utility.Controls.AxLabel lbl01_LOTNO;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxRadioButton rdo01_PD24120_RDO1;
        private DEV.Utility.Controls.AxLabel lbl01_LOT_DIV;
        private DEV.Utility.Controls.AxCodeBox cdx01_STR_LOC;
        private DEV.Utility.Controls.AxLabel lbl01_STR_LOC;
        private DEV.Utility.Controls.AxCheckBox chk01_SAP_YN;
    }
}
