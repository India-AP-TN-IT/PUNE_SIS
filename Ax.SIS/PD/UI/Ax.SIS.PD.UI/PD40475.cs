#region ▶ Description & History
/* 
 * 프로그램명 : PD40475 공정 투입실적 조회(아산)
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
    /// 생산라인 공정투입 실적 조회
    /// </summary>
    public partial class PD40475 : AxCommonBaseControl
    {
        //private IPD20190 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD40475";
        public PD40475()
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
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "라인", "LINECD", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "라인명", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "위치", "INSTALL_POS", "INSTALL_POS");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "계획", "PLAN_QTY", "PLAN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "공정실적", "RSLT_QTY", "PROC_RSLT_QTY");


                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PLAN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY");


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "07~08", "RSLT_QTY07", "RSLT_QTY07");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "08~09", "RSLT_QTY08", "RSLT_QTY08");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "09~10", "RSLT_QTY09", "RSLT_QTY09");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "10~11", "RSLT_QTY10", "RSLT_QTY10");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "11~12", "RSLT_QTY11", "RSLT_QTY11");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "12~13", "RSLT_QTY12", "RSLT_QTY12");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "13~14", "RSLT_QTY13", "RSLT_QTY13");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "14~15", "RSLT_QTY14", "RSLT_QTY14");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "15~16", "RSLT_QTY15", "RSLT_QTY15");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "16~17", "RSLT_QTY16", "RSLT_QTY16");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "17~18", "RSLT_QTY17", "RSLT_QTY17");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "18~19", "RSLT_QTY18", "RSLT_QTY18");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "19~20", "RSLT_QTY19", "RSLT_QTY19");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "20~21", "RSLT_QTY20", "RSLT_QTY20");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "21~22", "RSLT_QTY21", "RSLT_QTY21");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "22~23", "RSLT_QTY22", "RSLT_QTY22");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "23~24", "RSLT_QTY23", "RSLT_QTY23");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "00~01", "RSLT_QTY00", "RSLT_QTY00");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "01~02", "RSLT_QTY01", "RSLT_QTY01");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "02~03", "RSLT_QTY02", "RSLT_QTY02");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "03~04", "RSLT_QTY03", "RSLT_QTY03");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "04~05", "RSLT_QTY04", "RSLT_QTY04");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "05~06", "RSLT_QTY05", "RSLT_QTY05");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "06~07", "RSLT_QTY06", "RSLT_QTY06");


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
                set.Add("LINECD", "IG");
                set.Add("INSTALL_POS", "");
                set.Add("LANG_SET", this.UserInfo.Language);
                
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
                string vincd = grd01.GetValue(grd01.Row, "VINCD").ToString();


                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", "5220");
                set.Add("PROD_DATE", heDateEdit1.GetDateText());
                set.Add("LINECD", linecd);
                set.Add("VINCD", vincd);
                set.Add("INSTALL_POS", installPos);
                set.Add("LANG_SET", this.UserInfo.Language);

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
