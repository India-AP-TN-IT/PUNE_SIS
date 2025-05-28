#region ▶ Description & History
/* 
 * 프로그램명 : QA40122 입고불량대책서 품의 결재 및 현황관리
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
 * 
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
using System.Drawing;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>입고불량대책서 품의 결재 및 현황</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 4:05:47<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-17 오후 4:05:47   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA40122 : AxCommonBaseControl
    {
        //private IQA40122 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA40122";

        #region [ 초기화 작업 정의 ]

        public QA40122()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA40122>("QA00", "QA40122.svc", "CustomBinding");
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
                this.groupBox2.Text = this.GetLabel("QA40122_MSG1");

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

                this.cbo01_BIZCD.DataBind(this.GetBizCD(_CORCD).Tables[0], false);
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

                DataSet source = this.GetTypeCode("A1");
                this.cbo01_JOB_TYPE.DataBind(source.Tables[0], true);
                this.cbo01_JOB_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("IMPUT_VENDCD");// "귀책업체코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                DataTable combo_source = new DataTable();
                combo_source.Columns.Add("CODE");
                combo_source.Columns.Add("NAME");
                combo_source.Rows.Add("", "");
                combo_source.Rows.Add("0", this.GetLabel("NONE_CREATE"));//"미작성");
                combo_source.Rows.Add("1", this.GetLabel("NONE_RECEIPT"));//"미접수");
                combo_source.Rows.Add("2", this.GetLabel("RECEIPT_BOUNCE"));//"접수반송");
                combo_source.Rows.Add("3", this.GetLabel("RECEIPT_COMPLETE"));//"접수완료");
                combo_source.Rows.Add("5", this.GetLabel("APP_PROGRESS"));//"결재진행");
                combo_source.Rows.Add("6", this.GetLabel("APP_COMPLETE"));//"결재완료");
                combo_source.Rows.Add("7", this.GetLabel("APP_BOUNCE"));//"결재반송");

                this.cbo01_DESIDE.DataBind(combo_source, false);
                this.cbo01_DESIDE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA40122.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA40122.Initialize(false);
                this.grd01_QA40122.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA40122.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA40122.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA40122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "선택", "SEL_CHK", "CHK");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "대책서상태", "DESIDE2", "DESIDE2");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "발생일자", "RCV_DATE","OCCUR_DATE");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "LOT NO", "LOTNO");
                this.grd01_QA40122.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "불량장소코드", "DEF_PLACECD", "DEF_PLACECD");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "불량장소", "DEF_PLACENM", "DEF_PLACENM");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "귀책업체코드", "VENDCD", "IMPUT_VENDCD");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO", "PARTNO");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품명", "PARTNM", "PARTNM");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "차종", "VINCD", "VIN");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "품목", "ITEMCD", "ITEM");
                this.grd01_QA40122.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "업무유형코드", "JOB_TYPE", "JOB_TYPE");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "업무유형", "JOB_TYPENM", "JOB_TYPENM");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "불량번호", "DEFNO", "DEFNO");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "단가", "UCOST", "UCOST");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "불량금액", "DEF_AMT", "DEF_AMT");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "불량유형코드", "DEFCD", "DEFCD");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "불량유형", "DEFNM", "DEFNM");
                this.grd01_QA40122.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "조치내용코드", "MGRT_CNTTCD", "MGRT_CNTTCD");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "조치내용", "MGRT_CNTTNM", "MGRT_CNTTNM");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "회신요구일", "REPLY_DEM_DATE", "REPLY_DEM_DATE");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "검사자사번", "INSPECT_EMPNO", "INSPECT_EMPNO");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "검사자", "INSPECT_EMPNM", "INSPECT_EMPNM");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "결재진행일", "APPDATE", "APPDATE");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "대책서번호", "DOCNO", "MEASURE_DOCNO");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "첨부파일명", "ATT_FILE_NM", "ATT_FILE_NAME2");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "파일크기", "LENGTH", "FILE_SIZE");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "업체담당자", "VEND_MGR", "VEND_MGR");
                this.grd01_QA40122.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "당사처리비고", "RSLT_CNTT", "PROCESS_REMARK");
                this.grd01_QA40122.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "PID2", "PID2");
                this.grd01_QA40122.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd01_QA40122.SetColumnType(AxFlexGrid.FCellType.Decimal, "UCOST");
                this.grd01_QA40122.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_AMT");
                this.grd01_QA40122.SetColumnType(AxFlexGrid.FCellType.Decimal, "LENGTH");
                this.grd01_QA40122.SetColumnType(AxFlexGrid.FCellType.Check, "SEL_CHK");
                this.grd01_QA40122.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA40122.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA40122.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA40122.CurrentContextMenu.Items[3].Visible = false;

                this.grd02_QA40122.AllowEditing = false;
                this.grd02_QA40122.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA40122.Initialize();
                this.grd02_QA40122.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd02_QA40122.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA40122.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "수행일시", "ACT_DATE", "ACT_DATE");
                this.grd02_QA40122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "불량번호", "DEFNO", "DEFNO");
                this.grd02_QA40122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "대책서번호", "DOCNO", "MEASURE_DOCNO");
                this.grd02_QA40122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "작업사번", "EMPNO", "EMPNO");
                this.grd02_QA40122.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "성명", "EMPNONM", "EMPNM");

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
                this.grd02_QA40122.InitializeDataSource();
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
                string DESIDE = this.cbo01_DESIDE.GetValue().ToString();

                string PLANT_DIV = this.cbo01_PLANT_DIV.GetValue().ToString();  //공장구분 추가 2013.04.16(배명희)
                
                string PARTNO_PARTNM = this.txt01_PARTNO_PARTNM.GetValue().ToString();

                HEParameterSet paramSet_QA1020 = new HEParameterSet();
                paramSet_QA1020.Add("CORCD", _CORCD);
                paramSet_QA1020.Add("BIZCD", BIZCD);
                paramSet_QA1020.Add("RCV_DATE_FROM", RCV_DATE_FROM);
                paramSet_QA1020.Add("RCV_DATE_TO", RCV_DATE_TO);
                paramSet_QA1020.Add("VENDCD", VENDCD);
                paramSet_QA1020.Add("JOB_TYPE", JOB_TYPE);
                paramSet_QA1020.Add("DESIDE", DESIDE);
                paramSet_QA1020.Add("PARTNO_PARTNM", PARTNO_PARTNM);
                paramSet_QA1020.Add("LANG_SET", _LANG_SET);
                paramSet_QA1020.Add("PLANT_DIV", PLANT_DIV);                     //공장구분 추가 2013.04.16(배명희)

                HEParameterSet paramSet_QA1041 = new HEParameterSet();
                paramSet_QA1041.Add("CORCD", _CORCD);
                paramSet_QA1041.Add("BIZCD", BIZCD);
                paramSet_QA1041.Add("RCV_DATE_FROM", RCV_DATE_FROM);
                paramSet_QA1041.Add("RCV_DATE_TO", RCV_DATE_TO);
                paramSet_QA1041.Add("PLANT_DIV", PLANT_DIV);                     //공장구분 추가 2013.04.16(배명희)
                paramSet_QA1041.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source_QA1020 = _WSCOM.Inquery_QA1020(paramSet_QA1020);
                DataSet source_QA1020 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1020"), paramSet_QA1020);
                this.grd01_QA40122.SetValue(source_QA1020);

                //DataSet source_QA1041 = _WSCOM.Inquery_QA1041(paramSet_QA1041);
                DataSet source_QA1041 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA1041"), paramSet_QA1041);
                this.grd02_QA40122.SetValue(source_QA1041);

                this.AfterInvokeServer();

                this.grd_COROL(grd01_QA40122);
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
                
        private void grd01_QA40122_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA40122.SelectedRowIndex;

                if (Row >= this.grd01_QA40122.Rows.Fixed)
                {
                    string CORCD = this.grd01_QA40122.GetValue(Row, "CORCD").ToString();
                    string BIZCD = this.grd01_QA40122.GetValue(Row, "BIZCD").ToString();
                    string DOCNO = this.grd01_QA40122.GetValue(Row, "DOCNO").ToString();

                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("DOCNO", DOCNO);
                    paramSet.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);

                    //DataSet source = _WSCOM.Inquery_file_view(paramSet);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_FILE_VIEW"), paramSet);

                    this.AfterInvokeServer();

                    if (source.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = source.Tables[0].Rows[0];

                        if ((dr["ATT_FILE"]) != System.DBNull.Value)
                        {
                            byte[] _FILE_DATA = null;
                            _FILE_DATA = (byte[])(dr["ATT_FILE"]);

                            string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + dr["ATT_FILE_NM"].ToString();
                            System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                            TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                            TEMP_FILE.Close();
                            TEMP_FILE.Dispose();

                            System.Diagnostics.Process.Start(FILE_NAME);
                        }
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

        private void btn01_APPLAY_NEW_Click(object sender, EventArgs e)
        {
            if (!IsAPPLAY(grd01_QA40122)) return;

            this.APPLAY_NEW(grd01_QA40122);
            this.BtnQuery_Click(null, null);
        }
        
        private void btn01_APPLAY_CLEAR_Click(object sender, EventArgs e)
        {
            if (!IsAPPLAY_CLEAR(grd01_QA40122)) return;

            this.APPLAY_CLEAR(grd01_QA40122);
            this.BtnQuery_Click(null, null);
        }
        
        private void btn01_DOC_CLEAR_Click(object sender, EventArgs e)
        {
            if (!IsDOC_CLEAR(grd01_QA40122)) return;

            this.DOC_CLEAR(grd01_QA40122);
            this.BtnQuery_Click(null, null);
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsAPPLAY(AxFlexGrid grd)
        {
            try
            {
                for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                {
                    if (grd.GetValue(i, "SEL_CHK").ToString() == "Y")
                    {
                        if (grd.GetValue(i, "DESIDE2").ToString().Substring(0, 1) != "3")
                        {
                            //MsgBox.Show("대책서상태가 접수완료이 아닌 데이터는 전자결재품의를 할 수 없습니다.");
                            MsgCodeBox.Show("QA00-041");
                            return false;
                        }
                    }
                }

                //if (MsgBox.Show("전자결재품의를 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                if (MsgCodeBox.ShowFormat("QA00-042", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                {
                    if (grd.GetValue(i, "SEL_CHK").ToString() == "Y")
                    {
                        // 두서공장은 마음대로 초기화 가능
                        if (!this.UserInfo.PlantDiv.Equals("U902"))
                        {
                            if (grd.GetValue(i, "DESIDE2").ToString().Substring(0, 1) != "5" && grd.GetValue(i, "DESIDE2").ToString().Substring(0, 1) != "2" && grd.GetValue(i, "DESIDE2").ToString().Substring(0, 1) != "7")
                            {
                                //MsgBox.Show("대책서상태가 접수반송와 결재반송가 아닌 데이터는 결재문서 초기화를 할 수 없습니다.");
                                MsgCodeBox.Show("QA00-043");
                                return false;
                            }
                        }
                    }
                }

                //if (MsgBox.Show("결재문서 초기화를 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("QA00-040", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsDOC_CLEAR(AxFlexGrid grd)
        {
            try
            {
                for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                {
                    if (grd.GetValue(i, "SEL_CHK").ToString() == "Y")
                    {
                        if (grd.GetValue(i, "DESIDE2").ToString().Substring(0, 1) != "2" && grd.GetValue(i, "DESIDE2").ToString().Substring(0, 1) != "7")
                        {
                            //MsgBox.Show("대책서상태가 접수반송와 결재반송가 아닌 데이터는 대책서번호 초기화를 할 수 없습니다.");
                            MsgCodeBox.Show("QA00-045");
                            return false;
                        }
                    }
                }

                //if (MsgBox.Show("대책서번호 초기화를 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("QA00-046", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        private void DOC_CLEAR(AxFlexGrid grd)
        {
            DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "DEFNO", "DOCNO", "EMPNO", "PID2");

            for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "SEL_CHK").ToString() == "Y")
                {
                    source.Tables[0].Rows.Add(
                        grd.GetValue(i, "CORCD"),
                        grd.GetValue(i, "BIZCD"),
                        grd.GetValue(i, "DEFNO"),
                        grd.GetValue(i, "DOCNO"),
                        this.UserInfo.EmpNo,
                        grd.GetValue(i, "PID2")
                    );
                }
            }

            if (source.Tables[0].Rows.Count > 0)
            {
                //_WSCOM.Doc_clear(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "DOC_CLEAR"), source);
            }
        }

        private void APPLAY_CLEAR(AxFlexGrid grd)
        {
            DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "DEFNO", "DOCNO", "EMPNO", "PID2");

            for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "SEL_CHK").ToString() == "Y")
                {
                    source.Tables[0].Rows.Add(
                        grd.GetValue(i, "CORCD"),
                        grd.GetValue(i, "BIZCD"),
                        grd.GetValue(i, "DEFNO"),
                        grd.GetValue(i, "DOCNO"),
                        this.UserInfo.EmpNo,
                        grd.GetValue(i, "PID2")
                    );
                }
            }

            if (source.Tables[0].Rows.Count > 0)
            {
                //_WSCOM.App_clear(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "APP_CLEAR"), source);
            }
        }

        private void APPLAY_NEW(AxFlexGrid grd)
        {

            // 2015.07.01 부터 신규 전자결재 모듈로 연동 ( 두서공장일경우 결재를 즉시 완료 모드로 처리 )
            GWApprovaler gwapprovaler = new GWApprovaler("QA40122_1", "입고불량대책 품의서", true, (this.UserInfo.PlantDiv.Equals("U902") ? true : false));
            HEParameterSet param = null;
            DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "DEFNO", "PID2");
            string BIZCD = "";
            for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "SEL_CHK").ToString() == "Y")
                {
                    source.Tables[0].Rows.Add(
                        grd.GetValue(i, "CORCD"),
                        grd.GetValue(i, "BIZCD"),
                        grd.GetValue(i, "DEFNO"),
                        gwapprovaler.ERPID
                    );
                    BIZCD = grd.GetValue(i, "BIZCD").ToString();
                    if (param == null)
                    {
                        // 최초 한번만 처리
                        // GW_Instance 용 파라메터 ( 신형은 호출 파라메터를 파라메터 셋으로 정의하여야 함 )
                        // 주의 : 파라메터 앞에 IN_ 를 붙여야 함(프로시저 파라메터와 이름 동일), 프로시저의 파라메터 순서와 동일하여야 함
                        param = new HEParameterSet();
                        param.Add("IN_CORCD", grd.GetValue(i, "CORCD"));
                        param.Add("IN_BIZCD", grd.GetValue(i, "BIZCD"));
                        param.Add("IN_PID2", gwapprovaler.ERPID);
                    }
                }
            }

            if (source.Tables[0].Rows.Count > 0)
            {
                // ERP 에 데이터 업데이트
                //_WSCOM.App_save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "APP_SAVE"), source);

                // GW_Instance 용 파라메터 전달
                gwapprovaler.CallWithoutEvent("GWP_QA40122_1", param);
            }
            
        }
        
        private void grd_COROL(AxFlexGrid grd)
        {
            grd.Styles.Add("COLOR_R").BackColor = Color.FromArgb(255, 200, 200);
            grd.Styles.Add("COLOR_G").BackColor = Color.FromArgb(200, 255, 200);
            grd.Styles.Add("COLOR_B").BackColor = Color.FromArgb(200, 200, 255);
            grd.Styles.Add("COLOR_P").BackColor = Color.FromArgb(255, 63, 255);
            grd.Styles.Add("COLOR_W").BackColor = Color.FromArgb(255, 255, 255);

            CellRange cr = new CellRange();
            for (int i = 1; i < grd.Rows.Count; i++)
            {
                cr = grd.GetCellRange(i, grd.Cols.Fixed, i, grd.Cols.Count - grd.Cols.Fixed);
                switch (grd.GetValue(i, "DESIDE2").ToString().Substring(0,1))
                {
                    case "0":
                        cr.Style = grd.Styles["COLOR_R"];
                        break;
                    case "1":
                        cr.Style = grd.Styles["COLOR_B"];
                        break;
                    case "2":
                        cr.Style = grd.Styles["COLOR_G"];
                        break;
                    case "3":
                        cr.Style = grd.Styles["COLOR_B"];
                        break;
                    case "5":
                        cr.Style = grd.Styles["COLOR_P"];
                        break;
                    case "6":
                        cr.Style = grd.Styles["COLOR_W"];
                        break;
                    case "7":
                        cr.Style = grd.Styles["COLOR_G"];
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
