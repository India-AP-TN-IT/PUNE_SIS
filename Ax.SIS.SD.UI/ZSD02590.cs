using System;
using System.Data;
using System.ServiceModel;


using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
using System.Diagnostics;
using System.Data.OleDb;
using System.Text;


namespace Ax.SIS.SD.UI
{
    public partial class ZSD02590 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02590";
        public ZSD02590()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);                

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";
                this.axCodeBox1.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("KK", true, true, this.axCodeBox1);

                SetCustPLANT();
                
                //this.cbl01_CustCD.SetValue("303408");
                //this.cbl01_CustPLANT.SetValue("KVF1");
                dte01_SDATE.SetValue(DateTime.Now.AddDays(-1));
                DataSet ds01 = this.GetDataSourceSchema("Code", "CodeValue");
                ds01.Tables[0].Rows.Add("A3", "A3");
                ds01.Tables[0].Rows.Add("A4", "A4");
                ds01.Tables[0].Rows.Add("B2", "B2");
                ds01.Tables[0].Rows.Add("B3", "B3");
                ds01.Tables[0].Rows.Add("B4", "B4");
                this.cbo01_GATE.DataBind(ds01.Tables[0], true);

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 40, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 45, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 34, "C", "CHK", "CHK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "SAP", "SAPIF_YN", "SAPIF_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "IRN", "E_YN", "E_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "COUNT", "CNT", "CNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "TYPE", "TY", "TY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 75, "O/DATE", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "INVOICE DATE", "INV_DATE", "INV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "GATE-OUT DATE", "GATE_DATE", "GATE_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "CUSTOMER Code", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "CUSTOMER NM", "CUSTNM", "CUSTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "INVOICE", "INVOICE", "INVOICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "GATE", "GATE", "GATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "TRUCK", "CARNO", "CARNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "T/SEQ", "CARSEQ", "CARSEQ");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "QTY.", "QTY", "QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "AMOUNT", "AMT", "AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "TOT. CGST", "CGST", "CGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "TOT. SGST", "SGST", "SGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "TOT. IGST", "IGST", "IGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "TOT. TCS", "TCS", "TCS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "TOTAL", "TOTAL", "TOTAL");                
                
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd01.Cols["QTY"].Format = "###,###,###,##0";

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd01.Cols["AMT"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CGST");
                this.grd01.Cols["CGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SGST");
                this.grd01.Cols["SGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "TCS");
                this.grd01.Cols["TCS"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IGST");
                this.grd01.Cols["IGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOTAL");
                this.grd01.Cols["TOTAL"].Format = "###,###,###,##0.##";

                this.grd02.AllowEditing = true;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "INVOICE", "INVOICE", "INVOICE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 40, "I/SEQ", "SEQID", "SEQID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "P/NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "P/NAME", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "LOC", "STR_LOC", "STR_LOC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UOM", "UOM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY.", "QTY", "QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "U/PRICE", "UPRICE", "UPRICE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "AMOUNT", "AMT", "AMT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "CGST", "CGST", "CGST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "SGST", "SGST", "SGST");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "IGST", "IGST", "IGST");
                

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd02.Cols["QTY"].Format = "###,###,###,##0";

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd02.Cols["AMT"].Format = "###,###,###,##0.##";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "CGST");
                this.grd02.Cols["CGST"].Format = "###,###,###,##0.##";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "SGST");
                this.grd02.Cols["SGST"].Format = "###,###,###,##0.##";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "IGST");
                this.grd02.Cols["IGST"].Format = "###,###,###,##0.##";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "UPRICE");
                this.grd02.Cols["UPRICE"].Format = "###,###,###,##0.##";




                this.grd03.AllowEditing = false;
                this.grd03.Initialize();

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 75, "O/DATE", "DELI_DATE", "DELI_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CUSTOMER Code", "CUSTCD", "CUSTCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "CUSTOMER NM", "CUSTNM", "CUSTNM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "AMOUNT", "AMT", "AMT");
                
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd03.Cols["AMT"].Format = "###,###,###,##0.##";

                this.grd04.AllowEditing = false;
                this.grd04.Initialize();

                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 75, "O/DATE", "DELI_DATE", "DELI_DATE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "INVOICE", "INVOICE", "INVOICE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CUSTOMER Code", "CUSTCD", "CUSTCD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "CUSTOMER NM", "CUSTNM", "CUSTNM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "P/NO", "PARTNO", "PARTNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "P/NAME", "PARTNM", "PARTNM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UOM", "UOM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY.", "QTY", "QTY");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "AMOUNT", "AMT", "AMT");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd04.Cols["AMT"].Format = "###,###,###,##0.##";
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd04.Cols["QTY"].Format = "###,###,###,##0";


                this.grd05.AllowEditing = false;
                this.grd05.Initialize();

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Truck", "CARNO", "CARNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Trip Times", "RTIME", "RTIME");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "OURS", "OUR_OWN", "OUR_OWN");
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Int, "RTIME");



                this.grd06.AllowEditing = false;
                this.grd06.Initialize();
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Truck", "CARNO", "CARNO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 75, "O/DATE", "DELI_DATE", "DELI_DATE");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "INVOICE DATE", "INVOICE_DATE", "INVOICE_DATE");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "GATE-OUT DATE", "GATE_DATE", "GATE_DATE");
                this.grd06.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "CUSTOMER Code", "CUSTCD", "CUSTCD");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "CUSTOMER NAME", "CUSTNM", "CUSTNM");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "QTY.", "QTY", "QTY");
                this.grd06.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd06.Cols["QTY"].Format = "###,###,###,##0";

                axDateEdit1.Value = DateTime.Now.AddMonths(-1);
                this.grd07.AllowEditing = false;
                this.grd07.Initialize();
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "STATUS", "GRST", "GRST");
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "INVOICE NO.", "INVOICE", "INVOICE");
                this.grd07.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 120, "ASN NO.", "ASNNO", "ASNNO");
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "MIP PART NO.", "PARTNO", "PARTNO");
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "CUST.PART NO.", "PNO", "PNO");
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "PART NAME", "PARTNM", "PARTNM");
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UOM", "UOM");
                this.grd07.AddColumn(false, false, AxFlexGrid.FtextAlign.R, 80, "ASN/QTY", "ASN_QTY", "ASN_QTY");
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "GR/QTY", "GR_QTY", "GR_QTY");
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "SY/QTY", "SY_QTY", "SY_QTY");
                
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "GR/NO.", "GRNO", "GRNO");
                this.grd07.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "AGREEMENT", "AGNO", "AGNO");

                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "GR/DATE", "GRDATE", "GRDATE");
                this.grd07.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "D/DATE", "DELI_DATE", "DELI_DATE");

                this.grd07.SetColumnType(AxFlexGrid.FCellType.Int, "GR_QTY");
                this.grd07.Cols["GR_QTY"].Format = "###,###,###,##0";
                this.grd07.SetColumnType(AxFlexGrid.FCellType.Int, "SY_QTY");
                this.grd07.Cols["SY_QTY"].Format = "###,###,###,##0";
                this.grd07.SetColumnType(AxFlexGrid.FCellType.Int, "ASN_QTY");
                this.grd07.Cols["ASN_QTY"].Format = "###,###,###,##0";

            }
            catch(Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private string OurTruck()
        {
            if(axRadioButton8.Checked == true)
            {
                return "A";
            }
            else if (axRadioButton9.Checked == true)
            {
                return "1";
            }
            else if (axRadioButton10.Checked == true)
            {
                return "0";
            }
            return "A";
        }
        
        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = null;

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSD02500", "INQUERY_PLANT"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
       
        private string GetCate()
        {
            if(axRadioButton1.Checked)
            {
                return "N";
            }
            else if (axRadioButton2.Checked)
            {
                return "Y";
            }
            else if (axRadioButton3.Checked)
            {
                return "A";
            }
            else if (axRadioButton4.Checked)
            {
                return "C";
            }
            return "A";
        }
        private string GetTY()
        {
            if(axRadioButton6.Checked)
            {
                return "A";
            }
            else if (axRadioButton5.Checked)
            {
                return "M";
            }
            else if (axRadioButton7.Checked)
            {
                return "N";
            }
            return "A";
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                set.Add("TYPE ", this.axCodeBox1.GetValue().ToString().Replace("KK", ""));
                set.Add("BEG_DATE", this.dte01_SDATE.GetDateText().ToString());
                set.Add("END_DATE", this.dte01_EDATE.GetDateText().ToString());
                set.Add("GATE", this.cbo01_GATE.GetValue().ToString());
                set.Add("CARNO", this.axTextBox1.GetValue().ToString());
                set.Add("INVOICE", this.txt01_INVOICE.GetValue().ToString());
                set.Add("CUSTCD", this.cdx01_VENDCD.GetValue().ToString());
                set.Add("CUST_PLANT", this.cbl01_CustPLANT.GetValue().ToString());
                set.Add("LANG_SET", UserInfo.Language);
                set.Add("CAT", GetCate());
                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_INVOICE"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                ShowDataCount(source);

                for (int row = 1; row < grd01.Rows.Count; row++)
                {
                    if (grd01.GetValue(row, "SAPIF_YN").ToString() == "CANCEL")
                    {
                        grd01.Rows[row].StyleNew.BackColor = System.Drawing.Color.LightPink;
                    }
                    else if (grd01.GetValue(row, "SAPIF_YN").ToString() == "O")
                    {
                        grd01.Rows[row].StyleNew.BackColor = System.Drawing.Color.Lime;
                    }
                }
            }
            else if(tabControl1.SelectedIndex== 1)
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                set.Add("TYPE ", this.axCodeBox1.GetValue().ToString().Replace("KK", ""));
                set.Add("BEG_DATE", this.dte01_SDATE.GetDateText().ToString());
                set.Add("END_DATE", this.dte01_EDATE.GetDateText().ToString());
                set.Add("GATE", this.cbo01_GATE.GetValue().ToString());
                set.Add("CARNO", this.axTextBox1.GetValue().ToString());
                set.Add("INVOICE", this.txt01_INVOICE.GetValue().ToString());
                set.Add("CUSTCD", this.cdx01_VENDCD.GetValue().ToString());
                set.Add("CUST_PLANT", this.cbl01_CustPLANT.GetValue().ToString());
                set.Add("LANG_SET", UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SUM"), set, "OUT_CURSOR");
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SUM_DET"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd03.SetValue(source1.Tables[0]);
                this.grd04.SetValue(source2.Tables[0]);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                set.Add("TYPE ", this.axCodeBox1.GetValue().ToString().Replace("KK", ""));
                set.Add("BEG_DATE", this.dte01_SDATE.GetDateText().ToString());
                set.Add("END_DATE", this.dte01_EDATE.GetDateText().ToString());
                set.Add("GATE", this.cbo01_GATE.GetValue().ToString());
                set.Add("CARNO", this.axTextBox1.GetValue().ToString());
                set.Add("INVOICE", this.txt01_INVOICE.GetValue().ToString());
                set.Add("CUSTCD", this.cdx01_VENDCD.GetValue().ToString());
                set.Add("CUST_PLANT", this.cbl01_CustPLANT.GetValue().ToString());
                set.Add("LANG_SET", UserInfo.Language);
                set.Add("OUR_OWN", OurTruck());
                
                this.BeforeInvokeServer(true);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "TRUCK_SUM"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd05.SetValue(source1.Tables[0]);
            }

            else if (tabControl1.SelectedIndex == 3)
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                set.Add("YYYYMM ", axDateEdit1.Value.ToString("yyyyMM").ToString());
                set.Add("TY", GetTY());
                set.Add("INVOICE", txt01_INVOICE.GetValue());
                this.BeforeInvokeServer(true);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_ZSD0420"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd07.SetValue(source1.Tables[0]);
            }
        }
        
        private void Print_Invoice(string corcd, string bizcd, string custcd, string cust_plant, string ty, string invoice, string deli_date, string carno, string carseq, string gate, ref HE.Framework.ServiceModel.AxClientProxy wsCOM)
        {
            try
            {
                if (grd01.Rows.Count <= 1)
                {
                    MsgBox.Show("There is no Data to print", "Notice", MessageBoxButtons.OK, ImageKinds.Error);
                    return;
                }
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/ZSD02500B";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", deli_date);
                set.Add("INVOICE", invoice);
                set.Add("TYPE", ty);


                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_PRINTDATA_B"), set, "OUT_CURSOR");
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
        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < 1) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("INVOICE", this.grd01.GetValue(row, "INVOICE"));
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet dsInqueryDetail = _WSCOM.Inquery_Detail(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), paramSet);
                this.grd02.SetValue(source);
                ShowDataCount(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            if (grd01.Rows.Count > 1)
            {
                
                for (int j_cnt = this.grd01.Rows.Fixed; j_cnt < this.grd01.Rows.Count; j_cnt++)
                {
                    string s_value = this.grd01.GetValue(j_cnt, "CHK").ToString();
                    this.grd01.SetValue(j_cnt, "CHK", s_value == "N" ? "1" : "0");
                }
            }
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            if(grd01.Rows.Count<=0)
            {
                MsgBox.Show("There is no data to I/F", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (grd01.Rows.Count > 1)
            {
                if (MsgBox.Show("Do you want to I/F about seleceted orders?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
                {
                    for (int row = this.grd01.Rows.Fixed; row < this.grd01.Rows.Count; row++)
                    {
                        string s_value = this.grd01.GetValue(row, "CHK").ToString();
                        string invoice = this.grd01.GetValue(row, "INVOICE").ToString();
                        string corcd = this.grd01.GetValue(row, "CORCD").ToString();
                        string bizcd = this.grd01.GetValue(row, "BIZCD").ToString();
                        if (s_value == "Y")
                        {   //Selected Row
                            HEParameterSet paramSet = new HEParameterSet();

                            paramSet.Add("CORCD", corcd);
                            paramSet.Add("BIZCD", bizcd);
                            paramSet.Add("INVOICE", invoice);

                            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_SAPIF"), paramSet);




                        }
                    }
                    this.BtnQuery_Click(null, null);
                }
            }
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            if (grd01.Rows.Count <= 0)
            {
                MsgBox.Show("There is no data to Cancel", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (grd01.Rows.Count > 1)
            {
                if (MsgBox.Show("Do you want to cancel about seleceted orders?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
                {
                    for (int row = this.grd01.Rows.Fixed; row < this.grd01.Rows.Count; row++)
                    {
                        string s_value = this.grd01.GetValue(row, "CHK").ToString();
                        string invoice = this.grd01.GetValue(row, "INVOICE").ToString();
                        string corcd = this.grd01.GetValue(row, "CORCD").ToString();
                        string bizcd = this.grd01.GetValue(row, "BIZCD").ToString();
                        if (s_value == "Y")
                        {   //Selected Row
                            HEParameterSet paramSet = new HEParameterSet();

                            paramSet.Add("CORCD", corcd);
                            paramSet.Add("BIZCD", bizcd);
                            paramSet.Add("INVOICE", invoice);

                            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_CANCEL"), paramSet);




                        }
                    }
                    this.BtnQuery_Click(null, null);
                }
            }
        }

        private void axRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                this.BtnQuery_Click(null, null);
            }
        }

        private void grd05_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grd05.Rows.Count>1 && grd05.Row >= 1)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                    set.Add("TYPE ", this.axCodeBox1.GetValue().ToString().Replace("KK", ""));
                    set.Add("BEG_DATE", this.dte01_SDATE.GetDateText().ToString());
                    set.Add("END_DATE", this.dte01_EDATE.GetDateText().ToString());
                    set.Add("GATE", this.cbo01_GATE.GetValue().ToString());
                    set.Add("CARNO", grd05.GetValue(grd05.Row, "CARNO").ToString());
                    set.Add("INVOICE", this.txt01_INVOICE.GetValue().ToString());
                    set.Add("CUSTCD", this.cdx01_VENDCD.GetValue().ToString());
                    set.Add("CUST_PLANT", this.cbl01_CustPLANT.GetValue().ToString());
                    set.Add("LANG_SET", UserInfo.Language);

                    this.BeforeInvokeServer(true);
                    DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "TRUCK_DET"), set, "OUT_CURSOR");
                    this.AfterInvokeServer();

                    this.grd06.SetValue(source1.Tables[0]);
                }
            }
            catch(Exception eLog)
            {

            }
        }

        private void axButton4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                string filename = this.ofdExcel.FileName;
                //string extension = ((string[])filename.Split('.'))[filename.Split('.').Length - 1].ToUpper();
                //string endfilename = ((string[])filename.Split('\\'))[filename.Split('\\').Length - 1];

                if (!this.IsVaildFile(filename))
                {
                    //MessageBox.Show("파일에 접근할 수 없습니다. 파일이 열려있는지 확인하세요.");
                    MsgCodeBox.Show("CD00-0120");
                    return;
                }


                this.ReadExcelFile(filename);


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void ReadExcelFile(string FileName)
        {
            OleDbConnection oleDB = null;
            try
            {
                this.BeforeInvokeServer();

                StringBuilder connectionString = new StringBuilder();
                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");
                connectionString.AppendFormat(@"Data Source={0}", FileName);
                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();


                DataTable worksheets = oleDB.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                DataSet dsSheet = this.GetDataSourceSchema("Code", "CodeValue");

                foreach (DataRow row in worksheets.Rows)
                {
                    dsSheet.Tables[0].Rows.Add(Convert.ToString(row["TABLE_NAME"]), Convert.ToString(row["TABLE_NAME"]));
                }
                if (tabControl1.SelectedIndex ==3)
                {
                    axTextBox2.Value = FileName;
                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                oleDB.Close();

                this.AfterInvokeServer();
            }
        }
        private void DelZSD0420(string yyyymm)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            set.Add("YYYYMM ", yyyymm);
            _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02590.DEL_ZSD0420", set);
        }
        private void SetZSD0420(DataSet ds)
        {
            _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02590.SET_ZSD0420", ds);
            /*
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                try
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", ds.Tables[0].Rows[i]["CORCD"].ToString());
                    set.Add("BIZCD", ds.Tables[0].Rows[i]["BIZCD"].ToString());
                    set.Add("YYYYMM", ds.Tables[0].Rows[i]["YYYYMM"].ToString());
                    set.Add("INVOICE", ds.Tables[0].Rows[i]["INVOICE"].ToString());
                    set.Add("ASNNO", ds.Tables[0].Rows[i]["ASNNO"].ToString());
                    set.Add("GRST", ds.Tables[0].Rows[i]["GRST"].ToString());
                    set.Add("PARTNO", ds.Tables[0].Rows[i]["PARTNO"].ToString());
                    set.Add("PARTNM", ds.Tables[0].Rows[i]["PARTNM"].ToString());
                    set.Add("ASN_QTY", ds.Tables[0].Rows[i]["ASN_QTY"].ToString());
                    set.Add("GR_QTY", ds.Tables[0].Rows[i]["GR_QTY"].ToString());
                    set.Add("UOM", ds.Tables[0].Rows[i]["UOM"].ToString());
                    set.Add("GRDATE", ds.Tables[0].Rows[i]["GRDATE"].ToString());
                    set.Add("GRNO", ds.Tables[0].Rows[i]["GRNO"].ToString());
                    set.Add("AGNO", ds.Tables[0].Rows[i]["AGNO"].ToString());

                    _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02590.SET_ZSD0420", set);
                }
                catch(Exception eLog)
                {
                    break;
                }
            }
             */
            
        }
        private void ReadExcelSheet(string SheetName, string file)
        {
            if (string.IsNullOrEmpty(SheetName)) return;

            OleDbConnection oleDB = null;
            try
            {
                this.BeforeInvokeServer();

                StringBuilder connectionString = new StringBuilder();
                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");
                connectionString.AppendFormat(@"Data Source={0}", file);
                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();
                string commandString = "SELECT ";
                if (tabControl1.SelectedIndex == 3)
                {
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,'" + axDateEdit1.Value.ToString("yyyyMM").ToString()+"' as YYYYMM";
                    commandString += " ,[Invoice No] as INVOICE";
                    commandString += " ,[ASN No] as ASNNO";
                    commandString += " ,[GR Status] as GRST";
                    commandString += " ,[Material] as PARTNO";
                    commandString += " ,[Description] as PARTNM";
                    commandString += " ,[ASN Qty] as ASN_QTY";
                    commandString += " ,[GR Qty] as GR_QTY";
                    commandString += " ,[Unit] as UOM";
                    commandString += " ,[GR Date] as GRDATE";
                    commandString += " ,[GR Document] as GRNO";
                    commandString += " ,[Agreement] as AGNO";                
                }
                commandString += " FROM [" + SheetName + "]";
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                oleDB.Close();

                if (tabControl1.SelectedIndex == 3)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DelZSD0420(axDateEdit1.Value.ToString("yyyyMM"));

                        SetZSD0420(ds);
                        this.grd07.SetValue(ds);
                        for (int i = 1; i < this.grd01.Rows.Count; i++)
                        {
                            this.grd07[i, 0] = AxFlexGrid.FLAG_N;
                        }
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
                oleDB.Close();

                this.AfterInvokeServer();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 3)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }
    }
}
