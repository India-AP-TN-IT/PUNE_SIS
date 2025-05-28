using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheOne.Windows.Forms;

namespace Ax.SIS.SD.UI
{
    public partial class ZSDE602_LOGIN : Form
    {
        public ZSDE602_LOGIN()
        {
            InitializeComponent();
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Password.Text))
            {
                MsgBox.Show("Please enter password", "Information");
            }
            else
            {
                if (Txt_Password.Text == "12345")
                {
                    this.Close();
                }
                else
                {
                    MsgBox.Show("Enter correct password", "Information");
                }
            }
        }
    }
}
