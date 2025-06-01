/* 
 * 프로그램명 : 수입 입고 불량발생 등록
 * 설      명 : 
 * 최초작성자 : 이대형
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2010.05.10      이대형     최초 클래스 생성
 *              2014.07.02      배명희     #001 - PPM컬럼 소수점 1자리로 표시 (APG_QA30112도 병행 수정함)
 *              2015.01.05      배명희     화면 로딩 속도 느림. 사용자가 조회조건 설정하여 조회할수 있도록 기본조회는 제거(오세민대리요청)
 *              2015-07-23      배명희     통합WCF로 변경 
 *				2017-06-22      배명희      Rexpert적용              
*/
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>수입 입고 불량발생 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 5:34:21<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 5:34:21   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30112 : AxCommonBaseControl
    {
        //private IQA30112 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30112";
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";

        #region [ 초기화 작업 정의 ]

        public QA30112()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30112>("QA00", "QA30112.svc", "CustomBinding");
            //_WSCOMREPORT = ClientFactory.CreateChannel<IQAREPORT>("QA10", "QAREPORT.svc", "CustomBinding");
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

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_BIZCD.Enabled = true;

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 권한제어처리- UserInfo.PlantDiv = 'U902' 라면 U2:두서공장으로 고정하고 변경불가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                DataTable combo_source = new DataTable();
                combo_source.Columns.Add("CODE");
                combo_source.Columns.Add("NAME");
                //combo_source.Rows.Add("1", "업체별");
                //combo_source.Rows.Add("2", "차종별");
                //combo_source.Rows.Add("3", "불량유형별");
                //combo_source.Rows.Add("4", "불량장소별");

                combo_source.Rows.Add("1", this.GetLabel("BY_VENDER"));//"업체별");
                combo_source.Rows.Add("2", this.GetLabel("BY_VEHICLE"));//"차종별");
                combo_source.Rows.Add("3", this.GetLabel("BY_BAD_TYPE"));//"불량유형별");
                combo_source.Rows.Add("4", this.GetLabel("BY_OCCUR_PLACE"));//"발생장소별");

                this.cbo01_SELECT_GUBN.DataBind(combo_source,false);
                this.cbo01_SELECT_GUBN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD_FROM.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD_FROM.PopupTitle = this.GetLabel("COOPER_CODE");// "협력사코드";
                this.cdx01_VENDCD_FROM.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD_FROM.NameParameterName = "VENDNM";
                this.cdx01_VENDCD_FROM.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VENDCD_TO.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD_TO.PopupTitle = this.GetLabel("COOPER_CODE");// "협력사코드";
                this.cdx01_VENDCD_TO.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD_TO.NameParameterName = "VENDNM";
                this.cdx01_VENDCD_TO.HEParameterAdd("LANG_SET", _LANG_SET);

                this.grd01_QA30112.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd01_QA30112.AllowEditing = false;
                this.grd01_QA30112.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30112.Initialize(false);
                this.grd01_QA30112.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "", "ORDER2");
                this.grd01_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "귀책업체코드", "VENDCD", "IMPUT_VENDCD");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "차종", "VINCD", "VINCD");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNONM","PARTNM");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "입고량", "IN_QTY", "IN_QTY");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량금액", "DEF_AMT", "DEF_AMT");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "불량건수", "DEF_COUNT", "DEF_NOCASE");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "점수", "CNT_SCORE", "CNT_SCORE");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "PPM", "DEF_PPM");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "점수", "PPM_SCORE", "PPM_SCORE");
                this.grd01_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "총점", "TOT_SCORE", "TOT_SCORE");
                this.grd01_QA30112.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd01_QA30112.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd01_QA30112.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                this.grd01_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PPM");
                this.grd01_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "CNT_SCORE");
                this.grd01_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "PPM_SCORE");
                this.grd01_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT_SCORE");
                //this.grd01_QA30112.Cols["DEF_PPM"].Format = "###,###,###,###,###.0";    //#001
                this.grd01_QA30112.Cols["CORCD"].AllowMerging = true;
                this.grd01_QA30112.Cols["BIZCD"].AllowMerging = true;
                this.grd01_QA30112.Cols["VENDCD"].AllowMerging = true;
                this.grd01_QA30112.Cols["VENDNM"].AllowMerging = true;
                this.grd01_QA30112.Cols["VINCD"].AllowMerging = true;

                this.grd02_QA30112.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd02_QA30112.AllowEditing = false;
                this.grd02_QA30112.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA30112.Initialize(false);
                this.grd02_QA30112.AllowSorting = AllowSortingEnum.None;
                this.grd02_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "", "ORDER2");
                this.grd02_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "차종", "VINCD", "VINCD");
                this.grd02_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "귀책업체코드", "VENDCD", "IMPUT_VENDCD");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNONM", "PARTNM");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "입고량", "IN_QTY", "IN_QTY");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량금액", "DEF_AMT", "DEF_AMT");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량건수", "DEF_COUNT","");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "점수", "CNT_SCORE", "DEF_NOCASE");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "PPM", "DEF_PPM");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "점수", "PPM_SCORE", "PPM_SCORE");
                this.grd02_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "총점", "TOT_SCORE", "TOT_SCORE");
                this.grd02_QA30112.SetColumnType(AxFlexGrid.FCellType.Int, "IN_QTY");
                this.grd02_QA30112.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd02_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd02_QA30112.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_COUNT");
                this.grd02_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PPM");
                this.grd02_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "CNT_SCORE");
                this.grd02_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "PPM_SCORE");
                this.grd02_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT_SCORE");
                //this.grd02_QA30112.Cols["DEF_PPM"].Format = "###,###,###,###,###.0";    //#001
                this.grd02_QA30112.Cols["CORCD"].AllowMerging = true;
                this.grd02_QA30112.Cols["BIZCD"].AllowMerging = true;
                this.grd02_QA30112.Cols["VINCD"].AllowMerging = true;

                this.grd03_QA30112.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd03_QA30112.AllowEditing = false;
                this.grd03_QA30112.AllowDragging = AllowDraggingEnum.None;
                this.grd03_QA30112.Initialize(false);
                this.grd03_QA30112.AllowSorting = AllowSortingEnum.None;
                this.grd03_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "", "ORDER2");
                this.grd03_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd03_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd03_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량유형코드", "DEFCD", "DEFCD");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량유형", "DEFNM", "DEFNM");
                this.grd03_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "귀책업체코드", "VENDCD", "IMPUT_VENDCD");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNONM", "PARTNM");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "입고량", "IN_QTY", "IN_QTY");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량금액", "DEF_AMT", "DEF_AMT");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량건수", "DEF_COUNT", "DEF_NOCASE");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "점수", "CNT_SCORE", "CNT_SCORE");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "PPM", "DEF_PPM");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "점수", "PPM_SCORE", "PPM_SCORE");
                this.grd03_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "총점", "TOT_SCORE", "TOT_SCORE");
                this.grd03_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "IN_QTY");
                this.grd03_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd03_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd03_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_COUNT");
                this.grd03_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PPM");                
                this.grd03_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "PPM_SCORE");
                this.grd03_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT_SCORE");
                this.grd03_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "CNT_SCORE");
                this.grd03_QA30112.Cols["DEF_PPM"].Format = "###,###,###,###,###.0";    //#001
                this.grd03_QA30112.Cols["CORCD"].AllowMerging = true;
                this.grd03_QA30112.Cols["BIZCD"].AllowMerging = true;
                this.grd03_QA30112.Cols["DEFCD"].AllowMerging = true;
                this.grd03_QA30112.Cols["DEFNM"].AllowMerging = true;

                this.grd04_QA30112.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;

                this.grd04_QA30112.AllowEditing = false;
                this.grd04_QA30112.AllowDragging = AllowDraggingEnum.None;
                this.grd04_QA30112.Initialize(false);
                this.grd04_QA30112.AllowSorting = AllowSortingEnum.None;
                this.grd04_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "", "ORDER2");
                this.grd04_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd04_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd04_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량장소코드", "DEF_PLACECD", "DEF_PLACECD");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량장소", "DEF_PLACENM", "DEF_PLACENM");
                this.grd04_QA30112.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "귀책업체코드", "VENDCD", "IMPUT_VENDCD");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNONM", "PARTNM");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "입고량", "IN_QTY", "IN_QTY");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량금액", "DEF_AMT", "DEF_AMT");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량건수", "DEF_COUNT", "DEF_NOCASE");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "점수", "CNT_SCORE", "CNT_SCORE");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "PPM", "DEF_PPM");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "점수", "PPM_SCORE", "PPM_SCORE");
                this.grd04_QA30112.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "총점", "TOT_SCORE", "TOT_SCORE");
                this.grd04_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "IN_QTY");
                this.grd04_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd04_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd04_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_COUNT");
                this.grd04_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_PPM");
                this.grd04_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "CNT_SCORE");
                this.grd04_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "PPM_SCORE");
                this.grd04_QA30112.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT_SCORE");
                this.grd04_QA30112.Cols["DEF_PPM"].Format = "###,###,###,###,###.0";    //#001

                this.grd04_QA30112.Cols["CORCD"].AllowMerging = true;
                this.grd04_QA30112.Cols["BIZCD"].AllowMerging = true;
                this.grd04_QA30112.Cols["DEF_PLACECD"].AllowMerging = true;
                this.grd04_QA30112.Cols["DEF_PLACENM"].AllowMerging = true;
                this.grd04_QA30112.Cols["VENDCD"].AllowMerging = true;
                this.grd04_QA30112.Cols["VENDNM"].AllowMerging = true;

                this.SetRequired(lbl01_BIZNM, lbl01_SELECT_GUBN, lbl01_OCCUR_DATE);

                this.BtnReset_Click(null, null);

                //this.dte01_RCV_DATE_FROM.SetMMFromStart();
                this.dte01_RCV_DATE_FROM.SetValue(this.dte01_RCV_DATE_FROM.GetDateText().ToString().Substring(0, 8) + "01");
                
                //화면 로딩시 디폴트 조회 제거(속도느림)
                //this.BtnQuery_Click(null, null);
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
                this.grd01_QA30112.InitializeDataSource();
                this.grd02_QA30112.InitializeDataSource();
                this.grd03_QA30112.InitializeDataSource();
                this.grd04_QA30112.InitializeDataSource();

                this.chk01_OEM_YN.Checked = true;
                this.chk01_DEF_ONLY.Checked = true;
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
                string VENDCD_FROM = this.cdx01_VENDCD_FROM.GetValue().ToString();
                string VENDCD_TO = this.cdx01_VENDCD_TO.GetValue().ToString();
                string OEM_YN = this.chk01_OEM_YN.GetValue().ToString();
                string DEF_YN = this.chk01_DEF_ONLY.GetValue().ToString();
                string SELECT_GUBN = this.cbo01_SELECT_GUBN.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //공장구분 추가 2013.04.16 (배명희)

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE_FROM", RCV_DATE_FROM);
                paramSet.Add("RCV_DATE_TO", RCV_DATE_TO);
                paramSet.Add("VENDCD_FROM", VENDCD_FROM);
                paramSet.Add("VENDCD_TO", VENDCD_TO);
                paramSet.Add("OEM_YN", OEM_YN);
                paramSet.Add("DEF_YN", DEF_YN);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", PLANT_DIV);                       //공장구분 추가 2013.04.16 (배명희)
                this.BeforeInvokeServer(true);

                DataSet source = new DataSet();
                AxFlexGrid grd = new AxFlexGrid();

                this.grd01_QA30112.Visible = false;
                this.grd02_QA30112.Visible = false;
                this.grd03_QA30112.Visible = false;
                this.grd04_QA30112.Visible = false;

                switch (SELECT_GUBN)
                {
                    case "1":
                        this.grd01_QA30112.Visible = true;
                        //source = _WSCOM.Inquery_VENDCD(paramSet);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VENDCD"), paramSet);
                        this.grd01_QA30112.SetValue(source);
                        grd = this.grd01_QA30112;
                        break;
                    case "2":
                        this.grd02_QA30112.Visible = true;
                        //source = _WSCOM.Inquery_VINCD(paramSet);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VINCD"), paramSet);
                        this.grd02_QA30112.SetValue(source);
                        grd = this.grd02_QA30112;
                        break;
                    case "3":
                        this.grd03_QA30112.Visible = true;
                        //source = _WSCOM.Inquery_DEFCD(paramSet);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DEFCD"), paramSet);
                        this.grd03_QA30112.SetValue(source);
                        grd = this.grd03_QA30112;
                        break;
                    case "4":
                        this.grd04_QA30112.Visible = true;
                        //source = _WSCOM.Inquery_DEF_PLACECD(paramSet);
                        source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DEF_PLACECD"), paramSet);
                        this.grd04_QA30112.SetValue(source);
                        grd = this.grd04_QA30112;
                        break;
                    default:
                        break;
                }

                this.AfterInvokeServer();

                this.grd_COROL(grd);
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

        //글로벌 표준에서는 출력기능 미사용.
        //protected override void BtnPrint_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        this.Print();
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.ToString());
        //    }
        //}

        #endregion

        #region -- commented --
        //private void Print_Old()
        //{
        //    try
        //    {
        //        string SELECT_GUBN = this.cbo01_SELECT_GUBN.GetValue().ToString();

        //        if (SELECT_GUBN == "1" || SELECT_GUBN == "2")
        //        {
        //            string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
        //            string BEG_VENDCD = this.cdx01_VENDCD_FROM.GetValue().ToString();
        //            string END_VENDCD = this.cdx01_VENDCD_TO.GetValue().ToString();
        //            string BEG_DATE = this.dte01_RCV_DATE_FROM.GetValue().ToString();
        //            string END_DATE = this.dte01_RCV_DATE_TO.GetValue().ToString();

        //            string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //공장구분 추가 2013.04.16 (배명희)

        //            string DATA_TYPE = "";
        //            if (this.chk01_DEF_ONLY.Checked)
        //            {
        //                DATA_TYPE = "BAD";
        //            }
        //            else
        //            {
        //                DATA_TYPE = "ALL";
        //            }

        //            string PRINT_TYPE = "";
        //            if (SELECT_GUBN == "1")
        //            {
        //                PRINT_TYPE = "VENDCD";
        //            }
        //            else
        //            {
        //                PRINT_TYPE = "VINCD";
        //            }

        //            string JOB_TYPE = "";
        //            if (this.chk01_OEM_YN.Checked)
        //            {
        //                JOB_TYPE = "OEM";
        //            }
        //            else
        //            {
        //                JOB_TYPE = "ALL";
        //            }

        //            HEParameterSet paramSet = new HEParameterSet();
        //            paramSet.Add("CORCD", _CORCD);
        //            paramSet.Add("BIZCD", BIZCD);
        //            paramSet.Add("BEG_VENDCD", BEG_VENDCD);
        //            paramSet.Add("END_VENDCD", END_VENDCD);
        //            paramSet.Add("BEG_DATE", BEG_DATE);
        //            paramSet.Add("END_DATE", END_DATE);
        //            paramSet.Add("DATA_TYPE", DATA_TYPE);
        //            paramSet.Add("PRINT_TYPE", PRINT_TYPE);
        //            paramSet.Add("JOB_TYPE", JOB_TYPE);
        //            paramSet.Add("LANG_SET", _LANG_SET);
        //            paramSet.Add("PLANT_DIV", PLANT_DIV);       //공장구분 추가 2013.04.16 (배명희)

        //            this.BeforeInvokeServer(true);

        //            //DataSet source = _WSCOMREPORT.QA40112P(paramSet);
        //            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40112P"), paramSet);

        //            HEParameterSet paramSet_CORNM = new HEParameterSet();
        //            paramSet_CORNM.Add("CORCD", _CORCD);
        //            paramSet_CORNM.Add("LANG_SET", _LANG_SET);

        //            //DataSet source_CORNM = _WSINQUERY.Inquery_CORNM(paramSet_CORNM);
        //            DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

        //            HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
        //            paramSet_BIZCDNM.Add("CORCD", _CORCD);
        //            paramSet_BIZCDNM.Add("BIZCD", BIZCD);
        //            paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);

        //            //DataSet source_BIZCDNM = _WSINQUERY.Inquery_BIZCDNM(paramSet_BIZCDNM);
        //            DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);

        //            this.AfterInvokeServer();

        //            string SELMODE = "";
        //            if (this.chk01_DEF_ONLY.Checked)
        //            {
        //                SELMODE = this.GetLabel("DEFECT_DESC");// "불량내역";
        //            }
        //            else
        //            {
        //                SELMODE = this.GetLabel("ALL_DESC");//"전체내역";
        //            }

        //            string PAPERSPLIT = "";
        //            if (this.chk01_PRINT_GUBN.Checked)
        //            {
        //                PAPERSPLIT = "Y";
        //            }
        //            else
        //            {
        //                PAPERSPLIT = "N";
        //            }

        //            if (SELECT_GUBN == "1")
        //            {
        //                QA41112 report1 = new QA41112();
        //                report1.SetDataSource(source.Tables[0]);
        //                this.SetParam(report1, "BEG_YMD", BEG_DATE);
        //                this.SetParam(report1, "END_YMD", END_DATE);
        //                this.SetParam(report1, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //                this.SetParam(report1, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //                this.SetParam(report1, "EMPNO", this.UserInfo.EmpNo);
        //                this.SetParam(report1, "EMPNAME", this.UserInfo.UserName);
        //                this.SetParam(report1, "BEG_VEND", BEG_VENDCD);
        //                this.SetParam(report1, "END_VEND", END_VENDCD);
        //                this.SetParam(report1, "PROD_PLANT", "");
        //                this.SetParam(report1, "INSPECT_DIV", "FNINS01");
        //                this.SetParam(report1, "SELMODE", SELMODE);
        //                this.SetParam(report1, "PAPERSPLIT", PAPERSPLIT);
        //                this.SetParam(report1, "SELOEM", JOB_TYPE);

        //                this.ReportCall(report1);
        //            }
        //            else
        //            {
        //                QA42112 report2 = new QA42112();
        //                report2.SetDataSource(source.Tables[0]);
        //                this.SetParam(report2, "BEG_YMD", BEG_DATE);
        //                this.SetParam(report2, "END_YMD", END_DATE);
        //                this.SetParam(report2, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //                this.SetParam(report2, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //                this.SetParam(report2, "EMPNO", this.UserInfo.EmpNo);
        //                this.SetParam(report2, "EMPNAME", this.UserInfo.UserName);
        //                this.SetParam(report2, "BEG_VEND", BEG_VENDCD);
        //                this.SetParam(report2, "END_VEND", END_VENDCD);
        //                this.SetParam(report2, "PROD_PLANT", "");
        //                this.SetParam(report2, "INSPECT_DIV", "FNINS01");
        //                this.SetParam(report2, "SELMODE", SELMODE);
        //                this.SetParam(report2, "PAPERSPLIT", PAPERSPLIT);
        //                this.SetParam(report2, "SELOEM", JOB_TYPE);

        //                this.ReportCall(report2);
        //            }
        //        }
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

        #region [ 사용자 정의 메서드 ]
        
        private void grd_COROL(AxFlexGrid grd)
        {
            if (grd.Rows.Count >= grd.Rows.Fixed)
            {
                grd.Styles.Add("COLOR_W").BackColor = Color.FromArgb(255, 255, 255);
                grd.Styles.Add("COLOR_B").BackColor = Color.FromArgb(200, 200, 255);
                grd.Styles.Add("COLOR_G").BackColor = Color.FromArgb(200, 255, 200);
                grd.Styles.Add("COLOR_Y").BackColor = Color.FromArgb(255, 255, 200);

                CellRange cr = new CellRange();

                for (int i = 1; i < grd.Rows.Count; i++)
                {
                    switch (grd.GetValue(i, "ORDER2").ToString())
                    {
                        case "2":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_B"];
                            break;
                        case "3":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_G"];
                            break;
                        case "4":
                            cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                            cr.Style = grd.Styles["COLOR_Y"];
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        //private void Print()
        //{
        //    try
        //    {
        //        string SELECT_GUBN = this.cbo01_SELECT_GUBN.GetValue().ToString();

        //        if (SELECT_GUBN == "1" || SELECT_GUBN == "2")
        //        {
        //            string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
        //            string BEG_VENDCD = this.cdx01_VENDCD_FROM.GetValue().ToString();
        //            string END_VENDCD = this.cdx01_VENDCD_TO.GetValue().ToString();
        //            string BEG_DATE = this.dte01_RCV_DATE_FROM.GetValue().ToString();
        //            string END_DATE = this.dte01_RCV_DATE_TO.GetValue().ToString();

        //            string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //공장구분 추가 2013.04.16 (배명희)

        //            string DATA_TYPE = "";
        //            if (this.chk01_DEF_ONLY.Checked)
        //            {
        //                DATA_TYPE = "BAD";
        //            }
        //            else
        //            {
        //                DATA_TYPE = "ALL";
        //            }

        //            string PRINT_TYPE = "";
        //            if (SELECT_GUBN == "1")
        //            {
        //                PRINT_TYPE = "VENDCD";
        //            }
        //            else
        //            {
        //                PRINT_TYPE = "VINCD";
        //            }

        //            string JOB_TYPE = "";
        //            if (this.chk01_OEM_YN.Checked)
        //            {
        //                JOB_TYPE = "OEM";
        //            }
        //            else
        //            {
        //                JOB_TYPE = "ALL";
        //            }

        //            HEParameterSet paramSet = new HEParameterSet();
        //            paramSet.Add("CORCD", _CORCD);
        //            paramSet.Add("BIZCD", BIZCD);
        //            paramSet.Add("BEG_VENDCD", BEG_VENDCD);
        //            paramSet.Add("END_VENDCD", END_VENDCD);
        //            paramSet.Add("BEG_DATE", BEG_DATE);
        //            paramSet.Add("END_DATE", END_DATE);
        //            paramSet.Add("DATA_TYPE", DATA_TYPE);
        //            paramSet.Add("PRINT_TYPE", PRINT_TYPE);
        //            paramSet.Add("JOB_TYPE", JOB_TYPE);
        //            paramSet.Add("LANG_SET", _LANG_SET);
        //            paramSet.Add("PLANT_DIV", PLANT_DIV);       //공장구분 추가 2013.04.16 (배명희)

        //            this.BeforeInvokeServer(true);

        //            //DataSet source = _WSCOMREPORT.QA40112P(paramSet);
        //            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA40112P"), paramSet);

        //            HEParameterSet paramSet_CORNM = new HEParameterSet();
        //            paramSet_CORNM.Add("CORCD", _CORCD);
        //            paramSet_CORNM.Add("LANG_SET", _LANG_SET);

        //            //DataSet source_CORNM = _WSINQUERY.Inquery_CORNM(paramSet_CORNM);
        //            DataSet source_CORNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_CORNM"), paramSet_CORNM);

        //            HEParameterSet paramSet_BIZCDNM = new HEParameterSet();
        //            paramSet_BIZCDNM.Add("CORCD", _CORCD);
        //            paramSet_BIZCDNM.Add("BIZCD", BIZCD);
        //            paramSet_BIZCDNM.Add("LANG_SET", _LANG_SET);

        //            //DataSet source_BIZCDNM = _WSINQUERY.Inquery_BIZCDNM(paramSet_BIZCDNM);
        //            DataSet source_BIZCDNM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_BIZCDNM"), paramSet_BIZCDNM);

        //            this.AfterInvokeServer();

        //            string SELMODE = "";
        //            if (this.chk01_DEF_ONLY.Checked)
        //            {
        //                SELMODE = this.GetLabel("DEFECT_DESC");// "불량내역";
        //            }
        //            else
        //            {
        //                SELMODE = this.GetLabel("ALL_DESC");//"전체내역";
        //            }

        //            string PAPERSPLIT = "";
        //            if (this.chk01_PRINT_GUBN.Checked)
        //            {
        //                PAPERSPLIT = "Y";
        //            }
        //            else
        //            {
        //                PAPERSPLIT = "N";
        //            }

        //            if (SELECT_GUBN == "1")
        //            {
        //                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
        //                report.ReportName = "RxRpt/QA41112E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
        //                source.Tables[0].TableName = "DATA";
        //                //source.Tables[0].WriteXml("c:/temp/QA41112.xml", XmlWriteMode.WriteSchema);

        //                /* 
        //                  * 신규 리포트 또는 리포트 컬럼 변동시 디자인용 컬럼정의 XML 파일은 리포트 호출시 
        //                  * 하기 코드를 이용하여 직접 생성하여 사용하세요 ( 주의. reb 파일을 먼저 report 하위에 생성후 아래 xml 파일을 생성하세요 )
        //                  * 넘기고자 하는 DataSet 개체의 이름이 ds 라면
        //                  * ds.Tables[0].TableName = "DATA";
        //                  * ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
        //                  * 생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 소스제어에 포함시켜 주세요. ( /Report 폴더 아래 )
        //                  * */


        //                // Main Section ( 메인리포트 파라메터셋 )
        //                HERexSection mainSection = new HERexSection(source, new HEParameterSet());


        //                mainSection.ReportParameter.Add("BEG_YMD", BEG_DATE);
        //                mainSection.ReportParameter.Add("END_YMD", END_DATE);
        //                mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //                mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //                mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
        //                mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
        //                mainSection.ReportParameter.Add("BEG_VEND", BEG_VENDCD);
        //                mainSection.ReportParameter.Add("END_VEND", END_VENDCD);
        //                mainSection.ReportParameter.Add("PROD_PLANT", "");
        //                mainSection.ReportParameter.Add("INSPECT_DIV", "FNINS01");
        //                mainSection.ReportParameter.Add("SELMODE", SELMODE);
        //                mainSection.ReportParameter.Add("PAPERSPLIT", PAPERSPLIT);
        //                mainSection.ReportParameter.Add("SELOEM", JOB_TYPE);


        //                report.Sections.Add("MAIN", mainSection);

        //                AxRexpertReportViewer.ShowReport(report);

        //            }
        //            else
        //            {
        //                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
        //                report.ReportName = "RxRpt/QA42112E";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
        //                source.Tables[0].TableName = "DATA";
        //                //source.Tables[0].WriteXml("c:/temp/QA42112.xml", XmlWriteMode.WriteSchema);


        //                /* 
        //                  * 신규 리포트 또는 리포트 컬럼 변동시 디자인용 컬럼정의 XML 파일은 리포트 호출시 
        //                  * 하기 코드를 이용하여 직접 생성하여 사용하세요 ( 주의. reb 파일을 먼저 report 하위에 생성후 아래 xml 파일을 생성하세요 )
        //                  * 넘기고자 하는 DataSet 개체의 이름이 ds 라면
        //                  * ds.Tables[0].TableName = "DATA";
        //                  * ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
        //                  * 생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 소스제어에 포함시켜 주세요. ( /Report 폴더 아래 )
        //                  * */


        //                // Main Section ( 메인리포트 파라메터셋 )
        //                HERexSection mainSection = new HERexSection(source, new HEParameterSet());


        //                mainSection.ReportParameter.Add("BEG_YMD", BEG_DATE);
        //                mainSection.ReportParameter.Add("END_YMD", END_DATE);
        //                mainSection.ReportParameter.Add("COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //                mainSection.ReportParameter.Add("BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //                mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
        //                mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
        //                mainSection.ReportParameter.Add("BEG_VEND", BEG_VENDCD);
        //                mainSection.ReportParameter.Add("END_VEND", END_VENDCD);
        //                mainSection.ReportParameter.Add("PROD_PLANT", "");
        //                mainSection.ReportParameter.Add("INSPECT_DIV", "FNINS01");
        //                mainSection.ReportParameter.Add("SELMODE", SELMODE);
        //                mainSection.ReportParameter.Add("PAPERSPLIT", PAPERSPLIT);
        //                mainSection.ReportParameter.Add("SELOEM", JOB_TYPE);

        //                report.Sections.Add("MAIN", mainSection);


        //                AxRexpertReportViewer.ShowReport(report);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        
        #endregion
    }
}
