#region ▶ Description & History
/* 
 * 프로그램명 : QA30411 HMC, KIA Claim 세부 현황 조회
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
    /// <b>HKC, KIA Claim 세부현황 조회</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-18 오후 7:09:42<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 7:09:42   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA30411 : AxCommonBaseControl
    {
        //private IQA30411 _WSCOM;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;
        private String _CORCD;
        private String _LANG_SET;
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA30411";
        private string PAKAGE_NAME_COMBOBOX = "APG_QACOMBOBOX";
        private string PAKAGE_NAME_INQUERY = "APG_QAINQUERY";

        #region [ 초기화 작업 정의 ]

        public QA30411()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA30411>("QA01", "QA30411.svc", "CustomBinding");
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

                this.cbo01_BIZCD.Enabled = true;

                this.cdx01_SAL_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_SAL_VENDCD.PopupTitle = this.GetLabel("CUSTCD");// "고객사코드";
                this.cdx01_SAL_VENDCD.CodeParameterName = "CUSTCD";
                this.cdx01_SAL_VENDCD.NameParameterName = "CUSTNM";
                this.cdx01_SAL_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source_DATETYPE = _WSCOMBOBOX.Inquery_DATETYPE(paramSet);
                //DataSet source_OCCUR_DIVCD = _WSCOMBOBOX.Inquery_OCCUR_DIVCD(paramSet);
                //DataSet source_COM_CD = _WSCOMBOBOX.Inquery_COM_CD(paramSet);
                //DataSet source_USE_TERM = _WSCOMBOBOX.Inquery_USE_TERM(paramSet);
                DataSet source_DATETYPE = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_DATETYPE"), paramSet);
                DataSet source_OCCUR_DIVCD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_OCCUR_DIVCD"), paramSet);
                DataSet source_COM_CD = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_COM_CD"), paramSet);
                DataSet source_USE_TERM = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_COMBOBOX, "INQUERY_USE_TERM"), paramSet);



                this.AfterInvokeServer();

                this.cbo01_DATETYPE.DataBind(source_DATETYPE.Tables[0], false);
                this.cbo01_DATETYPE.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_OCCUR_DIVCD.DataBind(source_OCCUR_DIVCD.Tables[0]);
                this.cbo01_OCCUR_DIVCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_COM_YN.DataBind(source_COM_CD.Tables[0]);
                this.cbo01_COM_YN.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_USE_TERM_FROM.DataBind(source_USE_TERM.Tables[0]);
                this.cbo01_USE_TERM_FROM.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_USE_TERM_TO.DataBind(source_USE_TERM.Tables[0]);
                this.cbo01_USE_TERM_TO.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");//"협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");//"차종코드";
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_NATIONCD.HEPopupHelper = new QASubWindow();
                this.cdx01_NATIONCD.PopupTitle = this.GetLabel("NATIONCD");//"발생국가코드";
                this.cdx01_NATIONCD.CodeParameterName = "NATIONCD";
                this.cdx01_NATIONCD.NameParameterName = "NATIONNM";
                this.cdx01_NATIONCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_PRESCD.HEPopupHelper = new QASubWindow();
                this.cdx01_PRESCD.PopupTitle = this.GetLabel("PRESCD");//"현상코드";
                this.cdx01_PRESCD.CodeParameterName = "PRESCD";
                this.cdx01_PRESCD.NameParameterName = "PRESNM";
                this.cdx01_PRESCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_APPLICD.HEPopupHelper = new QASubWindow();
                this.cdx01_APPLICD.PopupTitle = this.GetLabel("APPLICD");//"원인코드코드";
                this.cdx01_APPLICD.CodeParameterName = "APPLICD";
                this.cdx01_APPLICD.NameParameterName = "APPLINM";
                this.cdx01_APPLICD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.grd01_APPLI_PART.AllowEditing = true;
                this.grd01_APPLI_PART.Initialize();
                this.grd01_APPLI_PART.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 30, "", "CHK");
                this.grd01_APPLI_PART.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "", "APPLI_PART");
                this.grd01_APPLI_PART.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");

                
                this.grd01_QA30411.AllowEditing = false;
                this.grd01_QA30411.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA30411.Initialize();

                this.grd01_QA30411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA30411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA30411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 60, "고객사", "SAL_VENDCD", "CUSTNM");
                this.grd01_QA30411.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 110, "고객사명", "SAL_VENDNM", "SAL_VENDNM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "통보서번호", "DOCRPTNO", "DOCRPTNO");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 130, "고객통보번호", "CUST_DOCRPTNO", "CUST_DOCRPTNO");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "처리년월", "PROC_DATE","PROYEAR");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "완료", "COM_YN", "COM_YN");
                this.grd01_QA30411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "클레임발생구분", "CLAIM_OCCUR_DIV", "CLAIM_OCCUR_DIV");
                this.grd01_QA30411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "클레임발생구분", "CLAIM_OCCUR_DIVNM", "CLAIM_OCCUR_DIVNM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "통보일자", "DOCRPT_DATE", "DOCRPT_DATE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "정산일자", "ADJUST_DATE", "ADJUST_DATE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "통보서SEQ", "DOCRPT_SEQ", "DOCRPT_SEQ");
                this.grd01_QA30411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 70, "차종", "VINCD","VIN");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종", "VINNM", "VIN");
                this.grd01_QA30411.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMCD","ITEM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMNM","ITEM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "원인부품", "APPLI_PART", "APPLI_PART");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "회사구분", "CMP_DIV", "CMP_DIV");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "발생구분", "OCCUR_DIVCD", "OCCUR_DIVNM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "발생순위", "OCCUR_SEQ", "OCCUR_SEQ");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "RO년월", "RO_YYMM", "RO_YYMM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 145, "RO번호", "RONO", "RONO");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 145, "VIN번호", "VINNO", "VINNO");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "C/TYPE", "CTYPE", "CTYPE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "고객사차종", "VEND_VINCD", "VEND_VIN");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "건수", "NO_CASE", "NO_CASE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "PART NAME", "PARTNM", "PARTNM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "캠페인ISSUE", "CAMPAIGNISSUE", "CAMPAIGNISSUE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "캠페인명", "CAMPAIGNNAME", "CAMPAIGNNAME");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "주작업코드", "MWORKCD", "MWORKCD");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "원인코드", "APPLICD", "APPLICD");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "현상코드", "PRESCD", "PRESCD");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "수리일자", "REPAIR_DATE", "REPAIR_DATE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "판매일자", "SAL_DATE", "SAL_DATE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "사용기간", "USE_TERM", "USE_TERM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "주행거리", "TRAVEL_DST", "TRAVEL_DST");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "납입율", "DELI_RATE", "DELI_RATE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "분담율", "SHA_RATE", "SHA_RATE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "적용률", "APP_RATE", "APP_RATE");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "부품비", "PART_COST", "PART_COST");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "공임비", "WAGE_COST", "WAGE_COST");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "외주비", "SUBCON_COST", "SUBCON_COST");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "합계", "SUMTOT", "SUMTOT");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "외장색상", "OUT_COLOR", "OUT_COLOR");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "국가코드", "CLAIM_NATIONCD","NATIONCD");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 170, "정비업체코드", "MAINT_VENDCD", "MAINT_VENDCD");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "거래처", "VENDCD", "VENDORCD");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "거래처명", "VENDNM", "VENDORNM");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "타사품", "PROD_OTH_YN", "PROD_OTH");
                this.grd01_QA30411.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "보증초과", "NOTAS", "NOTAS");
                //
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "NO_CASE");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "USE_TERM");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "TRAVEL_DST");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "DELI_RATE");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "SHA_RATE");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "APP_RATE");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");
                this.grd01_QA30411.Cols["PROC_DATE"].Format = "yyyy-MM";
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Date, "PROC_DATE");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Date, "DOCRPT_DATE");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Date, "ADJUST_DATE");
                this.grd01_QA30411.Cols["RO_YYMM"].Format = "yyyy-MM";
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Date, "RO_YYMM");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Date, "REPAIR_DATE");
                this.grd01_QA30411.SetColumnType(AxFlexGrid.FCellType.Date, "SAL_DATE");
                this.grd01_QA30411.AllowFreezing = AllowFreezingEnum.Columns;
                this.grd01_QA30411.Cols.Frozen = this.grd01_QA30411.Cols["COM_YN"].Index;

                this.SetRequired(lbl01_BIZNM, lbl01_CUSTNM, lbl01_SHARATE);

                this.cdx01_SAL_VENDCD.SetValue(this.GetSysEnviroment("QUALITY", "SAL_VENDCD_" + this.UserInfo.BusinessCode));

                this.BtnReset_Click(null, null);
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
                this.grd01_QA30411.InitializeDataSource();

                //DataSet source = _WSINQUERY.Inquery_APPLI_PART();
                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_INQUERY, "INQUERY_APPLI_PART"), paramSet);

                source.Tables[0].Columns.Add("CHK");

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        source.Tables[0].Rows[i]["CHK"] = "True";
                    }
                    else
                    {
                        source.Tables[0].Rows[i]["CHK"] = "False";
                    }
                }

                this.grd01_APPLI_PART.SetValue(source.Tables[0]);

                this.grd01_APPLI_PART.Rows[0].Visible = false;
                this.grd01_APPLI_PART.Cols[0].Visible = false;

                this.opt01_APPLY_SHARATE_BEGIN.SetValue("Y");
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
                if (!IsSelectValid()) return;

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();        
                string SAL_VENDCD = this.cdx01_SAL_VENDCD.GetValue().ToString();    
                string DATETYPE = this.cbo01_DATETYPE.GetValue().ToString();
                string PROC_DATE_FROM = this.dte01_PROC_DATE_FROM.GetDateText().Substring(0, 7);
                string PROC_DATE_TO = this.dte01_PROC_DATE_TO.GetDateText().Substring(0, 7);        
                string OCCUR_DIVCD = this.cbo01_OCCUR_DIVCD.GetValue().ToString();    
                string VINCD = this.cdx01_VINCD.GetValue().ToString();        
                string COM_YN = this.cbo01_COM_YN.GetValue().ToString();
                string APPLY_SHARATE = "";
                if (this.opt01_APPLY_SHARATE_BEGIN.GetValue().ToString() == "Y")
                {
                    APPLY_SHARATE = "1";
                }
                else
                {
                    APPLY_SHARATE = "2";
                }
                string OTHERYN = this.chk01_PROD_OTH.GetValue().ToString();
                string NOTAS = this.chk01_NOTAS.GetValue().ToString();    
                string SEARCH_TEXT = this.txt01_SEARCH_TEXT.GetValue().ToString();    
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();
                string PROD_DATE_FROM = this.txt01_PROD_DATE_FROM.GetValue().ToString().Length != 10 ? "": this.txt01_PROD_DATE_FROM.GetValue().ToString();
                string PROD_DATE_TO = this.txt01_PROD_DATE_TO.GetValue().ToString().Length != 10 ? "": this.txt01_PROD_DATE_TO.GetValue().ToString();

                string APPLI_PART = "";
                for(int i = 1;i < this.grd01_APPLI_PART.Rows.Count;i++)
                {
                    if (this.grd01_APPLI_PART.GetValue(i, "CHK").ToString() == "Y")
                    {
                        if (i == 1)
                        {
                            APPLI_PART = this.grd01_APPLI_PART.GetValue(i, "APPLI_PART").ToString();
                        }
                        else
                        {
                            APPLI_PART = APPLI_PART + ";" + this.grd01_APPLI_PART.GetValue(i, "APPLI_PART").ToString();
                        }
                    }
                }

                string NATIONCD = this.cdx01_NATIONCD.GetValue().ToString();
                string PRESCD = this.cdx01_PRESCD.GetValue().ToString();        
                string APPLICD = this.cdx01_APPLICD.GetValue().ToString();        
                string USE_TERM_FROM = this.cbo01_USE_TERM_FROM.GetValue().ToString();        
                string USE_TERM_TO = this.cbo01_USE_TERM_TO.GetValue().ToString();
                string SAL_DATE_FROM = this.txt01_SAL_DATE_FROM.GetValue().ToString().Length != 10 ? "" : this.txt01_SAL_DATE_FROM.GetValue().ToString();
                string SAL_DATE_TO = this.txt01_SAL_DATE_TO.GetValue().ToString().Length != 10 ? "" : this.txt01_SAL_DATE_TO.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("SAL_VENDCD", SAL_VENDCD);
                paramSet.Add("DATETYPE", DATETYPE);
                paramSet.Add("PROC_DATE_FROM", PROC_DATE_FROM);
                paramSet.Add("PROC_DATE_TO", PROC_DATE_TO);
                paramSet.Add("OCCUR_DIVCD", OCCUR_DIVCD);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("COM_YN", COM_YN);
                paramSet.Add("APPLY_SHARATE", APPLY_SHARATE);
                paramSet.Add("OTHERYN", OTHERYN);
                paramSet.Add("SEARCH_TEXT", SEARCH_TEXT);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("PROD_DATE_FROM", PROD_DATE_FROM);
                paramSet.Add("PROD_DATE_TO", PROD_DATE_TO);
                paramSet.Add("APPLI_PART", APPLI_PART);
                paramSet.Add("NATIONCD", NATIONCD);
                paramSet.Add("PRESCD", PRESCD);
                paramSet.Add("APPLICD", APPLICD);
                paramSet.Add("USE_TERM_FROM", USE_TERM_FROM);
                paramSet.Add("USE_TERM_TO", USE_TERM_TO);
                paramSet.Add("SAL_DATE_FROM", SAL_DATE_FROM);
                paramSet.Add("SAL_DATE_TO", SAL_DATE_TO);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("NOTAS", NOTAS);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA30411.SetValue(source);
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

        private void grd01_APPLI_PART_MouseClick(object sender, MouseEventArgs e)
        {
            int ROW = this.grd01_APPLI_PART.Row;

            if (ROW == 1)
            {
                for (int i = 2; i < this.grd01_APPLI_PART.Rows.Count; i++)
                {
                    this.grd01_APPLI_PART.SetValue(i, "CHK", "N");
                }
            }
            else
            {
                this.grd01_APPLI_PART.SetValue(1, "CHK", "N");
            }
        }

        private void opt01_APPLY_SHARATE_BEGIN_CheckedChanged(object sender, EventArgs e)
        {
            if (opt01_APPLY_SHARATE_BEGIN.GetValue().ToString() == "Y")
            {
                this.chk01_PROD_OTH.Enabled = true;
                this.chk01_NOTAS.Enabled = true;
            }
            else
            {
                this.chk01_PROD_OTH.SetValue("N");
                this.chk01_PROD_OTH.Enabled = false;
                this.chk01_NOTAS.SetValue("N");
                this.chk01_NOTAS.Enabled = false;
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSelectValid()
        {
            try
            {
                string SAL_VENDCD = this.cdx01_SAL_VENDCD.GetValue().ToString();

                if (this.GetByteCount(SAL_VENDCD) == 0)
                {
                    //MsgBox.Show("고객사코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", lbl01_CUSTNM.Text);
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

        #endregion


    }
}
