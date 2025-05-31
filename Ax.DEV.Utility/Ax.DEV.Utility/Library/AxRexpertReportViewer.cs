using HE.Framework.Core.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TheOne.Configuration;
using System.Net;
using System.Diagnostics;

namespace Ax.DEV.Utility.Library
{
    public partial class AxRexpertReportViewer : Form
    {
        public enum Browser
        {
            InternalWebBrowser,
            DefaultWebBrowser
        }

        public AxRexpertReportViewer()
        {
            BrowserEmulation.SetBrowserFeatureControl();     // 웹브라우저 컨트롤이 IE 최신버전을 사용하도록 에뮬레이션
            InitializeComponent();
        }

        /// <summary>
        /// ShowReport
        /// </summary>
        /// <param name="report"></param>
        public static void ShowReport(HERexReport report, AxUserInfo userInfor = null)
        {
            AxRexpertReportViewer _Report = new AxRexpertReportViewer();
            _Report.InternalShowReport(report, Assembly.GetCallingAssembly(), false, Browser.DefaultWebBrowser, userInfor);
        }

        /// <summary>
        /// ShowReport
        /// </summary>
        /// <param name="report"></param>
        /// <param name="browserType"></param>
        public static void ShowReport(HERexReport report, AxRexpertReportViewer.Browser browserType, AxUserInfo userInfor = null)
        {
            AxRexpertReportViewer _Report = new AxRexpertReportViewer();
            _Report.InternalShowReport(report, Assembly.GetCallingAssembly(), false, browserType, userInfor);
        }

        /// <summary>
        /// ShowReport
        /// </summary>
        /// <param name="report"></param>
        /// <param name="directPdf"></param>
        public static void ShowReport(HERexReport report, bool directPdf, AxUserInfo userInfor = null)
        {
            AxRexpertReportViewer _Report = new AxRexpertReportViewer();
            _Report.InternalShowReport(report, Assembly.GetCallingAssembly(), directPdf, Browser.DefaultWebBrowser, userInfor);
        }

        /// <summary>
        /// ShowReport
        /// </summary>
        /// <param name="report"></param>
        /// <param name="directPdf"></param>
        /// <param name="browserType"></param>
        public static void ShowReport(HERexReport report, bool directPdf, AxRexpertReportViewer.Browser browserType, AxUserInfo userInfor = null)
        {
            AxRexpertReportViewer _Report = new AxRexpertReportViewer();
            _Report.InternalShowReport(report, Assembly.GetCallingAssembly(), directPdf, browserType, userInfor);
        }

        /// <summary>
        /// InternalShowReport
        /// </summary>
        /// <param name="report"></param>
        /// <param name="assembly"></param>
        /// <param name="directPdf"></param>
        /// <param name="browserType"></param>
        protected void InternalShowReport(HERexReport report, Assembly assembly, bool directPdf, AxRexpertReportViewer.Browser browserType, AxUserInfo userInfor = null)
        {
            // 리포트 파일 서버 전송모드일 경우 포함리소스로 부터 파일을 읽어서 Binary 에 담는다.
            if (report.ReportFileTransfer && (report.ReportFileData == null || report.ReportFileData.Length == 0))
            {
                byte[] buffer = null;
                Assembly _assembly = assembly;// Assembly.GetCallingAssembly();

                using (Stream _stream = _assembly.GetManifestResourceStream(_assembly.GetName().Name + "." + report.ReportName.Replace("/", ".") + ".reb"))
                {
                    buffer = new byte[_stream.Length];
                    _stream.Read(buffer, 0, buffer.Length);
                    _stream.Close();
                }

                report.ReportFileData = buffer;
            }
            
            // 문서 생성 URL 생성
            string dataString = String.Format("{0}={1}", HERexReport.Key, HERexReport.SerializeToString(report));
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(dataString);

            string report_AppSect = "REPORT_URL";
            string reportUrl = AppSectionFactory.AppSection["REPORT_URL"];

            if (userInfor != null)
            {
                if (userInfor.CorporationCode == "5000")
                {
                    report_AppSect = "REPORT_URL_" + userInfor.CorporationCode;
                    reportUrl = AppSectionFactory.AppSection[report_AppSect];
                }
            }
        
            
            if (directPdf)
            {
                if (reportUrl.IndexOf("?") >= 0)
                    reportUrl += "&mode=PDF";
                else
                    reportUrl += "?mode=PDF";
            }

            if (reportUrl.IndexOf("?") >= 0)
                reportUrl += "&locale=" + System.Globalization.CultureInfo.CurrentCulture.Name;
            else
                reportUrl += "?locale=" + System.Globalization.CultureInfo.CurrentCulture.Name;

            if (reportUrl.IndexOf("?") >= 0)
                reportUrl += "&ver=" + System.DateTime.Now.ToString("yyyyMMddHHmmss");
            else
                reportUrl += "?ver=" + System.Globalization.CultureInfo.CurrentCulture.Name;


            // 브라우저 종류에 따른 처리 방식 변경
            if (browserType == Browser.InternalWebBrowser)
            {
                // 호출방식 (내장브라우저)
                string header = "Content-Type: application/x-www-form-urlencoded\r\n";
                reportBrowser.Navigate(reportUrl, string.Empty, postData, header);
            }
            else
            {
                // 호출방식 (윈도우 기본 브라우저)
                if (reportUrl.IndexOf("?") >= 0)
                    reportUrl += "&open=self";
                else
                    reportUrl += "?open=self";

                // HttpWebRequest 생성
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(reportUrl);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;

                // 스트림 생성 ( Byte => Stream ) 및 리포트 서버에 데이터 전달
                using (Stream stDataParams = request.GetRequestStream())
                {
                    stDataParams.Write(postData, 0, postData.Length);
                    stDataParams.Close();
                }

                string result;

                // 요청 후 문서번호 응답 받기
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // 응답 스트림 읽기
                    using (Stream stReadData = response.GetResponseStream())
                    {
                        using (StreamReader srReadData = new StreamReader(stReadData, Encoding.UTF8, true))
                        {
                            // 응답 Stream => 문자열 반환
                            result = srReadData.ReadToEnd();
                            srReadData.Close();
                        }
                        stReadData.Close();
                    }
                    response.Close();
                }

                // 해당 문서 ID 로 브라우저 호출
                string printUrl = AppSectionFactory.AppSection[report_AppSect].Replace("ReportViewer.aspx", "RexPreview2.aspx");
                printUrl += "?id=" + result;

                Process.Start(printUrl);  // 시스템 기본 웹브라우저로 구동
            }
        }

        private void AxRexpertReportViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportBrowser.Dispose();
        }
    }
}
