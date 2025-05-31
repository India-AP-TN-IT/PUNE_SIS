namespace Ax.SIS.QA.QA00.UI
{
    partial class QA20010
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
            this.txt01_INSPECT_BASECODE_CLASSNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grd02_QA20010 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.heButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.txt02_SORT_SEQ = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_SORT_SEQ = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_INSPECT_CLASSNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_QA_AINSPECT_CLASSNQA = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_INSPECT_BASECODE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_QA_INSPECT_BASECODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo02_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grd01_QA20010 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl01_INSPECT_BASECODE_CLASSNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPECT_BASECODE_CLASSNM)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA20010)).BeginInit();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_SORT_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SORT_SEQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_INSPECT_CLASSNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_QA_AINSPECT_CLASSNQA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_INSPECT_BASECODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_QA_INSPECT_BASECODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20010)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_BASECODE_CLASSNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt01_INSPECT_BASECODE_CLASSNM
            // 
            this.txt01_INSPECT_BASECODE_CLASSNM.Location = new System.Drawing.Point(505, 13);
            this.txt01_INSPECT_BASECODE_CLASSNM.Name = "txt01_INSPECT_BASECODE_CLASSNM";
            this.txt01_INSPECT_BASECODE_CLASSNM.Size = new System.Drawing.Size(244, 21);
            this.txt01_INSPECT_BASECODE_CLASSNM.TabIndex = 2;
            this.txt01_INSPECT_BASECODE_CLASSNM.Tag = null;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(113, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(244, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd02_QA20010);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 591);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 177);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "부품유형별 검사코드 상세 입력";
            // 
            // grd02_QA20010
            // 
            this.grd02_QA20010.AllowHeaderMerging = false;
            this.grd02_QA20010.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02_QA20010.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02_QA20010.EnabledActionFlag = true;
            this.grd02_QA20010.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02_QA20010.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02_QA20010.LastRowAdd = false;
            this.grd02_QA20010.Location = new System.Drawing.Point(3, 17);
            this.grd02_QA20010.Name = "grd02_QA20010";
            this.grd02_QA20010.OriginalFormat = null;
            this.grd02_QA20010.PopMenuVisible = false;
            this.grd02_QA20010.Rows.DefaultSize = 18;
            this.grd02_QA20010.Size = new System.Drawing.Size(1018, 157);
            this.grd02_QA20010.TabIndex = 1;
            this.grd02_QA20010.UseCustomHighlight = true;
            this.grd02_QA20010.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd02_QA20010_RowInserted);
            this.grd02_QA20010.RowDeleted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd02_QA20010_RowDeleted);
            this.grd02_QA20010.KeyDownEdit += new C1.Win.C1FlexGrid.KeyEditEventHandler(this.grd02_QA20010_KeyDownEdit);
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.heButton1);
            this.groupBox_main.Controls.Add(this.txt02_SORT_SEQ);
            this.groupBox_main.Controls.Add(this.lbl02_SORT_SEQ);
            this.groupBox_main.Controls.Add(this.txt02_INSPECT_CLASSNM);
            this.groupBox_main.Controls.Add(this.lbl02_QA_AINSPECT_CLASSNQA);
            this.groupBox_main.Controls.Add(this.txt02_INSPECT_BASECODE);
            this.groupBox_main.Controls.Add(this.lbl02_QA_INSPECT_BASECODE);
            this.groupBox_main.Controls.Add(this.cbo02_BIZCD);
            this.groupBox_main.Controls.Add(this.lbl02_BIZNM2);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_main.Location = new System.Drawing.Point(0, 520);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(1024, 71);
            this.groupBox_main.TabIndex = 3;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "부품유형별 검사코드 정보";
            // 
            // heButton1
            // 
            this.heButton1.Location = new System.Drawing.Point(799, 26);
            this.heButton1.Name = "heButton1";
            this.heButton1.Size = new System.Drawing.Size(142, 36);
            this.heButton1.TabIndex = 12;
            this.heButton1.Text = "렉스퍼트테스트";
            this.heButton1.UseVisualStyleBackColor = true;
            this.heButton1.Visible = false;
            this.heButton1.Click += new System.EventHandler(this.heButton1_Click);
            // 
            // txt02_SORT_SEQ
            // 
            this.txt02_SORT_SEQ.Location = new System.Drawing.Point(663, 41);
            this.txt02_SORT_SEQ.Name = "txt02_SORT_SEQ";
            this.txt02_SORT_SEQ.Size = new System.Drawing.Size(100, 21);
            this.txt02_SORT_SEQ.TabIndex = 11;
            this.txt02_SORT_SEQ.Tag = null;
            this.txt02_SORT_SEQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt02_SORT_SEQ.TextChanged += new System.EventHandler(this.txt02_SORT_SEQ_TextChanged);
            // 
            // lbl02_SORT_SEQ
            // 
            this.lbl02_SORT_SEQ.AutoFontSizeMaxValue = 9F;
            this.lbl02_SORT_SEQ.AutoFontSizeMinValue = 9F;
            this.lbl02_SORT_SEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_SORT_SEQ.Location = new System.Drawing.Point(540, 41);
            this.lbl02_SORT_SEQ.Name = "lbl02_SORT_SEQ";
            this.lbl02_SORT_SEQ.Size = new System.Drawing.Size(120, 21);
            this.lbl02_SORT_SEQ.TabIndex = 10;
            this.lbl02_SORT_SEQ.Tag = null;
            this.lbl02_SORT_SEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_SORT_SEQ.Value = "정렬순서";
            // 
            // txt02_INSPECT_CLASSNM
            // 
            this.txt02_INSPECT_CLASSNM.Location = new System.Drawing.Point(396, 41);
            this.txt02_INSPECT_CLASSNM.Name = "txt02_INSPECT_CLASSNM";
            this.txt02_INSPECT_CLASSNM.Size = new System.Drawing.Size(141, 21);
            this.txt02_INSPECT_CLASSNM.TabIndex = 5;
            this.txt02_INSPECT_CLASSNM.Tag = null;
            this.txt02_INSPECT_CLASSNM.TextChanged += new System.EventHandler(this.txt02_INSPECT_CLASSNM_TextChanged);
            // 
            // lbl02_QA_AINSPECT_CLASSNQA
            // 
            this.lbl02_QA_AINSPECT_CLASSNQA.AutoFontSizeMaxValue = 9F;
            this.lbl02_QA_AINSPECT_CLASSNQA.AutoFontSizeMinValue = 9F;
            this.lbl02_QA_AINSPECT_CLASSNQA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_QA_AINSPECT_CLASSNQA.Location = new System.Drawing.Point(273, 41);
            this.lbl02_QA_AINSPECT_CLASSNQA.Name = "lbl02_QA_AINSPECT_CLASSNQA";
            this.lbl02_QA_AINSPECT_CLASSNQA.Size = new System.Drawing.Size(120, 21);
            this.lbl02_QA_AINSPECT_CLASSNQA.TabIndex = 7;
            this.lbl02_QA_AINSPECT_CLASSNQA.Tag = null;
            this.lbl02_QA_AINSPECT_CLASSNQA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_QA_AINSPECT_CLASSNQA.Value = "검사명";
            // 
            // txt02_INSPECT_BASECODE
            // 
            this.txt02_INSPECT_BASECODE.Location = new System.Drawing.Point(129, 41);
            this.txt02_INSPECT_BASECODE.Name = "txt02_INSPECT_BASECODE";
            this.txt02_INSPECT_BASECODE.Size = new System.Drawing.Size(141, 21);
            this.txt02_INSPECT_BASECODE.TabIndex = 4;
            this.txt02_INSPECT_BASECODE.Tag = null;
            // 
            // lbl02_QA_INSPECT_BASECODE
            // 
            this.lbl02_QA_INSPECT_BASECODE.AutoFontSizeMaxValue = 9F;
            this.lbl02_QA_INSPECT_BASECODE.AutoFontSizeMinValue = 9F;
            this.lbl02_QA_INSPECT_BASECODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_QA_INSPECT_BASECODE.Location = new System.Drawing.Point(6, 41);
            this.lbl02_QA_INSPECT_BASECODE.Name = "lbl02_QA_INSPECT_BASECODE";
            this.lbl02_QA_INSPECT_BASECODE.Size = new System.Drawing.Size(120, 21);
            this.lbl02_QA_INSPECT_BASECODE.TabIndex = 5;
            this.lbl02_QA_INSPECT_BASECODE.Tag = null;
            this.lbl02_QA_INSPECT_BASECODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_QA_INSPECT_BASECODE.Value = "검사코드";
            // 
            // cbo02_BIZCD
            // 
            this.cbo02_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_BIZCD.FormattingEnabled = true;
            this.cbo02_BIZCD.Location = new System.Drawing.Point(129, 18);
            this.cbo02_BIZCD.Name = "cbo02_BIZCD";
            this.cbo02_BIZCD.Size = new System.Drawing.Size(141, 20);
            this.cbo02_BIZCD.TabIndex = 3;
            // 
            // lbl02_BIZNM2
            // 
            this.lbl02_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl02_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl02_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_BIZNM2.Location = new System.Drawing.Point(6, 17);
            this.lbl02_BIZNM2.Name = "lbl02_BIZNM2";
            this.lbl02_BIZNM2.Size = new System.Drawing.Size(120, 21);
            this.lbl02_BIZNM2.TabIndex = 3;
            this.lbl02_BIZNM2.Tag = null;
            this.lbl02_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_BIZNM2.Value = "사업장";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grd01_QA20010);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1024, 441);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "부품유형별 검사코드 목록";
            // 
            // grd01_QA20010
            // 
            this.grd01_QA20010.AllowHeaderMerging = false;
            this.grd01_QA20010.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01_QA20010.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA20010.EnabledActionFlag = true;
            this.grd01_QA20010.LastRowAdd = false;
            this.grd01_QA20010.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA20010.Name = "grd01_QA20010";
            this.grd01_QA20010.OriginalFormat = null;
            this.grd01_QA20010.PopMenuVisible = true;
            this.grd01_QA20010.Rows.DefaultSize = 18;
            this.grd01_QA20010.Size = new System.Drawing.Size(1018, 421);
            this.grd01_QA20010.TabIndex = 0;
            this.grd01_QA20010.UseCustomHighlight = true;
            this.grd01_QA20010.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_QA20010_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl01_INSPECT_BASECODE_CLASSNM);
            this.groupBox1.Controls.Add(this.txt01_INSPECT_BASECODE_CLASSNM);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // lbl01_INSPECT_BASECODE_CLASSNM
            // 
            this.lbl01_INSPECT_BASECODE_CLASSNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSPECT_BASECODE_CLASSNM.AutoFontSizeMinValue = 9F;
            this.lbl01_INSPECT_BASECODE_CLASSNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INSPECT_BASECODE_CLASSNM.Location = new System.Drawing.Point(363, 13);
            this.lbl01_INSPECT_BASECODE_CLASSNM.Name = "lbl01_INSPECT_BASECODE_CLASSNM";
            this.lbl01_INSPECT_BASECODE_CLASSNM.Size = new System.Drawing.Size(139, 21);
            this.lbl01_INSPECT_BASECODE_CLASSNM.TabIndex = 8;
            this.lbl01_INSPECT_BASECODE_CLASSNM.Tag = null;
            this.lbl01_INSPECT_BASECODE_CLASSNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INSPECT_BASECODE_CLASSNM.Value = "검사코드/검사명";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(10, 14);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 4;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // QA20010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox_main);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "QA20010";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox_main, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_INSPECT_BASECODE_CLASSNM)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02_QA20010)).EndInit();
            this.groupBox_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt02_SORT_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_SORT_SEQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_INSPECT_CLASSNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_QA_AINSPECT_CLASSNQA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_INSPECT_BASECODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_QA_INSPECT_BASECODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA20010)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSPECT_BASECODE_CLASSNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_SORT_SEQ;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_INSPECT_CLASSNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_QA_AINSPECT_CLASSNQA;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_INSPECT_BASECODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_QA_INSPECT_BASECODE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo02_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_BIZNM2;
        private System.Windows.Forms.GroupBox groupBox4;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA20010;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02_QA20010;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_INSPECT_BASECODE_CLASSNM;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INSPECT_BASECODE_CLASSNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxTextBox txt02_SORT_SEQ;
        private Ax.DEV.Utility.Controls.AxButton heButton1;
    }
}
