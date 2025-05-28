#region ▶ Description & History
/* 
 * 프로그램명 : QA20602 공정순회검사일보 품의
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-29      배명희      통합WCF로 변경 
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

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>공정 순회검사일보 품의</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-08-24 오후 5:29:52<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-24 오후 5:29:52   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20602 : AxCommonBaseControl
    {
        //private IQA20602 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private String _OCCUR_DATE;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20602";

        #region [초기화 작업에 대한 정의]

        public QA20602()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20602>("QA02", "QA20602.svc", "CustomBinding");
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

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                }

                this.cdx01_INSPECT_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_INSPECT_CLASSCD.PopupTitle = this.GetLabel("INSPECCD");// "검사코드";
                this.cdx01_INSPECT_CLASSCD.CodeParameterName = "INSPECT_CLASSCDR";
                this.cdx01_INSPECT_CLASSCD.NameParameterName = "INSPECT_CLASSNMR";
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("VINCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("ITEMCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_INSPECT_CLASSCD.SetCodePixedLength();

               

                this.grd01_QA20602.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;

                this.grd01_QA20602.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20602.Initialize();
                this.grd01_QA20602.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "DIV", "DIV");
                //this.grd01_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 35, "선택", "APP_CHK", "CHK");
                //this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "결재상태", "APP_STATE","APP_STATUS");
                this.grd01_QA20602.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD");
                this.grd01_QA20602.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD");
                this.grd01_QA20602.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "검사코드", "INSPECT_CLASSCD");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "등록일자", "OCCUR_DATE", "REGDATE");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "차종", "VINNM", "VIN");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMNM", "ITEM");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품명", "ITEMNM2", "PARTNONM");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "외관검사", "BCA_RSLT1", "EXT_INSPECT_RSLT1");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "기타문제점", "BCC_RSLT2", "ETC_ISSUE_REMARK");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "치수검사", "BCB_RSLT3","DEM_INSPECT_RSLT3");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "검사자(주간)", "DAY_WORKER", "DAY_INSPECTOR");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "검사자(야간)", "NIGHT_WORKER", "NIGHT_INSPECTOR");
                this.grd01_QA20602.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "검사순번", "INSPECT_SEQ", "INSPECT_SEQ");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "불량(주)", "DAY_DEF_QTY", "DAY_DEF_QTY");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "불량(야)", "BIGHT_DEF_QTY", "NIGHT_DEF_QTY");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "점검항목", "INSPECT_ITEMNM", "CHECK_ITEMNM");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "문제점", "DEFNM","EI21210_ISSUE_TEXT");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "조치결과", "MGRT_CNTTNM", "MGRT_RESULT");
                this.grd01_QA20602.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "기타문제점", "ETC_ISSUE_REMARK","ETC_ISSUE_REMARK");
                this.grd01_QA20602.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "PID", "PID");
                this.grd01_QA20602.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 0, "공장구분", "PLANT_DIV");
                //this.grd01_QA20602.SetColumnType(AxFlexGrid.FCellType.Check, "APP_CHK");
                this.grd01_QA20602.SetColumnType(AxFlexGrid.FCellType.Decimal, "DAY_DEF_QTY");
                this.grd01_QA20602.SetColumnType(AxFlexGrid.FCellType.Decimal, "BIGHT_DEF_QTY");
                this.grd01_QA20602.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA20602.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA20602.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA20602.CurrentContextMenu.Items[3].Visible = false;
                this.grd01_QA20602.Cols["DIV"].AllowMerging = true;
                //this.grd01_QA20602.Cols["APP_CHK"].AllowMerging = true;
                //this.grd01_QA20602.Cols["APP_STATE"].AllowMerging = true;
                this.grd01_QA20602.Cols["CORCD"].AllowMerging = true;
                this.grd01_QA20602.Cols["BIZCD"].AllowMerging = true;
                this.grd01_QA20602.Cols["INSPECT_CLASSCD"].AllowMerging = true;
                this.grd01_QA20602.Cols["OCCUR_DATE"].AllowMerging = true;
                this.grd01_QA20602.Cols["VINNM"].AllowMerging = true;
                this.grd01_QA20602.Cols["ITEMNM"].AllowMerging = true;
                this.grd01_QA20602.Cols["ITEMNM2"].AllowMerging = true;
                this.grd01_QA20602.Cols["BCA_RSLT1"].AllowMerging = true;
                this.grd01_QA20602.Cols["BCC_RSLT2"].AllowMerging = true;
                this.grd01_QA20602.Cols["BCB_RSLT3"].AllowMerging = true;
                this.grd01_QA20602.Cols["DAY_WORKER"].AllowMerging = true;
                this.grd01_QA20602.Cols["NIGHT_WORKER"].AllowMerging = true;

                this.grd01_QA20602.Cols["DIV"].Style.BackColor = Color.White;
                //this.grd01_QA20602.Cols["APP_CHK"].Style.BackColor = Color.White;
                //this.grd01_QA20602.Cols["APP_STATE"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["CORCD"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["BIZCD"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["INSPECT_CLASSCD"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["OCCUR_DATE"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["VINNM"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["ITEMNM"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["ITEMNM2"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["BCA_RSLT1"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["BCC_RSLT2"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["BCB_RSLT3"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["DAY_WORKER"].Style.BackColor = Color.White;
                this.grd01_QA20602.Cols["NIGHT_WORKER"].Style.BackColor = Color.White;

                this.grd02_QA20602.AllowEditing = false;
                this.grd02_QA20602.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20602.Initialize();
                this.grd02_QA20602.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD");
                this.grd02_QA20602.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "등록일자", "OCCUR_DATE", "REGDATE");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "PROC_DATE", "OCCUR_DATE");
                this.grd02_QA20602.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "불량번호", "DPTNO", "DEFNO");
                this.grd02_QA20602.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "불량_SEQ", "DPT_SEQ","불량_SEQ");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "차종", "VINCD", "VIN");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "ALCCD","ALC");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "완제품번", "ASSYPNO", "ASSYPNO2");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "완제품명", "ASSYPNM", "ASSYPNM2");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "자재품번", "PARTNO", "MAT_PARTNO");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "자재품명", "PARTNM","MAT_PARTNM");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "폐기수량", "DIS_QTY", "DIS_QTY");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "수정수량", "AMD_QTY", "AMD_QTY");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "불량내용", "DEFNM", "DEF_CNTT");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "조치구분", "MGRT_NM", "MGRT_NM");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "귀책구분", "IMPUT_DIVNM", "RESPONSTITLE");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "귀책업체", "IMPUT_VENDNM", "VENDOR");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "고품접수", "RET_PRDT_YN", "RET_PRDT_YN");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "점검 및 조치확인", "CHK_MGRT_YN", "CHECK_MGRT");
                this.grd02_QA20602.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "조치결과", "MGRT_CLASSCD", "MGRT_RESULT");
                this.grd02_QA20602.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "조치결과", "MGRT_CLASSNM", "MGRT_RESULT");

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가
                //2016.02.15 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);

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
                this.grd01_QA20602.InitializeDataSource();
                this.grd02_QA20602.InitializeDataSource();

                _OCCUR_DATE = "";
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
                string OCCUR_DATE_FROM = this.dte01_OCCUR_DATE_FROM.GetDateText().ToString();
                string OCCUR_DATE_TO = this.dte01_OCCUR_DATE_TO.GetDateText().ToString();
                string INSPECT_CLASSCD = this.cdx01_INSPECT_CLASSCD.GetValue().ToString();
                //string APP_STATE = this.cbo01_DESIDE.GetValue().ToString();
                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();

                HEParameterSet paramSet1 = new HEParameterSet();
                paramSet1.Add("CORCD", _CORCD);
                paramSet1.Add("BIZCD", BIZCD);
                paramSet1.Add("OCCUR_BEG_DATE", OCCUR_DATE_FROM);
                paramSet1.Add("OCCUR_END_DATE", OCCUR_DATE_TO);
                paramSet1.Add("INSPECT_CLASSCD", INSPECT_CLASSCD);
                //paramSet1.Add("APP_STATE", APP_STATE);
                paramSet1.Add("LANG_SET", _LANG_SET);
                paramSet1.Add("PLANT_DIV", PLANT_DIV);

                HEParameterSet paramSet2 = new HEParameterSet();
                paramSet2.Add("CORCD", _CORCD);
                paramSet2.Add("BIZCD", BIZCD);
                paramSet2.Add("OCCUR_BEG_DATE", OCCUR_DATE_FROM);
                paramSet2.Add("OCCUR_END_DATE", OCCUR_DATE_TO);
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
                _OCCUR_DATE = "";

                this.grd01_QA20602.SetValue(source_MAIN);
                this.grd02_QA20602.SetValue(source_QA6040_QA2020);
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

        #region [유효성 검사]

       

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



        private void grd01_QA20602_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA20602.SelectedRowIndex;

                if (Row >= this.grd01_QA20602.Rows.Fixed)
                {
                    string CORCD = this.grd01_QA20602.GetValue(Row, "CORCD").ToString();
                    string BIZCD = this.grd01_QA20602.GetValue(Row, "BIZCD").ToString();
                    string OCCUR_DATE = this.grd01_QA20602.GetValue(Row, "OCCUR_DATE").ToString();
                    string INSPECT_CLASSCD = this.grd01_QA20602.GetValue(Row, "INSPECT_CLASSCD").ToString();
                    string PLANT_DIV = this.grd01_QA20602.GetValue(Row, "PLANT_DIV").ToString();

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

        private void grd01_QA20602_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
