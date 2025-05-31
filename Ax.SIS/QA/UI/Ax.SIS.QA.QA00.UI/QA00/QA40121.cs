#region ▶ Description & History
/* 
 * 프로그램명 : QA40121 공정불량 현황 출력
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2015-07-24      배명희      통합WCF로 변경
 *				2017-06-22      배명희      Rexpert적용  
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>공정불량 현황 출력</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-19 오후 7:36:04<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-19 오후 7:36:04   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA40121 : AxCommonBaseControl
    {
        //private IQA40121 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";

        #region [ 초기화 작업 정의 ]

        public QA40121()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA40121>("QA00", "QA40121.svc", "CustomBinding");
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

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.19 공장구분 조회조건 추가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.cbo01_BIZCD.Enabled = true;

                this.BtnReset_Click(null, null);
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
                if (ctl.Name.Equals("cbo01_PLANT_DIV")) continue;
                

                if (ctl is IAxControl)
                {
                    
                    ((IAxControl)ctl).Initialize();
                }
            }

            this.opt01_BY_VENDER.SetValue(true);
        }

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Print();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        private void Print()
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string BEG_DATE = this.dte01_DATE_FROM.GetDateText().ToString();
                string END_DATE = this.dte01_DATE_TO.GetDateText().ToString();
                string PRINT_TYPE = "";
                string PRINTSPLIT = this.chk01_PRINT_GUBN.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  // 공장구분 추가

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("BEG_DATE", BEG_DATE);
                paramSet.Add("END_DATE", END_DATE);
                paramSet.Add("PRINT_TYPE", PRINT_TYPE);
                paramSet.Add("LANG_SET", _LANG_SET);

                paramSet.Add("PLANT_DIV", PLANT_DIV);       // 공장구분 추가

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40121P"), paramSet);

                HEParameterSet paramSet_CORNM = new HEParameterSet();
                paramSet_CORNM.Add("CORCD", _CORCD);
                paramSet_CORNM.Add("LANG_SET", _LANG_SET);
                DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

                HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
                paramSet_BIZCDNM.Add("CORCD", _CORCD);
                paramSet_BIZCDNM.Add("BIZCD", BIZCD);
                paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);
                DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);

                this.AfterInvokeServer();

                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);

                if (this.opt01_BY_VENDER.GetValue().ToString() == "Y")
                {
                    PRINT_TYPE = "VENDCD";
                    report.ReportName = "RxRpt/QA41121E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
                    source.Tables[0].TableName = "DATA";
                    //source.Tables[0].WriteXml("c:/temp/QA41121.xml", XmlWriteMode.WriteSchema);

                    /* 
                      * 신규 리포트 또는 리포트 컬럼 변동시 디자인용 컬럼정의 XML 파일은 리포트 호출시 
                      * 하기 코드를 이용하여 직접 생성하여 사용하세요 ( 주의. reb 파일을 먼저 report 하위에 생성후 아래 xml 파일을 생성하세요 )
                      * 넘기고자 하는 DataSet 개체의 이름이 ds 라면
                      * ds.Tables[0].TableName = "DATA";
                      * ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
                      * 생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 소스제어에 포함시켜 주세요. ( /Report 폴더 아래 )
                      */


                }
                else
                {
                    PRINT_TYPE = "VINCD";
                    report.ReportName = "RxRpt/QA42121E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
                    source.Tables[0].TableName = "DATA";
                    //source.Tables[0].WriteXml("c:/temp/QA42121.xml", XmlWriteMode.WriteSchema);

                    /* 
                      * 신규 리포트 또는 리포트 컬럼 변동시 디자인용 컬럼정의 XML 파일은 리포트 호출시 
                      * 하기 코드를 이용하여 직접 생성하여 사용하세요 ( 주의. reb 파일을 먼저 report 하위에 생성후 아래 xml 파일을 생성하세요 )
                      * 넘기고자 하는 DataSet 개체의 이름이 ds 라면
                      * ds.Tables[0].TableName = "DATA";
                      * ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
                      * 생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 소스제어에 포함시켜 주세요. ( /Report 폴더 아래 )
                      */


                }
                // Main Section ( 메인리포트 파라메터셋 )
                HERexSection mainSection = new HERexSection(source, new HEParameterSet());


                mainSection.ReportParameter.Add("BEG_YMD", BEG_DATE);
                mainSection.ReportParameter.Add("END_YMD", END_DATE);
                mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
                mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
                mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
                mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
                mainSection.ReportParameter.Add("PAPERSPLIT", PRINTSPLIT);


                report.Sections.Add("MAIN", mainSection);

                AxRexpertReportViewer.ShowReport(report);

            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }

        #endregion

        //private void Print_old()
        //{
        //    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
        //    string BEG_DATE = this.dte01_DATE_FROM.GetValue().ToString();
        //    string END_DATE = this.dte01_DATE_TO.GetValue().ToString();
        //    string PRINT_TYPE = "";
        //    string PRINTSPLIT = this.chk01_PRINT_GUBN.GetValue().ToString();

        //    string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  // 공장구분 추가

        //    HEParameterSet paramSet = new HEParameterSet();
        //    paramSet.Add("CORCD", _CORCD);
        //    paramSet.Add("BIZCD", BIZCD);
        //    paramSet.Add("BEG_DATE", BEG_DATE);
        //    paramSet.Add("END_DATE", END_DATE);
        //    paramSet.Add("PRINT_TYPE", PRINT_TYPE);
        //    paramSet.Add("LANG_SET", _LANG_SET);

        //    paramSet.Add("PLANT_DIV", PLANT_DIV);       // 공장구분 추가

        //    this.BeforeInvokeServer(true);

        //    //DataSet source = _WSCOMREPORT.QA40121P(paramSet);
        //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40121P"), paramSet);

        //    Object report;

        //    if (this.opt01_BY_VENDER.GetValue().ToString() == "Y")
        //    {
        //        report = new QA41121();
        //        PRINT_TYPE = "VENDCD";
        //        ((QA41121)report).SetDataSource(source.Tables[0]);
        //    }
        //    else
        //    {
        //        report = new QA42121();
        //        PRINT_TYPE = "VINCD";
        //        ((QA42121)report).SetDataSource(source.Tables[0]);
        //    }

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

        //    this.AfterInvokeServer();

        //    if (this.opt01_BY_VENDER.GetValue().ToString() == "Y")
        //    {
        //        this.SetParam(((QA41121)report), "BEG_YMD", BEG_DATE);
        //        this.SetParam(((QA41121)report), "END_YMD", END_DATE);
        //        this.SetParam(((QA41121)report), "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //        this.SetParam(((QA41121)report), "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //        this.SetParam(((QA41121)report), "EMPNO", this.UserInfo.EmpNo);
        //        this.SetParam(((QA41121)report), "EMPNAME", this.UserInfo.UserName);
        //        this.SetParam(((QA41121)report), "PAPERSPLIT", PRINTSPLIT);

        //        this.ReportCall(((QA41121)report));
        //    }
        //    else
        //    {
        //        this.SetParam(((QA42121)report), "BEG_YMD", BEG_DATE);
        //        this.SetParam(((QA42121)report), "END_YMD", END_DATE);
        //        this.SetParam(((QA42121)report), "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //        this.SetParam(((QA42121)report), "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //        this.SetParam(((QA42121)report), "EMPNO", this.UserInfo.EmpNo);
        //        this.SetParam(((QA42121)report), "EMPNAME", this.UserInfo.UserName);
        //        this.SetParam(((QA42121)report), "PAPERSPLIT", PRINTSPLIT);

        //        this.ReportCall(((QA42121)report));
        //    }
        //}

        //public void SetParam(CrystalDecisions.CrystalReports.Engine.ReportClass reportClass, string paramName, object value)
        //{
        //    CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition paramField = reportClass.DataDefinition.ParameterFields[paramName];
        //    CrystalDecisions.Shared.ParameterDiscreteValue discreteParam = new CrystalDecisions.Shared.ParameterDiscreteValue();
        //    discreteParam.Value = value;
        //    paramField.CurrentValues.Add(discreteParam);
        //    paramField.ApplyCurrentValues(paramField.CurrentValues);
        //}

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {

                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

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
    }
}
