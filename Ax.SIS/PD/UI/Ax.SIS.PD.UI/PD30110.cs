using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using System.Data.OleDb;
using System.Text;
using C1.Win.C1FlexGrid;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Collections.Generic;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>자재창고 출고정보 집계 및 상세조회</b>
    /// - 작 성 자 : 
    /// - 작 성 일 :
    /// </summary>
    public partial class PD30110 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public PD30110()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        private void InitGrid()
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;
                this.heDockingTab1.PanelWidth = 272;

                #region [그리드1]
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Customer Name", "CUSTNM", "CUSTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Invoice Date", "INVOICE_DATE", "INVOICE_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Invoice Qty", "INVOICE_QTY", "INVOICE_QTY");

                this.grd01.Cols["INVOICE_QTY"].Format = _IntFormat;
                #endregion

                #region [그리드2]
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Customer Name", "CUSTNM", "CUSTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Invoice Date", "INVOICE_DATE", "INVOICE_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "Invoice No", "INVOICENO", "INVOICENO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "PNO", "KMI_PARTNO", "KMI_PARTNO");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Invoice Qty", "INVOICE_QTY", "INVOICE_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 124, "Invoice Create Date", "INVOICE_CREATE_DATE", "INVOICE_CREATE_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 124, "Invoice Create Time", "INVOICE_CREATE_TIME", "INVOICE_CREATE_TIME");

                this.grd02.Cols["INVOICE_QTY"].Format = _IntFormat;
                #endregion

                this.grd04.AllowEditing = false;
                this.grd04.Initialize();

                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Customer Name", "CUSTNM", "CUSTNM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Invoice Date", "INVOICE_DATE", "INVOICE_DATE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "Invoice No", "INVOICENO", "INVOICENO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "PNO", "KMI_PARTNO", "KMI_PARTNO");

                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "Invoice Qty", "INVOICE_QTY", "INVOICE_QTY");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "AMT", "AMT", "AMT");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "O/TYPE", "ORD_TYPE", "ORD_TYPE");

                this.grd04.Cols["INVOICE_QTY"].Format = _IntFormat;
                this.grd04.Cols["AMT"].Format = _IntFormat;


                this.grd05.AllowEditing = false;
                this.grd05.Initialize();

                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Customer Name", "CUSTNM", "CUSTNM");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "C/PNO", "PNO", "PNO");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 150, "SAP U/PRICE", "SAP_UPRICE", "SAP_UPRICE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 150, "UNIT PRICE", "UPRICE", "UPRICE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CURRENCY", "CUR", "CUR");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "S/DATE", "ST_DATE", "ST_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "HSN", "HSN", "HSN");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PO", "SANO", "SANO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CUST PNO", "CUST_PARTNO", "CUST_PARTNO");

                this.grd05.Cols["UPRICE"].Format = _DecimalFormat;
                this.grd05.Cols["SAP_UPRICE"].Format = _DecimalFormat;



                this.grd06.AllowEditing = false;
                this.grd06.Initialize();

                this.grd06.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd06.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Month & Year", "YYYYMM", "YYYYMM");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "PartNo", "PARTNO", "PARTNO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Part Name", "PARTNM", "PARTNM");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "Child PartNo.", "CPNO", "CPNO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Cost Element", "ACCNO", "ACCNO");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Qty", "USAGE", "USAGE");

                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Unit", "UOM", "UOM");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Unit of Price", "CUR", "CUR");
                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Price", "UPRICE", "UPRICE");

                this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Index", "COL_ROW", "COL_ROW");


                this.grd06.Cols["USAGE"].Format = _IntFormat;
                this.grd06.Cols["UPRICE"].Format = _DecimalFormat;


                this.grd07.AllowEditing = false;
                this.grd07.Initialize();

                this.grd07.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd07.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "S/LOC", "STR_LOC", "STR_LOC");

                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "T/DATE", "ST_DATE", "ST_DATE");

                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "M/TYPE", "MTYPE", "MTYPE");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "D/NO", "DNO", "DNO");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "UNIT", "UOM", "UOM");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "QTY", "QTY", "QTY");

                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "AMT", "AMT", "AMT");
                this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "REASON", "REASON", "REASON");
                this.grd07.SetColumnType(AxFlexGrid.FCellType.Date, "ST_DATE");
                this.grd07.Cols["ST_DATE"].Format = "yyyy-MM-dd";


                this.grd08.AllowEditing = false;
                this.grd08.Initialize();

                this.grd08.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd08.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");
                this.grd08.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "ST_DATE", "ST_DATE", "ST_DATE");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "C/CODE", "CUSTCD", "CUSTCD");

                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "S/QTY", "SALES_QTY", "SALES_QTY");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "S/AMT", "SALES_AMT", "SALES_AMT");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "M/AMT", "MAT_AMT", "MAT_AMT");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "SM/AMT", "SMAT_AMT", "SMAT_AMT");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "G/AMT", "GOODS_AMT", "GOODS_AMT");


                this.grd09.AllowEditing = false;
                this.grd09.Initialize();

                this.grd09.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd09.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");
                this.grd09.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "ST_DATE", "ST_DATE", "ST_DATE");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "LOC", "STR_LOC", "STR_LOC");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "V/CLASS", "VCLASS", "VCLASS");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "UNIT", "UOM", "UOM");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "CUR", "CUR", "CUR");


                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "O/STOCK", "OPST_QTY", "OPST_QTY");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "O/AMT", "OPST_AMT", "OPST_AMT");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "GR/QTY", "GR_QTY", "GR_QTY");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "GR/AMT", "GR_AMT", "GR_AMT");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "GI/QTY", "GI_QTY", "GI_QTY");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "GI/AMT", "GI_AMT", "GI_AMT");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "E/STOCK", "CLST_QTY", "CLST_QTY");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "E/AMT", "CLST_AMT", "CLST_AMT");

                this.grd10.AllowEditing = false;
                this.grd10.Initialize();

                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Customer Name", "CUSTNM", "CUSTNM");

                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "C/PNO", "PNO", "PNO");

                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 150, "HSN Code", "HSNCD", "HSNCD");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Order No.", "ORDNO", "ORDNO");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "S/DATE", "ST_DATE", "ST_DATE");

                this.grd13.AllowEditing = false;
                this.grd13.Initialize();
                        
                this.grd13.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd13.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "Date", "DOC_DATE", "DOC_DATE");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "Invoice No.", "DOCNO", "DOCNO");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Customer Code", "CUSTCD", "CUSTCD");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "Customer Name", "CUSTNM", "CUSTNM");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "Order Type", "SALES_TYPE", "SALES_TYPE");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PO Number", "PONO", "PONO");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "Part No.", "PARTNO", "PARTNO");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 220, "Part Name", "PARTNM", "PARTNM");
                        
                        
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Qty.", "QTY", "QTY");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Unit", "UOM", "UOM");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Amt.", "AMT", "AMT");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Currency", "CUR", "CUR");
                this.grd13.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "Remarks", "REASON", "REASON");


                this.grd13.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd13.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd13.SetColumnType(AxFlexGrid.FCellType.Date, "DOC_DATE");
                this.grd13.Cols["DOC_DATE"].Format = "yyyy-MM-dd";


                string strcorcd = this.UserInfo.CorporationCode;

                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(strcorcd).Tables[0], false);
                this.cbo01_CORCD.SetReadOnly(true);
                this.cdx01_CUSTCD.HEPopupHelper = new Ax.SIS.CM.UI.CM22022P1(this.cdx01_CUSTCD);
                this.cdx01_CUSTCD.PopupTitle = this.GetLabel("Customer Code");// "업체 코드";

                //this.cbo01_JOB_TYPE.SetValue("A10");
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                this.dte01_CloseDate.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);

                this.Lbl_LastUpdatedDate.Text = GET_UP_UPDATEDATE(this.UserInfo.CorporationCode, this.UserInfo.CorporationCode, "303408");


                CellStyle err_UPrice = grd05.Styles.Add("ERR_UPRICE");
                err_UPrice.Font = new Font(this.Font, FontStyle.Bold);
                err_UPrice.ForeColor = Color.White;
                err_UPrice.BackColor = Color.Red;

                this.axCheckBox1.Checked = false;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            InitGrid();
        }

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0: this.Inquery_Summary(); break;
                    case 1: this.Inquery_Detail(); break;
                    case 2: this.Inquery_UPINV(); break;
                    case 3: this.Inquery_UPRICE(); break;
                    case 4: this.Inquery_COST_BOM(); break;
                    case 8: this.Inquery_HSN(); break;
                    case 9: this.Inquery_ZRE(); break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.InitializeDataSource();
                        this.cdx01_CUSTCD.Initialize();
                        this.txt01_PARTNO.Initialize();
                        this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        break;
                    case 1:
                        this.grd02.InitializeDataSource();
                        this.cdx01_CUSTCD.Initialize();
                        this.txt01_PARTNO.Initialize();
                        this.txt01_INVOICENO.Initialize();
                        this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.lbl01_INVOICENO.Visible = false;
                        this.txt01_INVOICENO.Visible = false;
                        break;
                    case 1:
                    case 9:
                        this.lbl01_INVOICENO.Visible = true;
                        this.txt01_INVOICENO.Visible = true;
                        break;
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void Inquery_Summary()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD30110.INQUERY_SUMMARY", paramSet);
                this.AfterInvokeServer();

                this.grd01.SetValue(source);
                this.ShowDataCount(source);
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

        private void Inquery_Detail()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("INVOICENO", this.txt01_INVOICENO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD30110.INQUERY_DETAIL", paramSet);
                this.AfterInvokeServer();

                this.grd02.SetValue(source);
                this.ShowDataCount(source);
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
        private void Inquery_UPINV()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD30110.INQUERY_UPINV", paramSet);
                this.AfterInvokeServer();

                this.grd04.SetValue(source);
                this.ShowDataCount(source);
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
        private void Inquery_COST_BOM()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("CDATE", this.dte01_CloseDate.Value.ToString("yyyy-MM-dd"));

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD30110.INQUERY_COST_BOM", paramSet);
                this.AfterInvokeServer();

                this.grd06.SetValue(source);
                this.ShowDataCount(source);
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
        private void Inquery_UPRICE()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("CHECKED_YN", this.axCheckBox1.Checked ? "Y" : "N");

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD30110.INQUERY_UPRICE", paramSet);
                this.AfterInvokeServer();

                this.grd05.SetValue(source);
                this.ShowDataCount(source);

                for (int i = 1; i < this.grd05.Rows.Count; i++)
                {
                    if (String.Compare(grd05.Rows[i]["UPRICE"].ToString(), grd05.Rows[i]["SAP_UPRICE"].ToString()) != 0)
                    {
                        for (int j = 1; j < this.grd05.Cols.Count; j++)
                        {
                            this.grd05.SetCellStyle(i, j, "ERR_UPRICE");
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
                this.AfterInvokeServer();
            }
        }
        private void Inquery_HSN()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD30110.INQUERY_HSN", paramSet);
                this.AfterInvokeServer();

                this.grd10.SetValue(source);
                this.ShowDataCount(source);
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
        private void Inquery_ZRE()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("CUSTCD", this.cdx01_CUSTCD.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("INVOICENO", this.txt01_INVOICENO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD30110.INQUERY_ZRE", paramSet);
                this.AfterInvokeServer();

                this.grd13.SetValue(source);
                this.ShowDataCount(source);
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
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0 || tabControl1.SelectedIndex == 1)
                {
                    return;
                }
                if (tabControl1.SelectedIndex == 2)
                {
                    DataSet source = this.grd04.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "CUSTCD", "PARTNO", "INVOICE_DATE", "INVOICENO", "INVOICE_QTY", "ORD_TYPE", "AMT");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_PD30110.DATA_SAVE"), source);
                    this.AfterInvokeServer();
                }
                else if(tabControl1.SelectedIndex == 3)
                {
                    DataSet source = this.grd05.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "CUSTCD", "PNO", "CUR", "UPRICE","HSN","SANO","CUST_PARTNO");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_PD30110.UP_SAVE"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    DataSet source = this.grd06.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "YYYYMM", "PARTNO", "CPNO", "USAGE", "UOM", "UPRICE", "CUR","ACCNO","COL_ROW");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_PD30110.COST_BOM_SAVE"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                   
                    DataSet source = this.grd07.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "PARTNO", "STR_LOC", "ST_DATE", "MTYPE", "DNO", "UOM", "QTY", "AMT", "REASON");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_PD30110.SCRAP_SAVE"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 6)
                {

                    DataSet source = this.grd08.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "ST_DATE", "PARTNO", "CUSTCD", "SALES_QTY", "SALES_AMT", "MAT_AMT", "SMAT_AMT", "GOODS_AMT");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_PD30110.MCLOSE_SAVE"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                 
                    DataSet source = this.grd09.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "ST_DATE", "PARTNO", "STR_LOC", "VCLASS"
                                        , "UOM", "CUR", "OPST_QTY", "OPST_AMT", "GR_QTY", "GR_AMT", "GI_QTY", "GI_AMT", "CLST_QTY", "CLST_AMT");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_PD30110.PS_SAVE"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 8)
                {

                    DataSet source = this.grd10.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "CUSTCD", "PNO", "HSNCD", "ORDNO");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_PD30110.HSN_SAVE"), source);
                    this.AfterInvokeServer();
                }
                else if (tabControl1.SelectedIndex == 9)
                {

                    DataSet source = this.grd13.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "DOC_DATE", "SALES_TYPE", "DOCNO", "PONO", "CUSTCD", "PARTNO", "QTY", "UOM", "AMT", "CUR", "REASON");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_PD30110.ZRE_SAVE"), source);
                    this.AfterInvokeServer();
                }
                this.BtnQuery_Click(null, null);

                //정상적으로 저장되었습니다.
                MsgCodeBox.Show("CD00-0009");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                if (ex.Message.ToString().Split('|').Length > 1)
                {
                    MessageBox.Show(ex.Message.ToString().Split('|')[1]);
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        private void btn01_FILE_UPLOAD2_Click(object sender, EventArgs e)
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
                if (tabControl1.SelectedIndex == 2)
                {
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,[Sold-to party] as CUSTCD";
                    commandString += " ,[Invocie date] as INVOICE_DATE";
                    commandString += " ,[Invocie no] as INVOICENO";
                    commandString += " ,[Matner] as PARTNO";
                    commandString += " ,[Qty] as INVOICE_QTY";
                    commandString += " ,[Order Type] as ORD_TYPE";
                    commandString += " ,[Total amt] as AMT";
                    commandString += " FROM [" + SheetName + "]";
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,[Plant] as CUSTCD";
                    commandString += " ,[Material] as PNO";
                    commandString += " ,[Price] as UPRICE";
                    commandString += " ,[Currency] as CUR";
                    commandString += " ,[SA No] as SANO";
                    commandString += " ,[HSN/SAC] as HSN";
                    commandString += " ,[Cust PartNo] as CUST_PARTNO";
                    commandString += " FROM [" + SheetName + "]";
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,[Material] as PARTNO";
                    commandString += " ,[Storage location] as STR_LOC";
                    commandString += " ,[Movement type] as MTYPE";
                    commandString += " ,[Material Document] as DNO";
                    commandString += " ,[Posting Date] as ST_DATE";
                    commandString += " ,[Qty in unit of entry] as QTY";
                    commandString += " ,[Unit of Entry] as UOM";
                    commandString += " ,[Document Header Text] as REASON";
                    commandString += " ,[Amt#in loc#cur#] as AMT";
                    //commandString += " * ";
                    
                    commandString += " FROM [" + SheetName + "]";
                }
                else if (tabControl1.SelectedIndex == 6)
                {
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,'" + this.axDateEdit1.Value.ToString("yyyy-MM-dd") + "' as ST_DATE";
                    commandString += " ,[Customer] as CUSTCD";
                    commandString += " ,[Product Code] as PARTNO";
                    commandString += " ,[Total Sales Qty#] as SALES_QTY";
                    commandString += " ,[Total Sales value] as SALES_AMT";
                    commandString += " ,[Raw material cost] as MAT_AMT";
                    commandString += " ,[Sub Materials expense] as SMAT_AMT";
                    commandString += " ,[Cost of Sales -Purchase Item] as GOODS_AMT";
                    commandString += " FROM [" + SheetName + "]";
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,'" + this.axDateEdit2.Value.ToString("yyyy-MM-dd") + "' as ST_DATE";
                    commandString += " ,[Storage location] as STR_LOC";
                    commandString += " ,[Valuation Class] as VCLASS";
                    commandString += " ,[Material] as PARTNO";
                    commandString += " ,[Base Unit of Measure] as UOM";
                    commandString += " ,[Currency] as CUR";
                    commandString += " ,[Stock Quantity on Period Start] as OPST_QTY";
                    commandString += " ,[Value on Period Start] as OPST_AMT";

                    commandString += " ,[Total Goods Receipt Quantity] as GR_QTY";
                    commandString += " ,[Total Goods Receipt Value] as GR_AMT";

                    commandString += " ,[Total Goods Issue Quantity] as GI_QTY";
                    commandString += " ,[Total Goods Issue Value] as GI_AMT";

                    commandString += " ,[Stock Quantity on Period End] as CLST_QTY";
                    commandString += " ,[Stock Value on Period End] as CLST_AMT";
                    commandString += " FROM [" + SheetName + "]";
                }
                else if (tabControl1.SelectedIndex == 8)
                {

                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,[Plant] as CUSTCD";
                    commandString += " ,[Material] as PNO";
                    commandString += " ,[Hsn] as HSNCD";
                    commandString += " ,[OrderNo] as ORDNO";
                    commandString += " FROM [" + SheetName + "]";
                }
                else if (tabControl1.SelectedIndex == 9)
                {

                    commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                    commandString += " ,[Invoice Date] as DOC_DATE";
                    commandString += " ,[Order Type] as SALES_TYPE";
                    commandString += " ,[Invoice No] as DOCNO";
                    commandString += " ,[PO Number] as PONO";
                    commandString += " ,[Customer] as CUSTCD";
                    commandString += " ,[Partno] as PARTNO";
                    commandString += " ,[Qty] as QTY";
                    commandString += " ,[Unit] as UOM";
                    commandString += " ,[Total Value] as AMT";
                    commandString += " ,[Currency] as CUR";
                    commandString += " ,[Remarks] as REASON";
                    commandString += " FROM [" + SheetName + "]";
                }
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                oleDB.Close();

                if (tabControl1.SelectedIndex == 2)
                {
                    this.grd04.SetValue(ds);
                    for (int i = 1; i < this.grd04.Rows.Count; i++)
                    {
                        this.grd04[i, 0] = AxFlexGrid.FLAG_N;
                    }
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    this.grd05.SetValue(ds);
                    for (int i = 1; i < this.grd05.Rows.Count; i++)
                    {
                        this.grd05[i, 0] = AxFlexGrid.FLAG_N;
                    }
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                    this.grd07.SetValue(ds);
                    for (int i = 1; i < this.grd07.Rows.Count; i++)
                    {
                        this.grd07[i, 0] = AxFlexGrid.FLAG_N;
                    }
                }
                else if (tabControl1.SelectedIndex == 6)
                {
                    this.grd08.SetValue(ds);
                    for (int i = 1; i < this.grd08.Rows.Count; i++)
                    {
                        this.grd08[i, 0] = AxFlexGrid.FLAG_N;
                    }
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                    this.grd09.SetValue(ds);
                    for (int i = 1; i < this.grd09.Rows.Count; i++)
                    {
                        this.grd09[i, 0] = AxFlexGrid.FLAG_N;
                    }
                }
                else if (tabControl1.SelectedIndex == 8)
                {
                    this.grd10.SetValue(ds);
                    for (int i = 1; i < this.grd10.Rows.Count; i++)
                    {
                        this.grd10[i, 0] = AxFlexGrid.FLAG_N;
                    }
                }
                else if (tabControl1.SelectedIndex == 9)
                {
                    this.grd13.SetValue(ds);
                    for (int i = 1; i < this.grd13.Rows.Count; i++)
                    {
                        this.grd13[i, 0] = AxFlexGrid.FLAG_N;
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
                if (tabControl1.SelectedIndex == 2)
                {
                    txt01_EXL_FILE.Value = FileName;
                    cbo01_EXL_SHEET.DataBind(dsSheet.Tables[0], false);
                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }
                else if(tabControl1.SelectedIndex ==3)
                {
                    axTextBox1.Value = FileName;
                    axComboBox1.DataBind(dsSheet.Tables[0], false);

                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                    axTextBox3.Value = FileName;
                    axComboBox3.DataBind(dsSheet.Tables[0], false);

                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }
                else if (tabControl1.SelectedIndex == 6)
                {
                    axTextBox3.Value = FileName;
                    axComboBox3.DataBind(dsSheet.Tables[0], false);

                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                    axTextBox4.Value = FileName;
                    axComboBox4.DataBind(dsSheet.Tables[0], false);

                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }
                else if (tabControl1.SelectedIndex == 8)
                {
                    axTextBox5.Value = FileName;
                    axComboBox5.DataBind(dsSheet.Tables[0], false);

                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
                }
                else if (tabControl1.SelectedIndex == 9)
                {
                    axTextBox6.Value = FileName;
                    axComboBox6.DataBind(dsSheet.Tables[0], false);

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
        private void axButton1_Click(object sender, EventArgs e)
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

        private string GET_UP_UPDATEDATE(string CORCD, string BIZCD, string CUSTCD)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("CUSTCD", CUSTCD);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_PD30110.GET_UP_UPDATEDATE", paramSet);
                this.AfterInvokeServer();

                return "File Last Updated Date : " + source.Tables[0].Rows[0]["UPDATE_DATE"].ToString();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                return "File Last Updated Date : Error on Fetching Data";
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void axCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void Btn01_COST_BOM_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = this.ofdTxt.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                string filename = this.ofdTxt.FileName;

                if (!this.IsVaildFile(filename))
                {
                    MsgCodeBox.Show("CD00-0120");
                    return;
                }

                string delimiter = "\t";
                DataTable dt = new DataTable();

                dt.Columns.Add("CORCD");
                dt.Columns.Add("BIZCD");
                dt.Columns.Add("YYYYMM");
                dt.Columns.Add("PARTNO");
                dt.Columns.Add("CPNO");
                dt.Columns.Add("ACCNO");
                dt.Columns.Add("USAGE");
                dt.Columns.Add("UOM");
                dt.Columns.Add("UPRICE");
                dt.Columns.Add("CUR");
                dt.Columns.Add("COL_ROW");

                Dictionary<string, int> data_map = new Dictionary<string, int>();

                List<string> colData = new List<string>();

                int FRow = -1;


                using (TextFieldParser parser = Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFieldParser(filename, delimiter))
                {
                    while (!parser.EndOfData)
                    {
                        try
                        {
                            FRow++;
                            string[] fields = parser.ReadFields();

                            for (int i = 0; i < fields.Length; i++)
                            {
                                if (FRow == 0)
                                {

                                    if (data_map.ContainsKey(fields[i].ToString().Replace(" ", "").ToUpper()) == false)
                                    {
                                        //MsgBox.Show(i.ToString() + "-" + data_map.ContainsKey(fields[i].ToString().Replace(" ", "").ToUpper()).ToString() + "-" + fields[i].ToString().Replace(" ", "").ToUpper());
                                        switch (fields[i].ToString().Replace(" ", "").ToUpper())
                                        {
                                            case "PLANT": data_map.Add("PLANT", i); break;
                                            case "PARENTMATERIALCODE": data_map.Add("PARENTMATERIALCODE", i); break;
                                            case "CHILDMATERIALPARTNO.": data_map.Add("CHILDMATERIALPARTNO.", i); break;
                                            case "COSTELEMENT": data_map.Add("COSTELEMENT", i); break;
                                            case "QTY.": data_map.Add("QTY.", i); break;
                                            case "BASEUNIT": data_map.Add("BASEUNIT", i); break;
                                            case "PRICE": data_map.Add("PRICE", i); break;
                                            case "PRICEUNIT": data_map.Add("PRICEUNIT", i); break;
                                        }
                                    }
                                    else
                                    {
                                        switch (fields[i].ToString().Replace(" ", "").ToUpper())
                                        {
                                            case "CHILDMATERIALPARTNO.": data_map["CHILDMATERIALPARTNO."] = i; break;
                                            case "PRICEUNIT": data_map["PRICEUNIT"] = i; break;
                                        }
                                    }
                                }
                            }


                            if (string.IsNullOrEmpty(fields[data_map["PARENTMATERIALCODE"]].ToString()) || string.IsNullOrEmpty(fields[data_map["CHILDMATERIALPARTNO."]].ToString()) || FRow == 0) continue;

                            for (int i = 0; i < fields.Length; i++)
                            {
                                if (data_map.ContainsValue(i))
                                {
                                    colData.Add(fields[i].ToString());
                                }
                            }

                            dt.Rows.Add();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

                if (dt != null)
                {
                    int k = 0;
                    for (int i = 0; i < (colData.Count / 8); i++)
                    {
                        for (int j = 1; j < 10; j++)
                        {
                            if (j == 2) continue;
                            dt.Rows[i][j] = colData[k];
                            dt.Rows[i]["CORCD"] = UserInfo.CorporationCode;
                            dt.Rows[i]["YYYYMM"] = dte01_CloseDate.GetValue().ToString().Substring(0,7).Replace("-","");
                            dt.Rows[i]["COL_ROW"] = k.ToString();
                            if (string.IsNullOrEmpty(dt.Rows[i]["BIZCD"].ToString())) dt.Rows[i]["BIZCD"] = UserInfo.BusinessCode;
                            k++;
                        }

                    }

                    this.grd06.SetValue(dt);
                }
                else
                {
                    MsgBox.Show("No result to show");
                }


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
    }
}
