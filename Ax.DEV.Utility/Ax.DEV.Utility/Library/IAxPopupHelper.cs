using System.Data;
using HE.Framework.Core;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// 한일이화 물류 시스템에서 사용하는 팝업 클래스에 대한 인터페이스입니다.
    /// </summary>
    public interface IAxPopupHelper
    {
        /// <summary>
        /// 팝업에서 선택된 값을 오브젝트로 가져옵니다.
        /// </summary>
        object SelectedValue { get; }

        /// <summary>
        /// 팝업창을 초기화합니다.
        /// </summary>
        void Initialize_Helper(object sender);

        /// <summary>
        /// HEParameterSet 인자를 조건으로 해서 원하는 데이타소스를 가져옵니다.
        /// </summary>
        DataTable GetDataSource(HEParameterSet set);
    }
}
