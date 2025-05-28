namespace Ax.SIS.PD.UI
{
    partial class PD35330
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD35330));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk01_LINE_SUM = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.dtp01_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.dtp01_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_WORKDATE2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINE4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORKDATE2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk01_LINE_SUM);
            this.groupBox1.Controls.Add(this.dtp01_END_DATE);
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.dtp01_BEG_DATE);
            this.groupBox1.Controls.Add(this.lbl01_WORKDATE2);
            this.groupBox1.Controls.Add(this.lbl01_LINE4);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 78);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // chk01_LINE_SUM
            // 
            this.chk01_LINE_SUM.AutoSize = true;
            this.chk01_LINE_SUM.Location = new System.Drawing.Point(424, 49);
            this.chk01_LINE_SUM.Name = "chk01_LINE_SUM";
            this.chk01_LINE_SUM.Size = new System.Drawing.Size(84, 16);
            this.chk01_LINE_SUM.TabIndex = 61;
            this.chk01_LINE_SUM.Text = "라인별합계";
            this.chk01_LINE_SUM.UseVisualStyleBackColor = true;
            // 
            // dtp01_END_DATE
            // 
            this.dtp01_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_END_DATE.Location = new System.Drawing.Point(251, 46);
            this.dtp01_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_END_DATE.Name = "dtp01_END_DATE";
            this.dtp01_END_DATE.OriginalFormat = "";
            this.dtp01_END_DATE.Size = new System.Drawing.Size(130, 21);
            this.dtp01_END_DATE.TabIndex = 60;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 50;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(357, 19);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(418, 21);
            this.cdx01_LINECD.TabIndex = 59;
            this.cdx01_LINECD.Tag = null;
            // 
            // dtp01_BEG_DATE
            // 
            this.dtp01_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_DATE.Location = new System.Drawing.Point(115, 46);
            this.dtp01_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_BEG_DATE.Name = "dtp01_BEG_DATE";
            this.dtp01_BEG_DATE.OriginalFormat = "";
            this.dtp01_BEG_DATE.Size = new System.Drawing.Size(130, 21);
            this.dtp01_BEG_DATE.TabIndex = 56;
            // 
            // lbl01_WORKDATE2
            // 
            this.lbl01_WORKDATE2.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORKDATE2.AutoFontSizeMinValue = 9F;
            this.lbl01_WORKDATE2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WORKDATE2.Location = new System.Drawing.Point(9, 46);
            this.lbl01_WORKDATE2.Name = "lbl01_WORKDATE2";
            this.lbl01_WORKDATE2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_WORKDATE2.TabIndex = 55;
            this.lbl01_WORKDATE2.Tag = null;
            this.lbl01_WORKDATE2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WORKDATE2.Value = "근무일자";
            // 
            // lbl01_LINE4
            // 
            this.lbl01_LINE4.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINE4.AutoFontSizeMinValue = 9F;
            this.lbl01_LINE4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINE4.Location = new System.Drawing.Point(251, 20);
            this.lbl01_LINE4.Name = "lbl01_LINE4";
            this.lbl01_LINE4.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINE4.TabIndex = 53;
            this.lbl01_LINE4.Tag = null;
            this.lbl01_LINE4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINE4.Value = "원소속라인";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(9, 19);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 52;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(115, 20);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 51;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 112);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 656);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 17;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD35330
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD35330";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORKDATE2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxDateEdit dtp01_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_WORKDATE2;
        private DEV.Utility.Controls.AxLabel lbl01_LINE4;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxDateEdit dtp01_END_DATE;
        private DEV.Utility.Controls.AxCheckBox chk01_LINE_SUM;
    }
}
