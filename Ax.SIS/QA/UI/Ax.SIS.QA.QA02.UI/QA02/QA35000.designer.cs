
namespace Ax.SIS.QA.QA02.UI
{
    partial class QA35000
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QA35000));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grd01 = new DEV.Utility.Controls.AxFlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.heLabel1 = new DEV.Utility.Controls.AxLabel();
            this.dte01_STD_DATE = new DEV.Utility.Controls.AxDateEdit();
            this.lbl01_QA35000_YYYYMM = new DEV.Utility.Controls.AxLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA35000_YYYYMM)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 734);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1024, 697);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.grd01);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.panel4.Size = new System.Drawing.Size(1024, 697);
            this.panel4.TabIndex = 0;
            // 
            // grd01
            // 
            this.grd01.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.grd01.AllowHeaderMerging = false;
            this.grd01.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.grd01.ColumnInfo = "0,0,0,0,0,120,Columns:";
            this.grd01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd01.EnabledActionFlag = true;
            this.grd01.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(5, 5);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = false;
            this.grd01.Rows.DefaultSize = 24;
            this.grd01.Size = new System.Drawing.Size(1014, 692);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 0;
            this.grd01.Tree.LineColor = System.Drawing.Color.Transparent;
            this.grd01.Resize += new System.EventHandler(this.grd01_Resize);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl01_QA35000_YYYYMM);
            this.panel2.Controls.Add(this.dte01_STD_DATE);
            this.panel2.Controls.Add(this.heLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 37);
            this.panel2.TabIndex = 0;
            // 
            // heLabel1
            // 
            this.heLabel1.BackColor = System.Drawing.Color.Transparent;
            this.heLabel1.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.heLabel1.ForeColor = System.Drawing.Color.Black;
            this.heLabel1.Location = new System.Drawing.Point(78, 153);
            this.heLabel1.Name = "heLabel1";
            this.heLabel1.Size = new System.Drawing.Size(196, 67);
            this.heLabel1.TabIndex = 85;
            this.heLabel1.Tag = null;
            this.heLabel1.Text = "heLabel1";
            this.heLabel1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.heLabel1.TextDetached = true;
            this.heLabel1.Value = "기준년도";
            this.heLabel1.Visible = false;
            // 
            // dte01_STD_DATE
            // 
            this.dte01_STD_DATE.CustomFormat = "yyyy-MM";
            this.dte01_STD_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte01_STD_DATE.Location = new System.Drawing.Point(143, 9);
            this.dte01_STD_DATE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dte01_STD_DATE.Name = "dte01_STD_DATE";
            this.dte01_STD_DATE.OriginalFormat = "";
            this.dte01_STD_DATE.Size = new System.Drawing.Size(100, 21);
            this.dte01_STD_DATE.TabIndex = 84;
            // 
            // lbl01_QA35000_YYYYMM
            // 
            this.lbl01_QA35000_YYYYMM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_QA35000_YYYYMM.ForeColor = System.Drawing.Color.Black;
            this.lbl01_QA35000_YYYYMM.Location = new System.Drawing.Point(5, 9);
            this.lbl01_QA35000_YYYYMM.Name = "lbl01_QA35000_YYYYMM";
            this.lbl01_QA35000_YYYYMM.Size = new System.Drawing.Size(135, 21);
            this.lbl01_QA35000_YYYYMM.TabIndex = 73;
            this.lbl01_QA35000_YYYYMM.Tag = null;
            this.lbl01_QA35000_YYYYMM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_QA35000_YYYYMM.Value = "Search Month";
            // 
            // QA35000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "QA35000";
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_QA35000_YYYYMM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private DEV.Utility.Controls.AxFlexGrid grd01;
        private DEV.Utility.Controls.AxLabel lbl01_QA35000_YYYYMM;
        private DEV.Utility.Controls.AxDateEdit dte01_STD_DATE;
        private DEV.Utility.Controls.AxLabel heLabel1;








    }
}
