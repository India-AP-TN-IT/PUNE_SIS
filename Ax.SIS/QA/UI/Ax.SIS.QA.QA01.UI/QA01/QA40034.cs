#region ▶ Description & History
/* 
 * 프로그램명 : QA40034 한도 견본 출력
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2015-07-28      배명희      통합WCF로 변경
 *              2017-06-22      배명희      Rexpert 적용
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>한도 견본 출력</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-31 오전 10:27:19<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-31 오전 10:27:19   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA40034 : AxCommonBaseControl
    {
        //private IQA40034 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";

        #region [초기화 작업에 대한 정의]

        public QA40034()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA40034>("QA01", "QA40034.svc", "CustomBinding");
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
                this._buttonsControl.BtnPrint.Visible = false;
                this._buttonsControl.BtnDownload.Visible = false;
                this._buttonsControl.BtnProcess.Visible = false;
                this._buttonsControl.BtnQuery.Visible = false;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo03_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo03_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo03_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo04_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo04_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo04_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo05_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo05_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo05_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;
                this.cbo02_BIZCD.Enabled = true;
                this.cbo03_BIZCD.Enabled = true;
                this.cbo04_BIZCD.Enabled = true;
                this.cbo05_BIZCD.Enabled = true;

                this.cdx02_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx02_CLASSCD.PopupTitle = this.GetLabel("SAMPLE_DIV_CODE");// "한도견본분류코드";
                this.cdx02_CLASSCD.CodeParameterName = "CLASSCD";
                this.cdx02_CLASSCD.NameParameterName = "CLASSNM";
                this.cdx02_CLASSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_CLASSCD.HEParameterAdd("BIZCD", "");
                this.cdx02_CLASSCD.HEParameterAdd("PLANT_DIV", "");
                this.cdx02_CLASSCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx03_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx03_CLASSCD.PopupTitle = this.GetLabel("SAMPLE_DIV_CODE");// "한도견본분류코드";
                this.cdx03_CLASSCD.CodeParameterName = "CLASSCD";
                this.cdx03_CLASSCD.NameParameterName = "CLASSNM";
                this.cdx03_CLASSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx03_CLASSCD.HEParameterAdd("BIZCD", "");
                this.cdx03_CLASSCD.HEParameterAdd("PLANT_DIV", "");
                this.cdx03_CLASSCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.cdx05_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx05_CLASSCD.PopupTitle = this.GetLabel("SAMPLE_DIV_CODE");// "한도견본분류코드";
                this.cdx05_CLASSCD.CodeParameterName = "CLASSCD";
                this.cdx05_CLASSCD.NameParameterName = "CLASSNM";
                this.cdx05_CLASSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx05_CLASSCD.HEParameterAdd("BIZCD", "");
                this.cdx05_CLASSCD.HEParameterAdd("PLANT_DIV", "");
                this.cdx05_CLASSCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.grd01_QA40034.Initialize();

                this.SetRequired(
                    lbl01_BIZNM, lbl02_BIZNM, lbl03_BIZNM, lbl04_BIZNM, lbl05_BIZNM, 
                    lbl02_CLASSCD, lbl03_CLASSCD, lbl05_CLASSCD, lbl02_FRONT_HALF_DATE, lbl02_REAR_HALF_DATE, 
                    lbl03_SET_BEG_DATE, lbl03_SET_END_DATE, lbl04_INSPECT_DATE, lbl04_NEXT_INSPECT_DATE);

                this.BtnReset_Click(null, null);
                this.chk05_APPUSE_YN.SetValue("Y");
                this.txt05_APPLINE.SetValue(this.GetSysEnviroment("APPLINE", "DEF_INC_QA"));

                this.rdo01_QA40034.SetValue("N");
                this.rdo02_QA40034.SetValue("Y");
                this.rdo03_QA40034.SetValue("N");

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

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
            this.dte02_DATE_FROM_FROM.Enabled = false;
            this.dte02_DATE_FROM_TO.Enabled = false;
            this.dte02_DATE_TO_FROM.Enabled = false;
            this.dte02_DATE_TO_TO.Enabled = false;
            this.dte03_DATE_FROM.Enabled = false;
            this.dte03_DATE_TO.Enabled = false;
            this.cdx02_CLASSCD.Initialize();
            this.cdx03_CLASSCD.Initialize();
            this.cdx05_CLASSCD.Initialize();

            this.cdx_SETTING();
        }

        #endregion

        #region [ 기타 이벤트 정의 ] 
        
        private void cdx02_CLASSCD_ButtonClickAfter(object sender, EventArgs args)
        {
            DataRow ROW = (DataRow)this.cdx02_CLASSCD.SelectedPopupValue;

            if (ROW["CHK_MGMTCYCLE_USE"].ToString() == "Y")
            {
                dte02_DATE_FROM_FROM.Enabled = true;
                dte02_DATE_FROM_TO.Enabled = true;
                dte02_DATE_TO_FROM.Enabled = true;
                dte02_DATE_TO_TO.Enabled = true;
            }
            else
            {
                dte02_DATE_FROM_FROM.Enabled = false;
                dte02_DATE_FROM_TO.Enabled = false;
                dte02_DATE_TO_FROM.Enabled = false;
                dte02_DATE_TO_TO.Enabled = false;
            }
        }

        private void cdx03_CLASSCD_ButtonClickAfter(object sender, EventArgs args)
        {
            DataRow ROW = (DataRow)this.cdx03_CLASSCD.SelectedPopupValue;

            if (ROW["CHK_MGMTCYCLE_USE"].ToString() == "Y")
            {
                dte03_DATE_FROM.Enabled = true;
                dte03_DATE_TO.Enabled = true;
            }
            else
            {
                dte03_DATE_FROM.Enabled = false;
                dte03_DATE_TO.Enabled = false;
            }
        }

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cbo03_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        private void cbo05_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }
        
        #region - 각종 검사구 한도견본 보유 집계 현황 "출력" -
        private void btn01_PRINT_Click(object sender, EventArgs e)
        {
            try
            {
                CallReportQA41034();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void CallReportQA41034()
        {
            string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
            string PRINT_DATE = this.dte01_DATE.GetDateText().ToString();

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", _CORCD);
            paramSet.Add("BIZCD", BIZCD);
            paramSet.Add("PRINT_DATE", PRINT_DATE);
            paramSet.Add("LANG_SET", _LANG_SET);

            string BOUT_YN = "";
            if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
            if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
            if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
            paramSet.Add("BOUT_YN", BOUT_YN);
            paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

            //this.BeforeInvokeServer(true);

            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T1"), paramSet);

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
            report.ReportName = "RxRpt/QA41034E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
            source.Tables[0].TableName = "DATA";
            //source.Tables[0].WriteXml("c:/temp/QA41034E.xml", XmlWriteMode.WriteSchema);
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
            mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows.Count > 0 ? source_CORNM.Tables[0].Rows[0]["CORNM"].ToString() : string.Empty);
            mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows.Count > 0 ? source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString() : string.Empty);

            mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
            mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
            report.Sections.Add("MAIN", mainSection);
            HERexSection xmlSection = new HERexSection(source, new HEParameterSet());

            // 서브리포트의 리포트파람이 존재할경우 하기와 같이 정의
            // xmlSection.ReportParameter.Add("CORCD", "1000");
            report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
            AxRexpertReportViewer.ShowReport(report);

        }
        #endregion

        #region -- commented --

        //public void SetParam(CrystalDecisions.CrystalReports.Engine.ReportClass reportClass, string paramName, object value)
        //{
        //    CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition paramField = reportClass.DataDefinition.ParameterFields[paramName];
        //    CrystalDecisions.Shared.ParameterDiscreteValue discreteParam = new CrystalDecisions.Shared.ParameterDiscreteValue();
        //    discreteParam.Value = value;
        //    paramField.CurrentValues.Add(discreteParam);
        //    paramField.ApplyCurrentValues(paramField.CurrentValues);
        //}


        //private void Print01_Old()
        //{
        //    QA41034 report = new QA41034();

        //    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
        //    string PRINT_DATE = this.dte01_DATE.GetValue().ToString();

        //    HEParameterSet paramSet = new HEParameterSet();
        //    paramSet.Add("CORCD", _CORCD);
        //    paramSet.Add("BIZCD", BIZCD);
        //    paramSet.Add("PRINT_DATE", PRINT_DATE);
        //    paramSet.Add("LANG_SET", _LANG_SET);

        //    string BOUT_YN = "";
        //    if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
        //    if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
        //    if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
        //    paramSet.Add("BOUT_YN", BOUT_YN);
        //    paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());


        //    this.BeforeInvokeServer(true);

        //    //DataSet source = _WSCOMREPORT.QA40034P_T1(paramSet);
        //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T1"), paramSet);

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

        //    this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //    this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //    this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //    this.SetParam(report, "EMPNAME", this.UserInfo.UserName);

        //    this.AfterInvokeServer();

        //    this.ReportCall(report);
        //}

        //private void Print02_Old()
        //{
        //    QA42034 report = new QA42034();

        //    string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
        //    string CLASSCD = this.cdx02_CLASSCD.GetValue().ToString();
        //    string FSETDATEF = "";
        //    string FSETDATET = "";
        //    string RSETDATEF = "";
        //    string RSETDATET = "";
        //    if (this.dte02_DATE_FROM_FROM.Enabled == true)
        //    {
        //        FSETDATEF = this.dte02_DATE_FROM_FROM.GetValue().ToString();
        //        FSETDATET = this.dte02_DATE_FROM_TO.GetValue().ToString();
        //        RSETDATEF = this.dte02_DATE_TO_FROM.GetValue().ToString();
        //        RSETDATET = this.dte02_DATE_TO_TO.GetValue().ToString();
        //    }
        //    string APPMODE = "N";

        //    HEParameterSet paramSet = new HEParameterSet();
        //    paramSet.Add("CORCD", _CORCD);
        //    paramSet.Add("BIZCD", BIZCD);
        //    paramSet.Add("CLASSCD", CLASSCD);
        //    paramSet.Add("FSETDATEF", FSETDATEF);
        //    paramSet.Add("FSETDATET", FSETDATET);
        //    paramSet.Add("RSETDATEF", RSETDATEF);
        //    paramSet.Add("RSETDATET", RSETDATET);
        //    paramSet.Add("APPMODE", APPMODE);
        //    paramSet.Add("LANG_SET", _LANG_SET);

        //    string BOUT_YN = "";
        //    if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
        //    if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
        //    if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
        //    paramSet.Add("BOUT_YN", BOUT_YN);
        //    paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

        //    this.BeforeInvokeServer(true);

        //    //DataSet source = _WSCOMREPORT.QA40034P_T2(paramSet);
        //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T2"), paramSet);

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

        //    this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //    this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //    this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //    this.SetParam(report, "EMPNAME", this.UserInfo.UserName);

        //    this.AfterInvokeServer();

        //    this.ReportCall(report);
        //}

        //private void Print03_Old()
        //{
        //    QA43034 report = new QA43034();

        //    string BIZCD = this.cbo03_BIZCD.GetValue().ToString();
        //    string CLASSCD = this.cdx03_CLASSCD.GetValue().ToString();
        //    string SETDATEF = "";
        //    string SETDATET = "";
        //    if (this.dte03_DATE_FROM.Enabled == true)
        //    {
        //        SETDATEF = this.dte03_DATE_FROM.GetValue().ToString();
        //        SETDATET = this.dte03_DATE_TO.GetValue().ToString();
        //    }

        //    HEParameterSet paramSet = new HEParameterSet();
        //    paramSet.Add("CORCD", _CORCD);
        //    paramSet.Add("BIZCD", BIZCD);
        //    paramSet.Add("CLASSCD", CLASSCD);
        //    paramSet.Add("SETDATEF", SETDATEF);
        //    paramSet.Add("SETDATET", SETDATET);
        //    paramSet.Add("LANG_SET", _LANG_SET);

        //    string BOUT_YN = "";
        //    if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
        //    if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
        //    if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
        //    paramSet.Add("BOUT_YN", BOUT_YN);
        //    paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

        //    this.BeforeInvokeServer(true);

        //    //DataSet source = _WSCOMREPORT.QA40034P_T3(paramSet);
        //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T3"), paramSet);

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

        //    this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //    this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //    this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //    this.SetParam(report, "EMPNAME", this.UserInfo.UserName);

        //    this.AfterInvokeServer();

        //    this.ReportCall(report);
        //}

        //private void Print04_Old()
        //{
        //    QA44034 report = new QA44034();

        //    string BIZCD = this.cbo04_BIZCD.GetValue().ToString();
        //    string INS_DATE = this.dte04_DATE_FROM.GetValue().ToString();
        //    string NXT_DATE = this.dte04_DATE_TO.GetValue().ToString();

        //    HEParameterSet paramSet = new HEParameterSet();
        //    paramSet.Add("CORCD", _CORCD);
        //    paramSet.Add("BIZCD", BIZCD);
        //    paramSet.Add("INS_DATE", INS_DATE);
        //    paramSet.Add("NXT_DATE", NXT_DATE);
        //    paramSet.Add("LANG_SET", _LANG_SET);
        //    paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

        //    this.BeforeInvokeServer(true);

        //    //DataSet source = _WSCOMREPORT.QA40034P_T4(paramSet);
        //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T4"), paramSet);

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

        //    this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //    this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //    this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //    this.SetParam(report, "EMPNAME", this.UserInfo.UserName);

        //    this.AfterInvokeServer();

        //    this.ReportCall(report);
        //}

        //private void Print05_Old()
        //{
        //    QA45034 report = new QA45034();

        //    string BIZCD = this.cbo05_BIZCD.GetValue().ToString();
        //    string CLASSCD = this.cdx05_CLASSCD.GetValue().ToString();

        //    HEParameterSet paramSet = new HEParameterSet();
        //    paramSet.Add("CORCD", _CORCD);
        //    paramSet.Add("BIZCD", BIZCD);
        //    paramSet.Add("CLASSCD", CLASSCD);
        //    paramSet.Add("LANG_SET", _LANG_SET);

        //    string BOUT_YN = "";
        //    if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
        //    if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
        //    if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
        //    paramSet.Add("BOUT_YN", BOUT_YN);
        //    paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

        //    this.BeforeInvokeServer(true);

        //    //DataSet source = _WSCOMREPORT.QA40034P_T5(paramSet);
        //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T5"), paramSet);

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

        //    this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //    this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //    this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //    this.SetParam(report, "EMPNAME", this.UserInfo.UserName);

        //    if (this.chk05_APPUSE_YN.GetValue().ToString() == "Y")
        //        this.SetParam(report, "APP_LINE", this.txt05_APPLINE.GetValue().ToString());
        //    else
        //        this.SetParam(report, "APP_LINE", "");

        //    this.AfterInvokeServer();

        //    this.ReportCall(report);
        //}
        #endregion

      


        #region - 각종 검사구 한도견본 보유 세부 내역서 "출력" -

        private void btn02_PRINT_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsPRINT02()) return;
                CallReportQA42034();
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void CallReportQA42034()
        {
            string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
            string CLASSCD = this.cdx02_CLASSCD.GetValue().ToString();
            string FSETDATEF = "";
            string FSETDATET = "";
            string RSETDATEF = "";
            string RSETDATET = "";
            if (this.dte02_DATE_FROM_FROM.Enabled == true)
            {
                FSETDATEF = this.dte02_DATE_FROM_FROM.GetDateText().ToString();
                FSETDATET = this.dte02_DATE_FROM_TO.GetDateText().ToString();
                RSETDATEF = this.dte02_DATE_TO_FROM.GetDateText().ToString();
                RSETDATET = this.dte02_DATE_TO_TO.GetDateText().ToString();
            }
            string APPMODE = "N";

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", _CORCD);
            paramSet.Add("BIZCD", BIZCD);
            paramSet.Add("CLASSCD", CLASSCD);
            paramSet.Add("FSETDATEF", FSETDATEF);
            paramSet.Add("FSETDATET", FSETDATET);
            paramSet.Add("RSETDATEF", RSETDATEF);
            paramSet.Add("RSETDATET", RSETDATET);
            paramSet.Add("APPMODE", APPMODE);
            paramSet.Add("LANG_SET", _LANG_SET);

            string BOUT_YN = "";
            if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
            if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
            if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
            paramSet.Add("BOUT_YN", BOUT_YN);
            paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T2"), paramSet);

            if (source.Tables[0].Rows.Count == 0)
            {
                MsgBox.Show("There is no data to print.");
                return;
            }

            HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
            report.ReportName = "RxRpt/QA42034E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
            source.Tables[0].TableName = "DATA";
            //source.Tables[0].WriteXml("c:/temp/QA42034E.xml", XmlWriteMode.WriteSchema);

            HEParameterSet paramSet_CORNM = new HEParameterSet();
            paramSet_CORNM.Add("CORCD", _CORCD);
            paramSet_CORNM.Add("LANG_SET", _LANG_SET);
            DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

            HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
            paramSet_BIZCDNM.Add("CORCD", _CORCD);
            paramSet_BIZCDNM.Add("BIZCD", BIZCD);
            paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);
            DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);

            // Main Section ( 메인리포트 파라메터셋 )
            HERexSection mainSection = new HERexSection();
            mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows.Count > 0 ? source_CORNM.Tables[0].Rows[0]["CORNM"].ToString() : string.Empty);
            mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows.Count > 0 ? source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString() : string.Empty);

            mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
            mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
            report.Sections.Add("MAIN", mainSection);
            HERexSection xmlSection = new HERexSection(source, new HEParameterSet());

            // 서브리포트의 리포트파람이 존재할경우 하기와 같이 정의
            // xmlSection.ReportParameter.Add("CORCD", "1000");
            report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
            AxRexpertReportViewer.ShowReport(report);

        }

        #endregion

        #region - 각종 검사구 한도견본 보유 세부 내역서 "Excel" -

        private void btn02_EXCEL_Click(object sender, EventArgs e)
        {
            try
            {
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string CLASSCD = this.cdx02_CLASSCD.GetValue().ToString();

                string FSETDATEF = "";
                string FSETDATET = "";
                string RSETDATEF = "";
                string RSETDATET = "";
                if (this.dte02_DATE_FROM_FROM.Enabled == true)
                {
                    FSETDATEF = this.dte02_DATE_FROM_FROM.GetDateText().ToString();
                    FSETDATET = this.dte02_DATE_FROM_TO.GetDateText().ToString();
                    RSETDATEF = this.dte02_DATE_TO_FROM.GetDateText().ToString();
                    RSETDATET = this.dte02_DATE_TO_TO.GetDateText().ToString();
                }
                string APPMODE = "Y";

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("CLASSCD", CLASSCD);
                paramSet.Add("FSETDATEF", FSETDATEF);
                paramSet.Add("FSETDATET", FSETDATET);
                paramSet.Add("RSETDATEF", RSETDATEF);
                paramSet.Add("RSETDATET", RSETDATET);
                paramSet.Add("APPMODE", APPMODE);
                paramSet.Add("LANG_SET", _LANG_SET);

                string BOUT_YN = "";
                if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
                if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
                if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
                paramSet.Add("BOUT_YN", BOUT_YN);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOMREPORT.QA40034P_T2(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T2"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.grd01_QA40034.Clear();

                    for (int i = 0; i < source.Tables[0].Columns.Count; i++)
                    {
                        this.grd01_QA40034.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, source.Tables[0].Columns[i].ToString(), source.Tables[0].Columns[i].ToString());
                    }

                    this.grd01_QA40034.SetValue(source);

                    this.saveFileDialog1.DefaultExt = "xls";
                    this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                    if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        string temp_file = this.saveFileDialog1.FileName;

                        this.grd01_QA40034.SaveExcel(temp_file);

                        FileFlags flags = FileFlags.IncludeFixedCells;
                        this.grd01_QA40034.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

                        //MsgBox.Show("다운로드가 완료되었습니다.");
                        MsgCodeBox.Show("CD00-0106");
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region - 각종 검사구 한도견본 조견표 출력 -

        private void btn03_PRINT_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsPRINT03()) return;
                CallReportQA43034();
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void CallReportQA43034()
        {
            string BIZCD = this.cbo03_BIZCD.GetValue().ToString();
            string CLASSCD = this.cdx03_CLASSCD.GetValue().ToString();
            string SETDATEF = "";
            string SETDATET = "";
            if (this.dte03_DATE_FROM.Enabled == true)
            {
                SETDATEF = this.dte03_DATE_FROM.GetDateText().ToString();
                SETDATET = this.dte03_DATE_TO.GetDateText().ToString();
            }

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", _CORCD);
            paramSet.Add("BIZCD", BIZCD);
            paramSet.Add("CLASSCD", CLASSCD);
            paramSet.Add("SETDATEF", SETDATEF);
            paramSet.Add("SETDATET", SETDATET);
            paramSet.Add("LANG_SET", _LANG_SET);

            string BOUT_YN = "";
            if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
            if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
            if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
            paramSet.Add("BOUT_YN", BOUT_YN);
            paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T3"), paramSet);

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
            report.ReportName = "RxRpt/QA43034E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
            source.Tables[0].TableName = "DATA";
            //source.Tables[0].WriteXml("c:/temp/QA43034E.xml", XmlWriteMode.WriteSchema);
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
            mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows.Count > 0 ? source_CORNM.Tables[0].Rows[0]["CORNM"].ToString() : string.Empty);
            mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows.Count > 0 ? source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString() : string.Empty);

            mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
            mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
            report.Sections.Add("MAIN", mainSection);
            HERexSection xmlSection = new HERexSection(source, new HEParameterSet());

            // 서브리포트의 리포트파람이 존재할경우 하기와 같이 정의
            // xmlSection.ReportParameter.Add("CORCD", "1000");
            report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
            AxRexpertReportViewer.ShowReport(report);


        }

        #endregion

        #region - 검사필증 출력 -

        private void btn04_PRINT_Click(object sender, EventArgs e)
        {
            try
            {
                CallReportQA44034();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void CallReportQA44034()
        {
            string BIZCD = this.cbo04_BIZCD.GetValue().ToString();
            string INS_DATE = this.dte04_DATE_FROM.GetDateText().ToString();
            string NXT_DATE = this.dte04_DATE_TO.GetDateText().ToString();

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", _CORCD);
            paramSet.Add("BIZCD", BIZCD);
            paramSet.Add("INS_DATE", INS_DATE);
            paramSet.Add("NXT_DATE", NXT_DATE);
            paramSet.Add("LANG_SET", _LANG_SET);
            paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T4"), paramSet);

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
            report.ReportName = "RxRpt/QA44034E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
            source.Tables[0].TableName = "DATA";
            //source.Tables[0].WriteXml("c:/temp/QA44034E.xml", XmlWriteMode.WriteSchema);
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
            mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows.Count > 0 ? source_CORNM.Tables[0].Rows[0]["CORNM"].ToString() : string.Empty);
            mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows.Count > 0 ? source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString() : string.Empty);

            mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
            mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
            report.Sections.Add("MAIN", mainSection);
            HERexSection xmlSection = new HERexSection(source, new HEParameterSet());

            // 서브리포트의 리포트파람이 존재할경우 하기와 같이 정의
            // xmlSection.ReportParameter.Add("CORCD", "1000");
            report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
            AxRexpertReportViewer.ShowReport(report);
        }

        #endregion

        #region - 각종 검사구 정기 점검표 출력 -

        private void btn05_PRINT_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsPRINT05()) return;

                CallReportQA45034();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void CallReportQA45034()
        {
            string BIZCD = this.cbo05_BIZCD.GetValue().ToString();
            string CLASSCD = this.cdx05_CLASSCD.GetValue().ToString();

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", _CORCD);
            paramSet.Add("BIZCD", BIZCD);
            paramSet.Add("CLASSCD", CLASSCD);
            paramSet.Add("LANG_SET", _LANG_SET);

            string BOUT_YN = "";
            if (this.rdo01_QA40034.GetValue().ToString() == "Y") BOUT_YN = "A";
            if (this.rdo02_QA40034.GetValue().ToString() == "Y") BOUT_YN = "N";
            if (this.rdo03_QA40034.GetValue().ToString() == "Y") BOUT_YN = "Y";
            paramSet.Add("BOUT_YN", BOUT_YN);
            paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40034P_T5"), paramSet);

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
            report.ReportName = "RxRpt/QA45034E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
            source.Tables[0].TableName = "DATA";
            //source.Tables[0].WriteXml("c:/temp/QA45034E.xml", XmlWriteMode.WriteSchema);
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
            mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows.Count > 0 ? source_CORNM.Tables[0].Rows[0]["CORNM"].ToString() : string.Empty);
            mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows.Count > 0 ? source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString() : string.Empty);

            mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
            mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
            if (this.chk05_APPUSE_YN.GetValue().ToString() == "Y")
                mainSection.ReportParameter.Add("EMAPP_LINEPNAME", this.txt05_APPLINE.GetValue().ToString());
            else
                mainSection.ReportParameter.Add("EMAPP_LINEPNAME", "");


            report.Sections.Add("MAIN", mainSection);
            HERexSection xmlSection = new HERexSection(source, new HEParameterSet());

            // 서브리포트의 리포트파람이 존재할경우 하기와 같이 정의
            // xmlSection.ReportParameter.Add("CORCD", "1000");
            report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
            AxRexpertReportViewer.ShowReport(report);

        }

        #endregion

        #endregion

        #region [유효성 검사]

        
        private bool IsPRINT02()
        {
            try
            {
                string CLASSCD = this.cdx02_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(CLASSCD) == 0)
                {
                    //MsgBox.Show("분류코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_CLASSCD.Text);
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

        private bool IsPRINT03()
        {
            try
            {
                string CLASSCD = this.cdx03_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(CLASSCD) == 0)
                {
                    //MsgBox.Show("분류코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl03_CLASSCD.Text);
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

        private bool IsPRINT05()
        {
            try
            {
                string CLASSCD = this.cdx05_CLASSCD.GetValue().ToString();

                if (this.GetByteCount(CLASSCD) == 0)
                {
                    //MsgBox.Show("분류코드가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl05_CLASSCD.Text);
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
                this.cdx02_CLASSCD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue().ToString());
                this.cdx03_CLASSCD.HEUserParameterSetValue("BIZCD", this.cbo03_BIZCD.GetValue().ToString());
                this.cdx05_CLASSCD.HEUserParameterSetValue("BIZCD", this.cbo05_BIZCD.GetValue().ToString());

                this.cdx02_CLASSCD.HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                this.cdx03_CLASSCD.HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                this.cdx05_CLASSCD.HEUserParameterSetValue("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
