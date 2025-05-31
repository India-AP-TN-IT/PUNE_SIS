namespace Ax.SIS.TM.UI
{
    partial class TM20800
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM20800));
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt_GRP = new Ax.DEV.Utility.Controls.AxTextBox();
            this.txt_PID = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt_Loc = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GRP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Loc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 96);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 669);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 128;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(449, 40);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_BIZCD.TabIndex = 160;
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(309, 40);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(134, 20);
            this.lbl01_BIZCD.TabIndex = 159;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Business";
            // 
            // cbo01_CORCD
            // 
            this.cbo01_CORCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_CORCD.FormattingEnabled = true;
            this.cbo01_CORCD.Location = new System.Drawing.Point(145, 40);
            this.cbo01_CORCD.Name = "cbo01_CORCD";
            this.cbo01_CORCD.Size = new System.Drawing.Size(158, 23);
            this.cbo01_CORCD.TabIndex = 158;
            // 
            // lbl01_CORCD
            // 
            this.lbl01_CORCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CORCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CORCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CORCD.Location = new System.Drawing.Point(5, 40);
            this.lbl01_CORCD.Name = "lbl01_CORCD";
            this.lbl01_CORCD.Size = new System.Drawing.Size(134, 21);
            this.lbl01_CORCD.TabIndex = 157;
            this.lbl01_CORCD.Tag = null;
            this.lbl01_CORCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CORCD.Value = "Corporation";
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel4.Location = new System.Drawing.Point(6, 68);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(160, 21);
            this.axLabel4.TabIndex = 163;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Pager/Group";
            // 
            // txt_GRP
            // 
            this.txt_GRP.Location = new System.Drawing.Point(172, 69);
            this.txt_GRP.Name = "txt_GRP";
            this.txt_GRP.Size = new System.Drawing.Size(109, 21);
            this.txt_GRP.TabIndex = 164;
            this.txt_GRP.Tag = null;
            // 
            // txt_PID
            // 
            this.txt_PID.Location = new System.Drawing.Point(461, 69);
            this.txt_PID.Name = "txt_PID";
            this.txt_PID.Size = new System.Drawing.Size(109, 21);
            this.txt_PID.TabIndex = 166;
            this.txt_PID.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(295, 68);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(160, 21);
            this.axLabel1.TabIndex = 165;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Pager/ID";
            // 
            // txt_Loc
            // 
            this.txt_Loc.Location = new System.Drawing.Point(749, 69);
            this.txt_Loc.Name = "txt_Loc";
            this.txt_Loc.Size = new System.Drawing.Size(248, 21);
            this.txt_Loc.TabIndex = 168;
            this.txt_Loc.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(583, 68);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(160, 21);
            this.axLabel2.TabIndex = 167;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Location";
            // 
            // TM20800
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txt_Loc);
            this.Controls.Add(this.axLabel2);
            this.Controls.Add(this.txt_PID);
            this.Controls.Add(this.axLabel1);
            this.Controls.Add(this.txt_GRP);
            this.Controls.Add(this.axLabel4);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.cbo01_CORCD);
            this.Controls.Add(this.lbl01_CORCD);
            this.Controls.Add(this.grd01);
            this.Name = "TM20800";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.Controls.SetChildIndex(this.lbl01_CORCD, 0);
            this.Controls.SetChildIndex(this.cbo01_CORCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.axLabel4, 0);
            this.Controls.SetChildIndex(this.txt_GRP, 0);
            this.Controls.SetChildIndex(this.axLabel1, 0);
            this.Controls.SetChildIndex(this.txt_PID, 0);
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.txt_Loc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GRP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Loc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private DEV.Utility.Controls.AxLabel axLabel4;
        private DEV.Utility.Controls.AxTextBox txt_GRP;
        private DEV.Utility.Controls.AxTextBox txt_PID;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxTextBox txt_Loc;
        private DEV.Utility.Controls.AxLabel axLabel2;


    }
}
