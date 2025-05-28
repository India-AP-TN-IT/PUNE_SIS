#region ▶ Description & History
/* 
 * 프로그램명 : 생산실적 마감 처리
 * 설     명 : 
 * 최초작성자 : 오세민
 * 최초작성일 : 2012-10-23
 * 최종수정자 :
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2012-10-23	오세민		최초 개발
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Collections.Generic;
using System.Drawing;
namespace Ax.SIS.BM.BM00.UI
{
    //sdfasdf
    public partial class BM60050 : AxCommonBaseControl
    {
        //private IPM63130 _WSCOM;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_BM_SAP_TO_MBOM";
        private DateTime m_qDate = DateTime.Now;
        double CN_REFRESH_TIME = 10;
        public BM60050()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM63130>("PM03", "PM63130.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));


                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
               
                this.grd02.Initialize();
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "PLANT", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "STATE", "STATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "DATE", "STD_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "CAR", "VINCD");
               
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "USER", "USERID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "USER", "EMPNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "INPUT DATE", "INS_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "RUN DATE", "RUN_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "FINISH DATE", "FINISH_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 210, "Message", "RUN_MSG");

                this.grd02.AddMerge(0, 0, "USERID", "EMPNM");

                GetJobList();

                m_qDate = DateTime.Now.AddSeconds(-1 * CN_REFRESH_TIME);
                timer1.Start();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        private void GetJobList()
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", UserInfo.CorporationCode);
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("VINCD", cdx01_VINCD.GetValue());
            paramSet.Add("ST_DATE", dtp01_S_DATE.GetDateText());

            DataTable dt = _WSCOM.ExecuteDataSet("APG_BM_SAP_TO_MBOM.GET_JOB_LIST", paramSet, "OUT_CURSOR").Tables[0];
            this.grd02.SetValue(dt);

        }
        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            base.BtnQuery_Click(sender, e);
            GetJobList();
        }
        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (string.IsNullOrEmpty(cdx01_VINCD.GetValue().ToString()))
                {
                    MsgBox.Show("You have to select the Car");
                    return;
                }
                
                if (MsgBox.Show("Do you want to expand BOM from SAP", "Question", System.Windows.Forms.MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                DataSet source02 = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD"
                                                                  , "STD_DATE", "VINCD", "UPDATE_USER");
                
                source02.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.cbo01_BIZCD.GetValue(),
                    this.dtp01_S_DATE.GetDateText(),                    
                    this.cdx01_VINCD.GetValue(),
                    this.UserInfo.UserID);
               
                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_BM_SAP_TO_MBOM.SET_QUEUE_BATCH", source02);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);

                GetJobList();
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());

            }
            finally
            {

                this.AfterInvokeServer();
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]


        private void dtp01_S_DATE_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //DateTime dt = DateTime.Parse(dtp01_S_DATE.GetValue().ToString());
                //dt = dt.AddDays(+4);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            double r = (DateTime.Now - m_qDate).TotalSeconds;
            heButton2.Text = "Refresh(" + (CN_REFRESH_TIME - r).ToString("N0") + ")";
            if (r > CN_REFRESH_TIME)
            {
                GetJobList();

                m_qDate = DateTime.Now;
            }
            timer1.Start();
        }

        private void heButton2_Click(object sender, EventArgs e)
        {
            GetJobList();
        }



    }
}
