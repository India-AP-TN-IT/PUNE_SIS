namespace Ax.SIS.PD.UI
{
    partial class PD40340
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD40340));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl02_LINE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_INSTALL_POS = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt03_Days = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl03_Days = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbl01_LINECD = new Ax.DEV.Utility.Controls.AxComboList();
            this.chk01_MERGE = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt03_Days)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_Days)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabControl1);
            this.panel4.Location = new System.Drawing.Point(291, 18);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 609);
            this.panel4.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(724, 603);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(716, 575);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Long Term Inventory";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(704, 563);
            this.panel3.TabIndex = 2;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(704, 563);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(716, 575);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Longterm Inventory Detail";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.grd02);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(707, 566);
            this.panel5.TabIndex = 0;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(0, 0);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(707, 566);
            this.grd02.StyleInfo = resources.GetString("grd02.StyleInfo");
            this.grd02.TabIndex = 3;
            this.grd02.UseCustomHighlight = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl02_LINE);
            this.panel2.Controls.Add(this.lbl01_INSTALL_POS);
            this.panel2.Controls.Add(this.cbo01_INSTALL_POS);
            this.panel2.Controls.Add(this.txt03_Days);
            this.panel2.Controls.Add(this.lbl03_Days);
            this.panel2.Controls.Add(this.cbl01_LINECD);
            this.panel2.Controls.Add(this.chk01_MERGE);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl02_LINE
            // 
            this.lbl02_LINE.AutoFontSizeMaxValue = 9F;
            this.lbl02_LINE.AutoFontSizeMinValue = 9F;
            this.lbl02_LINE.BackColor = System.Drawing.Color.Transparent;
            this.lbl02_LINE.Location = new System.Drawing.Point(13, 71);
            this.lbl02_LINE.Name = "lbl02_LINE";
            this.lbl02_LINE.Size = new System.Drawing.Size(226, 20);
            this.lbl02_LINE.TabIndex = 102;
            this.lbl02_LINE.Tag = null;
            this.lbl02_LINE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl02_LINE.Value = "LINE";
            // 
            // lbl01_INSTALL_POS
            // 
            this.lbl01_INSTALL_POS.AutoFontSizeMaxValue = 9F;
            this.lbl01_INSTALL_POS.AutoFontSizeMinValue = 9F;
            this.lbl01_INSTALL_POS.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_INSTALL_POS.Location = new System.Drawing.Point(13, 138);
            this.lbl01_INSTALL_POS.Name = "lbl01_INSTALL_POS";
            this.lbl01_INSTALL_POS.Size = new System.Drawing.Size(226, 20);
            this.lbl01_INSTALL_POS.TabIndex = 101;
            this.lbl01_INSTALL_POS.Tag = null;
            this.lbl01_INSTALL_POS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_INSTALL_POS.Value = "INSTALL POS";
            // 
            // cbo01_INSTALL_POS
            // 
            this.cbo01_INSTALL_POS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INSTALL_POS.FormattingEnabled = true;
            this.cbo01_INSTALL_POS.Location = new System.Drawing.Point(13, 159);
            this.cbo01_INSTALL_POS.Name = "cbo01_INSTALL_POS";
            this.cbo01_INSTALL_POS.Size = new System.Drawing.Size(226, 23);
            this.cbo01_INSTALL_POS.TabIndex = 100;
            // 
            // txt03_Days
            // 
            this.txt03_Days.Location = new System.Drawing.Point(115, 216);
            this.txt03_Days.Name = "txt03_Days";
            this.txt03_Days.Size = new System.Drawing.Size(90, 21);
            this.txt03_Days.TabIndex = 96;
            this.txt03_Days.Tag = null;
            // 
            // lbl03_Days
            // 
            this.lbl03_Days.AutoFontSizeMaxValue = 9F;
            this.lbl03_Days.AutoFontSizeMinValue = 9F;
            this.lbl03_Days.BackColor = System.Drawing.Color.Transparent;
            this.lbl03_Days.Location = new System.Drawing.Point(13, 215);
            this.lbl03_Days.Name = "lbl03_Days";
            this.lbl03_Days.Size = new System.Drawing.Size(100, 22);
            this.lbl03_Days.TabIndex = 95;
            this.lbl03_Days.Tag = null;
            this.lbl03_Days.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl03_Days.Value = "No. of Days Before";
            // 
            // cbl01_LINECD
            // 
            this.cbl01_LINECD.AddItemSeparator = ';';
            this.cbl01_LINECD.Caption = "";
            this.cbl01_LINECD.CaptionHeight = 17;
            this.cbl01_LINECD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbl01_LINECD.ColumnCaptionHeight = 18;
            this.cbl01_LINECD.ColumnFooterHeight = 18;
            this.cbl01_LINECD.ContentHeight = 16;
            this.cbl01_LINECD.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbl01_LINECD.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbl01_LINECD.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbl01_LINECD.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbl01_LINECD.EditorHeight = 16;
            this.cbl01_LINECD.Images.Add(((System.Drawing.Image)(resources.GetObject("cbl01_LINECD.Images"))));
            this.cbl01_LINECD.ItemHeight = 15;
            this.cbl01_LINECD.Location = new System.Drawing.Point(13, 94);
            this.cbl01_LINECD.MatchEntryTimeout = ((long)(2000));
            this.cbl01_LINECD.MaxDropDownItems = ((short)(5));
            this.cbl01_LINECD.MaxLength = 32767;
            this.cbl01_LINECD.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbl01_LINECD.Name = "cbl01_LINECD";
            this.cbl01_LINECD.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbl01_LINECD.Size = new System.Drawing.Size(226, 22);
            this.cbl01_LINECD.TabIndex = 80;
            this.cbl01_LINECD.BeforeOpen += new System.ComponentModel.CancelEventHandler(this.cbl01_LINECD_BeforeOpen);
            this.cbl01_LINECD.PropBag = resources.GetString("cbl01_LINECD.PropBag");
            // 
            // chk01_MERGE
            // 
            this.chk01_MERGE.AutoSize = true;
            this.chk01_MERGE.Checked = true;
            this.chk01_MERGE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_MERGE.Location = new System.Drawing.Point(13, 287);
            this.chk01_MERGE.Name = "chk01_MERGE";
            this.chk01_MERGE.Size = new System.Drawing.Size(76, 19);
            this.chk01_MERGE.TabIndex = 76;
            this.chk01_MERGE.Text = "Grid 병합";
            this.chk01_MERGE.UseVisualStyleBackColor = true;
            this.chk01_MERGE.Visible = false;
            this.chk01_MERGE.CheckedChanged += new System.EventHandler(this.chk01_GRID_MERGE_CheckedChanged);
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 23);
            this.cbo01_BIZCD.TabIndex = 7;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 26);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 12);
            this.lbl01_BIZNM2.TabIndex = 6;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 698;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 0;
            // 
            // PD40340
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "PD40340";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INSTALL_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt03_Days)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl03_Days)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_MERGE;
        private Ax.DEV.Utility.Controls.AxComboList cbl01_LINECD;
        private DEV.Utility.Controls.AxLabel lbl03_Days;
        private DEV.Utility.Controls.AxTextBox txt03_Days;
        private DEV.Utility.Controls.AxLabel lbl01_INSTALL_POS;
        private DEV.Utility.Controls.AxComboBox cbo01_INSTALL_POS;
        private DEV.Utility.Controls.AxLabel lbl02_LINE;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel5;
        private DEV.Utility.Controls.AxFlexGrid grd02;
    }
}
