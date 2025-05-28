namespace Ax.SIS.WM.UI
{
    partial class WM20443
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
            this.grd01_INSPEC_INFO = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_PRT_SIZE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PRT_SIZE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SLOT_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SLOT = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PRDT = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PRDT = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_WHCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_WHCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_DELIVERY_ABLE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_DELIVERY_ABLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LOCATION_NO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LOCATION_NO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grd01_INSPEC_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRT_SIZE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SLOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WHCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELIVERY_ABLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOCATION_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOCATION_NO)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1360, 34);
            // 
            // grd01_INSPEC_INFO
            // 
            this.grd01_INSPEC_INFO.Controls.Add(this.grd01);
            this.grd01_INSPEC_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_INSPEC_INFO.Location = new System.Drawing.Point(0, 74);
            this.grd01_INSPEC_INFO.Name = "grd01_INSPEC_INFO";
            this.grd01_INSPEC_INFO.Size = new System.Drawing.Size(1360, 694);
            this.grd01_INSPEC_INFO.TabIndex = 8;
            this.grd01_INSPEC_INFO.TabStop = false;
            this.grd01_INSPEC_INFO.Text = "Location Master";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1354, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_PRT_SIZE);
            this.groupBox1.Controls.Add(this.lbl01_PRT_SIZE);
            this.groupBox1.Controls.Add(this.cbo01_SLOT_YN);
            this.groupBox1.Controls.Add(this.lbl01_SLOT);
            this.groupBox1.Controls.Add(this.cbo01_PRDT);
            this.groupBox1.Controls.Add(this.lbl01_PRDT);
            this.groupBox1.Controls.Add(this.cbo01_WHCD);
            this.groupBox1.Controls.Add(this.lbl01_WHCD);
            this.groupBox1.Controls.Add(this.cbo01_DELIVERY_ABLE);
            this.groupBox1.Controls.Add(this.lbl01_DELIVERY_ABLE);
            this.groupBox1.Controls.Add(this.lbl01_LOCATION_NO);
            this.groupBox1.Controls.Add(this.txt01_LOCATION_NO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1360, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_PRT_SIZE
            // 
            this.cbo01_PRT_SIZE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo01_PRT_SIZE.DisplayMember = "Y";
            this.cbo01_PRT_SIZE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRT_SIZE.FormattingEnabled = true;
            this.cbo01_PRT_SIZE.Location = new System.Drawing.Point(1280, 13);
            this.cbo01_PRT_SIZE.Name = "cbo01_PRT_SIZE";
            this.cbo01_PRT_SIZE.Size = new System.Drawing.Size(74, 20);
            this.cbo01_PRT_SIZE.TabIndex = 103;
            // 
            // lbl01_PRT_SIZE
            // 
            this.lbl01_PRT_SIZE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_PRT_SIZE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRT_SIZE.AutoFontSizeMinValue = 9F;
            this.lbl01_PRT_SIZE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRT_SIZE.Location = new System.Drawing.Point(1174, 13);
            this.lbl01_PRT_SIZE.Name = "lbl01_PRT_SIZE";
            this.lbl01_PRT_SIZE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PRT_SIZE.TabIndex = 102;
            this.lbl01_PRT_SIZE.Tag = null;
            this.lbl01_PRT_SIZE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PRT_SIZE.Value = "PRINT SIZE";
            // 
            // cbo01_SLOT_YN
            // 
            this.cbo01_SLOT_YN.DisplayMember = "Y";
            this.cbo01_SLOT_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SLOT_YN.FormattingEnabled = true;
            this.cbo01_SLOT_YN.Location = new System.Drawing.Point(881, 13);
            this.cbo01_SLOT_YN.Name = "cbo01_SLOT_YN";
            this.cbo01_SLOT_YN.Size = new System.Drawing.Size(59, 20);
            this.cbo01_SLOT_YN.TabIndex = 101;
            // 
            // lbl01_SLOT
            // 
            this.lbl01_SLOT.AutoFontSizeMaxValue = 9F;
            this.lbl01_SLOT.AutoFontSizeMinValue = 9F;
            this.lbl01_SLOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SLOT.Location = new System.Drawing.Point(776, 13);
            this.lbl01_SLOT.Name = "lbl01_SLOT";
            this.lbl01_SLOT.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SLOT.TabIndex = 100;
            this.lbl01_SLOT.Tag = null;
            this.lbl01_SLOT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SLOT.Value = "SLOT_YN";
            // 
            // cbo01_PRDT
            // 
            this.cbo01_PRDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRDT.FormattingEnabled = true;
            this.cbo01_PRDT.Location = new System.Drawing.Point(460, 13);
            this.cbo01_PRDT.Name = "cbo01_PRDT";
            this.cbo01_PRDT.Size = new System.Drawing.Size(109, 20);
            this.cbo01_PRDT.TabIndex = 99;
            // 
            // lbl01_PRDT
            // 
            this.lbl01_PRDT.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRDT.AutoFontSizeMinValue = 9F;
            this.lbl01_PRDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRDT.Location = new System.Drawing.Point(353, 13);
            this.lbl01_PRDT.Name = "lbl01_PRDT";
            this.lbl01_PRDT.Size = new System.Drawing.Size(102, 21);
            this.lbl01_PRDT.TabIndex = 98;
            this.lbl01_PRDT.Tag = null;
            this.lbl01_PRDT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PRDT.Value = "GOODS DIV";
            // 
            // cbo01_WHCD
            // 
            this.cbo01_WHCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_WHCD.FormattingEnabled = true;
            this.cbo01_WHCD.Location = new System.Drawing.Point(113, 13);
            this.cbo01_WHCD.Name = "cbo01_WHCD";
            this.cbo01_WHCD.Size = new System.Drawing.Size(234, 20);
            this.cbo01_WHCD.TabIndex = 99;
            // 
            // lbl01_WHCD
            // 
            this.lbl01_WHCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_WHCD.AutoFontSizeMinValue = 9F;
            this.lbl01_WHCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WHCD.Location = new System.Drawing.Point(6, 13);
            this.lbl01_WHCD.Name = "lbl01_WHCD";
            this.lbl01_WHCD.Size = new System.Drawing.Size(102, 21);
            this.lbl01_WHCD.TabIndex = 98;
            this.lbl01_WHCD.Tag = null;
            this.lbl01_WHCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WHCD.Value = "차종";
            // 
            // cbo01_DELIVERY_ABLE
            // 
            this.cbo01_DELIVERY_ABLE.DisplayMember = "Y";
            this.cbo01_DELIVERY_ABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DELIVERY_ABLE.FormattingEnabled = true;
            this.cbo01_DELIVERY_ABLE.Location = new System.Drawing.Point(1050, 13);
            this.cbo01_DELIVERY_ABLE.Name = "cbo01_DELIVERY_ABLE";
            this.cbo01_DELIVERY_ABLE.Size = new System.Drawing.Size(59, 20);
            this.cbo01_DELIVERY_ABLE.TabIndex = 97;
            // 
            // lbl01_DELIVERY_ABLE
            // 
            this.lbl01_DELIVERY_ABLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELIVERY_ABLE.AutoFontSizeMinValue = 9F;
            this.lbl01_DELIVERY_ABLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DELIVERY_ABLE.Location = new System.Drawing.Point(945, 13);
            this.lbl01_DELIVERY_ABLE.Name = "lbl01_DELIVERY_ABLE";
            this.lbl01_DELIVERY_ABLE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_DELIVERY_ABLE.TabIndex = 96;
            this.lbl01_DELIVERY_ABLE.Tag = null;
            this.lbl01_DELIVERY_ABLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DELIVERY_ABLE.Value = "DELIVERY_ABLE";
            // 
            // lbl01_LOCATION_NO
            // 
            this.lbl01_LOCATION_NO.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOCATION_NO.AutoFontSizeMinValue = 9F;
            this.lbl01_LOCATION_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LOCATION_NO.Location = new System.Drawing.Point(574, 13);
            this.lbl01_LOCATION_NO.Name = "lbl01_LOCATION_NO";
            this.lbl01_LOCATION_NO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LOCATION_NO.TabIndex = 69;
            this.lbl01_LOCATION_NO.Tag = null;
            this.lbl01_LOCATION_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LOCATION_NO.Value = "Area 코드";
            // 
            // txt01_LOCATION_NO
            // 
            this.txt01_LOCATION_NO.Location = new System.Drawing.Point(679, 13);
            this.txt01_LOCATION_NO.Name = "txt01_LOCATION_NO";
            this.txt01_LOCATION_NO.Size = new System.Drawing.Size(92, 21);
            this.txt01_LOCATION_NO.TabIndex = 68;
            this.txt01_LOCATION_NO.Tag = null;
            this.txt01_LOCATION_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_Query_KeyDown);
            // 
            // WM20443
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01_INSPEC_INFO);
            this.Controls.Add(this.groupBox1);
            this.Name = "WM20443";
            this.Size = new System.Drawing.Size(1360, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01_INSPEC_INFO, 0);
            this.grd01_INSPEC_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRT_SIZE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SLOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WHCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELIVERY_ABLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOCATION_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOCATION_NO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grd01_INSPEC_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOCATION_NO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LOCATION_NO;
        private DEV.Utility.Controls.AxComboBox cbo01_PRDT;
        private DEV.Utility.Controls.AxLabel lbl01_PRDT;
        private DEV.Utility.Controls.AxComboBox cbo01_WHCD;
        private DEV.Utility.Controls.AxLabel lbl01_WHCD;
        private DEV.Utility.Controls.AxComboBox cbo01_DELIVERY_ABLE;
        private DEV.Utility.Controls.AxLabel lbl01_DELIVERY_ABLE;
        private DEV.Utility.Controls.AxComboBox cbo01_SLOT_YN;
        private DEV.Utility.Controls.AxLabel lbl01_SLOT;
        private DEV.Utility.Controls.AxComboBox cbo01_PRT_SIZE;
        private DEV.Utility.Controls.AxLabel lbl01_PRT_SIZE;        
    }
}
