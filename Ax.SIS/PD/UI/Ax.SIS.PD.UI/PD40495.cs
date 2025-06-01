#region ▶ Description & History
/* 
 * 프로그램명 : PD40495 협력사 재고조회(아산)
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
    public partial class PD40495 : AxCommonBaseControl
    {
        //private IPD20190 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD40495";
        public PD40495()
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
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "LOT", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "입고일자", "IN_RSLT_DATE", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "상태", "INV_STATUS", "STATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "출고일자", "OUT_RSLT_DATE", "OUT_DATE");



                heTextBox1.SetValue("IG");

                //this.BtnQuery_Click(null, null);
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
                if (heTextBox1.GetValue().ToString().Length > 1)
                {
                    string bizcd = this.UserInfo.BusinessCode;

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", "1040");
                    set.Add("BIZCD", "1042");
                    set.Add("PROD_DATE", heDateEdit1.GetDateText());
                    set.Add("LINECD", heTextBox1.GetValue());
                    set.Add("PARTNO", heTextBox2.GetValue());
                    set.Add("CUR_YN", chk01_CURR_INV_STD.Checked == true ? "Y" : "N");


                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                    this.AfterInvokeServer();

                    this.grd01.SetValue(source.Tables[0]);
                }
                else
                {

                }
               
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
