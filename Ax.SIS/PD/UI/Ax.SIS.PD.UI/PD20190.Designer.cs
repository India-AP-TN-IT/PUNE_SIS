namespace Ax.SIS.PD.UI
{
    partial class PD20190
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
            this.grp01_PD20190 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo01_VINCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_VEHICLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.grp01_PD20190.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEHICLE)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_PD20190
            // 
            this.grp01_PD20190.Controls.Add(this.grd01);
            this.grp01_PD20190.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD20190.Location = new System.Drawing.Point(0, 74);
            this.grp01_PD20190.Name = "grp01_PD20190";
            this.grp01_PD20190.Size = new System.Drawing.Size(1024, 694);
            this.grp01_PD20190.TabIndex = 8;
            this.grp01_PD20190.TabStop = false;
            this.grp01_PD20190.Text = "장기적재 기준일 정보";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 674);
            this.grd01.TabIndex = 8;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_CellChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo01_VINCD);
            this.groupBox1.Controls.Add(this.lbl01_VEHICLE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 40);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cbo01_VINCD
            // 
            this.cbo01_VINCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_VINCD.FormattingEnabled = true;
            this.cbo01_VINCD.Location = new System.Drawing.Point(112, 12);
            this.cbo01_VINCD.Name = "cbo01_VINCD";
            this.cbo01_VINCD.Size = new System.Drawing.Size(121, 20);
            this.cbo01_VINCD.TabIndex = 66;
            // 
            // lbl01_VEHICLE
            // 
            this.lbl01_VEHICLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_VEHICLE.AutoFontSizeMinValue = 9F;
            this.lbl01_VEHICLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VEHICLE.Location = new System.Drawing.Point(6, 12);
            this.lbl01_VEHICLE.Name = "lbl01_VEHICLE";
            this.lbl01_VEHICLE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VEHICLE.TabIndex = 65;
            this.lbl01_VEHICLE.Tag = null;
            this.lbl01_VEHICLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VEHICLE.Value = "차종";
            // 
            // PD20190
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_PD20190);
            this.Controls.Add(this.groupBox1);
            this.Name = "PD20190";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grp01_PD20190, 0);
            this.grp01_PD20190.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VEHICLE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_PD20190;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VEHICLE;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_VINCD;
    }
}
