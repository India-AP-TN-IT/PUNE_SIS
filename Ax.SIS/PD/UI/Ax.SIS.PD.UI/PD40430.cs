#region ▶ Description & History
/* 
 * 프로그램명 : PD40430 ALC서열 대비 MES출고 실적 비교
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


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 장기재고 이력조회
    /// </summary>
    public partial class PD40430 : AxCommonBaseControl
    {
        //private IPD40430 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40430";
        public PD40430()
        {
            InitializeComponent();

            //_WSCOM  = ClientFactory.CreateChannel<IPD40430>("PD", "PD40430_N.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "SEQ", "LSEQ", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "차종코드", "VINCD", "VINCD");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "FL 투입 LOTNO", "FL_LOTNO", "FL_IN_LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "FR 투입 LOTNO", "FR_LOTNO", "FR_IN_LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "RL 투입 LOTNO", "RL_LOTNO", "RL_IN_LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "RR 투입 LOTNO", "RL_LOTNO", "RR_IN_LOTNO");



                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "FL 수주ALC", "ERM_DTFL", "ERM_DTFL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "FL MES ALC", "MES_DTFL", "MES_DTFL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "FR 수주ALC", "ERM_DTFR", "ERM_DTFR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "FR MES ALC", "MES_DTFR", "MES_DTFR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "RL 수주ALC", "ERM_DTRL", "ERM_DTRL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "RL MES ALC", "MES_DTRL", "MES_DTRL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "RR 수주ALC", "ERM_DTRR", "ERM_DTRR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "RR MES ALC", "MES_DTRR", "MES_DTRR");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "FL 투입상태", "CHKFL", "CHK_IN_FL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "FR 투입상태", "CHKFR", "CHK_IN_FR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "RL 투입상태", "CHKRL", "CHK_IN_RL");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "RR 투입상태", "CHKRR", "CHK_IN_RR");
               

             
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);                
                set.Add("S_DATE", this.dtp01_INSPEC_SDATE.GetDateText());
                set.Add("R_DATE", this.dtp01_INSPEC_SDATE.GetDateText().ToString().Replace("-",""));
                set.Add("ERR_YN", chk01_PD40430_CHK01.Checked == true ?"Y": "N");

                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.grd01.SetValue(source);
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

        #endregion
    }
}
