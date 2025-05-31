namespace Ax.SIS.BM.BM00.UI
{
    partial class BM20710
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cdx01_LINECD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_REVISION = new Ax.DEV.Utility.Controls.AxTextBox();
            this.cdx01_ASSYNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_ASSYNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_BaseDate = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BaseDate = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_LINECD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_REVISION)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ASSYNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ASSYNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BaseDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cdx01_LINECD);
            this.groupBox1.Controls.Add(this.txt01_REVISION);
            this.groupBox1.Controls.Add(this.cdx01_ASSYNO);
            this.groupBox1.Controls.Add(this.lbl01_ASSYNO);
            this.groupBox1.Controls.Add(this.dte01_BaseDate);
            this.groupBox1.Controls.Add(this.lbl01_BaseDate);
            this.groupBox1.Controls.Add(this.lbl01_LINECD);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cdx01_LINECD
            // 
            this.cdx01_LINECD.CodeParameterName = "CODE";
            this.cdx01_LINECD.CodeTextBoxReadOnly = false;
            this.cdx01_LINECD.CodeTextBoxVisible = true;
            this.cdx01_LINECD.CodeTextBoxWidth = 80;
            this.cdx01_LINECD.HEPopupHelper = null;
            this.cdx01_LINECD.Location = new System.Drawing.Point(352, 19);
            this.cdx01_LINECD.Name = "cdx01_LINECD";
            this.cdx01_LINECD.NameParameterName = "NAME";
            this.cdx01_LINECD.NameTextBoxReadOnly = false;
            this.cdx01_LINECD.NameTextBoxVisible = true;
            this.cdx01_LINECD.PopupButtonReadOnly = false;
            this.cdx01_LINECD.PopupTitle = "";
            this.cdx01_LINECD.PrefixCode = "";
            this.cdx01_LINECD.Size = new System.Drawing.Size(432, 21);
            this.cdx01_LINECD.TabIndex = 41;
            this.cdx01_LINECD.Tag = null;
            this.cdx01_LINECD.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_LINECD_ButtonClickAfter);
            this.cdx01_LINECD.CodeBoxBindingAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_LINECD_CodeBoxBindingAfter);
            // 
            // txt01_REVISION
            // 
            this.txt01_REVISION.Location = new System.Drawing.Point(790, 47);
            this.txt01_REVISION.Name = "txt01_REVISION";
            this.txt01_REVISION.ReadOnly = true;
            this.txt01_REVISION.Size = new System.Drawing.Size(31, 21);
            this.txt01_REVISION.TabIndex = 13;
            this.txt01_REVISION.Tag = null;
            // 
            // cdx01_ASSYNO
            // 
            this.cdx01_ASSYNO.CodeParameterName = "CODE";
            this.cdx01_ASSYNO.CodeTextBoxReadOnly = false;
            this.cdx01_ASSYNO.CodeTextBoxVisible = true;
            this.cdx01_ASSYNO.CodeTextBoxWidth = 120;
            this.cdx01_ASSYNO.HEPopupHelper = null;
            this.cdx01_ASSYNO.Location = new System.Drawing.Point(352, 48);
            this.cdx01_ASSYNO.Name = "cdx01_ASSYNO";
            this.cdx01_ASSYNO.NameParameterName = "NAME";
            this.cdx01_ASSYNO.NameTextBoxReadOnly = false;
            this.cdx01_ASSYNO.NameTextBoxVisible = true;
            this.cdx01_ASSYNO.PopupButtonReadOnly = false;
            this.cdx01_ASSYNO.PopupTitle = "";
            this.cdx01_ASSYNO.PrefixCode = "";
            this.cdx01_ASSYNO.Size = new System.Drawing.Size(432, 21);
            this.cdx01_ASSYNO.TabIndex = 9;
            this.cdx01_ASSYNO.Tag = null;
            this.cdx01_ASSYNO.Value = "";
            this.cdx01_ASSYNO.ButtonClickAfter += new Ax.DEV.Utility.Controls.AxCodeBox.CButtonClickEventHandler(this.cdx01_ASSYNO_ButtonClickAfter);
            this.cdx01_ASSYNO.TextChanged += new System.EventHandler(this.cdx01_ASSYNO_TextChanged);
            // 
            // lbl01_ASSYNO
            // 
            this.lbl01_ASSYNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_ASSYNO.AutoFontSizeMinValue = 9F;
            this.lbl01_ASSYNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ASSYNO.Location = new System.Drawing.Point(246, 48);
            this.lbl01_ASSYNO.Name = "lbl01_ASSYNO";
            this.lbl01_ASSYNO.Size = new System.Drawing.Size(100, 20);
            this.lbl01_ASSYNO.TabIndex = 8;
            this.lbl01_ASSYNO.Tag = null;
            this.lbl01_ASSYNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_ASSYNO.Value = "P/NO";
            // 
            // dte01_BaseDate
            // 
            this.dte01_BaseDate.CustomFormat = "yyyy-MM-dd";
            this.dte01_BaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_BaseDate.Location = new System.Drawing.Point(112, 46);
            this.dte01_BaseDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_BaseDate.Name = "dte01_BaseDate";
            this.dte01_BaseDate.OriginalFormat = "";
            this.dte01_BaseDate.Size = new System.Drawing.Size(100, 21);
            this.dte01_BaseDate.TabIndex = 7;
            // 
            // lbl01_BaseDate
            // 
            this.lbl01_BaseDate.AutoFontSizeMaxValue = 9F;
            this.lbl01_BaseDate.AutoFontSizeMinValue = 9F;
            this.lbl01_BaseDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BaseDate.Location = new System.Drawing.Point(6, 47);
            this.lbl01_BaseDate.Name = "lbl01_BaseDate";
            this.lbl01_BaseDate.Size = new System.Drawing.Size(100, 20);
            this.lbl01_BaseDate.TabIndex = 6;
            this.lbl01_BaseDate.Tag = null;
            this.lbl01_BaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BaseDate.Value = "DATE";
            // 
            // lbl01_LINECD
            // 
            this.lbl01_LINECD.AutoFontSizeMaxValue = 9F;
            this.lbl01_LINECD.AutoFontSizeMinValue = 9F;
            this.lbl01_LINECD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_LINECD.Location = new System.Drawing.Point(246, 19);
            this.lbl01_LINECD.Name = "lbl01_LINECD";
            this.lbl01_LINECD.Size = new System.Drawing.Size(100, 20);
            this.lbl01_LINECD.TabIndex = 4;
            this.lbl01_LINECD.Tag = null;
            this.lbl01_LINECD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_LINECD.Value = "LINE";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(112, 20);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_BIZCD.TabIndex = 3;
            this.cbo01_BIZCD.SelectedIndexChanged += new System.EventHandler(this.cbo01_BIZCD_SelectedIndexChanged);
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(6, 20);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(100, 20);
            this.lbl01_BIZCD.TabIndex = 2;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business Plant";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd02.Dock = System.Windows.Forms.DockStyle.Right;
            this.grd02.EnabledActionFlag = true;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(784, 113);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(240, 655);
            this.grd02.TabIndex = 3;
            this.grd02.UseCustomHighlight = true;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 113);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(784, 655);
            this.grd01.TabIndex = 4;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            // 
            // BM20710
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.grd02);
            this.Controls.Add(this.groupBox1);
            this.Name = "BM20710";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd02, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_REVISION)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_ASSYNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ASSYNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BaseDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_LINECD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_LINECD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BaseDate;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_BaseDate;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_ASSYNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_ASSYNO;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_REVISION;
        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_LINECD;
    }
}
