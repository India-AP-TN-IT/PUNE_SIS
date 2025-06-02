namespace Ax.DEV.Utility.Controls
{
    partial class AxDockingTab
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
            this._C1CommandDock = new C1.Win.C1Command.C1CommandDock();
            this._C1DockingTab = new C1.Win.C1Command.C1DockingTab();
            this._C1DockingTabPage = new C1.Win.C1Command.C1DockingTabPage();
            this._PanelControlForm = new System.Windows.Forms.Panel();
            this._PanelBase = new System.Windows.Forms.Panel();
            this._PanelGrid = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._C1CommandDock)).BeginInit();
            this._C1CommandDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._C1DockingTab)).BeginInit();
            this._C1DockingTab.SuspendLayout();
            this._C1DockingTabPage.SuspendLayout();
            this._PanelBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // _C1CommandDock
            // 
            this._C1CommandDock.AutoDockBottom = false;
            this._C1CommandDock.AutoDockRight = false;
            this._C1CommandDock.AutoDockTop = false;
            this._C1CommandDock.Controls.Add(this._C1DockingTab);
            this._C1CommandDock.Dock = System.Windows.Forms.DockStyle.Left;
            this._C1CommandDock.DockingStyle = C1.Win.C1Command.DockingStyle.VS2005;
            this._C1CommandDock.Id = 2;
            this._C1CommandDock.Location = new System.Drawing.Point(0, 0);
            this._C1CommandDock.Name = "_C1CommandDock";
            this._C1CommandDock.Size = new System.Drawing.Size(277, 400);
            // 
            // _C1DockingTab
            // 
            this._C1DockingTab.Alignment = System.Windows.Forms.TabAlignment.Left;
            this._C1DockingTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._C1DockingTab.CanAutoHide = true;
            this._C1DockingTab.CanMoveTabs = true;
            this._C1DockingTab.Controls.Add(this._C1DockingTabPage);
            this._C1DockingTab.Location = new System.Drawing.Point(0, 0);
            this._C1DockingTab.Name = "_C1DockingTab";
            this._C1DockingTab.ShowCaption = true;
            this._C1DockingTab.ShowSingleTab = false;
            this._C1DockingTab.Size = new System.Drawing.Size(277, 400);
            this._C1DockingTab.TabAreaSpacing = 3;
            this._C1DockingTab.TabIndex = 0;
            this._C1DockingTab.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this._C1DockingTab.TabsSpacing = 5;
            this._C1DockingTab.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this._C1DockingTab.VisualStyle = C1.Win.C1Command.VisualStyle.Classic;
            this._C1DockingTab.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue;
            // 
            // _C1DockingTabPage
            // 
            this._C1DockingTabPage.Controls.Add(this._PanelControlForm);
            this._C1DockingTabPage.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._C1DockingTabPage.Location = new System.Drawing.Point(1, 1);
            this._C1DockingTabPage.Name = "_C1DockingTabPage";
            this._C1DockingTabPage.Size = new System.Drawing.Size(272, 398);
            this._C1DockingTabPage.TabIndex = 0;
            this._C1DockingTabPage.Text = "Search";
            // 
            // _PanelControlForm
            // 
            this._PanelControlForm.BackColor = System.Drawing.SystemColors.Control;
            this._PanelControlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelControlForm.Location = new System.Drawing.Point(0, 19);
            this._PanelControlForm.Name = "_PanelControlForm";
            this._PanelControlForm.Size = new System.Drawing.Size(272, 379);
            this._PanelControlForm.TabIndex = 0;
            // 
            // _PanelBase
            // 
            this._PanelBase.Controls.Add(this._PanelGrid);
            this._PanelBase.Controls.Add(this._C1CommandDock);
            this._PanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelBase.Location = new System.Drawing.Point(0, 0);
            this._PanelBase.Name = "_PanelBase";
            this._PanelBase.Size = new System.Drawing.Size(400, 400);
            this._PanelBase.TabIndex = 1;
            // 
            // _PanelGrid
            // 
            this._PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PanelGrid.Location = new System.Drawing.Point(277, 0);
            this._PanelGrid.Name = "_PanelGrid";
            this._PanelGrid.Size = new System.Drawing.Size(123, 400);
            this._PanelGrid.TabIndex = 1;
            // 
            // HEDockingTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._PanelBase);
            this.Name = "HEDockingTab";
            this.Size = new System.Drawing.Size(400, 400);
            ((System.ComponentModel.ISupportInitialize)(this._C1CommandDock)).EndInit();
            this._C1CommandDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._C1DockingTab)).EndInit();
            this._C1DockingTab.ResumeLayout(false);
            this._C1DockingTabPage.ResumeLayout(false);
            this._PanelBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Command.C1CommandDock _C1CommandDock;
        private System.Windows.Forms.Panel _PanelBase;
        private System.Windows.Forms.Panel _PanelControlForm;
        private C1.Win.C1Command.C1DockingTab _C1DockingTab;
        private C1.Win.C1Command.C1DockingTabPage _C1DockingTabPage;
        private System.Windows.Forms.Panel _PanelGrid;
    }
}
