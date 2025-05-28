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
using Ax.SIS.SD.UI.EINV;

namespace Ax.SIS.SD.UI
{
    public partial class ZSDE600_EDIT : AxCommonPopupControl
    {
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSDE605";
        private bool m_bClose = false;
        private string INVOICE_NO;
        private string CORPORATION_CODE;
        private string BUSINESS_CODE;
        private string CUSTOMER_PLANT;
        private ZSDE6000 OBJzsde600;
        private DataTable DataTableVehicle = new DataTable();
        private int CURRENT_ROW = 0;

        public ZSDE600_EDIT(string InvoiceNo, int currentRow, ZSDE6000 objInterface)
        {
            INVOICE_NO = InvoiceNo;
            OBJzsde600 = objInterface;
            CURRENT_ROW = currentRow;
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        private void InitDetailGrid()
        {
            try
            {
                this.grdDet.AllowEditing = true;
                this.grdDet.Initialize();
                this.grdDet.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "ORDER NO", "SANO", "SANO");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 305, "PARTS DESCRIPTION", "PARTNM", "PARTNM");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 75, "HSN CODE", "HSN", "HSN");
                this.grdDet.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "QUANTITY", "QTY", "QTY");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "UNIT", "UOM", "UOM");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 85, "BASIC COST", "UPRICE", "UPRICE");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "CGST VALUE", "CGST", "CGST");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "SGST VALUE", "SGST", "SGST");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "AMOUNT", "AMT_PLS_GST", "AMT_PLS_GST");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "TCS AMOUNT", "TCS", "TCS");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 105, "TOTAL AMOUNT", "TAMT", "TAMT");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 0, "PARTNO", "PARTNO", "PARTNO");
                this.grdDet.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 0, "PK", "PK_ID", "PK_ID");
                this.grdDet.AllowAddNew = false;
                //this.grd01.

                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grdDet.Cols["QTY"].Format = "###,###,###,##0";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "UPRICE");
                this.grdDet.Cols["UPRICE"].Format = "###,###,###,##0.00";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "CGST");
                this.grdDet.Cols["CGST"].Format = "###,###,###,##0.00";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "SGST");
                this.grdDet.Cols["SGST"].Format = "###,###,###,##0.00";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_PLS_GST");
                this.grdDet.Cols["AMT_PLS_GST"].Format = "###,###,###,##0.00";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "TCS");
                this.grdDet.Cols["TCS"].Format = "###,###,###,##0.00";
                this.grdDet.SetColumnType(AxFlexGrid.FCellType.Decimal, "TAMT");
                this.grdDet.Cols["TAMT"].Format = "###,###,###,##0.00";
            }
            catch (Exception)
            {
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                SetCustCD();
                InitDetailGrid();

                DisplayDetails();

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void DisplayDetails()
        {
            try
            {
                // Displaying common details
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("INVNO", INVOICE_NO);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_INV_EDIT"), paramSet, "OUT_CURSOR");
                this.grdDet.SetValue(source);

                if (source.Tables[0] != null)
                {
                    if (source.Tables[0].Rows.Count > 0)
                    {
                        cbl01_CustCD.SetValue(Convert.ToString(source.Tables[0].Rows[0]["CUSTCD_EINV"]));
                        BUSINESS_CODE = Convert.ToString(source.Tables[0].Rows[0]["BIZCD"]);
                        CUSTOMER_PLANT = Convert.ToString(source.Tables[0].Rows[0]["CUST_PLANT_EINV"]);
                        lbl01_CorporationName.Text = Convert.ToString(source.Tables[0].Rows[0]["SUP_COMNM_EINV"]);
                        CORPORATION_CODE = Convert.ToString(source.Tables[0].Rows[0]["CORCD"]);
                        SetTruckNo();
                        lbl01_Corporation_Address.Text = Convert.ToString(source.Tables[0].Rows[0]["SUP_COMADDR_EINV"]);
                        lbl01_Corporation_GSTINVal.Value = Convert.ToString(source.Tables[0].Rows[0]["SUP_GSTNO_EINV"]);
                        txt01_Customer_Address.Text = Convert.ToString(source.Tables[0].Rows[0]["REC_FADDR_EINV"]);
                        txt01_Customer_GSTIN.Text = Convert.ToString(source.Tables[0].Rows[0]["REC_STCD3_EINV"]);
                        txt01_INVOICE_NO.Text = Convert.ToString(source.Tables[0].Rows[0]["INVOICE_EINV"]);
                        dtp01_STD_DATE.SetValue(source.Tables[0].Rows[0]["INVOICE_DATE_EINV"]);
                        string find = "CAR_PLATE_NO = '" + Convert.ToString(source.Tables[0].Rows[0]["CARNO_EINV"]) + "'";
                        DataRow[] foundRows = DataTableVehicle.Select(find);
                        try
                        {
                            cbl01_VehicleNo.SelectedValue = foundRows[0]["TRKNO"].ToString();
                        }
                        catch (Exception)
                        {

                        }

                        txt01_CGST.Text = Convert.ToString(source.Tables[0].Rows[0]["CGST_EINV"]);
                        txt01_SGST.Text = Convert.ToString(source.Tables[0].Rows[0]["SGST_EINV"]);
                        txt01_Assessable_Value.Text = Convert.ToString(source.Tables[0].Rows[0]["AMT_EINV"]);
                        txt01_TCS.Text = Convert.ToString(source.Tables[0].Rows[0]["GRP_TCS_EINV"]);
                        txt01_Total.Text = Convert.ToString(source.Tables[0].Rows[0]["TAMT_EINV"]);
                    }
                }

                // Displaying product information
                HEParameterSet paramSetDet = new HEParameterSet();
                paramSetDet.Add("INVOICE", INVOICE_NO);
                paramSetDet.Add("LANG_SET", this.UserInfo.Language);
                DataSet sourceForDetGrid = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INV_DETAILS_EDIT"), paramSetDet, "OUT_CURSOR");
                this.grdDet.SetValue(sourceForDetGrid);

                for (int i = 1; i < this.grdDet.Rows.Count; i++)
                    this.grdDet.Rows[i].Height = 25;
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
                set.Add("VENDCD", "0");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = null;
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INV_CUSTCD"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustCD.DataBind(source, this.GetLabel("VENDCD") + ";" + this.GetLabel("VENDNM"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void SetTruckNo()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORPORATION_CODE);
                set.Add("BIZCD", BUSINESS_CODE);
                DataTable source = null;
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INV_TRUCK_GET"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_VehicleNo.DataBind(source, this.GetLabel("TRKNO") + ";" + this.GetLabel("CAR_PLATE_NO"), "C;L");
                DataTableVehicle = source;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void ReCalcGrid(int row)
        {
            switch (cbl01_CustCD.GetValue().ToString())
            {
                case "303408":
                    CUSTOMER_PLANT = "KVF1";
                    break;
                case "304069":
                    CUSTOMER_PLANT = "MBIA";
                    break;
                case "304070":
                    CUSTOMER_PLANT = "GVIA";
                    break;
                default:
                    CUSTOMER_PLANT = "KVF1";
                    break;
            }
            double up = Convert.ToDouble(grdDet.GetValue(row, "UPRICE").ToString());
            double qty = Convert.ToDouble(grdDet.GetValue(row, "QTY").ToString());
            double amt = up * qty;
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", CORPORATION_CODE);
            paramSet.Add("BIZCD", BUSINESS_CODE);
            paramSet.Add("CUSTCD", cbl01_CustCD.GetValue());
            paramSet.Add("PARTNO", this.grdDet.GetValue(row, "PARTNO"));
            paramSet.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            paramSet.Add("VAL", amt);

            DataTable dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.CALC_TAX", paramSet, "OUT_CURSOR").Tables[0];
            grdDet.SetValue(row, "CGST", dt.Rows[0]["CGST"].ToString());
            grdDet.SetValue(row, "SGST", dt.Rows[0]["SGST"].ToString());
            grdDet.SetValue(row, "TCS", dt.Rows[0]["TCS"].ToString());
            grdDet.SetValue(row, "AMT_PLS_GST", amt + Convert.ToDouble(grdDet.GetValue(row, "CGST").ToString()) + Convert.ToDouble(grdDet.GetValue(row, "SGST").ToString()));
            grdDet.SetValue(row, "TAMT", amt + Convert.ToDouble(grdDet.GetValue(row, "CGST").ToString()) + Convert.ToDouble(grdDet.GetValue(row, "SGST").ToString()) + Convert.ToDouble(grdDet.GetValue(row, "TCS")));
        }

        private void SetPartInfor(int row)
        {
        }

        private void grd01_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (m_bClose)
            {
                e.Cancel = true;
                return;
            }
        }

        private bool GridValidation()
        {
            try
            {
                System.Collections.Generic.List<string> dupList = new System.Collections.Generic.List<string>();

                for (int row = 1; row < grdDet.Rows.Count; row++)
                {
                    string partno = grdDet.GetValue(row, "PARTNO").ToString();
                    if (dupList.Contains(partno))
                    {
                        MsgBox.Show("Duplicated Part Number:" + partno, "Error", MessageBoxButtons.OK, ImageKinds.Error);
                        return false;
                    }
                    else
                    {
                        dupList.Add(partno);
                    }

                    string orderno = grdDet.GetValue(row, "SANO").ToString();
                    if (string.IsNullOrEmpty(orderno))
                    {
                        MsgBox.Show("Please enter valid Order No. for the row " + row + "", "Notice");
                        return false;
                    }
                    if (string.IsNullOrEmpty(partno))
                    {
                        MsgBox.Show("Please enter Part No. for the row " + row, "Notice");
                        return false;
                    }

                    string hsnCode = grdDet.GetValue(row, "HSN").ToString();
                    if (string.IsNullOrEmpty(hsnCode))
                    {
                        MsgBox.Show("Please enter valid HSN Code for the row " + row, "Notice");
                        return false;
                    }

                    string partsDescription = grdDet.GetValue(row, "PARTNM").ToString();
                    if (string.IsNullOrEmpty(partsDescription))
                    {
                        MsgBox.Show("Please enter valid Parts description for row " + row, "Notice");
                        return false;
                    }

                    string Qty = grdDet.GetValue(row, "QTY").ToString();
                    if (string.IsNullOrEmpty(Qty))
                    {
                        MsgBox.Show("Please enter valid Qty for the row " + row, "Notice");
                        return false;
                    }

                    int quantity = 0;
                    bool QuantityConvert = false;

                    QuantityConvert = int.TryParse(Qty, out quantity);

                    if (!QuantityConvert)
                    {
                        MsgBox.Show("Please enter valid Quantity for the row " + row, "Notice");
                        return false;
                    }
                    if (quantity == 0)
                    {
                        MsgBox.Show("Please enter valid Quantity for the row " + row, "Notice");
                        return false;
                    }
                    if (quantity < 0)
                    {
                        MsgBox.Show("Please enter valid Quantity for the row " + row, "Notice");
                        return false;
                    }

                    #region UnitPrice
                    string UPrice = grdDet.GetValue(row, "UPRICE").ToString();
                    if (string.IsNullOrEmpty(UPrice))
                    {
                        MsgBox.Show("Please enter valid Unit Price for the row " + row, "Notice");
                        return false;
                    }

                    decimal UnitPriceValue = 0;
                    bool UnitPriceValidation = false;

                    UnitPriceValidation = decimal.TryParse(UPrice, out UnitPriceValue);

                    if (!UnitPriceValidation)
                    {
                        MsgBox.Show("Please enter valid Unit price for the row " + row, "Notice");
                        return false;
                    }
                    if (UnitPriceValue < 0)
                    {
                        MsgBox.Show("Please enter valid Unit price value for the row " + row, "Notice");
                        return false;
                    }
                    if (UnitPriceValue == 0)
                    {
                        MsgBox.Show("Please enter valid Unit price value for the row " + row, "Notice");
                        return false;
                    }
                    #endregion

                    #region CGST
                    string cgst = grdDet.GetValue(row, "CGST").ToString();
                    if (string.IsNullOrEmpty(cgst))
                    {
                        MsgBox.Show("Please enter valid CGST for the row " + row, "Notice");
                        return false;
                    }

                    decimal CGSTValue = 0;
                    bool CGSTValidation = false;

                    CGSTValidation = decimal.TryParse(cgst, out CGSTValue);

                    if (!CGSTValidation)
                    {
                        MsgBox.Show("Please enter valid CGST for the row " + row, "Notice");
                        return false;
                    }
                    if (CGSTValue <= 0)
                    {
                        MsgBox.Show("Please enter valid CGST value for the row " + row, "Notice");
                        return false;
                    }
                    #endregion

                    #region SGST
                    string sgst = grdDet.GetValue(row, "SGST").ToString();
                    if (string.IsNullOrEmpty(sgst))
                    {
                        MsgBox.Show("Please enter valid SGST value for the row " + row, "Notice");
                        return false;
                    }

                    decimal SGSTValue = 0;
                    bool SGSTValidation = false;

                    SGSTValidation = decimal.TryParse(sgst, out SGSTValue);

                    if (!SGSTValidation)
                    {
                        MsgBox.Show("Please enter valid SGST value for the row " + row, "Notice");
                        return false;
                    }
                    if (SGSTValue <= 0)
                    {
                        MsgBox.Show("Please enter valid SGST value for the row " + row, "Notice");
                        return false;
                    }
                    #endregion

                    #region AmountPlusGST
                    string AmountPlusGST = grdDet.GetValue(row, "AMT_PLS_GST").ToString();
                    if (string.IsNullOrEmpty(AmountPlusGST))
                    {
                        MsgBox.Show("Please enter valid Assessable amount for the row " + row, "Notice");
                        return false;
                    }

                    decimal AmountPlusGSTValue = 0;
                    bool AmountPlusGSTValidation = false;

                    AmountPlusGSTValidation = decimal.TryParse(AmountPlusGST, out AmountPlusGSTValue);

                    if (!AmountPlusGSTValidation)
                    {
                        MsgBox.Show("Please enter valid Assessable amount for the row " + row, "Notice");
                        return false;
                    }
                    if (AmountPlusGSTValue <= 0)
                    {
                        MsgBox.Show("Please enter valid Assessable amount value for the row " + row, "Notice");
                        return false;
                    }
                    #endregion

                    #region TCS
                    string TCS = grdDet.GetValue(row, "TCS").ToString();
                    if (string.IsNullOrEmpty(TCS))
                    {
                        MsgBox.Show("Please enter valid TCS for the row " + row, "Notice");
                        return false;
                    }

                    decimal TCSValue = 0;
                    bool TCSValidation = false;

                    TCSValidation = decimal.TryParse(TCS, out TCSValue);

                    if (!TCSValidation)
                    {
                        MsgBox.Show("Please enter valid TCS value for the row " + row, "Notice");
                        return false;
                    }
                    if (TCSValue < 0)
                    {
                        MsgBox.Show("Please enter valid TCS value for the row " + row, "Notice");
                        return false;
                    }
                    #endregion

                    #region TotalAmount
                    string TotalAmount = grdDet.GetValue(row, "TAMT").ToString();
                    if (string.IsNullOrEmpty(TotalAmount))
                    {
                        MsgBox.Show("Please enter valid Total amount for the row " + row, "Notice");
                        return false;
                    }

                    decimal TotalAmountValue = 0;
                    bool TotalAmountValidation = false;

                    TotalAmountValidation = decimal.TryParse(TotalAmount, out TotalAmountValue);

                    if (!TotalAmountValidation)
                    {
                        MsgBox.Show("Please enter valid Total amount should be valid data for the row " + row, "Notice");
                        return false;
                    }
                    if (TotalAmountValue <= 0)
                    {
                        MsgBox.Show("Please enter valid Total amount should be valid data for the row " + row, "Notice");
                        return false;
                    }
                    #endregion

                    #region RowID
                    string RowID = grdDet.GetValue(row, "PK_ID").ToString();
                    if (string.IsNullOrEmpty(RowID))
                    {
                        MsgBox.Show("Row ID should not be empty for the row " + row, "Notice");
                        return false;
                    }

                    long RowIDValue = 0;
                    bool RowIDValidation = false;

                    RowIDValidation = long.TryParse(RowID, out RowIDValue);

                    if (!RowIDValidation)
                    {
                        MsgBox.Show("Row ID not found for the " + row + "row", "Notice");
                        return false;
                    }
                    if (RowIDValue == 0)
                    {
                        MsgBox.Show("Row ID is not found for the " + row + "row.", "Notice");
                        return false;
                    }
                    #endregion
                }
                return true;
            }
            catch (Exception)
            {
            }

            return false;
        }

        private bool MasterDetailsValidation()
        {
            try
            {
                if (string.IsNullOrEmpty(txt01_Customer_Address.Text))
                {
                    MsgBox.Show("Customer address should not be empty", "Notice");
                    txt01_Customer_Address.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txt01_Customer_Address.Text))
                {
                    MsgBox.Show("Customer address should not be empty", "Notice");
                    txt01_Customer_Address.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txt01_Customer_GSTIN.Text))
                {
                    MsgBox.Show("Customer GSTIN should not be empty", "Notice");
                    txt01_Customer_GSTIN.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txt01_Customer_GSTIN.Text))
                {
                    MsgBox.Show("Customer GSTIN should not be empty", "Notice");
                    txt01_Customer_GSTIN.Focus();
                    return false;
                }

                if (cbl01_CustCD.GetValue().ToString() == "")
                {
                    MsgBox.Show("Customer ID should not be empty", "Notice");
                    cbl01_CustCD.Focus();
                    return false;
                }


                string find = "CAR_PLATE_NO = '" + cbl01_VehicleNo.Text + "'";
                DataRow[] foundRows = DataTableVehicle.Select(find);

                if (foundRows.Length <= 0)
                {
                    MsgBox.Show("Select valid vehicle no", "Notice");
                    cbl01_VehicleNo.Focus();
                    return false;
                }

                if (Convert.ToString(cbl01_VehicleNo.SelectedValue) == "")
                {
                    MsgBox.Show("Select vehicle no", "Notice");
                    cbl01_VehicleNo.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txt01_INVOICE_NO.Text))
                {
                    MsgBox.Show("Invoice no should not be empty", "Notice");
                    txt01_INVOICE_NO.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txt01_INVOICE_NO.Text))
                {
                    MsgBox.Show("Invoice no should not be empty", "Notice");
                    txt01_INVOICE_NO.Focus();
                    return false;
                }

                #region FinalAssessableValue
                if (string.IsNullOrEmpty(txt01_Assessable_Value.Text))
                {
                    MsgBox.Show("Assessable value should not be empty", "Notice");
                    txt01_INVOICE_NO.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txt01_Assessable_Value.Text))
                {
                    MsgBox.Show("Assessable value should not be empty", "Notice");
                    txt01_Assessable_Value.Focus();
                    return false;
                }
                bool AssessableValueValidation = false;
                decimal AssessableValue = 0;

                AssessableValueValidation = decimal.TryParse(txt01_Assessable_Value.Text, out AssessableValue);
                if (!AssessableValueValidation)
                {
                    MsgBox.Show("Assessable value should be valid data", "Notice");
                    txt01_Assessable_Value.Focus();
                    return false;
                }
                if (AssessableValue == 0)
                {
                    MsgBox.Show("Assessable value should be valid data", "Notice");
                    txt01_Assessable_Value.Focus();
                    return false;
                }
                if (AssessableValue < 0)
                {
                    MsgBox.Show("Assessable value should be valid data", "Notice");
                    txt01_Assessable_Value.Focus();
                    return false;
                }
                #endregion

                #region FinalCGST
                if (string.IsNullOrEmpty(txt01_CGST.Text))
                {
                    MsgBox.Show("CGST value should be valid data", "Notice");
                    txt01_CGST.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txt01_CGST.Text))
                {
                    MsgBox.Show("CGST value should be valid data", "Notice");
                    txt01_CGST.Focus();
                    return false;
                }
                bool CGSTFinalValueValidation = false;
                decimal CGSTFinalValue = 0;

                CGSTFinalValueValidation = decimal.TryParse(txt01_CGST.Text, out CGSTFinalValue);
                if (!CGSTFinalValueValidation)
                {
                    MsgBox.Show("CGST value should be valid data", "Notice");
                    txt01_CGST.Focus();
                    return false;
                }
                if (CGSTFinalValue == 0)
                {
                    MsgBox.Show("CGST value should be valid data", "Notice");
                    txt01_CGST.Focus();
                    return false;
                }
                if (CGSTFinalValue < 0)
                {
                    MsgBox.Show("CGST value should be valid data", "Notice");
                    txt01_CGST.Focus();
                    return false;
                }
                #endregion

                #region FinalSGST
                if (string.IsNullOrEmpty(txt01_SGST.Text))
                {
                    MsgBox.Show("SGST value should be valid data", "Notice");
                    txt01_SGST.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txt01_SGST.Text))
                {
                    MsgBox.Show("SGST value should be valid data", "Notice");
                    txt01_SGST.Focus();
                    return false;
                }
                bool SGSTFinalValueValidation = false;
                decimal SGSTFinalValue = 0;

                SGSTFinalValueValidation = decimal.TryParse(txt01_SGST.Text, out SGSTFinalValue);
                if (!SGSTFinalValueValidation)
                {
                    MsgBox.Show("SGST value should be valid data", "Notice");
                    txt01_SGST.Focus();
                    return false;
                }
                if (SGSTFinalValue == 0)
                {
                    MsgBox.Show("SGST value should be valid data", "Notice");
                    txt01_SGST.Focus();
                    return false;
                }
                if (SGSTFinalValue < 0)
                {
                    MsgBox.Show("SGST value should be valid data", "Notice");
                    txt01_SGST.Focus();
                    return false;
                }
                #endregion

                #region FinalTCS
                if (string.IsNullOrEmpty(txt01_TCS.Text))
                {
                    MsgBox.Show("TCS value should be valid data", "Notice");
                    txt01_TCS.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txt01_TCS.Text))
                {
                    MsgBox.Show("TCS value should be valid data", "Notice");
                    txt01_TCS.Focus();
                    return false;
                }
                bool TCSFinalValueValidation = false;
                decimal TCSFinalValue = 0;

                TCSFinalValueValidation = decimal.TryParse(txt01_TCS.Text, out TCSFinalValue);
                if (!TCSFinalValueValidation)
                {
                    MsgBox.Show("TCS value should be valid data", "Notice");
                    txt01_TCS.Focus();
                    return false;
                }
                if (TCSFinalValue == 0)
                {
                    MsgBox.Show("TCS value should be valid data", "Notice");
                    txt01_TCS.Focus();
                    return false;
                }
                if (TCSFinalValue < 0)
                {
                    MsgBox.Show("TCS value should be valid data", "Notice");
                    txt01_TCS.Focus();
                    return false;
                }
                #endregion

                #region FinalInvoiceAmount
                if (string.IsNullOrEmpty(txt01_Total.Text))
                {
                    MsgBox.Show("Invoice amount value should be valid data", "Notice");
                    txt01_Total.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txt01_Total.Text))
                {
                    MsgBox.Show("Invoice value should be valid data", "Notice");
                    txt01_Total.Focus();
                    return false;
                }
                bool InvoiceFinalValueValidation = false;
                decimal InvoiceFinalValue = 0;

                InvoiceFinalValueValidation = decimal.TryParse(txt01_Total.Text, out InvoiceFinalValue);
                if (!InvoiceFinalValueValidation)
                {
                    MsgBox.Show("Invoice value should be valid data", "Notice");
                    txt01_Total.Focus();
                    return false;
                }
                if (InvoiceFinalValue == 0)
                {
                    MsgBox.Show("Invoice value should be valid data", "Notice");
                    txt01_Total.Focus();
                    return false;
                }
                if (InvoiceFinalValue < 0)
                {
                    MsgBox.Show("Invoice value should be valid data", "Notice");
                    txt01_Total.Focus();
                    return false;
                }
                #endregion

                if (dtp01_STD_DATE.Value > DateTime.Now)
                {
                    //MsgBox.Show("Future date is not allowed", "Notice");
                    dtp01_STD_DATE.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

            return false;
        }

        private bool UpdateMasterDetails()
        {
            try
            {
                if (MasterDetailsValidation())
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("INVNO", txt01_INVOICE_NO.Text);
                    set.Add("CORTADD", lbl01_Corporation_Address.Text);
                    set.Add("CORGSTIN", lbl01_Corporation_GSTINVal.Value);
                    set.Add("CUSCODE", cbl01_CustCD.GetValue().ToString());
                    set.Add("CUSNAME", cbl01_CustCD.Text);
                    set.Add("CUSADD", txt01_Customer_Address.Text);
                    set.Add("CUSGSTIN", txt01_Customer_GSTIN.Text);
                    set.Add("INV_DATE", dtp01_STD_DATE.GetDateText());
                    set.Add("VEHNO", cbl01_VehicleNo.Text);
                    set.Add("ASSVALUE", Convert.ToDecimal(txt01_Assessable_Value.Text));
                    set.Add("CGST", Convert.ToDecimal(txt01_CGST.Text));
                    set.Add("SGST", Convert.ToDecimal(txt01_SGST.Text));
                    set.Add("TCS", Convert.ToDecimal(txt01_TCS.Text));
                    set.Add("INVAMT", Convert.ToDecimal(txt01_Total.Text));


                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "UPDATE_INV"), set);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        private bool SaveGridData()
        {
            try
            {
                DataSet source = this.grdDet.GetValue(AxFlexGrid.FActionType.All,
                    "INVNO", "SANO", "PARTNM", "HSN", "QTY", "UPRICE", "CGST", "SGST", "AMT_PLS_GST", "TCS", "TAMT", "PK_ID");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["INVNO"] = txt01_INVOICE_NO.Text;
                }

                if (!GridValidation()) return false;

                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "UPDATE_INV_DETAILS"), source);
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString(), "Notice");
            }
            finally
            {
                this.AfterInvokeServer();
            }
            return false;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (UpdateMasterDetails())
            {
                if (SaveGridData())
                {
                    //OBJzsde600.SearchFunc();
                    OBJzsde600.UpdateSingleRowFromDB(CURRENT_ROW);

                    MsgBox.Show("Updated successfully", "Notice");
                }
            }
        }

        private void cbl01_CustCD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string selectedValue = this.cbl01_CustCD.GetValue().ToString();

            try
            {
                if (selectedValue != "")
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("VENDCD", cbl01_CustCD.SelectedValue.ToString());
                    set.Add("LANG_SET", this.UserInfo.Language);

                    DataTable source = null;
                    source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INV_CUSTCD"), set, "OUT_CURSOR").Tables[0];

                    if (source != null)
                    {
                        if (source.Rows.Count > 0)
                        {
                            txt01_Customer_Address.Text = Convert.ToString(source.Rows[0]["ADDRESS"]);
                            txt01_Customer_GSTIN.Text = Convert.ToString(source.Rows[0]["STCD3"]);
                        }
                    }
                }

            }
            catch (Exception)
            {
            }
        }


        private void CalculateGSTAmount()
        {
            try
            {
                txt01_CGST.Text = "";
                txt01_SGST.Text = "";
                txt01_TCS.Text = "";
                txt01_Assessable_Value.Text = "";
                txt01_Total.Text = "";
                double totalCGSTAmount = 0, totalSGSTAmount = 0, totalIGSTAmount = 0;
                double totalTCSAmount = 0, totalAssessableValue = 0, totalAmount = 0;
                double partno_wise_assessable_amount = 0;
                for (int row = 1; row < grdDet.Rows.Count; row++)
                {
                    totalCGSTAmount = totalCGSTAmount + Convert.ToDouble(grdDet.GetValue(row, "CGST").ToString());
                    totalSGSTAmount = totalSGSTAmount + Convert.ToDouble(grdDet.GetValue(row, "SGST").ToString());
                    partno_wise_assessable_amount = (Convert.ToDouble(grdDet.GetValue(row, "UPRICE").ToString())) * (Convert.ToDouble(grdDet.GetValue(row, "QTY").ToString()));
                    totalAssessableValue = totalAssessableValue + (Convert.ToDouble(grdDet.GetValue(row, "UPRICE").ToString())) * (Convert.ToDouble(grdDet.GetValue(row, "QTY").ToString()));
                    totalTCSAmount = totalTCSAmount + Convert.ToDouble(grdDet.GetValue(row, "TCS").ToString());
                    totalAmount = totalAmount + Convert.ToDouble(grdDet.GetValue(row, "TAMT").ToString());

                }

                txt01_CGST.Text = totalCGSTAmount.ToString();
                txt01_SGST.Text = totalSGSTAmount.ToString();
                txt01_TCS.Text = totalTCSAmount.ToString();
                txt01_Assessable_Value.Text = totalAssessableValue.ToString();
                txt01_Total.Text = Math.Round(Convert.ToDouble(totalAmount.ToString()), 2).ToString();
            }
            catch (Exception)
            {
            }
        }

        private void grd01_AfterEdit_1(object sender, RowColEventArgs e)
        {
            try
            {

                int row = e.Row;
                int col = e.Col;
                if (row < this.grdDet.Rows.Fixed) return;
                string findStr = grdDet.GetValue(e.Row, e.Col).ToString();
                DataTable dt = new DataTable();
                HEParameterSet paramSet = new HEParameterSet();
                grdDet.FinishEditing(true);
                switch (grdDet.Cols[col].UserData.ToString())
                {
                    case "UPRICE":
                    case "QTY":
                        ReCalcGrid(row);
                        break;
                    case "PARTNO":
                        break;
                    default:
                        break;
                }
                CalculateGSTAmount();
            }
            catch (Exception)
            {
            }
        }

        private void grdDet_RowInserting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            args.Cancel = true;
        }
    }
}
