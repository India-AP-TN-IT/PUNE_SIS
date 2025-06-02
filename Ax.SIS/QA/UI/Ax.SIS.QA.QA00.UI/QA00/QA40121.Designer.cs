namespace Ax.SIS.QA.QA00.UI
{
    partial class QA40121
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
            this.lbl01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT_DIV = new Ax.DEV.Utility.Controls.AxComboBox();
            this.chk01_PRINT_GUBN = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.opt02_BY_VEHICLE = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.opt01_BY_VENDER = new Ax.DEV.Utility.Controls.AxRadioButton();
            this.dte01_DATE_TO = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_DATE_FROM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_QA40121_MSG2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_PRINT = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_EQUIP_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_QA40121_MSG1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_QA40121_MSG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PRINT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_EQUIP_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA40121_MSG1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.lbl01_PLANT_DIV);
            this.groupBox_main.Controls.Add(this.cbo01_PLANT_DIV);
            this.groupBox_main.Controls.Add(this.chk01_PRINT_GUBN);
            this.groupBox_main.Controls.Add(this.opt02_BY_VEHICLE);
            this.groupBox_main.Controls.Add(this.opt01_BY_VENDER);
            this.groupBox_main.Controls.Add(this.dte01_DATE_TO);
            this.groupBox_main.Controls.Add(this.dte01_DATE_FROM);
            this.groupBox_main.Controls.Add(this.cbo01_BIZCD);
            this.groupBox_main.Controls.Add(this.lbl02_QA40121_MSG2);
            this.groupBox_main.Controls.Add(this.lbl02_PRINT);
            this.groupBox_main.Controls.Add(this.lbl02_EQUIP_DATE);
            this.groupBox_main.Controls.Add(this.lbl01_BIZNM);
            this.groupBox_main.Controls.Add(this.lbl01_QA40121_MSG1);
            this.groupBox_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_main.Location = new System.Drawing.Point(0, 34);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(1024, 734);
            this.groupBox_main.TabIndex = 3;
            this.groupBox_main.TabStop = false;
            // 
            // lbl01_PLANT_DIV
            // 
            this.lbl01_PLANT_DIV.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLANT_DIV.AutoFontSizeMinValue = 9F;
            this.lbl01_PLANT_DIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PLANT_DIV.Location = new System.Drawing.Point(34, 100);
            this.lbl01_PLANT_DIV.Name = "lbl01_PLANT_DIV";
            this.lbl01_PLANT_DIV.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PLANT_DIV.TabIndex = 65;
            this.lbl01_PLANT_DIV.Tag = null;
            this.lbl01_PLANT_DIV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PLANT_DIV.Value = "공장구분";
            // 
            // cbo01_PLANT_DIV
            // 
            this.cbo01_PLANT_DIV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT_DIV.FormattingEnabled = true;
            this.cbo01_PLANT_DIV.Location = new System.Drawing.Point(137, 101);
            this.cbo01_PLANT_DIV.Name = "cbo01_PLANT_DIV";
            this.cbo01_PLANT_DIV.Size = new System.Drawing.Size(234, 20);
            this.cbo01_PLANT_DIV.TabIndex = 64;
            // 
            // chk01_PRINT_GUBN
            // 
            this.chk01_PRINT_GUBN.AutoSize = true;
            this.chk01_PRINT_GUBN.Location = new System.Drawing.Point(271, 129);
            this.chk01_PRINT_GUBN.Name = "chk01_PRINT_GUBN";
            this.chk01_PRINT_GUBN.Size = new System.Drawing.Size(152, 16);
            this.chk01_PRINT_GUBN.TabIndex = 63;
            this.chk01_PRINT_GUBN.Text = "출력형태별 용지 나누기";
            this.chk01_PRINT_GUBN.UseVisualStyleBackColor = true;
            // 
            // opt02_BY_VEHICLE
            // 
            this.opt02_BY_VEHICLE.AutoSize = true;
            this.opt02_BY_VEHICLE.Location = new System.Drawing.Point(206, 129);
            this.opt02_BY_VEHICLE.Name = "opt02_BY_VEHICLE";
            this.opt02_BY_VEHICLE.Size = new System.Drawing.Size(59, 16);
            this.opt02_BY_VEHICLE.TabIndex = 60;
            this.opt02_BY_VEHICLE.TabStop = true;
            this.opt02_BY_VEHICLE.Text = "차종별";
            this.opt02_BY_VEHICLE.UseVisualStyleBackColor = true;
            // 
            // opt01_BY_VENDER
            // 
            this.opt01_BY_VENDER.AutoSize = true;
            this.opt01_BY_VENDER.Location = new System.Drawing.Point(141, 129);
            this.opt01_BY_VENDER.Name = "opt01_BY_VENDER";
            this.opt01_BY_VENDER.Size = new System.Drawing.Size(59, 16);
            this.opt01_BY_VENDER.TabIndex = 59;
            this.opt01_BY_VENDER.TabStop = true;
            this.opt01_BY_VENDER.Text = "업체별";
            this.opt01_BY_VENDER.UseVisualStyleBackColor = true;
            // 
            // dte01_DATE_TO
            // 
            this.dte01_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.dte01_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DATE_TO.Location = new System.Drawing.Point(342, 76);
            this.dte01_DATE_TO.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DATE_TO.Name = "dte01_DATE_TO";
            this.dte01_DATE_TO.OriginalFormat = "";
            this.dte01_DATE_TO.Size = new System.Drawing.Size(203, 21);
            this.dte01_DATE_TO.TabIndex = 39;
            // 
            // dte01_DATE_FROM
            // 
            this.dte01_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.dte01_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_DATE_FROM.Location = new System.Drawing.Point(137, 76);
            this.dte01_DATE_FROM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_DATE_FROM.Name = "dte01_DATE_FROM";
            this.dte01_DATE_FROM.OriginalFormat = "";
            this.dte01_DATE_FROM.Size = new System.Drawing.Size(203, 21);
            this.dte01_DATE_FROM.TabIndex = 38;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(137, 52);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(203, 20);
            this.cbo01_BIZCD.TabIndex = 27;
            // 
            // lbl02_QA40121_MSG2
            // 
            this.lbl02_QA40121_MSG2.AutoFontSizeMaxValue = 9F;
            this.lbl02_QA40121_MSG2.AutoFontSizeMinValue = 9F;
            this.lbl02_QA40121_MSG2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_QA40121_MSG2.Location = new System.Drawing.Point(34, 148);
            this.lbl02_QA40121_MSG2.Name = "lbl02_QA40121_MSG2";
            this.lbl02_QA40121_MSG2.Size = new System.Drawing.Size(728, 21);
            this.lbl02_QA40121_MSG2.TabIndex = 14;
            this.lbl02_QA40121_MSG2.Tag = null;
            this.lbl02_QA40121_MSG2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_QA40121_MSG2.Value = "LINE 단품 불량 및 공정 불량 현황입니다.";
            // 
            // lbl02_PRINT
            // 
            this.lbl02_PRINT.AutoFontSizeMaxValue = 9F;
            this.lbl02_PRINT.AutoFontSizeMinValue = 9F;
            this.lbl02_PRINT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_PRINT.Location = new System.Drawing.Point(34, 124);
            this.lbl02_PRINT.Name = "lbl02_PRINT";
            this.lbl02_PRINT.Size = new System.Drawing.Size(100, 21);
            this.lbl02_PRINT.TabIndex = 13;
            this.lbl02_PRINT.Tag = null;
            this.lbl02_PRINT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_PRINT.Value = "후반기";
            // 
            // lbl02_EQUIP_DATE
            // 
            this.lbl02_EQUIP_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_EQUIP_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_EQUIP_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_EQUIP_DATE.Location = new System.Drawing.Point(34, 76);
            this.lbl02_EQUIP_DATE.Name = "lbl02_EQUIP_DATE";
            this.lbl02_EQUIP_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_EQUIP_DATE.TabIndex = 11;
            this.lbl02_EQUIP_DATE.Tag = null;
            this.lbl02_EQUIP_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_EQUIP_DATE.Value = "반입일자";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(34, 52);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 6;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // lbl01_QA40121_MSG1
            // 
            this.lbl01_QA40121_MSG1.AutoFontSizeMaxValue = 9F;
            this.lbl01_QA40121_MSG1.AutoFontSizeMinValue = 9F;
            this.lbl01_QA40121_MSG1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_QA40121_MSG1.Location = new System.Drawing.Point(34, 28);
            this.lbl01_QA40121_MSG1.Name = "lbl01_QA40121_MSG1";
            this.lbl01_QA40121_MSG1.Size = new System.Drawing.Size(728, 21);
            this.lbl01_QA40121_MSG1.TabIndex = 5;
            this.lbl01_QA40121_MSG1.Tag = null;
            this.lbl01_QA40121_MSG1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_QA40121_MSG1.Value = "공정불량 현황 출력";
            // 
            // QA40121
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox_main);
            this.Name = "QA40121";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox_main, 0);
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLANT_DIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_QA40121_MSG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_PRINT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_EQUIP_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA40121_MSG1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_main;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_PRINT_GUBN;
        private Ax.DEV.Utility.Controls.AxRadioButton opt02_BY_VEHICLE;
        private Ax.DEV.Utility.Controls.AxRadioButton opt01_BY_VENDER;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_DATE_TO;
        private Ax.DEV.Utility.Controls.AxDateEdit dte01_DATE_FROM;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_QA40121_MSG2;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_PRINT;
        private Ax.DEV.Utility.Controls.AxLabel lbl02_EQUIP_DATE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_QA40121_MSG1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLANT_DIV;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_PLANT_DIV;
    }
}
