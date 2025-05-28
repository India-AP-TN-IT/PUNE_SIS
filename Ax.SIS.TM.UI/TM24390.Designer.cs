namespace Ax.SIS.TM.UI
{
    partial class TM24390
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM24390));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_ED_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_ST_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Margin = new System.Windows.Forms.Padding(12);
            this._buttonsControl.Size = new System.Drawing.Size(1265, 68);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(19, 210);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grd01);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grd02);
            this.splitContainer1.Size = new System.Drawing.Size(1226, 545);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 11;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Margin = new System.Windows.Forms.Padding(6);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1226, 271);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Margin = new System.Windows.Forms.Padding(6);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(1226, 270);
            this.grd02.StyleInfo = resources.GetString("grd02.StyleInfo");
            this.grd02.TabIndex = 9;
            this.grd02.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp01_ED_DATE);
            this.groupBox1.Controls.Add(this.dtp01_ST_DATE);
            this.groupBox1.Controls.Add(this.axLabel3);
            this.groupBox1.Controls.Add(this.axTextBox2);
            this.groupBox1.Controls.Add(this.axTextBox1);
            this.groupBox1.Controls.Add(this.axLabel2);
            this.groupBox1.Controls.Add(this.axLabel1);
            this.groupBox1.Controls.Add(this.cdx01_VENDCD);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_VENDCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Controls.Add(this.cbo01_CORCD);
            this.groupBox1.Controls.Add(this.lbl01_CORCD);
            this.groupBox1.Location = new System.Drawing.Point(19, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1226, 147);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 172;
            this.label1.Text = "~";
            // 
            // dtp01_ED_DATE
            // 
            this.dtp01_ED_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_ED_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_ED_DATE.Location = new System.Drawing.Point(334, 113);
            this.dtp01_ED_DATE.Margin = new System.Windows.Forms.Padding(6);
            this.dtp01_ED_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_ED_DATE.Name = "dtp01_ED_DATE";
            this.dtp01_ED_DATE.OriginalFormat = "";
            this.dtp01_ED_DATE.Size = new System.Drawing.Size(124, 21);
            this.dtp01_ED_DATE.TabIndex = 171;
            // 
            // dtp01_ST_DATE
            // 
            this.dtp01_ST_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_ST_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_ST_DATE.Location = new System.Drawing.Point(172, 113);
            this.dtp01_ST_DATE.Margin = new System.Windows.Forms.Padding(6);
            this.dtp01_ST_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_ST_DATE.Name = "dtp01_ST_DATE";
            this.dtp01_ST_DATE.OriginalFormat = "";
            this.dtp01_ST_DATE.Size = new System.Drawing.Size(119, 21);
            this.dtp01_ST_DATE.TabIndex = 170;
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(10, 108);
            this.axLabel3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(159, 27);
            this.axLabel3.TabIndex = 169;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "T/Date";
            // 
            // axTextBox2
            // 
            this.axTextBox2.Location = new System.Drawing.Point(608, 79);
            this.axTextBox2.Margin = new System.Windows.Forms.Padding(6);
            this.axTextBox2.Name = "axTextBox2";
            this.axTextBox2.Size = new System.Drawing.Size(240, 21);
            this.axTextBox2.TabIndex = 168;
            this.axTextBox2.Tag = null;
            // 
            // axTextBox1
            // 
            this.axTextBox1.Location = new System.Drawing.Point(174, 83);
            this.axTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(240, 21);
            this.axTextBox1.TabIndex = 167;
            this.axTextBox1.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(463, 79);
            this.axLabel2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(133, 24);
            this.axLabel2.TabIndex = 166;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Location Description";
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(10, 79);
            this.axLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(159, 24);
            this.axLabel1.TabIndex = 165;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Location Code";
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(172, 56);
            this.cdx01_VENDCD.Margin = new System.Windows.Forms.Padding(6);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(490, 21);
            this.cdx01_VENDCD.TabIndex = 146;
            this.cdx01_VENDCD.Tag = null;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(614, 28);
            this.cbo01_BIZCD.Margin = new System.Windows.Forms.Padding(6);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(240, 23);
            this.cbo01_BIZCD.TabIndex = 164;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.Location = new System.Drawing.Point(10, 55);
            this.lbl01_VENDCD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(157, 21);
            this.lbl01_VENDCD.TabIndex = 145;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VENDCD.Value = "Supplier";
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(476, 27);
            this.lbl01_BIZCD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(133, 24);
            this.lbl01_BIZCD.TabIndex = 163;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(174, 27);
            this.cbo01_CORCD.Margin = new System.Windows.Forms.Padding(6);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(240, 23);
            this.cbo01_CORCD.TabIndex = 162;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(10, 26);
            this.lbl01_CORCD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(159, 23);
            this.lbl01_CORCD.TabIndex = 161;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "Corporation";
            // 
            // TM24390
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TM24390";
            this.Size = new System.Drawing.Size(1265, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DEV.Utility.Controls.AxDateEdit dtp01_ED_DATE;
        private DEV.Utility.Controls.AxDateEdit dtp01_ST_DATE;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxTextBox axTextBox2;
        private DEV.Utility.Controls.AxTextBox axTextBox1;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;

    }
}
