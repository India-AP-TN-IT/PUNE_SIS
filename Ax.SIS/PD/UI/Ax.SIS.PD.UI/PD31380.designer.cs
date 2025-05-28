namespace Ax.SIS.PD.UI
{
    partial class PD31380
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD31380));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp01_PLAN_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_STD_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtp01_PLAN_DATE);
            this.panel1.Controls.Add(this.lbl01_STD_DATE);
            this.panel1.Controls.Add(this.cbo01_BIZCD);
            this.panel1.Controls.Add(this.lbl01_BIZNM2);
            this.panel1.Location = new System.Drawing.Point(3, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 45);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(839, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // dtp01_PLAN_DATE
            // 
            this.dtp01_PLAN_DATE.CustomFormat = "yyyy-MM-dd";
            this.dtp01_PLAN_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp01_PLAN_DATE.Location = new System.Drawing.Point(614, 8);
            this.dtp01_PLAN_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp01_PLAN_DATE.Name = "dtp01_PLAN_DATE";
            this.dtp01_PLAN_DATE.OriginalFormat = "";
            this.dtp01_PLAN_DATE.Size = new System.Drawing.Size(199, 21);
            this.dtp01_PLAN_DATE.TabIndex = 5;
            // 
            // lbl01_STD_DATE
            // 
            this.lbl01_STD_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_STD_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_STD_DATE.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_STD_DATE.Location = new System.Drawing.Point(483, 8);
            this.lbl01_STD_DATE.Name = "lbl01_STD_DATE";
            this.lbl01_STD_DATE.Size = new System.Drawing.Size(125, 23);
            this.lbl01_STD_DATE.TabIndex = 4;
            this.lbl01_STD_DATE.Tag = null;
            this.lbl01_STD_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_STD_DATE.Value = "Work Date";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(116, 10);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(199, 23);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM2
            // 
            this.lbl01_BIZNM2.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM2.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM2.BackColor = System.Drawing.Color.Transparent;
            this.lbl01_BIZNM2.Location = new System.Drawing.Point(13, 15);
            this.lbl01_BIZNM2.Name = "lbl01_BIZNM2";
            this.lbl01_BIZNM2.Size = new System.Drawing.Size(97, 16);
            this.lbl01_BIZNM2.TabIndex = 0;
            this.lbl01_BIZNM2.Tag = null;
            this.lbl01_BIZNM2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl01_BIZNM2.Value = "Business";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 91);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.Count = 13;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 674);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 14;
            this.grd01.UseCustomHighlight = true;
            // 
            // PD31380
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.panel1);
            this.Name = "PD31380";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_STD_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DEV.Utility.Controls.AxDateEdit dtp01_PLAN_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_STD_DATE;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM2;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.Label label1;
    }
}
