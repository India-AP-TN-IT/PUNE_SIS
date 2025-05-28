namespace Ax.SIS.QA.QA02.UI
{
    partial class QA20910P1
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.grp01_SEARCH = new System.Windows.Forms.GroupBox();
            this.lbl01_CODE_OR_NAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_GA_QUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_SEARCH = new Ax.DEV.Utility.Controls.AxTextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel2.SuspendLayout();
            this.grp01_SEARCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODE_OR_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SEARCH)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 414);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(442, 341);
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
            this.grd01.Location = new System.Drawing.Point(3, 3);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 1;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(436, 335);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grp01_SEARCH);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(442, 73);
            this.panel2.TabIndex = 0;
            // 
            // grp01_SEARCH
            // 
            this.grp01_SEARCH.Controls.Add(this.lbl01_CODE_OR_NAME);
            this.grp01_SEARCH.Controls.Add(this.btn01_GA_QUERY);
            this.grp01_SEARCH.Controls.Add(this.txt01_SEARCH);
            this.grp01_SEARCH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_SEARCH.Location = new System.Drawing.Point(3, 3);
            this.grp01_SEARCH.Name = "grp01_SEARCH";
            this.grp01_SEARCH.Size = new System.Drawing.Size(436, 67);
            this.grp01_SEARCH.TabIndex = 0;
            this.grp01_SEARCH.TabStop = false;
            // 
            // lbl01_CODE_OR_NAME
            // 
            this.lbl01_CODE_OR_NAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_CODE_OR_NAME.AutoFontSizeMinValue = 9F;
            this.lbl01_CODE_OR_NAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CODE_OR_NAME.Location = new System.Drawing.Point(6, 13);
            this.lbl01_CODE_OR_NAME.Name = "lbl01_CODE_OR_NAME";
            this.lbl01_CODE_OR_NAME.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CODE_OR_NAME.TabIndex = 119;
            this.lbl01_CODE_OR_NAME.Tag = null;
            this.lbl01_CODE_OR_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CODE_OR_NAME.Value = "코드/명";
            // 
            // btn01_GA_QUERY
            // 
            this.btn01_GA_QUERY.Location = new System.Drawing.Point(342, 12);
            this.btn01_GA_QUERY.Name = "btn01_GA_QUERY";
            this.btn01_GA_QUERY.Size = new System.Drawing.Size(75, 23);
            this.btn01_GA_QUERY.TabIndex = 18;
            this.btn01_GA_QUERY.Text = "조회";
            this.btn01_GA_QUERY.UseVisualStyleBackColor = true;
            this.btn01_GA_QUERY.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // txt01_SEARCH
            // 
            this.txt01_SEARCH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_SEARCH.Location = new System.Drawing.Point(112, 13);
            this.txt01_SEARCH.Name = "txt01_SEARCH";
            this.txt01_SEARCH.Size = new System.Drawing.Size(224, 21);
            this.txt01_SEARCH.TabIndex = 19;
            this.txt01_SEARCH.Tag = null;
            this.txt01_SEARCH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt01_SEARCH_KeyDown);
            // 
            // QA20910P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "QA20910P1";
            this.Size = new System.Drawing.Size(442, 414);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grp01_SEARCH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODE_OR_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_SEARCH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grp01_SEARCH;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxButton btn01_GA_QUERY;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_SEARCH;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CODE_OR_NAME;

    }
}
