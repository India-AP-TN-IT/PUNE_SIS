#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using System.IO;
using System.Text;

namespace Ax.SIS.TM.UI
{
    
    public partial class TM25500 : AxCommonBaseControl
    {
        public enum MoveEnum
        {
            Next,
            Back,
            Home
        }
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;
        private string m_PUBCD = "";
        private string m_CORCD = "";
        private string m_BIZCD = "";
        private int m_CurITEM =0;
        private string m_Phone = "";
        private string m_LOCCD = "";
        public TM25500()
        {
            InitializeComponent();

            _DB = new AxClientProxy();
            
        }
       
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                
            }
            finally
            {
            }
        }
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                
            }
            finally
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Txt_Phone.Text))
            {
                MsgBox.Show("Phone number is error", "Error");
                return;
            }
            txt_OTP.Visible = true;
            button3.Visible = true;
            Txt_Phone.Enabled = false;
            button1.Enabled = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MsgBox.Show("QR is error", "Error");
                return;
            }
            panel3.Enabled = false;
            panel2.Visible = true;

            string[] param = textBox2.Text.Split('?');
            if(param.Length<1)
            {
                MsgBox.Show("wrong address", "Error");
                return;
            }
            else
            {
                string[] str = param[1].Split('&');
                foreach(string ar in str)
                {
                    if(ar.Contains("CORCD"))
                    {
                        Txt_CORCD.Text = ar.Replace(" ", "").Replace("CORCD=", "");
                        m_CORCD = Txt_CORCD.Text;
                    }
                    if (ar.Contains("BIZCD"))
                    {
                        Txt_BIZCD.Text = ar.Replace(" ", "").Replace("BIZCD=", "");
                        m_BIZCD = Txt_BIZCD.Text;
                    }
                    if (ar.Contains("PUBCD"))
                    {
                        m_PUBCD = ar.Replace(" ", "").Replace("PUBCD=", "");
                    }
                }
            }
           
        }
        private string GetDocData(string corcd, string bizcd, string pubcd, string colNM)
        {
            DataTable dt = new DataTable();
            HEParameterSet paramSet = new HEParameterSet();
            


            paramSet = new HEParameterSet();
            paramSet.Add("CORCD", corcd);
            paramSet.Add("BIZCD", bizcd);
            paramSet.Add("PUBCD", pubcd);
            dt = _DB.ExecuteDataSet("APG_TM25500.GET_PUBDOC_DATA", paramSet, "OUT_CURSOR").Tables[0];
            if(dt.Rows.Count > 0)
            {
                return dt.Rows[0][colNM].ToString();
            }
            return "";
        }
        private void ResetLastData()
        {
            

            HEParameterSet paramSet = new HEParameterSet();



            paramSet = new HEParameterSet();
            paramSet.Add("CORCD", m_CORCD);
            paramSet.Add("BIZCD", m_BIZCD);
            paramSet.Add("PUBCD", m_PUBCD);
            paramSet.Add("WHO", m_Phone);
            _DB.ExecuteNonQueryTx("APG_TM25500.RESET_LAST_CHK_DATA", paramSet);

        }
        private DataTable GetDocDetTable(string corcd, string bizcd, string pubcd, string phone)
        {
            DataTable dt = new DataTable();
            HEParameterSet paramSet = new HEParameterSet();



            paramSet = new HEParameterSet();
            paramSet.Add("CORCD", corcd);
            paramSet.Add("BIZCD", bizcd);
            paramSet.Add("PUBCD", pubcd);
            paramSet.Add("PHONE", phone);
            dt = _DB.ExecuteDataSet("APG_TM25500.GET_DOC_DETAIL", paramSet, "OUT_CURSOR").Tables[0];

            return dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel4.Visible = true;
            m_Phone = Txt_Phone.Text;
            label3.Text = "Location:" + GetDocData(m_CORCD, m_BIZCD, m_PUBCD, "LOCNM");
            m_LOCCD = GetDocData(m_CORCD, m_BIZCD, m_PUBCD, "LOCCD");
            ResetLastData();    //Clear Last Input Data in DB

        }
        private string GetVal()
        {
            if(radioButton1.Visible)
            {
                if(radioButton1.Checked)
                {
                    return "OK";
                }
                else if(radioButton2.Checked)
                {
                    return "NG";
                }
                else if(radioButton3.Checked)
                {
                    return "WAIT";
                }
            }
            return textBox7.Text;
        }
        private void SetVal(string val)
        {
            if (radioButton1.Visible)
            {
                switch(val)
                {
                    case "OK":
                        radioButton1.Checked = true;
                        break;
                    case "NG":
                        radioButton2.Checked = true;
                        break;
                    case "WAIT":
                        radioButton3.Checked = true;
                        break;
                    default:
                        radioButton1.Checked = true;
                        break;
                }
            }
            else
            {
                textBox7.Text = val;
            }
        }
        private void DisCheckList(MoveEnum move)
        {
            
            DataTable dt = GetDocDetTable(m_CORCD, m_BIZCD, m_PUBCD, m_Phone);
            
            if (dt.Rows.Count > 0)
            {
                int maxCNT = Convert.ToInt32(dt.Rows[0]["MAX_CNT"]);
                
                if (move == MoveEnum.Home)
                {
                    m_CurITEM = 1;
                }
                else if(move == MoveEnum.Back)
                {
                    
                    if(m_CurITEM>1)
                    {
                        m_CurITEM--;
                        if (m_CurITEM != maxCNT)
                        {
                            button7.Text = "Next";
                        }
                    }
                    else
                    {
                        MsgBox.Show("It's first data!!", "Error");
                        return;
                    }
                }
                else if (move == MoveEnum.Next)
                {
                    string doccd = GetDocDetRow(dt, m_CurITEM)["DOCCD"].ToString();
                    string chkcd = GetDocDetRow(dt, m_CurITEM)["CHKCD"].ToString();
                    HEParameterSet paramSet = new HEParameterSet();

                    paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", m_CORCD);
                    paramSet.Add("BIZCD", m_BIZCD);
                    paramSet.Add("PUBCD", m_PUBCD);
                    paramSet.Add("DOCCD", doccd);
                    paramSet.Add("CHKCD", chkcd);
                    paramSet.Add("VAL", GetVal());
                    paramSet.Add("COMM", "");
                    paramSet.Add("WHO", m_Phone);
                    paramSet.Add("LOCCD", m_LOCCD);

                    _DB.ExecuteNonQueryTx("APG_TM25500.SET_LAST_CHK_DATA", paramSet);
                    if (m_CurITEM < maxCNT)
                    {
                        m_CurITEM++;
                        if(m_CurITEM == maxCNT)
                        {
                            button7.Text = "Save All";
                        }
                    }
                    else
                    {
                        _DB.ExecuteNonQueryTx("APG_TM25500.SET_CHK_DATA_HIST", paramSet);
                        panel5.Enabled = false;
                        return;
                    }
                }
                
                textBox1.Text = string.Format("{0}/{1}", GetDocDetRow(dt, m_CurITEM)["CUR_CNT"].ToString(), GetDocDetRow(dt, m_CurITEM)["MAX_CNT"].ToString());
                textBox3.Text = GetDocDetRow(dt, m_CurITEM)["CHKCD"].ToString();

                textBox5.Text = GetDocDetRow(dt, m_CurITEM)["PERD_DESC"].ToString();
                textBox4.Text = GetDocDetRow(dt, m_CurITEM)["CHKNM"].ToString();
                InputMode(GetDocDetRow(dt, m_CurITEM)["VALUE_TYPE"].ToString());
                textBox6.Text = GetDocDetRow(dt, m_CurITEM)["METHOD"].ToString();
                SetVal(GetDocDetRow(dt, m_CurITEM)["VAL"].ToString());
            }
            else
            {
                MsgBox.Show("No Data!!", "Error");
                return;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Enabled = false;
            panel5.Visible = true;
            label4.Text = GetDocData(m_CORCD, m_BIZCD, m_PUBCD, "DOCNM");
            label6.Text = "Location:" + GetDocData(m_CORCD, m_BIZCD, m_PUBCD, "LOCNM");
            DisCheckList(MoveEnum.Home);
            
            
        }
        private DataRow GetDocDetRow(DataTable dt, int cur)
        {
            for(int row = 0;row<dt.Rows.Count;row++)
            {
                if(dt.Rows[row]["CUR_CNT"].ToString() == cur.ToString())
                {
                    return dt.Rows[row];
                }
            }
            return null;
        }


        private void InputMode(string mode)
        {
            switch(mode)
            {
                case "TW01":
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                    textBox7.Visible = false;
                    break;
                default:
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    textBox7.Visible = true;
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DisCheckList(MoveEnum.Back);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DisCheckList(MoveEnum.Next);
        }

       
    }
}

