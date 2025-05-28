using System.Drawing;
using C1.Win.C1Input;
using Ax.DEV.Utility.Library;
using System.Windows.Forms;
using System;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// C1Label 클래스를 상속받아 구현된 라벨입니다.
    /// </summary>
    public class AxLabel : C1Label, IAxControl
    {
        private bool _autoFontSizeEnable = false; // 2018.05.09 by Geon-Woo, Kim
        private float _autoFontSizeMinValue;      // 2018.05.09 by Geon-Woo, Kim
        private float _autoFontSizeMaxValue;      // 2018.05.09 by Geon-Woo, Kim

        /// <summary>
        /// AutoFontSizeEnable 2018.05.09 by Geon-Woo, Kim
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool AutoFontSizeEnable
        {
            get { return this._autoFontSizeEnable; }
            set
            {
                if (DesignMode && value) this._autoFontSizeMaxValue = this.Font.Size;
                this._autoFontSizeEnable = value;
                AutoFontSizeExecute();
            }
        }

        /// <summary>
        /// AutoFontSizeMinValue 2018.05.09 by Geon-Woo, Kim
        /// </summary>
        public float AutoFontSizeMinValue
        {
            get { return this._autoFontSizeMinValue; }
            set
            {
                this._autoFontSizeMinValue = value;
                AutoFontSizeExecute();
            }
        }

        /// <summary>
        /// AutoFontSizeMaxValue 2018.05.09 by Geon-Woo, Kim
        /// </summary>
        public float AutoFontSizeMaxValue
        {
            get { return this._autoFontSizeMaxValue; }
            set
            {
                this._autoFontSizeMaxValue = value;
                AutoFontSizeExecute();
            }
        }


        public AxLabel()
            : base()
        {
            this.AutoSize = false;

            this.TextAlign = ContentAlignment.MiddleCenter;
            this.BackColor = Color.FromArgb(190, 220, 255);

            this.MouseHover += new System.EventHandler(HELabel_MouseHover);

            this._autoFontSizeMinValue = this.Font.Size; // 2018.05.09 by Geon-Woo, Kim
            this._autoFontSizeMaxValue = this.Font.Size; // 2018.05.09 by Geon-Woo, Kim
            this.TextChanged += AxLabel_TextChanged;     // 2018.05.09 by Geon-Woo, Kim
        }


        //[System.ComponentModel.Browsable(false)]
        //public new object Value
        //{
        //    get;
        //    set;
        //}
        #region IHEControl 멤버

        public object GetValue()
        {
            return this.Text;
        }

        public void SetValue(object value)
        {
            this.Value = value.ToString();
        }

        public void Initialize()
        {
        }

        #endregion

        private void HELabel_MouseHover(object sender, System.EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this, this.Text);
        }

        /// <summary>
        /// AxLabel_TextChanged 2018.05.09 by Geon-Woo, Kim
        /// </summary>
        void AxLabel_TextChanged(object sender, EventArgs e)
        {
            if (_autoFontSizeEnable) this.AutoFontSizeExecute();
        }

        /// <summary>
        /// AutoFontSizeExecute 2018.05.09 by Geon-Woo, Kim
        /// </summary>
        private void AutoFontSizeExecute()
        {
            if (_autoFontSizeEnable)
            {
                Graphics gp;
                SizeF sz;
                Single Faktor, FaktorX, FaktorY;

                gp = this.CreateGraphics();
                sz = gp.MeasureString(this.Text, this.Font);
                gp.Dispose();

                FaktorX = (this.Width) / sz.Width;
                FaktorY = (this.Height) / sz.Height;

                if (FaktorX > FaktorY)
                    Faktor = FaktorY;
                else
                    Faktor = FaktorX;

                float newSize = this.Font.SizeInPoints * (Faktor) - 1;
                if (newSize > this._autoFontSizeMaxValue) newSize = this._autoFontSizeMaxValue;
                if (newSize < this._autoFontSizeMinValue) newSize = this._autoFontSizeMinValue;

                this.Font = new Font(this.Font.Name, newSize, this.Font.Style);
            }
        }
    }
}
