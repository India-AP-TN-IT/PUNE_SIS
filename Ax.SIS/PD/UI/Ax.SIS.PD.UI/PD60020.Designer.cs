namespace Ax.SIS.PD.UI
{
    partial class PD60020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD60020));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_Plant = new Ax.DEV.Utility.Controls.AxComboList();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).BeginInit();
            this.panel3.SuspendLayout();
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
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl01_PLANT);
            this.panel2.Controls.Add(this.lbl01_BIZCD);
            this.panel2.Controls.Add(this.cbl01_Plant);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_PLANT
            // 
            this.lbl01_PLANT.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT.Location = new System.Drawing.Point(14, 75);
            this.lbl01_PLANT.Name = "lbl01_PLANT";
            this.lbl01_PLANT.Size = new System.Drawing.Size(200, 12);
            this.lbl01_PLANT.TabIndex = 100;
            this.lbl01_PLANT.Tag = null;
            this.lbl01_PLANT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT.Value = "공장";
            this.lbl01_PLANT.Visible = false;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZCD.Location = new System.Drawing.Point(14, 22);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(200, 12);
            this.lbl01_BIZCD.TabIndex = 86;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BIZCD.Value = "사업장코드";
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
            this.cbl01_Plant.Location = new System.Drawing.Point(14, 90);
            this.cbl01_Plant.MatchEntryTimeout = ((long)(2000));
            this.cbl01_Plant.MaxDropDownItems = ((short)(5));
            this.cbl01_Plant.MaxLength = 32767;
            this.cbl01_Plant.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_Plant.Name = "cbl01_Plant";
            this.cbl01_Plant.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_Plant.Size = new System.Drawing.Size(200, 22);
            this.cbl01_Plant.TabIndex = 99;
            this.cbl01_Plant.PropBag = resources.GetString("cbl01_Plant.PropBag");
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 37);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(200, 20);
            this.cbo01_BIZCD.TabIndex = 85;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
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
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 4;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 736);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD60020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD60020";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_Plant;



    }
}
