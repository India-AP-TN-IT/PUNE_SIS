using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.Drawing;
using HE.Framework.ServiceModel;
using System.Data.OleDb;
using System.Text;
using System.Collections.Generic;

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>실사 생산 실적 관리</b>
    /// </summary>
    public partial class BM30302 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_BM30302";
        List<string> m_Cols = new List<string>();

        public BM30302()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();	
        }

        #region [ 초기화 작업 정의 ]
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.dte01_EO_EFF_IN.SetMMFromStart();

                this.grd01.Initialize();
                this.grd01.AllowEditing = false;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "UPG", "UPG", "UPG");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PGN", "PGN", "PGN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PAC", "PAC", "PAC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "JOIN", "JOIN", "JOIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "CCN", "CCN", "CCN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "MD", "MODULE", "MODULE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "VENDOR NAME", "VENDOR", "VENDOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "EFFIN", "EO_EFF_IN", "EO_EFF_IN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "EFFOUT", "EO_EFF_OUT", "EO_EFF_OUT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "VC", "VC", "VC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "SEQ", "SEQ", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "NA", "I2", "I2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "ME", "I3", "I3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "EU", "I4", "I4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "IN", "IA", "IA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT01", "OPT01", "OPT01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT02", "OPT02", "OPT02");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT03", "OPT03", "OPT03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT04", "OPT04", "OPT04");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT05", "OPT05", "OPT05");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT06", "OPT06", "OPT06");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT07", "OPT07", "OPT07");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT08", "OPT08", "OPT08");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT09", "OPT09", "OPT09");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT10", "OPT10", "OPT10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT11", "OPT11", "OPT11");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT12", "OPT12", "OPT12");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT13", "OPT13", "OPT13");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT14", "OPT14", "OPT14");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT15", "OPT15", "OPT15");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT16", "OPT16", "OPT16");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT17", "OPT17", "OPT17");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT18", "OPT18", "OPT18");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT19", "OPT19", "OPT19");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT20", "OPT20", "OPT20");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT21", "OPT21", "OPT21");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT22", "OPT22", "OPT22");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT23", "OPT23", "OPT23");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT24", "OPT24", "OPT24");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT25", "OPT25", "OPT25");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT26", "OPT26", "OPT26");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT27", "OPT27", "OPT27");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT28", "OPT28", "OPT28");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT29", "OPT29", "OPT29");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPT30", "OPT30", "OPT30");


                this.grd01.Cols["CCN"].Format = "#,###,###,###,###,###";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CCN");

                for(int r=1; r < grd01.Cols.Count; r++)
                { 
                    m_Cols.Add(grd01.Cols[r].Name); 
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt01_PAC.Initialize();
                this.txt01_PGN.Initialize();
                this.txt01_PARTNO.Initialize();
                this.dte01_EO_EFF_IN.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                    set.Add("PGN", this.txt01_PGN.GetValue().ToString());
                    set.Add("PAC", this.txt01_PAC.GetValue().ToString());
                    set.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                    set.Add("EO_EFF_IN", chk01_DATE.Checked ? this.dte01_EO_EFF_IN.GetDateText().Replace("-", "") : "");

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);

                grd01.SetValue(source);
                ShowDataCount(source);
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All, m_Cols.ToArray());

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);
                this.AfterInvokeServer();

                //this.BtnQuery_Click(null, null);

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
        #endregion

        #region [ 기타 컨트롤들에 대한 이벤트 정의 ]

        #region 엑셀 양식 다운로드 / 엑셀 업로드 

        private void btn01_FILE_UPLOAD2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                string filename = this.ofdExcel.FileName;

                if (!this.IsVaildFile(filename))
                {
                    //MessageBox.Show("파일에 접근할 수 없습니다. 파일이 열려있는지 확인하세요.");
                    MsgCodeBox.Show("CD00-0120");
                    return;
                }
                this.ReadExcel(filename);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #endregion

        #region [ 사용자 정의 메서드 ]
        private void ReadExcel(string FileName)
        {
            OleDbConnection oleDB = null;
            try
            {
                this.BeforeInvokeServer();
                string version = FileName.Substring(FileName.Length - 1, 1);
                this.BeforeInvokeServer(true);
                StringBuilder connectionString = new StringBuilder();

                int ExcelVersion = this.ExcelFileType(FileName);

                string[] FileNames = FileName.Split('.');
                int EndFile = FileNames.Length - 1;

                string FType = FileName.Substring(FileName.LastIndexOf(".") + 1).ToUpper();
                switch (FType)
                {
                    case "XLS":
                    case "XLSX":
                        connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=""Excel 12.0;HDR=YES"";");
                        break;

                    case "":
                        //MsgBox.Show("파일이 선택 되지 않았습니다.");
                        MsgCodeBox.Show("QA01-0001");
                        return;

                    default:
                        //MsgBox.Show("확장자가 XLS, XLSX이 아닙니다.");
                        MsgCodeBox.Show("QA01-0002");
                        return;
                }

                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");

                connectionString.AppendFormat(@"Data Source={0}", FileName);

                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();

                DataTable worksheets = oleDB.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string commandString = String.Format(" SELECT * FROM [{0}]",
                                                worksheets.Rows[0]["TABLE_NAME"]); //SHEET NAME
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                oleDB.Close();

                //Remove Header in Excel
                for( int r = 0; r <=10; r++)
                { ds.Tables[0].Rows.RemoveAt(0); }

                //Remake Cols Name
                for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                {
                    if(c < 47) //grd01 Max Col index
                    ds.Tables[0].Columns[c].ColumnName = grd01.Cols[c+1].Name;
                }

                //Remove UPG EFF DATE Cols
                int Colcnt = ds.Tables[0].Columns.Count;

                for (int c = Colcnt; c > Colcnt - 4; c--)
                { ds.Tables[0].Columns.RemoveAt(ds.Tables[0].Columns.Count - 1); }

                //Set (*,○) -> Y , OPT01(*) -> LHD, OPT02(*) -> RHD
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                    {
                        DataRow row = ds.Tables[0].Rows[r];
                        DataColumn col = ds.Tables[0].Columns[c];
                        string curpartno = "";
                        string prepartno = "";

                        //if PARTNO is Del Space
                        if (col.ColumnName == "PARTNO")
                        {
                            row[col] = Convert.ToString(row[col]).Replace(" ", "");
                        }

                        //if PGN,PAC is Merged in Excel
                        if (r > 0 && (col.ColumnName == "PGN" || col.ColumnName == "PAC") && Convert.ToString(row[col]) == "")
                        {
                            curpartno = Convert.ToString(row["PARTNO"]).Replace(" ", "");
                            prepartno = Convert.ToString(ds.Tables[0].Rows[r - 1]["PARTNO"]).Replace(" ", "");
                            //Same Part No 
                            if (curpartno == prepartno)
                                row[col] = ds.Tables[0].Rows[r - 1][c];
                        }

                        if (col.ColumnName == "OPT01" && Convert.ToString(row[col]) == "*")
                            row[col] = "LHD";

                        if (col.ColumnName == "OPT02" && Convert.ToString(row[col]) == "*")
                            row[col] = "RHD";

                        if (Convert.ToString(row[col]) == "*" || Convert.ToString(row[col]) == "○")
                            row[col] = "Y";
                    }
                }

                this.grd01.SetValue(ds);
                ShowDataCount(ds);

                this.AfterInvokeServer();

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
        #endregion
    }
}
