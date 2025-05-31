namespace Ax.SIS.TM.UI
{
    partial class TM20300
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM20300));
            this.grd01_INSPEC_INFO = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_PROCCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_PROCCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl04_PROCNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01_INSPEC_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PROCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_PROCNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1360, 34);
            // 
            // grd01_INSPEC_INFO
            // 
            this.grd01_INSPEC_INFO.Controls.Add(this.grd01);
            this.grd01_INSPEC_INFO.Controls.Add(this.groupBox1);
            this.grd01_INSPEC_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_INSPEC_INFO.Location = new System.Drawing.Point(0, 0);
            this.grd01_INSPEC_INFO.Name = "grd01_INSPEC_INFO";
            this.grd01_INSPEC_INFO.Size = new System.Drawing.Size(1360, 768);
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
            this.grd01.Location = new System.Drawing.Point(3, 128);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1354, 634);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserting += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserting);
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
          
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_PROCCD);
            this.groupBox1.Controls.Add(this.cdx01_PROCCD);
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.lbl04_PROCNM);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Controls.Add(this.cbo01_CORCD);
            this.groupBox1.Controls.Add(this.lbl01_CORCD);
            this.groupBox1.Location = new System.Drawing.Point(6, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1348, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_PROCCD
            // 
            this.lbl01_PROCCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_PROCCD.AutoFontSizeMinValue = 9F;
            this.lbl01_PROCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PROCCD.Location = new System.Drawing.Point(6, 42);
            this.lbl01_PROCCD.Name = "lbl01_PROCCD";
            this.lbl01_PROCCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PROCCD.TabIndex = 167;
            this.lbl01_PROCCD.Tag = null;
            this.lbl01_PROCCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PROCCD.Value = "Station";
            // 
            // cdx01_PROCCD
            // 
            this.cdx01_PROCCD.CodeParameterName = "CODE";
            this.cdx01_PROCCD.CodeTextBoxReadOnly = false;
            this.cdx01_PROCCD.CodeTextBoxVisible = true;
            this.cdx01_PROCCD.CodeTextBoxWidth = 60;
            this.cdx01_PROCCD.HEPopupHelper = null;
            this.cdx01_PROCCD.Location = new System.Drawing.Point(112, 42);
            this.cdx01_PROCCD.Name = "cdx01_PROCCD";
            this.cdx01_PROCCD.NameParameterName = "NAME";
            this.cdx01_PROCCD.NameTextBoxReadOnly = false;
            this.cdx01_PROCCD.NameTextBoxVisible = true;
            this.cdx01_PROCCD.PopupButtonReadOnly = false;
            this.cdx01_PROCCD.PopupTitle = "";
            this.cdx01_PROCCD.PrefixCode = "";
            this.cdx01_PROCCD.Size = new System.Drawing.Size(371, 21);
            this.cdx01_PROCCD.TabIndex = 168;
            this.cdx01_PROCCD.Tag = null;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 60;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(729, 15);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(337, 21);
            this.cdx01_LINECD.TabIndex = 165;
            this.cdx01_LINECD.Tag = null;
            // 
            // lbl04_PROCNM
            // 
            this.lbl04_PROCNM.AutoFontSizeMaxValue = 9F;
            this.lbl04_PROCNM.AutoFontSizeMinValue = 9F;
            this.lbl04_PROCNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl04_PROCNM.Location = new System.Drawing.Point(623, 15);
            this.lbl04_PROCNM.Name = "lbl04_PROCNM";
            this.lbl04_PROCNM.Size = new System.Drawing.Size(100, 21);
            this.lbl04_PROCNM.TabIndex = 166;
            this.lbl04_PROCNM.Tag = null;
            this.lbl04_PROCNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl04_PROCNM.Value = "Line";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(449, 13);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_BIZCD.TabIndex = 164;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(309, 13);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(134, 20);
            this.lbl01_BIZCD.TabIndex = 163;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(145, 13);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_CORCD.TabIndex = 162;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(5, 13);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(134, 21);
            this.lbl01_CORCD.TabIndex = 161;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "Corporation";
            // 
            // TM20300
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01_INSPEC_INFO);
            this.Name = "TM20300";
            this.Size = new System.Drawing.Size(1360, 768);
            this.Controls.SetChildIndex(this.grd01_INSPEC_INFO, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.grd01_INSPEC_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PROCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PROCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl04_PROCNM)).EndInit();
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
        private DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl04_PROCNM;
        private DEV.Utility.Controls.AxLabel lbl01_PROCCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_PROCCD;        
    }
}
