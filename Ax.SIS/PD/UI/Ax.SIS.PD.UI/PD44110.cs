
#region ▶ Description & History
/* 
 * 프로그램명 : PD44110 재고조사이동표 
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 진승모
 * 최종수정일 : 2014-10-08
 * 수정  내용 :
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------------------------------------------------
 *				2013-12-13	  배명희		[#001] 출력시 Inquery_PM44110_REPORT 호출할 때 날짜 파라메터 추가(화면에서 선택한 일자의 -365일 날짜 넘김) (BY MS SQL 성능 및 속도 문제)
 *              2014-10-08    진승모     다국어 적용 
 *              2015-01-07    배명희     [#002] 날짜 파라메터 전달시 -365로직 제거(프로시저에서 처리함.) (BY 오세민대리님)
 *              2017-07~09    배명희     SIS 이관
*/
#endregion


using System;
using System.Data;
using System.ServiceModel;
using System.Collections;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;


using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// </summary>
    public partial class PD44110 : AxCommonBaseControl
    {
        //private IPM44110 _WSCOM;
        //private IPM22110 _WSCOM_PM22110;
        private string PACKAGE_NAME = "APG_PD44110";
        private AxClientProxy _WSCOM;
        
        #region [ 초기화 작업 정의 ]

        public PD44110()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM44110>("PM04", "PM44110.svc", "CustomBinding");
            //_WSCOM_PM22110 = ClientFactory.CreateChannel<IPM22110>("PM02", "PM22110.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }        

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                this.rdo01_OPTION1_PD44110.Checked = true;
                rdo01_OPTION_CheckedChanged(null, null);

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); //new PM20015P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", ""); 
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.SetRequired(this.lbl01_LINECD);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cdx01_LINECD.IsEmpty)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text);
                    return;
                }
              
                HEParameterSet paramSet02 = new HEParameterSet();
                paramSet02.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet02.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet02.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet02.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());
                paramSet02.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                
                
                paramSet02.Add("SEL_OPT", "0");
                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_REPORT"), paramSet02); //_WSCOM.Inquery_REPORT(paramSet02);
                this.AfterInvokeServer();
                report.ReportName = "RxRpt/PD44111E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
                   


                    //PM44111 oRpt = new PM44111();

                    //oRpt.SetDataSource(source.Tables[0]);
                    //oRpt.SetParameterValue("EMPNO", this.UserInfo.EmpNo.ToString());
                    //oRpt.SetParameterValue("EMPNAME", this.UserInfo.UserName);
                    //oRpt.SetParameterValue("BIZ", this.UserInfo.DeptName);

                    //this.AfterInvokeServer();

                    //this.ReportCall(oRpt);
              
                source.Tables[0].TableName = "DATA";

                HERexSection mainSection = new HERexSection();
                mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
                mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
                mainSection.ReportParameter.Add("BIZ", this.UserInfo.DeptName);
                report.Sections.Add("MAIN", mainSection);
                HERexSection xmlSection = new HERexSection(source, new HEParameterSet());
                report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
                AxRexpertReportViewer.ShowReport(report);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void rdo01_OPTION_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void cdx01_LINECD_ButtonClickBefore(object sender, EventArgs args)
        {
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.Initialize();
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }

        #endregion
    }
}
