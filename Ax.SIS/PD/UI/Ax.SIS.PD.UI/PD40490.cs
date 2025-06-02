#region ▶ Description & History
/* 
 * 프로그램명 : PD40490 아산 MMC이송시간 모니터링
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
using System.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 장기적재 기준일 관리
    /// </summary>
    public partial class PD40490 : AxCommonBaseControl
    {
        //private IPD20190 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD40490";
        public PD40490()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20190>("PD", "PD20190.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "공정코드", "PROCCD", "PROCCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "공정명", "PROCNM", "PROCNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "합계시간(초)(A)", "TICK_SUM", "TICK_SUM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "이송횟수(B)", "CNT_SUM", "CNT_SUM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "계획정지(초)(C)", "STOP_TIME", "STOP_TIME_C");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "평균(초)((A-C)/B)", "AVG_SUM", "AVG_SUM");
                

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "TICK_SUM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CNT_SUM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOP_TIME");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "AVG_SUM");


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "순번", "WO_SEQ", "SERNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "시작시간", "ST", "BEG_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "종료시간", "ED", "END_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "차이(초)", "TIK", "DIFF_TIK");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "WO_SEQ");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "TIK");


                this.BtnQuery_Click(null, null);
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
                set.Add("BIZCD", "5220");
                set.Add("PROD_DATE", heDateEdit1.GetDateText());
                set.Add("ST_HHMMSS", heTextBox1.GetValue());
                set.Add("ED_HHMMSS", heTextBox2.GetValue());
                set.Add("FREE_TIME", heTextBox3.GetValue());
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
               
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

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string linecd = grd01.GetValue(grd01.Row, "LINECD").ToString();
                string installPos = grd01.GetValue(grd01.Row, "INSTALL_POS").ToString();
                string proccd = grd01.GetValue(grd01.Row, "PROCCD").ToString();


                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", "5220");
                set.Add("PROD_DATE", heDateEdit1.GetDateText());
                set.Add("LINECD", linecd);
                set.Add("PROCCD", proccd);
                set.Add("INTALL_POS", installPos);
                set.Add("ST_HHMMSS", heTextBox1.GetValue());
                set.Add("ED_HHMMSS", heTextBox2.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DET"), set, "OUT_CURSOR");

                grd02.SetValue(source);
                this.AfterInvokeServer();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
