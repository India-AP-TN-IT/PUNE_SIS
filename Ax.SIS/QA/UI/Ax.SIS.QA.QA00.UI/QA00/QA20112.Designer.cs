namespace Ax.SIS.QA.QA00.UI
{
    partial class QA20112
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
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_IMPUT_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_CLOSE_MONTH = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_DEAD_STD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_INS_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cdx01_ITEMCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_SEARCH_OPT = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_ITEMCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_VIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEAD_STD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_OPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEMCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd02);
            this.groupBox3.Controls.Add(this.grd01);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(58, 492);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(3, 17);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(52, 472);
            this.grd02.TabIndex = 1;
            this.grd02.UseCustomHighlight = true;
            this.grd02.Visible = false;
            this.grd02.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd02_MouseDoubleClick);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "1,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(52, 472);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 50;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(13, 88);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(252, 21);
            this.cdx01_VENDCD.TabIndex = 12;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_IMPUT_VENDCD
            // 
            this.lbl01_IMPUT_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_IMPUT_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_IMPUT_VENDCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_IMPUT_VENDCD.Location = new System.Drawing.Point(13, 69);
            this.lbl01_IMPUT_VENDCD.Name = "lbl01_IMPUT_VENDCD";
            this.lbl01_IMPUT_VENDCD.Size = new System.Drawing.Size(252, 16);
            this.lbl01_IMPUT_VENDCD.TabIndex = 11;
            this.lbl01_IMPUT_VENDCD.Tag = null;
            this.lbl01_IMPUT_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_IMPUT_VENDCD.Value = "업체";
            // 
            // dte01_CLOSE_MONTH
            // 
            this.dte01_CLOSE_MONTH.CustomFormat = "yyyy-MM";
            this.dte01_CLOSE_MONTH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_CLOSE_MONTH.Location = new System.Drawing.Point(13, 141);
            this.dte01_CLOSE_MONTH.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_CLOSE_MONTH.Name = "dte01_CLOSE_MONTH";
            this.dte01_CLOSE_MONTH.OriginalFormat = "";
            this.dte01_CLOSE_MONTH.Size = new System.Drawing.Size(252, 21);
            this.dte01_CLOSE_MONTH.TabIndex = 6;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(13, 38);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(252, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_DEAD_STD
            // 
            this.lbl01_DEAD_STD.AutoFontSizeMaxValue = 9F;
            this.lbl01_DEAD_STD.AutoFontSizeMinValue = 9F;
            this.lbl01_DEAD_STD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DEAD_STD.Location = new System.Drawing.Point(13, 122);
            this.lbl01_DEAD_STD.Name = "lbl01_DEAD_STD";
            this.lbl01_DEAD_STD.Size = new System.Drawing.Size(252, 16);
            this.lbl01_DEAD_STD.TabIndex = 1;
            this.lbl01_DEAD_STD.Tag = null;
            this.lbl01_DEAD_STD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DEAD_STD.Value = "마감기준";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 19);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(252, 16);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 34);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 734;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 734);
            this.heDockingTab1.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.cbo01_INS_DIV);
            this.panel1.Controls.Add(this.cdx01_VINCD);
            this.panel1.Controls.Add(this.cdx01_ITEMCD);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.dte01_CLOSE_MONTH);
            this.panel1.Controls.Add(this.cdx01_VENDCD);
            this.panel1.Controls.Add(this.lbl01_IMPUT_VENDCD);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Controls.Add(this.lbl01_SEARCH_OPT);
            this.panel1.Controls.Add(this.lbl01_ITEMCD);
            this.panel1.Controls.Add(this.lbl01_VIN);
            this.panel1.Controls.Add(this.lbl01_DEAD_STD);
            this.panel1.Location = new System.Drawing.Point(54, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 493);
            this.panel1.TabIndex = 16;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(13, 330);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(252, 16);
            this.lbl01_PLANT_DIV.TabIndex = 17;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(13, 349);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(252, 20);
            this.cbo01_PLANT_DIV.TabIndex = 16;
            // 
            // cbo01_INS_DIV
            // 
            this.cbo01_INS_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_INS_DIV.FormattingEnabled = true;
            this.cbo01_INS_DIV.Location = new System.Drawing.Point(13, 297);
            this.cbo01_INS_DIV.Name = "cbo01_INS_DIV";
            this.cbo01_INS_DIV.Size = new System.Drawing.Size(252, 20);
            this.cbo01_INS_DIV.TabIndex = 15;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = false;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(13, 193);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(252, 21);
            this.cdx01_VINCD.TabIndex = 14;
            this.cdx01_VINCD.Tag = null;
            // 
            // cdx01_ITEMCD
            // 
            this.cdx01_ITEMCD.CodeParameterName = "CODE";
            this.cdx01_ITEMCD.CodeTextBoxReadOnly = false;
            this.cdx01_ITEMCD.CodeTextBoxVisible = false;
            this.cdx01_ITEMCD.CodeTextBoxWidth = 40;
            this.cdx01_ITEMCD.HEPopupHelper = null;
            this.cdx01_ITEMCD.Location = new System.Drawing.Point(13, 244);
            this.cdx01_ITEMCD.Name = "cdx01_ITEMCD";
            this.cdx01_ITEMCD.NameParameterName = "NAME";
            this.cdx01_ITEMCD.NameTextBoxReadOnly = false;
            this.cdx01_ITEMCD.NameTextBoxVisible = true;
            this.cdx01_ITEMCD.PopupButtonReadOnly = false;
            this.cdx01_ITEMCD.PopupTitle = "";
            this.cdx01_ITEMCD.PrefixCode = "";
            this.cdx01_ITEMCD.Size = new System.Drawing.Size(252, 21);
            this.cdx01_ITEMCD.TabIndex = 13;
            this.cdx01_ITEMCD.Tag = null;
            // 
            // lbl01_SEARCH_OPT
            // 
            this.lbl01_SEARCH_OPT.AutoFontSizeMaxValue = 9F;
            this.lbl01_SEARCH_OPT.AutoFontSizeMinValue = 9F;
            this.lbl01_SEARCH_OPT.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_SEARCH_OPT.Location = new System.Drawing.Point(13, 278);
            this.lbl01_SEARCH_OPT.Name = "lbl01_SEARCH_OPT";
            this.lbl01_SEARCH_OPT.Size = new System.Drawing.Size(252, 16);
            this.lbl01_SEARCH_OPT.TabIndex = 1;
            this.lbl01_SEARCH_OPT.Tag = null;
            this.lbl01_SEARCH_OPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_SEARCH_OPT.Value = "조회구분";
            // 
            // lbl01_ITEMCD
            // 
            this.lbl01_ITEMCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_ITEMCD.AutoFontSizeMinValue = 9F;
            this.lbl01_ITEMCD.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_ITEMCD.Location = new System.Drawing.Point(13, 225);
            this.lbl01_ITEMCD.Name = "lbl01_ITEMCD";
            this.lbl01_ITEMCD.Size = new System.Drawing.Size(252, 16);
            this.lbl01_ITEMCD.TabIndex = 1;
            this.lbl01_ITEMCD.Tag = null;
            this.lbl01_ITEMCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ITEMCD.Value = "품목";
            // 
            // lbl01_VIN
            // 
            this.lbl01_VIN.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIN.AutoFontSizeMinValue = 9F;
            this.lbl01_VIN.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_VIN.Location = new System.Drawing.Point(13, 174);
            this.lbl01_VIN.Name = "lbl01_VIN";
            this.lbl01_VIN.Size = new System.Drawing.Size(252, 16);
            this.lbl01_VIN.TabIndex = 1;
            this.lbl01_VIN.Tag = null;
            this.lbl01_VIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VIN.Value = "차종";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(339, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(58, 492);
            this.panel2.TabIndex = 17;
            // 
            // QA20112
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.heDockingTab1);
            this.Name = "QA20112";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.heDockingTab1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_IMPUT_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DEAD_STD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_SEARCH_OPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ITEMCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_IMPUT_VENDCD;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_CLOSE_MONTH;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DEAD_STD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_ITEMCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ITEMCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VIN;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_INS_DIV;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_SEARCH_OPT;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
