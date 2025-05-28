#region ▶ Description & History
/* 
 * 프로그램명 : QA20431 HMC, KIA Claim 전자결재 연동
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
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA01.UI
{
    /// <summary>
    /// <b>HKC, KIA Claim 전자결재 연동</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-06-11 오전 11:24:45<br />
    /// - 주요 변경 사항
    ///     1) 2010-06-11 오전 11:24:45   이대형 : 최초 클래스 생성<br />
    ///     2) 2015-02-12                 배명희 : 기존의 세부내역 다운로드는 "요약다운로드"로 변경, "세부 다운로드" 버튼 추가 및 로직 추가
    ///                                            다국어 처리
    /// </summary>
    public partial class QA20431 : AxCommonBaseControl
    {
        //private IQA20431 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;
        //private IQAComboBox _WSCOMBOBOX;
        //private IQAInquery _WSINQUERY;
        private String _VENDCD;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20431";

        #region [ 초기화 작업 정의 ]

        public QA20431()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20431>("QA01", "QA20431.svc", "CustomBinding");

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
                this.cdx01_VENDCD.PopupTitle = "협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.grd01_QA20431.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20431.Initialize();
                this.grd01_QA20431.AllowSorting = AllowSortingEnum.None;
                this.grd01_QA20431.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20431.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "CHK", "CHK_ENABLE", "CHK3");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "결재상태", "DESIDE", "APP_STATUS");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "협력사", "VENDCD","COOPER_NM");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "협력사명", "VENDNM", "COOPER_NM2");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "통보서번호", "DOCRPTNO", "DOCRPTNO");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "건수", "CNT", "COUNT");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "부품비", "PART_COST", "PART_COST");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "공임비", "WAGE_COST", "WAGE_COST");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "외주비", "SUBCON_COST", "SUBCON_COST02");
                this.grd01_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "합계", "SUMTOT", "SUMTOT");
                this.grd01_QA20431.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 100, "PID", "PID", "PID");
                this.grd01_QA20431.SetColumnType(AxFlexGrid.FCellType.Check, "CHK_ENABLE");
                this.grd01_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "CNT");
                this.grd01_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");
                this.grd01_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");
                this.grd01_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");
                this.grd01_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");
                this.grd01_QA20431.CurrentContextMenu.Items[0].Visible = false;
                this.grd01_QA20431.CurrentContextMenu.Items[1].Visible = false;
                this.grd01_QA20431.CurrentContextMenu.Items[2].Visible = false;
                this.grd01_QA20431.CurrentContextMenu.Items[3].Visible = false;


                #region --요약 다운로드용 그리드--
                this.grd02_QA20431.Cols.Count = 1;
                this.grd02_QA20431.AllowDragging = AllowDraggingEnum.None;
                this.grd02_QA20431.Initialize();
                this.grd02_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "차종", "VIN", "VIN"); //"차종"
                this.grd02_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "품목", "ITEM", "ITEM"); //"품목"
                this.grd02_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "발생건수", "OCCUR_CNT", "OCCUR_CNT");//"발생건수"
                this.grd02_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "부품비", "PART_COST", "PART_COST");//"부품비
                this.grd02_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "공임비", "WAGE_COST", "WAGE_COST");//"공임비
                this.grd02_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "용역비", "SUBCON_COST", "SUBCON_COST2");//"용역비
                this.grd02_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "클레임금액", "CLAIM_AMT", "CLAIM_AMT");//클레임금액
                this.grd02_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "OCCUR_CNT");//발생건수
                this.grd02_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");//부품비
                this.grd02_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");//공임비
                this.grd02_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");//용역비
                this.grd02_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "CLAIM_AMT");//클레임금액
                #endregion

                #region --세부 다운로드용 그리드--
                this.grd03_QA20431.Cols.Count = 1;
                this.grd03_QA20431.AllowDragging = AllowDraggingEnum.None;
                this.grd03_QA20431.Initialize();
                
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 85, "통보서번호", "DOCRPTNO", "DOCRPTNO");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 85, "고객통보번호", "CUST_DOCRPTNO", "CUST_DOCRPTNO");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "처리년월", "PROC_DATE", "PROYEAR");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "통보일자", "DOCRPT_DATE", "DOCRPT_DATE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "통보서SEQ", "DOCRPT_SEQ", "DOCRPT_SEQ");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 40, "차종", "VINNM", "VIN");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "품목", "ITEMNM", "ITEM");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 60, "원인부품", "APPLI_PART", "APPLI_PART");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "회사구분", "CMP_DIV", "CMP_DIV");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "발생구분", "OCCUR_DIVCD", "OCCUR_DIVNM");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "발생순위", "OCCUR_SEQ", "OCCUR_SEQ2");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "RO년월", "RO_YYMM", "RO_YYMM");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 145, "RO번호", "RONO", "RONO");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 145, "VIN번호", "VINNO", "VINNO");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "C/TYPE", "CTYPE", "CTYPE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "고객사차종", "VEND_VINCD", "VEND_VIN");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 40, "건수", "NO_CASE", "NO_CASE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "PARTNO", "PARTNO");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 240, "PART NAME", "PARTNM", "PARTNM");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "캠페인ISSUE", "CAMPAIGNISSUE", "CAMPAIGNISSUE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "캠페인명", "CAMPAIGNNAME", "CAMPAIGNNAME");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "주작업코드", "MWORKCD", "MWORKCD");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "원인코드", "APPLICD", "APPLICD");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "현상코드", "PRESCD", "PRESCD");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "수리일자", "REPAIR_DATE", "REPAIR_DATE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "판매일자", "SAL_DATE", "SAL_DATE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "사용기간", "USE_TERM", "USE_TERM");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "주행거리", "TRAVEL_DST", "TRAVEL_DST");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 45, "납입율", "DELI_RATE", "DELI_RATE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 45, "분담율", "SHA_RATE", "SHA_RATE");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 55, "적용률", "APP_RATE", "APP_RATE2");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "부품비", "PART_COST", "PART_COST");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "공임비", "WAGE_COST", "WAGE_COST");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "외주비", "SUBCON_COST", "SUBCON_COST");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "합계", "SUMTOT", "SUMTOT");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "외장색상", "OUT_COLOR", "OUT_COLOR");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "국가코드", "CLAIM_NATIONCD", "NATIONCD");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 85, "정비업체코드", "MAINT_VENDCD", "MAINT_VENDCD");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "거래처", "VENDCD", "VENDORCD");
                this.grd03_QA20431.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "거래처명", "VENDNM", "VENDORNM");
              
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "NO_CASE");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "USE_TERM");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "TRAVEL_DST");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "DELI_RATE");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "SHA_RATE");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "APP_RATE");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "PART_COST");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "WAGE_COST");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUBCON_COST");
                this.grd03_QA20431.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUMTOT");
                
                #endregion

                this.SetRequired(lbl01_BIZNM2, lbl01_DOCRPT_YYMM);
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
                this.grd01_QA20431.InitializeDataSource();
                _VENDCD = "";
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
                string PROC_DATE = this.dte01_PROC_DATE.GetDateText().Substring(0, 7);
                string VENDCD = this.cdx01_VENDCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("PROC_DATE", PROC_DATE);
                paramSet.Add("VENDCD", VENDCD);
                paramSet.Add("LANG_SET", _LANG_SET);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01_QA20431.SetValue(source);
                _VENDCD = "";

                this.grd01_QA20431.Styles.Add("A").BackColor = Color.FromArgb(255, 200, 200);
                this.grd01_QA20431.Styles.Add("B").BackColor = Color.FromArgb(200, 200, 255);
                this.grd01_QA20431.Styles.Add("C").BackColor = Color.FromArgb(200, 255, 200);
                this.grd01_QA20431.Styles.Add("D").BackColor = Color.FromArgb(255,255,255);

                CellRange cr = new CellRange();
                for (int i = 1; i < grd01_QA20431.Rows.Count; i++)
                {
                    cr = grd01_QA20431.GetCellRange(i, grd01_QA20431.Cols.Fixed, i, grd01_QA20431.Cols.Count - grd01_QA20431.Cols.Fixed);

                    switch (this.grd01_QA20431.GetValue(i, "DESIDE").ToString().Substring(0,1))
                    {
                        case "0":
                            cr.Style = grd01_QA20431.Styles["A"];
                            break;
                        case "1":
                            cr.Style = grd01_QA20431.Styles["B"];
                            break;
                        case "2":
                            cr.Style = grd01_QA20431.Styles["C"];
                            break;
                        case "3":
                            cr.Style = grd01_QA20431.Styles["D"];
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
        
        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_QA20431_MouseClick(object sender, MouseEventArgs e)
        {
            int iROW = this.grd01_QA20431.Row;
            int iCOL = this.grd01_QA20431.Col;

            if (iROW > 0 && this.grd01_QA20431.Cols[iCOL].Name == "CHK_ENABLE")
            {
                if (_VENDCD == "" || _VENDCD == this.grd01_QA20431.GetValue(iROW, "VENDCD").ToString())
                {
                    _VENDCD = this.grd01_QA20431.GetValue(iROW, "VENDCD").ToString();
                }
                else
                {
                    this.grd01_QA20431.SetValue(iROW, iCOL, false);
                    //MsgBox.Show("기존 선택하신 협력사와 다른 협력사를 선택하였습니다.");
                    MsgCodeBox.Show("QA01-0033");
                }

                int y = 0;

                for (int i = 0; i < grd01_QA20431.Rows.Count; i++)
                {
                    if (this.grd01_QA20431.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                    {
                        y = y + 1;
                    }
                }

                if (y == 0)
                {
                    _VENDCD = "";
                }
            }
        }

        #endregion

        #region [ 엑셀 다운로드 ]

        private void btn01_DOWN_Click(object sender, EventArgs e)
        {
            this.DownloadSummary(true);
            //try
            //{
            //    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
            //    string VENDCD = "";
            //    string DOCRPTNO = "";
            //    int y = 0;
            //    for (int i = 0; i < grd01_QA20431.Rows.Count; i++)
            //    {
            //        if (this.grd01_QA20431.GetValue(i, "CHK_ENABLE").ToString() == "Y")
            //        {
            //            y = y + 1;
            //            if (y == 1)
            //            {
            //                DOCRPTNO = this.grd01_QA20431.GetValue(i, "DOCRPTNO").ToString();
            //            }
            //            else
            //            {
            //                DOCRPTNO = DOCRPTNO + "," + this.grd01_QA20431.GetValue(i, "DOCRPTNO").ToString();
            //            }

            //            VENDCD = this.grd01_QA20431.GetValue(i, "VENDCD").ToString();
            //        }
            //    }

            //    if (y != 0)
            //    {
            //        HEParameterSet paramSet = new HEParameterSet();
            //        paramSet.Add("CORCD", _CORCD);
            //        paramSet.Add("BIZCD", BIZCD);
            //        paramSet.Add("VENDCD", VENDCD);
            //        paramSet.Add("DOCRPTNO", DOCRPTNO);
            //        paramSet.Add("LANG_SET", _LANG_SET);

            //        this.BeforeInvokeServer(true);

            //        DataSet source = _WSCOM.Inquery_EXCEL(paramSet);

            //        this.AfterInvokeServer();

            //        this.grd02_QA20431.SetValue(source);

            //        if (this.grd02_QA20431.Rows.Count > 0)
            //        {
            //            this.saveFileDialog1.DefaultExt = "xls";
            //            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            //            this.saveFileDialog1.ShowDialog();

            //            string temp_file = this.saveFileDialog1.FileName;
            //            this.grd02_QA20431.SaveExcel(temp_file);

            //            FileFlags flags = FileFlags.IncludeFixedCells;
            //            this.grd02_QA20431.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

            //            //MsgBox.Show("세부내역 다운로드가 완료 되었습니다.");
            //            MsgCodeBox.Show("QA01-0034"); //요약 다운로드가 완료되었습니다.
            //        }
            //    }
            //}
            //catch (FaultException<ExceptionDetail> ex)
            //{
            //    MsgBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    this.AfterInvokeServer();
            //}
        }
        
        private void btn01_DOWN2_Click(object sender, EventArgs e)
        {
            this.DownloadDetail(true);

            //try
            //{
            //    string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
            //    string VENDCD = "";
            //    string DOCRPTNO = "";
            //    int y = 0;
            //    for (int i = 0; i < grd01_QA20431.Rows.Count; i++)
            //    {
            //        if (this.grd01_QA20431.GetValue(i, "CHK_ENABLE").ToString() == "Y")
            //        {
            //            y = y + 1;
            //            if (y == 1)
            //            {
            //                DOCRPTNO = this.grd01_QA20431.GetValue(i, "DOCRPTNO").ToString();
            //            }
            //            else
            //            {
            //                DOCRPTNO = DOCRPTNO + "," + this.grd01_QA20431.GetValue(i, "DOCRPTNO").ToString();
            //            }

            //            VENDCD = this.grd01_QA20431.GetValue(i, "VENDCD").ToString();
            //        }
            //    }

            //    if (y != 0)
            //    {
            //        HEParameterSet paramSet = new HEParameterSet();
            //        paramSet.Add("CORCD", _CORCD);
            //        paramSet.Add("BIZCD", BIZCD);
            //        paramSet.Add("VENDCD", VENDCD);
            //        paramSet.Add("DOCRPTNO", DOCRPTNO);
            //        paramSet.Add("LANG_SET", _LANG_SET);

            //        this.BeforeInvokeServer(true);

            //        DataSet source = _WSCOM.Inquery_EXCEL_Detail(paramSet);

            //        this.AfterInvokeServer();

            //        this.grd03_QA20431.SetValue(source);

            //        if (this.grd03_QA20431.Rows.Count > 0)
            //        {
            //            this.saveFileDialog1.DefaultExt = "xls";
            //            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            //            this.saveFileDialog1.ShowDialog();

            //            string temp_file = this.saveFileDialog1.FileName;
            //            this.grd03_QA20431.SaveExcel(temp_file);

            //            FileFlags flags = FileFlags.IncludeFixedCells;
            //            this.grd03_QA20431.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

            //            //MsgBox.Show("세부내역 다운로드가 완료 되었습니다.");
            //            MsgCodeBox.Show("QA01-0035"); 
            //        }
            //    }
            //}
            //catch (FaultException<ExceptionDetail> ex)
            //{
            //    MsgBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    this.AfterInvokeServer();
            //}
        }

        //요약 다운로드
        private string DownloadSummary(bool openFileDialog)
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string VENDCD = "";
                
                string DOCRPTNO = "";
                int y = 0;
                for (int i = 0; i < grd01_QA20431.Rows.Count; i++)
                {
                    if (this.grd01_QA20431.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                    {
                        y = y + 1;
                        if (y == 1)
                        {
                            DOCRPTNO = this.grd01_QA20431.GetValue(i, "DOCRPTNO").ToString();
                        }
                        else
                        {
                            DOCRPTNO = DOCRPTNO + "," + this.grd01_QA20431.GetValue(i, "DOCRPTNO").ToString();
                        }

                        VENDCD = this.grd01_QA20431.GetValue(i, "VENDCD").ToString();
                    }
                }

                if (y != 0)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("VENDCD", VENDCD);
                    paramSet.Add("DOCRPTNO", DOCRPTNO);
                    paramSet.Add("LANG_SET", _LANG_SET);

                    this.BeforeInvokeServer(true);

                    //DataSet source = _WSCOM.Inquery_EXCEL(paramSet);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_EXCEL"), paramSet);

                    this.AfterInvokeServer();

                    this.grd02_QA20431.SetValue(source);

                    if (this.grd02_QA20431.Rows.Count > 0)
                    {
                        if (openFileDialog)
                        {
                            this.saveFileDialog1.DefaultExt = "xls";
                            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                            this.saveFileDialog1.ShowDialog();

                            string temp_file = this.saveFileDialog1.FileName;
                            this.grd02_QA20431.SaveExcel(temp_file);

                            FileFlags flags = FileFlags.IncludeFixedCells;
                            this.grd02_QA20431.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

                            //MsgBox.Show("세부내역 다운로드가 완료 되었습니다.");
                            MsgCodeBox.Show("QA01-0034"); //요약 다운로드가 완료되었습니다.
                            return temp_file;
                        }
                        else
                        {
                            string temp_file = @"C:\Temp\1.요약본_" + VENDCD + ".xls";
                            this.grd02_QA20431.SaveExcel(temp_file);

                            FileFlags flags = FileFlags.IncludeFixedCells;
                            this.grd02_QA20431.SaveGrid(temp_file, FileFormatEnum.Excel, flags);
                            return temp_file;
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
                return string.Empty;
            }
            return string.Empty;
        }

        //상세 다운로드
        private string DownloadDetail(bool isOpenFileDialog)
        {
            try
            {
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string VENDCD = "";
                
                string DOCRPTNO = "";
                int y = 0;
                for (int i = 0; i < grd01_QA20431.Rows.Count; i++)
                {
                    if (this.grd01_QA20431.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                    {
                        y = y + 1;
                        if (y == 1)
                        {
                            DOCRPTNO = this.grd01_QA20431.GetValue(i, "DOCRPTNO").ToString();
                        }
                        else
                        {
                            DOCRPTNO = DOCRPTNO + "," + this.grd01_QA20431.GetValue(i, "DOCRPTNO").ToString();
                        }

                        VENDCD = this.grd01_QA20431.GetValue(i, "VENDCD").ToString();
                    }
                }

                if (y != 0)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", _CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("VENDCD", VENDCD);
                    paramSet.Add("DOCRPTNO", DOCRPTNO);
                    paramSet.Add("LANG_SET", _LANG_SET);

                    this.BeforeInvokeServer(true);

                    //DataSet source = _WSCOM.Inquery_EXCEL_Detail(paramSet);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_EXCEL_DETAIL"), paramSet);

                    this.AfterInvokeServer();

                    this.grd03_QA20431.SetValue(source);

                    if (this.grd03_QA20431.Rows.Count > 0)
                    {
                        if (isOpenFileDialog)
                        {
                            this.saveFileDialog1.DefaultExt = "xls";
                            this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                            this.saveFileDialog1.ShowDialog();

                            string temp_file = this.saveFileDialog1.FileName;
                            this.grd03_QA20431.SaveExcel(temp_file);

                            FileFlags flags = FileFlags.IncludeFixedCells;
                            this.grd03_QA20431.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

                            //MsgBox.Show("세부내역 다운로드가 완료 되었습니다.");
                            MsgCodeBox.Show("QA01-0035");
                            return temp_file;
                        }
                        else
                        {
                            string temp_file = @"C:\Temp\2.상세본_" + VENDCD + ".xls";

                            this.grd03_QA20431.SaveExcel(temp_file);

                            FileFlags flags = FileFlags.IncludeFixedCells;
                            this.grd03_QA20431.SaveGrid(temp_file, FileFormatEnum.Excel, flags);
                            return temp_file;
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
                return string.Empty;
            }

            return string.Empty;
        }

        #endregion

        #region [ 업체통보/통보취소 관련 ]

        private void btn01_NOTIFY_VENDOR_Click(object sender, EventArgs e)
        {
            if (!IsNOTIFY_VENDOR(grd01_QA20431)) return;

            this.NOTIFY_TO_VENDOR(grd01_QA20431);
            this.BtnQuery_Click(null, null);
        }


        private void btn01_CANCEL_NOTIFY_Click(object sender, EventArgs e)
        {
            if (!IsCANCEL_NOTIFY(grd01_QA20431)) return;

            this.CANCEL_NOTIFY(grd01_QA20431);
            this.BtnQuery_Click(null, null);
        }


        private void NOTIFY_TO_VENDOR(AxFlexGrid grd)
        {
            DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "VENDCD", "DOCRPTNO");

            for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                {
                    // 데이터에 ERPID 업데이트용
                    source.Tables[0].Rows.Add(
                        grd.GetValue(i, "CORCD"),
                        grd.GetValue(i, "BIZCD"),
                        grd.GetValue(i, "VENDCD"),
                        grd.GetValue(i, "DOCRPTNO")
                
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

        private void CANCEL_NOTIFY(AxFlexGrid grd)
        {
            DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "VENDCD", "DOCRPTNO");

            for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "CHK_ENABLE").ToString() == "Y")
                {
                    source.Tables[0].Rows.Add(
                        grd.GetValue(i, "CORCD"),
                        grd.GetValue(i, "BIZCD"),
                        grd.GetValue(i, "VENDCD"),
                        grd.GetValue(i, "DOCRPTNO")
                    );
                }
            }

            if (source.Tables[0].Rows.Count > 0)
            {
                //_WSCOM.App_clear(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "APP_CLEAR"), source);
            }
        }

        #endregion 

        #region [유효성 검사]

        private bool IsNOTIFY_VENDOR(AxFlexGrid grd)
        {
            try
            {


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

        private bool IsCANCEL_NOTIFY(AxFlexGrid grd)
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
    }
}
