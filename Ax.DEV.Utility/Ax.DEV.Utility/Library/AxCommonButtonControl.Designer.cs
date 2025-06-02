namespace Ax.DEV.Utility.Library
{
    partial class AxCommonButtonControl
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
            this.btn01_SAVE = new C1.Win.C1Input.C1Button();
            this.btn01_DELETE = new C1.Win.C1Input.C1Button();
            this.btn01_QUERY = new C1.Win.C1Input.C1Button();
            this.btn01_RESET = new C1.Win.C1Input.C1Button();
            this.btn01_PROCESS = new C1.Win.C1Input.C1Button();
            this.btn01_PRINT = new C1.Win.C1Input.C1Button();
            this.btn01_UPLOAD = new C1.Win.C1Input.C1Button();
            this.btn01_DOWNLOAD = new C1.Win.C1Input.C1Button();
            this.btn01_HELP = new C1.Win.C1Input.C1Button();
            this.btn01_CLOSE = new C1.Win.C1Input.C1Button();
            this.flpArea = new System.Windows.Forms.FlowLayoutPanel();
            this.flpArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn01_SAVE
            // 
            this.btn01_SAVE.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_SAVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_SAVE.FlatAppearance.BorderSize = 0;
            this.btn01_SAVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_SAVE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_SAVE.ForeColor = System.Drawing.Color.White;
            this.btn01_SAVE.Location = new System.Drawing.Point(539, 3);
            this.btn01_SAVE.Name = "btn01_SAVE";
            this.btn01_SAVE.Size = new System.Drawing.Size(55, 25);
            this.btn01_SAVE.TabIndex = 2;
            this.btn01_SAVE.Text = "저장";
            this.btn01_SAVE.UseVisualStyleBackColor = true;
            this.btn01_SAVE.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btn01_DELETE
            // 
            this.btn01_DELETE.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_DELETE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_DELETE.FlatAppearance.BorderSize = 0;
            this.btn01_DELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_DELETE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_DELETE.ForeColor = System.Drawing.Color.White;
            this.btn01_DELETE.Location = new System.Drawing.Point(600, 3);
            this.btn01_DELETE.Name = "btn01_DELETE";
            this.btn01_DELETE.Size = new System.Drawing.Size(55, 25);
            this.btn01_DELETE.TabIndex = 3;
            this.btn01_DELETE.Text = "삭제";
            this.btn01_DELETE.UseVisualStyleBackColor = true;
            this.btn01_DELETE.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btn01_QUERY
            // 
            this.btn01_QUERY.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_QUERY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_QUERY.FlatAppearance.BorderSize = 0;
            this.btn01_QUERY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_QUERY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_QUERY.ForeColor = System.Drawing.Color.White;
            this.btn01_QUERY.Location = new System.Drawing.Point(417, 3);
            this.btn01_QUERY.Name = "btn01_QUERY";
            this.btn01_QUERY.Size = new System.Drawing.Size(55, 25);
            this.btn01_QUERY.TabIndex = 0;
            this.btn01_QUERY.Text = "조회";
            this.btn01_QUERY.UseVisualStyleBackColor = true;
            this.btn01_QUERY.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btn01_RESET
            // 
            this.btn01_RESET.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_RESET.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_RESET.FlatAppearance.BorderSize = 0;
            this.btn01_RESET.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_RESET.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_RESET.ForeColor = System.Drawing.Color.White;
            this.btn01_RESET.Location = new System.Drawing.Point(478, 3);
            this.btn01_RESET.Name = "btn01_RESET";
            this.btn01_RESET.Size = new System.Drawing.Size(55, 25);
            this.btn01_RESET.TabIndex = 1;
            this.btn01_RESET.Text = "초기화";
            this.btn01_RESET.UseVisualStyleBackColor = true;
            this.btn01_RESET.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btn01_PROCESS
            // 
            this.btn01_PROCESS.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_PROCESS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_PROCESS.FlatAppearance.BorderSize = 0;
            this.btn01_PROCESS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_PROCESS.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_PROCESS.ForeColor = System.Drawing.Color.White;
            this.btn01_PROCESS.Location = new System.Drawing.Point(661, 3);
            this.btn01_PROCESS.Name = "btn01_PROCESS";
            this.btn01_PROCESS.Size = new System.Drawing.Size(55, 25);
            this.btn01_PROCESS.TabIndex = 4;
            this.btn01_PROCESS.Text = "처리";
            this.btn01_PROCESS.UseVisualStyleBackColor = true;
            this.btn01_PROCESS.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btn01_PRINT
            // 
            this.btn01_PRINT.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_PRINT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_PRINT.FlatAppearance.BorderSize = 0;
            this.btn01_PRINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_PRINT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_PRINT.ForeColor = System.Drawing.Color.White;
            this.btn01_PRINT.Location = new System.Drawing.Point(722, 3);
            this.btn01_PRINT.Name = "btn01_PRINT";
            this.btn01_PRINT.Size = new System.Drawing.Size(55, 25);
            this.btn01_PRINT.TabIndex = 5;
            this.btn01_PRINT.Text = "출력";
            this.btn01_PRINT.UseVisualStyleBackColor = true;
            this.btn01_PRINT.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btn01_UPLOAD
            // 
            this.btn01_UPLOAD.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_UPLOAD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_UPLOAD.FlatAppearance.BorderSize = 0;
            this.btn01_UPLOAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_UPLOAD.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_UPLOAD.ForeColor = System.Drawing.Color.White;
            this.btn01_UPLOAD.Location = new System.Drawing.Point(844, 3);
            this.btn01_UPLOAD.Name = "btn01_UPLOAD";
            this.btn01_UPLOAD.Size = new System.Drawing.Size(55, 25);
            this.btn01_UPLOAD.TabIndex = 7;
            this.btn01_UPLOAD.Text = "업";
            this.btn01_UPLOAD.UseVisualStyleBackColor = true;
            this.btn01_UPLOAD.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btn01_DOWNLOAD
            // 
            this.btn01_DOWNLOAD.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_DOWNLOAD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_DOWNLOAD.FlatAppearance.BorderSize = 0;
            this.btn01_DOWNLOAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_DOWNLOAD.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_DOWNLOAD.ForeColor = System.Drawing.Color.White;
            this.btn01_DOWNLOAD.Location = new System.Drawing.Point(783, 3);
            this.btn01_DOWNLOAD.Name = "btn01_DOWNLOAD";
            this.btn01_DOWNLOAD.Size = new System.Drawing.Size(55, 25);
            this.btn01_DOWNLOAD.TabIndex = 6;
            this.btn01_DOWNLOAD.Text = "다운";
            this.btn01_DOWNLOAD.UseVisualStyleBackColor = true;
            this.btn01_DOWNLOAD.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btn01_HELP
            // 
            this.btn01_HELP.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_HELP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_HELP.FlatAppearance.BorderSize = 0;
            this.btn01_HELP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_HELP.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_HELP.ForeColor = System.Drawing.Color.White;
            this.btn01_HELP.Location = new System.Drawing.Point(966, 3);
            this.btn01_HELP.Name = "btn01_HELP";
            this.btn01_HELP.Size = new System.Drawing.Size(55, 25);
            this.btn01_HELP.TabIndex = 9;
            this.btn01_HELP.Text = "도움말";
            this.btn01_HELP.UseVisualStyleBackColor = true;
            this.btn01_HELP.Visible = false;
            this.btn01_HELP.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btn01_CLOSE
            // 
            this.btn01_CLOSE.BackgroundImage = global::Ax.DEV.Utility.Properties.Resources.button;
            this.btn01_CLOSE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01_CLOSE.FlatAppearance.BorderSize = 0;
            this.btn01_CLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01_CLOSE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01_CLOSE.ForeColor = System.Drawing.Color.White;
            this.btn01_CLOSE.Location = new System.Drawing.Point(905, 3);
            this.btn01_CLOSE.Name = "btn01_CLOSE";
            this.btn01_CLOSE.Size = new System.Drawing.Size(55, 25);
            this.btn01_CLOSE.TabIndex = 8;
            this.btn01_CLOSE.Text = "닫기";
            this.btn01_CLOSE.UseVisualStyleBackColor = false;
            this.btn01_CLOSE.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flpArea
            // 
            this.flpArea.BackColor = System.Drawing.Color.White;
            this.flpArea.Controls.Add(this.btn01_HELP);
            this.flpArea.Controls.Add(this.btn01_CLOSE);
            this.flpArea.Controls.Add(this.btn01_UPLOAD);
            this.flpArea.Controls.Add(this.btn01_DOWNLOAD);
            this.flpArea.Controls.Add(this.btn01_PRINT);
            this.flpArea.Controls.Add(this.btn01_PROCESS);
            this.flpArea.Controls.Add(this.btn01_DELETE);
            this.flpArea.Controls.Add(this.btn01_SAVE);
            this.flpArea.Controls.Add(this.btn01_RESET);
            this.flpArea.Controls.Add(this.btn01_QUERY);
            this.flpArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpArea.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpArea.Location = new System.Drawing.Point(0, 0);
            this.flpArea.Name = "flpArea";
            this.flpArea.Size = new System.Drawing.Size(1024, 34);
            this.flpArea.TabIndex = 10;
            // 
            // AxCommonButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.flpArea);
            this.Name = "AxCommonButtonControl";
            this.Size = new System.Drawing.Size(1024, 34);
            this.flpArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Input.C1Button btn01_SAVE;        
        private C1.Win.C1Input.C1Button btn01_DELETE;
        private C1.Win.C1Input.C1Button btn01_QUERY;
        private C1.Win.C1Input.C1Button btn01_PROCESS;
        private C1.Win.C1Input.C1Button btn01_PRINT;
        private C1.Win.C1Input.C1Button btn01_UPLOAD;
        private C1.Win.C1Input.C1Button btn01_DOWNLOAD;
        private C1.Win.C1Input.C1Button btn01_HELP;
        private C1.Win.C1Input.C1Button btn01_CLOSE;
		private System.Windows.Forms.FlowLayoutPanel flpArea;
        private C1.Win.C1Input.C1Button btn01_RESET;
    }
}
