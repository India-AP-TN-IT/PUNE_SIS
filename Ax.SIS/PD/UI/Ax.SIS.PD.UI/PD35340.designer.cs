namespace Ax.SIS.PD.UI
{
    partial class PD35340
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD35340));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp01_YYYY_MM = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_YYYYMM = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_YYYYMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp01_YYYY_MM);
            this.groupBox1.Controls.Add(this.lbl01_STD_YYYYMM);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM2);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 47);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // dtp01_YYYY_MM
            // 
            this.dtp01_YYYY_MM.CustomFormat = "yyyy-MM";
            this.dtp01_YYYY_MM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_YYYY_MM.Location = new System.Drawing.Point(357, 17);
            this.dtp01_YYYY_MM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_YYYY_MM.Name = "dtp01_YYYY_MM";
            this.dtp01_YYYY_MM.OriginalFormat = "";
            this.dtp01_YYYY_MM.Size = new System.Drawing.Size(130, 21);
            this.dtp01_YYYY_MM.TabIndex = 56;
            // 
            // lbl01_STD_YYYYMM
            // 
            this.lbl01_STD_YYYYMM.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_YYYYMM.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_YYYYMM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_YYYYMM.Location = new System.Drawing.Point(251, 17);
            this.lbl01_STD_YYYYMM.Name = "lbl01_STD_YYYYMM";
            this.lbl01_STD_YYYYMM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STD_YYYYMM.TabIndex = 55;
            this.lbl01_STD_YYYYMM.Tag = null;
            this.lbl01_STD_YYYYMM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_YYYYMM.Value = "근무일자";
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(9, 17);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 52;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(115, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(130, 20);
            this.cbo01_BIZCD.TabIndex = 51;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 81);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 687);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 17;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD35340
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD35340";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_YYYYMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxDateEdit dtp01_YYYY_MM;
        private DEV.Utility.Controls.AxLabel lbl01_STD_YYYYMM;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
    }
}
