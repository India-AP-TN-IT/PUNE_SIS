namespace Ax.SIS.PD.UI
{
    partial class PD20150
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD20150));
            this.grp01_GRP_ET_VINCD_LST = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbl01_ITEMCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_ITEM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_VINCD = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_VEHICLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_GRP_ET_VINCD_LST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEHICLE)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_GRP_ET_VINCD_LST
            // 
            this.grp01_GRP_ET_VINCD_LST.Controls.Add(this.grd01);
            this.grp01_GRP_ET_VINCD_LST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_GRP_ET_VINCD_LST.Location = new System.Drawing.Point(0, 74);
            this.grp01_GRP_ET_VINCD_LST.Name = "grp01_GRP_ET_VINCD_LST";
            this.grp01_GRP_ET_VINCD_LST.Size = new System.Drawing.Size(1024, 694);
            this.grp01_GRP_ET_VINCD_LST.TabIndex = 8;
            this.grp01_GRP_ET_VINCD_LST.TabStop = false;
            this.grp01_GRP_ET_VINCD_LST.Text = "차종별 통전 검사항목 리스트";
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
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.SetupEditor += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_SetupEditor);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbl01_ITEMCD);
            this.groupBox1.Controls.Add(this.lbl01_ITEM);
            this.groupBox1.Controls.Add(this.cbl01_VINCD);
            this.groupBox1.Controls.Add(this.lbl01_VEHICLE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbl01_ITEMCD
            // 
            this.cbl01_ITEMCD.AddItemSeparator = ';';
            this.cbl01_ITEMCD.Caption = "";
            this.cbl01_ITEMCD.CaptionHeight = 17;
            this.cbl01_ITEMCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_ITEMCD.ColumnCaptionHeight = 18;
            this.cbl01_ITEMCD.ColumnFooterHeight = 18;
            this.cbl01_ITEMCD.ContentHeight = 16;
            this.cbl01_ITEMCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_ITEMCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_ITEMCD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_ITEMCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_ITEMCD.EditorHeight = 16;
            this.cbl01_ITEMCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_ITEMCD.Images"))));
            this.cbl01_ITEMCD.ItemHeight = 15;
            this.cbl01_ITEMCD.Location = new System.Drawing.Point(399, 13);
            this.cbl01_ITEMCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_ITEMCD.MaxDropDownItems = ((short)(5));
            this.cbl01_ITEMCD.MaxLength = 32767;
            this.cbl01_ITEMCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_ITEMCD.Name = "cbl01_ITEMCD";
            this.cbl01_ITEMCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_ITEMCD.Size = new System.Drawing.Size(156, 22);
            this.cbl01_ITEMCD.TabIndex = 90;
            this.cbl01_ITEMCD.PropBag = resources.GetString("cbl01_ITEMCD.PropBag");
            // 
            // lbl01_ITEM
            // 
            this.lbl01_ITEM.AutoFontSizeMaxValue = 9F;
            this.lbl01_ITEM.AutoFontSizeMinValue = 9F;
            this.lbl01_ITEM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ITEM.Location = new System.Drawing.Point(293, 14);
            this.lbl01_ITEM.Name = "lbl01_ITEM";
            this.lbl01_ITEM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_ITEM.TabIndex = 89;
            this.lbl01_ITEM.Tag = null;
            this.lbl01_ITEM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ITEM.Value = "ITEM";
            // 
            // cbl01_VINCD
            // 
            this.cbl01_VINCD.AddItemSeparator = ';';
            this.cbl01_VINCD.Caption = "";
            this.cbl01_VINCD.CaptionHeight = 17;
            this.cbl01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_VINCD.ColumnCaptionHeight = 18;
            this.cbl01_VINCD.ColumnFooterHeight = 18;
            this.cbl01_VINCD.ContentHeight = 16;
            this.cbl01_VINCD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_VINCD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_VINCD.EditorFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_VINCD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_VINCD.EditorHeight = 16;
            this.cbl01_VINCD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_VINCD.Images"))));
            this.cbl01_VINCD.ItemHeight = 15;
            this.cbl01_VINCD.Location = new System.Drawing.Point(112, 13);
            this.cbl01_VINCD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_VINCD.MaxDropDownItems = ((short)(5));
            this.cbl01_VINCD.MaxLength = 32767;
            this.cbl01_VINCD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_VINCD.Name = "cbl01_VINCD";
            this.cbl01_VINCD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_VINCD.Size = new System.Drawing.Size(156, 22);
            this.cbl01_VINCD.TabIndex = 88;
            this.cbl01_VINCD.PropBag = resources.GetString("cbl01_VINCD.PropBag");
            // 
            // lbl01_VEHICLE
            // 
            this.lbl01_VEHICLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_VEHICLE.AutoFontSizeMinValue = 9F;
            this.lbl01_VEHICLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VEHICLE.Location = new System.Drawing.Point(6, 14);
            this.lbl01_VEHICLE.Name = "lbl01_VEHICLE";
            this.lbl01_VEHICLE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VEHICLE.TabIndex = 54;
            this.lbl01_VEHICLE.Tag = null;
            this.lbl01_VEHICLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VEHICLE.Value = "차종";
            // 
            // PD20150
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_GRP_ET_VINCD_LST);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20150";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_GRP_ET_VINCD_LST, 0);
            this.grp01_GRP_ET_VINCD_LST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEHICLE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_GRP_ET_VINCD_LST;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VEHICLE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_VINCD;
        private DEV.Utility.Controls.AxComboList cbl01_ITEMCD;
        private DEV.Utility.Controls.AxLabel lbl01_ITEM;
    }
}
