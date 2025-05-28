namespace Ax.SIS.WM.UI
{
    partial class WM20511
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo01_MAT_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_MAT_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DOM_IMP_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_DOM_IMP_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt01_LOCATION = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_LOCATION = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_ZONECD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_ZONECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_AREACD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_AREACD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_WHCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_WHCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_PRDT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAT_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOM_IMP_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOCATION)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOCATION)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ZONECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREACD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WHCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 28);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 740);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbo01_MAT_TYPE);
            this.panel2.Controls.Add(this.lbl01_MAT_TYPE);
            this.panel2.Controls.Add(this.lbl01_DOM_IMP_DIV);
            this.panel2.Controls.Add(this.cbo01_DOM_IMP_DIV);
            this.panel2.Controls.Add(this.txt01_LOCATION);
            this.panel2.Controls.Add(this.lbl01_LOCATION);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.cbo01_ZONECD);
            this.panel2.Controls.Add(this.lbl01_ZONECD);
            this.panel2.Controls.Add(this.cbo01_AREACD);
            this.panel2.Controls.Add(this.lbl01_AREACD);
            this.panel2.Controls.Add(this.cbo01_WHCD);
            this.panel2.Controls.Add(this.lbl01_WHCD);
            this.panel2.Controls.Add(this.cbo01_PRDT_DIV);
            this.panel2.Controls.Add(this.lbl01_PRDT_DIV);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // cbo01_MAT_TYPE
            // 
            this.cbo01_MAT_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_MAT_TYPE.FormattingEnabled = true;
            this.cbo01_MAT_TYPE.Location = new System.Drawing.Point(6, 171);
            this.cbo01_MAT_TYPE.Name = "cbo01_MAT_TYPE";
            this.cbo01_MAT_TYPE.Size = new System.Drawing.Size(222, 20);
            this.cbo01_MAT_TYPE.TabIndex = 139;
            // 
            // lbl01_MAT_TYPE
            // 
            this.lbl01_MAT_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_MAT_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_MAT_TYPE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MAT_TYPE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_MAT_TYPE.Location = new System.Drawing.Point(7, 150);
            this.lbl01_MAT_TYPE.Name = "lbl01_MAT_TYPE";
            this.lbl01_MAT_TYPE.Size = new System.Drawing.Size(221, 21);
            this.lbl01_MAT_TYPE.TabIndex = 138;
            this.lbl01_MAT_TYPE.Tag = null;
            this.lbl01_MAT_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_MAT_TYPE.Value = "자재유형";
            this.lbl01_MAT_TYPE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // lbl01_DOM_IMP_DIV
            // 
            this.lbl01_DOM_IMP_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_DOM_IMP_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_DOM_IMP_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DOM_IMP_DIV.Location = new System.Drawing.Point(5, 103);
            this.lbl01_DOM_IMP_DIV.Name = "lbl01_DOM_IMP_DIV";
            this.lbl01_DOM_IMP_DIV.Size = new System.Drawing.Size(224, 21);
            this.lbl01_DOM_IMP_DIV.TabIndex = 137;
            this.lbl01_DOM_IMP_DIV.Tag = null;
            this.lbl01_DOM_IMP_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DOM_IMP_DIV.Value = "_공장구분";
            // 
            // cbo01_DOM_IMP_DIV
            // 
            this.cbo01_DOM_IMP_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_DOM_IMP_DIV.FormattingEnabled = true;
            this.cbo01_DOM_IMP_DIV.Location = new System.Drawing.Point(5, 124);
            this.cbo01_DOM_IMP_DIV.Name = "cbo01_DOM_IMP_DIV";
            this.cbo01_DOM_IMP_DIV.Size = new System.Drawing.Size(224, 20);
            this.cbo01_DOM_IMP_DIV.TabIndex = 136;
            // 
            // txt01_LOCATION
            // 
            this.txt01_LOCATION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_LOCATION.Location = new System.Drawing.Point(5, 221);
            this.txt01_LOCATION.Name = "txt01_LOCATION";
            this.txt01_LOCATION.Size = new System.Drawing.Size(226, 21);
            this.txt01_LOCATION.TabIndex = 129;
            this.txt01_LOCATION.Tag = null;
            // 
            // lbl01_LOCATION
            // 
            this.lbl01_LOCATION.AutoFontSizeMaxValue = 9F;
            this.lbl01_LOCATION.AutoFontSizeMinValue = 9F;
            this.lbl01_LOCATION.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LOCATION.Location = new System.Drawing.Point(5, 197);
            this.lbl01_LOCATION.Name = "lbl01_LOCATION";
            this.lbl01_LOCATION.Size = new System.Drawing.Size(226, 21);
            this.lbl01_LOCATION.TabIndex = 128;
            this.lbl01_LOCATION.Tag = null;
            this.lbl01_LOCATION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_LOCATION.Value = "Location";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(5, 271);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(226, 21);
            this.txt01_PARTNO.TabIndex = 125;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(5, 247);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(226, 21);
            this.lbl01_PARTNO.TabIndex = 124;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "PART NO";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(5, 6);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(226, 23);
            this.lbl01_BIZNM2.TabIndex = 113;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(5, 32);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_BIZCD.TabIndex = 112;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // cbo01_ZONECD
            // 
            this.cbo01_ZONECD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_ZONECD.FormattingEnabled = true;
            this.cbo01_ZONECD.Location = new System.Drawing.Point(7, 518);
            this.cbo01_ZONECD.Name = "cbo01_ZONECD";
            this.cbo01_ZONECD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_ZONECD.TabIndex = 111;
            this.cbo01_ZONECD.Visible = false;
            // 
            // lbl01_ZONECD
            // 
            this.lbl01_ZONECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ZONECD.AutoFontSizeMinValue = 9F;
            this.lbl01_ZONECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ZONECD.Location = new System.Drawing.Point(7, 497);
            this.lbl01_ZONECD.Name = "lbl01_ZONECD";
            this.lbl01_ZONECD.Size = new System.Drawing.Size(226, 20);
            this.lbl01_ZONECD.TabIndex = 110;
            this.lbl01_ZONECD.Tag = null;
            this.lbl01_ZONECD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ZONECD.Value = "Zone code";
            this.lbl01_ZONECD.Visible = false;
            // 
            // cbo01_AREACD
            // 
            this.cbo01_AREACD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_AREACD.FormattingEnabled = true;
            this.cbo01_AREACD.Location = new System.Drawing.Point(7, 472);
            this.cbo01_AREACD.Name = "cbo01_AREACD";
            this.cbo01_AREACD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_AREACD.TabIndex = 109;
            this.cbo01_AREACD.Visible = false;
            this.cbo01_AREACD.SelectedIndexChanged += new System.EventHandler(this.cbo01_AREACD_SelectedIndexChanged);
            // 
            // lbl01_AREACD
            // 
            this.lbl01_AREACD.AutoFontSizeMaxValue = 9F;
            this.lbl01_AREACD.AutoFontSizeMinValue = 9F;
            this.lbl01_AREACD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_AREACD.Location = new System.Drawing.Point(7, 451);
            this.lbl01_AREACD.Name = "lbl01_AREACD";
            this.lbl01_AREACD.Size = new System.Drawing.Size(226, 20);
            this.lbl01_AREACD.TabIndex = 108;
            this.lbl01_AREACD.Tag = null;
            this.lbl01_AREACD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_AREACD.Value = "Area code";
            this.lbl01_AREACD.Visible = false;
            // 
            // cbo01_WHCD
            // 
            this.cbo01_WHCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_WHCD.FormattingEnabled = true;
            this.cbo01_WHCD.Location = new System.Drawing.Point(5, 78);
            this.cbo01_WHCD.Name = "cbo01_WHCD";
            this.cbo01_WHCD.Size = new System.Drawing.Size(226, 20);
            this.cbo01_WHCD.TabIndex = 107;
            this.cbo01_WHCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_WHCD_SelectedIndexChanged);
            // 
            // lbl01_WHCD
            // 
            this.lbl01_WHCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_WHCD.AutoFontSizeMinValue = 9F;
            this.lbl01_WHCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_WHCD.Location = new System.Drawing.Point(5, 57);
            this.lbl01_WHCD.Name = "lbl01_WHCD";
            this.lbl01_WHCD.Size = new System.Drawing.Size(226, 20);
            this.lbl01_WHCD.TabIndex = 106;
            this.lbl01_WHCD.Tag = null;
            this.lbl01_WHCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_WHCD.Value = "Warehouse code";
            // 
            // cbo01_PRDT_DIV
            // 
            this.cbo01_PRDT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PRDT_DIV.FormattingEnabled = true;
            this.cbo01_PRDT_DIV.Location = new System.Drawing.Point(5, 425);
            this.cbo01_PRDT_DIV.Name = "cbo01_PRDT_DIV";
            this.cbo01_PRDT_DIV.Size = new System.Drawing.Size(226, 20);
            this.cbo01_PRDT_DIV.TabIndex = 107;
            this.cbo01_PRDT_DIV.Visible = false;
            this.cbo01_PRDT_DIV.SelectedIndexChanged += new System.EventHandler(this.cbo01_PRDT_DIV_SelectedIndexChanged);
            // 
            // lbl01_PRDT_DIV
            // 
            this.lbl01_PRDT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PRDT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PRDT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PRDT_DIV.Location = new System.Drawing.Point(5, 404);
            this.lbl01_PRDT_DIV.Name = "lbl01_PRDT_DIV";
            this.lbl01_PRDT_DIV.Size = new System.Drawing.Size(226, 20);
            this.lbl01_PRDT_DIV.TabIndex = 106;
            this.lbl01_PRDT_DIV.Tag = null;
            this.lbl01_PRDT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PRDT_DIV.Value = "제품구분";
            this.lbl01_PRDT_DIV.Visible = false;
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 740;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 740);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 3;
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
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 736);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            // 
            // WM20511
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "WM20511";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MAT_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DOM_IMP_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_LOCATION)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LOCATION)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ZONECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AREACD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_WHCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PRDT_DIV)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PRDT_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PRDT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_ZONECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ZONECD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_AREACD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_AREACD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_WHCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_WHCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_LOCATION;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LOCATION;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DOM_IMP_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_DOM_IMP_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_MAT_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MAT_TYPE;
    }
}
