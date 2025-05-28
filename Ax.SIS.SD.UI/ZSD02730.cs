#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using System.Data.OleDb;
using System.Text;
using System.Collections.Generic;
using HE.Framework.Core.Report;

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZSD02730 : AxCommonBaseControl
    {
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02730";

        #region [ 초기화 작업 정의 ]

        public ZSD02730()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
                SetCustPLANT();
                cbl01_CustPLANT.SetValue("GVIA");
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);


                this.grd05.AllowEditing = true;
                this.grd05.AllowAddNew = false;
                this.grd05.Initialize();

                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");
                
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "PLANT", "CUST_PLANT", "CUST_PLANT");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "O/NO", "ORDERNO", "ORDERNO");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "PO", "PONO", "PONO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PO/QTY", "POQTY", "POQTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PLAN", "PLAN_QTY", "PLAN_QTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "T/QTY", "STUFF_QTY", "STUFF_QTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "SCAN", "SCAN_QTY", "SCAN_QTY");

                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "PNO", "PNO", "PNO");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "COMPANY", "COM_NAME", "COM_NAME");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "VENDOR CODE", "VCODE", "VCODE");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "PLAN/DATE", "PLAN_DATE", "PLAN_DATE");


                this.grd02.AllowEditing = false;
                this.grd02.AllowAddNew = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "O/NO", "ORDERNO", "ORDERNO");
                
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PO/QTY", "POQTY", "POQTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "SCAN", "QTY", "QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "RMAIN", "RQTY", "RQTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "DUE/DATE", "DUE_DATE", "DUE_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PO/DATE", "PO_DATE", "PO_DATE");

                this.grd03.AllowEditing = false;
                this.grd03.AllowAddNew = false;
                this.grd03.Initialize();

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 85, "LOT NO", "LOTNO", "LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "MAT LOT", "PART_LOTNO", "PART_LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 45, "SCAN", "QTY", "QTY");                
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "SCAN/DATE", "SCAN_DATE", "SCAN_DATE");
                




            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        
        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = null;

                source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02710.INQUERY_PLANT", set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

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
                if (tabControl1.SelectedIndex == 0)
                {
                    string bizcd = cbo01_BIZCD.GetValue().ToString();

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("PLAN_DATE", axDateEdit1.GetDateText());
                    set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                    set.Add("VINCD", cdx01_VINCD.GetValue());
                    set.Add("PARTNO", txt01_PARTNO.GetValue());
                    set.Add("ORDERNO", axTextBox1.GetValue());

                    this.BeforeInvokeServer(true);

                    DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02730.GET_DATA", set, "OUT_CURSOR");
                    grd05.SetValue(source);
                    this.AfterInvokeServer();
                }
                else if(tabControl1.SelectedIndex == 1)
                {
                    string bizcd = cbo01_BIZCD.GetValue().ToString();

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("PLAN_DATE", axDateEdit1.GetDateText());
                    set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                    set.Add("VINCD", cdx01_VINCD.GetValue());
                    set.Add("PARTNO", txt01_PARTNO.GetValue());
                    set.Add("ORDERNO", axTextBox1.GetValue());
                    set.Add("LOTNO", Txt_LOTNO.GetValue());

                    this.BeforeInvokeServer(true);

                    DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02730.GET_HIST", set, "OUT_CURSOR");
                    grd02.SetValue(source);
                    this.AfterInvokeServer();
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

        private void grd05_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd05.SelectedRowIndex;
            if (row >= 1)
            {
                Txt_ORDERNO.SetValue(grd05.GetValue(row, "ORDERNO"));
                Txt_PARTNO.SetValue(grd05.GetValue(row, "PARTNO"));
                Txt_STUFF_QTY.SetValue(grd05.GetValue(row, "STUFF_QTY"));
                Txt_PLAN_QTY.SetValue(grd05.GetValue(row, "PLAN_QTY"));
            }
        }
        private int DivRemain(int tot, int trolley)
        {
            int divVal = tot / trolley;
            if ((tot % trolley) == 0)
            {
                return 0;
            }
            else
            {
                return tot - (trolley * divVal);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(MsgBox.Show("Do you want to make barcode for this order?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int row = grd05.SelectedRowIndex;
                string CORCD = grd05.GetValue(row, "CORCD").ToString();
                string BIZCD = grd05.GetValue(row, "BIZCD").ToString();
                string ORDERNO = grd05.GetValue(row, "ORDERNO").ToString();
                string STUFF_QTY = Txt_STUFF_QTY.GetValue().ToString();
                string PLAN_QTY = grd05.GetValue(row, "PLAN_QTY").ToString();
                string PARTNO = grd05.GetValue(row, "PARTNO").ToString();
                string PARTNM = grd05.GetValue(row, "PARTNM").ToString();
                string CUST_PLANT = grd05.GetValue(row, "CUST_PLANT").ToString();
                string VINCD = grd05.GetValue(row, "VINCD").ToString();
                string PLAN_DATE = grd05.GetValue(row, "PLAN_DATE").ToString();
                string VCODE = grd05.GetValue(row, "VCODE").ToString();
                string COM_NAME = grd05.GetValue(row, "COM_NAME").ToString();
                string PNO = grd05.GetValue(row, "PNO").ToString();
                Dictionary<string, Dictionary<string, string>> param = new Dictionary<string, Dictionary<string, string>>();
                int pQTY = Convert.ToInt32(PLAN_QTY);
                int tQTY = Convert.ToInt32(STUFF_QTY);
                int remain = DivRemain(pQTY, tQTY);
                int divVal = pQTY / tQTY;
                if (remain>0)
                {
                    divVal = divVal + 1;
                }
                for (int i = 0; i < divVal;i++ )
                {
                    string lotno = GetLOT(CORCD, BIZCD);
                    if(string.IsNullOrEmpty(lotno))
                    {
                        MsgBox.Show("LOT Error!!", "Error");
                        return;
                    }
                    string binSEQ = (i + 1).ToString() + "/" + (divVal).ToString();
                    
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("CORCD", CORCD);
                    data.Add("BIZCD", BIZCD);
                    data.Add("ORDERNO", ORDERNO);
                    data.Add("STUFF_QTY", STUFF_QTY);
                    data.Add("PLAN_QTY", PLAN_QTY);
                    data.Add("PARTNO", PARTNO);
                    data.Add("PARTNM", PARTNM);
                    data.Add("CUST_PLANT", CUST_PLANT);
                    data.Add("VINCD", VINCD);
                    data.Add("PLAN_DATE", PLAN_DATE);
                    data.Add("VCODE", VCODE);
                    data.Add("COM_NAME", COM_NAME);
                    data.Add("QTY", STUFF_QTY);
                    data.Add("PNO", PNO);
                    if(i==divVal-1 && remain !=0)
                    {
                        data["QTY"] =  remain.ToString();
                    }
                    
                    data.Add("LOTNO", lotno);
                    data.Add("BIN_SEQ", binSEQ);
                    param.Add(lotno, data);
                    if (SaveData(data) == false)
                    {
                        MsgBox.Show("SAVE Error!!", "Error");
                        return;
                    }
                }
                Print_BoxTag(param);
            }
        }
        private bool SaveData(Dictionary<string, string> param)
        {
            try
            {                
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", param["CORCD"]);
                set.Add("BIZCD", param["BIZCD"]);
                set.Add("CUST_PLANT", param["CUST_PLANT"]);
                set.Add("PARTNO", param["PARTNO"]);
                set.Add("LOTNO", param["LOTNO"]);
                set.Add("ORDERNO", param["ORDERNO"]);
                set.Add("QTY", param["QTY"]);
                set.Add("STUFF_QTY", param["STUFF_QTY"]);
                set.Add("BIN_SEQ", param["BIN_SEQ"]);
                set.Add("UPDATE_ID", UserInfo.UserID);

                _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02730.SAVE_DATA", set);
                return true;
            }
            catch(Exception eLog)
            {
                return false;
            }
            
        }
        private string GetLOT(string corcd, string bizcd)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);

            DataTable dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02730.GET_LOTNO", set, "OUT_CURSOR").Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt.Rows[0]["LOTNO"].ToString();
            }
            return "";
            
        }
        private void Print_BoxTag(Dictionary<string, Dictionary<string, string>> param)
        {
            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RxRpt/ZSD02730";

                string[] cols = new string[]{"PARTNO","PARTNM","QTY","ORDERNO","BARCODE","COM_NAME","VCODE","VINCD","PLAN_DATE","BIN_SEQ","LOTNO"};
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                for(int col=0;col<cols.Length;col++)
                {
                    dt.Columns.Add(new DataColumn(cols[col]));
                }
                foreach(KeyValuePair<string, Dictionary<string, string>> pair in param)
                {
                    DataRow dr = dt.NewRow();
                    dr["PARTNO"] = pair.Value["PNO"];   //Printing Paper needs to display customer's partno.
                    dr["PARTNM"] = pair.Value["PARTNM"];
                    dr["QTY"] = pair.Value["QTY"];
                    dr["ORDERNO"] = pair.Value["ORDERNO"];
                    dr["BARCODE"] = pair.Value["LOTNO"];
                    dr["LOTNO"] = pair.Value["LOTNO"];
                    dr["BIN_SEQ"] = pair.Value["BIN_SEQ"];
                    dr["VINCD"] = pair.Value["VINCD"];
                    dr["PLAN_DATE"] = pair.Value["PLAN_DATE"];
                    dr["VCODE"] = pair.Value["VCODE"];
                    dr["COM_NAME"] = pair.Value["COM_NAME"];
                    
                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
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

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd02.SelectedRowIndex;

            if(row>=1)
            {
                string corcd = grd02.GetValue(row, "CORCD").ToString();
                string bizcd = grd02.GetValue(row, "BIZCD").ToString();
                string orderno = grd02.GetValue(row, "ORDERNO").ToString();
                string partno = grd02.GetValue(row, "PARTNO").ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", corcd);
                set.Add("BIZCD", bizcd);
                set.Add("ORDERNO", orderno);
                set.Add("PARTNO", partno);

                DataSet ds = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02730.GET_DET", set, "OUT_CURSOR");
                grd03.SetValue(ds);
            }
        }

    }
}

