using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ax.SIS.SD.UI
{
    public partial class ZSD02500_IRN_MANUAL : Form
    {
        private string m_Invoice;
        private string m_IRN;

        private string m_IRN_ACK;
        private string m_IRN_DATE;
        private string m_Old_IVNO;
        private string m_EWB;

        public string Invoice
        {
            get { return m_Invoice; }
            set { m_Invoice = value; }
        }
        public string IRN
        {
            get { return m_IRN; }
            set { m_IRN = value; }
        }
        public string EWB
        {
            get { return m_EWB; }
        }
        public string Old_IVNO
        {
            get { return m_Old_IVNO; }
        }
        public string IRN_DATE
        {
            get { return m_IRN_DATE; }
        }
        public string IRN_ACK
        {
            get { return m_IRN_ACK; }
        }
        
        public ZSD02500_IRN_MANUAL(string invoice)
        {
            InitializeComponent();
            if(DesignMode == false)
            {
                m_Invoice = invoice;
                textBox1.Text = invoice;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_IRN = textBox2.Text;
            m_IRN_ACK = txtIRNACK.Text;
            m_IRN_DATE = txtIRNDATE.Text;
            m_EWB = txtEWB.Text;
            m_Old_IVNO = txtOld.Text;
            Close();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
