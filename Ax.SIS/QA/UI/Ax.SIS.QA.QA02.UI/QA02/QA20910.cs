#region ▶ Description & History
/* 
 * 프로그램명 : QA20910 직거래부품 분리 단가정보
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2016-12-13      이재한      신규생성
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using System.IO;
using HE.Framework.ServiceModel;
using System.Drawing;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>직거래부품 분리 단가정보</b>
    /// - 작 성 자 : 이재한<br />
    /// - 작 성 일 : 2016-12-13 오후 4:59:51<br />
    /// </summary>
    public partial class QA20910 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA20910";
        private bool _isLoadCompleted = false;
        private bool _calendarDroppedDown = false;
        
        public QA20910()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }
        
        #region [ 초기화 작업 정의 ]

        /// <summary>
        /// [ 화면 초기 설정 ]
        /// </summary>
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region [ 코드 데이터 호출 ]

                #endregion

                #region [ 직거래 부품단가 TAB 설정 ]

                #region [ 직거래 부품단가 그리드 설정 ]

                // 그리드 설정
                this.grd01.AllowEditing = true;
                this.grd01.Initialize(1, 1);

                //this.grd01.Initialize();
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "품번", "PARTNO", "PARTNO3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "품명", "PARTNM", "PARTNONM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "직전단가", "EVE_UCOST", "EVE_UCOST");
                //this.grd01.AddColumn(false, true, HEFlexGrid.FtextAlign.R, 100, "단가", "UCOST", "CUST_VENDCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "당월단가", "UCOST", "MONTH_UCOST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "차종", "VINNM", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 200, "업체", "VENDNM", "VEND");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "등록사번", "MOD_EMPNO", "REG_EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "등록일시", "MOD_DATE", "REG_DATETIME");

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("YEAR");
                this.grd01.AddHiddenColumn("MONTH");

                #region [ 그리드내 포멧 설정 ]

                // 그리드내 포멧 설정
                //this.grd01.Cols["MOD_DATE"].Format = "yyyy-MM-dd";
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.Date, "MOD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "EVE_UCOST");
                this.grd01.Cols["EVE_UCOST"].Format = "###,###,###,###";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "UCOST");
                this.grd01.Cols["UCOST"].Format = "###,###,###,###";
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.Check, "USE_YN");

                // 그리드내 콤보데이터 설정
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.ComboBox, dsWORK_DIV_BASE.Tables[0], "MAPPINGCD");

                #endregion

                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
                //this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
                this.grd01.AllowSorting = AllowSortingEnum.SingleColumn;
                //this.grd01.AllowSorting = AllowSortingEnum.None;    // 등록화면에는 정렬시 순번의 상태값이 움직이지 않는 버그로 인해 정렬 비활성화
                this.grd01.InitializeDataSource();
                //this.grd01.Cols["GA_DESTINY_NM"].StyleDisplay.WordWrap = true;
                //this.grd01.Rows[0].Height = 35; //헤더 높이 재 설정
                //this.grd01.AddConextMenuSetting();  // 전체 행 삭제 및 전체 행 취소 툴팁 추가
                //this.grd01.Cols.Frozen = 1;

                // 그리드 행추가 행삭제 안되게 설정
                this.grd01.CurrentContextMenu.Items[0].Visible = false;   // 행추가
                this.grd01.CurrentContextMenu.Items[1].Visible = false;   // 행삭제
                //this.grd01.CurrentContextMenu.Items[2].Visible = false;   // 행취소
                //this.grd01.CurrentContextMenu.Items[3].Visible = false;   // 구분선

                #endregion

                // 품번 팝업
                this.cdx01_PARTNO.HEPopupHelper = new QA20910P1();
                this.cdx01_PARTNO.PopupTitle = this.GetLabel("QA20910P1");
                this.cdx01_PARTNO.CodeParameterName = "PARTNO";
                this.cdx01_PARTNO.NameParameterName = "PARTNM";
                this.cdx01_PARTNO.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_PARTNO.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_PARTNO.CodeTextBoxWidth = 50;

                // 초기화
                Reset_01(null, null);

                #endregion

                #region [ 기타 설정 ]

                // 필수입력 항목 표시
                //this.SetRequired(lbl01_VENDCD, lbl11_PARTNO);

                // 버튼 초기화
                tab01_SelectedIndexChanged(null, null);

                // 기본 조회
                this.BtnQuery_Click(null, null);
                //_isbinding = false;

                _isLoadCompleted = true;

                #endregion
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 조회 버튼 Click 이벤트 ]
        /// </summary>
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                Query_01(sender, e);
            }
        }

        /// <summary>
        /// [ 초기화 버튼 Click 이벤트트 ]
        /// </summary>
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                Reset_01(sender, e);
            }
        }

        /// <summary>
        /// [ 저장 버튼 Click 이벤트트 ]
        /// </summary>
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                Save_01(sender, e);
            }
        }

        #endregion

        #region [ 사용자 정의 method -공통- ]

        /// <summary>
        /// [ 그리드 및 바인딩 데이터 초기화 ]
        /// </summary>
        private void Reset_Grid_BindingData(int v_Tabindex)
        {
            if (v_Tabindex == 0)
            {
                this.grd01.InitializeDataSource();
            }
        }

        #region [ 체크 함수 ]

        /// <summary>
        /// [ 그리드내 데이터 찾아가기 ]
        /// </summary>
        private void Find_DATA_ROW(object sender, string find_data1, string find_data2, string find_data3, string find_data4, string find_data5)
        {
            //루핑 돌면서 해당 데이터의 행번호를 rowidx에 담아둔다.
            AxFlexGrid grd = (AxFlexGrid)sender;
            int rowidx = grd.Rows.Fixed;

            if (grd.Rows.Count - grd.Rows.Fixed > 0)
            {
                if (sender.Equals(grd01))
                {
                    for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                    {
                        if (find_data1 == grd.GetValue(i, "PARTNO").ToString())
                        {
                            rowidx = i;
                        }
                    }
                }
                //해당 데이터의 행번호를 select
                //grd.Rows[rowidx].Selected = true;
                grd.Row = rowidx;
            }
        }

        #endregion

        #endregion

        #region [ TAB 별 이벤트 설정 ]

        #region [ 직거래 부품단가 TAB ]

        #region [ 그리드 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 그리드에서 행취소 클릭시 발생되는 이벤트 ]
        /// </summary>
        private void grd01_RowCanceled(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                //이 이벤트는 수정, 삭제에만 일어나야함.
                for (int i = 0; i < args.RowCount; i++)
                {
                    //행취소시 배경색 초기화
                    if (args.RowIndex + i <= grd.Rows.Count - grd.Rows.Fixed)
                    {
                        if (grd[args.RowIndex + i, 0].ToString() != "N")
                        {
                            grd.Rows[args.RowIndex + i].StyleNew.Clear();
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 텝 선택에 따른 버튼 ENABLE SETTING ]
        /// </summary>
        private void tab01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                this.GetCommonButton(COMMONBUTTONTYPE.QUERY).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.RESET).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.SAVE).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.DELETE).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.PROCESS).Enabled = false;
                this.GetCommonButton(COMMONBUTTONTYPE.DOWNLOAD).Enabled = true;

                if (_isLoadCompleted)
                {
                    // 데이터 조회
                    this.BtnQuery_Click(null, null);
                }
            }
        }

        /// <summary>
        /// [ 텝 선택에 따른 이전 TAB MOVE ]
        /// </summary>
        private void tab01_main_Selecting(object sender, TabControlCancelEventArgs e)
        {
            /*if (e.TabPageIndex == 4)
            {
                MsgBox.Show("개발중입니다.");
                e.Cancel = true;
            }*/
        }

        /// <summary>
        /// [ 조회 코드박스 값 변경시 ]
        /// </summary>
        private void cdx01_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted)
            {
                // 그리드 및 바인딩 데이터 초기화
                Reset_Grid_BindingData(tab01_main.SelectedIndex);
            }
        }

        /// <summary>
        /// [ 조회 코드박스 사원정보 있으면 자동조회 ]
        /// </summary>
        private void cdx01_ButtonClickAfter(object sender, EventArgs args)
        {
            AxCodeBox cdx = (AxCodeBox)sender;
            string value = cdx.GetValue().ToString();
            //DataRow DR = (DataRow)cdx.HEPopupHelper.SelectedValue;    // 팝업창에서 선택된 값
            DataRow DR = cdx.SelectedPopupValue;
            if (_isLoadCompleted)
            {
                if (DR != null && value.Length > 0)
                {
                    // 조회
                    this.BtnQuery_Click(null, null);
                }
            }
        }

        /// <summary>
        /// [ 조회 라디오박스 값 변경시 ]
        /// </summary>
        private void rdo01_CheckedChanged(object sender, EventArgs e)
        {
            AxRadioButton rdo = (AxRadioButton)sender;
            string value = rdo.GetValue().ToString();

            if (sender.Equals(rdo01_ALL) || sender.Equals(rdo01_EXIST) || sender.Equals(rdo01_NOT_EXIST))
            {
                if (_isLoadCompleted)
                {
                    // 조회
                    this.BtnQuery_Click(null, null);
                }
            }
        }

        /// <summary>
        /// [ 조회 카렌더박스 값 변경시 ]
        /// </summary>
        private void dte01_ValueChanged(object sender, EventArgs e)
        {
            AxDateEdit dte = (AxDateEdit)sender;
            string value = dte.GetDateText().Substring(0, 7);
            if (value.Length == 7) value = value + "-01";

            // 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가
            if (_calendarDroppedDown) return;

            if (_isLoadCompleted)
            {
                // 그리드 및 바인딩 데이터 초기화
                Reset_Grid_BindingData(tab01_main.SelectedIndex);
            }
        }

        /// <summary>
        /// [ 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가 ]
        /// </summary>
        private void dte01_DropDown(object sender, EventArgs e)
        {
            _calendarDroppedDown = true;
        }

        /// <summary>
        /// [ 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가 ]
        /// </summary>
        private void dte01_CloseUp(object sender, EventArgs e)
        {
            _calendarDroppedDown = false;

            dte01_ValueChanged(sender, e);
        }

        /// <summary>
        /// 버튼 클릭시
        /// </summary>
        private void btn01_Click(object sender, EventArgs e)
        {
            AxButton btn = (AxButton)sender;
            if (sender.Equals(btn01_LASTMONTH_BASE_SAVE))
            {
                // 전월기준 단가데이터 등록 처리
                Process_01(sender, e);
                //MsgBox.Show("개발중입니다.");
            }
        }

        #endregion

        #region [ 사용자 정의 method ]

        /// <summary>
        /// [ TAB1 조회 함수 ]
        /// </summary>
        private void Query_01(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                paramSet.Add("YYYYMM", this.dte01_YYYYMM.GetDateText().Substring(0, 7).Replace("-", ""));
                paramSet.Add("PARTNO", this.cdx01_PARTNO.GetValue().ToString());
                // 단가유무 값 선택
                var v_UCOST_YN = "";
                if (this.rdo01_NOT_EXIST.Checked)
                {
                    v_UCOST_YN = "N";
                }
                else if (this.rdo01_EXIST.Checked)
                {
                    v_UCOST_YN = "Y";
                }
                paramSet.Add("UCOST_YN", v_UCOST_YN);

                if (!IsQueryValid_01(paramSet)) return;

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA4212"), paramSet);
                this.grd01.SetValue(source.Tables[0]);

                /*if (source.Tables[0].Rows.Count > 0)
                {
                    for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    {
                        // 협력사 팝업 버튼
                        this.grd01.SetCellStyle(i, this.grd01.Cols["BTN_VENDCD"].Index, this.grd01.Styles["btnpopup"]);
                    }
                }*/
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

        /// <summary>
        /// [ TAB1 조회 유효성 체크 함수 ]
        /// </summary>
        private bool IsQueryValid_01(HEParameterSet paramSet)
        {
            try
            {
                // 조회연월 체크
                if (paramSet["YYYYMM"].ToString().Length == 0)
                {
                    MsgCodeBox.Show("CD00-0111");
                    //MsgBox.Show("조회연월을 입력하세요.");
                    this.dte01_YYYYMM.Focus();
                    return false;
                }
                // 협력사 체크
                /*if (paramSet["VENDCD"].ToString().Length == 0)
                {
                    //MsgCodeBox.Show("HR06-0017");
                    MsgBox.Show("작업구분을 입력하세요.");
                    this.txt01_VENDCD.Focus();
                    return false;
                }*/

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        /// <summary>
        /// [ TAB1 초기화 함수 ]
        /// </summary>
        private void Reset_01(object sender, EventArgs e)
        {
            try
            {
                //this.BeforeInvokeServer();
                //this.dte01_YYYYMM.Initialize();
                this.dte01_YYYYMM.SetValue(DateTime.Today.AddMonths(-2).ToShortDateString());
                this.cdx01_PARTNO.Initialize();

                this.grd01.InitializeDataSource();
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

        /// <summary>
        /// [ TAB1 저장 함수 ]
        /// </summary>
        private void Save_01(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(
                      AxFlexGrid.FActionType.Save
                    , "CORCD"
                    , "REG_EMPNO"
                    , "YEAR"
                    , "MONTH"
                    , "PARTNO"
                    , "UCOST"
                );
                //source.Tables[0].Columns["HR_EMPNO"].ColumnName = "EMPNO";
                string r_YEAR = "";
                string r_MONTH = "";
                string r_PARTNO = "";

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["REG_EMPNO"] = this.UserInfo.EmpNo;

                    if (r_YEAR.Length == 0 || r_MONTH.Length == 0 || r_PARTNO.Length == 0)
                    {
                        r_YEAR = dr["YEAR"].ToString();
                        r_MONTH = dr["MONTH"].ToString();
                        r_PARTNO = dr["PARTNO"].ToString();
                    }
                }
                //source.Tables[0].Columns.Remove("OBJECT_ID");

                if (!IsSaveValid_01(this.grd01, source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA4212"), source);
                this.AfterInvokeServer();

                // 조회
                BtnQuery_Click(null, null);

                // 마지막 저장행으로 커서이동
                Find_DATA_ROW(this.grd01, r_YEAR, r_MONTH, r_PARTNO, "", "");

                //#001
                //MsgBox.Show("정상적으로 저장되었습니다.");
                MsgCodeBox.Show("CD00-0009");
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

        /// <summary>
        /// [ TAB1 저장 체크 함수 ]
        /// </summary>
        private bool IsSaveValid_01(object sender, DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //#001
                    //MsgBox.Show("저장할 데이터가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                AxFlexGrid grd = (AxFlexGrid)sender;

                //souce라는 DataSet에는 테이블이 2개 있음
                //[0]번째 테이블은 그리드에서 추출한 데이터
                //[1]번째 테이블은 행번호 데이터
                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = source.Tables[0].Rows[i];
                    int rowIndex = Convert.ToInt32(source.Tables[1].Rows[i][0]);

                    if (this.GetByteCount(dr["CORCD"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["CORCD"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["YEAR"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["YEAR"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["MONTH"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["MONTH"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["PARTNO"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["PARTNO"].Caption);
                        return false;
                    }
                }

                //저장하시겠습니까?
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        /// <summary>
        /// [ TAB1 처리 함수 (전월기준 단가데이터 등록) ]
        /// </summary>
        private void Process_01(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("REG_EMPNO", this.UserInfo.EmpNo);

                paramSet.Add("YYYYMM", this.dte01_YYYYMM.GetDateText().Substring(0, 7).Replace("-", ""));

                if (!IsProcessValid_01(paramSet)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA4212_LAST_MONTH"), paramSet);
                this.AfterInvokeServer();

                // 조회
                BtnQuery_Click(null, null);

                // 조회
                this.BtnQuery_Click(null, null);

                //#001
                //MsgBox.Show("정상적으로 처리되었습니다.");
                MsgCodeBox.Show("CD00-0013");
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

        /// <summary>
        /// [ TAB1 처리 (전월기준 단가데이터 등록) 체크 함수 ]
        /// </summary>
        private bool IsProcessValid_01(HEParameterSet paramSet)
        {
            try
            {
                // 조회연월 체크
                if (paramSet["YYYYMM"].ToString().Length == 0)
                {
                    MsgCodeBox.Show("CD00-0111");
                    //MsgBox.Show("조회연월을 입력하세요.");
                    this.dte01_YYYYMM.Focus();
                    return false;
                }

                // TAB NAME
                //var v_TAB_NAME = tab01_main.TabPages[tab01_main.SelectedIndex].Text;
                var v_TAB_NAME = this.btn01_LASTMONTH_BASE_SAVE.Text;

                // 처리 하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0112", MessageBoxButtons.OKCancel, v_TAB_NAME) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #endregion

        #endregion

    }
}
