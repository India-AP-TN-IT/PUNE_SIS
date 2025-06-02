using C1.Win.C1Input;
using Ax.DEV.Utility.Library;
using System.Windows.Forms;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// C1Button 클래스를 상속받아 구현된 버튼입니다.
    /// </summary>
    public class AxButton : C1Button, IAxControl
    {
        public AxButton() : base()
        {
            this.MouseHover += new System.EventHandler(HEButton_MouseHover);
        }
        #region IHEControl 멤버

        public object GetValue()
        {
            return this.Text;
        }

        public void SetValue(object value)
        {
            this.Text = value.ToString();
        }

        public void Initialize()
        {
            
        }

        #endregion

        public void SetReadOnly(bool read)
        {
            this.Enabled = !read;
        }

        private void HEButton_MouseHover(object sender, System.EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this, this.Text);
        }
    }
}
