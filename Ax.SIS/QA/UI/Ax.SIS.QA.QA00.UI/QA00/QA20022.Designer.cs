namespace Ax.SIS.QA.QA00.UI
{
    partial class QA20022
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
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd03_QA20022 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.panel10 = new System.Windows.Forms.Panel();
            this.grd01_QA20022 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl01_QA20022_MSG2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grd02_QA20022 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn01_LEFT = new Ax.DEV.Utility.Controls.AxButton();
            this.btn01_RIGHT = new Ax.DEV.Utility.Controls.AxButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.heLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03_QA20022)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20022)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20022_MSG2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA20022)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel4)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = false;
            this.cdx01_LINECD.CodeTextBoxWidth = 40;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(482, 16);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(251, 21);
            this.cdx01_LINECD.TabIndex = 4;
            this.cdx01_LINECD.Tag = null;
            // 
            // lbl01_LINE
            // 
            this.lbl01_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINE.AutoFontSizeMinValue = 9F;
            this.lbl01_LINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINE.Location = new System.Drawing.Point(376, 16);
            this.lbl01_LINE.Name = "lbl01_LINE";
            this.lbl01_LINE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_LINE.TabIndex = 2;
            this.lbl01_LINE.Tag = null;
            this.lbl01_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINE.Value = "라인";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(119, 18);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(251, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 17);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd03_QA20022);
            this.groupBox2.Controls.Add(this.axSplitter1);
            this.groupBox2.Controls.Add(this.panel10);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 681);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "라인별 불량코드 정보";
            // 
            // grd03_QA20022
            // 
            this.grd03_QA20022.AllowHeaderMerging = false;
            this.grd03_QA20022.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd03_QA20022.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03_QA20022.EnabledActionFlag = true;
            this.grd03_QA20022.LastRowAdd = false;
            this.grd03_QA20022.Location = new System.Drawing.Point(469, 17);
            this.grd03_QA20022.Name = "grd03_QA20022";
            this.grd03_QA20022.OriginalFormat = null;
            this.grd03_QA20022.PopMenuVisible = true;
            this.grd03_QA20022.Rows.DefaultSize = 18;
            this.grd03_QA20022.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.grd03_QA20022.Size = new System.Drawing.Size(552, 640);
            this.grd03_QA20022.TabIndex = 0;
            this.grd03_QA20022.UseCustomHighlight = true;
            // 
            // axSplitter1
            // 
            this.axSplitter1.Location = new System.Drawing.Point(465, 17);
            this.axSplitter1.Name = "axSplitter1";
            this.axSplitter1.Size = new System.Drawing.Size(4, 640);
            this.axSplitter1.TabIndex = 3;
            this.axSplitter1.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.grd01_QA20022);
            this.panel10.Controls.Add(this.panel6);
            this.panel10.Controls.Add(this.panel4);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(3, 17);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(462, 640);
            this.panel10.TabIndex = 0;
            // 
            // grd01_QA20022
            // 
            this.grd01_QA20022.AllowHeaderMerging = false;
            this.grd01_QA20022.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA20022.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA20022.EnabledActionFlag = true;
            this.grd01_QA20022.LastRowAdd = false;
            this.grd01_QA20022.Location = new System.Drawing.Point(0, 0);
            this.grd01_QA20022.Name = "grd01_QA20022";
            this.grd01_QA20022.OriginalFormat = null;
            this.grd01_QA20022.PopMenuVisible = true;
            this.grd01_QA20022.Rows.DefaultSize = 18;
            this.grd01_QA20022.Size = new System.Drawing.Size(462, 377);
            this.grd01_QA20022.TabIndex = 0;
            this.grd01_QA20022.UseCustomHighlight = true;
            this.grd01_QA20022.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA20022_MouseDoubleClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbl01_QA20022_MSG2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 377);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(462, 21);
            this.panel6.TabIndex = 3;
            // 
            // lbl01_QA20022_MSG2
            // 
            this.lbl01_QA20022_MSG2.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA20022_MSG2.AutoFontSizeMinValue = 9F;
            this.lbl01_QA20022_MSG2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_QA20022_MSG2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl01_QA20022_MSG2.Location = new System.Drawing.Point(0, 0);
            this.lbl01_QA20022_MSG2.Name = "lbl01_QA20022_MSG2";
            this.lbl01_QA20022_MSG2.Size = new System.Drawing.Size(462, 21);
            this.lbl01_QA20022_MSG2.TabIndex = 3;
            this.lbl01_QA20022_MSG2.Tag = null;
            this.lbl01_QA20022_MSG2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_QA20022_MSG2.Value = "등록가능한목록";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.grd02_QA20022);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 398);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 242);
            this.panel4.TabIndex = 1;
            // 
            // grd02_QA20022
            // 
            this.grd02_QA20022.AllowHeaderMerging = false;
            this.grd02_QA20022.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd02_QA20022.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02_QA20022.EnabledActionFlag = true;
            this.grd02_QA20022.LastRowAdd = false;
            this.grd02_QA20022.Location = new System.Drawing.Point(0, 0);
            this.grd02_QA20022.Name = "grd02_QA20022";
            this.grd02_QA20022.OriginalFormat = null;
            this.grd02_QA20022.PopMenuVisible = true;
            this.grd02_QA20022.Rows.DefaultSize = 18;
            this.grd02_QA20022.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            this.grd02_QA20022.Size = new System.Drawing.Size(432, 242);
            this.grd02_QA20022.TabIndex = 0;
            this.grd02_QA20022.UseCustomHighlight = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btn01_LEFT);
            this.panel8.Controls.Add(this.btn01_RIGHT);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(432, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(30, 242);
            this.panel8.TabIndex = 1;
            // 
            // btn01_LEFT
            // 
            this.btn01_LEFT.Location = new System.Drawing.Point(2, 127);
            this.btn01_LEFT.Name = "btn01_LEFT";
            this.btn01_LEFT.Size = new System.Drawing.Size(27, 111);
            this.btn01_LEFT.TabIndex = 1;
            this.btn01_LEFT.Text = "<";
            this.btn01_LEFT.UseVisualStyleBackColor = true;
            this.btn01_LEFT.Click += new System.EventHandler(this.btn01_LEFT_Click);
            // 
            // btn01_RIGHT
            // 
            this.btn01_RIGHT.Location = new System.Drawing.Point(2, 4);
            this.btn01_RIGHT.Name = "btn01_RIGHT";
            this.btn01_RIGHT.Size = new System.Drawing.Size(27, 113);
            this.btn01_RIGHT.TabIndex = 0;
            this.btn01_RIGHT.Text = ">";
            this.btn01_RIGHT.UseVisualStyleBackColor = true;
            this.btn01_RIGHT.Click += new System.EventHandler(this.btn01_RIGHT_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.heLabel4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 657);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1018, 21);
            this.panel5.TabIndex = 2;
            // 
            // heLabel4
            // 
            this.heLabel4.AutoFontSizeMaxValue = 9F;
            this.heLabel4.AutoFontSizeMinValue = 9F;
            this.heLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.heLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heLabel4.Location = new System.Drawing.Point(0, 0);
            this.heLabel4.Name = "heLabel4";
            this.heLabel4.Size = new System.Drawing.Size(1018, 21);
            this.heLabel4.TabIndex = 3;
            this.heLabel4.Tag = null;
            this.heLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 681);
            this.panel2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_LINE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 53);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // QA20022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QA20022";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03_QA20022)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20022)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20022_MSG2)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA20022)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heLabel4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private System.Windows.Forms.Panel panel5;
        private Ax.DEV.Utility.Controls.AxLabel heLabel4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel6;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA20022_MSG2;
        private System.Windows.Forms.Panel panel4;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03_QA20022;
        private System.Windows.Forms.Panel panel8;
        private Ax.DEV.Utility.Controls.AxButton btn01_LEFT;
        private Ax.DEV.Utility.Controls.AxButton btn01_RIGHT;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02_QA20022;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA20022;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxSplitter axSplitter1;


    }
}
