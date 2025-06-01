using System;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// RadioButton 클래스를 상속받은 라디오버튼입니다.
    /// </summary>
    public class AxRadioButton : RadioButton, IAxControl
    {
        public AxRadioButton()
        {
            this.MouseHover += new EventHandler(HERadioButton_MouseHover);
        }

        #region IHEControl 멤버

        /// <summary>
        /// 반환값은 checked='Y', unchecked='N' 입니다.
        /// </summary>
        public object GetValue()
        {
            return this.Checked ? "Y" : "N";
        }

        /// <summary>
        /// 체크되는 값은 true, 'Y', 이 있으며 모두 동일한 의미를 가집니다.
        /// </summary>
        public void SetValue(object value)
        {
            if (value is bool)
                this.Checked = (bool)value;
            else
                this.Checked = value.ToString().Equals("Y") ? true : false;
        }

        public void Initialize()
        {
            this.SetValue(false);
        }

        #endregion

        public void SetReadOnly(bool read)
        {
            this.Enabled = !read;
        }

        private void HERadioButton_MouseHover(object sender, System.EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this, this.Text);
        }
    }
}
