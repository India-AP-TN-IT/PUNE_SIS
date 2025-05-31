namespace Ax.SIS.PD.UI
{
    partial class PD50061
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
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_FILE_FIND = new Ax.DEV.Utility.Controls.AxButton();
            this.chk01_PLAY_CHK = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.txt01_MOVIE_NAME = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_MOVIE_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_MOVIE_NAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_RECENT_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl03_MOVIE_FILENM = new Ax.DEV.Utility.Controls.AxLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOVIE_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOVIE_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOVIE_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_RECENT_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_MOVIE_FILENM)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1018, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 13);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(161, 20);
            this.cbo01_BIZCD.TabIndex = 66;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 12);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 65;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // btn01_FILE_FIND
            // 
            this.btn01_FILE_FIND.Location = new System.Drawing.Point(444, 190);
            this.btn01_FILE_FIND.Name = "btn01_FILE_FIND";
            this.btn01_FILE_FIND.Size = new System.Drawing.Size(116, 23);
            this.btn01_FILE_FIND.TabIndex = 82;
            this.btn01_FILE_FIND.Text = "btn01_FILE_FIND";
            this.btn01_FILE_FIND.UseVisualStyleBackColor = true;
            this.btn01_FILE_FIND.Click += new System.EventHandler(this.btn01_FILE_Click);
            // 
            // chk01_PLAY_CHK
            // 
            this.chk01_PLAY_CHK.AutoSize = true;
            this.chk01_PLAY_CHK.Location = new System.Drawing.Point(115, 155);
            this.chk01_PLAY_CHK.Name = "chk01_PLAY_CHK";
            this.chk01_PLAY_CHK.Size = new System.Drawing.Size(124, 16);
            this.chk01_PLAY_CHK.TabIndex = 83;
            this.chk01_PLAY_CHK.Text = "chk01_PLAY_CHK";
            this.chk01_PLAY_CHK.UseVisualStyleBackColor = true;
            // 
            // txt01_MOVIE_NAME
            // 
            this.txt01_MOVIE_NAME.Location = new System.Drawing.Point(9, 190);
            this.txt01_MOVIE_NAME.Name = "txt01_MOVIE_NAME";
            this.txt01_MOVIE_NAME.Size = new System.Drawing.Size(429, 21);
            this.txt01_MOVIE_NAME.TabIndex = 84;
            this.txt01_MOVIE_NAME.Tag = null;
            // 
            // lbl02_MOVIE_DATE
            // 
            this.lbl02_MOVIE_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_MOVIE_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_MOVIE_DATE.AutoSize = true;
            this.lbl02_MOVIE_DATE.BackColor = System.Drawing.Color.White;
            this.lbl02_MOVIE_DATE.Location = new System.Drawing.Point(115, 103);
            this.lbl02_MOVIE_DATE.Name = "lbl02_MOVIE_DATE";
            this.lbl02_MOVIE_DATE.Size = new System.Drawing.Size(113, 12);
            this.lbl02_MOVIE_DATE.TabIndex = 85;
            this.lbl02_MOVIE_DATE.Tag = null;
            this.lbl02_MOVIE_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_MOVIE_DATE.Value = "최신날짜";
            // 
            // lbl02_MOVIE_NAME
            // 
            this.lbl02_MOVIE_NAME.AutoFontSizeMaxValue = 9F;
            this.lbl02_MOVIE_NAME.AutoFontSizeMinValue = 9F;
            this.lbl02_MOVIE_NAME.AutoSize = true;
            this.lbl02_MOVIE_NAME.BackColor = System.Drawing.Color.White;
            this.lbl02_MOVIE_NAME.Location = new System.Drawing.Point(115, 129);
            this.lbl02_MOVIE_NAME.Name = "lbl02_MOVIE_NAME";
            this.lbl02_MOVIE_NAME.Size = new System.Drawing.Size(117, 12);
            this.lbl02_MOVIE_NAME.TabIndex = 86;
            this.lbl02_MOVIE_NAME.Tag = null;
            this.lbl02_MOVIE_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_MOVIE_NAME.Value = "동영상 파일명";
            // 
            // lbl02_RECENT_DATE
            // 
            this.lbl02_RECENT_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_RECENT_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_RECENT_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_RECENT_DATE.Location = new System.Drawing.Point(9, 99);
            this.lbl02_RECENT_DATE.Name = "lbl02_RECENT_DATE";
            this.lbl02_RECENT_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_RECENT_DATE.TabIndex = 87;
            this.lbl02_RECENT_DATE.Tag = null;
            this.lbl02_RECENT_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_RECENT_DATE.Value = "최신날짜";
            // 
            // lbl03_MOVIE_FILENM
            // 
            this.lbl03_MOVIE_FILENM.AutoFontSizeMaxValue = 9F;
            this.lbl03_MOVIE_FILENM.AutoFontSizeMinValue = 9F;
            this.lbl03_MOVIE_FILENM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl03_MOVIE_FILENM.Location = new System.Drawing.Point(9, 125);
            this.lbl03_MOVIE_FILENM.Name = "lbl03_MOVIE_FILENM";
            this.lbl03_MOVIE_FILENM.Size = new System.Drawing.Size(100, 21);
            this.lbl03_MOVIE_FILENM.TabIndex = 88;
            this.lbl03_MOVIE_FILENM.Tag = null;
            this.lbl03_MOVIE_FILENM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl03_MOVIE_FILENM.Value = "동영상 파일명";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PD50061
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lbl03_MOVIE_FILENM);
            this.Controls.Add(this.lbl02_RECENT_DATE);
            this.Controls.Add(this.lbl02_MOVIE_NAME);
            this.Controls.Add(this.lbl02_MOVIE_DATE);
            this.Controls.Add(this.txt01_MOVIE_NAME);
            this.Controls.Add(this.chk01_PLAY_CHK);
            this.Controls.Add(this.btn01_FILE_FIND);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD50061";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btn01_FILE_FIND, 0);
            this.Controls.SetChildIndex(this.chk01_PLAY_CHK, 0);
            this.Controls.SetChildIndex(this.txt01_MOVIE_NAME, 0);
            this.Controls.SetChildIndex(this.lbl02_MOVIE_DATE, 0);
            this.Controls.SetChildIndex(this.lbl02_MOVIE_NAME, 0);
            this.Controls.SetChildIndex(this.lbl02_RECENT_DATE, 0);
            this.Controls.SetChildIndex(this.lbl03_MOVIE_FILENM, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MOVIE_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOVIE_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MOVIE_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_RECENT_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_MOVIE_FILENM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxButton btn01_FILE_FIND;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_PLAY_CHK;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_MOVIE_NAME;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_MOVIE_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_MOVIE_NAME;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_RECENT_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl03_MOVIE_FILENM;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
