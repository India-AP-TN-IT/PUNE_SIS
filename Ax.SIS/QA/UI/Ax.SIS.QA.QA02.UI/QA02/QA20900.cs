#region ▶ Description & History
/* 
 * 프로그램명 : QA20900 직거래부품 분리 기준정보
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2016-12-12      이재한      신규생성
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
    /// <b>직거래부품 분리 기준정보</b>
    /// - 작 성 자 : 이재한<br />
    /// - 작 성 일 : 2016-12-12 오후 4:59:51<br />
    /// </summary>
    public partial class QA20900 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA20900";
        private bool _isLoadCompleted = false;
        private Color _BtnPopupBackColor;
        private BorderStyleEnum _BtnPopupBorderStyle;
        private AxCodeBox cdx01_BTN_VENDCD = new AxCodeBox();
        
        public QA20900()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();

            _BtnPopupBackColor = Color.LightGray;
            _BtnPopupBorderStyle = BorderStyleEnum.Raised;
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

                #region [ 직거래 업체 TAB 설정 ]

                #region [ 직거래 업체 그리드 설정 ]

                // 그리드내 팝업버튼 cs 설정
                CellStyle cs = this.grd01.Styles.Add("btnpopup");
                cs.BackColor = _BtnPopupBackColor;
                cs.Border.Style = _BtnPopupBorderStyle;

                // 그리드 설정
                this.grd01.AllowEditing = true;
                this.grd01.Initialize(1, 1);

                //this.grd01.Initialize();
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "내부협력사코드", "VENDCD", "INS_VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 020, " ", "BTN_VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "내부협력사명", "VENDNM", "INS_VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "고객협력사코드", "CUST_VENDCD", "CUST_VENDCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "사용유무", "USE_YN", "USE_YN3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "등록사번", "MOD_EMPNO", "REG_EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "등록일시", "MOD_DATE", "REG_DATETIME");

                this.grd01.AddHiddenColumn("CORCD");

                #region [ 그리드내 포멧 설정 ]

                // 그리드내 포멧 설정
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "MOD_DATE");
                //this.grd01.Cols["MOD_DATE"].Format = "yyyy-MM-dd";
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.Decimal, "WORK_YEAR");
                //this.grd01.Cols["WORK_YEAR"].Format = "###,###,###,###";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");

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
                //this.grd01.CurrentContextMenu.Items[0].Visible = false;   // 행추가
                //this.grd01.CurrentContextMenu.Items[1].Visible = false;   // 행삭제
                //this.grd01.CurrentContextMenu.Items[2].Visible = false;   // 행취소
                //this.grd01.CurrentContextMenu.Items[3].Visible = false;   // 구분선

                #endregion

                // 협력사코드 팝업
                this.cdx01_VENDCD.HEPopupHelper = new QA20900P1();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("QA20900P1");
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_VENDCD.CodeTextBoxWidth = 50;

                // 협력사코드 팝업
                this.cdx01_BTN_VENDCD.HEPopupHelper = new QA20900P1();
                this.cdx01_BTN_VENDCD.PopupTitle = this.GetLabel("QA20900P1");
                this.cdx01_BTN_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_BTN_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_BTN_VENDCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_BTN_VENDCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_BTN_VENDCD.CodeTextBoxWidth = 50;
                this.cdx01_BTN_VENDCD.Name = "cdx01_BTN_VENDCD";
                this.Controls.Add(cdx01_BTN_VENDCD);

                #endregion

                #region [ 직거래 부품 TAB 설정 ]

                #region [ 직거래 부품 그리드 설정 ]

                // 그리드 설정
                this.grd11.AllowEditing = true;
                this.grd11.Initialize(1,1);

                //this.grd11.Initialize();
                this.grd11.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "품번(5자리)", "PARTNO", "PARTNO_5");
                this.grd11.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "비고", "NOTE", "NOTE");
                this.grd11.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "사용유무", "USE_YN", "USE_YN3");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "등록사번", "MOD_EMPNO", "REG_EMPNO");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "등록일시", "MOD_DATE", "REG_DATETIME");

                this.grd11.AddHiddenColumn("CORCD");

                #region [ 그리드내 포멧 설정 ]

                // 그리드내 포멧 설정
                this.grd11.SetColumnType(AxFlexGrid.FCellType.Date, "MOD_DATE");
                //this.grd11.Cols["MOD_DATE"].Format = "yyyy-MM-dd";
                //this.grd11.SetColumnType(HEFlexGrid.FCellType.Decimal, "WORK_YEAR");
                //this.grd11.Cols["WORK_YEAR"].Format = "###,###,###,###";
                this.grd11.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");

                // 그리드내 콤보데이터 설정
                //this.grd11.SetColumnType(HEFlexGrid.FCellType.ComboBox, dsWORK_DIV_BASE.Tables[0], "MAPPINGCD");

                #endregion

                this.grd11.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
                //this.grd11.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grd11.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
                this.grd11.AllowSorting = AllowSortingEnum.SingleColumn;
                //this.grd11.AllowSorting = AllowSortingEnum.None;    // 등록화면에는 정렬시 순번의 상태값이 움직이지 않는 버그로 인해 정렬 비활성화
                this.grd11.InitializeDataSource();
                //this.grd11.Cols["GA_DESTINY_NM"].StyleDisplay.WordWrap = true;
                //this.grd11.Rows[0].Height = 35; //헤더 높이 재 설정
                //this.grd11.AddConextMenuSetting();  // 전체 행 삭제 및 전체 행 취소 툴팁 추가
                //this.grd11.Cols.Frozen = 1;

                // 그리드 행추가 행삭제 안되게 설정
                //this.grd11.CurrentContextMenu.Items[0].Visible = false;   // 행추가
                //this.grd11.CurrentContextMenu.Items[1].Visible = false;   // 행삭제
                //this.grd11.CurrentContextMenu.Items[2].Visible = false;   // 행취소
                //this.grd11.CurrentContextMenu.Items[3].Visible = false;   // 구분선

                #endregion

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
            else if (tab01_main.SelectedIndex == 1)
            {
                Query_11(sender, e);
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
            else if (tab01_main.SelectedIndex == 1)
            {
                Reset_11(sender, e);
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
            else if (tab01_main.SelectedIndex == 1)
            {
                Save_11(sender, e);
            }
        }

        /// <summary>
        /// [ 삭제 버튼 Click 이벤트트 ]
        /// </summary>
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                Delete_01(sender, e);
            }
            else if (tab01_main.SelectedIndex == 1)
            {
                Delete_11(sender, e);
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
            else if (v_Tabindex == 1)
            {
                this.grd11.InitializeDataSource();
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
                        if (find_data1 == grd.GetValue(i, "VENDCD").ToString())
                        {
                            rowidx = i;
                        }
                    }
                }
                else if (sender.Equals(grd11))
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

        /// <summary>
        /// [ 중복 체크 ]
        /// </summary>
        private bool Check_Grid_SameRow(object sender, int v_Tabindex, int chk_rowIndex, string chk_cancle_data)
        {
            AxFlexGrid grd = (AxFlexGrid)sender;
            if (v_Tabindex == 0)
            {
                int head_cnt = grd.Rows.Fixed;
                string v_stand_data1 = "";
                //string v_stand_data2 = "";

                if (grd.Cols[grd.Col].Name.Equals("VENDCD") && chk_cancle_data.Equals("Y"))
                {
                    v_stand_data1 = grd.Editor.Text;
                    //v_stand_data2 = grd.GetValue(chk_rowIndex, "VENDNM").ToString();
                }
                /*else if (grd.Cols[grd.Col].Name.Equals("VENDNM") && chk_cancle_data.Equals("Y"))
                {
                    v_stand_data1 = grd.GetValue(chk_rowIndex, "VENDCD").ToString();
                    v_stand_data2 = grd.Editor.Text;
                    // 코드정보시 적용
                    //v_stand_data2 = grd.Editor.Text.Substring(0, 2);
                    //DataRow[] dr = dsBiz.Tables[0].Select("TYPENM = '" + grd.Editor.Text + "'");
                    //if (dr.Length > 0)
                    //{
                    //    v_stand_data2 = dr[0]["TYPECD"].ToString();
                    //}
                }*/
                else if (!chk_cancle_data.Equals("Y"))
                {
                    v_stand_data1 = grd.GetValue(chk_rowIndex, "VENDCD").ToString();
                    //v_stand_data2 = grd.GetValue(chk_rowIndex, "VENDNM").ToString();
                }
                string v_stand_data = v_stand_data1/* + v_stand_data2*/;

                for (int i = head_cnt; i < grd.Rows.Count; i++)
                {
                    string v_chk_data = grd.GetValue(i, "VENDCD").ToString()/* + grd.GetValue(i, "VENDNM").ToString()*/;
                    if (v_chk_data.Equals(v_stand_data) && i != chk_rowIndex)
                    {
                        //{0} 번째 행에서 {1} 번째 행과 중복된 데이터가 존재합니다. 확인하여 변경 하십시요.
                        MsgCodeBox.ShowFormat("CD00-0109", (chk_rowIndex).ToString(), (i).ToString());
                        if (chk_cancle_data.Equals("Y"))
                        {
                            grd.FinishEditing(true);
                        }
                        return false;
                    }
                }
            }
            else if (v_Tabindex == 1)
            {
                int head_cnt = grd.Rows.Fixed;
                string v_stand_data1 = "";

                if (grd.Cols[grd.Col].Name.Equals("PARTNO") && chk_cancle_data.Equals("Y"))
                {
                    v_stand_data1 = grd.Editor.Text;
                }
                else if (!chk_cancle_data.Equals("Y"))
                {
                    v_stand_data1 = grd.GetValue(chk_rowIndex, "PARTNO").ToString();
                }
                string v_stand_data = v_stand_data1/* + v_stand_data2*/;

                for (int i = head_cnt; i < grd.Rows.Count; i++)
                {
                    string v_chk_data = grd.GetValue(i, "PARTNO").ToString();
                    if (v_chk_data.Equals(v_stand_data) && i != chk_rowIndex)
                    {
                        //{0} 번째 행에서 {1} 번째 행과 중복된 데이터가 존재합니다. 확인하여 변경 하십시요.
                        MsgCodeBox.ShowFormat("CD00-0109", (chk_rowIndex).ToString(), (i).ToString());
                        if (chk_cancle_data.Equals("Y"))
                        {
                            grd.FinishEditing(true);
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #endregion

        #region [ TAB 별 이벤트 설정 ]

        #region [ 직거래 업체 TAB ]

        #region [ 그리드 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 그리드에 신규행 추가시 발생되는 이벤트 ]
        /// </summary>
        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                for (int i = 0; i < args.RowCount; i++)
                {
                    if (sender.Equals(grd01))
                    {
                        //신규행 추가시 기본 값 설정
                        grd.SetValue(args.RowIndex + i, grd.Cols["VENDCD"].Index, "");
                        grd.SetValue(args.RowIndex + i, grd.Cols["VENDNM"].Index, "");
                        grd.SetValue(args.RowIndex + i, grd.Cols["USE_YN"].Index, "1");

                        //신규행 배경색 설정
                        //for (int i = 0; i < grd.Cols.Count; i++)
                        //{
                        grd.Rows[args.RowIndex + i].StyleNew.BackColor = Color.Bisque;
                        //}

                        grd.SetCellStyle(args.RowIndex + i, grd.Cols["BTN_VENDCD"].Index, grd.Styles["btnpopup"]);
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 그리드에 신규행 추가시 유효성 체크 이벤트 ]
        /// </summary>
        private void grd01_RowInserting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    // 법인코드 유무 체크
                    /*if (this.cbo01_CORCD.GetValue().ToString().Length == 0)
                    {
                        // 법인코드를 입력하세요
                        MsgCodeBox.Show("PM00-0076");
                        this.cbo01_CORCD.Focus();
                        args.Cancel = true;
                    }
                    else
                    {
                        args.Cancel = false;
                    }*/
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 그리드에서 행삭제 클릭시 발생되는 이벤트 ]
        /// </summary>
        private void grd01_RowDeleted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                for (int i = 0; i < args.RowCount; i++)
                {
                    //행삭제시 배경색 설정
                    //for (int i = 0; i < grd.Cols.Count; i++)
                    //{
                    //grd.SetCellStyle(args.RowIndex, i, "csDelete");
                    if (grd[args.RowIndex + i, 0].ToString() == "D")
                    {
                        grd.Rows[args.RowIndex + i].StyleNew.BackColor = Color.LightPink;
                    }
                    //}
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

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

        /// <summary>
        /// [ 에디트 (활성화) 전 이벤트 ]
        /// </summary>
        private void grd01_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    // 키값 수정 불가
                    if (e.Col == grd.Cols["VENDCD"].Index)
                    {
                        if (grd.GetValue(e.Row, 0).ToString().Equals("N"))
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
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

        /// <summary>
        /// [ 에디트 후 이벤트 ]
        /// </summary>
        private void grd01_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    int v_row = grd.SelectedRowIndex;
                    // 정보 초기화
                    if (e.Col == grd.Cols["VENDCD"].Index && grd.GetValue(v_row, e.Col).ToString().Length < 4)
                    {
                        grd.SetValue(v_row, grd.Cols[e.Col].Name.Substring(0, grd.Cols[e.Col].Name.Length - 2) + "NM", "");

                        if (grd[v_row, 0].ToString() != "N" && grd[v_row, 0].ToString() != "D")
                        {
                            grd.SetValue(v_row, 0, "U");
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

        /// <summary>
        /// [ 에디트 내용이 그리드에 바인딩 되기전 체크 이벤트 ]
        /// </summary>
        private void grd01_ValidateEdit(object sender, ValidateEditEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    if (e.Col == grd.Cols["VENDCD"].Index)
                    {
                        if (grd.Editor.Text.Length > 0)
                        {
                            // 키값 수정 후 중복체크
                            int v_row = grd.SelectedRowIndex;
                            if (!Check_Grid_SameRow(sender, tab01_main.SelectedIndex, v_row, "Y")) return;
                            // 명칭 셋팅
                            if (e.Col == grd.Cols["VENDCD"].Index && grd.Editor.Text.Length >= 4)
                            {
                                string[,] arr_emp = new string[2, 1];
                                arr_emp[0, 0] = grd.Cols[e.Col].Name;    // 코드
                                arr_emp[1, 0] = grd.Cols[e.Col].Name.Substring(0, grd.Cols[e.Col].Name.Length - 2) + "NM"; // 명
                                GrdPopup_Search(sender, arr_emp, false);
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
        }

        /// <summary>
        /// [ 그리드 에디터 설정 이벤트 ]
        /// </summary>
        private void grd01_SetupEditor(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (e.Row < grd.Rows.Fixed || e.Col < grd.Cols.Fixed)
                    return;

                if (sender.Equals(grd01))
                {
                    //콤보 상자 초기화 될때 불필요한 항목은 제거
                    /*if (e.Col == grd.Cols["MAPPINGCD"].Index)
                    {
                        ComboBox cbo = grd.Editor as ComboBox;
                        cbo.Items.RemoveAt(0);
                    }*/
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 어떠한 이유로 U코드로 변경되지 않아 강제 변경시킴 ]
        /// </summary>
        private void grd01_CellChecked(object sender, RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    if (grd[e.Row, 0].ToString() != "N" && grd[e.Row, 0].ToString() != "D")
                    {
                        grd.SetValue(e.Row, 0, "U");
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 그리드 마우스 오버 이벤트 ]
        /// </summary>
        private void grd01_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    if (grd.MouseRow >= grd.Rows.Fixed && grd.MouseRow < grd.Rows.Count)
                    {
                        if (grd.MouseCol >= grd.Cols.Fixed && grd.MouseCol < grd.Cols.Count)
                        {
                            if (grd.Cols.Count > 0 && grd.GetValue(grd.MouseRow, 0).Equals("N") && grd.Cols[grd.MouseCol].Name.Equals("BTN_VENDCD"))
                            {
                                this.Cursor = Cursors.Hand;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 그리드 마우스 클릭 이벤트 ]
        /// </summary>
        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    if (grd.MouseRow >= grd.Rows.Fixed && grd.GetValue(grd.MouseRow, 0).Equals("N") && grd.Col == grd.Cols["BTN_VENDCD"].Index)
                    {
                        string[,] arr_emp = new string[2, 1];
                        arr_emp[0, 0] = grd.Cols[grd.Col].Name.Substring(4);    // 코드
                        arr_emp[1, 0] = grd.Cols[grd.Col].Name.Substring(4, grd.Cols[grd.Col].Name.Length - 6) + "NM";   // 명
                        GrdPopup_Search(sender, arr_emp, true);
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 그리드 팝업 호출 ]
        /// </summary>
        private void GrdPopup_Search(object sender, string[,] arr_emp, bool popup_open)
        {
            AxFlexGrid grd = (AxFlexGrid)sender;
            if (sender.Equals(grd01))
            {
                var cdx_name = "cdx"+grd.Name.Substring(3,2)+"_BTN_";
                AxCodeBox cdx = (AxCodeBox)this.Controls[cdx_name + arr_emp[0, 0]];

                int row = grd.SelectedRowIndex;
                cdx.HEPopupHelper.Initialize_Helper(cdx);
                if (popup_open)
                {
                    cdx.SetValue(grd.GetValue(row, arr_emp[0, 0]));
                    PopupHelper helper = new PopupHelper((Ax.DEV.Utility.Library.AxCommonPopupControl)cdx.HEPopupHelper, cdx.PopupTitle);
                    helper.ShowDialog();
                    object data = helper.SelectedValue;

                    if (data != null)
                    {
                        DataRow selectedPopupValue = (DataRow)data;
                        grd.SetValue(row, arr_emp[0, 0], selectedPopupValue["VENDCD"]);
                        grd.SetValue(row, arr_emp[1, 0], selectedPopupValue["VENDNM"]);

                        // 키값 수정 후 중복체크
                        int v_row = grd.SelectedRowIndex;
                        if (!Check_Grid_SameRow(sender, tab01_main.SelectedIndex, v_row, "N"))
                        {
                            grd.SetValue(row, arr_emp[0, 0], "");
                            grd.SetValue(row, arr_emp[1, 0], "");
                        }

                        if (grd[row, 0].ToString() != "N" && grd[row, 0].ToString() != "D")
                        {
                            grd.SetValue(row, 0, "U");
                        }
                    }
                }
                else
                {
                    HEParameterSet set = new HEParameterSet();

                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("LANG_SET", this.UserInfo.Language);
                    set.Add("VENDCD", grd.Editor.Text);

                    DataTable dt = cdx.HEPopupHelper.GetDataSource(set);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow selectedPopupValue = dt.Rows[0];
                        grd.SetValue(row, arr_emp[0, 0], selectedPopupValue["VENDCD"]);
                        grd.SetValue(row, arr_emp[1, 0], selectedPopupValue["VENDNM"]);
                    }
                    else
                    {
                        grd.SetValue(row, arr_emp[1, 0], "");
                    }
                }
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 텝 선택에 따른 버튼 ENABLE SETTING ]
        /// </summary>
        private void tab01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0 || tab01_main.SelectedIndex == 1)
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

                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue().ToString());
                paramSet.Add("CUST_VENDCD", this.txt01_CUST_VENDCD.GetValue().ToString());

                if (!IsQueryValid_01(paramSet)) return;

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA4210"), paramSet);
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
                this.cdx01_VENDCD.Initialize();
                this.txt01_CUST_VENDCD.Initialize();

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
                    , "VENDCD"
                    , "CUST_VENDCD"
                    , "USE_YN"
                );
                //source.Tables[0].Columns["HR_EMPNO"].ColumnName = "EMPNO";
                string r_VENDCD = "";

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["REG_EMPNO"] = this.UserInfo.EmpNo;
                    // 체크박스 1 를 Y 로 변경
                    if (dr["USE_YN"].ToString() == "Y" || dr["USE_YN"].ToString() == "1")
                    {
                        dr["USE_YN"] = "Y";
                    }
                    else
                    {
                        dr["USE_YN"] = "N";
                    }

                    if (r_VENDCD.Length == 0)
                    {
                        r_VENDCD = dr["VENDCD"].ToString();
                    }
                }
                //source.Tables[0].Columns.Remove("OBJECT_ID");

                if (!IsSaveValid_01(this.grd01, source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA4210"), source);
                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                Find_DATA_ROW(this.grd01, r_VENDCD, "", "", "", "");

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

                    if (this.GetByteCount(dr["VENDCD"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["VENDCD"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["CUST_VENDCD"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["CUST_VENDCD"].Caption);
                        return false;
                    }

                    // 중복체크 항수 호출
                    if (!Check_Grid_SameRow(sender, tab01_main.SelectedIndex, rowIndex, "N"))
                    {
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
        /// [ TAB1 삭제 함수 ]
        /// </summary>
        private void Delete_01(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(
                      AxFlexGrid.FActionType.Remove
                    , "CORCD"
                    , "VENDCD"
                );
                //source.Tables[0].Columns["HR_EMPNO"].ColumnName = "EMPNO";
                string r_VENDCD = "";

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;

                    if (r_VENDCD.Length == 0)
                    {
                        r_VENDCD = dr["VENDCD"].ToString();
                    }
                }
                //source.Tables[0].Columns.Remove("CASH_TRANS");

                if (!IsDeleteValid_01(this.grd01, source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA4210"), source);
                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                Find_DATA_ROW(this.grd01, r_VENDCD, "", "", "", "");

                //#001
                //MsgBox.Show("정상적으로 삭제되었습니다.");
                MsgCodeBox.Show("CD00-0010");
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
        /// [ TAB1 삭제 체크 함수 ]
        /// </summary>
        private bool IsDeleteValid_01(object sender, DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //#001
                    //MsgBox.Show("삭제할 데이터가 존재하지 않습니다");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //#001
                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #endregion

        #region [ 직거래 부품 TAB ]

        #region [ 그리드 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 그리드에 신규행 추가시 발생되는 이벤트 ]
        /// </summary>
        private void grd11_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                for (int i = 0; i < args.RowCount; i++)
                {
                    if (sender.Equals(grd11))
                    {
                        //신규행 추가시 기본 값 설정
                        grd.SetValue(args.RowIndex + i, grd.Cols["PARTNO"].Index, "");
                        grd.SetValue(args.RowIndex + i, grd.Cols["NOTE"].Index, "");
                        grd.SetValue(args.RowIndex + i, grd.Cols["USE_YN"].Index, "1");

                        //신규행 배경색 설정
                        //for (int i = 0; i < grd.Cols.Count; i++)
                        //{
                        grd.Rows[args.RowIndex + i].StyleNew.BackColor = Color.Bisque;
                        //}
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 그리드에서 행삭제 클릭시 발생되는 이벤트 ]
        /// </summary>
        private void grd11_RowDeleted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                for (int i = 0; i < args.RowCount; i++)
                {
                    //행삭제시 배경색 설정
                    //for (int i = 0; i < grd.Cols.Count; i++)
                    //{
                    //grd.SetCellStyle(args.RowIndex, i, "csDelete");
                    if (grd[args.RowIndex + i, 0].ToString() == "D")
                    {
                        grd.Rows[args.RowIndex + i].StyleNew.BackColor = Color.LightPink;
                    }
                    //}
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 그리드에서 행취소 클릭시 발생되는 이벤트 ]
        /// </summary>
        private void grd11_RowCanceled(object sender, AxFlexGrid.FAlterEventRow args)
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

        /// <summary>
        /// [ 에디트 (활성화) 전 이벤트 ]
        /// </summary>
        private void grd11_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd11))
                {
                    // 키값 수정 불가
                    if (e.Col == grd.Cols["PARTNO"].Index)
                    {
                        if (grd.GetValue(e.Row, 0).ToString().Equals("N"))
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
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

        /// <summary>
        /// [ 에디트 내용이 그리드에 바인딩 되기전 체크 이벤트 ]
        /// </summary>
        private void grd11_ValidateEdit(object sender, ValidateEditEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd11))
                {
                    if (e.Col == grd.Cols["PARTNO"].Index)
                    {
                        if (grd.Editor.Text.Length > 0)
                        {
                            // 키값 수정 후 중복체크
                            int v_row = grd.SelectedRowIndex;
                            if (!Check_Grid_SameRow(sender, tab01_main.SelectedIndex, v_row, "Y")) return;
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

        /// <summary>
        /// [ 그리드 에디터 설정 이벤트 ]
        /// </summary>
        private void grd11_SetupEditor(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (e.Row < grd.Rows.Fixed || e.Col < grd.Cols.Fixed)
                    return;

                if (sender.Equals(grd11))
                {
                    if (e.Col == grd.Cols["PARTNO"].Index)
                    {
                        TextBox txt = (TextBox)grd.Editor;
                        txt.MaxLength = 5;
                    }
                    //콤보 상자 초기화 될때 불필요한 항목은 제거
                    /*if (e.Col == grd.Cols["MAPPINGCD"].Index)
                    {
                        ComboBox cbo = grd.Editor as ComboBox;
                        cbo.Items.RemoveAt(0);
                    }*/
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 어떠한 이유로 U코드로 변경되지 않아 강제 변경시킴 ]
        /// </summary>
        private void grd11_CellChecked(object sender, RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd11))
                {
                    if (grd[e.Row, 0].ToString() != "N" && grd[e.Row, 0].ToString() != "D")
                    {
                        grd.SetValue(e.Row, 0, "U");
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

        #endregion

        #region [ 사용자 정의 method ]

        /// <summary>
        /// [ TAB2 조회 함수 ]
        /// </summary>
        private void Query_11(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);

                paramSet.Add("PARTNO", this.txt11_PARTNO.GetValue().ToString());
                paramSet.Add("NOTE", this.txt11_NOTE.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                if (!IsQueryValid_11(paramSet)) return;

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA4211"), paramSet);
                this.grd11.SetValue(source.Tables[0]);
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
        /// [ TAB2 조회 유효성 체크 함수 ]
        /// </summary>
        private bool IsQueryValid_11(HEParameterSet paramSet)
        {
            try
            {
                // 품번(5자리) 체크
                /*if (paramSet["PARTNO"].ToString().Length == 0)
                {
                    //MsgCodeBox.Show("HR06-0017");
                    MsgBox.Show("품번(5자리)을 입력하세요.");
                    this.txt11_WORK_DIV.Focus();
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
        /// [ TAB2 초기화 함수 ]
        /// </summary>
        private void Reset_11(object sender, EventArgs e)
        {
            try
            {
                //this.BeforeInvokeServer();
                this.txt11_PARTNO.Initialize();
                this.txt11_NOTE.Initialize();

                this.grd11.InitializeDataSource();
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
        /// [ TAB2 저장 함수 ]
        /// </summary>
        private void Save_11(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd11.GetValue(
                      AxFlexGrid.FActionType.Save
                    , "CORCD"
                    , "REG_EMPNO"
                    , "PARTNO"
                    , "NOTE"
                    , "USE_YN"
                );
                //source.Tables[0].Columns["HR_EMPNO"].ColumnName = "EMPNO";
                string r_PARTNO = "";

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["REG_EMPNO"] = this.UserInfo.EmpNo;
                    // 체크박스 1 를 Y 로 변경
                    if (dr["USE_YN"].ToString() == "Y" || dr["USE_YN"].ToString() == "1")
                    {
                        dr["USE_YN"] = "Y";
                    }
                    else
                    {
                        dr["USE_YN"] = "N";
                    }

                    if (r_PARTNO.Length == 0)
                    {
                        r_PARTNO = dr["PARTNO"].ToString();
                    }
                }
                //source.Tables[0].Columns.Remove("OBJECT_ID");

                if (!IsSaveValid_11(this.grd11, source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA4211"), source);
                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                Find_DATA_ROW(this.grd11, r_PARTNO, "", "", "", "");

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
        /// [ TAB2 저장 체크 함수 ]
        /// </summary>
        private bool IsSaveValid_11(object sender, DataSet source)
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

                    if (this.GetByteCount(dr["PARTNO"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["PARTNO"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["PARTNO"].ToString()) != 5)
                    {
                        //{0} 번째 행에 {1} 가 {2} 자리가 아닙니다.\r\n{2} 자리로 등록하시기 바랍니다.
                        MsgCodeBox.ShowFormat("QA02-0056", rowIndex, grd.Cols["PARTNO"].Caption, 5);
                        return false;
                    }

                    /*if (this.GetByteCount(dr["NOTE"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["NOTE"].Caption);
                        return false;
                    }*/

                    // 중복체크 항수 호출
                    if (!Check_Grid_SameRow(sender, tab01_main.SelectedIndex, rowIndex, "N"))
                    {
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
        /// [ TAB2 삭제 함수 ]
        /// </summary>
        private void Delete_11(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd11.GetValue(
                      AxFlexGrid.FActionType.Remove
                    , "CORCD"
                    , "PARTNO"
                );
                //source.Tables[0].Columns["HR_EMPNO"].ColumnName = "EMPNO";
                string r_PARTNO = "";

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;

                    if (r_PARTNO.Length == 0)
                    {
                        r_PARTNO = dr["PARTNO"].ToString();
                    }
                }
                //source.Tables[0].Columns.Remove("CASH_TRANS");

                if (!IsDeleteValid_11(this.grd11, source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA4211"), source);
                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                Find_DATA_ROW(this.grd11, r_PARTNO, "", "", "", "");

                //#001
                //MsgBox.Show("정상적으로 삭제되었습니다.");
                MsgCodeBox.Show("CD00-0010");
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
        /// [ TAB2 삭제 체크 함수 ]
        /// </summary>
        private bool IsDeleteValid_11(object sender, DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //#001
                    //MsgBox.Show("삭제할 데이터가 존재하지 않습니다");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //#001
                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #endregion

        #endregion

    }
}
