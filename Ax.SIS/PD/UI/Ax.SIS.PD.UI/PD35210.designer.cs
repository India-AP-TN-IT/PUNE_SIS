namespace Ax.SIS.PD.UI
{
    partial class PD35210
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
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_NON_OPRCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.dtp01_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_END_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BEG_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_NON_OPRCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_END_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BEG_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NON_OPRCD)).BeginInit();
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
            this.groupBox3.TabIndex = 12;
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
            this.panel1.Controls.Add(this.cdx01_LINECD);
            this.panel1.Controls.Add(this.cbo01_NON_OPRCD);
            this.panel1.Controls.Add(this.dtp01_END_DATE);
            this.panel1.Controls.Add(this.lbl01_END_DATE);
            this.panel1.Controls.Add(this.dtp01_BEG_DATE);
            this.panel1.Controls.Add(this.lbl01_BEG_DATE);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_LINECD);
            this.panel1.Controls.Add(this.lbl01_NON_OPRCD);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 486);
            this.panel1.TabIndex = 12;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(13, 165);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_LINECD.TabIndex = 87;
            this.cdx01_LINECD.Tag = null;
            this.cdx01_LINECD.ButtonClickBefore += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_LINECD_ButtonClickBefore);
            // 
            // cbo01_NON_OPRCD
            // 
            this.cbo01_NON_OPRCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_NON_OPRCD.FormattingEnabled = true;
            this.cbo01_NON_OPRCD.Location = new System.Drawing.Point(13, 212);
            this.cbo01_NON_OPRCD.Name = "cbo01_NON_OPRCD";
            this.cbo01_NON_OPRCD.Size = new System.Drawing.Size(200, 20);
            this.cbo01_NON_OPRCD.TabIndex = 86;
            // 
            // dtp01_END_DATE
            // 
            this.dtp01_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_END_DATE.Location = new System.Drawing.Point(13, 117);
            this.dtp01_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_END_DATE.Name = "dtp01_END_DATE";
            this.dtp01_END_DATE.OriginalFormat = "";
            this.dtp01_END_DATE.Size = new System.Drawing.Size(200, 21);
            this.dtp01_END_DATE.TabIndex = 85;
            // 
            // lbl01_END_DATE
            // 
            this.lbl01_END_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_END_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_END_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_END_DATE.Location = new System.Drawing.Point(13, 102);
            this.lbl01_END_DATE.Name = "lbl01_END_DATE";
            this.lbl01_END_DATE.Size = new System.Drawing.Size(130, 12);
            this.lbl01_END_DATE.TabIndex = 84;
            this.lbl01_END_DATE.Tag = null;
            this.lbl01_END_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_END_DATE.Value = "일자 To";
            // 
            // dtp01_BEG_DATE
            // 
            this.dtp01_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_DATE.Location = new System.Drawing.Point(13, 68);
            this.dtp01_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_BEG_DATE.Name = "dtp01_BEG_DATE";
            this.dtp01_BEG_DATE.OriginalFormat = "";
            this.dtp01_BEG_DATE.Size = new System.Drawing.Size(200, 21);
            this.dtp01_BEG_DATE.TabIndex = 83;
            // 
            // lbl01_BEG_DATE
            // 
            this.lbl01_BEG_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_BEG_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_BEG_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BEG_DATE.Location = new System.Drawing.Point(13, 53);
            this.lbl01_BEG_DATE.Name = "lbl01_BEG_DATE";
            this.lbl01_BEG_DATE.Size = new System.Drawing.Size(145, 12);
            this.lbl01_BEG_DATE.TabIndex = 82;
            this.lbl01_BEG_DATE.Tag = null;
            this.lbl01_BEG_DATE.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BEG_DATE.Value = "일자 From";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.AutoSize = true;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(13, 9);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(75, 12);
            this.lbl01_BIZNM.TabIndex = 61;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 24);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(200, 20);
            this.cbo01_BIZCD.TabIndex = 62;
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.AutoSize = true;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_LINECD.Location = new System.Drawing.Point(13, 150);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(80, 12);
            this.lbl01_LINECD.TabIndex = 58;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "대상 LINE";
            // 
            // lbl01_NON_OPRCD
            // 
            this.lbl01_NON_OPRCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_NON_OPRCD.AutoFontSizeMinValue = 9F;
            this.lbl01_NON_OPRCD.AutoSize = true;
            this.lbl01_NON_OPRCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_NON_OPRCD.Location = new System.Drawing.Point(13, 197);
            this.lbl01_NON_OPRCD.Name = "lbl01_NON_OPRCD";
            this.lbl01_NON_OPRCD.Size = new System.Drawing.Size(111, 12);
            this.lbl01_NON_OPRCD.TabIndex = 56;
            this.lbl01_NON_OPRCD.Tag = null;
            this.lbl01_NON_OPRCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_NON_OPRCD.Value = "비가동코드";
            // 
            // axDockingTab1
            // 
            this.axDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.axDockingTab1.Name = "axDockingTab1";
            this.axDockingTab1.PanelHeight = 714;
            this.axDockingTab1.PanelWidth = 277;
            this.axDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.axDockingTab1.TabIndex = 13;
            // 
            // PD35210
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Name = "PD35210";
            this.Load += new System.EventHandler(this.PD35210_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_END_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BEG_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NON_OPRCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxComboBox cbo01_NON_OPRCD;
        private DEV.Utility.Controls.AxDateEdit dtp01_END_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_END_DATE;
        private DEV.Utility.Controls.AxDateEdit dtp01_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_NON_OPRCD;
        private DEV.Utility.Controls.AxDockingTab axDockingTab1;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
    }
}
