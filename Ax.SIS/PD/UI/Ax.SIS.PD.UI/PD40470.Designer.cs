namespace Ax.SIS.PD.UI
{
    partial class PD40470
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
            this.grp01_SUMMARY = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.lbl01_DD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.grp01_DETAILS = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_SUMMARY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DD)).BeginInit();
            this.grp01_DETAILS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).BeginInit();
            this.SuspendLayout();
            // 
            // grp01_SUMMARY
            // 
            this.grp01_SUMMARY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp01_SUMMARY.Controls.Add(this.grd01);
            this.grp01_SUMMARY.Location = new System.Drawing.Point(14, 73);
            this.grp01_SUMMARY.Name = "grp01_SUMMARY";
            this.grp01_SUMMARY.Size = new System.Drawing.Size(513, 671);
            this.grp01_SUMMARY.TabIndex = 12;
            this.grp01_SUMMARY.TabStop = false;
            this.grp01_SUMMARY.Text = "집계";
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
            this.grd01.Location = new System.Drawing.Point(9, 20);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(489, 636);
            this.grd01.TabIndex = 10;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
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
            // grp01_DETAILS
            // 
            this.grp01_DETAILS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp01_DETAILS.Controls.Add(this.grd02);
            this.grp01_DETAILS.Location = new System.Drawing.Point(533, 73);
            this.grp01_DETAILS.Name = "grp01_DETAILS";
            this.grp01_DETAILS.Size = new System.Drawing.Size(483, 671);
            this.grp01_DETAILS.TabIndex = 22;
            this.grp01_DETAILS.TabStop = false;
            this.grp01_DETAILS.Text = "상세";
            // 
            // grd02
            // 
            this.grd02.AllowHeaderMerging = false;
            this.grd02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd02.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd02.EnabledActionFlag = true;
            this.grd02.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd02.LastRowAdd = false;
            this.grd02.Location = new System.Drawing.Point(9, 20);
            this.grd02.Name = "grd02";
            this.grd02.OriginalFormat = null;
            this.grd02.PopMenuVisible = true;
            this.grd02.Rows.DefaultSize = 18;
            this.grd02.Size = new System.Drawing.Size(468, 636);
            this.grd02.TabIndex = 10;
            this.grd02.UseCustomHighlight = true;
            // 
            // PD40470
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_DETAILS);
            this.Controls.Add(this.grp01_SUMMARY);
            this.Controls.Add(this.heDateEdit1);
            this.Controls.Add(this.lbl01_DD);
            this.Name = "PD40470";
            this.Controls.SetChildIndex(this.lbl01_DD, 0);
            this.Controls.SetChildIndex(this.heDateEdit1, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grp01_SUMMARY, 0);
            this.Controls.SetChildIndex(this.grp01_DETAILS, 0);
            this.grp01_SUMMARY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DD)).EndInit();
            this.grp01_DETAILS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_SUMMARY;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DD;
        private Ax.DEV.Utility.Controls.AxDateEdit heDateEdit1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox grp01_DETAILS;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;

    }
}
