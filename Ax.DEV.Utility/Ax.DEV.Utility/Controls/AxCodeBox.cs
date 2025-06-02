using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using System.Diagnostics;

namespace Ax.DEV.Utility.Controls
{
    ///#001 배명희 2013.11.12 _CodeValue 항목 추가함. 단순 포커스 이동시에는 Validation로직 진행되지 않도록 하기위함. (기존 코드값이 저장됨.)
    /// <summary>
    /// HETextBox 클래스를 상속받아 구현된 코드박스입니다.
    /// </summary>
    public class AxCodeBox : AxTextBox, IAxControl
    {
        private IAxPopupHelper _IHEPopupHelper;
        private AxTextBox _CodeTextBox;
        private AxButton  _PopupButton;
        private Point _Location;
        private bool _IsCreated;
        private int _CodeTextBoxWidth;
        private bool _CodeTextBoxVisible;
        private bool _NameTextBoxVisible;
        private bool _CodeTextBoxReadOnly;
        private bool _NameTextBoxReadOnly;
        private bool _CodeValidationCheck;
        private bool _GetDataSourceLock;
        private string _CodeParameterName;
        private string _NameParameterName;
        private string _PopupTitle;
        private string _PrefixCode;
        private int _CodePixedLength;
        private bool _CodeValidationEnabled;
        private SortedList _HEParameterDummy;
        private SortedList _HEUserParameterDummy;
        private DataRow _SelectedPopupValue;
        private Size _Size;
        private bool _Visible;

        private string _CodeValue;//코드값  #001

        #region Description: Event define

        /// <summary>
        /// 팝업 버튼클릭 이벤트 대리자입니다.
        /// </summary>
        public delegate void CButtonClickEventHandler(object sender, EventArgs args);

        /// <summary>
        /// 팝업 버튼을 클릭하고 난 후에 발생되는 이벤트 핸들러입니다.
        /// </summary>
        public event CButtonClickEventHandler ButtonClickAfter;

        /// <summary>
        /// 팝업 버튼을 클릭하기 전에 발생되는 이벤트 핸들러입니다.
        /// </summary>
        public event CButtonClickEventHandler ButtonClickBefore;

        /// <summary>
        /// 코드박스에 데이타를 바인딩하고 난 후에 발생되는 핸들러입니다.
        /// </summary>
        public event CButtonClickEventHandler CodeBoxBindingAfter;

        /// <summary>
        /// 팝업 버튼을 클릭하고 난 후에 발생되는 이벤트 입니다.
        /// </summary>
        public void OnButtonClickAfter(object sender, EventArgs e)
        {
            if (this.ButtonClickAfter != null)
                this.ButtonClickAfter(sender, e);
        }

        /// <summary>
        /// 팝업 버튼을 클릭하기 전에 발생되는 이벤트 입니다.
        /// </summary>
        public void OnButtonClickBefore(object sender, EventArgs e)
        {
            if (this.ButtonClickBefore != null)
                this.ButtonClickBefore(sender, e);
        }

        /// <summary>
        /// 코드박스에 데이타를 바인딩하고 난 후에 발생되는 입니다.
        /// </summary>
        public void OnCodeBoxBindingAfter(object sender, EventArgs e)
        {
            if (this.CodeBoxBindingAfter != null)
                this.CodeBoxBindingAfter(sender, e);
        }



        #endregion

        public AxCodeBox()
            : base()
        {
            _CodeTextBox = new AxTextBox();
            _PopupButton = new AxButton();

            // 윈도우 8이상에서 한글 끝자리 잘림 및 입력 후 포커스 손실시 데이터 날라가는 현상 방지 - 2019-11-25 김건우 추가
            this.Tag = "cdx";
            _CodeTextBox.Tag = "cdx";
            
            _CodeParameterName     = "CODE";
            _NameParameterName     = "NAME";
            _HEParameterDummy      = new SortedList();
            _HEUserParameterDummy  = new SortedList();
            _SelectedPopupValue    = null;
            _CodeValidationEnabled = true; //기본값 false에서 true로 변경. 2017-10-19
            _IsCreated             = false;

            _CodeTextBoxWidth      = 40;
            _CodeTextBoxVisible    = true;
            //2015-04-14 ReadOnly = true로 변경
            //_CodeTextBoxReadOnly   = false;
            _CodeTextBoxReadOnly = true;
            _NameTextBoxVisible    = true;
            _NameTextBoxReadOnly   = false;
            _CodeValidationCheck   = true;
            _GetDataSourceLock     = false;

            _PopupTitle            = "";
            _PrefixCode            = "";
            _CodePixedLength       = 0;
            _Location              = new Point(0, 0);
            _Size                  = new Size(0, 0);
            _Visible               = true;

            //코드박스 네임부분
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(HECodeBox_KeyUp);
            this.Leave += new System.EventHandler(HECodeBox_Leave);
            
            //코드박스 코드부분
            _CodeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(_CodeTextBox_KeyUp);
            _CodeTextBox.Leave += new System.EventHandler(_CodeTextBox_Leave);
            
            //코드박스 팝업부분
            _PopupButton.Click += new System.EventHandler(_PopupButton_Click);
            this.TabIndexChanged += new EventHandler(HECodeBox_TabIndexChanged);
        }

        private void HECodeBox_TabIndexChanged(object sender, EventArgs e)
        {
            if (this.TabIndex > 0)
            {
                _CodeTextBox.TabIndex = this.TabIndex - 1;
                _PopupButton.TabIndex = this.TabIndex + 1;
            }
        }

        #region IHEControl 멤버

        /// <summary>
        /// 선택된 코드값(OriginalCode)을 반환합니다.
        /// </summary>
        public new object GetValue()
        {
            //if (_PrefixCode.Equals("A3") && String.IsNullOrEmpty(_CodeTextBox.Text.Trim()))
            //{
            //    SetValue("TLE");
            //}

            //PrefixCode 값설정 시 CodeTextBox부분 값이 없을 시 PrefixCode 제거
            if (String.IsNullOrEmpty(this.CodeTextBox.Text.Trim()))
                return "";
            else
                return this.GetOriginalCode();
        }

        /// <summary>
        /// 선택된 오리지널 코드값(유형코드)을 반환합니다.
        /// </summary>
        private string GetOriginalCode()
        {
            return String.Format("{0}{1}", _PrefixCode, _CodeTextBox.GetValue());
        }

        /// <summary>
        /// 인자로 받은 코드를 프리픽스 코드와 붙여 반환합니다.
        /// </summary>
        public string GetOriginalCode(string code)
        {
            return String.Format("{0}{1}", _PrefixCode, code);
        }

        /// <summary>
        /// 선택된 코드값(OriginalCode)을 반환합니다.
        /// </summary>
        public string GetProcessCode()
        {
            return this.GetProcessCode(_CodeTextBox.GetValue().ToString());
        }

        /// <summary>
        /// 인자로 받은 코드를 프리픽스 코드와 붙여 반환합니다.
        /// </summary>
        public string GetProcessCode(string code)
        {
            if (_PrefixCode.Length > 0 && _PrefixCode.Length < code.Length)
            {
                string fcode = code.Substring(0, _PrefixCode.Length).Replace(_PrefixCode, "");
                string ncode = code.Substring(_PrefixCode.Length);

                code = String.Format("{0}{1}", fcode, ncode);
            }

            return code;
        }

        /// <summary>
        /// 코드를 입력받아 유효성을 검사 후 코드와 코드명을 코드박스에 설정합니다.
        /// </summary>
        public new void SetValue(object value)
        {
            string valueCode  = this.GetProcessCode(value.ToString());
            string beforeCode = _CodeTextBox.GetValue().ToString();
            _CodeTextBox.SetValue(valueCode);

            if (_CodeTextBox.IsEmpty)
            {
                this.SetText("");
                this._CodeValue = "";//코드값 초기화  #001
                return;
            }

            if (!beforeCode.Equals(valueCode))
            {
                this.SetText("");
                this._CodeValue = "";//코드값 초기화 #001
                
                this.HECodeBox_Validation(null, null);                
            }
        }

        public new void Initialize()
        {
            this.SetText("");
            this.SetValue("");

            OnCodeBoxBindingAfter(this, null);
        }

        #endregion

        #region "프로퍼티"
        /// <summary>
        /// 코드박스의 코드영역에 위치한 텍스트박스를 가져옵니다.
        /// </summary>
        public AxTextBox CodeTextBox
        {
            get { return _CodeTextBox; }
        }

        /// <summary>
        /// 코드박스의 코드영역에 위치한 텍스트박스의 넓이를 가져오거나 설정합니다.
        /// 참고로 전체 넓이에서 코드영역의 텍스트박스 넓이를 뺀 부분이 코드명이 들어가는 텍스트박스의 넓이입니다.
        /// </summary>
        public int CodeTextBoxWidth
        {
            get { return _CodeTextBoxWidth; }
            set { _CodeTextBoxWidth = value; }
        }

        /// <summary>
        /// 코드박스의 코드영역에 위치한 텍스트박스의 숨김여부를 가져오거나 설정합니다.
        /// </summary>
        public bool CodeTextBoxVisible
        {
            get { return _CodeTextBoxVisible; }
            set { _CodeTextBoxVisible = value; }
        }

        /// <summary>
        /// 코드박스의 코드영역에 위치한 텍스트박스의 읽기전용 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool CodeTextBoxReadOnly
        {
            get { return _CodeTextBoxReadOnly; }
            set { _CodeTextBoxReadOnly = value; }
        }

        /// <summary>
        /// 코드박스의 코드명 영역에 위치한 텍스트박스의 숨김여부를 가져오거나 설정합니다.
        /// </summary>
        public bool NameTextBoxVisible
        {
            get { return _NameTextBoxVisible; }
            set { _NameTextBoxVisible = value; }
        }

        /// <summary>
        ///  코드박스의 코드명 영역에 위치한 텍스트박스의 읽기전용 여부를 가져오거나 설정합니다.
        /// </summary>
        /// <remarks>
        /// NameTextBox부분에 ReadOnly 속성 추가
        /// </remarks>
        public bool NameTextBoxReadOnly
        {
            get { return _NameTextBoxReadOnly; }
            set 
            { 
                _NameTextBoxReadOnly = value;
                base.ReadOnly = _NameTextBoxReadOnly;                                
            }
        }

        /// <summary>
        /// 코드박스에 바인딩 되어있는 데이타소스의 잠금여부를 가져옵니다.
        /// </summary>
        public bool GetDataSourceLock
        {
            get { return _GetDataSourceLock; }
        }

        /// <summary>
        /// 팝업버튼의 읽기전용 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool PopupButtonReadOnly
        {
            get { return !_PopupButton.Enabled; }
            set { _PopupButton.Enabled = !value; }
        }

        /// <summary>
        /// 코드박스의 숨김여부를 가져오거나 설정합니다.
        /// </summary>
        public new bool Visible
        {
            get { return base.Visible; }
            set
            {
                base.Visible = value;
                _Visible = value;
                this.CreateCodeBoxControl();
            }
        }

        /// <summary>
        /// 코드박스의 위치를 가져오거나 설정합니다.
        /// </summary>
        public new Point Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        /// <summary>
        /// 코드박스의 사이즈를 가져오거나 설정합니다.
        /// </summary>
        public new Size Size
        {
            get { return this.DesignMode ? base.Size : _Size; }
            set
            {
                if (this.DesignMode)
                    base.Size = value;
                else
                    _Size = value;
            }
        }

        /// <summary>
        /// 팝업 윈도우가 나타날때 상단 타이틀을 가져오거나 설정합니다.
        /// </summary>
        public string PopupTitle
        {
            get { return _PopupTitle; }
            set { _PopupTitle = value; }
        }

        /// <summary>
        /// 코드박스에 바인딩 될 코드파라메터를 가져오거나 설정합니다.
        /// </summary>
        public string CodeParameterName
        {
            get { return _CodeParameterName; }
            set { _CodeParameterName = value; }
        }

        /// <summary>
        /// 코드박스에 바인딩 될 명파라메터를 가져오거나 설정합니다.
        /// </summary>
        public string NameParameterName
        {
            get { return _NameParameterName; }
            set { _NameParameterName = value; }
        }

        /// <summary>
        /// 팝업에서 선택된 정보(행)에 대해 DataRow 타입으로 가져옵니다.
        /// </summary>
        public DataRow SelectedPopupValue
        {
            get { return _SelectedPopupValue; }
        }

        public new bool IsEmpty
        {
            get { return this.GetValue().ToString().Length == 0 ? true : false; }
        }

        /// <summary>
        /// 코드박스에 코드 혹은 명이 바인딩 되었는지 여부를 가져옵니다.
        /// </summary>
        public bool IsBinded
        {
            get
            {
                return (_CodeTextBox.GetValue().ToString().Length == 0 || this.Value.ToString().Length == 0) ? false : true;
            }
        }

        /// <summary>
        /// 코드박스에 바인딩 된 코드의 바이트를 가져옵니다.
        /// </summary>
        public new int ByteCount
        {
            get { return Encoding.Default.GetByteCount(AxStaticCommon.Nvl(this.GetValue(), "").ToString()); }
        }

        /// <summary>
        /// 코드박스의 코드영역에 고정지정길이(Char)를 설정합니다.
        /// </summary>
        public int CodePixedLength
        {
            set { _CodePixedLength = value; }
        }

        /// <summary>
        /// 코드유효성 검사유무를 설정합니다.
        /// </summary>
        public bool CodeValidationEnabled
        {
            set { _CodeValidationEnabled = value; }
        }

        /// <summary>
        /// 코드의 프리픽스 코드를 가져오거나 설정합니다.
        /// </summary>
        public string PrefixCode
        {
            get { return _PrefixCode; }
            set { _PrefixCode = value; }
        }
        #endregion

        /// <summary>
        /// 코드박스에 지정된 IHEPopupHelper 인스턴스를 가져오거나 설정합니다.
        /// 참고로 코드박스와 연동하여 구현되는 팝업 클래스는 IHEPopupHelper 인터페이스를 구현해야 합니다.
        /// </summary>
        public IAxPopupHelper HEPopupHelper
        {
            get { return _IHEPopupHelper; }
            set 
            { 
                _IHEPopupHelper = value;

                if (_IHEPopupHelper is IPopupControl)
                {
                    IPopupControl popup = (IPopupControl)_IHEPopupHelper;
                    _PrefixCode = popup.PrefixCode;
                }
            }
        }

        /// <summary>
        /// 코드박스의 코드영역에 고정지정길이(Char)을 기본값(10)으로 설정합니다.
        /// </summary>
        public void SetCodePixedLength()
        {
            _CodePixedLength = 10;
        }

        /// <summary>
        /// 코드박스에서 IHEPopupHelper 구현 클래스에 넘겨줄 사용자 파라메터를 설정합니다.
        /// </summary>
        public void HEUserParameterSetValue(string key, object value)
        {
            if (_HEUserParameterDummy[key] != null)
                _HEUserParameterDummy[key] = value;
            else
                _HEUserParameterDummy.Add(key, value);
        }

        /// <summary>
        /// 사용자 파라메터의 키에 속한 값을 반환합니다.
        /// 만약 인자로 넘긴 키가 존재하지 않을 경우에는 공백이 반환됩니다.
        /// </summary>
        public object HEUserParameterGetValue(string key)
        {
            return (_HEUserParameterDummy[key] == null) ? "" : _HEUserParameterDummy[key];
        }

        /// <summary>
        /// 코드박스에 코드와 명을 설정합니다.
        /// 이 메서드의 경우에는 코드와 명에 대한 유효성 검사를 하지 않습니다.
        /// </summary>
        public void SetValue(string text, string value)
        {
            _CodeValidationEnabled = false; //true에서 false로 변경 2017.10.31
            value = this.GetProcessCode(value);
            _CodeTextBox.SetValue(value);
            this.Value = text;
            this._CodeValue = value;//코드값 설정. #001
            _CodeValidationEnabled = true; //false에서 true로 변경 2017.10.31
        }

        /// <summary>
        /// HEFlexGrid에서 지정한 행, 명에 대해 코드와 명을 가져와서 코드박스에 설정합니다.
        /// </summary>
        public void SetValue(AxFlexGrid flex, int row, string name)
        {
            string code = flex.GetValue(row, name).ToString();
            string text = flex.GetText(row, name);

            _CodeValidationEnabled = false; //true에서 false로 변경 2017.10.31
            code = this.GetProcessCode(code);
            _CodeTextBox.SetValue(code);
            this.Value = text;
            this._CodeValue = code;//코드값 설정 #001 
            _CodeValidationEnabled = true; //false에서 true로 변경 2017.10.31
        }

        /// <summary>
        /// 코드박스의 코드명을 반환합니다.
        /// </summary>
        public string GetText()
        {
            return this.Text.Trim();
        }

        /// <summary>
        /// 코드박스의 코드명을 설정합니다.
        /// </summary>
        public void SetText(object value)
        {
            base.Value = value.ToString().Trim();            
        }

        /// <summary>
        /// 코드박스에서 IHEPopupHelper 구현 클래스에 넘겨줄 파라메터를 설정합니다.
        /// </summary>
        public void HEParameterAdd(string key, object value)
        {
            _HEParameterDummy.Add(key, value);
        }

        /// <summary>
        /// 코드박스에서 IHEPopupHelper 구현 클래스에 넘겨줄 파라메터에 대해 키의 값을 수정합니다.
        /// </summary>
        public void HEParameterSetValue(string key, object value)
        {
            _HEParameterDummy[key] = value;
        }

        /// <summary>
        /// 파라메터에 지정된 키에 해당하는 값을 반환합니다.
        /// 만약 해당 키가 존재하지 않을 경우에는 공백이 반환됩니다.
        /// </summary>
        public object HEParameterGetValue(string key)
        {
            return (_HEParameterDummy[key] == null) ? "" : _HEParameterDummy[key];
        }

        protected override void OnCreateControl()
        {
            _IsCreated = true;

            base.OnCreateControl();
            this.CreateCodeBoxControl();
        }

        //코드, 버튼 디자인 추가 부분
        private void CreateCodeBoxControl()
        {
            if (!this.DesignMode && _IsCreated)
            {
                if (!_Visible)
                {
                    _CodeTextBox.Visible = false;
                    _PopupButton.Visible = false;
                    return;
                }

                this.Parent.Controls.Add(_PopupButton);
                this.Parent.Controls.Add(_CodeTextBox);
                //_CodeTextBox.Text = "aaa";
                //this.Text = "명칭";
                _PopupButton.Enabled = this.Enabled;
                _PopupButton.UseVisualStyleBackColor = true;
                _PopupButton.Size = new Size(21, 21);
                _PopupButton.Image = global::Ax.DEV.Utility.Properties.Resources.magnifier;
                
                _CodeTextBox.Enabled  = this.Enabled;
                _CodeTextBox.ReadOnly = _CodeTextBoxReadOnly;
                _CodeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                base.ReadOnly = _NameTextBoxReadOnly;
                base.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
                
                base.Visible = true;
                _CodeTextBox.Visible = true;
                _PopupButton.Visible = true;
                
                if (_CodeTextBoxVisible && _NameTextBoxVisible)
                {
                    _CodeTextBox.Width = _CodeTextBoxWidth;
                    base.Width = _Size.Width - _CodeTextBoxWidth - 23;

                    _CodeTextBox.Location = _Location;
                    base.Location = new Point(_Location.X + _CodeTextBox.Width + 1, _Location.Y);
                    _PopupButton.Location = new Point(base.Location.X + base.Width + 1, base.Location.Y);
                }

                if (_CodeTextBoxVisible && !_NameTextBoxVisible)
                {
                    base.Visible = false;
                    _CodeTextBox.Visible = true;
                    _CodeTextBox.Location = _Location;
                    _CodeTextBox.Width = _Size.Width - 23;
                    _PopupButton.Location = new Point(_CodeTextBox.Location.X + _CodeTextBox.Width + 1, _Location.Y);
                }

                if (!_CodeTextBoxVisible && _NameTextBoxVisible)
                {
                    _CodeTextBox.Visible = false;
                    base.Visible = true;
                    base.Location = _Location;
                    base.Width = _Size.Width - 23;
                    _PopupButton.Location = new Point(base.Location.X + base.Width + 1, base.Location.Y);
                }
            }
        }

        /// <summary>
        /// 코드박스 컨트롤을 새로 그리고 설정하는 CreateCodeBoxControl()를 재 호출합니다.
        /// </summary>
        public void Recall_CreateCodeBoxControl()
        {
            _IsCreated = true;
            this.CreateCodeBoxControl();
        }

        /// <summary>
        /// 코드박스의 읽기모드 여부를 설정합니다.
        /// </summary>
        public new void SetReadOnly(bool read)
        {
            this.ReadOnly = read;
            _CodeTextBox.ReadOnly = read;
            _PopupButton.Enabled  = !read;
        }
        #region "Key 및 팝업관련 이벤트 처리"
        private void _CodeTextBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1 || e.KeyCode == Keys.Tab)
            {
                _CodeValidationCheck = true;
                _CodeValidationEnabled = true;

                this.HECodeBox_Validation(sender, e);
            }

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                this.Value = "";
                this._CodeValue = "";//코드값 초기화 #001
                OnCodeBoxBindingAfter(this, e);
            }

        }

        private void _CodeTextBox_Leave(object sender, System.EventArgs e)
        {
            //주석 처리함 .. 2017-10-19
            //_CodeValidationCheck = true;
            //if (_CodeValidationEnabled)
            //    _CodeValidationEnabled = false;
            //else
            //    _CodeValidationEnabled = true;

            this.HECodeBox_Validation(sender, e);
        }

        private void HECodeBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F1 || e.KeyCode == Keys.Tab)
            {
                _CodeValidationCheck = false;
                //_CodeValidationEnabled = true;
                
                this.HECodeBox_Validation(sender, e);
            }

            //2015-04-14 Delete, Backspace Event 삭제
            //2015-05-26 코드 값 VISIBLE FALSE는 NAME 삭제 시 CODE 값 삭제
            if ((e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) && _CodeTextBox.Visible == false)
            {
                _CodeTextBox.Initialize();
                OnCodeBoxBindingAfter(this, e);
            }
        }

        private void HECodeBox_Leave(object sender, System.EventArgs e)
        {
            _CodeValidationCheck = false;

            ////오류메시지 2번 뜨는 오류 방지 //주석 처리함 .. 2017-10-19
            //if (_CodeValidationEnabled)
            //    _CodeValidationEnabled = false;
            //else
            //    _CodeValidationEnabled = true;

            this.HECodeBox_Validation(sender, e);
            if (_CodeTextBox.Value.Equals(""))
                this.SetValue("");
        }

        private void HECodeBox_Validation(object sender, System.EventArgs e)
        {
            this.OnButtonClickBefore(this, e);  // 키 타이핑으로 검색시에도 Popup Before Event 처리후 동작하게끔 변경 - 2019.11.26
            if (!_CodeValidationEnabled) return;//_CodeValidationEnabled=false이면 HECodeBox_Validation 로직 타지 않도록 함. Leave이벤트 중첩으로인한 중복 호출 문제. 2017-10-19

            if (_IHEPopupHelper == null)
                return;

            string text = this.GetText();
            string code = _CodeTextBox.GetValue().ToString();

            if (text.Trim().Equals(string.Empty) && code.Trim().Equals(string.Empty)) //code,text모두 빈값일 때는 종료.
            {
                this._CodeValue = "";
                _SelectedPopupValue = null;
                OnButtonClickAfter(this, e); 
                return;                                 
            }
            if (!text.Trim().Equals(string.Empty) && !code.Trim().Equals(string.Empty) && this._CodeValue == code) return;    //입력값과 기존코드값 확인 (두 값이 같으면 종료, 단순 포커스 이동시에는 validation 로직 진행 안함.) #001
            
            if (text.Length > 0 || code.Length > 0)
            {
                code = this.GetValue().ToString();

                if (_CodePixedLength > 0 && code.Length > 0)
                    code = code.PadRight(_CodePixedLength, ' ');

                HEParameterSet set = new HEParameterSet();
                set.Add(_CodeParameterName, code);
                set.Add(_NameParameterName, text);

                for (int i = 0; i < _HEParameterDummy.Count; i++)
                {
                    string key   = _HEParameterDummy.GetKey(i).ToString();
                    object value = _HEParameterDummy[key].ToString();

                    set.Add(key, value);
                }

                ////////////////////////////////////////////////////////////////////////////////////////
                // HEUserParameterValue 를 사용할 경우 이 콜렉션에 저장 된 값을 Parameter 로 추가 설정.
                // 2010-07-20 홍정현대리 추가.
                for (int i = 0; i < _HEUserParameterDummy.Count; i++)
                {
                    string key   = _HEUserParameterDummy.GetKey(i).ToString();
                    string value = _HEUserParameterDummy[key].ToString();

                    if (!_HEParameterDummy.ContainsKey(key))
                        set.Add(key, value);
                    else
                        set[key] = value;
                }
                ////////////////////////////////////////////////////////////////////////////////////////

                _GetDataSourceLock = true;
                DataTable source = _IHEPopupHelper.GetDataSource(set);
                _GetDataSourceLock = false;

                switch (source.Rows.Count)
                {
                    case 0:
                        if (!_CodeValidationEnabled) return;                                                
                        
                        //string msg = _CodeValidationCheck ? "코드를" : "명을";                        
                        //MessageBox.Show(String.Format("{0} 정확히 입력하세요.", msg));
                        _CodeValidationEnabled = false;//2017-10-19
                        MessageBox.Show("the code doesn't exist, please check again");
                        this.Initialize();                        
                        if (_CodeValidationCheck)
                            _CodeTextBox.Focus();
                        else
                            this.Focus();
                        break;
                    case 1:
                        this.SetValue(
                            AxStaticCommon.Nvl(source.Rows[0][_NameParameterName], "").ToString(),
                            AxStaticCommon.Nvl(source.Rows[0][_CodeParameterName], "").ToString());

                        _SelectedPopupValue = source.Rows[0];
                        OnCodeBoxBindingAfter(this, e);

                        OnButtonClickAfter(this, e); 
                        break;
                    default:
                        if (!_CodeValidationEnabled) return;

                        //
                        DataRow[] drs = source.Select(_CodeParameterName + "='" +  code + "'");
                        if (drs.Length == 1)
                        {
                            this.SetValue(
                            AxStaticCommon.Nvl(drs[0][_NameParameterName], "").ToString(),
                            AxStaticCommon.Nvl(drs[0][_CodeParameterName], "").ToString());

                            _SelectedPopupValue = drs[0];
                            OnCodeBoxBindingAfter(this, e);
                            OnButtonClickAfter(this, e); 
                            return; 
                        }
                        //if (this.Focused)
                            this._PopupButton_Click(sender, e);
                            _CodeValidationEnabled = true;//2017-10-19
                        break;
                }
            }
            else
                this.Initialize();

            _CodeValidationEnabled = true;//2017-10-19
        }

        private void _PopupButton_Click(object sender, System.EventArgs e)
        {
            OnButtonClickBefore(this, e);

            if (_IHEPopupHelper == null)
            {
                OnButtonClickAfter(this, e);
                return;
            }

            _IHEPopupHelper.Initialize_Helper(this);
            PopupHelper helper = new PopupHelper((IPopupControl)_IHEPopupHelper, _PopupTitle);
            
            helper.ShowDialog();

            object data = helper.SelectedValue;
            if (data != null)
            {
                _SelectedPopupValue = (DataRow)data;

                string text = AxStaticCommon.Nvl(_SelectedPopupValue[_NameParameterName], "").ToString();
                string code = AxStaticCommon.Nvl(_SelectedPopupValue[_CodeParameterName], "").ToString();
                if (text.Length > 0 && code.Length > 0)
                    this.SetValue(text, code);
                else
                    this.Initialize();
                OnButtonClickAfter(this, e);
                _CodeValidationEnabled = true;//2017-10-19
            }
            else
            {
                if(!this.IsBinded)
                    this.Initialize();
            }
        }

        #endregion

        /// <summary>
        /// 코드박스의 최대, 최소 사이즈 및 입력타입을 지정합니다.
        /// </summary>
        public new void SetValid(int max, int min, TextType type)
        {
            _CodeTextBox.SetValid(max, min, type);
        }

        /// <summary>
        /// 코드박스의 최대 사이즈 및 입력타입을 지정합니다.
        /// </summary>
        public new void SetValid(int max, TextType type)
        {
            _CodeTextBox.SetValid(max, type);
        }

        /// <summary>
        /// 코드박스의 입력타입을 지정합니다.
        /// </summary>
        public new void SetValid(TextType type)
        {
            _CodeTextBox.SetValid(type);
        }
    }
}
