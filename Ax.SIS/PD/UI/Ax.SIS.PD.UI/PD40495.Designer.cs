namespace Ax.SIS.PD.UI
{
    partial class PD40495
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
            this.lbl01_DD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lbl01_VIN_LINE_CODE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_PARTNOTITLE = new Ax.DEV.Utility.Controls.AxLabel();
            this.heTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.heTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.chk01_CURR_INV_STD = new Ax.DEV.Utility.Controls.AxCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN_LINE_CODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl01_DD
            // 
            this.lbl01_DD.AutoFontSizeMaxValue = 9F;
            this.lbl01_DD.AutoFontSizeMinValue = 9F;
            this.lbl01_DD.AutoSize = true;
            this.lbl01_DD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DD.Location = new System.Drawing.Point(18, 44);
            this.lbl01_DD.Name = "lbl01_DD";
            this.lbl01_DD.Size = new System.Drawing.Size(52, 12);
            this.lbl01_DD.TabIndex = 12;
            this.lbl01_DD.Tag = null;
            this.lbl01_DD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DD.Value = "일자";
            // 
            // heDateEdit1
            // 
            this.heDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.heDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.heDateEdit1.Location = new System.Drawing.Point(92, 40);
            this.heDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.heDateEdit1.Name = "heDateEdit1";
            this.heDateEdit1.OriginalFormat = "";
            this.heDateEdit1.Size = new System.Drawing.Size(138, 21);
            this.heDateEdit1.TabIndex = 11;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(18, 111);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(991, 641);
            this.grd01.TabIndex = 13;
            this.grd01.UseCustomHighlight = true;
            // 
            // lbl01_VIN_LINE_CODE
            // 
            this.lbl01_VIN_LINE_CODE.AutoFontSizeMaxValue = 9F;
            this.lbl01_VIN_LINE_CODE.AutoFontSizeMinValue = 9F;
            this.lbl01_VIN_LINE_CODE.AutoSize = true;
            this.lbl01_VIN_LINE_CODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VIN_LINE_CODE.Location = new System.Drawing.Point(18, 82);
            this.lbl01_VIN_LINE_CODE.Name = "lbl01_VIN_LINE_CODE";
            this.lbl01_VIN_LINE_CODE.Size = new System.Drawing.Size(129, 12);
            this.lbl01_VIN_LINE_CODE.TabIndex = 14;
            this.lbl01_VIN_LINE_CODE.Tag = null;
            this.lbl01_VIN_LINE_CODE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VIN_LINE_CODE.Value = "차종/라인코드";
            // 
            // lbl01_PARTNOTITLE
            // 
            this.lbl01_PARTNOTITLE.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNOTITLE.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNOTITLE.AutoSize = true;
            this.lbl01_PARTNOTITLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNOTITLE.Location = new System.Drawing.Point(313, 82);
            this.lbl01_PARTNOTITLE.Name = "lbl01_PARTNOTITLE";
            this.lbl01_PARTNOTITLE.Size = new System.Drawing.Size(120, 12);
            this.lbl01_PARTNOTITLE.TabIndex = 15;
            this.lbl01_PARTNOTITLE.Tag = null;
            this.lbl01_PARTNOTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNOTITLE.Value = "품번";
            // 
            // heTextBox1
            // 
            this.heTextBox1.Location = new System.Drawing.Point(124, 76);
            this.heTextBox1.Name = "heTextBox1";
            this.heTextBox1.Size = new System.Drawing.Size(131, 21);
            this.heTextBox1.TabIndex = 16;
            this.heTextBox1.Tag = null;
            // 
            // heTextBox2
            // 
            this.heTextBox2.Location = new System.Drawing.Point(383, 76);
            this.heTextBox2.Name = "heTextBox2";
            this.heTextBox2.Size = new System.Drawing.Size(131, 21);
            this.heTextBox2.TabIndex = 17;
            this.heTextBox2.Tag = null;
            // 
            // chk01_CURR_INV_STD
            // 
            this.chk01_CURR_INV_STD.AutoSize = true;
            this.chk01_CURR_INV_STD.Checked = true;
            this.chk01_CURR_INV_STD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01_CURR_INV_STD.Location = new System.Drawing.Point(593, 80);
            this.chk01_CURR_INV_STD.Name = "chk01_CURR_INV_STD";
            this.chk01_CURR_INV_STD.Size = new System.Drawing.Size(84, 16);
            this.chk01_CURR_INV_STD.TabIndex = 18;
            this.chk01_CURR_INV_STD.Text = "현재고기준";
            this.chk01_CURR_INV_STD.UseVisualStyleBackColor = true;
            // 
            // PD40495
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.chk01_CURR_INV_STD);
            this.Controls.Add(this.heTextBox2);
            this.Controls.Add(this.heTextBox1);
            this.Controls.Add(this.lbl01_PARTNOTITLE);
            this.Controls.Add(this.lbl01_VIN_LINE_CODE);
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.heDateEdit1);
            this.Controls.Add(this.lbl01_DD);
            this.Name = "PD40495";
            this.Controls.SetChildIndex(this.lbl01_DD, 0);
            this.Controls.SetChildIndex(this.heDateEdit1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.Controls.SetChildIndex(this.lbl01_VIN_LINE_CODE, 0);
            this.Controls.SetChildIndex(this.lbl01_PARTNOTITLE, 0);
            this.Controls.SetChildIndex(this.heTextBox1, 0);
            this.Controls.SetChildIndex(this.heTextBox2, 0);
            this.Controls.SetChildIndex(this.chk01_CURR_INV_STD, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VIN_LINE_CODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNOTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxLabel lbl01_DD;
        private Ax.DEV.Utility.Controls.AxDateEdit heDateEdit1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VIN_LINE_CODE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PARTNOTITLE;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox1;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox2;
        private Ax.DEV.Utility.Controls.AxCheckBox chk01_CURR_INV_STD;

    }
}
