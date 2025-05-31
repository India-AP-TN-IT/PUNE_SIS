namespace Ax.SIS.SD.UI
{
    partial class ZSD02500_EtcDelDLG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZSD02500_EtcDelDLG));
            this.panel1 = new System.Windows.Forms.Panel();
            this.axButton3 = new Ax.DEV.Utility.Controls.AxButton();
            this.axButton2 = new Ax.DEV.Utility.Controls.AxButton();
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.lbl01_VENDNM = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_VENDCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.btn01_Inquery = new Ax.DEV.Utility.Controls.AxButton();
            this.txt01_ORDERNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ORDERNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axDateEdit1);
            this.panel1.Controls.Add(this.axLabel1);
            this.panel1.Controls.Add(this.axButton3);
            this.panel1.Controls.Add(this.axButton2);
            this.panel1.Controls.Add(this.axButton1);
            this.panel1.Controls.Add(this.lbl01_VENDNM);
            this.panel1.Controls.Add(this.txt01_PARTNO);
            this.panel1.Controls.Add(this.lbl01_VENDCD);
            this.panel1.Controls.Add(this.btn01_Inquery);
            this.panel1.Controls.Add(this.txt01_ORDERNO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 79);
            this.panel1.TabIndex = 6;
            // 
            // axButton3
            // 
            this.axButton3.Location = new System.Drawing.Point(677, 19);
            this.axButton3.Name = "axButton3";
            this.axButton3.Size = new System.Drawing.Size(75, 31);
            this.axButton3.TabIndex = 61;
            this.axButton3.Text = "All UCHK";
            this.axButton3.UseVisualStyleBackColor = true;
            this.axButton3.Click += new System.EventHandler(this.axButton3_Click);
            // 
            // axButton2
            // 
            this.axButton2.Location = new System.Drawing.Point(596, 19);
            this.axButton2.Name = "axButton2";
            this.axButton2.Size = new System.Drawing.Size(75, 31);
            this.axButton2.TabIndex = 60;
            this.axButton2.Text = "All CHK";
            this.axButton2.UseVisualStyleBackColor = true;
            this.axButton2.Click += new System.EventHandler(this.axButton2_Click);
            // 
            // axButton1
            // 
            this.axButton1.Location = new System.Drawing.Point(816, 19);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(75, 31);
            this.axButton1.TabIndex = 59;
            this.axButton1.Text = "Select";
            this.axButton1.UseVisualStyleBackColor = true;
            this.axButton1.Click += new System.EventHandler(this.axButton1_Click);
            // 
            // lbl01_VENDNM
            // 
            this.lbl01_VENDNM.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDNM.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDNM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDNM.Location = new System.Drawing.Point(3, 30);
            this.lbl01_VENDNM.Name = "lbl01_VENDNM";
            this.lbl01_VENDNM.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VENDNM.TabIndex = 58;
            this.lbl01_VENDNM.Tag = null;
            this.lbl01_VENDNM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VENDNM.Value = "PART NO.";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(109, 30);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(307, 21);
            this.txt01_PARTNO.TabIndex = 57;
            this.txt01_PARTNO.Tag = null;
            // 
            // lbl01_VENDCD
            // 
            this.lbl01_VENDCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VENDCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VENDCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VENDCD.Location = new System.Drawing.Point(3, 3);
            this.lbl01_VENDCD.Name = "lbl01_VENDCD";
            this.lbl01_VENDCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VENDCD.TabIndex = 56;
            this.lbl01_VENDCD.Tag = null;
            this.lbl01_VENDCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VENDCD.Value = "ORDER NO.";
            // 
            // btn01_Inquery
            // 
            this.btn01_Inquery.Location = new System.Drawing.Point(425, 3);
            this.btn01_Inquery.Name = "btn01_Inquery";
            this.btn01_Inquery.Size = new System.Drawing.Size(75, 31);
            this.btn01_Inquery.TabIndex = 9;
            this.btn01_Inquery.Text = "Query";
            this.btn01_Inquery.UseVisualStyleBackColor = true;
            this.btn01_Inquery.Click += new System.EventHandler(this.btn01_Inquery_Click);
            // 
            // txt01_ORDERNO
            // 
            this.txt01_ORDERNO.Location = new System.Drawing.Point(109, 3);
            this.txt01_ORDERNO.Name = "txt01_ORDERNO";
            this.txt01_ORDERNO.Size = new System.Drawing.Size(307, 21);
            this.txt01_ORDERNO.TabIndex = 6;
            this.txt01_ORDERNO.Tag = null;
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 79);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(894, 355);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 7;
            this.grd01.UseCustomHighlight = true;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(3, 55);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(151, 21);
            this.axLabel1.TabIndex = 63;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Delivery Date.";
            // 
            // axDateEdit1
            // 
            this.axDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit1.Location = new System.Drawing.Point(160, 57);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(100, 21);
            this.axDateEdit1.TabIndex = 64;
            // 
            // ZSD02500_EtcDelDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.panel1);
            this.Name = "ZSD02500_EtcDelDLG";
            this.Size = new System.Drawing.Size(894, 434);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VENDCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_ORDERNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDNM;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_PARTNO;
        private Ax.DEV.Utility.Controls.AxLabel lbl01_VENDCD;
        private Ax.DEV.Utility.Controls.AxButton btn01_Inquery;
        private Ax.DEV.Utility.Controls.AxTextBox txt01_ORDERNO;
        private Ax.DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxButton axButton2;
        private DEV.Utility.Controls.AxButton axButton1;
        private DEV.Utility.Controls.AxButton axButton3;
        private DEV.Utility.Controls.AxDateEdit axDateEdit1;
        private DEV.Utility.Controls.AxLabel axLabel1;
    }
}
