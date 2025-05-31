#region ▶ Description & History
/* 
 * 프로그램명 : QA30132 유,무검사 종합 현황 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-24      배명희      통합WCF로 변경 
 *				2017-06-22      배명희      Rexpert적용  
*/
#endregion
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

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
    /// <b>유,무검사 종합현황 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-11 오후 2:22:28<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-11 오후 2:22:28   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30132 : AxCommonBaseControl
    {
        //private IQA30132 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;
        //private ICommon _WSCOM_CM;
        private String Get_VIEW_VINCD;
        private String Get_VIEW_ITEMCD;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30132";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";
        private string PAKAGE_NAME_CM = "APG_COMMON";

        #region [ 초기화 작업 정의 ]

        public QA30132()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30132>("QA00", "QA30132.svc", "CustomBinding");
            //_WSCOMREPORT = ClientFactory.CreateChannel<IQAREPORT>("QA10", "QAREPORT.svc", "CustomBinding");
            //_WSCOM_CM = ClientFactory.CreateChannel<ICommon>("CM", "COMMON.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
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

                this.grd01_VIEW_VINCD.AllowEditing = true;
                this.grd01_VIEW_VINCD.Initialize();
                this.grd01_VIEW_VINCD.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 30, "", "CHK");
                this.grd01_VIEW_VINCD.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "", "TYPECD");
                this.grd01_VIEW_VINCD.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "", "OBJECT_NM");
                this.grd01_VIEW_VINCD.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");

                this.grd01_VIEW_ITEMCD.AllowEditing = true;
                this.grd01_VIEW_ITEMCD.Initialize();
                this.grd01_VIEW_ITEMCD.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 30, "", "CHK");
                this.grd01_VIEW_ITEMCD.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "", "TYPECD");
                this.grd01_VIEW_ITEMCD.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "", "OBJECT_NM");
                this.grd01_VIEW_ITEMCD.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;

                DataTable combo_source_SELECT_GUBN = new DataTable();
                combo_source_SELECT_GUBN.Columns.Add("CODE");
                combo_source_SELECT_GUBN.Columns.Add("NAME");
                combo_source_SELECT_GUBN.Rows.Add("1", this.GetLabel("ISSUEITEM"));//"주요품목");
                combo_source_SELECT_GUBN.Rows.Add("2", this.GetLabel("ALLITEM"));//"전체품목");
                this.cbo01_SEARCH_TYPE.DataBind(combo_source_SELECT_GUBN, false);
                this.cbo01_SEARCH_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_SEARCH_TYPE.SetValue("2"); //디폴트값 전체품목으로

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
                

                this.grd01_QA30132.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;

                this.grd01_QA30132.AllowEditing = false;
                this.grd01_QA30132.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30132.Initialize();
                this.grd01_QA30132.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "차종", "TYPENM", "VIN");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "종합 ITEM", "V0_Y", "TOTAL_ITEM");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "종합 ITEM", "V0_N", "TOTAL_ITEM");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V1_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V1_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V2_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V2_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V3_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V3_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V4_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V4_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V5_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V5_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V6_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V6_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V7_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V7_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V8_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V8_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V9_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V9_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V10_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V10_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V11_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V11_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V12_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V12_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V13_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V13_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V14_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V14_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V15_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V15_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V16_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V16_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V17_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V17_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V18_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V18_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V19_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V19_N");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V20_Y");
                this.grd01_QA30132.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "", "V20_N");

                this.SetRequired(lbl01_BIZNM, lbl01_SEARCH_TYPE, lbl01_STD_DATE);

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
                this.cbo01_BIZCD_SelectedIndexChanged(null, null);

                this.grd01_QA30132.InitializeDataSource();


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
                this.Set_grd01_QA30132_COL(Get_VIEW_VINCD);

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string CONV_BEG_DATE = this.dte01_CONV_DATE.GetDateText().ToString();
                string SEARCH_TYPE = this.cbo01_SEARCH_TYPE.GetValue().ToString();
                string RPT_GBN = "N";

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("CONV_BEG_DATE", CONV_BEG_DATE);
                paramSet.Add("SEARCH_TYPE", SEARCH_TYPE);
                paramSet.Add("VINLIST", Get_VIEW_VINCD);
                paramSet.Add("ITEMLIST", Get_VIEW_ITEMCD);
                paramSet.Add("USERID", this.UserInfo.EmpNo);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("RPT_GBN", RPT_GBN);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                DataRow dr1 = source.Tables[0].NewRow();
                DataRow dr2 = source.Tables[0].NewRow();
                DataRow dr3 = source.Tables[0].NewRow();
                DataRow dr4 = source.Tables[0].NewRow();

                decimal []V_Y = new decimal[21];
                decimal []V_N = new decimal[21];
                for (int i = 0; i < 21; i++)
                {
                    decimal SUM_Y = 0;
                    decimal SUM_N = 0;
                    for (int y = 0; y < source.Tables[0].Rows.Count; y++)
                    {
                        string sY = source.Tables[0].Rows[y]["V" + i + "_Y"].ToString();
                        string sN = source.Tables[0].Rows[y]["V" + i + "_N"].ToString();
                        SUM_Y = SUM_Y + decimal.Parse(sY == "" ? "0" : sY);
                        SUM_N = SUM_N + decimal.Parse(sN == "" ? "0" : sN);
                    }
                    V_Y[i] = SUM_Y;
                    V_N[i] = SUM_N;

                    dr3["V" + i + "_Y"] = V_Y[i] == 0 ? "" : V_Y[i].ToString();
                    dr3["V" + i + "_N"] = V_N[i] == 0 ? "" : V_N[i].ToString();

                    dr2["V" + i + "_Y"] = this.GetLabel("EXIST");
                    dr2["V" + i + "_N"] = this.GetLabel("NOT_EXIST");// "무";

                    decimal TOTAL = V_Y[i] + V_N[i];
                    dr1["V" + i + "_Y"] = TOTAL == 0 ? "" : TOTAL.ToString();
                    dr1["V" + i + "_N"] = TOTAL == 0 ? "" : TOTAL.ToString();

                    decimal FormulaY = 0;
                    decimal FormulaN = 100 - FormulaY;
                    if (V_Y[i] + V_N[i] == 0)
                    {
                        FormulaY = 0;
                        FormulaN = 0;
                    }
                    else
                    {
                        FormulaY = decimal.Round(V_Y[i] / (V_Y[i] + V_N[i]) * 100, 1);
                        FormulaN = 100 - FormulaY;
                    }
                    dr4["V" + i + "_Y"] = FormulaY == 0 ? "" : FormulaY.ToString();
                    dr4["V" + i + "_N"] = FormulaN == 0 ? "" : FormulaN.ToString();
                }

                dr1["TYPENM"] = this.GetLabel("ITEMQTY_OF_VIN");//"차종별 ITEM 수량";
                dr2["TYPENM"] = this.GetLabel("INSPECT_DIV");//"검사구분";
                dr3["TYPENM"] = this.GetLabel("INSPECT_SUM_QTY");//"검사수량 합계";
                dr4["TYPENM"] = this.GetLabel("INSPECT_RATE");//"검사비율(%)";

                source.Tables[0].Rows.InsertAt(dr1, 0);
                source.Tables[0].Rows.InsertAt(dr2, 1);
                source.Tables[0].Rows.InsertAt(dr3, 2);
                source.Tables[0].Rows.InsertAt(dr4, 3);
                this.grd01_QA30132.SetValue(source);

                this.grd01_QA30132.Rows[0].AllowMerging = true;
                this.grd01_QA30132.Rows[1].AllowMerging = true;

                this.grd01_QA30132.Styles.Add("COLOR").BackColor = Color.FromArgb(255, 255, 200);
                CellRange cr = new CellRange();
                cr = grd01_QA30132.GetCellRange(1, grd01_QA30132.Cols.Fixed, 4, grd01_QA30132.Cols.Count - grd01_QA30132.Cols.Fixed);
                cr.Style = grd01_QA30132.Styles["COLOR"];

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
        //    try
        //    {
        //        this.Print();   //글로벌표준. 삭제기능 제거. 2018-01-18
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //}

        private void Print()
        {
            try
            {


                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string SEARCH_TYPE = this.cbo01_SEARCH_TYPE.GetValue().ToString();
                string CONV_BEG_DATE = this.dte01_CONV_DATE.GetDateText().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("CONV_BEG_DATE", CONV_BEG_DATE);
                paramSet.Add("SEARCH_TYPE", SEARCH_TYPE);
                paramSet.Add("VINLIST", Get_VIEW_VINCD);
                paramSet.Add("ITEMLIST", Get_VIEW_ITEMCD);
                paramSet.Add("USERID", this.UserInfo.EmpNo);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("RPT_GBN", "Y");
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA30132P"), paramSet);


                HEParameterSet paramSet_CORNM = new HEParameterSet();
                paramSet_CORNM.Add("CORCD", _CORCD);
                paramSet_CORNM.Add("LANG_SET", _LANG_SET);
                DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

                HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
                paramSet_BIZCDNM.Add("CORCD", _CORCD);
                paramSet_BIZCDNM.Add("BIZCD", BIZCD);
                paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);
                DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);


                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/QA31132E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
                source.Tables[0].TableName = "DATA";
                //source.Tables[0].WriteXml("c:/temp/QA31132.xml", XmlWriteMode.WriteSchema);

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

                mainSection.ReportParameter.Add("CONV_YMD", CONV_BEG_DATE);
                mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
                mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
                mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
                mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
                mainSection.ReportParameter.Add("SEARCHTYPE", SEARCH_TYPE);
                mainSection.ReportParameter.Add("HEADER", Get_VIEW_VINCD);

                report.Sections.Add("MAIN", mainSection);


                this.AfterInvokeServer();



                AxRexpertReportViewer.ShowReport(report);



            }

            catch (Exception ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }

        #endregion

        #region -- commented --

        //private void Print_Old()
        //{

        //    try
        //    {
        //        QA31132 report = new QA31132();

        //        string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
        //        string SEARCH_TYPE = this.cbo01_SEARCH_TYPE.GetValue().ToString();
        //        string CONV_BEG_DATE = this.dte01_CONV_DATE.GetValue().ToString();

        //        HEParameterSet paramSet = new HEParameterSet();
        //        paramSet.Add("CORCD", _CORCD);
        //        paramSet.Add("BIZCD", BIZCD);
        //        paramSet.Add("CONV_BEG_DATE", CONV_BEG_DATE);
        //        paramSet.Add("SEARCH_TYPE", SEARCH_TYPE);
        //        paramSet.Add("VINLIST", Get_VIEW_VINCD);
        //        paramSet.Add("ITEMLIST", Get_VIEW_ITEMCD);
        //        paramSet.Add("USERID", this.UserInfo.EmpNo);
        //        paramSet.Add("LANG_SET", _LANG_SET);
        //        paramSet.Add("RPT_GBN", "Y");
        //        paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue());
        //        this.BeforeInvokeServer(true);

        //        //DataSet source = _WSCOMREPORT.QA30132P(paramSet);
        //        DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA30132P"), paramSet);

        //        report.SetDataSource(source.Tables[0]);

        //        HEParameterSet paramSet_CORNM = new HEParameterSet();
        //        paramSet_CORNM.Add("CORCD", _CORCD);
        //        paramSet_CORNM.Add("LANG_SET", _LANG_SET);

        //        //DataSet source_CORNM = _WSINQUERY.Inquery_CORNM(paramSet_CORNM);
        //        DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

        //        HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
        //        paramSet_BIZCDNM.Add("CORCD", _CORCD);
        //        paramSet_BIZCDNM.Add("BIZCD", BIZCD);
        //        paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);

        //        //DataSet source_BIZCDNM = _WSINQUERY.Inquery_BIZCDNM(paramSet_BIZCDNM);
        //        DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);

        //        this.SetParam(report, "CONV_YMD", CONV_BEG_DATE);
        //        this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //        this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //        this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //        this.SetParam(report, "EMPNAME", this.UserInfo.UserName);
        //        this.SetParam(report, "SEARCHTYPE", SEARCH_TYPE);
        //        this.SetParam(report, "HEADER", Get_VIEW_VINCD);

        //        this.AfterInvokeServer();

        //        this.ReportCall(report);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
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

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string VIEW_VINCD = _WSCOM_CM.GetUserEnviroment("", "QA30132_ITEMLIST_ALL");
            HEParameterSet set = new HEParameterSet();
            set.Add("USERID", "");
            set.Add("ENVNAME", "QA30132_ITEMLIST_ALL");
            string VIEW_VINCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_CM, "GETUSERENVIROMENT"), set).Tables[0].Rows[0][0].ToString();

            //string VIEW_ITEMCD = _WSCOM_CM.GetUserEnviroment("", "QA30132_ITEMLIST_ALL");       
            HEParameterSet set2 = new HEParameterSet();
            set2.Add("USERID", "");
            set2.Add("ENVNAME", "QA30132_ITEMLIST_ALL");
            string VIEW_ITEMCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_CM, "GETUSERENVIROMENT"), set2).Tables[0].Rows[0][0].ToString();

            //Get_VIEW_VINCD = _WSCOM_CM.GetUserEnviroment(this.UserInfo.EmpNo, "QA30132_VINLIST_" + this.cbo01_BIZCD.GetValue());
            HEParameterSet set3 = new HEParameterSet();
            set3.Add("USERID", this.UserInfo.EmpNo);
            set3.Add("ENVNAME", "QA30132_VINLIST_" + this.cbo01_BIZCD.GetValue());
            Get_VIEW_VINCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_CM, "GETUSERENVIROMENT"), set3).Tables[0].Rows[0][0].ToString();

            //Get_VIEW_ITEMCD = _WSCOM_CM.GetUserEnviroment(this.UserInfo.EmpNo, "QA30132_ITEMLIST_" + this.cbo01_BIZCD.GetValue());
            HEParameterSet set4 = new HEParameterSet();
            set4.Add("USERID", this.UserInfo.EmpNo);
            set4.Add("ENVNAME", "QA30132_ITEMLIST_" + this.cbo01_BIZCD.GetValue());
            Get_VIEW_ITEMCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_CM, "GETUSERENVIROMENT"), set4).Tables[0].Rows[0][0].ToString();


            DataSet source = this.GetTypeCode("A3", "A4");

            source.Tables[0].Columns.Add("CHK");
            source.Tables[1].Columns.Add("CHK");

            string[] VIEW_VINCD_ARR = Get_VIEW_VINCD.Split(';');
            string[] VIEW_ITEMCD_ARR = Get_VIEW_ITEMCD.Split(';');

            for (int i = 0; i < source.Tables[0].Rows.Count; i++)
            {
                source.Tables[0].Rows[i]["CHK"] = "False";
            }

            for (int i = 0; i < VIEW_VINCD_ARR.Length; i++)
            {
                for (int y = 0; y < source.Tables[0].Rows.Count; y++)
                {
                    if (source.Tables[0].Rows[y]["TYPECD"].ToString() == VIEW_VINCD_ARR[i])
                    {
                        source.Tables[0].Rows[y]["CHK"] = "True";
                    }
                }
            }

            for (int i = 0; i < source.Tables[1].Rows.Count; i++)
            {
                source.Tables[1].Rows[i]["CHK"] = "False";
            }

            for (int i = 0; i < VIEW_ITEMCD_ARR.Length; i++)
            {
                for (int y = 0; y < source.Tables[1].Rows.Count; y++)
                {
                    if (source.Tables[1].Rows[y]["TYPECD"].ToString() == VIEW_ITEMCD_ARR[i])
                    {
                        source.Tables[1].Rows[y]["CHK"] = "True";
                    }
                }
            }

            this.grd01_VIEW_VINCD.SetValue(source.Tables[0]);
            this.grd01_VIEW_ITEMCD.SetValue(source.Tables[1]);

            this.grd01_VIEW_VINCD.Rows[0].Visible = false;
            this.grd01_VIEW_VINCD.Cols[0].Visible = false;

            this.grd01_VIEW_ITEMCD.Rows[0].Visible = false;
            this.grd01_VIEW_ITEMCD.Cols[0].Visible = false;
        }

        private void btn01_SetUserEnviroment_Click(object sender, EventArgs e)
        {
            //_WSCOM_CM.SetUserEnviroment(this.UserInfo.EmpNo, "QA30132_VINLIST_" + this.cbo01_BIZCD.GetValue(), Get_VIEW_VINCD);
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("USERID", this.UserInfo.EmpNo);
            paramSet.Add("ENVNAME", "QA30132_VINLIST_" + this.cbo01_BIZCD.GetValue());
            paramSet.Add("ENVVALUE", Get_VIEW_VINCD);            
            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME_CM, "SETUSERENVIROMENT"), paramSet);


            //_WSCOM_CM.SetUserEnviroment(this.UserInfo.EmpNo, "QA30132_ITEMLIST_" + this.cbo01_BIZCD.GetValue(), Get_VIEW_ITEMCD);
            HEParameterSet paramSet2 = new HEParameterSet();
            paramSet2.Add("USERID", this.UserInfo.EmpNo);
            paramSet2.Add("ENVNAME", "QA30132_ITEMLIST_" + this.cbo01_BIZCD.GetValue());
            paramSet2.Add("ENVVALUE", Get_VIEW_ITEMCD);
            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME_CM, "SETUSERENVIROMENT"), paramSet2);

            MsgCodeBox.Show("CD00-0071");
            //MsgBox.Show("사용자설정 저장이 완료 되었습니다.");
        }

        private void grd01_VIEW_VINCD_MouseClick(object sender, MouseEventArgs e)
        {
            Get_VIEW_VINCD = "";
            for (int i = 1; i < grd01_VIEW_VINCD.Rows.Count; i++)
            {
                if(grd01_VIEW_VINCD.GetValue(i,"CHK").ToString() == "Y")
                {
                    if (Get_VIEW_VINCD == "")
                    {
                        Get_VIEW_VINCD = grd01_VIEW_VINCD.GetValue(i, "TYPECD").ToString();
                    }
                    else
                    {
                        Get_VIEW_VINCD = Get_VIEW_VINCD + ";" + grd01_VIEW_VINCD.GetValue(i, "TYPECD").ToString();
                    }
                }

            }
        }

        private void grd01_VIEW_ITEMCD_MouseClick(object sender, MouseEventArgs e)
        {
            Get_VIEW_ITEMCD = "";
            for (int i = 1; i < grd01_VIEW_ITEMCD.Rows.Count; i++)
            {
                if (grd01_VIEW_ITEMCD.GetValue(i, "CHK").ToString() == "Y")
                {
                    if (Get_VIEW_ITEMCD == "")
                    {
                        Get_VIEW_ITEMCD = grd01_VIEW_ITEMCD.GetValue(i, "TYPECD").ToString();
                    }
                    else
                    {
                        Get_VIEW_ITEMCD = Get_VIEW_ITEMCD + ";" + grd01_VIEW_ITEMCD.GetValue(i, "TYPECD").ToString();
                    }
                }

            }
        }

        private void cbo01_SEARCH_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbo01_SEARCH_TYPE.GetValue().ToString() == "1")
            {
                this.lbl01_VIEW_ITEMCD.Visible = true;
                this.grd01_VIEW_ITEMCD.Visible = true; 
            }
            else
            {
                this.lbl01_VIEW_ITEMCD.Visible = false;
                this.grd01_VIEW_ITEMCD.Visible = false;
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void Set_grd01_QA30132_COL(string VIEW_VINCD)
        {
            try
            {
                string []VINCD = VIEW_VINCD.Split(';');
                int startColIndex = this.grd01_QA30132.Cols["V1_Y"].Index;

                int y = 0;
                for (int i = 0; i < 20; i++)
                {
                    y = startColIndex + (i * 2);
                    if(i < VINCD.Length)
                    {
                        this.grd01_QA30132.SetValue(0, y, VINCD[i]);
                        this.grd01_QA30132.SetValue(0, y + 1, VINCD[i]);
                    }
                    else
                    {
                        this.grd01_QA30132.SetValue(0, y, "-");
                        this.grd01_QA30132.SetValue(0, y + 1, "-");
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
