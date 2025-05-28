namespace Ax.SIS.TM.UI
{
    partial class TM20400
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
            this.Txt_PhoneNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_PWD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel6 = new Ax.DEV.Utility.Controls.AxLabel();
            this.Txt_ID = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel5 = new Ax.DEV.Utility.Controls.AxLabel();
            this.Txt_Wh_Addr = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.Txt_KeyID = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Txt_Web_Addr = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel7 = new Ax.DEV.Utility.Controls.AxLabel();
            this.Txt_Web_Addr2 = new Ax.DEV.Utility.Controls.AxTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PhoneNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Wh_Addr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_KeyID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Web_Addr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Web_Addr2)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1024, 32);
            // 
            // Txt_PhoneNO
            // 
            this.Txt_PhoneNO.Location = new System.Drawing.Point(201, 92);
            this.Txt_PhoneNO.Name = "Txt_PhoneNO";
            this.Txt_PhoneNO.Size = new System.Drawing.Size(285, 21);
            this.Txt_PhoneNO.TabIndex = 116;
            this.Txt_PhoneNO.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(20, 91);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(175, 21);
            this.axLabel1.TabIndex = 115;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Phone Num";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Txt_PWD);
            this.groupBox1.Controls.Add(this.axLabel6);
            this.groupBox1.Controls.Add(this.Txt_ID);
            this.groupBox1.Controls.Add(this.axLabel5);
            this.groupBox1.Controls.Add(this.Txt_Wh_Addr);
            this.groupBox1.Controls.Add(this.axLabel4);
            this.groupBox1.Controls.Add(this.Txt_KeyID);
            this.groupBox1.Controls.Add(this.axLabel3);
            this.groupBox1.Controls.Add(this.Txt_PhoneNO);
            this.groupBox1.Controls.Add(this.axLabel1);
            this.groupBox1.Location = new System.Drawing.Point(17, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(990, 358);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Whatsapp Information";
            // 
            // Txt_PWD
            // 
            this.Txt_PWD.Location = new System.Drawing.Point(201, 206);
            this.Txt_PWD.Name = "Txt_PWD";
            this.Txt_PWD.PasswordChar = '*';
            this.Txt_PWD.Size = new System.Drawing.Size(285, 21);
            this.Txt_PWD.TabIndex = 124;
            this.Txt_PWD.Tag = null;
            // 
            // axLabel6
            // 
            this.axLabel6.AutoFontSizeMaxValue = 9F;
            this.axLabel6.AutoFontSizeMinValue = 9F;
            this.axLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel6.Location = new System.Drawing.Point(20, 205);
            this.axLabel6.Name = "axLabel6";
            this.axLabel6.Size = new System.Drawing.Size(175, 21);
            this.axLabel6.TabIndex = 123;
            this.axLabel6.Tag = null;
            this.axLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel6.Value = "PWD";
            // 
            // Txt_ID
            // 
            this.Txt_ID.Location = new System.Drawing.Point(201, 165);
            this.Txt_ID.Name = "Txt_ID";
            this.Txt_ID.Size = new System.Drawing.Size(285, 21);
            this.Txt_ID.TabIndex = 122;
            this.Txt_ID.Tag = null;
            // 
            // axLabel5
            // 
            this.axLabel5.AutoFontSizeMaxValue = 9F;
            this.axLabel5.AutoFontSizeMinValue = 9F;
            this.axLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel5.Location = new System.Drawing.Point(20, 164);
            this.axLabel5.Name = "axLabel5";
            this.axLabel5.Size = new System.Drawing.Size(175, 21);
            this.axLabel5.TabIndex = 121;
            this.axLabel5.Tag = null;
            this.axLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel5.Value = "ID";
            // 
            // Txt_Wh_Addr
            // 
            this.Txt_Wh_Addr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Wh_Addr.Location = new System.Drawing.Point(201, 52);
            this.Txt_Wh_Addr.Name = "Txt_Wh_Addr";
            this.Txt_Wh_Addr.Size = new System.Drawing.Size(783, 21);
            this.Txt_Wh_Addr.TabIndex = 120;
            this.Txt_Wh_Addr.Tag = null;
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel4.Location = new System.Drawing.Point(20, 51);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(175, 21);
            this.axLabel4.TabIndex = 119;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Service URL";
            // 
            // Txt_KeyID
            // 
            this.Txt_KeyID.Location = new System.Drawing.Point(201, 128);
            this.Txt_KeyID.Name = "Txt_KeyID";
            this.Txt_KeyID.Size = new System.Drawing.Size(285, 21);
            this.Txt_KeyID.TabIndex = 118;
            this.Txt_KeyID.Tag = null;
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(20, 127);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(175, 21);
            this.axLabel3.TabIndex = 117;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "KEY ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Txt_Web_Addr2);
            this.groupBox2.Controls.Add(this.axLabel7);
            this.groupBox2.Controls.Add(this.Txt_Web_Addr);
            this.groupBox2.Controls.Add(this.axLabel2);
            this.groupBox2.Location = new System.Drawing.Point(17, 454);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(990, 307);
            this.groupBox2.TabIndex = 118;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Web Information";
            // 
            // Txt_Web_Addr
            // 
            this.Txt_Web_Addr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Web_Addr.Location = new System.Drawing.Point(201, 36);
            this.Txt_Web_Addr.Name = "Txt_Web_Addr";
            this.Txt_Web_Addr.Size = new System.Drawing.Size(783, 21);
            this.Txt_Web_Addr.TabIndex = 116;
            this.Txt_Web_Addr.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(20, 35);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(175, 21);
            this.axLabel2.TabIndex = 115;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Mobile Web Address(Login)";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(464, 61);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_BIZCD.TabIndex = 120;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(324, 61);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(134, 20);
            this.lbl01_BIZCD.TabIndex = 119;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(160, 61);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_CORCD.TabIndex = 118;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(20, 61);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(134, 21);
            this.lbl01_CORCD.TabIndex = 117;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "Corporation";
            // 
            // axLabel7
            // 
            this.axLabel7.AutoFontSizeMaxValue = 9F;
            this.axLabel7.AutoFontSizeMinValue = 9F;
            this.axLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel7.Location = new System.Drawing.Point(20, 77);
            this.axLabel7.Name = "axLabel7";
            this.axLabel7.Size = new System.Drawing.Size(175, 21);
            this.axLabel7.TabIndex = 117;
            this.axLabel7.Tag = null;
            this.axLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel7.Value = "Mobile Web Address(Asset)";
            // 
            // Txt_Web_Addr2
            // 
            this.Txt_Web_Addr2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Web_Addr2.Location = new System.Drawing.Point(201, 77);
            this.Txt_Web_Addr2.Name = "Txt_Web_Addr2";
            this.Txt_Web_Addr2.Size = new System.Drawing.Size(783, 21);
            this.Txt_Web_Addr2.TabIndex = 118;
            this.Txt_Web_Addr2.Tag = null;
            // 
            // TM20400
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbo01_CORCD);
            this.Controls.Add(this.lbl01_CORCD);
            this.Name = "TM20400";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.lbl01_CORCD, 0);
            this.Controls.SetChildIndex(this.cbo01_CORCD, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PhoneNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Wh_Addr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_KeyID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Web_Addr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Web_Addr2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxTextBox Txt_PhoneNO;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DEV.Utility.Controls.AxTextBox Txt_Web_Addr;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private DEV.Utility.Controls.AxTextBox Txt_Wh_Addr;
        private DEV.Utility.Controls.AxLabel axLabel4;
        private DEV.Utility.Controls.AxTextBox Txt_KeyID;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxTextBox Txt_PWD;
        private DEV.Utility.Controls.AxLabel axLabel6;
        private DEV.Utility.Controls.AxTextBox Txt_ID;
        private DEV.Utility.Controls.AxLabel axLabel5;
        private DEV.Utility.Controls.AxTextBox Txt_Web_Addr2;
        private DEV.Utility.Controls.AxLabel axLabel7;

    }
}
