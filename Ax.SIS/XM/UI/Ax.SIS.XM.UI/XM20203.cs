#region ▶ Description & History
/* 
 * 프로그램명 : 사용자관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-07      배명희      프로그램 아이디 변경(XM80030 -> XM20203)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 공통컨트롤로 전환
 *              2014-07-14      배명희      사용자 구분 (유형코드 T1, user_div) 및 인증경로(유형코드 T4, cert_course) 항목 추가.
 *                                          [사용자 구분]항목과 [인증경로] 항목의 상호 연동은, 유형코드 T1의 GROUPCD 데이터 이용하여 로직 적용함.
 *                                             --> 사용자 구분 [T11], [T15],[T16] 선택시, 인증경로 [T4A] 자동 선택
 *                                             --> 사용자 구분 [T12] 선택시, 인증경로 [T4D] 자동 선택
 *              2014-07-15      배명희      grd01_MouseDoubleClick 이벤트에 현재 선택된 행 체크 로직 추가함. (최초 로드후 그리드의 행 선택 없이 더블클릭하면 null 참조 오류 발생함)
 *              2014-07-16      배명희      사용자구분별 사번, 업체코드, 고객코드 항목 관리 기능 추가.(필수체크는 유형코드 데이터의 OPTION_C01 항목 이용)
 *                                          비밀번호 오류 횟수 초기화 기능 추가
 *                                          관리자 여부 항목 추가.
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거        
 *              2014-07-22      배명희     cdx02_LINECD 연결 팝업 변경 (CM20015P1 -> CM30030P1)
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
 *              2015-04-10      김민재     저장 시 사용자구분(T12)일 경우 사번 항목 필수 조건 삭제
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// 사용자 관리
    /// </summary>
    public partial class XM20203 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;        
        private DataTable _DTUSER_DIV;
        private DataTable _DTCERT_COURSE;
        private string PAKAGE_NAME = "APG_XM20203";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";
        public XM20203()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            _DTUSER_DIV = new DataTable();
            _DTCERT_COURSE = new DataTable();
        }
        
        #region [초기화 작업 정의]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "_사용자 아이디", "USERID", "USERID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "_사용자명", "USERNAME", "USERNAME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "_라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "_법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "_사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "_시스템코드", "SYSCD", "SYSCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "_시스템명", "SYSNAME", "SYSNAME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_전화번호", "TELNO", "TELNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_휴대전화", "MOB_PHONE_NO", "MOB_PHONE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "_전자메일", "EMAIL_ADDR", "EMAIL_ADDR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "_퇴사일자", "RETIRE_DATE", "RETIRE_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_공장구분", "PLANT_DIV", "PLANT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_인증경로", "CERT_COURSE", "CERT_COURSE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "_사용자구분", "USER_DIV", "USER_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 085, "_사번", "EMPNO", "EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "_거래처코드", "VENDORCD", "VENDORCD");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "_패스워드 유효일자", "PWD_VALID_DATE", "PWD_VALID_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "_패스워드 변경일", "PWD_CHG_DATE", "PWD_CHG_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "_패스워드 오류횟수", "PWD_ERR_COUNT", "PWD_ERR_COUNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "_관리자 여부", "ADMIN_FLAG", "ADMIN_FLAG");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RETIRE_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "ADMIN_FLAG");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "U9", "PLANT_DIV", true);
                this.cbo02_CORCD.DataBind_CORCD(false);
                this.cbo02_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo02_PLANT_DIV.DataBindCodeName("U9", false);

                DataTable dtSystemCode = this.getSystemCode();
                this.cbo01_SYSCD.DataBind(dtSystemCode, true);
                this.cbo02_SYSCD.SetValue(this.UserInfo.SystemCode);
                this.cbo02_SYSCD.DataBind(dtSystemCode, true);

                DataSet source = this.GetTypeCode("T1", "T4");
                source.Tables[0].DefaultView.RowFilter = "GROUPCD LIKE 'T4%'";  //사용자구분 중에서 groupcd가 T4로 시작되는 항목만 이 화면에서 사용함.
                                                                                //한일이화(t12), 거래처(t11), 협력업체(t15)
                _DTUSER_DIV = source.Tables[0].DefaultView.ToTable();

                _DTCERT_COURSE = source.Tables[1].Copy();

                this.cbo01_USER_DIV.DataBind(_DTUSER_DIV);
                this.cbo02_USER_DIV.DataBind(_DTUSER_DIV, false);

                this.cbo02_CERT_COURSE.DataBind(_DTCERT_COURSE, false);
                this.cbo02_CERT_COURSE.SetValue("T4D"); //기본값 DB
                this.cbo02_CERT_COURSE.SetReadOnly(true);

                this.cdx02_EMPNO.HEPopupHelper = new CM30020P1();
                this.cdx02_EMPNO.PopupTitle = this.GetLabel("EMPINFO");
                this.cdx02_EMPNO.CodeParameterName = "EMPNO";
                this.cdx02_EMPNO.NameParameterName = "NAME_KOR";
                this.cdx02_EMPNO.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_EMPNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                
                this.cdx02_EMPNO.HEPopupHelper.Initialize_Helper(this.cdx02_EMPNO);

                this.cdx02_VENDCD.HEPopupHelper = new CM20017P1(this.cdx02_VENDCD, true);
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("XM20203_POP_VEND");

                

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, _DTUSER_DIV, "USER_DIV");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, _DTCERT_COURSE, "CERT_COURSE");

                this.cdx02_LINECD.HEPopupHelper = new CM30030P1();
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
               
                this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("LINECD_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx02_LINECD.SetCodePixedLength();

                this.SetRequired(lbl02_USERID, lbl02_USERNAME, lbl02_CORCD, lbl02_BIZCD, 
                    lbl02_SYSCD, lbl02_RETIRE_DATE, lbl02_USER_DIV, lbl02_CERT_COURSE);

                this.txt02_USERID.SetValid(10, AxTextBox.TextType.Default);

                this.BtnQuery_Click(null, null);

                this.cbo02_USER_DIV.SelectedIndexChanged += new System.EventHandler(this.cbo02_USER_DIV_SelectedIndexChanged);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string USERID = this.txt02_USERID.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema(
                    "USERID", "USERNAME", "LINECD", "LINENAME", "CORCD", "SYSCD", "BIZCD", 
                    "TELNO", "MOB_PHONE_NO", "EMAIL_ADDR", "RETIRE_DATE", "CORNAME", "SYSNAME", "BIZNAME",
                    "PLANT_DIV", "USER_DIV", "CERT_COURSE", "EMPNO", "VENDCD", "ADMIN_FLAG");

                source.Tables[0].Rows.Add(
                    USERID,
                    this.txt02_USERNAME.GetValue(),
                    this.cdx02_LINECD.GetValue(),
                    this.cdx02_LINECD.GetText(),
                    this.cbo02_CORCD.GetValue(),
                    this.cbo02_SYSCD.GetValue(),
                    this.cbo02_BIZCD.GetValue(),
                    this.txt02_TELNO.GetValue(),
                    this.txt02_MOB_PHONE_NO.GetValue(),
                    this.txt02_EMAIL_ADDR.GetValue(),
                    this.dte02_RETIRE_DATE.GetDateText(),
                    this.cbo02_CORCD.GetText(),
                    this.cbo02_SYSCD.GetText(),
                    this.cbo02_BIZCD.GetText(),
                    this.cbo02_PLANT_DIV.GetValue(),
                    this.cbo02_USER_DIV.GetValue(),
                    this.cbo02_CERT_COURSE.GetValue(),
                    this.cdx02_EMPNO.GetValue(),
                    this.cdx02_VENDCD.GetValue(),                    
                    this.chk02_ADMIN_FLAG.Checked? "1" : "0"
                    );

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.BtnQuery_Click(USERID);
                //MsgBox.Show("입력하신 사용자 정보를 저장하였습니다.");
                MsgCodeBox.Show("XM00-0081");
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
                DataSet source = this.GetDataSourceSchema("USERID");

                source.Tables[0].Rows.Add(
                    this.txt02_USERID.GetValue());

                if (!this.IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 사용자 정보를 삭제하였습니다.");
                MsgCodeBox.Show("XM00-0082");
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string USERID   = this.txt01_USERID.GetValue().ToString();
                string USERNAME = this.txt01_USERNAME.GetValue().ToString();
                string CORCD    = this.UserInfo.CorporationCode;
                string LANG_SET = this.UserInfo.Language;
                string SYSCD = this.cbo01_SYSCD.GetValue().ToString();
                string USER_DIV = this.cbo01_USER_DIV.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("USERID",   USERID);
                set.Add("USERNAME", USERNAME);
                set.Add("CORCD",    CORCD);
                set.Add("LANG_SET", LANG_SET);
                set.Add("SYSCD",    SYSCD);
                set.Add("USER_DIV", USER_DIV);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);

                this.BtnReset_Click(null, null);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt02_USERID.Initialize();
                this.txt02_USERNAME.Initialize();
                this.txt02_TELNO.Initialize();
                this.cbo02_SYSCD.Initialize();
                this.txt02_MOB_PHONE_NO.Initialize();
                this.txt02_EMAIL_ADDR.Initialize();
                this.cdx02_LINECD.Initialize();
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.dte02_RETIRE_DATE.SetValue("9998-12-31");

                this.cbo02_USER_DIV.SetValue("T12");    //기본값 한일이화
                this.cbo02_CERT_COURSE.SetValue("T4D"); //기본값 DB

                this.txt02_USERID.SetReadOnly(false);
                this.btn02_CLEAR_PWD.SetReadOnly(true);
                this.btn02_CLEAR_ERROR_CNT.SetReadOnly(true);

                this.cdx02_EMPNO.Initialize();
                this.cdx02_VENDCD.Initialize();
                
                this.chk02_ADMIN_FLAG.Checked = false;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [기타 이벤트에 대한 정의]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;
                string USERID = this.grd01.GetValue(row, "USERID").ToString();

                this.BtnQuery_Click(USERID);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_CLEAR_PWD_Click(object sender, EventArgs e)
        {
            try
            {

                //if (MsgBox.Show("선택하신 사용자 비밀번호를 초기화 하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0083", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                DataSet source = this.GetDataSourceSchema("USERID");
                source.Tables[0].Rows.Add(
                    this.txt02_USERID.GetValue()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_PASSWORD_CLEAR(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_PASSWORD_CLEAR"), source);
                this.AfterInvokeServer();

                //MsgBox.Show("선택하신 사용자 비밀번호가 초기화 되었습니다.");
                MsgCodeBox.Show("XM00-0084");
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
                
        private void btn02_CLEAR_ERROR_CNT_Click(object sender, EventArgs e)
        {
            try
            {
                //if (MsgBox.Show("선택하신 사용자의 패스워드 오류횟수를 초기화하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0105", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                DataSet source = this.GetDataSourceSchema("USERID");
                source.Tables[0].Rows.Add(
                    this.txt02_USERID.GetValue()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_PASSWORD_CLEAR(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_ERROR_CNT_CLEAR"), source);
                this.AfterInvokeServer();

                //MsgBox.Show("선택하신 사용자 패스워드 오류횟수가 초기화 되었습니다.");
                MsgCodeBox.Show("XM00-0106");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo02_USER_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //사용자구분과 default 인증경로는 연관이 있음. 
                //한일이화인 경우 active directory 인증, 고객사/협력업체인 경우 database 인증이 기본 선택되도록 함.
                string user_div = this.cbo02_USER_DIV.GetValue().ToString();
                DataRow[] drs = _DTUSER_DIV.Select("OBJECT_ID='" + user_div + "'");

                if (drs.Length > 0)
                {
                    string cert_course = drs[0]["GROUPCD"].ToString();
                    this.cbo02_CERT_COURSE.SetValue(cert_course);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (this.cbo02_USER_DIV.IsEmpty)
                {
                    //MsgBox.Show("사용자구분 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_USER_DIV.GetValue());
                    return false;
                }
                if (this.cbo02_CERT_COURSE.IsEmpty)
                {
                    //MsgBox.Show("인증방법 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_CERT_COURSE.GetValue());
                    return false;
                }

                string user_div = this.cbo02_USER_DIV.GetValue().ToString();
                DataRow[] drs = _DTUSER_DIV.Select("OBJECT_ID='" + user_div + "'");
                if (drs.Length > 0)
                {
                    //사용자 구분에 따라 필수 입력해야할 필드가 있음.
                    //[T11 고객    ]인 경우 "고객사코드" 필수
                    //[T12 한일이화]인 경우 "사번" 필수
                    //[T15,T16 협력업체]인 경우 "협력업체코드" 필수
                    string required = drs[0]["OPTION_C01"].ToString();

                    if (required.Equals("VENDCD"))
                    {
                        if (this.cdx02_VENDCD.IsEmpty)
                        {
                            //MsgBox.Show("협력업체를 입력하세요.");
                            MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_VENDORCD.GetValue());
                            return false;
                        }
                    }
                   
                    else if (required.Equals("EMPNO"))
                    {
                        //if (this.cdx02_EMPNO.IsEmpty)
                        //{
                        //    //MsgBox.Show("사번을 입력하세요.");
                        //    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_EMPNO.GetValue());
                        //    return false;
                        //}

                        

                    }
                }

                if (this.txt02_USERID.IsEmpty)
                {
                    //MsgBox.Show("사용자 아이디를 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_USERID.GetValue());
                    return false;
                }          

                if (!this.txt02_USERID.ReadOnly)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("USERID", this.txt02_USERID.GetValue());

                    //string exist_yn = _WSCOM.INQUERY_EXIST(set).Tables[0].Rows[0]["EXIST_YN"].ToString();
                    string exist_yn = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_EXIST"), set).Tables[0].Rows[0]["EXIST_YN"].ToString();

                    if (exist_yn.Equals("Y"))
                    {
                        //MsgBox.Show("이미 사용중인 사용자 아이디 입니다.");
                        MsgCodeBox.Show("XM00-0085");
                        return false;
                    }
                }

                if (this.txt02_USERNAME.IsEmpty)
                {
                    //MsgBox.Show("사용자 명을 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_USERNAME.GetValue());
                    return false;
                }
                
               

                if (this.cbo02_SYSCD.IsEmpty)
                {
                    //MsgBox.Show("시스템코드를 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_SYSCD.GetValue());
                    return false;
                }

               

                if (this.cbo02_USER_DIV.IsEmpty)
                {
                    //MsgBox.Show("사용자 구분을 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_USER_DIV.GetValue());
                    return false;
                }

                if (this.cbo02_CERT_COURSE.IsEmpty)
                {
                    //MsgBox.Show("인증경로를 입력하세요.");
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_CERT_COURSE.GetValue());
                    return false;
                }

                //if (MsgBox.Show("입력하신 사용자 정보를 저장하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0086", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (!this.txt02_USERID.ReadOnly)
                {
                    //MsgBox.Show("삭제할 사용자가 선택되지 않았습니다.");
                    MsgBox.Show("XM00-0087");
                    return false;
                }

                //if (MsgBox.Show("선택하신 사용자를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0088", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        #region [사용자 정의 메서드]

        private void BtnQuery_Click(string USERID)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("USERID", USERID);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_DETAIL(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), set);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count == 0) return;

                DataRow row = source.Tables[0].Rows[0];

                this.txt02_EMAIL_ADDR.SetValue(row["EMAIL_ADDR"]);
                this.txt02_MOB_PHONE_NO.SetValue(row["MOB_PHONE_NO"]);
                this.cbo02_SYSCD.SetValue(row["SYSCD"]);
                this.txt02_TELNO.SetValue(row["TELNO"]);
                this.txt02_USERID.SetValue(row["USERID"]);
                this.txt02_USERNAME.SetValue(row["USERNAME"]);
                this.cbo02_BIZCD.SetValue(row["BIZCD"]);
                this.cbo02_CORCD.SetValue(row["CORCD"]);
               
                this.dte02_RETIRE_DATE.SetValue(row["RETIRE_DATE"]);

                this.cbo02_PLANT_DIV.SetValue(row["PLANT_DIV"]);

                this.txt02_USERID.SetReadOnly(true);
                this.btn02_CLEAR_PWD.SetReadOnly(false);
                this.btn02_CLEAR_ERROR_CNT.SetReadOnly(false);

                this.cbo02_USER_DIV.SetValue(row["USER_DIV"]);

                this.cdx02_LINECD.Initialize();
                string user_div = row["USER_DIV"].ToString();
                DataRow[] drs = _DTUSER_DIV.Select("OBJECT_ID='" + user_div + "'");
                if (drs.Length > 0)
                {
                    //사용자 구분에 따라 필수 입력해야할 필드가 있음.
                    //[T11 고객    ]인 경우 "고객사코드" 필수
                    //[T12 한일이화]인 경우 "사번" 필수
                    //[T15,T16 협력업체]인 경우 "협력업체코드" 필수
                    //필수입력이 vendcd, custcd인 경우 linecd에 값 셋팅하지 않기.
                    string required = drs[0]["OPTION_C01"].ToString();
                    if (!(required.Equals("VENDCD") || required.Equals("CUSTCD")))
                    {
                        this.cdx02_LINECD.SetValue(row["LINECD"]);
                    }
                }

                this.cbo02_CERT_COURSE.SetValue(row["CERT_COURSE"]);

                this.cdx02_EMPNO.SetValue(row["EMPNO"]);
                this.cdx02_VENDCD.SetValue(row["VENDORCD"]);
                
                this.chk02_ADMIN_FLAG.Checked = row["ADMIN_FLAG"].ToString() == "1" ? true : false;
                
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

        private DataTable getSystemCode()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20001, "INQUERY_SYSTEMCODE"), set);

                //source.Tables[0].Columns["SYSNAME"].SetOrdinal(1);
                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        #endregion        
        
    }
}
