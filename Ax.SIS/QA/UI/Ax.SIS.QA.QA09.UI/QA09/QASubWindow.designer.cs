namespace Ax.SIS.QA.QA09.UI
{
    partial class QASubWindow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_Inquery = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_NAME = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_NAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_CODE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CODE)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grd01);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 298);
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
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 1;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(609, 278);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_PLANT_DIV);
            this.groupBox1.Controls.Add(this.lbl01_PLANT_DIV);
            this.groupBox1.Controls.Add(this.btn01_Inquery);
            this.groupBox1.Controls.Add(this.txt01_NAME);
            this.groupBox1.Controls.Add(this.lbl01_NAME);
            this.groupBox1.Controls.Add(this.txt01_CODE);
            this.groupBox1.Controls.Add(this.lbl01_CODE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 40);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(600, 13);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(90, 20);
            this.cbo01_PLANT_DIV.TabIndex = 9;
            this.cbo01_PLANT_DIV.Visible = false;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(528, 13);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(70, 21);
            this.lbl01_PLANT_DIV.TabIndex = 8;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            this.lbl01_PLANT_DIV.Visible = false;
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
            // txt01_NAME
            // 
            this.txt01_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_NAME.Location = new System.Drawing.Point(362, 13);
            this.txt01_NAME.Name = "txt01_NAME";
            this.txt01_NAME.Size = new System.Drawing.Size(160, 21);
            this.txt01_NAME.TabIndex = 4;
            this.txt01_NAME.Tag = null;
            // 
            // lbl01_NAME
            // 
            this.lbl01_NAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_NAME.AutoFontSizeMinValue = 9F;
            this.lbl01_NAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_NAME.Location = new System.Drawing.Point(241, 13);
            this.lbl01_NAME.Name = "lbl01_NAME";
            this.lbl01_NAME.Size = new System.Drawing.Size(117, 21);
            this.lbl01_NAME.TabIndex = 3;
            this.lbl01_NAME.Tag = null;
            this.lbl01_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_NAME.Value = "검사명";
            // 
            // txt01_CODE
            // 
            this.txt01_CODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CODE.Location = new System.Drawing.Point(142, 13);
            this.txt01_CODE.Name = "txt01_CODE";
            this.txt01_CODE.Size = new System.Drawing.Size(93, 21);
            this.txt01_CODE.TabIndex = 2;
            this.txt01_CODE.Tag = null;
            // 
            // lbl01_CODE
            // 
            this.lbl01_CODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CODE.AutoFontSizeMinValue = 9F;
            this.lbl01_CODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CODE.Location = new System.Drawing.Point(6, 13);
            this.lbl01_CODE.Name = "lbl01_CODE";
            this.lbl01_CODE.Size = new System.Drawing.Size(130, 21);
            this.lbl01_CODE.TabIndex = 1;
            this.lbl01_CODE.Tag = null;
            this.lbl01_CODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CODE.Value = "검사코드";
            // 
            // QASubWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QASubWindow";
            this.Size = new System.Drawing.Size(615, 338);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
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
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;

    }
}
