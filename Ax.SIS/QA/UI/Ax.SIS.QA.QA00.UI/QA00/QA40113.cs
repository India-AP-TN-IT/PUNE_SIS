#region ▶ Description & History
/* 
 * 프로그램명 : QA40113 일입고자재 불량품의서 결재
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
    /// <b>일입고자재 불량품의서 결재</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA40113 : AxCommonBaseControl
    {
        //private IQA40113 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;
        //private IQAREPORT _WSCOMREPORT;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA40113";
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";

        #region [ 초기화 작업 정의 ]

        public QA40113()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA40113>("QA00", "QA40113.svc", "CustomBinding");

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
                this.cdx01_VENDCD.PopupTitle = "협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.grd01_QA40113.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                this.grd01_QA40113.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA40113.Initialize();
                this.grd01_QA40113.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA40113.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD");
                this.grd01_QA40113.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD");
                this.grd01_QA40113.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "CHK", "CHK_ENABLE", "CHK3");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "결재상태", "DESIDE", "APP_STATUS");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "RCV_DATE","OCCUR_DATE");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD", "VIN");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "협력사", "VENDCD", "VENDER");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "협력사명", "VENDNM","COOPER_NM2");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "품명", "PARTNM","PARTNMTITLE");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "LOTNO", "LOTNO","LOTNO_TITLE");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "불량번호", "DEFNO", "DEFNO");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "불량내용", "DEFCD", "DEF_CNTT");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량내용", "DEFNM", "DEF_CNTT");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "불량부위", "DEFPOSCD", "DEFPOSNM2");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량부위", "DEFPOSNM", "DEFPOSNM2");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "단위", "UNIT", "UNIT");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "조치내용", "MGRT_CNTTCD", "CNTTCD");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "조치내용", "MGRT_CNTTNM", "CNTTCD");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "불량장소", "DEF_PLACECD", "DEF_PLACE");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량장소", "DEF_PLACENM", "DEF_PLACE");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "검사자사번", "INSPECT_EMPNO","INSPECT_EMPNO");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "검사자명", "INSPECT_EMPNM", "INSPECT_EMPNM");
                this.grd01_QA40113.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "PID", "PID");
                this.grd01_QA40113.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "공장구분", "PLANT_DIV", "PLANT_DIV"); //공장구분 추가 2013.04.15(배명희)

                this.grd01_QA40113.SetColumnType(AxFlexGrid.FCellType.Check, "CHK_ENABLE");
                this.grd01_QA40113.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");

                this.grd01_QA40113.SetColumnType(AxFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV", true); //공장구분 추가 2013.04.15(배명희)

                this.grd01_QA40113.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA40113.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA40113.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA40113.CurrentContextMenu.Items[3].Visible = false;

                this.grd01_QA40113.AddMerge(0, 0, "DEFCD", "DEFNM");
                this.grd01_QA40113.AddMerge(0, 0, "DEFPOSCD", "DEFPOSNM");
                this.grd01_QA40113.AddMerge(0, 0, "MGRT_CNTTCD", "MGRT_CNTTNM");
                this.grd01_QA40113.AddMerge(0, 0, "DEF_PLACECD", "DEF_PLACENM");

                this.grd01_QA40113.SetHeadTitle(0, "DEFCD", this.GetLabel("DEF_CNTT")); // "불량내용");
                this.grd01_QA40113.SetHeadTitle(0, "DEFPOSCD", this.GetLabel("DEFPOSNM2")); //"불량부위");
                this.grd01_QA40113.SetHeadTitle(0, "MGRT_CNTTCD", this.GetLabel("CNTTCD")); //"조치내용");
                this.grd01_QA40113.SetHeadTitle(0, "DEF_PLACECD", this.GetLabel("DEF_PLACE")); //"불량장소");

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
                this.grd01_QA40113.InitializeDataSource();
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
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //2013.04.15 공장구분 조회조건 추가 (배명희)

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE_FROM", RCV_DATE_FROM);
                paramSet.Add("RCV_DATE_TO", RCV_DATE_TO);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);                           //2013.04.15 공장구분 조회조건 추가 (배명희)

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA40113.SetValue(source);

                this.grd01_QA40113.Styles.Add("A").BackColor = Color.FromArgb(255, 200, 200);                
                this.grd01_QA40113.Styles.Add("D").BackColor = Color.FromArgb(255, 255, 255);

                CellRange cr = new CellRange();
                for (int i = 1; i < grd01_QA40113.Rows.Count; i++)
                {
                    cr = grd01_QA40113.GetCellRange(i, grd01_QA40113.Cols.Fixed, i, grd01_QA40113.Cols.Count - grd01_QA40113.Cols.Fixed);

                    switch (this.grd01_QA40113.GetValue(i, "DESIDE").ToString().Substring(0, 1))
                    {
                        case "N":
                            cr.Style = grd01_QA40113.Styles["A"];
                            break;
                
                        case "Y":
                            cr.Style = grd01_QA40113.Styles["D"];
                            break;
                        default:
                            break;
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

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01_QA40113.Rows.Count - this.grd01_QA40113.Rows.Fixed > 0)
                {
                    this.Print();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void Print()
        {
            try
            {

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string BEG_DATE = this.dte01_RCV_DATE_FROM.GetDateText().ToString();
                string END_DATE = this.dte01_RCV_DATE_TO.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string INSPECT_DIV = "";
                string APP_MODE = "N";
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //2013.04.15 공장구분 조회조건 추가 (배명희)

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("BEG_DATE", BEG_DATE);
                paramSet.Add("END_DATE", END_DATE);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("INSPECT_DIV", INSPECT_DIV);
                paramSet.Add("APP_MODE", APP_MODE);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);                           //2013.04.15 공장구분 조회조건 추가 (배명희)

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOMREPORT.QA40113P(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40113P"), paramSet);



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



                this.AfterInvokeServer();

                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/QA41113";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
                source.Tables[0].TableName = "DATA";
                //source.Tables[0].WriteXml("c:/temp/QA41113.xml", XmlWriteMode.WriteSchema);

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




                mainSection.ReportParameter.Add("APPLINE", "");
                mainSection.ReportParameter.Add("BEG_YMD", END_DATE);
                mainSection.ReportParameter.Add("END_YMD", END_DATE);
                mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
                mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
                mainSection.ReportParameter.Add("VENDCD", VENDCD);
                mainSection.ReportParameter.Add("INSPECT_DIV", INSPECT_DIV);
                mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
                mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);


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

     

        #region [ 기타 이벤트 정의 ]

      

        private void grd01_QA40113_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA40113.SelectedRowIndex;

                if (Row >= this.grd01_QA40113.Rows.Fixed)
                {
                    string BIZCD = this.grd01_QA40113.GetValue(Row, "BIZCD").ToString();
                    string RCV_DATE = this.grd01_QA40113.GetValue(Row, "RCV_DATE").ToString();
                    string DEFNO = this.grd01_QA40113.GetValue(Row, "DEFNO").ToString();
                    string VENDCD = this.grd01_QA40113.GetValue(Row, "VENDCD").ToString();

                    ShowPopup(new QA20111(BIZCD, RCV_DATE, VENDCD, DEFNO));
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_APPLAY_NEW_Click(object sender, EventArgs e)
        {
            if (!IsAPPLAY(grd01_QA40113)) return;

            this.APPLAY_NEW(grd01_QA40113);
            this.BtnQuery_Click(null, null);
        }

        private void btn01_APPLAY_CLEAR_Click(object sender, EventArgs e)
        {
            if (!IsAPPLAY_CLEAR(grd01_QA40113)) return;

            this.APPLAY_CLEAR(grd01_QA40113);
            this.BtnQuery_Click(null, null);
        }

        #endregion

        #region [유효성 검사]

        private bool IsAPPLAY(AxFlexGrid grd)
        {
            try
            {

                //if (MsgBox.Show("협력사에 통보처리 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("QA00-047", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsAPPLAY_CLEAR(AxFlexGrid grd)
        {
            try
            {
                //통보처리를 취소 하시겠습니까?
                if (MsgCodeBox.Show("QA00-048", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

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

        private void APPLAY_NEW(AxFlexGrid grd)
        {            
            DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "DEFNO");
            
            for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                {
                    source.Tables[0].Rows.Add(
                        grd.GetValue(i, "CORCD"),
                        grd.GetValue(i, "BIZCD"),
                        grd.GetValue(i, "DEFNO")                        
                    );                  
                }
            }
            if (source.Tables[0].Rows.Count > 0)
            {
                // ERP 에 데이터 업데이트
                //_WSCOM.App_save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "APP_SAVE"), source);
                
            }
            
            
        }
        
        private void APPLAY_CLEAR(AxFlexGrid grd)
        {
            DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "DEFNO");

            for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                {
                    source.Tables[0].Rows.Add(
                        grd.GetValue(i, "CORCD"),
                        grd.GetValue(i, "BIZCD"),
                        grd.GetValue(i, "DEFNO")     
                    );
                }
            }

            if (source.Tables[0].Rows.Count > 0)
            {
                //_WSCOM.App_clear(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "APP_CLEAR"), source);
            }
        }

        #endregion
    }
}
