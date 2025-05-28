#region ▶ Description & History
/* 
 * 프로그램명 : QA30115 입고불량유효성평가결과 조회 및 출력 상세
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
 *				2017-06-19      배명희      크리스탈리포트 → Rexpert로 컨버전 (Report_View_Rexpert)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using System.Drawing;
using HE.Framework.ServiceModel;
using System.Diagnostics;
using TheOne.Net;
using HE.Framework.Core.Report;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>입고불량유효성평가결과 조회 및 출력 상세</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 5:34:21<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 5:34:21   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30115 : AxCommonBaseControl
    {
        //private IQA20115 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;
        private String _BIZCD_T;
        private String _RCV_DATE_T;
        private String _DEFNO_T;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20115";
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";

        #region [ 초기화 작업 정의 ]

        public QA30115()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20115>("QA00", "QA20115.svc", "CustomBinding");
            //_WSCOMREPORT = ClientFactory.CreateChannel<IQAREPORT>("QA10", "QAREPORT.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            _BIZCD_T = "";
            _DEFNO_T = "";
            _RCV_DATE_T = "";
        }

        public QA30115(string BIZCD, string RCV_DATE, string DEFNO)
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20115>("QA00", "QA20115.svc", "CustomBinding");
            //_WSCOMREPORT = ClientFactory.CreateChannel<IQAREPORT>("QA10", "QAREPORT.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            _BIZCD_T = BIZCD;
            _DEFNO_T = DEFNO;
            _RCV_DATE_T = RCV_DATE;
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
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                DataSet source = this.GetTypeCode("F1", "II", "IW");
                this.cbo02_VER_4M_TYPE.DataBind(source.Tables[0], true);
                this.cbo02_VER_4M_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_VER1_CHKRSLT_TYPE.DataBind(source.Tables[1], true);
                this.cbo02_VER1_CHKRSLT_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_VER1_CHKRSLT_TYPE2.DataBind(source.Tables[2], true);
                this.cbo02_VER1_CHKRSLT_TYPE2.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source1 = new DataTable();
                combo_source1.Columns.Add("CODE");
                combo_source1.Columns.Add("NAME");
                combo_source1.Rows.Add("Y", this.GetLabel("COMPLETE"));//"완료");
                combo_source1.Rows.Add("N", this.GetLabel("NOT_COMPLETE"));//"미결");
                this.cbo02_VER2_CHKRSLT.DataBind(combo_source1);
                this.cbo02_VER2_CHKRSLT.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source2 = new DataTable();
                combo_source2.Columns.Add("CODE");
                combo_source2.Columns.Add("NAME");
                combo_source2.Rows.Add("Y", this.GetLabel("EXIST"));//"유");
                combo_source2.Rows.Add("N", this.GetLabel("NOT_EXIST"));//"무");
                this.cbo02_VER2_AMEND_RSLT.DataBind(combo_source2);
                this.cbo02_VER2_AMEND_RSLT.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source3 = new DataTable();
                combo_source3.Columns.Add("CODE");
                combo_source3.Columns.Add("NAME");
                combo_source3.Rows.Add("Y", this.GetLabel("NECESSARY"));//"필요");
                combo_source3.Rows.Add("N", this.GetLabel("NOT_NECESSARY"));//"불필요");
                this.cbo02_ADD_AMEND_APPLY_YN.DataBind(combo_source3);
                this.cbo02_ADD_AMEND_APPLY_YN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx02_VER2_CHK_EMPNO.HEPopupHelper = new QASubWindow();
                this.cdx02_VER2_CHK_EMPNO.PopupTitle = this.GetLabel("EMPNO");//"사원코드";
                this.cdx02_VER2_CHK_EMPNO.CodeParameterName = "EMPNO";
                this.cdx02_VER2_CHK_EMPNO.NameParameterName = "EMPNONM";
                this.cdx02_VER2_CHK_EMPNO.HEParameterAdd("CORCD", _CORCD);
                this.cdx02_VER2_CHK_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.pic02_FILE_DATA1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_FILE_DATA2.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_AFILE_DATA1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pic02_AFILE_DATA2.SizeMode = PictureBoxSizeMode.Zoom;

                this.cdx02_VER2_CHK_EMPNO.SetReadOnly(true);

                this.BtnReset_Click(null, null);
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
            try
            {
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                pic02_FILE_DATA1.Initialize();
                pic02_FILE_DATA2.Initialize();
                pic02_AFILE_DATA1.Initialize();
                pic02_AFILE_DATA2.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", _BIZCD_T);
                paramSet.Add("RCV_DATE", _RCV_DATE_T);
                paramSet.Add("DEFNO", _DEFNO_T);
                paramSet.Add("LANG_SET", _LANG_SET);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.txt02_VER2_CHK_DETAIL.SetValue(source.Tables[0].Rows[0]["VER2_CHK_DETAIL"].ToString());
                    this.cdx02_VER2_CHK_EMPNO.SetValue(source.Tables[0].Rows[0]["VER2_CHK_EMPNO"].ToString());
                    this.cbo02_VER2_AMEND_RSLT.SetValue(source.Tables[0].Rows[0]["VER2_AMEND_RSLT"].ToString());
                    this.cbo02_VER2_CHKRSLT.SetValue(source.Tables[0].Rows[0]["VER2_CHKRSLT"].ToString());
                    this.txt02_VER2_CHK_DATE.SetValue(source.Tables[0].Rows[0]["VER2_CHK_DATE"].ToString());
                    this.cbo02_VER1_CHKRSLT_TYPE2.SetValue(source.Tables[0].Rows[0]["VER1_CHKRSLT_TYPE2"].ToString());
                    this.cbo02_VER1_CHKRSLT_TYPE.SetValue(source.Tables[0].Rows[0]["VER1_CHKRSLT_TYPE"].ToString());
                    this.txt02_AMEND_CNTT.SetValue(source.Tables[0].Rows[0]["AMEND_CNTT"].ToString());
                    this.txt02_OCCUR_CNTT.SetValue(source.Tables[0].Rows[0]["OCCUR_CNTT"].ToString());
                    this.txt02_VER1_CHK_DATE.SetValue(source.Tables[0].Rows[0]["VER1_CHK_DATE"].ToString());
                    this.txt02_AMEND_DATE.SetValue(source.Tables[0].Rows[0]["AMEND_DATE"].ToString());
                    this.cbo02_VER_4M_TYPE.SetValue(source.Tables[0].Rows[0]["VER_4M_TYPE"].ToString());
                    this.cbo02_ADD_AMEND_APPLY_YN.SetValue(source.Tables[0].Rows[0]["ADD_AMEND_APPLY_YN"].ToString());
                    this.txt02_ADD_AMEND_CNTT.SetValue(source.Tables[0].Rows[0]["ADD_AMEND_CNTT"].ToString());

                    this.IMAGE_VIEW(_BIZCD_T, _RCV_DATE_T, _DEFNO_T);

                    //this.Report_View("2");
                    //this.Report_View_Rexpert("2"); //Rexpert 로 미리보기는 미완성... 기존대로 CrystalReport 호출
                }
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

        //protected override void BtnPrint_Click(object sender, EventArgs e)
        //{
            //this.Report_View("1");
           // this.Report_View_Rexpert();//Rexpert 호출  글로벌표준 출력기능 제거 2018.01.18
        //}

        #endregion

        #region [ 사용자 정의 메서드 ]

        //public void SetParam(CrystalDecisions.CrystalReports.Engine.ReportClass reportClass, string paramName, object value)
        //{
        //    CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition paramField = reportClass.DataDefinition.ParameterFields[paramName];
        //    CrystalDecisions.Shared.ParameterDiscreteValue discreteParam = new CrystalDecisions.Shared.ParameterDiscreteValue();
        //    discreteParam.Value = value;
        //    paramField.CurrentValues.Add(discreteParam);
        //    paramField.ApplyCurrentValues(paramField.CurrentValues);
        //}

        //Rexpert 호출 (미리보기 기능은 미완성)
        private void Report_View_Rexpert()
        {
            try
            {

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", _BIZCD_T);
                paramSet.Add("RCVDATE", _RCV_DATE_T);
                paramSet.Add("DEFNO", _DEFNO_T);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA30115P"), paramSet);

                HEParameterSet paramSet_CORNM = new HEParameterSet();
                paramSet_CORNM.Add("CORCD", _CORCD);
                paramSet_CORNM.Add("LANG_SET", _LANG_SET);
                DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

                HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
                paramSet_BIZCDNM.Add("CORCD", _CORCD);
                paramSet_BIZCDNM.Add("BIZCD", _BIZCD_T);
                paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);
                DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);



                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/QA30115E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
                source.Tables[0].TableName = "DATA";
                //source.Tables[0].WriteXml("c:/temp/QA30115.xml", XmlWriteMode.WriteSchema);

                /* 
                    * 신규 리포트 또는 리포트 컬럼 변동시 디자인용 컬럼정의 XML 파일은 리포트 호출시 
                    * 하기 코드를 이용하여 직접 생성하여 사용하세요 ( 주의. reb 파일을 먼저 report 하위에 생성후 아래 xml 파일을 생성하세요 )
                    * 넘기고자 하는 DataSet 개체의 이름이 ds 라면
                    * ds.Tables[0].TableName = "DATA";
                    * ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
                    * 생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 소스제어에 포함시켜 주세요. ( /Report 폴더 아래 )
                    * */

                // Main Section ( 메인리포트 파라메터셋 )
                HERexSection mainSection = new HERexSection(source, new HEParameterSet());

                mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
                mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
                mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
                mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
                report.Sections.Add("MAIN", mainSection);


                this.AfterInvokeServer();


                // 서브리포트의 리포트파람이 존재할경우 하기와 같이 정의
                // xmlSection.ReportParameter.Add("CORCD", "1000");
                // report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
                AxRexpertReportViewer.ShowReport(report);



            }

            catch (Exception ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }


        //private void Report_View(string GUBN)
        //{
        //    try
        //    {
        //        QA31115 report = new QA31115();

        //        HEParameterSet paramSet = new HEParameterSet();
        //        paramSet.Add("CORCD", _CORCD);
        //        paramSet.Add("BIZCD", _BIZCD_T);
        //        paramSet.Add("RCVDATE", _RCV_DATE_T);
        //        paramSet.Add("DEFNO", _DEFNO_T);
        //        paramSet.Add("LANG_SET", _LANG_SET);

        //        this.BeforeInvokeServer(true);

        //        //DataSet source = _WSCOMREPORT.QA30115P(paramSet);
        //        DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA30115P"), paramSet);

        //        report.SetDataSource(source.Tables[0]);

        //        HEParameterSet paramSet_CORNM = new HEParameterSet();
        //        paramSet_CORNM.Add("CORCD", _CORCD);
        //        paramSet_CORNM.Add("LANG_SET", _LANG_SET);

        //        //DataSet source_CORNM = _WSINQUERY.Inquery_CORNM(paramSet_CORNM);
        //        DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

        //        HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
        //        paramSet_BIZCDNM.Add("CORCD", _CORCD);
        //        paramSet_BIZCDNM.Add("BIZCD", _BIZCD_T);
        //        paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);

        //        //DataSet source_BIZCDNM = _WSINQUERY.Inquery_BIZCDNM(paramSet_BIZCDNM);
        //        DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);

        //        this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //        this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //        this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //        this.SetParam(report, "EMPNAME", this.UserInfo.UserName);

        //        this.AfterInvokeServer();

        //        if (GUBN == "1")
        //        {
        //            this.ReportCall(report);
        //        }
        //        else
        //        {
        //            ReportViewer rpt = new ReportViewer(report);
        //            panel19.Controls.Add(rpt.Controls["_CrystalReportViewer"]);

        //            rpt.Width = 0; rpt.Height = 0;
        //            rpt.Show();
        //            rpt.Hide();
        //        }
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //}

        private void IMAGE_VIEW(string BIZCD, string RCV_DATE, string DEFNO)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE", RCV_DATE);
                paramSet.Add("DEFNO", DEFNO);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_IMAGE_VIEW(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_IMAGE_VIEW"), paramSet);

                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = source.Tables[0].Rows[0];

                    if ((dr["FILE_DATA1"]) != System.DBNull.Value)
                    {
                        byte[] _FILE_DATA1 = null;
                        _FILE_DATA1 = (byte[])(dr["FILE_DATA1"]);
                        this.pic02_FILE_DATA1.SetValue(_FILE_DATA1);
                    }

                    if ((dr["FILE_DATA2"]) != System.DBNull.Value)
                    {
                        byte[] _FILE_DATA2 = null;
                        _FILE_DATA2 = (byte[])(dr["FILE_DATA2"]);
                        this.pic02_FILE_DATA2.SetValue(_FILE_DATA2);
                    }

                    if ((dr["AFILE_DATA1"]) != System.DBNull.Value)
                    {
                        byte[] _AFILE_DATA1 = null;
                        _AFILE_DATA1 = (byte[])(dr["AFILE_DATA1"]);
                        this.pic02_AFILE_DATA1.SetValue(_AFILE_DATA1);
                    }

                    if ((dr["AFILE_DATA2"]) != System.DBNull.Value)
                    {
                        byte[] _AFILE_DATA2 = null;
                        _AFILE_DATA2 = (byte[])(dr["AFILE_DATA2"]);
                        this.pic02_AFILE_DATA2.SetValue(_AFILE_DATA2);
                    }
                }
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

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void pic02_FILE_DATA1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_FILE_DATA1.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_FILE_DATA1.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_FILE_DATA2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_FILE_DATA2.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_FILE_DATA2.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_AFILE_DATA1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_AFILE_DATA1.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_AFILE_DATA1.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void pic02_AFILE_DATA2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pic02_AFILE_DATA2.Image != null)
                {
                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";
                    this.pic02_AFILE_DATA2.Image.Save(FILE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Process.Start(FILE_NAME);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void dte02_VER1_RECHK_DATE_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
