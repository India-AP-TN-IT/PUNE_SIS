#region ▶ Description & History
/* 
 * 프로그램명 : QA30601 공정순회검사일보 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				-------------------------------------------------------------------------------------------------------------------------------------
 *				2015-07-29      배명희      통합WCF로 변경 
 *              2017-06-22      배명희      Rexpert적용
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
using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using System.Drawing;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>공정 순회검사일보 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-08-24 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-24 오후 5:29:52   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30601 : AxCommonBaseControl
    {
        //private IQA30601 _WSCOM;
        //private IQAREPORT _WSCOMREPORT;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30601";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";
        private string PAKAGE_NAME_REPORT = "APG_QAREPORT";

        #region [ 초기화 설정에 대한 정의 ]

        public QA30601()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30601>("QA02", "QA30601.svc", "CustomBinding");
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

                this.groupBox3.Text = this.GetLabel("QA30601_MSG1");
                this.groupBox_main.Text = this.GetLabel("QA30601_MSG2");

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

                this.cdx01_INSPECT_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_INSPECT_CLASSCD.PopupTitle = this.GetLabel("QA_INSPECT_BASECODE");//"검사코드";
                this.cdx01_INSPECT_CLASSCD.CodeParameterName = "INSPECT_CLASSCDR";
                this.cdx01_INSPECT_CLASSCD.NameParameterName = "INSPECT_CLASSNMR";
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("VINCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("ITEMCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_INSPECT_CLASSCD.SetCodePixedLength();

                this.grd01_QA30601.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;

                this.grd01_QA30601.AllowEditing = false;
                this.grd01_QA30601.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30601.Initialize(2,2);
              

                
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "DIV", "DIV");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "등록일자", "OCCUR_DATE", "REG_DATE");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "차종", "VINNM", "VIN");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품목", "ITEMNM", "ITEM");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품목명", "ITEMNM2", "ITEMNM3");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 170, "외관검사", "BCA_RSLT1", "EXT_INSPECT_RSLT1");//*체크
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "기타문제점", "BCC_RSLT2", "ETC_ISSUE_REMARK");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 220, "치수검사", "BCB_RSLT3", "DEM_INSPECT_RSLT3");//*체크
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 130, "검사순번", "INSPECT_SEQ", "INSPECT_SEQ");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 60, "FRT_LH", "FRT_LH");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 60, "FRT_RH", "FRT_RH");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 60, "RR_LH", "RR_LH");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 60, "RR_RH", "RR_RH");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 60, "3DR_LH", "DR3_LH");
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 60, "3DR_RH", "DR3_RH");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "1SHIFT", "DEF_QTY1", "1SHIFT");//*체크
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "2SHIFT", "DEF_QTY2", "2SHIFT");//*체크
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "3SHIFT", "DEF_QTY3", "3SHIFT");//*체크
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "점검항목", "INSPECT_ITEMNM", "CHECK_ITEMNM");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량명", "DEFNM", "DEFNM");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "조치결과", "MGRT_CNTTNM", "MGRT_RESULT");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "기타문제점", "ETC_ISSUE_REMARK", "ETC_ISSUE_REMARK");
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 220, "검사자(주간오전)", "DAY_WORKER", "DAY_INSPECTOR_AM");//*체크
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 230, "검사자(주간오후)", "DAY_WORKER2", "DAY_INSPECTOR_PM");//*체크
                this.grd01_QA30601.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "검사자(야간오전)", "NIGHT_WORKER", "NIGHT_INSPECTOR_AM");//*체크
                this.grd01_QA30601.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 160, "검사자(야간오후)", "NIGHT_WORKER2", "NIGHT_INSPECTOR_PM");//*체크
                this.grd01_QA30601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 0, "공장구분", "PLANT_DIV");
                this.grd01_QA30601.AddMerge(0, 1, "DIV", "DIV");
                this.grd01_QA30601.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01_QA30601.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd01_QA30601.AddMerge(0, 1, "INSPECT_CLASSCD", "INSPECT_CLASSCD");
                this.grd01_QA30601.AddMerge(0, 1, "OCCUR_DATE", "OCCUR_DATE");
                this.grd01_QA30601.AddMerge(0, 1, "VINNM", "VINNM");
                this.grd01_QA30601.AddMerge(0, 1, "ITEMNM", "ITEMNM");
                this.grd01_QA30601.AddMerge(0, 1, "ITEMNM2", "ITEMNM2");
                this.grd01_QA30601.AddMerge(0, 1, "BCA_RSLT1", "BCA_RSLT1");
                this.grd01_QA30601.AddMerge(0, 1, "BCC_RSLT2", "BCC_RSLT2");
                this.grd01_QA30601.AddMerge(0, 1, "BCB_RSLT3", "BCB_RSLT3");
                this.grd01_QA30601.AddMerge(0, 1, "INSPECT_SEQ", "INSPECT_SEQ");
                this.grd01_QA30601.AddMerge(0, 1, "FRT_LH", "FRT_LH");
                this.grd01_QA30601.AddMerge(0, 1, "FRT_RH", "FRT_RH");
                this.grd01_QA30601.AddMerge(0, 1, "RR_LH", "RR_LH");
                this.grd01_QA30601.AddMerge(0, 1, "RR_RH", "RR_RH");
                this.grd01_QA30601.AddMerge(0, 1, "DR3_LH", "DR3_LH");
                this.grd01_QA30601.AddMerge(0, 1, "DR3_RH", "DR3_RH");
                this.grd01_QA30601.AddMerge(0, 0, "DEF_QTY1", "DEF_QTY3");
                this.grd01_QA30601.AddMerge(0, 1, "INSPECT_ITEMNM", "INSPECT_ITEMNM");
                this.grd01_QA30601.AddMerge(0, 1, "DEFNM", "DEFNM");
                this.grd01_QA30601.AddMerge(0, 1, "MGRT_CNTTNM", "MGRT_CNTTNM");
                this.grd01_QA30601.AddMerge(0, 1, "ETC_ISSUE_REMARK", "ETC_ISSUE_REMARK");
                this.grd01_QA30601.AddMerge(0, 0, "DAY_WORKER", "NIGHT_WORKER2");

                this.grd01_QA30601.SetHeadTitle(0, "DIV", this.GetLabel("DIV"));//"법인코드");
                this.grd01_QA30601.SetHeadTitle(0, "CORCD", this.GetLabel("CORCD"));//"법인코드");
                this.grd01_QA30601.SetHeadTitle(0, "BIZCD", this.GetLabel("BIZCD"));//"사업장코드");
                this.grd01_QA30601.SetHeadTitle(0, "INSPECT_CLASSCD", this.GetLabel("QA_INSPECT_BASECODE"));//"검사코드");
                this.grd01_QA30601.SetHeadTitle(0, "OCCUR_DATE", this.GetLabel("REG_DATE"));//"등록일자");
                this.grd01_QA30601.SetHeadTitle(0, "VINNM", this.GetLabel("VIN"));//"차종");
                this.grd01_QA30601.SetHeadTitle(0, "ITEMNM", this.GetLabel("ITEM"));//"품목");
                this.grd01_QA30601.SetHeadTitle(0, "ITEMNM2", this.GetLabel("ITEMNM3"));//"품목명");
                this.grd01_QA30601.SetHeadTitle(0, "BCA_RSLT1", this.GetLabel("EXT_INSPECT_RSLT1"));//"외관검사");
                this.grd01_QA30601.SetHeadTitle(0, "BCC_RSLT2", this.GetLabel("ETC_ISSUE_REMARK"));//"기타문제점");
                this.grd01_QA30601.SetHeadTitle(0, "BCB_RSLT3", this.GetLabel("DEM_INSPECT_RSLT3"));//"치수검사");
                this.grd01_QA30601.SetHeadTitle(0, "INSPECT_SEQ", this.GetLabel("INSPECT_SEQ"));//"검사순번");
                this.grd01_QA30601.SetHeadTitle(0, "FRT_LH", this.GetLabel("FRT_LH"));//"FRT_LH");
                this.grd01_QA30601.SetHeadTitle(0, "FRT_RH", this.GetLabel("FRT_RH"));//"FRT_RH");
                this.grd01_QA30601.SetHeadTitle(0, "RR_LH", this.GetLabel("RR_LH"));//"RR_LH");
                this.grd01_QA30601.SetHeadTitle(0, "RR_RH", this.GetLabel("RR_RH"));//"RR_RH");
                this.grd01_QA30601.SetHeadTitle(0, "DR3_LH", this.GetLabel("DR3_LH"));//"DR3_LH");
                this.grd01_QA30601.SetHeadTitle(0, "DR3_RH", this.GetLabel("DR3_RH"));//"DR3_RH");
                this.grd01_QA30601.SetHeadTitle(0, "DEF_QTY1", this.GetLabel("DEF_QTY"));//"불량수량");
                this.grd01_QA30601.SetHeadTitle(1, "DEF_QTY1", this.GetLabel("1SHIFT"));//"1SHIFT");
                this.grd01_QA30601.SetHeadTitle(1, "DEF_QTY2", this.GetLabel("2SHIFT"));//"2SHIFT");
                this.grd01_QA30601.SetHeadTitle(1, "DEF_QTY3", this.GetLabel("3SHIFT"));//"3SHIFT");
                this.grd01_QA30601.SetHeadTitle(0, "INSPECT_ITEMNM", this.GetLabel("CHECK_ITEMNM"));//"점검항목");
                this.grd01_QA30601.SetHeadTitle(0, "DEFNM", this.GetLabel("DEFNM"));//"불량명");
                this.grd01_QA30601.SetHeadTitle(0, "MGRT_CNTTNM", this.GetLabel("MGRT_RESULT"));//"조치결과");
                this.grd01_QA30601.SetHeadTitle(0, "ETC_ISSUE_REMARK", this.GetLabel("ETC_ISSUE_REMARK"));//"기타문제점");
                this.grd01_QA30601.SetHeadTitle(0, "DAY_WORKER", this.GetLabel("WRITE_EMP"));//"작성자");
                this.grd01_QA30601.SetHeadTitle(1, "DAY_WORKER", this.GetLabel("1SHIFT"));//"1SHIFT");
                this.grd01_QA30601.SetHeadTitle(1, "DAY_WORKER2", this.GetLabel("2SHIFT"));//"2SHIFT");
                this.grd01_QA30601.SetHeadTitle(1, "NIGHT_WORKER", this.GetLabel("3SHIFT"));//"3SHIFT");
                this.grd01_QA30601.SetHeadTitle(1, "NIGHT_WORKER2", this.GetLabel("NIGHT_PM"));//"야간(오후)");

                
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Date, "OCCUR_DATE");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "FRT_LH");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "FRT_RH");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "RR_LH");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "RR_RH");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "DR3_LH");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "DR3_RH");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY1");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY2");
                this.grd01_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY3");

                //this.grd01_QA30601.Cols["DIV"].AllowMerging = true;
                //this.grd01_QA30601.Cols["CORCD"].AllowMerging = true;
                //this.grd01_QA30601.Cols["BIZCD"].AllowMerging = true;
                //this.grd01_QA30601.Cols["INSPECT_CLASSCD"].AllowMerging = true;
                //this.grd01_QA30601.Cols["OCCUR_DATE"].AllowMerging = true;
                //this.grd01_QA30601.Cols["VINNM"].AllowMerging = true;
                //this.grd01_QA30601.Cols["ITEMNM"].AllowMerging = true;
                //this.grd01_QA30601.Cols["ITEMNM2"].AllowMerging = true;
                //this.grd01_QA30601.Cols["BCA_RSLT1"].AllowMerging = true;
                //this.grd01_QA30601.Cols["BCC_RSLT2"].AllowMerging = true;
                //this.grd01_QA30601.Cols["BCB_RSLT3"].AllowMerging = true;

                this.grd01_QA30601.Cols["DIV"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["CORCD"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["BIZCD"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["INSPECT_CLASSCD"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["OCCUR_DATE"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["VINNM"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["ITEMNM"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["ITEMNM2"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["BCA_RSLT1"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["BCC_RSLT2"].Style.BackColor = Color.White;
                this.grd01_QA30601.Cols["BCB_RSLT3"].Style.BackColor = Color.White;


                this.grd02_QA30601.AllowEditing = false;
                this.grd02_QA30601.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA30601.Initialize();
                this.grd02_QA30601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA30601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "등록일자", "OCCUR_DATE", "REG_DATE");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "PROC_DATE", "OCCUR_DATE");
                this.grd02_QA30601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "불량번호", "DPTNO", "DEFNO");
                this.grd02_QA30601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "불량_SEQ", "DPT_SEQ", "BAD_SEQ");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "ALC", "ALCCD");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "완제품", "ASSYPNO", "ASSYPNO");//*체크
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "A'SSY NAME", "ASSYPNM", "ASSYPNM");//*체크
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "PART NAME", "PARTNM", "PARTNM");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "폐기수량", "DIS_QTY", "DIS_QTY");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "수정수량", "AMD_QTY", "AMD_QTY");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "불량명", "DEFNM", "DEFNM");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "조치구분", "MGRT_NM", "MGRT_NM");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "귀책", "IMPUT_DIVNM", "IMPUT_DIVNM");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "귀책업체", "IMPUT_VENDNM", "IMPUT_VENDNM");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "고품접수", "RET_PRDT_YN", "RET_PRDT_YN");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "조치확인", "CHK_MGRT_YN", "CHK_MGRT_YN");//*체크
                this.grd02_QA30601.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "조치결과", "MGRT_CLASSCD", "MGRT_RESULT");
                this.grd02_QA30601.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "조치결과", "MGRT_CLASSNM", "MGRT_RESULT");
                this.grd02_QA30601.SetColumnType(AxFlexGrid.FCellType.Date, "OCCUR_DATE");
                this.grd02_QA30601.SetColumnType(AxFlexGrid.FCellType.Date, "PROC_DATE");
                this.grd02_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "DIS_QTY");
                this.grd02_QA30601.SetColumnType(AxFlexGrid.FCellType.Int, "AMD_QTY");
                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가
                //2016.02.15 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

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
                this.grd01_QA30601.InitializeDataSource();
                this.grd02_QA30601.InitializeDataSource();

                this.cdx_SETTING();
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
                string OCCUR_BEG_DATE = this.dte01_OCCUR_BEG_DATE.GetDateText().ToString();
                string OCCUR_END_DATE = this.dte01_OCCUR_END_DATE.GetDateText().ToString();
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet paramSet1 = new HEParameterSet();
                paramSet1.Add("CORCD", _CORCD);
                paramSet1.Add("BIZCD", BIZCD);
                paramSet1.Add("OCCUR_BEG_DATE", OCCUR_BEG_DATE);
                paramSet1.Add("OCCUR_END_DATE", OCCUR_END_DATE);
                paramSet1.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet1.Add("LANG_SET", _LANG_SET);
                paramSet1.Add("PLANT_DIV", PLANT_DIV);

                HEParameterSet paramSet2 = new HEParameterSet();
                paramSet2.Add("CORCD", _CORCD);
                paramSet2.Add("BIZCD", BIZCD);
                paramSet2.Add("OCCUR_BEG_DATE", OCCUR_BEG_DATE);
                paramSet2.Add("OCCUR_END_DATE", OCCUR_END_DATE);
                paramSet2.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet2.Add("MODE", "2");
                paramSet2.Add("LANG_SET", _LANG_SET);
                paramSet2.Add("PLANT_DIV", PLANT_DIV);

                this.BeforeInvokeServer(true);

                //DataSet source_MAIN = _WSCOM.Inquery_MAIN(paramSet1);
                DataSet source_MAIN = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MAIN"), paramSet1);
                
                //DataSet source_QA6040_QA2020 = _WSCOM.Inquery_QA6040_QA2020(paramSet2);
                DataSet source_QA6040_QA2020 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA6040_QA2020"), paramSet2);

                this.AfterInvokeServer();

                this.grd01_QA30601.SetValue(source_MAIN);
                this.grd02_QA30601.SetValue(source_QA6040_QA2020);
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
                Print();
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
                string OCCUR_BEG_DATE = this.dte01_OCCUR_BEG_DATE.GetDateText().ToString();
                string OCCUR_END_DATE = this.dte01_OCCUR_END_DATE.GetDateText().ToString();
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("OCCUR_BEG_DATE", OCCUR_BEG_DATE);
                paramSet.Add("OCCUR_END_DATE", OCCUR_END_DATE);
                paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA30601P"), paramSet);

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
                report.ReportName = "RxRpt/QA31601";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
                source.Tables[0].TableName = "DATA";
                //source.Tables[0].WriteXml("c:/temp/QA31601.xml", XmlWriteMode.WriteSchema);

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
        #endregion

        #region commented

        //private void Print_Old()
        //{
        //    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
        //    string OCCUR_BEG_DATE = this.dte01_OCCUR_BEG_DATE.GetValue().ToString();
        //    string OCCUR_END_DATE = this.dte01_OCCUR_END_DATE.GetValue().ToString();
        //    string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();

        //    HEParameterSet paramSet = new HEParameterSet();
        //    paramSet.Add("CORCD", _CORCD);
        //    paramSet.Add("BIZCD", BIZCD);
        //    paramSet.Add("OCCUR_BEG_DATE", OCCUR_BEG_DATE);
        //    paramSet.Add("OCCUR_END_DATE", OCCUR_END_DATE);
        //    paramSet.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
        //    paramSet.Add("LANG_SET", _LANG_SET);

        //    this.BeforeInvokeServer(true);

        //    //DataSet source = _WSCOMREPORT.QA30601P(paramSet);
        //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_REPORT, "QA30601P"), paramSet);

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

        //    QA31601 report = new QA31601();
        //    report.SetDataSource(source.Tables[0]);
        //    this.SetParam(report, "COR_NM", source_CORNM.Tables[0].Rows[0]["CORNM"].ToString());
        //    this.SetParam(report, "BIZ_NM", source_BIZCDNM.Tables[0].Rows[0]["BIZCDNM"].ToString());
        //    this.SetParam(report, "EMPNO", this.UserInfo.EmpNo);
        //    this.SetParam(report, "EMPNAME", this.UserInfo.UserName);

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

        #region [ 사용자 정의 메서드 ] 

        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("VINCD", "");
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("ITEMCD", "");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void grd01_QA30601_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30601.SelectedRowIndex;

                if (Row >= this.grd01_QA30601.Rows.Fixed)
                {
                    string CORCD = this.grd01_QA30601.GetValue(Row, "CORCD").ToString();
                    string BIZCD = this.grd01_QA30601.GetValue(Row, "BIZCD").ToString();
                    string OCCUR_DATE = this.grd01_QA30601.GetValue(Row, "OCCUR_DATE").ToString();
                    string INSPECT_CLASSCD = this.grd01_QA30601.GetValue(Row, "INSPECT_CLASSCD").ToString();
                    string PLANT_DIV = this.grd01_QA30601.GetValue(Row, "PLANT_DIV").ToString();

                    ShowPopup(new QA20601(CORCD, BIZCD, OCCUR_DATE, INSPECT_CLASSCD, PLANT_DIV));
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        #endregion
    }
}
