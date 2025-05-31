using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;

using HE.Framework.Core;
using TheOne.Text;
using HE.Framework.Windows.Forms;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// 한일이화 물류 시스템에서 사용하는 팝업 베이스 컨트롤입니다.
    /// </summary>
    public class AxCommonPopupControl : HEUserControlBase, IPopupControl
    {
        private bool _IsCreated;
        private object _SelectedData;
        private string _PrefixCode;
        private AxCodeBox _AxCodeBox;
        private ControlFactoryList _ControlFactory;
        private ControlSequenceList _ControlSequenceList;

        private DataTable _dtLanInfo;
        private DataTable _dtGridInfo;
        private DataTable _dtGridHeaderInfo;

        public AxCommonPopupControl()
            : base()
        {
            this.Load += new EventHandler(HECommonPopupControl_Load);

            _AxCodeBox = null;
            _IsCreated = false;
            _PrefixCode = "";
            _ControlFactory = new ControlFactoryList();
            _ControlSequenceList = new ControlSequenceList();
            this.Initialize_Property();

            this.LostFocus += new EventHandler(HECommonPopupControl_LostFocus);
        }

        protected override void OnShown(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 메시지가 이미 출력되어 있으면 제거해줘야 한다.
                this.ShowMessage(string.Empty);

                // 다국어 관련 데이터 가져오기
                DataSet dsUIData = GetUIData();

                // C1 관련 컨트롤 찾기
                LanguageHelper.InitializeC1Control(this.Controls,
                    dsUIData.Tables[0], dsUIData.Tables[1], dsUIData.Tables[2]);
                
                _dtLanInfo = dsUIData.Tables[0].Copy();
                _dtGridInfo = dsUIData.Tables[1].Copy();
                _dtGridHeaderInfo = dsUIData.Tables[2].Copy();

            }

            base.OnShown(e);
        }
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

        public string GetLabel(string findKey)
        {

            return LanguageHelper.GetLabel(_dtLanInfo, findKey);
        }


        private void HECommonPopupControl_LostFocus(object sender, EventArgs e)
        {
            if (_ControlFactory.Count > 0)
                ((Control)_ControlFactory[0]).Focus();
        }

        private void HECommonPopupControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                StaticUserInfoContext.UserInfoContext = base.UserInfo;

                this.IControlFactoryCollection(this.Controls);
                this.IControlFactoryCollectionTabIndexSorting();
                this.IControlSequenceCollectionEnterKeySetting();

                if (_ControlFactory.Count > 0)
                    ((Control)_ControlFactory[0]).Focus();
            }
        }

        /// <summary>
        /// HeUserInfo 타입의 사용자정보를 가져옵니다.
        /// </summary>
        protected new AxUserInfo UserInfo
        {
            get { return StaticUserInfoContext.GetUserInfo(this.GetType().Name.IndexOf("MP")); }
        }

        protected void CodeBox_HEParameterSetSetting(ref HEParameterSet set)
        {
            if (_AxCodeBox != null && !_AxCodeBox.GetDataSourceLock)
                if (_AxCodeBox.PrefixCode.Length > 0)
                    if (set[_AxCodeBox.CodeParameterName] != null)
                    {
                        string code = set[_AxCodeBox.CodeParameterName].ToString();
                        set[_AxCodeBox.CodeParameterName] = _AxCodeBox.GetOriginalCode(code);
                    }
        }

        protected DataTable CodeBox_GetDataSourceChange(DataSet source)
        {
            return CodeBox_GetDataSourceChange(source.Tables[0]);
        }

        protected DataTable CodeBox_GetDataSourceChange(DataTable source)
        {
            if (_AxCodeBox != null && !_AxCodeBox.GetDataSourceLock)
                if (_AxCodeBox.PrefixCode.Length > 0)
                    if (source.Columns.Contains(_AxCodeBox.CodeParameterName))
                    {
                        string cur_code = _AxCodeBox.CodeParameterName;
                        for (int i = 0; i < source.Rows.Count; i++)
                            source.Rows[i][cur_code] = _AxCodeBox.GetProcessCode(source.Rows[i][cur_code].ToString());
                    }
            return source;
        }

        #region Description: 팝업 프로퍼티

        /// <summary>
        /// HECommonPopupControl 클래스의 인스턴스화 유무를 가져오거나 설정합니다.
        /// </summary>
        protected bool IsCreated
        {
            get { return _IsCreated; }
            set { _IsCreated = value; }
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
            return AxStaticCommon.GetLineCode(this.UserInfo.CorporationCode, this.UserInfo.BusinessCode, this.UserInfo.Language);
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

        /// <summary>
        /// 로그인 사용자의 회사정보와 인자로 받은 나머지 정보에 해당하는 어클리케이션폼ID를 반환합니다.
        /// </summary>
        protected DataSet GetAppformID(string program_id, string sector, bool runmode)
        {
            return AxStaticCommon.GetAppformID(program_id, sector, runmode);
        }

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
                    if (control is AxCheckBox ||
                        control is AxCodeBox ||
                        control is AxComboBox ||
                        control is AxDateEdit ||
                        control is AxNumericEdit ||
                        control is AxRadioButton ||
                        control is AxTextBox)
                        _ControlFactory.Add((IAxControl)control);
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
                string[] item = newFactorySortingList[i].ToString().Split('#');
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
            Point point = control.Location;
            string group = String.Format("#{0:0000}-{1:0000}",
                Math.Ceiling(point.Y * 0.1),
                Math.Ceiling(point.X * 0.1));

            while (control.Parent != null)
            {
                control = (Control)control.Parent;
                point = control.Location;
                group = String.Format("{0:0000}-{1:0000}-{2}",
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

        #region IPopupControl 멤버

        public object SelectedData
        {
            get { return _SelectedData; }
            set { _SelectedData = value; }
        }

        public AxCodeBox CodeBox
        {
            get { return _AxCodeBox; }
            set { _AxCodeBox = value; }
        }

        public string PrefixCode
        {
            get { return _PrefixCode; }
            set { _PrefixCode = value; }
        }

        public new bool RequireAuthentication
        {
            get { return base.RequireAuthentication; }
            set { base.RequireAuthentication = value; }
        }

        public new bool RequireAuthorization
        {
            get { return base.RequireAuthorization; }
            set { base.RequireAuthorization = value; }
        }

        public void Initialize_Property()
        {
            _SelectedData = null;
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AxCommonPopupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Name = "AxCommonPopupControl";
            this.ResumeLayout(false);

        }

    }

}