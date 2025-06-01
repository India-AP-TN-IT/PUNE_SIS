namespace Ax.SIS.QA.QA02.UI
{
    partial class QA34010
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
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.chk01_LAST_2MONTH = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.txt01_SUBJECT = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_SPEC_NO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo01_LANG_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SUBJECT = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_SPEC_NO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LANG = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnl01_INPUT_REASON = new System.Windows.Forms.Panel();
            this.chk01_AGREE = new System.Windows.Forms.CheckBox();
            this.lbl01_INPUT_REASON = new System.Windows.Forms.Label();
            this.lbl01_QA34010_MSG2 = new System.Windows.Forms.Label();
            this.lbl01_QA34010_MSG1 = new System.Windows.Forms.Label();
            this.txt01_ACCESS_REASON = new Ax.DEV.Utility.Controls.AxTextBox();
            this.btn01_CLOSE_0 = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_CONFIRM = new Ax.DEV.Utility.Controls.AxButton();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SUBJECT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SPEC_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SUBJECT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SPEC_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LANG)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnl01_INPUT_REASON.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ACCESS_REASON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.chk01_LAST_2MONTH);
            this.groupBox_main.Controls.Add(this.txt01_SUBJECT);
            this.groupBox_main.Controls.Add(this.txt01_SPEC_NO);
            this.groupBox_main.Controls.Add(this.cbo01_LANG_DIV);
            this.groupBox_main.Controls.Add(this.lbl01_SUBJECT);
            this.groupBox_main.Controls.Add(this.lbl01_SPEC_NO);
            this.groupBox_main.Controls.Add(this.lbl01_LANG);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_main.Location = new System.Drawing.Point(0, 34);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(1024, 49);
            this.groupBox_main.TabIndex = 1;
            this.groupBox_main.TabStop = false;
            // 
            // chk01_LAST_2MONTH
            // 
            this.chk01_LAST_2MONTH.AutoSize = true;
            this.chk01_LAST_2MONTH.Location = new System.Drawing.Point(748, 21);
            this.chk01_LAST_2MONTH.Name = "chk01_LAST_2MONTH";
            this.chk01_LAST_2MONTH.Size = new System.Drawing.Size(110, 16);
            this.chk01_LAST_2MONTH.TabIndex = 32;
            this.chk01_LAST_2MONTH.Text = "최근 2개월 이내";
            this.chk01_LAST_2MONTH.UseVisualStyleBackColor = true;
            // 
            // txt01_SUBJECT
            // 
            this.txt01_SUBJECT.Location = new System.Drawing.Point(543, 18);
            this.txt01_SUBJECT.Name = "txt01_SUBJECT";
            this.txt01_SUBJECT.Size = new System.Drawing.Size(199, 21);
            this.txt01_SUBJECT.TabIndex = 5;
            this.txt01_SUBJECT.Tag = null;
            // 
            // txt01_SPEC_NO
            // 
            this.txt01_SPEC_NO.Location = new System.Drawing.Point(101, 18);
            this.txt01_SPEC_NO.Name = "txt01_SPEC_NO";
            this.txt01_SPEC_NO.Size = new System.Drawing.Size(144, 21);
            this.txt01_SPEC_NO.TabIndex = 5;
            this.txt01_SPEC_NO.Tag = null;
            // 
            // cbo01_LANG_DIV
            // 
            this.cbo01_LANG_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_LANG_DIV.FormattingEnabled = true;
            this.cbo01_LANG_DIV.Location = new System.Drawing.Point(344, 18);
            this.cbo01_LANG_DIV.Name = "cbo01_LANG_DIV";
            this.cbo01_LANG_DIV.Size = new System.Drawing.Size(101, 20);
            this.cbo01_LANG_DIV.TabIndex = 1;
            // 
            // lbl01_SUBJECT
            // 
            this.lbl01_SUBJECT.AutoFontSizeMaxValue = 9F;
            this.lbl01_SUBJECT.AutoFontSizeMinValue = 9F;
            this.lbl01_SUBJECT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SUBJECT.Location = new System.Drawing.Point(450, 18);
            this.lbl01_SUBJECT.Name = "lbl01_SUBJECT";
            this.lbl01_SUBJECT.Size = new System.Drawing.Size(90, 21);
            this.lbl01_SUBJECT.TabIndex = 5;
            this.lbl01_SUBJECT.Tag = null;
            this.lbl01_SUBJECT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SUBJECT.Value = "제목";
            // 
            // lbl01_SPEC_NO
            // 
            this.lbl01_SPEC_NO.AutoFontSizeMaxValue = 9F;
            this.lbl01_SPEC_NO.AutoFontSizeMinValue = 9F;
            this.lbl01_SPEC_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SPEC_NO.Location = new System.Drawing.Point(8, 18);
            this.lbl01_SPEC_NO.Name = "lbl01_SPEC_NO";
            this.lbl01_SPEC_NO.Size = new System.Drawing.Size(90, 21);
            this.lbl01_SPEC_NO.TabIndex = 5;
            this.lbl01_SPEC_NO.Tag = null;
            this.lbl01_SPEC_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SPEC_NO.Value = "스펙명";
            // 
            // lbl01_LANG
            // 
            this.lbl01_LANG.AutoFontSizeMaxValue = 9F;
            this.lbl01_LANG.AutoFontSizeMinValue = 9F;
            this.lbl01_LANG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LANG.Location = new System.Drawing.Point(251, 18);
            this.lbl01_LANG.Name = "lbl01_LANG";
            this.lbl01_LANG.Size = new System.Drawing.Size(90, 21);
            this.lbl01_LANG.TabIndex = 1;
            this.lbl01_LANG.Tag = null;
            this.lbl01_LANG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LANG.Value = "언어";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnl01_INPUT_REASON);
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 685);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // pnl01_INPUT_REASON
            // 
            this.pnl01_INPUT_REASON.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl01_INPUT_REASON.Controls.Add(this.chk01_AGREE);
            this.pnl01_INPUT_REASON.Controls.Add(this.lbl01_INPUT_REASON);
            this.pnl01_INPUT_REASON.Controls.Add(this.lbl01_QA34010_MSG2);
            this.pnl01_INPUT_REASON.Controls.Add(this.lbl01_QA34010_MSG1);
            this.pnl01_INPUT_REASON.Controls.Add(this.txt01_ACCESS_REASON);
            this.pnl01_INPUT_REASON.Controls.Add(this.btn01_CLOSE_0);
            this.pnl01_INPUT_REASON.Controls.Add(this.btn01_CONFIRM);
            this.pnl01_INPUT_REASON.Location = new System.Drawing.Point(187, 119);
            this.pnl01_INPUT_REASON.Name = "pnl01_INPUT_REASON";
            this.pnl01_INPUT_REASON.Size = new System.Drawing.Size(600, 170);
            this.pnl01_INPUT_REASON.TabIndex = 1;
            this.pnl01_INPUT_REASON.Visible = false;
            this.pnl01_INPUT_REASON.VisibleChanged += new System.EventHandler(this.pnl01_INPUT_REASON_VisibleChanged);
            this.pnl01_INPUT_REASON.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl01_INPUT_REASON_MouseDown);
            this.pnl01_INPUT_REASON.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl01_INPUT_REASON_MouseMove);
            // 
            // chk01_AGREE
            // 
            this.chk01_AGREE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk01_AGREE.AutoSize = true;
            this.chk01_AGREE.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chk01_AGREE.Location = new System.Drawing.Point(518, 21);
            this.chk01_AGREE.Name = "chk01_AGREE";
            this.chk01_AGREE.Size = new System.Drawing.Size(50, 16);
            this.chk01_AGREE.TabIndex = 22;
            this.chk01_AGREE.Text = "동의";
            this.chk01_AGREE.UseVisualStyleBackColor = true;
            this.chk01_AGREE.CheckedChanged += new System.EventHandler(this.chk01_AGREE_CheckedChanged);
            // 
            // lbl01_INPUT_REASON
            // 
            this.lbl01_INPUT_REASON.AutoSize = true;
            this.lbl01_INPUT_REASON.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl01_INPUT_REASON.Location = new System.Drawing.Point(14, 62);
            this.lbl01_INPUT_REASON.Name = "lbl01_INPUT_REASON";
            this.lbl01_INPUT_REASON.Size = new System.Drawing.Size(101, 12);
            this.lbl01_INPUT_REASON.TabIndex = 25;
            this.lbl01_INPUT_REASON.Text = "◈ 열람 사유 입력";
            // 
            // lbl01_QA34010_MSG2
            // 
            this.lbl01_QA34010_MSG2.AutoSize = true;
            this.lbl01_QA34010_MSG2.ForeColor = System.Drawing.Color.Red;
            this.lbl01_QA34010_MSG2.Location = new System.Drawing.Point(14, 103);
            this.lbl01_QA34010_MSG2.Name = "lbl01_QA34010_MSG2";
            this.lbl01_QA34010_MSG2.Size = new System.Drawing.Size(361, 12);
            this.lbl01_QA34010_MSG2.TabIndex = 24;
            this.lbl01_QA34010_MSG2.Text = "※사유가 불분명할 경우 예고없이 스펙조회가 차단될 수 있습니다.";
            // 
            // lbl01_QA34010_MSG1
            // 
            this.lbl01_QA34010_MSG1.AutoSize = true;
            this.lbl01_QA34010_MSG1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl01_QA34010_MSG1.Location = new System.Drawing.Point(14, 22);
            this.lbl01_QA34010_MSG1.Name = "lbl01_QA34010_MSG1";
            this.lbl01_QA34010_MSG1.Size = new System.Drawing.Size(331, 12);
            this.lbl01_QA34010_MSG1.TabIndex = 23;
            this.lbl01_QA34010_MSG1.Text = "본 스펙을 동의 없이 배포하지 않을 것임을 서약합니다.";
            // 
            // txt01_ACCESS_REASON
            // 
            this.txt01_ACCESS_REASON.Location = new System.Drawing.Point(14, 77);
            this.txt01_ACCESS_REASON.Name = "txt01_ACCESS_REASON";
            this.txt01_ACCESS_REASON.Size = new System.Drawing.Size(356, 21);
            this.txt01_ACCESS_REASON.TabIndex = 20;
            this.txt01_ACCESS_REASON.Tag = null;
            // 
            // btn01_CLOSE_0
            // 
            this.btn01_CLOSE_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_CLOSE_0.Location = new System.Drawing.Point(497, 127);
            this.btn01_CLOSE_0.Name = "btn01_CLOSE_0";
            this.btn01_CLOSE_0.Size = new System.Drawing.Size(92, 28);
            this.btn01_CLOSE_0.TabIndex = 19;
            this.btn01_CLOSE_0.Text = "닫기";
            this.btn01_CLOSE_0.UseVisualStyleBackColor = true;
            this.btn01_CLOSE_0.Click += new System.EventHandler(this.btn01_CLOSE_Click);
            // 
            // btn01_CONFIRM
            // 
            this.btn01_CONFIRM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_CONFIRM.Enabled = false;
            this.btn01_CONFIRM.Location = new System.Drawing.Point(399, 127);
            this.btn01_CONFIRM.Name = "btn01_CONFIRM";
            this.btn01_CONFIRM.Size = new System.Drawing.Size(92, 28);
            this.btn01_CONFIRM.TabIndex = 19;
            this.btn01_CONFIRM.Text = "확인";
            this.btn01_CONFIRM.UseVisualStyleBackColor = true;
            this.btn01_CONFIRM.Click += new System.EventHandler(this.btn01_CONFIRM_Click);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(6, 14);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1012, 665);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // QA34010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_main);
            this.Name = "QA34010";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox_main, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SUBJECT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SPEC_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SUBJECT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SPEC_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LANG)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.pnl01_INPUT_REASON.ResumeLayout(false);
            this.pnl01_INPUT_REASON.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ACCESS_REASON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_SPEC_NO;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_LANG_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SPEC_NO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LANG;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_SUBJECT;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SUBJECT;
        private System.Windows.Forms.Panel pnl01_INPUT_REASON;
        private Ax.DEV.Utility.Controls.AxButton btn01_CLOSE_0;
        private Ax.DEV.Utility.Controls.AxButton btn01_CONFIRM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ACCESS_REASON;
        private System.Windows.Forms.CheckBox chk01_AGREE;
        private System.Windows.Forms.Label lbl01_QA34010_MSG1;
        private System.Windows.Forms.Label lbl01_QA34010_MSG2;
        private System.Windows.Forms.Label lbl01_INPUT_REASON;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_LAST_2MONTH;
    }
}
