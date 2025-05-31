namespace Ax.SIS.WM.UI
{
    partial class WM30512
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
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_ESTI_CLASS = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_ESTI_CLASS = new Ax.DEV.Utility.Controls.AxComboBox();
            this.dtp01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_Date = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lbl01_WM30512_MSG1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ESTI_CLASS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 28);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.heDockingTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 740);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl01_WM30512_MSG1);
            this.panel2.Controls.Add(this.lbl01_VENDCD);
            this.panel2.Controls.Add(this.cdx01_VENDCD);
            this.panel2.Controls.Add(this.lbl01_ESTI_CLASS);
            this.panel2.Controls.Add(this.cbo01_ESTI_CLASS);
            this.panel2.Controls.Add(this.dtp01_STD_DATE);
            this.panel2.Controls.Add(this.lbl01_Date);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_VENDCD.Location = new System.Drawing.Point(5, 132);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(260, 21);
            this.lbl01_VENDCD.TabIndex = 136;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VENDCD.Value = "업체명";
            this.lbl01_VENDCD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(5, 156);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(260, 21);
            this.cdx01_VENDCD.TabIndex = 135;
            this.cdx01_VENDCD.Tag = null;
            // 
            // lbl01_ESTI_CLASS
            // 
            this.lbl01_ESTI_CLASS.AutoFontSizeMaxValue = 9F;
            this.lbl01_ESTI_CLASS.AutoFontSizeMinValue = 9F;
            this.lbl01_ESTI_CLASS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_ESTI_CLASS.Location = new System.Drawing.Point(5, 81);
            this.lbl01_ESTI_CLASS.Name = "lbl01_ESTI_CLASS";
            this.lbl01_ESTI_CLASS.Size = new System.Drawing.Size(260, 23);
            this.lbl01_ESTI_CLASS.TabIndex = 134;
            this.lbl01_ESTI_CLASS.Tag = null;
            this.lbl01_ESTI_CLASS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_ESTI_CLASS.Value = "평가클래스";
            // 
            // cbo01_ESTI_CLASS
            // 
            this.cbo01_ESTI_CLASS.BackColor = System.Drawing.Color.White;
            this.cbo01_ESTI_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_ESTI_CLASS.FormattingEnabled = true;
            this.cbo01_ESTI_CLASS.Location = new System.Drawing.Point(5, 107);
            this.cbo01_ESTI_CLASS.Name = "cbo01_ESTI_CLASS";
            this.cbo01_ESTI_CLASS.Size = new System.Drawing.Size(260, 20);
            this.cbo01_ESTI_CLASS.TabIndex = 133;
            // 
            // dtp01_STD_DATE
            // 
            this.dtp01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STD_DATE.Location = new System.Drawing.Point(117, 55);
            this.dtp01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STD_DATE.Name = "dtp01_STD_DATE";
            this.dtp01_STD_DATE.OriginalFormat = "";
            this.dtp01_STD_DATE.Size = new System.Drawing.Size(148, 21);
            this.dtp01_STD_DATE.TabIndex = 132;
            // 
            // lbl01_Date
            // 
            this.lbl01_Date.AutoFontSizeMaxValue = 9F;
            this.lbl01_Date.AutoFontSizeMinValue = 9F;
            this.lbl01_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_Date.Location = new System.Drawing.Point(5, 55);
            this.lbl01_Date.Name = "lbl01_Date";
            this.lbl01_Date.Size = new System.Drawing.Size(106, 21);
            this.lbl01_Date.TabIndex = 131;
            this.lbl01_Date.Tag = null;
            this.lbl01_Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_Date.Value = "Date";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(5, 206);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(260, 21);
            this.txt01_PARTNO.TabIndex = 125;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(5, 182);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(260, 23);
            this.lbl01_PARTNO.TabIndex = 124;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PARTNO.Value = "PART NO";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(5, 5);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(260, 23);
            this.lbl01_BIZNM2.TabIndex = 113;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(5, 31);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(260, 20);
            this.cbo01_BIZCD.TabIndex = 112;
            // 
            // heDockingTab1
            // 
            this.heDockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heDockingTab1.Location = new System.Drawing.Point(0, 0);
            this.heDockingTab1.Name = "heDockingTab1";
            this.heDockingTab1.PanelHeight = 740;
            this.heDockingTab1.PanelWidth = 277;
            this.heDockingTab1.Size = new System.Drawing.Size(1024, 740);
            this.heDockingTab1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grd01);
            this.panel3.Location = new System.Drawing.Point(279, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 736);
            this.panel3.TabIndex = 3;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 0);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(742, 736);
            this.grd01.TabIndex = 1;
            this.grd01.UseCustomHighlight = true;
            // 
            // lbl01_WM30512_MSG1
            // 
            this.lbl01_WM30512_MSG1.Font = new System.Drawing.Font("굴림체", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl01_WM30512_MSG1.Location = new System.Drawing.Point(3, 241);
            this.lbl01_WM30512_MSG1.Name = "lbl01_WM30512_MSG1";
            this.lbl01_WM30512_MSG1.Size = new System.Drawing.Size(270, 49);
            this.lbl01_WM30512_MSG1.TabIndex = 137;
            this.lbl01_WM30512_MSG1.Text = "SAP단위가 \'G\'인 것은 MES수량을 \'KG\'에서 \'G\'로 환산하였음 \r\n예) 수지류";
            this.lbl01_WM30512_MSG1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WM30512
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "WM30512";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ESTI_CLASS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxDockingTab heDockingTab1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxDateEdit dtp01_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_Date;
        private DEV.Utility.Controls.AxLabel lbl01_ESTI_CLASS;
        private DEV.Utility.Controls.AxComboBox cbo01_ESTI_CLASS;
        private DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private System.Windows.Forms.Label lbl01_WM30512_MSG1;
    }
}
