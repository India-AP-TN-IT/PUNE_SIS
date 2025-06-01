using System.Windows.Forms;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// Splitter 클래스를 상속받은 스플라이트이며, 현재 구현내용은 없습니다.
    /// </summary>
    public class AxSplitter : Splitter
    {
        public AxSplitter()
            : base()
        {
            this.Size = new System.Drawing.Size(10, 400);
            this.TabStop = false;
        }
    }
}
