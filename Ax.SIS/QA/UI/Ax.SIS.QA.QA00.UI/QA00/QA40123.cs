#region ▶ Description & History
/* 
 * 프로그램명 : QA40123 일공정불량품의서 결재
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
 *              2017-06-22      배명희      Rexpert적용  
*/
#endregion
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>일공정 불량 품의서 결재</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA40123 : AxCommonBaseControl
    {
        //private IQA40123 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;
        //private IQAREPORT _WSCOMREPORT;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA40123";
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";

        #region [ 초기화 작업 정의 ]

        public QA40123()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA40123>("QA00", "QA40123.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
            //_WSCOMREPORT = ClientFactory.CreateChannel<IQAREPORT>("QA10", "QAREPORT.svc", "CustomBinding");

            _WSCOM_N = new AxClientProxy();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
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
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                this._buttonsControl.BtnSave.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                }

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");// "협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.grd01_QA40123.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA40123.Initialize();
                this.grd01_QA40123.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA40123.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD");
                this.grd01_QA40123.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD");                
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "RCV_DATE", "OCCUR_DATE");
                
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD", "VIN");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM", "PARTNONM");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "협력사", "VENDCD", "VENDER");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "협력사명", "VENDNM", "COOPER_NM2");
                this.grd01_QA40123.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "귀책구분", "IMPUTCD", "RESPONSTITLE");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "귀책구분", "IMPUTNM", "RESPONSTITLE");
                this.grd01_QA40123.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "불량장소", "PLACECD", "DEF_PLACE");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량장소", "PLACENM", "DEF_PLACE");
                this.grd01_QA40123.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "불량내용", "DEFCD", "DEF_CNTT");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량내용", "DEFNM", "DEF_CNTT");
                this.grd01_QA40123.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "불량부위", "DEFPOSCD", "DEFPOSNM2");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량부위", "DEFPOSNM", "DEFPOSNM2");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "검사자사번", "EMPNO", "INSPECT_EMPNO");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "검사자명", "EMPNM", "INSPECT_EMPNM");
                this.grd01_QA40123.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "발생번호", "NOTENO", "OCCURNO");
                this.grd01_QA40123.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "불량구분", "DEFTYPE", "DEFTYPE");
                this.grd01_QA40123.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "PID", "PID");                
                this.grd01_QA40123.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd01_QA40123.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA40123.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA40123.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA40123.CurrentContextMenu.Items[3].Visible = false;

                DataTable dtPLANT_DIV = this.GetTypeCode("U9").Tables[0];
                foreach (DataRow dr in dtPLANT_DIV.Rows)
                {
                    dr["OBJECT_NM"] = dr["TYPECD"].ToString() + ":" + dr["OBJECT_NM"].ToString();
                }
                this.grd01_QA40123.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01_QA40123.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPLANT_DIV, "PLANT_DIV");
                this.grd01_QA40123.Cols["PLANT_DIV"].TextAlign = TextAlignEnum.CenterCenter;



                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.19 공장구분 조회조건 추가
                //2015.07.01 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                this.SetRequired(lbl01_SAUP, lbl01_RCV_FROM_TO);

                this.BtnReset_Click(null, null);

                //this.dte01_RCV_DATE_FROM.SetMMFromStart();
                this.dte01_RCV_DATE_FROM.SetValue(this.dte01_RCV_DATE_FROM.GetDateText().ToString().Substring(0, 8) + "01");

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
                this.grd01_QA40123.InitializeDataSource();
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
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string RCV_DATE_FROM = this.dte01_RCV_DATE_FROM.GetDateText().ToString();
                string RCV_DATE_TO = this.dte01_RCV_DATE_TO.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();      //공장구분 추가

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE_FROM", RCV_DATE_FROM);
                paramSet.Add("RCV_DATE_TO", RCV_DATE_TO);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                paramSet.Add("PLANT_DIV", PLANT_DIV);                               //공장구분 추가

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA40123.SetValue(source);

                this.grd01_QA40123.Styles.Add("A").BackColor = Color.FromArgb(255, 200, 200);
                this.grd01_QA40123.Styles.Add("B").BackColor = Color.FromArgb(200, 200, 255);
                this.grd01_QA40123.Styles.Add("C").BackColor = Color.FromArgb(200, 255, 200);
                this.grd01_QA40123.Styles.Add("D").BackColor = Color.FromArgb(255, 255, 255);

                
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

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01_QA40123.Rows.Count - this.grd01_QA40123.Rows.Fixed > 0)
                {
                    CallReportQA41123();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void CallReportQA41123()
        {
            string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
            string BEG_DATE = this.dte01_RCV_DATE_FROM.GetDateText().ToString();
            string END_DATE = this.dte01_RCV_DATE_TO.GetDateText().ToString();
            string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
            string PROD_PLANT = "";
            string APP_MODE = "N";

            string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //공장구분 추가

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", _CORCD);
            paramSet.Add("BIZCD", BIZCD);
            paramSet.Add("BEG_DATE", BEG_DATE);
            paramSet.Add("END_DATE", END_DATE);
            paramSet.Add("VENDCD", VENDCD);
            paramSet.Add("PROD_PLANT", PROD_PLANT);
            paramSet.Add("APP_MODE", APP_MODE);
            paramSet.Add("LANG_SET", _LANG_SET);

            paramSet.Add("PLANT_DIV", PLANT_DIV);           //공장구분 추가        
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40123P"), paramSet);

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
            report.ReportName = "RxRpt/QA41123E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
            source.Tables[0].TableName = "DATA";
            source.Tables[0].WriteXml("c:/temp/QA41123.xml", XmlWriteMode.WriteSchema);
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
            mainSection.ReportParameter.Add("APPLINE", "");
            mainSection.ReportParameter.Add("BEG_YMD", BEG_DATE);
            mainSection.ReportParameter.Add("END_YMD", END_DATE);
            mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows.Count > 0 ? source_CORNM.Tables[0].Rows[0]["CORNM"].ToString() : string.Empty);
            mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows.Count > 0 ? source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString() : string.Empty);
            mainSection.ReportParameter.Add("VENDCD", VENDCD);
            mainSection.ReportParameter.Add("PROD_PLANT", PROD_PLANT);
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

        #region [ 기타 이벤트 정의 ]

        private void grd01_QA40123_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void grd01_QA40123_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA40123.SelectedRowIndex;

                if (Row >= this.grd01_QA40123.Rows.Fixed)
                {
                    string BIZCD = this.grd01_QA40123.GetValue(Row, "BIZCD").ToString();
                    string RCV_DATE = this.grd01_QA40123.GetValue(Row, "RCV_DATE").ToString();
                    string VENDCD = this.grd01_QA40123.GetValue(Row, "VENDCD").ToString();
                    string NOTENO = this.grd01_QA40123.GetValue(Row, "NOTENO").ToString();

                    if (this.grd01_QA40123.GetValue(Row, "DEFTYPE").ToString() == "R")
                    {
                        ShowPopup(new QA20123(BIZCD, RCV_DATE, VENDCD, NOTENO));
                    }
                    else
                    {
                        ShowPopup(new QA20121(BIZCD, RCV_DATE, VENDCD, NOTENO));
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        

        #endregion

        #region [유효성 검사]


        #endregion

        #region [ 사용자 정의 메서드 ]


        #endregion
    }
}
