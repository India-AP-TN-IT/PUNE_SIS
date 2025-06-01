using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace Ax.DEV.Utility.Library
{
    // 기본 헬퍼 클래스
    public static class CoreHelper
    {
        /// <summary>
        /// 정규식과 일치하는지를 비교하는 메서드
        /// </summary>
        /// <param name="pattern">패턴식</param>
        /// <param name="inputValue">패턴식과 비교할 값</param>
        /// <returns></returns>
        public static bool CheckRegex(string pattern, string compareValue)
        {
            Regex re = new Regex(@pattern);

            return re.IsMatch(compareValue);
        }

        /// <summary>
        /// 파일 대화 상자를 이용하여, 로컬에 있는 데이터를 읽어온다.
        /// </summary>
        /// <returns></returns>
        public static byte[] GetDataFromLocalFile()
        {
            return GetDataFromLocalFile(FILETYPE.NONE);
        }

        /// <summary>
        /// 파일 대화 상자를 이용하여, 로컬에 있는 데이터를 읽어온다.
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public static byte[] GetDataFromLocalFile(FILETYPE fileType) 
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = GetFileFilter(fileType);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                byte[] imageData = new byte[stream.Length];
                stream.Read(imageData, 0, Convert.ToInt32(stream.Length));
                stream.Close();

                return imageData;
            }
            else 
            {
                return null;
            }
        }

        /// <summary>
        /// 파일 대화 상자에서 사용할 Filter 문자열을 가져온다.
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public static string GetFileFilter(FILETYPE fileType) 
        {
            string filter = string.Empty;

            switch (fileType)
            {
                case FILETYPE.NONE:
                    filter = FileFilter.noneString;
                    break;
                case FILETYPE.IMAGE:
                    filter = FileFilter.imageString;
                    break;
                case FILETYPE.OFFICE:
                    break;
                case FILETYPE.EXCEL:
                    filter = FileFilter.excelString;
                    break;
                case FILETYPE.WORD:
                    break;
                default:
                    break;
            }

            return filter;
        }
    }

    public enum FILETYPE 
    {
        NONE,
        IMAGE,
        OFFICE,
        EXCEL,
        WORD
    }

    public struct FileFilter 
    {
        //"xls files (*.xls; *.xlsx)|*.xls;*xlsx"
        public const string noneString = "All Files (*.*)|*.*";
        public const string imageString = "Image Files (*.png;*.gif;*.jpg;*.jpeg)|*.png;*.gif;*.jpg;*.jpeg";
        public const string excelString = "Excel Files (*.xls;*.xlsx)|*.xls;*xlsx";
    }
}
