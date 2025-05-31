using System;
using System.Windows.Forms;
using System.Drawing;

namespace Ax.DEV.Utility.Library
{
    /// <summary>
    /// 한일이화 물류 시스템에서 사용하는 Input Box 입니다.
    /// </summary>
    public class AxInputBox
    {
        public static HEDialogResult ShowInputBox(string title, string promptText, string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            HEDialogResult dialogResult = new HEDialogResult();
            dialogResult.Result = form.ShowDialog();
            dialogResult.Value = (object)textBox.Text;

            return dialogResult;
        }
    }

    /// <summary>
    /// 한일이화 물류 시스템에서 사용하는 Input Box 입니다.
    /// </summary>
    public class HEDialogResult
    {
        private DialogResult _dialogResult;
        private object _value;

        public DialogResult Result
        {
            get { return _dialogResult; }
            set { _dialogResult = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = (object)value; }
        }
    }
}