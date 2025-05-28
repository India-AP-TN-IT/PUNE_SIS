namespace Ax.SIS.HR.UI
{
    partial class HR10020
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HR10020));
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cdx01_EMPNO = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel9 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VENDCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel14 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_CATEGORY = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.Dat_DOJ = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.axLabel12 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axRadioButton1 = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.axRadioButton2 = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.axRadioButton3 = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.axRadioButton4 = new Ax.DEV.Utility.Controls.AxRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_EMPNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CATEGORY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel12)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(12, 41);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(85, 21);
            this.lbl01_BIZCD.TabIndex = 123;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Plant";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(100, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(123, 23);
            this.cbo01_BIZCD.TabIndex = 122;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(12, 118);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = false;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(997, 535);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 151;
            this.grd01.UseCustomHighlight = true;
            // 
            // cdx01_EMPNO
            // 
            this.cdx01_EMPNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_EMPNO.CodeParameterName = "CODE";
            this.cdx01_EMPNO.CodeTextBoxReadOnly = false;
            this.cdx01_EMPNO.CodeTextBoxVisible = true;
            this.cdx01_EMPNO.CodeTextBoxWidth = 60;
            this.cdx01_EMPNO.HEPopupHelper = null;
            this.cdx01_EMPNO.Location = new System.Drawing.Point(186, 67);
            this.cdx01_EMPNO.Name = "cdx01_EMPNO";
            this.cdx01_EMPNO.NameParameterName = "NAME";
            this.cdx01_EMPNO.NameTextBoxReadOnly = false;
            this.cdx01_EMPNO.NameTextBoxVisible = true;
            this.cdx01_EMPNO.PopupButtonReadOnly = false;
            this.cdx01_EMPNO.PopupTitle = "";
            this.cdx01_EMPNO.PrefixCode = "";
            this.cdx01_EMPNO.Size = new System.Drawing.Size(278, 21);
            this.cdx01_EMPNO.TabIndex = 158;
            this.cdx01_EMPNO.Tag = null;
            // 
            // axLabel9
            // 
            this.axLabel9.AutoFontSizeMaxValue = 9F;
            this.axLabel9.AutoFontSizeMinValue = 9F;
            this.axLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel9.Location = new System.Drawing.Point(11, 69);
            this.axLabel9.Name = "axLabel9";
            this.axLabel9.Size = new System.Drawing.Size(169, 21);
            this.axLabel9.TabIndex = 157;
            this.axLabel9.Tag = null;
            this.axLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel9.Value = "Employee";
            // 
            // cdx01_VENDCD
            // 
            this.cdx01_VENDCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VENDCD.CodeParameterName = "CODE";
            this.cdx01_VENDCD.CodeTextBoxReadOnly = false;
            this.cdx01_VENDCD.CodeTextBoxVisible = true;
            this.cdx01_VENDCD.CodeTextBoxWidth = 60;
            this.cdx01_VENDCD.HEPopupHelper = null;
            this.cdx01_VENDCD.Location = new System.Drawing.Point(413, 40);
            this.cdx01_VENDCD.Name = "cdx01_VENDCD";
            this.cdx01_VENDCD.NameParameterName = "NAME";
            this.cdx01_VENDCD.NameTextBoxReadOnly = false;
            this.cdx01_VENDCD.NameTextBoxVisible = true;
            this.cdx01_VENDCD.PopupButtonReadOnly = false;
            this.cdx01_VENDCD.PopupTitle = "";
            this.cdx01_VENDCD.PrefixCode = "";
            this.cdx01_VENDCD.Size = new System.Drawing.Size(278, 21);
            this.cdx01_VENDCD.TabIndex = 156;
            this.cdx01_VENDCD.Tag = null;
            // 
            // axLabel14
            // 
            this.axLabel14.AutoFontSizeMaxValue = 9F;
            this.axLabel14.AutoFontSizeMinValue = 9F;
            this.axLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel14.Location = new System.Drawing.Point(238, 42);
            this.axLabel14.Name = "axLabel14";
            this.axLabel14.Size = new System.Drawing.Size(169, 21);
            this.axLabel14.TabIndex = 155;
            this.axLabel14.Tag = null;
            this.axLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel14.Value = "Vendor";
            // 
            // cdx01_CATEGORY
            // 
            this.cdx01_CATEGORY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_CATEGORY.CodeParameterName = "CODE";
            this.cdx01_CATEGORY.CodeTextBoxReadOnly = false;
            this.cdx01_CATEGORY.CodeTextBoxVisible = true;
            this.cdx01_CATEGORY.CodeTextBoxWidth = 60;
            this.cdx01_CATEGORY.HEPopupHelper = null;
            this.cdx01_CATEGORY.Location = new System.Drawing.Point(651, 67);
            this.cdx01_CATEGORY.Name = "cdx01_CATEGORY";
            this.cdx01_CATEGORY.NameParameterName = "NAME";
            this.cdx01_CATEGORY.NameTextBoxReadOnly = false;
            this.cdx01_CATEGORY.NameTextBoxVisible = true;
            this.cdx01_CATEGORY.PopupButtonReadOnly = false;
            this.cdx01_CATEGORY.PopupTitle = "";
            this.cdx01_CATEGORY.PrefixCode = "";
            this.cdx01_CATEGORY.Size = new System.Drawing.Size(285, 21);
            this.cdx01_CATEGORY.TabIndex = 164;
            this.cdx01_CATEGORY.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(470, 67);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(175, 21);
            this.axLabel2.TabIndex = 163;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Category";
            // 
            // Dat_DOJ
            // 
            this.Dat_DOJ.CustomFormat = "yyyy-MM-dd";
            this.Dat_DOJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dat_DOJ.Location = new System.Drawing.Point(192, 94);
            this.Dat_DOJ.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.Dat_DOJ.Name = "Dat_DOJ";
            this.Dat_DOJ.OriginalFormat = "";
            this.Dat_DOJ.Size = new System.Drawing.Size(124, 21);
            this.Dat_DOJ.TabIndex = 166;
            // 
            // axLabel12
            // 
            this.axLabel12.AutoFontSizeMaxValue = 9F;
            this.axLabel12.AutoFontSizeMinValue = 9F;
            this.axLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel12.Location = new System.Drawing.Point(11, 94);
            this.axLabel12.Name = "axLabel12";
            this.axLabel12.Size = new System.Drawing.Size(175, 21);
            this.axLabel12.TabIndex = 165;
            this.axLabel12.Tag = null;
            this.axLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel12.Value = "W/Date";
            // 
            // axRadioButton1
            // 
            this.axRadioButton1.AutoSize = true;
            this.axRadioButton1.Checked = true;
            this.axRadioButton1.Location = new System.Drawing.Point(379, 94);
            this.axRadioButton1.Name = "axRadioButton1";
            this.axRadioButton1.Size = new System.Drawing.Size(86, 19);
            this.axRadioButton1.TabIndex = 167;
            this.axRadioButton1.TabStop = true;
            this.axRadioButton1.Text = "Attendance";
            this.axRadioButton1.UseVisualStyleBackColor = true;
            // 
            // axRadioButton2
            // 
            this.axRadioButton2.AutoSize = true;
            this.axRadioButton2.Location = new System.Drawing.Point(480, 94);
            this.axRadioButton2.Name = "axRadioButton2";
            this.axRadioButton2.Size = new System.Drawing.Size(58, 19);
            this.axRadioButton2.TabIndex = 168;
            this.axRadioButton2.Text = "Leave";
            this.axRadioButton2.UseVisualStyleBackColor = true;
            // 
            // axRadioButton3
            // 
            this.axRadioButton3.AutoSize = true;
            this.axRadioButton3.Location = new System.Drawing.Point(559, 94);
            this.axRadioButton3.Name = "axRadioButton3";
            this.axRadioButton3.Size = new System.Drawing.Size(53, 19);
            this.axRadioButton3.TabIndex = 169;
            this.axRadioButton3.Text = "Meal";
            this.axRadioButton3.UseVisualStyleBackColor = true;
            // 
            // axRadioButton4
            // 
            this.axRadioButton4.AutoSize = true;
            this.axRadioButton4.Location = new System.Drawing.Point(559, 94);
            this.axRadioButton4.Name = "axRadioButton4";
            this.axRadioButton4.Size = new System.Drawing.Size(82, 19);
            this.axRadioButton4.TabIndex = 169;
            this.axRadioButton4.Text = "Out Punch";
            this.axRadioButton4.UseVisualStyleBackColor = true;
            // 
            // HR10020
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.axRadioButton4);
            this.Controls.Add(this.axRadioButton3);
            this.Controls.Add(this.axRadioButton2);
            this.Controls.Add(this.axRadioButton1);
            this.Controls.Add(this.Dat_DOJ);
            this.Controls.Add(this.axLabel12);
            this.Controls.Add(this.cdx01_CATEGORY);
            this.Controls.Add(this.axLabel2);
            this.Controls.Add(this.cdx01_EMPNO);
            this.Controls.Add(this.axLabel9);
            this.Controls.Add(this.cdx01_VENDCD);
            this.Controls.Add(this.axLabel14);
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Name = "HR10020";
            this.Size = new System.Drawing.Size(1024, 656);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.Controls.SetChildIndex(this.axLabel14, 0);
            this.Controls.SetChildIndex(this.cdx01_VENDCD, 0);
            this.Controls.SetChildIndex(this.axLabel9, 0);
            this.Controls.SetChildIndex(this.cdx01_EMPNO, 0);
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.cdx01_CATEGORY, 0);
            this.Controls.SetChildIndex(this.axLabel12, 0);
            this.Controls.SetChildIndex(this.Dat_DOJ, 0);
            this.Controls.SetChildIndex(this.axRadioButton1, 0);
            this.Controls.SetChildIndex(this.axRadioButton2, 0);
            this.Controls.SetChildIndex(this.axRadioButton3, 0);
            this.Controls.SetChildIndex(this.axRadioButton4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_EMPNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CATEGORY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxCodeBox cdx01_EMPNO;
        private DEV.Utility.Controls.AxLabel axLabel9;
        private DEV.Utility.Controls.AxCodeBox cdx01_VENDCD;
        private DEV.Utility.Controls.AxLabel axLabel14;
        private DEV.Utility.Controls.AxCodeBox cdx01_CATEGORY;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxDateEdit Dat_DOJ;
        private DEV.Utility.Controls.AxLabel axLabel12;
        private DEV.Utility.Controls.AxRadioButton axRadioButton1;
        private DEV.Utility.Controls.AxRadioButton axRadioButton2;
        private DEV.Utility.Controls.AxRadioButton axRadioButton3;
        private DEV.Utility.Controls.AxRadioButton axRadioButton4;

    }
}
