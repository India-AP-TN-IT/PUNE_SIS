using System.Windows.Forms;
using System.Collections.Generic;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// List 클래스를 상속받아 구현된 IHEControl을 관리하는 클래스입니다.
    /// </summary>
    public class ControlFactoryList : List<IAxControl> 
    {
        /// <summary>
        /// IHEControl을 리스트에 추가하며, 이 메서드는 새로 정의되었습니다.
        /// </summary>
        public new void Add(IAxControl control)
        {
            if (control is Control)
            {
                Control c = (Control)control;
                if (c.Name.Length > 0)
                    base.Add(control);
            }
        }

        /// <summary>
        /// Control을 리스트에 IHEControl 형변환 하여 추가합니다.
        /// </summary>
        public void Add(Control control)
        {
            if (control.Name.Length > 0)
                base.Add((IAxControl)control);
        }

        /// <summary>
        /// 인수로 넘겨진 컨트롤 이름에 해당하는 컨트롤을 리스트에서 가져옵니다.
        /// </summary>
        public Control GetControl(string name)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Control control = (Control)this[i];
                if (control.Name.Equals(name))
                    return control;
            }

            return null;
        }
    }

    /// <summary>
    /// List 클래스를 상속받아 구현된 컨트롤 순서를 기록하는 순서 클래스입니다.
    /// </summary>
    public class ControlSequenceList : List<Control>
    {
        /// <summary>
        /// 인수로 넘겨진 명에 해당하는 컨트롤을 리스트에서 가져옵니다.
        /// </summary>
        public Control GetControl(string name)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Control control = (Control)this[i];
                if (control.Name.Equals(name))
                    return control;
            }

            return null;
        }
    }
}
