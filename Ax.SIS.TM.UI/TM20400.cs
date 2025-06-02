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
    
    public partial class TM20400 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;
       
        public TM20400()
        {
            InitializeComponent();

            _DB = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //CORCD
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //BIZCD
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void ClearCtl()
        {
            Txt_Wh_Addr.SetValue("");
            Txt_PhoneNO.SetValue("");
            Txt_PWD.SetValue("");
            Txt_KeyID.SetValue("");
            Txt_ID.SetValue("");
            Txt_Web_Addr.SetValue("");
            Txt_Web_Addr2.SetValue("");
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("WA_ADDR", Txt_Wh_Addr.GetValue());
                set.Add("WA_KEYID", Txt_KeyID.GetValue());
                set.Add("WA_PHONE", Txt_PhoneNO.GetValue());
                set.Add("WA_ID", Txt_ID.GetValue());
                set.Add("WA_PWD", Txt_PWD.GetValue());
                set.Add("WEB_ADDR", Txt_Web_Addr.GetValue());
                set.Add("WEB_ADDR2", Txt_Web_Addr2.GetValue());
                set.Add("UPDATE_ID", UserInfo.UserID);

                this.BeforeInvokeServer(true);
                
                 _DB.ExecuteNonQueryTx("APG_TM20400.SAVE", set);


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

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
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                ClearCtl();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
               
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _DB.ExecuteDataSet("APG_TM20400.INQUERY", set, "OUT_CURSOR");
                if(source.Tables[0].Rows.Count>0)
                {
                    Txt_Wh_Addr.SetValue(source.Tables[0].Rows[0]["WA_ADDR"].ToString());
                    Txt_ID.SetValue(source.Tables[0].Rows[0]["WA_ID"].ToString());
                    Txt_PWD.SetValue(source.Tables[0].Rows[0]["WA_PWD"].ToString());
                    Txt_KeyID.SetValue(source.Tables[0].Rows[0]["WA_KEYID"].ToString());
                    Txt_PhoneNO.SetValue(source.Tables[0].Rows[0]["WA_PHONE"].ToString());


                    Txt_Web_Addr.SetValue(source.Tables[0].Rows[0]["WEB_ADDR"].ToString());
                    Txt_Web_Addr2.SetValue(source.Tables[0].Rows[0]["WEB_ADDR2"].ToString());
                }
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
       
    }
}

