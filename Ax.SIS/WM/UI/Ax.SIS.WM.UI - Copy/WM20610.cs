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
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;
using Ax.SIS.WM.UI.BarcodePRT;
using System.Collections.Generic;
using System.IO;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 조회 
    /// </summary>
    public partial class WM20610 : AxCommonBaseControl
    {
        #region [Initialize]
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        BarcodePrt m_Prt = new BarcodePrt();
        public WM20610()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {


                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                //제품
                //this.cbo01_PRDT_DIV.DataBind("A0");
                //this.cbo01_PRDT_DIV.SelectedItem = 0;
                this.cdx01_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD"));
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "");
                this.cdx01_LINECD.SetCodePixedLength();





                #endregion

                //this.SetRequired(lbl01_VENDCD);
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);

                #region grd01

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "C/Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "B/Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "INV_STATUS", "INV_STATUS", "INV_STATUS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "PLAN_DATE", "PLAN_DATE", "PLAN_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "LINECD", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 260, "Part name", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "T/QTY", "TRY_QTY", "TRY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "L/QTY", "LOAD_QTY", "LOAD_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TRY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "LOAD_QTY");

                this.grd01.Cols["TRY_QTY"].Format = _IntFormat;
                this.grd01.Cols["LOAD_QTY"].Format = _IntFormat;

                #endregion

                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "C/Code", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "B/Code", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "LOT", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "W/CENTER", "LINECD", "LINECD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 260, "Part name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "L/QTY", "LOAD_QTY", "LOAD_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "S/DATE", "STOCK_DATE", "STOCK_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "I/DATE", "ISSUE_DATE", "ISSUE_DATE");
                

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "LOAD_QTY");

                this.grd02.Cols["LOAD_QTY"].Format = _IntFormat;

                radioButton1.Checked = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [Common Btn Event]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                grd02.InitializeDataSource();
                HEParameterSet set_plan = new HEParameterSet();
                set_plan.Add("CORCD", this.UserInfo.CorporationCode);
                set_plan.Add("BIZCD", cbo01_BIZCD.GetValue());
                set_plan.Add("INV_STATUS", radioButton1.Checked == true ? "I" : "O");
                set_plan.Add("PLAN_DATE", dtp01_STD_DATE.GetDateText());
                set_plan.Add("LINECD", cdx01_LINECD.GetValue());
                set_plan.Add("PARTNO", txt01_PARTNO.Text);


                DataSet source_plan = _WSCOM.ExecuteDataSet("APG_WM20610.INQUERY", set_plan, "OUT_CURSOR");
                grd01.SetValue(source_plan);
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

        #region [Define Method]
        
        private void Query_Cust_Plan_ASSY()
        {
            
            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", this.UserInfo.BusinessCode);
            set1.Add("LINECD", cdx01_LINECD.GetValue());
            set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
            set1.Add("LANG_SET", this.UserInfo.Language);
            set1.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());
            

            this.BeforeInvokeServer(true);

            DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20514.INQUERY_ASSY", set1, "OUT_CURSOR");
            this.grd01.SetValue(source1);
            ShowDataCount(source1);

        }
        #endregion

        #region [Controls Event]
        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", bizcd);

            DataTable source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY_COMBO_WHCD", set1, "OUT_CURSOR").Tables[0];

            //this.cbo01_WHCD.DataBind(source1, false);
        }

        #endregion


        

        private void VisibleDT(bool val)
        {
            lbl01_Date.Visible = val;
            dtp01_STD_DATE.Visible = val;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                VisibleDT(true);
            }
            else if(radioButton1.Checked)
            {
                VisibleDT(false);
            }

        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            int row = grd01.Row;
            if (row >= 1)
            {
                
                string corcd = grd01.GetValue(row, "CORCD").ToString();
                string bizcd = grd01.GetValue(row, "BIZCD").ToString();
                string inv = grd01.GetValue(row, "INV_STATUS").ToString();
                string pdate = grd01.GetValue(row, "PLAN_DATE").ToString();
                string linecd = grd01.GetValue(row, "LINECD").ToString();
                string part = grd01.GetValue(row, "PARTNO").ToString();
                HEParameterSet set_plan = new HEParameterSet();
                set_plan.Add("CORCD", corcd);
                set_plan.Add("BIZCD", bizcd);
                set_plan.Add("INV_STATUS", inv);
                set_plan.Add("PLAN_DATE", pdate);
                set_plan.Add("LINECD", linecd);
                set_plan.Add("PARTNO", part);


                DataSet source_plan = _WSCOM.ExecuteDataSet("APG_WM20610.INQUERY_DET", set_plan, "OUT_CURSOR");
                grd02.SetValue(source_plan);
            }
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            string line = cdx01_LINECD.GetValue().ToString();
            if(string.IsNullOrEmpty(line))
            {
                line = "ALL";
            }
            if (MsgBox.Show("Do you want to reset stock Line:" + line, "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (axTextBox1.GetValue().ToString() == DateTime.Now.ToString("MMdd"))
                {
                    HEParameterSet set_plan = new HEParameterSet();
                    set_plan.Add("CORCD", UserInfo.CorporationCode);
                    set_plan.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set_plan.Add("LINECD", cdx01_LINECD.GetValue());
                    _WSCOM.ExecuteNonQueryTx("APG_WM20610.RESET_STOCK", set_plan);
                    BtnQuery_Click(null, null);
                }
                else
                {
                    MsgBox.Show("Wrong Password!!", "Error");
                    return;
                }
            }
        }
        
        

    }
}

