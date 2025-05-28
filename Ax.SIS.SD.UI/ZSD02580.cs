#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
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
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZSD02580 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02580";

        #region [ 초기화 작업 정의 ]

        public ZSD02580()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            
        }
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                Lbl_detQTY.Text = "";
                Lbl_TotalQuantity.Text = "";
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "INVOICE", "INVOICE", "INVOICE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "VENDOR", "CUSTNM", "CUSTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "NEW", "NEW_DATA", "NEW_DATA");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "IRN", "IRN", "IRN");


                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "TRUCK No.", "CARNO", "CARNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 45, "PGN", "PGN", "PGN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "D/TYPE", "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "O/NO", "SANO", "SANO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 60, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 40, "SEQ", "SEQID", "SEQID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "P/NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "P/NAME", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY.", "QTY", "QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "U/PRICE", "UPRICE", "UPRICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "AMOUNT", "AMT", "AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "CGST", "CGST", "CGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "SGST", "SGST", "SGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "IGST", "IGST", "IGST");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 70, "UTGST", "UTGST", "UTGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "TCS", "TCS", "TCS");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "INVOICE", "INVOICE", "INVOICE");
                

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "IRN", "E_YN", "E_YN");

                //<<BUFFERS
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUSTCD", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUST_PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "DELI_DATE", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CARSEQ", "CARSEQ", "CARSEQ");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "GATE", "GATE", "GATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "USER_ID", "USER_ID", "USER_ID");
                //>>



                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd01.Cols["QTY"].Format = "###,###,###,##0";

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "UPRICE");
                this.grd01.Cols["UPRICE"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd01.Cols["AMT"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CGST");
                this.grd01.Cols["CGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SGST");
                this.grd01.Cols["SGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IGST");
                this.grd01.Cols["IGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "UTGST");
                this.grd01.Cols["UTGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "TCS");
                this.grd01.Cols["TCS"].Format = "###,###,###,##0.##";


                //this.grd01.Cols["UPRICE"].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;


                string TotalQuantity = "0";
                this.Lbl_TotalQuantity.Text = string.Format("{0} : {1:N0}", "Total Quantity", TotalQuantity);

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";

                BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        

        private string GetChkType()
        {
            if(RD_All.Checked == true)
            {
                return "A";
            }
            else if(RD_New.Checked == true)
            {
                return "N";
            }
            else if(RD_IRP.Checked == true)
            {
                return "I";
            }
            return "A";
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                
                string bizcd = cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("DELI_DATE", axDateEdit1.GetDateText());
                set.Add("INVOICE", Txt_INV.GetValue());
                set.Add("VENDCD", cdx01_VENDCD.GetValue());
                set.Add("TYPE", GetChkType());
               
               
                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_INVOICE_HEADER"), set, "OUT_CURSOR");
                grd02.SetValue(source);
                this.AfterInvokeServer();

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

        private void Print_Invoice()
        {
            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/ZSD02580";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", axDateEdit1.GetDateText());
                set.Add("INVOICE", axTextBox3.GetValue());


                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_PRINTDATA"), set, "OUT_CURSOR");
                this.AfterInvokeServer();
                HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
                report.Sections.Add("MAIN", xmlSection);

                AxRexpertReportViewer.ShowReport(report);

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
        
        private void GetDetData()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", axDateEdit1.GetDateText());
                set.Add("INVOICE", axTextBox3.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_INVOICE_DETAIL"), set, "OUT_CURSOR");
                this.AfterInvokeServer();
                if(source.Tables.Count>0 && source.Tables[0].Rows.Count>0)
                {
                    axTextBox1.SetValue(source.Tables[0].Rows[0]["CARNO"].ToString());
                }
                this.grd01.SetValue(source.Tables[0]);

                if (source.Tables[0].Rows.Count > 0)
                {
                    Lbl_detQTY.Text = string.Format("Invoice : {0:N0} / IRN : {1:N0}", source.Tables[0].Rows[0]["INV_CNT"].ToString(), source.Tables[0].Rows[0]["IRN_CNT"].ToString());
                    string TotalQuantity = source.Tables[0].Rows[0]["TOT_QTY"].ToString();
                    this.Lbl_TotalQuantity.Text = string.Format("{0} : {1:N0}", "Total Quantity", TotalQuantity);
                }
                else
                {
                    Lbl_detQTY.Text = "Invoice : 0 / IRN : 0";
                    this.Lbl_TotalQuantity.Text = string.Format("{0} : {1:N0}", "Total Quantity", 0);
                }

                
            }
            catch (Exception eLog)
            {
                this.AfterInvokeServer();
            }
        }
        private void SetTruck()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", axDateEdit1.GetDateText());
                set.Add("INVOICE", axTextBox3.GetValue());
                set.Add("CARNO", axTextBox1.GetValue());
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_TRUCK"), set);
            }
            catch (Exception eLog)
            {
            }
        }
        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd02.SelectedRowIndex;
                int col = this.grd02.ColSel;
                if (row < this.grd02.Rows.Fixed) return;

                axTextBox3.SetValue(grd02.GetValue(row, "INVOICE").ToString());
                axTextBox4.SetValue(grd02.GetValue(row, "CUSTNM").ToString());
                
                GetDetData();
            }
            catch (Exception eLog)
            {

            }
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(axTextBox1.GetValue().ToString()) == true)
                {
                    MsgBox.Show("Vehicle Number is not inputed.", "Error", MessageBoxButtons.OK);
                    axTextBox1.Focus();
                    return;
                }
                SetTruck();

                //TO DO : E-Invoicing
            }
            catch(Exception eLog)
            {

            }
        }

        private void axButton4_Click(object sender, EventArgs e)
        {
            if (grd01.Rows.Count < 1)
            {
                MsgBox.Show("Select an Invoice to Print", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }
            Print_Invoice();
        }




    }
}

