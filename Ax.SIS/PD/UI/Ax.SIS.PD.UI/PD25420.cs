#region ▶ Description & History
/* 
 * 프로그램명 : 월별 마감 등록
 * 설     명 : 
 * 최초작성자 : 오세민
 * 최초작성일 : 2012-06-27
 * 최종수정자 :
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2012-06-27	  오세민		최초 개발
 *              2014-10-14    진승모     다국어 적용
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Collections;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;   
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;


namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>월별 마감 등록</b>
    /// </summary>
    public partial class PD25420 : AxCommonBaseControl
    {   
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD25420";

        public PD25420()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();     
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grp01_PD25221.Text = this.GetLabel("PD25221");
                this.grp01_PD25311.Text = this.GetLabel("PD25311");

                this.dtp01_STD_DATE.SetValue(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                this.dtp02_STD_DATE.SetValue(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                
                string strCorCD = this.UserInfo.CorporationCode;
                this.cbo01_SAUP.DataBind_BIZCD(strCorCD, false);
                this.cbo01_SAUP.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin != "Y")
                    this.cbo01_SAUP.SetReadOnly(true);

                this.cbo02_SAUP.DataBind_BIZCD(strCorCD, false);
                this.cbo02_SAUP.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin != "Y")
                    this.cbo02_SAUP.SetReadOnly(true);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

      

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        #endregion

        #region [ 유효성 검사 ]

        private bool IsProcessValid(string corcd, string bizcd, string std_date, string menuid, string lock_type)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", corcd);
                set.Add("BIZCD", bizcd);
                set.Add("STD_DATE", std_date);
                set.Add("MENUID", menuid);
                set.Add("LOCK_TYPE", lock_type);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LOCK"), set);
                if (source.Tables[0].Rows.Count <= 0)
                {
                    //해당일자 잠금 기준 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0103");
                    return false;
                }

                if (source.Tables[0].Rows[0]["LOCK_STA"].ToString().Equals("Y"))
                {
                    //이미 잠금처리 되었습니다.
                    MsgCodeBox.Show("PD00-0098");
                    return false;
                }


                //I/F 전송하시겠습니까?
                if (MsgCodeBox.Show("PD00-0107", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }


        #endregion

        private void btn01_PROCESS_Click(object sender, EventArgs e)
        {
            try
            {

                string corcd = this.UserInfo.CorporationCode;
                string bizcd = this.cbo01_SAUP.GetValue().ToString();
                string menuid = "PD25311/2";
                string lock_type = "A";
                string std_date = this.dtp01_STD_DATE.GetDateText().ToString();

                if (!IsProcessValid(corcd, bizcd, std_date, menuid, lock_type))
                    return;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", corcd);
                set.Add("BIZCD", bizcd);
                set.Add("STD_DATE", std_date);
                set.Add("MENUID", menuid);
                set.Add("LOCK_TYPE", lock_type);
                set.Add("USERID", this.UserInfo.UserID);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer();
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROCESS_PD25311"), set);
                this.AfterInvokeServer();

                //SAP Interface 정보 생성이 완료되었습니다.
                MsgCodeBox.Show("PD00-0099");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_PROCESS_Click(object sender, EventArgs e)
        {
            try
            {
                string corcd = this.UserInfo.CorporationCode;
                string bizcd = this.cbo02_SAUP.GetValue().ToString();
                string menuid = "PD25221";
                string lock_type = "A";
                string std_date = this.dtp02_STD_DATE.GetDateText().ToString();

                if (!IsProcessValid(corcd, bizcd, std_date, menuid, lock_type))
                    return;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", corcd);
                set.Add("BIZCD", bizcd);
                set.Add("STD_DATE", std_date);
                set.Add("MENUID", menuid);
                set.Add("LOCK_TYPE", lock_type);
                set.Add("USERID", this.UserInfo.UserID);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer();
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROCESS_PD25221"), set);
                this.AfterInvokeServer();
                
                //SAP Interface 정보 생성이 완료되었습니다.
                MsgCodeBox.Show("PD00-0099");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
    }
}
