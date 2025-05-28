namespace Ax.SIS.PD.UI
{
    partial class PD30010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD30010));
            this.grp01_PD30010_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNOTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PLANT = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_Plant = new Ax.DEV.Utility.Controls.AxComboList();
            this.txt01_GRADE_NO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_RESIN_GRADE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD30010_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_GRADE_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RESIN_GRADE)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD30010_GRP_1
            // 
            this.grp01_PD30010_GRP_1.Controls.Add(this.grd01);
            this.grp01_PD30010_GRP_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD30010_GRP_1.Location = new System.Drawing.Point(0, 74);
            this.grp01_PD30010_GRP_1.Name = "grp01_PD30010_GRP_1";
            this.grp01_PD30010_GRP_1.Size = new System.Drawing.Size(1024, 694);
            this.grp01_PD30010_GRP_1.TabIndex = 8;
            this.grp01_PD30010_GRP_1.TabStop = false;
            this.grp01_PD30010_GRP_1.Text = "수지 Grade 정보";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_PARTNOTITLE);
            this.groupBox1.Controls.Add(this.lbl01_PLANT);
            this.groupBox1.Controls.Add(this.cbl01_Plant);
            this.groupBox1.Controls.Add(this.txt01_GRADE_NO);
            this.groupBox1.Controls.Add(this.lbl01_RESIN_GRADE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(544, 12);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(152, 21);
            this.txt01_PARTNO.TabIndex = 100;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNOTITLE
            // 
            this.lbl01_PARTNOTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNOTITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNOTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNOTITLE.Location = new System.Drawing.Point(438, 12);
            this.lbl01_PARTNOTITLE.Name = "lbl01_PARTNOTITLE";
            this.lbl01_PARTNOTITLE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PARTNOTITLE.TabIndex = 99;
            this.lbl01_PARTNOTITLE.Tag = null;
            this.lbl01_PARTNOTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNOTITLE.Value = "품번";
            // 
            // lbl01_PLANT
            // 
            this.lbl01_PLANT.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PLANT.Location = new System.Drawing.Point(218, 12);
            this.lbl01_PLANT.Name = "lbl01_PLANT";
            this.lbl01_PLANT.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PLANT.TabIndex = 98;
            this.lbl01_PLANT.Tag = null;
            this.lbl01_PLANT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PLANT.Value = "공장";
            // 
            // cbl01_Plant
            // 
            this.cbl01_Plant.AddItemSeparator = ';';
            this.cbl01_Plant.Caption = "";
            this.cbl01_Plant.CaptionHeight = 17;
            this.cbl01_Plant.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_Plant.ColumnCaptionHeight = 18;
            this.cbl01_Plant.ColumnFooterHeight = 18;
            this.cbl01_Plant.ContentHeight = 16;
            this.cbl01_Plant.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_Plant.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_Plant.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_Plant.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_Plant.EditorHeight = 16;
            this.cbl01_Plant.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_Plant.Images"))));
            this.cbl01_Plant.ItemHeight = 15;
            this.cbl01_Plant.Location = new System.Drawing.Point(324, 12);
            this.cbl01_Plant.MatchEntryTimeout = ((long)(2000));
            this.cbl01_Plant.MaxDropDownItems = ((short)(5));
            this.cbl01_Plant.MaxLength = 32767;
            this.cbl01_Plant.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_Plant.Name = "cbl01_Plant";
            this.cbl01_Plant.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_Plant.Size = new System.Drawing.Size(109, 22);
            this.cbl01_Plant.TabIndex = 97;
            this.cbl01_Plant.PropBag = resources.GetString("cbl01_Plant.PropBag");
            // 
            // txt01_GRADE_NO
            // 
            this.txt01_GRADE_NO.Location = new System.Drawing.Point(112, 12);
            this.txt01_GRADE_NO.Name = "txt01_GRADE_NO";
            this.txt01_GRADE_NO.Size = new System.Drawing.Size(100, 21);
            this.txt01_GRADE_NO.TabIndex = 66;
            this.txt01_GRADE_NO.Tag = null;
            // 
            // lbl01_RESIN_GRADE
            // 
            this.lbl01_RESIN_GRADE.AutoFontSizeMaxValue = 9F;
            this.lbl01_RESIN_GRADE.AutoFontSizeMinValue = 9F;
            this.lbl01_RESIN_GRADE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_RESIN_GRADE.Location = new System.Drawing.Point(6, 12);
            this.lbl01_RESIN_GRADE.Name = "lbl01_RESIN_GRADE";
            this.lbl01_RESIN_GRADE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_RESIN_GRADE.TabIndex = 65;
            this.lbl01_RESIN_GRADE.Tag = null;
            this.lbl01_RESIN_GRADE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_RESIN_GRADE.Value = "수지 Grade";
            // 
            // PD30010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD30010_GRP_1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD30010";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD30010_GRP_1, 0);
            this.grp01_PD30010_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_GRADE_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_RESIN_GRADE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD30010_GRP_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_RESIN_GRADE;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_GRADE_NO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_Plant;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNOTITLE;
    }
}
