namespace Ax.SIS.XM.UI
{
    partial class XM30303P1
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
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.btn01_Inquery = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_TYPENM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_TYPENM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_TYPECD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_TYPECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TYPENM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TYPENM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TYPECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TYPECD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd03);
            this.groupBox2.Controls.Add(this.grd02);
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 332);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.AutoGenerateColumns = false;
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03.EnabledActionFlag = true;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 17);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.Count = 1;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(604, 312);
            this.grd03.TabIndex = 2;
            this.grd03.UseCustomHighlight = true;
            this.grd03.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd03.DoubleClick += new System.EventHandler(this.grd03_DoubleClick);
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.AutoGenerateColumns = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.Count = 1;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(604, 312);
            this.grd02.TabIndex = 1;
            this.grd02.UseCustomHighlight = true;
            this.grd02.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd02.DoubleClick += new System.EventHandler(this.grd02_DoubleClick);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AutoGenerateColumns = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 1;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(604, 312);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.btn01_Inquery);
            this.groupBox1.Controls.Add(this.txt01_TYPENM);
            this.groupBox1.Controls.Add(this.lbl01_TYPENM);
            this.groupBox1.Controls.Add(this.txt01_TYPECD);
            this.groupBox1.Controls.Add(this.lbl01_TYPECD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 68);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(6, 40);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 8;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(206, 20);
            this.cbo01_BIZCD.TabIndex = 7;
            // 
            // btn01_Inquery
            // 
            this.btn01_Inquery.Location = new System.Drawing.Point(530, 12);
            this.btn01_Inquery.Name = "btn01_Inquery";
            this.btn01_Inquery.Size = new System.Drawing.Size(75, 23);
            this.btn01_Inquery.TabIndex = 6;
            this.btn01_Inquery.Text = "조회";
            this.btn01_Inquery.UseVisualStyleBackColor = true;
            this.btn01_Inquery.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // txt01_TYPENM
            // 
            this.txt01_TYPENM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_TYPENM.Location = new System.Drawing.Point(324, 13);
            this.txt01_TYPENM.Name = "txt01_TYPENM";
            this.txt01_TYPENM.Size = new System.Drawing.Size(200, 21);
            this.txt01_TYPENM.TabIndex = 4;
            this.txt01_TYPENM.Tag = null;
            // 
            // lbl01_TYPENM
            // 
            this.lbl01_TYPENM.AutoFontSizeMaxValue = 9F;
            this.lbl01_TYPENM.AutoFontSizeMinValue = 9F;
            this.lbl01_TYPENM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_TYPENM.Location = new System.Drawing.Point(218, 13);
            this.lbl01_TYPENM.Name = "lbl01_TYPENM";
            this.lbl01_TYPENM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_TYPENM.TabIndex = 3;
            this.lbl01_TYPENM.Tag = null;
            this.lbl01_TYPENM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_TYPENM.Value = "";
            // 
            // txt01_TYPECD
            // 
            this.txt01_TYPECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_TYPECD.Location = new System.Drawing.Point(112, 13);
            this.txt01_TYPECD.Name = "txt01_TYPECD";
            this.txt01_TYPECD.Size = new System.Drawing.Size(100, 21);
            this.txt01_TYPECD.TabIndex = 2;
            this.txt01_TYPECD.Tag = null;
            // 
            // lbl01_TYPECD
            // 
            this.lbl01_TYPECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_TYPECD.AutoFontSizeMinValue = 9F;
            this.lbl01_TYPECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_TYPECD.Location = new System.Drawing.Point(6, 13);
            this.lbl01_TYPECD.Name = "lbl01_TYPECD";
            this.lbl01_TYPECD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_TYPECD.TabIndex = 1;
            this.lbl01_TYPECD.Tag = null;
            this.lbl01_TYPECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_TYPECD.Value = "";
            // 
            // XM30303P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "XM30303P1";
            this.Size = new System.Drawing.Size(610, 400);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TYPENM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TYPENM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_TYPECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_TYPECD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxButton btn01_Inquery;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_TYPENM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_TYPENM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_TYPECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_TYPECD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
    }
}
