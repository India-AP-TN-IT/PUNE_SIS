
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
using System.Net;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using TheOne.Configuration;
using iTextSharp.text;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;

namespace Ax.SIS.SD.UI
{

    public partial class ZSD02500 : AxCommonBaseControl
    {
        //private IPD20010 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;

        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02500";
        private string m_LastCarNo = "";
        private string m_LastCarSeq = "";
        private string m_LastGate = "";
        private bool m_bClose = false;
        ZSD02500_PRTHelper m_newPrt = null;
        public enum InvoiceTypeEnum
        {
            A_KMI_Normal,
            B_ETC_Normal,
            R_Returnable,
            S_Resale,
            T_Retroactive,
            M_Material_Return
        }
        private InvoiceTypeEnum m_InvType = InvoiceTypeEnum.A_KMI_Normal;
        #region [ 초기화 작업 정의 ]

        private string GetInvType()
        {
            string ret = "A";
            switch (m_InvType)
            {
                case InvoiceTypeEnum.A_KMI_Normal:
                    ret = "A";
                    break;
                case InvoiceTypeEnum.B_ETC_Normal:
                    ret = "B";
                    break;
                case InvoiceTypeEnum.R_Returnable:
                    ret = "R";
                    break;
                case InvoiceTypeEnum.S_Resale:
                    ret = "S";
                    break;
                case InvoiceTypeEnum.T_Retroactive:
                    ret = "T";
                    break;
                case InvoiceTypeEnum.M_Material_Return:
                    ret = "M";
                    break;
            }
            return ret;
        }
        private void SetInvType()
        {
            string menu = "";

            if (string.IsNullOrEmpty(MenuID) == true)
            {
                menu = "ZSD02500";
            }
            else
            {
                menu = MenuID;
            }
            //<<Change - Mode
            //menu = "ZSD02501";
            //>>
            switch (menu)
            {
                case "ZSD02500":    //Normal + KMI
                    Lbl_title.Text = "(A)HKMI Only";
                    m_InvType = InvoiceTypeEnum.A_KMI_Normal;
                    SetCustPLANT(GetInvType());
                    cdx01_VENDCD.SetReadOnly(true);
                    cbl01_CustPLANT.ReadOnly = false;
                    if (UserInfo.CorporationCode == "5300")
                    {
                        this.cdx01_VENDCD.SetValue("305995");
                        this.cbl01_CustPLANT.SetValue("HVF5");
                    }
                    else
                    {
                        this.cdx01_VENDCD.SetValue("303408");
                        this.cbl01_CustPLANT.SetValue("KVF1");
                    }
                    panel6.Visible = true;
                    panel7.Visible = false;
                    grd02.Visible = true;
                    Chk_Mnu.Visible = true;
                    Lbl_Gate.ReadOnly = true;
                    lbl01_Remarks.Visible = false;
                    txt01_Remarks.Visible = false;
                    break;
                case "ZSD02501":    //Normal + ETC
                    Lbl_title.Text = "(B)Manual input";
                    m_InvType = InvoiceTypeEnum.B_ETC_Normal;
                    SetCustPLANT(GetInvType());
                    cdx01_VENDCD.SetReadOnly(true);
                    cbl01_CustPLANT.ReadOnly = false;
                    if (UserInfo.CorporationCode == "5300")
                    {
                        this.cdx01_VENDCD.SetValue("305995");
                        this.cbl01_CustPLANT.SetValue("HVF5");
                    }
                    else
                    {
                        this.cdx01_VENDCD.SetValue("303408");
                        this.cbl01_CustPLANT.SetValue("KVF1");
                    }
                    panel6.Visible = false;
                    panel7.Visible = true;
                    grd02.Visible = true;
                    Chk_Mnu.Visible = false;
                    Lbl_Gate.ReadOnly = true;
                    lbl01_Remarks.Visible = false;
                    txt01_Remarks.Visible = false;
                    break;
                case "ZSD02502":    //Resales
                    Lbl_title.Text = "(S)Material Resales";
                    m_InvType = InvoiceTypeEnum.S_Resale;
                    SetCustPLANT(GetInvType());
                    cdx01_VENDCD.SetReadOnly(true);
                    cbl01_CustPLANT.ReadOnly = false;
                    this.cdx01_VENDCD.SetValue("");
                    this.cbl01_CustPLANT.SetValue("");

                    grd01.Cols["DELI_TYPE"].Visible = false;
                    grd01.Cols["SANO"].Visible = false;
                    grd01.Cols["ALCCD"].Visible = false;
                    panel6.Visible = false;
                    panel7.Visible = true;
                    grd02.Visible = true;
                    Chk_Mnu.Visible = false;
                    Lbl_Gate.ReadOnly = false;
                    lbl01_Remarks.Visible = true;
                    txt01_Remarks.Visible = true;
                    break;
            }

        }

        public ZSD02500()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        private void SetCustPLANT(string ty)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("TY", ty);
                DataTable source = null;

                //this.lbl03_LINECD.Value = this.GetLabel("LINE");    //라인
                //this.lbl03_PART_NO.Value = this.GetLabel("PARTNO");    //PART NO

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PLANT"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

                //source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                //this.cbl04_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void SetPartInfor(int row)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());

            set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
            set.Add("CUSTCD", cdx01_VENDCD.GetValue());
            set.Add("PARTNO", grd01.GetValue(row, "PARTNO"));

            set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            set.Add("LANG_SET", this.UserInfo.Language);
            DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.INQUERY_PART_INFOR", set, "OUT_CURSOR");

            if (source.Tables[0].Rows.Count > 0)
            {
                grd01.SetValue(row, "ALCCD", source.Tables[0].Rows[0]["ALCCD"].ToString());
                grd01.SetValue(row, "PGN", source.Tables[0].Rows[0]["PGN"].ToString());
                grd01.SetValue(row, "DELI_TYPE", source.Tables[0].Rows[0]["DELI_TYPE"].ToString());
                grd01.SetValue(row, "UPRICE", source.Tables[0].Rows[0]["UPRICE"].ToString());
                grd01.SetValue(row, "UOM", source.Tables[0].Rows[0]["UOM"].ToString());
                grd01.SetValue(row, "SANO", source.Tables[0].Rows[0]["SANO"].ToString());
                grd01.SetValue(row, "CUST_SHOP", source.Tables[0].Rows[0]["CUST_SHOP"].ToString());
                grd01.SetValue(row, "CUST_GATE", source.Tables[0].Rows[0]["CUST_GATE"].ToString());
            }
            else
            {
                grd01.SetValue(row, "ALCCD", "");
                grd01.SetValue(row, "PGN", "");
                grd01.SetValue(row, "DELI_TYPE", "");
                grd01.SetValue(row, "UPRICE", "");
                grd01.SetValue(row, "UOM", "");
                grd01.SetValue(row, "SANO", "");
                grd01.SetValue(row, "CUST_SHOP", "");
                grd01.SetValue(row, "CUST_GATE", "");
            }
        }
        private void DispInvoiceQTY()
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
            set.Add("CUSTCD", cdx01_VENDCD.GetValue());
            set.Add("CARNO", "");
            set.Add("CARSEQ", "");
            set.Add("TYPE", GetInvType());
            DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.GET_TOTAL", set, "OUT_CURSOR");

            if (source.Tables[0].Rows.Count > 0)
            {
                Lbl_Invoice.Text = string.Format("Invoice : {0:N0} / IRN : {1:N0}", source.Tables[0].Rows[0]["INV_CNT"].ToString(), source.Tables[0].Rows[0]["IRN_CNT"].ToString());
                Lbl_Remain.Text = string.Format("IRN Remain : {0:N0}", source.Tables[0].Rows[0]["REMAIN_CNT"].ToString());
            }
            else
            {
                Lbl_Invoice.Text = "Invoice : 0 / IRN : 0";
                Lbl_Remain.Text = "IRN Remain : 0";
            }
        }
        private void DispInvoiceQTY_DET()
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
            set.Add("CUSTCD", cdx01_VENDCD.GetValue());
            set.Add("CARNO", m_LastCarNo);
            set.Add("CARSEQ", m_LastCarSeq);
            set.Add("TYPE", GetInvType());
            DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.GET_TOTAL", set, "OUT_CURSOR");

            if (source.Tables[0].Rows.Count > 0)
            {
                Lbl_detQTY.Text = string.Format("Invoice : {0:N0} / IRN : {1:N0}", source.Tables[0].Rows[0]["INV_CNT"].ToString(), source.Tables[0].Rows[0]["IRN_CNT"].ToString());
            }
            else
            {
                Lbl_detQTY.Text = "Invoice : 0 / IRN : 0";
            }
        }
        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                Lbl_Invoice.Text = "";
                Lbl_Remain.Text = "";
                Lbl_TotalQuantity.Text = "";
                Lbl_detQTY.Text = "";
                PAN_Supplier.Visible = false;
                Btn_Cancel.Visible = false;
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";



                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 38, "G", "GATE", "GATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "TRUCK", "CARNO", "CARNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 38, "SEQ", "CARSEQ", "CARSEQ");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "SCAN", "SCAN_DATE", "SCAN_DATE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "INVOICE", "INVOICE", "INVOICE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 38, "IRN", "E_YN", "E_YN");



                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 38, "G", "GATE", "GATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "TRUCK", "CARNO", "CARNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 38, "SEQ", "CARSEQ", "CARSEQ");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "SCAN", "SCAN_DATE", "SCAN_DATE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 40, "INVOICE", "INVOICE", "INVOICE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "I/CNT", "INV_CNT", "INV_CNT");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 38, "IRN", "E_YN", "E_YN");

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "TRUCK No.", "CARNO", "CARNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 45, "PGN", "PGN", "PGN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "D/TYPE", "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "INVOICE", "INVOICE", "INVOICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "IRN", "E_YN", "E_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 77, "IRN ACK NO", "IRN_ACK", "IRN_ACK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "EWB", "EWB", "EWB");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "O/NO", "SANO", "SANO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "P/NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "P/NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UOM", "UOM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 50, "QTY.", "QTY", "QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "U/PRICE", "UPRICE", "UPRICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "AMOUNT", "AMT", "AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "CGST", "CGST", "CGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "SGST", "SGST", "SGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "IGST", "IGST", "IGST");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 70, "UTGST", "UTGST", "UTGST");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "TCS", "TCS", "TCS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 40, "SEQ", "SEQID", "SEQID");
                //<<BUFFERS
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUSTCD", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUST_PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUST_SHOP", "CUST_SHOP", "CUST_SHOP");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CUST_GATE", "CUST_GATE", "CUST_GATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "DELI_DATE", "DELI_DATE", "DELI_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CARSEQ", "CARSEQ", "CARSEQ");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "GATE", "GATE", "GATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "USER_ID", "USER_ID", "USER_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "GRPID", "GRPID", "GRPID");
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

                SetInvType();

                rdbIRNGenerationUsingManual.Checked = false;
                rdbIRNGenerationUsingDirectAPIAccess.Checked = true;
                btnDownloadJson.Visible = false;
                btnUploadExcel.Visible = false;
                btnCancelledIRNExcelUpload.Visible = false;
                btnGenerateIRNAndEWayBill.Visible = true;
                btnGenerateEWB.Visible = true;
                LoadCertDATA();
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
            LoadCarData();
            LoadDetail();
        }
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            base.BtnDelete_Click(sender, e);
            try
            {

                if (grd01.Rows.Count > 1)
                {
                    if (string.IsNullOrEmpty(grd01.Rows[1]["INVOICE"].ToString()))
                    {
                        DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "CUSTCD", "CUST_PLANT", "DELI_DATE", "CARNO", "CARSEQ", "PARTNO");
                        _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DEL_DATA"), source);
                        LoadDetail();
                        MsgBox.Show("Removed Data successfully.", "Confirm", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        MsgBox.Show("Already Closed!!", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                        return;
                    }
                }
                else
                {
                    MsgBox.Show("There is no data to delete", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception eLog)
            {
                MsgBox.Show(eLog.ToString());
            }
            finally
            {

            }
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                MsgCodeBox.Show("CD00-0071"); //저장되었습니다.
            }
        }
        private bool SaveData()
        {

            try
            {
                if (grd01.Rows.Count <= 1)
                {
                    MsgBox.Show("There is no data to save", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                    return false;
                }

                if (CheckInvoiceGenerated())
                {
                    MsgBox.Show("Already Closed!!", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                    return false;
                }

                SetCarVars(m_LastCarNo, m_LastCarSeq, true);
                
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All,
     "CORCD", "BIZCD", "CUSTCD", "CUST_PLANT", "DELI_DATE", "CARNO", "CARSEQ"
     , "GATE", "PARTNO", "DELI_TYPE", "QTY", "UPRICE", "AMT", "CGST"
     , "SGST", "IGST", "UTGST", "TCS", "USER_ID", "SANO", "UOM","ALCCD", "CUST_SHOP", "CUST_GATE");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["USER_ID"] = this.UserInfo.EmpNo;
                    rows["CORCD"] = cbo01_CORCD.GetValue();
                    rows["BIZCD"] = cbo01_BIZCD.GetValue();
                    rows["CUSTCD"] = cdx01_VENDCD.GetValue();
                    rows["CUST_PLANT"] = cbl01_CustPLANT.GetValue();
                    rows["DELI_DATE"] = dtp01_STD_DATE.GetDateText();
                    rows["CARSEQ"] = m_LastCarSeq;
                    rows["CARNO"] = m_LastCarNo;
                    rows["GATE"] = Lbl_Gate.Text;
                }

                if (!IsSaveValid(source)) return false;

                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_DATA"), source);
                this.AfterInvokeServer();
                Chk_Mnu.Checked = false;
                this.BtnQuery_Click(null, null);
                return true;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                this.AfterInvokeServer();

            }
        }


        #endregion


        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {

                if (string.IsNullOrEmpty(Lbl_Gate.Text))
                {
                    MsgBox.Show("Gate No should not be empty", "Notice");
                    return false;
                }
                System.Collections.Generic.List<string> dupList = new System.Collections.Generic.List<string>();

                for (int row = 0; row < grd01.Rows.Count; row++)
                {
                    string partno = grd01.GetValue(row, "PARTNO").ToString();
                    // string vendcd = grd01.GetValue(row, "CUSTCD").ToString();
                    if (dupList.Contains(partno))
                    {
                        MsgBox.Show("Duplicated Part Number:" + partno, "Error", MessageBoxButtons.OK, ImageKinds.Error);
                        return false;
                    }
                    else
                    {
                        dupList.Add(partno);
                    }
                    //if (string.IsNullOrEmpty(vendcd))
                    //{
                    //    MsgBox.Show("There is no Customer Code!!");
                    //    return false;
                    //}
                    if (m_InvType == InvoiceTypeEnum.A_KMI_Normal || m_InvType == InvoiceTypeEnum.B_ETC_Normal)
                    {
                        if (cdx01_VENDCD.GetValue().ToString() == "303408")
                        {
                            string orderno = grd01.GetValue(row, "SANO").ToString();
                            if (string.IsNullOrEmpty(orderno))
                            {
                                MsgBox.Show("Enter Order No. for the " + row + "row");
                                return false;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(partno))
                    {
                        MsgBox.Show("Enter Part No. for the " + row + "row");
                        return false;
                    }
                    string Qty = grd01.GetValue(row, "QTY").ToString();
                    if (string.IsNullOrEmpty(Qty) || Qty == "0")
                    {
                        MsgBox.Show("Enter Qty for the row " + row, "Notice");
                        return false;
                    }
                    string UPrice = grd01.GetValue(row, "UPRICE").ToString();
                    if (string.IsNullOrEmpty(UPrice) || UPrice == "0")
                    {
                        MsgBox.Show("Unit Price not fetched for the row " + row + ". Contact IT Team.", "Notice");
                        return false;
                    }
                }
                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        private string GetGate()
        {
            if (axCheckBox1.Checked && axCheckBox2.Checked)
            {
                return "";
            }
            else if (axCheckBox1.Checked)
            {
                return "A";
            }
            else if (axCheckBox2.Checked)
            {
                return "B";
            }
            return "";
        }


        private void Txt_Car_TextChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }

        private string GetALL_YN()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (m_InvType == InvoiceTypeEnum.B_ETC_Normal || m_InvType == InvoiceTypeEnum.S_Resale)
                {
                    return "M";
                }
                else if (Chk_Mnu.Checked == true && m_InvType == InvoiceTypeEnum.A_KMI_Normal)
                {
                    return "M";
                }
                else if (Chk_Mnu.Checked == false && m_InvType == InvoiceTypeEnum.A_KMI_Normal)
                {
                    return "N";
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                return "Y";
            }
            return "Y";
        }
        private void DisCancelBtn()
        {
            Btn_Cancel.Visible = false;
            if (string.IsNullOrEmpty(MenuID) || MenuID == "ZSD02500")
            {
                if (m_bClose == false && GetALL_YN() == "N")
                {
                    Btn_Cancel.Visible = true;
                }
            }
        }
        private void LoadCarData()
        {

            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("DELI_DATE", this.dtp01_STD_DATE.GetDateText());
                set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                set.Add("CUSTCD", cdx01_VENDCD.GetValue());
                set.Add("GATE", GetGate());
                set.Add("TRUCKNO", Txt_Car.Text);
                set.Add("ALL_YN", GetALL_YN());
                set.Add("TYPE", GetInvType());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_TRUCK"), set, "OUT_CURSOR");
                this.AfterInvokeServer();
                this.GetSelectedGrd().SetValue(source.Tables[0]);
                for (int row = 1; row < GetSelectedGrd().Rows.Count; row++)
                {
                    if (string.IsNullOrEmpty(GetSelectedGrd().GetValue(row, "INVOICE").ToString()) == false && GetSelectedGrd().GetValue(row, "E_YN").ToString() == "O")
                    {
                        GetSelectedGrd().Rows[row].StyleNew.BackColor = System.Drawing.Color.Lime;
                    }
                }
                DispInvoiceQTY();


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
        private void axButton1_Click(object sender, EventArgs e)
        {
            LoadCarData();
        }

        private void dtp01_STD_DATE_ValueChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }

        private void axRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }


        private void axCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }
        private DEV.Utility.Controls.AxFlexGrid GetSelectedGrd()
        {
            DEV.Utility.Controls.AxFlexGrid grd = null;
            if (tabControl1.SelectedIndex == 0)
            {
                grd = grd02;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                grd = grd03;
            }
            return grd;
        }
        private void LoadDetail()
        {
            m_bClose = false;
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            set.Add("CARNO", m_LastCarNo);
            set.Add("CARSEQ", m_LastCarSeq);
            set.Add("LANG_SET", UserInfo.Language);

            this.BeforeInvokeServer(true);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DET"), set, "OUT_CURSOR", "OUT_CURSOR1");
            this.AfterInvokeServer();

            string TotalQuantity = source.Tables[1].Rows[0]["TOTAL_QTY"].ToString();
            this.Lbl_TotalQuantity.Text = string.Format("{0} : {1:N0}", "Total Quantity", TotalQuantity);

            this.grd01.SetValue(source.Tables[0]);

            if (MenuID == "ZSD02502")
            {
                if (CheckInvoiceGenerated() == true)
                {
                    txt01_Remarks.Enabled = false;
                    txt01_Remarks.Text = "";
                }
                else
                {
                    txt01_Remarks.Enabled = true;
                }
            }

            if (source.Tables[0] != null)
            {
                if (source.Tables[0].Rows.Count > 0)
                {
                    // MODIFIED
                    txt01_IRN_Generated_Status.Text = Convert.ToInt32(Convert.ToString(source.Tables[0].Rows[0]["IS_IRP_SENT"])) > 0 ? "N" : "Y";
                    if (MenuID == "ZSD02502")
                    {
                        if (CheckInvoiceGenerated() == true)
                        {
                            txt01_Remarks.Text = Convert.ToString(source.Tables[0].Rows[0]["REMARK"]);
                        }
                    }
                }
                else
                {
                    txt01_IRN_Generated_Status.Text = "N";
                }
            }

            if (source.Tables[0].Rows.Count <= 0)
            {
                if (m_InvType == InvoiceTypeEnum.A_KMI_Normal || m_InvType == InvoiceTypeEnum.B_ETC_Normal)
                {
                    this.grd01.Cols[8].Visible = true;
                }
                else
                {
                    this.grd01.Cols[8].Visible = false;
                }
                Lbl_detQTY.Text = "";
            }
            else
            {
                this.grd01.Cols[8].Visible = false;
                DispInvoiceQTY_DET();
            }
            for (int row = 1; row < grd01.Rows.Count; row++)
            {
                string strGRP = grd01.GetValue(row, "GRPID").ToString();
                string strINV = grd01.GetValue(row, "INVOICE").ToString();
                if (string.IsNullOrEmpty(strINV) == false)
                {
                    if (Convert.ToUInt32(strGRP) % 2 == 0)
                    {
                        grd01.Rows[row].StyleNew.BackColor = System.Drawing.Color.Khaki;
                    }
                    else
                    {
                        grd01.Rows[row].StyleNew.BackColor = System.Drawing.Color.Lime;
                    }
                    m_bClose = true;
                }
                else if (row == 1)
                {

                    this.grd01.Cols["SANO"].StyleNew.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    this.grd01.Cols["PARTNO"].StyleNew.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    this.grd01.Cols["QTY"].StyleNew.BackColor = System.Drawing.Color.LightGoldenrodYellow;

                }

            }

            for (int row = 1; row < GetSelectedGrd().Rows.Count; row++)
            {
                if (GetSelectedGrd().GetValue(row, "CARNO").ToString() == m_LastCarNo && GetSelectedGrd().GetValue(row, "CARSEQ").ToString() == m_LastCarSeq)
                {
                    GetSelectedGrd().Rows[row].StyleNew.BackColor = System.Drawing.Color.Blue;
                    GetSelectedGrd().Rows[row].StyleNew.ForeColor = System.Drawing.Color.White;
                }
            }

            if (MenuID == "ZSD02502")
            {
                if (grd01.Rows.Count == 1)
                {
                    txt01_Remarks.Enabled = true;
                    txt01_Remarks.Text = "";
                }
            }

            DisCancelBtn();

            //rdbIRNGenerationUsingManual.Checked = false;
            //rdbIRNGenerationUsingDirectAPIAccess.Checked = true;
            //rdbIRNGenerationUsingDirectAPIAccess_CheckedChanged(null, null);
        }

        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            int row = this.GetSelectedGrd().SelectedRowIndex;
            if (row < 1)
            {
                return;
            }
            GetDetail(GetSelectedGrd().GetValue(row, "CARNO").ToString(), GetSelectedGrd().GetValue(row, "CARSEQ").ToString());
        }
        private void SetCarVars(string carno, string carseq, bool SavingTime = false)
        {
            if (m_InvType != InvoiceTypeEnum.A_KMI_Normal && SavingTime)
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                set.Add("CARNO", carno);
                DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_CUR_MNU_TSEQ"), set, "OUT_CURSOR").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Lbl_TSEQ.Text = dt.Rows[0]["CARSEQ"].ToString();
                }
                else
                {
                    Lbl_TSEQ.Text = carseq;
                }
            }
            else
            {
                Lbl_TSEQ.Text = carseq;
            }
            Lbl_TNO.Text = carno;

            m_LastCarNo = Lbl_TNO.Text;
            m_LastCarSeq = Lbl_TSEQ.Text;
        }
        private void GetDetail(string carno, string carseq)
        {
            try
            {
                int row = this.GetSelectedGrd().SelectedRowIndex;
                int col = this.GetSelectedGrd().ColSel;
                if (row < this.GetSelectedGrd().Rows.Fixed) return;

                SetCarVars(carno, carseq, false);
                Lbl_Gate.Text = GetSelectedGrd().GetValue(row, "GATE").ToString();

                Lbl_Scan.Text = GetSelectedGrd().GetValue(row, "SCAN_DATE").ToString();



                m_LastGate = Lbl_Gate.Text;
                LoadCarData();
                if (string.IsNullOrEmpty(cdx01_VENDCD.GetValue().ToString()) == true)
                {

                    MsgBox.Show("You need to check Customer Code first!!", "Error", MessageBoxButtons.OK);
                    cdx01_VENDCD.Focus();
                    return;
                }
                else
                {
                    LoadDetail();
                }

            }
            catch (Exception eLog)
            {

            }
        }

        private void ReCalcGrid(int row)
        {
            string partno = grd01.GetValue(row, "PARTNO").ToString();
            double up = Convert.ToDouble(grd01.GetValue(row, "UPRICE").ToString());
            double qty = Convert.ToDouble(grd01.GetValue(row, "QTY").ToString());
            double amt = up * qty;
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("CUSTCD", cdx01_VENDCD.GetValue());
            paramSet.Add("PARTNO", partno);
            paramSet.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
            paramSet.Add("VAL", amt);

            DataTable dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.CALC_TAX", paramSet, "OUT_CURSOR").Tables[0];


            grd01.SetValue(row, "AMT", amt);

            grd01.SetValue(row, "CGST", dt.Rows[0]["CGST"].ToString());
            grd01.SetValue(row, "SGST", dt.Rows[0]["SGST"].ToString());

            grd01.SetValue(row, "IGST", dt.Rows[0]["IGST"].ToString());
            grd01.SetValue(row, "UTGST", dt.Rows[0]["UTGST"].ToString());
            grd01.SetValue(row, "TCS", dt.Rows[0]["TCS"].ToString());
        }
        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {

                int row = e.Row;
                int col = e.Col;
                if (row < this.grd01.Rows.Fixed) return;

                string cdStr = "";
                string descStr = "";
                string findStr = grd01.GetValue(e.Row, e.Col).ToString();
                DataTable dt = new DataTable();
                HEParameterSet paramSet = new HEParameterSet();

                grd01.FinishEditing(true);
                switch (grd01.Cols[col].UserData.ToString())
                {
                    case "UPRICE":
                    case "QTY":
                        ReCalcGrid(row);
                        break;
                    case "PARTNO":
                        findStr = grd01.GetValue(row, col).ToString();
                        paramSet = new HEParameterSet();
                        paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                        paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                        paramSet.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                        paramSet.Add("VENDCD", cdx01_VENDCD.GetValue());
                        paramSet.Add("PARTNO", string.IsNullOrEmpty(findStr) ? "@#@#@#@#" : findStr);
                        paramSet.Add("LANG_SET", this.UserInfo.Language);

                        dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.INQUERY_DLG_PART", paramSet, "OUT_CURSOR").Tables[0];
                        if (dt.Rows.Count > 1)
                        {
                            PopupHelper helper = null;
                            ZSD02500_DLG _bm1 = new ZSD02500_DLG("PART", "DESC", findStr, "");
                            _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                            _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                            _bm1.HEUserParameterSetValue("DELI_DATE", dtp01_STD_DATE.GetDateText());
                            _bm1.HEUserParameterSetValue("VENDCD", cdx01_VENDCD.GetValue());
                            _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                            _bm1.HEUserParameterSetValue("PARTNO", findStr);
                            _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                            helper = new PopupHelper(_bm1, "PART");

                            helper.ShowDialog();

                            DataRow slectedRow = (DataRow)helper.SelectedData;
                            if (slectedRow != null)
                            {
                                grd01.SetValue(grd01.Row, 0, "U");
                                grd01.SetValue(grd01.Row, "PARTNO", slectedRow["T_CODE"]);
                                grd01.SetValue(grd01.Row, "PARTNM", slectedRow["T_DESC"]);
                            }
                        }
                        else
                        {
                            grd01.SetValue(row, 0, "U");
                            grd01.SetValue(row, "PARTNO", dt.Rows[0]["T_CODE"]);
                            grd01.SetValue(row, "PARTNM", dt.Rows[0]["T_DESC"]);
                        }
                        SetPartInfor(row);
                        ReCalcGrid(row);
                        break;
                    default:
                        grd01.SetValue(row, 0, "U");
                        break;
                }






            }
            catch (Exception eLog)
            {

            }
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            if (grd01.Rows.Count <= 1)
            {
                MsgBox.Show("There is no data to close", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                return;
            }
            for (int row = 1; row < grd01.Rows.Count; row++)
            {
                if (string.IsNullOrEmpty(grd01.GetValue(row, "INVOICE").ToString()) == false)
                {
                    MsgBox.Show("Already Closed!!", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                    return;
                }
            }
            if (MsgBox.Show("If you select 'YES', data will be closed.\nAre you sure that process this?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
            {


                if (SaveData() == false)
                {
                    return;
                }

                string remarks = "";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("CUSTCD", cdx01_VENDCD.GetValue());
                set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                set.Add("CARNO", m_LastCarNo);
                set.Add("CARSEQ", m_LastCarSeq);
                set.Add("TYPE", GetInvType());  //--A:KMI Normal, B:ETC Normal, R:Returnable Invoice, S:Resale Invoice, T:Retroactive Invoice, M:Material Return Invoice
                if (MenuID == "ZSD02502")
                {
                    remarks = txt01_Remarks.Text;
                }
                set.Add("REMARKS", remarks);

                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROC_DATA"), set);
                CreateJSON();
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                MsgBox.Show("Invoice was assigned.", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
            }

        }

        private void grd01_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (m_bClose)
            {
                e.Cancel = true;
                return;
            }
        }

        private void axButton4_Click(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;
            if (row < 0)
            {
                MsgBox.Show("Select an Invoice to Print", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }
            string Invoice_Number = grd01.GetValue(row, "INVOICE").ToString();

            if (string.IsNullOrEmpty(Invoice_Number))
            {
                MessageBox.Show("Please create Invoice to proceed print", "Notice");
                return;
            }
            string IRN_Presented = grd01.GetValue(row, "E_YN").ToString();

            if (IRN_Presented == "X")
            {
                if (MsgBox.Show("Are you sure to print Invoice(s) without IRN ?", "Warning", MessageBoxButtons.YesNo, ImageKinds.Warnning) != DialogResult.Yes)
                {
                    return;
                }

            }

            if (cdx01_VENDCD.GetValue().ToString() == "303408" || cdx01_VENDCD.GetValue().ToString() == "304069" || cdx01_VENDCD.GetValue().ToString() == "304070" || cdx01_VENDCD.GetValue().ToString() == "305995")
            {
                Print_Invoice(Invoice_Number);
            }
            else
            {
                Print_Invoice_MaterialResale();
            }
        }
        private void Print_InvoiceB()
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
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                set.Add("INVOICE", grd01.GetValue(1, "INVOICE").ToString());
                set.Add("TYPE", GetInvType());


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

        private void Print_Invoice_MaterialResale()
        {
            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                //report.ReportName = "RxRpt/ZSD02500_Temp";
                report.ReportName = "RxRpt/ZSD02500B_IRN";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                set.Add("INVOICE", grd01.GetValue(grd01.Row, "INVOICE").ToString());
                set.Add("TYPE", GetInvType());

                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_PRINTDATA_B"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                DataSet ds1 = new DataSet();
                DataTable dt1 = new DataTable();

                dt1 = ds.Tables[0].Clone();


                // 현재 리포트 구조 그대로 사용을 위해 컬럼 8개 복제..  ( 로직 바꾸면 리포트 본문 반복 구조로 재디자인해야함 공수 많이 들어감 그래서 그냥 기존꺼 활용 )
                for (int i = 1; i <= 8; i++)
                {
                    dt1.Columns.Add("SID" + i, typeof(String));
                    dt1.Columns.Add("RPCS" + i, typeof(String));
                    dt1.Columns.Add("ORDER_NO" + i, typeof(String));
                    dt1.Columns.Add("PARTNO" + i, typeof(String));
                    dt1.Columns.Add("PARTNM" + i, typeof(String));
                    dt1.Columns.Add("HSN" + i, typeof(String));
                    dt1.Columns.Add("QTY" + i, typeof(String));
                    dt1.Columns.Add("CGST_PER" + i, typeof(String));
                    dt1.Columns.Add("CGST" + i, typeof(String));
                    dt1.Columns.Add("SGST" + i, typeof(String));
                    dt1.Columns.Add("SGST_PER" + i, typeof(String));
                    dt1.Columns.Add("IGST" + i, typeof(String));
                    dt1.Columns.Add("IGST_PER" + i, typeof(String));
                    dt1.Columns.Add("UPRICE" + i, typeof(String));
                    dt1.Columns.Add("AMT" + i, typeof(String));

                    dt1.Columns.Add("TCS" + i, typeof(String));
                    dt1.Columns.Add("TCS_PER" + i, typeof(String));
                    dt1.Columns.Add("AMT_PLS_GST" + i, typeof(String));
                    dt1.Columns.Add("TAMT" + i, typeof(String));

                }
                dt1.Columns.Add("QRCODE_INFO");
                dt1.Columns.Add("OTH_INFO", typeof(String));
                dt1.Columns.Add("REC_VENDNM", typeof(String));
                dt1.Columns.Add("REC_ADDRESS_1", typeof(String));
                dt1.Columns.Add("REC_ADDRESS_2", typeof(String));
                dt1.Columns.Add("REMARKS1", typeof(String));

                int startColumn = 1;
                string prevInvoiceNo = string.Empty;
                string qrcode_info = string.Empty;
                DataRow dr = null;

                // 8개 Rows => 1개 Row 로 통합 ( 8개 Rows => Column 으로 대체 되므로 => 계단식 레코드셋 X)
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i]; // 원본 데이터

                    if (!row["INVOICE"].ToString().Trim().Equals(prevInvoiceNo))
                    {
                        // 인보이스의 첫번째 행이라면 새로운 레코드 추가 ( 시작 컬럼 및 qrcode 정보 초기화 )
                        startColumn = 1;
                        qrcode_info = string.Empty;

                        // 인보이스 바뀌면 새 Row 를 추가하기 전에 기존 Row 데이터 Add 하고 신규 Row 생성
                        if (dr != null)
                        {
                            for (int t = 0; t < 4; t++)
                            {
                                var desRow = dt1.NewRow();
                                var sourceRow = dr;
                                desRow.ItemArray = sourceRow.ItemArray.Clone() as object[];

                                dt1.Rows.Add(desRow);           // 요거 여기서 복제해서 4개 더 추가 #1
                            }
                        }

                        dr = dt1.NewRow();          // 신규 Row 생성
                    }
                    else
                    {
                        // 동일한 인보이스 행이라면 컬럼 인덱스 증가 ( 기존 Row 덮어쓰기 )
                        startColumn++;
                    }

                    prevInvoiceNo = row["INVOICE"].ToString().Trim();

                    // 값 추출
                    string current_sid = "SID" + startColumn.ToString();
                    string current_rpcs = "RPCS" + startColumn.ToString();
                    string current_ordno = "ORDER_NO" + startColumn.ToString();
                    string current_partno = "PARTNO" + startColumn.ToString();
                    string current_partnm = "PARTNM" + startColumn.ToString();
                    string current_hsn = "HSN" + startColumn.ToString();
                    string current_qty = "QTY" + startColumn.ToString();
                    string current_cgst = "CGST" + startColumn.ToString();
                    string current_cgst_per = "CGST_PER" + startColumn.ToString();
                    string current_sgst = "SGST" + startColumn.ToString();
                    string current_sgst_per = "SGST_PER" + startColumn.ToString();
                    string current_igst = "IGST" + startColumn.ToString();
                    string current_igst_per = "IGST_PER" + startColumn.ToString();

                    string current_uprice = "UPRICE" + startColumn.ToString();
                    string current_amt = "AMT" + startColumn.ToString();

                    string current_TCS = "TCS" + startColumn.ToString();
                    string current_TCS_per = "TCS_PER" + startColumn.ToString();
                    string current_APG = "AMT_PLS_GST" + startColumn.ToString();
                    string current_TAMT = "TAMT" + startColumn.ToString();

                    decimal dtcs = Math.Round(Convert.ToDecimal(row["TCS"].ToString()), 2);
                    decimal dapg = Math.Round(Convert.ToDecimal(row["AMT_PLS_GST"].ToString()), 2);
                    decimal dtamt = Math.Round(Convert.ToDecimal(row["TAMT"].ToString()), 2);

                    decimal cgst = Math.Round(Convert.ToDecimal(row["CGST"].ToString()), 2);
                    decimal sgst = Math.Round(Convert.ToDecimal(row["SGST"].ToString()), 2);
                    decimal igst = Math.Round(Convert.ToDecimal(row["IGST"].ToString()), 2);
                    decimal uprice = Math.Round(Convert.ToDecimal(row["UPRICE"].ToString()), 2);
                    decimal amt = Math.Round(Convert.ToDecimal(row["AMT"].ToString()), 2);
                    decimal assess_value = Math.Round(Convert.ToDecimal(row["ASSESS_VALUE"].ToString()), 2);
                    decimal overall_cgst = Math.Round(Convert.ToDecimal(row["OVERALL_CGST"].ToString()), 2);
                    decimal overall_sgst = Math.Round(Convert.ToDecimal(row["OVERALL_SGST"].ToString()), 2);
                    decimal overall_igst = Math.Round(Convert.ToDecimal(row["OVERALL_IGST"].ToString()), 2);
                    decimal overall_utgst = Math.Round(Convert.ToDecimal(row["OVERALL_UTGST"].ToString()), 2);
                    decimal overall_tcs = Math.Round(Convert.ToDecimal(row["OVERALL_TCS"].ToString()), 2);
                    decimal total_amt = Math.Round(Convert.ToDecimal(row["TOTAL_AMT"].ToString()), 2);
                    string wd_cgst = row["CGST_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");
                    string wd_sgst = row["SGST_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");
                    string wd_total_amt = row["TOTALAMT_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");
                    string wd_tcs = row["TCS_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");

                    // DataRow 생성
                    dr["COMNM"] = row["COMNM"].ToString();
                    dr["IRN"] = row["IRN"].ToString();
                    if (dr["IRN"].ToString() == "C")
                    {
                        dr["OTH_INFO"] = "CANCELLED";
                    }
                    else
                    {
                        dr["OTH_INFO"] = "";
                    }
                    dr["INVOICE"] = " " + row["INVOICE"].ToString();
                    dr["DELI_DATE"] = " " + row["DELI_DATE"].ToString();
                    dr["CARNO"] = " " + row["CARNO"].ToString();
                    dr["IRN_ACK_NO"] = row["IRN_ACK_NO"].ToString();
                    dr["IRN_ACK_DATE"] = row["IRN_ACK_DATE"].ToString();
                    dr["EWAY_BILL_NO"] = row["EWAY_BILL_NO"].ToString();
                    dr["QRCD_IRN"] = row["QRCD_IRN"].ToString();
                    dr["VENDNM"] = row["VENDNM"].ToString();
                    dr["ADDRESS_1"] = row["ADDRESS_1"].ToString();
                    dr["ADDRESS_2"] = row["ADDRESS_2"].ToString();
                    dr["VEND_GST"] = row["VEND_GST"].ToString();
                    dr["REC_VENDNM"] = row["VENDNM"].ToString();
                    dr["REC_ADDRESS_1"] = row["ADDRESS_1"].ToString();
                    dr["REC_ADDRESS_2"] = row["ADDRESS_2"].ToString();
                    dr["TOTAL_QTY"] = row["TOTAL_QTY"].ToString();
                    dr["ASSESS_VALUE"] = assess_value.ToString().Contains(".") ? assess_value.ToString() : assess_value.ToString() + ".00";
                    dr["OVERALL_CGST"] = overall_cgst.ToString().Contains(".") ? overall_cgst.ToString() : overall_cgst.ToString() + ".00";
                    dr["OVERALL_SGST"] = overall_sgst.ToString().Contains(".") ? overall_sgst.ToString() : overall_sgst.ToString() + ".00";
                    dr["OVERALL_IGST"] = overall_igst.ToString().Contains(".") ? overall_igst.ToString() : overall_igst.ToString() + ".00";
                    dr["OVERALL_UTGST"] = overall_utgst.ToString().Contains(".") ? overall_utgst.ToString() : overall_utgst.ToString() + ".00";
                    dr["OVERALL_TCS"] = overall_tcs.ToString().Contains(".") ? overall_tcs.ToString() : overall_tcs.ToString() + ".00";
                    dr["TOTAL_AMT"] = total_amt.ToString().Contains(".") ? total_amt.ToString() : total_amt.ToString() + ".00";
                    dr["CGST_IN_WORDS"] = wd_cgst;
                    dr["SGST_IN_WORDS"] = wd_sgst;
                    dr["TOTALAMT_IN_WORDS"] = wd_total_amt;
                    dr["TCS_IN_WORDS"] = wd_tcs;
                    dr["KMI_VENDCD"] = row["CUSTCD"].ToString();
                    dr["COMADDR"] = row["COMADDR"].ToString();
                    dr["COM_ETC"] = row["COM_ETC"].ToString();
                    dr["REMARKS1"] = row["REMARK"].ToString();
                    dr[current_sid] = row["SID"].ToString();
                    dr[current_rpcs] = row["RPCS"].ToString();
                    dr[current_ordno] = row["ORDER_NO"].ToString();
                    dr[current_partno] = row["PARTNO"].ToString();
                    dr[current_partnm] = row["PARTNM"].ToString();
                    dr[current_hsn] = row["HSN"].ToString();
                    dr[current_qty] = row["QTY"].ToString();

                    dr[current_cgst] = cgst.ToString().Contains(".") ? cgst.ToString() : cgst.ToString() + ".00";
                    dr[current_cgst_per] = row["CGST_PER"].ToString();
                    dr[current_sgst] = sgst.ToString().Contains(".") ? sgst.ToString() : sgst.ToString() + ".00";
                    dr[current_sgst_per] = row["SGST_PER"].ToString();
                    dr[current_igst] = igst.ToString().Contains(".") ? igst.ToString() : igst.ToString() + ".00";
                    dr[current_igst_per] = row["IGST_PER"].ToString();
                    dr[current_TCS] = dtcs.ToString().Contains(".") ? dtcs.ToString() : dtcs.ToString() + ".00";
                    dr[current_TCS_per] = row["TCS_PER"].ToString();

                    dr[current_uprice] = uprice.ToString().Contains(".") ? uprice.ToString() : uprice.ToString() + ".00";
                    dr[current_uprice] = uprice.ToString().Contains(".") ? uprice.ToString() : uprice.ToString() + ".00";

                    dr[current_APG] = dapg.ToString().Contains(".") ? dapg.ToString() : dapg.ToString() + ".00";
                    dr[current_TAMT] = dtamt.ToString().Contains(".") ? dtamt.ToString() : dtamt.ToString() + ".00";

                    decimal cost_with_tax = cgst + sgst + amt;

                    qrcode_info += "T1" + row["ORDER_NO"].ToString() + row["PARTNO"].ToString() + "\n"
                                    + row["INVOICE"].ToString() + " " + row["DELI_DATE"].ToString().Replace(".", "") + row["QTY"].ToString() + " " + Math.Round(cost_with_tax, 2).ToString() + " " + row["HSN"].ToString() + "0.00" + " "
                                    + cgst.ToString() + " " + "0.00 0.00 " + uprice.ToString() + " " + amt.ToString() + " " + sgst.ToString() + " " + "0.00 0.00 "
                                    + dapg.ToString() + " " + "0.00 0.00 0.00 " + row["GSTNO"].ToString() + " 0" + "\n";

                    dr["QRCODE_INFO"] = qrcode_info;

                }

                // 마지막 Row 는 For 루프 안에서 다음 인덱스가 없어서 탐지가 안되므로 수동으로 추가
                if (dr != null)
                {
                    for (int t = 0; t < 4; t++)
                    {
                        var desRow = dt1.NewRow();
                        var sourceRow = dr;
                        desRow.ItemArray = sourceRow.ItemArray.Clone() as object[];
                        dt1.Rows.Add(desRow);  // 요거 여기서 복제해서 4개 더 추가 #1
                    }
                }

                //int no_of_invoices = dt1.Rows

                // DataTable Add
                ds1.Tables.Add(dt1);
                ds1.Tables[0].TableName = "DATA";
                // ds1.Tables[0].WriteXml("c:\\temp\\ZSD02500.xml", XmlWriteMode.WriteSchema);

                HERexSection xmlSection = new HERexSection(ds1, new HEParameterSet());
                report.Sections.Add("MAIN", xmlSection);

                AxRexpertReportViewer.ShowReport(report);

                dt1.Clear();
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

        public DataSet Print_Invoice(string corcd, string bizcd, string vendcd, string plantcd, string delidate, string carno, string carseq, string gate, string invoice, bool bDigital = false, bool dsRET = false)
        {
            try
            {
                int addPage = 4;
                if (bDigital)
                {
                    addPage = 1;
                }
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                //report.ReportName = "RxRpt/ZSD02500_Temp";
                report.ReportName = "RxRpt/ZSD02500_IRN";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", corcd);
                set.Add("BIZCD", bizcd);
                set.Add("CUSTCD", vendcd);
                set.Add("CUST_PLANT", plantcd);
                set.Add("DELI_DATE", delidate);
                set.Add("CARNO", carno);
                set.Add("CARSEQ", carseq);
                set.Add("GATE", gate);
                if (invoice == "All")
                {
                    set.Add("INVOICE", "");
                }
                else
                {
                    set.Add("INVOICE", invoice);
                }
                set.Add("ADDPAGE", addPage);
                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSD02500", "GET_PRINTDATA"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                DataSet ds1 = new DataSet();
                DataTable dt1 = new DataTable();

                dt1 = ds.Tables[0].Clone();


                // 현재 리포트 구조 그대로 사용을 위해 컬럼 8개 복제..  ( 로직 바꾸면 리포트 본문 반복 구조로 재디자인해야함 공수 많이 들어감 그래서 그냥 기존꺼 활용 )
                for (int i = 1; i <= 8; i++)
                {
                    dt1.Columns.Add("SID" + i, typeof(String));
                    dt1.Columns.Add("RPCS" + i, typeof(String));
                    dt1.Columns.Add("ORDER_NO" + i, typeof(String));
                    dt1.Columns.Add("PARTNO" + i, typeof(String));
                    dt1.Columns.Add("PARTNM" + i, typeof(String));
                    dt1.Columns.Add("HSN" + i, typeof(String));
                    dt1.Columns.Add("QTY" + i, typeof(String));
                    dt1.Columns.Add("CGST_PER" + i, typeof(String));
                    dt1.Columns.Add("CGST" + i, typeof(String));
                    dt1.Columns.Add("SGST" + i, typeof(String));
                    dt1.Columns.Add("SGST_PER" + i, typeof(String));
                    dt1.Columns.Add("IGST" + i, typeof(String));
                    dt1.Columns.Add("IGST_PER" + i, typeof(String));
                    dt1.Columns.Add("UPRICE" + i, typeof(String));
                    dt1.Columns.Add("AMT" + i, typeof(String));

                    dt1.Columns.Add("TCS" + i, typeof(String));
                    dt1.Columns.Add("TCS_PER" + i, typeof(String));
                    dt1.Columns.Add("AMT_PLS_GST" + i, typeof(String));
                    dt1.Columns.Add("TAMT" + i, typeof(String));

                }
                dt1.Columns.Add("QRCODE_INFO");
                dt1.Columns.Add("OTH_INFO", typeof(String));

                int startColumn = 1;
                string prevInvoiceNo = string.Empty;
                string qrcode_info = string.Empty;
                DataRow dr = null;

                // 8개 Rows => 1개 Row 로 통합 ( 8개 Rows => Column 으로 대체 되므로 => 계단식 레코드셋 X)
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i]; // 원본 데이터

                    if (!row["INVOICE"].ToString().Trim().Equals(prevInvoiceNo))
                    {
                        // 인보이스의 첫번째 행이라면 새로운 레코드 추가 ( 시작 컬럼 및 qrcode 정보 초기화 )
                        startColumn = 1;
                        qrcode_info = string.Empty;

                        // 인보이스 바뀌면 새 Row 를 추가하기 전에 기존 Row 데이터 Add 하고 신규 Row 생성
                        if (dr != null)
                        {
                            for (int t = 0; t < addPage; t++)
                            {
                                var desRow = dt1.NewRow();
                                var sourceRow = dr;
                                desRow.ItemArray = sourceRow.ItemArray.Clone() as object[];

                                dt1.Rows.Add(desRow);           // 요거 여기서 복제해서 4개 더 추가 #1
                            }
                        }

                        dr = dt1.NewRow();          // 신규 Row 생성
                    }
                    else
                    {
                        // 동일한 인보이스 행이라면 컬럼 인덱스 증가 ( 기존 Row 덮어쓰기 )
                        startColumn++;
                    }

                    prevInvoiceNo = row["INVOICE"].ToString().Trim();

                    // 값 추출
                    string current_sid = "SID" + startColumn.ToString();
                    string current_rpcs = "RPCS" + startColumn.ToString();
                    string current_ordno = "ORDER_NO" + startColumn.ToString();
                    string current_partno = "PARTNO" + startColumn.ToString();
                    string current_partnm = "PARTNM" + startColumn.ToString();
                    string current_hsn = "HSN" + startColumn.ToString();
                    string current_qty = "QTY" + startColumn.ToString();
                    string current_cgst = "CGST" + startColumn.ToString();
                    string current_cgst_per = "CGST_PER" + startColumn.ToString();
                    string current_sgst = "SGST" + startColumn.ToString();
                    string current_sgst_per = "SGST_PER" + startColumn.ToString();
                    string current_igst = "IGST" + startColumn.ToString();
                    string current_igst_per = "IGST_PER" + startColumn.ToString();

                    string current_uprice = "UPRICE" + startColumn.ToString();
                    string current_amt = "AMT" + startColumn.ToString();

                    string current_TCS = "TCS" + startColumn.ToString();
                    string current_TCS_per = "TCS_PER" + startColumn.ToString();
                    string current_APG = "AMT_PLS_GST" + startColumn.ToString();
                    string current_TAMT = "TAMT" + startColumn.ToString();

                    decimal dtcs = Math.Round(Convert.ToDecimal(row["TCS"].ToString()), 2);
                    decimal dapg = Math.Round(Convert.ToDecimal(row["AMT_PLS_GST"].ToString()), 2);
                    decimal dtamt = Math.Round(Convert.ToDecimal(row["TAMT"].ToString()), 2);

                    decimal cgst = Math.Round(Convert.ToDecimal(row["CGST"].ToString()), 2);
                    decimal sgst = Math.Round(Convert.ToDecimal(row["SGST"].ToString()), 2);
                    decimal igst = Math.Round(Convert.ToDecimal(row["IGST"].ToString()), 2);
                    decimal uprice = Math.Round(Convert.ToDecimal(row["UPRICE"].ToString()), 2);
                    decimal amt = Math.Round(Convert.ToDecimal(row["AMT"].ToString()), 2);
                    decimal assess_value = Math.Round(Convert.ToDecimal(row["ASSESS_VALUE"].ToString()), 2);
                    decimal overall_cgst = Math.Round(Convert.ToDecimal(row["OVERALL_CGST"].ToString()), 2);
                    decimal overall_sgst = Math.Round(Convert.ToDecimal(row["OVERALL_SGST"].ToString()), 2);
                    decimal overall_igst = Math.Round(Convert.ToDecimal(row["OVERALL_IGST"].ToString()), 2);
                    decimal overall_utgst = Math.Round(Convert.ToDecimal(row["OVERALL_UTGST"].ToString()), 2);
                    decimal overall_tcs = Math.Round(Convert.ToDecimal(row["OVERALL_TCS"].ToString()), 2);
                    decimal total_amt = Math.Round(Convert.ToDecimal(row["TOTAL_AMT"].ToString()), 2);
                    string wd_cgst = row["CGST_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");
                    string wd_sgst = row["SGST_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");
                    string wd_total_amt = row["TOTALAMT_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");
                    string wd_tcs = row["TCS_IN_WORDS"].ToString().ToUpper().Replace("RUPEES", "Rupees").Replace("PAISE", "Paise");

                    // DataRow 생성
                    dr["COMNM"] = row["COMNM"].ToString();
                    dr["IRN"] = row["IRN"].ToString();
                    if (dr["IRN"].ToString() == "C")
                    {
                        dr["OTH_INFO"] = "CANCELLED";
                    }
                    else
                    {
                        dr["OTH_INFO"] = "";
                    }
                    dr["INVOICE"] = " " + row["INVOICE"].ToString();
                    dr["DELI_DATE"] = " " + row["DELI_DATE"].ToString();
                    dr["CARNO"] = " " + row["CARNO"].ToString();
                    dr["IRN_ACK_NO"] = row["IRN_ACK_NO"].ToString();
                    dr["IRN_ACK_DATE"] = row["IRN_ACK_DATE"].ToString();
                    dr["EWAY_BILL_NO"] = row["EWAY_BILL_NO"].ToString();
                    dr["QRCD_IRN"] = row["QRCD_IRN"].ToString();
                    dr["VENDNM"] = row["VENDNM"].ToString();
                    dr["ADDRESS_1"] = row["ADDRESS_1"].ToString();
                    dr["ADDRESS_2"] = row["ADDRESS_2"].ToString();
                    dr["VEND_GST"] = row["VEND_GST"].ToString();
                    dr["TOTAL_QTY"] = row["TOTAL_QTY"].ToString();
                    dr["ASSESS_VALUE"] = assess_value.ToString().Contains(".") ? assess_value.ToString() : assess_value.ToString() + ".00";
                    dr["OVERALL_CGST"] = overall_cgst.ToString().Contains(".") ? overall_cgst.ToString() : overall_cgst.ToString() + ".00";
                    dr["OVERALL_SGST"] = overall_sgst.ToString().Contains(".") ? overall_sgst.ToString() : overall_sgst.ToString() + ".00";
                    dr["OVERALL_IGST"] = overall_igst.ToString().Contains(".") ? overall_igst.ToString() : overall_igst.ToString() + ".00";
                    dr["OVERALL_UTGST"] = overall_utgst.ToString().Contains(".") ? overall_utgst.ToString() : overall_utgst.ToString() + ".00";
                    dr["OVERALL_TCS"] = overall_tcs.ToString().Contains(".") ? overall_tcs.ToString() : overall_tcs.ToString() + ".00";
                    dr["TOTAL_AMT"] = total_amt.ToString().Contains(".") ? total_amt.ToString() : total_amt.ToString() + ".00";
                    dr["CGST_IN_WORDS"] = wd_cgst;
                    dr["SGST_IN_WORDS"] = wd_sgst;
                    dr["TOTALAMT_IN_WORDS"] = wd_total_amt;
                    dr["TCS_IN_WORDS"] = wd_tcs;
                    dr["KMI_VENDCD"] = row["KMI_VENDCD"].ToString();
                    dr["COMADDR"] = row["COMADDR"].ToString();
                    dr["COM_ETC"] = row["COM_ETC"].ToString();
                    dr[current_sid] = row["SID"].ToString();
                    dr[current_rpcs] = row["RPCS"].ToString();
                    dr[current_ordno] = row["ORDER_NO"].ToString();
                    dr[current_partno] = row["PARTNO"].ToString();
                    dr[current_partnm] = row["PARTNO"].ToString() + " " + row["PARTNM"].ToString();
                    dr[current_hsn] = row["HSN"].ToString();
                    dr[current_qty] = row["QTY"].ToString();

                    dr[current_cgst] = cgst.ToString().Contains(".") ? cgst.ToString() : cgst.ToString() + ".00";
                    dr[current_cgst_per] = row["CGST_PER"].ToString();
                    dr[current_sgst] = sgst.ToString().Contains(".") ? sgst.ToString() : sgst.ToString() + ".00";
                    dr[current_sgst_per] = row["SGST_PER"].ToString();
                    dr[current_igst] = igst.ToString().Contains(".") ? igst.ToString() : igst.ToString() + ".00";
                    dr[current_igst_per] = row["IGST_PER"].ToString();
                    dr[current_TCS] = dtcs.ToString().Contains(".") ? dtcs.ToString() : dtcs.ToString() + ".00";
                    dr[current_TCS_per] = row["TCS_PER"].ToString();

                    dr[current_uprice] = uprice.ToString().Contains(".") ? uprice.ToString() : uprice.ToString() + ".00";
                    dr[current_uprice] = uprice.ToString().Contains(".") ? uprice.ToString() : uprice.ToString() + ".00";

                    dr[current_APG] = dapg.ToString().Contains(".") ? dapg.ToString() : dapg.ToString() + ".00";
                    dr[current_TAMT] = dtamt.ToString().Contains(".") ? dtamt.ToString() : dtamt.ToString() + ".00";

                    decimal cost_with_tax = cgst + sgst + amt;

                    qrcode_info += "T1" + row["ORDER_NO"].ToString() + row["PARTNO"].ToString() + "\n"
                                    + row["INVOICE"].ToString() + " " + row["DELI_DATE"].ToString().Replace(".", "") + row["QTY"].ToString() + " " + Math.Round(cost_with_tax, 2).ToString() + " " + row["HSN"].ToString() + "0.00" + " "
                                    + cgst.ToString() + " " + "0.00 0.00 " + uprice.ToString() + " " + amt.ToString() + " " + sgst.ToString() + " " + "0.00 0.00 "
                                    + dapg.ToString() + " " + "0.00 0.00 0.00 " + row["GSTNO"].ToString() + " 0" + "\n";

                    dr["QRCODE_INFO"] = qrcode_info;
                    dr["ADDPAGE"] = row["ADDPAGE"].ToString();

                }

                // 마지막 Row 는 For 루프 안에서 다음 인덱스가 없어서 탐지가 안되므로 수동으로 추가
                if (dr != null)
                {
                    for (int t = 0; t < addPage; t++)
                    {
                        var desRow = dt1.NewRow();
                        var sourceRow = dr;
                        desRow.ItemArray = sourceRow.ItemArray.Clone() as object[];
                        dt1.Rows.Add(desRow);  // 요거 여기서 복제해서 4개 더 추가 #1
                    }
                }

                //int no_of_invoices = dt1.Rows

                // DataTable Add
                ds1.Tables.Add(dt1);
                ds1.Tables[0].TableName = "DATA";

                if (dsRET)
                {
                    return ds1;
                }

                HERexSection xmlSection = new HERexSection(ds1, new HEParameterSet());
                report.Sections.Add("MAIN", xmlSection);

                AxRexpertReportViewer.ShowReport(report);

                dt1.Clear();
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
            return null;
        }
        private DataTable GetPrintData(string corcd, string bizcd, string custcd, string cust_plant, string deli_date, string carno, string carseq, string gate, string invoice, string addPage)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("CUSTCD", custcd);
            set.Add("CUST_PLANT", cust_plant);
            set.Add("DELI_DATE", deli_date);
            set.Add("CARNO", carno);
            set.Add("CARSEQ", carseq);
            set.Add("GATE", gate);
            if (invoice == "All")
            {
                set.Add("INVOICE", "");
            }
            else
            {
                set.Add("INVOICE", invoice);
            }
            set.Add("ADDPAGE", addPage);

            DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSD02500", "GET_PRINTDATA"), set, "OUT_CURSOR").Tables[0];
            return dt;

        }
        private void Print_Invoice(string invoice)
        {
            
            if (cbo01_CORCD.GetValue().ToString() == "5300")
            {
                m_newPrt = new ZSD02500_PRTHelper("RxRpt/ZSD02500_PN.xml", "ZSD02500_PN", ref _WSCOM_N);
            }
            else
            {
                m_newPrt = new ZSD02500_PRTHelper("RxRpt/ZSD02500_01.xml", "ZSD02500_01", ref _WSCOM_N);
            }
            DataTable dt = GetPrintData(
                    cbo01_CORCD.GetValue().ToString()
                    , cbo01_BIZCD.GetValue().ToString()
                    , cdx01_VENDCD.GetValue().ToString()
                    , cbl01_CustPLANT.GetValue().ToString()
                    , dtp01_STD_DATE.GetDateText()
                    , Lbl_TNO.Text
                    , Lbl_TSEQ.Text
                    , "X"
                    , invoice == "All" ? "" : invoice
                    , "4"
                    );
            m_newPrt.PrintInvoice(dt);
        }


        private void axButton3_Click(object sender, EventArgs e)
        {
            if (grd01.Rows.Count <= 1)
            {
                MsgBox.Show("Select an Invoice to Print", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
            {
                string InvoiceNo = grd01.GetValue(currRow, "INVOICE").ToString();
                if (string.IsNullOrEmpty(InvoiceNo))
                {
                    MsgBox.Show("Please complete previous operations", "Notice");
                    return;
                }
            }

            // MODIFIED
            if (txt01_IRN_Generated_Status.Text == "N")
            {
                if (cbo01_CORCD.GetValue().ToString() == "5300")
                {
                    string ivx = "";
                    for(int row=grd01.Rows.Fixed;row<grd01.Rows.Count;row++)
                    {
                        if(ivx!=grd01.GetValue(row, "INVOICE").ToString())
                        {
                            ivx = grd01.GetValue(row, "INVOICE").ToString();
                            ZSD02500_IRN_MANUAL dlg = new ZSD02500_IRN_MANUAL(ivx);

                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                dlg.BringToFront();

                                UpdateIRN_MNL(dlg.Invoice, dlg.IRN, dlg.IRN_ACK, dlg.IRN_DATE, dlg.EWB, dlg.Old_IVNO);
                            }
                            else
                            {
                                return;
                            }
                        }

                    }
                }
                else
                {
                    if (MsgBox.Show("Are you sure to print Invoice(s) without IRN ?", "Warning", MessageBoxButtons.YesNo, ImageKinds.Warnning) != DialogResult.Yes)
                    {
                        return;
                    }
                }
            }

            if (cdx01_VENDCD.GetValue().ToString() == "303408" || cdx01_VENDCD.GetValue().ToString() == "304069" || cdx01_VENDCD.GetValue().ToString() == "304070" || cdx01_VENDCD.GetValue().ToString() == "305995")
            {
                Print_Invoice("All");
            }
            else
            {
                Print_Invoice_MaterialResale();
            }
        }

        private void UpdateIRN_MNL(string invoice, string irn, string inr_ack, string inr_date, string ewb, string oldIV)
        {
           
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("INVOICE", invoice);
            paramSet.Add("IRN", irn);
            paramSet.Add("IRN_ACK", inr_ack);
            paramSet.Add("IRN_ACK_DATE", inr_date);
            paramSet.Add("EWB", ewb);
            paramSet.Add("OLD_IVNO", oldIV);
            _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02500.SAVE_IRN_MNL", paramSet);
        }


        private void cbl01_CustPLANT_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbl01_CustPLANT.GetValue().ToString()))
                {
                    cdx01_VENDCD.SetValue("", "");
                    return;
                }
                cdx01_VENDCD.SetValue("", "");
                string selectedValue = this.cbl01_CustPLANT.GetValue().ToString();
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("PLANTCD", selectedValue);
                paramSet.Add("LANG_SET", UserInfo.Language);
                DataTable dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.INQUERY_PLANT_DET", paramSet, "OUT_CURSOR").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string cd = dt.Rows[0]["VENDCD"].ToString();
                    string nm = dt.Rows[0]["VENDNM"].ToString();
                    cdx01_VENDCD.SetValue(nm, cd);
                    if (cd != "303408")
                    {
                        Btn_EtcData.Visible = true;
                    }
                    else
                    {
                        Btn_EtcData.Visible = false;
                    }
                }

            }
            catch (Exception eLog)
            {

            }

        }


        private void grd01_RowInserting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            if (string.IsNullOrEmpty(cdx01_VENDCD.GetValue().ToString()) == true)
            {
                args.Cancel = true;
                MsgBox.Show("You need to check Customer Code first!!", "Error", MessageBoxButtons.OK);
                cdx01_VENDCD.Focus();
                return;

            }
            else if (m_bClose)
            {
                args.Cancel = true;
                MsgBox.Show("Already Colsed!!", "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void axRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (axRadioButton2.Checked)
            {
                PAN_Supplier.Visible = true;
                grd02.Visible = false;

            }
            else
            {
                PAN_Supplier.Visible = false;
                grd02.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 8)
            {
                MsgBox.Show("Wrong Truck Number", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                SetCarVars(textBox1.Text, "500");
                textBox1.Text = "";
            }
        }

        private void btnSyncToIRP_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.grd01.Rows.Count <= 0)
                {
                    MessageBox.Show("Please make invoice then click sync to IRP", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txt01_IRN_Generated_Status.Text == "Y")
                {
                    MessageBox.Show("These invoices have already sent to IRP Interface, You can't resend.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txt01_IRN_Generated_Status.Text == "N")
                {
                    EInvoiceMapper InvMapper = new EInvoiceMapper();

                    IRNRequestModel ObjIRNRequestModel = new IRNRequestModel();

                    if (ValidateIRNRequest())
                    {
                        ObjIRNRequestModel.CorporationCode = Convert.ToString(cbo01_CORCD.GetValue());
                        ObjIRNRequestModel.BusinessCode = Convert.ToString(cbo01_BIZCD.GetValue());
                        ObjIRNRequestModel.CustomerCode = Convert.ToString(cdx01_VENDCD.GetValue());
                        ObjIRNRequestModel.DeliveryDate = dtp01_STD_DATE.GetDateText();
                        ObjIRNRequestModel.TruckNo = Lbl_TNO.Text;
                        ObjIRNRequestModel.TruckSeqNo = Lbl_TSEQ.Text;
                        ObjIRNRequestModel.CustomerPlant = Convert.ToString(cbl01_CustPLANT.GetValue());
                        ObjIRNRequestModel.Gate = Lbl_Gate.Text;
                        ObjIRNRequestModel.InvoiceNo = "";
                    }
                    else
                    {
                        return;
                    }

                    var objMessageEntity = InvMapper.GenerateIRN(ObjIRNRequestModel);

                    if (!string.IsNullOrEmpty(objMessageEntity.Message) && objMessageEntity.Message != "Error Found")
                    {
                        MessageBox.Show("IRN generated successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDetail();
                    }
                    else
                    {
                        MessageBox.Show("IRN generated successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, "Notice");
            }
        }

        private bool ValidateIRNRequest()
        {
            bool ValidationResult = false;

            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(cbo01_CORCD.GetValue())))
                {
                    MessageBox.Show("Select Corporation Code");
                    cbo01_CORCD.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(Convert.ToString(cbo01_BIZCD.GetValue())))
                {
                    MessageBox.Show("Select Business Code");
                    cbo01_BIZCD.Focus();
                    return false;
                }


                if (string.IsNullOrEmpty(Convert.ToString(dtp01_STD_DATE.GetDateText())))
                {
                    MessageBox.Show("Delivery date should not be empty");
                    dtp01_STD_DATE.Focus();
                    return false;
                }

                if (DateTime.Parse(dtp01_STD_DATE.GetDateText()) > DateTime.Parse(DateTime.Now.ToString()))
                {
                    MessageBox.Show("Delivery date should not be future date");
                    dtp01_STD_DATE.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(Lbl_TNO.Text) || string.IsNullOrWhiteSpace(Lbl_TNO.Text))
                {
                    MessageBox.Show("Truck no should not be empty");
                    return false;
                }

                if (string.IsNullOrEmpty(Convert.ToString(cdx01_VENDCD.GetValue())))
                {
                    MessageBox.Show("Select customer code");
                    cdx01_VENDCD.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(Convert.ToString(cbl01_CustPLANT.GetValue())))
                {
                    MessageBox.Show("Select customer plant");
                    cbl01_CustPLANT.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(Convert.ToString(Lbl_Gate.Text)))
                {
                    MessageBox.Show("Gate no should not be empty");
                    return false;
                }

                ValidationResult = true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

            return ValidationResult;
        }

        private void btnDownloadJson_Click(object sender, EventArgs e)
        {
            try
            {
                // MODIFIED
                if (txt01_IRN_Generated_Status.Text == "Y")
                {
                    MsgBox.Show("IRN generated for invoices", "Notice");
                    return;
                }
                for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
                {
                    if (string.IsNullOrEmpty(grd01.GetValue(currRow, "INVOICE").ToString()))
                    {
                        MsgBox.Show("Please create Invoice before JSON download", "Notice");
                        return;
                    }
                }

                if (grd01.Rows.Count == 1)
                {
                    MsgBox.Show("Please create Invoice before JSON download", "Notice");
                    return;
                }

                DownloadJSonFile();
            }
            catch (Exception)
            {
                MsgBox.Show("Failed to download JSON File", "Notice");
            }
        }

        private bool CreateJSON()
        {
            try
            {

                if (this.grd01.Rows.Count <= 1)
                {
                    MessageBox.Show("Please create Invoice before JSON download", "Notice");
                    return false;
                }

                EInvoiceMapper InvMapper = new EInvoiceMapper();

                IRNRequestModel ObjIRNRequestModel = new IRNRequestModel();

                if (ValidateIRNRequest())
                {
                    ObjIRNRequestModel.CorporationCode = Convert.ToString(cbo01_CORCD.GetValue());
                    ObjIRNRequestModel.BusinessCode = Convert.ToString(cbo01_BIZCD.GetValue());
                    ObjIRNRequestModel.CustomerCode = Convert.ToString(cdx01_VENDCD.GetValue());
                    ObjIRNRequestModel.DeliveryDate = dtp01_STD_DATE.GetDateText();
                    ObjIRNRequestModel.TruckNo = Lbl_TNO.Text;
                    ObjIRNRequestModel.TruckSeqNo = Lbl_TSEQ.Text;
                    ObjIRNRequestModel.CustomerPlant = Convert.ToString(cbl01_CustPLANT.GetValue());
                    ObjIRNRequestModel.Gate = Lbl_Gate.Text;
                    ObjIRNRequestModel.InvoiceNo = "";
                    ObjIRNRequestModel.Filename = Lbl_TNO.Text + "_" + Lbl_TSEQ.Text + "_" + dtp01_STD_DATE.GetDateText().Replace(" ", "_").Replace("-", "_").Replace(":", "_") + "_" + Lbl_Gate.Text;

                }
                else
                {
                    return false;
                }
                var objMessageEntity = InvMapper.GenerateJSONFile(ObjIRNRequestModel);
                if (objMessageEntity.Status == "200")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
            return false;
        }

        private void DownloadJSonFile()
        {
            try
            {
                if (CreateJSON())
                {
                    using (WebClient webClient = new WebClient())
                    {

                        string FileNameToDownload = Lbl_TNO.Text + "_" + Lbl_TSEQ.Text + "_" + dtp01_STD_DATE.GetDateText().Replace(" ", "_").Replace("-", "_").Replace(":", "_") + "_" + Lbl_Gate.Text + ".json";
                        SaveFileDialog sf = new SaveFileDialog();
                        sf.FileName = FileNameToDownload;
                        string savePath = "";
                        if (sf.ShowDialog() == DialogResult.OK)
                        {
                            // Now here's our save folder
                            savePath = Path.GetDirectoryName(sf.FileName) + "\\";
                            var urlToSend = new Uri("http://sis.seoyonehap.com/sisinterface/JSON_DOWNLOAD/" + FileNameToDownload);
                            webClient.DownloadFile(urlToSend, sf.FileName);
                            MessageBox.Show("Downloaded successfully", "Notice");
                        }
                    }
                }
                else
                {
                    MsgBox.Show("Failed to create JSON file", "Notice");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notice");
            }
        }

        private void btnUploadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // MODIFIED
                if (txt01_IRN_Generated_Status.Text == "N")
                {
                    for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
                    {
                        if (string.IsNullOrEmpty(grd01.GetValue(currRow, "INVOICE").ToString()))
                        {
                            MsgBox.Show("Please complete previous operations", "Notice");
                            return;
                        }
                    }

                    if (grd01.Rows.Count > 1)
                    {
                        DialogResult result = this.ofdExcel.ShowDialog(this);
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }

                        string filename = this.ofdExcel.FileName;

                        if (!this.IsVaildFile(filename))
                        {
                            MsgCodeBox.Show("CD00-0120");
                            return;
                        }

                        var extensionType = Path.GetExtension(filename);
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                        ReadExcelFile(filename, fileNameWithoutExtension);
                    }
                    else
                    {
                        MsgBox.Show("Select truck no to upload the details", "Notice");
                    }
                }
                else
                {
                    if (grd01.Rows.Count == 1)
                    {
                        MsgBox.Show("Please create invoice before upload excel file", "Notice");
                        return;
                    }

                    MsgBox.Show("All invoices listed here have IRN, You can't update it again", "Notice");
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, "Notice");
            }
        }

        private void ReadExcelFile(string fileName, string fileNameWithoutExtension)
        {
            try
            {
                List<string> lstInvoicesInGrid = new List<string>();
                List<string> lstInvoiceInExcel = new List<string>();

                // GET DATA FROM EXCEL SHEET.

                List<GenerateIRNResponseEntity> lstGenerateIRNRes = new List<GenerateIRNResponseEntity>();
                GenerateIRNResponseEntity objIRNResponseEntity = new GenerateIRNResponseEntity();
                DataTable dt = new DataTable();

                dt = ReadExcelFileAndReturnDataTable("UploadedInvoiceDetails", fileName);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        List<IRNData> lstIRNData = new List<IRNData>();
                        lstIRNData = (from DataRow dr in dt.Rows
                                      select new IRNData()
                                      {
                                          SlNo = Convert.ToString(dr["Sl# No"]),
                                          IRN = Convert.ToString(dr["IRN"]),
                                          AckNo = Convert.ToString(dr["Ack No"]),
                                          AckDate = Convert.ToString(dr["Ack Date"]),
                                          DocNo = Convert.ToString(dr["Doc No"]),
                                          DocType = Convert.ToString(dr["Doc Typ"]),
                                          DocDate = Convert.ToString(dr["Doc Date"]),
                                          InvValue = Convert.ToString(dr["Inv Value#"]),
                                          RecptGSTIN = Convert.ToString(dr["Recipient GSTIN"]),
                                          SignedQRCode = Convert.ToString(dr["Signed QR Code"]),
                                          EWayBill = Convert.ToString(dr["EWB No#/ If Any Errors While Creating EWB#"])
                                      }).ToList();

                        List<IRNData> lstIRNDataAfterDeletEmpRow = new List<IRNData>();
                        lstIRNDataAfterDeletEmpRow = lstIRNData.Where(
                                DataRow => !string.IsNullOrEmpty(DataRow.SlNo) &&
                                           !string.IsNullOrEmpty(DataRow.IRN) &&
                                           !string.IsNullOrEmpty(DataRow.AckNo) &&
                                           !string.IsNullOrEmpty(DataRow.AckDate) &&
                                           !string.IsNullOrEmpty(DataRow.DocNo) &&
                                           !string.IsNullOrEmpty(DataRow.DocType) &&
                                           !string.IsNullOrEmpty(DataRow.DocDate) &&
                                           !string.IsNullOrEmpty(DataRow.InvValue) &&
                                           !string.IsNullOrEmpty(DataRow.RecptGSTIN) &&
                                           !string.IsNullOrEmpty(DataRow.SignedQRCode) &&
                                           !string.IsNullOrEmpty(DataRow.EWayBill)
                                           ).ToList();

                        if (lstIRNDataAfterDeletEmpRow.Count == 0)
                        {
                            MsgBox.Show("Please select the valid excel file", "Notice");
                            return;
                        }

                        for (int currentRow = 0; currentRow <= lstIRNDataAfterDeletEmpRow.Count - 1; currentRow++)
                        {
                            lstInvoiceInExcel.Add(Convert.ToString(dt.Rows[currentRow]["Doc No"]));
                            GenerateIRNResponseEntity IRNRes = new GenerateIRNResponseEntity();
                            IRNRes.AckNo = lstIRNDataAfterDeletEmpRow[currentRow].AckNo;
                            IRNRes.AckDt = lstIRNDataAfterDeletEmpRow[currentRow].AckDate;

                            if (lstIRNDataAfterDeletEmpRow[currentRow].IRN.Length != 64)
                            {
                                MsgBox.Show("IRN should be valid data", "Notice");
                                return;
                            }
                            IRNRes.Irn = lstIRNDataAfterDeletEmpRow[currentRow].IRN;
                            IRNRes.InoviceNo = lstIRNDataAfterDeletEmpRow[currentRow].DocNo;
                            IRNRes.SignedQRCode = lstIRNDataAfterDeletEmpRow[currentRow].SignedQRCode;
                            IRNRes.EwbNo = lstIRNDataAfterDeletEmpRow[currentRow].EWayBill;
                            lstGenerateIRNRes.Add(IRNRes);
                        }
                    }
                    else
                    {
                        ReadFailedExcelFile("FailedInvoiceDetails", fileName);
                        return;
                    }
                }

                for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
                {
                    if (grd01.GetValue(currRow, "E_YN").ToString() == "X")
                    {
                        lstInvoicesInGrid.Add(grd01.GetValue(currRow, "INVOICE").ToString());
                    }

                }

                lstInvoicesInGrid = lstInvoicesInGrid.Distinct().ToList();
                bool sameelementFound = false;
                for (int iter = 0; iter < lstInvoiceInExcel.Count; iter++)
                {
                    sameelementFound = false;
                    for (int grdItr = 0; grdItr < lstInvoicesInGrid.Count; grdItr++)
                    {
                        if (lstInvoiceInExcel.ElementAt(iter) == lstInvoicesInGrid.ElementAt(grdItr))
                        {
                            sameelementFound = true;
                        }
                    }

                    if (sameelementFound == false)
                    {
                        break;
                    }
                }

                if (sameelementFound == false)
                {
                    MsgBox.Show("Please select the valid excel file that contains the invoice no in this page", "Notice");
                    return;
                }
                else
                {
                    objIRNResponseEntity.ListResponse = lstGenerateIRNRes;
                    EInvoiceMapper InvMapper = new EInvoiceMapper();

                    var result = InvMapper.UpdateInvoice(objIRNResponseEntity);

                    if (result.Status != null)
                    {
                        if (result.Status == "200")
                        {
                            LoadDetail();
                            MsgBox.Show("IRN is updated successfully", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
                        }
                        else
                        {
                            MsgBox.Show("Failed to update IRN ", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
                        }
                    }
                    else
                    {
                        MsgBox.Show("Failed to update IRN ", "Notice", MessageBoxButtons.OK, ImageKinds.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void ReadFailedExcelFile(string SheetName, string fileName)
        {
            try
            {
                List<string> lstInvoicesInGrid = new List<string>();
                List<string> lstInvoiceInExcel = new List<string>();
                List<FailedInvoiceDetails> lstFailedInvoiceDetails = new List<FailedInvoiceDetails>();

                // GET DATA FROM EXCEL SHEET.

                List<GenerateIRNResponseEntity> lstGenerateIRNRes = new List<GenerateIRNResponseEntity>();
                GenerateIRNResponseEntity objIRNResponseEntity = new GenerateIRNResponseEntity();
                DataTable dt = new DataTable();

                dt = ReadExcelFileAndReturnDataTable("FailedInvoiceDetails", fileName);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        lstFailedInvoiceDetails = (from DataRow dr in dt.Rows
                                                   select new FailedInvoiceDetails()
                                                   {
                                                       SlNo = Convert.ToString(dr["Sl# No"]),
                                                       InvoiceNo = Convert.ToString(dr["Invoice No"]),
                                                       InvoiceDate = Convert.ToString(dr["Invoice Date"]),
                                                       BuyerGSTIN = Convert.ToString(dr["Buyer GSTIN"]),
                                                       InvoiceValue = Convert.ToString(dr["Invoice Value"]),
                                                       ErrorCode = Convert.ToString(dr["Error Code"]),
                                                       ErrorData = Convert.ToString(dr["Error Date"])
                                                   }
                                                  ).ToList();

                        List<FailedInvoiceDetails> lstFailedInvoiceDetailsAfterDeletEmptyRows = new List<FailedInvoiceDetails>();

                        lstFailedInvoiceDetailsAfterDeletEmptyRows = lstFailedInvoiceDetails.Where(
                                                DataRow => !string.IsNullOrEmpty(DataRow.SlNo) &&
                                                           !string.IsNullOrEmpty(DataRow.InvoiceNo) &&
                                                           !string.IsNullOrEmpty(DataRow.InvoiceDate) &&
                                                           !string.IsNullOrEmpty(DataRow.InvoiceValue) &&
                                                           !string.IsNullOrEmpty(DataRow.BuyerGSTIN) &&
                                                           !string.IsNullOrEmpty(DataRow.ErrorCode) &&
                                                           !string.IsNullOrEmpty(DataRow.ErrorData)
                                                           ).ToList();

                        if (lstFailedInvoiceDetailsAfterDeletEmptyRows.Count == 0)
                        {
                            MsgBox.Show("Please upload valid excel file", "Notice");
                            return;
                        }

                        for (int currentRow = 0; currentRow < lstFailedInvoiceDetailsAfterDeletEmptyRows.Count; currentRow++)
                        {
                            lstInvoiceInExcel.Add(lstFailedInvoiceDetailsAfterDeletEmptyRows[currentRow].InvoiceNo);
                            GenerateIRNResponseEntity IRNRes = new GenerateIRNResponseEntity();
                            IRNRes.InoviceNo = lstFailedInvoiceDetailsAfterDeletEmptyRows[currentRow].InvoiceNo;
                            IRNRes.Remarks = lstFailedInvoiceDetailsAfterDeletEmptyRows[currentRow].ErrorData;
                            lstGenerateIRNRes.Add(IRNRes);
                        }
                    }
                    else
                    {
                        MsgBox.Show("Failed to upload, Please upload correct file/details", "Notice");
                        return;
                    }
                }
                else
                {
                    MsgBox.Show("Failed to upload, Please upload correct file/details", "Notice");
                    return;
                }
                for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
                {
                    if (grd01.GetValue(currRow, "E_YN").ToString() == "X")
                    {
                        lstInvoicesInGrid.Add(grd01.GetValue(currRow, "INVOICE").ToString());
                    }

                }
                lstInvoicesInGrid = lstInvoicesInGrid.Distinct().ToList();
                bool sameelementFound = false;
                for (int iter = 0; iter < lstInvoiceInExcel.Count; iter++)
                {
                    sameelementFound = false;
                    for (int grdItr = 0; grdItr < lstInvoicesInGrid.Count; grdItr++)
                    {
                        if (lstInvoiceInExcel.ElementAt(iter) == lstInvoicesInGrid.ElementAt(grdItr))
                        {
                            sameelementFound = true;
                        }
                    }

                    if (sameelementFound == false)
                    {
                        break;
                    }
                }

                if (sameelementFound == false)
                {
                    MsgBox.Show("Please select the valid excel file that contains the invoice no in this page", "Notice");
                    return;
                }
                else
                {
                    objIRNResponseEntity.ListResponse = lstGenerateIRNRes;
                    EInvoiceMapper InvMapper = new EInvoiceMapper();

                    var result = InvMapper.FailedInvoiceUpdate(objIRNResponseEntity);

                    if (result.Status != null)
                    {
                        if (result.Status == "200")
                        {
                            LoadDetail();
                            MsgBox.Show("Failed invoice is updated successfully", "Notice");
                        }
                        else
                        {
                            MsgBox.Show("Failed invoice details not updated", "Notice");
                        }
                    }
                    else
                    {
                        MsgBox.Show("Failed invoice details not updated", "Notice");
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, "Notice");
            }
        }

        private DataTable ReadExcelFileAndReturnDataTable(string sheetName, string path)
        {

            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                try
                {
                    string Import_FileName = path;
                    string fileExtension = Path.GetExtension(Import_FileName);
                    if (fileExtension == ".xls")
                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                    if (fileExtension == ".xlsx")
                        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                    using (OleDbCommand comm = new OleDbCommand())
                    {
                        comm.CommandText = "Select * from [" + sheetName + "$]";

                        comm.Connection = conn;

                        using (OleDbDataAdapter da = new OleDbDataAdapter())
                        {
                            da.SelectCommand = comm;
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception)
                {
                }
                return dt;
            }
        }
        private void LoadCertDATA()
        {

            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                DataTable inDT = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSD02600", "GET_CERT_DATA"), set, "OUT_CURSOR").Tables[0];
                if (inDT.Rows.Count > 0)
                {

                    string passwd = inDT.Rows[0]["CER_PWD"].ToString();
                    string strFile = inDT.Rows[0]["CER_FILE"].ToString();
                    string strPic = inDT.Rows[0]["CER_PIC"].ToString();
                    byte[] file = GetstringToByte(strFile);
                    byte[] img = GetstringToByte(strPic);
                    ZSD02500_PRTHelper.SetCertPDF(file, img, passwd);



                }
            }
            catch (Exception eLog)
            {
            }
        }
        private byte[] GetstringToByte(string byString)
        {
            return ZSD02100.HexStringToBytes(byString);
        }

        private void Chk_Mnu_CheckedChanged(object sender, EventArgs e)
        {
            LoadCarData();
        }

        private void btnCancelledIRNExcelUpload_Click_1(object sender, EventArgs e)
        {
            try
            {

                for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
                {
                    if (string.IsNullOrEmpty(grd01.GetValue(currRow, "INVOICE").ToString()))
                    {
                        MsgBox.Show("Please complete previous operations", "Notice");
                        return;
                    }
                }

                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                string filename = this.ofdExcel.FileName;
                if (!this.IsVaildFile(filename))
                {
                    MsgCodeBox.Show("CD00-0120");
                    return;
                }
                ReadJSONFileAndUpdate(filename);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void ReadJSONFileAndUpdate(string fileName)
        {
            CancelIRN objCancelIRN = new CancelIRN();

            try
            {
                List<string> lstIRNsInGrid = new List<string>();
                bool IRNFound = false;

                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                    string JsonToDeserialize = json.Substring(1, json.Length - 2);
                    objCancelIRN = JsonConvert.DeserializeObject<CancelIRN>(JsonToDeserialize);
                }

                if (string.IsNullOrEmpty(objCancelIRN.Irn))
                {
                    MsgBox.Show("Please enter valid IRN", "Notice");
                    return;
                }

                if (string.IsNullOrEmpty(objCancelIRN.CancelDate.ToString()))
                {
                    MsgBox.Show("Please enter valid Cancel Date", "Notice");
                    return;
                }

                for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
                {
                    if (grd01.GetValue(currRow, "E_YN").ToString() != "X" && grd01.GetValue(currRow, "E_YN").ToString() != "C")
                    {
                        lstIRNsInGrid.Add(grd01.GetValue(currRow, "E_YN").ToString());
                    }
                }
                lstIRNsInGrid = lstIRNsInGrid.Distinct().ToList();
                for (int currRow = 0; currRow < lstIRNsInGrid.Count; currRow++)
                {
                    if (objCancelIRN.Irn == lstIRNsInGrid.ElementAt(currRow))
                    {
                        IRNFound = true;
                        break;
                    }
                }

                if (IRNFound == false)
                {
                    MsgBox.Show("Please select the valid JSON file that contains the IRN(s) to be cancelled", "Notice");
                    return;
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("IRN", objCancelIRN.Irn);
                set.Add("CAN_DATE", objCancelIRN.CancelDate);
                DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSDE605.IRN_CANCEL", set, "OUT_CURSOR");
                if (source.Tables[0] != null)
                {
                    if (source.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(source.Tables[0].Rows[0]["V_UPDATE_STATUS"]) == "1")
                        {
                            LoadDetail();
                            MsgBox.Show("Cancelled IRN updated successfully", "Notice");
                            return;
                        }
                        else
                        {
                            MsgBox.Show("Failed to update cancelled IRN into SIS", "Notice");
                        }
                    }
                    else
                    {
                        MsgBox.Show("Failed to update cancelled IRN into SIS", "Notice");
                    }
                }
                else
                {
                    MsgBox.Show("Failed to update cancelled IRN into SIS", "Notice");
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private bool CheckInvoiceGenerated()
        {
            bool InvoicePresented = false;
            try
            {
                for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
                {
                    if (!string.IsNullOrEmpty(grd01.GetValue(currRow, "INVOICE").ToString()))
                    {
                        InvoicePresented = true;
                        break;
                    }
                }
                return InvoicePresented;
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
            return false;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MsgBox.Show("Do you want to cancel [" + Lbl_TNO.Text + "/" + Lbl_TSEQ.Text + "]?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", dtp01_STD_DATE.GetDateText());
                set.Add("CARNO", m_LastCarNo);
                set.Add("CARSEQ", m_LastCarSeq);
                _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02500.CANCEL_DATA", set);
                this.BtnQuery_Click(null, null);
            }
        }

        private void btnGenerateIRNAndEWayBill_Click(object sender, EventArgs e)
        {
            if (this.grd01.Rows.Count <= 1)
            {
                MsgBox.Show("Please create Invoice before Generate IRN And EWay Bill", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            if (txt01_IRN_Generated_Status.Text == "Y")
            {
                MsgBox.Show("IRN already generated for all selected invoices", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
            {
                if (string.IsNullOrEmpty(grd01.GetValue(currRow, "INVOICE").ToString()))
                {
                    MsgBox.Show("Please create Invoice before IRN & EWay bill creation", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                    return;
                }
            }

            if (!ValidateIRNRequest())
            {
                return;
            }

            MessageEntity IRNResult = GenerateIRNAndEWayBill();

            if (IRNResult != null)
            {
                LoadDetail();
                if (IRNResult.Status == "200")
                {
                    MsgBox.Show(IRNResult.Message, "SUCCESS", MessageBoxButtons.OK, ImageKinds.Information);
                }
                else
                {
                    //MsgBox.Show(IRNResult.Message, "Information", MessageBoxButtons.OK, ImageKinds.Information);
                    MsgBox.Show("Failed to generate IRN And EWay Bill, Please refer to detailed information in SIS interface table", "Warning", MessageBoxButtons.OK, ImageKinds.Information);
                }

            }
            else
            {
                MsgBox.Show("Failed to generate IRN And EWay Bill, Please refer to detailed information in SIS interface table", "Warning", MessageBoxButtons.OK, ImageKinds.Information);
            }
        }

        private MessageEntity GenerateIRNAndEWayBill()
        {
            MessageEntity messageToBeREturn = null;
            try
            {

                EInvoiceMapper InvMapper = new EInvoiceMapper();

                IRNRequestModel ObjIRNRequestModel = new IRNRequestModel();

                ObjIRNRequestModel.CorporationCode = Convert.ToString(cbo01_CORCD.GetValue());
                ObjIRNRequestModel.BusinessCode = Convert.ToString(cbo01_BIZCD.GetValue());
                ObjIRNRequestModel.CustomerCode = Convert.ToString(cdx01_VENDCD.GetValue());
                ObjIRNRequestModel.DeliveryDate = dtp01_STD_DATE.GetDateText();
                ObjIRNRequestModel.TruckNo = Lbl_TNO.Text;
                ObjIRNRequestModel.TruckSeqNo = Lbl_TSEQ.Text;
                ObjIRNRequestModel.CustomerPlant = Convert.ToString(cbl01_CustPLANT.GetValue());
                ObjIRNRequestModel.Gate = Lbl_Gate.Text;
                ObjIRNRequestModel.InvoiceNo = "";
                ObjIRNRequestModel.Filename = Lbl_TNO.Text + "_" + Lbl_TSEQ.Text + "_" + dtp01_STD_DATE.GetDateText().Replace(" ", "_").Replace("-", "_").Replace(":", "_") + "_" + Lbl_Gate.Text;

                messageToBeREturn = InvMapper.GenerateIRNAndEWayBillUsingDirectAPIAccess(ObjIRNRequestModel);

            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

            return messageToBeREturn;
        }

        private void rdbIRNGenerationUsingManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIRNGenerationUsingManual.Checked == true)
            {
                btnDownloadJson.Visible = true;
                btnUploadExcel.Visible = true;
                btnCancelledIRNExcelUpload.Visible = true;
                btnGenerateIRNAndEWayBill.Visible = false;
                btnGenerateEWB.Visible = false;
            }
        }

        private void rdbIRNGenerationUsingDirectAPIAccess_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIRNGenerationUsingDirectAPIAccess.Checked == true)
            {
                btnDownloadJson.Visible = false;
                btnUploadExcel.Visible = false;
                btnCancelledIRNExcelUpload.Visible = false;
                btnGenerateIRNAndEWayBill.Visible = true;
                btnGenerateEWB.Visible = true;
            }
        }

        private void btnGenerateEWB_Click(object sender, EventArgs e)
        {
            int currentInvoiceRow = this.grd01.SelectedRowIndex;

            if (currentInvoiceRow < 0)
            {
                MsgBox.Show("Select an Invoice to generate EWay bill", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            string Invoice_Number = grd01.GetValue(currentInvoiceRow, "INVOICE").ToString();

            if (string.IsNullOrEmpty(Invoice_Number))
            {
                MsgBox.Show("Please create Invoice to generate EWay bill", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }


            if (IsEWayBillGeneratedForAllInvoices())
            {
                MsgBox.Show("EWay bill is already created", "Information", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            string IRN = Convert.ToString(grd01.GetValue(currentInvoiceRow, "E_YN"));

            if (IRN == "X")
            {
                MsgBox.Show("Please generate IRN for the invoice as IRN should not be empty to generate EWay Bill for the invoice  " + Invoice_Number, "Information", MessageBoxButtons.OK, ImageKinds.Information);
                return;
            }

            MessageEntity EWBResult = GenerateEWayBill(IRN);

            if (EWBResult != null)
            {
                if (EWBResult.Status == "200")
                {
                    LoadDetail();
                }
                MsgBox.Show(EWBResult.Message, "Information", MessageBoxButtons.OK, ImageKinds.Information);
            }
            else
            {
                MsgBox.Show("Failed to generate EWay Bill, Please refer to detailed information in the SIS interface table", "Warning!", MessageBoxButtons.OK, ImageKinds.Information);
            }
        }

        private MessageEntity GenerateEWayBill(string IRN)
        {
            MessageEntity messageToBeREturn = null;
            try
            {

                EInvoiceMapper InvMapper = new EInvoiceMapper();

                CreateEWayBillRequestEntity createEWayBillRequest = new CreateEWayBillRequestEntity();

                createEWayBillRequest.Irn = IRN;
                messageToBeREturn = InvMapper.GenerateEWayBillUsingDirectAPIAccess(createEWayBillRequest);

            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

            return messageToBeREturn;
        }

        private bool IsEWayBillGeneratedForAllInvoices()
        {
            try
            {
                for (int currRow = 1; currRow < grd01.Rows.Count; currRow++)
                {
                    if (string.IsNullOrEmpty(grd01.GetValue(currRow, "EWB").ToString()))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
            return false;
        }

        private void Btn_EtcData_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Lbl_TNO.Text) || string.IsNullOrWhiteSpace(Lbl_TNO.Text))
            {
                MessageBox.Show("Truck no should not be empty");
                return;
            }

            if (string.IsNullOrEmpty(Convert.ToString(cdx01_VENDCD.GetValue())))
            {
                MessageBox.Show("Select customer code");
                cdx01_VENDCD.Focus();
                return;
            }
            PopupHelper helper = null;
            ZSD02500_EtcDelDLG dlg = new ZSD02500_EtcDelDLG(cbo01_CORCD.GetValue().ToString(), cbo01_BIZCD.GetValue().ToString(), cdx01_VENDCD.GetValue().ToString(), dtp01_STD_DATE.GetDateText());
            helper = new PopupHelper(dlg, "ETC Delivery List");
            helper.ShowDialog();
            if(dlg.Selected)
            {
                DataTable dt = dlg.SelectedDT;
                this.grd01.InitializeDataSource();
                for(int row = 0;row<dt.Rows.Count;row++)
                {
                    grd01.Rows.Add();
                    grd01.SetValue(row + 1, "PARTNO", dt.Rows[row]["PARTNO"].ToString());
                    SetPartInfor(row+1);
                    grd01.SetValue(row + 1, "PARTNM", dt.Rows[row]["PARTNM"].ToString());
                    grd01.SetValue(row + 1, "SANO", dt.Rows[row]["PONO"].ToString());
                    grd01.SetValue(row + 1, "QTY", dt.Rows[row]["QTY"].ToString());
                    ReCalcGrid(row+1);

                    
                }

            }
        }
    }




}
