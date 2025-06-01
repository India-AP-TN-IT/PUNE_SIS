#region ▶ Description & History
/* 
 * 프로그램명 : PopupHelper
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-14      배명희      우측 하단의 "초기화", "종료"버튼에 대한 다국어 적용.
 *				                            ==> 환경정보인 CultureInfo.CurrentCulture가 로그인시에 선택한language로 셋팅됨. (CultureInfo.CurrentCulture와 resource파일 이용)
 *                                          
*/
#endregion
using System;
using System.Windows.Forms;
using System.Collections;
using Ax.DEV.Utility.Controls;
using System.Resources;
using System.Globalization;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// 한일이화 물류 시스템에서 사용하는 팝업 부모창입니다.
    /// 본 시스템에서는 UserControl에 프로그램을 작성하기에 이를 노출시킬 Form 클래스가 필요합니다.
    /// </summary>
    public partial class PopupHelper : Form
    {
        private IPopupControl _HECommonPopupControl;
        private ControlFactoryList _ControlFactory;

        /// <summary>
        /// 사용자 정의 생성자이며, IPopupControl 타입의 UserControl 을 인수로 받습니다.
        /// </summary>
        public PopupHelper(AxCommonPopupControl helper, string title)
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                _ControlFactory = new ControlFactoryList();

                this.Text   = title;
                this.Width  = helper.Width + 20;
                this.Height = helper.Height + 50;

                _HECommonPopupControl = helper;
                _HECommonPopupControl.Initialize_Property();
                _HECommonPopupControl.RequireAuthentication = false;
                _HECommonPopupControl.RequireAuthorization = false;

                UserControl popup = (UserControl)helper;
                popup.Dock = System.Windows.Forms.DockStyle.Fill;
                popup.Location = new System.Drawing.Point(0, 0);
                popup.TabIndex = 0;

                this.Controls.Add(popup);
                this.Controls.Remove(this.panel2);
                this.Controls.Add(this.panel2);
                this.IControlFactoryCollection(this.Controls);
            }
        }
        
        /// <summary>
        /// 사용자 정의 생성자이며, IPopupControl 타입의 UserControl을 인수로 받습니다.
        /// </summary>
        public PopupHelper(IPopupControl popup, string title)
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
               
                this.setLangSet();

                _ControlFactory = new ControlFactoryList();

                _HECommonPopupControl = popup;
                _HECommonPopupControl.Initialize_Property();
                _HECommonPopupControl.RequireAuthentication = false;
                _HECommonPopupControl.RequireAuthorization = false;

                UserControl helper = (UserControl)popup;

                this.Text   = title;
                this.Width  = helper.Width + 20;
                this.Height = helper.Height + 50;

                helper.Dock = System.Windows.Forms.DockStyle.Fill;
                helper.Location = new System.Drawing.Point(0, 0);
                helper.TabIndex = 0;

                this.Controls.Add(helper);
                this.Controls.Remove(this.panel2);
                this.Controls.Add(this.panel2);
                this.IControlFactoryCollection(this.Controls);
            }
        }

        /// <summary>
        /// 팝업 윈도우의 타이틀을 설정합니다.
        /// </summary>
        public string PopupTitle
        {
            set { this.Text = value; }
        }

        /// <summary>
        /// 팝업 윈도우에서 선택된 값을 가져옵니다.
        /// 대부분은 DataRow 타입이 object 타입으로 묵시적 형변환되어 반환됩니다.
        /// </summary>
        public object SelectedValue
        {
            get { return ((IAxPopupHelper)_HECommonPopupControl).SelectedValue; }
        }

        /// <summary>
        /// 팝업 윈도우에서 선택된 값을 가져옵니다.
        /// 다만 SelectedValue 프로퍼티는 IHEPopupHelper 인터페이스의 메서드형이며, 
        /// SelectedData 프로퍼티는 IPopupControl 인터페이스가 제공하는 공개된 프로퍼티입니다.
        /// </summary>
        public object SelectedData
        {
            get { return _HECommonPopupControl.SelectedData; }
        }

        /// <summary>
        /// 팝업 윈도우의 사이즈를 고정시킵니다.
        /// </summary>
        public void FixedPopupSize()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void btn01_NEW_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _ControlFactory.Count; i++)
            {
                Control control = (Control)_ControlFactory[i];
                if (control.Visible)
                {
                    if (control is AxTextBox)
                    {
                        if (!((AxTextBox)control).ReadOnly && control.Enabled)
                            _ControlFactory[i].Initialize();
                    }
                    else
                    {
                        if (control.Enabled)
                            _ControlFactory[i].Initialize();
                    }
                }
            }
        }

        private void btn01_CLS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IControlFactoryCollection(Control.ControlCollection controls)
        {
            if (controls.Count == 0) return;

            ArrayList outer = new ArrayList();
            for (int i = 0; i < controls.Count; i++)
            {
                Control control = controls[i];
                control.TabIndex = 0;
                if (control is IAxControl)
                {
                    if (control is AxCheckBox       || 
                        control is AxCodeBox        ||
                        control is AxComboBox       || 
                        control is AxDateEdit       || 
                        control is AxNumericEdit    || 
                        control is AxRadioButton    || 
                        control is AxTextBox)
                        _ControlFactory.Add((IAxControl)control);
                }
                else
                    outer.Add(control);
            }

            for (int i = 0; i < outer.Count; i++)
                this.IControlFactoryCollection(((Control)outer[i]).Controls);
        }

        /// <summary>
        /// Form 클래스의 ShowDialog()를 내부적으로 호출하며,
        /// 팝업 윈도우 하단에 위치한 초기화 부분 판넬의 숨김여부를 인자로 받습니다.
        /// </summary>
        public void ShowDialog(bool initVisible)
        {
            this.panel2.Visible = initVisible;
            base.ShowDialog();
        }

        /// <summary>
        /// Form 클래스의 Show()를 내부적으로 호출하며,
        /// 팝업 윈도우 하단에 위치한 초기화 부분 판넬의 숨김여부를 인자로 받습니다.
        /// </summary>
        public void Show(bool initVisible)
        {
            this.panel2.Visible = initVisible;
            base.Show();
        }



        /// <summary>
        /// 리소스 파일로부터 버튼에 표시할 text 읽어와서 설정한다.
        /// </summary>
        /// <param name="language"></param>
        private void setLangSet()
        {
            try
            {
                btn01_CLS.Text = Ax.DEV.Utility.Resources.Default.CLS; //TheOne.Resources.ResourceHelper.GetStringFromCallingAssembly("NEW");
                btn01_NEW.Text = Ax.DEV.Utility.Resources.Default.NEW;
                //ResourceManager res = new ResourceManager("Ax.DEV.Utility.Resources.Resources", typeof(PopupHelper).Assembly);
                //btn01_NEW.Text = res.GetString("NEW", CultureInfo.CurrentCulture);
                //btn01_CLS.Text = res.GetString("CLS", CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
