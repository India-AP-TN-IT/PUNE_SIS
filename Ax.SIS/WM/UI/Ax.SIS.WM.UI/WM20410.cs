using System;
using System.Data;
using System.ServiceModel;

using System.Drawing;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;
using System.Diagnostics;
using C1.Win.C1FlexGrid;
using System.Data.OleDb;
using System.Text;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class WM20410 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
      
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public WM20410()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);

                this.cbo01_CORCD.DataBind_CORCD();
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                #region [그리드1]
                
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "MODEL", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part Number", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part Description", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "VENDOR", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 55, "UNIT", "UOM", "UOM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "USAGE", "USG", "USG");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 60, "OPT", "OPT_RATE", "OPT_RATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "L/TIME(D)", "DEL_LEAD_TIME_DAYS", "DEL_LEAD_TIME_DAYS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "R/AVG", "DAY_AVG_USAGE", "DAY_AVG_USAGE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "STOCK", "STOCK_QTY", "STOCK_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "MIN", "MIN_STOCK_QTY", "MIN_STOCK_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "MAX", "MAX_STOCK_QTY", "MAX_STOCK_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "S/QTY", "QTY_TROLLEY_IN", "QTY_TROLLEY_IN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 70, "L/CAPA", "LOC_CAPA", "LOC_CAPA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "STATUS", "STATUS", "STATUS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L,120, "REMARK", "REMARK", "REMARK");
                

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 180, "VENDOR", "UPDATE_ID", "UPDATE_ID");

     


                #endregion
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private string GetPRDT_DIV()
        {
            if(radioButton1.Checked)
            {
                return "A0A";
            }
            else if (radioButton1.Checked)
            {
                return "A0S";
            }
            return "A0M";
        }
        #region [공통버튼]
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                DataSet source = null;
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("STD_DATE", dtp01_STD_DATE.Value.ToString("yyyy-MM-dd"));
                set.Add("PARTNO", Txt_PartNo.Text);
                set.Add("PRDT_DIV", GetPRDT_DIV());

                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet("APG_WM20410.INQUERY", set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet sourceIU = null;
                sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save
                                                              , "CORCD"
                                                              , "BIZCD"
                                                              , "VINCD"
                                                              , "PARTNO"
                                                              , "USG"
                                                              , "DEL_LEAD_TIME_DAYS"
                                                              , "DAY_AVG_USAGE"
                                                              , "MIN_STOCK_QTY"
                                                              , "MAX_STOCK_QTY"
                                                              , "QTY_TROLLEY_IN"
                                                              , "LOC_CAPA"
                                                              , "REMARK"
                                                              , "OPT_RATE"
                                                              ,"UPDATE_ID"
                                                            );
                

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["CORCD"] = UserInfo.CorporationCode;
                        rows["BIZCD"] = UserInfo.BusinessCode;
                        rows["UPDATE_ID"] = UserInfo.UserID;
                    }

                    if (!IsSaveValid(sourceIU)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20410.SAVE", sourceIU);

                    this.AfterInvokeServer();
                }

                this.BtnQuery_Click(null, null);

                //저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
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
        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                



                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //저장할 데이터가 존재하지 않습니다..
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }


                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

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

                foreach (DataRow row in worksheets.Rows)
                {
                    dsSheet.Tables[0].Rows.Add(Convert.ToString(row["TABLE_NAME"]), Convert.ToString(row["TABLE_NAME"]));
                }
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
               
                commandString += " '" + cbo01_CORCD.GetValue().ToString() + "' as CORCD";
                commandString += " ,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
                commandString += " ,'" + this.dtp01_STD_DATE.Value.ToString("yyyy-MM-dd") + "' as ST_DATE";
                commandString += " ,[MODEL] as VINCD";
                commandString += " ,[Part Number] as PARTNO";
                commandString += " ,[USAGE] as USG";
                commandString += " ,[L/TIME(D)] as DEL_LEAD_TIME_DAYS";

                commandString += " ,[R/AVG] as DAY_AVG_USAGE";
                commandString += " ,[MIN] as MIN_STOCK_QTY";
                commandString += " ,[MAX] as MAX_STOCK_QTY";
                commandString += " ,[S/QTY] as QTY_TROLLEY_IN";
                commandString += " ,[L/CAPA] as LOC_CAPA";
                commandString += " ,[OPT] as OPT_RATE";
                commandString += " ,[REMARK] as REMARK";
                commandString += " FROM [" + SheetName + "]";
                 
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                oleDB.Close();

                this.grd01.SetValue(ds);
                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01[i, 0] = AxFlexGrid.FLAG_N;
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


    }
}
