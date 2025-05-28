namespace Ax.SIS.WM.UI
{
    partial class WM20460
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WM20460));
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl01_PGNDESC = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PGNDESC = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axLabel3 = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_PLANT = new Ax.DEV.Utility.Controls.AxComboBox();
            this.cbo01_VINCD = new Ax.DEV.Utility.Controls.AxComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PGNDESC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PGNDESC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsControl
            // 
            this._buttonsControl.Size = new System.Drawing.Size(1080, 34);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(0, 74);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(1080, 694);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 10;
            this.grd01.UseCustomHighlight = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbo01_VINCD);
            this.groupBox3.Controls.Add(this.cbo01_PLANT);
            this.groupBox3.Controls.Add(this.axLabel2);
            this.groupBox3.Controls.Add(this.axLabel3);
            this.groupBox3.Controls.Add(this.lbl01_PGNDESC);
            this.groupBox3.Controls.Add(this.txt01_PGNDESC);
            this.groupBox3.Controls.Add(this.axLabel1);
            this.groupBox3.Controls.Add(this.axTextBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1080, 40);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // lbl01_PGNDESC
            // 
            this.lbl01_PGNDESC.AutoFontSizeMaxValue = 9F;
            this.lbl01_PGNDESC.AutoFontSizeMinValue = 9F;
            this.lbl01_PGNDESC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PGNDESC.Location = new System.Drawing.Point(222, 13);
            this.lbl01_PGNDESC.Name = "lbl01_PGNDESC";
            this.lbl01_PGNDESC.Size = new System.Drawing.Size(117, 21);
            this.lbl01_PGNDESC.TabIndex = 103;
            this.lbl01_PGNDESC.Tag = null;
            this.lbl01_PGNDESC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PGNDESC.Value = "Part Group Description";
            // 
            // txt01_PGNDESC
            // 
            this.txt01_PGNDESC.Location = new System.Drawing.Point(345, 13);
            this.txt01_PGNDESC.Name = "txt01_PGNDESC";
            this.txt01_PGNDESC.Size = new System.Drawing.Size(174, 21);
            this.txt01_PGNDESC.TabIndex = 102;
            this.txt01_PGNDESC.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(6, 13);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(103, 21);
            this.axLabel1.TabIndex = 105;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Part Group Code";
            // 
            // axTextBox1
            // 
            this.axTextBox1.Location = new System.Drawing.Point(115, 13);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(92, 21);
            this.axTextBox1.TabIndex = 104;
            this.axTextBox1.Tag = null;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(750, 13);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(137, 21);
            this.axLabel2.TabIndex = 107;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "Vehicle Code";
            // 
            // axLabel3
            // 
            this.axLabel3.AutoFontSizeMaxValue = 9F;
            this.axLabel3.AutoFontSizeMinValue = 9F;
            this.axLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel3.Location = new System.Drawing.Point(536, 13);
            this.axLabel3.Name = "axLabel3";
            this.axLabel3.Size = new System.Drawing.Size(99, 21);
            this.axLabel3.TabIndex = 109;
            this.axLabel3.Tag = null;
            this.axLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel3.Value = "Plant";
            // 
            // cbo01_PLANT
            // 
            this.cbo01_PLANT.BackColor = System.Drawing.Color.White;
            this.cbo01_PLANT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_PLANT.FormattingEnabled = true;
            this.cbo01_PLANT.Location = new System.Drawing.Point(641, 11);
            this.cbo01_PLANT.Name = "cbo01_PLANT";
            this.cbo01_PLANT.Size = new System.Drawing.Size(92, 23);
            this.cbo01_PLANT.TabIndex = 157;
            // 
            // cbo01_VINCD
            // 
            this.cbo01_VINCD.BackColor = System.Drawing.Color.White;
            this.cbo01_VINCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_VINCD.FormattingEnabled = true;
            this.cbo01_VINCD.Location = new System.Drawing.Point(893, 13);
            this.cbo01_VINCD.Name = "cbo01_VINCD";
            this.cbo01_VINCD.Size = new System.Drawing.Size(173, 23);
            this.cbo01_VINCD.TabIndex = 158;
            // 
            // WM20460
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.groupBox3);
            this.Name = "WM20460";
            this.Size = new System.Drawing.Size(1080, 768);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.grd01, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PGNDESC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PGNDESC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DEV.Utility.Controls.AxFlexGrid grd01;
        private System.Windows.Forms.GroupBox groupBox3;
        private DEV.Utility.Controls.AxLabel lbl01_PGNDESC;
        private DEV.Utility.Controls.AxTextBox txt01_PGNDESC;
        private DEV.Utility.Controls.AxLabel axLabel1;
        private DEV.Utility.Controls.AxTextBox axTextBox1;
        private DEV.Utility.Controls.AxLabel axLabel2;
        private DEV.Utility.Controls.AxLabel axLabel3;
        private DEV.Utility.Controls.AxComboBox cbo01_VINCD;
        private DEV.Utility.Controls.AxComboBox cbo01_PLANT;

    }
}
