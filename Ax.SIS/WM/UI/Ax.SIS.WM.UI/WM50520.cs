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
using Ax.SIS.CM.UI;

namespace Ax.SIS.WM.UI
{
    public partial class WM50520 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";

        public WM50520()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel1;
                this.heDockingTab1.LinkPanel = this.panel2;
                this.heDockingTab1.PanelWidth = 272;

                #region [그리드1]
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.SubtotalPosition = SubtotalPositionEnum.AboveData;
                this.grd01.AllowSorting = AllowSortingEnum.MultiColumn;
                this.grd01.AllowMerging = AllowMergingEnum.Free;
                this.grd01.AutoGenerateColumns = false;
                this.grd01.Rows.MinSize = 22;
                this.grd01.AllowMerging = AllowMergingEnum.RestrictCols;
                this.grd01.EnabledActionFlag = false;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "Date", "INV_DATE", "INV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "Order No", "ORDER_NO", "ORDER_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "Vendor Name", "VENDOR", "VENDOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "Partno", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "Qty", "QUANTITY", "QUANTITY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Delivery Type", "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Remarks", "REMARKS", "REMARKS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Prepared By", "PREPARED_BY", "PREPARED_BY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Requested By", "REQUESTED_BY", "REQUESTED_BY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Vehicle No.", "VEHICLE_NO", "VEHICLE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Department", "DEPT", "DEPT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Open Qty.", "OPEN", "OPEN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Closed Qty.", "CLOSED", "CLOSED");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INV_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QUANTITY");
                #endregion

                string strcorcd = this.UserInfo.CorporationCode;

                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(strcorcd).Tables[0], false);
                this.cbo01_CORCD.SetReadOnly(true);
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1();
                this.cdx01_VENDCD.PopupTitle = lbl01_VENDCD.Text;
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                //this.cbo01_JOB_TYPE.SetValue("A10");
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));
                this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

                DataTable combo_source_DELI_TYPE = new DataTable();
                combo_source_DELI_TYPE.Columns.Add("CODE");
                combo_source_DELI_TYPE.Columns.Add("NAME");
                combo_source_DELI_TYPE.Rows.Add("", " ");
                combo_source_DELI_TYPE.Rows.Add("RETURNABLE", "RETURNABLE");
                combo_source_DELI_TYPE.Rows.Add("NON RETURNABLE", "NON RETURNABLE");

                this.cbo01_DELI_TYPE.DataBind(combo_source_DELI_TYPE, false);
                this.cbo01_DELI_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable combo_source_STATUS = new DataTable();
                combo_source_STATUS.Columns.Add("CODE");
                combo_source_STATUS.Columns.Add("NAME");
                combo_source_STATUS.Rows.Add("", " ");
                combo_source_STATUS.Rows.Add("OPEN", "OPEN");
                combo_source_STATUS.Rows.Add("CLOSED", "CLOSED");

                this.cbo01_STATUS.DataBind(combo_source_STATUS, false);
                this.cbo01_STATUS.DropDownStyle = ComboBoxStyle.DropDownList;
                this.panel3.Show();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.panel3.Show();
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("ORDER_NO", this.txt01_ORDERNO.GetValue());
                paramSet.Add("DELI_TYPE", this.cbo01_DELI_TYPE.GetValue());
                //paramSet.Add("STATUS", this.cbo01_STATUS.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM50510.INQUERY_WM50520",paramSet);
                this.AfterInvokeServer();

                this.grd01.SetValue(source);

                this.grd01.Tree.Column = 1;

                this.grd01.Subtotal(AggregateEnum.Count, 0, 1, 3, "[{0}] " + this.GetLabel("TOTAL"));   //전체 합계
                this.grd01.Subtotal(AggregateEnum.Count, 1, 2, 3, "[{0}] " + this.GetLabel("TOTAL")); //합계

                this.grd01.Styles["Subtotal0"].BackColor = Color.Yellow;
                this.grd01.Styles["Subtotal0"].ForeColor = Color.Black;

                this.grd01.Styles["Subtotal1"].BackColor = Color.LightYellow;
                this.grd01.Styles["Subtotal1"].ForeColor = Color.Black;
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

        #endregion

        private void btn01_Reprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txt02_ORDERNO.GetValue().ToString()))
                {
                    MsgBox.Show("Enter a Order to reprint");
                    return;
                }


                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/WM50510_R2";

                // Main Section (main report parameter set)
                HERexSection mainSection = new HERexSection();
                report.Sections.Add("MAIN", mainSection);

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.cbo01_CORCD.GetValue().ToString());
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                set.Add("ORD_NO", this.txt02_ORDERNO.GetValue().ToString());
                DataSet ds = _WSCOM.ExecuteDataSet("APG_WM50510.INQUERY",set);
                ds.Tables[0].Columns.Remove("CHK");

                HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());

                report.Sections.Add("XML", xmlSection); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections

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

                if (this.grd01.GetValue(row, "DELI_TYPE").ToString().Trim() != "RETURNABLE")
                {
                    this.panel3.Hide();
                }
                else
                {
                    this.panel3.Show();
                }

                this.lbl05_ORDERNO.Text = this.grd01.GetValue(row, "ORDER_NO").ToString();
                this.lbl05_PARTNO.Text = this.grd01.GetValue(row, "PARTNO").ToString();
                this.txt01_CLOSED.SetValue(this.grd01.GetValue(row, "CLOSED").ToString());
                this.lbl05_QTY.Text = this.grd01.GetValue(row, "QUANTITY").ToString();

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

        private void btn01_SAVE_Click(object sender, EventArgs e)
        {
            string order_no = this.lbl05_ORDERNO.Text;
            string part_no = this.lbl05_PARTNO.Text;
            string closedQty = this.txt01_CLOSED.GetValue().ToString();
            string actualQty = this.lbl05_QTY.Text;
            int open_qty = 0;

            if (string.IsNullOrEmpty(order_no) || string.IsNullOrEmpty(part_no)) return;

            int closed_qty = 0;
            bool is_ClosedQty = Int32.TryParse(closedQty, out closed_qty);
            if (!is_ClosedQty)
            {
                MessageBox.Show("Enter Valid Number");
            }

            open_qty = Int32.Parse(actualQty) - closed_qty;

            DataSet source = AxFlexGrid.GetDataSourceSchema
                (
                    "ORDER_NO",
                    "PARTNO",
                    "OPEN_QTY",
                    "CLOSED_QTY"
                );
            source.Tables[0].Rows.Add
            (
                order_no,
                part_no,
                open_qty.ToString(),
                closedQty
            );
            
            this.BeforeInvokeServer(true);
            //_WSCOM.Remove(source);
            _WSCOM.ExecuteNonQueryTx("APG_WM50510.SAVE_50520", source);
            this.AfterInvokeServer();

            BtnQuery_Click(null, null);
        }

        private void btn01_CLOSEDC_Click(object sender, EventArgs e)
        {
            string order_no = this.lbl05_ORDERNO.Text;

            DataSet source = AxFlexGrid.GetDataSourceSchema
                (
                    "ORDER_NO"
                );
            source.Tables[0].Rows.Add
            (
                order_no
            );

            this.BeforeInvokeServer(true);
            //_WSCOM.Remove(source);
            _WSCOM.ExecuteNonQueryTx("APG_WM50510.CLOSEDC_50520", source);
            this.AfterInvokeServer();

            BtnQuery_Click(null, null);
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            string order_no = this.txt02_ORDERNO.Text;

            DataSet source = AxFlexGrid.GetDataSourceSchema
                (
                    "ORDER_NO"
                );
            source.Tables[0].Rows.Add
            (
                order_no
            );

            this.BeforeInvokeServer(true);
            //_WSCOM.Remove(source);
            _WSCOM.ExecuteNonQueryTx("APG_WM50510.CANCELDC_50520", source);
            this.AfterInvokeServer();

            BtnQuery_Click(null, null);
        }

        private void txt02_ORDERNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void grd01_Click(object sender, EventArgs e)
        {

        }

        private void cbo01_STATUS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl02_ORDERNO_Click(object sender, EventArgs e)
        {

        }
    }
}
