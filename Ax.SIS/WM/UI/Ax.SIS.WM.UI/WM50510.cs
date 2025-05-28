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
using System.Collections.Generic;

namespace Ax.SIS.WM.UI
{
    public partial class WM50510 : AxCommonBaseControl
    {

        List<string> m_Part = new List<string>();
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";

        public WM50510()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        private string GetTY()
        {
            if (axRadioButton2.Checked == true)
            {
                return "M";
            }
            else if (axRadioButton3.Checked == true)
            {
                return "T";
            }
            return "A";
        }
        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                txt01_PART.Text = "";
                txt01_PARTNM.Text = "";

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1();
                this.cdx01_VENDCD.PopupTitle = lbl01_VENDCD.Text;
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                #region grd01

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Business", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "MAT PART", "CPNO", "CPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 310, "MAT name", "CPNM", "CPNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "ASSY PART no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 310, "ASSY PART name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "Mat type", "TY", "TY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "Vendor", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "Vendor name", "VENDNM", "VENDNM");

                this.grd01.SelectionMode = SelectionModeEnum.Row;

                #endregion

                #region grd03
                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "CORCD", "P_CORCD", "P_LOTNO");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "BIZCD", "P_BIZCD", "P_LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PARTNO", "P_PARTNO", "P_PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PARTNM", "P_PARTNM", "P_PARTNM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY", "P_QTY", "P_QTY");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "VENDCD", "P_VENDCD", "P_VENDCD");
                //this.grd03.SelectionMode = SelectionModeEnum.Row;
                this.grd03.Rows.Fixed = 1;
                //this.grd03.Clear();
                #endregion

                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));



                DataTable combo_source_DELI_TYPE = new DataTable();
                combo_source_DELI_TYPE.Columns.Add("CODE");
                combo_source_DELI_TYPE.Columns.Add("NAME");
                combo_source_DELI_TYPE.Rows.Add("RETURNABLE", "RETURNABLE");
                combo_source_DELI_TYPE.Rows.Add("NON RETURNABLE", "NON RETURNABLE");

                this.cbo01_DELI_TYPE.DataBind(combo_source_DELI_TYPE, false);
                this.cbo01_DELI_TYPE.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cbo01_DELI_TYPE.SetValue("RETURNABLE");

                DataTable combo_source_PART = new DataTable();
                combo_source_PART.Columns.Add("CODE");
                combo_source_PART.Columns.Add("NAME");
                combo_source_PART.Rows.Add("EMP_T", "EMPTY TROLLEY");
                combo_source_PART.Rows.Add("EMP_B", "EMPTY BIN");
                combo_source_PART.Rows.Add("EMP_C", "EMPTY CARTONBOX");

                this.cbo01_Part.DataBind(combo_source_PART, false);
                this.cbo01_Part.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo01_Part.Visible = false;



                #region [그리드1]
                this.grd04.AllowEditing = false;
                this.grd04.Initialize();


                this.grd04.AllowMerging = AllowMergingEnum.RestrictCols;
                this.grd04.EnabledActionFlag = false;
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "Date", "INV_DATE", "INV_DATE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "Order No", "ORDER_NO", "ORDER_NO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "Vendor Name", "VENDOR", "VENDOR");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "Partno", "PARTNO", "PARTNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part Name", "PARTNM", "PARTNM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "Qty", "QUANTITY", "QUANTITY");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Delivery Type", "DELI_TYPE", "DELI_TYPE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Remarks", "REMARKS", "REMARKS");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Prepared By", "PREPARED_BY", "PREPARED_BY");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Requested By", "REQUESTED_BY", "REQUESTED_BY");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Vehicle No.", "VEHICLE_NO", "VEHICLE_NO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Department", "DEPT", "DEPT");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Open Qty.", "OPEN", "OPEN");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Closed Qty.", "CLOSED", "CLOSED");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Date, "INV_DATE");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Int, "QUANTITY");


                this.axComboBox1.DataBind(combo_source_DELI_TYPE, false);
                this.axComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                #endregion

                #endregion


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
                string vendcd = this.cdx01_VENDCD.GetValue().ToString();
                
                if (tabControl1.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(vendcd))
                    {
                        MsgBox.Show("Vendor inforation is mandatory!!", "Error");
                        return;
                    }
                    string bizcd = this.UserInfo.BusinessCode;
                    HEParameterSet set = new HEParameterSet();

                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                    set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                    set.Add("TY", this.GetTY());
                    set.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM.ExecuteDataSet("ZPG_WM50510.INQUIRY_PART_INFO", set, "OUT_CURSOR");
                    grd01.SetValue(source.Tables[0]);

                    txt01_PART.Text = "";
                    txt01_PARTNM.Text = "";
                }
                else
                {
                    string bizcd = this.UserInfo.BusinessCode;
                    HEParameterSet set = new HEParameterSet();

                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("SDATE", this.dte01_SDATE.Value.ToString("yyyy-MM-dd"));
                    set.Add("EDATE", this.dte01_EDATE.Value.ToString("yyyy-MM-dd"));
                    set.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                    set.Add("ORDER_NO", this.axTextBox9.GetValue());

                    set.Add("DELI_TYPE", this.axComboBox1.GetValue());
                    
                    set.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM.ExecuteDataSet("ZPG_WM50510.INQUERY_WM50520", set, "OUT_CURSOR");
                    grd04.SetValue(source.Tables[0]);

                    axTextBox8.SetValue("");
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

        
        private void btn01_AddPrint_Click(object sender, EventArgs e)
        {
            if(grd03.Rows.Count >= 16)
            {
                MsgBox.Show("Only 15 Items allowed per Invoice");
                return;
            }

            if (string.IsNullOrEmpty(axTextBox2.Text))
            {
                MsgBox.Show("Item Qty is mandatory!!");
                return;
            }
           
            if (string.IsNullOrEmpty(txt01_PART.Text))
            {
                MsgBox.Show("Part Number is mandatory!!");
                return;
            }
            string vendcd = this.cdx01_VENDCD.GetValue().ToString();
            if (string.IsNullOrEmpty(vendcd))
            {
                MsgBox.Show("Vendor inforation is mandatory!!", "Error");
                return;
            }
            if (m_Part.Contains(txt01_PART.Text))
            {
                axTextBox2.Text = "";
                txt01_PART.Text = "";
                txt01_PARTNM.Text = "";
                MsgBox.Show("Part Number has to be unique", "Error");
                return;
            }
            else
            {
                m_Part.Add(txt01_PART.Text);
            }
            C1.Win.C1FlexGrid.Row newRow = grd03.Rows.Add();
            newRow["P_CORCD"] = this.UserInfo.CorporationCode;
            newRow["P_BIZCD"] = this.UserInfo.BusinessCode;
            newRow["P_PARTNO"] = txt01_PART.Text;
            newRow["P_PARTNM"] = txt01_PARTNM.Text;
            newRow["P_QTY"] = axTextBox2.Text;
            newRow["P_VENDCD"] = cdx01_VENDCD.GetValue().ToString();
            
            axTextBox2.Text = "";
            txt01_PART.Text = "";
            txt01_PARTNM.Text = "";

        }
        private string GetNext_IV()
        {
            HEParameterSet set = new HEParameterSet();

            set.Add("CORCD", Convert.ToString(UserInfo.CorporationCode));//this.UserInfo.CorporationCode);
            set.Add("BIZCD", Convert.ToString(cbo01_BIZCD.GetValue()));//this.UserInfo.BusinessCode);

            DataTable dt = _WSCOM.ExecuteDataSetTx("ZPG_WM50510.GET_NEXT_IV", set).Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt.Rows[0]["NEXT_IV"].ToString();
            }
            return "";
        }
        private void axButton1_Click(object sender, EventArgs e)
        {
            if (grd03.Rows.Count <= grd03.Rows.Fixed)
            {
                MsgBox.Show("There is no item to print");
                return;
            }
            axTextBox4.SetValue(GetNext_IV());
            
            DataSet ds_selected = grd03.GetValue(AxFlexGrid.FActionType.All
                , "P_CORCD", "P_BIZCD", "P_PARTNO", "P_PARTNM", "P_QTY","P_VENDCD");

            for (int j_cnt = 0; j_cnt < ds_selected.Tables[0].Rows.Count; j_cnt++)
            {
                string f_value = j_cnt == 0 ? "Y" : "N";
                DataRow row = ds_selected.Tables[0].Rows[j_cnt];
                HEParameterSet set = new HEParameterSet();

                set.Add("CORCD", Convert.ToString(row["P_CORCD"]));//this.UserInfo.CorporationCode);
                set.Add("BIZCD", Convert.ToString(row["P_BIZCD"]));//this.UserInfo.BusinessCode);
                set.Add("ORDER_NO", axTextBox4.GetValue());
                set.Add("PARTNO", Convert.ToString(row["P_PARTNO"]));//txt01_PART.Text);
                set.Add("PARTNM", Convert.ToString(row["P_PARTNM"]));//txt01_PARTNM.Text);
                set.Add("QTY", Convert.ToString(row["P_QTY"]));//axTextBox2.Text);
                set.Add("VENDCD", Convert.ToString(row["P_VENDCD"]));//grd01.GetValue(grd01.SelectedRowIndex, "VENDCD").ToString());
                set.Add("DELI_TYPE", this.cbo01_DELI_TYPE.GetValue().ToString());
                set.Add("REMARKS", this.axTextBox3.GetValue().ToString());
                set.Add("CONTACT_PERSON", this.axTextBox1.GetValue().ToString());
                set.Add("PREPARED_BY", this.axTextBox5.GetValue().ToString());
                set.Add("REQUESTED_BY", this.axTextBox1.GetValue().ToString());
                set.Add("VEHICLE_NO", this.axTextBox6.GetValue().ToString());
                set.Add("DEPT", this.axTextBox7.GetValue().ToString());
                set.Add("F_VALUE", f_value);

                _WSCOM.ExecuteNonQueryTx("ZPG_WM50510.SAVE_PRINT", set);
            }

            grd03.Rows.RemoveRange(grd03.Rows.Fixed, grd03.Rows.Count - grd03.Rows.Fixed);
            m_Part.Clear();
            this.cbo01_DELI_TYPE.SetValue("RETURNABLE");
            this.axTextBox1.SetValue("");
            this.axTextBox3.SetValue("");
            this.axTextBox5.SetValue("");
            this.axTextBox6.SetValue("");
            this.axTextBox7.SetValue("");
            PrintTag(axTextBox4.GetValue().ToString());
             
        }

        private void PrintTag(string ordno)
        {
            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/WM50510_R2";

                // Main Section (main report parameter set)
                HERexSection mainSection = new HERexSection();
                report.Sections.Add("MAIN", mainSection);

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("ORD_NO", ordno);
                DataSet ds = _WSCOM.ExecuteDataSet("ZPG_WM50510.INQUERY_PRT", set);

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
            int row = grd01.SelectedRowIndex;
            if (grd01.Rows.Fixed <= row)
            {
                txt01_PART.Text = grd01.GetValue(row, "CPNO").ToString();
                txt01_PARTNM.Text = grd01.GetValue(row, "CPNM").ToString();
            }
        }

        private void grd04_DoubleClick(object sender, EventArgs e)
        {
                int row = grd04.SelectedRowIndex;
                if (grd04.Rows.Fixed <= row)
                {
                    axTextBox8.SetValue(grd04.GetValue(row, "ORDER_NO").ToString());
                    axTextBox14.SetValue(grd04.GetValue(row, "PARTNO").ToString());
                    axTextBox11.SetValue(grd04.GetValue(row, "QUANTITY").ToString());
                }
        }
        private void btn02_SAVE_Click(object sender, EventArgs e)
        {
            string order_no = this.axTextBox8.Text;
           string part_no = this.axTextBox14.Text;
            string closedQty = this.axTextBox11.GetValue().ToString();
            string actualQty = this.axTextBox11.Text;
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
            _WSCOM.ExecuteNonQueryTx("ZPG_WM50510.SAVE_50520", source);
            this.AfterInvokeServer();

            BtnQuery_Click(null, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ordno = axTextBox8.GetValue().ToString();
            if (MsgBox.Show("Do you want to delete [" + ordno + "]", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("ORDER_NO", ordno);
                _WSCOM.ExecuteNonQueryTx("ZPG_WM50510.CANCELDC_50520", set);
                BtnQuery_Click(null, null);
            }
            axTextBox8.SetValue("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ordno = axTextBox8.GetValue().ToString();
            if(string.IsNullOrEmpty(ordno))
            {
                MsgBox.Show("Order no is not selected", "Error");
                return;
            }
            PrintTag(ordno);
        }

        private void axRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (axRadioButton4.Checked)
            {
                txt01_PART.ReadOnly = false;
                txt01_PARTNM.ReadOnly = false;
                axRadioButton2.Checked = false;
            }
            else
            {
                txt01_PART.ReadOnly = true;
                txt01_PARTNM.ReadOnly = true;
            }
        }
        private void axRadioButton2_CheckStateChanged(object sender, EventArgs e)
        {
            if (axRadioButton2.Checked)
            {
                cbo01_Part.Visible = true;
                txt01_PART.Visible = false;
                txt01_PARTNM.Visible = false;
                axRadioButton4.Checked = false;
            }
            else
            {
                cbo01_Part.Visible = false;
                txt01_PART.Visible = true;
                txt01_PARTNM.Visible = true;
            }
        }


        
    }
}
