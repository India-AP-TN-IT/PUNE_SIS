using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;

using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
using System.Diagnostics;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 초기화 
    /// </summary>
    public partial class WM20520 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";

        private string m_strPrintType = "A4";

        DataSet source_grd = null;

        public WM20520()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                label1.Text = "";
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1();
                this.cdx01_VENDCD.PopupTitle = lbl01_VENDCD.Text;
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                #region grd01

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Business", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 350, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "Mat type", "MAT_TYPE_NM", "MAT_TYPE_NM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Mat type", "MAT_TYPE", "MAT_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 102, "Dom imp div", "DOM_IMP_DIV", "DOM_IMP_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "Vendor", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 400, "Vendor name", "VENDNM", "VENDNM");;
                 


                #endregion 

                this.grd02.Initialize();
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 021, "선택", "CHK", "CHK");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Business", "BIZCD", "BIZNM2");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "Lot no", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "Part name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "Qty", "QTY", "QTY");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Mat type", "MAT_TYPE_NM", "MAT_TYPE_NM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Mat type", "MAT_TYPE", "MAT_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 102, "Dom imp div", "DOM_IMP_DIV", "DOM_IMP_DIV");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 070, "PRINT_QTY", "PRINT_QTY", "PRINT_QTY");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 082, "Stock date", "STOCK_DATE", "STOCK_DATE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 082, "Prod date", "PROD_DATE", "PROD_DATE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Order no", "ORDERNO", "ORDERNO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 090, "Vendor", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "Vendor name", "VENDNM", "VENDNM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "INV_STATUS", "INV_STATUS", "INV_STATUS");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "USER_ID", "USER_ID", "USER_ID");

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "NOTENO", "NOTENO", "NOTENO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "DELI_DATE", "DELI_DATE", "DELI_DATE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "DELI_CNT", "DELI_CNT", "DELI_CNT");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "INVOICE_NO", "INVOICE_NO", "INVOICE_NO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "CASE_NO", "CASENO", "CASENO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "EDI_TAG", "EDI_TAG", "EDI_TAG");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "STOCKED_LOTNO", "STOCKED_LOTNO", "STOCKED_LOTNO");

                #region grd03
                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "CORCD", "P_CORCD", "P_LOTNO");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "BIZCD", "P_BIZCD", "P_LOTNO");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "LOTNO", "P_LOTNO", "P_LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PARTNO", "P_PARTNO", "P_PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY", "P_QTY", "P_QTY");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Mat type", "P_MAT_TYPE_NM", "P_MAT_TYPE_NM");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Mat type", "P_MAT_TYPE", "P_MAT_TYPE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "DOM_IMP_DIV", "P_DOM_IMP_DIV", "P_DOM_IMP_DIV");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "PROD_DATE", "P_PROD_DATE", "P_PROD_DATE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "VENDCD", "P_VENDCD", "P_VENDCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "PRINT", "P_PRINT_QTY", "P_PRINT_QTY");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "TOTAL", "P_TOTAL_QTY", "P_TOTAL_QTY");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "USER_ID", "P_USER_ID", "P_USER_ID");
                //this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "TAG CNT", "P_TAGCNT", "P_TAGCNT");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "TAG SIZE", "P_TAGSIZE", "P_TAGSIZE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "TAG PIECE", "P_TAGPIECE", "P_TAGPIECE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "CASE_NO", "P_CASE_NO", "P_CASE_NO");
                //this.grd03.SelectionMode = SelectionModeEnum.Row;
                this.grd03.Rows.Fixed = 1;
                //this.grd03.Clear();
                #endregion

                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                // tag size
                DataTable combo_source_PRINT_DIV2 = new DataTable();
                combo_source_PRINT_DIV2.Columns.Add("CODE");
                combo_source_PRINT_DIV2.Columns.Add("NAME");
                combo_source_PRINT_DIV2.Rows.Add("LARGE", "LARGE");
                combo_source_PRINT_DIV2.Rows.Add("MIDDLE", "MIDDLE");
                combo_source_PRINT_DIV2.Rows.Add("SMALL", "SMALL");
                this.cbo01_PRINT_DIV2.DataBind(combo_source_PRINT_DIV2, false);
                this.cbo01_PRINT_DIV2.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_PRINT_DIV2.SetValue("MIDDLE");

                DataTable combo_source_PRINT_DIV3 = new DataTable();
                combo_source_PRINT_DIV3.Columns.Add("CODE");
                combo_source_PRINT_DIV3.Columns.Add("NAME");
                combo_source_PRINT_DIV3.Rows.Add("ONE", "ONE PIECE");
                combo_source_PRINT_DIV3.Rows.Add("TWO", "TWO PIECE");
                this.cbo01_PRINT_DIV3.DataBind(combo_source_PRINT_DIV3, false);
                this.cbo01_PRINT_DIV3.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_PRINT_DIV3.SetValue("ONE");

                #endregion

                grd01.SelectionMode = SelectionModeEnum.Row;
               

                

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
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20520.INQUIRY_PART_INFO", set, "OUT_CURSOR");
                grd01.SetValue(source.Tables[0]);

                label1.Text = "";
                


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


        private void axButton1_Click(object sender, EventArgs e)
        {
            m_strPrintType = "A4";
            Print_SCM_Tag();

            //if (grd03.Rows.Count <= grd03.Rows.Fixed)
            //{
            //    MsgBox.Show("There is no item to print");
            //    return;
            //}
            //DataSet ds_selected = grd03.GetValue(AxFlexGrid.FActionType.All
            //    , "P_CORCD", "P_BIZCD", "P_LOTNO", "P_PARTNO", "P_QTY", "P_MAT_TYPE", "P_MAT_TYPE_NM", "P_DOM_IMP_DIV", "P_PROD_DATE", "P_VENDCD", "P_PRINT_QTY", "P_USER_ID", "P_TAGSIZE", "P_TAGPIECE");

            //for (int j_cnt = 0; j_cnt < ds_selected.Tables[0].Rows.Count; j_cnt++)
            //{
            //    DataRow row = ds_selected.Tables[0].Rows[j_cnt];
            //    HEParameterSet set = new HEParameterSet();
                
            //    set.Add("CORCD", Convert.ToString(row["P_CORCD"]));//this.UserInfo.CorporationCode);
            //    set.Add("BIZCD", Convert.ToString(row["P_BIZCD"]));//this.UserInfo.BusinessCode);
            //    set.Add("LOTNO", Convert.ToString(row["P_LOTNO"]));//"");
            //    set.Add("PARTNO", Convert.ToString(row["P_PARTNO"]));//label1.Text);
            //    set.Add("QTY", Convert.ToString(row["P_QTY"]));//axTextBox2.Text);
            //    set.Add("MAT_TYPE", Convert.ToString(row["P_MAT_TYPE"]));//grd01.GetValue(grd01.SelectedRowIndex, "MAT_TYPE").ToString());
            //    set.Add("DOM_IMP_DIV", Convert.ToString(row["P_DOM_IMP_DIV"]));//grd01.GetValue(grd01.SelectedRowIndex, "DOM_IMP_DIV").ToString());
            //    set.Add("PROD_DATE", Convert.ToString(row["P_PROD_DATE"]));//"");
            //    set.Add("VENDCD", Convert.ToString(row["P_VENDCD"]));//grd01.GetValue(grd01.SelectedRowIndex, "VENDCD").ToString());
            //    set.Add("PRINT_QTY", Convert.ToString(row["P_PRINT_QTY"]));//axTextBox1.Text);
            //    set.Add("USER_ID", Convert.ToString(row["P_USER_ID"]));//this.UserInfo.UserID);

            //    DataSet source = _WSCOM.ExecuteDataSet("APG_WM20520.SAVE_PRINT", set);
            //    DataTable exist_source = (DataTable)grd02.GetValue();
            //    //if (null != exist_source) exist_source.Merge(source.Tables[0]);
            //    if (j_cnt != 0) exist_source.Merge(source.Tables[0]);
            //    else exist_source = source.Tables[0];
            //    grd02.SetValue(exist_source);
            //}

            //PrintTag();
            //grd03.Rows.RemoveRange(grd03.Rows.Fixed, grd03.Rows.Count - grd03.Rows.Fixed);
        }

        private void Print_SCM_Tag()
        {

            if (grd03.Rows.Count <= grd03.Rows.Fixed)
            {
                MsgBox.Show("There is no item to print");
                return;
            }
            DataSet ds_selected = grd03.GetValue(AxFlexGrid.FActionType.All
                , "P_CORCD", "P_BIZCD", "P_LOTNO", "P_PARTNO", "P_QTY", "P_MAT_TYPE", "P_MAT_TYPE_NM", "P_DOM_IMP_DIV", "P_PROD_DATE", "P_VENDCD", "P_PRINT_QTY", "P_USER_ID", "P_TAGSIZE", "P_TAGPIECE", "P_CASE_NO");
            
            for (int j_cnt = 0; j_cnt < ds_selected.Tables[0].Rows.Count; j_cnt++)
            {
                DataRow row = ds_selected.Tables[0].Rows[j_cnt];
                HEParameterSet set = new HEParameterSet();

                set.Add("CORCD", Convert.ToString(row["P_CORCD"]));//this.UserInfo.CorporationCode);
                set.Add("BIZCD", Convert.ToString(row["P_BIZCD"]));//this.UserInfo.BusinessCode);
                set.Add("LOTNO", Convert.ToString(row["P_LOTNO"]));//"");
                set.Add("PARTNO", Convert.ToString(row["P_PARTNO"]));//label1.Text);
                set.Add("QTY", Convert.ToString(row["P_QTY"]));//axTextBox2.Text);
                set.Add("MAT_TYPE", Convert.ToString(row["P_MAT_TYPE"]));//grd01.GetValue(grd01.SelectedRowIndex, "MAT_TYPE").ToString());
                set.Add("DOM_IMP_DIV", Convert.ToString(row["P_DOM_IMP_DIV"]));//grd01.GetValue(grd01.SelectedRowIndex, "DOM_IMP_DIV").ToString());
                set.Add("PROD_DATE", Convert.ToString(row["P_PROD_DATE"]));//"");
                set.Add("VENDCD", Convert.ToString(row["P_VENDCD"]));//grd01.GetValue(grd01.SelectedRowIndex, "VENDCD").ToString());
                set.Add("PRINT_QTY", Convert.ToString(row["P_PRINT_QTY"]));//axTextBox1.Text);
                set.Add("USER_ID", Convert.ToString(row["P_USER_ID"]));//this.UserInfo.UserID);
                set.Add("CASE_NO", Convert.ToString(row["P_CASE_NO"]));//this.UserInfo.UserID);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20520.SAVE_PRINT", set);
                DataTable exist_source = (DataTable)grd02.GetValue();
                //if (null != exist_source) exist_source.Merge(source.Tables[0]);
                if (j_cnt != 0) exist_source.Merge(source.Tables[0]);
                else exist_source = source.Tables[0];
                grd02.SetValue(exist_source);
            }

            PrintTag();
            grd03.Rows.RemoveRange(grd03.Rows.Fixed, grd03.Rows.Count - grd03.Rows.Fixed);
        }

        private void PrintTag()
        {
            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                //if (object.Equals(this.cbo01_PRINT_DIV2.GetValue(),"LARGE"))
                //    report.ReportName = "RxRpt/WM20430_R1_L";
                //else if (object.Equals(this.cbo01_PRINT_DIV2.GetValue(),"MIDDLE"))
                //    report.ReportName = "RxRpt/WM20430_R1";
                //else
                //    report.ReportName = "RxRpt/WM20430_R1_S";

                if (m_strPrintType == "A4")
                {
                    if (this.cbo01_PRINT_DIV2.GetValue().ToString().Equals("LARGE"))
                        if (this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
                            report.ReportName = "RxRpt/WM20430_R1_L";
                        else
                            report.ReportName = "RxRpt/WM20430_R1_L2";
                    else if (this.cbo01_PRINT_DIV2.GetValue().ToString().Equals("MIDDLE"))
                        if (this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
                            report.ReportName = "RxRpt/WM20430_R1";
                        else
                            report.ReportName = "RxRpt/WM20430_R12";
                    else
                        if (this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
                            report.ReportName = "RxRpt/WM20430_R1_S";
                        else
                            report.ReportName = "RxRpt/WM20430_R1_S2";
                }
                else if (m_strPrintType == "BARCODE")
                {
                    report.ReportName = "RxRpt/WM20520_BP2";
                }
                else if (m_strPrintType == "UBCODE")
                {
                    report.ReportName = "RxRpt/WM20520_BP2";
                }
                //string url = "C:\\Work\\HE_ERM\\HE.ERM\\PD\\UI\\HE.ERM.PD.UI\\";     //XML 경로  

                // Main Section (main report parameter set)
                HERexSection mainSection = new HERexSection();
                mainSection.ReportParameter.Add("PRINT_USER", this.UserInfo.UserID + "(" + this.UserInfo.UserName + ")");
                mainSection.ReportParameter.Add("TEST_PARAM1", "파라메터1");
                mainSection.ReportParameter.Add("TEST_PARAM2", "파라메터2");
                report.Sections.Add("MAIN", mainSection);


                DataSet ds = this.grd02.GetValue(AxFlexGrid.FActionType.All,
                        "CHK",
                        "BIZCD",
                        "LOTNO",
                        "NOTENO",
                        "PARTNO",
                        "PARTNM",
                        "QTY",
                        "DELI_DATE",
                        "DELI_CNT",
                        "ORDERNO",
                        "VENDCD",
                        "VENDNM",
                        "INVOICE_NO",
                        "CASENO",
                        "INV_STATUS",
                        "DOM_IMP_DIV",
                        "WORK_DATE",
                        "WORK_TIME",
                        "USER_ID",
                        "EDI_TAG",
                        "PROD_DATE",
                        "MAT_TYPE",
                        "MAT_TYPE_NM",
                        "STOCK_DATE2");

                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    // LOT입력여부 체크 
                    row["BIZCD"] = row["BIZCD"].ToString();
                    if (m_strPrintType == "UBCODE")
                    {
                        row["LOTNO"] = row["PARTNO"].ToString();
                        row["NOTENO"] = row["PARTNO"].ToString();
                    }
                    else
                    {
                        row["LOTNO"] = row["LOTNO"].ToString();
                        row["NOTENO"] = row["NOTENO"].ToString();
                    }
                    row["PARTNO"] = row["PARTNO"].ToString();
                    row["PARTNM"] = row["PARTNM"].ToString();
                    row["QTY"] = row["QTY"].ToString();
                    row["DELI_DATE"] = row["DELI_DATE"].ToString().Length > 0 ? DateTime.Parse(row["DELI_DATE"].ToString()).ToString("dd/MM/yyyy") : "";
                    row["DELI_CNT"] = row["DELI_CNT"].ToString();
                    row["ORDERNO"] = row["ORDERNO"].ToString();
                    row["VENDCD"] = row["VENDCD"].ToString();
                    //row["VENDNM"] = "TRANSFER"; // row["VENDNM"].ToString();
                    row["VENDNM"] = row["VENDNM"].ToString();
                    if (m_strPrintType == "UBCODE")
                    {
                        row["INVOICE_NO"] = row["PARTNO"].ToString();
                    }
                    else
                    {
                        row["INVOICE_NO"] = row["INVOICE_NO"].ToString();
                    }                    
                    row["CASENO"] = row["CASENO"].ToString();
                    row["INV_STATUS"] = row["INV_STATUS"].ToString();
                    row["DOM_IMP_DIV"] = row["DOM_IMP_DIV"].ToString();
                    row["STOCK_DATE2"] = row["WORK_DATE"].ToString().Length > 0 ? DateTime.Parse(row["WORK_DATE"].ToString()).ToString("dd/MM/yyyy").Replace(".", "/").Replace("-", "/") : "";
                    row["WORK_TIME"] = row["WORK_TIME"].ToString();
                    row["USER_ID"] = row["USER_ID"].ToString();
                    row["EDI_TAG"] = row["EDI_TAG"].ToString();
                    row["PROD_DATE"] = row["PROD_DATE"].ToString().Length > 0 ? DateTime.Parse(row["PROD_DATE"].ToString()).ToString("dd/MM/yyyy") : "";
                    row["MAT_TYPE"] = row["MAT_TYPE"].ToString();
                    row["MAT_TYPE_NM"] = row["MAT_TYPE_NM"].ToString();
                }


                for (int i = ds.Tables[0].Rows.Count - 1; i > -1; i--)
                {
                    if (ds.Tables[0].Rows[i]["CHK"].ToString().Equals("N"))
                        ds.Tables[0].Rows.RemoveAt(i);
                }

                ds.Tables[0].Columns.Remove("CHK");

                HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());

                report.Sections.Add("XML", xmlSection); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections

                AxRexpertReportViewer.ShowReport(report);


                // Save Print Check
                for (int i = ds.Tables[0].Columns.Count - 1; i >= 0; i--)
                {
                    if ((ds.Tables[0].Columns[i].ColumnName == "LOTNO" || ds.Tables[0].Columns[i].ColumnName == "BIZCD") == false)
                        ds.Tables[0].Columns.RemoveAt(i);
                }

                ds.Tables[0].Columns.Add("CORCD");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row["CORCD"] = this.UserInfo.CorporationCode;
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

        //private void PrintTag(DataRow pDataRow)
        //{
        //    try
        //    {
        //        //if (string.IsNullOrEmpty(axTextBox2.Text))
        //        //{
        //        //    MsgBox.Show("Box Qty is mandatory!!");
        //        //    return;
        //        //}
        //        //if (string.IsNullOrEmpty(label1.Text))
        //        //{
        //        //    MsgBox.Show("Part Number is mandatory!!");
        //        //    return;
        //        //}
        //        //if (string.IsNullOrEmpty(axTextBox1.Text))
        //        //{
        //        //    MsgBox.Show("Tag Qty is mandatory!!");
        //        //    return;
        //        //}

        //        HEParameterSet set = new HEParameterSet();

        //        //
        //        set.Add("CORCD", Convert.ToString(pDataRow["P_CORCD"]));//this.UserInfo.CorporationCode);
        //        set.Add("BIZCD", Convert.ToString(pDataRow["P_BIZCD"]));//this.UserInfo.BusinessCode);
        //        set.Add("LOTNO", Convert.ToString(pDataRow["P_LOTNO"]));//"");
        //        set.Add("PARTNO", Convert.ToString(pDataRow["P_PARTNO"]));//label1.Text);
        //        set.Add("QTY", Convert.ToString(pDataRow["P_QTY"]));//axTextBox2.Text);
        //        set.Add("MAT_TYPE", Convert.ToString(pDataRow["P_MAT_TYPE"]));//grd01.GetValue(grd01.SelectedRowIndex, "MAT_TYPE").ToString());
        //        set.Add("DOM_IMP_DIV", Convert.ToString(pDataRow["P_DOM_IMP_DIV"]));//grd01.GetValue(grd01.SelectedRowIndex, "DOM_IMP_DIV").ToString());
        //        set.Add("PROD_DATE", Convert.ToString(pDataRow["P_PROD_DATE"]));//"");
        //        set.Add("VENDCD", Convert.ToString(pDataRow["P_VENDCD"]));//grd01.GetValue(grd01.SelectedRowIndex, "VENDCD").ToString());
        //        set.Add("PRINT_QTY", Convert.ToString(pDataRow["P_PRINT_QTY"]));//axTextBox1.Text);
        //        set.Add("USER_ID", Convert.ToString(pDataRow["P_USER_ID"]));//this.UserInfo.UserID);

        //        DataSet source = _WSCOM.ExecuteDataSet("APG_WM20520.SAVE_PRINT", set);
        //        grd02.SetValue(source.Tables[0]);


        //        HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
        //        //if (object.Equals(this.cbo01_PRINT_DIV2.GetValue(),"LARGE"))
        //        //    report.ReportName = "RxRpt/WM20430_R1_L";
        //        //else if (object.Equals(this.cbo01_PRINT_DIV2.GetValue(),"MIDDLE"))
        //        //    report.ReportName = "RxRpt/WM20430_R1";
        //        //else
        //        //    report.ReportName = "RxRpt/WM20430_R1_S";

        //        if (Convert.ToString(pDataRow["P_TAGSIZE"]).Equals("LARGE"))//this.cbo01_PRINT_DIV2.GetValue().ToString().Equals("LARGE"))
        //            if (Convert.ToString(pDataRow["P_TAGPIECE"]).Equals("TWO"))//this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
        //                report.ReportName = "RxRpt/WM20430_R1_L";
        //            else
        //                report.ReportName = "RxRpt/WM20430_R1_L2";
        //        else if (Convert.ToString(pDataRow["P_TAGSIZE"]).Equals("MIDDLE"))//this.cbo01_PRINT_DIV2.GetValue().ToString().Equals("MIDDLE"))
        //            if (Convert.ToString(pDataRow["P_TAGPIECE"]).Equals("TWO"))//this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
        //                report.ReportName = "RxRpt/WM20430_R1";
        //            else
        //                report.ReportName = "RxRpt/WM20430_R12";
        //        else
        //            if (Convert.ToString(pDataRow["P_TAGPIECE"]).Equals("TWO"))//this.cbo01_PRINT_DIV3.GetValue().ToString().Equals("TWO"))
        //                report.ReportName = "RxRpt/WM20430_R1_S";
        //            else
        //                report.ReportName = "RxRpt/WM20430_R1_S2";

        //        //string url = "C:\\Work\\HE_ERM\\HE.ERM\\PD\\UI\\HE.ERM.PD.UI\\";     //XML 경로  

        //        // Main Section (main report parameter set)
        //        HERexSection mainSection = new HERexSection();
        //        mainSection.ReportParameter.Add("PRINT_USER", this.UserInfo.UserID + "(" + this.UserInfo.UserName + ")");
        //        mainSection.ReportParameter.Add("TEST_PARAM1", "파라메터1");
        //        mainSection.ReportParameter.Add("TEST_PARAM2", "파라메터2");
        //        report.Sections.Add("MAIN", mainSection);

        //        DataSet ds = this.grd02.GetValue(AxFlexGrid.FActionType.All,
        //                "CHK",
        //                "BIZCD",
        //                "LOTNO",
        //                "NOTENO",
        //                "PARTNO",
        //                "PARTNM",
        //                "QTY",
        //                "DELI_DATE",
        //                "DELI_CNT",
        //                "ORDERNO",
        //                "VENDCD",
        //                "VENDNM",
        //                "INVOICE_NO",
        //                "CASE_NO",
        //                "INV_STATUS",
        //                "DOM_IMP_DIV",
        //                "WORK_DATE",
        //                "WORK_TIME",
        //                "USER_ID",
        //                "EDI_TAG",
        //                "PROD_DATE",
        //                "MAT_TYPE",
        //                "STOCK_DATE2");

        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {

        //            // LOT입력여부 체크 
        //            row["BIZCD"] = row["BIZCD"].ToString();
        //            row["LOTNO"] = row["LOTNO"].ToString();
        //            row["NOTENO"] = row["NOTENO"].ToString();
        //            row["PARTNO"] = row["PARTNO"].ToString();
        //            row["PARTNM"] = row["PARTNM"].ToString();
        //            row["QTY"] = row["QTY"].ToString();
        //            row["DELI_DATE"] = row["DELI_DATE"].ToString().Length > 0 ? DateTime.Parse(row["DELI_DATE"].ToString()).ToString("dd/MM/yyyy") : "";
        //            row["DELI_CNT"] = row["DELI_CNT"].ToString();
        //            row["ORDERNO"] = "";
        //            row["VENDCD"] = row["VENDCD"].ToString();
        //            //row["VENDNM"] = "TRANSFER"; // row["VENDNM"].ToString();
        //            row["VENDNM"] = row["VENDNM"].ToString();
        //            row["INVOICE_NO"] = row["INVOICE_NO"].ToString();
        //            row["CASE_NO"] = row["CASE_NO"].ToString();
        //            row["INV_STATUS"] = "";
        //            row["DOM_IMP_DIV"] = "";
        //            row["STOCK_DATE2"] = row["WORK_DATE"].ToString().Length > 0 ? DateTime.Parse(row["WORK_DATE"].ToString()).ToString("dd/MM/yyyy").Replace(".", "/").Replace("-", "/") : "";
        //            row["WORK_TIME"] = row["WORK_TIME"].ToString();
        //            row["USER_ID"] = row["USER_ID"].ToString();
        //            row["EDI_TAG"] = row["EDI_TAG"].ToString();
        //            row["PROD_DATE"] = row["PROD_DATE"].ToString().Length > 0 ? DateTime.Parse(row["PROD_DATE"].ToString()).ToString("dd/MM/yyyy") : "";
        //            row["MAT_TYPE"] = "";
        //        }


        //        for (int i = ds.Tables[0].Rows.Count - 1; i > -1; i--)
        //        {
        //            if (ds.Tables[0].Rows[i]["CHK"].ToString().Equals("N"))
        //                ds.Tables[0].Rows.RemoveAt(i);
        //        }

        //        ds.Tables[0].Columns.Remove("CHK");


        //        HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());

        //        report.Sections.Add("XML", xmlSection); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections

        //        AxRexpertReportViewer.ShowReport(report);


        //        // Save Print Check
        //        for (int i = ds.Tables[0].Columns.Count - 1; i >= 0; i--)
        //        {
        //            if ((ds.Tables[0].Columns[i].ColumnName == "LOTNO" || ds.Tables[0].Columns[i].ColumnName == "BIZCD") == false)
        //                ds.Tables[0].Columns.RemoveAt(i);
        //        }

        //        ds.Tables[0].Columns.Add("CORCD");
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            row["CORCD"] = this.UserInfo.CorporationCode;
        //        }
                

        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

        private void grd01_SelChange(object sender, EventArgs e)
        {
            if (grd01.SelectedRowIndex >= 0 && grd01.Focused)
            {
                label1.Text = grd01.GetValue(grd01.SelectedRowIndex, "PARTNO").ToString();
                axTextBox2.Text = "";
                axTextBox1.Text = "1";
            }
        }

        private void btn01_AddPrint_Click(object sender, EventArgs e)
        {
            if (!(grd01.SelectedRowIndex >= 0 && grd01.SelectedRowIndex < grd01.Rows.Count))
            {
                MsgBox.Show("First, You have to select a part");
                return;
            }

            if (string.IsNullOrEmpty(axTextBox2.Text))
            {
                MsgBox.Show("Box Qty is mandatory!!");
                return;
            }
            if (string.IsNullOrEmpty(label1.Text))
            {
                MsgBox.Show("Part Number is mandatory!!");
                return;
            }
            if (string.IsNullOrEmpty(axTextBox1.Text))
            {
                MsgBox.Show("Tag Qty is mandatory!!");
                return;
            }

            //DataTable ds_selected = (DataTable)grd03.GetValue();
            //if (null == ds_selected)
            //{
            //    DataTable source = GetDataSourceSchema("P_CORCD", "P_BIZCD", "P_LOTNO", "P_PARTNO", "P_QTY", "P_MAT_TYPE", "P_DOM_IMP_DIV", "P_PROD_DATE", "P_VENDCD", "P_PRINT_QTY", "P_USER_ID", "P_TAGSIZE", "P_TAGPIECE").Tables[0];
            //    source.Rows.Add(this.UserInfo.CorporationCode
            //        , this.UserInfo.BusinessCode
            //        , ""
            //        , label1.Text
            //        , axTextBox2.Text
            //        , grd01.GetValue(grd01.SelectedRowIndex, "MAT_TYPE").ToString()
            //        , grd01.GetValue(grd01.SelectedRowIndex, "DOM_IMP_DIV").ToString()
            //        , ""
            //        , grd01.GetValue(grd01.SelectedRowIndex, "VENDCD").ToString()
            //        , axTextBox1.Text
            //        , this.UserInfo.UserID
            //        , cbo01_PRINT_DIV2.GetValue().ToString() //Large or small
            //        , cbo01_PRINT_DIV3.GetValue().ToString() //one or two
            //        );
            //    grd03.SetValue(source);
            //    //ds_selected = (DataTable)grd03.GetValue();
            //}
            //else
            {
                C1.Win.C1FlexGrid.Row newRow = grd03.Rows.Add();
                newRow["P_CORCD"] = this.UserInfo.CorporationCode;
                newRow["P_BIZCD"] = this.UserInfo.BusinessCode;
                newRow["P_LOTNO"] = "";
                newRow["P_PARTNO"] = label1.Text;
                newRow["P_QTY"] = axTextBox2.Text;
                newRow["P_MAT_TYPE"] = grd01.GetValue(grd01.SelectedRowIndex, "MAT_TYPE").ToString();
                newRow["P_MAT_TYPE_NM"] = grd01.GetValue(grd01.SelectedRowIndex, "MAT_TYPE_NM").ToString();
                newRow["P_DOM_IMP_DIV"] = grd01.GetValue(grd01.SelectedRowIndex, "DOM_IMP_DIV").ToString();
                newRow["P_PROD_DATE"] = "";
                newRow["P_VENDCD"] = grd01.GetValue(grd01.SelectedRowIndex, "VENDCD").ToString();
                newRow["P_PRINT_QTY"] = axTextBox1.Text;
                newRow["P_TOTAL_QTY"] = Convert.ToString(Convert.ToInt32(axTextBox2.Text) * Convert.ToInt32(axTextBox1.Text));
                newRow["P_USER_ID"] = this.UserInfo.UserID;
                newRow["P_TAGSIZE"] = cbo01_PRINT_DIV2.GetValue().ToString();
                newRow["P_TAGPIECE"] = cbo01_PRINT_DIV3.GetValue().ToString();
                newRow["P_CASE_NO"] = string.IsNullOrEmpty(axTextBox3.Text) ? "" : axTextBox3.Text.Substring(0, 10) + " / " + axTextBox3.Text.Substring(10);
            }
            //grd03.SetValue(ds_selected);
            axTextBox2.Text = "";
            axTextBox1.Text = "1";
            axTextBox3.Text = "";
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            m_strPrintType = "BARCODE";
            Print_SCM_Tag();
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            m_strPrintType = "UBCODE";
            Print_SCM_Tag();
        }

    }
}
