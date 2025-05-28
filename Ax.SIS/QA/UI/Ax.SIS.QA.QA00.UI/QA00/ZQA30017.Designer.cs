namespace Ax.SIS.QA.QA00.UI
{
    partial class ZQA30017
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
            this.grd01_ZQA30017 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel6 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel5 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_APP_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.heLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_APP_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_OCCR_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_VIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_COOPER_NM = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_ZQA30017)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCR_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COOPER_NM)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grd01_ZQA30017);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1024, 632);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inspection Item List";
            // 
            // grd01_ZQA30017
            // 
            this.grd01_ZQA30017.AllowHeaderMerging = false;
            this.grd01_ZQA30017.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_ZQA30017.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_ZQA30017.EnabledActionFlag = true;
            this.grd01_ZQA30017.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01_ZQA30017.LastRowAdd = false;
            this.grd01_ZQA30017.Location = new System.Drawing.Point(3, 17);
            this.grd01_ZQA30017.Name = "grd01_ZQA30017";
            this.grd01_ZQA30017.OriginalFormat = null;
            this.grd01_ZQA30017.PopMenuVisible = true;
            this.grd01_ZQA30017.Rows.DefaultSize = 18;
            this.grd01_ZQA30017.Size = new System.Drawing.Size(1018, 612);
            this.grd01_ZQA30017.TabIndex = 0;
            this.grd01_ZQA30017.UseCustomHighlight = true;
            this.grd01_ZQA30017.AfterSort += new C1.Win.C1FlexGrid.SortColEventHandler(this.grd01_ZQA30017_AfterSort);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dte01_APP_END_DATE);
            this.groupBox1.Controls.Add(this.heLabel2);
            this.groupBox1.Controls.Add(this.dte01_APP_BEG_DATE);
            this.groupBox1.Controls.Add(this.lbl01_OCCR_DATE);
            this.groupBox1.Controls.Add(this.txt01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_PARTNO);
            this.groupBox1.Controls.Add(this.lbl01_PLANT_DIV);
            this.groupBox1.Controls.Add(this.cbo01_PLANT_DIV);
            this.groupBox1.Controls.Add(this.lbl01_VIN);
            this.groupBox1.Controls.Add(this.cdx01_VINCD);
            this.groupBox1.Controls.Add(this.cdx01_VENDCD);
            this.groupBox1.Controls.Add(this.lbl01_COOPER_NM);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 102);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.axLabel1);
            this.groupBox2.Controls.Add(this.axLabel6);
            this.groupBox2.Controls.Add(this.axLabel5);
            this.groupBox2.Controls.Add(this.axLabel2);
            this.groupBox2.Controls.Add(this.axLabel4);
            this.groupBox2.Controls.Add(this.axLabel3);
            this.groupBox2.Location = new System.Drawing.Point(688, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 81);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Legend";
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(144)))));
            this.axLabel1.BorderColor = System.Drawing.Color.Black;
            this.axLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axLabel1.Location = new System.Drawing.Point(10, 20);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(48, 21);
            this.axLabel1.TabIndex = 21;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "";
            // 
            // axLabel6
            // 
            this.axLabel6.AutoFontSizeMaxValue = 9F;
            this.axLabel6.AutoFontSizeMinValue = 9F;
            this.axLabel6.BackColor = System.Drawing.Color.White;
            this.axLabel6.BorderColor = System.Drawing.Color.Black;
            this.axLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axLabel6.Location = new System.Drawing.Point(178, 16);
            this.axLabel6.Name = "axLabel6";
            this.axLabel6.Size = new System.Drawing.Size(48, 21);
            this.axLabel6.TabIndex = 23;
            this.axLabel6.Tag = null;
            this.axLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel6.Value = "";
            // 
            // axLabel5
            // 
            this.axLabel5.AutoFontSizeMaxValue = 9F;
            this.axLabel5.AutoFontSizeMinValue = 9F;
            this.axLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(202)))));
            this.axLabel5.BorderColor = System.Drawing.Color.Black;
            this.axLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axLabel5.Location = new System.Drawing.Point(10, 47);
            this.axLabel5.Name = "axLabel5";
            this.axLabel5.Size = new System.Drawing.Size(48, 21);
            this.axLabel5.TabIndex = 22;
            this.axLabel5.Tag = null;
            this.axLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel5.Value = "";
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.AutoSize = true;
            this.axLabel2.BackColor = System.Drawing.Color.Transparent;
            this.axLabel2.Location = new System.Drawing.Point(64, 24);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(56, 12);
            this.axLabel2.TabIndex = 18;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "100% Inspection";
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.AutoSize = true;
            this.axLabel4.BackColor = System.Drawing.Color.Transparent;
            this.axLabel4.Location = new System.Drawing.Point(232, 21);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(56, 12);
            this.axLabel4.TabIndex = 20;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Without Inspection";
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.AutoSize = true;
            this.axLabel3.BackColor = System.Drawing.Color.Transparent;
            this.axLabel3.Location = new System.Drawing.Point(64, 52);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(56, 12);
            this.axLabel3.TabIndex = 19;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "Sampling Inspection";
            // 
            // dte01_APP_END_DATE
            // 
            this.dte01_APP_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_APP_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_APP_END_DATE.Location = new System.Drawing.Point(232, 70);
            this.dte01_APP_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_APP_END_DATE.Name = "dte01_APP_END_DATE";
            this.dte01_APP_END_DATE.OriginalFormat = "";
            this.dte01_APP_END_DATE.Size = new System.Drawing.Size(103, 21);
            this.dte01_APP_END_DATE.TabIndex = 15;
            // 
            // heLabel2
            // 
            this.heLabel2.AutoFontSizeMaxValue = 9F;
            this.heLabel2.AutoFontSizeMinValue = 9F;
            this.heLabel2.AutoSize = true;
            this.heLabel2.BackColor = System.Drawing.Color.Transparent;
            this.heLabel2.Location = new System.Drawing.Point(212, 74);
            this.heLabel2.Name = "heLabel2";
            this.heLabel2.Size = new System.Drawing.Size(56, 12);
            this.heLabel2.TabIndex = 16;
            this.heLabel2.Tag = null;
            this.heLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.heLabel2.Value = "~";
            // 
            // dte01_APP_BEG_DATE
            // 
            this.dte01_APP_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_APP_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_APP_BEG_DATE.Location = new System.Drawing.Point(103, 70);
            this.dte01_APP_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_APP_BEG_DATE.Name = "dte01_APP_BEG_DATE";
            this.dte01_APP_BEG_DATE.OriginalFormat = "";
            this.dte01_APP_BEG_DATE.Size = new System.Drawing.Size(103, 21);
            this.dte01_APP_BEG_DATE.TabIndex = 14;
            // 
            // lbl01_OCCR_DATE
            // 
            this.lbl01_OCCR_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_OCCR_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_OCCR_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_OCCR_DATE.Location = new System.Drawing.Point(10, 70);
            this.lbl01_OCCR_DATE.Name = "lbl01_OCCR_DATE";
            this.lbl01_OCCR_DATE.Size = new System.Drawing.Size(90, 21);
            this.lbl01_OCCR_DATE.TabIndex = 13;
            this.lbl01_OCCR_DATE.Tag = null;
            this.lbl01_OCCR_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_OCCR_DATE.Value = "Date";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(452, 43);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(221, 21);
            this.txt01_PARTNO.TabIndex = 12;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(352, 44);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(94, 21);
            this.lbl01_PARTNO.TabIndex = 11;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "Partno";
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(10, 44);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(90, 21);
            this.lbl01_PLANT_DIV.TabIndex = 9;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PLANT_DIV.Value = "Plant";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(103, 44);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(232, 20);
            this.cbo01_PLANT_DIV.TabIndex = 10;
            // 
            // lbl01_VIN
            // 
            this.lbl01_VIN.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIN.AutoFontSizeMinValue = 9F;
            this.lbl01_VIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VIN.Location = new System.Drawing.Point(352, 17);
            this.lbl01_VIN.Name = "lbl01_VIN";
            this.lbl01_VIN.Size = new System.Drawing.Size(94, 21);
            this.lbl01_VIN.TabIndex = 6;
            this.lbl01_VIN.Tag = null;
            this.lbl01_VIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VIN.Value = "Vehicle";
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = false;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(452, 17);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(221, 21);
            this.cdx01_VINCD.TabIndex = 7;
            this.cdx01_VINCD.Tag = null;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 50;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(103, 17);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(232, 21);
            this.cdx01_VENDCD.TabIndex = 5;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_COOPER_NM
            // 
            this.lbl01_COOPER_NM.AutoFontSizeMaxValue = 9F;
            this.lbl01_COOPER_NM.AutoFontSizeMinValue = 9F;
            this.lbl01_COOPER_NM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_COOPER_NM.Location = new System.Drawing.Point(10, 17);
            this.lbl01_COOPER_NM.Name = "lbl01_COOPER_NM";
            this.lbl01_COOPER_NM.Size = new System.Drawing.Size(90, 21);
            this.lbl01_COOPER_NM.TabIndex = 4;
            this.lbl01_COOPER_NM.Tag = null;
            this.lbl01_COOPER_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_COOPER_NM.Value = "Supplier";
            // 
            // ZQA30017
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ZQA30017";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_ZQA30017)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OCCR_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_COOPER_NM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_ZQA30017;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxLabel lbl01_COOPER_NM;
        private DEV.Utility.Controls.AxLabel lbl01_VIN;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxDateEdit dte01_APP_END_DATE;
        private DEV.Utility.Controls.AxDateEdit dte01_APP_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_OCCR_DATE;
        private DEV.Utility.Controls.AxLabel heLabel2;
        private DEV.Utility.Controls.AxLabel axLabel4;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxLabel axLabel6;
        private DEV.Utility.Controls.AxLabel axLabel5;



    }
}
