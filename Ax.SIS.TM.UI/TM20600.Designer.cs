namespace Ax.SIS.TM.UI
{
    partial class TM20600
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TM20600));
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.cdx01_DOCCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_CORCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.lbl01_CORCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx_GRPCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx_LOCCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_DOCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx_GRPCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx_LOCCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
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
            this.grd01.Location = new System.Drawing.Point(6, 123);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1015, 642);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 128;
            this.grd01.UseCustomHighlight = true;
            this.grd01.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grd01_AfterEdit);
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // cdx01_DOCCD
            // 
            this.cdx01_DOCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_DOCCD.CodeParameterName = "CODE";
            this.cdx01_DOCCD.CodeTextBoxReadOnly = false;
            this.cdx01_DOCCD.CodeTextBoxVisible = true;
            this.cdx01_DOCCD.CodeTextBoxWidth = 60;
            this.cdx01_DOCCD.HEPopupHelper = null;
            this.cdx01_DOCCD.Location = new System.Drawing.Point(172, 96);
            this.cdx01_DOCCD.Name = "cdx01_DOCCD";
            this.cdx01_DOCCD.NameParameterName = "NAME";
            this.cdx01_DOCCD.NameTextBoxReadOnly = false;
            this.cdx01_DOCCD.NameTextBoxVisible = true;
            this.cdx01_DOCCD.PopupButtonReadOnly = false;
            this.cdx01_DOCCD.PopupTitle = "";
            this.cdx01_DOCCD.PrefixCode = "";
            this.cdx01_DOCCD.Size = new System.Drawing.Size(278, 21);
            this.cdx01_DOCCD.TabIndex = 156;
            this.cdx01_DOCCD.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(6, 95);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(160, 21);
            this.axLabel2.TabIndex = 155;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Document";
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
            // cdx_GRPCD
            // 
            this.cdx_GRPCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx_GRPCD.CodeParameterName = "CODE";
            this.cdx_GRPCD.CodeTextBoxReadOnly = false;
            this.cdx_GRPCD.CodeTextBoxVisible = true;
            this.cdx_GRPCD.CodeTextBoxWidth = 60;
            this.cdx_GRPCD.HEPopupHelper = null;
            this.cdx_GRPCD.Location = new System.Drawing.Point(635, 96);
            this.cdx_GRPCD.Name = "cdx_GRPCD";
            this.cdx_GRPCD.NameParameterName = "NAME";
            this.cdx_GRPCD.NameTextBoxReadOnly = false;
            this.cdx_GRPCD.NameTextBoxVisible = true;
            this.cdx_GRPCD.PopupButtonReadOnly = false;
            this.cdx_GRPCD.PopupTitle = "";
            this.cdx_GRPCD.PrefixCode = "";
            this.cdx_GRPCD.Size = new System.Drawing.Size(278, 21);
            this.cdx_GRPCD.TabIndex = 162;
            this.cdx_GRPCD.Tag = null;
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(469, 95);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(160, 21);
            this.axLabel3.TabIndex = 161;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "Group";
            // 
            // cdx_LOCCD
            // 
            this.cdx_LOCCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx_LOCCD.CodeParameterName = "CODE";
            this.cdx_LOCCD.CodeTextBoxReadOnly = false;
            this.cdx_LOCCD.CodeTextBoxVisible = true;
            this.cdx_LOCCD.CodeTextBoxWidth = 60;
            this.cdx_LOCCD.HEPopupHelper = null;
            this.cdx_LOCCD.Location = new System.Drawing.Point(172, 69);
            this.cdx_LOCCD.Name = "cdx_LOCCD";
            this.cdx_LOCCD.NameParameterName = "NAME";
            this.cdx_LOCCD.NameTextBoxReadOnly = false;
            this.cdx_LOCCD.NameTextBoxVisible = true;
            this.cdx_LOCCD.PopupButtonReadOnly = false;
            this.cdx_LOCCD.PopupTitle = "";
            this.cdx_LOCCD.PrefixCode = "";
            this.cdx_LOCCD.Size = new System.Drawing.Size(278, 21);
            this.cdx_LOCCD.TabIndex = 164;
            this.cdx_LOCCD.Tag = null;
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
            this.axLabel4.Value = "Location";
            // 
            // TM20600
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cdx_LOCCD);
            this.Controls.Add(this.axLabel4);
            this.Controls.Add(this.cdx_GRPCD);
            this.Controls.Add(this.axLabel3);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Controls.Add(this.cbo01_CORCD);
            this.Controls.Add(this.lbl01_CORCD);
            this.Controls.Add(this.cdx01_DOCCD);
            this.Controls.Add(this.axLabel2);
            this.Controls.Add(this.grd01);
            this.Name = "TM20600";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.cdx01_DOCCD, 0);
            this.Controls.SetChildIndex(this.lbl01_CORCD, 0);
            this.Controls.SetChildIndex(this.cbo01_CORCD, 0);
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.axLabel3, 0);
            this.Controls.SetChildIndex(this.cdx_GRPCD, 0);
            this.Controls.SetChildIndex(this.axLabel4, 0);
            this.Controls.SetChildIndex(this.cdx_LOCCD, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_DOCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CORCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx_GRPCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx_LOCCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxCodeBox cdx01_DOCCD;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxLabel lbl01_BIZCD;
        private DEV.Utility.Controls.AxComboBox cbo01_CORCD;
        private DEV.Utility.Controls.AxLabel lbl01_CORCD;
        private DEV.Utility.Controls.AxCodeBox cdx_GRPCD;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxCodeBox cdx_LOCCD;
        private DEV.Utility.Controls.AxLabel axLabel4;


    }
}
