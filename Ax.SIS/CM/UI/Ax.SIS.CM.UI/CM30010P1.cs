#region ▶ Description & History
/* 
 * 프로그램명 : 공통코드 팝업
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-15      배명희      공통코드 팝업 신규
 *				                              >> 사용 방법 (각 업무단 화면에서 아래와 같이 설정)
 *				                                this.cdx01_ITEMCD.HEPopupHelper     = new CM30010P1("A4");                      //==> CLASS_ID 값 전달
                                                this.cdx01_ITEMCD.CodeParameterName = "CODE";                                   //==> CODE 고정
                                                this.cdx01_ITEMCD.NameParameterName = "CODENAME";                               //==> CODENAME 고정
                                                this.cdx01_ITEMCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);  //==> LANG_SET 고정
                                                this.cdx01_ITEMCD.HEUserParameterSetValue("CLASS_ID", "A4");                    //==> CLASS_ID 값 전달
 *                                              
 *                                              OR
 *
 *                                              this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3");   
                                                this.cdx01_VINCD.CodeParameterName = "CODE";
                                                this.cdx01_VINCD.NameParameterName = "CODENAME";
                                                this.cdx01_VINCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                                                this.cdx01_VINCD.HEUserParameterSetValue("CLASS_ID", "A3");                
                                                this.cdx01_VINCD.PrefixCode = "A3";
 * 
 *              2014-07-28      배명희       생성자 오버로딩 처리, 코드박스 입력키 제한(영어와 숫자만 입력되도록)               
 *                                              >> 사용 방법 (각 업무단 화면에서 아래와 같이 설정)
 *                                                  this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);
 *
 * 
 */
#endregion
using System;
using System.Collections;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.CM.UI
{
    /// <summary>
    /// <b>유형 코드 헬퍼</b>
    /// </summary>
    public partial class CM30010P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_CM30010";
        //private ICM30010 _WSCOM;
        private string _CLASS_ID= "";
        private Boolean _AutoLink = true;

        private bool _IsCodeFixedLength = false;    //기본 : 길이고정 안함.
        private bool _IsPrefixCode = false;         //기본 : classId + typecd 표시

        #region [ 생성자 정의 ]

        /// <summary>
        /// 유형코드 조회 팝업
        /// </summary>
        /// <param name="classId">클래스Id</param>
        public CM30010P1(string classId)
        {
            _CLASS_ID = classId;
            InitializeComponent();

            _WSCOM = new AxClientProxy();

            this.Init();
        }

        /// <summary>
        /// 유형코드 조회 팝업
        /// </summary>
        /// <param name="classId">클래스Id</param>
        /// <param name="AutoLink">자동연결여부..true인경우에만 "코드", "명"에 기존 값 표시함. 숨김 코드박스 이용하여 팝업만 띄우려는 경우에는 false로 넘김. </param>
        public CM30010P1(string classId, Boolean AutoLink)
        {
            _CLASS_ID = classId;
            _AutoLink = AutoLink;

            InitializeComponent();

            _WSCOM = new AxClientProxy();

            this.Init();
        }

        /// <summary>
        /// 유형코드 조회 팝업
        /// </summary>
        /// <param name="classId">클래스Id</param>
        /// <param name="IsCodeFixedLength">코드 길이 고정여부(true이면 10자리에 맞춰서 " "(공백) 오른쪽 패딩 처리)</param>
        /// <param name="IsPrefixCode">prefix제외 여부(코드입력란에 true:typecd만 표시, false:classid+typecd표시)</param>
        /// <param name="sender">팝업과 연결되는 코드박스 컨트롤</param>
        public CM30010P1(string classId, bool IsCodeFixedLength, bool IsPrefixCode, AxCodeBox sender)
        {
            _CLASS_ID = classId;
            _IsCodeFixedLength = IsCodeFixedLength;
            _IsPrefixCode = IsPrefixCode;

          
            InitializeComponent();

            _WSCOM = new AxClientProxy();

            this.CodeBox = sender;
            this.Init();
        }

        private void Init()
        {
            if (this.CodeBox != null)
            {
                this.CodeBox.CodeParameterName = "CODE";
                this.CodeBox.NameParameterName = "CODENAME";
                this.CodeBox.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.CodeBox.HEUserParameterSetValue("CLASS_ID", _CLASS_ID);
                this.CodeBox.SetValid(AxTextBox.TextType.UAlphabet);

                if (_IsCodeFixedLength)
                {
                    this.CodeBox.SetCodePixedLength();
                }

                if (_IsPrefixCode)
                {
                    this.CodeBox.PrefixCode = _CLASS_ID;
                    this.PrefixCode = _CLASS_ID;
                }
            }
        }

        #endregion

        #region [ 초기화 작업 정의 ]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!this.IsCreated)
                {
                    this.grd01.AllowEditing = false;
                    this.grd01.AllowFiltering = true;
                    this.grd01.Initialize();

                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_코드", "CODE", "CODE");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "_코드명", "CODENAME", "CODENAME");

                    this.IsCreated = true;
                }
                ((Form)this.Parent).Text = this.GetTitle(_CLASS_ID);                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            if (_AutoLink)
            {
                this.txt01_CODE.SetValue(this.CodeBox.GetProcessCode());
                this.txt01_CODENAME.SetValue(this.CodeBox.GetText());
            }

            this.btn01_Inquery_Click(null, null);
        }

        #endregion

        #region IHEPopupHelper 멤버

        public object SelectedValue
        {
            get { return this.SelectedData; }
        }

        public void Initialize_Helper(object sender)
        {
            this.CodeBox = (AxCodeBox)sender;
        }

        public DataTable GetDataSource(HEParameterSet set)
        {
            this.CodeBox_HEParameterSetSetting(ref set);
            //DataTable dt = _WSCOM.ExecuteDataSet("PKG_CM30010.INQUERY", set).Tables[0];
            //return dt;
            //DataTable dt = _WSCOM.Inquery(set).Tables[0];
            //dt = this.CodeBox_GetDataSourceChange(dt);
            return this.CodeBox_GetDataSourceChange(_WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set));
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CODE", this.txt01_CODE.GetValue());
                set.Add("CODENAME", this.txt01_CODENAME.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("CLASS_ID", _CLASS_ID);

                this.BeforeInvokeServer(true);

                DataTable table = this.GetDataSource(set);
                this.grd01.SetValue(table);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.SelectedRowIndex < this.grd01.Rows.Fixed) return;

                this.SelectedData = this.grd01.SelectedDataRowMultiLang;
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //필터링 기능(코드 입력시)
        private void txt01_CODE_KeyUp(object sender, KeyEventArgs e)
        {
            ColumnFilter cf = new ColumnFilter();
            cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
            cf.ConditionFilter.Condition1.Parameter = this.txt01_CODE.GetValue().ToString();
            this.grd01.Cols["CODE"].Filter = cf;
            this.grd01.ApplyFilters();
        }
        
        //필터링 기능(코드명 입력시)
        private void txt01_CODENAME_KeyUp(object sender, KeyEventArgs e)
        {
            ColumnFilter cf = new ColumnFilter();
            cf.ConditionFilter.Condition1.Operator = ConditionOperator.Contains;
            cf.ConditionFilter.Condition1.Parameter = this.txt01_CODENAME.GetValue().ToString();
            this.grd01.Cols["CODENAME"].Filter = cf;
            this.grd01.ApplyFilters();
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        //팝업 타이틀 조회 CLASS_ID + "-" + CLASS_NM
        private string GetTitle(string classId)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("CLASS_ID", _CLASS_ID);
                DataTable dt = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "GET_TITLE"), set).Tables[0];
                //DataTable dt = _WSCOM.Get_Title( set).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["POP_TITLE"].ToString();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
            return "";
        }

        //그리드에서 제공되는 기능인 SelectedDataRow는 다국어 모드에서는 지원되지 않음.
        //동일한 로직을 화면에서 처리함.
        
        private DataRow SelectedDataRow(AxFlexGrid grd)
        {
            try
            {
                ArrayList values = new ArrayList();
                DataTable source = new DataTable();
                for (int i = grd.Cols.Fixed; i < grd.Cols.Count; i++)
                {
                    source.Columns.Add(grd.Cols[i].Name);
                    values.Add(grd.GetValue(grd.Row, grd.Cols[i].Name));
                }
                source.Rows.Add(values.ToArray());

                return source.Rows[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
            return null;
        }

        #endregion

        
    }
}
