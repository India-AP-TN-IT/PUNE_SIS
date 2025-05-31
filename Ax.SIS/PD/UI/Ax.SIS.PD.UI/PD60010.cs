#region ▶ Description & History
/* 
 * 프로그램명 : PD60010 사출 믹서 신재 및 분쇄재 중량 이력 조회
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
    /// 사출 믹서 신재 및 분쇄재 중량 이력 조회
    /// </summary>
    public partial class PD60010 : AxCommonBaseControl
    {
        //private IPD60010 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD60010";

        #region [ 초기화 작업 정의 ]

        public PD60010()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD60010>("PD", "PD60010.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.heDockingTab1.LinkBody  = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "COR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "수지믹서번호", "MIXER_NO", "MIXER_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "믹싱순번", "SEQ", "MIXER_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "측정시간", "MIX_TIME", "MIX_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "신재중량", "NEW_WT", "NEW_WT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 150, "분쇄재중량", "REUSE_WT", "REUSE_WT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "최종중량", "TOTAL_WT", "TOTAL_WT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "분쇄재 비율(%)", "REUSE_RATE", "REUSE_RATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "NEW_WT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "REUSE_WT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOTAL_WT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "REUSE_RATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.dtp01_SDATE.SetValue(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01));
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
                set.Add("WORK_SDATE", this.dtp01_SDATE.GetDateText());
                set.Add("WORK_EDATE", this.dtp01_EDATE.GetDateText());
                set.Add("MIXER_NO", this.txt01_MIXNO.GetValue());

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

        
        #region [ 기타 이벤트 정의 ]
        
        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            grd01.AllowMerging = (this.chk01_GRID_MERGE.Checked) ?
                C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                C1.Win.C1FlexGrid.AllowMergingEnum.None;
        }

        #endregion

    }
}
