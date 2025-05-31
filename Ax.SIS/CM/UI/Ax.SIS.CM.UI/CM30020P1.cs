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
 *				2014-07-16      배명희     사원정보 공통 팝업 신규 (다국어 처리有, 퇴사자도 조회됨!!!)
 *				2014-07-21      배명희     생성자에 퇴직자 제외여부 정보 추가.
 *				                            (RET_EXCLUDE: 기본은 퇴사자 포함임, 퇴사자 제외하고자할 때 생성자에 true 넘겨주도록 구성함)                      
 *               
 *
 *
 * 
 */
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.CM.UI
{
    /// <summary>
    /// <b>사원정보 팝업</b>
    /// </summary>
    public partial class CM30020P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_CM30020";
        
        private bool _RETIRE_EXCLUDE = false;   //퇴직자 제외여부(true이면 재직자만 조회, false이면 퇴직자 포함 전사원 조회대상) 

        #region [ 생성자 정의 ]

        /// <summary>
        /// 사원정보 팝업 (퇴직자 포함 전 사워정보 조회)
        /// </summary>
        public CM30020P1()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        /// <summary>
        /// 사원정보 팝업 
        /// </summary>
        /// <param name="retire_exclude">퇴직자 제외여부 (true:재직자만, false:퇴직자포함)</param>
        public CM30020P1(bool retire_exclude)
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            _RETIRE_EXCLUDE = retire_exclude;
        }

        #endregion

        #region [ 화면 초기화 설정 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!this.IsCreated)
                {
                    this.grd01.AllowEditing = false;
                    this.grd01.Initialize();
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "사용자 아이디", "EMPNO", "EMPNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 170, "성명", "NAME_KOR", "NAME_KOR");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "부서", "DEPART", "DEPART");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "휴대전화", "MOB_PHONE_NO", "MOB_PHONE_NO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "전자메일 구분", "EMAIL_ADDR", "EMAIL_ADDR");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "사업장코드", "BIZCD", "BIZCD");
                    //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "내선번호", "LINE_NO", "PHONE"); 2017-06-30  내선번호 항목 임의 제거함. 배명희
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "부서코드", "DEPARTCD", "DEPARTCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "라인코드", "LINECD", "LINECD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "라인명", "LINENM", "LINENM");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "소속", "USER_DIV", "USER_DIV");
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                    this.IsCreated = true;
                }

                if (this.CodeBox != null)
                {
                    this.txt01_EMPNO.SetValue(this.CodeBox.GetValue());
                    this.txt01_NAME_KOR.SetValue(this.CodeBox.GetText());
                }

                //this.txt01_EMPNO.SetValid(   HETextBox.TextType.OnlyNumber);
                //this.txt01_NAME_KOR.SetValid(HETextBox.TextType.Hangle);

                this.btn01_INQUERY_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
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
            //조회조건 체크하여 
            //퇴사자 제외 여부 조건 추가함.
            //개발자가 코드박스 초기설정시 실수로 파라메터 추가를 누락할지도 몰라서...노파심인가....싶기도..
            bool isExists = false;
            for (int i = 0; i < set.Keys.Count; i++)
            {
                if (set.Items[i].Key.Equals("RET_EXCLUDE"))
                {
                    isExists = true;
                    break;
                    
                }
            }

            if (!isExists)
            {
                set.Add("RET_EXCLUDE", (_RETIRE_EXCLUDE == true) ? "Y" : "N");
            }

            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_EMPLOYEE"), set).Tables[0];
        }

        #endregion

        #region [ 기타 컨트롤 이벤트 ]

        private void btn01_INQUERY_Click(object sender, EventArgs e)
        {
            try
            {
                string EMPNO    = this.txt01_EMPNO.GetValue().ToString();
                string NAME_KOR = this.txt01_NAME_KOR.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("EMPNO",    EMPNO);
                paramSet.Add("NAME_KOR", NAME_KOR);
                paramSet.Add("CORCD",    this.UserInfo.CorporationCode);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("RET_EXCLUDE",(_RETIRE_EXCLUDE == true) ? "Y" : "N");

                this.BeforeInvokeServer(true);
                DataTable source = this.GetDataSource(paramSet);
                this.AfterInvokeServer();
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

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
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

        #endregion
    }
}
