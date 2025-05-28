#region ▶ Description & History
/* 
 * 프로그램명 : PD70020 직수출 반제품 박스라벨 발행
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     신규개발
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Drawing;

using System.Windows.Forms;
using C1.Win.C1FlexGrid;

using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.PD.UI
{

    public partial class PD70020 : AxCommonBaseControl
    {
        
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_PD70020";

        #region [ 초기화 작업 정의 ]

        public PD70020()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.dte01_PLAN_BEG_DATE.SetValue(System.DateTime.Now.ToString("yyyy-MM") + "-01");
                this.dte01_PLAN_END_DATE.SetMMFromStart();
                this.dte02_ISSUE_BEG_DATE.SetMMFromStart();
                this.dte02_ISSUE_END_DATE.SetMMFromStart();


                this.cdx01_CUSTCD.HEPopupHelper = new Ax.SIS.CM.UI.CM22022P1();
                this.cdx01_CUSTCD.CodeParameterName = "CUSTCD";
                this.cdx01_CUSTCD.NameParameterName = "CUSTNM";
                this.cdx01_CUSTCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_CUSTCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                #region [  grd01  ]

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AllowEditing = true;

                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 085, "판매오더NO", "SO_NO", "SALE_ORDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 045, "SEQ", "SO_SEQ", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "고객PO번호", "CUST_PONO", "CUST_PONO3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "수주일자", "ORD_DATE", "ORD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "선적요청일", "BIZ_DELI_DATE", "RSHIPYMD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "고객코드", "CUSTCD", "CUSTCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "고객명", "CUSTNM", "CUSTNM4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 045, "차종", "VINCD", "VEHICLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "자재품번", "PARTNO", "MAT_PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "자재품명", "PARTNM", "MAT_PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "자재단위", "UNIT", "UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "수주수량", "ORDER_QTY", "ORD_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "계획량", "PLAN_QTY", "PLAN_QTY1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "실적량", "RSLT_QTY", "RSLT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "미생산량", "REMAIN_QTY", "REMAIN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "발행량", "ISSUED_QTY", "ISSUED_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "미발행량", "NONE_ISSUE_QTY", "NONE_ISSUE_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "박스적입수량", "BOX_UNIT_QTY", "BOX_UNIT_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "박스수량", "BOX_QTY", "BOX_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "생산LOTNO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "유통경로", "VTEXT", "VTWEG");
                
                

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("VTWEG");
                this.grd01.AddHiddenColumn("BARCODE_DIV");
                this.grd01.AddHiddenColumn("SORT_SEQ");
                this.grd01.AddHiddenColumn("ISSUE_DATE_FROM");
                this.grd01.AddHiddenColumn("ISSUE_DATE_TO");

                this.grd01.Cols["ORDER_QTY"].DataType = typeof(decimal);
                this.grd01.Cols["PLAN_QTY"].DataType = typeof(decimal);
                this.grd01.Cols["RSLT_QTY"].DataType = typeof(decimal);
                this.grd01.Cols["REMAIN_QTY"].DataType = typeof(decimal);
                this.grd01.Cols["ISSUED_QTY"].DataType = typeof(decimal);
                this.grd01.Cols["NONE_ISSUE_QTY"].DataType = typeof(decimal);
                this.grd01.Cols["BOX_UNIT_QTY"].DataType = typeof(decimal);
                this.grd01.Cols["BOX_QTY"].DataType = typeof(decimal);

                this.grd01.Cols["ORDER_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.Cols["PLAN_QTY"].Format ="#,###,###,###,###,###,##0";
                this.grd01.Cols["RSLT_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.Cols["REMAIN_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.Cols["ISSUED_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.Cols["NONE_ISSUE_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.Cols["BOX_UNIT_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.Cols["BOX_QTY"].Format = "#,###,###,###,###,###,##0";

                this.grd01.Cols["BOX_UNIT_QTY"].Style.BackColor = Color.Beige;
                this.grd01.Cols["BOX_QTY"].Style.BackColor = Color.Beige;

                CellStyle csBg = this.grd01.Styles.Add("bgWarn");
                csBg.BackColor = Color.Orange;

                csBg = this.grd01.Styles.Add("bgAlarm");
                csBg.BackColor = Color.Beige;

                #endregion

                #region [  grd02  ]

                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.AllowEditing = true;

                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "선택", "CHK", "CHK");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매오더NO", "SO_NO", "SALE_ORDNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매오더순번", "SO_SEQ", "SALE_SEQNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Part No", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "Part Name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "총수량", "QTY", "CNT_COMPLY_TT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "라벨수량", "LABEL_QTY", "LABEL_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "발행횟수", "ISSUE_CNT", "ISSUE_CNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "발행상태", "STATUS", "ISSUE_STATUS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "전송상태", "IF_STATUS", "TRANS_STATUS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "발행일시", "ISSUE_TIME_2", "ISSUE_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "작업자", "USER_ID", "WORKER");

                this.grd02.AddHiddenColumn("ISSUE_TIME");
                this.grd02.AddHiddenColumn("CORCD");
                this.grd02.AddHiddenColumn("BIZCD");
                this.grd02.AddHiddenColumn("IF_STATUS_COLOR");
                this.grd02.AddHiddenColumn("CANCEL_YN");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                this.grd02.Cols["QTY"].DataType = typeof(decimal);
                this.grd02.Cols["QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd02.Cols["ISSUE_CNT"].DataType = typeof(decimal);
                this.grd02.Cols["ISSUE_CNT"].Format = "#,###,###,###,###,###,##0";
                this.grd02.Cols["LABEL_QTY"].DataType = typeof(decimal);
                this.grd02.Cols["LABEL_QTY"].Format = "#,###,###,###,###,###,##0";
                

                CellStyle csBlue = this.grd02.Styles.Add("fontBlue");
                csBlue.ForeColor = Color.Blue;
                CellStyle csBluebgGray = this.grd02.Styles.Add("fontBluebgGray");
                csBluebgGray.ForeColor = Color.Blue;
                csBluebgGray.BackColor = Color.Gray;

                CellStyle csRed = this.grd02.Styles.Add("fontRed");
                csRed.ForeColor = Color.Red;
                CellStyle csRedbgGray = this.grd02.Styles.Add("fontRedbgGray");
                csRedbgGray.ForeColor = Color.Red;
                csRedbgGray.BackColor = Color.Gray;

                CellStyle csGray = this.grd02.Styles.Add("bgGray");
                csGray.BackColor = Color.Gray;
                #endregion

                #region [  grd03  ]

                this.grd03.AllowEditing = false;
                this.grd03.AllowDragging = AllowDraggingEnum.None;
                this.grd03.Initialize();


                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "바코드", "BOX_BARCODE", "BARCODE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "수량", "QTY", "QTY");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "취소여부", "CANC_YN", "CANCEL_YN");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "처리상태", "ZRSLT_SAP", "PROC_STA");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "I/F 날짜", "ZDATE_SAP", "ZDATE_SAP");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "I/F 시간", "ZTIME_SAP", "ZTIME_SAP");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "메시지", "ZMSG_SAP", "MESSAGE");
                
                #endregion

                this.SetRequired(lbl01_BIZNM2, lbl01_PLAN_DATE);
                
             
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
                if (!this.IsQueryValid())
                    return;
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("BEG_DATE", this.dte01_PLAN_BEG_DATE.GetDateText());
                paramSet.Add("END_DATE", this.dte01_PLAN_END_DATE.GetDateText());
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("SO_NO", this.txt01_SO_NO.GetValue());
                paramSet.Add("CUST_PONO", this.txt01_CUST_PONO.GetValue());
                paramSet.Add("PART", this.txt01_PARTNO_PARTNM.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01.SetValue(source);

                //상태에 따른 행 배경색 지정
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    string seq = this.grd01.GetValue(i, "SORT_SEQ").ToString();
                    // [실적수량 != 발행수량] 이면 오렌지색
                    // [계획수량 != 실적수량] 이면 베이지색
                    if (seq == "1" || seq == "2")
                        for (int c = this.grd01.Cols.Fixed; c <= this.grd01.Cols["PARTNM"].Index; c++)
                        {
                            this.grd01.SetCellStyle(i, c, (seq == "1" ? "bgWarn" : "bgAlarm"));
                        }
                    else
                        this.grd01.Rows[i].StyleNew.Clear();

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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema(
                                        "CORCD", "BIZCD", "CUSTCD", "VTWEG",
                                        "VTEXT", "SO_NO", "SO_SEQ", "CUST_PONO", "PARTNO", 
                                        "PARTNM", "QTY", "UNIT", "LOTNO", "ISSUE_TIME", 
                                        "BARCODE_DIV", "INSERT_ID");


                DataSet data = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                                        "CORCD", "BIZCD", "CUSTCD", "VTWEG",
                                        "VTEXT", "SO_NO", "SO_SEQ", "CUST_PONO", "PARTNO",
                                        "PARTNM", "UNIT", "LOTNO", "BARCODE_DIV", 
                                        "BOX_UNIT_QTY", "BOX_QTY", "NONE_ISSUE_QTY");

                if (!IsSaveValid(data)) return;
                                
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    if (dr["BOX_QTY"] != DBNull.Value && !dr["BOX_QTY"].ToString().Equals("") && Convert.ToInt32(dr["BOX_QTY"]) > 0)
                    {
                        int boxQty = Convert.ToInt32(dr["BOX_QTY"]);
                        string issueDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

                        //테이터를 박스수량 만큼 레코드 생성
                        for (int i = 0; i < boxQty; i++)
                        {
                            source.Tables[0].Rows.Add(dr["CORCD"],
                                                      dr["BIZCD"],
                                                      dr["CUSTCD"],
                                                      dr["VTWEG"],
                                                      dr["VTEXT"],                                                      
                                                      dr["SO_NO"],
                                                      dr["SO_SEQ"],
                                                      dr["CUST_PONO"],
                                                      dr["PARTNO"],
                                                      dr["PARTNM"],
                                                      dr["BOX_UNIT_QTY"],
                                                      dr["UNIT"],
                                                      dr["LOTNO"],
                                                      issueDateTime,
                                                      dr["BARCODE_DIV"],
                                                      this.UserInfo.UserID);
                        }                           
                    }
                    

                }

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                
                this.reset(false);
                this.btn01_INQUERY_Click(null, null);

                //MsgBox.Show("저장되었습니다.");
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

        #endregion

        #region [ 사용자 정의 메서드 ]

        //바코드 출력 영역 조회조건 초기화
        private void reset(bool onlytoday)
        {
            if (onlytoday)
            {
                this.dte02_ISSUE_BEG_DATE.SetMMFromStart();
                this.dte02_ISSUE_END_DATE.SetMMFromStart();
            }
            this.txt02_SO_NO.SetValue("");
            this.txt02_SO_SEQ.SetValue("");
            this.txt02_PARTNO.SetValue("");
        }
        
        #endregion

        #region [ 유효성 검사 ]

        private bool IsCancelValid(DataSet source)
        {
            try
            {


                if (source.Tables[0].Rows.Count <= 0)
                {
                    //처리할 대상 Data가 없습니다.
                    MsgCodeBox.Show("COM-00021");
                    return false;
                }



                DataRow dr = source.Tables[0].Rows[0];

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", dr["CORCD"].ToString());
                paramSet.Add("BIZCD", dr["BIZCD"].ToString());
                paramSet.Add("SO_NO", dr["SO_NO"].ToString());
                paramSet.Add("SO_SEQ", dr["SO_SEQ"].ToString());
                paramSet.Add("ISSUE_TIME", dr["ISSUE_TIME"].ToString());
                DataSet dsCheck = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CANCEL_VALID"), paramSet);

                if (dsCheck.Tables[0].Rows[0]["CANC_LABEL_CNT"].ToString() != "0")
                {
                    //취소 처리된 바코드 라벨입니다.
                    MsgCodeBox.Show("PD00-0045");
                    return false;
                }


                if (dsCheck.Tables[0].Rows[0]["IF_CNT"].ToString() != "0") //IF_CNT = IF11.ZEXT9023에 생성된 데이터 건수
                {
                    if (dsCheck.Tables[0].Rows[0]["IF_ING_CNT"].ToString() != "0")
                    {
                        //SAP I/F 전송이 진행중입니다.
                        MsgCodeBox.Show("PD00-0046");
                        return false;
                    }

                    ////IF11.ZEXT9023에 데이터 생성되어 있는 경우에만 SAP 전송상태를 체크한다. 전송진행중이면 취소 불가. (전송완료 후 취소 가능함)
                    //if (dsCheck.Tables[0].Rows[0]["IF_ING_CNT"].ToString() == dsCheck.Tables[0].Rows[0]["LABEL_CNT"].ToString())
                    //{
                    //    //SAP I/F 전송이 진행중입니다.
                    //    MsgCodeBox.Show("PD00-0046");
                    //    return false;
                    //}
                }


                

                //발행 취소하시겠습니까?
                if (MsgCodeBox.Show("PD00-0044", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                return true;


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

        }
        
        private bool IsIFValid(DataSet source)
        {
            try
            {

                if (source.Tables[0].Rows.Count <= 0)
                {
                    //처리할 대상 Data가 없습니다.
                    MsgCodeBox.Show("COM-00021");
                    return false;
                }



                DataRow dr = source.Tables[0].Rows[0];

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", dr["CORCD"].ToString());
                paramSet.Add("BIZCD", dr["BIZCD"].ToString());
                paramSet.Add("SO_NO", dr["SO_NO"].ToString());
                paramSet.Add("SO_SEQ", dr["SO_SEQ"].ToString());
                paramSet.Add("ISSUE_TIME", dr["ISSUE_TIME"].ToString());
                DataSet dsCheck = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_IF_VALID"), paramSet);

                if (dsCheck.Tables[0].Rows[0]["IF_DATA_CNT"].ToString() == "")
                {
                    //처리할 대상 Data가 없습니다.
                    MsgCodeBox.Show("COM-00021");
                    return false;
                }


                if (dsCheck.Tables[0].Rows[0]["IF_DATA_CNT"].ToString() != "0")
                {
                    //이미 전송 처리되었습니다.
                    MsgCodeBox.Show("PD00-0042");
                    return false;
                }

                if (dsCheck.Tables[0].Rows[0]["CANC_LABEL_CNT"].ToString() != "0")
                {
                    //취소 처리된 바코드 라벨입니다.
                    MsgCodeBox.Show("PD00-0045");
                    return false;
                }

                //I/F 전송하시겠습니까?
                if (MsgCodeBox.Show("PD00-0043", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                return true;


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

        }
       
        private bool IsPrintValid(DataSet source)
        { 
            try
            {
                
                if (source.Tables[0].Rows.Count <= 0)
                {
                    //출력할 대상 Data가 없습니다.
                    MsgCodeBox.Show("COM-00022");
                    return false;
                }



                DataRow dr = source.Tables[0].Rows[0];

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", dr["CORCD"].ToString());
                paramSet.Add("BIZCD", dr["BIZCD"].ToString());
                paramSet.Add("SO_NO", dr["SO_NO"].ToString());
                paramSet.Add("SO_SEQ", dr["SO_SEQ"].ToString());
                paramSet.Add("ISSUE_TIME", dr["ISSUE_TIME"].ToString());
                DataSet dsCheck = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_PRINT_VALID"), paramSet);

                if (dsCheck.Tables[0].Rows[0]["LABEL_CNT"].ToString() == "" || dsCheck.Tables[0].Rows[0]["LABEL_CNT"].ToString() == "0")
                {
                    //출력할 대상 Data가 없습니다.
                    MsgCodeBox.Show("COM-00022");
                    return false;
                }

                if (dsCheck.Tables[0].Rows[0]["CANC_LABEL_CNT"].ToString() != "0")
                {
                    //취소 처리된 바코드 라벨입니다.
                    MsgCodeBox.Show("PD00-0045");
                    return false;
                }
                
                if (dsCheck.Tables[0].Rows[0]["FAIL_CNT"].ToString() != "0")
                {
                    //SAP I/F전송이 실패하여 출력할 수 없습니다.
                    MsgCodeBox.Show("PD00-0047");
                    return false;
                }

                if (dsCheck.Tables[0].Rows[0]["LABEL_CNT"].ToString() != dsCheck.Tables[0].Rows[0]["IF_CNT"].ToString())
                {
                    //바코드 데이터와 IF 완료된 데이터 수가 다른 경우
                    //SAP I/F 전송이 완료되지 않아 출력할 수 없습니다.
                    MsgCodeBox.Show("PD00-0041"); 
                    return false;
                }

                
                //출력하시겠습니까?
                if (MsgCodeBox.Show("CD00-0085", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                return true;
                
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

        }
        
        private bool IsQueryValid()
        {
            try
            {
                
                if (this.cbo01_BIZCD.ByteCount == 0)
                {
                    //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("LINECD"));
                    return false;
                }
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                int cnt = 0;
                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = source.Tables[0].Rows[i];
                    int rowIdx = Convert.ToInt32(source.Tables[1].Rows[i][0]);

                    //박스적입수량
                    int boxUnitQty = (dr["BOX_UNIT_QTY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BOX_UNIT_QTY"]));
                    if (boxUnitQty <= 0)
                    {
                        //{0} 번째 행에 {1}은(는) 0보다 큰 값을 입력해야 합니다.
                        MsgCodeBox.ShowFormat("CD00-0123", rowIdx, this.grd01.Cols["BOX_UNIT_QTY"].Caption, 0);
                        return false;
                    }

                    //박수수량
                    int boxQty= (dr["BOX_QTY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BOX_QTY"]));
                    if (boxQty < 0)
                    {
                        //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                        MsgCodeBox.ShowFormat("CD00-0096", rowIdx, this.grd01.Cols["BOX_QTY"].Caption);
                        return false;
                    }

                    int none_issue_qty = (dr["NONE_ISSUE_QTY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NONE_ISSUE_QTY"]));

                    //박스적입수량 * 박스수량이 미발행량보다 크면 안됨!!!!!!!
                    if (none_issue_qty < boxUnitQty * boxQty)
                    {
                        //발행량
                        //{0} 번째 행에 {1} 은 {2} 보다 큽니다.\r\n{1} 를 다시  입력 하십시요.
                        //
                        MsgCodeBox.ShowFormat("PD00-0105", rowIdx, 
                                                            this.grd01.Cols["BOX_QTY"].Caption + " X " + this.grd01.Cols["BOX_UNIT_QTY"].Caption, 
                                                            this.grd01.Cols["NONE_ISSUE_QTY"].Caption);
                        return false;
                    }

                    cnt++;
                }

                if (cnt == 0)
                {
                    MsgCodeBox.Show("CD00-0042"); //저장할 데이터가 존재하지 않습니다.
                    return false;
                }

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

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rowIdx = this.grd01.MouseRow;
            if (rowIdx >= this.grd01.Rows.Fixed && rowIdx < this.grd01.Rows.Count)
            {
                string so_no = this.grd01.GetValue(rowIdx, "SO_NO").ToString();
                string so_seq = this.grd01.GetValue(rowIdx, "SO_SEQ").ToString();
                string partno = this.grd01.GetValue(rowIdx, "PARTNO").ToString();
                string from = this.grd01.GetValue(rowIdx, "ISSUE_DATE_FROM").ToString();
                string to = this.grd01.GetValue(rowIdx, "ISSUE_DATE_TO").ToString();


                this.dte02_ISSUE_BEG_DATE.SetValue(from);
                this.dte02_ISSUE_END_DATE.SetValue(to);
                this.txt02_SO_NO.SetValue(so_no);
                this.txt02_SO_SEQ.SetValue(so_seq);
                this.txt02_PARTNO.SetValue(partno);

                this.btn01_INQUERY_Click(null, null);
            }
        }

        #region -- 바코드 Print 그리드 --

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd02.SelectedRowIndex;

                if (Row >= this.grd02.Rows.Fixed)
                {
                    string CORCD = this.grd02.GetValue(Row, "CORCD").ToString();
                    string BIZCD = this.grd02.GetValue(Row, "BIZCD").ToString();
                    string SO_NO = this.grd02.GetValue(Row, "SO_NO").ToString();
                    string SO_SEQ = this.grd02.GetValue(Row, "SO_SEQ").ToString();
                    string ISSUE_TIME = this.grd02.GetValue(Row, "ISSUE_TIME").ToString();

                   
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", CORCD);
                    paramSet.Add("BIZCD", BIZCD);
                    paramSet.Add("SO_NO", SO_NO);
                    paramSet.Add("SO_SEQ", SO_SEQ);
                    paramSet.Add("ISSUE_TIME", ISSUE_TIME);
                    paramSet.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);

                    //DataSet source = _WSCOM.Inquery(paramSet);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_BOXBARCODE_DETAIL"), paramSet);

                    this.AfterInvokeServer();

                    this.grd03.SetValue(source);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

        }
        
        private void grd02_CellChecked(object sender, RowColEventArgs e)
        {
            try
            {
                int col = e.Col;
                int row = e.Row;


                if (col == this.grd02.Cols["CHK"].Index)
                {
                    string chk = this.grd02.GetValue(row, col).ToString();

                    if (chk == "Y")
                    {
                        for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                        {
                            if( i != row)
                                this.grd02.SetValue(i, col, 0);
                        }
                    }
                        
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        // 체크박스만 어떻게 잘 클릭해서 그리드에 포커스 안가고 체크박스에만 포커스가 간 경우에는 위 "grd02_CellChecked"를 안탐.. 
        // 그래서 동일한 로직을 grd02_MouseClick에서도 구현함.
        private void grd02_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                int col = this.grd02.MouseCol;
                int row = this.grd02.MouseRow;

                if (col < this.grd02.Cols.Fixed || col >= this.grd02.Cols.Count) return;
                if (row < this.grd02.Rows.Fixed || row >= this.grd02.Rows.Count) return;

                if (col == this.grd02.Cols["CHK"].Index)
                {
                    //전체 데이터 중에서 1건만 체크되도록 함.
                    string chk = this.grd02.GetValue(row, col).ToString();

                    if (chk == "Y")
                    {
                        for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                        {
                            if (i != row)
                                this.grd02.SetValue(i, col, 0);
                        }
                    }

                }
                else
                {
                    //마우스 클릭한 행 체크박스 체크 되도록 함.
                    this.grd02.SetValue(row, this.grd02.Cols["CHK"].Index, 1);
                    for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                    {
                        if (i != row)
                            this.grd02.SetValue(i, this.grd02.Cols["CHK"].Index, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region -- 조회/ 출력 / 전송/ 취소 버튼 --
        
        private void btn01_INQUERY_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsQueryValid())
                    return;
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("BEG_DATE", this.dte02_ISSUE_BEG_DATE.GetDateText());
                paramSet.Add("END_DATE", this.dte02_ISSUE_END_DATE.GetDateText());
                paramSet.Add("SO_NO", this.txt02_SO_NO.GetValue());
                paramSet.Add("SO_SEQ", this.txt02_SO_SEQ.GetValue());
                paramSet.Add("PARTNO", this.txt02_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_BOXBARCODE"), paramSet);

                this.AfterInvokeServer();

                this.grd02.SetValue(source);

                for (int r = this.grd02.Rows.Fixed; r < this.grd02.Rows.Count; r++)
                {
                    string status = this.grd02.GetValue(r, "IF_STATUS_COLOR").ToString();
                    string cancel = this.grd02.GetValue(r, "CANCEL_YN").ToString();

                    this.grd02.Rows[r].StyleNew.Clear();
                    if (cancel.Equals("Y"))
                    {
                        //취소행은 배경색 회색
                        for (int c = this.grd02.Cols.Fixed; c < this.grd02.Cols.Count; c++)
                            this.grd02.SetCellStyle(r, c, "bgGray");

                        if (status.Equals("BLUE"))
                            this.grd02.SetCellStyle(r, this.grd02.Cols["IF_STATUS"].Index, "fontBluebgGray");
                        else if (status.Equals("RED"))
                            this.grd02.SetCellStyle(r, this.grd02.Cols["IF_STATUS"].Index, "fontRedbgGray");
                    }
                    else
                    {
                        if (status.Equals("BLUE"))
                            this.grd02.SetCellStyle(r, this.grd02.Cols["IF_STATUS"].Index, "fontBlue");
                        else if (status.Equals("RED"))
                            this.grd02.SetCellStyle(r, this.grd02.Cols["IF_STATUS"].Index, "fontRed");
                    }
                    
                }

                this.grd03.InitializeDataSource();
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

        private void btn01_RESET_Click(object sender, EventArgs e)
        {
            try
            {
                this.reset(true);
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

        private void bn01_PRINT_Click(object sender, EventArgs e)
        {
            try
            {
                

                DataSet data = this.grd02.GetValue( AxFlexGrid.FActionType.All, "CHK", "CORCD", "BIZCD", 
                                                                                "SO_NO", "SO_SEQ", "ISSUE_TIME");
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SO_NO", "SO_SEQ",
                                                                    "ISSUE_TIME",  "LANG_SET", "PAPER", "UPDATE_ID");

                foreach(DataRow dr in data.Tables[0].Rows)
                {
                    string chk = dr["CHK"].ToString();
                    if (chk != "Y")
                        continue;

                    source.Tables[0].Rows.Add(dr["CORCD"], dr["BIZCD"], dr["SO_NO"], dr["SO_SEQ"], 
                        dr["ISSUE_TIME"], this.UserInfo.Language, (this.rdo02_A4.Checked ? "A4" : "ROLL"), this.UserInfo.UserID);
                }

                if (!IsPrintValid(source))
                    return;

                this.BeforeInvokeServer(true);

                
                // 체크박스 선택한 데이터 루프돌면서 리포트 미리보기 팝업 띄움. 현재는 1건만 선택할수 있으므로 한번만 루프돔.
                foreach (DataRow dr in source.Tables[0].Rows)
                //for (int i =0; i<10; i++)
                {
                    //DataRow dr = source.Tables[0].Rows[0];
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", dr["CORCD"]);
                    set.Add("BIZCD", dr["BIZCD"]);
                    set.Add("SO_NO", dr["SO_NO"]);
                    set.Add("SO_SEQ", dr["SO_SEQ"]);
                    set.Add("ISSUE_TIME", dr["ISSUE_TIME"]);
                    set.Add("LANG_SET", dr["LANG_SET"]);
                    set.Add("PAPER", dr["PAPER"]);
                    set.Add("UPDATE_ID", dr["UPDATE_ID"]);

                    DataSet dsReport = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_REPORT"), set);
                    dsReport.Tables[0].TableName = "DATA";

                    HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                    //출력구분에 따라 양식이 다름.
                    if(this.rdo02_A4.Checked ) 
                        report.ReportName = "RxRpt/KdPkPackA4P";  
                    else
                        report.ReportName = "RxRpt/KdPoDeliPackP";

                    HERexSection mainSection = new HERexSection();
                    mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);                    
                    report.Sections.Add("MAIN", mainSection);
                    HERexSection xmlSection = new HERexSection(dsReport, new HEParameterSet());
                    report.Sections.Add("XML1", xmlSection); 
                    AxRexpertReportViewer.ShowReport(report);
                }
                this.AfterInvokeServer();

                //발행횟수 재조회
                this.btn01_INQUERY_Click(null, null);

                //MsgBox.Show("저장되었습니다.");
                //MsgCodeBox.Show("CD00-0071");


            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
        }
         
        private void btn01_CANCEL_Click(object sender, EventArgs e)
        {
            try
            {


                DataSet data = this.grd02.GetValue(AxFlexGrid.FActionType.All, "CHK", "CORCD", "BIZCD", "SO_NO", "SO_SEQ", "ISSUE_TIME");
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SO_NO", "SO_SEQ", "ISSUE_TIME", "UPDATE_ID");

                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    string chk = dr["CHK"].ToString();
                    if (chk != "Y")
                        continue;

                    source.Tables[0].Rows.Add(dr["CORCD"], dr["BIZCD"], dr["SO_NO"], dr["SO_SEQ"], dr["ISSUE_TIME"], UserInfo.UserID);
                }

                if (!IsCancelValid(source))
                    return;


                this.BeforeInvokeServer(true);


                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_CANCEL"), source);

                this.AfterInvokeServer();

                //발행횟수 재조회
                this.btn01_INQUERY_Click(null, null);

                //MsgBox.Show("저장되었습니다.");
                //MsgCodeBox.Show("CD00-0071");


            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }

        }

        private void btn01_IF_Click(object sender, EventArgs e)
        {
            try
            {


                DataSet data = this.grd02.GetValue(AxFlexGrid.FActionType.All, "CHK", "CORCD", "BIZCD",
                                                                                "SO_NO", "SO_SEQ", "ISSUE_TIME");
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SO_NO", "SO_SEQ", "ISSUE_TIME");

                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    string chk = dr["CHK"].ToString();
                    if (chk != "Y")
                        continue;

                    source.Tables[0].Rows.Add(dr["CORCD"], dr["BIZCD"], dr["SO_NO"], dr["SO_SEQ"], dr["ISSUE_TIME"]);
                }

                if (!IsIFValid(source))
                    return;


                this.BeforeInvokeServer(true);


                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_IF"), source);

                this.AfterInvokeServer();

                //발행횟수 재조회
                this.btn01_INQUERY_Click(null, null);

                //MsgBox.Show("저장되었습니다.");
                //MsgCodeBox.Show("CD00-0071");


            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
        }
        
        #endregion
        
        #endregion       

    }
}
