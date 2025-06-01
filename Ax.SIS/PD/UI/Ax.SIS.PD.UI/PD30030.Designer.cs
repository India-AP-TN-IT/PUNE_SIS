namespace Ax.SIS.PD.UI
{
    partial class PD30030
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD30030));
            this.grp01_PD30030_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbl01_Plant = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_Plant = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD30030_GRP_3 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_PD30030_GRP_2 = new System.Windows.Forms.GroupBox();
            this.lbl02_PLANT_ALL = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD30030_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Plant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            this.grp01_PD30030_GRP_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.grp01_PD30030_GRP_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PLANT_ALL)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD30030_GRP_1
            // 
            this.grp01_PD30030_GRP_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD30030_GRP_1.Controls.Add(this.grd01);
            this.grp01_PD30030_GRP_1.Location = new System.Drawing.Point(0, 74);
            this.grp01_PD30030_GRP_1.Name = "grp01_PD30030_GRP_1";
            this.grp01_PD30030_GRP_1.Size = new System.Drawing.Size(702, 694);
            this.grp01_PD30030_GRP_1.TabIndex = 8;
            this.grp01_PD30030_GRP_1.TabStop = false;
            this.grp01_PD30030_GRP_1.Text = "수지 탱크 정보";
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
            this.grd01.Size = new System.Drawing.Size(696, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbl01_Plant);
            this.groupBox1.Controls.Add(this.lbl01_Plant);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
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
            this.cbl01_Plant.Location = new System.Drawing.Point(343, 11);
            this.cbl01_Plant.MatchEntryTimeout = ((long)(2000));
            this.cbl01_Plant.MaxDropDownItems = ((short)(5));
            this.cbl01_Plant.MaxLength = 32767;
            this.cbl01_Plant.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_Plant.Name = "cbl01_Plant";
            this.cbl01_Plant.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_Plant.Size = new System.Drawing.Size(109, 22);
            this.cbl01_Plant.TabIndex = 100;
            this.cbl01_Plant.PropBag = resources.GetString("cbl01_Plant.PropBag");
            // 
            // lbl01_Plant
            // 
            this.lbl01_Plant.AutoFontSizeMaxValue = 9F;
            this.lbl01_Plant.AutoFontSizeMinValue = 9F;
            this.lbl01_Plant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_Plant.Location = new System.Drawing.Point(239, 12);
            this.lbl01_Plant.Name = "lbl01_Plant";
            this.lbl01_Plant.Size = new System.Drawing.Size(100, 21);
            this.lbl01_Plant.TabIndex = 99;
            this.lbl01_Plant.Tag = null;
            this.lbl01_Plant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_Plant.Value = "공장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 12);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 66;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(6, 12);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZCD.TabIndex = 65;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "사업장코드";
            // 
            // grp01_PD30030_GRP_3
            // 
            this.grp01_PD30030_GRP_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD30030_GRP_3.Controls.Add(this.grd02);
            this.grp01_PD30030_GRP_3.Location = new System.Drawing.Point(705, 123);
            this.grp01_PD30030_GRP_3.Name = "grp01_PD30030_GRP_3";
            this.grp01_PD30030_GRP_3.Size = new System.Drawing.Size(319, 645);
            this.grp01_PD30030_GRP_3.TabIndex = 9;
            this.grp01_PD30030_GRP_3.TabStop = false;
            this.grp01_PD30030_GRP_3.Text = "수지Part No 정보";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(310, 625);
            this.grd02.TabIndex = 10;
            this.grd02.UseCustomHighlight = true;
            // 
            // grp01_PD30030_GRP_2
            // 
            this.grp01_PD30030_GRP_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD30030_GRP_2.Controls.Add(this.lbl02_PLANT_ALL);
            this.grp01_PD30030_GRP_2.Location = new System.Drawing.Point(705, 74);
            this.grp01_PD30030_GRP_2.Name = "grp01_PD30030_GRP_2";
            this.grp01_PD30030_GRP_2.Size = new System.Drawing.Size(318, 49);
            this.grp01_PD30030_GRP_2.TabIndex = 10;
            this.grp01_PD30030_GRP_2.TabStop = false;
            this.grp01_PD30030_GRP_2.Text = "공장코드정보";
            // 
            // lbl02_PLANT_ALL
            // 
            this.lbl02_PLANT_ALL.AutoFontSizeMaxValue = 9F;
            this.lbl02_PLANT_ALL.AutoFontSizeMinValue = 9F;
            this.lbl02_PLANT_ALL.BackColor = System.Drawing.Color.White;
            this.lbl02_PLANT_ALL.Location = new System.Drawing.Point(3, 20);
            this.lbl02_PLANT_ALL.Name = "lbl02_PLANT_ALL";
            this.lbl02_PLANT_ALL.Size = new System.Drawing.Size(309, 21);
            this.lbl02_PLANT_ALL.TabIndex = 30;
            this.lbl02_PLANT_ALL.Tag = null;
            this.lbl02_PLANT_ALL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_PLANT_ALL.Value = "P01:생산4동, P02:PILOT, P03:생산2동, P04: 두서공장";
            // 
            // PD30030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD30030_GRP_2);
            this.Controls.Add(this.grp01_PD30030_GRP_3);
            this.Controls.Add(this.grp01_PD30030_GRP_1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD30030";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD30030_GRP_1, 0);
            this.Controls.SetChildIndex(this.grp01_PD30030_GRP_3, 0);
            this.Controls.SetChildIndex(this.grp01_PD30030_GRP_2, 0);
            this.grp01_PD30030_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Plant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            this.grp01_PD30030_GRP_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.grp01_PD30030_GRP_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PLANT_ALL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD30030_GRP_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private System.Windows.Forms.GroupBox grp01_PD30030_GRP_3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.GroupBox grp01_PD30030_GRP_2;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_PLANT_ALL;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_Plant;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_Plant;
    }
}
