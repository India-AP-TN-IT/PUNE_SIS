#region ▶ Description & History
/* 
 * 프로그램명 : 프로그램 사용현황 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : ㅂ명희
 * 최종수정일 : 2013-11-12
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2013-11-12	    배명희		등록일자, 수정일자 정보 추가
 *				
 *              2013-11-12      배명희      [#001] 사번/파트 팝업 조회 기능 추가, 그리드 상단에 총 합계 추가. *           
 *                                          [#002] 미사용제외 기능 추가 - 체크하면 사용하지 않는 데이터는 화면에 미 표시
 *                                          [#003] 사용자별로 프로그램 사용현황 조회 기능 추가.(사번별 건수)
 *                                          [#004] 화면 로드시 기본 조회 기능 제거함. (2014.04.23)
 *              2014-07-08      배명희      프로그램 아이디 변경(X60020 -> XM30303)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 공통컨트롤로 전환
 *              2014-07-15      배명희      사용자별 조회시 모듈정보(대메뉴) 외에 하위 "중메뉴" 조건도 추가.
 *              2014-07-21      배명희      사용자별 조회 그리드(GRD02) USERID, NAME_KOR 컬럼 allowMerging = true 처리함.
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거        
 *              2014-08-13      배명희     사용자별 조회 그리드(GRD02)에 소속(DEPTNM)항목 추가, AllowMerging = true처리.
 *              2014-08-14      배명희     사용자별 조회 그리드(GRD02)에 소속별 소계 추가. 고정컬럼 스타일의 BORDER COLOR 변경(색이 너무 연해서)
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
 * 
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// 프로그램 사용현황 조회ㅇㅇㅇ
    /// </summary>
    public partial class XM30303 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM30303";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";
        private string PAKAGE_NAME_XM20005 = "APG_XM20005";        

        private bool _isLoadCompleted = false;
        private string gubun = "";

        public XM30303()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 설정 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_메뉴아이디", "MENUID", "MENUID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_메뉴구분", "MENU_DIV", "MENU_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 380, "_메뉴명", "MENUNM", "MENUNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_OPEN", "CNT", "CNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_조회", "QUERY_CNT", "QUERY_CNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_저장", "SAVE_CNT", "SAVE_CNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_삭제", "DELETE_CNT", "DELETE_CNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_처리", "PROCESS_CNT", "PROCESS_CNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "_최종사용일시", "LAST_OPEN_TIME", "LAST_OPEN_TIME");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 060, "_정렬순서", "SORT_SEQ", "SORT_SEQ");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QUERY_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SAVE_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DELETE_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PROCESS_CNT");
                this.grd01.Cols["CNT"].Format = "#,###,###,###,##0";
                this.grd01.Cols["QUERY_CNT"].Format = "#,###,###,###,##0";
                this.grd01.Cols["SAVE_CNT"].Format = "#,###,###,###,##0";
                this.grd01.Cols["DELETE_CNT"].Format = "#,###,###,###,##0";
                this.grd01.Cols["PROCESS_CNT"].Format = "#,###,###,###,##0";

                //#003
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                //this.grd02.Cols.RemoveRange(1, this.grd02.Cols.Count - 1);
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_소속", "DEPTNM", "DEPTNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "_성명", "NAME_KOR", "NAME_KOR");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "_사용자 아이디", "USERID", "USERID");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_메뉴아이디", "MENUID", "MENUID");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_메뉴구분", "MENU_DIV", "MENU_DIV");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 380, "_메뉴명", "MENUNM", "MENUNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_OPEN", "CNT", "CNT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_조회", "QUERY_CNT", "QUERY_CNT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_저장", "SAVE_CNT", "SAVE_CNT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_삭제", "DELETE_CNT", "DELETE_CNT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "_처리", "PROCESS_CNT", "PROCESS_CNT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "_최종사용일시", "LAST_OPEN_TIME", "LAST_OPEN_TIME");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 060, "_정렬순서", "SORT_SEQ", "SORT_SEQ");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 060, "", "PATH", "PATH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "CNT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "QUERY_CNT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "SAVE_CNT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "DELETE_CNT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "PROCESS_CNT");
                this.grd02.Cols["CNT"].Format = "#,###,###,###,##0";
                this.grd02.Cols["QUERY_CNT"].Format = "#,###,###,###,##0";
                this.grd02.Cols["SAVE_CNT"].Format = "#,###,###,###,##0";
                this.grd02.Cols["DELETE_CNT"].Format = "#,###,###,###,##0";
                this.grd02.Cols["PROCESS_CNT"].Format = "#,###,###,###,##0";

                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;             
                this.grd02.AllowMerging = AllowMergingEnum.RestrictCols;
                this.grd02.Cols["DEPTNM"].AllowMerging = true;
                this.grd02.Cols["USERID"].AllowMerging = true;
                this.grd02.Cols["NAME_KOR"].AllowMerging = true;
                CellStyle cs = this.grd02.Styles[CellStyleEnum.Frozen];
                cs.Border.Color = Color.Gainsboro;

                DataTable source2 = this.getSystemCode();
                this.cbo01_SYSTEMCODE.DataBind(source2, false);
                this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("DIVISION", "A");
                set1.Add("SYSTEMCODE", this.UserInfo.SystemCode);
                set1.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source1 = _WSCOM2.INQUERY_CODE(set1);
                DataSet source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20005, "INQUERY_CODE"), set1);
                this.cbo01_CODE.DataBind(source1.Tables[0]);

                this.dte01_SDATE.SetValue(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"));

                //#001 기본 사번 선택으로 코드박스 설정함.
                this.rdo01_EMPNO_CheckedChanged(null, null);

                this.tabControl1_SelectedIndexChanged(null, null);

                //#004
                //this.BtnQuery_Click(null, null);
                
                _isLoadCompleted = true;
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

        #region [ 공통 버튼 클릭 이벤트 ]
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)//메뉴별 조회시 
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("PARENTID", this.cbo01_CODE.GetValue());
                    set.Add("SDATE", this.dte01_SDATE.GetDateText());
                    set.Add("EDATE", this.dte01_EDATE.GetDateText());
                    set.Add("LANG_SET", this.UserInfo.Language);

                    //#001 조회 조건 추가
                    set.Add("TYPE", gubun);
                    set.Add("SEARCH", cdx01_SEARCH.GetValue().ToString());
                    //#002 조회조건 추가
                    set.Add("EXCLUDE", chk01_EXCLUDE.Checked ? "1" : "");
                    set.Add("SYSTEMCODE", cbo01_SYSTEMCODE.GetValue());

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(set);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                    this.AfterInvokeServer();

                    this.grd01.SetValue(source);

                    ////#001 합계 처리
                    this.grd01.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
                    this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear);
                    this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, 4, this.GetLabel("TOTAL"));
                    this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, 5, this.GetLabel("TOTAL"));
                    this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, 6, this.GetLabel("TOTAL"));
                    this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, 7, this.GetLabel("TOTAL"));
                    this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, 8, this.GetLabel("TOTAL"));
                    CellStyle cs = this.grd01.Styles[CellStyleEnum.GrandTotal];
                    cs.Clear();
                    //cs.BackColor = Color.White; 
                    cs.ForeColor = Color.Red;
                    cs.Font = new Font(Font, FontStyle.Regular);
                    this.grd01.Rows.Frozen = 1;
                    this.grd01.SetValue(1, 1, "[" + this.GetLabel("TOTAL") + "]");
                }
                else//사용자별 조회시
                {
                    if (this.cbo01_CODE.GetValue().ToString().Equals(string.Empty))
                    {
                        //MsgBox.Show("대메뉴를 반드시 선택하여 주세요.");
                        MsgCodeBox.Show("XM00-0107");
                        this.cbo01_CODE.Focus();
                        return ;
                    }

                    //#003
                    HEParameterSet set = new HEParameterSet();
                    set.Add("PARENTID", this.cbo01_CODE.GetValue());
                    set.Add("SDATE", this.dte01_SDATE.GetDateText());
                    set.Add("EDATE", this.dte01_EDATE.GetDateText());
                    set.Add("LANG_SET", this.UserInfo.Language);

                    //#001 조회 조건 추가
                    if (rdo01_XM30303_RDO_1.Checked)
                    {
                        set.Add("TYPE", "USER_EMP");
                    }
                    else
                    { 
                        set.Add("TYPE", "USER_LINE"); 
                    }

                    set.Add("SEARCH", cdx01_SEARCH.GetValue().ToString());
                    //#002 조회조건 추가
                    set.Add("EXCLUDE", chk01_EXCLUDE.Checked ? "1" : "");

                    set.Add("SYSTEMCODE", cbo01_SYSTEMCODE.GetValue());
                    set.Add("SUB_PARENTID", this.cbo01_SUBCODE.GetValue());

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(set);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                    this.AfterInvokeServer();

                    this.grd02.SetValue(source);

                    //#001 합계 처리
                    this.grd02.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.AboveData;
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear);
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, this.grd02.Cols["CNT"].Index, this.GetLabel("TOTAL"));
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, this.grd02.Cols["QUERY_CNT"].Index, this.GetLabel("TOTAL"));
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, this.grd02.Cols["SAVE_CNT"].Index, this.GetLabel("TOTAL"));
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, this.grd02.Cols["DELETE_CNT"].Index, this.GetLabel("TOTAL"));
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, this.grd02.Cols["PROCESS_CNT"].Index, this.GetLabel("TOTAL"));
                    //소계처리
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, this.grd02.Cols["DEPTNM"].Index, this.grd02.Cols["CNT"].Index, this.GetLabel("TOTAL"));
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, this.grd02.Cols["DEPTNM"].Index, this.grd02.Cols["QUERY_CNT"].Index, this.GetLabel("TOTAL"));
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, this.grd02.Cols["DEPTNM"].Index, this.grd02.Cols["SAVE_CNT"].Index, this.GetLabel("TOTAL"));
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, this.grd02.Cols["DEPTNM"].Index, this.grd02.Cols["DELETE_CNT"].Index, this.GetLabel("TOTAL"));
                    this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, this.grd02.Cols["DEPTNM"].Index, this.grd02.Cols["PROCESS_CNT"].Index, this.GetLabel("TOTAL"));
                    
                    //합계스타일
                    CellStyle cs = this.grd02.Styles[CellStyleEnum.GrandTotal];
                    cs.Clear();
                    //cs.BackColor = Color.White; 
                    cs.ForeColor = Color.Red;
                    cs.Font = new Font(Font, FontStyle.Regular);
                    //소계스타일
                    cs = this.grd02.Styles[CellStyleEnum.Subtotal0];
                    cs.Clear();
                    cs.BackColor = Color.FromArgb(208, 253, 248);
                    cs.ForeColor = Color.Black;
                    cs.Font = new Font(Font, FontStyle.Regular);
                   
                    //합계ROW에 [합계]라고 표시함.
                    if (source.Tables[0].Rows.Count > 0)
                    {
                        this.grd02.Rows.Frozen = 1;
                        this.grd02.SetValue(1, 1, "[" + this.GetLabel("TOTAL") + "]");
                    }

                    //소계ROW에 어느소속의 소계인지 표시
                    for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                    {
                        if (this.grd02.Rows[i].StyleNew.Name != null && this.grd02.Rows[i].StyleNew.Name.Equals("Subtotal0"))
                        {
                            this.grd02.SetValue(i, this.grd02.Cols["DEPTNM"].Index, "[" + this.grd02.GetValue(i + 1, "DEPTNM").ToString() + "] 소계");
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
        
        #region [ 사용자 정의 메서드 ]

        //시스템코드 콤보상자용 데이터 조회
        private DataTable getSystemCode()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20001, "INQUERY_SYSTEMCODE"), set);

                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        #endregion

        #region [ 기타 컨트롤 이벤트 ]

        //#001 - 사번 선택시
        private void rdo01_EMPNO_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.cdx01_SEARCH.Initialize();

                this.cdx01_SEARCH.HEPopupHelper = new XM30303P1();
                this.cdx01_SEARCH.PopupTitle = this.GetLabel("XM30303_POP_1");//"사번검색";
                this.cdx01_SEARCH.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_SEARCH.CodeParameterName = "XM30303P1_EMP";
                this.cdx01_SEARCH.NameParameterName = "XM30303P1_EMPNM";
                this.cdx01_SEARCH.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_SEARCH.HEUserParameterSetValue("TYPE", "EMPNO");
                this.cdx01_SEARCH.HEPopupHelper.Initialize_Helper(this.cdx01_SEARCH);

                gubun = "EMPNO";
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //#001 - 파트 선택시
        private void rdo01_PARTNO_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.cdx01_SEARCH.Initialize();
                
                this.cdx01_SEARCH.HEPopupHelper = new XM30303P1();
                this.cdx01_SEARCH.PopupTitle = this.GetLabel("XM30303_POP_3"); //"부서검색";
                this.cdx01_SEARCH.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_SEARCH.CodeParameterName = "XM30303P1_LINE";
                this.cdx01_SEARCH.NameParameterName = "XM30303P1_LINENM";
                this.cdx01_SEARCH.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_SEARCH.HEUserParameterSetValue("TYPE", "LINE");
                this.cdx01_SEARCH.HEPopupHelper.Initialize_Helper(this.cdx01_SEARCH);
                gubun = "LINE";
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //#002 - 미사용 제외 선택시  : 이미 조회된 데이터 중에서 OPEN, 조회, 저장, 삭제, 처리 건수가 모두 0인 데이터 UNVISIBLE 처리함.
        private void chk01_EXCLUDE_CheckedChanged(object sender, EventArgs e)
        {
            if (chk01_EXCLUDE.Checked)
            {
                for (int i = grd01.Rows.Fixed + grd01.Rows.Frozen; i < grd01.Rows.Count; i++)
                {

                    if (this.grd01.GetValue(i, "CNT").ToString().Equals("0") &&
                        this.grd01.GetValue(i, "QUERY_CNT").ToString().Equals("0") &&
                        this.grd01.GetValue(i, "SAVE_CNT").ToString().Equals("0") &&
                        this.grd01.GetValue(i, "DELETE_CNT").ToString().Equals("0") &&
                        this.grd01.GetValue(i, "PROCESS_CNT").ToString().Equals("0") &&
                        this.grd01.GetValue(i,"MENU_DIV").ToString().Equals("UI"))
                    {
                        this.grd01.Rows[i].Visible = false;
                    }
                }
            }
            else
            {
                for (int i = grd01.Rows.Fixed + grd01.Rows.Frozen; i < grd01.Rows.Count; i++)
                {
                    grd01.Rows[i].Visible = true;
                }
            }
        }

        //#003 : 사용자별 조회시 사번/부서 조회 조건 표시 안함.
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.cbo01_SUBCODE.Visible = false;
            }
            else
            {
                this.cbo01_SUBCODE.Visible = true;
            }
        }

        //시스템 코드 선택시 하위 모듈 목록 바인딩
        private void cbo01_SYSTEMCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoadCompleted)
                return;
            try
            {
                HEParameterSet set1 = new HEParameterSet();
                set1.Add("DIVISION", "A");
                set1.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set1.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source1 = _WSCOM.INQUERY_CODE(set1);
                DataSet source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20005, "INQUERY_CODE"), set1);
                this.cbo01_CODE.DataBind(source1.Tables[0]);

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

        //모듈 선택시 하위 중메뉴 목록 바인딩
        private void cbo01_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoadCompleted)
                return;
            try
            {
                HEParameterSet set1 = new HEParameterSet();
                set1.Add("DIVISION", "A2");
                set1.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set1.Add("MENUID", this.cbo01_CODE.GetValue());
                set1.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source1 = _WSCOM.INQUERY_CODE(set1);
                DataSet source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20005, "INQUERY_CODE"), set1);
                this.cbo01_SUBCODE.DataBind(source1.Tables[0], true);

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

    }
}
