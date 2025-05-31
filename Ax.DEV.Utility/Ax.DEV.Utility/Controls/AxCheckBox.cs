using System.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// CheckBox 클래스를 상속받아 구현된 체크박스입니다.
    /// </summary>
    public class AxCheckBox : CheckBox, IAxControl
    {
        public AxCheckBox()
        {
            this.MouseHover += new System.EventHandler(HECheckBox_MouseHover);
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
        /// 체크되는 값은 true, 'Y', '1' 이 있으며 모두 동일한 의미를 가집니다.
        /// </summary>
        public void SetValue(object value)
        {
            if (value is bool)
                this.Checked = (bool)value;
            else
                this.Checked = (value.ToString().Equals("Y") ||
                                value.ToString().Equals("1")) ? true : false;
        }

        public void Initialize()
        {
            this.Checked = false;
        }

        #endregion

        public void SetReadOnly(bool read)
        {
            this.Enabled = !read;
        }

        private void HECheckBox_MouseHover(object sender, System.EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this, this.Text);
        }
    }
}
