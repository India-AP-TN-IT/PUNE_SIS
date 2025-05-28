namespace Ax.SIS.PD.UI
{
    partial class PD50130
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PROCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_APPLY_PROC = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn04_COPY2 = new Ax.DEV.Utility.Controls.AxButton();
            this.heTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lbl01_FILE_PATH = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_FILE_SEARCH = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_FILE_UPLOAD2 = new Ax.DEV.Utility.Controls.AxButton();
            this.grp01_PD50130_GRP_1 = new System.Windows.Forms.GroupBox();
            this.lbl01_PD50130_NOTE_1 = new System.Windows.Forms.Label();
            this.grp01_PD50130_GRP_2 = new System.Windows.Forms.GroupBox();
            this.lbl01_PD50130_NOTE_2 = new System.Windows.Forms.Label();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.btn01_DELETE_4 = new Ax.DEV.Utility.Controls.AxButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_PROC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_FILE_PATH)).BeginInit();
            this.grp01_PD50130_GRP_1.SuspendLayout();
            this.grp01_PD50130_GRP_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heDateEdit1);
            this.groupBox1.Controls.Add(this.lbl01_STD_DATE);
            this.groupBox1.Controls.Add(this.cbo01_PROCD);
            this.groupBox1.Controls.Add(this.lbl01_APPLY_PROC);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // heDateEdit1
            // 
            this.heDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.heDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.heDateEdit1.Location = new System.Drawing.Point(578, 11);
            this.heDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.heDateEdit1.Name = "heDateEdit1";
            this.heDateEdit1.OriginalFormat = "";
            this.heDateEdit1.Size = new System.Drawing.Size(100, 21);
            this.heDateEdit1.TabIndex = 74;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(472, 12);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STD_DATE.TabIndex = 73;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "기준일자";
            // 
            // cbo01_PROCD
            // 
            this.cbo01_PROCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PROCD.FormattingEnabled = true;
            this.cbo01_PROCD.Location = new System.Drawing.Point(345, 13);
            this.cbo01_PROCD.Name = "cbo01_PROCD";
            this.cbo01_PROCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_PROCD.TabIndex = 72;
            // 
            // lbl01_APPLY_PROC
            // 
            this.lbl01_APPLY_PROC.AutoFontSizeMaxValue = 9F;
            this.lbl01_APPLY_PROC.AutoFontSizeMinValue = 9F;
            this.lbl01_APPLY_PROC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_APPLY_PROC.Location = new System.Drawing.Point(239, 13);
            this.lbl01_APPLY_PROC.Name = "lbl01_APPLY_PROC";
            this.lbl01_APPLY_PROC.Size = new System.Drawing.Size(100, 21);
            this.lbl01_APPLY_PROC.TabIndex = 71;
            this.lbl01_APPLY_PROC.Tag = null;
            this.lbl01_APPLY_PROC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_APPLY_PROC.Value = "적용공정";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 13);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 70;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 13);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 69;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // btn04_COPY2
            // 
            this.btn04_COPY2.Location = new System.Drawing.Point(345, 205);
            this.btn04_COPY2.Name = "btn04_COPY2";
            this.btn04_COPY2.Size = new System.Drawing.Size(76, 23);
            this.btn04_COPY2.TabIndex = 73;
            this.btn04_COPY2.Text = "->복사";
            this.btn04_COPY2.UseVisualStyleBackColor = true;
            this.btn04_COPY2.Click += new System.EventHandler(this.Btn_Copy_Click);
            // 
            // heTextBox1
            // 
            this.heTextBox1.Location = new System.Drawing.Point(57, 28);
            this.heTextBox1.Name = "heTextBox1";
            this.heTextBox1.Size = new System.Drawing.Size(218, 21);
            this.heTextBox1.TabIndex = 10;
            this.heTextBox1.Tag = null;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 84);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(330, 573);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            // 
            // lbl01_FILE_PATH
            // 
            this.lbl01_FILE_PATH.AutoFontSizeMaxValue = 9F;
            this.lbl01_FILE_PATH.AutoFontSizeMinValue = 9F;
            this.lbl01_FILE_PATH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_FILE_PATH.Location = new System.Drawing.Point(6, 28);
            this.lbl01_FILE_PATH.Name = "lbl01_FILE_PATH";
            this.lbl01_FILE_PATH.Size = new System.Drawing.Size(45, 21);
            this.lbl01_FILE_PATH.TabIndex = 70;
            this.lbl01_FILE_PATH.Tag = null;
            this.lbl01_FILE_PATH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_FILE_PATH.Value = "경로";
            // 
            // btn01_FILE_SEARCH
            // 
            this.btn01_FILE_SEARCH.Location = new System.Drawing.Point(281, 28);
            this.btn01_FILE_SEARCH.Name = "btn01_FILE_SEARCH";
            this.btn01_FILE_SEARCH.Size = new System.Drawing.Size(55, 23);
            this.btn01_FILE_SEARCH.TabIndex = 71;
            this.btn01_FILE_SEARCH.Text = "찾기";
            this.btn01_FILE_SEARCH.UseVisualStyleBackColor = true;
            this.btn01_FILE_SEARCH.Click += new System.EventHandler(this.Btn_Path_Click);
            // 
            // btn01_FILE_UPLOAD2
            // 
            this.btn01_FILE_UPLOAD2.Location = new System.Drawing.Point(6, 55);
            this.btn01_FILE_UPLOAD2.Name = "btn01_FILE_UPLOAD2";
            this.btn01_FILE_UPLOAD2.Size = new System.Drawing.Size(100, 23);
            this.btn01_FILE_UPLOAD2.TabIndex = 72;
            this.btn01_FILE_UPLOAD2.Text = "업로드";
            this.btn01_FILE_UPLOAD2.UseVisualStyleBackColor = true;
            this.btn01_FILE_UPLOAD2.Click += new System.EventHandler(this.Btn_Upload_Click);
            // 
            // grp01_PD50130_GRP_1
            // 
            this.grp01_PD50130_GRP_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp01_PD50130_GRP_1.Controls.Add(this.lbl01_PD50130_NOTE_1);
            this.grp01_PD50130_GRP_1.Controls.Add(this.btn01_FILE_UPLOAD2);
            this.grp01_PD50130_GRP_1.Controls.Add(this.btn01_FILE_SEARCH);
            this.grp01_PD50130_GRP_1.Controls.Add(this.lbl01_FILE_PATH);
            this.grp01_PD50130_GRP_1.Controls.Add(this.heTextBox1);
            this.grp01_PD50130_GRP_1.Controls.Add(this.grd01);
            this.grp01_PD50130_GRP_1.Location = new System.Drawing.Point(0, 80);
            this.grp01_PD50130_GRP_1.Name = "grp01_PD50130_GRP_1";
            this.grp01_PD50130_GRP_1.Size = new System.Drawing.Size(339, 688);
            this.grp01_PD50130_GRP_1.TabIndex = 8;
            this.grp01_PD50130_GRP_1.TabStop = false;
            this.grp01_PD50130_GRP_1.Text = "1. 동영상 파일 List";
            // 
            // lbl01_PD50130_NOTE_1
            // 
            this.lbl01_PD50130_NOTE_1.AutoSize = true;
            this.lbl01_PD50130_NOTE_1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl01_PD50130_NOTE_1.Location = new System.Drawing.Point(112, 60);
            this.lbl01_PD50130_NOTE_1.Name = "lbl01_PD50130_NOTE_1";
            this.lbl01_PD50130_NOTE_1.Size = new System.Drawing.Size(202, 12);
            this.lbl01_PD50130_NOTE_1.TabIndex = 10;
            this.lbl01_PD50130_NOTE_1.Text = "파일명은 반드시 영문이나 숫자만";
            // 
            // grp01_PD50130_GRP_2
            // 
            this.grp01_PD50130_GRP_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD50130_GRP_2.Controls.Add(this.lbl01_PD50130_NOTE_2);
            this.grp01_PD50130_GRP_2.Controls.Add(this.grd02);
            this.grp01_PD50130_GRP_2.Location = new System.Drawing.Point(438, 80);
            this.grp01_PD50130_GRP_2.Name = "grp01_PD50130_GRP_2";
            this.grp01_PD50130_GRP_2.Size = new System.Drawing.Size(586, 688);
            this.grp01_PD50130_GRP_2.TabIndex = 74;
            this.grp01_PD50130_GRP_2.TabStop = false;
            this.grp01_PD50130_GRP_2.Text = "2. 게시내용입력";
            // 
            // lbl01_PD50130_NOTE_2
            // 
            this.lbl01_PD50130_NOTE_2.AutoSize = true;
            this.lbl01_PD50130_NOTE_2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl01_PD50130_NOTE_2.Location = new System.Drawing.Point(6, 37);
            this.lbl01_PD50130_NOTE_2.Name = "lbl01_PD50130_NOTE_2";
            this.lbl01_PD50130_NOTE_2.Size = new System.Drawing.Size(391, 12);
            this.lbl01_PD50130_NOTE_2.TabIndex = 9;
            this.lbl01_PD50130_NOTE_2.Text = "시간입력시 \'HH:MM\'의 형식으로 입력(예 : 11시 10분 -> 11:10)";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 55);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(577, 602);
            this.grd02.TabIndex = 8;
            this.grd02.UseCustomHighlight = true;
            // 
            // btn01_DELETE_4
            // 
            this.btn01_DELETE_4.Location = new System.Drawing.Point(345, 234);
            this.btn01_DELETE_4.Name = "btn01_DELETE_4";
            this.btn01_DELETE_4.Size = new System.Drawing.Size(76, 23);
            this.btn01_DELETE_4.TabIndex = 75;
            this.btn01_DELETE_4.Text = "X 삭제";
            this.btn01_DELETE_4.UseVisualStyleBackColor = true;
            this.btn01_DELETE_4.Click += new System.EventHandler(this.Btn_Del_Click);
            // 
            // PD50130
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btn01_DELETE_4);
            this.Controls.Add(this.grp01_PD50130_GRP_2);
            this.Controls.Add(this.btn04_COPY2);
            this.Controls.Add(this.grp01_PD50130_GRP_1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD50130";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD50130_GRP_1, 0);
            this.Controls.SetChildIndex(this.btn04_COPY2, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grp01_PD50130_GRP_2, 0);
            this.Controls.SetChildIndex(this.btn01_DELETE_4, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_PROC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_FILE_PATH)).EndInit();
            this.grp01_PD50130_GRP_1.ResumeLayout(false);
            this.grp01_PD50130_GRP_1.PerformLayout();
            this.grp01_PD50130_GRP_2.ResumeLayout(false);
            this.grp01_PD50130_GRP_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxButton btn04_COPY2;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_FILE_PATH;
        private Ax.DEV.Utility.Controls.AxButton btn01_FILE_SEARCH;
        private Ax.DEV.Utility.Controls.AxButton btn01_FILE_UPLOAD2;
        private System.Windows.Forms.GroupBox grp01_PD50130_GRP_1;
        private System.Windows.Forms.GroupBox grp01_PD50130_GRP_2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PROCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_APPLY_PROC;
        private System.Windows.Forms.Label lbl01_PD50130_NOTE_2;
        private Ax.DEV.Utility.Controls.AxDateEdit heDateEdit1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private System.Windows.Forms.Label lbl01_PD50130_NOTE_1;
        private Ax.DEV.Utility.Controls.AxButton btn01_DELETE_4;
    }
}
