#region ▶ Description & History
/* 
 * 프로그램명 : PD40470 통전 오류 조회(외수내자 전용)
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
    public partial class PD40470 : AxCommonBaseControl
    {
        //private IPD20190 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD40470";
        public PD40470()
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

                
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "사업장", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "라인", "LINECD", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "위치", "INSTALL_POS", "INSTALL_POS");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "실적", "RSLT_CNT", "RSLT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "오류", "ERR_CNT", "ERR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "오류율(%)", "RATE", "ERR_RATE");


                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "ERR_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RATE");


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "ALC", "ALCCD", "ALC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNOTITLE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "검사시간", "INSPEC_DATE", "INSPECT_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "항목코드", "INSPECCD", "MGRT_EXPNCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "항목명", "ET_DESC", "MGRT_EXPNNM");


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
                set.Add("LINECD", "");
                set.Add("PROCCD", "");
                set.Add("INSTALL_POS", "");
                
                
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
                string proccd = "";


                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", "5220");
                set.Add("PROD_DATE", heDateEdit1.GetDateText());
                set.Add("LINECD", linecd);
                set.Add("PROCCD", proccd);
                set.Add("INTALL_POS", installPos);

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
