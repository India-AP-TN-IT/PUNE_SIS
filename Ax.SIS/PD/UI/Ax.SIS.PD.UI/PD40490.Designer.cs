namespace Ax.SIS.PD.UI
{
    partial class PD40490
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
            this.lbl01_PLAN_STOP_NOTE = new System.Windows.Forms.Label();
            this.lbl01_PLAN_STOP_MIN = new Ax.DEV.Utility.Controls.AxLabel();
            this.heTextBox3 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.heTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.heTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_OPR_END = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_OPR_BEG = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_DD = new Ax.DEV.Utility.Controls.AxLabel();
            this.heDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.grp01_DETAILS = new System.Windows.Forms.GroupBox();
            this.grd02 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.grp01_SUMMARY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLAN_STOP_MIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OPR_END)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OPR_BEG)).BeginInit();
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
            this.grp01_SUMMARY.Size = new System.Drawing.Size(714, 671);
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
            this.grd01.Size = new System.Drawing.Size(699, 636);
            this.grd01.TabIndex = 10;
            this.grd01.UseCustomHighlight = true;
            this.grd01.DoubleClick += new System.EventHandler(this.grd01_DoubleClick);
            // 
            // lbl01_PLAN_STOP_NOTE
            // 
            this.lbl01_PLAN_STOP_NOTE.AutoSize = true;
            this.lbl01_PLAN_STOP_NOTE.Location = new System.Drawing.Point(872, 44);
            this.lbl01_PLAN_STOP_NOTE.Name = "lbl01_PLAN_STOP_NOTE";
            this.lbl01_PLAN_STOP_NOTE.Size = new System.Drawing.Size(59, 12);
            this.lbl01_PLAN_STOP_NOTE.TabIndex = 21;
            this.lbl01_PLAN_STOP_NOTE.Text = "휴식+식사";
            // 
            // lbl01_PLAN_STOP_MIN
            // 
            this.lbl01_PLAN_STOP_MIN.AutoFontSizeMaxValue = 9F;
            this.lbl01_PLAN_STOP_MIN.AutoFontSizeMinValue = 9F;
            this.lbl01_PLAN_STOP_MIN.AutoSize = true;
            this.lbl01_PLAN_STOP_MIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PLAN_STOP_MIN.Location = new System.Drawing.Point(649, 44);
            this.lbl01_PLAN_STOP_MIN.Name = "lbl01_PLAN_STOP_MIN";
            this.lbl01_PLAN_STOP_MIN.Size = new System.Drawing.Size(136, 12);
            this.lbl01_PLAN_STOP_MIN.TabIndex = 18;
            this.lbl01_PLAN_STOP_MIN.Tag = null;
            this.lbl01_PLAN_STOP_MIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PLAN_STOP_MIN.Value = "계획정지(분)";
            // 
            // heTextBox3
            // 
            this.heTextBox3.Location = new System.Drawing.Point(767, 41);
            this.heTextBox3.Name = "heTextBox3";
            this.heTextBox3.Size = new System.Drawing.Size(100, 21);
            this.heTextBox3.TabIndex = 17;
            this.heTextBox3.Tag = null;
            this.heTextBox3.Value = "60";
            // 
            // heTextBox2
            // 
            this.heTextBox2.Location = new System.Drawing.Point(520, 41);
            this.heTextBox2.Name = "heTextBox2";
            this.heTextBox2.Size = new System.Drawing.Size(100, 21);
            this.heTextBox2.TabIndex = 16;
            this.heTextBox2.Tag = null;
            this.heTextBox2.Value = "164000";
            // 
            // heTextBox1
            // 
            this.heTextBox1.Location = new System.Drawing.Point(322, 40);
            this.heTextBox1.Name = "heTextBox1";
            this.heTextBox1.Size = new System.Drawing.Size(100, 21);
            this.heTextBox1.TabIndex = 15;
            this.heTextBox1.Tag = null;
            this.heTextBox1.Value = "075000";
            // 
            // lbl01_OPR_END
            // 
            this.lbl01_OPR_END.AutoFontSizeMaxValue = 9F;
            this.lbl01_OPR_END.AutoFontSizeMinValue = 9F;
            this.lbl01_OPR_END.AutoSize = true;
            this.lbl01_OPR_END.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_OPR_END.Location = new System.Drawing.Point(446, 46);
            this.lbl01_OPR_END.Name = "lbl01_OPR_END";
            this.lbl01_OPR_END.Size = new System.Drawing.Size(92, 12);
            this.lbl01_OPR_END.TabIndex = 14;
            this.lbl01_OPR_END.Tag = null;
            this.lbl01_OPR_END.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_OPR_END.Value = "조업종료";
            // 
            // lbl01_OPR_BEG
            // 
            this.lbl01_OPR_BEG.AutoFontSizeMaxValue = 9F;
            this.lbl01_OPR_BEG.AutoFontSizeMinValue = 9F;
            this.lbl01_OPR_BEG.AutoSize = true;
            this.lbl01_OPR_BEG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_OPR_BEG.Location = new System.Drawing.Point(248, 43);
            this.lbl01_OPR_BEG.Name = "lbl01_OPR_BEG";
            this.lbl01_OPR_BEG.Size = new System.Drawing.Size(92, 12);
            this.lbl01_OPR_BEG.TabIndex = 13;
            this.lbl01_OPR_BEG.Tag = null;
            this.lbl01_OPR_BEG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_OPR_BEG.Value = "조업시작";
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
            this.grp01_DETAILS.Location = new System.Drawing.Point(734, 73);
            this.grp01_DETAILS.Name = "grp01_DETAILS";
            this.grp01_DETAILS.Size = new System.Drawing.Size(282, 671);
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
            this.grd02.Size = new System.Drawing.Size(267, 636);
            this.grd02.TabIndex = 10;
            this.grd02.UseCustomHighlight = true;
            // 
            // PD40490
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp01_DETAILS);
            this.Controls.Add(this.lbl01_PLAN_STOP_NOTE);
            this.Controls.Add(this.grp01_SUMMARY);
            this.Controls.Add(this.lbl01_PLAN_STOP_MIN);
            this.Controls.Add(this.heTextBox3);
            this.Controls.Add(this.heDateEdit1);
            this.Controls.Add(this.heTextBox2);
            this.Controls.Add(this.lbl01_OPR_END);
            this.Controls.Add(this.lbl01_DD);
            this.Controls.Add(this.heTextBox1);
            this.Controls.Add(this.lbl01_OPR_BEG);
            this.Name = "PD40490";
            this.Controls.SetChildIndex(this.lbl01_OPR_BEG, 0);
            this.Controls.SetChildIndex(this.heTextBox1, 0);
            this.Controls.SetChildIndex(this.lbl01_DD, 0);
            this.Controls.SetChildIndex(this.lbl01_OPR_END, 0);
            this.Controls.SetChildIndex(this.heTextBox2, 0);
            this.Controls.SetChildIndex(this.heDateEdit1, 0);
            this.Controls.SetChildIndex(this.heTextBox3, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.lbl01_PLAN_STOP_MIN, 0);
            this.Controls.SetChildIndex(this.grp01_SUMMARY, 0);
            this.Controls.SetChildIndex(this.lbl01_PLAN_STOP_NOTE, 0);
            this.Controls.SetChildIndex(this.grp01_DETAILS, 0);
            this.grp01_SUMMARY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PLAN_STOP_MIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OPR_END)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_OPR_BEG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DD)).EndInit();
            this.grp01_DETAILS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp01_SUMMARY;
        private System.Windows.Forms.Label lbl01_PLAN_STOP_NOTE;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_PLAN_STOP_MIN;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox3;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox2;
        private Ax.DEV.Utility.Controls.AxTextBox heTextBox1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OPR_END;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_OPR_BEG;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DD;
        private Ax.DEV.Utility.Controls.AxDateEdit heDateEdit1;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox grp01_DETAILS;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd02;

    }
}
