namespace Ax.SIS.PD.UI
{
    partial class PD80040
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
            this.grd01_INSPEC_INFO = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_MAPYN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_AssignYN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PC_IP = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PC_IP = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_CLIENT_ID = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_CLIENT_ID = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grd01_INSPEC_INFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AssignYN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_IP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_IP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CLIENT_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CLIENT_ID)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1028, 34);
            // 
            // grd01_INSPEC_INFO
            // 
            this.grd01_INSPEC_INFO.Controls.Add(this.grd01);
            this.grd01_INSPEC_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01_INSPEC_INFO.Location = new System.Drawing.Point(0, 74);
            this.grd01_INSPEC_INFO.Name = "grd01_INSPEC_INFO";
            this.grd01_INSPEC_INFO.Size = new System.Drawing.Size(1028, 694);
            this.grd01_INSPEC_INFO.TabIndex = 8;
            this.grd01_INSPEC_INFO.TabStop = false;
            this.grd01_INSPEC_INFO.Text = "PC Client ID Management";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AutoGenerateColumns = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.ExtendLastCol = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.grd01.Size = new System.Drawing.Size(1022, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_MAPYN);
            this.groupBox1.Controls.Add(this.lbl01_AssignYN);
            this.groupBox1.Controls.Add(this.lbl01_PC_IP);
            this.groupBox1.Controls.Add(this.txt01_PC_IP);
            this.groupBox1.Controls.Add(this.lbl01_CLIENT_ID);
            this.groupBox1.Controls.Add(this.txt01_CLIENT_ID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_MAPYN
            // 
            this.cbo01_MAPYN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_MAPYN.FormattingEnabled = true;
            this.cbo01_MAPYN.Location = new System.Drawing.Point(617, 13);
            this.cbo01_MAPYN.Name = "cbo01_MAPYN";
            this.cbo01_MAPYN.Size = new System.Drawing.Size(139, 20);
            this.cbo01_MAPYN.TabIndex = 90;
            this.cbo01_MAPYN.SelectedIndexChanged += new System.EventHandler(this.cbo01_MAPYN_SelectedIndexChanged);
            // 
            // lbl01_AssignYN
            // 
            this.lbl01_AssignYN.AutoFontSizeMaxValue = 9F;
            this.lbl01_AssignYN.AutoFontSizeMinValue = 9F;
            this.lbl01_AssignYN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_AssignYN.Location = new System.Drawing.Point(542, 14);
            this.lbl01_AssignYN.Name = "lbl01_AssignYN";
            this.lbl01_AssignYN.Size = new System.Drawing.Size(69, 20);
            this.lbl01_AssignYN.TabIndex = 89;
            this.lbl01_AssignYN.Tag = null;
            this.lbl01_AssignYN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_AssignYN.Value = "AssignYN";
            // 
            // lbl01_PC_IP
            // 
            this.lbl01_PC_IP.AccessibleName = "";
            this.lbl01_PC_IP.AutoFontSizeMaxValue = 9F;
            this.lbl01_PC_IP.AutoFontSizeMinValue = 9F;
            this.lbl01_PC_IP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PC_IP.Location = new System.Drawing.Point(206, 13);
            this.lbl01_PC_IP.Name = "lbl01_PC_IP";
            this.lbl01_PC_IP.Size = new System.Drawing.Size(100, 21);
            this.lbl01_PC_IP.TabIndex = 71;
            this.lbl01_PC_IP.Tag = null;
            this.lbl01_PC_IP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PC_IP.Value = "PC_IP";
            // 
            // txt01_PC_IP
            // 
            this.txt01_PC_IP.AccessibleName = "";
            this.txt01_PC_IP.Location = new System.Drawing.Point(310, 13);
            this.txt01_PC_IP.Name = "txt01_PC_IP";
            this.txt01_PC_IP.Size = new System.Drawing.Size(221, 21);
            this.txt01_PC_IP.TabIndex = 70;
            this.txt01_PC_IP.Tag = null;
            this.txt01_PC_IP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt01_PC_IP_KeyPress);
            // 
            // lbl01_CLIENT_ID
            // 
            this.lbl01_CLIENT_ID.AutoFontSizeMaxValue = 9F;
            this.lbl01_CLIENT_ID.AutoFontSizeMinValue = 9F;
            this.lbl01_CLIENT_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CLIENT_ID.Location = new System.Drawing.Point(6, 13);
            this.lbl01_CLIENT_ID.Name = "lbl01_CLIENT_ID";
            this.lbl01_CLIENT_ID.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CLIENT_ID.TabIndex = 69;
            this.lbl01_CLIENT_ID.Tag = null;
            this.lbl01_CLIENT_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CLIENT_ID.Value = "CLIENT_ID";
            // 
            // txt01_CLIENT_ID
            // 
            this.txt01_CLIENT_ID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt01_CLIENT_ID.Location = new System.Drawing.Point(110, 13);
            this.txt01_CLIENT_ID.Name = "txt01_CLIENT_ID";
            this.txt01_CLIENT_ID.Size = new System.Drawing.Size(78, 21);
            this.txt01_CLIENT_ID.TabIndex = 68;
            this.txt01_CLIENT_ID.Tag = null;
            // 
            // PD80040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01_INSPEC_INFO);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD80040";
            this.Size = new System.Drawing.Size(1028, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grd01_INSPEC_INFO, 0);
            this.grd01_INSPEC_INFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_AssignYN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PC_IP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PC_IP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CLIENT_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_CLIENT_ID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grd01_INSPEC_INFO;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_CLIENT_ID;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_CLIENT_ID;
        private DEV.Utility.Controls.AxLabel lbl01_PC_IP;
        private DEV.Utility.Controls.AxTextBox txt01_PC_IP;
        private DEV.Utility.Controls.AxComboBox cbo01_MAPYN;
        private DEV.Utility.Controls.AxLabel lbl01_AssignYN;        
    }
}
