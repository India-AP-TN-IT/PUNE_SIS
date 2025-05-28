#region ▶ Description & History
/* 
 * 프로그램명 : QA50418 자체 Claim 전자결재 연동
 * 설      명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2015-07-28      배명희      통합WCF로 변경
 * 
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

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>자체 Claim 전자결재 연동</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA50418 : AxCommonBaseControl
    {
        //private IQA50418 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;


        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA50418";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";

        #region [초기화 작업에 대한 정의]

        public QA50418()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA50418>("QA01", "QA50418.svc", "CustomBinding");

            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
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

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");// "협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                HEParameterSet paramSet_OCCUR_DIV = new HEParameterSet();
                paramSet_OCCUR_DIV.Add("LANG_SET", _LANG_SET);
                
                this.BeforeInvokeServer(true);

                //DataSet source_OCCUR_DIV = _WSCOMBOBOX.Inquery_OCCUR_DIV(paramSet_OCCUR_DIV);
                DataSet source_OCCUR_DIV = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_OCCUR_DIV"), paramSet_OCCUR_DIV);

                this.AfterInvokeServer();
                
                this.cbo01_OCCUR_DIV.DataBind(source_OCCUR_DIV.Tables[0], true);
                this.cbo01_OCCUR_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.grd01_QA50418.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA50418.Initialize();
                this.grd01_QA50418.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA50418.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD");
                this.grd01_QA50418.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD");
                this.grd01_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "CHK", "CHK_ENABLE", "CHK3");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "결재상태", "APP_STATE", "APP_STATUS");
                this.grd01_QA50418.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "문서번호", "DOCRPTNO", "DOCCD");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작성일자", "DOC_DATE", "DOC_DATE");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "발행번호", "OCCURNO", "DOC_NO");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "발생구분", "OCCUR_DIVNM", "OCCUR_DIVNM");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "귀책업체", "VENDCD", "VENDOR");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "귀책업체", "VENDNM", "VENDOR");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD", "VIN");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "완제품", "ASSY_PNO", "ASSYPNO");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "완제품", "ASSY_PNM", "ASSYPNO");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "부품", "PARTNO", "PART3");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "부품", "PARTNM", "PART3");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "불량유형", "DEFCD", "DEF_TYPE");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "불량유형", "DEFNM", "DEF_TYPE");
                this.grd01_QA50418.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "불량부위", "DEFPOSCD", "DEFPOSNM2");
                this.grd01_QA50418.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "불량부위", "DEFPOSNM", "DEFPOSNM2");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "조치현황", "MGRT_CNTT_DIV", "MGRT_CNTT_DIV");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "폐기비용", "DIS_AMT", "DIS_AMOUNT");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 180, "공수투입비용", "WORK_AMT", "MAN_AMOUNT02");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "총합계금액", "SUMTOT", "TOTSUM_AMT");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "결재진행일", "APP_DATE", "APPDATE");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "업체발송일", "NOTIFY_DATE", "NOTIFY_DATE");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "회계전표발행일자", "RECEIPT_DATE", "NOTE_OCR_DATE");
                this.grd01_QA50418.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "작업자", "INSPECT_EMPNO", "WORK_EMPNO");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "작업자", "INSPECT_EMPNM", "WORK_EMPNO");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "업체확인서", "DOCUMENT_NAME", "DOCUMENT");
                this.grd01_QA50418.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "업체확인서2", "DOCUMENT_NAME2", "DOCUMENT_2");
                this.grd01_QA50418.SetColumnType(AxFlexGrid.FCellType.Check, "CHK_ENABLE");
                this.grd01_QA50418.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_AMT");
                this.grd01_QA50418.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_AMT");
                this.grd01_QA50418.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");
                this.grd01_QA50418.SetColumnType(AxFlexGrid.FCellType.Date, "DOC_DATE");
                this.grd01_QA50418.SetColumnType(AxFlexGrid.FCellType.Date, "APP_DATE");
                this.grd01_QA50418.SetColumnType(AxFlexGrid.FCellType.Date, "NOTIFY_DATE");
                this.grd01_QA50418.SetColumnType(AxFlexGrid.FCellType.Date, "RECEIPT_DATE");
                this.grd01_QA50418.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA50418.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA50418.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA50418.CurrentContextMenu.Items[3].Visible = false;

                //초기화 로그 조회 기능 삭제함(글로벌표준에서는 사용안함.)
                //this.grd02_QA50418.AllowEditing = false;
                //this.grd02_QA50418.AllowDragging = AllowDraggingEnum.None;
                //this.grd02_QA50418.Initialize();
                //this.grd02_QA50418.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD");
                //this.grd02_QA50418.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD");
                //this.grd02_QA50418.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "문서번호", "DOCRPTNO");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "작성일자", "DOC_DATE", "DOC_DATE");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "발행번호", "OCCURNO", "DOC_NO");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "발생구분", "OCCUR_DIVNM", "OCCUR_DIV");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "귀책업체", "VENDCD", "VENDOR");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "귀책업체", "VENDNM", "VENDOR");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "차종", "VINCD", "VIN");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "완제품", "ASSY_PNO", "ASSYPNO");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "완제품", "ASSY_PNM", "ASSYPNO");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "부품", "PARTNO", "PART3");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "부품", "PARTNM", "PART3");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "불량유형", "DEFCD", "DEF_TYPE");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량유형", "DEFNM", "DEF_TYPE");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "불량부위", "DEFPOSCD", "DEFPOSNM2");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량부위", "DEFPOSNM", "DEFPOSNM2");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "조치현황", "MGRT_CNTT_DIV", "MGRT_CNTT_DIV");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "폐기비용", "DIS_AMT", "DIS_AMOUNT");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "공수투입비용", "WORK_AMT", "MAN_AMOUNT02");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "총합계금액", "SUMTOT", "TOTSUM_AMT");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "결재상태", "APP_STATE", "APP_STATUS");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "결재진행일", "APP_DATE", "APPDATE");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "결재반송일", "RET_DATE", "APP_RET_DATE");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "반송사유", "RET_REASON", "RET_REASON");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "업체확인서", "DOCUMENT_NAME", "DOCUMENT");
                //this.grd02_QA50418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "업체확인서2", "DOCUMENT_NAME2", "DOCUMENT_2");
                //this.grd02_QA50418.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_AMT");
                //this.grd02_QA50418.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_AMT");
                //this.grd02_QA50418.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");

                this.SetRequired(lbl01_BIZNM2, lbl01_DOC_DATE2);

                this.cbo01_PLANT_DIV.DataBindCodeName("U9", false); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                this.BtnReset_Click(null, null);

                //this.dte01_DOC_DATE_FROM.SetMMFromStart();
                this.dte01_DOC_DATE_FROM.SetValue(this.dte01_DOC_DATE_FROM.GetDateText().ToString().Substring(0, 8) + "01");

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01_QA50418.InitializeDataSource();
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
                string DOC_DATE_FROM = this.dte01_DOC_DATE_FROM.GetDateText().ToString();
                string DOC_DATE_TO = this.dte01_DOC_DATE_TO.GetDateText().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string OCCUR_DIV = this.cbo01_OCCUR_DIV.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("DOC_DATE_FROM", DOC_DATE_FROM);
                paramSet.Add("DOC_DATE_TO", DOC_DATE_TO);
                paramSet.Add("OCCUR_DIV", OCCUR_DIV);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);
                
                
                //DataSet source_log = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_LOG"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA50418.SetValue(source);
                //this.grd02_QA50418.SetValue(source_log);

                this.grd01_QA50418.Styles.Add("A").BackColor = Color.FromArgb(255, 200, 200);
                this.grd01_QA50418.Styles.Add("B").BackColor = Color.FromArgb(200, 200, 255);
                this.grd01_QA50418.Styles.Add("C").BackColor = Color.FromArgb(255, 63, 255);
                this.grd01_QA50418.Styles.Add("D").BackColor = Color.FromArgb(200, 255, 200);

                CellRange cr = new CellRange();
                for (int i = 1; i < grd01_QA50418.Rows.Count; i++)
                {
                    cr = grd01_QA50418.GetCellRange(i, grd01_QA50418.Cols.Fixed, i, grd01_QA50418.Cols.Count - grd01_QA50418.Cols.Fixed);

                    switch (this.grd01_QA50418.GetValue(i, "APP_STATE").ToString().Substring(0, 1))
                    {
                        case "0":
                            cr.Style = grd01_QA50418.Styles["A"];
                            break;
                        case "1":
                            cr.Style = grd01_QA50418.Styles["C"];
                            break;
                        case "2":
                            if (this.grd01_QA50418.GetValue(i, "RECEIPT_DATE").ToString() == "")
                            {
                                cr.Style = grd01_QA50418.Styles["B"];
                            }
                            break;
                        case "3":
                            cr.Style = grd01_QA50418.Styles["D"];
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

        #endregion

        #region [  기타 이벤트 정의 ]

        private void btn01_NOTIFY_VENDOR_Click(object sender, EventArgs e)
        {
            if (!IsNotifyToVendor(grd01_QA50418)) return;

            this.NotifyToVendor(grd01_QA50418);
            this.BtnQuery_Click(null, null);
        }



        private void btn01_CANCEL_NOTIFY_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsCancelNotify()) return;

                DataSet source = this.GetDataSourceSchema(
                    "CORCD", "BIZCD", "DOCRPTNO", "LANG_SET");

                for (int i = 1; i < grd01_QA50418.Rows.Count; i++)
                {
                    if (this.grd01_QA50418.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                    {
                        source.Tables[0].Rows.Add(
                            _CORCD,
                            this.cbo01_BIZCD.GetValue(),
                            this.grd01_QA50418.GetValue(i, "DOCRPTNO"),
                            _LANG_SET
                        );
                    }
                }

                this.BeforeInvokeServer(true);

                //_WSCOM.Reset_DOCUMENT(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "RESET_DOCUMENT"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);


                //MsgBox.Show("취소처리 되었습니다.");
                MsgCodeBox.Show("CD00-0056");
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



       
        private void grd01_QA50418_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA50418.SelectedRowIndex;
                int Col = this.grd01_QA50418.Col;

                if (Row >= this.grd01_QA50418.Rows.Fixed)
                {
                    if (this.grd01_QA50418.Cols["DOCUMENT_NAME"].Index == Col || this.grd01_QA50418.Cols["DOCUMENT_NAME2"].Index == Col)
                    {
                        string CORCD = this.grd01_QA50418.GetValue(Row, "CORCD").ToString();
                        string BIZCD = this.grd01_QA50418.GetValue(Row, "BIZCD").ToString();
                        string OCCURNO = this.grd01_QA50418.GetValue(Row, "OCCURNO").ToString();

                        HEParameterSet paramSet = new HEParameterSet();
                        paramSet.Add("CORCD", CORCD);
                        paramSet.Add("BIZCD", BIZCD);
                        paramSet.Add("OCCURNO", OCCURNO);
                        paramSet.Add("LANG_SET", this.UserInfo.Language);

                        this.BeforeInvokeServer(true);

                        DataSet source = new DataSet();

                        string SUB_DOCUMENT = "";
                        if (this.grd01_QA50418.Cols["DOCUMENT_NAME"].Index == Col)
                        {
                            //source = _WSCOM.Inquery_get_file1(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GET_FILE1"), paramSet);
                        }
                        else
                        {
                            //source = _WSCOM.Inquery_get_file2(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GET_FILE2"), paramSet);
                            SUB_DOCUMENT = "2";
                        }

                        this.AfterInvokeServer();

                        if (source.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = source.Tables[0].Rows[0];

                            if ((dr["DOCUMENT" + SUB_DOCUMENT]) != System.DBNull.Value)
                            {
                                byte[] _FILE_DATA = null;
                                _FILE_DATA = (byte[])(dr["DOCUMENT" + SUB_DOCUMENT]);

                                string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + "_" + dr["DOCUMENT_NAME" + SUB_DOCUMENT].ToString();
                                System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                                TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                                TEMP_FILE.Close();
                                TEMP_FILE.Dispose();

                                System.Diagnostics.Process.Start(FILE_NAME);
                            }
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

        #endregion

        #region [유효성 검사]

        private bool IsNotifyToVendor(AxFlexGrid grd)
        {
            try
            {
                //int cnt_CHK = 0;
                //for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                //{
                //    if (grd.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                //    {
                //        cnt_CHK = cnt_CHK + 1;
                //    }
                //}

                //if (cnt_CHK != 1)
                //{
                //    //MsgBox.Show("전자결재 품의는 한건씩 처리 하여야 합니다.");
                //    MsgCodeBox.Show("QA01-0048");
                //    return false;
                //}



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

        private bool IsSET_RECEIPT_DATE_COMMIT()
        {
            try
            {
                //if (MsgBox.Show("회계전표 발행일자 등록을 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("QA01-0050", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsCancelNotify()
        {
            try
            {
                //if (MsgBox.Show("통보처리를 취소 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        private void NotifyToVendor(AxFlexGrid grd)
        {
            //string vendnm = string.Empty;
            //for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            //{
            //    if (grd.GetValue(i, "CHK_ENABLE").ToString() == "Y")
            //    {
            //        vendnm = grd.GetValue(i, "VENDNM").ToString();
            //        break;
            //    }
            //}

            
            DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "OCCURNO");
            
            for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                {
                    source.Tables[0].Rows.Add(
                        grd.GetValue(i, "CORCD"),
                        grd.GetValue(i, "BIZCD"),
                        grd.GetValue(i, "OCCURNO")
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

        #endregion

    }
}
