using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
//using Ax.SIS.CM.IF;
using HE.Framework.Core;
using HE.Framework.Windows.Forms;
using TheOne.ServiceModel;
using System.Globalization;
using System.Text.RegularExpressions;
using HE.Framework.ServiceModel;


namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// Ax.DEV.Utility에 사용하는 공용 기능으로 외부에 노출하지 않습니다.
    /// </summary>
    internal class AxStaticCommon
    {
        #region Description: 공용 메서드 모음        

        public static bool isTypeCodeLoaded = false;

        public static DataSet dsTypeCode;

        public static void GetTypeCode()
        {
            using (AxClientProxy proxy = new AxClientProxy())
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CLASS_ID", "");
                paramSet.Add("LANG_SET", StaticUserInfoContext.Language);
                dsTypeCode = proxy.ExecuteDataSet("APG_COMMON.INQUERY_TYPE_CODE", paramSet);
                isTypeCodeLoaded = true;
            }
        }

        /// <summary>
        /// 인자로 받은 날짜형태의 문자를 DateTime 타입으로 형변환하여 반환합니다.
        /// </summary>
        public static DateTime GetFromDateTime(object value)
        {

            System.Globalization.DateTimeFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            
            int year = 0;
            int month = 0;
            int day = 0;
            int hour = 0;
            int minute = 0;
            int second = 0;

            if (StaticUserInfoContext.Language.Equals("PL") && value.ToString().Length == 5)
                value = "2012-" + value;
            if (value.GetType() == typeof(DBNull))
                return new System.DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0);

            if (Regex.IsMatch(value.ToString(), "[0-9]{8}") || Regex.IsMatch(value.ToString(), "[0-9]{10}")  || Regex.IsMatch(value.ToString(), "[0-9]{12}")  || Regex.IsMatch(value.ToString(), "[0-9]{14}") )
            {
                string date = value.ToString().PadRight(14, '0');
                try
                {
                    year = int.Parse(date.Substring(0, 4));
                    month = int.Parse(date.Substring(4, 2));
                    day = int.Parse(date.Substring(6, 2));
                    hour = int.Parse(date.Substring(8, 2));
                    minute = int.Parse(date.Substring(10, 2));
                    second = int.Parse(date.Substring(12, 2));
                }
                catch
                {
                    throw new Exception(String.Format("Error!! value:{0}, date:{1}", value, date));
                }
                value = value.ToString().Replace('-', '/');
            }
            else
            {
                string  date = "19000101000000"; 
                
                if (value.ToString().Length > 0)
                    date = Convert.ToDateTime(value).ToString("yyyyMMddHHmmss");

                year = int.Parse(date.Substring(0, 4));
                month = int.Parse(date.Substring(4, 2));
                day = int.Parse(date.Substring(6, 2));
                hour = int.Parse(date.Substring(8, 2));
                minute = int.Parse(date.Substring(10, 2));
                second = int.Parse(date.Substring(12, 2));
            }

            return new System.DateTime(year==9999?9998:year, month, day, hour, minute, second);
        }

        /// <summary>
        /// 인자로 받은 날짜(문자형)를 년도내 주차정보 구해 반환합니다.
        /// </summary>
        public static int GetWeekOfYear(string sourceDate)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = Convert.ToDateTime(sourceDate);
            Calendar cal = dfi.Calendar;

            //return cal.GetWeekOfYear(date1, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            return cal.GetWeekOfYear(date1, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        /// <summary>
        /// 인자로 받은 시간간격을 TimeSpan 타입으로 형변환하여 반환합니다.
        /// </summary>
        public static TimeSpan GetFromTrimSpan(string span)
        {
            return TimeSpan.Parse(span);
        }

        /// <summary>
        /// 인자로 받은 value 값이 null 일 경우 replace 인자로 대처되어 반환됩니다.
        /// </summary>
        public static object Nvl(object value, object replace)
        {
            return (value == null) ? replace : value;
        }

        /// <summary>
        /// 인자로 받은 문자의 바이트 수를 반환합니다.
        /// </summary>
        public static int GetByteCount(string text)
        {
            return Encoding.Default.GetByteCount(AxStaticCommon.Nvl(text, "").ToString());
        }

        /// <summary>
        /// 인수로 받은 컬럼명들을 기준으로 하여 새로운 DataSet을 만들어 반환합니다.
        /// </summary>
        public static DataSet GetDataSourceSchema(params string[] parameters)
        {
            DataTable source = new DataTable();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].IndexOf("$") > -1)
                {
                    string[] temp = parameters[i].Split('$');
                    if (temp[0].Equals("CLOB"))
                    {
                        source.Columns.Add(parameters[i]);
                    }else
                    {
                        source.Columns.Add("$" + temp[1]);

                        switch (temp[0].ToUpper())
                        {
                            case "BLOB":
                                source.Columns[source.Columns.Count - 1].DataType = typeof(byte[]);
                                break;
                        }
                    }
                }
                else
                    source.Columns.Add(parameters[i]);
            }

            DataSet set = new DataSet();
            set.Tables.Add(source);

            return set;
        }

        /// <summary>
        /// HEUserControlBase 타입의 클래스를 윈도우로 노출합니다.
        /// </summary>
        public static Form ShowPopup(HEUserControlBase frm)
        {
            if ((frm.Location.X > 0) || (frm.Location.Y > 0))
                return ShowPopup(frm, FormStartPosition.Manual);

            return ShowPopup(frm, FormStartPosition.WindowsDefaultLocation);
        }

        /// <summary>
        /// HEUserControlBase 타입의 클래스를 윈도우로 노출합니다.
        /// 참고로 팝업 윈도우의 위치를 설정할 수 있습니다.
        /// <returns></returns>
        public static Form ShowPopup(HEUserControlBase frm, FormStartPosition pos)
        {
            Form win = new Form();

            win.StartPosition = pos;
            win.Location = frm.Location;

            frm.RequireAuthentication = false;
            frm.RequireAuthorization = false;

            win.Controls.Add(frm);
            win.Text = frm.Name;
            win.AutoSize = true;
            frm.Dock = DockStyle.Fill;
            win.ShowDialog();

            return win;
        }

        /// <summary>
        /// 본 프로젝트에서 사용하는 ReportClass 를 ReportViewer를 통해서 불러옵니다.
        /// </summary>
        //public static void ReportCall(ReportClass report)
        //{
        //    ReportViewer view = new ReportViewer(report);
        //    view.Show();
        //}

        #endregion

        #region Description: 공용 서비스 모음

        /// <summary>
        /// 클래스ID를 가지고 해당하는 유형코드를 반환합니다.
        /// </summary>
        public static DataSet GetTypeCode(string classID)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CLASS_ID", classID);
            set.Add("LANG_SET", StaticUserInfoContext.Language);


            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_TYPE_CODE", set);
            }
            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_Type_Code(set);
        }
        
        /// <summary>
        /// 인자로 받은 클래스ID의 수만큼의 유형코드를 반환합니다.
        /// </summary>
        public static DataSet GetTypeCode(params string[] classIDList)
        {
            DataTable table = new DataTable();
            table.Columns.Add("CLASS_ID");
            table.Columns.Add("LANG_SET");
            DataSet source = new DataSet();

            for (int i = 0; i < classIDList.Length; i++)
                table.Rows.Add(classIDList[i], StaticUserInfoContext.Language);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataTable table1 = new DataTable();
                dsTypeCode.Tables[0].DefaultView.RowFilter = " CLASS_ID = '" + table.Rows[i]["CLASS_ID"].ToString() + "'";

                table1 = dsTypeCode.Tables[0].DefaultView.ToTable().Copy();
                table1.TableName = String.Format("HEBIZ_TABLE{0}", i);

                source.Tables.Add(table1);
            }
            return source;
            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            
            //return common.Inquery_Type_Code_Set(set);
        }

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 라인코드를 반환합니다.
        /// </summary>
        public static DataSet GetLineCode()
        {
            return AxStaticCommon.GetLineCode(
                StaticUserInfoContext.CorporationCode,
                StaticUserInfoContext.BusinessCode,
                StaticUserInfoContext.Language);
        }

        /// <summary>
        /// 회사코드, 사업장, 언어를 조건으로 라인코드를 검색하여 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static DataSet GetLineCode(string corcd, string bizcd, string lang_set)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("LANG_SET", lang_set);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_LINECODE", set);
            }

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_LineCode(set);
        }

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 ALC 코드의 Partno를 반환합니다.
        /// </summary>
        //public sealed static DataSet GetALCCode_ByPartNo(string partNo)
        //{
        //    return HEStaticCommon.GetALCCode_ByPartNo(
        //        StaticHeUserInfoContext.CorporationCode,
        //        StaticHeUserInfoContext.BusinessCode,
        //        StaticHeUserInfoContext.Language,
        //        partNo);
        //}

        /// <summary>
        /// 회사코드, 사업장, 언어, Partno를 조건으로 ALC코드의 Partno를 검색하여 반환합니다.
        /// </summary>
        //public static DataSet GetALCCode_ByPartNo(string corcd, string bizcd, string lang_set, string partNo)
        //{
        //    HEParameterSet set = new HEParameterSet();
        //    set.Add("CORCD", corcd);
        //    set.Add("BIZCD", bizcd);
        //    set.Add("LANG_SET", lang_set);
        //    set.Add("PARTNO", partNo);

        //    ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
        //    return common.Inquery_AlcCode_By_PartNo(set);
        //}

        /// <summary>
        /// 한일이화의 회사코드를 반환합니다.
        /// </summary>
        public static DataSet GetCorCD()
        {
            /*
            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_CORCD");
            }
             */
            HEParameterSet set = new HEParameterSet();
            set.Add("LANG_SET", StaticUserInfoContext.Language);
            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_CORCD", set);
            }

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_Corcd();
        }

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 사업장코드를 반환합니다.
        /// </summary>
        public static DataSet GetBizCD()
        {
            return AxStaticCommon.GetBizCD(
                StaticUserInfoContext.CorporationCode);
        }

        /// <summary>
        /// 회사코드를 조건으로 검색하여 사업장코드를 반환합니다.
        /// </summary>
        public static DataSet GetBizCD(string corcd)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("LANG_SET", StaticUserInfoContext.Language);
            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_BIZCD", set);
            }

            //HEParameterSet set = new HEParameterSet();
            //set.Add("CORCD", corcd);

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_Bizcd(set);
        }

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 고객사코드를 반환합니다.
        /// </summary>
        public static DataSet GetCustCD()
        {
            return AxStaticCommon.GetCustCD(
                StaticUserInfoContext.CorporationCode);
        }

        /// <summary>
        /// 인자로 받은 회사코드를 조건으로 검색하여 고객사코드를 반환합니다.
        /// </summary>
        public static DataSet GetCustCD(string corcd)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("LANG_SET", StaticUserInfoContext.Language);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_CUSTCD", set);
            }


            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_Custcd(set);
        }

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 업체코드를 반환합니다.
        /// </summary>
        public static DataSet GetVendCD()
        {
            return AxStaticCommon.GetVendCD(
                StaticUserInfoContext.CorporationCode);
        }

        /// <summary>
        /// 회사코드를 조건으로 검색하여 업체코드를 반환합니다.
        /// </summary>
        public static DataSet GetVendCD(string corcd)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("LANG_SET", StaticUserInfoContext.Language);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_VENDCD", set);
            }
            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_Vendcd(set);
        }

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 야드번호를 반환합니다.
        /// </summary>
        public static DataSet GetYardNo()
        {
            return AxStaticCommon.GetYardNo(
                StaticUserInfoContext.CorporationCode,
                StaticUserInfoContext.BusinessCode);
        }

        /// <summary>
        /// 회사코드, 사업장코드를 조건으로 검색하여 야드번호를 반환합니다.
        /// </summary>
        public static DataSet GetYardNo(string corcd, string bizcd)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_YARDNO", set);
            }

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_YardNo(set);
        }

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 사원정보를 반환합니다.
        /// </summary>
        public static DataSet GetEmployeeNo()
        {
            return AxStaticCommon.GetEmployeeNo(
                StaticUserInfoContext.CorporationCode,
                StaticUserInfoContext.BusinessCode);
        }

        /// <summary>
        /// 회사코드, 사업자코드를 조건으로 검색하여 사원정보를 반환합니다.
        /// </summary>
        public static DataSet GetEmployeeNo(string corcd, string bizcd)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_EMPLOYEE", set);
            }
            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_Employee(set);
        }

        /// <summary>
        /// 인자로 받은 기간에 메뉴ID의 잠금유무를 bool 타입으로 반환합니다.
        /// </summary>
        public static bool GetIsLocked(string yymmFrom, string yymmTo, string menuid)
        {
            return AxStaticCommon.GetIsLocked(
                StaticUserInfoContext.CorporationCode,
                StaticUserInfoContext.BusinessCode,
                yymmFrom,
                yymmTo,
                menuid);
        }

        /// <summary>
        /// 회사코드, 사업장코드, 기간에 메뉴ID의 잠금유무를 bool 타입으로 반환합니다.
        /// </summary>
        public static bool GetIsLocked(string corcd, string bizcd, string yymmFrom, string yymmTo, string menuid)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("BEG_YYMM", yymmFrom);
            set.Add("END_YYMM", yymmTo);
            set.Add("MENUID", menuid);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                DataSet ds = proxy.ExecuteDataSet("APG_COMMON.IS_LOCK", set);

                if (ds.Tables[0].Rows[0]["LOCK_STA"].ToString().Equals("1"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.IsLocked(set);
        }

        /// <summary>
        /// 로그인 사용자의 회사정보와 인자로 받은 나머지 정보에 해당하는 어클리케이션폼ID를 반환합니다.
        /// </summary>
        public static DataSet GetAppformID(string program_id, string sector, bool runmode)
        {
            return AxStaticCommon.GetAppformID(
                StaticUserInfoContext.CorporationCode,
                program_id,
                sector,
                runmode);
        }

        /// <summary>
        /// 회사정보와 인자로 받은 나머지 정보에 해당하는 어클리케이션폼ID를 반환합니다.
        /// </summary>
        public static DataSet GetAppformID(string corcd, string program_id, string sector, bool runmode)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("PROGRAM_ID", program_id);
            set.Add("SECTOR", sector);
            set.Add("RUNMODE", runmode ? "1" : "0");

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_APPFORMID", set);
            }

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_AppformID(set);
        }

        /// <summary>
        /// 법인코드, 사업자코드를 조건으로 검색하여 공장정보를 반환합니다.
        /// </summary>
        //public static DataSet GetPlantcd(string corcd, string bizcd)
        //{
            //HEParameterSet set = new HEParameterSet();
            //set.Add("CORCD", corcd);
            //set.Add("BIZCD", bizcd);

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_Plantcd(set);
        //}

        ///// <summary>
        ///// 결재 윈도우 진행시 HEPS 시스템의 결재정보를 물류시스템에 반영합니다.
        ///// </summary>
        //public static void SetLegacyInstance(DataSet heps)
        //{
        //    using (AxClientProxy proxy = new AxClientProxy())
        //    {
        //        proxy.ExecuteNonQueryTx("APG_COMMON.SETSYSENVIROMENT", heps);
        //    }

        //    //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
        //    //common.Save_Legacy_Instance(heps);
        //}

        ///// <summary>
        ///// HEPS 시스템의 결재정보를 인자로 받아 물류시스템에 반영합니다.
        ///// </summary>
        //public static void SetLegacyInstance(string pid, string eid, string fid, string title, string legacy_key)
        //{
        //    DataSet heps = new DataSet();
        //    DataTable source = new DataTable();
        //    source.Columns.Add("PID");
        //    source.Columns.Add("EID");
        //    source.Columns.Add("FID");
        //    source.Columns.Add("REG_EMPNO");
        //    source.Columns.Add("TITLE");
        //    source.Columns.Add("LEGACY_KEY");
        //    source.Rows.Add(pid, eid, fid, StaticUserInfoContext.EmpNo, title, legacy_key);
        //    heps.Tables.Add(source);

        //    AxStaticCommon.SetLegacyInstance(heps);
        //}

        /// <summary>
        /// 시스템 환경정보를 반환합니다.
        /// </summary>
        public static string GetSysEnviroment(string section, string envname)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("SECTION", section);
            set.Add("ENVNAME", envname);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.GETSYSENVIROMENT", set).Tables[0].Rows[0][0].ToString();
            }

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.GetSysEnviroment(section, envname);
        }

        /// <summary>
        /// 시스템 환경정보를 설정합니다.
        /// </summary>
        public static void SetSysEnviroment(string section, string envname, string envvalue)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("SECTION", section);
            set.Add("ENVNAME", envname);
            set.Add("ENVVALUE", envvalue);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                proxy.ExecuteNonQueryTx("APG_COMMON.SETSYSENVIROMENT", set);
            }
            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //common.SetSysEnviroment(section, envname, envvalue);
        }

        /// <summary>
        /// 사용자 환경정보를 반환합니다.
        /// </summary>
        public static string GetUserEnviroment(string userid, string envname)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("USERID", userid);
            set.Add("ENVNAME", envname);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.GETUSERNVIROMENT", set).Tables[0].Rows[0][0].ToString();
            }
            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.GetUserEnviroment(userid, envname);
        }

        /// <summary>
        /// 사용자 환경정보를 설정합니다.
        /// </summary>
        public static void SetUserEnviroment(string userid, string envname, string envvalue)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("USERID", userid);
            set.Add("ENVNAME", envname);
            set.Add("ENVVALUE", envvalue);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                proxy.ExecuteNonQueryTx("APG_COMMON.SETUSEREVIROMENT", set);
            }

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //common.SetUserEnviroment(userid, envname, envvalue);
        }

        /// <summary>
        /// 리포트를 노출하는데 필요한 콤포넌트들이 설치되지 않았을 경우 설치할 수 있도록 유도합니다.
        /// </summary>
        public static void GetReportSetup()
        {
            //if (!System.IO.File.Exists(@"C:\Program Files\Business Objects\Common\2.8\bin\commonobjmodel.dll"))
            //{
            //    string DIR = @"C:\ReportViewer";
            //    string SETUP = @"C:\ReportViewer\setup.exe";
            //    string REPORTVIEWER = @"C:\ReportViewer\ReportViewer.msi";

            //    ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //    DataSet ds = common.Inquery_Report_Setup();

            //    byte[] Setup = (byte[])ds.Tables[0].Rows[0]["TEMP_FILE1"];
            //    byte[] ReportViewer = (byte[])ds.Tables[0].Rows[0]["TEMP_FILE2"];

            //    if (!Directory.Exists(DIR))
            //        Directory.CreateDirectory(DIR);

            //    int ArraySize = Setup.GetUpperBound(0);
            //    FileStream stream = new FileStream(SETUP, FileMode.OpenOrCreate, FileAccess.Write);
            //    stream.Write(Setup, 0, ArraySize + 1);
            //    stream.Close();

            //    ArraySize = ReportViewer.GetUpperBound(0);
            //    stream = new FileStream(REPORTVIEWER, FileMode.OpenOrCreate, FileAccess.Write);
            //    stream.Write(ReportViewer, 0, ArraySize + 1);
            //    stream.Close();


            //    StringBuilder builer = new StringBuilder();
            //    builer.Append("본 컴퓨터에는 리포트를 출력하는데 필요한 구성요소가 설치되지 않았습니다.\r\n\r\n");
            //    builer.Append("해당 메시지 창이 닫히면 자동으로 설치프로그램이 실행됩니다.\r\n\r\n\r\n\r\n");
            //    builer.Append("※ 다음버튼을 눌러 구성요소를 모두 설치 후 ERM을 다시 실행하시기 바랍니다.");
            //    MessageBox.Show(builer.ToString());

            //    System.Threading.Thread.Sleep(2000);

            //    while (!File.Exists(SETUP) || !File.Exists(REPORTVIEWER))
            //    {
            //        System.Threading.Thread.Sleep(1000);
            //    }

            //    while ((new FileInfo(SETUP)).Length != (long)519680 ||
            //           (new FileInfo(REPORTVIEWER)).Length != (long)84992)
            //    {
            //        System.Threading.Thread.Sleep(1000);
            //    }

            //    System.Diagnostics.Process.Start(SETUP);
            //    return;
            //}
        }

        /// <summary>
        /// 클래스ID를 가지고 해당하는 유형코드를 반환합니다.
        /// </summary>
        public static DataSet GetPlantDiv(string userid)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("USERID", userid);

            using (AxClientProxy proxy = new AxClientProxy())
            {
                return proxy.ExecuteDataSet("APG_COMMON.INQUERY_PLANT_DIV", set);
            }

            //ICommon common = ClientFactory.CreateChannel<ICommon>("CM", "Common.svc", "CustomBinding");
            //return common.Inquery_Plant_Div(set);
        }

        #endregion

        #region Description : 인사 공용 서비스 모음
        //★★###############################################################★★
        /// <summary>
        /// 클래스ID를 가지고 해당하는 유형코드를 반환합니다.
        /// </summary>
        //public static DataSet GetHRTypeName(string classID)
        //{
        //    HEParameterSet set = new HEParameterSet();
        //    set.Add("CLASS_ID", classID);
        //    set.Add("LANG_SET", StaticHeUserInfoContext.Language == "KO" ? "KOREAN" : StaticHeUserInfoContext.Language);

        //    IHRCommon common = ClientFactory.CreateChannel<IHRCommon>("CM", "HRCommon.svc", "CustomBinding");
        //    return common.Inquery_HR_Type_Name(set);
        //}

        /// <summary>
        /// 인자로 받은 클래스ID의 수만큼의 유형코드를 반환합니다.
        /// </summary>
        //public static DataSet GetHRTypeName(params string[] classIDList)
        //{
        //    DataSet set = new DataSet();
        //    DataTable table = new DataTable();
        //    set.Tables.Add(table);
        //    table.Columns.Add("CLASS_ID");
        //    table.Columns.Add("LANG_SET");

        //    for (int i = 0; i < classIDList.Length; i++)
        //        table.Rows.Add(classIDList[i], StaticHeUserInfoContext.Language == "KO" ? "KOREAN" : StaticHeUserInfoContext.Language); //

        //    IHRCommon common = ClientFactory.CreateChannel<IHRCommon>("CM", "HRCommon.svc", "CustomBinding");
        //    return common.Inquery_HR_Type_Name_Set(set);
        //}

        /// <summary>
        /// 클래스ID를 가지고 해당하는 유형코드를 반환합니다.
        /// </summary>
        //public static DataSet GetHRTypeCode(string classID)
        //{
        //    HEParameterSet set = new HEParameterSet();
        //    set.Add("CLASS_ID", classID);
        //    set.Add("LANG_SET", StaticHeUserInfoContext.Language == "KO" ? "KOREAN" : StaticHeUserInfoContext.Language);

        //    IHRCommon common = ClientFactory.CreateChannel<IHRCommon>("CM", "HRCommon.svc", "CustomBinding");
        //    return common.Inquery_HR_Type_Code(set);
        //}

        /// <summary>
        /// 인자로 받은 클래스ID의 수만큼의 유형코드를 반환합니다.
        /// </summary>
        //public static DataSet GetHRTypeCode(params string[] classIDList)
        //{
        //    DataSet set = new DataSet();
        //    DataTable table = new DataTable();
        //    set.Tables.Add(table);
        //    table.Columns.Add("CLASS_ID");
        //    table.Columns.Add("LANG_SET");

        //    for (int i = 0; i < classIDList.Length; i++)
        //        table.Rows.Add(classIDList[i], StaticHeUserInfoContext.Language == "KO" ? "KOREAN" : StaticHeUserInfoContext.Language); //

        //    IHRCommon common = ClientFactory.CreateChannel<IHRCommon>("CM", "HRCommon.svc", "CustomBinding");
        //    return common.Inquery_HR_Type_Code_Set(set);
        //}

        /// <summary>
        /// 클래스ID를 가지고 해당하는 유형코드를 반환합니다.
        /// </summary>
        //public static DataSet GetHRTypeObject(string classID)
        //{
        //    HEParameterSet set = new HEParameterSet();
        //    set.Add("CLASS_ID", classID);
        //    set.Add("LANG_SET", StaticHeUserInfoContext.Language == "KO" ? "KOREAN" : StaticHeUserInfoContext.Language);

        //    IHRCommon common = ClientFactory.CreateChannel<IHRCommon>("CM", "HRCommon.svc", "CustomBinding");
        //    return common.Inquery_HR_Type_Object(set);
        //}

        /// <summary>
        /// 인자로 받은 클래스ID의 수만큼의 유형코드를 반환합니다.
        /// </summary>
        //public static DataSet GetHRTypeObject(params string[] classIDList)
        //{
        //    DataSet set = new DataSet();
        //    DataTable table = new DataTable();
        //    set.Tables.Add(table);
        //    table.Columns.Add("CLASS_ID");
        //    table.Columns.Add("LANG_SET");

        //    for (int i = 0; i < classIDList.Length; i++)
        //        table.Rows.Add(classIDList[i], StaticHeUserInfoContext.Language == "KO" ? "KOREAN" : StaticHeUserInfoContext.Language); //

        //    IHRCommon common = ClientFactory.CreateChannel<IHRCommon>("CM", "HRCommon.svc", "CustomBinding");
        //    return common.Inquery_HR_Type_Object_Set(set);
        //}

        /// <summary>
        /// 회사코드를 조건으로 검색하여 사업장코드를 반환합니다.
        /// </summary>
        //public static DataSet GetHRBizCD(string corcd)
        //{
        //    HEParameterSet set = new HEParameterSet();
        //    set.Add("CORCD", corcd);

        //    IHRCommon common = ClientFactory.CreateChannel<IHRCommon>("CM", "HRCommon.svc", "CustomBinding");
        //    return common.Inquery_HR_Bizcd(set);
        //}

        //★★###############################################################★★
        #endregion
    }
}
