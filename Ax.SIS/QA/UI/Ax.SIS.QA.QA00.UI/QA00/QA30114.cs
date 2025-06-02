#region ▶ Description & History
/* 
 * 프로그램명 : QA30114 입고불량유효성평가결과 조회 및 출력
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
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

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>입고불량유효성평가결과 조회 및 출력</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 5:34:21<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 5:34:21   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30114 : AxCommonBaseControl
    {
       // private IQA20114 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20114";
        private string PACKAGE_NAME_FILESERVICE = "APG_FILESERVICE";
        HttpFileManager _manager;

        #region [ 초기화 작업 정의 ]

        public QA30114()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20114>("QA00", "QA20114.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            _manager = new HttpFileManager();
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
                this._buttonsControl.BtnPrint.Visible = false;
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

                DataSet source = this.GetTypeCode("A1");
                this.cbo01_JOB_TYPE.DataBind(source.Tables[0], true);
                this.cbo01_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD"); //귀책업체코드
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.17 공장구분 조회조건 추가
                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

                this.grd01_QA30114.AllowEditing = false;
                this.grd01_QA30114.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30114.Initialize(2, 2);
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "", "BGCOLOR","");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "", "FGCOLOR","");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "", "SEQ","");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "발생일자", "RCV_DATE", "OCCUR_DATE");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "불량번호", "DEFNO", "DEFNO");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "발생장소코드", "DEF_PLACECD", "OCCUR_PLACECD2");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "발생장소", "DEF_PLACENM", "OCCUR_PLACECD");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "귀책업체코드", "VENDCD", "IMPUT_VENDCD");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO_TITLE");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNM", "PARTNM");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "차종", "VINCD","VIN");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINTYPE","VIN");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMCD","ITEM");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMTYPE","ITEM");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 140, "불량내용코드", "DEFCD", "DEFCD");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "불량내용", "DEFNM", "DEFNM");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "조치내용코드", "MGRT_CNTTCD", "MGRT_CNTTCD");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "조치내용", "MGRT_CNTTNM", "MGRT_CNTTNM");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "검사원", "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "검사원", "INSPECT_EMPNONM", "INSPECT_EMPNONM");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 160, "첨부파일", "DOCNO", "ATTACH_FILE");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "첨부파일명", "ATT_FILE_NM", "ATT_FILE_NAME2");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "개선일정", "AMEND_DATE", "IMPROV_DATA");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 90, "4M구분", "VER_4M_TYPE", "VER_4M_TYPE");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "4M구분", "VER_4M_TYPENM", "VER_4M_TYPE");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "확인일자", "VER1_CHK_DATE", "CONF_DATE");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "확인결과", "VER1_CHKRSLT_TYPE", "CONF_RESULT");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "확인결과", "VER1_CHKRSLT_TYPENM", "CONF_RESULT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "확인결과", "VER1_CHKRSLT_TYPE2", "CONF_RESULT");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "확인결과", "VER1_CHKRSLT_TYPE2NM", "CONF_RESULT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "재점검일자", "VER1_RECHK_DATE", "RECHECK_DATE");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "재점검결과", "VER1_RECHKRSLT_TYPE", "RECHECK_RESULT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "재점검결과", "VER1_RECHKRSLT_TYPENM", "RECHECK_RESULT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "재점검결과", "VER1_RECHKRSLT_TYPE2", "RECHECK_RESULT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "재점검결과", "VER1_RECHKRSLT_TYPE2NM", "RECHECK_RESULT");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "점검일자", "VER2_CHK_DATE", "CHECK_DATE");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "점검결과", "VER2_CHKRSLT", "CHECK_RESULT");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "점검결과", "VER2_CHKRSLTNM", "CHECK_RESULT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "개선효과", "VER2_AMEND_RSLT", "IMPROV_EFFECT");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "개선효과", "VER2_AMEND_RSLTNM", "IMPROV_EFFECT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "재점검일자", "VER2_RECHK_DATE", "RECHECK_DATE");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "재점검결과", "VER2_RECHKRSLT", "RECHECK_RESULT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "재점검결과", "VER2_RECHKRSLTNM", "RECHECK_RESULT");
                this.grd01_QA30114.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 80, "재발횟수", "VER2_RET_TIME", "RET_TIME");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "적용여부", "ADD_AMEND_APPLY_YN", "APPLY_YN2");
                this.grd01_QA30114.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 240, "표준화 및 수평전개", "FILENAME", "STD_FILENM"); //첨부파일(입고불량 대책서등록에서 저장(SCM_QA20002P2)) 추가 2016.4.12 이현범
                this.grd01_QA30114.AddHiddenColumn("ATT_FILE");
                this.grd01_QA30114.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA30114.SetColumnType(AxFlexGrid.FCellType.Decimal, "VER2_RET_TIME");
                this.grd01_QA30114.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd01_QA30114.SetColumnType(AxFlexGrid.FCellType.Date, "AMEND_DATE");
                this.grd01_QA30114.SetColumnType(AxFlexGrid.FCellType.Date, "VER1_CHK_DATE");
                this.grd01_QA30114.SetColumnType(AxFlexGrid.FCellType.Date, "VER1_RECHK_DATE");
                this.grd01_QA30114.SetColumnType(AxFlexGrid.FCellType.Date, "VER2_CHK_DATE");
                this.grd01_QA30114.SetColumnType(AxFlexGrid.FCellType.Date, "VER2_RECHK_DATE");

                this.grd01_QA30114.AddMerge(0, 1, "SEQ", "SEQ");
                this.grd01_QA30114.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01_QA30114.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd01_QA30114.AddMerge(0, 1, "RCV_DATE", "RCV_DATE");
                this.grd01_QA30114.AddMerge(0, 1, "DEFNO", "DEFNO");
                this.grd01_QA30114.AddMerge(0, 1, "DEF_PLACECD", "DEF_PLACECD");
                this.grd01_QA30114.AddMerge(0, 1, "DEF_PLACENM", "DEF_PLACENM");
                this.grd01_QA30114.AddMerge(0, 1, "VENDCD", "VENDCD");
                this.grd01_QA30114.AddMerge(0, 1, "VENDNM", "VENDNM");
                this.grd01_QA30114.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01_QA30114.AddMerge(0, 1, "INSPECT_CLASSCD", "INSPECT_CLASSCD");
                this.grd01_QA30114.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd01_QA30114.AddMerge(0, 1, "VINCD", "VINCD");
                this.grd01_QA30114.AddMerge(0, 1, "VINTYPE", "VINTYPE");
                this.grd01_QA30114.AddMerge(0, 1, "ITEMCD", "ITEMCD");
                this.grd01_QA30114.AddMerge(0, 1, "ITEMTYPE", "ITEMTYPE");
                this.grd01_QA30114.AddMerge(0, 1, "DEF_QTY", "DEF_QTY");
                this.grd01_QA30114.AddMerge(0, 1, "DEFCD", "DEFCD");
                this.grd01_QA30114.AddMerge(0, 1, "DEFNM", "DEFNM");
                this.grd01_QA30114.AddMerge(0, 1, "MGRT_CNTTCD", "MGRT_CNTTCD");
                this.grd01_QA30114.AddMerge(0, 1, "MGRT_CNTTNM", "MGRT_CNTTNM");
                this.grd01_QA30114.AddMerge(0, 1, "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd01_QA30114.AddMerge(0, 1, "INSPECT_EMPNONM", "INSPECT_EMPNONM");
                this.grd01_QA30114.AddMerge(0, 1, "DOCNO", "DOCNO");
                this.grd01_QA30114.AddMerge(0, 1, "ATT_FILE_NM", "ATT_FILE_NM");
                this.grd01_QA30114.AddMerge(0, 1, "AMEND_DATE", "AMEND_DATE");
                this.grd01_QA30114.AddMerge(0, 1, "VER_4M_TYPE", "VER_4M_TYPE");
                this.grd01_QA30114.AddMerge(0, 1, "VER_4M_TYPENM", "VER_4M_TYPENM");
                this.grd01_QA30114.AddMerge(0, 1, "FILENAME", "FILENAME");

                this.grd01_QA30114.AddMerge(0, 0, "VER1_CHK_DATE", "VER1_RECHKRSLT_TYPE2NM");
                this.grd01_QA30114.AddMerge(0, 0, "VER2_CHK_DATE", "VER2_RET_TIME");

                //this.grd01_QA30114.AddMerge(1, 1, "VER1_CHKRSLT_TYPE", "VER1_CHKRSLT_TYPE2NM");
                //this.grd01_QA30114.AddMerge(1, 1, "VER1_RECHKRSLT_TYPE", "VER1_RECHKRSLT_TYPE2NM");

                this.grd01_QA30114.SetHeadTitle(0, "CORCD", this.GetLabel("CORCD"));//"법인코드");
                this.grd01_QA30114.SetHeadTitle(0, "BIZCD", this.GetLabel("BIZCD"));// "사업장코드");
                this.grd01_QA30114.SetHeadTitle(0, "RCV_DATE", this.GetLabel("OCCUR_DATE"));//"발생일자");
                this.grd01_QA30114.SetHeadTitle(0, "DEFNO", this.GetLabel("DEFNO"));//"불량번호");
                this.grd01_QA30114.SetHeadTitle(0, "DEF_PLACECD", this.GetLabel("OCCUR_PLACECD2"));//"발생장소코드");
                this.grd01_QA30114.SetHeadTitle(0, "DEF_PLACENM", this.GetLabel("OCCUR_PLACECD"));//"발생장소");
                this.grd01_QA30114.SetHeadTitle(0, "VENDCD", this.GetLabel("IMPUT_VENDCD"));//"귀책업체코드");
                this.grd01_QA30114.SetHeadTitle(0, "VENDNM", this.GetLabel("IMPUT_VENDNM"));//"귀책업체");
                this.grd01_QA30114.SetHeadTitle(0, "PARTNO", this.GetLabel("PARTNO_TITLE"));//"품번");
                this.grd01_QA30114.SetHeadTitle(0, "INSPECT_CLASSCD", this.GetLabel("QA_INSPECT_BASECODE"));//"검사코드");
                this.grd01_QA30114.SetHeadTitle(0, "PARTNM", this.GetLabel("PARTNMTITLE"));//"품명");
                this.grd01_QA30114.SetHeadTitle(0, "VINCD", this.GetLabel("VIN"));//"차종");
                this.grd01_QA30114.SetHeadTitle(0, "VINTYPE", this.GetLabel("VIN"));//"차종");
                this.grd01_QA30114.SetHeadTitle(0, "ITEMCD", this.GetLabel("ITEM"));//"품목");
                this.grd01_QA30114.SetHeadTitle(0, "ITEMTYPE", this.GetLabel("ITEM"));//"품목");
                this.grd01_QA30114.SetHeadTitle(0, "DEF_QTY", this.GetLabel("DEF_QTY"));//"불량수량");
                this.grd01_QA30114.SetHeadTitle(0, "DEFCD", this.GetLabel("DEF_CNTT_CD"));//"불량내용코드");
                this.grd01_QA30114.SetHeadTitle(0, "DEFNM", this.GetLabel("DEF_CNTT"));//"불량내용");
                this.grd01_QA30114.SetHeadTitle(0, "MGRT_CNTTCD", this.GetLabel("MGRT_CNTTCD"));//"조치내용코드");
                this.grd01_QA30114.SetHeadTitle(0, "MGRT_CNTTNM", this.GetLabel("MGRT_CNTT"));//"조치내용");
                this.grd01_QA30114.SetHeadTitle(0, "INSPECT_EMPNO", this.GetLabel("INSPECT_NAME"));//"검사원");
                this.grd01_QA30114.SetHeadTitle(0, "INSPECT_EMPNONM", this.GetLabel("INSPECT_NAME"));//"검사원");
                this.grd01_QA30114.SetHeadTitle(0, "DOCNO", this.GetLabel("ATTACH_FILE"));//"첨부파일");
                this.grd01_QA30114.SetHeadTitle(0, "ATT_FILE_NM", this.GetLabel("ATT_FILE_NAME2"));//"첨부파일명");
                this.grd01_QA30114.SetHeadTitle(0, "AMEND_DATE", this.GetLabel("IMPROV_DATA"));//"개선일정");
                this.grd01_QA30114.SetHeadTitle(0, "VER_4M_TYPE", this.GetLabel("VER_4M_TYPE"));//"4M구분");
                this.grd01_QA30114.SetHeadTitle(0, "VER_4M_TYPENM", this.GetLabel("VER_4M_TYPE"));//"4M구분");
                this.grd01_QA30114.SetHeadTitle(0, "VER1_CHK_DATE", this.GetLabel("CONF_DATE"));//"확인일자");
                this.grd01_QA30114.SetHeadTitle(0, "VER1_CHK_DATE", this.GetLabel("VER1_CHK_DATE2"));//"유효성1차");
                this.grd01_QA30114.SetHeadTitle(0, "ADD_AMEND_APPLY_YN", this.GetLabel("ADD_IMPROV_ACTIVITY"));//"추가개선활동");
                this.grd01_QA30114.SetHeadTitle(0, "VER2_CHK_DATE", this.GetLabel("VER2_CHK_DATE2"));//"유효성2차");

                this.grd01_QA30114.SetHeadTitle(1, "VER1_CHK_DATE", this.GetLabel("CONF_DATE"));//"확인일자");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_CHKRSLT_TYPE", this.GetLabel("CONF_RESULT"));//"확인결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_CHKRSLT_TYPENM", this.GetLabel("CONF_RESULT"));//"확인결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_CHKRSLT_TYPE2", this.GetLabel("CONF_RESULT"));//"확인결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_CHKRSLT_TYPE2NM", this.GetLabel("CONF_RESULT"));//"확인결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_RECHK_DATE", this.GetLabel("RECHECK_DATE"));//"재점검일자");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_RECHKRSLT_TYPE", this.GetLabel("RECHECK_RESULT"));//"재점검결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_RECHKRSLT_TYPENM", this.GetLabel("RECHECK_RESULT"));//"재점검결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_RECHKRSLT_TYPE2", this.GetLabel("RECHECK_RESULT"));//"재점검결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER1_RECHKRSLT_TYPE2NM", this.GetLabel("RECHECK_RESULT"));//"재점검결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_CHK_DATE", this.GetLabel("CHECK_DATE"));//"점검일자");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_CHKRSLT", this.GetLabel("CHECK_RESULT"));//"점검결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_CHKRSLTNM", this.GetLabel("CHECK_RESULT"));//"점검결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_AMEND_RSLT", this.GetLabel("IMPROV_EFFECT"));//"개선효과");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_AMEND_RSLTNM", this.GetLabel("IMPROV_EFFECT"));//"개선효과");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_RECHK_DATE", this.GetLabel("RECHECK_DATE"));//"재점검일자");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_RECHKRSLT", this.GetLabel("RECHECK_RESULT"));//"재점검결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_RECHKRSLTNM", this.GetLabel("RECHECK_RESULT"));//"재점검결과");
                this.grd01_QA30114.SetHeadTitle(1, "VER2_RET_TIME", this.GetLabel("RET_TIME"));//"재발횟수");
                this.grd01_QA30114.SetHeadTitle(1, "ADD_AMEND_APPLY_YN", this.GetLabel("APPLY_YN2"));//"적용여부");


                this.SetRequired(lbl01_BIZNM, lbl01_OCCUR_DATE);

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
                this.grd01_QA30114.InitializeDataSource();
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
                string JOB_TYPE = this.cbo01_JOB_TYPE.GetValue().ToString();
                string PARTNO_PARTNONM = this.txt01_PARTNO_PARTNONM.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //공장구분 추가 2013.04.17 (배명희)


                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE_FROM", RCV_DATE_FROM);
                paramSet.Add("RCV_DATE_TO", RCV_DATE_TO);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("JOB_TYPE", JOB_TYPE);
                paramSet.Add("PARTNO_PARTNONM", PARTNO_PARTNONM);
                paramSet.Add("LANG_SET", _LANG_SET);

                paramSet.Add("PLANT_DIV", PLANT_DIV);                        //공장구분 추가 2013.04.17 (배명희)

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30114.SetValue(source);

                this.grd_COROL(grd01_QA30114);
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

        private void grd01_QA30114_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30114.SelectedRowIndex;
                int Col = this.grd01_QA30114.Col;

                if (Row >= this.grd01_QA30114.Rows.Fixed)
                {
                    string BIZCD = this.grd01_QA30114.GetValue(Row, "BIZCD").ToString();
                    string RCV_DATE = this.grd01_QA30114.GetValue(Row, "RCV_DATE").ToString();
                    string DEFNO = this.grd01_QA30114.GetValue(Row, "DEFNO").ToString();
                    string DOCNO = this.grd01_QA30114.GetValue(Row, "DOCNO").ToString();

                    switch (this.grd01_QA30114.Cols[Col].Name.ToString().ToUpper().Trim())
                    {
                        case "ATT_FILE_NM":
                            HEParameterSet paramSet = new HEParameterSet();
                            paramSet.Add("CORCD", _CORCD);
                            paramSet.Add("BIZCD", BIZCD);
                            paramSet.Add("DOCNO", DOCNO);
                            paramSet.Add("LANG_SET", _LANG_SET);

                            this.BeforeInvokeServer(true);

                            //DataSet source = _WSCOM.Inquery_GET_FILE(paramSet);
                            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GET_FILE"), paramSet);

                            this.AfterInvokeServer();

                            if (source.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = source.Tables[0].Rows[0];

                                if ((dr["ATT_FILE"]) != System.DBNull.Value)
                                {
                                    byte[] _FILE_DATA = null;
                                    _FILE_DATA = (byte[])(dr["ATT_FILE"]);

                                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + "_" + dr["ATT_FILE_NM"].ToString();
                                    System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                                    TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                                    TEMP_FILE.Close();
                                    TEMP_FILE.Dispose();

                                    System.Diagnostics.Process.Start(FILE_NAME);
                                }
                            }

                            break;
                        case "FILENAME":
                            if (string.IsNullOrEmpty(this.grd01_QA30114.GetValue(Row, "FILENAME").ToString()))
                                return;

                            openFile(this.grd01_QA30114.GetValue(Row, "ATT_FILE").ToString());

                            break;
                        default:
                            if (this.grd01_QA30114.GetValue(Row, "VER1_CHK_DATE").ToString() != "")
                            {
                                ShowPopup(new QA30115(BIZCD, RCV_DATE, DEFNO));
                            }
                            else
                            {
                                //MsgBox.Show("유효성평가가 수행되지 않았습니다.");
                                MsgCodeBox.Show("QA00-025");
                            }

                            break;
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

        #region [ 사용자 정의 메서드 ]

        private void grd_COROL(AxFlexGrid grd)
        {
            grd.Styles.Add("COLOR_B").BackColor = Color.FromArgb(247, 185, 56);
            grd.Styles.Add("COLOR_F").ForeColor = Color.FromArgb(255, 0, 0);

            CellRange cr = new CellRange();
            for (int i = 1; i < grd.Rows.Count; i++)
            {
                switch (grd.GetValue(i, "FGCOLOR").ToString())
                {
                    case "1":
                        cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                        cr.Style = grd.Styles["COLOR_F"];
                        break;
                    default:
                        break;
                }

                switch (grd.GetValue(i, "BGCOLOR").ToString())
                {
                    case "1":
                        cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                        cr.Style = grd.Styles["COLOR_B"];
                        break;
                    default:
                        break;
                }
            }
        }

        private void openFile(string fileId)
        {
            try
            {
                if (!String.IsNullOrEmpty(fileId))
                {
                    try
                    {
                        HEParameterSet paramSet = new HEParameterSet();
                        paramSet.Add("FILEID", fileId);
                        DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_FILESERVICE, "GET_FILE_METAINFO"), paramSet);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string FileName = ds.Tables[0].Rows[0]["FILENAME"].ToString();
                            string FilePath = ds.Tables[0].Rows[0]["PATH"].ToString();

                            string ServerFileName = fileId + FileName;
                            string tempFileName = String.Format("{0}temp{1}{2}", "C:/Temp/Ax.SIS/", fileId, FileName);

                            // 로컬 폴더가 없을 경우 폴더를 생성한다.
                            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(tempFileName)))
                                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(tempFileName));

                            //파일 다운로드
                            _manager.DownloadFile(FilePath, ServerFileName, 0, tempFileName, 0, "");
                            Process.Start(tempFileName);
                        }
                        else
                        {
                            MessageBox.Show("There is no file infomation.");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    finally
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Invalid value. File id missing or empty.");
                    return;
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
