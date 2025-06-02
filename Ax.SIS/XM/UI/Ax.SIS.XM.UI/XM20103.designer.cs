namespace Ax.SIS.XM.UI
{
    partial class XM20103
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
            this.grp01_XM20102_GRP_3 = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_MENU_SELECTED = new System.Windows.Forms.GroupBox();
            this.lbl01_MENUID = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_MENUNAME = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_Menuname = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt01_Menuid = new Ax.DEV.Utility.Controls.AxTextBox();
            this.heSplitter1 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.grp01_XM20102_GRP_1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.heSplitter2 = new Ax.DEV.Utility.Controls.AxSplitter();
            this.grp01_TARGET_LANGSET = new System.Windows.Forms.GroupBox();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SYSTEMCODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_Module = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_MODULE = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grp01_XM20102_GRP_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.grp01_MENU_SELECTED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MENUID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MENUNAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_Menuname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_Menuid)).BeginInit();
            this.grp01_XM20102_GRP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.grp01_TARGET_LANGSET.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MODULE)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heSplitter1);
            this.panel1.Controls.Add(this.grp01_XM20102_GRP_1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grp01_XM20102_GRP_3);
            this.panel2.Controls.Add(this.grp01_MENU_SELECTED);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(386, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 694);
            this.panel2.TabIndex = 32;
            // 
            // grp01_XM20102_GRP_3
            // 
            this.grp01_XM20102_GRP_3.Controls.Add(this.grd02);
            this.grp01_XM20102_GRP_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_XM20102_GRP_3.Location = new System.Drawing.Point(0, 40);
            this.grp01_XM20102_GRP_3.Name = "grp01_XM20102_GRP_3";
            this.grp01_XM20102_GRP_3.Size = new System.Drawing.Size(638, 654);
            this.grp01_XM20102_GRP_3.TabIndex = 21;
            this.grp01_XM20102_GRP_3.TabStop = false;
            this.grp01_XM20102_GRP_3.Text = "다국어 정보";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(6, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(626, 634);
            this.grd02.TabIndex = 7;
            this.grd02.UseCustomHighlight = true;
            // 
            // grp01_MENU_SELECTED
            // 
            this.grp01_MENU_SELECTED.Controls.Add(this.lbl01_MENUID);
            this.grp01_MENU_SELECTED.Controls.Add(this.lbl01_MENUNAME);
            this.grp01_MENU_SELECTED.Controls.Add(this.txt01_Menuname);
            this.grp01_MENU_SELECTED.Controls.Add(this.txt01_Menuid);
            this.grp01_MENU_SELECTED.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp01_MENU_SELECTED.Location = new System.Drawing.Point(0, 0);
            this.grp01_MENU_SELECTED.Name = "grp01_MENU_SELECTED";
            this.grp01_MENU_SELECTED.Size = new System.Drawing.Size(638, 40);
            this.grp01_MENU_SELECTED.TabIndex = 22;
            this.grp01_MENU_SELECTED.TabStop = false;
            this.grp01_MENU_SELECTED.Text = "선택된 메뉴정보";
            // 
            // lbl01_MENUID
            // 
            this.lbl01_MENUID.AutoFontSizeMaxValue = 9F;
            this.lbl01_MENUID.AutoFontSizeMinValue = 9F;
            this.lbl01_MENUID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MENUID.Location = new System.Drawing.Point(6, 13);
            this.lbl01_MENUID.Name = "lbl01_MENUID";
            this.lbl01_MENUID.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MENUID.TabIndex = 9;
            this.lbl01_MENUID.Tag = null;
            this.lbl01_MENUID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MENUID.Value = "코드";
            // 
            // lbl01_MENUNAME
            // 
            this.lbl01_MENUNAME.AutoFontSizeMaxValue = 9F;
            this.lbl01_MENUNAME.AutoFontSizeMinValue = 9F;
            this.lbl01_MENUNAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MENUNAME.Location = new System.Drawing.Point(238, 13);
            this.lbl01_MENUNAME.Name = "lbl01_MENUNAME";
            this.lbl01_MENUNAME.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MENUNAME.TabIndex = 7;
            this.lbl01_MENUNAME.Tag = null;
            this.lbl01_MENUNAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MENUNAME.Value = "코드명";
            // 
            // txt01_Menuname
            // 
            this.txt01_Menuname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt01_Menuname.Location = new System.Drawing.Point(344, 13);
            this.txt01_Menuname.Name = "txt01_Menuname";
            this.txt01_Menuname.Size = new System.Drawing.Size(288, 21);
            this.txt01_Menuname.TabIndex = 8;
            this.txt01_Menuname.Tag = null;
            // 
            // txt01_Menuid
            // 
            this.txt01_Menuid.Location = new System.Drawing.Point(112, 13);
            this.txt01_Menuid.Name = "txt01_Menuid";
            this.txt01_Menuid.Size = new System.Drawing.Size(120, 21);
            this.txt01_Menuid.TabIndex = 6;
            this.txt01_Menuid.Tag = null;
            // 
            // heSplitter1
            // 
            this.heSplitter1.Location = new System.Drawing.Point(383, 40);
            this.heSplitter1.Name = "heSplitter1";
            this.heSplitter1.Size = new System.Drawing.Size(3, 694);
            this.heSplitter1.TabIndex = 11;
            this.heSplitter1.TabStop = false;
            // 
            // grp01_XM20102_GRP_1
            // 
            this.grp01_XM20102_GRP_1.Controls.Add(this.grd01);
            this.grp01_XM20102_GRP_1.Controls.Add(this.heSplitter2);
            this.grp01_XM20102_GRP_1.Controls.Add(this.grp01_TARGET_LANGSET);
            this.grp01_XM20102_GRP_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp01_XM20102_GRP_1.Location = new System.Drawing.Point(0, 40);
            this.grp01_XM20102_GRP_1.Name = "grp01_XM20102_GRP_1";
            this.grp01_XM20102_GRP_1.Size = new System.Drawing.Size(383, 694);
            this.grp01_XM20102_GRP_1.TabIndex = 19;
            this.grp01_XM20102_GRP_1.TabStop = false;
            this.grp01_XM20102_GRP_1.Text = "메뉴 목록";
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
            this.grd01.Size = new System.Drawing.Size(377, 538);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // heSplitter2
            // 
            this.heSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.heSplitter2.Location = new System.Drawing.Point(3, 555);
            this.heSplitter2.Name = "heSplitter2";
            this.heSplitter2.Size = new System.Drawing.Size(377, 3);
            this.heSplitter2.TabIndex = 21;
            this.heSplitter2.TabStop = false;
            // 
            // grp01_TARGET_LANGSET
            // 
            this.grp01_TARGET_LANGSET.Controls.Add(this.grd03);
            this.grp01_TARGET_LANGSET.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_TARGET_LANGSET.Location = new System.Drawing.Point(3, 558);
            this.grp01_TARGET_LANGSET.Name = "grp01_TARGET_LANGSET";
            this.grp01_TARGET_LANGSET.Size = new System.Drawing.Size(377, 133);
            this.grp01_TARGET_LANGSET.TabIndex = 20;
            this.grp01_TARGET_LANGSET.TabStop = false;
            this.grp01_TARGET_LANGSET.Text = "저장대상언어";
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
            this.grd03.Size = new System.Drawing.Size(371, 113);
            this.grd03.TabIndex = 1;
            this.grd03.UseCustomHighlight = true;
            this.grd03.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd03_CellChecked);
            this.grd03.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd03_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_SYSTEMCODE);
            this.groupBox1.Controls.Add(this.lbl01_SYSTEMCODE);
            this.groupBox1.Controls.Add(this.cbo01_Module);
            this.groupBox1.Controls.Add(this.lbl01_MODULE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_SYSTEMCODE
            // 
            this.cbo01_SYSTEMCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SYSTEMCODE.FormattingEnabled = true;
            this.cbo01_SYSTEMCODE.Location = new System.Drawing.Point(114, 13);
            this.cbo01_SYSTEMCODE.Name = "cbo01_SYSTEMCODE";
            this.cbo01_SYSTEMCODE.Size = new System.Drawing.Size(98, 20);
            this.cbo01_SYSTEMCODE.TabIndex = 10;
            this.cbo01_SYSTEMCODE.SelectedIndexChanged += new System.EventHandler(this.cbo01_SYSTEMCODE_SelectedIndexChanged);
            // 
            // lbl01_SYSTEMCODE
            // 
            this.lbl01_SYSTEMCODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_SYSTEMCODE.AutoFontSizeMinValue = 9F;
            this.lbl01_SYSTEMCODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_SYSTEMCODE.Location = new System.Drawing.Point(8, 13);
            this.lbl01_SYSTEMCODE.Name = "lbl01_SYSTEMCODE";
            this.lbl01_SYSTEMCODE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_SYSTEMCODE.TabIndex = 9;
            this.lbl01_SYSTEMCODE.Tag = null;
            this.lbl01_SYSTEMCODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_SYSTEMCODE.Value = "시스템 코드";
            // 
            // cbo01_Module
            // 
            this.cbo01_Module.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_Module.FormattingEnabled = true;
            this.cbo01_Module.Location = new System.Drawing.Point(324, 13);
            this.cbo01_Module.Name = "cbo01_Module";
            this.cbo01_Module.Size = new System.Drawing.Size(205, 20);
            this.cbo01_Module.TabIndex = 5;
            // 
            // lbl01_MODULE
            // 
            this.lbl01_MODULE.AutoFontSizeMaxValue = 9F;
            this.lbl01_MODULE.AutoFontSizeMinValue = 9F;
            this.lbl01_MODULE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MODULE.Location = new System.Drawing.Point(218, 13);
            this.lbl01_MODULE.Name = "lbl01_MODULE";
            this.lbl01_MODULE.Size = new System.Drawing.Size(100, 20);
            this.lbl01_MODULE.TabIndex = 4;
            this.lbl01_MODULE.Tag = null;
            this.lbl01_MODULE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MODULE.Value = "모듈종류";
            // 
            // XM20103
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "XM20103";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grp01_XM20102_GRP_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.grp01_MENU_SELECTED.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MENUID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MENUNAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_Menuname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_Menuid)).EndInit();
            this.grp01_XM20102_GRP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.grp01_TARGET_LANGSET.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SYSTEMCODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MODULE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_Module;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MODULE;
        private System.Windows.Forms.GroupBox grp01_XM20102_GRP_1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox grp01_XM20102_GRP_3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SYSTEMCODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SYSTEMCODE;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter1;
        private System.Windows.Forms.GroupBox grp01_TARGET_LANGSET;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd03;
        private System.Windows.Forms.GroupBox grp01_MENU_SELECTED;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MENUID;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_MENUNAME;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_Menuname;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_Menuid;
        private Ax.DEV.Utility.Controls.AxSplitter heSplitter2;
    }
}
