#region ▶ Description & History
/* 
 * 프로그램명 : QA30116 입고불량 기간별 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-24      배명희      통합WCF로 변경 
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
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>입고불량 기간별 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 5:34:21<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 5:34:21   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30116 : AxCommonBaseControl
    {
        //private IQA30116 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30116";

        #region [ 초기화 작업 정의 ]

        public QA30116()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30116>("QA00", "QA30116.svc", "CustomBinding");
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

                this.cbo01_BIZCD.Enabled = true;

                DataSet source = this.GetTypeCode("A1");
                this.cbo01_JOB_TYPE.DataBind(source.Tables[0], true);
                this.cbo01_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.15 공장구분 조회조건 추가
              
                //2015.06.29 권한제어처리- UserInfo.PlantDiv = 'U902' 라면 U2:두서공장으로 고정하고 변경불가
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902"))
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");//"귀책업체코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.grd01_QA30116.AllowEditing = false;
                this.grd01_QA30116.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30116.Initialize();
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "RCV_DATE","OCCUR_DATE");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "LOT NO", "LOTNO");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "발생장소코드", "DEF_PLACECD", "DEF_PLACECD");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "발생장소", "DEF_PLACENM", "DEF_PLACENM");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "귀책업체코드", "VENDCD", "IMPUT_VENDCD");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNONM", "PARTNM");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 70, "차종", "VINCD", "VINCD");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINTYPE","VIN");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMCD", "ITEMCD");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "업무유형", "JOB_TYPE", "JOB_TYPE");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "업무유형", "JOB_TYPENM", "JOB_TYPENM");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "불량번호", "DEFNO", "DEFNO");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "단가", "UCOST", "UCOST");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "불량금액", "DEF_AMT", "DEF_AMT");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량내용코드", "DEFCD", "DEFCD");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량내용", "DEFNM", "DEFNM");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량부위코드", "DEFPOSCD", "DEFPOSCD");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "조치내용코드", "MGRT_CNTTCD", "MGRT_CNTTCD");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "조치내용", "MGRT_CNTTNM", "MGRT_CNTT");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "회신요구일", "REPLY_DEM_DATE", "REPLY_DEM_DATE");
                this.grd01_QA30116.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "검사원", "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "검사원", "INSPECT_EMPNONM", "INSPECT_EMPNM");
                //this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "결재상태", "APR_YN", "APP_STATUS");

                this.grd01_QA30116.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "공장구분", "PLANT_DIV", "PLANT_DIV"); //공장구분 추가 2013.04.15(배명희)

                this.grd01_QA30116.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01_QA30116.SetColumnType(AxFlexGrid.FCellType.Decimal, "UCOST");
                this.grd01_QA30116.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd01_QA30116.SetColumnType(AxFlexGrid.FCellType.Date, "RCV_DATE");
                this.grd01_QA30116.SetColumnType(AxFlexGrid.FCellType.Date, "REPLY_DEM_DATE");

                this.grd01_QA30116.SetColumnType(AxFlexGrid.FCellType.ComboBox,"U9", "PLANT_DIV", true); //공장구분 추가 2013.04.15(배명희)

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
                this.grd01_QA30116.InitializeDataSource();
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

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //2013.04.15 공장구분 조회조건 추가 (배명희)

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("RCV_DATE_FROM", RCV_DATE_FROM);
                paramSet.Add("RCV_DATE_TO", RCV_DATE_TO);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("JOB_TYPE", JOB_TYPE);
                paramSet.Add("PARTNO_PARTNONM", PARTNO_PARTNONM);
                paramSet.Add("LANG_SET", _LANG_SET);

                paramSet.Add("PLANT_DIV", PLANT_DIV);                           //2013.04.15 공장구분 조회조건 추가 (배명희)

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30116.SetValue(source);
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

        private void grd01_QA30116_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30116.SelectedRowIndex;

                if (Row >= this.grd01_QA30116.Rows.Fixed)
                {
                    string BIZCD = this.grd01_QA30116.GetValue(Row, "BIZCD").ToString();
                    string RCV_DATE = this.grd01_QA30116.GetValue(Row, "RCV_DATE").ToString();
                    string VENDCD = this.grd01_QA30116.GetValue(Row, "VENDCD").ToString();
                    string DEFNO = this.grd01_QA30116.GetValue(Row, "DEFNO").ToString();

                    ShowPopup(new QA20111(BIZCD, RCV_DATE, VENDCD, DEFNO));
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
