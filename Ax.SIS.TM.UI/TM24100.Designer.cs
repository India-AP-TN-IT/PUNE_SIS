namespace Ax.SIS.TM.UI
{
    partial class TM24100
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM24100));
            this.grd01_INSPEC_INFO = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
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
            this.grd01_INSPEC_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this._buttonsControl.Margin = new System.Windows.Forms.Padding(6);
            this._buttonsControl.Size = new System.Drawing.Size(1475, 50);
            // 
            // grd01_INSPEC_INFO
            // 
            this.grd01_INSPEC_INFO.Controls.Add(this.grd01);
            this.grd01_INSPEC_INFO.Controls.Add(this.groupBox1);
            this.grd01_INSPEC_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_INSPEC_INFO.Location = new System.Drawing.Point(0, 0);
            this.grd01_INSPEC_INFO.Margin = new System.Windows.Forms.Padding(4);
            this.grd01_INSPEC_INFO.Name = "grd01_INSPEC_INFO";
            this.grd01_INSPEC_INFO.Padding = new System.Windows.Forms.Padding(4);
            this.grd01_INSPEC_INFO.Size = new System.Drawing.Size(1475, 1152);
            this.grd01_INSPEC_INFO.TabIndex = 8;
            this.grd01_INSPEC_INFO.TabStop = false;
            this.grd01_INSPEC_INFO.Text = "Location Master";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(4, 205);
            this.grd01.Margin = new System.Windows.Forms.Padding(4);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1464, 936);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserting += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserting);
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.axButton1);
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
            this.groupBox1.Location = new System.Drawing.Point(9, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1449, 137);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // axButton1
            // 
            this.axButton1.Location = new System.Drawing.Point(925, 19);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(219, 34);
            this.axButton1.TabIndex = 169;
            this.axButton1.Text = "Import from WMS Truck";
            this.axButton1.UseVisualStyleBackColor = true;
            this.axButton1.Click += new System.EventHandler(this.axButton1_Click);
            // 
            // axTextBox2
            // 
            this.axTextBox2.Location = new System.Drawing.Point(674, 96);
            this.axTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.axTextBox2.Name = "axTextBox2";
            this.axTextBox2.Size = new System.Drawing.Size(470, 21);
            this.axTextBox2.TabIndex = 168;
            this.axTextBox2.Tag = null;
            // 
            // axTextBox1
            // 
            this.axTextBox1.Location = new System.Drawing.Point(218, 96);
            this.axTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(237, 21);
            this.axTextBox1.TabIndex = 167;
            this.axTextBox1.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(464, 96);
            this.axLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(201, 28);
            this.axLabel2.TabIndex = 166;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Truck Description";
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(8, 96);
            this.axLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(201, 28);
            this.axLabel1.TabIndex = 165;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Truck No";
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(240, 59);
            this.cdx01_VENDCD.Margin = new System.Windows.Forms.Padding(4);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(669, 21);
            this.cdx01_VENDCD.TabIndex = 146;
            this.cdx01_VENDCD.Tag = null;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(674, 20);
            this.cbo01_BIZCD.Margin = new System.Windows.Forms.Padding(4);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(235, 23);
            this.cbo01_BIZCD.TabIndex = 164;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.Location = new System.Drawing.Point(8, 59);
            this.lbl01_VENDCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(224, 28);
            this.lbl01_VENDCD.TabIndex = 145;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VENDCD.Value = "Supplier";
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(464, 20);
            this.lbl01_BIZCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(201, 30);
            this.lbl01_BIZCD.TabIndex = 163;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(218, 20);
            this.cbo01_CORCD.Margin = new System.Windows.Forms.Padding(4);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(235, 23);
            this.cbo01_CORCD.TabIndex = 162;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(8, 20);
            this.lbl01_CORCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(201, 32);
            this.lbl01_CORCD.TabIndex = 161;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "Corporation";
            // 
            // TM24100
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grd01_INSPEC_INFO);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TM24100";
            this.Size = new System.Drawing.Size(1475, 1152);
            this.Controls.SetChildIndex(this.grd01_INSPEC_INFO, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.grd01_INSPEC_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
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

        private System.Windows.Forms.GroupBox grd01_INSPEC_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private DEV.Utility.Controls.AxTextBox axTextBox2;
        private DEV.Utility.Controls.AxTextBox axTextBox1;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxButton axButton1;        
    }
}
