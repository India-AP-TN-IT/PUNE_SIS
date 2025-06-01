namespace Ax.SIS.BM.BM00.UI
{
    partial class BM20011
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
            this.cbo01_LINECD_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_LINECD_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_LINECD_LIST = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINENM = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk01DELETE_YN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.lbl01_DISPLAY_DEL_Y = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_LINENM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_LINECD = new Ax.DEV.Utility.Controls.AxTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD_DIV)).BeginInit();
            this.grp01_LINECD_LIST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINENM)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DISPLAY_DEL_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINENM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINECD)).BeginInit();
            this.SuspendLayout();
            // 
            // cbo01_LINECD_DIV
            // 
            this.cbo01_LINECD_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_LINECD_DIV.FormattingEnabled = true;
            this.cbo01_LINECD_DIV.Location = new System.Drawing.Point(385, 15);
            this.cbo01_LINECD_DIV.Name = "cbo01_LINECD_DIV";
            this.cbo01_LINECD_DIV.Size = new System.Drawing.Size(161, 20);
            this.cbo01_LINECD_DIV.TabIndex = 17;
            // 
            // lbl01_LINECD_DIV
            // 
            this.lbl01_LINECD_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD_DIV.Location = new System.Drawing.Point(262, 15);
            this.lbl01_LINECD_DIV.Name = "lbl01_LINECD_DIV";
            this.lbl01_LINECD_DIV.Size = new System.Drawing.Size(120, 21);
            this.lbl01_LINECD_DIV.TabIndex = 3;
            this.lbl01_LINECD_DIV.Tag = null;
            this.lbl01_LINECD_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grp01_LINECD_LIST
            // 
            this.grp01_LINECD_LIST.Controls.Add(this.grd01);
            this.grp01_LINECD_LIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_LINECD_LIST.Location = new System.Drawing.Point(0, 104);
            this.grp01_LINECD_LIST.Name = "grp01_LINECD_LIST";
            this.grp01_LINECD_LIST.Size = new System.Drawing.Size(1024, 664);
            this.grp01_LINECD_LIST.TabIndex = 8;
            this.grp01_LINECD_LIST.TabStop = false;
            this.grp01_LINECD_LIST.Text = "Line Code List";
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
            this.grd01.PopMenuVisible = false;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 644);
            this.grd01.TabIndex = 7;
            this.grd01.UseCustomHighlight = true;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(6, 15);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(120, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(129, 15);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(124, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(6, 41);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(120, 21);
            this.lbl01_LINECD.TabIndex = 2;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl01_LINENM
            // 
            this.lbl01_LINENM.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINENM.AutoFontSizeMinValue = 9F;
            this.lbl01_LINENM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINENM.Location = new System.Drawing.Point(262, 41);
            this.lbl01_LINENM.Name = "lbl01_LINENM";
            this.lbl01_LINENM.Size = new System.Drawing.Size(120, 21);
            this.lbl01_LINENM.TabIndex = 4;
            this.lbl01_LINENM.Tag = null;
            this.lbl01_LINENM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk01DELETE_YN);
            this.groupBox1.Controls.Add(this.lbl01_DISPLAY_DEL_Y);
            this.groupBox1.Controls.Add(this.txt01_LINENM);
            this.groupBox1.Controls.Add(this.lbl01_LINENM);
            this.groupBox1.Controls.Add(this.txt01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_LINECD);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Controls.Add(this.cbo01_LINECD_DIV);
            this.groupBox1.Controls.Add(this.lbl01_LINECD_DIV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 70);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // chk01DELETE_YN
            // 
            this.chk01DELETE_YN.AutoSize = true;
            this.chk01DELETE_YN.Checked = true;
            this.chk01DELETE_YN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01DELETE_YN.Location = new System.Drawing.Point(719, 45);
            this.chk01DELETE_YN.Name = "chk01DELETE_YN";
            this.chk01DELETE_YN.Size = new System.Drawing.Size(15, 14);
            this.chk01DELETE_YN.TabIndex = 63;
            this.chk01DELETE_YN.UseVisualStyleBackColor = true;
            // 
            // lbl01_DISPLAY_DEL_Y
            // 
            this.lbl01_DISPLAY_DEL_Y.AutoFontSizeMaxValue = 9F;
            this.lbl01_DISPLAY_DEL_Y.AutoFontSizeMinValue = 9F;
            this.lbl01_DISPLAY_DEL_Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DISPLAY_DEL_Y.Location = new System.Drawing.Point(593, 41);
            this.lbl01_DISPLAY_DEL_Y.Name = "lbl01_DISPLAY_DEL_Y";
            this.lbl01_DISPLAY_DEL_Y.Size = new System.Drawing.Size(120, 21);
            this.lbl01_DISPLAY_DEL_Y.TabIndex = 62;
            this.lbl01_DISPLAY_DEL_Y.Tag = null;
            this.lbl01_DISPLAY_DEL_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DISPLAY_DEL_Y.Value = "상태구분";
            // 
            // txt01_LINENM
            // 
            this.txt01_LINENM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_LINENM.Location = new System.Drawing.Point(385, 41);
            this.txt01_LINENM.Name = "txt01_LINENM";
            this.txt01_LINENM.Size = new System.Drawing.Size(200, 21);
            this.txt01_LINENM.TabIndex = 5;
            this.txt01_LINENM.Tag = null;
            // 
            // txt01_LINECD
            // 
            this.txt01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_LINECD.Location = new System.Drawing.Point(129, 41);
            this.txt01_LINECD.Name = "txt01_LINECD";
            this.txt01_LINECD.Size = new System.Drawing.Size(124, 21);
            this.txt01_LINECD.TabIndex = 3;
            this.txt01_LINECD.Tag = null;
            // 
            // BM20011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_LINECD_LIST);
            this.Controls.Add(this.groupBox1);
            this.Name = "BM20011";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_LINECD_LIST, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD_DIV)).EndInit();
            this.grp01_LINECD_LIST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINENM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DISPLAY_DEL_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINENM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINECD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_LINECD_DIV;
        private DEV.Utility.Controls.AxComboBox cbo01_LINECD_DIV;
        private System.Windows.Forms.GroupBox grp01_LINECD_LIST;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxTextBox txt01_LINENM;
        private DEV.Utility.Controls.AxLabel lbl01_LINENM;
        private DEV.Utility.Controls.AxTextBox txt01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxCheckBox chk01DELETE_YN;
        private DEV.Utility.Controls.AxLabel lbl01_DISPLAY_DEL_Y;

    }
}
