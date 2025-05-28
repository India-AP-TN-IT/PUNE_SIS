namespace Ax.SIS.QA.QA01.UI
{
    partial class QA30234P1
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
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_QA30234P1_GRP_1 = new System.Windows.Forms.GroupBox();
            this.txt01_CUSTCD_CUSTNM = new Ax.DEV.Utility.Controls.AxTextBox();
            this.btn01_SAVE = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl02_EI_EI21030_CUSTCD_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_EI_EI21030_DELIBAD_YN2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_DELIBAD_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.btn01_QUERY = new Ax.DEV.Utility.Controls.AxButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.grp01_QA30234P1_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CUSTCD_CUSTNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_EI_EI21030_CUSTCD_NM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EI_EI21030_DELIBAD_YN2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grd01);
            this.panel1.Controls.Add(this.grp01_QA30234P1_GRP_1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 635);
            this.panel1.TabIndex = 2;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 47);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(752, 588);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            // 
            // grp01_QA30234P1_GRP_1
            // 
            this.grp01_QA30234P1_GRP_1.Controls.Add(this.txt01_CUSTCD_CUSTNM);
            this.grp01_QA30234P1_GRP_1.Controls.Add(this.btn01_SAVE);
            this.grp01_QA30234P1_GRP_1.Controls.Add(this.lbl02_EI_EI21030_CUSTCD_NM);
            this.grp01_QA30234P1_GRP_1.Controls.Add(this.lbl01_EI_EI21030_DELIBAD_YN2);
            this.grp01_QA30234P1_GRP_1.Controls.Add(this.cbo01_DELIBAD_YN);
            this.grp01_QA30234P1_GRP_1.Controls.Add(this.btn01_QUERY);
            this.grp01_QA30234P1_GRP_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_QA30234P1_GRP_1.Location = new System.Drawing.Point(0, 0);
            this.grp01_QA30234P1_GRP_1.Name = "grp01_QA30234P1_GRP_1";
            this.grp01_QA30234P1_GRP_1.Size = new System.Drawing.Size(752, 47);
            this.grp01_QA30234P1_GRP_1.TabIndex = 2;
            this.grp01_QA30234P1_GRP_1.TabStop = false;
            // 
            // txt01_CUSTCD_CUSTNM
            // 
            this.txt01_CUSTCD_CUSTNM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_CUSTCD_CUSTNM.Location = new System.Drawing.Point(98, 17);
            this.txt01_CUSTCD_CUSTNM.Name = "txt01_CUSTCD_CUSTNM";
            this.txt01_CUSTCD_CUSTNM.Size = new System.Drawing.Size(214, 21);
            this.txt01_CUSTCD_CUSTNM.TabIndex = 42;
            this.txt01_CUSTCD_CUSTNM.Tag = null;
            // 
            // btn01_SAVE
            // 
            this.btn01_SAVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_SAVE.Location = new System.Drawing.Point(678, 15);
            this.btn01_SAVE.Name = "btn01_SAVE";
            this.btn01_SAVE.Size = new System.Drawing.Size(65, 25);
            this.btn01_SAVE.TabIndex = 41;
            this.btn01_SAVE.Text = "저장";
            this.btn01_SAVE.UseVisualStyleBackColor = true;
            this.btn01_SAVE.Click += new System.EventHandler(this.btn01_SAVE_Click);
            // 
            // lbl02_EI_EI21030_CUSTCD_NM
            // 
            this.lbl02_EI_EI21030_CUSTCD_NM.AutoFontSizeMaxValue = 9F;
            this.lbl02_EI_EI21030_CUSTCD_NM.AutoFontSizeMinValue = 9F;
            this.lbl02_EI_EI21030_CUSTCD_NM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_EI_EI21030_CUSTCD_NM.Location = new System.Drawing.Point(9, 17);
            this.lbl02_EI_EI21030_CUSTCD_NM.Name = "lbl02_EI_EI21030_CUSTCD_NM";
            this.lbl02_EI_EI21030_CUSTCD_NM.Size = new System.Drawing.Size(83, 21);
            this.lbl02_EI_EI21030_CUSTCD_NM.TabIndex = 40;
            this.lbl02_EI_EI21030_CUSTCD_NM.Tag = null;
            this.lbl02_EI_EI21030_CUSTCD_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_EI_EI21030_CUSTCD_NM.Value = "고객명/코드";
            // 
            // lbl01_EI_EI21030_DELIBAD_YN2
            // 
            this.lbl01_EI_EI21030_DELIBAD_YN2.AutoFontSizeMaxValue = 9F;
            this.lbl01_EI_EI21030_DELIBAD_YN2.AutoFontSizeMinValue = 9F;
            this.lbl01_EI_EI21030_DELIBAD_YN2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_EI_EI21030_DELIBAD_YN2.Location = new System.Drawing.Point(318, 17);
            this.lbl01_EI_EI21030_DELIBAD_YN2.Name = "lbl01_EI_EI21030_DELIBAD_YN2";
            this.lbl01_EI_EI21030_DELIBAD_YN2.Size = new System.Drawing.Size(141, 21);
            this.lbl01_EI_EI21030_DELIBAD_YN2.TabIndex = 39;
            this.lbl01_EI_EI21030_DELIBAD_YN2.Tag = null;
            this.lbl01_EI_EI21030_DELIBAD_YN2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_EI_EI21030_DELIBAD_YN2.Value = "납입불량 적용유무";
            // 
            // cbo01_DELIBAD_YN
            // 
            this.cbo01_DELIBAD_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DELIBAD_YN.FormattingEnabled = true;
            this.cbo01_DELIBAD_YN.Location = new System.Drawing.Point(465, 17);
            this.cbo01_DELIBAD_YN.Name = "cbo01_DELIBAD_YN";
            this.cbo01_DELIBAD_YN.Size = new System.Drawing.Size(125, 20);
            this.cbo01_DELIBAD_YN.TabIndex = 36;
            // 
            // btn01_QUERY
            // 
            this.btn01_QUERY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_QUERY.Location = new System.Drawing.Point(607, 15);
            this.btn01_QUERY.Name = "btn01_QUERY";
            this.btn01_QUERY.Size = new System.Drawing.Size(65, 25);
            this.btn01_QUERY.TabIndex = 33;
            this.btn01_QUERY.Text = "조회";
            this.btn01_QUERY.UseVisualStyleBackColor = true;
            this.btn01_QUERY.Click += new System.EventHandler(this.btn01_INQUERY_Click);
            // 
            // QA30234P1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "QA30234P1";
            this.Size = new System.Drawing.Size(752, 635);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.grp01_QA30234P1_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CUSTCD_CUSTNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_EI_EI21030_CUSTCD_NM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_EI_EI21030_DELIBAD_YN2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grp01_QA30234P1_GRP_1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxButton btn01_QUERY;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_DELIBAD_YN;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_EI_EI21030_CUSTCD_NM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_EI_EI21030_DELIBAD_YN2;
        private DEV.Utility.Controls.AxButton btn01_SAVE;
        private DEV.Utility.Controls.AxTextBox txt01_CUSTCD_CUSTNM;
    }
}
