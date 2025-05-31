namespace Ax.SIS.PD.UI
{
    partial class PD20042
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
            this.grp01_PD20042_GRP1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cdx01_MOLDNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNOTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_MOLDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SAUP = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD20042_GRP2 = new System.Windows.Forms.GroupBox();
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.nme01_USAGE = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.lbl01_USAGE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_PARTNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_MOLDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.grp01_PD20042_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.grp01_PD20042_GRP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nme01_USAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOLDNO)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD20042_GRP1
            // 
            this.grp01_PD20042_GRP1.Controls.Add(this.grd01);
            this.grp01_PD20042_GRP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD20042_GRP1.Location = new System.Drawing.Point(0, 74);
            this.grp01_PD20042_GRP1.Name = "grp01_PD20042_GRP1";
            this.grp01_PD20042_GRP1.Size = new System.Drawing.Size(1024, 595);
            this.grp01_PD20042_GRP1.TabIndex = 1;
            this.grp01_PD20042_GRP1.TabStop = false;
            this.grp01_PD20042_GRP1.Text = "금형별 제품 목록";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 575);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cdx01_MOLDNO);
            this.groupBox2.Controls.Add(this.txt01_PARTNO);
            this.groupBox2.Controls.Add(this.lbl01_PARTNOTITLE);
            this.groupBox2.Controls.Add(this.lbl01_MOLDNO);
            this.groupBox2.Controls.Add(this.cbo01_SAUP);
            this.groupBox2.Controls.Add(this.lbl01_BIZNM);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 40);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // cdx01_MOLDNO
            // 
            this.cdx01_MOLDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_MOLDNO.CodeParameterName = "CODE";
            this.cdx01_MOLDNO.CodeTextBoxReadOnly = false;
            this.cdx01_MOLDNO.CodeTextBoxVisible = true;
            this.cdx01_MOLDNO.CodeTextBoxWidth = 90;
            this.cdx01_MOLDNO.HEPopupHelper = null;
            this.cdx01_MOLDNO.Location = new System.Drawing.Point(354, 14);
            this.cdx01_MOLDNO.Name = "cdx01_MOLDNO";
            this.cdx01_MOLDNO.NameParameterName = "NAME";
            this.cdx01_MOLDNO.NameTextBoxReadOnly = false;
            this.cdx01_MOLDNO.NameTextBoxVisible = true;
            this.cdx01_MOLDNO.PopupButtonReadOnly = false;
            this.cdx01_MOLDNO.PopupTitle = "";
            this.cdx01_MOLDNO.PrefixCode = "";
            this.cdx01_MOLDNO.Size = new System.Drawing.Size(248, 21);
            this.cdx01_MOLDNO.TabIndex = 13;
            this.cdx01_MOLDNO.Tag = null;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(713, 15);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(224, 21);
            this.txt01_PARTNO.TabIndex = 5;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNOTITLE
            // 
            this.lbl01_PARTNOTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNOTITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNOTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNOTITLE.Location = new System.Drawing.Point(607, 15);
            this.lbl01_PARTNOTITLE.Name = "lbl01_PARTNOTITLE";
            this.lbl01_PARTNOTITLE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PARTNOTITLE.TabIndex = 4;
            this.lbl01_PARTNOTITLE.Tag = null;
            this.lbl01_PARTNOTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNOTITLE.Value = "대상 PART NO";
            // 
            // lbl01_MOLDNO
            // 
            this.lbl01_MOLDNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_MOLDNO.AutoFontSizeMinValue = 9F;
            this.lbl01_MOLDNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MOLDNO.Location = new System.Drawing.Point(248, 14);
            this.lbl01_MOLDNO.Name = "lbl01_MOLDNO";
            this.lbl01_MOLDNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MOLDNO.TabIndex = 2;
            this.lbl01_MOLDNO.Tag = null;
            this.lbl01_MOLDNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MOLDNO.Value = "금형번호";
            // 
            // cbo01_SAUP
            // 
            this.cbo01_SAUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SAUP.FormattingEnabled = true;
            this.cbo01_SAUP.Location = new System.Drawing.Point(112, 14);
            this.cbo01_SAUP.Name = "cbo01_SAUP";
            this.cbo01_SAUP.Size = new System.Drawing.Size(130, 20);
            this.cbo01_SAUP.TabIndex = 1;
            this.cbo01_SAUP.SelectedIndexChanged += new System.EventHandler(this.cbo01_SAUP_SelectedIndexChanged);
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
            // grp01_PD20042_GRP2
            // 
            this.grp01_PD20042_GRP2.Controls.Add(this.label1);
            this.grp01_PD20042_GRP2.Controls.Add(this.axButton1);
            this.grp01_PD20042_GRP2.Controls.Add(this.nme01_USAGE);
            this.grp01_PD20042_GRP2.Controls.Add(this.lbl01_USAGE);
            this.grp01_PD20042_GRP2.Controls.Add(this.cdx01_PARTNO);
            this.grp01_PD20042_GRP2.Controls.Add(this.lbl01_PARTNO);
            this.grp01_PD20042_GRP2.Controls.Add(this.lbl02_MOLDNO);
            this.grp01_PD20042_GRP2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_PD20042_GRP2.Location = new System.Drawing.Point(0, 669);
            this.grp01_PD20042_GRP2.Name = "grp01_PD20042_GRP2";
            this.grp01_PD20042_GRP2.Size = new System.Drawing.Size(1024, 99);
            this.grp01_PD20042_GRP2.TabIndex = 9;
            this.grp01_PD20042_GRP2.TabStop = false;
            this.grp01_PD20042_GRP2.Text = "금형별 제품 정보";
            // 
            // axButton1
            // 
            this.axButton1.Location = new System.Drawing.Point(700, 23);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(255, 53);
            this.axButton1.TabIndex = 14;
            this.axButton1.Text = "Data Import From SAP";
            this.axButton1.UseVisualStyleBackColor = true;
            this.axButton1.Click += new System.EventHandler(this.axButton1_Click);
            // 
            // nme01_USAGE
            // 
            this.nme01_USAGE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.StandardNumber;
            this.nme01_USAGE.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme01_USAGE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.StandardNumber;
            this.nme01_USAGE.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme01_USAGE.EmptyAsNull = true;
            this.nme01_USAGE.Location = new System.Drawing.Point(112, 71);
            this.nme01_USAGE.Name = "nme01_USAGE";
            this.nme01_USAGE.NullText = "0";
            this.nme01_USAGE.Size = new System.Drawing.Size(60, 21);
            this.nme01_USAGE.TabIndex = 13;
            this.nme01_USAGE.Tag = null;
            this.nme01_USAGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme01_USAGE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // lbl01_USAGE
            // 
            this.lbl01_USAGE.AutoFontSizeMaxValue = 9F;
            this.lbl01_USAGE.AutoFontSizeMinValue = 9F;
            this.lbl01_USAGE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_USAGE.Location = new System.Drawing.Point(6, 70);
            this.lbl01_USAGE.Name = "lbl01_USAGE";
            this.lbl01_USAGE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_USAGE.TabIndex = 10;
            this.lbl01_USAGE.Tag = null;
            this.lbl01_USAGE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_USAGE.Value = "USAGE";
            // 
            // cdx01_PARTNO
            // 
            this.cdx01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_PARTNO.CodeParameterName = "CODE";
            this.cdx01_PARTNO.CodeTextBoxReadOnly = false;
            this.cdx01_PARTNO.CodeTextBoxVisible = true;
            this.cdx01_PARTNO.CodeTextBoxWidth = 110;
            this.cdx01_PARTNO.HEPopupHelper = null;
            this.cdx01_PARTNO.Location = new System.Drawing.Point(112, 44);
            this.cdx01_PARTNO.Name = "cdx01_PARTNO";
            this.cdx01_PARTNO.NameParameterName = "NAME";
            this.cdx01_PARTNO.NameTextBoxReadOnly = false;
            this.cdx01_PARTNO.NameTextBoxVisible = true;
            this.cdx01_PARTNO.PopupButtonReadOnly = false;
            this.cdx01_PARTNO.PopupTitle = "";
            this.cdx01_PARTNO.PrefixCode = "";
            this.cdx01_PARTNO.Size = new System.Drawing.Size(320, 21);
            this.cdx01_PARTNO.TabIndex = 9;
            this.cdx01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(6, 43);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PARTNO.TabIndex = 7;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "품번";
            // 
            // lbl02_MOLDNO
            // 
            this.lbl02_MOLDNO.AutoFontSizeMaxValue = 9F;
            this.lbl02_MOLDNO.AutoFontSizeMinValue = 9F;
            this.lbl02_MOLDNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_MOLDNO.Location = new System.Drawing.Point(6, 17);
            this.lbl02_MOLDNO.Name = "lbl02_MOLDNO";
            this.lbl02_MOLDNO.Size = new System.Drawing.Size(100, 21);
            this.lbl02_MOLDNO.TabIndex = 1;
            this.lbl02_MOLDNO.Tag = null;
            this.lbl02_MOLDNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_MOLDNO.Value = "금형번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // PD20042
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD20042_GRP1);
            this.Controls.Add(this.grp01_PD20042_GRP2);
            this.Controls.Add(this.groupBox2);
            this.Name = "PD20042";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.grp01_PD20042_GRP2, 0);
            this.Controls.SetChildIndex(this.grp01_PD20042_GRP1, 0);
            this.grp01_PD20042_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.grp01_PD20042_GRP2.ResumeLayout(false);
            this.grp01_PD20042_GRP2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nme01_USAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_USAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOLDNO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD20042_GRP1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNOTITLE;
        private DEV.Utility.Controls.AxLabel lbl01_MOLDNO;
        private DEV.Utility.Controls.AxComboBox cbo01_SAUP;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private System.Windows.Forms.GroupBox grp01_PD20042_GRP2;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl02_MOLDNO;
        private DEV.Utility.Controls.AxLabel lbl01_USAGE;
        private DEV.Utility.Controls.AxCodeBox cdx01_PARTNO;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxCodeBox cdx01_MOLDNO;
        private DEV.Utility.Controls.AxNumericEdit nme01_USAGE;
        private DEV.Utility.Controls.AxButton axButton1;
        private System.Windows.Forms.Label label1;
    }
}
