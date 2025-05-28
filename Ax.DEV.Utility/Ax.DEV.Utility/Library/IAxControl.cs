
namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// Ax.DEV.Utility에 사용하는 컨트롤에 대한 인터페이스입니다.
    /// 한일이화 프로젝트에서 구현된 모든 사용자 정의 컨트롤은 IHEControl 인터페이스를 상속받습니다.
    /// </summary>
    public interface IAxControl
    {
        /// <summary>
        /// 지정된 값을 가져오는 인터페이스 형(메서드)입니다.
        /// </summary>
        object GetValue();

        /// <summary>
        /// 입력받은 인수를 값으로 설정하는 인터페이스 형(메서드)입니다.
        /// </summary>
        void SetValue(object value);

        /// <summary>
        /// 컨트롤을 초기화하는 인터페이스 형(메서드)입니다.
        /// </summary>
        void Initialize();
    }
}
