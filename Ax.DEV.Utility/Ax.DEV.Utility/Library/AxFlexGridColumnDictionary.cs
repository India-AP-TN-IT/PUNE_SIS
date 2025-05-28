using System.Collections.Generic;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// HEFlexGrid 컬럼 인덱스를 설정하는 사전타입입니다.
    /// </summary>
    public class AxFlexGridColumnDictionary : Dictionary<int, string> 
    { 
        /// <summary>
        /// HEFlexGrid 에 추가 된 컬럼의 인덱스를 명으로 가져옵니다.
        /// </summary>
        public int GetNameIndex(string name)
        {
            for (int i = 1; i <= this.Count; i++)
                if (this[i].Equals(name)) return i;

            return -1;
        }
    }
}
