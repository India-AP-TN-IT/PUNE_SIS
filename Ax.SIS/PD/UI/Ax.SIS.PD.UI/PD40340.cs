#region ▶ Description & History
/* 
 * 프로그램명 : PD40340 장기 재고 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
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
using C1.Win.C1FlexGrid;
using System.Drawing;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 장기 재고 조회 
    /// </summary>
    public partial class PD40340 : AxCommonBaseControl
    {
        //private IPD40340 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD40340";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        public PD40340()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD40340>("PD", "PD40340_N.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody  = this.panel4;
                this.heDockingTab1.LinkPanel = this.panel2;
                
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "라인", "LINECD", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "라인명", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 30, "POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "P/NO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "ALC", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "LOT NO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "RACK NO", "LODTBL_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "입고일자", "IN_READ_DATE", "RCV_DATE");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "IN_READ_DATE");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                         
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZNM2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "라인", "LINECD", "LINE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "라인명", "LINENM", "LINENM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 30, "POS", "INSTALL_POS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "P/NO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PROD DATE", "PROD_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "LTI QTY", "LTI_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "UPRICE", "UPRICE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "INV COST", "INV_COST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Exp. DATE", "EXP_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "Days", "NO_DAYS");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.Date.ToString("dd-MM"), "CUST_D1DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(1).Date.ToString("dd-MM"), "CUST_D2DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(2).Date.ToString("dd-MM"), "CUST_D3DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(3).Date.ToString("dd-MM"), "CUST_D4DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(4).Date.ToString("dd-MM"), "CUST_D5DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(5).Date.ToString("dd-MM"), "CUST_D6DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(6).Date.ToString("dd-MM"), "CUST_D7DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(7).Date.ToString("dd-MM"), "CUST_D8DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(8).Date.ToString("dd-MM"), "CUST_D9DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(9).Date.ToString("dd-MM"), "CUST_D10DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(10).Date.ToString("dd-MM"), "CUST_D11DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(11).Date.ToString("dd-MM"), "CUST_D12DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(12).Date.ToString("dd-MM"), "CUST_D13DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(13).Date.ToString("dd-MM"), "CUST_D14DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(14).Date.ToString("dd-MM"), "CUST_D15DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(15).Date.ToString("dd-MM"), "CUST_D16DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(16).Date.ToString("dd-MM"), "CUST_D17DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(17).Date.ToString("dd-MM"), "CUST_D18DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(18).Date.ToString("dd-MM"), "CUST_D19DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, DateTime.Now.AddDays(19).Date.ToString("dd-MM"), "CUST_D20DAY_QTY");

                this.grd02.Cols["BIZCD"].AllowMerging = true;
                this.grd02.Cols["LINECD"].AllowMerging = true;
                this.grd02.Cols["LINENM"].AllowMerging = true;
                this.grd02.Cols["INSTALL_POS"].AllowMerging = true;
                this.grd02.Cols["PARTNO"].AllowMerging = true;
                this.grd02.Cols["ALCCD"].AllowMerging = true;

                this.grd01.Cols["BIZCD"].AllowMerging = true;
                this.grd01.Cols["LINECD"].AllowMerging = true;
                this.grd01.Cols["LINENM"].AllowMerging = true;
                this.grd01.Cols["INSTALL_POS"].AllowMerging = true;
                this.grd01.Cols["PARTNO"].AllowMerging = true;
                this.grd01.Cols["ALCCD"].AllowMerging = true;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.SetRequired(this.lbl02_LINE);
                this.cbo01_INSTALL_POS.DataBind("A7");
                this.txt03_Days.SetValue(20);

                grd02.Cols.Frozen = 6;

                CellStyle csEXP000 = grd02.Styles.Add("EXP000");
                csEXP000.Font = new Font(this.Font, FontStyle.Bold);
                csEXP000.ForeColor = Color.White;
                csEXP000.BackColor = Color.Red;

                CellStyle csEXP100 = grd02.Styles.Add("EXP100");
                csEXP100.Font = new Font(this.Font, FontStyle.Bold);
                csEXP100.ForeColor = Color.Black;
                csEXP100.BackColor = Color.Beige;
                
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
                if (string.IsNullOrEmpty(this.cbl01_LINECD.GetValue().ToString()))
                {
                    MsgBox.Show("LINE is mandatory field");
                    return;
                }
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("LINECD", this.cbl01_LINECD.GetValue());
                    set.Add("LOTNO", "");
                    set.Add("BEG_DATE", "");
                    set.Add("END_DATE", "");
                    set.Add("LANG_SET", this.UserInfo.Language);
                    set.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue());
                    set.Add("DAYS", this.txt03_Days.GetValue());
                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                    this.grd01.SetValue(source);
                }
                else
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("LINECD", this.cbl01_LINECD.GetValue());
                    set.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue());
                    set.Add("DAYS", this.txt03_Days.GetValue());
                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_LONG_TERM_INVENTORY_DETAIL"), set, "OUT_CURSOR");

                    DataTable dt = source.Tables[0];
                    Set_Grid(dt);

                    this.grd02.SetValue(source);

                    for (int i = 1; i < grd02.Rows.Count; i++)
                    {
                        if (Convert.ToInt16(grd02.Rows[i]["NO_DAYS"]) > 10 || Convert.ToInt16(grd02.Rows[i]["NO_DAYS"]) == 0) this.grd02.SetCellStyle(i, 12, "EXP000");
                        else this.grd02.SetCellStyle(i, 12, "EXP100");
                    }
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


        #region [ 기타 이벤트 정의 ]

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            this.grd01.AllowMerging = (this.chk01_MERGE.Checked == true) ?
                C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                C1.Win.C1FlexGrid.AllowMergingEnum.None;
        }

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set.Add("PRDT_DIV", "");
            set.Add("LANG_SET", this.UserInfo.Language);
            this.cbl01_LINECD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            //this.cbl01_LINECD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
        }
        
        #endregion

        #region [ 사용자 정의 메서드 ]

        private void Set_Grid(DataTable dt)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int sum = 0;
                    DateTime pd = Convert.ToDateTime(dt.Rows[i]["PROD_DATE"]);
                    dt.Rows[i]["PROD_DATE"] = pd.ToString("dd-MM-yyyy");
                    int iLTI = Convert.ToInt16(dt.Rows[i]["LTI_QTY"]);
                    for (int j = 1; j < 21;j++ )
                    {
                        int iKPLAN = Convert.ToInt16(dt.Rows[i]["CUST_D"+j+"DAY_QTY"]);
                        sum = sum + iKPLAN;
                        if (sum >= iLTI)
                        {
                            dt.Rows[i]["NO_DAYS"] = j;
                            dt.Rows[i]["EXP_DATE"] = DateTime.Now.AddDays(j - 1).Date.ToString("dd-MM-yyyy");
                            break;
                        }
                    }
                    if (sum == 0)
                    {
                        dt.Rows[i]["NO_DAYS"] = sum;
                    }
                }
            }
            catch
            {
                
            }
        }

        private string GetOldLotHeaderLocal(DateTime date)
        {
            try
            {
                //08:00기준으로 오늘 로컬 날짜를 가져옴
                DateTime dtNow = date;

                //년(2000-A, 2001-B ...)
                string strY = Convert.ToChar(65 + dtNow.Year - 2000).ToString();

                //월(0~9, A, B)
                string strM = string.Format("{0:X}", dtNow.Month);

                //일(0~9, A, B, ...)
                string strD = (dtNow.Day < 10) ? dtNow.Day.ToString() : Convert.ToChar(65 + dtNow.Day - 10).ToString();
                return strY + strM + strD;
            }
            catch
            {
                return "";
            }
        }
        
        #endregion

    }
}
