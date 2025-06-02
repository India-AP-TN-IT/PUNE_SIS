namespace Ax.SIS.PD.UI
{
    partial class PD25130
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
            this.grp01_WORK_DIVCD_LIST = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_DIRE_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_WORK_DIVCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DIRE_DIVNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_WORK_DIV = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grp01_MAN_WORK_INFO = new System.Windows.Forms.GroupBox();
            this.nme02_SORT_SEQ = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.lbl02_SORT_SEQ = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo02_DIRE_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_DIRE_DIVNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_WORK_DIV_NM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_WORK_DIV = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_WORK_DIVCD_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_WORK_DIVCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_WORK_DIVCD_LIST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DIVCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DIRE_DIVNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_WORK_DIV)).BeginInit();
            this.grp01_MAN_WORK_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nme02_SORT_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SORT_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DIRE_DIVNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_WORK_DIV_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_WORK_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DIVCD_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_WORK_DIVCD)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_WORK_DIVCD_LIST
            // 
            this.grp01_WORK_DIVCD_LIST.Controls.Add(this.grd01);
            this.grp01_WORK_DIVCD_LIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_WORK_DIVCD_LIST.Location = new System.Drawing.Point(0, 83);
            this.grp01_WORK_DIVCD_LIST.Name = "grp01_WORK_DIVCD_LIST";
            this.grp01_WORK_DIVCD_LIST.Size = new System.Drawing.Size(1024, 605);
            this.grp01_WORK_DIVCD_LIST.TabIndex = 16;
            this.grp01_WORK_DIVCD_LIST.TabStop = false;
            this.grp01_WORK_DIVCD_LIST.Text = "작업 구분코드 목록";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 585);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_DIRE_DIV);
            this.groupBox1.Controls.Add(this.lbl01_WORK_DIVCD);
            this.groupBox1.Controls.Add(this.lbl01_DIRE_DIVNM);
            this.groupBox1.Controls.Add(this.txt01_WORK_DIV);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 49);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_DIRE_DIV
            // 
            this.cbo01_DIRE_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DIRE_DIV.FormattingEnabled = true;
            this.cbo01_DIRE_DIV.Location = new System.Drawing.Point(336, 17);
            this.cbo01_DIRE_DIV.Name = "cbo01_DIRE_DIV";
            this.cbo01_DIRE_DIV.Size = new System.Drawing.Size(130, 20);
            this.cbo01_DIRE_DIV.TabIndex = 57;
            // 
            // lbl01_WORK_DIVCD
            // 
            this.lbl01_WORK_DIVCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORK_DIVCD.AutoFontSizeMinValue = 9F;
            this.lbl01_WORK_DIVCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WORK_DIVCD.Location = new System.Drawing.Point(15, 17);
            this.lbl01_WORK_DIVCD.Name = "lbl01_WORK_DIVCD";
            this.lbl01_WORK_DIVCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_WORK_DIVCD.TabIndex = 55;
            this.lbl01_WORK_DIVCD.Tag = null;
            this.lbl01_WORK_DIVCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WORK_DIVCD.Value = "작업구분코드";
            // 
            // lbl01_DIRE_DIVNM
            // 
            this.lbl01_DIRE_DIVNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_DIRE_DIVNM.AutoFontSizeMinValue = 9F;
            this.lbl01_DIRE_DIVNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DIRE_DIVNM.Location = new System.Drawing.Point(230, 17);
            this.lbl01_DIRE_DIVNM.Name = "lbl01_DIRE_DIVNM";
            this.lbl01_DIRE_DIVNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_DIRE_DIVNM.TabIndex = 56;
            this.lbl01_DIRE_DIVNM.Tag = null;
            this.lbl01_DIRE_DIVNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DIRE_DIVNM.Value = "직간접구분";
            // 
            // txt01_WORK_DIV
            // 
            this.txt01_WORK_DIV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_WORK_DIV.Location = new System.Drawing.Point(121, 17);
            this.txt01_WORK_DIV.Name = "txt01_WORK_DIV";
            this.txt01_WORK_DIV.Size = new System.Drawing.Size(100, 21);
            this.txt01_WORK_DIV.TabIndex = 53;
            this.txt01_WORK_DIV.Tag = null;
            // 
            // grp01_MAN_WORK_INFO
            // 
            this.grp01_MAN_WORK_INFO.Controls.Add(this.nme02_SORT_SEQ);
            this.grp01_MAN_WORK_INFO.Controls.Add(this.lbl02_SORT_SEQ);
            this.grp01_MAN_WORK_INFO.Controls.Add(this.cbo02_DIRE_DIV);
            this.grp01_MAN_WORK_INFO.Controls.Add(this.lbl02_DIRE_DIVNM);
            this.grp01_MAN_WORK_INFO.Controls.Add(this.txt01_WORK_DIV_NM);
            this.grp01_MAN_WORK_INFO.Controls.Add(this.txt02_WORK_DIV);
            this.grp01_MAN_WORK_INFO.Controls.Add(this.lbl01_WORK_DIVCD_NM);
            this.grp01_MAN_WORK_INFO.Controls.Add(this.lbl02_WORK_DIVCD);
            this.grp01_MAN_WORK_INFO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_MAN_WORK_INFO.Location = new System.Drawing.Point(0, 688);
            this.grp01_MAN_WORK_INFO.Name = "grp01_MAN_WORK_INFO";
            this.grp01_MAN_WORK_INFO.Size = new System.Drawing.Size(1024, 80);
            this.grp01_MAN_WORK_INFO.TabIndex = 15;
            this.grp01_MAN_WORK_INFO.TabStop = false;
            this.grp01_MAN_WORK_INFO.Text = "공수 작업코드 정보";
            // 
            // nme02_SORT_SEQ
            // 
            this.nme02_SORT_SEQ.DisplayFormat.CustomFormat = "###,###,###,###,###,##0";
            this.nme02_SORT_SEQ.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_SORT_SEQ.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_SORT_SEQ.EditFormat.CustomFormat = "###,###,###,###,###,##0";
            this.nme02_SORT_SEQ.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_SORT_SEQ.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme02_SORT_SEQ.EmptyAsNull = true;
            this.nme02_SORT_SEQ.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme02_SORT_SEQ.Location = new System.Drawing.Point(815, 31);
            this.nme02_SORT_SEQ.Name = "nme02_SORT_SEQ";
            this.nme02_SORT_SEQ.NullText = "0";
            this.nme02_SORT_SEQ.Size = new System.Drawing.Size(100, 21);
            this.nme02_SORT_SEQ.TabIndex = 70;
            this.nme02_SORT_SEQ.Tag = null;
            this.nme02_SORT_SEQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme02_SORT_SEQ.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // lbl02_SORT_SEQ
            // 
            this.lbl02_SORT_SEQ.AutoFontSizeMaxValue = 9F;
            this.lbl02_SORT_SEQ.AutoFontSizeMinValue = 9F;
            this.lbl02_SORT_SEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_SORT_SEQ.Location = new System.Drawing.Point(712, 31);
            this.lbl02_SORT_SEQ.Name = "lbl02_SORT_SEQ";
            this.lbl02_SORT_SEQ.Size = new System.Drawing.Size(100, 21);
            this.lbl02_SORT_SEQ.TabIndex = 71;
            this.lbl02_SORT_SEQ.Tag = null;
            this.lbl02_SORT_SEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_SORT_SEQ.Value = "정렬순서";
            // 
            // cbo02_DIRE_DIV
            // 
            this.cbo02_DIRE_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_DIRE_DIV.FormattingEnabled = true;
            this.cbo02_DIRE_DIV.Location = new System.Drawing.Point(576, 31);
            this.cbo02_DIRE_DIV.Name = "cbo02_DIRE_DIV";
            this.cbo02_DIRE_DIV.Size = new System.Drawing.Size(130, 20);
            this.cbo02_DIRE_DIV.TabIndex = 69;
            // 
            // lbl02_DIRE_DIVNM
            // 
            this.lbl02_DIRE_DIVNM.AutoFontSizeMaxValue = 9F;
            this.lbl02_DIRE_DIVNM.AutoFontSizeMinValue = 9F;
            this.lbl02_DIRE_DIVNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_DIRE_DIVNM.Location = new System.Drawing.Point(470, 31);
            this.lbl02_DIRE_DIVNM.Name = "lbl02_DIRE_DIVNM";
            this.lbl02_DIRE_DIVNM.Size = new System.Drawing.Size(100, 21);
            this.lbl02_DIRE_DIVNM.TabIndex = 68;
            this.lbl02_DIRE_DIVNM.Tag = null;
            this.lbl02_DIRE_DIVNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_DIRE_DIVNM.Value = "직간접구분";
            // 
            // txt01_WORK_DIV_NM
            // 
            this.txt01_WORK_DIV_NM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_WORK_DIV_NM.Location = new System.Drawing.Point(334, 32);
            this.txt01_WORK_DIV_NM.Name = "txt01_WORK_DIV_NM";
            this.txt01_WORK_DIV_NM.Size = new System.Drawing.Size(130, 21);
            this.txt01_WORK_DIV_NM.TabIndex = 67;
            this.txt01_WORK_DIV_NM.Tag = null;
            // 
            // txt02_WORK_DIV
            // 
            this.txt02_WORK_DIV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_WORK_DIV.Location = new System.Drawing.Point(122, 34);
            this.txt02_WORK_DIV.Name = "txt02_WORK_DIV";
            this.txt02_WORK_DIV.Size = new System.Drawing.Size(100, 21);
            this.txt02_WORK_DIV.TabIndex = 64;
            this.txt02_WORK_DIV.Tag = null;
            this.txt02_WORK_DIV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt02_WORK_DIV_KeyUp);
            // 
            // lbl01_WORK_DIVCD_NM
            // 
            this.lbl01_WORK_DIVCD_NM.AutoFontSizeMaxValue = 9F;
            this.lbl01_WORK_DIVCD_NM.AutoFontSizeMinValue = 9F;
            this.lbl01_WORK_DIVCD_NM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WORK_DIVCD_NM.Location = new System.Drawing.Point(228, 32);
            this.lbl01_WORK_DIVCD_NM.Name = "lbl01_WORK_DIVCD_NM";
            this.lbl01_WORK_DIVCD_NM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_WORK_DIVCD_NM.TabIndex = 66;
            this.lbl01_WORK_DIVCD_NM.Tag = null;
            this.lbl01_WORK_DIVCD_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_WORK_DIVCD_NM.Value = "작업구분명";
            // 
            // lbl02_WORK_DIVCD
            // 
            this.lbl02_WORK_DIVCD.AutoFontSizeMaxValue = 9F;
            this.lbl02_WORK_DIVCD.AutoFontSizeMinValue = 9F;
            this.lbl02_WORK_DIVCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_WORK_DIVCD.Location = new System.Drawing.Point(18, 33);
            this.lbl02_WORK_DIVCD.Name = "lbl02_WORK_DIVCD";
            this.lbl02_WORK_DIVCD.Size = new System.Drawing.Size(100, 21);
            this.lbl02_WORK_DIVCD.TabIndex = 65;
            this.lbl02_WORK_DIVCD.Tag = null;
            this.lbl02_WORK_DIVCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_WORK_DIVCD.Value = "작업구분코드";
            // 
            // PD25130
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_WORK_DIVCD_LIST);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp01_MAN_WORK_INFO);
            this.Name = "PD25130";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grp01_MAN_WORK_INFO, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_WORK_DIVCD_LIST, 0);
            this.grp01_WORK_DIVCD_LIST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DIVCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DIRE_DIVNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_WORK_DIV)).EndInit();
            this.grp01_MAN_WORK_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nme02_SORT_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SORT_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_DIRE_DIVNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_WORK_DIV_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_WORK_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WORK_DIVCD_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_WORK_DIVCD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_WORK_DIVCD_LIST;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grp01_MAN_WORK_INFO;
        private DEV.Utility.Controls.AxLabel lbl01_WORK_DIVCD;
        private DEV.Utility.Controls.AxLabel lbl01_DIRE_DIVNM;
        private DEV.Utility.Controls.AxTextBox txt01_WORK_DIV;
        private DEV.Utility.Controls.AxTextBox txt01_WORK_DIV_NM;
        private DEV.Utility.Controls.AxTextBox txt02_WORK_DIV;
        private DEV.Utility.Controls.AxLabel lbl01_WORK_DIVCD_NM;
        private DEV.Utility.Controls.AxLabel lbl02_WORK_DIVCD;
        private DEV.Utility.Controls.AxComboBox cbo01_DIRE_DIV;
        private DEV.Utility.Controls.AxComboBox cbo02_DIRE_DIV;
        private DEV.Utility.Controls.AxLabel lbl02_DIRE_DIVNM;
        private DEV.Utility.Controls.AxNumericEdit nme02_SORT_SEQ;
        private DEV.Utility.Controls.AxLabel lbl02_SORT_SEQ;
    }
}
