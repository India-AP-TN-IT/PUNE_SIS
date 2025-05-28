namespace Ax.SIS.QA.QA02.UI
{
    partial class QA20900
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
            this.tab01_main = new System.Windows.Forms.TabControl();
            this.tpg01_DIRE_VEND = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel8 = new System.Windows.Forms.Panel();
            this.grp01_SEARCH = new System.Windows.Forms.GroupBox();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_CUST_VENDCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CUST_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_INS_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA20900_MSG2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA20900_MSG1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.tpg01_DIRE_PART = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd11 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grp11_SEARCH = new System.Windows.Forms.GroupBox();
            this.txt11_NOTE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl11_NOTE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt11_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl11_PARTNO_5 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl11_QA20900_MSG4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl11_QA20900_MSG3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.tab01_main.SuspendLayout();
            this.tpg01_DIRE_VEND.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel8.SuspendLayout();
            this.grp01_SEARCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CUST_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUST_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INS_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20900_MSG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20900_MSG1)).BeginInit();
            this.tpg01_DIRE_PART.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd11)).BeginInit();
            this.panel3.SuspendLayout();
            this.grp11_SEARCH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt11_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt11_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_PARTNO_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_QA20900_MSG4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_QA20900_MSG3)).BeginInit();
            this.SuspendLayout();
            // 
            // tab01_main
            // 
            this.tab01_main.Controls.Add(this.tpg01_DIRE_VEND);
            this.tab01_main.Controls.Add(this.tpg01_DIRE_PART);
            this.tab01_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab01_main.Location = new System.Drawing.Point(0, 34);
            this.tab01_main.Name = "tab01_main";
            this.tab01_main.SelectedIndex = 0;
            this.tab01_main.Size = new System.Drawing.Size(1024, 734);
            this.tab01_main.TabIndex = 3;
            this.tab01_main.SelectedIndexChanged += new System.EventHandler(this.tab01_SelectedIndexChanged);
            this.tab01_main.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tab01_main_Selecting);
            // 
            // tpg01_DIRE_VEND
            // 
            this.tpg01_DIRE_VEND.Controls.Add(this.panel7);
            this.tpg01_DIRE_VEND.Controls.Add(this.panel8);
            this.tpg01_DIRE_VEND.Location = new System.Drawing.Point(4, 22);
            this.tpg01_DIRE_VEND.Name = "tpg01_DIRE_VEND";
            this.tpg01_DIRE_VEND.Padding = new System.Windows.Forms.Padding(3);
            this.tpg01_DIRE_VEND.Size = new System.Drawing.Size(1016, 708);
            this.tpg01_DIRE_VEND.TabIndex = 3;
            this.tpg01_DIRE_VEND.Text = "직거래업체";
            this.tpg01_DIRE_VEND.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.grd01);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 70);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1010, 635);
            this.panel7.TabIndex = 4;
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
            this.grd01.Size = new System.Drawing.Size(1010, 635);
            this.grd01.TabIndex = 24;
            this.grd01.UseCustomHighlight = true;
            this.grd01.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowInserted);
            this.grd01.RowDeleted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowDeleted);
            this.grd01.RowCanceled += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd01_RowCanceled);
            this.grd01.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_BeforeEdit);
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.SetupEditor += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_SetupEditor);
            this.grd01.ValidateEdit += new C1.Win.C1FlexGrid.ValidateEditEventHandler(this.grd01_ValidateEdit);
            this.grd01.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_CellChecked);
            this.grd01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseClick);
            this.grd01.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseMove);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.grp01_SEARCH);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1010, 67);
            this.panel8.TabIndex = 7;
            // 
            // grp01_SEARCH
            // 
            this.grp01_SEARCH.Controls.Add(this.cdx01_VENDCD);
            this.grp01_SEARCH.Controls.Add(this.txt01_CUST_VENDCD);
            this.grp01_SEARCH.Controls.Add(this.lbl01_CUST_VENDCD);
            this.grp01_SEARCH.Controls.Add(this.lbl01_INS_VENDCD);
            this.grp01_SEARCH.Controls.Add(this.lbl01_QA20900_MSG2);
            this.grp01_SEARCH.Controls.Add(this.lbl01_QA20900_MSG1);
            this.grp01_SEARCH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_SEARCH.Location = new System.Drawing.Point(0, 0);
            this.grp01_SEARCH.Name = "grp01_SEARCH";
            this.grp01_SEARCH.Size = new System.Drawing.Size(1010, 67);
            this.grp01_SEARCH.TabIndex = 2;
            this.grp01_SEARCH.TabStop = false;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(112, 13);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(223, 21);
            this.cdx01_VENDCD.TabIndex = 283;
            this.cdx01_VENDCD.Tag = null;
            this.cdx01_VENDCD.Value = "";
            this.cdx01_VENDCD.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_ButtonClickAfter);
            this.cdx01_VENDCD.ValueChanged += new System.EventHandler(this.cdx01_ValueChanged);
            // 
            // txt01_CUST_VENDCD
            // 
            this.txt01_CUST_VENDCD.Location = new System.Drawing.Point(112, 39);
            this.txt01_CUST_VENDCD.Name = "txt01_CUST_VENDCD";
            this.txt01_CUST_VENDCD.Size = new System.Drawing.Size(184, 21);
            this.txt01_CUST_VENDCD.TabIndex = 268;
            this.txt01_CUST_VENDCD.Tag = null;
            // 
            // lbl01_CUST_VENDCD
            // 
            this.lbl01_CUST_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CUST_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CUST_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CUST_VENDCD.Location = new System.Drawing.Point(6, 39);
            this.lbl01_CUST_VENDCD.Name = "lbl01_CUST_VENDCD";
            this.lbl01_CUST_VENDCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CUST_VENDCD.TabIndex = 267;
            this.lbl01_CUST_VENDCD.Tag = null;
            this.lbl01_CUST_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CUST_VENDCD.Value = "고객협력사코드";
            // 
            // lbl01_INS_VENDCD
            // 
            this.lbl01_INS_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_INS_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_INS_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_INS_VENDCD.Location = new System.Drawing.Point(6, 13);
            this.lbl01_INS_VENDCD.Name = "lbl01_INS_VENDCD";
            this.lbl01_INS_VENDCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_INS_VENDCD.TabIndex = 117;
            this.lbl01_INS_VENDCD.Tag = null;
            this.lbl01_INS_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_INS_VENDCD.Value = "내부협력사코드";
            // 
            // lbl01_QA20900_MSG2
            // 
            this.lbl01_QA20900_MSG2.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA20900_MSG2.AutoFontSizeMinValue = 9F;
            this.lbl01_QA20900_MSG2.BackColor = System.Drawing.Color.White;
            this.lbl01_QA20900_MSG2.ForeColor = System.Drawing.Color.Red;
            this.lbl01_QA20900_MSG2.Location = new System.Drawing.Point(490, 24);
            this.lbl01_QA20900_MSG2.Name = "lbl01_QA20900_MSG2";
            this.lbl01_QA20900_MSG2.Size = new System.Drawing.Size(514, 11);
            this.lbl01_QA20900_MSG2.TabIndex = 91;
            this.lbl01_QA20900_MSG2.Tag = null;
            this.lbl01_QA20900_MSG2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_QA20900_MSG2.Value = "";
            this.lbl01_QA20900_MSG2.Visible = false;
            // 
            // lbl01_QA20900_MSG1
            // 
            this.lbl01_QA20900_MSG1.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA20900_MSG1.AutoFontSizeMinValue = 9F;
            this.lbl01_QA20900_MSG1.BackColor = System.Drawing.Color.White;
            this.lbl01_QA20900_MSG1.ForeColor = System.Drawing.Color.Red;
            this.lbl01_QA20900_MSG1.Location = new System.Drawing.Point(490, 10);
            this.lbl01_QA20900_MSG1.Name = "lbl01_QA20900_MSG1";
            this.lbl01_QA20900_MSG1.Size = new System.Drawing.Size(514, 11);
            this.lbl01_QA20900_MSG1.TabIndex = 90;
            this.lbl01_QA20900_MSG1.Tag = null;
            this.lbl01_QA20900_MSG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_QA20900_MSG1.Value = "";
            this.lbl01_QA20900_MSG1.Visible = false;
            // 
            // tpg01_DIRE_PART
            // 
            this.tpg01_DIRE_PART.Controls.Add(this.panel1);
            this.tpg01_DIRE_PART.Controls.Add(this.panel3);
            this.tpg01_DIRE_PART.Location = new System.Drawing.Point(4, 22);
            this.tpg01_DIRE_PART.Name = "tpg01_DIRE_PART";
            this.tpg01_DIRE_PART.Padding = new System.Windows.Forms.Padding(3);
            this.tpg01_DIRE_PART.Size = new System.Drawing.Size(1016, 708);
            this.tpg01_DIRE_PART.TabIndex = 0;
            this.tpg01_DIRE_PART.Text = "직거래부품";
            this.tpg01_DIRE_PART.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grd11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 635);
            this.panel1.TabIndex = 3;
            // 
            // grd11
            // 
            this.grd11.AllowHeaderMerging = false;
            this.grd11.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd11.EnabledActionFlag = true;
            this.grd11.LastRowAdd = false;
            this.grd11.Location = new System.Drawing.Point(0, 0);
            this.grd11.Name = "grd11";
            this.grd11.OriginalFormat = null;
            this.grd11.PopMenuVisible = true;
            this.grd11.Rows.DefaultSize = 18;
            this.grd11.Size = new System.Drawing.Size(1010, 635);
            this.grd11.TabIndex = 24;
            this.grd11.UseCustomHighlight = true;
            this.grd11.RowInserted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd11_RowInserted);
            this.grd11.RowDeleted += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd11_RowDeleted);
            this.grd11.RowCanceled += new Ax.DEV.Utility.Controls.AxFlexGrid.FAlterRowInsertEventHandler(this.grd11_RowCanceled);
            this.grd11.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd11_BeforeEdit);
            this.grd11.SetupEditor += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd11_SetupEditor);
            this.grd11.ValidateEdit += new C1.Win.C1FlexGrid.ValidateEditEventHandler(this.grd11_ValidateEdit);
            this.grd11.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd11_CellChecked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grp11_SEARCH);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1010, 67);
            this.panel3.TabIndex = 6;
            // 
            // grp11_SEARCH
            // 
            this.grp11_SEARCH.Controls.Add(this.txt11_NOTE);
            this.grp11_SEARCH.Controls.Add(this.lbl11_NOTE);
            this.grp11_SEARCH.Controls.Add(this.txt11_PARTNO);
            this.grp11_SEARCH.Controls.Add(this.lbl11_PARTNO_5);
            this.grp11_SEARCH.Controls.Add(this.lbl11_QA20900_MSG4);
            this.grp11_SEARCH.Controls.Add(this.lbl11_QA20900_MSG3);
            this.grp11_SEARCH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp11_SEARCH.Location = new System.Drawing.Point(0, 0);
            this.grp11_SEARCH.Name = "grp11_SEARCH";
            this.grp11_SEARCH.Size = new System.Drawing.Size(1010, 67);
            this.grp11_SEARCH.TabIndex = 2;
            this.grp11_SEARCH.TabStop = false;
            // 
            // txt11_NOTE
            // 
            this.txt11_NOTE.Location = new System.Drawing.Point(112, 39);
            this.txt11_NOTE.Name = "txt11_NOTE";
            this.txt11_NOTE.Size = new System.Drawing.Size(184, 21);
            this.txt11_NOTE.TabIndex = 268;
            this.txt11_NOTE.Tag = null;
            // 
            // lbl11_NOTE
            // 
            this.lbl11_NOTE.AutoFontSizeMaxValue = 9F;
            this.lbl11_NOTE.AutoFontSizeMinValue = 9F;
            this.lbl11_NOTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl11_NOTE.Location = new System.Drawing.Point(6, 39);
            this.lbl11_NOTE.Name = "lbl11_NOTE";
            this.lbl11_NOTE.Size = new System.Drawing.Size(100, 21);
            this.lbl11_NOTE.TabIndex = 267;
            this.lbl11_NOTE.Tag = null;
            this.lbl11_NOTE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl11_NOTE.Value = "비고";
            // 
            // txt11_PARTNO
            // 
            this.txt11_PARTNO.Location = new System.Drawing.Point(112, 13);
            this.txt11_PARTNO.Name = "txt11_PARTNO";
            this.txt11_PARTNO.Size = new System.Drawing.Size(184, 21);
            this.txt11_PARTNO.TabIndex = 266;
            this.txt11_PARTNO.Tag = null;
            // 
            // lbl11_PARTNO_5
            // 
            this.lbl11_PARTNO_5.AutoFontSizeMaxValue = 9F;
            this.lbl11_PARTNO_5.AutoFontSizeMinValue = 9F;
            this.lbl11_PARTNO_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl11_PARTNO_5.Location = new System.Drawing.Point(6, 13);
            this.lbl11_PARTNO_5.Name = "lbl11_PARTNO_5";
            this.lbl11_PARTNO_5.Size = new System.Drawing.Size(100, 21);
            this.lbl11_PARTNO_5.TabIndex = 117;
            this.lbl11_PARTNO_5.Tag = null;
            this.lbl11_PARTNO_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl11_PARTNO_5.Value = "품번(앞5자리)";
            // 
            // lbl11_QA20900_MSG4
            // 
            this.lbl11_QA20900_MSG4.AutoFontSizeMaxValue = 9F;
            this.lbl11_QA20900_MSG4.AutoFontSizeMinValue = 9F;
            this.lbl11_QA20900_MSG4.BackColor = System.Drawing.Color.White;
            this.lbl11_QA20900_MSG4.ForeColor = System.Drawing.Color.Red;
            this.lbl11_QA20900_MSG4.Location = new System.Drawing.Point(490, 24);
            this.lbl11_QA20900_MSG4.Name = "lbl11_QA20900_MSG4";
            this.lbl11_QA20900_MSG4.Size = new System.Drawing.Size(514, 11);
            this.lbl11_QA20900_MSG4.TabIndex = 91;
            this.lbl11_QA20900_MSG4.Tag = null;
            this.lbl11_QA20900_MSG4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl11_QA20900_MSG4.Value = "";
            this.lbl11_QA20900_MSG4.Visible = false;
            // 
            // lbl11_QA20900_MSG3
            // 
            this.lbl11_QA20900_MSG3.AutoFontSizeMaxValue = 9F;
            this.lbl11_QA20900_MSG3.AutoFontSizeMinValue = 9F;
            this.lbl11_QA20900_MSG3.BackColor = System.Drawing.Color.White;
            this.lbl11_QA20900_MSG3.ForeColor = System.Drawing.Color.Red;
            this.lbl11_QA20900_MSG3.Location = new System.Drawing.Point(490, 10);
            this.lbl11_QA20900_MSG3.Name = "lbl11_QA20900_MSG3";
            this.lbl11_QA20900_MSG3.Size = new System.Drawing.Size(514, 11);
            this.lbl11_QA20900_MSG3.TabIndex = 90;
            this.lbl11_QA20900_MSG3.Tag = null;
            this.lbl11_QA20900_MSG3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl11_QA20900_MSG3.Value = "";
            this.lbl11_QA20900_MSG3.Visible = false;
            // 
            // QA20900
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tab01_main);
            this.Name = "QA20900";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.tab01_main, 0);
            this.tab01_main.ResumeLayout(false);
            this.tpg01_DIRE_VEND.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel8.ResumeLayout(false);
            this.grp01_SEARCH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CUST_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUST_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_INS_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20900_MSG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA20900_MSG1)).EndInit();
            this.tpg01_DIRE_PART.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd11)).EndInit();
            this.panel3.ResumeLayout(false);
            this.grp11_SEARCH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt11_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt11_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_PARTNO_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_QA20900_MSG4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11_QA20900_MSG3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab01_main;
        private System.Windows.Forms.TabPage tpg01_DIRE_PART;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd11;
        private System.Windows.Forms.GroupBox grp11_SEARCH;
        private Ax.DEV.Utility.Controls.AxLabel lbl11_QA20900_MSG4;
        private Ax.DEV.Utility.Controls.AxLabel lbl11_QA20900_MSG3;
        private Ax.DEV.Utility.Controls.AxLabel lbl11_PARTNO_5;
        private Ax.DEV.Utility.Controls.AxTextBox txt11_PARTNO;
        private Ax.DEV.Utility.Controls.AxTextBox txt11_NOTE;
        private Ax.DEV.Utility.Controls.AxLabel lbl11_NOTE;
        private Ax.DEV.Utility.Controls.AxLabel lbl21_WORK_DIV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage tpg01_DIRE_VEND;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.GroupBox grp01_SEARCH;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_CUST_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CUST_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_INS_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA20900_MSG2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA20900_MSG1;
        private System.Windows.Forms.Panel panel7;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;

    }
}
