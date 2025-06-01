namespace Ax.SIS.PD.UI
{
    partial class PD30050
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD30050));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dte01_APPLY_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BEG_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_CUST_ITEMCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_VEND_ITEMCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BEG_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CUST_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEND_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.axDockingTab1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 734);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dte01_APPLY_BEG_DATE);
            this.panel1.Controls.Add(this.lbl01_BEG_DATE);
            this.panel1.Controls.Add(this.txt01_CUST_ITEMCD);
            this.panel1.Controls.Add(this.lbl01_VEND_ITEMCD);
            this.panel1.Controls.Add(this.cdx01_VINCD);
            this.panel1.Controls.Add(this.txt01_PARTNO);
            this.panel1.Controls.Add(this.lbl01_PARTNO);
            this.panel1.Controls.Add(this.lbl01_VINCD);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 637);
            this.panel1.TabIndex = 10;
            // 
            // dte01_APPLY_BEG_DATE
            // 
            this.dte01_APPLY_BEG_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dte01_APPLY_BEG_DATE.Checked = false;
            this.dte01_APPLY_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_APPLY_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_APPLY_BEG_DATE.Location = new System.Drawing.Point(13, 211);
            this.dte01_APPLY_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_APPLY_BEG_DATE.Name = "dte01_APPLY_BEG_DATE";
            this.dte01_APPLY_BEG_DATE.OriginalFormat = "";
            this.dte01_APPLY_BEG_DATE.ShowCheckBox = true;
            this.dte01_APPLY_BEG_DATE.Size = new System.Drawing.Size(200, 21);
            this.dte01_APPLY_BEG_DATE.TabIndex = 75;
            // 
            // lbl01_BEG_DATE
            // 
            this.lbl01_BEG_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_BEG_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_BEG_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_BEG_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BEG_DATE.Location = new System.Drawing.Point(13, 188);
            this.lbl01_BEG_DATE.Name = "lbl01_BEG_DATE";
            this.lbl01_BEG_DATE.Size = new System.Drawing.Size(200, 20);
            this.lbl01_BEG_DATE.TabIndex = 74;
            this.lbl01_BEG_DATE.Tag = null;
            this.lbl01_BEG_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BEG_DATE.Value = "시작일자 (>=)";
            // 
            // txt01_CUST_ITEMCD
            // 
            this.txt01_CUST_ITEMCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_CUST_ITEMCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CUST_ITEMCD.Location = new System.Drawing.Point(13, 164);
            this.txt01_CUST_ITEMCD.Name = "txt01_CUST_ITEMCD";
            this.txt01_CUST_ITEMCD.Size = new System.Drawing.Size(200, 21);
            this.txt01_CUST_ITEMCD.TabIndex = 72;
            this.txt01_CUST_ITEMCD.Tag = null;
            // 
            // lbl01_VEND_ITEMCD
            // 
            this.lbl01_VEND_ITEMCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_VEND_ITEMCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VEND_ITEMCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VEND_ITEMCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VEND_ITEMCD.Location = new System.Drawing.Point(13, 143);
            this.lbl01_VEND_ITEMCD.Name = "lbl01_VEND_ITEMCD";
            this.lbl01_VEND_ITEMCD.Size = new System.Drawing.Size(200, 20);
            this.lbl01_VEND_ITEMCD.TabIndex = 73;
            this.lbl01_VEND_ITEMCD.Tag = null;
            this.lbl01_VEND_ITEMCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VEND_ITEMCD.Value = "고객사 품목코드";
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 30;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(13, 74);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_VINCD.TabIndex = 70;
            this.cdx01_VINCD.Tag = null;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(13, 119);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(200, 21);
            this.txt01_PARTNO.TabIndex = 7;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(13, 98);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(200, 20);
            this.lbl01_PARTNO.TabIndex = 45;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "품번";
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(13, 53);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(200, 20);
            this.lbl01_VINCD.TabIndex = 48;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VINCD.Value = "차종";
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
            this.cbo01_BIZCD.TabIndex = 55;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(13, 9);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(200, 20);
            this.lbl01_BIZNM.TabIndex = 56;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd01);
            this.panel2.Location = new System.Drawing.Point(313, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 244);
            this.panel2.TabIndex = 12;
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
            this.grd01.Size = new System.Drawing.Size(346, 244);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            // 
            // axDockingTab1
            // 
            this.axDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.axDockingTab1.Name = "axDockingTab1";
            this.axDockingTab1.PanelHeight = 714;
            this.axDockingTab1.PanelWidth = 513;
            this.axDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.axDockingTab1.TabIndex = 11;
            // 
            // PD30050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Name = "PD30050";
            this.Load += new System.EventHandler(this.PD30050_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BEG_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CUST_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEND_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxDockingTab axDockingTab1;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxTextBox txt01_CUST_ITEMCD;
        private DEV.Utility.Controls.AxLabel lbl01_VEND_ITEMCD;
        private DEV.Utility.Controls.AxLabel lbl01_BEG_DATE;
        private DEV.Utility.Controls.AxDateEdit dte01_APPLY_BEG_DATE;

    }
}
