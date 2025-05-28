namespace Ax.SIS.QA.QA00.UI
{
    partial class QA60131
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
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd01_QA60131 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.nme01_CYCLE = new Ax.DEV.Utility.Controls.AxNumericEdit();
            this.dte01_CONV_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CYCLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA40032 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox_main.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA60131)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme01_CYCLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CYCLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA40032)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.panel2);
            this.groupBox_main.Controls.Add(this.panel1);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_main.Location = new System.Drawing.Point(0, 34);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(1024, 734);
            this.groupBox_main.TabIndex = 4;
            this.groupBox_main.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd01_QA60131);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 563);
            this.panel2.TabIndex = 44;
            // 
            // grd01_QA60131
            // 
            this.grd01_QA60131.AllowHeaderMerging = false;
            this.grd01_QA60131.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01_QA60131.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_QA60131.EnabledActionFlag = true;
            this.grd01_QA60131.LastRowAdd = false;
            this.grd01_QA60131.Location = new System.Drawing.Point(0, 0);
            this.grd01_QA60131.Name = "grd01_QA60131";
            this.grd01_QA60131.OriginalFormat = null;
            this.grd01_QA60131.PopMenuVisible = true;
            this.grd01_QA60131.Rows.DefaultSize = 18;
            this.grd01_QA60131.Size = new System.Drawing.Size(1018, 563);
            this.grd01_QA60131.TabIndex = 3;
            this.grd01_QA60131.UseCustomHighlight = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_PLANT_DIV);
            this.panel1.Controls.Add(this.lbl01_VINCD);
            this.panel1.Controls.Add(this.cbo01_PLANT_DIV);
            this.panel1.Controls.Add(this.cdx01_VINCD);
            this.panel1.Controls.Add(this.nme01_CYCLE);
            this.panel1.Controls.Add(this.dte01_CONV_DATE);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_CYCLE);
            this.panel1.Controls.Add(this.lbl01_STD_DATE);
            this.panel1.Controls.Add(this.lbl01_BIZNM);
            this.panel1.Controls.Add(this.lbl01_QA40032);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 151);
            this.panel1.TabIndex = 43;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(346, 44);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(120, 21);
            this.lbl01_PLANT_DIV.TabIndex = 73;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(14, 116);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(120, 21);
            this.lbl01_VINCD.TabIndex = 50;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "적용차종";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(469, 45);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(203, 20);
            this.cbo01_PLANT_DIV.TabIndex = 72;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = false;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(137, 116);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(203, 21);
            this.cdx01_VINCD.TabIndex = 51;
            this.cdx01_VINCD.Tag = null;
            // 
            // nme01_CYCLE
            // 
            this.nme01_CYCLE.DisplayFormat.CustomFormat = "###,###,##0";
            this.nme01_CYCLE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme01_CYCLE.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme01_CYCLE.EditFormat.CustomFormat = "###,###,##0";
            this.nme01_CYCLE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme01_CYCLE.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.nme01_CYCLE.EmptyAsNull = true;
            this.nme01_CYCLE.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
            this.nme01_CYCLE.Location = new System.Drawing.Point(137, 92);
            this.nme01_CYCLE.Name = "nme01_CYCLE";
            this.nme01_CYCLE.NullText = "0";
            this.nme01_CYCLE.Size = new System.Drawing.Size(203, 21);
            this.nme01_CYCLE.TabIndex = 49;
            this.nme01_CYCLE.Tag = null;
            this.nme01_CYCLE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nme01_CYCLE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // dte01_CONV_DATE
            // 
            this.dte01_CONV_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_CONV_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_CONV_DATE.Location = new System.Drawing.Point(137, 68);
            this.dte01_CONV_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_CONV_DATE.Name = "dte01_CONV_DATE";
            this.dte01_CONV_DATE.OriginalFormat = "";
            this.dte01_CONV_DATE.Size = new System.Drawing.Size(203, 21);
            this.dte01_CONV_DATE.TabIndex = 48;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(137, 44);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(203, 20);
            this.cbo01_BIZCD.TabIndex = 47;
            // 
            // lbl01_CYCLE
            // 
            this.lbl01_CYCLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_CYCLE.AutoFontSizeMinValue = 9F;
            this.lbl01_CYCLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CYCLE.Location = new System.Drawing.Point(14, 92);
            this.lbl01_CYCLE.Name = "lbl01_CYCLE";
            this.lbl01_CYCLE.Size = new System.Drawing.Size(120, 21);
            this.lbl01_CYCLE.TabIndex = 46;
            this.lbl01_CYCLE.Tag = null;
            this.lbl01_CYCLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CYCLE.Value = "적용개월";
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(14, 68);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(120, 21);
            this.lbl01_STD_DATE.TabIndex = 45;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "기준일자";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(14, 44);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(120, 21);
            this.lbl01_BIZNM.TabIndex = 44;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // lbl01_QA40032
            // 
            this.lbl01_QA40032.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl01_QA40032.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA40032.AutoFontSizeMinValue = 9F;
            this.lbl01_QA40032.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_QA40032.Location = new System.Drawing.Point(14, 20);
            this.lbl01_QA40032.Name = "lbl01_QA40032";
            this.lbl01_QA40032.Size = new System.Drawing.Size(991, 21);
            this.lbl01_QA40032.TabIndex = 43;
            this.lbl01_QA40032.Tag = null;
            this.lbl01_QA40032.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_QA40032.Value = "유무검사 수동판정";
            // 
            // QA60131
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox_main);
            this.Name = "QA60131";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox_main, 0);
            this.groupBox_main.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01_QA60131)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nme01_CYCLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CYCLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA40032)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_main;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private Ax.DEV.Utility.Controls.AxNumericEdit nme01_CYCLE;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_CONV_DATE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CYCLE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA40032;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01_QA60131;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
