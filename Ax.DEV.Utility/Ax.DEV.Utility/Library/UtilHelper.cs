using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HE.DevHelper
{
	public static class UtilHelper
	{
		/// <summary>
		/// Int형 배열을 만드는 메서드
		/// </summary>
		/// <param name="arrayCount">배열의 개수</param>
		/// <returns></returns>
		public static int[] MakeIntArray(int arrayCount) 
		{
			return MakeIntArray(arrayCount, 0);
		}

		/// <summary>
		/// Int형 배열을 만드는 메서드
		/// </summary>
		/// <param name="arrayCount">배열의 개수</param>
		/// <param name="startValue">처음 시작 값</param>
		/// <returns></returns>
		public static int[] MakeIntArray(int arrayCount, int startValue)
		{
			int[] iArray = new int[arrayCount];

			for (int i = 0; i < arrayCount; i++)
			{
				iArray[i] = startValue++;
			}

			return iArray;
		}
	}
}
