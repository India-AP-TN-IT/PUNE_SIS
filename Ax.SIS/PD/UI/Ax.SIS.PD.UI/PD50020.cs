
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using System.Drawing;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b> ASSY ALL LINE MORNITORING </b>
    /// </summary>
    public partial class PD50020 : AxCommonBaseControl
    {
        //private IPMCommon _WSCOM;
        private AxClientProxy _WSCOM;
        private DateTime _svrDate;
        private const string _IntFormat = "###,###,###,###,##0";
        List<string> m_Cols = new List<string>();
        private string PACKAGE_NAME = "APG_PD50020";

        public PD50020()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        private void PD50020_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;
                this.axDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void InitForm()
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cdx01_VENDCD.HEPopupHelper = new CM20017P1();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                this.cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);

                //303408 Kia Motors India Private Limited

                this.cdx01_VENDCD.SetValue("303408");
                dtp01_STD_DATE.SetValue(DateTime.Now.Date);

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_STD_DATE, this.lbl01_VENDCD);

                this.txt01_EXL_FILE.Initialize();
                this.cbo01_EXL_SHEET.Initialize();

                #region grd01
                this.grd01.AllowEditing = true;
                this.grd01.Initialize(1, 1);
                this.grd01.Font = new Font("맑은 고딕", 8);

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Std Date", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "Part No.", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Deli Type", "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "Base Stock", "BASE_STOCK", "BASE_STOCK");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "VENDCD", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 100, "USERID", "USERID", "USERID");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BASE_STOCK");
                this.grd01.Cols["BASE_STOCK"].Format = _IntFormat;

                for (int r = 1; r < grd01.Cols.Count; r++)
                {
                    m_Cols.Add(grd01.Cols[r].Name);
                }

                #endregion
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        protected override void UI_Shown(EventArgs e)
        {
            this.InitForm();

            #region [grdExcel-숨김그리드]

            this.grdExcel.AllowEditing = false;
            this.grdExcel.AllowDragging = AllowDraggingEnum.None;
            this.grdExcel.Initialize();
            this.grdExcel.Cols.RemoveRange(1, this.grdExcel.Cols.Count - 1);
            this.grdExcel.Cols.Fixed = 1;
            this.grdExcel.Styles.Fixed.BackColor = Color.Yellow;
            this.grdExcel.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PartNo", "PARTNO", "PARTNO");
            this.grdExcel.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "BaseStock", "BASE_STOCK", "BASE_STOCK");
            this.grdExcel.Cols["PARTNO"].DataType = typeof(string);
            this.grdExcel.Cols["BASE_STOCK"].DataType = typeof(decimal);
            this.grdExcel.Cols["BASE_STOCK"].Format = "###,##0";
            this.grdExcel.Cols[0].Visible = false;
            this.grdExcel.Styles.Fixed.Border.Color = Color.DarkGray;


            this.grdExcel.Rows.Add();
            this.grdExcel.SetValue(1, "PARTNO", "82301-XXXXXXXX");
            this.grdExcel.SetValue(1, "BASE_STOCK", "0");

            Font f = new Font(this.grdExcel.Font, FontStyle.Italic);
            this.grdExcel.Rows[1].StyleDisplay.Font = f;
            this.grdExcel.Rows[1].StyleDisplay.BackColor = Color.Transparent;
            this.grdExcel.Rows[1].StyleDisplay.ForeColor = Color.Gray;
            #endregion
        }
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                set.Add("STD_DATE", this.dtp01_STD_DATE.GetValue().ToString());
                set.Add("VENDCD", this.cdx01_VENDCD.GetValue().ToString());
                set.Add("LANG_SET", this.UserInfo.Language);

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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All, "VENDCD", "STD_DATE", "PARTNO", "BASE_STOCK", "USERID");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["VENDCD"] = this.cdx01_VENDCD.GetValue().ToString();
                    rows["USERID"] = this.UserInfo.UserID;
                }

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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
                this.InitForm();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion
        
        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        #region 엑셀 양식 다운로드 / 엑셀 업로드
        private void btn01_FILE_UPLOAD2_Click(object sender, EventArgs e)
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

        private void cbo01_EXL_SHEET_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo01_EXL_SHEET.Items.Count > 0)
                ReadExcelSheet(cbo01_EXL_SHEET.GetValue().ToString());
        }

        private void btn01_EXCEL_DOWN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdExcel.Rows.Count > 0)
                {
                    this.sfdExcel.DefaultExt = "xlsx";
                    this.sfdExcel.Filter = "Excel files (*.xls)|*.xls;*.xlsx|All files (*.*)|*.*";
                    this.sfdExcel.FileName = "KMI BaseStock Data Form";

                    if (this.sfdExcel.ShowDialog() == DialogResult.OK)
                    {
                        string temp_file = this.sfdExcel.FileName;

                        //행번호 컬럼은 엑셀로 전환되지 않도록..                     
                        this.grdExcel.Cols.Fixed = 0;

                        FileFlags flags = FileFlags.IncludeFixedCells | FileFlags.VisibleOnly;
                        this.grdExcel.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

                        //MsgBox.Show("다운로드가 완료되었습니다.");
                        MsgCodeBox.Show("CD00-0106");
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
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

                txt01_EXL_FILE.Value = FileName;
                DataTable worksheets = oleDB.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                DataSet dsSheet = this.GetDataSourceSchema("Code", "CodeValue");

                foreach (DataRow row in worksheets.Rows)
                {
                    dsSheet.Tables[0].Rows.Add(Convert.ToString(row["TABLE_NAME"]), Convert.ToString(row["TABLE_NAME"]));
                }
                cbo01_EXL_SHEET.DataBind(dsSheet.Tables[0], false);

                oleDB.Close();
                this.AfterInvokeServer();

                ReadExcelSheet(Convert.ToString(worksheets.Rows[0]["TABLE_NAME"]));
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

        private void ReadExcelSheet(string SheetName)
        {
            if (string.IsNullOrEmpty(SheetName)) return;

            OleDbConnection oleDB = null;
            try
            {
                this.BeforeInvokeServer();

                StringBuilder connectionString = new StringBuilder();
                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");
                connectionString.AppendFormat(@"Data Source={0}", txt01_EXL_FILE.Value.ToString());
                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();

                string commandString = String.Format(@"SELECT * FROM [{0}]", SheetName); //Excel SHeeT

                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                oleDB.Close();
                bool bPARTNO = ds.Tables[0].Columns.Contains("PartNo");
                bool BASE_STOCK = ds.Tables[0].Columns.Contains("BaseStock");

                if (bPARTNO) ds.Tables[0].Columns["PartNo"].ColumnName = "PARTNO";
                if (BASE_STOCK) ds.Tables[0].Columns["BaseStock"].ColumnName = "BASE_STOCK";

                if (!(bPARTNO && BASE_STOCK)) return;

                ds.Tables[0].Columns.Add("STD_DATE");
                ds.Tables[0].Columns.Add("PARTNM");
                ds.Tables[0].Columns.Add("DELI_TYPE");

                DataRow[] DelRow = ds.Tables[0].Select("PARTNO is NULL");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("PARTNO", dr["PARTNO"].ToString());
                    set.Add("LANG_SET", this.UserInfo.Language);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", this.PACKAGE_NAME, "INQUERY_PARTNO"), set);
                    if (source.Tables[0].Rows.Count > 0)
                    {
                        dr["STD_DATE"] = this.dtp01_STD_DATE.GetDateText();
                        dr["PARTNM"] = source.Tables[0].Rows[0]["PARTNM"].ToString();
                        dr["DELI_TYPE"] = source.Tables[0].Rows[0]["DELI_TYPE"].ToString();
                        int iBASE_STOCK = 0;
                        int.TryParse(dr["BASE_STOCK"].ToString(), out iBASE_STOCK);
                        dr["BASE_STOCK"] = iBASE_STOCK;
                    }
                }

                for (int i = DelRow.Length - 1; i >= 0; i--)
                {
                    ds.Tables[0].Rows.Remove(DelRow[i]);
                }

                ds.Tables[0].AcceptChanges();


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
        #endregion

        #endregion

        #region [ 유효성 검사 ]
        #endregion



    }
}
