#region ▶ Description & History
/* 
 * 프로그램명 : QA30418 자체 Claim 세부 현황 조회
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

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>자체 Claim 세부현황 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-18 오후 7:09:42<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 7:09:42   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30418 : AxCommonBaseControl
    {
        //private IQA30418 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30418";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";
        
        #region [ 초기화 작업 정의 ]

        public QA30418()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30418>("QA01", "QA30418.svc", "CustomBinding");
            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");

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

                HEParameterSet paramSet_OCCUR_DIV = new HEParameterSet();
                paramSet_OCCUR_DIV.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source_OCCUR_DIV = _WSCOMBOBOX.Inquery_OCCUR_DIV(paramSet_OCCUR_DIV);
                DataSet source_OCCUR_DIV = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_OCCUR_DIV"), paramSet_OCCUR_DIV);

                this.AfterInvokeServer();

                this.cbo01_OCCUR_DIV.DataBind(source_OCCUR_DIV.Tables[0], false);
                this.cbo01_OCCUR_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                DataSet source_XD0411 = this.GetTypeCode("FX");
                this.cbo01_MGRT_CNTT_DIV.DataBind(source_XD0411.Tables[0], true);
                this.cbo01_MGRT_CNTT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");//"협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_DEFCD.HEPopupHelper = new QASubWindow_DEFCD();
                this.cdx01_DEFCD.PopupTitle = this.GetLabel("DEF_CNTT_CD");//"불량내용코드";
                this.cdx01_DEFCD.CodeParameterName = "DEFCD";
                this.cdx01_DEFCD.NameParameterName = "DEFNM";
                this.cdx01_DEFCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DEFCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                //this.cdx01_DEFCD.CodePixedLength = 5;
                this.cdx01_DEFCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_DEFPOSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_DEFPOSCD.PopupTitle = this.GetLabel("DEFPOSCD2");//"불량부위코드";
                this.cdx01_DEFPOSCD.CodeParameterName = "DEFPOSCD";
                this.cdx01_DEFPOSCD.NameParameterName = "DEFPOSNM";
                this.cdx01_DEFPOSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_DEFPOSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_DEFPOSCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.grd01_QA30418.AllowEditing = false;
                this.grd01_QA30418.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30418.Initialize();
                this.grd01_QA30418.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30418.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "작성일자", "DOC_DATE", "DOC_DATE");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "발행번호", "OCCURNO", "OCCURNO");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "발생구분", "OCCUR_DIVNM", "OCCUR_DIVNM");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "귀책업체", "VENDCD","IMPUT_VENDNM");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "귀책업체", "VENDNM", "IMPUT_VENDNM");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD","VIN");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "완제품", "ASSY_PNO", "ASSYPNO");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "완제품", "ASSY_PNM", "ASSYPNO");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNM", "PARTNM");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "불량내용", "DEFCD", "DEFCD");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "불량내용", "DEFNM", "DEFNM");
                this.grd01_QA30418.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "불량부위", "DEFPOSCD", "DEFPOSCD");
                this.grd01_QA30418.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "불량부위", "DEFPOSNM", "DEFPOSNM");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "조치현황", "MGRT_CNTT_DIV", "MGRT_CNTT_DIV");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "발생기간", "OCCUR_BEG_DATE", "OCCUR_BEG_DATE");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "발생기간", "OCCUR_END_DATE", "OCCUR_END_DATE");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "LOTNO", "LOTNO_FROM", "LOTNO");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "LOTNO", "LOTNO_TO", "LOTNO");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "폐기수량", "DIS_QTY", "DIS_QTY");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "폐기비용", "DIS_AMT", "DIS_AMOUNT");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 180, "공수투입비용", "WORK_AMT", "MAN_AMOUNT02");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "총합계금액", "SUMTOT", "TOTSUM_AMT");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "결재진행일", "APP_DATE", "APPDATE");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "업체발송일", "NOTIFY_DATE", "NOTIFY_DATE");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "회계전표발행일자", "RECEIPT_DATE", "NOTE_OCR_DATE");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "작업자", "INSPECT_EMPNO", "WORK_EMPNO");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "작업자", "INSPECT_EMPNM", "WORK_EMPNO");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "업체확인서", "DOCUMENT_NAME", "DOCUMENT1");
                this.grd01_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "업체확인서2", "DOCUMENT_NAME2", "DOCUMENT2");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_QTY");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_AMT");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_AMT");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Date, "DOC_DATE");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Date, "OCCUR_BEG_DATE");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Date, "OCCUR_END_DATE");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Date, "APP_DATE");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Date, "NOTIFY_DATE");
                this.grd01_QA30418.SetColumnType(AxFlexGrid.FCellType.Date, "RECEIPT_DATE");
                this.grd02_QA30418.AllowEditing = false;
                this.grd02_QA30418.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA30418.Initialize();
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "순번", "OCCUR_SEQ", "SEQ_NO");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "불량세부내용", "DEF_DET_DESC", "DEF_DET_DESC");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "ALCCD");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "완제품", "ASSY_PNO", "ASSYPNO");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "완제품", "ASSY_PNM", "ASSYPNO");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNO");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "품명", "PARTNM", "PARTNM");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "단가", "PART_UCOST", "PART_UCOST");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "폐기수량", "DIS_QTY", "DIS_QTY");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "폐기비용", "DIS_AMOUNT", "DIS_AMOUNT");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "선별수량", "WORK_QTY", "FETCH_QTY");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "불량수량", "DEF_QTY", "DEF_QTY");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 180, "인원", "WORK_PERSON", "PERSON");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "시간", "WORK_TIME","TIME");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "임율", "WAGE_AMT", "WAGE_AMT");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 180, "공수투입비", "MAN_AMOUNT", "MAN_AMOUNT");
                this.grd02_QA30418.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "합계금액", "TOT_AMOUNT", "TOT_AMOUNT");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_UCOST");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_QTY");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIS_AMOUNT");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_QTY");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_PERSON");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "WORK_TIME");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_AMT");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "MAN_AMOUNT");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOT_AMOUNT");
                this.grd02_QA30418.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");
                this.SetRequired(lbl01_BIZNM, lbl01_DOC_DATE, lbl01_OCCUR_DIV);


                this.cbo01_PLANT_DIV.DataBindCodeName("U9", true); //2013.04.16 공장구분 조회조건 추가

                //2015.06.29 공장구분 - 권한제어
                this.cbo01_PLANT_DIV.SetValue(this.UserInfo.PlantDiv);
                if (this.UserInfo.PlantDiv.Equals("U902")) //UserInfo.PlantDiv = 'U902' 라면  공장구분  U2:두서공장 고정 ( 변경불가 )
                    this.cbo01_PLANT_DIV.SetReadOnly(true);


                this.BtnReset_Click(null, null);

                //this.dte01_DOC_DATE_FROM.SetMMFromStart();
                this.dte01_DOC_DATE_FROM.SetValue(this.dte01_DOC_DATE_FROM.GetDateText().Substring(0, 8) + "01");

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
                this.grd01_QA30418.InitializeDataSource();
                this.grd02_QA30418.InitializeDataSource();

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
                string DOC_DATE_FROM = this.dte01_DOC_DATE_FROM.GetDateText().ToString();
                string DOC_DATE_TO = this.dte01_DOC_DATE_TO.GetDateText().ToString();
                string OCCUR_DIV = this.cbo01_OCCUR_DIV.GetValue().ToString();
                string MGRT_CNTT_DIV = this.cbo01_MGRT_CNTT_DIV.GetValue().ToString();
                string DEFCD = this.cdx01_DEFCD.GetValue().ToString();
                string DEFPOSCD = this.cdx01_DEFPOSCD.GetValue().ToString();
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string OCCURNO_PARTNO_NAME = this.txt01_OCCURNO_PARTNO_NAME.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("DOC_DATE_FROM", DOC_DATE_FROM);
                paramSet.Add("DOC_DATE_TO", DOC_DATE_TO);
                paramSet.Add("OCCUR_DIV", OCCUR_DIV);
                paramSet.Add("MGRT_CNTT_DIV", MGRT_CNTT_DIV);
                paramSet.Add("DEFCD", DEFCD);
                paramSet.Add("DEFPOSCD", DEFPOSCD);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("OCCURNO_PARTNO_NAME", OCCURNO_PARTNO_NAME);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();
                
                this.grd01_QA30418.SetValue(source);
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

        private void grd01_QA30418_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01_QA30418.SelectedRowIndex;
                int Col = this.grd01_QA30418.Col;

                if (Row >= this.grd01_QA30418.Rows.Fixed)
                {
                    string BIZCD = this.grd01_QA30418.GetValue(Row, "BIZCD").ToString();
                    string OCCURNO = this.grd01_QA30418.GetValue(Row, "OCCURNO").ToString();

                    DataSet source = new DataSet();
                    HEParameterSet paramSet = new HEParameterSet();

                    switch (this.grd01_QA30418.Cols[Col].Name.ToString().ToUpper().Trim())
                    {
                        case "DOCUMENT_NAME":
                            paramSet.Add("CORCD", _CORCD);
                            paramSet.Add("BIZCD", BIZCD);
                            paramSet.Add("OCCURNO", OCCURNO);
                            paramSet.Add("LANG_SET", this.UserInfo.Language);
                            this.BeforeInvokeServer(true);

                            //source = _WSCOM.Inquery_GET_FILE1(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GET_FILE1"), paramSet);

                            this.AfterInvokeServer();

                            if (source.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = source.Tables[0].Rows[0];

                                if ((dr["DOCUMENT"]) != System.DBNull.Value)
                                {
                                    byte[] _FILE_DATA = null;
                                    _FILE_DATA = (byte[])(dr["DOCUMENT"]);

                                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + "_" + dr["DOCUMENT_NAME"].ToString();
                                    System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                                    TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                                    TEMP_FILE.Close();
                                    TEMP_FILE.Dispose();

                                    System.Diagnostics.Process.Start(FILE_NAME);
                                }
                            }

                            break;
                        case "DOCUMENT_NAME2":
                            paramSet.Add("CORCD", _CORCD);
                            paramSet.Add("BIZCD", BIZCD);
                            paramSet.Add("OCCURNO", OCCURNO);
                            paramSet.Add("LANG_SET", this.UserInfo.Language);
                            this.BeforeInvokeServer(true);

                            //source = _WSCOM.Inquery_GET_FILE2(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GET_FILE2"), paramSet);

                            this.AfterInvokeServer();

                            if (source.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = source.Tables[0].Rows[0];

                                if ((dr["DOCUMENT2"]) != System.DBNull.Value)
                                {
                                    byte[] _FILE_DATA = null;
                                    _FILE_DATA = (byte[])(dr["DOCUMENT2"]);

                                    string FILE_NAME = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + "_" + dr["DOCUMENT_NAME2"].ToString();
                                    System.IO.FileStream TEMP_FILE = System.IO.File.Create(FILE_NAME);
                                    TEMP_FILE.Write(_FILE_DATA, 0, _FILE_DATA.Length);
                                    TEMP_FILE.Close();
                                    TEMP_FILE.Dispose();

                                    System.Diagnostics.Process.Start(FILE_NAME);
                                }
                            }

                            break;
                        default:
                            paramSet.Add("CORCD", _CORCD);
                            paramSet.Add("BIZCD", BIZCD);
                            paramSet.Add("OCCURNO", OCCURNO);
                            paramSet.Add("LANG_SET", _LANG_SET);

                            this.BeforeInvokeServer(true);

                            //source = _WSCOM.Inquery_DETAIL(paramSet);
                            source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), paramSet);

                            this.AfterInvokeServer();

                            this.grd02_QA30418.SetValue(source);

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

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }

        #endregion


        #region [ 사용자 정의 메서드 ]
        
        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_DEFCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_DEFPOSCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
