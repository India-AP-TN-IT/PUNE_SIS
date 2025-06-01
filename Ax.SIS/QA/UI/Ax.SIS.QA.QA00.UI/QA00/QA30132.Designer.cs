namespace Ax.SIS.QA.QA00.UI
{
    partial class QA30132
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grd01_QA30132 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.btn01_SetUserEnviroment = new Ax.DEV.Utility.Controls.AxButton();
            this.grd01_VIEW_ITEMCD = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd01_VIEW_VINCD = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lbl01_VIEW_ITEMCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_CONV_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_SEARCH_TYPE = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_VIEW_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_SEARCH_TYPE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30132)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_VIEW_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_VIEW_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIEW_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIEW_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_QA30132);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 423);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // grd01_QA30132
            // 
            this.grd01_QA30132.AllowHeaderMerging = false;
            this.grd01_QA30132.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_QA30132.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA30132.EnabledActionFlag = true;
            this.grd01_QA30132.LastRowAdd = false;
            this.grd01_QA30132.Location = new System.Drawing.Point(3, 17);
            this.grd01_QA30132.Name = "grd01_QA30132";
            this.grd01_QA30132.OriginalFormat = null;
            this.grd01_QA30132.PopMenuVisible = true;
            this.grd01_QA30132.Rows.DefaultSize = 18;
            this.grd01_QA30132.Size = new System.Drawing.Size(272, 403);
            this.grd01_QA30132.TabIndex = 2;
            this.grd01_QA30132.UseCustomHighlight = true;
            // 
            // btn01_SetUserEnviroment
            // 
            this.btn01_SetUserEnviroment.Location = new System.Drawing.Point(14, 373);
            this.btn01_SetUserEnviroment.Name = "btn01_SetUserEnviroment";
            this.btn01_SetUserEnviroment.Size = new System.Drawing.Size(247, 23);
            this.btn01_SetUserEnviroment.TabIndex = 21;
            this.btn01_SetUserEnviroment.Text = "사용자설정저장";
            this.btn01_SetUserEnviroment.UseVisualStyleBackColor = true;
            this.btn01_SetUserEnviroment.Click += new System.EventHandler(this.btn01_SetUserEnviroment_Click);
            // 
            // grd01_VIEW_ITEMCD
            // 
            this.grd01_VIEW_ITEMCD.AllowHeaderMerging = false;
            this.grd01_VIEW_ITEMCD.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_VIEW_ITEMCD.EnabledActionFlag = true;
            this.grd01_VIEW_ITEMCD.LastRowAdd = false;
            this.grd01_VIEW_ITEMCD.Location = new System.Drawing.Point(14, 285);
            this.grd01_VIEW_ITEMCD.Name = "grd01_VIEW_ITEMCD";
            this.grd01_VIEW_ITEMCD.OriginalFormat = null;
            this.grd01_VIEW_ITEMCD.PopMenuVisible = true;
            this.grd01_VIEW_ITEMCD.Rows.DefaultSize = 18;
            this.grd01_VIEW_ITEMCD.Size = new System.Drawing.Size(247, 82);
            this.grd01_VIEW_ITEMCD.TabIndex = 20;
            this.grd01_VIEW_ITEMCD.UseCustomHighlight = true;
            this.grd01_VIEW_ITEMCD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_VIEW_ITEMCD_MouseClick);
            // 
            // grd01_VIEW_VINCD
            // 
            this.grd01_VIEW_VINCD.AllowHeaderMerging = false;
            this.grd01_VIEW_VINCD.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01_VIEW_VINCD.EnabledActionFlag = true;
            this.grd01_VIEW_VINCD.LastRowAdd = false;
            this.grd01_VIEW_VINCD.Location = new System.Drawing.Point(14, 176);
            this.grd01_VIEW_VINCD.Name = "grd01_VIEW_VINCD";
            this.grd01_VIEW_VINCD.OriginalFormat = null;
            this.grd01_VIEW_VINCD.PopMenuVisible = true;
            this.grd01_VIEW_VINCD.Rows.DefaultSize = 18;
            this.grd01_VIEW_VINCD.Size = new System.Drawing.Size(247, 82);
            this.grd01_VIEW_VINCD.TabIndex = 19;
            this.grd01_VIEW_VINCD.UseCustomHighlight = true;
            this.grd01_VIEW_VINCD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grd01_VIEW_VINCD_MouseClick);
            // 
            // lbl01_VIEW_ITEMCD
            // 
            this.lbl01_VIEW_ITEMCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIEW_ITEMCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VIEW_ITEMCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VIEW_ITEMCD.Location = new System.Drawing.Point(14, 270);
            this.lbl01_VIEW_ITEMCD.Name = "lbl01_VIEW_ITEMCD";
            this.lbl01_VIEW_ITEMCD.Size = new System.Drawing.Size(247, 12);
            this.lbl01_VIEW_ITEMCD.TabIndex = 18;
            this.lbl01_VIEW_ITEMCD.Tag = null;
            this.lbl01_VIEW_ITEMCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VIEW_ITEMCD.Value = "표시품목";
            // 
            // dte01_CONV_DATE
            // 
            this.dte01_CONV_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_CONV_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_CONV_DATE.Location = new System.Drawing.Point(14, 128);
            this.dte01_CONV_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_CONV_DATE.Name = "dte01_CONV_DATE";
            this.dte01_CONV_DATE.OriginalFormat = "";
            this.dte01_CONV_DATE.Size = new System.Drawing.Size(247, 21);
            this.dte01_CONV_DATE.TabIndex = 16;
            // 
            // cbo01_SEARCH_TYPE
            // 
            this.cbo01_SEARCH_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SEARCH_TYPE.FormattingEnabled = true;
            this.cbo01_SEARCH_TYPE.Location = new System.Drawing.Point(14, 81);
            this.cbo01_SEARCH_TYPE.Name = "cbo01_SEARCH_TYPE";
            this.cbo01_SEARCH_TYPE.Size = new System.Drawing.Size(247, 20);
            this.cbo01_SEARCH_TYPE.TabIndex = 14;
            this.cbo01_SEARCH_TYPE.SelectedIndexChanged += new System.EventHandler(this.cbo01_SEARCH_TYPE_SelectedIndexChanged);
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(14, 113);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(247, 12);
            this.lbl01_STD_DATE.TabIndex = 6;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_STD_DATE.Value = "조회일자";
            // 
            // lbl01_VIEW_VINCD
            // 
            this.lbl01_VIEW_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIEW_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VIEW_VINCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VIEW_VINCD.Location = new System.Drawing.Point(14, 161);
            this.lbl01_VIEW_VINCD.Name = "lbl01_VIEW_VINCD";
            this.lbl01_VIEW_VINCD.Size = new System.Drawing.Size(247, 12);
            this.lbl01_VIEW_VINCD.TabIndex = 4;
            this.lbl01_VIEW_VINCD.Tag = null;
            this.lbl01_VIEW_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VIEW_VINCD.Value = "표시차종";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(14, 34);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(247, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_SEARCH_TYPE
            // 
            this.lbl01_SEARCH_TYPE.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCH_TYPE.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCH_TYPE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SEARCH_TYPE.Location = new System.Drawing.Point(14, 66);
            this.lbl01_SEARCH_TYPE.Name = "lbl01_SEARCH_TYPE";
            this.lbl01_SEARCH_TYPE.Size = new System.Drawing.Size(247, 12);
            this.lbl01_SEARCH_TYPE.TabIndex = 2;
            this.lbl01_SEARCH_TYPE.Tag = null;
            this.lbl01_SEARCH_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_SEARCH_TYPE.Value = "조회형태";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(14, 19);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(247, 12);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.btn01_SetUserEnviroment);
            this.panel1.Controls.Add(this.grd01_VIEW_ITEMCD);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_VIEW_ITEMCD);
            this.panel1.Controls.Add(this.grd01_VIEW_VINCD);
            this.panel1.Controls.Add(this.cbo01_SEARCH_TYPE);
            this.panel1.Controls.Add(this.lbl01_VIEW_VINCD);
            this.panel1.Controls.Add(this.dte01_CONV_DATE);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.lbl01_SEARCH_TYPE);
            this.panel1.Controls.Add(this.lbl01_STD_DATE);
            this.panel1.Location = new System.Drawing.Point(26, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 491);
            this.panel1.TabIndex = 14;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(14, 408);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(247, 12);
            this.lbl01_PLANT_DIV.TabIndex = 23;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(14, 427);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(247, 20);
            this.cbo01_PLANT_DIV.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(319, 342);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 423);
            this.panel2.TabIndex = 15;
            // 
            // QA30132
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA30132";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA30132)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_VIEW_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_VIEW_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIEW_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIEW_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA30132;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_CONV_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_SEARCH_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VIEW_VINCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SEARCH_TYPE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VIEW_ITEMCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_VIEW_ITEMCD;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_VIEW_VINCD;
        private Ax.DEV.Utility.Controls.AxButton btn01_SetUserEnviroment;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
