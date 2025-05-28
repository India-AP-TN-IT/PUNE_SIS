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
    public partial class ZSD02120 : AxCommonBaseControl
    {
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02120";

        #region [ 초기화 작업 정의 ]

        public ZSD02120()
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

                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
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
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "UPDATE DATE", "UPDATE_DATE", "UPDATE_DATE");


                

                this.grd05.Cols["UPRICE"].Format = _DecimalFormat;
                this.grd05.Cols["SAP_UPRICE"].Format = _DecimalFormat;
                this.grd05.Cols["DIFF"].Format = _DecimalFormat;




                this.grd01.AllowEditing = true;
                this.grd01.AllowAddNew = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
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
                this.grd01.Cols["DIFF"].Format = _DecimalFormat;


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
                if(Convert.ToInt32(source.Tables[0].Rows[0]["CHK_CNT"].ToString())>=1)
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
        private void ExcelLoad(object sender, EventArgs e)
        {
            try
            {
                if (axCheckBox1.Checked == false)
                {
                    if (CheckCustcd(cdx01_CUSTCD.GetValue().ToString()) == false)
                    {
                        MsgBox.Show("Customer must be selected.", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                        return;
                    }
                }
                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    return;
                }

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
            if(axCheckBox1.Checked == false)
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
                
                if(ds.Tables.Count>0 & ds.Tables[0].Rows.Count>0)
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
                    , "CUR", "UPRICE", "HSN", "SANO", "ST_DATE", "ED_DATE", "CUST_PLANT", "UOM","TY");
                if(source.Tables.Count>0 && source.Tables[0].Rows.Count>0)
                {
                    for(int row=0;row<source.Tables[0].Rows.Count;row++)
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
                if(grd01.Rows.Count<=1)
                {
                    MsgBox.Show("There is no data to save!!", "Error", MessageBoxButtons.OK);
                    return;
                }
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "CUSTCD","PARTNO", "PNO", "ST_DATE","ED_DATE", "UPRICE", "TY", "HSN", "SANO", "CUST_PLANT");
                
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
                else if(tabControl1.SelectedIndex == 0)
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
        private void axButton2_Click(object sender, EventArgs e)
        {
            if (MsgBox.Show("Do you want to send this unit price to e-Invoice System?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
            {
                ProcData();
                this.BtnQuery_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgBox.Show("Do you want to import sap unit price for reference?", "Question", MessageBoxButtons.YesNo, ImageKinds.Question) == DialogResult.Yes)
                {
                    this.BeforeInvokeServer(true);
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set.Add("ST_DATE", axDateEdit1.GetDateText());
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "ZSD1000_SAP_UP"), set);
                    BtnQuery_Click(null, null);
                }
            }
            catch(Exception eLog)
            {
                this.AfterInvokeServer();
                MsgBox.Show(eLog.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void grd01_Click(object sender, EventArgs e)
        {

        }

        private void sfdExcel_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ofdExcel_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }




    }
}

