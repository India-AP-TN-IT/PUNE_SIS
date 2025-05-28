namespace Ax.SIS.XM.UI
{
    partial class XM20304
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
            this.lbl01_LANGUAGE = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab01_XM20304_TAB_1 = new System.Windows.Forms.TabPage();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tab01_XM20304_TAB_2 = new System.Windows.Forms.TabPage();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cdx01_NATIONCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cbo01_LANGUAGE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_CODE = new Ax.DEV.Utility.Controls.AxTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LANGUAGE)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab01_XM20304_TAB_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.tab01_XM20304_TAB_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_NATIONCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODE)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl01_LANGUAGE
            // 
            this.lbl01_LANGUAGE.AutoFontSizeMaxValue = 9F;
            this.lbl01_LANGUAGE.AutoFontSizeMinValue = 9F;
            this.lbl01_LANGUAGE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LANGUAGE.Location = new System.Drawing.Point(6, 13);
            this.lbl01_LANGUAGE.Name = "lbl01_LANGUAGE";
            this.lbl01_LANGUAGE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LANGUAGE.TabIndex = 1;
            this.lbl01_LANGUAGE.Tag = null;
            this.lbl01_LANGUAGE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LANGUAGE.Value = "언어";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab01_XM20304_TAB_1);
            this.tabControl1.Controls.Add(this.tab01_XM20304_TAB_2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 694);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tab01_XM20304_TAB_1
            // 
            this.tab01_XM20304_TAB_1.Controls.Add(this.grd01);
            this.tab01_XM20304_TAB_1.Location = new System.Drawing.Point(4, 22);
            this.tab01_XM20304_TAB_1.Name = "tab01_XM20304_TAB_1";
            this.tab01_XM20304_TAB_1.Padding = new System.Windows.Forms.Padding(3);
            this.tab01_XM20304_TAB_1.Size = new System.Drawing.Size(1016, 668);
            this.tab01_XM20304_TAB_1.TabIndex = 0;
            this.tab01_XM20304_TAB_1.Text = "법인 정보";
            this.tab01_XM20304_TAB_1.UseVisualStyleBackColor = true;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 3);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1010, 662);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd_AfterEdit);
            this.grd01.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDoubleClick);
            // 
            // tab01_XM20304_TAB_2
            // 
            this.tab01_XM20304_TAB_2.Controls.Add(this.grd02);
            this.tab01_XM20304_TAB_2.Location = new System.Drawing.Point(4, 22);
            this.tab01_XM20304_TAB_2.Name = "tab01_XM20304_TAB_2";
            this.tab01_XM20304_TAB_2.Padding = new System.Windows.Forms.Padding(3);
            this.tab01_XM20304_TAB_2.Size = new System.Drawing.Size(1016, 668);
            this.tab01_XM20304_TAB_2.TabIndex = 1;
            this.tab01_XM20304_TAB_2.Text = "사업장 정보";
            this.tab01_XM20304_TAB_2.UseVisualStyleBackColor = true;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 3);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(1010, 662);
            this.grd02.TabIndex = 1;
            this.grd02.UseCustomHighlight = true;
            this.grd02.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd_AfterEdit);
            this.grd02.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
            this.grd02.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cdx01_NATIONCD);
            this.groupBox1.Controls.Add(this.cbo01_LANGUAGE);
            this.groupBox1.Controls.Add(this.lbl01_CORCD);
            this.groupBox1.Controls.Add(this.txt01_CODE);
            this.groupBox1.Controls.Add(this.lbl01_LANGUAGE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cdx01_NATIONCD
            // 
            this.cdx01_NATIONCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_NATIONCD.CodeParameterName = "CODE";
            this.cdx01_NATIONCD.CodeTextBoxReadOnly = false;
            this.cdx01_NATIONCD.CodeTextBoxVisible = true;
            this.cdx01_NATIONCD.CodeTextBoxWidth = 40;
            this.cdx01_NATIONCD.HEPopupHelper = null;
            this.cdx01_NATIONCD.Location = new System.Drawing.Point(783, 14);
            this.cdx01_NATIONCD.Name = "cdx01_NATIONCD";
            this.cdx01_NATIONCD.NameParameterName = "NAME";
            this.cdx01_NATIONCD.NameTextBoxReadOnly = false;
            this.cdx01_NATIONCD.NameTextBoxVisible = true;
            this.cdx01_NATIONCD.PopupButtonReadOnly = false;
            this.cdx01_NATIONCD.PopupTitle = "";
            this.cdx01_NATIONCD.PrefixCode = "";
            this.cdx01_NATIONCD.Size = new System.Drawing.Size(121, 21);
            this.cdx01_NATIONCD.TabIndex = 69;
            this.cdx01_NATIONCD.Tag = null;
            this.cdx01_NATIONCD.Visible = false;
            // 
            // cbo01_LANGUAGE
            // 
            this.cbo01_LANGUAGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_LANGUAGE.FormattingEnabled = true;
            this.cbo01_LANGUAGE.Location = new System.Drawing.Point(112, 13);
            this.cbo01_LANGUAGE.Name = "cbo01_LANGUAGE";
            this.cbo01_LANGUAGE.Size = new System.Drawing.Size(121, 20);
            this.cbo01_LANGUAGE.TabIndex = 6;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(239, 13);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CORCD.TabIndex = 5;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "법인코드";
            // 
            // txt01_CODE
            // 
            this.txt01_CODE.Location = new System.Drawing.Point(345, 13);
            this.txt01_CODE.Name = "txt01_CODE";
            this.txt01_CODE.Size = new System.Drawing.Size(120, 21);
            this.txt01_CODE.TabIndex = 2;
            this.txt01_CODE.Tag = null;
            // 
            // XM20304
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "XM20304";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LANGUAGE)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab01_XM20304_TAB_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.tab01_XM20304_TAB_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_NATIONCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_LANGUAGE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxTextBox txt01_CODE;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private DEV.Utility.Controls.AxComboBox cbo01_LANGUAGE;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab01_XM20304_TAB_1;
        private System.Windows.Forms.TabPage tab01_XM20304_TAB_2;
        private DEV.Utility.Controls.AxFlexGrid grd02;
        private DEV.Utility.Controls.AxCodeBox cdx01_NATIONCD;
    }
}
