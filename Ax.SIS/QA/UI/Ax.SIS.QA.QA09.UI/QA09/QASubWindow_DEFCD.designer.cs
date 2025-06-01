namespace Ax.SIS.QA.QA09.UI
{
    partial class QASubWindow_DEFCD
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdLeft = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl01_DEFCD_POPUP_REMARK = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_DEF_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_Inquery = new Ax.DEV.Utility.Controls.AxButton();
            this.cbo01_DEFKINDCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt01_NAME = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_NAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_CODE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLeft)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEF_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODE)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(723, 430);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AutoGenerateColumns = false;
            this.grd01.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.ExtendLastCol = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(300, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 1;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(420, 410);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(297, 17);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 410);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdLeft);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 410);
            this.panel1.TabIndex = 3;
            // 
            // grdLeft
            // 
            this.grdLeft.AllowHeaderMerging = false;
            this.grdLeft.AutoGenerateColumns = false;
            this.grdLeft.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grdLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLeft.EnabledActionFlag = true;
            this.grdLeft.ExtendLastCol = true;
            this.grdLeft.LastRowAdd = false;
            this.grdLeft.Location = new System.Drawing.Point(0, 0);
            this.grdLeft.Name = "grdLeft";
            this.grdLeft.OriginalFormat = null;
            this.grdLeft.PopMenuVisible = true;
            this.grdLeft.Rows.Count = 1;
            this.grdLeft.Rows.DefaultSize = 18;
            this.grdLeft.Size = new System.Drawing.Size(294, 355);
            this.grdLeft.TabIndex = 1;
            this.grdLeft.UseCustomHighlight = true;
            this.grdLeft.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grdLeft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdLeft_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbl01_DEFCD_POPUP_REMARK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 355);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 55);
            this.panel2.TabIndex = 3;
            // 
            // lbl01_DEFCD_POPUP_REMARK
            // 
            this.lbl01_DEFCD_POPUP_REMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl01_DEFCD_POPUP_REMARK.Location = new System.Drawing.Point(0, 0);
            this.lbl01_DEFCD_POPUP_REMARK.Name = "lbl01_DEFCD_POPUP_REMARK";
            this.lbl01_DEFCD_POPUP_REMARK.Padding = new System.Windows.Forms.Padding(5);
            this.lbl01_DEFCD_POPUP_REMARK.Size = new System.Drawing.Size(292, 53);
            this.lbl01_DEFCD_POPUP_REMARK.TabIndex = 2;
            this.lbl01_DEFCD_POPUP_REMARK.Text = "불량유형 선택시 해당되는 불량코드가 조회됩니다.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_DEF_TYPE);
            this.groupBox1.Controls.Add(this.btn01_Inquery);
            this.groupBox1.Controls.Add(this.cbo01_DEFKINDCD);
            this.groupBox1.Controls.Add(this.txt01_NAME);
            this.groupBox1.Controls.Add(this.lbl01_NAME);
            this.groupBox1.Controls.Add(this.txt01_CODE);
            this.groupBox1.Controls.Add(this.lbl01_CODE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(723, 41);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_DEF_TYPE
            // 
            this.lbl01_DEF_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DEF_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_DEF_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DEF_TYPE.Location = new System.Drawing.Point(5, 13);
            this.lbl01_DEF_TYPE.Name = "lbl01_DEF_TYPE";
            this.lbl01_DEF_TYPE.Size = new System.Drawing.Size(90, 21);
            this.lbl01_DEF_TYPE.TabIndex = 14;
            this.lbl01_DEF_TYPE.Tag = null;
            this.lbl01_DEF_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DEF_TYPE.Value = "불량유형";
            // 
            // btn01_Inquery
            // 
            this.btn01_Inquery.Location = new System.Drawing.Point(639, 12);
            this.btn01_Inquery.Name = "btn01_Inquery";
            this.btn01_Inquery.Size = new System.Drawing.Size(75, 23);
            this.btn01_Inquery.TabIndex = 6;
            this.btn01_Inquery.Text = "조회";
            this.btn01_Inquery.UseVisualStyleBackColor = true;
            this.btn01_Inquery.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // cbo01_DEFKINDCD
            // 
            this.cbo01_DEFKINDCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DEFKINDCD.FormattingEnabled = true;
            this.cbo01_DEFKINDCD.Location = new System.Drawing.Point(101, 13);
            this.cbo01_DEFKINDCD.Name = "cbo01_DEFKINDCD";
            this.cbo01_DEFKINDCD.Size = new System.Drawing.Size(100, 20);
            this.cbo01_DEFKINDCD.TabIndex = 13;
            // 
            // txt01_NAME
            // 
            this.txt01_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_NAME.Location = new System.Drawing.Point(505, 13);
            this.txt01_NAME.Name = "txt01_NAME";
            this.txt01_NAME.Size = new System.Drawing.Size(130, 21);
            this.txt01_NAME.TabIndex = 4;
            this.txt01_NAME.Tag = null;
            // 
            // lbl01_NAME
            // 
            this.lbl01_NAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_NAME.AutoFontSizeMinValue = 9F;
            this.lbl01_NAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_NAME.Location = new System.Drawing.Point(409, 13);
            this.lbl01_NAME.Name = "lbl01_NAME";
            this.lbl01_NAME.Size = new System.Drawing.Size(90, 21);
            this.lbl01_NAME.TabIndex = 3;
            this.lbl01_NAME.Tag = null;
            this.lbl01_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_NAME.Value = "검사명";
            // 
            // txt01_CODE
            // 
            this.txt01_CODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CODE.Location = new System.Drawing.Point(303, 13);
            this.txt01_CODE.Name = "txt01_CODE";
            this.txt01_CODE.Size = new System.Drawing.Size(100, 21);
            this.txt01_CODE.TabIndex = 2;
            this.txt01_CODE.Tag = null;
            // 
            // lbl01_CODE
            // 
            this.lbl01_CODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CODE.AutoFontSizeMinValue = 9F;
            this.lbl01_CODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CODE.Location = new System.Drawing.Point(207, 13);
            this.lbl01_CODE.Name = "lbl01_CODE";
            this.lbl01_CODE.Size = new System.Drawing.Size(90, 21);
            this.lbl01_CODE.TabIndex = 1;
            this.lbl01_CODE.Tag = null;
            this.lbl01_CODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CODE.Value = "검사코드";
            // 
            // QASubWindow_DEFCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QASubWindow_DEFCD";
            this.Size = new System.Drawing.Size(723, 471);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLeft)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEF_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxButton btn01_Inquery;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_NAME;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_NAME;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_CODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CODE;
        private DEV.Utility.Controls.AxFlexGrid grdLeft;
        private System.Windows.Forms.Splitter splitter1;
        private DEV.Utility.Controls.AxLabel lbl01_DEF_TYPE;
        private DEV.Utility.Controls.AxComboBox cbo01_DEFKINDCD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl01_DEFCD_POPUP_REMARK;

    }
}
