namespace Ax.SIS.PD.UI
{
    partial class PD60050
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD60050));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_Plant = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grp01_PD60050_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_PD60050_GRP_2 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_PD60050_GRP_3 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            this.panel3.SuspendLayout();
            this.grp01_PD60050_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.grp01_PD60050_GRP_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.grp01_PD60050_GRP_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl01_PLANT);
            this.panel2.Controls.Add(this.cbl01_Plant);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZCD);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_PLANT
            // 
            this.lbl01_PLANT.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT.Location = new System.Drawing.Point(13, 79);
            this.lbl01_PLANT.Name = "lbl01_PLANT";
            this.lbl01_PLANT.Size = new System.Drawing.Size(226, 12);
            this.lbl01_PLANT.TabIndex = 96;
            this.lbl01_PLANT.Tag = null;
            this.lbl01_PLANT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cbl01_Plant.Location = new System.Drawing.Point(13, 94);
            this.cbl01_Plant.MatchEntryTimeout = ((long)(2000));
            this.cbl01_Plant.MaxDropDownItems = ((short)(5));
            this.cbl01_Plant.MaxLength = 32767;
            this.cbl01_Plant.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_Plant.Name = "cbl01_Plant";
            this.cbl01_Plant.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_Plant.Size = new System.Drawing.Size(226, 22);
            this.cbl01_Plant.TabIndex = 95;
            this.cbl01_Plant.PropBag = resources.GetString("cbl01_Plant.PropBag");
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 32);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 7;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZCD.Location = new System.Drawing.Point(13, 17);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZCD.TabIndex = 6;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZCD.Value = "사업장코드";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grp01_PD60050_GRP_1);
            this.panel3.Controls.Add(this.grp01_PD60050_GRP_2);
            this.panel3.Controls.Add(this.grp01_PD60050_GRP_3);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 2;
            // 
            // grp01_PD60050_GRP_1
            // 
            this.grp01_PD60050_GRP_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD60050_GRP_1.Controls.Add(this.grd03);
            this.grp01_PD60050_GRP_1.Location = new System.Drawing.Point(520, 321);
            this.grp01_PD60050_GRP_1.Name = "grp01_PD60050_GRP_1";
            this.grp01_PD60050_GRP_1.Size = new System.Drawing.Size(217, 412);
            this.grp01_PD60050_GRP_1.TabIndex = 5;
            this.grp01_PD60050_GRP_1.TabStop = false;
            this.grp01_PD60050_GRP_1.Text = "Rack No 별 수지 적재 현황";
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd03.EnabledActionFlag = true;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 17);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = true;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(211, 392);
            this.grd03.TabIndex = 2;
            this.grd03.UseCustomHighlight = true;
            // 
            // grp01_PD60050_GRP_2
            // 
            this.grp01_PD60050_GRP_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_PD60050_GRP_2.Controls.Add(this.grd02);
            this.grp01_PD60050_GRP_2.Location = new System.Drawing.Point(520, 11);
            this.grp01_PD60050_GRP_2.Name = "grp01_PD60050_GRP_2";
            this.grp01_PD60050_GRP_2.Size = new System.Drawing.Size(217, 304);
            this.grp01_PD60050_GRP_2.TabIndex = 4;
            this.grp01_PD60050_GRP_2.TabStop = false;
            this.grp01_PD60050_GRP_2.Text = "수지별 상세재고 현황";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(211, 284);
            this.grd02.TabIndex = 2;
            this.grd02.UseCustomHighlight = true;
            // 
            // grp01_PD60050_GRP_3
            // 
            this.grp01_PD60050_GRP_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp01_PD60050_GRP_3.Controls.Add(this.grd01);
            this.grp01_PD60050_GRP_3.Location = new System.Drawing.Point(3, 11);
            this.grp01_PD60050_GRP_3.Name = "grp01_PD60050_GRP_3";
            this.grp01_PD60050_GRP_3.Size = new System.Drawing.Size(514, 722);
            this.grp01_PD60050_GRP_3.TabIndex = 3;
            this.grp01_PD60050_GRP_3.TabStop = false;
            this.grp01_PD60050_GRP_3.Text = "수지별 재고현황";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(508, 702);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.grd01_AfterDataRefresh);
            this.grd01.Click += new System.EventHandler(this.grd01_Click);
            // 
            // PD60050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD60050";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            this.panel3.ResumeLayout(false);
            this.grp01_PD60050_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.grp01_PD60050_GRP_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.grp01_PD60050_GRP_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private System.Windows.Forms.GroupBox grp01_PD60050_GRP_1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03;
        private System.Windows.Forms.GroupBox grp01_PD60050_GRP_2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private System.Windows.Forms.GroupBox grp01_PD60050_GRP_3;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_Plant;
    }
}
