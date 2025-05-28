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

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 초기화 
    /// </summary>
    public partial class TM23200 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";

        private string m_strPrintType = "A4";

        DataSet source_grd = null;

        public TM23200()
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

                #region grd01

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Business", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 350, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "Maker", "MAKER", "MAKER");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 210, "Specification", "SPEC", "SPEC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 102, "RACK", "RACK", "RACK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "Location", "LOC", "LOC");


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
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "PART NAME", "P_PARTNM", "P_PARTNM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY", "P_QTY", "P_QTY");
                
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "PROD_DATE", "P_PROD_DATE", "P_PROD_DATE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "MAKER", "P_MAKER", "P_MAKER");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "USER_ID", "P_USER_ID", "P_USER_ID");
         
                this.grd03.Rows.Fixed = 1;
                #endregion

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));


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
                set.Add("PARTNO", cdx01_PARTNO.GetValue());
                set.Add("PARTNM", "");

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_TM23200.INQUERY", set, "OUT_CURSOR");
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


        private void Print_SCM_Tag()
        {

            if (grd03.Rows.Count <= grd03.Rows.Fixed)
            {
                MsgBox.Show("There is no item to print");
                return;
            }
            DataSet ds = this.GetDataSourceSchema("CORCD"
                                , "BIZCD"
                                , "LOTNO"
                                ,"LSEQ"
                                , "PRT_BATCHNO"
                                , "PARTNO"
                                , "QTY"
                                , "PRINT_QTY"
                                , "UPDATE_ID");

            DataSet ds_selected = grd03.GetValue(AxFlexGrid.FActionType.All
                , "P_CORCD", "P_BIZCD", "P_LOTNO", "P_PARTNO", "P_QTY", "P_PARTNM", "P_MAKER", "P_PROD_DATE");

            string startLOT = GetLOT(UserInfo.CorporationCode, UserInfo.BusinessCode);
            
            for (int row = 0; row < ds_selected.Tables[0].Rows.Count; row++)
            {
                ds.Tables[0].Rows.Add();

                ds.Tables[0].Rows[row]["CORCD"] = ds_selected.Tables[0].Rows[row]["P_CORCD"];
                ds.Tables[0].Rows[row]["BIZCD"] = ds_selected.Tables[0].Rows[row]["P_BIZCD"];
                ds.Tables[0].Rows[row]["LOTNO"] = startLOT;
                ds.Tables[0].Rows[row]["LSEQ"] = row + 1;
                ds.Tables[0].Rows[row]["PRT_BATCHNO"] = startLOT;
                ds.Tables[0].Rows[row]["PARTNO"] = ds_selected.Tables[0].Rows[row]["P_PARTNO"];
                ds.Tables[0].Rows[row]["QTY"] = ds_selected.Tables[0].Rows[row]["P_QTY"];
                ds.Tables[0].Rows[row]["PRINT_QTY"] = ds_selected.Tables[0].Rows.Count;
                ds.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;

                //DataTable exist_source = (DataTable)grd02.GetValue();

                //if (j_cnt != 0) exist_source.Merge(source.Tables[0]);
                //else exist_source = source.Tables[0];
                //grd02.SetValue(exist_source);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                _WSCOM.ExecuteNonQueryTx("APG_TM23200.SAVE_PRINT", ds);
                PrintTag(startLOT);
                grd03.Rows.RemoveRange(grd03.Rows.Fixed, grd03.Rows.Count - grd03.Rows.Fixed);

            }
        }
        private string GetLOT(string corcd, string bizcd)
        {
            HEParameterSet set = new HEParameterSet();

            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            DataTable dt = _WSCOM.ExecuteDataSet("APG_TM23200.GET_LOTNO", set, "OUT_CURSOR").Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt.Rows[0]["LOTNO"].ToString();
            }
            return "";
        }
        private void PrintTag(string batch_lot)
        {
           
            try
            {
                

                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RPT/TM23200_B";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                set.Add("PRT_BATCHNO", batch_lot);
                
                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_TM23200", "INQUERY_PRT"), set, "OUT_CURSOR");
                this.AfterInvokeServer();
                HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
                // ds.WriteXml("D:\\A\\HR10010.XML");
                report.Sections.Add("MAIN", xmlSection);

                AxRexpertReportViewer.ShowReport(report);

            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void grd01_SelChange(object sender, EventArgs e)
        {
            if (grd01.SelectedRowIndex >= 0 && grd01.Focused)
            {
                label1.Text = grd01.GetValue(grd01.SelectedRowIndex, "PARTNO").ToString();
                axTextBox2.Text = "";
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
                C1.Win.C1FlexGrid.Row newRow = grd03.Rows.Add();
                newRow["P_CORCD"] = this.UserInfo.CorporationCode;
                newRow["P_BIZCD"] = this.UserInfo.BusinessCode;
                newRow["P_LOTNO"] = "";
                newRow["P_PARTNO"] = label1.Text;
                newRow["P_PARTNM"] = grd01.GetValue(grd01.Row, "PARTNM").ToString();
                newRow["P_QTY"] = axTextBox2.Text;
                newRow["P_MAKER"] = grd01.GetValue(grd01.Row, "MAKER").ToString();
                newRow["P_USER_ID"] = this.UserInfo.UserID;
            
            axTextBox2.Text = "";
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            m_strPrintType = "BARCODE";
            Print_SCM_Tag();
        }

    }
}
