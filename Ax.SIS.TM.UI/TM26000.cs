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

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class TM26000 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_TM26000";
        private string m_MID = "";
        #region [ 초기화 작업 정의 ]

        public TM26000()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {


                axTextBox1.SetValue("");
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 64, "M/ID", "MID", "MID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "DEPARTMENT", "DEPT", "DEPT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "NAME", "NAME", "NAME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "MOBILE", "MPHONE", "MPHONE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "E-MAIL", "EMAIL", "EMAIL");




                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("MID", m_MID);
                set.Add("NAME", axTextBox2.GetValue());
                set.Add("DEPT", axTextBox5.GetValue());
                set.Add("PHONE", axTextBox3.GetValue());
                set.Add("EMAIL", axTextBox4.GetValue());
                set.Add("UPDATE_ID", this.UserInfo.UserID);


                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), set);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                ResetInput();
                //MsgBox.Show(" 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            
            base.BtnDelete_Click(sender, e);
            if (grd01.SelectedRowIndex > -1)
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                string selectedName = grd01.GetValue(grd01.SelectedRowIndex, "NAME").ToString();
                string mid = grd01.GetValue(grd01.SelectedRowIndex, "MID").ToString();
                if (!string.IsNullOrEmpty(mid))
                {
                    if (MsgBox.Show("Do you want to delete selected member:" + selectedName + "?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
                    {
                        HEParameterSet set = new HEParameterSet();
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", bizcd);
                        set.Add("MID", mid);
                        _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DEL_DATA"), set);
                        this.BtnQuery_Click(null, null);
                        ResetInput();
                    }
                }
            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                string bizcd = cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("NAME", axTextBox6.GetValue());
                set.Add("DEPT", "");
                set.Add("PHONE", axTextBox1.GetValue());
                set.Add("EMAIL", axTextBox7.GetValue());
                

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_DATA"), set, "OUT_CURSOR");
                grd01.SetValue(source);
                this.AfterInvokeServer();

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            base.BtnReset_Click(sender, e);
            ResetInput();
        }
        
        #endregion

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ResetInput();
            int row = this.grd01.SelectedRowIndex;
            string mid = grd01.GetValue(row, "MID").ToString();
            if(!string.IsNullOrEmpty(mid))
            {
                m_MID = mid;
                axTextBox2.SetValue(grd01.GetValue(row, "NAME").ToString());
                axTextBox3.SetValue(grd01.GetValue(row, "MPHONE").ToString());
                axTextBox4.SetValue(grd01.GetValue(row, "EMAIL").ToString());
                axTextBox5.SetValue(grd01.GetValue(row, "DEPT").ToString());
            }
            else
            {
                m_MID = "";
            }
        }
        private void ResetInput()
        {
            m_MID = "";
            axTextBox2.SetValue("");
            axTextBox3.SetValue("");
            axTextBox4.SetValue("");
            axTextBox5.SetValue("");
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            string email = axTextBox4.GetValue().ToString();
            string phone = axTextBox3.GetValue().ToString();
            string mid = m_MID;
            string bizcd = cbo01_BIZCD.GetValue().ToString();
            if (string.IsNullOrEmpty(phone) && string.IsNullOrEmpty(email))
            {
                MsgBox.Show("if E-Mail or Phone is empty, we cannot send any OTP!!");
                return;
            }
            else
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("MID", mid);

                set.Add("PHONE", phone);
                set.Add("EMAIL", email);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SEND_OTP"), set);
            }
        }





    }
}

