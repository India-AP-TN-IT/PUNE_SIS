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
    public partial class ZSD02750 : AxCommonBaseControl
    {
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02750";

        #region [ 초기화 작업 정의 ]

        public ZSD02750()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            
        }
        private DataTable GetColItems()
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("PLANTCD", "KVF1");
            DataTable source = null;

            source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02750.GET_ITEMS", set, "OUT_CURSOR").Tables[0];
            return source;
        }
        private List<string> GetColList()
        {
            List<string> lstCol = new List<string>();
             DataTable source = GetColItems();
            for(int row=0;row<source.Rows.Count;row++)
            {
                string key = source.Rows[row]["ITEMS"].ToString();
                if(!lstCol.Contains(key))
                {
                    lstCol.Add(key);
                }
                
            }
            return lstCol;
        }
        private string GetExcelColItems()
        {
            DataTable source = GetColItems();
            string cols = "";
            for(int row=0;row<source.Rows.Count;row++)
            {
                cols += "[" + source.Rows[row]["ITEMS"].ToString().Substring(0, 1) + "(" + source.Rows[row]["ITEMS"].ToString().Substring(1, 3) + ")" + "] AS " + source.Rows[row]["ITEMS"].ToString();
                if(row!=source.Rows.Count-1)
                {
                    cols += ",";
                }
            }
            return cols;
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
                
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);


                this.grd05.AllowEditing = true;
                this.grd05.AllowAddNew = false;
                this.grd05.Initialize();

                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CORCD", "CORCD", "CORCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "BIZCD", "BIZCD", "BIZCD");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Customer", "CUSTCD", "CUSTCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "PLANT", "PLANT", "PLANT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "LINE", "LINE", "LINE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "DATA_TYPE", "DATA_TYPE", "DATA_TYPE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "RCV_DATE", "RCV_DATE", "RCV_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "SEQ", "SEQ", "SEQ");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "BODYNO", "BODYNO", "BODYNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 170, "VINNO", "VINNO", "VINNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 170, "ORDNO", "ORDNO", "ORDNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "COLOR", "COLOR", "COLOR");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "EXCOLOR", "EXCOLOR", "EXCOLOR");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "PROD_DATE", "PROD_DATE", "PROD_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "TIME", "TIME", "TIME");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "BSEQ", "BSEQ", "BSEQ");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "ALCCD", "ALCCD", "ALCCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "ITEM", "ITEM", "ITEM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "MODEL", "MODEL", "MODEL");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "CLIENT", "CLIENT", "CLIENT");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "USERID", "USERID", "USERID");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "BSEQCD_SEQNO", "BSEQCD_SEQNO", "BSEQCD_SEQNO");
                
                






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
                commandString += " '" +UserInfo.CorporationCode +"' as CORCD";
                commandString += " ,'" + cbo01_BIZCD.GetValue().ToString() + "' as BIZCD";
                commandString += " ,'KMI' as CUSTCD";
                commandString += " ,'1' as PLANT";
                commandString += " ,'1' as LINE";
                commandString += " ,'EM' as DATA_TYPE";
                commandString += " ,' ' as RCV_DATE";
                commandString += " ,[MES SEQ] as SEQ";
                commandString += " ,[Body No] as BODYNO";
                commandString += " ,[V#I#N] as VINNO";
                commandString += " ,[W/ORDER] as ORDNO";
                commandString += " ,[Int] as COLOR";
                commandString += " ,[Ext] as EXCOLOR";
                commandString += " ,[RP Act# Datetime] as PROD_DATE";
                commandString += " ,' ' as PROD_TIME";
                commandString += " ,' ' as BSEQ";
                commandString += " ,' ' as ALCCD";
                commandString += " ,' ' as ITEM";
                commandString += " ,[Model] as MODEL";
                commandString += " ,'EM' as CLIENT";
                commandString += " ,'" + UserInfo.UserID + "' as USERID";
                commandString += " ,'' as BSEQCD_SEQNO";
                
                
                
                
                
                commandString += " ," +GetExcelColItems();
                commandString += " FROM [" + SheetName + "]";
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                oleDB.Close();
                ds.Tables[0].Columns["PROD_TIME"].ColumnName = "TIME";

                List<string> lstCols = GetColList();
                DataTable dt = ds.Tables[0].Clone();
                foreach(string strCOL in lstCols)
                {
                    dt.Columns.Remove(strCOL);
                }
                
                for (int row = 0; row < ds.Tables[0].Rows.Count;row++ )
                {
                    
                    ds.Tables[0].Rows[row]["SEQ"] = ds.Tables[0].Rows[row]["SEQ"].ToString().PadLeft(4, '0');
                    ds.Tables[0].Rows[row]["BODYNO"] = ds.Tables[0].Rows[row]["MODEL"].ToString().Substring(0,3) + " " + ds.Tables[0].Rows[row]["BODYNO"].ToString().PadLeft(6, '0');
                    ds.Tables[0].Rows[row]["MODEL"] = ds.Tables[0].Rows[row]["MODEL"].ToString().Substring(0, 2);
                    string tmpDate = ds.Tables[0].Rows[row]["PROD_DATE"].ToString();
                    ds.Tables[0].Rows[row]["RCV_DATE"] = GetProdDate(tmpDate, "YMD");
                    ds.Tables[0].Rows[row]["PROD_DATE"] = GetProdDate(tmpDate, "YMD");

                    ds.Tables[0].Rows[row]["TIME"] = GetProdDate(tmpDate, "HM");
                    for(int col=0;col< ds.Tables[0].Columns.Count;col++)
                    {
                        string key = ds.Tables[0].Columns[col].ColumnName;
                        if(lstCols.Contains(key))
                        {
                            dt.ImportRow(ds.Tables[0].Rows[row]);
                            dt.Rows[dt.Rows.Count-1]["ITEM"] = key;
                            dt.Rows[dt.Rows.Count - 1]["ALCCD"] = ds.Tables[0].Rows[row][key].ToString();
                        }
                    }
                    
                }

                this.grd05.SetValue(dt);
                
                
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
        
        private string GetProdDate(string date, string frm)
        {
            string rt ="";
            string tmpDATE =  date.Trim().Replace(" ", "").Replace(".", "").Replace(":","");
            if(frm == "YMD")
            {
                rt = tmpDATE.Substring(4, 4) + tmpDATE.Substring(2, 2) + tmpDATE.Substring(0, 2);
            }
            else if (frm == "HM")
            {
                rt = tmpDATE.Substring(8, 2) + tmpDATE.Substring(10, 2);
            }
            return rt;
        }
        private void DataSave()
        {
            try
            {
                List<string> lstORD = new List<string>();
                string bizcd = cbo01_BIZCD.GetValue().ToString();
               
                DataSet source = this.grd05.GetValue(AxFlexGrid.FActionType.Save, 
                                            "CORCD"
                                            ,"BIZCD"
                                            , "CUSTCD"
                                            , "PLANT"
                                            , "LINE"
                                            , "DATA_TYPE"
                                            , "RCV_DATE"
                                            , "SEQ"
                                            , "BODYNO"
                                            , "VINNO"
                                            , "ORDNO"
                                            , "COLOR"
                                            , "EXCOLOR"
                                            , "PROD_DATE"
                                            , "TIME"
                                            , "BSEQ"
                                            , "ALCCD"
                                            , "ITEM"
                                            , "MODEL"
                                            , "CLIENT"
                                            , "USERID"
                                            , "BSEQCD_SEQNO"
                                            );
                
                
                if (source.Tables[0].Rows.Count > 0)
                {
                    
                    
                  //  this.BeforeInvokeServer(true);

                    _WSCOM_N.ExecuteNonQueryTx("APG_ALC_TXT2DB.SAVE_ZSD0320_TXT2DB", source);

                //    this.AfterInvokeServer();

                   // this.BtnQuery_Click(null, null);

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("CUSTCD", "KMI");

                    _WSCOM_N.ExecuteNonQueryTx("ASP_SD_ZSD0320_TO_ZSD0330_EM", set);
                }
                else
                {
                    MsgBox.Show("There is no data to save!", "Error", MessageBoxButtons.OK, ImageKinds.Error);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
               // this.AfterInvokeServer();
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
                set.Add("PARTNO", txt01_PARTNO.GetValue());
                set.Add("VINCD", cdx01_VINCD.GetValue());
                set.Add("BODY", axTextBox1.GetValue());

                set.Add("ST_DATE", axDateEdit1.GetDateText());
                set.Add("ED_DATE", axDateEdit2.GetDateText());    
                
                
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02750.GET_DATA", set, "OUT_CURSOR");
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

