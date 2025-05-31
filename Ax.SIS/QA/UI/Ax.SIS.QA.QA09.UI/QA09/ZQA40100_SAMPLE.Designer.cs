namespace Ax.SIS.QA.QA09.UI
{
    partial class ZQA40100_SAMPLE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZQA40100_SAMPLE));
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.axTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 32);
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(17, 45);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(85, 21);
            this.lbl01_BIZCD.TabIndex = 114;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Plant";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(105, 44);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(123, 23);
            this.cbo01_BIZCD.TabIndex = 113;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 108);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 657);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 125;
            this.grd01.UseCustomHighlight = true;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(15, 81);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(85, 21);
            this.axLabel1.TabIndex = 121;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "TAX ID";
            // 
            // axDateEdit1
            // 
            this.axDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit1.Location = new System.Drawing.Point(409, 79);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(100, 21);
            this.axDateEdit1.TabIndex = 124;
            // 
            // axTextBox1
            // 
            this.axTextBox1.BackColor = System.Drawing.Color.White;
            this.axTextBox1.CausesValidation = false;
            this.axTextBox1.Location = new System.Drawing.Point(106, 81);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(128, 21);
            this.axTextBox1.TabIndex = 122;
            this.axTextBox1.Tag = null;
            this.axTextBox1.TextDetached = true;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(263, 80);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(140, 21);
            this.axLabel2.TabIndex = 123;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "TARGET DATE";
            // 
            // ZQA40100_SAMPLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.axLabel1);
            this.Controls.Add(this.axDateEdit1);
            this.Controls.Add(this.axTextBox1);
            this.Controls.Add(this.axLabel2);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Name = "ZQA40100_SAMPLE";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.axTextBox1, 0);
            this.Controls.SetChildIndex(this.axDateEdit1, 0);
            this.Controls.SetChildIndex(this.axLabel1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxDateEdit axDateEdit1;
        private DEV.Utility.Controls.AxTextBox axTextBox1;
        private DEV.Utility.Controls.AxLabel axLabel2;

    }
}
