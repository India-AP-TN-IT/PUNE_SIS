namespace Ax.SIS.QA.QA02.UI
{
    partial class QA20801P1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_SEARCH = new System.Windows.Forms.GroupBox();
            this.lbl01_SERIAL = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_QUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_SERIAL = new Ax.DEV.Utility.Controls.AxTextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.grp01_SEARCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SERIAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SERIAL)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 414);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Controls.Add(this.grp01_SEARCH);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(663, 414);
            this.panel3.TabIndex = 1;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AutoGenerateColumns = false;
            this.grd01.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 48);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 1;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(657, 363);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            // 
            // grp01_SEARCH
            // 
            this.grp01_SEARCH.Controls.Add(this.lbl01_SERIAL);
            this.grp01_SEARCH.Controls.Add(this.btn01_QUERY);
            this.grp01_SEARCH.Controls.Add(this.txt01_SERIAL);
            this.grp01_SEARCH.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_SEARCH.Location = new System.Drawing.Point(3, 3);
            this.grp01_SEARCH.Name = "grp01_SEARCH";
            this.grp01_SEARCH.Size = new System.Drawing.Size(657, 45);
            this.grp01_SEARCH.TabIndex = 2;
            this.grp01_SEARCH.TabStop = false;
            this.grp01_SEARCH.Visible = false;
            // 
            // lbl01_SERIAL
            // 
            this.lbl01_SERIAL.AutoFontSizeMaxValue = 9F;
            this.lbl01_SERIAL.AutoFontSizeMinValue = 9F;
            this.lbl01_SERIAL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SERIAL.Location = new System.Drawing.Point(6, 16);
            this.lbl01_SERIAL.Name = "lbl01_SERIAL";
            this.lbl01_SERIAL.Size = new System.Drawing.Size(81, 21);
            this.lbl01_SERIAL.TabIndex = 119;
            this.lbl01_SERIAL.Tag = null;
            this.lbl01_SERIAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SERIAL.Value = "SERIAL";
            // 
            // btn01_QUERY
            // 
            this.btn01_QUERY.Location = new System.Drawing.Point(576, 16);
            this.btn01_QUERY.Name = "btn01_QUERY";
            this.btn01_QUERY.Size = new System.Drawing.Size(75, 23);
            this.btn01_QUERY.TabIndex = 18;
            this.btn01_QUERY.Text = "조회";
            this.btn01_QUERY.UseVisualStyleBackColor = true;
            this.btn01_QUERY.Click += new System.EventHandler(this.btn01_QUERY_Click);
            // 
            // txt01_SERIAL
            // 
            this.txt01_SERIAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_SERIAL.Location = new System.Drawing.Point(93, 15);
            this.txt01_SERIAL.Name = "txt01_SERIAL";
            this.txt01_SERIAL.Size = new System.Drawing.Size(128, 21);
            this.txt01_SERIAL.TabIndex = 19;
            this.txt01_SERIAL.Tag = null;
            // 
            // QA20801P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "QA20801P1";
            this.Size = new System.Drawing.Size(663, 414);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.grp01_SEARCH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SERIAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SERIAL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox grp01_SEARCH;
        private DEV.Utility.Controls.AxLabel lbl01_SERIAL;
        private DEV.Utility.Controls.AxButton btn01_QUERY;
        private DEV.Utility.Controls.AxTextBox txt01_SERIAL;

    }
}
