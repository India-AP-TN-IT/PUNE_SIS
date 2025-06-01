namespace Ax.SIS.XM.UI
{
    partial class XM39010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XM39010));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk01_BASIC_ONLY = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.dte01_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_ESTI_CLASS = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_DATE_TITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ESTI_CLASS = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.chk01_VIEW_END_INV = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk01_VIEW_OUT_INV = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.chk01_VIEW_RCV_INV = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DATE_TITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ESTI_CLASS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.axDockingTab1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 734);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk01_VIEW_END_INV);
            this.panel1.Controls.Add(this.chk01_VIEW_OUT_INV);
            this.panel1.Controls.Add(this.chk01_VIEW_RCV_INV);
            this.panel1.Controls.Add(this.chk01_BASIC_ONLY);
            this.panel1.Controls.Add(this.dte01_DATE);
            this.panel1.Controls.Add(this.cbo01_ESTI_CLASS);
            this.panel1.Controls.Add(this.lbl01_DATE_TITLE);
            this.panel1.Controls.Add(this.lbl01_ESTI_CLASS);
            this.panel1.Controls.Add(this.txt01_PARTNO);
            this.panel1.Controls.Add(this.lbl01_PARTNO);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 637);
            this.panel1.TabIndex = 10;
            // 
            // chk01_BASIC_ONLY
            // 
            this.chk01_BASIC_ONLY.AutoSize = true;
            this.chk01_BASIC_ONLY.Checked = true;
            this.chk01_BASIC_ONLY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_BASIC_ONLY.Location = new System.Drawing.Point(13, 171);
            this.chk01_BASIC_ONLY.Name = "chk01_BASIC_ONLY";
            this.chk01_BASIC_ONLY.Size = new System.Drawing.Size(112, 16);
            this.chk01_BASIC_ONLY.TabIndex = 135;
            this.chk01_BASIC_ONLY.Text = "기초재고만 조회";
            this.chk01_BASIC_ONLY.UseVisualStyleBackColor = true;
            // 
            // dte01_DATE
            // 
            this.dte01_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DATE.Location = new System.Drawing.Point(96, 53);
            this.dte01_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DATE.Name = "dte01_DATE";
            this.dte01_DATE.OriginalFormat = "";
            this.dte01_DATE.Size = new System.Drawing.Size(117, 21);
            this.dte01_DATE.TabIndex = 133;
            this.dte01_DATE.ValueChanged += new System.EventHandler(this.dte01_DATE_ValueChanged);
            // 
            // cbo01_ESTI_CLASS
            // 
            this.cbo01_ESTI_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_ESTI_CLASS.FormattingEnabled = true;
            this.cbo01_ESTI_CLASS.Location = new System.Drawing.Point(13, 100);
            this.cbo01_ESTI_CLASS.Name = "cbo01_ESTI_CLASS";
            this.cbo01_ESTI_CLASS.Size = new System.Drawing.Size(200, 20);
            this.cbo01_ESTI_CLASS.TabIndex = 89;
            // 
            // lbl01_DATE_TITLE
            // 
            this.lbl01_DATE_TITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DATE_TITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_DATE_TITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DATE_TITLE.Location = new System.Drawing.Point(13, 53);
            this.lbl01_DATE_TITLE.Name = "lbl01_DATE_TITLE";
            this.lbl01_DATE_TITLE.Size = new System.Drawing.Size(80, 20);
            this.lbl01_DATE_TITLE.TabIndex = 74;
            this.lbl01_DATE_TITLE.Tag = null;
            this.lbl01_DATE_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DATE_TITLE.Value = "일자";
            // 
            // lbl01_ESTI_CLASS
            // 
            this.lbl01_ESTI_CLASS.AutoFontSizeMaxValue = 9F;
            this.lbl01_ESTI_CLASS.AutoFontSizeMinValue = 9F;
            this.lbl01_ESTI_CLASS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ESTI_CLASS.Location = new System.Drawing.Point(13, 77);
            this.lbl01_ESTI_CLASS.Name = "lbl01_ESTI_CLASS";
            this.lbl01_ESTI_CLASS.Size = new System.Drawing.Size(200, 20);
            this.lbl01_ESTI_CLASS.TabIndex = 73;
            this.lbl01_ESTI_CLASS.Tag = null;
            this.lbl01_ESTI_CLASS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ESTI_CLASS.Value = "평가클래스";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(13, 144);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(200, 21);
            this.txt01_PARTNO.TabIndex = 7;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(13, 123);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(200, 20);
            this.lbl01_PARTNO.TabIndex = 45;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "품번";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 30);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(200, 20);
            this.cbo01_BIZCD.TabIndex = 55;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 9);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(200, 20);
            this.lbl01_BIZNM2.TabIndex = 56;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd01);
            this.panel2.Location = new System.Drawing.Point(313, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 244);
            this.panel2.TabIndex = 12;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(346, 244);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            // 
            // axDockingTab1
            // 
            this.axDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axDockingTab1.Location = new System.Drawing.Point(3, 17);
            this.axDockingTab1.Name = "axDockingTab1";
            this.axDockingTab1.PanelHeight = 714;
            this.axDockingTab1.PanelWidth = 513;
            this.axDockingTab1.Size = new System.Drawing.Size(1018, 714);
            this.axDockingTab1.TabIndex = 11;
            // 
            // chk01_VIEW_END_INV
            // 
            this.chk01_VIEW_END_INV.AutoSize = true;
            this.chk01_VIEW_END_INV.Checked = true;
            this.chk01_VIEW_END_INV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_VIEW_END_INV.Location = new System.Drawing.Point(13, 237);
            this.chk01_VIEW_END_INV.Name = "chk01_VIEW_END_INV";
            this.chk01_VIEW_END_INV.Size = new System.Drawing.Size(100, 16);
            this.chk01_VIEW_END_INV.TabIndex = 140;
            this.chk01_VIEW_END_INV.Text = "기말재고 조회";
            this.chk01_VIEW_END_INV.UseVisualStyleBackColor = true;
            // 
            // chk01_VIEW_OUT_INV
            // 
            this.chk01_VIEW_OUT_INV.AutoSize = true;
            this.chk01_VIEW_OUT_INV.Checked = true;
            this.chk01_VIEW_OUT_INV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_VIEW_OUT_INV.Location = new System.Drawing.Point(13, 215);
            this.chk01_VIEW_OUT_INV.Name = "chk01_VIEW_OUT_INV";
            this.chk01_VIEW_OUT_INV.Size = new System.Drawing.Size(100, 16);
            this.chk01_VIEW_OUT_INV.TabIndex = 139;
            this.chk01_VIEW_OUT_INV.Text = "출고재고 조회";
            this.chk01_VIEW_OUT_INV.UseVisualStyleBackColor = true;
            // 
            // chk01_VIEW_RCV_INV
            // 
            this.chk01_VIEW_RCV_INV.AutoSize = true;
            this.chk01_VIEW_RCV_INV.Checked = true;
            this.chk01_VIEW_RCV_INV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_VIEW_RCV_INV.Location = new System.Drawing.Point(13, 193);
            this.chk01_VIEW_RCV_INV.Name = "chk01_VIEW_RCV_INV";
            this.chk01_VIEW_RCV_INV.Size = new System.Drawing.Size(100, 16);
            this.chk01_VIEW_RCV_INV.TabIndex = 138;
            this.chk01_VIEW_RCV_INV.Text = "입고재고 조회";
            this.chk01_VIEW_RCV_INV.UseVisualStyleBackColor = true;
            // 
            // XM39010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Name = "XM39010";
            this.Load += new System.EventHandler(this.XM39010_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DATE_TITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ESTI_CLASS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private System.Windows.Forms.Panel panel2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxDockingTab axDockingTab1;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxLabel lbl01_ESTI_CLASS;
        private DEV.Utility.Controls.AxLabel lbl01_DATE_TITLE;
        private DEV.Utility.Controls.AxComboBox cbo01_ESTI_CLASS;
        private DEV.Utility.Controls.AxDateEdit dte01_DATE;
        private DEV.Utility.Controls.AxCheckBox chk01_BASIC_ONLY;
        private DEV.Utility.Controls.AxCheckBox chk01_VIEW_END_INV;
        private DEV.Utility.Controls.AxCheckBox chk01_VIEW_OUT_INV;
        private DEV.Utility.Controls.AxCheckBox chk01_VIEW_RCV_INV;

    }
}
