namespace Ax.SIS.TM.UI
{
    partial class TM23200
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM23200));
            this.cdx01_PARTNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axButton2 = new Ax.DEV.Utility.Controls.AxButton();
            this.grd03 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.btn01_AddPrint = new Ax.DEV.Utility.Controls.AxButton();
            this.label1 = new System.Windows.Forms.Label();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 28);
            // 
            // cdx01_PARTNO
            // 
            this.cdx01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_PARTNO.CodeParameterName = "CODE";
            this.cdx01_PARTNO.CodeTextBoxReadOnly = false;
            this.cdx01_PARTNO.CodeTextBoxVisible = true;
            this.cdx01_PARTNO.CodeTextBoxWidth = 40;
            this.cdx01_PARTNO.HEPopupHelper = null;
            this.cdx01_PARTNO.Location = new System.Drawing.Point(30, 0);
            this.cdx01_PARTNO.Name = "cdx01_PARTNO";
            this.cdx01_PARTNO.NameParameterName = "NAME";
            this.cdx01_PARTNO.NameTextBoxReadOnly = false;
            this.cdx01_PARTNO.NameTextBoxVisible = true;
            this.cdx01_PARTNO.PopupButtonReadOnly = false;
            this.cdx01_PARTNO.PopupTitle = "";
            this.cdx01_PARTNO.PrefixCode = "";
            this.cdx01_PARTNO.Size = new System.Drawing.Size(207, 21);
            this.cdx01_PARTNO.TabIndex = 36;
            this.cdx01_PARTNO.Tag = null;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(187, 59);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(407, 21);
            this.txt01_PARTNO.TabIndex = 127;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(11, 59);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(170, 21);
            this.lbl01_PARTNO.TabIndex = 126;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "PART NO";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(11, 31);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(172, 23);
            this.lbl01_BIZNM2.TabIndex = 113;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "Plant";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(187, 33);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(226, 23);
            this.cbo01_BIZCD.TabIndex = 112;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.axButton2);
            this.panel1.Controls.Add(this.grd03);
            this.panel1.Controls.Add(this.btn01_AddPrint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.axLabel3);
            this.panel1.Controls.Add(this.axTextBox2);
            this.panel1.Controls.Add(this.axLabel1);
            this.panel1.Location = new System.Drawing.Point(652, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 679);
            this.panel1.TabIndex = 128;
            // 
            // axButton2
            // 
            this.axButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axButton2.BackColor = System.Drawing.Color.Yellow;
            this.axButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.axButton2.Location = new System.Drawing.Point(189, 610);
            this.axButton2.Name = "axButton2";
            this.axButton2.Size = new System.Drawing.Size(172, 62);
            this.axButton2.TabIndex = 149;
            this.axButton2.Text = "Barcode\r\nPrinter";
            this.axButton2.UseVisualStyleBackColor = false;
            this.axButton2.Click += new System.EventHandler(this.axButton2_Click);
            // 
            // grd03
            // 
            this.grd03.AllowHeaderMerging = false;
            this.grd03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd03.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd03.EnabledActionFlag = true;
            this.grd03.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd03.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd03.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd03.LastRowAdd = false;
            this.grd03.Location = new System.Drawing.Point(3, 328);
            this.grd03.Name = "grd03";
            this.grd03.OriginalFormat = null;
            this.grd03.PopMenuVisible = false;
            this.grd03.Rows.DefaultSize = 18;
            this.grd03.Size = new System.Drawing.Size(359, 276);
            this.grd03.StyleInfo = resources.GetString("grd03.StyleInfo");
            this.grd03.TabIndex = 148;
            this.grd03.UseCustomHighlight = true;
            // 
            // btn01_AddPrint
            // 
            this.btn01_AddPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn01_AddPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn01_AddPrint.Location = new System.Drawing.Point(3, 194);
            this.btn01_AddPrint.Name = "btn01_AddPrint";
            this.btn01_AddPrint.Size = new System.Drawing.Size(231, 41);
            this.btn01_AddPrint.TabIndex = 128;
            this.btn01_AddPrint.Text = "Add to lists";
            this.btn01_AddPrint.UseVisualStyleBackColor = true;
            this.btn01_AddPrint.Click += new System.EventHandler(this.btn01_AddPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 127;
            this.label1.Text = "label1";
            // 
            // axLabel3
            // 
            this.axLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(2, 10);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(359, 23);
            this.axLabel3.TabIndex = 126;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.axLabel3.Value = "Selected Part NO.";
            // 
            // axTextBox2
            // 
            this.axTextBox2.Location = new System.Drawing.Point(2, 90);
            this.axTextBox2.Name = "axTextBox2";
            this.axTextBox2.Size = new System.Drawing.Size(135, 21);
            this.axTextBox2.TabIndex = 124;
            this.axTextBox2.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(2, 64);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(359, 23);
            this.axLabel1.TabIndex = 121;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.axLabel1.Value = "QTY";
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
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(11, 86);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = false;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(635, 679);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 129;
            this.grd01.UseCustomHighlight = true;
            this.grd01.SelChange += new System.EventHandler(this.grd01_SelChange);
            // 
            // TM23200
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl01_PARTNO);
            this.Controls.Add(this.txt01_PARTNO);
            this.Controls.Add(this.cdx01_PARTNO);
            this.Controls.Add(this.lbl01_BIZNM2);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Name = "TM23200";
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZNM2, 0);
            this.Controls.SetChildIndex(this.cdx01_PARTNO, 0);
            this.Controls.SetChildIndex(this.txt01_PARTNO, 0);
            this.Controls.SetChildIndex(this.lbl01_PARTNO, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxCodeBox cdx01_PARTNO;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxTextBox axTextBox2;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Label label1;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxFlexGrid grd03;
        private DEV.Utility.Controls.AxButton btn01_AddPrint;
        private DEV.Utility.Controls.AxButton axButton2;
    }
}
