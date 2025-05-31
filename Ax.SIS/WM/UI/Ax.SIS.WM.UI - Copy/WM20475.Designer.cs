namespace Ax.SIS.WM.UI
{
    partial class WM20475
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
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.txt01_BARCODE_NOTE = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_DELIVERY_NOTE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.gbxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_BARCODE_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELIVERY_NOTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.txt01_BARCODE_NOTE);
            this.gbxSearch.Controls.Add(this.lbl01_DELIVERY_NOTE);
            this.gbxSearch.Controls.Add(this.cbo01_BIZCD);
            this.gbxSearch.Controls.Add(this.lbl01_BIZNM);
            this.gbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSearch.Location = new System.Drawing.Point(0, 34);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(1024, 47);
            this.gbxSearch.TabIndex = 0;
            this.gbxSearch.TabStop = false;
            // 
            // txt01_BARCODE_NOTE
            // 
            this.txt01_BARCODE_NOTE.Location = new System.Drawing.Point(521, 17);
            this.txt01_BARCODE_NOTE.Name = "txt01_BARCODE_NOTE";
            this.txt01_BARCODE_NOTE.Size = new System.Drawing.Size(261, 21);
            this.txt01_BARCODE_NOTE.TabIndex = 52;
            this.txt01_BARCODE_NOTE.Tag = null;
            // 
            // lbl01_DELIVERY_NOTE
            // 
            this.lbl01_DELIVERY_NOTE.AutoFontSizeMaxValue = 9F;
            this.lbl01_DELIVERY_NOTE.AutoFontSizeMinValue = 9F;
            this.lbl01_DELIVERY_NOTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_DELIVERY_NOTE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_DELIVERY_NOTE.Location = new System.Drawing.Point(375, 16);
            this.lbl01_DELIVERY_NOTE.Name = "lbl01_DELIVERY_NOTE";
            this.lbl01_DELIVERY_NOTE.Size = new System.Drawing.Size(140, 21);
            this.lbl01_DELIVERY_NOTE.TabIndex = 0;
            this.lbl01_DELIVERY_NOTE.Tag = null;
            this.lbl01_DELIVERY_NOTE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_DELIVERY_NOTE.Value = "Note No";
            this.lbl01_DELIVERY_NOTE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(152, 18);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(166, 20);
            this.cbo01_BIZCD.TabIndex = 1;
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl01_BIZNM.Location = new System.Drawing.Point(6, 17);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(140, 21);
            this.lbl01_BIZNM.TabIndex = 0;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "Plant";
            this.lbl01_BIZNM.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 81);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1024, 687);
            this.grd01.TabIndex = 2;
            this.grd01.UseCustomHighlight = true;
            // 
            // WM20475
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.gbxSearch);
            this.Name = "WM20475";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.gbxSearch, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.gbxSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt01_BARCODE_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_DELIVERY_NOTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ax.DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private System.Windows.Forms.GroupBox gbxSearch;
        private Ax.DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_DELIVERY_NOTE;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_BARCODE_NOTE;
    }
}
