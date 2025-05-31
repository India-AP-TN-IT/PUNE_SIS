#region ▶ Description & History
/* 
 * 프로그램명 : QA20411 HMC, KIA Claim 수신자료 등록
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
 *				2015-07-27      배명희      통합WCF로 변경 
 *				2015-08-17      배명희      통합WCF 누락건 추가.  //_WSCOM.Save(ds); ==>  _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), ds);
 * 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;


using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using System.IO;
using System.Data.OleDb;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>HMC, KIA Claim 수신자료 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20411 : AxCommonBaseControl
    {
        //private IQA20411 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;
        private String _INQUERY_HECD_OF_HKMC;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20411";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";
        //private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";
        
        #region [ 초기화 작업 정의 ]

        public QA20411()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20411>("QA01", "QA20411.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

            //_WSCOMBOBOX = ClientFactory.CreateChannel<IQAComboBox>("QA09", "QAComboBox.svc", "CustomBinding");
            //_WSINQUERY = ClientFactory.CreateChannel<IQAInquery>("QA09", "QAInquery.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                //this._buttonsControl.BtnDelete.Visible = true;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
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

                DataTable combo_source = new DataTable();
                combo_source.Columns.Add("CODE");
                combo_source.Columns.Add("NAME");
                combo_source.Rows.Add("H", "HMC");
                combo_source.Rows.Add("K", "KIA");
                this.cbo01_COMP_DIV.DataBind(combo_source, false);
                this.cbo01_COMP_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx03_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx03_VENDCD.PopupTitle = this.GetLabel("CUSTCD");// "고객사코드";
                this.cdx03_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx03_VENDCD.NameParameterName = "CUSTNM";
                this.cdx03_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.grd01_QA20411.AllowEditing = false;
                this.grd01_QA20411.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20411.Initialize();
                this.grd01_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "기준년월", "STD_YYYYMM", "STD_YYMM");
                this.grd01_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "회사구분", "COMP_DIV", "COMP_DIV");
                this.grd01_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "발생구분", "OCCUR_DIV", "OCCUR_DIV");
                this.grd01_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "통보서번호", "DOCNO", "DOCRPT");
                this.grd01_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "건수", "NOCASE", "NO_CASE");
                this.grd01_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "금액", "AMOUNT", "AMOUNT");
                this.grd01_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "NOCASE");
                this.grd01_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMOUNT");
                this.grd01_QA20411.Cols["STD_YYYYMM"].Format = "yyyy-MM";
                this.grd01_QA20411.SetColumnType(AxFlexGrid.FCellType.Date, "STD_YYYYMM");

                this.grd02_QA20411.AllowEditing = true;
                this.grd02_QA20411.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20411.Initialize();
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "처리결과", "PROC_RSLT", "PROC_RSLT");
                this.grd02_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "법인코드", "CORCD", "CORCD");
                this.grd02_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "사업장코드", "BIZCD", "BIZCD");
                this.grd02_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "기준년월", "STD_YYYYMM", "STD_YYMM");
                this.grd02_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "회사구분", "COMP_DIV", "COMP_DIV");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "발생구분", "OCCUR_DIV", "OCCUR_DIV");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "통보서", "DOCNO", "DOCRPT");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "업체", "VEND", "VEND");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "순위", "SEQ", "RANK_SEQ");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "RO 년월", "RO_YYYYMM", "RO_YYYYMM");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "RO 번호", "RONO", "RONO");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "VIN 번호", "VINNO", "VINNO");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "C/TYPE", "CTYPE", "CTYPE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VIN", "VIN");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "건수", "NOCASE","NO_CASE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "원인부품", "PARTNO", "APPLI_PART");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "원인품명", "PARTNM", "APPLY_PARTNM");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "캠페인ISSUE", "CAMPAIGNISSUE", "CAMPAIGNISSUE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "캠페인명", "CAMPAIGNNAME", "CAMPAIGNNAME");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "주작업코드", "MWORKCD", "MWORKCD");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "원인", "APPLICANT", "APPLI_CNTT");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "현상", "PRESENT_SIT", "PRESENT_SIT");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "수리일자", "REPAIR_DATE", "REPAIR_DATE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "판매일자", "SAL_DATE", "SAL_DATE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "사용기간", "USE_TERM", "USE_TERM");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "주행거리", "TRAVEL_DST", "TRAVEL_DST");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "PWA", "PWA");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "납입율", "DELI_RATE", "DELI_RATE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "분담율", "SHA_RATE", "SHA_RATE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "적용율", "APP_RATE", "APP_RATE");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "부품비", "PART_COST", "PART_COST");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "공임비", "WAGE_COST", "WAGE_COST");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "외주비", "SUBCON_COST", "SUBCON_COST");
                this.grd02_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "외장색상", "OUT_COLOR", "OUT_COLOR");

                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "NOCASE");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "USE_TERM");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "TRAVEL_DST");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "DELI_RATE");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "SHA_RATE");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "APP_RATE");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");

                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Date, "REPAIR_DATE");
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Date, "SAL_DATE");
                this.grd02_QA20411.Cols["STD_YYYYMM"].Format = "yyyy-MM";
                this.grd02_QA20411.SetColumnType(AxFlexGrid.FCellType.Date, "STD_YYYYMM");

                this.grd03_QA20411.AllowEditing = false;
                this.grd03_QA20411.AllowDragging = AllowDraggingEnum.None;
                this.grd03_QA20411.Initialize();
                this.grd03_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd03_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "프로그램ID", "PROGRAM_ID", "PROGRAM_ID");
                this.grd03_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "영역", "SECTOR", "SECTOR");
                this.grd03_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "DB COLNM", "DB_COLNM");
                this.grd03_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "FILE_COLNM", "FILE_COLNM");
                this.grd03_QA20411.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 80, "SEQ_SORT", "SEQ_SORT");
                this.grd03_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "REMARK", "REMARK");

                //양식 다운로드용으로 다국어 처리 하지 말라고 함. 
                this.grd04_QA20411.AllowEditing = true;
                this.grd04_QA20411.AllowDragging = AllowDraggingEnum.None;
                this.grd04_QA20411.Initialize();
                this.grd04_QA20411.Cols.RemoveRange(0, 1);
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "법인", "CORNM");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "발생구분", "OCCUR_DIV");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "통보서", "DOCNO");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "회사구분", "COMP_DIV");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "업체", "VEND");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "순위", "SEQ");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "RO년월", "RO_YYYYMM");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "RO번호", "RONO");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "VIN번호", "VINNO");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "C/TYPE", "CTYPE");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VIN");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "원인부품", "PARTNO");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "원인품명", "PARTNM");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "캠페인ISSUE", "CAMPAIGNISSUE");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "캠페인명", "CAMPAIGNNAME");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "주작업코드", "MWORKCD");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "원인", "APPLICANT");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "현상", "PRESENT_SIT");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "생산일자", "PROD_DATE");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "수리일자", "REPAIR_DATE");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "판매일자", "SAL_DATE");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "사용기간", "USE_TERM");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "주행거리", "TRAVEL_DST");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "PWA", "PWA");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "납입율", "DELI_RATE");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "분담율", "SHA_RATE");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "적용율", "APP_RATE");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "부품비", "PART_COST");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "공임비", "WAGE_COST");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "외주비", "SUBCON_COST");
                this.grd04_QA20411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "외장색상", "OUT_COLOR");
                this.grd04_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "USE_TERM");
                this.grd04_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "TRAVEL_DST");
                this.grd04_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "DELI_RATE");
                this.grd04_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "SHA_RATE");
                this.grd04_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "APP_RATE");
                this.grd04_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");
                this.grd04_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");
                this.grd04_QA20411.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");

                this.pnl01_FMT.Visible = false;

                this.SetRequired(lbl01_BIZNM, lbl01_STD_YYMM, lbl01_COMP_DIV, lbl03_CUSTNM);

                this.cdx03_VENDCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.UserInfo.BusinessCode));

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
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }
                this.cdx03_VENDCD.Initialize();
                this.grd01_QA20411.InitializeDataSource();
                this.grd02_QA20411.InitializeDataSource();

                this.grd04_QA20411_ADDROW();

                this.FIELDS_MAPPING();
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
                string STD_YYYYMM = this.dte01_STD_YYYYMM.GetDateText().Substring(0,7);
                string COMP_DIV = this.cbo01_COMP_DIV.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("STD_YYYYMM", STD_YYYYMM);
                paramSet.Add("COMP_DIV", COMP_DIV);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source1 = _WSCOM.Inquery_QA4011W_H(paramSet);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA4011W_H"), paramSet);
                
                //DataSet source2 = _WSCOM.Inquery_QA4011W_D(paramSet);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA4011W_D"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20411.SetValue(source1);
                this.grd02_QA20411.SetValue(source2);
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD", "BIZCD", "PROC_DATE", "COMP_DIV", "SAL_VENDCD");
                source.Tables[0].Rows.Add(
                    _CORCD,
                    this.cbo01_BIZCD.GetValue(),
                    this.dte01_STD_YYYYMM.GetDateText().Substring(0,7),
                    this.cbo01_COMP_DIV.GetValue(),
                    this.cdx03_VENDCD.GetValue()
                );

                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Process(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "PROCESS"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("정상적으로 저장 되었습니다.");
                MsgCodeBox.Show("CD00-0071");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt02_SELECT_ROW.GetValue().ToString() != "")
                {
                    int ROW = Convert.ToInt32(this.txt02_SELECT_ROW.GetValue().ToString());

                    DataSet source = AxFlexGrid.GetDataSourceSchema(
                        "CORCD", "BIZCD", "STD_YYYYMM", "COMP_DIV", "OCCUR_DIV", "DOCNO");
                    source.Tables[0].Rows.Add(
                        this.grd01_QA20411.GetValue(ROW, "CORCD"),
                        this.grd01_QA20411.GetValue(ROW, "BIZCD"),
                        this.grd01_QA20411.GetValue(ROW, "STD_YYYYMM"),
                        this.grd01_QA20411.GetValue(ROW, "COMP_DIV"),
                        this.grd01_QA20411.GetValue(ROW, "OCCUR_DIV"),
                        this.grd01_QA20411.GetValue(ROW, "DOCNO")
                    );

                    if (!IsDeleteValid()) return;

                    this.BeforeInvokeServer(true);

                    //_WSCOM.Remove(source);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                    this.AfterInvokeServer();

                    this.BtnReset_Click(null, null);
                    this.BtnQuery_Click(null, null);

                    //MsgBox.Show("정상적으로 삭제 되었습니다.");
                    MsgCodeBox.Show("CD00-0072");
                }
                else
                {
                    //MsgBox.Show("삭제를 하기 위해서는 데이터를 선택하여야 합니다.");
                    MsgCodeBox.Show("QA01-0015");
                    
                    return;
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

        #region [ 기타 이벤트 정의 ]

        private void grd01_QA20411_Click(object sender, EventArgs e)
        {
            if (this.grd01_QA20411.SelectedRowIndex >= this.grd01_QA20411.Rows.Fixed)
            {
                this.txt02_SELECT_ROW.SetValue(this.grd01_QA20411.SelectedRowIndex);
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_HECD_OF_HKMC(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_HECD_OF_HKMC"), paramSet);

                this.AfterInvokeServer();

                _INQUERY_HECD_OF_HKMC = source.Tables[0].Rows[0]["VENDCD"].ToString();
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

        private void btn01_FILE_UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = this.txt02_EXCEL.GetValue().ToString();

                string[] FileNames = filename.Split('.');
                int EndFile = FileNames.Length - 1;

                StringBuilder connectionString = new StringBuilder();

                string FType = filename.Substring(filename.LastIndexOf(".") + 1).ToUpper();
                switch (FType)
                {
                    case "XLS":
                        //connectionString.AppendFormat(@"Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=""Excel 8.0;HDR=YES;IMEX=1"";");
                        connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;IMEX=1';");
                        break;
                    case "XLSX":
                        //connectionString.AppendFormat(@"Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=""Excel 12.0;HDR=YES;IMEX=1"";");
                        connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;IMEX=1';");
                        break;

                    case "":
                        //MsgBox.Show("파일이 선택 되지 않았습니다.");
                        MsgCodeBox.Show("QA01-0001");
                        return; 

                    default:
                        //MsgBox.Show("확장자가 XLS, XLSX이 아닙니다.");
                        MsgCodeBox.Show("QA01-0002");
                        return; 
                }

                connectionString.AppendFormat(@"Data Source={0}", filename);

                OleDbConnection oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();

                DataTable worksheets = oleDB.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string STD_YYYYMM = this.dte01_STD_YYYYMM.GetDateText().Substring(0, 7);
                string TEMP = "";
                string TEMP_VEND = "";

                for (int i = 1; i < this.grd03_QA20411.Rows.Count; i++)
                {
                    if (i != 1)
                    {
                        TEMP = TEMP + ", ";
                    }

                    TEMP = TEMP + " [" + this.grd03_QA20411.GetValue(i, "FILE_COLNM").ToString() + "]";

                    if (this.grd03_QA20411.GetValue(i, "FILE_COLNM").ToString() != this.grd03_QA20411.GetValue(i, "DB_COLNM").ToString())
                    {
                        TEMP = TEMP + " AS " + this.grd03_QA20411.GetValue(i, "DB_COLNM").ToString() + " ";
                    }


                    if (this.grd03_QA20411.GetValue(i, "DB_COLNM").ToString() == "VEND")
                    {
                        TEMP_VEND = this.grd03_QA20411.GetValue(i, "FILE_COLNM").ToString();
                    }
                }

                string commandString = "SELECT " + TEMP + " FROM [" + worksheets.Rows[0]["TABLE_NAME"].ToString() + "] " + " WHERE [" + TEMP_VEND + "] = '" + _INQUERY_HECD_OF_HKMC + "' AND [" + TEMP_VEND + "] <> 'A' ";

                commandString = commandString.Replace("[$SERIAL$]", "''").Replace("[$BIZCD$]", "'" + BIZCD + "'").Replace("[$STD_YYYYMM$]", "'" + STD_YYYYMM + "'").Replace("[$CORCD$]", "'" + _CORCD + "'").Replace("[$NOCASE$]", "'1'");

                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                oleDB.Close();

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(ds);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), ds);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("파일업로드가 완료 되었습니다.");
                MsgCodeBox.Show("QA01-0004");
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

        private void btn01_EXCEL_SELECT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "EXCEL");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DOCUMENT = new byte[(int)fs.Length];
                    fs.Read(_DOCUMENT, 0, _DOCUMENT.Length);
                    fs.Close();

                    this.txt02_EXCEL.SetValue(fs.Name);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btn02_FMT_OK_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd03_QA20411.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "PROGRAM_ID", "SECTOR", "DB_COLNM", "FILE_COLNM",
                    "SEQ_SORT", "REMARK");

                if (!IsExcelSaveValid()) return;

                this.BeforeInvokeServer(true);

                //_WSINQUERY.Save_FIELDS_MAPPING(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "SAVE_FIELDS_MAPPING"), source);
                

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnReset_Click(null, null);

                //MsgBox.Show("정상적으로 저장 되었습니다.");
                MsgCodeBox.Show("CD00-0071");

                this.pnl01_FMT.Visible = false;
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

        private void btn02_FMT_NO_Click(object sender, EventArgs e)
        {

            this.pnl01_FMT.Visible = false;
        }

        private void btn01_FIELDS_MAPPING_Click(object sender, EventArgs e)
        {
            this.pnl01_FMT.Visible = true;
        }

        private void btn01_EXCEL_DOWN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd04_QA20411.Rows.Count > 0)
                {
                    this.saveFileDialog1.DefaultExt = "xls";
                    this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                    this.saveFileDialog1.FileName = this.GetLabel("QA20411_MSG5");// "양식 - HMC_KIA_FLD_CLAIM_FORM";

                    if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string temp_file = this.saveFileDialog1.FileName;

                        this.grd04_QA20411.SaveExcel(temp_file);

                        FileFlags flags = FileFlags.IncludeFixedCells;
                        this.grd04_QA20411.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

                        //MsgBox.Show("다운로드가 완료 되었습니다.");
                        MsgCodeBox.Show("CD00-0106");
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                string VENDCD = this.cdx03_VENDCD.GetValue().ToString();

                if (this.GetByteCount(VENDCD) == 0)
                {
                    //MsgBox.Show("고객사 코드이 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl03_CUSTNM.Text);
                    return false;
                }
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsExcelSaveValid()
        {
            try
            {
                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsDeleteValid()
        {
            try
            {
                string SELECT_ROW = this.txt02_SELECT_ROW.GetValue().ToString();

                if (this.GetByteCount(SELECT_ROW) == 0)
                {
                    //MsgBox.Show("삭제 할 데이터가 선택 되지 않았습니다.");
                    MsgCodeBox.Show("QA01-0015");
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

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
        
        private void FIELDS_MAPPING()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("PROGRAM_ID", "QA20411");
                paramSet.Add("SECTOR", "1");
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_QA4011F(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA4011F"), paramSet);

                this.AfterInvokeServer();

                this.grd03_QA20411.SetValue(source);
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

        private void grd04_QA20411_ADDROW()
        {
            this.grd04_QA20411.Rows.Add();
            this.grd04_QA20411.SetValue(1, "CORNM", "A");
            this.grd04_QA20411.SetValue(1, "OCCUR_DIV", "A");
            this.grd04_QA20411.SetValue(1, "DOCNO", "A");
            this.grd04_QA20411.SetValue(1, "COMP_DIV", "A");
            this.grd04_QA20411.SetValue(1, "VEND", "A");
            this.grd04_QA20411.SetValue(1, "SEQ", "A");
            this.grd04_QA20411.SetValue(1, "RO_YYYYMM", "A");
            this.grd04_QA20411.SetValue(1, "RONO", "A");
            this.grd04_QA20411.SetValue(1, "VINNO", "A");
            this.grd04_QA20411.SetValue(1, "CTYPE", "A");
            this.grd04_QA20411.SetValue(1, "VIN", "A");
            this.grd04_QA20411.SetValue(1, "PARTNO", "A");
            this.grd04_QA20411.SetValue(1, "PARTNM", "A");
            this.grd04_QA20411.SetValue(1, "CAMPAIGNISSUE", "A");
            this.grd04_QA20411.SetValue(1, "CAMPAIGNNAME", "A");
            this.grd04_QA20411.SetValue(1, "MWORKCD", "A");
            this.grd04_QA20411.SetValue(1, "APPLICANT", "A");
            this.grd04_QA20411.SetValue(1, "PRESENT_SIT", "A");
            this.grd04_QA20411.SetValue(1, "PROD_DATE", "A");
            this.grd04_QA20411.SetValue(1, "REPAIR_DATE", "A");
            this.grd04_QA20411.SetValue(1, "SAL_DATE", "A");
            this.grd04_QA20411.SetValue(1, "USE_TERM", "A");
            this.grd04_QA20411.SetValue(1, "TRAVEL_DST", "A");
            this.grd04_QA20411.SetValue(1, "PWA", "A");
            this.grd04_QA20411.SetValue(1, "DELI_RATE", "A");
            this.grd04_QA20411.SetValue(1, "SHA_RATE", "A");
            this.grd04_QA20411.SetValue(1, "APP_RATE", "A");
            this.grd04_QA20411.SetValue(1, "PART_COST", "A");
            this.grd04_QA20411.SetValue(1, "WAGE_COST", "A");
            this.grd04_QA20411.SetValue(1, "SUBCON_COST", "A");
            this.grd04_QA20411.SetValue(1, "OUT_COLOR", "A");
            this.grd04_QA20411.Rows[1].Visible = false;
        }

        #endregion

    }
}
