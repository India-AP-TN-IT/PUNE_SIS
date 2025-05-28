using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Input;
using System.Runtime.InteropServices;

namespace  Ax.DEV.Utility.Library
{
    /// <summary>
    /// C1Button 클래스를 상속받아 구현된 버튼입니다.
    /// FullScreen Module  추가   2016.11.07 김건우
    /// </summary>
    [DefaultProperty("FullScreenTarget")]
    public class AxFullScreenHelper
    {
        public delegate void FullScreenModeChangedHandler(object sender, bool changedMode);
        public event FullScreenModeChangedHandler modeChanged;


        [DefaultValue(false)]
        public bool fullScreenMode
        {
            get;
            set;
        }

        //public Rectangle FullScreenBound
        //{
        //    get;
        //    set;
        //}

        private void OnFullScreenModeChanged(object sender, bool changedMode)
        {
            if (this.modeChanged != null)
                this.modeChanged(sender, changedMode);
        }

        // 화면 절전 모드 방지용
        [DllImport("kernel32.dll", EntryPoint = "SetThreadExecutionState", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE flags);

        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_USER_PRESENT = 0x00000004,
            ES_CONTINUOUS = 0x80000000
        }

        [Description("FullScreen 을 처리할 사용자 컨트롤을 지정")]
        public AxCommonBaseControl FullScreenTarget
        {
            get;
            set;
        }

        [DefaultValue(true), Description("상단의 버튼 컨트롤을 표시할지 말지 결정합니다.")]
        public bool ShowButtonControl
        {
            get;
            set;
        }

        private bool InitButtonControlVisible
        {
            get;
            set;
        }

        Control parentControl = null;
        Form fsForm = null;

        public AxFullScreenHelper()
        {
            this.PreventMonitorPowerdown();
            this.FullScreenTarget = null;
            this.ShowButtonControl = true;
            //this.fullScreenBound = 0;
        }

        public void ExecuteFullScreen()
        {
            this.HEFullScreenButton_Click(this, null);
        }

        void HEFullScreenButton_Click(object sender, System.EventArgs e)
        {
            if (this.FullScreenTarget == null) return;

            if (!this.FullScreenTarget.Showned) return;

            if (this.parentControl == null)
            {
                parentControl = this.FullScreenTarget.Parent;

                // 초기 버튼 컨트롤 Visiable 상태
                InitButtonControlVisible = this.FullScreenTarget._buttonsControl.Visible;
            }

            if (this.FullScreenTarget.Parent == parentControl)
            {
                fsForm = new Form();

                fsForm.ControlBox = false;
                fsForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fsForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                fsForm.Text = "FullScreen";
                fsForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                fsForm.Bounds = Screen.GetBounds(this.FullScreenTarget);

                if (!this.ShowButtonControl && InitButtonControlVisible) this.FullScreenTarget._buttonsControl.Visible = false;

                Form srcForm = this.FullScreenTarget.FindForm();
                this.FullScreenTarget.Parent = fsForm;
                fsForm.Text = srcForm.Text;
                fsForm.Show();
                srcForm.Visible = false;

                fullScreenMode = true;
                OnFullScreenModeChanged(this, true);
            }
            else
            {
                this.FullScreenTarget.Parent = parentControl;

                if (!this.ShowButtonControl && InitButtonControlVisible) this.FullScreenTarget._buttonsControl.Visible = true;

                Form srcForm = this.FullScreenTarget.FindForm();
                srcForm.Visible = true;
                fsForm.Close();
                this.FullScreenTarget.Focus();

                fullScreenMode = false;
                OnFullScreenModeChanged(this, false);
            }
        }


        // 절전/대기 모드 진입 금지
        private void PreventMonitorPowerdown()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }

        // 절전/대기 모드 진입 허용
        private void AllowMonitorPowerdown()
        {
            SetThreadExecutionState(~EXECUTION_STATE.ES_DISPLAY_REQUIRED & EXECUTION_STATE.ES_CONTINUOUS & ~EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }
    }
}
