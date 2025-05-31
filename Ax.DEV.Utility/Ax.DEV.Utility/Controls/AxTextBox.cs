using System.Text;
using System.Windows.Forms;
using C1.Win.C1Input;
using Ax.DEV.Utility.Library;
using System.Text.RegularExpressions;
using System;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// C1TextBox 클래스를 상속받은 텍스트박스입니다.
    /// </summary>
    public class AxTextBox : C1TextBox, IAxControl
    {
        private string _RegexPattern;
        private int _MinLength;
        private TextType _Type;
        private Color _oldColor;
        #region IHEControl 멤버

        /// <summary>
        /// 텍스트를 Trim() 실행 후 반환합니다.
        /// </summary>
        public object GetValue()
        {
            return this.Text.Trim();
        }

        public AxTextBox()  : base()
        {
            _RegexPattern  = "";
            _MinLength     = 0;

            this.TextAlign = HorizontalAlignment.Left;
            this.TextChanged += new EventHandler(HETextBox_TextChanged);            
            this.Leave += new EventHandler(HETextBox_Leave);
            this.Enter += new EventHandler(AxTextBox_Enter);

            _oldColor = this.BackColor;
        }


        
        /// <summary>
        /// 입력받은 텍스트를 Trim() 실행 후 지정합니다.
        /// </summary>
        public void SetValue(object value)
        {
            // 윈도우 8이상에서 한글 끝자리 잘림 및 입력 후 포커스 손실시 데이터 날라가는 현상 방지 2줄 - 2019-11-25 김건우 추가
            this.TextDetached = false;
            this.CausesValidation = true;

            bool enabled = this.Enabled;
            bool read = this.ReadOnly;

            this.Enabled = true;
            this.ReadOnly = false;
            this.Value = value.ToString().Trim();

            this.Enabled = enabled;
            this.ReadOnly = read;
        }

        public void Initialize()
        {
            this.SetValue("");
        }

        #endregion

        public bool IsEmpty
        {
            get { return this.GetValue().ToString().Length == 0 ? true : false; }
        }

        /// <summary>
        /// 입력된 글자의 총 바이트를 가져옵니다.
        /// </summary>
        public int ByteCount
        {
            get { return Encoding.Default.GetByteCount(AxStaticCommon.Nvl(this.GetValue(), "").ToString()); }
        }

        public void SetReadOnly(bool read)
        {
            this.ReadOnly = read;
        }

        public enum TextType { Default, UAlphabet, Hangle, OnlyNumber }

        /// <summary>
        /// 텍스트박스의 최대, 최소 사이즈 및 입력타입을 지정합니다.
        /// </summary>
        public void SetValid(int max, int min, TextType type)
        {
            this.MaxLength = max;
            _MinLength = min;
            _Type = type;

            this.ImeMode = ImeMode.Disable;
            switch (_Type)
            {
                case TextType.Default: // Default
                    this.ImeMode = ImeMode.NoControl;
                    break;
                case TextType.Hangle: // Hangul
                    this.ImeMode = ImeMode.Hangul;
                    break;
                case TextType.OnlyNumber: // OnlyNumber
                    _RegexPattern = @"[0-9\-]";
                    break;
                case TextType.UAlphabet: // UAlphabet
                    _RegexPattern = @"[A-Z0-9\s ._\-]";//공백허용 2018.06.12 배명희
                    this.TextAlign = HorizontalAlignment.Left;
                    break;
            }
        }

        /// <summary>
        /// 텍스트박스의 최대 사이즈 및 입력타입을 지정합니다.
        /// </summary>
        public void SetValid(int max, TextType type)
        {
            this.SetValid(max, 0, type);
        }

        /// <summary>
        /// 텍스트박스의 입력타입을 지정합니다.
        /// </summary>
        public void SetValid(TextType type)
        {
            this.SetValid(999999, 0, type);
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // HETextBox
            // 
            this.Size = new System.Drawing.Size(100, 21);
            this.Leave += new System.EventHandler(this.HETextBox_Leave);
            this.TextChanged += new System.EventHandler(this.HETextBox_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void HETextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (_Type == TextType.Default ||
                _Type == TextType.Hangle) return;

            StringBuilder builder = new StringBuilder();
            Regex regex = new Regex(_RegexPattern);
            //string inputText = this.GetValue().ToString();
            string inputText = this.Text; // 2018.06.12 배명희 GetValue는 앞,뒤공백 제거한 후 반환하므로  Text값을 읽는다. 맨뒤에 공백이 있는 경우 입력 허용하기 위해.(코드중에 문자열사이에 공백 들어간 코드 있음.)

            for (int i = 0; i < inputText.Length; i++)
            {
                string charText = inputText[i].ToString();
                if (_Type == TextType.UAlphabet)
                    charText = charText.ToUpper();

                if (regex.IsMatch(charText))
                    builder.Append(charText);
            }

            //this.Text = builder.ToString();
            if (this.Text != builder.ToString().TrimStart()) //2018.06.12 배명희 정규식 통과한 문자열이 원래 문자열과 다른경우에만 바뀐값 적용해준다.(공백으로 시작하지 않아야한다.)
            {
                this.Text = builder.ToString().TrimStart();
            }
            this.SelectionStart = this.Text.Length;
        }

        private void HETextBox_Leave(object sender, System.EventArgs e)
        {
            string inputText = this.GetValue().ToString();
            if (inputText.Length > 0)
            {
                int byteLength = Encoding.Default.GetByteCount(inputText);

                if (_MinLength > byteLength)
                {
                    MessageBox.Show(String.Format("{0} 바이트 이상 입력되어야 합니다.", _MinLength));
                    this.Initialize();
                    this.Focus();
                }

                if (this.MaxLength < byteLength)
                {
                    MessageBox.Show(String.Format("{0} 바이트 이상 입력되어서는 안됩니다.", _MinLength));
                    this.Initialize();
                    this.Focus();
                }
            }

            this.BackColor = _oldColor;
        }



        void AxTextBox_Enter(object sender, EventArgs e)
        {
            _oldColor = this.BackColor;


            if (_oldColor == Color.FromArgb(254, 240, 158))
            {
                if (this.ReadOnly)
                    _oldColor = SystemColors.Window;
                else
                    _oldColor = Color.White;
            }

            if (!this.ReadOnly)
                this.BackColor = Color.FromArgb(254, 240, 158);

            // 윈도우 8이상에서 한글 끝자리 잘림 및 입력 후 포커스 손실시 데이터 날라가는 현상 방지 - 2019-11-25 김건우 추가
            // using System.Reflection; 추가 필요
            if (string.IsNullOrEmpty(this.Name) || this.Name.IndexOf("cdx") >= 0 || (this.Tag != null && this.Tag.Equals("cdx"))) return;
            if (!this.IsRegistEvent("Validating") && !this.IsRegistEvent("Validated") &&
                !this.IsRegistEvent("PostValidating") && !this.IsRegistEvent("PostValidated") &&
                !this.IsRegistEvent("PreValidating") && !this.IsRegistEvent("PreValidated"))
            {
                if (!this.TextDetached) this.TextDetached = true;
                if (this.CausesValidation) this.CausesValidation = false;
            }
        }

        /// <summary>
        /// 이벤트 연결 체크 함수
        /// 윈도우 8이상에서 한글 끝자리 잘림 및 입력 후 포커스 손실시 데이터 날라가는 현상 방지 - 2019-11-25 김건우 추가
        /// using System.Reflection; 추가 필요
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        bool IsRegistEvent(string eventName)
        {
            PropertyInfo propertyInfo = this.GetType().GetProperty("Events", BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            EventHandlerList eventHandlerList = propertyInfo.GetValue(this, new object[] { }) as EventHandlerList;
            FieldInfo fieldInfo = typeof(Control).GetField("Event" + eventName, BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            if (fieldInfo == null)
                return false;
            else
            {
                object eventKey = fieldInfo.GetValue(this);
                return eventHandlerList[eventKey] != null;
            }
        } 

    }
}
