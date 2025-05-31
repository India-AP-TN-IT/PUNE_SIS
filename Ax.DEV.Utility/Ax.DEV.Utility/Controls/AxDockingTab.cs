using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// UserControl를 상속받은 사용자 정의 컨트롤 DockingTab입니다.
    /// 한일이화에서 조회 프로그램의 표준형태에 사용되며, 좌측 조회조건 판넬, 우측 조회내용 판넬로 구성됩니다.
    /// </summary>
    public partial class AxDockingTab : UserControl
    {
        public AxDockingTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 화면 좌측에 조회조건이 될 판넬을 지정합니다.
        /// </summary>
        public Panel LinkPanel
        {
            set 
            {
                this.PanelWidth = value.Width;
                value.BackColor = Color.White;
                value.Dock = DockStyle.Fill;                
                this._PanelControlForm.Controls.Add(value); 
            }
        }

        /// <summary>
        /// 화면 우측에 조회내용을 표시할 판넬을 지정합니다.
        /// </summary>
        public Panel LinkBody
        {
            set 
            {
                value.Dock = DockStyle.Fill;
                this._PanelGrid.Controls.Add(value); 
            }
        }

        /// <summary>
        /// DockingTab 넓이를 가져오거나 지정합니다.
        /// </summary>
        [CategoryAttribute("PanelWidth"), DescriptionAttribute("PanelWidth")]
        public int PanelWidth
        {
            get 
            { 
                return this._C1DockingTab.Width; 
            }
            set 
            { 
                this._C1DockingTab.Width = value; 
            }
        }

        /// <summary>
        /// DockingTab 높이를 가져오거나 지정합니다.
        /// </summary>
        [CategoryAttribute("PanelHeight"), DescriptionAttribute("PanelHeight")]
        public int PanelHeight
        {
            get
            {
                return this._C1DockingTab.Height;
            }
            set
            {
                this._C1DockingTab.Height = value;
            }
        }

        /// <summary>
        /// DockingTab 자동숨김(AutoHiding) 속성을 지정합니다.
        /// </summary>
        public void SetAutoHiding(bool autoHiding)
        {
            this._C1DockingTab.AutoHiding = autoHiding;
        }
    }
}
