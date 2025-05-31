namespace Ax.SIS.PD.UI
{
    partial class PD20420
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
            this.grp01_PD20420_GRP1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk01_ALL_CHK = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_MASTER_ITEM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_MASTER_ITEM = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt01_MOLDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MOLDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_MOLDNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_SUB_ITEM = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SUB_ITEM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grp01_PD20420_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MASTER_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SUB_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD20420_GRP1
            // 
            this.grp01_PD20420_GRP1.Controls.Add(this.grd01);
            this.grp01_PD20420_GRP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD20420_GRP1.Location = new System.Drawing.Point(0, 106);
            this.grp01_PD20420_GRP1.Name = "grp01_PD20420_GRP1";
            this.grp01_PD20420_GRP1.Size = new System.Drawing.Size(1024, 407);
            this.grp01_PD20420_GRP1.TabIndex = 8;
            this.grp01_PD20420_GRP1.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 387);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_BeforeEdit);
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.SetupEditor += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_SetupEditor);
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk01_ALL_CHK);
            this.groupBox1.Controls.Add(this.lbl01_MASTER_ITEM);
            this.groupBox1.Controls.Add(this.cbo01_MASTER_ITEM);
            this.groupBox1.Controls.Add(this.txt01_MOLDNO);
            this.groupBox1.Controls.Add(this.lbl01_MOLDNO);
            this.groupBox1.Controls.Add(this.cdx01_MOLDNO);
            this.groupBox1.Controls.Add(this.cbo01_SUB_ITEM);
            this.groupBox1.Controls.Add(this.lbl01_SUB_ITEM);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 72);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // chk01_ALL_CHK
            // 
            this.chk01_ALL_CHK.AutoSize = true;
            this.chk01_ALL_CHK.Location = new System.Drawing.Point(512, 41);
            this.chk01_ALL_CHK.Name = "chk01_ALL_CHK";
            this.chk01_ALL_CHK.Size = new System.Drawing.Size(72, 16);
            this.chk01_ALL_CHK.TabIndex = 122;
            this.chk01_ALL_CHK.Text = "전체선택";
            this.chk01_ALL_CHK.UseVisualStyleBackColor = true;
            this.chk01_ALL_CHK.CheckedChanged += new System.EventHandler(this.chk01_CHECK_CheckedChanged);
            // 
            // lbl01_MASTER_ITEM
            // 
            this.lbl01_MASTER_ITEM.AutoFontSizeMaxValue = 9F;
            this.lbl01_MASTER_ITEM.AutoFontSizeMinValue = 9F;
            this.lbl01_MASTER_ITEM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MASTER_ITEM.Location = new System.Drawing.Point(6, 38);
            this.lbl01_MASTER_ITEM.Name = "lbl01_MASTER_ITEM";
            this.lbl01_MASTER_ITEM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MASTER_ITEM.TabIndex = 55;
            this.lbl01_MASTER_ITEM.Tag = null;
            this.lbl01_MASTER_ITEM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MASTER_ITEM.Value = "대항목";
            // 
            // cbo01_MASTER_ITEM
            // 
            this.cbo01_MASTER_ITEM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_MASTER_ITEM.FormattingEnabled = true;
            this.cbo01_MASTER_ITEM.Location = new System.Drawing.Point(112, 38);
            this.cbo01_MASTER_ITEM.Name = "cbo01_MASTER_ITEM";
            this.cbo01_MASTER_ITEM.Size = new System.Drawing.Size(126, 20);
            this.cbo01_MASTER_ITEM.TabIndex = 56;
            this.cbo01_MASTER_ITEM.SelectedValueChanged += new System.EventHandler(this.cbo01_MASTER_ITEM_SelectedValueChanged);
            // 
            // txt01_MOLDNO
            // 
            this.txt01_MOLDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_MOLDNO.Location = new System.Drawing.Point(352, 14);
            this.txt01_MOLDNO.Name = "txt01_MOLDNO";
            this.txt01_MOLDNO.Size = new System.Drawing.Size(154, 21);
            this.txt01_MOLDNO.TabIndex = 92;
            this.txt01_MOLDNO.Tag = null;
            // 
            // lbl01_MOLDNO
            // 
            this.lbl01_MOLDNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_MOLDNO.AutoFontSizeMinValue = 9F;
            this.lbl01_MOLDNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MOLDNO.Location = new System.Drawing.Point(246, 14);
            this.lbl01_MOLDNO.Name = "lbl01_MOLDNO";
            this.lbl01_MOLDNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MOLDNO.TabIndex = 91;
            this.lbl01_MOLDNO.Tag = null;
            this.lbl01_MOLDNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MOLDNO.Value = "금형번호";
            // 
            // cdx01_MOLDNO
            // 
            this.cdx01_MOLDNO.BackColor = System.Drawing.Color.LightCyan;
            this.cdx01_MOLDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_MOLDNO.CodeParameterName = "CODE";
            this.cdx01_MOLDNO.CodeTextBoxReadOnly = false;
            this.cdx01_MOLDNO.CodeTextBoxVisible = true;
            this.cdx01_MOLDNO.CodeTextBoxWidth = 90;
            this.cdx01_MOLDNO.HEPopupHelper = null;
            this.cdx01_MOLDNO.Location = new System.Drawing.Point(654, 39);
            this.cdx01_MOLDNO.Name = "cdx01_MOLDNO";
            this.cdx01_MOLDNO.NameParameterName = "NAME";
            this.cdx01_MOLDNO.NameTextBoxReadOnly = false;
            this.cdx01_MOLDNO.NameTextBoxVisible = true;
            this.cdx01_MOLDNO.PopupButtonReadOnly = false;
            this.cdx01_MOLDNO.PopupTitle = "";
            this.cdx01_MOLDNO.PrefixCode = "";
            this.cdx01_MOLDNO.Size = new System.Drawing.Size(248, 21);
            this.cdx01_MOLDNO.TabIndex = 90;
            this.cdx01_MOLDNO.Tag = null;
            this.cdx01_MOLDNO.Visible = false;
            // 
            // cbo01_SUB_ITEM
            // 
            this.cbo01_SUB_ITEM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SUB_ITEM.FormattingEnabled = true;
            this.cbo01_SUB_ITEM.Location = new System.Drawing.Point(352, 38);
            this.cbo01_SUB_ITEM.Name = "cbo01_SUB_ITEM";
            this.cbo01_SUB_ITEM.Size = new System.Drawing.Size(154, 20);
            this.cbo01_SUB_ITEM.TabIndex = 60;
            this.cbo01_SUB_ITEM.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // lbl01_SUB_ITEM
            // 
            this.lbl01_SUB_ITEM.AutoFontSizeMaxValue = 9F;
            this.lbl01_SUB_ITEM.AutoFontSizeMinValue = 9F;
            this.lbl01_SUB_ITEM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SUB_ITEM.Location = new System.Drawing.Point(246, 39);
            this.lbl01_SUB_ITEM.Name = "lbl01_SUB_ITEM";
            this.lbl01_SUB_ITEM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SUB_ITEM.TabIndex = 59;
            this.lbl01_SUB_ITEM.Tag = null;
            this.lbl01_SUB_ITEM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SUB_ITEM.Value = "조건항목";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 54;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(110, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(128, 20);
            this.cbo01_BIZCD.TabIndex = 53;
            this.cbo01_BIZCD.SelectedValueChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd02);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 518);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 250);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(1018, 230);
            this.grd02.TabIndex = 8;
            this.grd02.UseCustomHighlight = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 513);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1024, 5);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // PD20420
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD20420_GRP1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20420";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.grp01_PD20420_GRP1, 0);
            this.grp01_PD20420_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MASTER_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SUB_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD20420_GRP1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SUB_ITEM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SUB_ITEM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_MASTER_ITEM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MASTER_ITEM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_MOLDNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MOLDNO;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_MOLDNO;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_ALL_CHK;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.Splitter splitter1;
    }
}
