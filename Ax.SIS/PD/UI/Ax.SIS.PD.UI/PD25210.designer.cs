namespace Ax.SIS.PD.UI
{
    partial class PD25210
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD25210));
            this.grp01_PD25210_GRP1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk01DELETE_YN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_DISPLAY_DEL_Y = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_STACD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_NON_OPRCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_STAT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_NON_OPRCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grp01_PD25210_GRP2 = new System.Windows.Forms.GroupBox();
            this.chk01_OPTION4_PD25210 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk01_OPTION3_PD25210 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk01_OPTION2_PD25210 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk01_OPTION1_PD25210 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo02_STACD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_STAT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_NON_GROUPCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_NON_OPRNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_NON_GROUPCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_NON_OPRCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_NON_OPRNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_NON_OPRCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD25210_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DISPLAY_DEL_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NON_OPRCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STAT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NON_OPRCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.grp01_PD25210_GRP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_STAT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NON_GROUPCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NON_OPRNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NON_GROUPCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NON_OPRCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NON_OPRNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NON_OPRCD)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1110, 34);
            // 
            // grp01_PD25210_GRP1
            // 
            this.grp01_PD25210_GRP1.Controls.Add(this.grd01);
            this.grp01_PD25210_GRP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD25210_GRP1.Location = new System.Drawing.Point(0, 79);
            this.grp01_PD25210_GRP1.Name = "grp01_PD25210_GRP1";
            this.grp01_PD25210_GRP1.Size = new System.Drawing.Size(1110, 516);
            this.grp01_PD25210_GRP1.TabIndex = 16;
            this.grp01_PD25210_GRP1.TabStop = false;
            this.grp01_PD25210_GRP1.Text = "비가동 코드 목록";
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
            this.grd01.Size = new System.Drawing.Size(1104, 496);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.Click += new System.EventHandler(this.grd01_Click);
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk01DELETE_YN);
            this.groupBox1.Controls.Add(this.lbl01_DISPLAY_DEL_Y);
            this.groupBox1.Controls.Add(this.cbo01_STACD);
            this.groupBox1.Controls.Add(this.lbl01_NON_OPRCD);
            this.groupBox1.Controls.Add(this.lbl01_STAT_DIV);
            this.groupBox1.Controls.Add(this.txt01_NON_OPRCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1110, 45);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // chk01DELETE_YN
            // 
            this.chk01DELETE_YN.AutoSize = true;
            this.chk01DELETE_YN.Checked = true;
            this.chk01DELETE_YN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01DELETE_YN.Location = new System.Drawing.Point(830, 19);
            this.chk01DELETE_YN.Name = "chk01DELETE_YN";
            this.chk01DELETE_YN.Size = new System.Drawing.Size(15, 14);
            this.chk01DELETE_YN.TabIndex = 59;
            this.chk01DELETE_YN.UseVisualStyleBackColor = true;
            // 
            // lbl01_DISPLAY_DEL_Y
            // 
            this.lbl01_DISPLAY_DEL_Y.AutoFontSizeMaxValue = 9F;
            this.lbl01_DISPLAY_DEL_Y.AutoFontSizeMinValue = 9F;
            this.lbl01_DISPLAY_DEL_Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DISPLAY_DEL_Y.Location = new System.Drawing.Point(704, 15);
            this.lbl01_DISPLAY_DEL_Y.Name = "lbl01_DISPLAY_DEL_Y";
            this.lbl01_DISPLAY_DEL_Y.Size = new System.Drawing.Size(120, 21);
            this.lbl01_DISPLAY_DEL_Y.TabIndex = 58;
            this.lbl01_DISPLAY_DEL_Y.Tag = null;
            this.lbl01_DISPLAY_DEL_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DISPLAY_DEL_Y.Value = "상태구분";
            // 
            // cbo01_STACD
            // 
            this.cbo01_STACD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_STACD.FormattingEnabled = true;
            this.cbo01_STACD.Location = new System.Drawing.Point(568, 15);
            this.cbo01_STACD.Name = "cbo01_STACD";
            this.cbo01_STACD.Size = new System.Drawing.Size(130, 23);
            this.cbo01_STACD.TabIndex = 57;
            // 
            // lbl01_NON_OPRCD
            // 
            this.lbl01_NON_OPRCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_NON_OPRCD.AutoFontSizeMinValue = 9F;
            this.lbl01_NON_OPRCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_NON_OPRCD.Location = new System.Drawing.Point(247, 15);
            this.lbl01_NON_OPRCD.Name = "lbl01_NON_OPRCD";
            this.lbl01_NON_OPRCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_NON_OPRCD.TabIndex = 55;
            this.lbl01_NON_OPRCD.Tag = null;
            this.lbl01_NON_OPRCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_NON_OPRCD.Value = "비가동코드";
            // 
            // lbl01_STAT_DIV
            // 
            this.lbl01_STAT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_STAT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_STAT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STAT_DIV.Location = new System.Drawing.Point(462, 15);
            this.lbl01_STAT_DIV.Name = "lbl01_STAT_DIV";
            this.lbl01_STAT_DIV.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STAT_DIV.TabIndex = 56;
            this.lbl01_STAT_DIV.Tag = null;
            this.lbl01_STAT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STAT_DIV.Value = "상태구분";
            // 
            // txt01_NON_OPRCD
            // 
            this.txt01_NON_OPRCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_NON_OPRCD.Location = new System.Drawing.Point(353, 15);
            this.txt01_NON_OPRCD.Name = "txt01_NON_OPRCD";
            this.txt01_NON_OPRCD.Size = new System.Drawing.Size(100, 21);
            this.txt01_NON_OPRCD.TabIndex = 53;
            this.txt01_NON_OPRCD.Tag = null;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(7, 15);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 52;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(111, 15);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 23);
            this.cbo01_BIZCD.TabIndex = 51;
            // 
            // grp01_PD25210_GRP2
            // 
            this.grp01_PD25210_GRP2.Controls.Add(this.chk01_OPTION4_PD25210);
            this.grp01_PD25210_GRP2.Controls.Add(this.chk01_OPTION3_PD25210);
            this.grp01_PD25210_GRP2.Controls.Add(this.chk01_OPTION2_PD25210);
            this.grp01_PD25210_GRP2.Controls.Add(this.chk01_OPTION1_PD25210);
            this.grp01_PD25210_GRP2.Controls.Add(this.cbo02_STACD);
            this.grp01_PD25210_GRP2.Controls.Add(this.lbl02_STAT_DIV);
            this.grp01_PD25210_GRP2.Controls.Add(this.txt02_NON_GROUPCD);
            this.grp01_PD25210_GRP2.Controls.Add(this.txt02_NON_OPRNM);
            this.grp01_PD25210_GRP2.Controls.Add(this.lbl02_NON_GROUPCD);
            this.grp01_PD25210_GRP2.Controls.Add(this.txt02_NON_OPRCD);
            this.grp01_PD25210_GRP2.Controls.Add(this.lbl02_NON_OPRNM);
            this.grp01_PD25210_GRP2.Controls.Add(this.lbl02_NON_OPRCD);
            this.grp01_PD25210_GRP2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_PD25210_GRP2.Location = new System.Drawing.Point(0, 595);
            this.grp01_PD25210_GRP2.Name = "grp01_PD25210_GRP2";
            this.grp01_PD25210_GRP2.Size = new System.Drawing.Size(1110, 86);
            this.grp01_PD25210_GRP2.TabIndex = 15;
            this.grp01_PD25210_GRP2.TabStop = false;
            this.grp01_PD25210_GRP2.Text = "비가동 코드 정보";
            // 
            // chk01_OPTION4_PD25210
            // 
            this.chk01_OPTION4_PD25210.AutoSize = true;
            this.chk01_OPTION4_PD25210.Location = new System.Drawing.Point(1030, 59);
            this.chk01_OPTION4_PD25210.Name = "chk01_OPTION4_PD25210";
            this.chk01_OPTION4_PD25210.Size = new System.Drawing.Size(90, 19);
            this.chk01_OPTION4_PD25210.TabIndex = 94;
            this.chk01_OPTION4_PD25210.Text = "PAINT LINE";
            this.chk01_OPTION4_PD25210.UseVisualStyleBackColor = true;
            // 
            // chk01_OPTION3_PD25210
            // 
            this.chk01_OPTION3_PD25210.AutoSize = true;
            this.chk01_OPTION3_PD25210.Location = new System.Drawing.Point(1030, 34);
            this.chk01_OPTION3_PD25210.Name = "chk01_OPTION3_PD25210";
            this.chk01_OPTION3_PD25210.Size = new System.Drawing.Size(74, 19);
            this.chk01_OPTION3_PD25210.TabIndex = 93;
            this.chk01_OPTION3_PD25210.Text = "INJ LINE";
            this.chk01_OPTION3_PD25210.UseVisualStyleBackColor = true;
            // 
            // chk01_OPTION2_PD25210
            // 
            this.chk01_OPTION2_PD25210.AutoSize = true;
            this.chk01_OPTION2_PD25210.Location = new System.Drawing.Point(948, 59);
            this.chk01_OPTION2_PD25210.Name = "chk01_OPTION2_PD25210";
            this.chk01_OPTION2_PD25210.Size = new System.Drawing.Size(80, 19);
            this.chk01_OPTION2_PD25210.TabIndex = 92;
            this.chk01_OPTION2_PD25210.Text = "SFG LINE";
            this.chk01_OPTION2_PD25210.UseVisualStyleBackColor = true;
            // 
            // chk01_OPTION1_PD25210
            // 
            this.chk01_OPTION1_PD25210.AutoSize = true;
            this.chk01_OPTION1_PD25210.Location = new System.Drawing.Point(948, 34);
            this.chk01_OPTION1_PD25210.Name = "chk01_OPTION1_PD25210";
            this.chk01_OPTION1_PD25210.Size = new System.Drawing.Size(72, 19);
            this.chk01_OPTION1_PD25210.TabIndex = 70;
            this.chk01_OPTION1_PD25210.Text = "FG LINE";
            this.chk01_OPTION1_PD25210.UseVisualStyleBackColor = true;
            // 
            // cbo02_STACD
            // 
            this.cbo02_STACD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_STACD.FormattingEnabled = true;
            this.cbo02_STACD.Location = new System.Drawing.Point(784, 34);
            this.cbo02_STACD.Name = "cbo02_STACD";
            this.cbo02_STACD.Size = new System.Drawing.Size(130, 23);
            this.cbo02_STACD.TabIndex = 69;
            // 
            // lbl02_STAT_DIV
            // 
            this.lbl02_STAT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl02_STAT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl02_STAT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_STAT_DIV.Location = new System.Drawing.Point(678, 34);
            this.lbl02_STAT_DIV.Name = "lbl02_STAT_DIV";
            this.lbl02_STAT_DIV.Size = new System.Drawing.Size(100, 21);
            this.lbl02_STAT_DIV.TabIndex = 68;
            this.lbl02_STAT_DIV.Tag = null;
            this.lbl02_STAT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_STAT_DIV.Value = "상태구분";
            // 
            // txt02_NON_GROUPCD
            // 
            this.txt02_NON_GROUPCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_NON_GROUPCD.Location = new System.Drawing.Point(577, 34);
            this.txt02_NON_GROUPCD.Name = "txt02_NON_GROUPCD";
            this.txt02_NON_GROUPCD.Size = new System.Drawing.Size(97, 21);
            this.txt02_NON_GROUPCD.TabIndex = 67;
            this.txt02_NON_GROUPCD.Tag = null;
            // 
            // txt02_NON_OPRNM
            // 
            this.txt02_NON_OPRNM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_NON_OPRNM.Location = new System.Drawing.Point(334, 34);
            this.txt02_NON_OPRNM.Name = "txt02_NON_OPRNM";
            this.txt02_NON_OPRNM.ReadOnly = true;
            this.txt02_NON_OPRNM.Size = new System.Drawing.Size(130, 21);
            this.txt02_NON_OPRNM.TabIndex = 67;
            this.txt02_NON_OPRNM.Tag = null;
            // 
            // lbl02_NON_GROUPCD
            // 
            this.lbl02_NON_GROUPCD.AutoFontSizeMaxValue = 9F;
            this.lbl02_NON_GROUPCD.AutoFontSizeMinValue = 9F;
            this.lbl02_NON_GROUPCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_NON_GROUPCD.Location = new System.Drawing.Point(471, 34);
            this.lbl02_NON_GROUPCD.Name = "lbl02_NON_GROUPCD";
            this.lbl02_NON_GROUPCD.Size = new System.Drawing.Size(100, 21);
            this.lbl02_NON_GROUPCD.TabIndex = 66;
            this.lbl02_NON_GROUPCD.Tag = null;
            this.lbl02_NON_GROUPCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_NON_GROUPCD.Value = "비가동그룹코드";
            // 
            // txt02_NON_OPRCD
            // 
            this.txt02_NON_OPRCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_NON_OPRCD.Location = new System.Drawing.Point(122, 34);
            this.txt02_NON_OPRCD.Name = "txt02_NON_OPRCD";
            this.txt02_NON_OPRCD.Size = new System.Drawing.Size(100, 21);
            this.txt02_NON_OPRCD.TabIndex = 64;
            this.txt02_NON_OPRCD.Tag = null;
            this.txt02_NON_OPRCD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt02_NON_OPRCD_KeyUp);
            this.txt02_NON_OPRCD.Leave += new System.EventHandler(this.txt02_NON_OPRCD_Leave);
            // 
            // lbl02_NON_OPRNM
            // 
            this.lbl02_NON_OPRNM.AutoFontSizeMaxValue = 9F;
            this.lbl02_NON_OPRNM.AutoFontSizeMinValue = 9F;
            this.lbl02_NON_OPRNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_NON_OPRNM.Location = new System.Drawing.Point(228, 34);
            this.lbl02_NON_OPRNM.Name = "lbl02_NON_OPRNM";
            this.lbl02_NON_OPRNM.Size = new System.Drawing.Size(100, 21);
            this.lbl02_NON_OPRNM.TabIndex = 66;
            this.lbl02_NON_OPRNM.Tag = null;
            this.lbl02_NON_OPRNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_NON_OPRNM.Value = "비가동명";
            // 
            // lbl02_NON_OPRCD
            // 
            this.lbl02_NON_OPRCD.AutoFontSizeMaxValue = 9F;
            this.lbl02_NON_OPRCD.AutoFontSizeMinValue = 9F;
            this.lbl02_NON_OPRCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_NON_OPRCD.Location = new System.Drawing.Point(18, 34);
            this.lbl02_NON_OPRCD.Name = "lbl02_NON_OPRCD";
            this.lbl02_NON_OPRCD.Size = new System.Drawing.Size(100, 21);
            this.lbl02_NON_OPRCD.TabIndex = 65;
            this.lbl02_NON_OPRCD.Tag = null;
            this.lbl02_NON_OPRCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_NON_OPRCD.Value = "비가동코드";
            // 
            // PD25210
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD25210_GRP1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp01_PD25210_GRP2);
            this.Name = "PD25210";
            this.Size = new System.Drawing.Size(1110, 681);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grp01_PD25210_GRP2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD25210_GRP1, 0);
            this.grp01_PD25210_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DISPLAY_DEL_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NON_OPRCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STAT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NON_OPRCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.grp01_PD25210_GRP2.ResumeLayout(false);
            this.grp01_PD25210_GRP2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_STAT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NON_GROUPCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NON_OPRNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NON_GROUPCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_NON_OPRCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NON_OPRNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_NON_OPRCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD25210_GRP1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private System.Windows.Forms.GroupBox grp01_PD25210_GRP2;
        private DEV.Utility.Controls.AxLabel lbl01_NON_OPRCD;
        private DEV.Utility.Controls.AxLabel lbl01_STAT_DIV;
        private DEV.Utility.Controls.AxTextBox txt01_NON_OPRCD;
        private DEV.Utility.Controls.AxTextBox txt02_NON_OPRNM;
        private DEV.Utility.Controls.AxTextBox txt02_NON_OPRCD;
        private DEV.Utility.Controls.AxLabel lbl02_NON_OPRNM;
        private DEV.Utility.Controls.AxLabel lbl02_NON_OPRCD;
        private DEV.Utility.Controls.AxComboBox cbo01_STACD;
        private DEV.Utility.Controls.AxComboBox cbo02_STACD;
        private DEV.Utility.Controls.AxLabel lbl02_STAT_DIV;
        private DEV.Utility.Controls.AxTextBox txt02_NON_GROUPCD;
        private DEV.Utility.Controls.AxLabel lbl02_NON_GROUPCD;
        private DEV.Utility.Controls.AxLabel lbl01_DISPLAY_DEL_Y;
        private DEV.Utility.Controls.AxCheckBox chk01DELETE_YN;
        private DEV.Utility.Controls.AxCheckBox chk01_OPTION1_PD25210;
        private DEV.Utility.Controls.AxCheckBox chk01_OPTION4_PD25210;
        private DEV.Utility.Controls.AxCheckBox chk01_OPTION3_PD25210;
        private DEV.Utility.Controls.AxCheckBox chk01_OPTION2_PD25210;
    }
}
