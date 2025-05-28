using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
using System.Diagnostics;
using Ax.SIS.SD.UI.EINV;
using System.Globalization;

namespace Ax.SIS.SD.UI
{
    public partial class ZSDE6000 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSDE600";
        private List<EInvoice> LST_EINVOICE_DETAILS = new List<EInvoice>();

        public ZSDE6000()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                SetCustCD();
                SetInvoiceStatus();
                SetValidationFlag();

                dte01_SDATE.Value = DateTime.Now.AddDays(-7);
                this.grdDet.Initialize();
                InitGrid();
                InitDetailGrid();
                BtnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void InitGrid()
        {
            try
            {
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "TRUCK", "CARNO_EINV", "CARNO_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "T/SEQ", "CARSEQ_EINV", "CARSEQ_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "GATE", "GATE_EINV", "GATE_ENIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PLANT", "CUST_PLANT_EINV", "CUST_PLANT_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "INVOICE NO", "INVOICE_EINV", "INVOICE_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "INVOICE" + Environment.NewLine + "DATE", "INVOICE_DATE_EINV", "INVOICE_DATE_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "INVOICE" + Environment.NewLine + " TYPE", "INV_TYPE_EINV", "INV_TYPE_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "IS" + Environment.NewLine + "SERVICE", "SERV_TYPE_EINV", "SERV_TYPE_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "SUPPLY" + Environment.NewLine + "TYPE", "SUPPLY_TYPE_EINV", "SUPPLY_TYPE_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "TOTAL" + Environment.NewLine + "AMOUNT", "AMT_EINV", "AMT_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "GST" + Environment.NewLine + "RATE", "GST_PER_EINV", "GST_PER_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "IGST" + Environment.NewLine + "VALUE", "IGST_EINV", "IGST_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "CGST" + Environment.NewLine + "VALUE", "CGST_EINV", "CGST_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "SGST" + Environment.NewLine + "VALUE", "SGST_EINV", "SGST_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "INVOICE" + Environment.NewLine + "VALUE", "TAMT_EINV", "TAMT_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "IRN", "IRN_EINV", "IRN_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "IRN ACK NO", "IRN_ACK_EINV", "IRN_ACK_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "QR" + Environment.NewLine + "CODE", "QRCD_EINV", "QRCD_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "EWB", "EWB_EINV", "EWB_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "VALIDATION" + Environment.NewLine + "STATUS", "VF_FLAG", "VF_FLAG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "VALIDATION" + Environment.NewLine + "FAILURE REASON", "VF_REASON", "VF_REASON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "IRN CREATION" + Environment.NewLine + "STATUS", "INVOICE_STATUS_EINV", "INVOICE_STATUS_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "CUSTOMER NAME", "REC_VENDNM_EINV", "RVENDNM_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "CUSTOMER GSTIN", "REC_STCD3_EINV", "STCD3_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "CUSTOMER ADDRESS", "REC_FADDR_EINV", "FADDR_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "CUSTOMER" + Environment.NewLine + "STATE CODE", "REC_REGIO_EINV", "REGIO_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SUPPLY" + Environment.NewLine + "STATE CODE", "REC_PL_REGIO_EINV", "PL_REGIO_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "CUSTOMER" + Environment.NewLine + "STATE", "ORT02_EINV", "ORT02_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "CUSTOMER" + Environment.NewLine + "PINCODE", "ZIPCD_EINV", "ZIPCD_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "CUSTOMER" + Environment.NewLine + "PLACE", "STRAS_EINV", "STRAS_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SHIP TO" + Environment.NewLine + "GSTIN", "SH_STCD3_EINV", "SH_STCD3_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SHIP TO" + Environment.NewLine + "PINCODE", "SH_ZIPCD_EINV", "SH_ZIPCD_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "SHIP TO" + Environment.NewLine + "STATE CODE", "SH_REGIO_EINV", "SH_REGIO_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SUPPLIER" + Environment.NewLine + "NAME", "SUP_COMNM_EINV", "SUP_COMNM_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SUPPLIER" + Environment.NewLine + "GSTIN", "SUP_GSTNO_EINV", "SUP_GSTNO_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SUPPLIER" + Environment.NewLine + "ADDRESS", "SUP_COMADDR_EINV", "SUP_COMADDR_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SUPPLIER" + Environment.NewLine + "PLACE", "SUP_PLC_EINV", "SUP_PLC_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SUPPLIER" + Environment.NewLine + "STATE CODE", "SUP_AREACD_EINV", "SUP_AREACD_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SUPPLIER" + Environment.NewLine + "PINCODE", "SUP_ZIPCD_EINV", "SUP_ZIPCD_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "DESPATCH" + Environment.NewLine + "FROM", "DI_COMNM_EINV", "DI_COMNM_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "DESPATCH" + Environment.NewLine + "FROM ADDRESS", "DI_COMADDR_EINV", "DI_COMADDR_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "DESPATCH" + Environment.NewLine + "FROM PLACE", "DIP_COMADDR_EINV", "DI_COMADDR_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "DESPATCH" + Environment.NewLine + "FROM PINCODE", "DI_ZIPCD_EINV", "DI_ZIPCD_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "INVOICE" + Environment.NewLine + "REF NO", "INV_REF_EINV", "INV_REF_EINV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "INVOICE" + Environment.NewLine + "REF DATE", "INV_DATE_REF_EINV", "INV_DATE_REF_EINV");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "IRN" + Environment.NewLine + "STATUS A/C", "IRN_STATUS", "IRN_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "IRN CREATION" + Environment.NewLine + "FAILURE FROM IRP", "IRN_CREATION_FAILURE_MSG_IRP", "IRN_CREATION_FAILURE_MSG_IRP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "IRN CANCEL" + Environment.NewLine + "VALIDATION STATUS", "IRN_CANCEL_VALDTION_FLAG", "IRN_CANCEL_VALDTION_FLAG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "IRN CANCEL" + Environment.NewLine + "VALIDATION FAILURE MSG", "IRN_CANCEL_VF_REN", "IRN_CANCEL_VF_REN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "IRN CANCEL" + Environment.NewLine + "STATUS", "IRN_CANCEL_STATUS", "IRN_CANCEL_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "IRN CANCEL" + Environment.NewLine + "FAILURE MSG FROM IRP", "IRN_CANCEL_FAILURE_MSG_IRP", "IRN_CANCEL_FAILURE_MSG_IRP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "GET IRN DETAIL" + Environment.NewLine + "FAILURE MSG FROM IRP", "IRN_GET_FAILURE_MSG", "IRN_GET_FAILURE_MSG");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "EWB STATUS", "EWB_STATUS", "EWB_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "EWB CREATION " + Environment.NewLine + "VALIDATION STATUS", "EWB_CREATION_VALDTION_FLAG", "EWB_CREATION_VALDTION_FLAG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "EWB CREATON" + Environment.NewLine + "VALIDATION FAILURE RSN", "EWB_CREATION_VF_REN", "EWB_CREATION_VF_REN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "EWB CREATION STATUS", "EWB_CREATION_STATUS", "EWB_CREATION_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "EWB CREATION" + Environment.NewLine + "FAILURE MSG FROM IRP", "EWB_CREATION_FAILURE_MSG_IRP", "EWB_CREATION_FAILURE_MSG_IRP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "EWB CANCEL" + Environment.NewLine + "VALIDATION STATUS", "EWB_CANCEL_VALDTION_FLAG", "EWB_CANCEL_VALDTION_FLAG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "EWB CANCEL" + Environment.NewLine + "VALIDATION FAIL RSN", "EWB_CANCEL_VF_REN", "EWB_CANCEL_VF_REN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "EWB CANCEL" + Environment.NewLine + "STATUS", "EWB_CANCEL_STATUS", "EWB_CANCEL_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "GET EWB DETAIL" + Environment.NewLine + "FAILURE MSG FROM IRP", "EWB_GET_FAILURE_MSG", "EWB_GET_FAILURE_MSG");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "GST_PER_EINV");
                this.grd01.Cols["GST_PER_EINV"].Format = "###,###,###,##0.00";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IGST_EINV");
                this.grd01.Cols["IGST_EINV"].Format = "###,###,###,##0.00";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CGST_EINV");
                this.grd01.Cols["CGST_EINV"].Format = "###,###,###,##0.00";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SGST_EINV");
                this.grd01.Cols["SGST_EINV"].Format = "###,###,###,##0.00";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "TAMT_EINV");
                this.grd01.Cols["TAMT_EINV"].Format = "###,###,###,##0.00";
                this.grd01.Rows[0].Height = 35;
            }
            catch (Exception)
            {
            }
        }

        private void InitDetailGrid()
        {
            try
            {
                this.grdDet.AllowEditing = false;
                this.grdDet.Initialize();
                this.grdDet.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;

                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "INVOICE NO", "INVOICE", "INVOICE");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "PO NO", "SANO", "SANO");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 75, "HSN CODE", "HSN", "HSN");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 330, "ITEM DESCRIPTION", "HSN_DES", "HSN_DES");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "QUANTITY", "QTY", "QTY");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "UNIT", "UOM", "UOM");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 85, "ITEM PRICE", "UPRICE", "UPRICE");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "IGST VALUE", "IGST", "IGST");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "CGST VALUE", "CGST", "CGST");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "SGST VALUE", "SGST", "SGST");

                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "UPRICE");
                this.grdDet.Cols["UPRICE"].Format = "###,###,###,##0.00";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "IGST");
                this.grdDet.Cols["IGST"].Format = "###,###,###,##0.00";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "CGST");
                this.grdDet.Cols["CGST"].Format = "###,###,###,##0.00";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "SGST");
                this.grdDet.Cols["SGST"].Format = "###,###,###,##0.00";
            }
            catch (Exception)
            {
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
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSD02500", "INQUERY_CUSTCD"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustCD.DataBind(source, this.GetLabel("CUSTCD") + ";" + this.GetLabel("CUSTNM"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void SetInvoiceStatus()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                DataTable source = null;
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSDE600", "GET_INV_STATUS"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_INVOICE_STATUS.DataBind(source, this.GetLabel("INVOICE_STATUS_ID") + ";" + this.GetLabel("INVOICE_STATUS"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        private void SetValidationFlag()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                DataTable source = null;
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSDE600", "GET_VFFLAG"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_VALIDATION_STATUS.DataBind(source, this.GetLabel("VALIDATION_STATUS_ID") + ";" + this.GetLabel("VALIDATION_STATUS"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            SearchFunc();
        }

        public void SearchFunc()
        {
            try
            {
                this.grdDet.DataSource = new DataTable();
                HEParameterSet set = new HEParameterSet();
                set.Add("CUSTCD", this.cbl01_CustCD.GetValue().ToString());
                set.Add("BEG_DATE", this.dte01_SDATE.GetDateText().ToString());
                set.Add("END_DATE", this.dte01_EDATE.GetDateText().ToString());
                set.Add("INVOICE_STATUS", this.cbl01_INVOICE_STATUS.GetValue().ToString());
                set.Add("VALIDATION_FLAG", this.cbl01_VALIDATION_STATUS.GetValue().ToString());
                set.Add("LANG_SET", UserInfo.Language.ToString());
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_EINVOICE_DETAILS"), set, "OUT_CURSOR");
                this.grd01.SetValue(source.Tables[0]);

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                    this.grd01.Rows[i].Height = 25;

                LST_EINVOICE_DETAILS = (from DataRow dr in source.Tables[0].Rows
                                        select new EInvoice()
                                        {
                                            INVOICE_EINV = Convert.ToString(dr["INVOICE_EINV"]),
                                            INV_TYPE_EINV = Convert.ToString(dr["INV_TYPE_EINV"]),
                                            INVOICE_DATE_EINV = GetShortDate(Convert.ToString(dr["INVOICE_DATE_EINV"])),
                                            SERV_TYPE_EINV = Convert.ToString(dr["SERV_TYPE_EINV"]),
                                            SUPPLY_TYPE_EINV = Convert.ToString(dr["SUPPLY_TYPE_EINV"]),
                                            REC_VENDNM_EINV = Convert.ToString(dr["REC_VENDNM_EINV"]),
                                            REC_STCD3_EINV = Convert.ToString(dr["REC_STCD3_EINV"]),
                                            REC_FADDR_EINV = Convert.ToString(dr["REC_FADDR_EINV"]),
                                            REC_REGIO_EINV = Convert.ToString(dr["REC_REGIO_EINV"]),
                                            REC_PL_REGIO_EINV = Convert.ToString(dr["REC_PL_REGIO_EINV"]),
                                            ORT02_EINV = Convert.ToString(dr["ORT02_EINV"]),
                                            ZIPCD_EINV = Convert.ToString(dr["ZIPCD_EINV"]),
                                            STRAS_EINV = Convert.ToString(dr["STRAS_EINV"]),
                                            SH_STCD3_EINV = Convert.ToString(dr["SH_STCD3_EINV"]),
                                            SH_ZIPCD_EINV = Convert.ToString(dr["SH_ZIPCD_EINV"]),
                                            SH_REGIO_EINV = Convert.ToString(dr["SH_REGIO_EINV"]),
                                            SUP_COMNM_EINV = Convert.ToString(dr["SUP_COMNM_EINV"]),
                                            SUP_GSTNO_EINV = Convert.ToString(dr["SUP_GSTNO_EINV"]),
                                            SUP_COMADDR_EINV = Convert.ToString(dr["SUP_COMADDR_EINV"]),
                                            SUP_PLC_EINV = Convert.ToString(dr["SUP_PLC_EINV"]),
                                            SUP_AREACD_EINV = Convert.ToString(dr["SUP_AREACD_EINV"]),
                                            SUP_ZIPCD_EINV = Convert.ToString(dr["SUP_ZIPCD_EINV"]),
                                            DI_COMNM_EINV = Convert.ToString(dr["DI_COMNM_EINV"]),
                                            DI_COMADDR_EINV = Convert.ToString(dr["DI_COMADDR_EINV"]),
                                            DI_ZIPCD_EINV = Convert.ToString(dr["DI_ZIPCD_EINV"]),
                                            INV_REF_EINV = Convert.ToString(dr["INV_REF_EINV"]),
                                            INV_DATE_REF_EINV = GetShortDate(Convert.ToString(dr["INV_DATE_REF_EINV"])),
                                            GST_PER_EINV = Convert.ToString(dr["GST_PER_EINV"]),
                                            IGST_EINV = Convert.ToString(dr["IGST_EINV"]),
                                            CGST_EINV = Convert.ToString(dr["CGST_EINV"]),
                                            SGST_EINV = Convert.ToString(dr["SGST_EINV"]),
                                            TAMT_EINV = Convert.ToString(dr["TAMT_EINV"]),
                                            IRN_EINV = Convert.ToString(dr["IRN_EINV"]),
                                            IRN_ACK_EINV = Convert.ToString(dr["IRN_ACK_EINV"]),
                                            QRCD_EINV = Convert.ToString(dr["QRCD_EINV"]),
                                            EWB_EINV = Convert.ToString(dr["EWB_EINV"]),
                                            VF_FLAG = Convert.ToString(dr["VF_FLAG"]),
                                            VF_REASON = Convert.ToString(dr["VF_REASON"]),
                                            GATE_EINV = Convert.ToString(dr["GATE_EINV"]),
                                            CARNO_EINV = Convert.ToString(dr["CARNO_EINV"]),
                                            CUST_PLANT_EINV = Convert.ToString(dr["CUST_PLANT_EINV"]),
                                            CARSEQ_EINV = Convert.ToString(dr["CARSEQ_EINV"]),
                                            INVOICE_STATUS_EINV = Convert.ToString(dr["INVOICE_STATUS_EINV"]),
                                            IRN_STATUS = Convert.ToString(dr["IRN_STATUS"]),
                                            IRN_CREATION_FAILURE_MSG_IRP = Convert.ToString(dr["IRN_CREATION_FAILURE_MSG_IRP"]),
                                            IRN_CANCEL_VALDTION_FLAG = Convert.ToString(dr["IRN_CANCEL_VALDTION_FLAG"]),
                                            IRN_CANCEL_VF_REN = Convert.ToString(dr["IRN_CANCEL_VF_REN"]),
                                            IRN_CANCEL_STATUS = Convert.ToString(dr["IRN_CANCEL_STATUS"]),
                                            IRN_CANCEL_FAILURE_MSG_IRP = Convert.ToString(dr["IRN_CANCEL_FAILURE_MSG_IRP"]),
                                            IRN_GET_FAILURE_MSG = Convert.ToString(dr["IRN_GET_FAILURE_MSG"]),
                                            EWB_STATUS = Convert.ToString(dr["EWB_STATUS"]),
                                            EWB_CREATION_VALDTION_FLAG = Convert.ToString(dr["EWB_CREATION_VALDTION_FLAG"]),
                                            EWB_CREATION_VF_REN = Convert.ToString(dr["EWB_CREATION_VF_REN"]),
                                            EWB_CREATION_STATUS = Convert.ToString(dr["EWB_CREATION_STATUS"]),
                                            EWB_CREATION_FAILURE_MSG_IRP = Convert.ToString(dr["EWB_CREATION_FAILURE_MSG_IRP"]),
                                            EWB_CANCEL_VALDTION_FLAG = Convert.ToString(dr["EWB_CANCEL_VALDTION_FLAG"]),
                                            EWB_CANCEL_VF_REN = Convert.ToString(dr["EWB_CANCEL_VF_REN"]),
                                            EWB_CANCEL_STATUS = Convert.ToString(dr["EWB_CANCEL_STATUS"]),
                                            EWB_GET_FAILURE_MSG = Convert.ToString(dr["EWB_GET_FAILURE_MSG"])

                                        }).ToList();
                ShowDataCount(source);
            }
            catch (Exception)
            {
            }
        }

        public void UpdateSingleRowFromDB(int rowNo)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("INVOICENO", this.grd01.GetValue(rowNo, "INVOICE_EINV"));
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_SINGLE_INVOICE_DETAILS"), set, "OUT_CURSOR");
                DataTable dtDetails = new DataTable();
                dtDetails = source.Tables[0];

                if (dtDetails != null)
                {
                    if (dtDetails.Rows.Count > 0)
                    {
                        grd01.SetValue(rowNo, "CARNO_EINV", dtDetails.Rows[0]["CARNO_EINV"]);
                        grd01.SetValue(rowNo, "CARSEQ_EINV", dtDetails.Rows[0]["CARSEQ_EINV"]);
                        grd01.SetValue(rowNo, "GATE_EINV", dtDetails.Rows[0]["GATE_EINV"]);
                        grd01.SetValue(rowNo, "CUST_PLANT_EINV", dtDetails.Rows[0]["CUST_PLANT_EINV"]);
                        grd01.SetValue(rowNo, "INVOICE_EINV", dtDetails.Rows[0]["INVOICE_EINV"]);
                        grd01.SetValue(rowNo, "INVOICE_DATE_EINV", dtDetails.Rows[0]["INVOICE_DATE_EINV"]);
                        grd01.SetValue(rowNo, "INV_TYPE_EINV", dtDetails.Rows[0]["INV_TYPE_EINV"]);
                        grd01.SetValue(rowNo, "SERV_TYPE_EINV", dtDetails.Rows[0]["SERV_TYPE_EINV"]);
                        grd01.SetValue(rowNo, "SUPPLY_TYPE_EINV", dtDetails.Rows[0]["SUPPLY_TYPE_EINV"]);
                        grd01.SetValue(rowNo, "AMT_EINV", dtDetails.Rows[0]["AMT_EINV"]);
                        grd01.SetValue(rowNo, "GST_PER_EINV", dtDetails.Rows[0]["GST_PER_EINV"]);
                        grd01.SetValue(rowNo, "IGST_EINV", dtDetails.Rows[0]["IGST_EINV"]);
                        grd01.SetValue(rowNo, "CGST_EINV", dtDetails.Rows[0]["CGST_EINV"]);
                        grd01.SetValue(rowNo, "SGST_EINV", dtDetails.Rows[0]["SGST_EINV"]);
                        grd01.SetValue(rowNo, "TAMT_EINV", dtDetails.Rows[0]["TAMT_EINV"]);
                        grd01.SetValue(rowNo, "IRN_EINV", dtDetails.Rows[0]["IRN_EINV"]);
                        grd01.SetValue(rowNo, "IRN_ACK_EINV", dtDetails.Rows[0]["IRN_ACK_EINV"]);
                        grd01.SetValue(rowNo, "QRCD_EINV", dtDetails.Rows[0]["QRCD_EINV"]);
                        grd01.SetValue(rowNo, "EWB_EINV", dtDetails.Rows[0]["EWB_EINV"]);
                        grd01.SetValue(rowNo, "VF_FLAG", dtDetails.Rows[0]["VF_FLAG"]);
                        grd01.SetValue(rowNo, "VF_REASON", dtDetails.Rows[0]["VF_REASON"]);
                        grd01.SetValue(rowNo, "INVOICE_STATUS_EINV", dtDetails.Rows[0]["INVOICE_STATUS_EINV"]);
                        grd01.SetValue(rowNo, "REC_VENDNM_EINV", dtDetails.Rows[0]["REC_VENDNM_EINV"]);
                        grd01.SetValue(rowNo, "REC_STCD3_EINV", dtDetails.Rows[0]["REC_STCD3_EINV"]);
                        grd01.SetValue(rowNo, "REC_FADDR_EINV", dtDetails.Rows[0]["REC_FADDR_EINV"]);
                        grd01.SetValue(rowNo, "REC_REGIO_EINV", dtDetails.Rows[0]["REC_REGIO_EINV"]);
                        grd01.SetValue(rowNo, "REC_PL_REGIO_EINV", dtDetails.Rows[0]["REC_PL_REGIO_EINV"]);
                        grd01.SetValue(rowNo, "ORT02_EINV", dtDetails.Rows[0]["ORT02_EINV"]);
                        grd01.SetValue(rowNo, "ZIPCD_EINV", dtDetails.Rows[0]["ZIPCD_EINV"]);
                        grd01.SetValue(rowNo, "STRAS_EINV", dtDetails.Rows[0]["STRAS_EINV"]);
                        grd01.SetValue(rowNo, "SH_STCD3_EINV", dtDetails.Rows[0]["SH_STCD3_EINV"]);
                        grd01.SetValue(rowNo, "SH_ZIPCD_EINV", dtDetails.Rows[0]["SH_ZIPCD_EINV"]);
                        grd01.SetValue(rowNo, "SH_REGIO_EINV", dtDetails.Rows[0]["SH_REGIO_EINV"]);
                        grd01.SetValue(rowNo, "SUP_COMNM_EINV", dtDetails.Rows[0]["SUP_COMNM_EINV"]);
                        grd01.SetValue(rowNo, "SUP_GSTNO_EINV", dtDetails.Rows[0]["SUP_GSTNO_EINV"]);
                        grd01.SetValue(rowNo, "SUP_COMADDR_EINV", dtDetails.Rows[0]["SUP_COMADDR_EINV"]);
                        grd01.SetValue(rowNo, "SUP_PLC_EINV", dtDetails.Rows[0]["SUP_PLC_EINV"]);
                        grd01.SetValue(rowNo, "SUP_AREACD_EINV", dtDetails.Rows[0]["SUP_AREACD_EINV"]);
                        grd01.SetValue(rowNo, "SUP_ZIPCD_EINV", dtDetails.Rows[0]["SUP_ZIPCD_EINV"]);
                        grd01.SetValue(rowNo, "DI_COMNM_EINV", dtDetails.Rows[0]["DI_COMNM_EINV"]);
                        grd01.SetValue(rowNo, "DI_COMADDR_EINV", dtDetails.Rows[0]["DI_COMADDR_EINV"]);
                        grd01.SetValue(rowNo, "DIP_COMADDR_EINV", dtDetails.Rows[0]["DIP_COMADDR_EINV"]);
                        grd01.SetValue(rowNo, "DI_ZIPCD_EINV", dtDetails.Rows[0]["DI_ZIPCD_EINV"]);
                        grd01.SetValue(rowNo, "INV_REF_EINV", dtDetails.Rows[0]["INV_REF_EINV"]);
                        grd01.SetValue(rowNo, "INV_DATE_REF_EINV", dtDetails.Rows[0]["INV_DATE_REF_EINV"]);

                        HEParameterSet paramSetDet = new HEParameterSet();
                        paramSetDet.Add("INVOICE", this.grd01.GetValue(rowNo, "INVOICE_EINV"));
                        paramSetDet.Add("LANG_SET", this.UserInfo.Language);
                        DataSet sourceDet = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INV_DETAILS"), paramSetDet);
                        this.grdDet.SetValue(sourceDet);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

        }

        public void UpdateCurrentRow()
        {
            try
            {
                this.grdDet.DataSource = new DataTable();
                HEParameterSet set = new HEParameterSet();
                //paramSet.Add("INVNO", grd01.GetValue(grd01.Row, "INVOICE_EINV");
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_EINVOICE_DETAILS"), set, "OUT_CURSOR");
                this.grd01.SetValue(source.Tables[0]);
                LST_EINVOICE_DETAILS = (from DataRow dr in source.Tables[0].Rows
                                        select new EInvoice()
                                        {
                                            INVOICE_EINV = Convert.ToString(dr["INVOICE_EINV"]),
                                            INV_TYPE_EINV = Convert.ToString(dr["INV_TYPE_EINV"]),
                                            INVOICE_DATE_EINV = GetShortDate(Convert.ToString(dr["INVOICE_DATE_EINV"])),
                                            SERV_TYPE_EINV = Convert.ToString(dr["SERV_TYPE_EINV"]),
                                            SUPPLY_TYPE_EINV = Convert.ToString(dr["SUPPLY_TYPE_EINV"]),
                                            REC_VENDNM_EINV = Convert.ToString(dr["REC_VENDNM_EINV"]),
                                            REC_STCD3_EINV = Convert.ToString(dr["REC_STCD3_EINV"]),
                                            REC_FADDR_EINV = Convert.ToString(dr["REC_FADDR_EINV"]),
                                            REC_REGIO_EINV = Convert.ToString(dr["REC_REGIO_EINV"]),
                                            REC_PL_REGIO_EINV = Convert.ToString(dr["REC_PL_REGIO_EINV"]),
                                            ORT02_EINV = Convert.ToString(dr["ORT02_EINV"]),
                                            ZIPCD_EINV = Convert.ToString(dr["ZIPCD_EINV"]),
                                            STRAS_EINV = Convert.ToString(dr["STRAS_EINV"]),
                                            SH_STCD3_EINV = Convert.ToString(dr["SH_STCD3_EINV"]),
                                            SH_ZIPCD_EINV = Convert.ToString(dr["SH_ZIPCD_EINV"]),
                                            SH_REGIO_EINV = Convert.ToString(dr["SH_REGIO_EINV"]),
                                            SUP_COMNM_EINV = Convert.ToString(dr["SUP_COMNM_EINV"]),
                                            SUP_GSTNO_EINV = Convert.ToString(dr["SUP_GSTNO_EINV"]),
                                            SUP_COMADDR_EINV = Convert.ToString(dr["SUP_COMADDR_EINV"]),
                                            SUP_PLC_EINV = Convert.ToString(dr["SUP_PLC_EINV"]),
                                            SUP_AREACD_EINV = Convert.ToString(dr["SUP_AREACD_EINV"]),
                                            SUP_ZIPCD_EINV = Convert.ToString(dr["SUP_ZIPCD_EINV"]),
                                            DI_COMNM_EINV = Convert.ToString(dr["DI_COMNM_EINV"]),
                                            DI_COMADDR_EINV = Convert.ToString(dr["DI_COMADDR_EINV"]),
                                            DI_ZIPCD_EINV = Convert.ToString(dr["DI_ZIPCD_EINV"]),
                                            INV_REF_EINV = Convert.ToString(dr["INV_REF_EINV"]),
                                            INV_DATE_REF_EINV = GetShortDate(Convert.ToString(dr["INV_DATE_REF_EINV"])),
                                            GST_PER_EINV = Convert.ToString(dr["GST_PER_EINV"]),
                                            IGST_EINV = Convert.ToString(dr["IGST_EINV"]),
                                            CGST_EINV = Convert.ToString(dr["CGST_EINV"]),
                                            SGST_EINV = Convert.ToString(dr["SGST_EINV"]),
                                            TAMT_EINV = Convert.ToString(dr["TAMT_EINV"]),
                                            IRN_EINV = Convert.ToString(dr["IRN_EINV"]),
                                            IRN_ACK_EINV = Convert.ToString(dr["IRN_ACK_EINV"]),
                                            QRCD_EINV = Convert.ToString(dr["QRCD_EINV"]),
                                            EWB_EINV = Convert.ToString(dr["EWB_EINV"]),
                                            VF_FLAG = Convert.ToString(dr["VF_FLAG"]),
                                            VF_REASON = Convert.ToString(dr["VF_REASON"]),
                                            GATE_EINV = Convert.ToString(dr["GATE_EINV"]),
                                            CARNO_EINV = Convert.ToString(dr["CARNO_EINV"]),
                                            CUST_PLANT_EINV = Convert.ToString(dr["CUST_PLANT_EINV"]),
                                            CARSEQ_EINV = Convert.ToString(dr["CARSEQ_EINV"]),
                                            INVOICE_STATUS_EINV = Convert.ToString(dr["INVOICE_STATUS_EINV"])

                                        }).ToList();
                ShowDataCount(source);
            }
            catch (Exception)
            {
            }
        }


        private void grd01_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < 1) return;
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("INVOICE", this.grd01.GetValue(row, "INVOICE_EINV"));
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INV_DETAILS"), paramSet);
                this.grdDet.SetValue(source);

                for (int i = 1; i < this.grdDet.Rows.Count; i++)
                    this.grdDet.Rows[i].Height = 25;

                ShowDataCount(source);
                string IRN = this.grd01.GetValue(row, "INVOICE_STATUS_EINV").ToString();
                if (IRN == "Pending" || IRN == "Rejected" || string.IsNullOrEmpty(IRN) || IRN == "Yet to Process")
                {
                    ZSDE600_EDIT zsde600_Edit = new ZSDE600_EDIT(this.grd01.GetValue(row, "INVOICE_EINV").ToString(), this.grd01.Row, this);
                    PopupHelper helper = null;
                    helper = new PopupHelper(zsde600_Edit, "Invoice");
                    helper.ShowDialog();
                }
                else
                {
                    if (IRN == "Cancelled")
                    {
                        MsgBox.Show(" This Invoice is cancelled in IRP, cannot be edited or reused.", "Notice");
                    }
                    else if (IRN == "Processed")
                    {
                        MsgBox.Show(" Non Editable as the IRN is already generated for this Invoice.", "Notice");
                    }
                    return;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private string GetShortDate(string DateInput)
        {
            string DateOutputInStringFormat = "";
            DateTime DateOutput = new DateTime();

            try
            {
                if (DateTime.TryParse(DateInput, out DateOutput))
                {
                    DateOutputInStringFormat = DateOutput.ToString("dd-MM-yyyy");
                }
                else
                {
                    DateOutputInStringFormat = "";
                }
            }
            catch (Exception)
            {
            }
            return DateOutputInStringFormat;
        }

        private void txt01_Search_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (LST_EINVOICE_DETAILS != null)
                {
                    if (LST_EINVOICE_DETAILS.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(txt01_Search.Text))
                        {
                            grd01.DataSource = new List<EInvoice>();
                            grd01.DataSource = LST_EINVOICE_DETAILS.Where(
                                Inv => Inv.INVOICE_EINV.Contains(txt01_Search.Text) ||
                                Inv.INV_TYPE_EINV.Contains(txt01_Search.Text) ||
                                Inv.INVOICE_DATE_EINV.Contains(txt01_Search.Text) ||
                                Inv.SERV_TYPE_EINV.Contains(txt01_Search.Text) ||
                                Inv.SUPPLY_TYPE_EINV.Contains(txt01_Search.Text) ||
                                Inv.REC_VENDNM_EINV.Contains(txt01_Search.Text) ||
                                Inv.REC_STCD3_EINV.Contains(txt01_Search.Text) ||
                                Inv.REC_FADDR_EINV.Contains(txt01_Search.Text) ||
                                Inv.REC_REGIO_EINV.Contains(txt01_Search.Text) ||
                                Inv.REC_PL_REGIO_EINV.Contains(txt01_Search.Text) ||
                                Inv.ORT02_EINV.Contains(txt01_Search.Text) ||
                                Inv.ZIPCD_EINV.Contains(txt01_Search.Text) ||
                                Inv.STRAS_EINV.Contains(txt01_Search.Text) ||
                                Inv.SH_STCD3_EINV.Contains(txt01_Search.Text) ||
                                Inv.SH_ZIPCD_EINV.Contains(txt01_Search.Text) ||
                                Inv.SH_REGIO_EINV.Contains(txt01_Search.Text) ||
                                Inv.SUP_COMNM_EINV.Contains(txt01_Search.Text) ||
                                Inv.SUP_GSTNO_EINV.Contains(txt01_Search.Text) ||
                                Inv.SUP_COMADDR_EINV.Contains(txt01_Search.Text) ||
                                Inv.SUP_PLC_EINV.Contains(txt01_Search.Text) ||
                                Inv.SUP_AREACD_EINV.Contains(txt01_Search.Text) ||
                                Inv.SUP_ZIPCD_EINV.Contains(txt01_Search.Text) ||
                                Inv.DI_COMNM_EINV.Contains(txt01_Search.Text) ||
                                Inv.DI_COMADDR_EINV.Contains(txt01_Search.Text) ||
                                Inv.DI_ZIPCD_EINV.Contains(txt01_Search.Text) ||
                                Inv.INV_REF_EINV.Contains(txt01_Search.Text) ||
                                Inv.INV_DATE_REF_EINV.Contains(txt01_Search.Text) ||
                                Inv.IGST_EINV.Contains(txt01_Search.Text) ||
                                Inv.CGST_EINV.Contains(txt01_Search.Text) ||
                                Inv.SGST_EINV.Contains(txt01_Search.Text) ||
                                Inv.TAMT_EINV.Contains(txt01_Search.Text) ||
                                Inv.IRN_EINV.Contains(txt01_Search.Text) ||
                                Inv.IRN_ACK_EINV.Contains(txt01_Search.Text) ||
                                Inv.QRCD_EINV.Contains(txt01_Search.Text) ||
                                Inv.EWB_EINV.Contains(txt01_Search.Text) ||
                                Inv.VF_FLAG.Contains(txt01_Search.Text) ||
                                Inv.VF_REASON.Contains(txt01_Search.Text) ||
                                Inv.GATE_EINV.Contains(txt01_Search.Text) ||
                                Inv.CARNO_EINV.Contains(txt01_Search.Text) ||
                                Inv.CARSEQ_EINV.Contains(txt01_Search.Text) ||
                                Inv.CUST_PLANT_EINV.Contains(txt01_Search.Text) ||
                                Inv.INVOICE_STATUS_EINV.Contains(txt01_Search.Text) ||
                                Inv.IRN_STATUS.Contains(txt01_Search.Text) ||
                                Inv.IRN_CREATION_FAILURE_MSG_IRP.Contains(txt01_Search.Text) ||
                                Inv.IRN_CANCEL_VALDTION_FLAG.Contains(txt01_Search.Text) ||
                                Inv.IRN_CANCEL_VF_REN.Contains(txt01_Search.Text) ||
                                Inv.IRN_CANCEL_STATUS.Contains(txt01_Search.Text) ||
                                Inv.IRN_CANCEL_FAILURE_MSG_IRP.Contains(txt01_Search.Text) ||
                                Inv.IRN_GET_FAILURE_MSG.Contains(txt01_Search.Text) ||
                                Inv.EWB_STATUS.Contains(txt01_Search.Text) ||
                                Inv.EWB_CREATION_VALDTION_FLAG.Contains(txt01_Search.Text) ||
                                Inv.EWB_CREATION_VF_REN.Contains(txt01_Search.Text) ||
                                Inv.EWB_CREATION_STATUS.Contains(txt01_Search.Text) ||
                                Inv.EWB_CREATION_FAILURE_MSG_IRP.Contains(txt01_Search.Text) ||
                                Inv.EWB_CANCEL_VALDTION_FLAG.Contains(txt01_Search.Text) ||
                                Inv.EWB_CANCEL_VF_REN.Contains(txt01_Search.Text) ||
                                Inv.EWB_CANCEL_STATUS.Contains(txt01_Search.Text) ||
                                Inv.EWB_GET_FAILURE_MSG.Contains(txt01_Search.Text)
                                ).ToList();
                        }
                        else
                        {
                            grd01.DataSource = LST_EINVOICE_DETAILS;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnCancelEWayBill_Click(object sender, EventArgs e)
        {
            if (MsgBox.Show("Are you sure you want to cancel EWay Bill ? This action cannot be undone", "Warning!", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.No)
            {
                return;
            }

            int currentInvoiceRow = this.grd01.SelectedRowIndex;

            if (currentInvoiceRow < 0)
            {
                MsgBox.Show("Select the Invoice to cancel the corresponding EWay bill, This action cannot be undone", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            string EWayBill = grd01.GetValue(currentInvoiceRow, "EWB_EINV").ToString();

            if (string.IsNullOrEmpty(EWayBill))
            {
                MsgBox.Show("EWay bill is not generated, Please refer to detailed information in SIS interface table", "Information", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            //string EWB_NO = Convert.ToString(grd01.GetValue(currentInvoiceRow, "EWB_EINV"));

            //if (EWB_NO != "")
            //{
            //    MsgBox.Show("EWay bill is already created", "Information", MessageBoxButtons.OK, ImageKinds.Information);
            //    return;
            //}

            MessageEntity EWBResult = CancelEWayBill(EWayBill);

            if (EWBResult != null)
            {
                BtnQuery_Click(null, null);
                txt01_Search_KeyUp(null, null);
                MsgBox.Show(EWBResult.Message, "Information", MessageBoxButtons.OK, ImageKinds.Information);
            }
            else
            {
                MsgBox.Show("Failed to cancel EWay Bill,  Please refer to detailed information in SIS interface table", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
            }
        }

        private MessageEntity CancelEWayBill(string EWayBillNo)
        {
            MessageEntity messageToBeREturn = null;
            try
            {

                EInvoiceMapper InvMapper = new EInvoiceMapper();

                CancelEWayBillRequestEntity cancelEWayBill = new CancelEWayBillRequestEntity();

                cancelEWayBill.ewbNo = Convert.ToInt64(EWayBillNo);
                cancelEWayBill.cancelRmrk = "Data Entry mistake";
                cancelEWayBill.cancelRsnCode = 1;
                messageToBeREturn = InvMapper.CancelEWayBillUsingDirectAPIAccess(cancelEWayBill);

            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

            return messageToBeREturn;
        }

        private void btnCancelIRN_Click(object sender, EventArgs e)
        {
            if (MsgBox.Show("Are you sure you want to cancel IRN ? This action cannot be undone. IRN cancelled invoices cannot be reused.", "Warning!", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.No)
            {
                return;
            }

            int currentInvoiceRow = this.grd01.SelectedRowIndex;

            if (currentInvoiceRow < 0)
            {
                MsgBox.Show("Select the Invoice to cancel  the corresponding IRN, This action cannot be undone. IRN cancelled invoices cannot be reused.", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            string IRN = grd01.GetValue(currentInvoiceRow, "IRN_EINV").ToString();

            if (string.IsNullOrEmpty(IRN))
            {
                MsgBox.Show("IRN is not yet generated for this invoice", "Information", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            //string EWB_NO = Convert.ToString(grd01.GetValue(currentInvoiceRow, "EWB_EINV"));

            //if (EWB_NO != "")
            //{
            //    MsgBox.Show("EWay bill is already created", "Information", MessageBoxButtons.OK, ImageKinds.Information);
            //    return;
            //}

            MessageEntity IRNResult = CancelIRN(IRN);

            if (IRNResult != null)
            {
                BtnQuery_Click(null, null);
                txt01_Search_KeyUp(null, null);
                MsgBox.Show(IRNResult.Message, "Information", MessageBoxButtons.OK, ImageKinds.Information);
            }
            else
            {
                MsgBox.Show("Failed to cancel IRN, Please refer to detailed information in SIS interface table", "Warning", MessageBoxButtons.OK, ImageKinds.Information);
            }

        }

        private MessageEntity CancelIRN(string IRN)
        {
            MessageEntity messageToBeREturn = null;
            try
            {

                EInvoiceMapper InvMapper = new EInvoiceMapper();
                CancelIRNDirectAPIAccess cancelIRN = new CancelIRNDirectAPIAccess();
                cancelIRN.Irn = IRN;
                cancelIRN.CnlRsn = "2";
                cancelIRN.CnlRem = "Data entry mistake";
                messageToBeREturn = InvMapper.CancelIRNUsingDirectAPIAccess(cancelIRN);

            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

            return messageToBeREturn;
        }

        private void btnGetEWayBillDetails_Click(object sender, EventArgs e)
        {
            int currentInvoiceRow = this.grd01.SelectedRowIndex;

            if (currentInvoiceRow < 0)
            {
                MsgBox.Show("Select an Invoice to get EWay Bill details", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            string IRN = grd01.GetValue(currentInvoiceRow, "IRN_EINV").ToString();


            var ewayBillDetails = GetEWayBillDetails();

            if (ewayBillDetails != null)
            {
                if (ewayBillDetails.ResultCode == "200")
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("IRN", IRN);
                    set.Add("EWB", ewayBillDetails.EwbNo);
                    set.Add("EWBILL_DATE", ewayBillDetails.EwbDt);
                    set.Add("EWBILL_EXPIRED_DATE", ewayBillDetails.EwbValidTill);
                    set.Add("EWB_STATUS", ewayBillDetails.Status);

                    this.BeforeInvokeServer(true);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_ZSDE605", "EWAYBILL_UPDATE"), set);
                    this.AfterInvokeServer();
                    BtnQuery_Click(null, null);
                    txt01_Search_KeyUp(null, null);
                    MsgBox.Show("EWay Bill details fetched successfully", "Information", MessageBoxButtons.OK, ImageKinds.Information);
                }
                else
                {
                    MsgBox.Show("Failed to fetch EWay bill details, Please refer to detailed information in SIS interface table", "Information", MessageBoxButtons.OK, ImageKinds.Information);
                }
            }
            else
            {
                MsgBox.Show("Failed to fetch EWay bill details, Please refer to detailed information in SIS interface table", "Information", MessageBoxButtons.OK, ImageKinds.Information);
            }
        }

        private void btnGetIRNDetails_Click(object sender, EventArgs e)
        {
            int currentInvoiceRow = this.grd01.SelectedRowIndex;

            if (currentInvoiceRow < 0)
            {
                MsgBox.Show("Select an Invoice to cancel corresponding IRN", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            string Invoice = grd01.GetValue(currentInvoiceRow, "INVOICE_EINV").ToString();

            var irnDetails = GetIRNDetails();

            if (irnDetails != null)
            {
                if (irnDetails.ResultCode == "200")
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("INVNO", Invoice);
                    set.Add("IRNAC", irnDetails.AckNo);
                    set.Add("IRN", irnDetails.Irn);
                    set.Add("QRCD", irnDetails.SignedQRCode);
                    set.Add("EWB", irnDetails.EwbNo);
                    set.Add("ACK_DATE", irnDetails.AckDt);
                    set.Add("EWB_DATE", irnDetails.EwbDt);
                    set.Add("EWB_VALID_TILL", irnDetails.EwbValidTill);
                    set.Add("IRN_STATUS", irnDetails.Status);
                    this.BeforeInvokeServer(true);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_ZSDE600", "IRN_UPDATE_DIRECT_API"), set);
                    this.AfterInvokeServer();
                    BtnQuery_Click(null, null);
                    txt01_Search_KeyUp(null, null);
                    MsgBox.Show("IRN details fetched successfully", "Information", MessageBoxButtons.OK, ImageKinds.Information);
                }
                else
                {
                    MsgBox.Show("Failed to fetch IRN details, Please refer to detailed information in SIS interface table", "Information", MessageBoxButtons.OK, ImageKinds.Information);
                }
            }
            else
            {
                MsgBox.Show("Failed to fetch IRN details, Please refer to detailed information in SIS interface table", "Information", MessageBoxButtons.OK, ImageKinds.Information);
            }

        }

        private IRNDetailsEntity GetIRNDetails()
        {
            IRNDetailsEntity messageToBeREturn = null;
            try
            {
                int currentInvoiceRow = this.grd01.SelectedRowIndex;

                string InvoiceNo = grd01.GetValue(currentInvoiceRow, "INVOICE_EINV").ToString();
                string InvoiceDate = grd01.GetValue(currentInvoiceRow, "INVOICE_DATE_EINV").ToString();
                string InvoiceType = grd01.GetValue(currentInvoiceRow, "INV_TYPE_EINV").ToString();

                string dateToProcess = Convert.ToDateTime(InvoiceDate).ToShortDateString();
                string dayOfDate = DateTime.ParseExact(dateToProcess, "dd-MM-yyyy", CultureInfo.InvariantCulture).Day.ToString();
                string MonthOfDate = DateTime.ParseExact(dateToProcess, "dd-MM-yyyy", CultureInfo.InvariantCulture).Month.ToString();
                string YearOfDate = DateTime.ParseExact(dateToProcess, "dd-MM-yyyy", CultureInfo.InvariantCulture).Year.ToString();

                if (dayOfDate.Length == 1)
                {
                    dayOfDate = "0" + dayOfDate;
                }

                if (MonthOfDate.Length == 1)
                {
                    MonthOfDate = "0" + MonthOfDate;
                }
                string invoiceDateToSend = dayOfDate + "/" + MonthOfDate + "/" + YearOfDate;

                if (string.IsNullOrEmpty(InvoiceDate))
                {
                    MsgBox.Show("Invoice date should not be empty", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                    return messageToBeREturn;
                }

                if (string.IsNullOrEmpty(InvoiceType))
                {
                    MsgBox.Show("Invoice type should not be empty", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                    return messageToBeREturn;
                }

                EInvoiceMapper InvMapper = new EInvoiceMapper();
                GetIRNDetailsRequestEntity GetIRNDetailsRequest = new GetIRNDetailsRequestEntity();
                GetIRNDetailsRequest.doctype = InvoiceType;
                GetIRNDetailsRequest.docnum = InvoiceNo;
                GetIRNDetailsRequest.docdate = invoiceDateToSend;
                messageToBeREturn = InvMapper.GetIRNDetails(GetIRNDetailsRequest);

            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

            return messageToBeREturn;
        }

        private EWayBillEntity GetEWayBillDetails()
        {
            EWayBillEntity messageToBeREturn = null;
            try
            {
                int currentInvoiceRow = this.grd01.SelectedRowIndex;

                string IRN = grd01.GetValue(currentInvoiceRow, "IRN_EINV").ToString();


                EInvoiceMapper InvMapper = new EInvoiceMapper();
                GetEWayBillDetailsRequestEntity GetEWayBillDetailsRequest = new GetEWayBillDetailsRequestEntity();
                GetEWayBillDetailsRequest.Irn = IRN;
                messageToBeREturn = InvMapper.GetEWayBillDetails(GetEWayBillDetailsRequest);

            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

            return messageToBeREturn;
        }
    }

    public class EInvoice
    {
        public string INVOICE_EINV { get; set; }

        public string INVOICE_DATE_EINV { get; set; }

        public string INV_TYPE_EINV { get; set; }

        public string HSN_EINV { get; set; }

        public string HSN_DES_EINV { get; set; }

        public string SERV_TYPE_EINV { get; set; }

        public string SUPPLY_TYPE_EINV { get; set; }

        public string REC_VENDNM_EINV { get; set; }

        public string REC_STCD3_EINV { get; set; }

        public string REC_FADDR_EINV { get; set; }

        public string REC_REGIO_EINV { get; set; }

        public string REC_PL_REGIO_EINV { get; set; }

        public string ORT02_EINV { get; set; }

        public string ZIPCD_EINV { get; set; }

        public string STRAS_EINV { get; set; }

        public string SH_STCD3_EINV { get; set; }

        public string SH_ZIPCD_EINV { get; set; }

        public string SH_REGIO_EINV { get; set; }

        public string SUP_COMNM_EINV { get; set; }

        public string SUP_GSTNO_EINV { get; set; }

        public string SUP_COMADDR_EINV { get; set; }

        public string SUP_PLC_EINV { get; set; }

        public string SUP_AREACD_EINV { get; set; }

        public string SUP_ZIPCD_EINV { get; set; }

        public string DI_COMNM_EINV { get; set; }

        public string DI_COMADDR_EINV { get; set; }

        public string DI_ZIPCD_EINV { get; set; }

        public string INV_REF_EINV { get; set; }

        public string INV_DATE_REF_EINV { get; set; }

        public string UPRICE_EINV { get; set; }

        public string AS_UPRICE_EINV { get; set; }

        public string GST_PER_EINV { get; set; }

        public string IGST_EINV { get; set; }

        public string CGST_EINV { get; set; }

        public string SGST_EINV { get; set; }

        public string TAMT_EINV { get; set; }

        public string SANO_EINV { get; set; }

        public string IRN_EINV { get; set; }

        public string IRN_ACK_EINV { get; set; }

        public string QRCD_EINV { get; set; }

        public string EWB_EINV { get; set; }

        public string VF_FLAG { get; set; }

        public string VF_REASON { get; set; }

        public string GATE_EINV { get; set; }

        public string CARNO_EINV { get; set; }

        public string CUST_PLANT_EINV { get; set; }
        public string CARSEQ_EINV { get; set; }

        public string INVOICE_STATUS_EINV { get; set; }

        public string IRN_STATUS { get; set; }
        public string IRN_CREATION_FAILURE_MSG_IRP { get; set; }
        public string IRN_CANCEL_VALDTION_FLAG { get; set; }
        public string IRN_CANCEL_VF_REN { get; set; }
        public string IRN_CANCEL_STATUS { get; set; }
        public string IRN_CANCEL_FAILURE_MSG_IRP { get; set; }
        public string IRN_GET_FAILURE_MSG { get; set; }
        public string EWB_STATUS { get; set; }
        public string EWB_CREATION_VALDTION_FLAG { get; set; }
        public string EWB_CREATION_VF_REN { get; set; }
        public string EWB_CREATION_STATUS { get; set; }
        public string EWB_CREATION_FAILURE_MSG_IRP { get; set; }
        public string EWB_CANCEL_VALDTION_FLAG { get; set; }
        public string EWB_CANCEL_VF_REN { get; set; }
        public string EWB_CANCEL_STATUS { get; set; }
        public string EWB_GET_FAILURE_MSG { get; set; }


    }
}
