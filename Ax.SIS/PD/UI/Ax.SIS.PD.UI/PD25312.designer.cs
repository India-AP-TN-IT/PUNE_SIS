namespace Ax.SIS.PD.UI
{
    partial class PD25312
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
            this.lbl01_DASH = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_WORKDATE_END = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_SHIFT = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SHIFT = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_WORKDATE_BEG = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_WORK_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SHIFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_DASH);
            this.groupBox1.Controls.Add(this.dtp01_WORKDATE_END);
            this.groupBox1.Controls.Add(this.cbo01_SHIFT);
            this.groupBox1.Controls.Add(this.lbl01_SHIFT);
            this.groupBox1.Controls.Add(this.dtp01_WORKDATE_BEG);
            this.groupBox1.Controls.Add(this.lbl01_WORK_DATE);
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_LINECD);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 68);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_DASH
            // 
            this.lbl01_DASH.AutoFontSizeMaxValue = 9F;
            this.lbl01_DASH.AutoFontSizeMinValue = 9F;
            this.lbl01_DASH.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DASH.Location = new System.Drawing.Point(487, 13);
            this.lbl01_DASH.Name = "lbl01_DASH";
            this.lbl01_DASH.Size = new System.Drawing.Size(17, 21);
            this.lbl01_DASH.TabIndex = 62;
            this.lbl01_DASH.Tag = null;
            this.lbl01_DASH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DASH.Value = "~";
            // 
            // dtp01_WORKDATE_END
            // 
            this.dtp01_WORKDATE_END.CustomFormat = "yyyy-MM-dd";
            this.dtp01_WORKDATE_END.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_WORKDATE_END.Location = new System.Drawing.Point(504, 13);
            this.dtp01_WORKDATE_END.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_WORKDATE_END.Name = "dtp01_WORKDATE_END";
            this.dtp01_WORKDATE_END.OriginalFormat = "";
            this.dtp01_WORKDATE_END.Size = new System.Drawing.Size(130, 21);
            this.dtp01_WORKDATE_END.TabIndex = 61;
            // 
            // cbo01_SHIFT
            // 
            this.cbo01_SHIFT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SHIFT.FormattingEnabled = true;
            this.cbo01_SHIFT.Location = new System.Drawing.Point(460, 39);
            this.cbo01_SHIFT.Name = "cbo01_SHIFT";
            this.cbo01_SHIFT.Size = new System.Drawing.Size(111, 20);
            this.cbo01_SHIFT.TabIndex = 60;
            // 
            // lbl01_SHIFT
            // 
            this.lbl01_SHIFT.AutoFontSizeMaxValue = 9F;
            this.lbl01_SHIFT.AutoFontSizeMinValue = 9F;
            this.lbl01_SHIFT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SHIFT.Location = new System.Drawing.Point(354, 39);
            this.lbl01_SHIFT.Name = "lbl01_SHIFT";
            this.lbl01_SHIFT.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SHIFT.TabIndex = 59;
            this.lbl01_SHIFT.Tag = null;
            this.lbl01_SHIFT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SHIFT.Value = "SHIFT";
            // 
            // dtp01_WORKDATE_BEG
            // 
            this.dtp01_WORKDATE_BEG.CustomFormat = "yyyy-MM-dd";
            this.dtp01_WORKDATE_BEG.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_WORKDATE_BEG.Location = new System.Drawing.Point(354, 13);
            this.dtp01_WORKDATE_BEG.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_WORKDATE_BEG.Name = "dtp01_WORKDATE_BEG";
            this.dtp01_WORKDATE_BEG.OriginalFormat = "";
            this.dtp01_WORKDATE_BEG.Size = new System.Drawing.Size(130, 21);
            this.dtp01_WORKDATE_BEG.TabIndex = 58;
            // 
            // lbl01_WORK_DATE
            // 
            this.lbl01_WORK_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORK_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_WORK_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WORK_DATE.Location = new System.Drawing.Point(248, 14);
            this.lbl01_WORK_DATE.Name = "lbl01_WORK_DATE";
            this.lbl01_WORK_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_WORK_DATE.TabIndex = 57;
            this.lbl01_WORK_DATE.Tag = null;
            this.lbl01_WORK_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WORK_DATE.Value = "작업일자";
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 60;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(112, 39);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(236, 21);
            this.cdx01_LINECD.TabIndex = 14;
            this.cdx01_LINECD.Tag = null;
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(6, 39);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINECD.TabIndex = 10;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "Line";
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
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 102);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 666);
            this.grd01.TabIndex = 9;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowDeleting += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowDeleting);
            this.grd01.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_BeforeEdit);
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            // 
            // PD25312
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD25312";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SHIFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxDateEdit dtp01_WORKDATE_BEG;
        private DEV.Utility.Controls.AxLabel lbl01_WORK_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_SHIFT;
        private DEV.Utility.Controls.AxLabel lbl01_SHIFT;
        private DEV.Utility.Controls.AxDateEdit dtp01_WORKDATE_END;
        private DEV.Utility.Controls.AxLabel lbl01_DASH;
    }
}
