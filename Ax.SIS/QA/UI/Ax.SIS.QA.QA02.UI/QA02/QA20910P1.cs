#region ▶ Description & History
/* 
 * 프로그램명 : QA20910P1 품번조회 팝업
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

using System.Collections;
using System.Text.RegularExpressions;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>품번조회 팝업</b>
    /// - 생 성 자 : 이재한<br />
    /// - 생 성 일 : 2016-12-13 오후 16:59:51<br />
    /// </summary>
    public partial class QA20910P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA20910";
        private bool _isLoadCompleted = false;
        private string _SEARCH_CODE = "";

        public QA20910P1()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        //#001
        public QA20910P1(string SEARCH_CODE)
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();    
            _SEARCH_CODE = SEARCH_CODE;
        }

        #region [ IHEPopupHelper 멤버 ]

        public object SelectedValue
        {
            get
            {
                return this.SelectedData;
            }
        }

        public void Initialize_Helper(object sender)
        {
            this.CodeBox = (AxCodeBox)sender;
        }

        public DataTable GetDataSource(HEParameterSet set)
        {
            this.CodeBox_HEParameterSetSetting(ref set);
            return this.CodeBox_GetDataSourceChange(_WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CD0020"), set));
        }

        #endregion

        #region [ 초기화 작업 정의 ]

        /// <summary>
        /// [ 화면 초기 설정 ]
        /// </summary>
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!this.IsCreated)
                {
                    #region [ 코드 데이터 호출 ]

                    #endregion

                    #region [ 품번조회 설정 ]

                    #region [ 품번조회 그리드 설정 ]

                    // 그리드 설정
                    this.grd01.AllowEditing = false;
                    //this.grd01.Initialize(1,1);

                    this.grd01.Initialize();
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "품번", "PARTNO", "PARTNO3");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 299, "품명", "PARTNM", "PARTNONM");

                    this.grd01.AddHiddenColumn("PARTNM2");

                    #region [ 그리드내 포멧 설정 ]

                    // 그리드내 포멧 설정
                    //this.grd01.SetColumnType(HEFlexGrid.FCellType.Date, "BEG_DATE");
                    //this.grd01.Cols["BEG_DATE"].Format = "MM-dd";
                    //this.grd01.SetColumnType(HEFlexGrid.FCellType.Decimal, "LOAN_CAPITAL");
                    //this.grd01.Cols["LOAN_CAPITAL"].Format = "###,###,###,###";
                    //this.grd01.SetColumnType(HEFlexGrid.FCellType.Check, "CODE03");

                    // 그리드내 콤보데이터 설정
                    //this.grd01.SetColumnType(HEFlexGrid.FCellType.ComboBox, dtDR_CR_DIV, "CODE03");

                    #endregion

                    this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
                    this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                    //this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
                    this.grd01.AllowSorting = AllowSortingEnum.SingleColumn;
                    //this.grd01.AllowSorting = AllowSortingEnum.None;    // 등록화면에는 정렬시 순번의 상태값이 움직이지 않는 버그로 인해 정렬 비활성화
                    this.grd01.InitializeDataSource();
                    //this.grd01.Cols["GA_DESTINY_NM"].StyleDisplay.WordWrap = true;
                    //this.grd01.Rows[0].Height = 35; //헤더 높이 재 설정

                    // 그리드 행추가 행삭제 안되게 설정
                    //this.grd01.CurrentContextMenu.Items[0].Visible = false;   // 행추가
                    //this.grd01.CurrentContextMenu.Items[1].Visible = false;   // 행삭제
                    //this.grd01.CurrentContextMenu.Items[2].Visible = false;   // 행취소
                    //this.grd01.CurrentContextMenu.Items[3].Visible = false;   // 구분선

                    #endregion

                    #endregion

                    #region [ 기타 설정 ]

                    this.IsCreated = true;

                    //if (this._SEARCH_CODE != string.Empty)
                    //{
                        this.txt01_SEARCH.SetValue(_SEARCH_CODE);
                        btn01_Inquery_Click(null, null);
                    //}

                    //_isbinding = false;

                    _isLoadCompleted = true;

                    #endregion
                }

                // 기본 조회 (코드박스 연동시 필요한 로직)
                if (this.CodeBox != null)
                {
                    this.txt01_SEARCH.SetValue(this.CodeBox.GetValue());                    
                    btn01_Inquery_Click(null, null);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 그리드 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 그리드 마우스 더블클릭 이벤트 ]
        /// </summary>
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    //if (grd.SelectedRowIndex < grd.Rows.Fixed) return;
                    if (grd.MouseRow < grd.Rows.Fixed) return;

                    ArrayList values = new ArrayList();
                    DataTable source = new DataTable();

                    for (int i = grd.Cols.Fixed; i < grd.Cols.Count; i++)
                    {
                        source.Columns.Add(grd.Cols[i].Name);
                        values.Add(grd.GetValue(grd.Row, grd.Cols[i].Name));
                    }

                    source.Rows.Add(values.ToArray());

                    this.SelectedData = source.Rows[0];
                    ((Form)this.Parent).Close();
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
        /// [ 팝업조회 택스트 키다운 이벤트 ]
        /// </summary>
        private void txt01_SEARCH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn01_Inquery_Click(null, null);
            }
        }

        /// <summary>
        /// [ 팝업조회 버튼 클릭 이벤트 ]
        /// </summary>
        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            Query_01(sender, null);
        }

        #endregion

        #region [ 사용자 정의 method ]

        /// <summary>
        /// [ 팝업 조회 함수 ]
        /// </summary>
        private void Query_01(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                paramSet.Add("PARTNO", this.txt01_SEARCH.GetValue().ToString());

                //if (!IsQueryValid_01(paramSet)) return;

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA20910", "INQUERY_CD0020"), paramSet);
                DataTable source = this.GetDataSource(paramSet);
                this.grd01.SetValue(source);
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
        /// [ 팝업 조회 유효성 체크 함수 ]
        /// </summary>
        private bool IsQueryValid_01(HEParameterSet paramSet)
        {
            try
            {
                if (paramSet["PARTNO"].ToString().Length == 0)
                {
                    //검색조건을 입력하여 주세요.
                    MsgCodeBox.Show("CD00-0110");
                    this.txt01_SEARCH.Focus();
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        public static bool CheckNumber(string letter)
        {
            bool IsCheck = true;
            Regex numRegex = new Regex(@"[0-9]");

            Boolean ismatch = numRegex.IsMatch(letter);
            if (!ismatch)
                IsCheck = false;
            return IsCheck;
        }

        #endregion

    }
}
