namespace Ax.SIS.PD.UI
{
    partial class PD20421
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
            this.grp01_PD20421_GRP1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_END_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_CHANGE_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_MASTER_ITEM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_MASTER_ITEM = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt01_MOLDNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MOLDNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SUB_ITEM = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SUB_ITEM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grp01_PD20421_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CHANGE_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MASTER_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SUB_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD20421_GRP1
            // 
            this.grp01_PD20421_GRP1.Controls.Add(this.grd01);
            this.grp01_PD20421_GRP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD20421_GRP1.Location = new System.Drawing.Point(0, 106);
            this.grp01_PD20421_GRP1.Name = "grp01_PD20421_GRP1";
            this.grp01_PD20421_GRP1.Size = new System.Drawing.Size(1024, 662);
            this.grp01_PD20421_GRP1.TabIndex = 8;
            this.grp01_PD20421_GRP1.TabStop = false;
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
            this.grd01.Size = new System.Drawing.Size(1018, 642);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp01_END_EDATE);
            this.groupBox1.Controls.Add(this.dtp01_BEG_DATE);
            this.groupBox1.Controls.Add(this.lbl01_CHANGE_DATE);
            this.groupBox1.Controls.Add(this.lbl01_MASTER_ITEM);
            this.groupBox1.Controls.Add(this.cbo01_MASTER_ITEM);
            this.groupBox1.Controls.Add(this.txt01_MOLDNO);
            this.groupBox1.Controls.Add(this.lbl01_MOLDNO);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 96;
            this.label1.Text = "~";
            // 
            // dtp01_END_EDATE
            // 
            this.dtp01_END_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_END_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_END_EDATE.Location = new System.Drawing.Point(744, 14);
            this.dtp01_END_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_END_EDATE.Name = "dtp01_END_EDATE";
            this.dtp01_END_EDATE.OriginalFormat = "";
            this.dtp01_END_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_END_EDATE.TabIndex = 95;
            // 
            // dtp01_BEG_DATE
            // 
            this.dtp01_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_BEG_DATE.Location = new System.Drawing.Point(618, 14);
            this.dtp01_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_BEG_DATE.Name = "dtp01_BEG_DATE";
            this.dtp01_BEG_DATE.OriginalFormat = "";
            this.dtp01_BEG_DATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_BEG_DATE.TabIndex = 94;
            // 
            // lbl01_CHANGE_DATE
            // 
            this.lbl01_CHANGE_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CHANGE_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_CHANGE_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CHANGE_DATE.Location = new System.Drawing.Point(512, 14);
            this.lbl01_CHANGE_DATE.Name = "lbl01_CHANGE_DATE";
            this.lbl01_CHANGE_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CHANGE_DATE.TabIndex = 93;
            this.lbl01_CHANGE_DATE.Tag = null;
            this.lbl01_CHANGE_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CHANGE_DATE.Value = "변경일자";
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
            // cbo01_SUB_ITEM
            // 
            this.cbo01_SUB_ITEM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SUB_ITEM.FormattingEnabled = true;
            this.cbo01_SUB_ITEM.Location = new System.Drawing.Point(352, 38);
            this.cbo01_SUB_ITEM.Name = "cbo01_SUB_ITEM";
            this.cbo01_SUB_ITEM.Size = new System.Drawing.Size(154, 20);
            this.cbo01_SUB_ITEM.TabIndex = 60;
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
            // 
            // PD20421
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD20421_GRP1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20421";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD20421_GRP1, 0);
            this.grp01_PD20421_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CHANGE_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MASTER_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MOLDNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SUB_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD20421_GRP1;
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
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_END_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_BEG_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CHANGE_DATE;
    }
}
