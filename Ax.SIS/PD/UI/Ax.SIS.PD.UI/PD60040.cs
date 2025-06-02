#region ▶ Description & History
/* 
 * 프로그램명 : PD60040 사출수지탱크 중량 이력(07시 기준)
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
    /// 사출수지탱크 중량 이력(08시 기준)
    /// </summary>
    public partial class PD60040 : AxCommonBaseControl
    {
        //private IPD60040 _WSCOM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD60040";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";

        #region [ 초기화 작업 정의 ]

        public PD60040()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD60040>("PD", "PD60040.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "수지탱크코드", "RES_TANK_NO", "RES_TANK_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 240, "수지탱크명칭", "RES_TANK_NM", "RES_TANK_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "측정시간", "MEASURE_TIME", "MIX_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "측정중량", "MEASURE_WT", "MEASURE_WT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "단위", "UNIT", "UNIT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "등록일자", "INSERT_DATE", "REG_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "등록자ID", "INSERT_USER_ID", "INSERT_USER_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "수정일자", "UPDATE_DATE", "AMD_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "수정자ID", "UPDATE_USER_ID", "UPDATE_USER_ID");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSERT_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "UPDATE_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "MEASURE_WT");
                this.grd01.Cols["MEASURE_WT"].Format = "#,###,###,###,##0"; ;

                for (int i = 0; i <= this.grd01.Cols["RES_TANK_NM"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("WORK_SDATE", this.dtp01_WORK_SDATE.GetDateText());
                set.Add("WORK_EDATE", this.dtp01_WORK_EDATE.GetDateText());
                set.Add("RES_TANK_NO", this.cbo01_RESTANK.GetValue());

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

        #region [ 기타 컨트롤 이벤트 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_RESTANK"), set);
                //DataSet source = _WSCOM_MES.INQUERY_COMBO_RESTANK(this.cbo01_BIZCD.GetValue().ToString());

                this.cbo01_RESTANK.DataBind(source.Tables[0]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
