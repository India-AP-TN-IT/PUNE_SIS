namespace Ax.SIS.PD.UI
{
    partial class PD20034
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grp01_PD20034_GRP1 = new System.Windows.Forms.GroupBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grp01_PD20034_GPR2 = new System.Windows.Forms.GroupBox();
            this.dte01_APPLY_END_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.dte01_APPLY_BEG_DATE = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.lbl01_APPLY_END_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_APPLY_BEG_DATE = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_CUSTCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_CUSTCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_HANIL_VINCD_YN = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cdx02_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_HANIL_VINCD_YN = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl02_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt02_MODELCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl02_MODELCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.txt01_MODELCD = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_MODELCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.lbl01_BIZNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.grp01_PD20034_GRP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.grp01_PD20034_GPR2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_END_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_BEG_DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx02_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_HANIL_VINCD_YN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_MODELCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MODELCD)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MODELCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MODELCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grp01_PD20034_GRP1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.grp01_PD20034_GPR2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 1;
            // 
            // grp01_PD20034_GRP1
            // 
            this.grp01_PD20034_GRP1.Controls.Add(this.grd01);
            this.grp01_PD20034_GRP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp01_PD20034_GRP1.Location = new System.Drawing.Point(0, 55);
            this.grp01_PD20034_GRP1.Name = "grp01_PD20034_GRP1";
            this.grp01_PD20034_GRP1.Size = new System.Drawing.Size(1024, 603);
            this.grp01_PD20034_GRP1.TabIndex = 4;
            this.grp01_PD20034_GRP1.TabStop = false;
            this.grp01_PD20034_GRP1.Text = "고객사 차종 - 당사 차종 목록";
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(3, 17);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1018, 583);
            this.grd01.TabIndex = 0;
            this.grd01.UseCustomHighlight = true;
            this.grd01.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grd01_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 658);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 5);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 5);
            this.panel2.TabIndex = 2;
            // 
            // grp01_PD20034_GPR2
            // 
            this.grp01_PD20034_GPR2.Controls.Add(this.dte01_APPLY_END_DATE);
            this.grp01_PD20034_GPR2.Controls.Add(this.dte01_APPLY_BEG_DATE);
            this.grp01_PD20034_GPR2.Controls.Add(this.lbl01_APPLY_END_DATE);
            this.grp01_PD20034_GPR2.Controls.Add(this.lbl01_APPLY_BEG_DATE);
            this.grp01_PD20034_GPR2.Controls.Add(this.cdx01_CUSTCD);
            this.grp01_PD20034_GPR2.Controls.Add(this.lbl01_CUSTCD);
            this.grp01_PD20034_GPR2.Controls.Add(this.cbo01_HANIL_VINCD_YN);
            this.grp01_PD20034_GPR2.Controls.Add(this.cdx02_VINCD);
            this.grp01_PD20034_GPR2.Controls.Add(this.lbl01_HANIL_VINCD_YN);
            this.grp01_PD20034_GPR2.Controls.Add(this.lbl02_VINCD);
            this.grp01_PD20034_GPR2.Controls.Add(this.txt02_MODELCD);
            this.grp01_PD20034_GPR2.Controls.Add(this.lbl02_MODELCD);
            this.grp01_PD20034_GPR2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp01_PD20034_GPR2.Location = new System.Drawing.Point(0, 663);
            this.grp01_PD20034_GPR2.Name = "grp01_PD20034_GPR2";
            this.grp01_PD20034_GPR2.Size = new System.Drawing.Size(1024, 71);
            this.grp01_PD20034_GPR2.TabIndex = 1;
            this.grp01_PD20034_GPR2.TabStop = false;
            this.grp01_PD20034_GPR2.Text = "고객사 차종 - 당사 차종 연결 정보";
            // 
            // dte01_APPLY_END_DATE
            // 
            this.dte01_APPLY_END_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_APPLY_END_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_APPLY_END_DATE.Location = new System.Drawing.Point(664, 41);
            this.dte01_APPLY_END_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_APPLY_END_DATE.Name = "dte01_APPLY_END_DATE";
            this.dte01_APPLY_END_DATE.OriginalFormat = "";
            this.dte01_APPLY_END_DATE.Size = new System.Drawing.Size(121, 21);
            this.dte01_APPLY_END_DATE.TabIndex = 74;
            // 
            // dte01_APPLY_BEG_DATE
            // 
            this.dte01_APPLY_BEG_DATE.CustomFormat = "yyyy-MM-dd";
            this.dte01_APPLY_BEG_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_APPLY_BEG_DATE.Location = new System.Drawing.Point(354, 41);
            this.dte01_APPLY_BEG_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_APPLY_BEG_DATE.Name = "dte01_APPLY_BEG_DATE";
            this.dte01_APPLY_BEG_DATE.OriginalFormat = "";
            this.dte01_APPLY_BEG_DATE.Size = new System.Drawing.Size(121, 21);
            this.dte01_APPLY_BEG_DATE.TabIndex = 73;
            // 
            // lbl01_APPLY_END_DATE
            // 
            this.lbl01_APPLY_END_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_APPLY_END_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_APPLY_END_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_APPLY_END_DATE.Location = new System.Drawing.Point(558, 42);
            this.lbl01_APPLY_END_DATE.Name = "lbl01_APPLY_END_DATE";
            this.lbl01_APPLY_END_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_APPLY_END_DATE.TabIndex = 72;
            this.lbl01_APPLY_END_DATE.Tag = null;
            this.lbl01_APPLY_END_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_APPLY_END_DATE.Value = "적용종료일";
            // 
            // lbl01_APPLY_BEG_DATE
            // 
            this.lbl01_APPLY_BEG_DATE.AutoFontSizeMaxValue = 9F;
            this.lbl01_APPLY_BEG_DATE.AutoFontSizeMinValue = 9F;
            this.lbl01_APPLY_BEG_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_APPLY_BEG_DATE.Location = new System.Drawing.Point(248, 42);
            this.lbl01_APPLY_BEG_DATE.Name = "lbl01_APPLY_BEG_DATE";
            this.lbl01_APPLY_BEG_DATE.Size = new System.Drawing.Size(100, 21);
            this.lbl01_APPLY_BEG_DATE.TabIndex = 71;
            this.lbl01_APPLY_BEG_DATE.Tag = null;
            this.lbl01_APPLY_BEG_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_APPLY_BEG_DATE.Value = "적용시작일";
            // 
            // cdx01_CUSTCD
            // 
            this.cdx01_CUSTCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_CUSTCD.CodeParameterName = "CODE";
            this.cdx01_CUSTCD.CodeTextBoxReadOnly = false;
            this.cdx01_CUSTCD.CodeTextBoxVisible = true;
            this.cdx01_CUSTCD.CodeTextBoxWidth = 40;
            this.cdx01_CUSTCD.HEPopupHelper = null;
            this.cdx01_CUSTCD.Location = new System.Drawing.Point(664, 18);
            this.cdx01_CUSTCD.Name = "cdx01_CUSTCD";
            this.cdx01_CUSTCD.NameParameterName = "NAME";
            this.cdx01_CUSTCD.NameTextBoxReadOnly = false;
            this.cdx01_CUSTCD.NameTextBoxVisible = true;
            this.cdx01_CUSTCD.PopupButtonReadOnly = false;
            this.cdx01_CUSTCD.PopupTitle = "";
            this.cdx01_CUSTCD.PrefixCode = "";
            this.cdx01_CUSTCD.Size = new System.Drawing.Size(150, 21);
            this.cdx01_CUSTCD.TabIndex = 70;
            this.cdx01_CUSTCD.Tag = null;
            // 
            // lbl01_CUSTCD
            // 
            this.lbl01_CUSTCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CUSTCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CUSTCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CUSTCD.Location = new System.Drawing.Point(558, 17);
            this.lbl01_CUSTCD.Name = "lbl01_CUSTCD";
            this.lbl01_CUSTCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_CUSTCD.TabIndex = 69;
            this.lbl01_CUSTCD.Tag = null;
            this.lbl01_CUSTCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CUSTCD.Value = "고객코드";
            // 
            // cbo01_HANIL_VINCD_YN
            // 
            this.cbo01_HANIL_VINCD_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_HANIL_VINCD_YN.FormattingEnabled = true;
            this.cbo01_HANIL_VINCD_YN.Location = new System.Drawing.Point(111, 42);
            this.cbo01_HANIL_VINCD_YN.Name = "cbo01_HANIL_VINCD_YN";
            this.cbo01_HANIL_VINCD_YN.Size = new System.Drawing.Size(51, 20);
            this.cbo01_HANIL_VINCD_YN.TabIndex = 66;
            // 
            // cdx02_VINCD
            // 
            this.cdx02_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx02_VINCD.CodeParameterName = "CODE";
            this.cdx02_VINCD.CodeTextBoxReadOnly = false;
            this.cdx02_VINCD.CodeTextBoxVisible = true;
            this.cdx02_VINCD.CodeTextBoxWidth = 40;
            this.cdx02_VINCD.HEPopupHelper = null;
            this.cdx02_VINCD.Location = new System.Drawing.Point(352, 17);
            this.cdx02_VINCD.Name = "cdx02_VINCD";
            this.cdx02_VINCD.NameParameterName = "NAME";
            this.cdx02_VINCD.NameTextBoxReadOnly = false;
            this.cdx02_VINCD.NameTextBoxVisible = true;
            this.cdx02_VINCD.PopupButtonReadOnly = false;
            this.cdx02_VINCD.PopupTitle = "";
            this.cdx02_VINCD.PrefixCode = "";
            this.cdx02_VINCD.Size = new System.Drawing.Size(200, 21);
            this.cdx02_VINCD.TabIndex = 65;
            this.cdx02_VINCD.Tag = null;
            // 
            // lbl01_HANIL_VINCD_YN
            // 
            this.lbl01_HANIL_VINCD_YN.AutoFontSizeMaxValue = 9F;
            this.lbl01_HANIL_VINCD_YN.AutoFontSizeMinValue = 9F;
            this.lbl01_HANIL_VINCD_YN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_HANIL_VINCD_YN.Location = new System.Drawing.Point(5, 42);
            this.lbl01_HANIL_VINCD_YN.Name = "lbl01_HANIL_VINCD_YN";
            this.lbl01_HANIL_VINCD_YN.Size = new System.Drawing.Size(100, 21);
            this.lbl01_HANIL_VINCD_YN.TabIndex = 63;
            this.lbl01_HANIL_VINCD_YN.Tag = null;
            this.lbl01_HANIL_VINCD_YN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_HANIL_VINCD_YN.Value = "당사차종유무";
            // 
            // lbl02_VINCD
            // 
            this.lbl02_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl02_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl02_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_VINCD.Location = new System.Drawing.Point(248, 17);
            this.lbl02_VINCD.Name = "lbl02_VINCD";
            this.lbl02_VINCD.Size = new System.Drawing.Size(100, 21);
            this.lbl02_VINCD.TabIndex = 62;
            this.lbl02_VINCD.Tag = null;
            this.lbl02_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_VINCD.Value = "차종";
            // 
            // txt02_MODELCD
            // 
            this.txt02_MODELCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt02_MODELCD.Location = new System.Drawing.Point(112, 17);
            this.txt02_MODELCD.Name = "txt02_MODELCD";
            this.txt02_MODELCD.Size = new System.Drawing.Size(130, 21);
            this.txt02_MODELCD.TabIndex = 60;
            this.txt02_MODELCD.Tag = null;
            // 
            // lbl02_MODELCD
            // 
            this.lbl02_MODELCD.AutoFontSizeMaxValue = 9F;
            this.lbl02_MODELCD.AutoFontSizeMinValue = 9F;
            this.lbl02_MODELCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl02_MODELCD.Location = new System.Drawing.Point(6, 17);
            this.lbl02_MODELCD.Name = "lbl02_MODELCD";
            this.lbl02_MODELCD.Size = new System.Drawing.Size(100, 21);
            this.lbl02_MODELCD.TabIndex = 59;
            this.lbl02_MODELCD.Tag = null;
            this.lbl02_MODELCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl02_MODELCD.Value = "모델코드";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cdx01_VINCD);
            this.groupBox1.Controls.Add(this.txt01_MODELCD);
            this.groupBox1.Controls.Add(this.lbl01_MODELCD);
            this.groupBox1.Controls.Add(this.lbl01_VINCD);
            this.groupBox1.Controls.Add(this.lbl01_BIZNM);
            this.groupBox1.Controls.Add(this.cbo01_BIZCD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(624, 17);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(200, 21);
            this.cdx01_VINCD.TabIndex = 65;
            this.cdx01_VINCD.Tag = null;
            // 
            // txt01_MODELCD
            // 
            this.txt01_MODELCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt01_MODELCD.Location = new System.Drawing.Point(382, 17);
            this.txt01_MODELCD.Name = "txt01_MODELCD";
            this.txt01_MODELCD.Size = new System.Drawing.Size(130, 21);
            this.txt01_MODELCD.TabIndex = 58;
            this.txt01_MODELCD.Tag = null;
            // 
            // lbl01_MODELCD
            // 
            this.lbl01_MODELCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_MODELCD.AutoFontSizeMinValue = 9F;
            this.lbl01_MODELCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_MODELCD.Location = new System.Drawing.Point(276, 17);
            this.lbl01_MODELCD.Name = "lbl01_MODELCD";
            this.lbl01_MODELCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_MODELCD.TabIndex = 57;
            this.lbl01_MODELCD.Tag = null;
            this.lbl01_MODELCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_MODELCD.Value = "모델코드";
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(518, 17);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VINCD.TabIndex = 56;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "차종";
            // 
            // lbl01_BIZNM
            // 
            this.lbl01_BIZNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZNM.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZNM.Location = new System.Drawing.Point(6, 17);
            this.lbl01_BIZNM.Name = "lbl01_BIZNM";
            this.lbl01_BIZNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_BIZNM.TabIndex = 54;
            this.lbl01_BIZNM.Tag = null;
            this.lbl01_BIZNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZNM.Value = "사업장";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(110, 17);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(160, 20);
            this.cbo01_BIZCD.TabIndex = 53;
            // 
            // PD20034
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Name = "PD20034";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.grp01_PD20034_GRP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.grp01_PD20034_GPR2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_END_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_APPLY_BEG_DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx02_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_HANIL_VINCD_YN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt02_MODELCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl02_MODELCD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_MODELCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_MODELCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZNM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grp01_PD20034_GRP1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grp01_PD20034_GPR2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DEV.Utility.Controls.AxLabel lbl01_BIZNM;
        private DEV.Utility.Controls.AxComboBox cbo01_BIZCD;
        private DEV.Utility.Controls.AxTextBox txt01_MODELCD;
        private DEV.Utility.Controls.AxLabel lbl01_MODELCD;
        private DEV.Utility.Controls.AxLabel lbl01_VINCD;
        private DEV.Utility.Controls.AxLabel lbl01_HANIL_VINCD_YN;
        private DEV.Utility.Controls.AxLabel lbl02_VINCD;
        private DEV.Utility.Controls.AxTextBox txt02_MODELCD;
        private DEV.Utility.Controls.AxLabel lbl02_MODELCD;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxCodeBox cdx02_VINCD;
        private DEV.Utility.Controls.AxCodeBox cdx01_VINCD;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DEV.Utility.Controls.AxComboBox cbo01_HANIL_VINCD_YN;
        private DEV.Utility.Controls.AxCodeBox cdx01_CUSTCD;
        private DEV.Utility.Controls.AxLabel lbl01_CUSTCD;
        private DEV.Utility.Controls.AxDateEdit dte01_APPLY_END_DATE;
        private DEV.Utility.Controls.AxDateEdit dte01_APPLY_BEG_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_APPLY_END_DATE;
        private DEV.Utility.Controls.AxLabel lbl01_APPLY_BEG_DATE;
    }
}
