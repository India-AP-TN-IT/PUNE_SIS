#region ▶ Description & History
/* 
 * 프로그램명 : 검사자 승인서 출력
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : ㅂ명희
 * 최종수정일 : 2013-12-10
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				-------------------------------------------------------------------------------------------------------------------------------------
 *				2013-12-10	    배명희		[#001] 검사자 승인서 출력물 양식 변경(QA41114.rpt)
 *				                                   조회조건 발행일자  ->  승인대상년도로 변경
 *				2015-07-28      배명희      통합WCF로 변경
 *				2017-06-22      배명희      Rexpert적용
 *
 * 
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using Ax.SIS.QA.QA09.UI;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>검사자 승인서</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-19 오후 7:36:04<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-19 오후 7:36:04   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA40114 : AxCommonBaseControl
    {
        //private IQA40114 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";

        #region [초기화 작업에 대한 정의]

        public QA40114()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA40114>("QA01", "QA40114.svc", "CustomBinding");
            //_WSCOMREPORT = ClientFactory.CreateChannel<IQAREPORT>("QA10", "QAREPORT.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                //this._buttonsControl.BtnPrint.Visible = true;
                this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                this._buttonsControl.BtnQuery.Visible = false;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cdx01_LINECD.HEPopupHelper = new QASubWindow();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("INSPECTOR_LINECD");// "검사원라인코드";
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx02_LINECD.HEPopupHelper = new QASubWindow();
                this.cdx02_LINECD.PopupTitle = this.GetLabel("INSPECTOR_LINECD");//"검사원라인코드";
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;

                //공장구분-------------------------------------------------------------------------
                DataTable source = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in source.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.cbo01_PLANT_DIV.DataBind(source, true);
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);
                //---------------------------------------------------------------------------------

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in groupBox_main.Controls)
            {
                if (ctl is IAxControl)
                {
                    ((IAxControl)ctl).Initialize();
                }
            }

            this.cdx_SETTING();
        }

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                CallReportQA41114();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void CallReportQA41114()
        {
            string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
            string DATE = this.dte01_ISS_DATE.GetDateText().Substring(0, 4);
            string FLINECD = this.cdx01_LINECD.GetValue().ToString();
            string TLINECD = this.cdx02_LINECD.GetValue().ToString();
            string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", _CORCD);
            paramSet.Add("BIZCD", BIZCD);
            paramSet.Add("DATE", DATE);             //[#001]
            paramSet.Add("FLINECD", FLINECD);
            paramSet.Add("TLINECD", TLINECD);
            paramSet.Add("LANG_SET", _LANG_SET);
            paramSet.Add("PLANT_DIV", PLANT_DIV);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40114P"), paramSet);

            HEParameterSet paramSet_CORNM = new HEParameterSet();
            paramSet_CORNM.Add("CORCD", _CORCD);
            paramSet_CORNM.Add("LANG_SET", _LANG_SET);

            //DataSet source_CORNM = _WSINQUERY.Inquery_CORNM(paramSet_CORNM);
            DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

            HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
            paramSet_BIZCDNM.Add("CORCD", _CORCD);
            paramSet_BIZCDNM.Add("BIZCD", BIZCD);
            paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);

            //DataSet source_BIZCDNM = _WSINQUERY.Inquery_BIZCDNM(paramSet_BIZCDNM);
            DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);

            HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
            report.ReportName = "RxRpt/QA41114E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
            source.Tables[0].TableName = "DATA";
            source.Tables[0].WriteXml("c:/temp/QA41114E.xml", XmlWriteMode.WriteSchema);
            /* 
                * 신규 리포트 또는 리포트 컬럼 변동시 디자인용 컬럼정의 XML 파일은 리포트 호출시 
                * 하기 코드를 이용하여 직접 생성하여 사용하세요 ( 주의. reb 파일을 먼저 report 하위에 생성후 아래 xml 파일을 생성하세요 )
                * 넘기고자 하는 DataSet 개체의 이름이 ds 라면
                * ds.Tables[0].TableName = "DATA";
                * ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
                * 생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 소스제어에 포함시켜 주세요. ( /Report 폴더 아래 )
                * */

            // Main Section ( 메인리포트 파라메터셋 )
            HERexSection mainSection = new HERexSection();
            mainSection.ReportParameter.Add("BEG_YMD", DATE);
            mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows.Count > 0 ? source_CORNM.Tables[0].Rows[0]["CORNM"].ToString() : string.Empty);
            mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows.Count > 0 ? source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString() : string.Empty);

            mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
            mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
            mainSection.ReportParameter.Add("TEAM_DIV", "");

            report.Sections.Add("MAIN", mainSection);
            HERexSection xmlSection = new HERexSection(source, new HEParameterSet());

            // 서브리포트의 리포트파람이 존재할경우 하기와 같이 정의
            // xmlSection.ReportParameter.Add("CORCD", "1000");
            report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
            AxRexpertReportViewer.ShowReport(report);


        }

        #endregion

        #region commented --
        //private void Print_Old()
        //{
        //    QA41114 report = new QA41114();

        //    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
        //    string DATE = this.dte01_ISS_DATE.GetValue().ToString();
        //    string FLINECD = this.cdx01_LINECD.GetValue().ToString();
        //    string TLINECD = this.cdx02_LINECD.GetValue().ToString();
        //    string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

        //    HEParameterSet paramSet = new HEParameterSet();
        //    paramSet.Add("CORCD", _CORCD);
        //    paramSet.Add("BIZCD", BIZCD);
        //    paramSet.Add("DATE", DATE);             //[#001]
        //    paramSet.Add("FLINECD", FLINECD);
        //    paramSet.Add("TLINECD", TLINECD);
        //    paramSet.Add("LANG_SET", _LANG_SET);
        //    paramSet.Add("PLANT_DIV", PLANT_DIV);

        //    this.BeforeInvokeServer(true);

        //    //DataSet source = _WSCOMREPORT.QA40114P(paramSet);
        //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40114P"), paramSet);

        //    report.SetDataSource(source.Tables[0]);

        //    HEParameterSet paramSet_CORNM = new HEParameterSet();
        //    paramSet_CORNM.Add("CORCD", _CORCD);
        //    paramSet_CORNM.Add("LANG_SET", _LANG_SET);

        //    //DataSet source_CORNM = _WSINQUERY.Inquery_CORNM(paramSet_CORNM);
        //    DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

        //    HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
        //    paramSet_BIZCDNM.Add("CORCD", _CORCD);
        //    paramSet_BIZCDNM.Add("BIZCD", BIZCD);
        //    paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);

        //    //DataSet source_BIZCDNM = _WSINQUERY.Inquery_BIZCDNM(paramSet_BIZCDNM);
        //    DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);

        //    this.SetParam(report, "BEG_YMD", DATE);
        //    this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //    this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //    this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //    this.SetParam(report, "EMPNAME", this.UserInfo.UserName);
        //    this.SetParam(report, "TEAM_DIV", "");

        //    this.AfterInvokeServer();

        //    this.ReportCall(report);
        //}

        //public void SetParam(CrystalDecisions.CrystalReports.Engine.ReportClass reportClass, string paramName, object value)
        //{
        //    CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition paramField = reportClass.DataDefinition.ParameterFields[paramName];
        //    CrystalDecisions.Shared.ParameterDiscreteValue discreteParam = new CrystalDecisions.Shared.ParameterDiscreteValue();
        //    discreteParam.Value = value;
        //    paramField.CurrentValues.Add(discreteParam);
        //    paramField.ApplyCurrentValues(paramField.CurrentValues);
        //}

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ] 

        private void cdx_SETTING()
        {
            try
            {
                //this.cdx01_LINECD.HEUserParameterSetValue("TITLE", "검사원라인코드");
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                //this.cdx02_LINECD.HEUserParameterSetValue("TITLE", "검사원라인코드");
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 이벤트 정의 ] 

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        #endregion
    }
}
