namespace Ax.SIS.WM.UI
{
    partial class WM30551
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
            this.lbl01_CANCEL_YN = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CANCEL_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt01_DELI_NOTE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_DELI_NOTE2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PONO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PONO_PER = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DASH = new Ax.DEV.Utility.Controls.AxLabel();
            this.dte01_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_PO_DELI_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_VEND = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_ESTI_CLASS = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_ESTI_CLASS = new Ax.DEV.Utility.Controls.AxComboBox();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.heDockingTab1 = new Ax.DEV.Utility.Controls.AxDockingTab();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CANCEL_YN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DELI_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_NOTE2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PONO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PONO_PER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PO_DELI_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ESTI_CLASS)).BeginInit();
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
            this.panel2.Controls.Add(this.lbl01_CANCEL_YN);
            this.panel2.Controls.Add(this.cbo01_CANCEL_YN);
            this.panel2.Controls.Add(this.txt01_DELI_NOTE);
            this.panel2.Controls.Add(this.lbl01_DELI_NOTE2);
            this.panel2.Controls.Add(this.txt01_PONO);
            this.panel2.Controls.Add(this.lbl01_PONO_PER);
            this.panel2.Controls.Add(this.lbl01_DASH);
            this.panel2.Controls.Add(this.dte01_DATE_TO);
            this.panel2.Controls.Add(this.dte01_DATE_FROM);
            this.panel2.Controls.Add(this.lbl01_PO_DELI_DATE);
            this.panel2.Controls.Add(this.lbl01_VEND);
            this.panel2.Controls.Add(this.cdx01_VENDCD);
            this.panel2.Controls.Add(this.lbl01_ESTI_CLASS);
            this.panel2.Controls.Add(this.cbo01_ESTI_CLASS);
            this.panel2.Controls.Add(this.txt01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_PARTNO);
            this.panel2.Controls.Add(this.lbl01_BIZNM2);
            this.panel2.Controls.Add(this.cbo01_BIZCD);
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 721);
            this.panel2.TabIndex = 1;
            // 
            // lbl01_CANCEL_YN
            // 
            this.lbl01_CANCEL_YN.AutoFontSizeMaxValue = 9F;
            this.lbl01_CANCEL_YN.AutoFontSizeMinValue = 9F;
            this.lbl01_CANCEL_YN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CANCEL_YN.Location = new System.Drawing.Point(3, 343);
            this.lbl01_CANCEL_YN.Name = "lbl01_CANCEL_YN";
            this.lbl01_CANCEL_YN.Size = new System.Drawing.Size(260, 23);
            this.lbl01_CANCEL_YN.TabIndex = 146;
            this.lbl01_CANCEL_YN.Tag = null;
            this.lbl01_CANCEL_YN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_CANCEL_YN.Value = "취소여부";
            // 
            // cbo01_CANCEL_YN
            // 
            this.cbo01_CANCEL_YN.BackColor = System.Drawing.Color.White;
            this.cbo01_CANCEL_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CANCEL_YN.FormattingEnabled = true;
            this.cbo01_CANCEL_YN.Location = new System.Drawing.Point(3, 369);
            this.cbo01_CANCEL_YN.Name = "cbo01_CANCEL_YN";
            this.cbo01_CANCEL_YN.Size = new System.Drawing.Size(260, 20);
            this.cbo01_CANCEL_YN.TabIndex = 145;
            // 
            // txt01_DELI_NOTE
            // 
            this.txt01_DELI_NOTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_DELI_NOTE.Location = new System.Drawing.Point(3, 319);
            this.txt01_DELI_NOTE.Name = "txt01_DELI_NOTE";
            this.txt01_DELI_NOTE.Size = new System.Drawing.Size(260, 21);
            this.txt01_DELI_NOTE.TabIndex = 144;
            this.txt01_DELI_NOTE.Tag = null;
            // 
            // lbl01_DELI_NOTE2
            // 
            this.lbl01_DELI_NOTE2.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELI_NOTE2.AutoFontSizeMinValue = 9F;
            this.lbl01_DELI_NOTE2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DELI_NOTE2.Location = new System.Drawing.Point(3, 295);
            this.lbl01_DELI_NOTE2.Name = "lbl01_DELI_NOTE2";
            this.lbl01_DELI_NOTE2.Size = new System.Drawing.Size(260, 23);
            this.lbl01_DELI_NOTE2.TabIndex = 143;
            this.lbl01_DELI_NOTE2.Tag = null;
            this.lbl01_DELI_NOTE2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_DELI_NOTE2.Value = "전표번호";
            // 
            // txt01_PONO
            // 
            this.txt01_PONO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PONO.Location = new System.Drawing.Point(3, 271);
            this.txt01_PONO.Name = "txt01_PONO";
            this.txt01_PONO.Size = new System.Drawing.Size(260, 21);
            this.txt01_PONO.TabIndex = 142;
            this.txt01_PONO.Tag = null;
            // 
            // lbl01_PONO_PER
            // 
            this.lbl01_PONO_PER.AutoFontSizeMaxValue = 9F;
            this.lbl01_PONO_PER.AutoFontSizeMinValue = 9F;
            this.lbl01_PONO_PER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PONO_PER.Location = new System.Drawing.Point(3, 247);
            this.lbl01_PONO_PER.Name = "lbl01_PONO_PER";
            this.lbl01_PONO_PER.Size = new System.Drawing.Size(260, 23);
            this.lbl01_PONO_PER.TabIndex = 141;
            this.lbl01_PONO_PER.Tag = null;
            this.lbl01_PONO_PER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PONO_PER.Value = "발주번호";
            // 
            // lbl01_DASH
            // 
            this.lbl01_DASH.AutoFontSizeMaxValue = 9F;
            this.lbl01_DASH.AutoFontSizeMinValue = 9F;
            this.lbl01_DASH.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_DASH.Location = new System.Drawing.Point(110, 80);
            this.lbl01_DASH.Name = "lbl01_DASH";
            this.lbl01_DASH.Size = new System.Drawing.Size(49, 21);
            this.lbl01_DASH.TabIndex = 140;
            this.lbl01_DASH.Tag = null;
            this.lbl01_DASH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DASH.Value = "~";
            // 
            // dte01_DATE_TO
            // 
            this.dte01_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DATE_TO.Location = new System.Drawing.Point(165, 78);
            this.dte01_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DATE_TO.Name = "dte01_DATE_TO";
            this.dte01_DATE_TO.OriginalFormat = "";
            this.dte01_DATE_TO.Size = new System.Drawing.Size(100, 21);
            this.dte01_DATE_TO.TabIndex = 139;
            // 
            // dte01_DATE_FROM
            // 
            this.dte01_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DATE_FROM.Location = new System.Drawing.Point(4, 78);
            this.dte01_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DATE_FROM.Name = "dte01_DATE_FROM";
            this.dte01_DATE_FROM.OriginalFormat = "";
            this.dte01_DATE_FROM.Size = new System.Drawing.Size(100, 21);
            this.dte01_DATE_FROM.TabIndex = 138;
            // 
            // lbl01_PO_DELI_DATE
            // 
            this.lbl01_PO_DELI_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PO_DELI_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_PO_DELI_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PO_DELI_DATE.Location = new System.Drawing.Point(4, 54);
            this.lbl01_PO_DELI_DATE.Name = "lbl01_PO_DELI_DATE";
            this.lbl01_PO_DELI_DATE.Size = new System.Drawing.Size(261, 21);
            this.lbl01_PO_DELI_DATE.TabIndex = 137;
            this.lbl01_PO_DELI_DATE.Tag = null;
            this.lbl01_PO_DELI_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_PO_DELI_DATE.Value = "_검수일자";
            // 
            // lbl01_VEND
            // 
            this.lbl01_VEND.AutoFontSizeMaxValue = 9F;
            this.lbl01_VEND.AutoFontSizeMinValue = 9F;
            this.lbl01_VEND.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VEND.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_VEND.Location = new System.Drawing.Point(3, 102);
            this.lbl01_VEND.Name = "lbl01_VEND";
            this.lbl01_VEND.Size = new System.Drawing.Size(260, 21);
            this.lbl01_VEND.TabIndex = 136;
            this.lbl01_VEND.Tag = null;
            this.lbl01_VEND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_VEND.Value = "업체명";
            this.lbl01_VEND.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(3, 126);
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
            this.lbl01_ESTI_CLASS.Location = new System.Drawing.Point(3, 150);
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
            this.cbo01_ESTI_CLASS.Location = new System.Drawing.Point(3, 176);
            this.cbo01_ESTI_CLASS.Name = "cbo01_ESTI_CLASS";
            this.cbo01_ESTI_CLASS.Size = new System.Drawing.Size(260, 20);
            this.cbo01_ESTI_CLASS.TabIndex = 133;
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_PARTNO.Location = new System.Drawing.Point(3, 223);
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
            this.lbl01_PARTNO.Location = new System.Drawing.Point(3, 199);
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
            this.grd01.EnabledActionFlag = false;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
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
            // WM30551
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "WM30551";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CANCEL_YN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_DELI_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELI_NOTE2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PONO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PONO_PER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DASH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PO_DELI_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_ESTI_CLASS)).EndInit();
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
        private DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxLabel lbl01_ESTI_CLASS;
        private DEV.Utility.Controls.AxComboBox cbo01_ESTI_CLASS;
        private DEV.Utility.Controls.AxLabel lbl01_VEND;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxLabel lbl01_CANCEL_YN;
        private DEV.Utility.Controls.AxComboBox cbo01_CANCEL_YN;
        private DEV.Utility.Controls.AxTextBox txt01_DELI_NOTE;
        private DEV.Utility.Controls.AxLabel lbl01_DELI_NOTE2;
        private DEV.Utility.Controls.AxTextBox txt01_PONO;
        private DEV.Utility.Controls.AxLabel lbl01_PONO_PER;
        private DEV.Utility.Controls.AxLabel lbl01_DASH;
        private DEV.Utility.Controls.AxDateEdit dte01_DATE_TO;
        private DEV.Utility.Controls.AxDateEdit dte01_DATE_FROM;
        private DEV.Utility.Controls.AxLabel lbl01_PO_DELI_DATE;
        private DEV.Utility.Controls.AxFlexGrid grd01;
    }
}
