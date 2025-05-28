namespace Ax.SIS.PD.UI
{
    partial class PD60030
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD60030));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_Plant = new Ax.DEV.Utility.Controls.AxComboList();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grp01_DIVNM1 = new System.Windows.Forms.GroupBox();
            this.rdo01_TAGPRINT = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_LOSS = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_DELIVERY = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_RCV = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.rdo01_NOW_INV = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_IN_EDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dtp01_IN_SDATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_SEARCH_DAY = new Ax.DEV.Utility.Controls.AxLabel();
            this.chk01_GRID_MERGE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            this.grp01_DIVNM1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_DAY)).BeginInit();
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
            this.panel2.Controls.Add(this.cbl01_Plant);
            this.panel2.Controls.Add(this.lbl01_BIZCD);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.grp01_DIVNM1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dtp01_IN_EDATE);
            this.panel2.Controls.Add(this.dtp01_IN_SDATE);
            this.panel2.Controls.Add(this.lbl01_SEARCH_DAY);
            this.panel2.Controls.Add(this.chk01_GRID_MERGE);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_PLANT
            // 
            this.lbl01_PLANT.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT.Location = new System.Drawing.Point(17, 286);
            this.lbl01_PLANT.Name = "lbl01_PLANT";
            this.lbl01_PLANT.Size = new System.Drawing.Size(217, 12);
            this.lbl01_PLANT.TabIndex = 102;
            this.lbl01_PLANT.Tag = null;
            this.lbl01_PLANT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT.Value = "공장";
            this.lbl01_PLANT.Visible = false;
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
            this.cbl01_Plant.Location = new System.Drawing.Point(17, 301);
            this.cbl01_Plant.MatchEntryTimeout = ((long)(2000));
            this.cbl01_Plant.MaxDropDownItems = ((short)(5));
            this.cbl01_Plant.MaxLength = 32767;
            this.cbl01_Plant.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_Plant.Name = "cbl01_Plant";
            this.cbl01_Plant.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_Plant.Size = new System.Drawing.Size(226, 22);
            this.cbl01_Plant.TabIndex = 101;
            this.cbl01_Plant.PropBag = resources.GetString("cbl01_Plant.PropBag");
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZCD.Location = new System.Drawing.Point(17, 17);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(226, 12);
            this.lbl01_BIZCD.TabIndex = 88;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZCD.Value = "사업장코드";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(17, 32);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 87;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // grp01_DIVNM1
            // 
            this.grp01_DIVNM1.Controls.Add(this.rdo01_TAGPRINT);
            this.grp01_DIVNM1.Controls.Add(this.rdo01_LOSS);
            this.grp01_DIVNM1.Controls.Add(this.rdo01_DELIVERY);
            this.grp01_DIVNM1.Controls.Add(this.rdo01_RCV);
            this.grp01_DIVNM1.Controls.Add(this.rdo01_NOW_INV);
            this.grp01_DIVNM1.Location = new System.Drawing.Point(17, 118);
            this.grp01_DIVNM1.Name = "grp01_DIVNM1";
            this.grp01_DIVNM1.Size = new System.Drawing.Size(226, 132);
            this.grp01_DIVNM1.TabIndex = 83;
            this.grp01_DIVNM1.TabStop = false;
            this.grp01_DIVNM1.Text = "구분";
            // 
            // rdo01_TAGPRINT
            // 
            this.rdo01_TAGPRINT.AutoSize = true;
            this.rdo01_TAGPRINT.Location = new System.Drawing.Point(6, 108);
            this.rdo01_TAGPRINT.Name = "rdo01_TAGPRINT";
            this.rdo01_TAGPRINT.Size = new System.Drawing.Size(75, 16);
            this.rdo01_TAGPRINT.TabIndex = 4;
            this.rdo01_TAGPRINT.TabStop = true;
            this.rdo01_TAGPRINT.Text = "태그 출력";
            this.rdo01_TAGPRINT.UseVisualStyleBackColor = true;
            // 
            // rdo01_LOSS
            // 
            this.rdo01_LOSS.AutoSize = true;
            this.rdo01_LOSS.Location = new System.Drawing.Point(6, 86);
            this.rdo01_LOSS.Name = "rdo01_LOSS";
            this.rdo01_LOSS.Size = new System.Drawing.Size(59, 16);
            this.rdo01_LOSS.TabIndex = 3;
            this.rdo01_LOSS.TabStop = true;
            this.rdo01_LOSS.Text = "손망실";
            this.rdo01_LOSS.UseVisualStyleBackColor = true;
            // 
            // rdo01_DELIVERY
            // 
            this.rdo01_DELIVERY.AutoSize = true;
            this.rdo01_DELIVERY.Location = new System.Drawing.Point(6, 64);
            this.rdo01_DELIVERY.Name = "rdo01_DELIVERY";
            this.rdo01_DELIVERY.Size = new System.Drawing.Size(47, 16);
            this.rdo01_DELIVERY.TabIndex = 2;
            this.rdo01_DELIVERY.TabStop = true;
            this.rdo01_DELIVERY.Text = "출고";
            this.rdo01_DELIVERY.UseVisualStyleBackColor = true;
            // 
            // rdo01_RCV
            // 
            this.rdo01_RCV.AutoSize = true;
            this.rdo01_RCV.Location = new System.Drawing.Point(6, 42);
            this.rdo01_RCV.Name = "rdo01_RCV";
            this.rdo01_RCV.Size = new System.Drawing.Size(47, 16);
            this.rdo01_RCV.TabIndex = 1;
            this.rdo01_RCV.TabStop = true;
            this.rdo01_RCV.Text = "입고";
            this.rdo01_RCV.UseVisualStyleBackColor = true;
            // 
            // rdo01_NOW_INV
            // 
            this.rdo01_NOW_INV.AutoSize = true;
            this.rdo01_NOW_INV.Checked = true;
            this.rdo01_NOW_INV.Location = new System.Drawing.Point(6, 20);
            this.rdo01_NOW_INV.Name = "rdo01_NOW_INV";
            this.rdo01_NOW_INV.Size = new System.Drawing.Size(59, 16);
            this.rdo01_NOW_INV.TabIndex = 0;
            this.rdo01_NOW_INV.TabStop = true;
            this.rdo01_NOW_INV.Text = "현재고";
            this.rdo01_NOW_INV.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 82;
            this.label1.Text = "~";
            // 
            // dtp01_IN_EDATE
            // 
            this.dtp01_IN_EDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_IN_EDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_IN_EDATE.Location = new System.Drawing.Point(143, 81);
            this.dtp01_IN_EDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_IN_EDATE.Name = "dtp01_IN_EDATE";
            this.dtp01_IN_EDATE.OriginalFormat = "";
            this.dtp01_IN_EDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_IN_EDATE.TabIndex = 81;
            // 
            // dtp01_IN_SDATE
            // 
            this.dtp01_IN_SDATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_IN_SDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_IN_SDATE.Location = new System.Drawing.Point(17, 81);
            this.dtp01_IN_SDATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_IN_SDATE.Name = "dtp01_IN_SDATE";
            this.dtp01_IN_SDATE.OriginalFormat = "";
            this.dtp01_IN_SDATE.Size = new System.Drawing.Size(100, 21);
            this.dtp01_IN_SDATE.TabIndex = 80;
            // 
            // lbl01_SEARCH_DAY
            // 
            this.lbl01_SEARCH_DAY.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCH_DAY.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCH_DAY.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SEARCH_DAY.Location = new System.Drawing.Point(17, 66);
            this.lbl01_SEARCH_DAY.Name = "lbl01_SEARCH_DAY";
            this.lbl01_SEARCH_DAY.Size = new System.Drawing.Size(226, 12);
            this.lbl01_SEARCH_DAY.TabIndex = 79;
            this.lbl01_SEARCH_DAY.Tag = null;
            this.lbl01_SEARCH_DAY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_SEARCH_DAY.Value = "조회일자";
            // 
            // chk01_GRID_MERGE
            // 
            this.chk01_GRID_MERGE.AutoSize = true;
            this.chk01_GRID_MERGE.Checked = true;
            this.chk01_GRID_MERGE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_GRID_MERGE.Location = new System.Drawing.Point(17, 256);
            this.chk01_GRID_MERGE.Name = "chk01_GRID_MERGE";
            this.chk01_GRID_MERGE.Size = new System.Drawing.Size(88, 16);
            this.chk01_GRID_MERGE.TabIndex = 76;
            this.chk01_GRID_MERGE.Text = "그리드 병합";
            this.chk01_GRID_MERGE.UseVisualStyleBackColor = true;
            this.chk01_GRID_MERGE.CheckedChanged += new System.EventHandler(this.chk01_GRID_MERGE_CheckedChanged);
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
            this.grd01.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.grd01_AfterDataRefresh);
            // 
            // PD60030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "PD60030";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_Plant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            this.grp01_DIVNM1.ResumeLayout(false);
            this.grp01_DIVNM1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_DAY)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_GRID_MERGE;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Label label1;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_IN_EDATE;
        private Ax.DEV.Utility.Controls.AxDateEdit dtp01_IN_SDATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SEARCH_DAY;
        private System.Windows.Forms.GroupBox grp01_DIVNM1;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_TAGPRINT;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_LOSS;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_DELIVERY;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_RCV;
        private Ax.DEV.Utility.Controls.AxRadioButton rdo01_NOW_INV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_Plant;



    }
}
