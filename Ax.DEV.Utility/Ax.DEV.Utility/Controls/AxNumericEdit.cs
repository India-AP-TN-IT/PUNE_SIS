using C1.Win.C1Input;
using Ax.DEV.Utility.Library;
using System.Drawing;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// C1NumericEdit 클래스를 상속받은 숫자에디트입니다.
    /// </summary>
    public class AxNumericEdit : C1NumericEdit //, IHEControl
    {
        private Color _oldColor;

        public AxNumericEdit()
            : base()
        {
            this.DisplayFormat.FormatType = FormatTypeEnum.StandardNumber;
            this.DisplayFormat.Inherit = ((FormatInfoInheritFlags)(((((FormatInfoInheritFlags.CustomFormat | FormatInfoInheritFlags.NullText)
                        | FormatInfoInheritFlags.EmptyAsNull)
                        | FormatInfoInheritFlags.TrimStart)
                        | FormatInfoInheritFlags.TrimEnd)));
            this.EditFormat.FormatType = FormatTypeEnum.StandardNumber;
            this.EditFormat.Inherit = ((FormatInfoInheritFlags)(((((FormatInfoInheritFlags.CustomFormat | FormatInfoInheritFlags.NullText)
                        | FormatInfoInheritFlags.EmptyAsNull)
                        | FormatInfoInheritFlags.TrimStart)
                        | FormatInfoInheritFlags.TrimEnd)));
            this.EmptyAsNull = true;
            this.NullText = "0";
            
            this.Size = new System.Drawing.Size(100, 21);
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.VisibleButtons = DropDownControlButtonFlags.None;
            this.Enter += new System.EventHandler(AxNumericEdit_Enter);
            this.Leave += new System.EventHandler(AxNumericEdit_Leave);

            _oldColor = this.BackColor;

        }

        void AxNumericEdit_Leave(object sender, System.EventArgs e)
        {
            this.BackColor = _oldColor;
        }

        void AxNumericEdit_Enter(object sender, System.EventArgs e)
        {
            _oldColor = this.BackColor;
            if (!this.ReadOnly)
                this.BackColor = Color.FromArgb(254, 240, 158);
        }
        
        #region IHEControl 멤버

        public object GetValue()
        {
            //return this.Value.ToString().Split(new char[] {',','.'}).Length == 1 ? int.Parse(this.Value.ToString()) : double.Parse(this.Value.ToString());
            //System.Globalization.NumberFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat;
            //if (format.NumberDecimalSeparator.Equals(","))
            //    return Value.ToString().Replace(',', '.');
            //else
                return Value;            
        }

        public string GetDBValue()
        {
            System.Globalization.NumberFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat;
            if (format.NumberDecimalSeparator.Equals(","))
                return Value.ToString().Replace(',', '.');
            else
            return Value.ToString();            
            //return Value.ToString().Replace(',','.');
        }
        public void SetValue(object value)
        {
            if (value.ToString().Equals(string.Empty))
                this.Value = "";
            else
                this.Value = double.Parse(value.ToString());            
        }

        public void Initialize()
        {
            this.SetValue(0);
        }

        #endregion

        public void SetLanguageCustomFormat()
        {
            //if (StaticHeUserInfoContext.Language.Equals("EN"))
            //    if (this.CustomFormat.Length > 0)
            //    {
            //        string format = this.CustomFormat.Replace(",", ".").Replace(".", "*");
            //        this.CustomFormat = format.Replace("@", ".").Replace("*", ",");
            //    }
        }

        public void SetReadOnly(bool read)
        {
            this.ReadOnly = read;
        }

        /// <summary>
        /// GetValue() 의 경우에는 Value 속성에서 값을 반환하지만 
        /// GetText() 의 경우에는 Text 속성에서 콤마를 제거한 후 Decimal로 반환합니다. 
        /// </summary>
        public object GetText()
        {
            string text = "";
            if (StaticUserInfoContext.Language.Equals("KO"))
                text = this.Text.Trim().Replace(",", "");
            else
                text = this.Text.Trim().Replace(".", "").Replace(",", ".");

            object value = decimal.Parse(text);
            this.SetValue(value);
            return value.ToString();
        }
    }
}
