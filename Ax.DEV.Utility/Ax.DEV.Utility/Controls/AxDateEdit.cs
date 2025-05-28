using System;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// DateTimePicker 클래스를 상속받아 구현된 날짜박스입니다.
    /// </summary>
    public class AxDateEdit : DateTimePicker, IAxControl
    { 
        public AxDateEdit()
            : base()
        {
            this.MinDate = new DateTime(1900, 01, 01);
            this.MaxDate = new DateTime(9998, 12, 31);
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "yyyy-MM-dd";
            this.OriginalFormat = string.Empty;
            this.Size = new System.Drawing.Size(100, 21);
        }

        public string OriginalFormat
        {
            set;
            get;
        }

        public void SetLanguageCustomFormat()
        {
            SetFormat();
        }
        
        private void SetFormat()
        {
           
            System.Globalization.DateTimeFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            if (string.IsNullOrEmpty(OriginalFormat))
            {
                OriginalFormat = this.CustomFormat;
            }

            string shortTimePatten = format.ShortTimePattern;

            if (shortTimePatten.Equals("h tt")) shortTimePatten = "HH";
            if (shortTimePatten.Equals("h:mm tt")) shortTimePatten = "HH:mm";
            if (shortTimePatten.Equals("h:mm:ss tt")) shortTimePatten = "HH:mm:ss";

            shortTimePatten = shortTimePatten.Replace("tt", "").Trim();


            switch (this.OriginalFormat)
            {
                case "yyyy-MM-dd":
                    this.CustomFormat = format.ShortDatePattern;
                    break;
                case "yyyy-MM":
                    this.CustomFormat = format.ShortDatePattern.Replace("d.", "").Replace(".dd", "").Replace("dd.", "").Replace("-dd", "").Replace("dd-", "").Replace("/dd", "").Replace("dd/", "").Replace("d/", "").Replace("/d", "");
                    break;
                case "MM-dd":
                    this.CustomFormat = format.ShortDatePattern.Replace(". yyyy","").Replace(".yyyy", "").Replace("yyyy.", "").Replace("-yyyy", "").Replace("yyyy-", "").Replace("/yyyy", "").Replace("yyyy/", "");
                    break;
                case "dd":
                    this.CustomFormat = format.ShortDatePattern.Replace(". yyyy", "").Replace(".yyyy", "").Replace("yyyy.", "").Replace("-yyyy", "").Replace("yyyy-", "").Replace("/yyyy", "").Replace("yyyy/", "").Replace("M.", "").Replace(".MM", "").Replace("MM.", "").Replace("-MM", "").Replace("MM-", "").Replace("/MM", "").Replace("MM/", "").Replace("M/", "").Replace("/M", "");
                    break;
                case "HH:mm":
                    this.CustomFormat = "HH:mm"; //format.ShortTimePattern;
                    break;
                case "yyyy-MM-dd HH:mm:ss":
                    this.CustomFormat = format.ShortDatePattern + " " + shortTimePatten;
                    break;
                case "yyyy-MM-dd HH:mm":
                    this.CustomFormat = format.ShortDatePattern + " " + shortTimePatten;
                    break;
                case "yyyy-MM-dd HH":
                    this.CustomFormat = format.ShortDatePattern + " " + shortTimePatten;
                    break;
                case "yyyy":
                    //2015-04-30 mhlee 추가
                    this.CustomFormat = format.ShortDatePattern.Replace("M.d.", "").Replace(".MM.dd", "").Replace("MM.dd.", "").Replace("-MM-dd", "").Replace("MM-dd-", "").Replace("/MM/dd", "").Replace("MM/dd/", "").Replace("M/d/", "").Replace("/M/d", "");
                    break;
                default:
                    this.CustomFormat = format.ShortDatePattern;
                    break;
            }


            //if (StaticHeUserInfoContext.Language.Equals("EN"))
            //    switch (this.CustomFormat.ToUpper())
            //    {
            //        case "YYYY-MM":
            //            this.CustomFormat = "MM/yyyy";
            //            break;
            //        case "YYYY-MM-DD HH:MM":
            //            this.CustomFormat = "MM/dd/yyyy HH/mm";
            //            break;
            //        case "YYYY-MM-DD HH:MM:SS":
            //            this.CustomFormat = "MM/dd/yyyy HH/mm/ss";
            //            break;
            //        case "HH:MM":
            //            this.CustomFormat = "HH/mm";
            //            break;
            //        default:
            //            this.CustomFormat = "MM/dd/yyyy";
            //            break;
            //    }
            //else if (!(StaticHeUserInfoContext.Language.Equals("KO") || StaticHeUserInfoContext.Language.Equals("ZH") || StaticHeUserInfoContext.Language.Equals("PL")))
            //{
            //    switch (this.CustomFormat.ToUpper())
            //    {
            //        case "YYYY-MM":
            //            this.CustomFormat = "MM/yyyy";
            //            break;
            //        case "YYYY-MM-DD HH:MM":
            //            this.CustomFormat = "dd/MM/yyyy HH/mm";
            //            break;
            //        case "YYYY-MM-DD HH:MM:SS":
            //            this.CustomFormat = "dd/MM/yyyy HH/mm/ss";
            //            break;
            //        case "HH:MM":
            //            this.CustomFormat = "HH/mm";
            //            break;
            //        default:
            //            this.CustomFormat = "dd/MM/yyyy";
            //            break;
            //    }
            //}
        }

        #region IHEControl 멤버

        /// <summary>
        /// CustomFormat에 지정된 형태에 맞게끔 날짜를 문자로 반환합니다.
        /// </summary>
        public object GetValue()
        {
            if (this.Value == null) return "";

            if (this.CustomFormat.ToUpper().Equals("YYYY"))
                return ((DateTime)this.Value).ToString("yyyy");

            if (this.CustomFormat.ToUpper().Equals("YYYY-MM") ||
                this.CustomFormat.ToUpper().Equals("MM/YYYY") ||
                this.CustomFormat.ToUpper().Equals("M/YYYY"))
                return ((DateTime)this.Value).ToString("yyyy-MM");

            if (this.CustomFormat.ToUpper().Equals("YYYY-MM-DD HH:MM") ||
                this.CustomFormat.ToUpper().Equals("DD/MM/YYYY HH/MM"))
                return ((DateTime)this.Value).ToString("yyyyMMddHHmm");

            if (this.CustomFormat.ToUpper().Equals("YYYY-MM-DD HH:MM:SS") ||
                this.CustomFormat.ToUpper().Equals("DD/MM/YYYY HH/MM/SS"))
                return ((DateTime)this.Value).ToString("yyyyMMddHHmmss");

            if (this.CustomFormat.ToUpper().Equals("HH:MM") ||
                this.CustomFormat.ToUpper().Equals("HH/MM"))
                return ((DateTime)this.Value).ToString("HH:mm");
            
            return ((DateTime)this.Value).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 날짜형식의 문자를 입력받아 날짜박스에 설정합니다.
        /// </summary>
        public void SetValue(object value)
        {
            this.Value = AxStaticCommon.GetFromDateTime(value);
            SetFormat();
        }

        public void Initialize()
        {
            this.ResetText();
            SetFormat();
        }

        #endregion

        /// <summary>
        /// yyyyMMdd 형태로 날짜를 반환합니다.
        /// </summary>
        public string GetDateText()
        {
            return (this.Value == null || this.Text.Length == 0) ? "" : ((DateTime)this.Value).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// yyyyMMddHHmmss 형태로 날짜와 시간을 반환합니다.
        /// </summary>
        public string GetDateTimeText()
        {
            return (this.Value == null || this.Text.Length == 0) ? "" : ((DateTime)this.Value).ToString("yyyy-MM-ddHHmmss");
        }

        /// <summary>
        /// 현재 날짜를 날짜박스에 설정합니다.
        /// </summary>
        public void SetMMFromStart()
        {
            this.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
            SetFormat();
        }

        /// <summary>
        /// 현재 달의 마지막 날짜를 날짜박스에 설정합니다.
        /// </summary>
        public void SetMMFromEnd()
        {
            string date = AxStaticCommon.GetFromDateTime(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            this.SetValue(date);
        }

        /// <summary>
        /// 9998년 12월 31일을 날짜박스에 설정합니다.
        /// </summary>
        public void SetFromEnd()
        {
            this.SetValue("9998-12-31");
        }

        public void SetReadOnly(bool read)
        {
            this.Enabled = !read;
        }
    }
}
