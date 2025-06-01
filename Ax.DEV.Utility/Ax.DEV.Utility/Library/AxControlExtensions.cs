using System;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;


namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// 한일이화 프로젝트에서 크로스 스레드 처리합니다.
    /// 해당 클래스는 오픈된 소스를 인터넷에서 찾아 작성되었습니다.
    /// </summary>
    public static class ControlExtensions
    {
        public static void InvokeIfNeeded(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }

        public static void InvokeIfNeeded<T>(this Control control, Action<T> action, T arg)
        {
            if (control.InvokeRequired)
                control.Invoke(action, arg);
            else
                action(arg);
        }

        /// <summary>
        /// 그리드 다국처 처리 확장 메서드
        /// </summary>
        /// <param name="control"></param>
        /// <param name="read"></param>
        /// <param name="visible"></param>
        /// <param name="align"></param>
        /// <param name="width"></param>
        /// <param name="caption"></param>
        /// <param name="name"></param>
        public static void AddColumn(this AxFlexGrid control, bool read, bool visible, AxFlexGrid.FtextAlign align, int width, string caption, string name)
        {
            AddColumn(control, read, visible, align, width, caption, name, name);
        }

        /// <summary>
        /// 그리드 신규 컬럼추가 다국어 코드 포함
        /// </summary>
        /// <param name="control"></param>
        /// <param name="read"></param>
        /// <param name="visible"></param>
        /// <param name="align"></param>
        /// <param name="width"></param>
        /// <param name="caption"></param>
        /// <param name="name"></param>
        /// <param name="langCode"></param>        
        public static void AddColumn(this AxFlexGrid control, bool read, bool visible, AxFlexGrid.FtextAlign align, int width, string caption, string name, string langCode)
        {                                    
            string _caption;
            //if (control.GetContainerControl() is HEDockingTab)
            //{
            //    _caption = ((HECommonUserControl)(control.GetContainerControl() as UserControl).Parent.GetContainerControl()).GetLabel(langCode);
            //}
            //else
            //{
            //    _caption = ((HECommonUserControl)control.GetContainerControl()).GetLabel(langCode);
            //}


            Control ctl = control.GetContainerControl() as Control;

            while (!(ctl is AxCommonBaseControl || ctl is AxCommonPopupControl) && ctl != null)
            {                    
                ctl = ctl.Parent.GetContainerControl() as Control;
            }

            if (ctl is AxCommonPopupControl)
            {
                _caption = ((AxCommonPopupControl)ctl).GetLabel(langCode);
            }
            else
            {
                _caption = ((AxCommonBaseControl)ctl).GetLabel(langCode);
            }
            _caption = (string.IsNullOrEmpty(_caption) ? caption : _caption);
            //control.AddColumn(read, visible, align, width, _caption, name);
            control.AddColumnLang(read, visible, align, width, _caption, name, langCode);
        }
    }
}
