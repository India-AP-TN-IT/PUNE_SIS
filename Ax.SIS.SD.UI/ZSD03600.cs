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

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZSD03600 : AxCommonBaseControl
    {
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private AxLabel lbl01_BIZCD;
        private AxComboBox cbo01_BIZCD;
        private AxLabel axLabel2;
        private AxDateEdit axDateEdit1;
        private CheckBox checkBox1;
        private AxLabel lbl01_CUSTCD;
        private AxCodeBox cdx01_CUSTCD;
        private AxLabel lbl01_PARTNO;
        private AxTextBox txt01_PARTNO;
        private AxLabel axLabel1;
        private AxTextBox axTextBox1;
        private AxLabel lbl01_VINCD;
        private AxCodeBox cdx01_VINCD;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button1;
        private AxFlexGrid grd01;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private AxCheckBox axCheckBox1;
        private AxButton axButton1;
        private AxTextBox axTextBox2;
        private AxLabel axLabel4;
        private AxFlexGrid grd05;
        private AxButton axButton2;
        private SaveFileDialog sfdExcel;
        private OpenFileDialog ofdExcel;
        private string PACKAGE_NAME = "ZPG_ZSD03600";

        #region [ 초기화 작업 정의 ]

        public ZSD03600()
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
                this.cdx01_CUSTCD.HEPopupHelper = new Ax.SIS.CM.UI.CM22022P1(this.cdx01_CUSTCD);
                this.cdx01_CUSTCD.PopupTitle = this.GetLabel("Customer Code");// "업체 코드";

                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);


                this.grd05.AllowEditing = true;
                this.grd05.AllowAddNew = false;
                this.grd05.Initialize();

               /* this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "SENT", "SENT", "SENT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Customer Name", "CUSTNM", "CUSTNM");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "C/PNO", "PNO", "PNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "UNIT", "UOM", "UOM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "SAP U/PRICE", "SAP_UPRICE", "SAP_UPRICE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "UNIT PRICE", "UPRICE", "UPRICE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "DIFF", "DIFF", "DIFF");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CURRENCY", "CUR", "CUR");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "S/DATE", "ST_DATE", "ST_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "E/DATE", "ED_DATE", "ED_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "HSN", "HSN", "HSN");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PO", "SANO", "SANO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "UPDATE DATE", "UPDATE_DATE", "UPDATE_DATE");*/

                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "Order No", "OrderNo", "OrderNo");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PO NO", "PONO", "PONO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "Part Name", "PARTNM", "PARTNM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "PO Kind", "Pokind", "Pokind");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "PO QTY", "P_QTY", "P_QTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Curr", "Curr", "Curr");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "UNIT PRICE", "UPRICE", "UPRICE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Amount", "PRICE", "PRICE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PO Date ", "PODATE", "PODATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Due Date", "D_DATE", "D_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Delivery Planned Date", "DEV_PLAN", "CUR");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Gate No", "GATE_NO", "GATE_NO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Delay Reason", "D_Reason", "D_Reason");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Status", "Status", "Status");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Vend Pack Fg", "Vend_Pack_Fg", "Vend_Pack_Fg");
                /*this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "UPDATE DATE", "UPDATE_DATE", "UPDATE_DATE");*/



                //this.grd05.Cols["UPRICE"].Format = _DecimalFormat;
                //this.grd05.Cols["SAP_UPRICE"].Format = _DecimalFormat;
                //this.grd05.Cols["DIFF"].Format = _DecimalFormat;




                this.grd01.AllowEditing = true;
                this.grd01.AllowAddNew = false;
                this.grd01.Initialize();

                /*this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Customer Name", "CUSTNM", "CUSTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "C/PNO", "PNO", "PNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "UNIT", "UOM", "UOM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "SAP U/PRICE", "SAP_UPRICE", "SAP_UPRICE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "UNIT PRICE", "UPRICE", "UPRICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "DIFF", "DIFF", "DIFF");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CURRENCY", "CUR", "CUR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "S/DATE", "ST_DATE", "ST_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "E/DATE", "ED_DATE", "ED_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "HSN", "HSN", "HSN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "PO", "SANO", "SANO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "PLANT", "CUST_PLANT", "CUST_PLANT");


                grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ED_DATE");


                this.grd01.Cols["UPRICE"].Format = _DecimalFormat;
                this.grd01.Cols["SAP_UPRICE"].Format = _DecimalFormat;
                this.grd01.Cols["DIFF"].Format = _DecimalFormat;*/

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "Order No", "OrderNo", "OrderNo");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PO NO", "PONO", "PONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "PO Kind", "Pokind", "Pokind");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "PO QTY", "P_QTY", "P_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Currency", "Currency", "Currency");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "UNIT PRICE", "UPRICE", "UPRICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Amount", "PRICE", "PRICE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PO Date ", "PODATE", "PODATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Due Date", "D_DATE", "D_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Delivery Planned Date", "DEV_PLAN", "CUR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Gate No", "GATE_NO", "GATE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Delay Reason", "D_Reason", "D_Reason");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Status", "Status", "Status");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Vend Pack Fg", "Vend_Pack_Fg", "Vend_Pack_Fg");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        private bool CheckCustcd(string custcd)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("CUSTCD", custcd);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "CHK_CUST"), set, "OUT_CURSOR");
                if (Convert.ToInt32(source.Tables[0].Rows[0]["CHK_CNT"].ToString()) >= 1)
                {
                    return true;
                }
                return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
            finally
            {

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

                axTextBox2.Value = FileName;
                // axComboBox1.DataBind(dsSheet.Tables[0], false);

                oleDB.Close();
                this.AfterInvokeServer();

                ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);

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
        private string GetTY()
        {
            if (axCheckBox1.Checked == false)
            {
                return "2";
            }
            return "1";
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
                commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";

                if (cdx01_CUSTCD.GetValue().ToString() == "303408" && axCheckBox1.Checked == false)
                {   //KMI 
                    commandString += " ,'" + cdx01_CUSTCD.GetValue().ToString() + "' as CUSTCD";
                    commandString += " ,[Material] as PNO";
                    commandString += " ,[Price] as UPRICE";
                    commandString += " ,[Currency] as CUR";
                    commandString += " ,[SA No] as SANO";
                    commandString += " ,[HSN/SAC] as HSN";
                    commandString += " ,[Valid From] as ST_DATE";
                    commandString += " ,[Valid To] as ED_DATE";
                    commandString += " ,[Plant] as CUST_PLANT";
                    commandString += " ,'' as UOM";
                    commandString += " FROM [" + SheetName + "]";
                }
                else
                {   //MOBIS & GLOVIS 
                    commandString += " ,[Customer material info Record] as PNO";
                    commandString += " ,[Material Code] as PARTNO";
                    commandString += " ,[Sales Price] as UPRICE";
                    commandString += " ,[Currency] as CUR";
                    commandString += " ,[Valid From] as ST_DATE";
                    commandString += " ,[Valid To] as ED_DATE";
                    commandString += " ,[Customer Code] as CUSTCD";
                    commandString += " ,[Unit] as UOM";
                    commandString += " FROM [" + SheetName + "]";
                }

                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                oleDB.Close();

                this.grd05.SetValue(ds);
                for (int i = 1; i < this.grd05.Rows.Count; i++)
                {
                    this.grd05[i, 0] = AxFlexGrid.FLAG_N;
                }

                if (ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 0)
                {
                    DataSave();
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
        private void DataSave()
        {
            DataRow dr = null;
            try
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                DataSet source = this.grd05.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "CUSTCD", "PNO", "PARTNO"
                    , "CUR", "UPRICE", "HSN", "SANO", "ST_DATE", "ED_DATE", "CUST_PLANT", "UOM", "TY");
                if (source.Tables.Count > 0 && source.Tables[0].Rows.Count > 0)
                {
                    for (int row = 0; row < source.Tables[0].Rows.Count; row++)
                    {
                        source.Tables[0].Rows[row]["TY"] = GetTY();
                    }
                }
                if (axCheckBox1.Checked == false)
                {
                    if (cdx01_CUSTCD.GetValue().ToString() != "303408" && source.Tables.Count > 0)
                    {
                        if (source.Tables[0].Rows[0]["CUSTCD"].ToString() != cdx01_CUSTCD.GetValue().ToString())
                        {
                            MsgBox.Show("Wrong Customer Code", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                            return;
                        }
                    }
                }

                if (source.Tables[0].Rows.Count > 0)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("CUSTCD", cdx01_CUSTCD.GetValue().ToString());
                    set.Add("CUST_PLANT", source.Tables[0].Rows[0]["CUST_PLANT"].ToString());
                    set.Add("TY", GetTY());
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DEL_DATA"), set);


                    dr = source.Tables[0].Rows[0];


                    this.BeforeInvokeServer(true);

                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_DATA"), source);


                    this.AfterInvokeServer();

                    this.BtnQuery_Click(null, null);
                }
                else
                {
                    MsgBox.Show("There is no data to save!", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
                /*
                if (dr == null)
                {
                    MsgBox.Show(ex.Message);
                    
                }
                else
                {
                    MsgBox.Show("ST_DATE=" + dr["ST_DATE"].ToString() + ", ED_DATE=" + dr["ED_DATE"].ToString());
                }
                     */
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd01.Rows.Count <= 1)
                {
                    MsgBox.Show("There is no data to save!!", "Error", MessageBoxButtons.OK);
                    return;
                }
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "CUSTCD", "PARTNO", "PNO", "ST_DATE", "ED_DATE", "UPRICE", "TY", "HSN", "SANO", "CUST_PLANT");

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_UNITPRICE"), source);


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show(" 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
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
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("STD_DATE", axDateEdit1.GetDateText());
                set.Add("CUSTCD", cdx01_CUSTCD.GetValue());
                set.Add("VINCD", cdx01_VINCD.GetValue());
                set.Add("PARTNO", txt01_PARTNO.GetValue());
                set.Add("PNO", axTextBox1.GetValue());
                set.Add("DIFF", checkBox1.Checked ? "Y" : "N");
                set.Add("TY", GetTY());
                // set.Add("TAXID", axTextBox1.GetValue());

                this.BeforeInvokeServer(true);
                if (tabControl1.SelectedIndex == 1)
                {
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_DATA"), set, "OUT_CURSOR");
                    grd05.SetValue(source);
                }
                else if (tabControl1.SelectedIndex == 0)
                {
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_DATA_1000"), set, "OUT_CURSOR");
                    grd01.SetValue(source);
                }
                this.AfterInvokeServer();

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
        private void ProcData()
        {
            string bizcd = cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("STD_DATE", axDateEdit1.GetDateText());
            set.Add("CUSTCD", cdx01_CUSTCD.GetValue().ToString());
            set.Add("TY", GetTY());
            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_SYNC_UP"), set);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZSD03600));
            this.lbl01_BIZCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cbo01_BIZCD = new Ax.DEV.Utility.Controls.AxComboBox();
            this.axLabel2 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axDateEdit1 = new Ax.DEV.Utility.Controls.AxDateEdit();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbl01_CUSTCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_CUSTCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.lbl01_PARTNO = new Ax.DEV.Utility.Controls.AxLabel();
            this.txt01_PARTNO = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel1 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axTextBox1 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.lbl01_VINCD = new Ax.DEV.Utility.Controls.AxLabel();
            this.cdx01_VINCD = new Ax.DEV.Utility.Controls.AxCodeBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.grd01 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axCheckBox1 = new Ax.DEV.Utility.Controls.AxCheckBox();
            this.axButton1 = new Ax.DEV.Utility.Controls.AxButton();
            this.axTextBox2 = new Ax.DEV.Utility.Controls.AxTextBox();
            this.axLabel4 = new Ax.DEV.Utility.Controls.AxLabel();
            this.axButton2 = new Ax.DEV.Utility.Controls.AxButton();
            this.grd05 = new Ax.DEV.Utility.Controls.AxFlexGrid();
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CUSTCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl01_BIZCD
            // 
            this.lbl01_BIZCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_BIZCD.AutoFontSizeMinValue = 9F;
            this.lbl01_BIZCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_BIZCD.Location = new System.Drawing.Point(39, 66);
            this.lbl01_BIZCD.Name = "lbl01_BIZCD";
            this.lbl01_BIZCD.Size = new System.Drawing.Size(87, 21);
            this.lbl01_BIZCD.TabIndex = 115;
            this.lbl01_BIZCD.Tag = null;
            this.lbl01_BIZCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_BIZCD.Value = "Plant";
            // 
            // cbo01_BIZCD
            // 
            this.cbo01_BIZCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo01_BIZCD.FormattingEnabled = true;
            this.cbo01_BIZCD.Location = new System.Drawing.Point(132, 66);
            this.cbo01_BIZCD.Name = "cbo01_BIZCD";
            this.cbo01_BIZCD.Size = new System.Drawing.Size(123, 23);
            this.cbo01_BIZCD.TabIndex = 116;
            // 
            // axLabel2
            // 
            this.axLabel2.AutoFontSizeMaxValue = 9F;
            this.axLabel2.AutoFontSizeMinValue = 9F;
            this.axLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel2.Location = new System.Drawing.Point(273, 68);
            this.axLabel2.Name = "axLabel2";
            this.axLabel2.Size = new System.Drawing.Size(140, 21);
            this.axLabel2.TabIndex = 119;
            this.axLabel2.Tag = null;
            this.axLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel2.Value = "TARGET DATE";
            // 
            // axDateEdit1
            // 
            this.axDateEdit1.CustomFormat = "yyyy-MM-dd";
            this.axDateEdit1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.axDateEdit1.Location = new System.Drawing.Point(440, 68);
            this.axDateEdit1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.axDateEdit1.Name = "axDateEdit1";
            this.axDateEdit1.OriginalFormat = "";
            this.axDateEdit1.Size = new System.Drawing.Size(100, 21);
            this.axDateEdit1.TabIndex = 120;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(546, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 19);
            this.checkBox1.TabIndex = 143;
            this.checkBox1.Text = "Only Different Price";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lbl01_CUSTCD
            // 
            this.lbl01_CUSTCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_CUSTCD.AutoFontSizeMinValue = 9F;
            this.lbl01_CUSTCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_CUSTCD.Location = new System.Drawing.Point(39, 101);
            this.lbl01_CUSTCD.Name = "lbl01_CUSTCD";
            this.lbl01_CUSTCD.Size = new System.Drawing.Size(261, 21);
            this.lbl01_CUSTCD.TabIndex = 144;
            this.lbl01_CUSTCD.Tag = null;
            this.lbl01_CUSTCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_CUSTCD.Value = "Customer Code";
            // 
            // cdx01_CUSTCD
            // 
            this.cdx01_CUSTCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_CUSTCD.CodeParameterName = "CODE";
            this.cdx01_CUSTCD.CodeTextBoxReadOnly = false;
            this.cdx01_CUSTCD.CodeTextBoxVisible = true;
            this.cdx01_CUSTCD.CodeTextBoxWidth = 60;
            this.cdx01_CUSTCD.HEPopupHelper = null;
            this.cdx01_CUSTCD.Location = new System.Drawing.Point(306, 101);
            this.cdx01_CUSTCD.Name = "cdx01_CUSTCD";
            this.cdx01_CUSTCD.NameParameterName = "NAME";
            this.cdx01_CUSTCD.NameTextBoxReadOnly = false;
            this.cdx01_CUSTCD.NameTextBoxVisible = true;
            this.cdx01_CUSTCD.PopupButtonReadOnly = false;
            this.cdx01_CUSTCD.PopupTitle = "";
            this.cdx01_CUSTCD.PrefixCode = "";
            this.cdx01_CUSTCD.Size = new System.Drawing.Size(379, 21);
            this.cdx01_CUSTCD.TabIndex = 145;
            this.cdx01_CUSTCD.Tag = null;
            // 
            // lbl01_PARTNO
            // 
            this.lbl01_PARTNO.AutoFontSizeMaxValue = 9F;
            this.lbl01_PARTNO.AutoFontSizeMinValue = 9F;
            this.lbl01_PARTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_PARTNO.Location = new System.Drawing.Point(39, 132);
            this.lbl01_PARTNO.Name = "lbl01_PARTNO";
            this.lbl01_PARTNO.Size = new System.Drawing.Size(261, 19);
            this.lbl01_PARTNO.TabIndex = 146;
            this.lbl01_PARTNO.Tag = null;
            this.lbl01_PARTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_PARTNO.Value = "Part No ";
            // 
            // txt01_PARTNO
            // 
            this.txt01_PARTNO.Location = new System.Drawing.Point(306, 132);
            this.txt01_PARTNO.Name = "txt01_PARTNO";
            this.txt01_PARTNO.Size = new System.Drawing.Size(261, 21);
            this.txt01_PARTNO.TabIndex = 147;
            this.txt01_PARTNO.Tag = null;
            // 
            // axLabel1
            // 
            this.axLabel1.AutoFontSizeMaxValue = 9F;
            this.axLabel1.AutoFontSizeMinValue = 9F;
            this.axLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel1.Location = new System.Drawing.Point(39, 164);
            this.axLabel1.Name = "axLabel1";
            this.axLabel1.Size = new System.Drawing.Size(261, 21);
            this.axLabel1.TabIndex = 148;
            this.axLabel1.Tag = null;
            this.axLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel1.Value = "Customer\'s PART NO. ";
            this.axLabel1.Click += new System.EventHandler(this.axLabel1_Click);
            // 
            // axTextBox1
            // 
            this.axTextBox1.Location = new System.Drawing.Point(306, 164);
            this.axTextBox1.Name = "axTextBox1";
            this.axTextBox1.Size = new System.Drawing.Size(261, 21);
            this.axTextBox1.TabIndex = 149;
            this.axTextBox1.Tag = null;
            // 
            // lbl01_VINCD
            // 
            this.lbl01_VINCD.AutoFontSizeMaxValue = 9F;
            this.lbl01_VINCD.AutoFontSizeMinValue = 9F;
            this.lbl01_VINCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lbl01_VINCD.Location = new System.Drawing.Point(585, 164);
            this.lbl01_VINCD.Name = "lbl01_VINCD";
            this.lbl01_VINCD.Size = new System.Drawing.Size(100, 21);
            this.lbl01_VINCD.TabIndex = 150;
            this.lbl01_VINCD.Tag = null;
            this.lbl01_VINCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl01_VINCD.Value = "CAR";
            // 
            // cdx01_VINCD
            // 
            this.cdx01_VINCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cdx01_VINCD.CodeParameterName = "CODE";
            this.cdx01_VINCD.CodeTextBoxReadOnly = false;
            this.cdx01_VINCD.CodeTextBoxVisible = true;
            this.cdx01_VINCD.CodeTextBoxWidth = 40;
            this.cdx01_VINCD.HEPopupHelper = null;
            this.cdx01_VINCD.Location = new System.Drawing.Point(691, 164);
            this.cdx01_VINCD.Name = "cdx01_VINCD";
            this.cdx01_VINCD.NameParameterName = "NAME";
            this.cdx01_VINCD.NameTextBoxReadOnly = false;
            this.cdx01_VINCD.NameTextBoxVisible = true;
            this.cdx01_VINCD.PopupButtonReadOnly = false;
            this.cdx01_VINCD.PopupTitle = "";
            this.cdx01_VINCD.PrefixCode = "";
            this.cdx01_VINCD.Size = new System.Drawing.Size(224, 21);
            this.cdx01_VINCD.TabIndex = 151;
            this.cdx01_VINCD.Tag = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 191);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1018, 518);
            this.tabControl1.TabIndex = 152;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.grd01);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1010, 490);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Inquery/Edit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(747, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 23);
            this.button1.TabIndex = 127;
            this.button1.Text = "Excel uploaded data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grd01
            // 
            this.grd01.AllowHeaderMerging = false;
            this.grd01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd01.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd01.EnabledActionFlag = true;
            this.grd01.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd01.LastRowAdd = false;
            this.grd01.Location = new System.Drawing.Point(8, 30);
            this.grd01.Name = "grd01";
            this.grd01.OriginalFormat = null;
            this.grd01.PopMenuVisible = true;
            this.grd01.Rows.DefaultSize = 18;
            this.grd01.Size = new System.Drawing.Size(993, 453);
            this.grd01.StyleInfo = resources.GetString("grd01.StyleInfo");
            this.grd01.TabIndex = 126;
            this.grd01.UseCustomHighlight = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.axButton2);
            this.tabPage2.Controls.Add(this.grd05);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1010, 490);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Upload";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.axCheckBox1);
            this.groupBox1.Controls.Add(this.axButton1);
            this.groupBox1.Controls.Add(this.axTextBox2);
            this.groupBox1.Controls.Add(this.axLabel4);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 47);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel Upload";
            // 
            // axCheckBox1
            // 
            this.axCheckBox1.AutoSize = true;
            this.axCheckBox1.Checked = true;
            this.axCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.axCheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.axCheckBox1.ForeColor = System.Drawing.Color.Red;
            this.axCheckBox1.Location = new System.Drawing.Point(14, 22);
            this.axCheckBox1.Name = "axCheckBox1";
            this.axCheckBox1.Size = new System.Drawing.Size(110, 19);
            this.axCheckBox1.TabIndex = 129;
            this.axCheckBox1.Text = "Excel Format";
            this.axCheckBox1.UseVisualStyleBackColor = true;
            // 
            // axButton1
            // 
            this.axButton1.Location = new System.Drawing.Point(670, 17);
            this.axButton1.Name = "axButton1";
            this.axButton1.Size = new System.Drawing.Size(140, 21);
            this.axButton1.TabIndex = 128;
            this.axButton1.Text = "Excel File Load";
            this.axButton1.UseVisualStyleBackColor = true;
            this.axButton1.Click += new System.EventHandler(this.axButton1_Click);
            // 
            // axTextBox2
            // 
            this.axTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.axTextBox2.Location = new System.Drawing.Point(312, 17);
            this.axTextBox2.Name = "axTextBox2";
            this.axTextBox2.ReadOnly = true;
            this.axTextBox2.Size = new System.Drawing.Size(338, 21);
            this.axTextBox2.TabIndex = 127;
            this.axTextBox2.Tag = null;
            // 
            // axLabel4
            // 
            this.axLabel4.AutoFontSizeMaxValue = 9F;
            this.axLabel4.AutoFontSizeMinValue = 9F;
            this.axLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.axLabel4.Location = new System.Drawing.Point(192, 17);
            this.axLabel4.Name = "axLabel4";
            this.axLabel4.Size = new System.Drawing.Size(114, 21);
            this.axLabel4.TabIndex = 126;
            this.axLabel4.Tag = null;
            this.axLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.axLabel4.Value = "Exdel File";
            // 
            // axButton2
            // 
            this.axButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.axButton2.BackColor = System.Drawing.Color.Lime;
            this.axButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.axButton2.Location = new System.Drawing.Point(870, 8);
            this.axButton2.Name = "axButton2";
            this.axButton2.Size = new System.Drawing.Size(133, 44);
            this.axButton2.TabIndex = 143;
            this.axButton2.Text = "Print";
            this.axButton2.UseVisualStyleBackColor = false;
            this.axButton2.Click += new System.EventHandler(this.axButton2_Click);
            // 
            // grd05
            // 
            this.grd05.AllowHeaderMerging = false;
            this.grd05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd05.ColumnInfo = "0,0,0,0,0,0,Columns:";
            this.grd05.EnabledActionFlag = true;
            this.grd05.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            this.grd05.LastRowAdd = false;
            this.grd05.Location = new System.Drawing.Point(7, 73);
            this.grd05.Name = "grd05";
            this.grd05.OriginalFormat = null;
            this.grd05.PopMenuVisible = true;
            this.grd05.Rows.DefaultSize = 18;
            this.grd05.Size = new System.Drawing.Size(996, 409);
            this.grd05.StyleInfo = resources.GetString("grd05.StyleInfo");
            this.grd05.TabIndex = 125;
            this.grd05.UseCustomHighlight = true;
            this.grd05.Click += new System.EventHandler(this.grd05_Click);
            // 
            // ofdExcel
            // 
            this.ofdExcel.Filter = "Excel|*.xlsx|Excel|*.xls";
            // 
            // ZSD03600
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cdx01_VINCD);
            this.Controls.Add(this.lbl01_VINCD);
            this.Controls.Add(this.axTextBox1);
            this.Controls.Add(this.axLabel1);
            this.Controls.Add(this.txt01_PARTNO);
            this.Controls.Add(this.lbl01_PARTNO);
            this.Controls.Add(this.cdx01_CUSTCD);
            this.Controls.Add(this.lbl01_CUSTCD);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.axDateEdit1);
            this.Controls.Add(this.axLabel2);
            this.Controls.Add(this.cbo01_BIZCD);
            this.Controls.Add(this.lbl01_BIZCD);
            this.Name = "ZSD03600";
            this.Controls.SetChildIndex(this.lbl01_BIZCD, 0);
            this.Controls.SetChildIndex(this.cbo01_BIZCD, 0);
            this.Controls.SetChildIndex(this.axLabel2, 0);
            this.Controls.SetChildIndex(this.axDateEdit1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.lbl01_CUSTCD, 0);
            this.Controls.SetChildIndex(this.cdx01_CUSTCD, 0);
            this.Controls.SetChildIndex(this.lbl01_PARTNO, 0);
            this.Controls.SetChildIndex(this.txt01_PARTNO, 0);
            this.Controls.SetChildIndex(this.axLabel1, 0);
            this.Controls.SetChildIndex(this.axTextBox1, 0);
            this.Controls.SetChildIndex(this.lbl01_VINCD, 0);
            this.Controls.SetChildIndex(this.cdx01_VINCD, 0);
            this.Controls.SetChildIndex(this._buttonsControl, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_BIZCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_CUSTCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt01_PARTNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl01_VINCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdx01_VINCD)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd01)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd05)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void axButton2_Click(object sender, EventArgs e)
        {

        }

        private void grd05_Click(object sender, EventArgs e)
        {

        }

        private void axButton1_Click(object sender, EventArgs e)
        {

        }

        private void axLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }




    }
}

