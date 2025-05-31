namespace Ax.SIS.QA.QA02.UI
{
    partial class QA24010P1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.rdo01_CURR_SPEC_HISTORY = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_ALL_SPEC_HISTORY = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.btn01_INQUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_SPEC_HISTORY = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SPEC_HISTORY)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(752, 501);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
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
            this.grd01.Size = new System.Drawing.Size(740, 481);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // rdo01_CURR_SPEC_HISTORY
            // 
            this.rdo01_CURR_SPEC_HISTORY.AutoSize = true;
            this.rdo01_CURR_SPEC_HISTORY.Checked = true;
            this.rdo01_CURR_SPEC_HISTORY.Location = new System.Drawing.Point(121, 15);
            this.rdo01_CURR_SPEC_HISTORY.Name = "rdo01_CURR_SPEC_HISTORY";
            this.rdo01_CURR_SPEC_HISTORY.Size = new System.Drawing.Size(84, 16);
            this.rdo01_CURR_SPEC_HISTORY.TabIndex = 0;
            this.rdo01_CURR_SPEC_HISTORY.TabStop = true;
            this.rdo01_CURR_SPEC_HISTORY.Text = "현재 SPEC";
            this.rdo01_CURR_SPEC_HISTORY.UseVisualStyleBackColor = true;
            // 
            // rdo01_ALL_SPEC_HISTORY
            // 
            this.rdo01_ALL_SPEC_HISTORY.AutoSize = true;
            this.rdo01_ALL_SPEC_HISTORY.Location = new System.Drawing.Point(217, 15);
            this.rdo01_ALL_SPEC_HISTORY.Name = "rdo01_ALL_SPEC_HISTORY";
            this.rdo01_ALL_SPEC_HISTORY.Size = new System.Drawing.Size(84, 16);
            this.rdo01_ALL_SPEC_HISTORY.TabIndex = 1;
            this.rdo01_ALL_SPEC_HISTORY.Text = "전체 SPEC";
            this.rdo01_ALL_SPEC_HISTORY.UseVisualStyleBackColor = true;
            // 
            // btn01_INQUERY
            // 
            this.btn01_INQUERY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_INQUERY.Location = new System.Drawing.Point(669, 10);
            this.btn01_INQUERY.Name = "btn01_INQUERY";
            this.btn01_INQUERY.Size = new System.Drawing.Size(77, 24);
            this.btn01_INQUERY.TabIndex = 20;
            this.btn01_INQUERY.Text = "조회";
            this.btn01_INQUERY.UseVisualStyleBackColor = true;
            this.btn01_INQUERY.Click += new System.EventHandler(this.btn01_INQUERY_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_SPEC_HISTORY);
            this.groupBox1.Controls.Add(this.rdo01_ALL_SPEC_HISTORY);
            this.groupBox1.Controls.Add(this.rdo01_CURR_SPEC_HISTORY);
            this.groupBox1.Controls.Add(this.btn01_INQUERY);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 39);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_SPEC_HISTORY
            // 
            this.lbl01_SPEC_HISTORY.AutoFontSizeMaxValue = 9F;
            this.lbl01_SPEC_HISTORY.AutoFontSizeMinValue = 9F;
            this.lbl01_SPEC_HISTORY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SPEC_HISTORY.Location = new System.Drawing.Point(6, 12);
            this.lbl01_SPEC_HISTORY.Name = "lbl01_SPEC_HISTORY";
            this.lbl01_SPEC_HISTORY.Size = new System.Drawing.Size(107, 21);
            this.lbl01_SPEC_HISTORY.TabIndex = 21;
            this.lbl01_SPEC_HISTORY.Tag = null;
            this.lbl01_SPEC_HISTORY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SPEC_HISTORY.Value = "열람이력구분";
            // 
            // QA24010P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QA24010P1";
            this.Size = new System.Drawing.Size(752, 540);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SPEC_HISTORY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_ALL_SPEC_HISTORY;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_CURR_SPEC_HISTORY;
        private Ax.DEV.Utility.Controls.AxButton btn01_INQUERY;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SPEC_HISTORY;
    }
}
