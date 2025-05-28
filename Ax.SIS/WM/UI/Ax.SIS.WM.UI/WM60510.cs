using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using System.Diagnostics;
using System.ServiceModel;
using System.Data.OleDb;

namespace Ax.SIS.WM.UI
{
    public partial class WM60510 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        public WM60510()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;

                #region grd01

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Asset Code", "ASSET_CODE", "ASSET_CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Serial No", "SR_NO", "SR_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "Asset Type", "ASSET_TYPE", "ASSET_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Make", "MAKE", "MAKE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "Issued Date", "ISSUED_DATE", "ISSUED_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "Issued Name", "ISSUED_NAME", "ISSUED_NAME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "Issued Dept", "ISSUED_DEPT", "ISSUED_DEPT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "Issued Location", "ISSUED_LOCATION", "ISSUED_LOCATION");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "Hostname", "HOSTNAME", "HOSTNAME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "STATUS", "STATUS", "STATUS");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Processor", "ASSET_PROCESSOR", "ASSET_PROCESSOR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "RAM", "ASSET_RAM", "ASSET_RAM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "HDD", "ASSET_HDD", "ASSET_HDD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "OS", "ASSET_OS", "ASSET_OS");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Warranty End Date", "WARRANTY_END_DATE", "WARRANTY_END_DATE");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Ethernet Mac Address", "ASSET_EMAC_ADDR", "ASSET_EMAC_ADDR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Wifi Mac Address", "ASSET_WMAC_ADDR", "ASSET_WMAC_ADDR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Antivirus", "ANTIVIRUS_YN", "ANTIVIRUS_YN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "Keyboard", "KEYBOARD_YN", "KEYBOARD_YN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "Mouse", "MOUSE_YN", "MOUSE_YN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "Pendrive", "PENDRIVE_YN", "PENDRIVE_YN");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Remarks", "REMARKS", "REMARKS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Model", "ASSET_MODEL", "ASSET_MODEL");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "Has Warranty End?", "WARRANTY_END_ALERT", "WARRANTY_END_ALERT");


                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "WARRANTY_END_DATE");
                this.grd01.Cols["WARRANTY_END_DATE"].Format = "dd-MM-yyyy";


                this.grd01.SelectionMode = SelectionModeEnum.Row;

                #endregion


                #region initilize combo

                this.cbo01_ASSET_TYPE.Initialize();
                this.cbo01_MAKE.Initialize();
                this.cbo01_DEPT.Initialize();
                this.cbo01_LOC.Initialize();
                this.chk01_WARR_END_ASSETS.Checked = false;
                this.chk01_KB_MSE.Checked = false;
                this.chk01_PENDRIVE.Checked = false;

                
                Inquery_AssetType();
                Inquery_AssetMake();
                Inquery_IssuedDept();
                Inquery_IssuedLoc();

                #endregion


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void axButton1_Click(object sender, EventArgs e)
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
                if (tabControl1.SelectedIndex == 0)
                {
                    commandString += " [Asset Code] as ASSET_CODE";
                    commandString += " ,[Serial No] as SR_NO";
                    commandString += " ,[Asset Type] as ASSET_TYPE";
                    commandString += " ,[Make] as MAKE";
                    commandString += " ,[Issued Date] as ISSUED_DATE";
                    commandString += " ,[Issued Name] as ISSUED_NAME";
                    commandString += " ,[Issued Dept] as ISSUED_DEPT";
                    commandString += " ,[Issued Location] as ISSUED_LOCATION";
                    commandString += " ,[Hostname] as HOSTNAME";
                    commandString += " ,[STATUS] as STATUS";
                    commandString += " ,[Processor] as ASSET_PROCESSOR";
                    commandString += " ,[RAM] as ASSET_RAM";
                    commandString += " ,[HDD] as ASSET_HDD";
                    commandString += " ,[OS] as ASSET_OS";
                    commandString += " ,[Warranty End Date] as WARRANTY_END_DATE";
                    commandString += " ,[Ethernet Mac Address] as ASSET_EMAC_ADDR";
                    commandString += " ,[Wifi Mac Address] as ASSET_WMAC_ADDR";
                    commandString += " ,[Antivirus] as ANTIVIRUS_YN";
                    commandString += " ,[Keyboard] as KEYBOARD_YN";
                    commandString += " ,[Mouse] as MOUSE_YN";
                    commandString += " ,[Pendrive] as PENDRIVE_YN";
                    commandString += " ,[Remarks] as REMARKS";
                    commandString += " ,[Model] as ASSET_MODEL";
                    commandString += " FROM [" + SheetName + "]";
                }
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                oleDB.Close();

                if (tabControl1.SelectedIndex == 0)
                {
                    this.grd01.SetValue(ds);
                    //for (int i = 1; i < this.grd01.Rows.Count; i++)
                    //{
                    //    this.grd01[i, 0] = AxFlexGrid.FLAG_N;
                    //}
                    ShowDataCount(ds);
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
                if (tabControl1.SelectedIndex == 0)
                {
                    txt01_EXL_FILE.Value = FileName;
                    cbo01_EXL_SHEET.DataBind(dsSheet.Tables[0], false);
                    oleDB.Close();
                    this.AfterInvokeServer();

                    ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]), FileName);
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All, "ASSET_CODE", "SR_NO", "ASSET_TYPE", "MAKE", "ISSUED_DATE", "ISSUED_NAME", "ISSUED_DEPT", "ISSUED_LOCATION", "HOSTNAME", "STATUS", "ASSET_PROCESSOR", "ASSET_RAM", "ASSET_HDD", "ASSET_OS", "WARRANTY_END_DATE", "ASSET_EMAC_ADDR", "ASSET_WMAC_ADDR", "ANTIVIRUS_YN", "KEYBOARD_YN", "MOUSE_YN", "PENDRIVE_YN", "REMARKS", "ASSET_MODEL");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("APG_WM60510.DATA_SAVE"), source);
                    this.AfterInvokeServer();
                }
                this.BtnQuery_Click(null, null);

                //정상적으로 저장되었습니다.
                MsgCodeBox.Show("CD00-0009");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                if (ex.Message.ToString().Split('|').Length > 1)
                {
                    MessageBox.Show(ex.Message.ToString().Split('|')[1]);
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
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
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("AST_TYPE", this.cbo01_ASSET_TYPE.GetValue());
                paramSet.Add("AST_MAKE", this.cbo01_MAKE.GetValue());
                paramSet.Add("ISS_DEPT", this.cbo01_DEPT.GetValue());
                paramSet.Add("ISS_LOC", this.cbo01_LOC.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM60510.INQUERY_ASSET", paramSet);
                this.AfterInvokeServer();

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.grd01.SetValue(source);
                    this.ShowDataCount(source);
                }
                else
                {
                    MsgBox.Show("No Records to show");
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.InitializeDataSource();
                        this.cbo01_ASSET_TYPE.Initialize();
                        this.cbo01_MAKE.Initialize();
                        this.cbo01_DEPT.Initialize();
                        this.cbo01_LOC.Initialize();
                        this.chk01_WARR_END_ASSETS.Checked = false;
                        this.chk01_KB_MSE.Checked = false;
                        this.chk01_PENDRIVE.Checked = false;
                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk01_WARR_END_ASSETS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_WARR_END_ASSETS.Checked == true)
            {
                this.grd01.Cols["WARRANTY_END_DATE"].Visible = true;
                int resultCol = this.grd01.Cols["WARRANTY_END_DATE"].Index;

                for (int i = 1; i < grd01.Rows.Count; i++)
                {
                    if (grd01.Rows[i]["WARRANTY_END_ALERT"].ToString() == "Y")
                    {
                        CellRange cRange = this.grd01.GetCellRange(i, resultCol);
                        cRange.StyleNew.BackColor = Color.Red;
                        cRange.StyleNew.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                this.grd01.Cols["WARRANTY_END_DATE"].Visible = false;
            }
        }

        private void chk01_KB_MSE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_KB_MSE.Checked == true)
            {
                this.grd01.Cols["KEYBOARD_YN"].Visible = true;
                this.grd01.Cols["MOUSE_YN"].Visible = true;
            }
            else
            {
                this.grd01.Cols["KEYBOARD_YN"].Visible = false;
                this.grd01.Cols["MOUSE_YN"].Visible = false;
            }
        }

        private void chk01_PENDRIVE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_PENDRIVE.Checked == true)
            {
                this.grd01.Cols["PENDRIVE_YN"].Visible = true;
            }
            else
            {
                this.grd01.Cols["PENDRIVE_YN"].Visible = false;
            }
        }

        private void Inquery_AssetType()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM.ExecuteDataSet("APG_WM60510.INQUERY_ASSETTYPE");
                this.AfterInvokeServer();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("NAME");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["NAME"] = dr["CODE"].ToString();
                    }
                    this.cbo01_ASSET_TYPE.DataBind(ds.Tables[0], true);
                    this.ShowDataCount(ds);
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

        private void Inquery_AssetMake() 
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM.ExecuteDataSet("APG_WM60510.INQUERY_ASSETMAKE");
                this.AfterInvokeServer();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("NAME");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["NAME"] = dr["CODE"].ToString();
                    }
                    this.cbo01_MAKE.DataBind(ds.Tables[0], true);
                    this.ShowDataCount(ds);
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

        private void Inquery_IssuedDept()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM.ExecuteDataSet("APG_WM60510.INQUERY_ISSUEDDEPT");
                this.AfterInvokeServer();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("NAME");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["NAME"] = dr["CODE"].ToString();
                    }
                    this.cbo01_DEPT.DataBind(ds.Tables[0], true);
                    this.ShowDataCount(ds);
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

        private void Inquery_IssuedLoc()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM.ExecuteDataSet("APG_WM60510.INQUERY_ISSUEDLOC");
                this.AfterInvokeServer();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("NAME");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["NAME"] = dr["CODE"].ToString();
                    }
                    this.cbo01_LOC.DataBind(ds.Tables[0], true);
                    this.ShowDataCount(ds);
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

    }
}
