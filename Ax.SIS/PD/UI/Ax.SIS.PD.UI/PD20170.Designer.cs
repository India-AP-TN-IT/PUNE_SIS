namespace Ax.SIS.PD.UI
{
    partial class PD20170
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20170));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_ASSYNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ASSYNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.axTextBox1);
            this.groupBox1.Controls.Add(this.cdx01_VINCD);
            this.groupBox1.Controls.Add(this.lbl01_VINCD);
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_ASSYNO);
            this.groupBox1.Controls.Add(this.lbl01_LINECD);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Location = new System.Drawing.Point(0, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 76);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(89, 44);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(272, 21);
            this.cdx01_VINCD.TabIndex = 76;
            this.cdx01_VINCD.Tag = null;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(9, 44);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(74, 21);
            this.lbl01_VINCD.TabIndex = 75;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "CAR";
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 80;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(354, 17);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(432, 21);
            this.cdx01_LINECD.TabIndex = 47;
            this.cdx01_LINECD.Tag = null;
            // 
            // lbl01_ASSYNO
            // 
            this.lbl01_ASSYNO.AutoFontSizeMaxValue = 8.25F;
            this.lbl01_ASSYNO.AutoFontSizeMinValue = 8.25F;
            this.lbl01_ASSYNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ASSYNO.Location = new System.Drawing.Point(389, 44);
            this.lbl01_ASSYNO.Name = "lbl01_ASSYNO";
            this.lbl01_ASSYNO.Size = new System.Drawing.Size(100, 20);
            this.lbl01_ASSYNO.TabIndex = 45;
            this.lbl01_ASSYNO.Tag = null;
            this.lbl01_ASSYNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ASSYNO.Value = "P/NO";
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 8.25F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 8.25F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(248, 17);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 20);
            this.lbl01_LINECD.TabIndex = 44;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "LINE";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(114, 18);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 23);
            this.cbo01_BIZCD.TabIndex = 43;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 8.25F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 8.25F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(8, 18);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(100, 20);
            this.lbl01_BIZCD.TabIndex = 42;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business Plant";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(6, 125);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1015, 832);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 9;
            this.grd01.UseCustomHighlight = true;
            // 
            // axTextBox1
            // 
            this.axTextBox1.Location = new System.Drawing.Point(495, 44);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(291, 21);
            this.axTextBox1.TabIndex = 77;
            this.axTextBox1.Tag = null;
            // 
            // PD20170
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20170";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ASSYNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_ASSYNO;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private DEV.Utility.Controls.AxTextBox axTextBox1;
    }
}
