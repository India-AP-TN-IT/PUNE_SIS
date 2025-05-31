namespace Ax.SIS.XM.UI
{
    partial class XM30410
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
            this.행삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행취소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_CATEGORY = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CATEGORY = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_SEARCH = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_TITLE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_SUBJECT = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.axSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt01_LINK_COLUMN = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt02_QUERY = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_QUERY = new Ax.DEV.Utility.Controls.AxTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CATEGORY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SUBJECT)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINK_COLUMN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_QUERY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_QUERY)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // 행삭제ToolStripMenuItem
            // 
            this.행삭제ToolStripMenuItem.Name = "행삭제ToolStripMenuItem";
            this.행삭제ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 행취소ToolStripMenuItem
            // 
            this.행취소ToolStripMenuItem.Name = "행취소ToolStripMenuItem";
            this.행취소ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_CATEGORY);
            this.groupBox1.Controls.Add(this.lbl01_CATEGORY);
            this.groupBox1.Controls.Add(this.btn01_SEARCH);
            this.groupBox1.Controls.Add(this.txt01_TITLE);
            this.groupBox1.Controls.Add(this.lbl01_SUBJECT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 41);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_CATEGORY
            // 
            this.cbo01_CATEGORY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CATEGORY.FormattingEnabled = true;
            this.cbo01_CATEGORY.Location = new System.Drawing.Point(460, 15);
            this.cbo01_CATEGORY.Name = "cbo01_CATEGORY";
            this.cbo01_CATEGORY.Size = new System.Drawing.Size(139, 20);
            this.cbo01_CATEGORY.TabIndex = 88;
            // 
            // lbl01_CATEGORY
            // 
            this.lbl01_CATEGORY.AutoFontSizeMaxValue = 9F;
            this.lbl01_CATEGORY.AutoFontSizeMinValue = 9F;
            this.lbl01_CATEGORY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CATEGORY.Location = new System.Drawing.Point(385, 16);
            this.lbl01_CATEGORY.Name = "lbl01_CATEGORY";
            this.lbl01_CATEGORY.Size = new System.Drawing.Size(69, 20);
            this.lbl01_CATEGORY.TabIndex = 87;
            this.lbl01_CATEGORY.Tag = null;
            this.lbl01_CATEGORY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CATEGORY.Value = "Category";
            // 
            // btn01_SEARCH
            // 
            this.btn01_SEARCH.Location = new System.Drawing.Point(605, 14);
            this.btn01_SEARCH.Name = "btn01_SEARCH";
            this.btn01_SEARCH.Size = new System.Drawing.Size(102, 21);
            this.btn01_SEARCH.TabIndex = 0;
            this.btn01_SEARCH.Text = "Find";
            this.btn01_SEARCH.UseVisualStyleBackColor = true;
            this.btn01_SEARCH.Click += new System.EventHandler(this.btn01_SEARCH_Click);
            // 
            // txt01_TITLE
            // 
            this.txt01_TITLE.Location = new System.Drawing.Point(111, 15);
            this.txt01_TITLE.Name = "txt01_TITLE";
            this.txt01_TITLE.Size = new System.Drawing.Size(268, 21);
            this.txt01_TITLE.TabIndex = 5;
            this.txt01_TITLE.Tag = null;
            this.txt01_TITLE.TextDetached = true;
            // 
            // lbl01_SUBJECT
            // 
            this.lbl01_SUBJECT.AutoFontSizeMaxValue = 9F;
            this.lbl01_SUBJECT.AutoFontSizeMinValue = 9F;
            this.lbl01_SUBJECT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SUBJECT.Location = new System.Drawing.Point(5, 15);
            this.lbl01_SUBJECT.Name = "lbl01_SUBJECT";
            this.lbl01_SUBJECT.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SUBJECT.TabIndex = 4;
            this.lbl01_SUBJECT.Tag = null;
            this.lbl01_SUBJECT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SUBJECT.Value = "Subject";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.axDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 693);
            this.panel1.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.axSplitter1);
            this.panel4.Controls.Add(this.grd02);
            this.panel4.Controls.Add(this.grd03);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(379, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(645, 693);
            this.panel4.TabIndex = 30;
            // 
            // axSplitter1
            // 
            this.axSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.axSplitter1.Location = new System.Drawing.Point(0, 335);
            this.axSplitter1.Name = "axSplitter1";
            this.axSplitter1.Size = new System.Drawing.Size(645, 5);
            this.axSplitter1.TabIndex = 8;
            this.axSplitter1.TabStop = false;
            this.axSplitter1.Visible = false;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(645, 340);
            this.grd02.TabIndex = 6;
            this.grd02.UseCustomHighlight = true;
            this.grd02.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseDoubleClick);
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grd03.EnabledActionFlag = true;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(0, 340);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(645, 353);
            this.grd03.TabIndex = 7;
            this.grd03.UseCustomHighlight = true;
            this.grd03.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 693);
            this.panel2.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txt01_LINK_COLUMN);
            this.panel5.Controls.Add(this.txt02_QUERY);
            this.panel5.Controls.Add(this.txt01_QUERY);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 641);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(379, 52);
            this.panel5.TabIndex = 1;
            // 
            // txt01_LINK_COLUMN
            // 
            this.txt01_LINK_COLUMN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_LINK_COLUMN.Location = new System.Drawing.Point(36, 131);
            this.txt01_LINK_COLUMN.Multiline = true;
            this.txt01_LINK_COLUMN.Name = "txt01_LINK_COLUMN";
            this.txt01_LINK_COLUMN.Size = new System.Drawing.Size(269, 28);
            this.txt01_LINK_COLUMN.TabIndex = 13;
            this.txt01_LINK_COLUMN.Tag = null;
            this.txt01_LINK_COLUMN.Visible = false;
            // 
            // txt02_QUERY
            // 
            this.txt02_QUERY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt02_QUERY.Location = new System.Drawing.Point(36, 163);
            this.txt02_QUERY.Multiline = true;
            this.txt02_QUERY.Name = "txt02_QUERY";
            this.txt02_QUERY.Size = new System.Drawing.Size(269, 28);
            this.txt02_QUERY.TabIndex = 12;
            this.txt02_QUERY.Tag = null;
            this.txt02_QUERY.Visible = false;
            // 
            // txt01_QUERY
            // 
            this.txt01_QUERY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_QUERY.Location = new System.Drawing.Point(36, 195);
            this.txt01_QUERY.Multiline = true;
            this.txt01_QUERY.Name = "txt01_QUERY";
            this.txt01_QUERY.Size = new System.Drawing.Size(269, 28);
            this.txt01_QUERY.TabIndex = 11;
            this.txt01_QUERY.Tag = null;
            this.txt01_QUERY.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 641);
            this.panel3.TabIndex = 0;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.ExtendLastCol = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(379, 641);
            this.grd01.TabIndex = 5;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // axDockingTab1
            // 
            this.axDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.axDockingTab1.Name = "axDockingTab1";
            this.axDockingTab1.PanelHeight = 693;
            this.axDockingTab1.PanelWidth = 384;
            this.axDockingTab1.Size = new System.Drawing.Size(1024, 693);
            this.axDockingTab1.TabIndex = 14;
            // 
            // XM30410
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "XM30410";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CATEGORY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SUBJECT)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LINK_COLUMN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_QUERY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_QUERY)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
                
        private System.Windows.Forms.ToolStripMenuItem 행삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행취소ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_TITLE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SUBJECT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_QUERY;
        private Ax.DEV.Utility.Controls.AxButton btn01_SEARCH;
        private DEV.Utility.Controls.AxSplitter axSplitter1;
        private DEV.Utility.Controls.AxFlexGrid grd03;
        private DEV.Utility.Controls.AxTextBox txt02_QUERY;
        private DEV.Utility.Controls.AxTextBox txt01_LINK_COLUMN;
        private DEV.Utility.Controls.AxDockingTab axDockingTab1;
        private DEV.Utility.Controls.AxComboBox cbo01_CATEGORY;
        private DEV.Utility.Controls.AxLabel lbl01_CATEGORY;


    }
}

