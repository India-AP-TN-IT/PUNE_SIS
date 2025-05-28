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
using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class PD20050 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
      

        public PD20050()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));//new PD20043P1();
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "");

                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);
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
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "MODEL", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part Number", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part Description", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 210, "LINE", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 55, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 55, "DIV", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "TIT#1", "TIT01", "TIT01");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "TIT#2", "TIT02", "TIT02");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "TIT#3", "TIT03", "TIT03");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "TIT#4", "TIT04", "TIT04");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "TIT#5", "TIT05", "TIT05");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "TIT#6", "TIT06", "TIT06");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "TIT#7", "TIT07", "TIT07");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "SPC#1", "SPC01", "SPC01");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "SPC#2", "SPC02", "SPC02");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "SPC#3", "SPC03", "SPC03");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "SPC#4", "SPC04", "SPC04");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "SPC#5", "SPC05", "SPC05");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "SPC#6", "SPC06", "SPC06");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "SPC#7", "SPC07", "SPC07");

     


                #endregion
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
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
                set.Add("VINCD", cdx01_VINCD.GetValue());
                set.Add("PARTNO", Txt_PartNo.Text);
                set.Add("PRDT_DIV", "");
                set.Add("LINECD", cdx01_LINECD.GetValue());

                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet("APG_PD20050.INQUERY", set, "OUT_CURSOR");

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
                                                              
                                                              , "PARTNO"
                                                              ,"TIT01"
                                                              , "TIT02"
                                                              , "TIT03"
                                                              , "TIT04"
                                                              , "TIT05"
                                                              , "TIT06"
                                                              , "TIT07"
                                                              , "SPC01"
                                                              , "SPC02"
                                                              , "SPC03"
                                                              , "SPC04"
                                                              , "SPC05"
                                                              , "SPC06"
                                                              , "SPC07"
                                                            );
                

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["CORCD"] = UserInfo.CorporationCode;
                        rows["BIZCD"] = UserInfo.BusinessCode;
                    }

                    if (!IsSaveValid(sourceIU)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_PD20050.SAVE", sourceIU);

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
                commandString += " ,[Part Number] as PARTNO";
                commandString += " ,[TIT#1] as TIT01";
                commandString += " ,[TIT#2] as TIT02";
                commandString += " ,[TIT#3] as TIT03";
                commandString += " ,[TIT#4] as TIT04";
                commandString += " ,[TIT#5] as TIT05";
                commandString += " ,[TIT#6] as TIT06";
                commandString += " ,[TIT#7] as TIT07";

                commandString += " ,[SPC#1] as SPC01";
                commandString += " ,[SPC#2] as SPC02";
                commandString += " ,[SPC#3] as SPC03";
                commandString += " ,[SPC#4] as SPC04";
                commandString += " ,[SPC#5] as SPC05";
                commandString += " ,[SPC#6] as SPC06";
                commandString += " ,[SPC#7] as SPC07";
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
