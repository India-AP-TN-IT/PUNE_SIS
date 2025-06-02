namespace Ax.SIS.PD.UI
{
    partial class PD25420
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
            this.grp01_PD25311 = new System.Windows.Forms.GroupBox();
            this.btn01_PROCESS = new Ax.DEV.Utility.Controls.AxButton();
            this.dtp01_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_SAUP = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.grp01_PD25221 = new System.Windows.Forms.GroupBox();
            this.btn02_PROCESS = new Ax.DEV.Utility.Controls.AxButton();
            this.dtp02_STD_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl02_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo02_SAUP = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl02_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grp01_PD25311.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            this.grp01_PD25221.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_STD_DATE)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp01_PD25311
            // 
            this.grp01_PD25311.Controls.Add(this.btn01_PROCESS);
            this.grp01_PD25311.Controls.Add(this.dtp01_STD_DATE);
            this.grp01_PD25311.Controls.Add(this.lbl01_BIZNM2);
            this.grp01_PD25311.Controls.Add(this.cbo01_SAUP);
            this.grp01_PD25311.Controls.Add(this.lbl01_STD_DATE);
            this.grp01_PD25311.Location = new System.Drawing.Point(15, 20);
            this.grp01_PD25311.Name = "grp01_PD25311";
            this.grp01_PD25311.Size = new System.Drawing.Size(664, 80);
            this.grp01_PD25311.TabIndex = 8;
            this.grp01_PD25311.TabStop = false;
            this.grp01_PD25311.Text = "PD25311 공수일지 등록";
            // 
            // btn01_PROCESS
            // 
            this.btn01_PROCESS.Location = new System.Drawing.Point(540, 30);
            this.btn01_PROCESS.Name = "btn01_PROCESS";
            this.btn01_PROCESS.Size = new System.Drawing.Size(95, 25);
            this.btn01_PROCESS.TabIndex = 70;
            this.btn01_PROCESS.Text = "처리";
            this.btn01_PROCESS.UseVisualStyleBackColor = true;
            this.btn01_PROCESS.Click += new System.EventHandler(this.btn01_PROCESS_Click);
            // 
            // dtp01_STD_DATE
            // 
            this.dtp01_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_STD_DATE.Location = new System.Drawing.Point(393, 33);
            this.dtp01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_STD_DATE.Name = "dtp01_STD_DATE";
            this.dtp01_STD_DATE.OriginalFormat = "";
            this.dtp01_STD_DATE.Size = new System.Drawing.Size(106, 21);
            this.dtp01_STD_DATE.TabIndex = 69;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(25, 33);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM2.TabIndex = 68;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM2.Value = "사업장";
            // 
            // cbo01_SAUP
            // 
            this.cbo01_SAUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_SAUP.FormattingEnabled = true;
            this.cbo01_SAUP.Location = new System.Drawing.Point(129, 33);
            this.cbo01_SAUP.Name = "cbo01_SAUP";
            this.cbo01_SAUP.Size = new System.Drawing.Size(152, 20);
            this.cbo01_SAUP.TabIndex = 67;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(287, 32);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_STD_DATE.TabIndex = 48;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_STD_DATE.Value = "기준일자";
            // 
            // axDateEdit1
            // 
            this.axDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit1.Location = new System.Drawing.Point(507, 21);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(106, 21);
            this.axDateEdit1.TabIndex = 72;
            // 
            // grp01_PD25221
            // 
            this.grp01_PD25221.Controls.Add(this.btn02_PROCESS);
            this.grp01_PD25221.Controls.Add(this.dtp02_STD_DATE);
            this.grp01_PD25221.Controls.Add(this.lbl02_BIZNM2);
            this.grp01_PD25221.Controls.Add(this.cbo02_SAUP);
            this.grp01_PD25221.Controls.Add(this.lbl02_STD_DATE);
            this.grp01_PD25221.Location = new System.Drawing.Point(15, 115);
            this.grp01_PD25221.Name = "grp01_PD25221";
            this.grp01_PD25221.Size = new System.Drawing.Size(664, 80);
            this.grp01_PD25221.TabIndex = 10;
            this.grp01_PD25221.TabStop = false;
            this.grp01_PD25221.Text = "PD25221 비가동 실적 등록";
            // 
            // btn02_PROCESS
            // 
            this.btn02_PROCESS.Location = new System.Drawing.Point(540, 30);
            this.btn02_PROCESS.Name = "btn02_PROCESS";
            this.btn02_PROCESS.Size = new System.Drawing.Size(95, 25);
            this.btn02_PROCESS.TabIndex = 70;
            this.btn02_PROCESS.Text = "처리";
            this.btn02_PROCESS.UseVisualStyleBackColor = true;
            this.btn02_PROCESS.Click += new System.EventHandler(this.btn02_PROCESS_Click);
            // 
            // dtp02_STD_DATE
            // 
            this.dtp02_STD_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp02_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp02_STD_DATE.Location = new System.Drawing.Point(393, 33);
            this.dtp02_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp02_STD_DATE.Name = "dtp02_STD_DATE";
            this.dtp02_STD_DATE.OriginalFormat = "";
            this.dtp02_STD_DATE.Size = new System.Drawing.Size(106, 21);
            this.dtp02_STD_DATE.TabIndex = 69;
            // 
            // lbl02_BIZNM2
            // 
            this.lbl02_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl02_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl02_BIZNM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_BIZNM2.Location = new System.Drawing.Point(25, 33);
            this.lbl02_BIZNM2.Name = "lbl02_BIZNM2";
            this.lbl02_BIZNM2.Size = new System.Drawing.Size(100, 21);
            this.lbl02_BIZNM2.TabIndex = 68;
            this.lbl02_BIZNM2.Tag = null;
            this.lbl02_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_BIZNM2.Value = "사업장";
            // 
            // cbo02_SAUP
            // 
            this.cbo02_SAUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo02_SAUP.FormattingEnabled = true;
            this.cbo02_SAUP.Location = new System.Drawing.Point(129, 33);
            this.cbo02_SAUP.Name = "cbo02_SAUP";
            this.cbo02_SAUP.Size = new System.Drawing.Size(152, 20);
            this.cbo02_SAUP.TabIndex = 67;
            // 
            // lbl02_STD_DATE
            // 
            this.lbl02_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl02_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl02_STD_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_STD_DATE.Location = new System.Drawing.Point(287, 32);
            this.lbl02_STD_DATE.Name = "lbl02_STD_DATE";
            this.lbl02_STD_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl02_STD_DATE.TabIndex = 48;
            this.lbl02_STD_DATE.Tag = null;
            this.lbl02_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_STD_DATE.Value = "기준일자";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grp01_PD25311);
            this.groupBox1.Controls.Add(this.grp01_PD25221);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 734);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // PD25420
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Name = "PD25420";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grp01_PD25311.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            this.grp01_PD25221.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_STD_DATE)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD25311;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo01_SAUP;
        private DEV.Utility.Controls.AxDateEdit dtp01_STD_DATE;
        private DEV.Utility.Controls.AxDateEdit axDateEdit1;
        private System.Windows.Forms.GroupBox grp01_PD25221;
        private DEV.Utility.Controls.AxDateEdit dtp02_STD_DATE;
        private DEV.Utility.Controls.AxLabel lbl02_BIZNM2;
        private DEV.Utility.Controls.AxComboBox cbo02_SAUP;
        private DEV.Utility.Controls.AxLabel lbl02_STD_DATE;
        private DEV.Utility.Controls.AxButton btn01_PROCESS;
        private DEV.Utility.Controls.AxButton btn02_PROCESS;
        private System.Windows.Forms.GroupBox groupBox1;
        
    }
}
