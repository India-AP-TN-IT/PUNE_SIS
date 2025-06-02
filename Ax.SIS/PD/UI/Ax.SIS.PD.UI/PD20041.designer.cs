namespace Ax.SIS.PD.UI
{
    partial class PD20041
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20041));
            this.grp01_PD20041_GRP1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk01DELETE_YN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_DISPLAY_DEL_Y = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_MOLDNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MOLDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_MOLDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MOLDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD20041_GRP2 = new System.Windows.Forms.GroupBox();
            this.txt01_MCPOS = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MCPOS = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_REP_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_REP_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_MOLDNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_MOLDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_MOLDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_MOLDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.axTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD20041_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DISPLAY_DEL_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.grp01_PD20041_GRP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MCPOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MCPOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_REP_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_REP_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_MOLDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOLDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1337, 34);
            // 
            // grp01_PD20041_GRP1
            // 
            this.grp01_PD20041_GRP1.Controls.Add(this.grd01);
            this.grp01_PD20041_GRP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD20041_GRP1.Location = new System.Drawing.Point(0, 79);
            this.grp01_PD20041_GRP1.Name = "grp01_PD20041_GRP1";
            this.grp01_PD20041_GRP1.Size = new System.Drawing.Size(1337, 605);
            this.grp01_PD20041_GRP1.TabIndex = 1;
            this.grp01_PD20041_GRP1.TabStop = false;
            this.grp01_PD20041_GRP1.Text = "금형 목록";
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
            this.grd01.Size = new System.Drawing.Size(1331, 585);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk01DELETE_YN);
            this.groupBox2.Controls.Add(this.lbl01_DISPLAY_DEL_Y);
            this.groupBox2.Controls.Add(this.txt01_MOLDNM);
            this.groupBox2.Controls.Add(this.lbl01_MOLDNM);
            this.groupBox2.Controls.Add(this.txt01_MOLDNO);
            this.groupBox2.Controls.Add(this.lbl01_MOLDNO);
            this.groupBox2.Controls.Add(this.cbo01_BIZCD);
            this.groupBox2.Controls.Add(this.lbl01_BIZNM);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1337, 45);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // chk01DELETE_YN
            // 
            this.chk01DELETE_YN.AutoSize = true;
            this.chk01DELETE_YN.Checked = true;
            this.chk01DELETE_YN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01DELETE_YN.Location = new System.Drawing.Point(922, 18);
            this.chk01DELETE_YN.Name = "chk01DELETE_YN";
            this.chk01DELETE_YN.Size = new System.Drawing.Size(15, 14);
            this.chk01DELETE_YN.TabIndex = 61;
            this.chk01DELETE_YN.UseVisualStyleBackColor = true;
            // 
            // lbl01_DISPLAY_DEL_Y
            // 
            this.lbl01_DISPLAY_DEL_Y.AutoFontSizeMaxValue = 9F;
            this.lbl01_DISPLAY_DEL_Y.AutoFontSizeMinValue = 9F;
            this.lbl01_DISPLAY_DEL_Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DISPLAY_DEL_Y.Location = new System.Drawing.Point(796, 15);
            this.lbl01_DISPLAY_DEL_Y.Name = "lbl01_DISPLAY_DEL_Y";
            this.lbl01_DISPLAY_DEL_Y.Size = new System.Drawing.Size(120, 21);
            this.lbl01_DISPLAY_DEL_Y.TabIndex = 60;
            this.lbl01_DISPLAY_DEL_Y.Tag = null;
            this.lbl01_DISPLAY_DEL_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DISPLAY_DEL_Y.Value = "상태구분";
            // 
            // txt01_MOLDNM
            // 
            this.txt01_MOLDNM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_MOLDNM.Location = new System.Drawing.Point(566, 15);
            this.txt01_MOLDNM.Name = "txt01_MOLDNM";
            this.txt01_MOLDNM.Size = new System.Drawing.Size(224, 21);
            this.txt01_MOLDNM.TabIndex = 5;
            this.txt01_MOLDNM.Tag = null;
            // 
            // lbl01_MOLDNM
            // 
            this.lbl01_MOLDNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_MOLDNM.AutoFontSizeMinValue = 9F;
            this.lbl01_MOLDNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MOLDNM.Location = new System.Drawing.Point(460, 15);
            this.lbl01_MOLDNM.Name = "lbl01_MOLDNM";
            this.lbl01_MOLDNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MOLDNM.TabIndex = 4;
            this.lbl01_MOLDNM.Tag = null;
            this.lbl01_MOLDNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MOLDNM.Value = "금형명";
            // 
            // txt01_MOLDNO
            // 
            this.txt01_MOLDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_MOLDNO.Location = new System.Drawing.Point(354, 15);
            this.txt01_MOLDNO.Name = "txt01_MOLDNO";
            this.txt01_MOLDNO.Size = new System.Drawing.Size(100, 21);
            this.txt01_MOLDNO.TabIndex = 3;
            this.txt01_MOLDNO.Tag = null;
            // 
            // lbl01_MOLDNO
            // 
            this.lbl01_MOLDNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_MOLDNO.AutoFontSizeMinValue = 9F;
            this.lbl01_MOLDNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MOLDNO.Location = new System.Drawing.Point(248, 15);
            this.lbl01_MOLDNO.Name = "lbl01_MOLDNO";
            this.lbl01_MOLDNO.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MOLDNO.TabIndex = 2;
            this.lbl01_MOLDNO.Tag = null;
            this.lbl01_MOLDNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MOLDNO.Value = "금형번호";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 15);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 23);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(6, 15);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // grp01_PD20041_GRP2
            // 
            this.grp01_PD20041_GRP2.Controls.Add(this.axTextBox1);
            this.grp01_PD20041_GRP2.Controls.Add(this.axLabel1);
            this.grp01_PD20041_GRP2.Controls.Add(this.txt01_MCPOS);
            this.grp01_PD20041_GRP2.Controls.Add(this.lbl01_MCPOS);
            this.grp01_PD20041_GRP2.Controls.Add(this.cdx01_REP_LINECD);
            this.grp01_PD20041_GRP2.Controls.Add(this.lbl01_REP_LINECD);
            this.grp01_PD20041_GRP2.Controls.Add(this.txt02_MOLDNM);
            this.grp01_PD20041_GRP2.Controls.Add(this.txt02_MOLDNO);
            this.grp01_PD20041_GRP2.Controls.Add(this.lbl02_MOLDNM);
            this.grp01_PD20041_GRP2.Controls.Add(this.lbl02_MOLDNO);
            this.grp01_PD20041_GRP2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_PD20041_GRP2.Location = new System.Drawing.Point(0, 684);
            this.grp01_PD20041_GRP2.Name = "grp01_PD20041_GRP2";
            this.grp01_PD20041_GRP2.Size = new System.Drawing.Size(1337, 84);
            this.grp01_PD20041_GRP2.TabIndex = 8;
            this.grp01_PD20041_GRP2.TabStop = false;
            this.grp01_PD20041_GRP2.Text = "금형 정보";
            // 
            // txt01_MCPOS
            // 
            this.txt01_MCPOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_MCPOS.Location = new System.Drawing.Point(1141, 17);
            this.txt01_MCPOS.Name = "txt01_MCPOS";
            this.txt01_MCPOS.Size = new System.Drawing.Size(153, 21);
            this.txt01_MCPOS.TabIndex = 18;
            this.txt01_MCPOS.Tag = null;
            // 
            // lbl01_MCPOS
            // 
            this.lbl01_MCPOS.AutoFontSizeMaxValue = 9F;
            this.lbl01_MCPOS.AutoFontSizeMinValue = 9F;
            this.lbl01_MCPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MCPOS.Location = new System.Drawing.Point(1035, 17);
            this.lbl01_MCPOS.Name = "lbl01_MCPOS";
            this.lbl01_MCPOS.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MCPOS.TabIndex = 17;
            this.lbl01_MCPOS.Tag = null;
            this.lbl01_MCPOS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MCPOS.Value = "MC/POS";
            // 
            // cdx01_REP_LINECD
            // 
            this.cdx01_REP_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_REP_LINECD.CodeParameterName = "CODE";
            this.cdx01_REP_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_REP_LINECD.CodeTextBoxVisible = true;
            this.cdx01_REP_LINECD.CodeTextBoxWidth = 60;
            this.cdx01_REP_LINECD.HEPopupHelper = null;
            this.cdx01_REP_LINECD.Location = new System.Drawing.Point(761, 17);
            this.cdx01_REP_LINECD.Name = "cdx01_REP_LINECD";
            this.cdx01_REP_LINECD.NameParameterName = "NAME";
            this.cdx01_REP_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_REP_LINECD.NameTextBoxVisible = true;
            this.cdx01_REP_LINECD.PopupButtonReadOnly = false;
            this.cdx01_REP_LINECD.PopupTitle = "";
            this.cdx01_REP_LINECD.PrefixCode = "";
            this.cdx01_REP_LINECD.Size = new System.Drawing.Size(267, 21);
            this.cdx01_REP_LINECD.TabIndex = 16;
            this.cdx01_REP_LINECD.Tag = null;
            // 
            // lbl01_REP_LINECD
            // 
            this.lbl01_REP_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_REP_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_REP_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_REP_LINECD.Location = new System.Drawing.Point(615, 17);
            this.lbl01_REP_LINECD.Name = "lbl01_REP_LINECD";
            this.lbl01_REP_LINECD.Size = new System.Drawing.Size(140, 21);
            this.lbl01_REP_LINECD.TabIndex = 15;
            this.lbl01_REP_LINECD.Tag = null;
            this.lbl01_REP_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_REP_LINECD.Value = "대표라인코드";
            // 
            // txt02_MOLDNM
            // 
            this.txt02_MOLDNM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_MOLDNM.Location = new System.Drawing.Point(385, 17);
            this.txt02_MOLDNM.Name = "txt02_MOLDNM";
            this.txt02_MOLDNM.Size = new System.Drawing.Size(224, 21);
            this.txt02_MOLDNM.TabIndex = 14;
            this.txt02_MOLDNM.Tag = null;
            // 
            // txt02_MOLDNO
            // 
            this.txt02_MOLDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_MOLDNO.Location = new System.Drawing.Point(112, 17);
            this.txt02_MOLDNO.Name = "txt02_MOLDNO";
            this.txt02_MOLDNO.Size = new System.Drawing.Size(161, 21);
            this.txt02_MOLDNO.TabIndex = 13;
            this.txt02_MOLDNO.Tag = null;
            // 
            // lbl02_MOLDNM
            // 
            this.lbl02_MOLDNM.AutoFontSizeMaxValue = 9F;
            this.lbl02_MOLDNM.AutoFontSizeMinValue = 9F;
            this.lbl02_MOLDNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_MOLDNM.Location = new System.Drawing.Point(279, 17);
            this.lbl02_MOLDNM.Name = "lbl02_MOLDNM";
            this.lbl02_MOLDNM.Size = new System.Drawing.Size(100, 21);
            this.lbl02_MOLDNM.TabIndex = 7;
            this.lbl02_MOLDNM.Tag = null;
            this.lbl02_MOLDNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_MOLDNM.Value = "금형명";
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
            // axTextBox1
            // 
            this.axTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.axTextBox1.Location = new System.Drawing.Point(113, 44);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(153, 21);
            this.axTextBox1.TabIndex = 20;
            this.axTextBox1.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(7, 44);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(100, 21);
            this.axLabel1.TabIndex = 19;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "UPH";
            // 
            // PD20041
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD20041_GRP1);
            this.Controls.Add(this.grp01_PD20041_GRP2);
            this.Controls.Add(this.groupBox2);
            this.Name = "PD20041";
            this.Size = new System.Drawing.Size(1337, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.grp01_PD20041_GRP2, 0);
            this.Controls.SetChildIndex(this.grp01_PD20041_GRP1, 0);
            this.grp01_PD20041_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DISPLAY_DEL_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.grp01_PD20041_GRP2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MCPOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MCPOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_REP_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_REP_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_MOLDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOLDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD20041_GRP1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox2;
        private DEV.Utility.Controls.AxTextBox txt01_MOLDNM;
        private DEV.Utility.Controls.AxLabel lbl01_MOLDNM;
        private DEV.Utility.Controls.AxTextBox txt01_MOLDNO;
        private DEV.Utility.Controls.AxLabel lbl01_MOLDNO;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private System.Windows.Forms.GroupBox grp01_PD20041_GRP2;
        private DEV.Utility.Controls.AxTextBox txt02_MOLDNM;
        private DEV.Utility.Controls.AxTextBox txt02_MOLDNO;
        private DEV.Utility.Controls.AxLabel lbl02_MOLDNM;
        private DEV.Utility.Controls.AxLabel lbl02_MOLDNO;
        private DEV.Utility.Controls.AxCodeBox cdx01_REP_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_REP_LINECD;
        private DEV.Utility.Controls.AxCheckBox chk01DELETE_YN;
        private DEV.Utility.Controls.AxLabel lbl01_DISPLAY_DEL_Y;
        private DEV.Utility.Controls.AxTextBox txt01_MCPOS;
        private DEV.Utility.Controls.AxLabel lbl01_MCPOS;
        private DEV.Utility.Controls.AxTextBox axTextBox1;
        private DEV.Utility.Controls.AxLabel axLabel1;
    }
}
