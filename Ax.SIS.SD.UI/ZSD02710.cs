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

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZSD02710 : AxCommonBaseControl
    {
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02710";

        #region [ 초기화 작업 정의 ]

        public ZSD02710()
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
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "PLANT", "CUST_PLANT", "CUST_PLANT");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "O/NO", "ORDERNO", "ORDERNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PO", "PONO", "PONO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CAR", "VINCD", "VINCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Part No", "PARTNO", "PARTNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "P/TY", "POTY", "POTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "QTY", "POQTY", "POQTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CURRENCY", "CUR", "CUR");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "UNIT PRICE", "UP", "UP");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "AMOUNT", "AMOUNT", "AMOUNT");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PO/DATE", "PO_DATE", "PO_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "D/DATE", "DUE_DATE", "DUE_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "DEL/DATE", "DEL_DATE", "DEL_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "GATE", "GATENO", "GATENO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Delay Reason", "DREASON", "DREASON");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "STATUS", "STATUS", "STATUS");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PACK", "VEND_PACK", "VEND_PACK");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "USER ID", "UPDATE_ID", "UPDATE_ID");



                axDateEdit1.SetValue(DateTime.Now.AddMonths(-2));




            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        
        private void ExcelLoad(object sender, EventArgs e)
        {
            try
            {
                
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
        private void ReadExcelSheet(string SheetName, string file)
        {
            if (string.IsNullOrEmpty(SheetName)) return;

            OleDbConnection oleDB = null;
            try
            {
                if (string.IsNullOrEmpty(cbl01_CustPLANT.GetValue().ToString()))
                {
                    MsgBox.Show("Please select the Customer's Code", "Error");                    
                    return;
                }
                this.BeforeInvokeServer();

                StringBuilder connectionString = new StringBuilder();
                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");
                connectionString.AppendFormat(@"Data Source={0}", file);
                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();


                string commandString = "SELECT ";
                commandString += " '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                
                commandString += " ,'" + cbl01_CustPLANT.GetValue().ToString() + "' as CUST_PLANT";
                commandString += " ,[Part Name] as PARTNM";
                commandString += " ,[Order No#] as ORDERNO";
                
                commandString += " ,[PO No#] as PONO";
                commandString += " ,[Part No#] as PARTNO";
                
                commandString += " ,[PO Kind] as POTY";
                commandString += " ,[PO QTY] as POQTY";
                commandString += " ,[Curr] as CUR";
                commandString += " ,[Unit Price] as UP";
                commandString += " ,[Amount] as AMOUNT";
                commandString += " ,[PO Date] as PO_DATE";
                commandString += " ,[Due Date] as DUE_DATE";
                commandString += " ,[Delivery Planned Date] as DEL_DATE";
                commandString += " ,[Gate No] as GATENO";
                commandString += " ,[Delay Reason] as DREASON";
                commandString += " ,[Status] as STATUS";
                commandString += " ,[Vend Pack Fg] as VEND_PACK";
                commandString += " FROM [" + SheetName + "]";
                commandString += " where [Order No#]<>''";
                
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
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (oleDB != null)
                {
                    oleDB.Close();
                }
                this.AfterInvokeServer();
            }
        }
        private void DataSave()
        {
            try
            {
                List<string> lstORD = new List<string>();
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                DataSet source = this.grd05.GetValue(AxFlexGrid.FActionType.All, 
                                            "CORCD"
                                            ,"BIZCD"
                                            ,"CUSTCD"
                                            ,"CUST_PLANT"
                                            ,"ORDERNO"
                                            ,"PONO"
                                            ,"PARTNO"
                                            ,"PARTNM"
                                            ,"POTY"
                                            ,"POQTY"
                                            ,"CUR"
                                            ,"UP"
                                            ,"AMOUNT"
                                            ,"PO_DATE"
                                            ,"DUE_DATE"
                                            ,"DEL_DATE"
                                            ,"GATENO"
                                            ,"DREASON"
                                            ,"STATUS"
                                            ,"VEND_PACK"
                                            ,"UPDATE_ID"
                                            );
                
                
                if (source.Tables[0].Rows.Count > 0)
                {
                    /*
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        string ord = source.Tables[0].Rows[i]["ORDERNO"].ToString();
                        if(lstORD.Contains(ord) == false)
                        {
                            lstORD.Add(ord);
                            HEParameterSet set = new HEParameterSet();
                            set.Add("CORCD", UserInfo.CorporationCode);
                            set.Add("BIZCD", cbo01_BIZCD.GetValue());
                            set.Add("ORDERNO", ord);
                            _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02710.DEL_ORD", set);
                        }
                    }
                        
                    */
                    
                    this.BeforeInvokeServer(true);
                   
                    _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02710.SAVE_DATA", source);

                    this.AfterInvokeServer();

                   // this.BtnQuery_Click(null, null);
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
               
                this.BeforeInvokeServer(true);

                DataSave();

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
                set.Add("ED_DATE", axDateEdit2.GetDateText());                
                set.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
                set.Add("VINCD", cdx01_VINCD.GetValue());
                set.Add("PARTNO", txt01_PARTNO.GetValue());
                set.Add("ORDERNO", axTextBox1.GetValue());
               
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02710.GET_DATA", set, "OUT_CURSOR");
                grd05.SetValue(source);
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


    }
}

