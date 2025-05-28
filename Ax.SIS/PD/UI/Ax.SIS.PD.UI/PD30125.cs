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


namespace Ax.SIS.PD.UI
{
    public partial class PD30125 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD30125";
        public PD30125()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                SetCustCD();
                SetCustPLANT();
                SetTruck();
                //this.cbl01_CustCD.SetValue("303408");
                //this.cbl01_CustPLANT.SetValue("KVF1");

                DataSet ds01 = this.GetDataSourceSchema("Code", "CodeValue");
                ds01.Tables[0].Rows.Add("A3", "A3");
                ds01.Tables[0].Rows.Add("A4", "A4");
                ds01.Tables[0].Rows.Add("B2", "B2");
                ds01.Tables[0].Rows.Add("B3", "B3");
                ds01.Tables[0].Rows.Add("B4", "B4");
                this.cbo01_GATE.DataBind(ds01.Tables[0], true);

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 40, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 45, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 45, "TYPE", "TYPE", "TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "INVOICE DATE", "INV_DATE", "INV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CUSTOMER Code", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 250, "CUSTOMER NM", "CUSTNM", "CUSTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "INVOICE", "INVOICE", "INVOICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "GATE", "GATE", "GATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "TRUCK", "CARNO", "CARNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "T/SEQ", "CARSEQ", "CARSEQ");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY.", "QTY", "QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "AMOUNT", "AMT", "AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "TOT. CGST", "CGST", "CGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "TOT. SGST", "SGST", "SGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "TOT. IGST", "IGST", "IGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "TOTAL", "TOTAL", "TOTAL");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd01.Cols["QTY"].Format = "###,###,###,##0";

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd01.Cols["AMT"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CGST");
                this.grd01.Cols["CGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SGST");
                this.grd01.Cols["SGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IGST");
                this.grd01.Cols["IGST"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "TOTAL");
                this.grd01.Cols["TOTAL"].Format = "###,###,###,##0.##";

                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "INVOICE", "INVOICE", "INVOICE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 40, "I/SEQ", "SEQID", "SEQID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "P/NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "P/NAME", "PARTNM", "PARTNM");


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
            }
            catch(Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void SetCustCD()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = null;

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "APG_PD30120", "INQUERY_CUSTCD"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustCD.DataBind(source, this.GetLabel("CUSTCD") + ";" + this.GetLabel("CUSTNM"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = null;

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "APG_PD30120", "INQUERY_PLANT"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void SetTruck()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                DataTable source = null;

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_TRUCK"), set, "OUT_CURSOR").Tables[0];
                this.cbo01_TRUCK.DataBind(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_CustCD_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedValue = this.cbl01_CustCD.GetValue().ToString();
            switch (selectedValue)
            {
                case "303408":
                    this.cbl01_CustPLANT.SelectedValue = "KVF1";
                    break;
                case "304069":
                    this.cbl01_CustPLANT.SelectedValue = "MBIA";
                    break;
                case "304070":
                    this.cbl01_CustPLANT.SelectedValue = "GVIA";
                    break;
                default:
                    this.cbl01_CustPLANT.SelectedValue = "KVF1";
                    break;
            }
        }

        private void cbl01_CustPLANT_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedValue = this.cbl01_CustPLANT.GetValue().ToString();
            switch (selectedValue)
            {
                case "KVF1":
                case "KVF2":
                    this.cbl01_CustCD.SelectedValue = "303408";
                    break;
                case "MBIA":
                    this.cbl01_CustCD.SelectedValue = "304069";
                    break;
                case "GVIA":
                    this.cbl01_CustCD.SelectedValue = "304070";
                    break;
                default:
                    this.cbl01_CustCD.SelectedValue = "303408";
                    break;
            }
        }


        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.cbo01_CORCD.GetValue().ToString());
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
            set.Add("BEG_DATE", this.dte01_SDATE.GetDateText().ToString());
            set.Add("END_DATE", this.dte01_EDATE.GetDateText().ToString());
            set.Add("GATE", this.cbo01_GATE.GetValue().ToString());
            set.Add("CARNO", this.cbo01_TRUCK.GetValue().ToString());
            set.Add("INVOICE", this.txt01_INVOICE.GetValue().ToString());
            set.Add("CUSTCD", this.cbl01_CustCD.GetValue().ToString());
            set.Add("CUST_PLANT", this.cbl01_CustPLANT.GetValue().ToString());
            set.Add("LANG_SET", UserInfo.Language);

            this.BeforeInvokeServer(true);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_INVOICE"), set, "OUT_CURSOR");
            this.AfterInvokeServer();

            this.grd01.SetValue(source.Tables[0]);
            ShowDataCount(source);
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
    }
}
