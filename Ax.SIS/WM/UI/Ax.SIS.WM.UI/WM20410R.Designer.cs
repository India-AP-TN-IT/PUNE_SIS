namespace Ax.SIS.WM.UI
{
    partial class WM20410R
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WM20410R));
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.dtp01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.Txt_PartNo = new System.Windows.Forms.TextBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1080, 34);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 106);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1080, 662);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 10;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.cbo01_CORCD);
            this.groupBox3.Controls.Add(this.lbl01_CORCD);
            this.groupBox3.Controls.Add(this.cbo01_BIZCD);
            this.groupBox3.Controls.Add(this.lbl01_BIZCD);
            this.groupBox3.Controls.Add(this.Txt_PartNo);
            this.groupBox3.Controls.Add(this.lbl01_PARTNO);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1080, 72);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl01_STD_DATE);
            this.panel1.Controls.Add(this.dtp01_STD_DATE);
            this.panel1.Location = new System.Drawing.Point(864, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 26);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(3, 2);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(107, 20);
            this.lbl01_STD_DATE.TabIndex = 78;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "DATE";
            // 
            // dtp01_STD_DATE
            // 
            this.dtp01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STD_DATE.Location = new System.Drawing.Point(114, 3);
            this.dtp01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STD_DATE.Name = "dtp01_STD_DATE";
            this.dtp01_STD_DATE.OriginalFormat = "";
            this.dtp01_STD_DATE.Size = new System.Drawing.Size(97, 21);
            this.dtp01_STD_DATE.TabIndex = 79;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(552, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 48);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Part Division";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(219, 21);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Material";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(105, 21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "SUB-ASS\'Y";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "ASS\'Y";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(140, 14);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_CORCD.TabIndex = 75;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(3, 13);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(134, 21);
            this.lbl01_CORCD.TabIndex = 76;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "Corporation";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(413, 14);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(121, 23);
            this.cbo01_BIZCD.TabIndex = 74;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(311, 14);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(100, 20);
            this.lbl01_BIZCD.TabIndex = 73;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business";
            // 
            // Txt_PartNo
            // 
            this.Txt_PartNo.Location = new System.Drawing.Point(116, 40);
            this.Txt_PartNo.Name = "Txt_PartNo";
            this.Txt_PartNo.Size = new System.Drawing.Size(221, 21);
            this.Txt_PartNo.TabIndex = 71;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(3, 41);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(108, 20);
            this.lbl01_PARTNO.TabIndex = 70;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "Part Number";
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel|*.xlsx|Excel 97 - 2003|*.xls";
            // 
            // WM20410R
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox3);
            this.Name = "WM20410R";
            this.Size = new System.Drawing.Size(1080, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Txt_PartNo;
        private DEV.Utility.Controls.AxLabel lbl01_PARTNO;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxDateEdit dtp01_STD_DATE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog ofdExcel;

    }
}
