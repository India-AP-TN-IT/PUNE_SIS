namespace Ax.SIS.XM.UI
{
    partial class XM20102P1
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
            this.grp01_XM20102P1_GRP_2 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_XM20102P1_GRP_1 = new System.Windows.Forms.GroupBox();
            this.btn01_CLOSE = new Ax.DEV.Utility.Controls.AxButton();
            this.btn03_REMOVE = new Ax.DEV.Utility.Controls.AxButton();
            this.btn03_SAVE = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_QUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl01_GRIDNAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_HEADERCOUNT = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_HEADERCOUNT = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_GRIDNAME = new Ax.DEV.Utility.Controls.AxTextBox();
            this.panel1.SuspendLayout();
            this.grp01_XM20102P1_GRP_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.grp01_XM20102P1_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_GRIDNAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_HEADERCOUNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_HEADERCOUNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_GRIDNAME)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grp01_XM20102P1_GRP_2);
            this.panel1.Controls.Add(this.grp01_XM20102P1_GRP_1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 600);
            this.panel1.TabIndex = 2;
            // 
            // grp01_XM20102P1_GRP_2
            // 
            this.grp01_XM20102P1_GRP_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_XM20102P1_GRP_2.Controls.Add(this.grd01);
            this.grp01_XM20102P1_GRP_2.ForeColor = System.Drawing.Color.Black;
            this.grp01_XM20102P1_GRP_2.Location = new System.Drawing.Point(0, 46);
            this.grp01_XM20102P1_GRP_2.Name = "grp01_XM20102P1_GRP_2";
            this.grp01_XM20102P1_GRP_2.Size = new System.Drawing.Size(900, 551);
            this.grp01_XM20102P1_GRP_2.TabIndex = 0;
            this.grp01_XM20102P1_GRP_2.TabStop = false;
            this.grp01_XM20102P1_GRP_2.Text = "그리드 정보";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(894, 531);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // grp01_XM20102P1_GRP_1
            // 
            this.grp01_XM20102P1_GRP_1.Controls.Add(this.btn01_CLOSE);
            this.grp01_XM20102P1_GRP_1.Controls.Add(this.btn03_REMOVE);
            this.grp01_XM20102P1_GRP_1.Controls.Add(this.btn03_SAVE);
            this.grp01_XM20102P1_GRP_1.Controls.Add(this.btn01_QUERY);
            this.grp01_XM20102P1_GRP_1.Controls.Add(this.lbl01_GRIDNAME);
            this.grp01_XM20102P1_GRP_1.Controls.Add(this.txt01_HEADERCOUNT);
            this.grp01_XM20102P1_GRP_1.Controls.Add(this.lbl01_HEADERCOUNT);
            this.grp01_XM20102P1_GRP_1.Controls.Add(this.txt01_GRIDNAME);
            this.grp01_XM20102P1_GRP_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_XM20102P1_GRP_1.Location = new System.Drawing.Point(0, 0);
            this.grp01_XM20102P1_GRP_1.Name = "grp01_XM20102P1_GRP_1";
            this.grp01_XM20102P1_GRP_1.Size = new System.Drawing.Size(900, 40);
            this.grp01_XM20102P1_GRP_1.TabIndex = 2;
            this.grp01_XM20102P1_GRP_1.TabStop = false;
            this.grp01_XM20102P1_GRP_1.Text = "선택된 그리드";
            // 
            // btn01_CLOSE
            // 
            this.btn01_CLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_CLOSE.Location = new System.Drawing.Point(842, 13);
            this.btn01_CLOSE.Name = "btn01_CLOSE";
            this.btn01_CLOSE.Size = new System.Drawing.Size(52, 20);
            this.btn01_CLOSE.TabIndex = 35;
            this.btn01_CLOSE.Text = "닫기";
            this.btn01_CLOSE.UseVisualStyleBackColor = true;
            this.btn01_CLOSE.Click += new System.EventHandler(this.btn01_CLOSE_Click);
            // 
            // btn03_REMOVE
            // 
            this.btn03_REMOVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn03_REMOVE.Location = new System.Drawing.Point(784, 13);
            this.btn03_REMOVE.Name = "btn03_REMOVE";
            this.btn03_REMOVE.Size = new System.Drawing.Size(52, 20);
            this.btn03_REMOVE.TabIndex = 34;
            this.btn03_REMOVE.Text = "삭제";
            this.btn03_REMOVE.UseVisualStyleBackColor = true;
            this.btn03_REMOVE.Click += new System.EventHandler(this.btn03_Remove_Click);
            // 
            // btn03_SAVE
            // 
            this.btn03_SAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn03_SAVE.Location = new System.Drawing.Point(726, 13);
            this.btn03_SAVE.Name = "btn03_SAVE";
            this.btn03_SAVE.Size = new System.Drawing.Size(52, 20);
            this.btn03_SAVE.TabIndex = 33;
            this.btn03_SAVE.Text = "저장";
            this.btn03_SAVE.UseVisualStyleBackColor = true;
            this.btn03_SAVE.Click += new System.EventHandler(this.btn03_Save_Click);
            // 
            // btn01_QUERY
            // 
            this.btn01_QUERY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_QUERY.Location = new System.Drawing.Point(668, 13);
            this.btn01_QUERY.Name = "btn01_QUERY";
            this.btn01_QUERY.Size = new System.Drawing.Size(52, 20);
            this.btn01_QUERY.TabIndex = 32;
            this.btn01_QUERY.Text = "조회";
            this.btn01_QUERY.UseVisualStyleBackColor = true;
            this.btn01_QUERY.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // lbl01_GRIDNAME
            // 
            this.lbl01_GRIDNAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_GRIDNAME.AutoFontSizeMinValue = 9F;
            this.lbl01_GRIDNAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_GRIDNAME.Location = new System.Drawing.Point(6, 13);
            this.lbl01_GRIDNAME.Name = "lbl01_GRIDNAME";
            this.lbl01_GRIDNAME.Size = new System.Drawing.Size(100, 21);
            this.lbl01_GRIDNAME.TabIndex = 5;
            this.lbl01_GRIDNAME.Tag = null;
            this.lbl01_GRIDNAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_GRIDNAME.Value = "그리드명";
            // 
            // txt01_HEADERCOUNT
            // 
            this.txt01_HEADERCOUNT.Location = new System.Drawing.Point(344, 13);
            this.txt01_HEADERCOUNT.Name = "txt01_HEADERCOUNT";
            this.txt01_HEADERCOUNT.Size = new System.Drawing.Size(91, 21);
            this.txt01_HEADERCOUNT.TabIndex = 4;
            this.txt01_HEADERCOUNT.Tag = null;
            this.txt01_HEADERCOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl01_HEADERCOUNT
            // 
            this.lbl01_HEADERCOUNT.AutoFontSizeMaxValue = 9F;
            this.lbl01_HEADERCOUNT.AutoFontSizeMinValue = 9F;
            this.lbl01_HEADERCOUNT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_HEADERCOUNT.Location = new System.Drawing.Point(238, 13);
            this.lbl01_HEADERCOUNT.Name = "lbl01_HEADERCOUNT";
            this.lbl01_HEADERCOUNT.Size = new System.Drawing.Size(100, 21);
            this.lbl01_HEADERCOUNT.TabIndex = 3;
            this.lbl01_HEADERCOUNT.Tag = null;
            this.lbl01_HEADERCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_HEADERCOUNT.Value = "헤더갯수";
            // 
            // txt01_GRIDNAME
            // 
            this.txt01_GRIDNAME.Location = new System.Drawing.Point(112, 13);
            this.txt01_GRIDNAME.Name = "txt01_GRIDNAME";
            this.txt01_GRIDNAME.Size = new System.Drawing.Size(120, 21);
            this.txt01_GRIDNAME.TabIndex = 2;
            this.txt01_GRIDNAME.Tag = null;
            // 
            // XM20102P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "XM20102P1";
            this.Size = new System.Drawing.Size(900, 600);
            this.panel1.ResumeLayout(false);
            this.grp01_XM20102P1_GRP_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.grp01_XM20102P1_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_GRIDNAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_HEADERCOUNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_HEADERCOUNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_GRIDNAME)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grp01_XM20102P1_GRP_1;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_HEADERCOUNT;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_HEADERCOUNT;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_GRIDNAME;
        private System.Windows.Forms.GroupBox grp01_XM20102P1_GRP_2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_GRIDNAME;
        private Ax.DEV.Utility.Controls.AxButton btn01_QUERY;
        private Ax.DEV.Utility.Controls.AxButton btn03_SAVE;
        private Ax.DEV.Utility.Controls.AxButton btn03_REMOVE;
        private Ax.DEV.Utility.Controls.AxButton btn01_CLOSE;
    }
}
