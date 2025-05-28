using Ax.DEV.Utility.Controls;

namespace Ax.DEV.Utility.Library
{
    public interface IPopupControl
    {
        object SelectedData { get; }
        AxCodeBox CodeBox { get; set; }
        string PrefixCode { get; set; }
        bool RequireAuthentication { get; set; }
        bool RequireAuthorization { get; set; }
        void Initialize_Property();
    }
}
