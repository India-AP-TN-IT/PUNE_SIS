#region ▶ Description & History
/* 
 * 프로그램명 : 베이스 컨트롤
 * 설     명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 
 *				
*/
#endregion
using Ax.DEV.Utility.Controls;
using C1.Win.C1Input;

using HE.Framework.Core;
using HE.Framework.Core.Security;
using HE.Framework.ServiceModel;
using HE.Framework.Windows.Forms;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TheOne.Text;
using System.ComponentModel;


//using Ax.SIS.FX.COMMON.IF;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// 서연이화 물류 시스템에서 사용하는 베이스 컨트롤입니다.    
    /// </summary>
    public partial class AxCommonBaseControl : HEUserControlBase //AxCommonUserControl
    {
        #region "HECommonUserControl"
        public AxCommonButtonControl _buttonsControl;
        private DataTable _dtLanInfo;
        private DataTable _dtGridInfo;
        private DataTable _dtGridHeaderInfo;

        #endregion



        private bool _IsCreated;
        private object _SelectedData;
        private string _StatusMessage;
        private ControlFactoryList _ControlFactory;
        private ControlSequenceList _ControlSequenceList;


        #region fullscreen

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool Showned
        {
            get;
            set;
        }


        // 풀스크린 처리 by 2016.11.07 김건우 추가
        private AxFullScreenHelper fullScreenHelper = new AxFullScreenHelper();


        public bool FullScreenMode
        {
            get { return this.fullScreenHelper.fullScreenMode; }
        }


        public event AxFullScreenHelper.FullScreenModeChangedHandler FullScreenModeChanged;

        private void OnFullScreenModeChanged(object sender, bool changedMode)
        {
            if (this.FullScreenModeChanged != null)
                this.FullScreenModeChanged(sender, changedMode);
        }

        // 풀스크린 처리 by 2016.11.07 김건우 추가
        [DefaultValue(true), Description("전체화면시 상단의 버튼 컨트롤을 표시할지 말지 결정합니다.")]
        public bool FullScreenButtonsVisible
        {
            get
            {
                return fullScreenHelper.ShowButtonControl;
            }
            set
            {
                fullScreenHelper.ShowButtonControl = value;
            }
        }

        // 풀스크린 처리 by 2016.11.07 김건우 추가
        [DefaultValue(true), Description("전체화면 사용여부(F11) Function Key 사용")]
        public bool FullScreenModeAllow
        {
            get;
            set;
        }

        public void ExecuteFullScreen()
        {
            fullScreenHelper.ExecuteFullScreen();
        }

        //// 풀스크린 처리 by 2016.11.07 김건우 추가
        //[DefaultValue(0), Description("전체화면을 표시할 모니터 번호")]
        //public int FullScreenBound
        //{
        //    get
        //    {
        //        //return Screen.gets
        //        //return fullScreenHelper.FullScreenBound;
        //    }
        //    set
        //    {
        //        //fullScreenHelper.FullScreenBound = value;
        //    }
        //}

        #endregion

        public AxCommonBaseControl()
            : base()
        {

            // 풀스크린 처리 by 2016.11.07 김건우 추가
            fullScreenHelper.FullScreenTarget = this;
            FullScreenButtonsVisible = true;
            FullScreenModeAllow = true;
            fullScreenHelper.modeChanged += new AxFullScreenHelper.FullScreenModeChangedHandler(OnFullScreenModeChanged);

            #region "GDCommonUserControl"
            InitializeComponent();

            Showned = false;

            // 공통 버튼 컨트롤 초기화 작업
            InitializeCommonButton();
            #endregion

            
            //로그인 정보매핑-팝업창 유저 정보 연동 2014-04-25 semin
            StaticUserInfoContext.UserInfoContext = base.UserInfo;

            this.Load += new EventHandler(HECommonBaseControl_Load);
            this.VisibleChanged += new System.EventHandler(this.setStatusMessage);
            
            _IsCreated = false;
            _SelectedData = null;
            _StatusMessage = "";
            _ControlFactory = new ControlFactoryList();
            _ControlSequenceList = new ControlSequenceList();
            this.LostFocus += new EventHandler(HECommonBaseControl_LostFocus);

            
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (string.Compare(this.UserInfo.UserID, "Admin", true) != 0)
                {
                    this.RequireAuthorization = true;
                }

                base.OnLoad(e);
            }
        }

        private void HECommonBaseControl_LostFocus(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                if (_ControlFactory.Count > 0)
                    ((Control)_ControlFactory[0]).Focus();
        }

        private void HECommonBaseControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                //HECommonBaseControl로 이동
                //StaticHeUserInfoContext.UserInfoContext = base.UserInfo;

                if (!AxStaticCommon.isTypeCodeLoaded)
                    AxStaticCommon.GetTypeCode();


                //StaticHeUserInfoContext 에 공장구분 추가 배명희
                //DataTable dt = HEStaticCommon.GetPlantDiv(base.UserInfo.UserID).Tables[0];
                //if (dt.Rows.Count > 0)
                //{
                //    StaticHeUserInfoContext._PlantDiv = dt.Rows[0]["PLANT_DIV"].ToString();
                //}

                //추가되는 사용자 정보는 여기서 통합관리 2015-04-04 semin
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("USERID", this.UserInfo.UserID);
                    
                    DataSet ds = new DataSet();
                    ds = proxy.ExecuteDataSet("APG_COMMON.INQUERY_USERINFO", paramSet);
                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        StaticUserInfoContext._PlantDiv = ds.Tables[0].Rows[0]["PLANT_DIV"].ToString();
                        StaticUserInfoContext._UserDiv = ds.Tables[0].Rows[0]["USER_DIV"].ToString();
                        StaticUserInfoContext._Vendcd = ds.Tables[0].Rows[0]["VENDCD"].ToString();
                        StaticUserInfoContext._Custcd = ds.Tables[0].Rows[0]["CUSTCD"].ToString();
                    }
                }
                
                //리포트는 Rexpert가 표준이므로 Crystal Report 체크할 필요 없음.
                //크리스탈 리포트 설치 여부 체크 추가 by semix
                //this.GetReportSetup();

                this.IControlFactoryCollection(this.Controls);
                this.IControlFactoryCollectionTabIndexSorting();
                this.IControlSequenceCollectionEnterKeySetting();

                if (_ControlFactory.Count > 0)
                    ((Control)_ControlFactory[0]).Focus();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            #region "HECommonUserControl"
            if (!this.DesignMode)
            {
                if (string.Compare(this.UserInfo.UserID, "Admin", true) != 0)
                {
                    ApplySecurityContext();
                }

                // 다국어 관련 데이터 가져오기
                DataSet dsUIData = GetUIData();

                // C1 관련 컨트롤 찾기
                LanguageHelper.InitializeC1Control(this.Controls,
                    dsUIData.Tables[0], dsUIData.Tables[1], dsUIData.Tables[2]);

                _dtLanInfo = dsUIData.Tables[0].Copy();
                _dtGridInfo = dsUIData.Tables[1].Copy();
                _dtGridHeaderInfo = dsUIData.Tables[2].Copy();

            }
            else
            {
                // 메시지가 이미 출력되어 있으면 제거해줘야 한다.
                this.ShowMessage(string.Empty);
            }
            SaveActionRecord("OPEN");
            #endregion

            base.OnShown(e);

            Type[] args = { typeof(object), typeof(EventArgs) };

            Type type = this.GetType();
            MethodInfo b1 = type.GetMethod("BtnReset_Click",      BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
            MethodInfo b2 = type.GetMethod("BtnQuery_Click",      BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
            MethodInfo b3 = type.GetMethod("BtnSave_Click",       BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
            MethodInfo b4 = type.GetMethod("BtnDelete_Click",     BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
            MethodInfo b5 = type.GetMethod("BtnPrint_Click",      BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
            MethodInfo b7 = type.GetMethod("BtnUpload_Click",     BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
            MethodInfo b8 = type.GetMethod("BtnProcess_Click",    BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);

            this._buttonsControl.BtnReset.Visible       = !b1.DeclaringType.Name.Equals("AxCommonBaseControl");
            this._buttonsControl.BtnQuery.Visible = !b2.DeclaringType.Name.Equals("AxCommonBaseControl");
            this._buttonsControl.BtnSave.Visible = !b3.DeclaringType.Name.Equals("AxCommonBaseControl");
            this._buttonsControl.BtnDelete.Visible = !b4.DeclaringType.Name.Equals("AxCommonBaseControl");
            this._buttonsControl.BtnPrint.Visible = !b5.DeclaringType.Name.Equals("AxCommonBaseControl");
            this._buttonsControl.BtnUpload.Visible = !b7.DeclaringType.Name.Equals("AxCommonBaseControl");
            this._buttonsControl.BtnProcess.Visible = !b8.DeclaringType.Name.Equals("AxCommonBaseControl");

            Showned = true;
        }

        private void ApplySecurityContext()
        {
            // 다른 컨트롤의 Visible 처리
            _buttonsControl.BtnUpload.Visible = (this.SecurityContext.CanUpload) ? true : false;
            _buttonsControl.BtnDownload.Visible = (this.SecurityContext.CanDownload) ? true : false;
            _buttonsControl.BtnPrint.Visible = (this.SecurityContext.CanPrint) ? true : false;
            _buttonsControl.BtnProcess.Visible = (this.SecurityContext.CanProcess) ? true : false;
            _buttonsControl.BtnReset.Visible = (this.SecurityContext.CanReset) ? true : false;
            _buttonsControl.BtnDelete.Visible = (this.SecurityContext.CanDelete) ? true : false;
            _buttonsControl.BtnSave.Visible = (this.SecurityContext.CanSave) ? true : false;
            _buttonsControl.BtnQuery.Visible = (this.SecurityContext.CanSelect) ? true : false;
        }

        

        /// <summary>
        /// HeUserInfo 타입의 사용자정보를 가져옵니다.
        /// </summary>
        protected new AxUserInfo UserInfo
        {
            get { return StaticUserInfoContext.GetUserInfo(this.GetType().Name.IndexOf("MP")); }
        }

        #region Description: 팝업 프로퍼티      

        /// <summary>
        /// HECommonBaseControl 클래스의 인스턴스화 유무를 가져오거나 설정합니다.
        /// </summary>
        protected bool IsCreated
        {
            get { return _IsCreated; }
            set { _IsCreated = value; }
        }

        /// <summary>
        /// 선택된 데이타를 가져오거나 설정합니다.
        /// </summary>
        public object SelectedData
        {
            get { return _SelectedData; }
            set { _SelectedData = value; }
        }

        #endregion

        #region Description: 공용 메서드 모음   

        /// <summary>
        /// 인자로 받은 날짜형태의 문자를 DateTime 타입으로 형변환하여 반환합니다.
        /// </summary>
        protected DateTime GetFromDateTime(object value)
        {
            return AxStaticCommon.GetFromDateTime(value);
        }

        /// <summary>
        /// 인자로 받은 날짜(문자형)를 년도내 주차정보 구해 반환합니다.
        /// </summary>
        protected int GetWeekOfYear(string date)
        {
            return AxStaticCommon.GetWeekOfYear(date);
        }

        /// <summary>
        /// 인자로 받은 시간간격을 TimeSpan 타입으로 형변환하여 반환합니다.
        /// </summary>
        protected TimeSpan GetFromTrimSpan(string span)
        {
            return AxStaticCommon.GetFromTrimSpan(span);
        }

        /// <summary>
        /// 인자로 받은 value 값이 null 일 경우 replace 인자로 대처되어 반환됩니다.
        /// </summary>
        protected object Nvl(object value, object replace)
        {
            return AxStaticCommon.Nvl(value, replace);
        }

        /// <summary>
        /// 인자로 받은 문자의 바이트 수를 반환합니다.
        /// </summary>
        protected int GetByteCount(string text)
        {
            return AxStaticCommon.GetByteCount(text);
        }

        /// <summary>
        /// 인수로 받은 컬럼명들을 기준으로 하여 새로운 DataSet을 만들어 반환합니다.
        /// </summary>
        protected DataSet GetDataSourceSchema(params string[] parameters)
        {
            return AxStaticCommon.GetDataSourceSchema(parameters);
        }

        /// <summary>
        /// HEUserControlBase 타입의 클래스를 윈도우로 노출합니다.
        /// </summary>
        protected void ShowPopup(HEUserControlBase frm)
        {
            AxStaticCommon.ShowPopup(frm);
        }

        /// <summary>
        /// HEUserControlBase 타입의 클래스를 윈도우로 노출 후 반환합니다.
        /// </summary>
        protected Form ShowPopup1(HEUserControlBase frm)
        {
            return AxStaticCommon.ShowPopup(frm);
        }

        /// <summary>
        /// 프로그램의 접근권한을 체크합니다.
        /// </summary>
        protected bool Access_Commit(params string[] possbleList)
        {
            bool denied = true;
            for (int i = 0; i < possbleList.Length; i++)
                if (this.UserInfo.EmpNo.Equals(possbleList[i]))
                {
                    denied = false;
                    break;
                }

            if (denied)
            {
                Panel _BPnl = new Panel();
                _BPnl.BackColor = System.Drawing.Color.WhiteSmoke;
                _BPnl.Location = new System.Drawing.Point(0, 0);
                _BPnl.Name = "_BPnl";
                _BPnl.Size = new System.Drawing.Size(9999, 9999);
                _BPnl.TabIndex = 3;

                Controls.Add(_BPnl);
                Controls.SetChildIndex(_BPnl, 0);
                MessageBox.Show("\r\n해당 프로그램에 접근할 수 있는 권한이 없습니다.\r\n");
            }

            return denied;
        }

        /// <summary>
        /// 인수로 받은 데이타소스의 데이타 수를 메인컨테이너의 상태표시줄에 표시합니다.
        /// </summary>
        protected void ShowDataCount(DataSet ds)
        {
            ShowDataCount(ds, 0);
        }

        /// <summary>
        /// 인수로 받은 데이타소스의 데이타 수를 메인컨테이너의 상태표시줄에 표시합니다.
        /// </summary>
        protected void ShowDataCount(DataSet ds, int iTableIndex)
        {
            if (ds.Tables[iTableIndex].Rows.Count == 0)
            {
                _StatusMessage = TheOne.Text.MessageManager.GetMessage("CD00-0039");
                ShowMessage(_StatusMessage);
            }
            else
            {
                _StatusMessage = string.Format(TheOne.Text.MessageManager.GetMessage("FX00-0002"), string.Format("{0:###,###,###,###}", ds.Tables[iTableIndex].Rows.Count));
                ShowMessage(_StatusMessage);
            }
        }

        /// <summary>
        /// 인수로 받은 데이타소스의 데이타 수를 메인컨테이너의 상태표시줄에 표시합니다.
        /// </summary>
        protected void ShowDataCount(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                _StatusMessage = TheOne.Text.MessageManager.GetMessage("CD00-0039");
                ShowMessage(_StatusMessage);
            }
            else
            {
                _StatusMessage = string.Format(TheOne.Text.MessageManager.GetMessage("FX00-0002"), string.Format("{0:###,###,###,###}", dt.Rows.Count));
                ShowMessage(_StatusMessage);
            }
        }

        /// <summary>
        /// 메인컨테이너의 상태표시줄에 메시지를 표시합니다.
        /// </summary>
        protected void setStatusMessage(object sender, EventArgs e)
        {
            ShowMessage(_StatusMessage);
        }

        /// <summary>
        /// HEDialogResult 타입의 인풋박스를 반환합니다.
        /// </summary>
        protected HEDialogResult ShowInputBox(string title, string promptText, string value)
        {
            return AxInputBox.ShowInputBox(title, promptText, value);
        }

        /// <summary>
        /// 필수요소의 라벨에 대한 마킹을 합니다.
        /// </summary>
        protected void SetRequired(params AxLabel[] Labels)
        {
            foreach (AxLabel lbl in Labels)
            {
                lbl.Image = global::Ax.DEV.Utility.Properties.Resources.required;
                lbl.ImageAlign = ContentAlignment.TopRight;                
            }
        }

        /// <summary>
        /// 필수요소의 라벨에 대한 마킹 해제을 합니다.
        /// </summary>
        protected void SetRemoveRequired(params AxLabel[] Labels)
        {
            foreach (AxLabel lbl in Labels)
            {
                lbl.Image = null;
                lbl.ImageAlign = ContentAlignment.TopRight;
            }
        }

        /// <summary>
        /// 본 프로젝트에서 사용하는 ReportClass 를 ReportViewer를 통해서 불러옵니다.
        /// </summary>
        //protected void ReportCall(ReportClass report)
        //{
        //    HEStaticCommon.ReportCall(report);
        //}

        #endregion

        #region Description: 공용 서비스 모음   
        
        /// <summary>
        /// 클래스ID를 가지고 해당하는 유형코드를 반환합니다.
        /// </summary>
        protected DataSet GetTypeCode(string classID)
        {
            return AxStaticCommon.GetTypeCode(classID);
        }

        /// <summary>
        /// 인자로 받은 클래스ID의 수만큼의 유형코드를 반환합니다.
        /// </summary>
        protected DataSet GetTypeCode(params string[] classIDList)
        {
            return AxStaticCommon.GetTypeCode(classIDList);
        }

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 라인코드를 반환합니다.
        /// </summary>
        protected DataSet GetLineCode()
        {
            return AxStaticCommon.GetLineCode(this.UserInfo.CorporationCode,this.UserInfo.BusinessCode,this.UserInfo.Language);
        }

        /// <summary>
        /// 다국어 언어 테이블에서 특정 코드를 찾을 때 사용하는 메서드
        /// </summary>
        /// <param name="findKey"></param>
        /// <returns></returns>
        public string GetLabel(string findKey)
        {

            return LanguageHelper.GetLabel(_dtLanInfo, findKey);
        }        

        /// <summary>
        /// 로그인한 사용자의 로그인 정보를 기준으로 ALC 코드의 Partno를 반환합니다.
        /// </summary>
        //protected DataSet GetALCCode_ByPartNo(string partNo)
        //{
        //    return HEStaticCommon.GetALCCode_ByPartNo(this.UserInfo.CorporationCode,this.UserInfo.BusinessCode,this.UserInfo.Language,partNo);
        //}

        /// <summary>
        /// 한일이화의 회사코드를 반환합니다.
        /// </summary>
        protected DataSet GetCorCD()
        {
            return AxStaticCommon.GetCorCD();
        }

        /// <summary>
        /// 회사코드를 조건으로 검색하여 사업장코드를 반환합니다.
        /// </summary>
        protected DataSet GetBizCD(string corcd)
        {
            return AxStaticCommon.GetBizCD(corcd);
        }

        /// <summary>
        /// 인자로 받은 회사코드를 조건으로 검색하여 고객사코드를 반환합니다.
        /// </summary>
        protected DataSet GetCustCD(string corcd)
        {
            return AxStaticCommon.GetCustCD(corcd);
        }

        /// <summary>
        /// 회사코드를 조건으로 검색하여 업체코드를 반환합니다.
        /// </summary>
        protected DataSet GetVendCD(string corcd)
        {
            return AxStaticCommon.GetVendCD(corcd);
        }

        /// <summary>
        /// 회사코드, 사업장코드를 조건으로 검색하여 야드번호를 반환합니다.
        /// </summary>
        protected DataSet GetYardNo(string corcd, string bizcd)
        {
            return AxStaticCommon.GetYardNo(corcd, bizcd);
        }

        /// <summary>
        /// 회사코드, 사업자코드를 조건으로 검색하여 사원정보를 반환합니다.
        /// </summary>
        protected DataSet GetEmployeeNo(string corcd, string bizcd)
        {
            return AxStaticCommon.GetEmployeeNo(corcd, bizcd);
        }

        /// <summary>
        /// 회사코드, 사업장코드, 기간에 메뉴ID의 잠금유무를 bool 타입으로 반환합니다.
        /// </summary>
        protected bool GetIsLocked(string corcd, string bizcd, string yymmFrom, string yymmTo, string menuid)
        {
            return AxStaticCommon.GetIsLocked(corcd, bizcd, yymmFrom, yymmTo, menuid);
        }

        ///// <summary>
        ///// 로그인 사용자의 회사정보와 인자로 받은 나머지 정보에 해당하는 어클리케이션폼ID를 반환합니다.
        ///// </summary>
        //protected DataSet GetAppformID(string program_id, string sector, bool runmode)
        //{
        //    return AxStaticCommon.GetAppformID(program_id, sector, runmode);
        //}

        /// <summary>
        /// 한일폴란드의 내부공장 정보를 반환합니다.
        /// </summary>
        //public DataSet GetPlantcd(string corcd, string bizcd)
        //{
        //    return AxStaticCommon.GetPlantcd(corcd, bizcd);
        //}

        ///// <summary>
        ///// HEPS 시스템의 결재정보를 인자로 받아 물류시스템에 반영합니다.
        ///// </summary>
        //protected void SetLegacyInstance(string pid, string eid, string fid, string title, string legacy_key)
        //{
        //    AxStaticCommon.SetLegacyInstance(pid, eid, fid, title, legacy_key);
        //}

        /// <summary>
        /// 시스템 환경정보를 반환합니다.
        /// </summary>
        protected string GetSysEnviroment(string section, string envname)
        {
            return AxStaticCommon.GetSysEnviroment(section, envname);
        }

        /// <summary>
        /// 시스템 환경정보를 설정합니다.
        /// </summary>
        protected void SetSysEnviroment(string section, string envname, string envvalue)
        {
            AxStaticCommon.SetSysEnviroment(section, envname, envvalue);
        }

        /// <summary>
        /// 사용자 환경정보를 반환합니다.
        /// </summary>
        protected string GetUserEnviroment(string userid, string envname)
        {
            return AxStaticCommon.GetUserEnviroment(userid, envname);
        }

        /// <summary>
        /// 사용자 환경정보를 설정합니다.
        /// </summary>
        protected void SetUserEnviroment(string userid, string envname, string envvalue)
        {
            AxStaticCommon.SetUserEnviroment(userid, envname, envvalue);
        }

        ///// <summary>
        ///// 리포트를 노출하는데 필요한 콤포넌트들이 설치되지 않았을 경우 설치할 수 있도록 유도합니다.
        ///// </summary>
        //protected void GetReportSetup()
        //{
        //    Thread thread1 = new Thread(new ThreadStart(ReportSetupFileDownload));
        //    //Thread thread2 = new Thread(new ThreadStart(OfficeViewerSetupFileDownload));
        //    thread1.Start();
        //    //thread2.Start();
        //}

        //private void ReportSetupFileDownload()
        //{
        //    try
        //    {
        //        // 리포트 구성요소를 설치하는 메서드로써 인터넷이 되는 곳에서만 작동한다.
        //        // HEStaticCommon.GetReportSetup();

        //        if (!System.IO.File.Exists(@"C:\Program Files\Business Objects\Common\2.8\bin\commonobjmodel.dll"))
        //        {
        //            string REPORTDIRECT = @"C:\ReportViewer";
        //            string REPORTVIEWER = @"C:\ReportViewer\ReportViewer.msi";

        //            if (IntPtr.Size == 4)
        //            {
        //                if (!File.Exists(REPORTVIEWER) || (new FileInfo(REPORTVIEWER)).Length != (long)17964544)
        //                {
        //                    if (!Directory.Exists(REPORTDIRECT))
        //                        Directory.CreateDirectory(REPORTDIRECT);

        //                    WebClient client = new WebClient();
        //                    client.DownloadFile(@"http://erm.seoyoneh.com.mx/crviewer/crredist2008_x86.msi", REPORTVIEWER);

        //                    while ((new FileInfo(REPORTVIEWER)).Length != (long)17964544)
        //                        Thread.Sleep(1000);
        //                }
        //            }
        //            else if (IntPtr.Size == 8)
        //            {
        //                if (!File.Exists(REPORTVIEWER) || (new FileInfo(REPORTVIEWER)).Length != (long)25330176)
        //                {
        //                    if (!Directory.Exists(REPORTDIRECT))
        //                        Directory.CreateDirectory(REPORTDIRECT);

        //                    WebClient client = new WebClient();
        //                    client.DownloadFile(@"http://erm.seoyoneh.com.mx/crviewer/crredist2008_x64.msi", REPORTVIEWER);

        //                    while ((new FileInfo(REPORTVIEWER)).Length != (long)25330176)
        //                        Thread.Sleep(1000);
        //                }
        //            }
        //            else
        //            {
        //            }
        //            StringBuilder builer = new StringBuilder();
        //            builer.Append("The components required to print the report has not been installed.\r\n\r\n");
        //            builer.Append("The message window is closed, the installation program will automatically run.\r\n\r\n\r\n\r\n");
        //            builer.Append("※ Click on the Next button, please re-run the ERM after installing all the components.");
        //            MessageBox.Show(this, builer.ToString());

        //            Thread.Sleep(500);
        //            System.Diagnostics.Process.Start(REPORTVIEWER);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}

        //private void OfficeViewerSetupFileDownload()
        //{
        //    try
        //    {
        //        //if (Application.ExecutablePath.IndexOf("Ax.SIS.QA") > -1) return;

        //        if (!this.ProgramID.Contains("QA")) return;

        //        if (!System.IO.File.Exists(@"C:\DsoFramer\dsoframer.ocx"))
        //        {
        //            string OFFICEDIRECT = @"C:\DsoFramer";
        //            string OFFICEVIEWER = @"C:\DsoFramer\DsoFramer_KB311765_x86.exe";

        //            if (IntPtr.Size == 4)
        //            {
        //                if (!File.Exists(OFFICEVIEWER) || (new FileInfo(OFFICEVIEWER)).Length != (long)488568)
        //                {
        //                    if (!Directory.Exists(OFFICEDIRECT))
        //                        Directory.CreateDirectory(OFFICEDIRECT);

        //                    WebClient client = new WebClient();
        //                    client.DownloadFile(@"http://erm.hanileh.com/ERM/ClickOnce/OFCViewer/DsoFramer_KB311765_x86.exe", OFFICEVIEWER);

        //                    while ((new FileInfo(OFFICEVIEWER)).Length != (long)488568)
        //                        Thread.Sleep(1000);
        //                }

        //                StringBuilder builer = new StringBuilder();
        //                builer.Append("본 컴퓨터에는 오피스 뷰어를 구동하기 위해 필요한 구성요소가 설치되지 않았습니다.\r\n\r\n");
        //                builer.Append("해당 메시지 창이 닫히면 자동으로 설치프로그램이 실행됩니다.\r\n\r\n\r\n\r\n");
        //                builer.Append("※ 다음버튼을 눌러 구성요소를 모두 설치 후 ERM을 다시 실행하시기 바랍니다.");
        //                MessageBox.Show(this, builer.ToString());

        //                Thread.Sleep(500);
        //                System.Diagnostics.Process.Start(OFFICEVIEWER);
        //            }
        //            else if (IntPtr.Size == 8)
        //            {
        //                StringBuilder builer = new StringBuilder();
        //                builer.Append("64비트 운영체제에서는 오피스 뷰어를 구동하기 위해 필요한 구성요소가 동작하지 않습니다.\r\n\r\n");
        //                builer.Append("한일이화 전산팀으로 문의해주시기 바랍니다.");
        //                MessageBox.Show(this, builer.ToString());
        //            }
        //            else
        //            {
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}

        //2011.12.27일 추가 엑셀 버전 판별 메서드
        protected int ExcelFileType(string XlsFile)
        {
            // 요거이 비교할 파일 데이터 입니다.
            byte[,] ExcelHeader = {
                { 0xD0, 0xCF, 0x11, 0xE0, 0xA1 }, // XLS  File Header
                { 0x50, 0x4B, 0x03, 0x04, 0x14 }  // XLSX File Header
            };
            // result -2=error, -1=not excel , 0=xls , 1=xlsx
            int result = -1;
            FileInfo FI = new FileInfo(XlsFile);
            FileStream FS = FI.Open(FileMode.Open, FileAccess.Read);

            try
            {
                byte[] FH = new byte[5];
                FS.Read(FH, 0, 5);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (FH[j] != ExcelHeader[i, j]) break;
                        else if (j == 4) result = i;
                    }
                    if (result >= 0) break;
                }
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                result = (-2);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (FS != null)
                    FS.Close();
            }
            return result;
        }

        //2011.12.27일 추가 접근 가능 파일인지 판별
        protected bool IsVaildFile(string FilePath)
        {
            FileInfo FI = new FileInfo(FilePath);
            FileStream FS = null;

            try
            {
                FS = FI.Open(FileMode.Open);
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (FS != null)
                    FS.Close();
            }
            return true;
        }

        #endregion


        #region Description: 컨트롤의 탭인덱스 조정 및 엔터이동 처리

        private void IControlFactoryCollection(Control.ControlCollection controls)
        {
            if (controls.Count == 0) return;

            ArrayList outer = new ArrayList();
            for (int i = 0; i < controls.Count; i++)
            {
                Control control = controls[i];
                control.TabIndex = 0;
                if (control is IAxControl)
                {
                    if (control is AxCheckBox       || 
                        control is AxCodeBox        ||
                        control is AxComboBox       || 
                        control is AxDateEdit       || 
                        control is AxNumericEdit    || 
                        control is AxRadioButton    || 
                        control is AxTextBox)
                        _ControlFactory.Add((IAxControl)control);

                    if (control is AxDateEdit)
                        ((AxDateEdit)control).SetLanguageCustomFormat();

                    if (control is AxNumericEdit)
                        ((AxNumericEdit)control).SetLanguageCustomFormat();
                }
                else
                    outer.Add(control);
            }

            for (int i = 0; i < outer.Count; i++)
                this.IControlFactoryCollection(((Control)outer[i]).Controls);
        }

        private void IControlFactoryCollectionTabIndexSorting()
        {
            ArrayList newFactorySortingList = new ArrayList();
            for (int i = 0; i < _ControlFactory.Count; i++)
            {
                Control control = (Control)_ControlFactory[i];
                newFactorySortingList.Add(String.Format("{0}#{1}", 
                    this.GetControlAllSumPoint(control), control.Name));
            }

            newFactorySortingList.Sort();
            ControlFactoryList newFactoryList = new ControlFactoryList();
            for (int i = 0; i < newFactorySortingList.Count; i++)
            {
                string[] item   = newFactorySortingList[i].ToString().Split('#');
                Control control = _ControlFactory.GetControl(item[2]);
                if (control != null)
                {
                    control.TabIndex = (i + 1) * 2;
                    newFactoryList.Add(control);
                }
            }

            _ControlFactory = newFactoryList;
        }

        private string GetControlAllSumPoint(Control control)
        {
            Point point  = control.Location;
            string group = String.Format("#{0:0000}-{1:0000}", 
                Math.Ceiling(point.Y * 0.1), 
                Math.Ceiling(point.X * 0.1));

            while (control.Parent != null)
            {
                control = (Control)control.Parent;
                point   = control.Location;
                group   = String.Format("{0:0000}-{1:0000}-{2}", 
                    Math.Ceiling(point.Y * 0.1), 
                    Math.Ceiling(point.X * 0.1), group);
            }

            return group;
        }

        private void IControlSequenceCollectionEnterKeySetting()
        {
            for (int i = 0; i < _ControlFactory.Count; i++)
            {
                Control control = (Control)_ControlFactory[i];
                if (control.Visible)
                {
                    if (control is AxTextBox)
                    {
                        if (control is AxCodeBox && control.Enabled)
                        {
                            _ControlSequenceList.Add((Control)((AxCodeBox)control).CodeTextBox);
                            _ControlSequenceList.Add(control);
                        }
                        else
                        {
                            AxTextBox textbox = (AxTextBox)control;
                            if (!textbox.ReadOnly && control.Enabled)
                                _ControlSequenceList.Add(control);
                        }
                    }
                    else
                    {
                        if (control.Enabled)
                            _ControlSequenceList.Add(control);
                    }
                }
            }

            for (int i = 0; i < _ControlSequenceList.Count; i++)
                _ControlSequenceList[i].KeyUp += new KeyEventHandler(control_KeyUp);
        }

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control control = (Control)sender;
                if (control is AxTextBox && !(control is AxCodeBox))
                    if (((AxTextBox)control).Multiline)
                        return;

                int index = _ControlSequenceList.IndexOf(control);

                index = (index == _ControlSequenceList.Count - 1) ? 0 : index + 1;
                _ControlSequenceList[index].Focus();
            }
        }

        #endregion




        #region "HECommonUserControl"
        

        /// <summary>
        /// 단축키 처리를 위해 Key 이벤트를 가로챔
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bStop = false;

            //포커스 강제 이동 - 단축키 입력시 그리드나 기타 컨트롤의 편집중인 내용이 확정되도록
            Type type = this.GetType();
            Type[] args = { typeof(object), typeof(EventArgs) };

            switch (keyData)
            {
                case Keys.F2:
                    //포커스 강제 이동
                    MethodInfo b2 = type.GetMethod("BtnQuery_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b2.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnQuery.Focus();
                    }

                    BtnQuery_Click(null, null);
                    bStop = true;
                    break;
                case Keys.F3:
                    //포커스 강제 이동
                    MethodInfo b3 = type.GetMethod("BtnReset_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b3.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnReset.Focus();
                    }
                    BtnReset_Click(null, null);
                    bStop = true;
                    break;
                case Keys.F4:
                    //포커스 강제 이동
                    MethodInfo b4 = type.GetMethod("BtnSave_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b4.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnSave.Focus();
                    }
                    BtnSave_Click(null, null);
                    bStop = true;
                    break;
                case Keys.F5:
                    //포커스 강제 이동
                    MethodInfo b5 = type.GetMethod("BtnDelete_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b5.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnDelete.Focus();
                    }
                    BtnDelete_Click(null, null);
                    bStop = true;
                    break;
                case Keys.F6:
                    //포커스 강제 이동
                    MethodInfo b6 = type.GetMethod("BtnProcess_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b6.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnProcess.Focus();
                    }
                    BtnProcess_Click(null, null);
                    bStop = true;
                    break;
                case Keys.F7:
                    //포커스 강제 이동
                    MethodInfo b7 = type.GetMethod("BtnPrint_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b7.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnPrint.Focus();
                    }
                    BtnPrint_Click(null, null);
                    bStop = true;
                    break;
                case Keys.F8:
                    //포커스 강제 이동
                    MethodInfo b8 = type.GetMethod("BtnDownload_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b8.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnDownload.Focus();
                    }
                    BtnDownload_Click(null, null);
                    bStop = true;
                    break;
                case Keys.F9:
                    //포커스 강제 이동
                    MethodInfo b9 = type.GetMethod("BtnUpload_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b9.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnUpload.Focus();
                    }
                    BtnUpload_Click(null, null);
                    bStop = true;
                    break;
                case Keys.F10:
                    // 종료 버튼
                    //포커스 강제 이동
                    MethodInfo b10 = type.GetMethod("BtnClose_Click", BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
                    if (!b10.DeclaringType.Name.Equals("AxCommonBaseControl"))
                    {
                        this._buttonsControl.BtnClose.Focus();
                    }
                    BtnClose_Click(null, null);
                    _buttonsControl.CloseUIScreen();
                    bStop = true;
                    break;
                case Keys.F11:
                    // 도움말 버튼
                    _buttonsControl.ShowHelpWindow();
                    bStop = true;
                    break;
                case Keys.F12:
                    // 풀스크린 처리 by 2016.11.07 김건우 추가
                    if (this.FullScreenModeAllow) fullScreenHelper.ExecuteFullScreen();
                    break;
                default:
                    break;
            }

            if (bStop)
            {
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        
        #endregion

        #region "HECommonUserControl"

        protected new HESecurityContext SecurityContext
        {
            get { return base.SecurityContext as HESecurityContext; }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected virtual void BtnSave_Click(object sender, EventArgs e)
        {

        }

        protected virtual void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected virtual void BtnQuery_Click(object sender, EventArgs e)
        {

        }

        protected virtual void BtnPrint_Click(object sender, EventArgs e)
        {

        }

        protected virtual void BtnProcess_Click(object sender, EventArgs e)
        {

        }

        protected virtual void BtnReset_Click(object sender, EventArgs e)
        {

        }

        protected virtual void BtnDownload_Click(object sender, EventArgs e)
        {

        }

        protected virtual void BtnUpload_Click(object sender, EventArgs e)
        {

        }

        protected virtual void BtnClose_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region [ 별도 메서드 ]

        /// <summary>
        /// 공통 버튼 컨트롤을 초기화한다.
        /// </summary>
        private void InitializeCommonButton()
        {
            _buttonsControl = new AxCommonButtonControl();
            _buttonsControl.Name = "CommonButtons";
            _buttonsControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _buttonsControl.Dock = DockStyle.Top;
            _buttonsControl.TabIndex = 0;

            this.QueryControls.Add(_buttonsControl.BtnQuery);
            this.SaveControls.Add(_buttonsControl.BtnSave);
            this.DeleteControls.Add(_buttonsControl.BtnDelete);

            this._buttonsControl.ParentControl = this;
            this.Controls.Add(this._buttonsControl);

            // 버튼 이벤트 할당
            this._buttonsControl.BtnSave.Click += delegate(object sender, EventArgs e)
            {
                SaveActionRecord("SAVE");
                BtnSave_Click(sender, e);
            };
            this._buttonsControl.BtnDelete.Click += delegate(object sender, EventArgs e)
            {
                SaveActionRecord("DELETE");
                BtnDelete_Click(sender, e);
            };
            this._buttonsControl.BtnQuery.Click += delegate(object sender, EventArgs e)
            {
                SaveActionRecord("QUERY");
                BtnQuery_Click(sender, e);
            };
            this._buttonsControl.BtnPrint.Click += new EventHandler(BtnPrint_Click);
            this._buttonsControl.BtnProcess.Click += delegate(object sender, EventArgs e)
            {
                SaveActionRecord("PROCESS");
                BtnProcess_Click(sender, e);
            };
            //new EventHandler(BtnProcess_Click);
            this._buttonsControl.BtnReset.Click += new EventHandler(BtnReset_Click);
            this._buttonsControl.BtnDownload.Click += delegate(object sender, EventArgs e)
            {
                SaveActionRecord("DOWNLOAD");
                BtnDownload_Click(sender, e);
            };
            this._buttonsControl.BtnUpload.Click += delegate(object sender, EventArgs e)
            {
                SaveActionRecord("UPLOAD");
                BtnUpload_Click(sender, e);
            };

            this._buttonsControl.BtnClose.Click += delegate(object sender, EventArgs e)
            {
                SaveActionRecord("CLOSE");
                BtnClose_Click(sender, e);
                _buttonsControl.CloseUIScreen();
            };
            
        }

        /// <summary>
        /// 다국어 관련 데이터 가져오는 메서드
        /// </summary>
        private DataSet GetUIData()
        {
            try
            {
                // FX00-0012 : 초기 화면 구성 정보를 조회중입니다.
                this.BeforeInvokeServer(MessageManager.GetMessage("FX00-0012"));
                return LanguageHelper.GetUIData(this.Name, this.UserInfo.Language);

                
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        /// <summary>
        /// 사용자의 액션 로그 정보를 저장한다.
        /// </summary>
        /// <param name="actionName">사용자의 액션 형태</param>
        private void SaveActionRecord(string actionName)
        {
            try
            {
                if (System.AppDomain.CurrentDomain.FriendlyName.Equals("UI.TestContainer.exe"))
                    return;

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("MENUID", this.Name);
                    paramSet.Add("SYSTEMCODE", this.UserInfo.SystemCode);
                    paramSet.Add("USERID", this.UserInfo.UserID);
                    paramSet.Add("IP", this.UserInfo.UserIP);
                    paramSet.Add("ACTIONNAME", actionName);
                    //paramSet.Add("LOGDATE", DateTime.Now);

                    proxy.ExecuteNonQueryTx("APG_FXSERVICE.INSERTACTIONLOG", paramSet);
                }
            }
            catch
            {
                // 예외 무시
                // 로그인 시간 기록에 실패하더라도,
                // 프로그램을 실행하는 부분에는 영향을 주면 안된다.
            }
        }

        /// <summary>
        /// 공통 버튼을 반환하는 메서드
        /// </summary>
        /// <param name="commonButtonType"></param>
        /// <returns></returns>
        protected C1Button GetCommonButton(COMMONBUTTONTYPE commonButtonType)
        {
            C1Button btnInfo = null;

            switch (commonButtonType)
            {
                case COMMONBUTTONTYPE.SAVE:
                    btnInfo = _buttonsControl.BtnSave;
                    break;
                case COMMONBUTTONTYPE.DELETE:
                    btnInfo = _buttonsControl.BtnDelete;
                    break;
                case COMMONBUTTONTYPE.QUERY:
                    btnInfo = _buttonsControl.BtnQuery;
                    break;
                case COMMONBUTTONTYPE.PRINT:
                    btnInfo = _buttonsControl.BtnPrint;
                    break;
                case COMMONBUTTONTYPE.PROCESS:
                    btnInfo = _buttonsControl.BtnProcess;
                    break;
                case COMMONBUTTONTYPE.RESET:
                    btnInfo = _buttonsControl.BtnReset;
                    break;
                case COMMONBUTTONTYPE.DOWNLOAD:
                    btnInfo = _buttonsControl.BtnDownload;
                    break;
                case COMMONBUTTONTYPE.UPLOAD:
                    btnInfo = _buttonsControl.BtnUpload;
                    break;
                case COMMONBUTTONTYPE.CLOSE:
                    btnInfo = _buttonsControl.BtnClose;
                    break;
            }

            return btnInfo;
        }

        #endregion        


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AxCommonBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Name = "AxCommonBaseControl";
            this.Size = new System.Drawing.Size(1024, 768);
            this.ResumeLayout(false);

        }
    }
    	/// <summary>
	/// 공통 버튼 타입을 정의하는 열거형
	/// </summary>
	public enum COMMONBUTTONTYPE 
	{
		SAVE = 1,
		DELETE = 2,
		QUERY = 3,
		PRINT = 4,
		PROCESS = 5,
		RESET = 6,
		DOWNLOAD = 7,
		UPLOAD = 8,
        CLOSE = 9
	}
}

