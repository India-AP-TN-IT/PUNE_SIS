namespace Ax.SIS.PD.UI
{
    partial class PD20412
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20412));
            this.grd01_INSPECTION_TYPE = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt01_PART_NAME = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PART_NAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PART_NO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PART_NO = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_ED_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01_INSPECTION_TYPE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PART_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PART_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PART_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PART_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            this.SuspendLayout();
            // 
            // grd01_INSPECTION_TYPE
            // 
            this.grd01_INSPECTION_TYPE.Controls.Add(this.grd01);
            this.grd01_INSPECTION_TYPE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_INSPECTION_TYPE.Location = new System.Drawing.Point(0, 74);
            this.grd01_INSPECTION_TYPE.Name = "grd01_INSPECTION_TYPE";
            this.grd01_INSPECTION_TYPE.Size = new System.Drawing.Size(1024, 694);
            this.grd01_INSPECTION_TYPE.TabIndex = 8;
            this.grd01_INSPECTION_TYPE.TabStop = false;
            this.grd01_INSPECTION_TYPE.Text = "REGRIDING QTY";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 674);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp01_ED_DATE);
            this.groupBox1.Controls.Add(this.dtp01_STD_DATE);
            this.groupBox1.Controls.Add(this.lbl01_STD_DATE);
            this.groupBox1.Controls.Add(this.txt01_PART_NAME);
            this.groupBox1.Controls.Add(this.lbl01_PART_NAME);
            this.groupBox1.Controls.Add(this.txt01_PART_NO);
            this.groupBox1.Controls.Add(this.lbl01_PART_NO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txt01_PART_NAME
            // 
            this.txt01_PART_NAME.Location = new System.Drawing.Point(404, 12);
            this.txt01_PART_NAME.Name = "txt01_PART_NAME";
            this.txt01_PART_NAME.Size = new System.Drawing.Size(173, 21);
            this.txt01_PART_NAME.TabIndex = 68;
            this.txt01_PART_NAME.Tag = null;
            // 
            // lbl01_PART_NAME
            // 
            this.lbl01_PART_NAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_PART_NAME.AutoFontSizeMinValue = 9F;
            this.lbl01_PART_NAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PART_NAME.Location = new System.Drawing.Point(258, 12);
            this.lbl01_PART_NAME.Name = "lbl01_PART_NAME";
            this.lbl01_PART_NAME.Size = new System.Drawing.Size(140, 21);
            this.lbl01_PART_NAME.TabIndex = 67;
            this.lbl01_PART_NAME.Tag = null;
            this.lbl01_PART_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PART_NAME.Value = "PART NAME";
            // 
            // txt01_PART_NO
            // 
            this.txt01_PART_NO.Location = new System.Drawing.Point(152, 12);
            this.txt01_PART_NO.Name = "txt01_PART_NO";
            this.txt01_PART_NO.Size = new System.Drawing.Size(100, 21);
            this.txt01_PART_NO.TabIndex = 66;
            this.txt01_PART_NO.Tag = null;
            // 
            // lbl01_PART_NO
            // 
            this.lbl01_PART_NO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PART_NO.AutoFontSizeMinValue = 9F;
            this.lbl01_PART_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PART_NO.Location = new System.Drawing.Point(6, 12);
            this.lbl01_PART_NO.Name = "lbl01_PART_NO";
            this.lbl01_PART_NO.Size = new System.Drawing.Size(140, 21);
            this.lbl01_PART_NO.TabIndex = 65;
            this.lbl01_PART_NO.Tag = null;
            this.lbl01_PART_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PART_NO.Value = "PART NO";
            // 
            // dtp01_ED_DATE
            // 
            this.dtp01_ED_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_ED_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_ED_DATE.Location = new System.Drawing.Point(842, 11);
            this.dtp01_ED_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_ED_DATE.Name = "dtp01_ED_DATE";
            this.dtp01_ED_DATE.OriginalFormat = "";
            this.dtp01_ED_DATE.Size = new System.Drawing.Size(92, 21);
            this.dtp01_ED_DATE.TabIndex = 88;
            // 
            // dtp01_STD_DATE
            // 
            this.dtp01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STD_DATE.Location = new System.Drawing.Point(744, 12);
            this.dtp01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STD_DATE.Name = "dtp01_STD_DATE";
            this.dtp01_STD_DATE.OriginalFormat = "";
            this.dtp01_STD_DATE.Size = new System.Drawing.Size(92, 21);
            this.dtp01_STD_DATE.TabIndex = 87;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(633, 11);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(102, 20);
            this.lbl01_STD_DATE.TabIndex = 86;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "DATE";
            // 
            // PD20412
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01_INSPECTION_TYPE);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20412";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01_INSPECTION_TYPE, 0);
            this.grd01_INSPECTION_TYPE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PART_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PART_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PART_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PART_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grd01_INSPECTION_TYPE;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PART_NO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PART_NAME;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PART_NAME;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PART_NO;
        private DEV.Utility.Controls.AxDateEdit dtp01_ED_DATE;
        private DEV.Utility.Controls.AxDateEdit dtp01_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
    }
}
