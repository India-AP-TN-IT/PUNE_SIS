using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Ax.DEV.Utility.Library;
using System.ServiceModel;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core;
using Ax.DEV.Utility.Controls;
using System.Data.OleDb;

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// <b> 협력 업체를 조회하는 클래스</b>
    /// - 작 성 일 : 2019-06-27<br/>
    /// - 주요 변경 사항<br/>
    ///     1) 2019-06-27 : 최초 클래스 생성.<br/>
    /// </summary>
    public partial class ZSD02170 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;


        public ZSD02170()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
        }
        private Dictionary<string, string> GetDicCols(string pgmid)
        {
            Dictionary<string, string> dicRet = new Dictionary<string, string>();
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("PGMID", pgmid);
            DataTable dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02150.GET_COLS", paramSet, "OUT_CURSOR").Tables[0];
            for(int row = 0 ;row<dt.Rows.Count;row++)
            {
                string key = dt.Rows[row]["TB_COL"].ToString();
                string val = dt.Rows[row]["EX_COL"].ToString();
                dicRet.Add(key, val);
            }
            return dicRet;
        }
        #region [초기화 작업 정의]
        protected override void UI_Shown(EventArgs e)
        {
            base.UI_Shown(e);
            try
            {
                Lbl_Total.Text = "";
                // 법인
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";
                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
                
                #region grd01
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 90, "SEQ", "SEQ", "SEQ");
                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 90, "CUSTCD", "CUSTCD", "CUSTCD");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 90, "C/PLANT", "CUST_PLANT", "CUST_PLANT");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 140, "C/ID", "CUST_PLANT_ID", "CUST_PLANT_ID");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "ORDNO", "ORDNO", "ORDNO");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 70, "SHOP", "CUST_SHOP", "CUST_SHOP");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 70, "GATE", "CUST_GATE", "CUST_GATE");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 70, "CAR", "VINCD", "VINCD");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 60, "HSN", "HSN", "HSN");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "PART NO.", "PARTNO", "PARTNO");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 350, "PART DESC", "PARTNM", "PARTNM");

                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 60, "QTY.", "QTY", "QTY");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 60, "UOM", "UOM", "UOM");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 80, "PRICE", "UP", "UP");

                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "S/DATE", "ST_DATE", "ST_DATE");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 80, "E/DATE", "ED_DATE", "ST_DATE");

                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "PART_YN", "PART_YN", "PART_YN");
              
                
                #endregion
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ST_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ED_DATE");
                SetCustPLANT();
                cdx01_VENDCD.SetReadOnly(true);


            }
            catch (FaultException<ExceptionDetail> except)
            {
                MsgBox.Show(except.ToString());
            }
            finally
            {
            }
        }
        #endregion
        private void SetCustPLANT()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("TY", "A");
                DataTable source = null;

                //this.lbl03_LINECD.Value = this.GetLabel("LINE");    //라인
                //this.lbl03_PART_NO.Value = this.GetLabel("PARTNO");    //PART NO

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_ZSD02500", "INQUERY_PLANT"), set, "OUT_CURSOR").Tables[0];
                this.cbl01_CustPLANT.DataBind(source, this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L");

                //source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_LINE"), set, "OUT_CURSOR").Tables[0];
                //this.cbl04_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #region [공통 버튼에 대한 이벤트 정의]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.BeforeInvokeServer();
                this.grd01.Cols["SEQ"].Visible = false;
                this.grd01.Cols["ED_DATE"].Visible = true;
                grd01.SetValue(GetData());
                int rowcnt = 0;
                int errcnt = 0;
                for(int row=grd01.Rows.Fixed;row<grd01.Rows.Count;row++)
                {
                    if(grd01.GetValue(row,"PART_YN").ToString() != "Y")
                    {
                        grd01.Rows[row].StyleNew.BackColor = Color.Yellow;
                        errcnt++;
                    }
                    rowcnt++;
                }
                
                Lbl_Total.Text = "Total Rows:" + rowcnt.ToString() + "   Error Rows:" + errcnt.ToString();
                this.AfterInvokeServer();
            }
            catch (FaultException<ExceptionDetail> except)
            {
                MsgBox.Show(except.ToString());
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


                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "CUSTCD", "CUST_PLANT", "ORDNO", "HSN","PARTNO", "PARTNM", "QTY", "UOM", "UP", "ST_DATE", "UPDATE_ID", "PART_YN", "CUST_SHOP", "CUST_GATE", "CUST_PLANT_ID");
                DataSet deleteDS = this.grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "CUSTCD", "CUST_PLANT", "PARTNO", "ST_DATE","ORDNO");
                
                this.BeforeInvokeServer(true);
                if (source.Tables[0].Rows.Count > 0)
                {
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_ZSD02170", "SAVE"), source);
                }

                if (deleteDS.Tables[0].Rows.Count > 0)
                {
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_ZSD02170", "REMOVE"), deleteDS);
                }
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

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
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            base.BtnReset_Click(sender, e);
        }

        private DataTable GetData(bool bSchemaOnly = false)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            if (bSchemaOnly)
            {
                paramSet.Add("BIZCD", "XXXX");
            }
            else
            {
                paramSet.Add("BIZCD",cbo01_BIZCD.GetValue());
            }
            paramSet.Add("VINCD", cdx01_VINCD.GetValue());
            paramSet.Add("ORDNO", Txt_ORDNO.GetValue());
            paramSet.Add("PARTNO", Txt_PARTNO.GetValue());
            paramSet.Add("CUST_PLANT", cbl01_CustPLANT.GetValue());
            paramSet.Add("ST_DATE", Dat_ST_DATE.GetDateText());
            


            return _WSCOM_N.ExecuteDataSet("ZPG_ZSD02170.INQUERY", paramSet, "OUT_CURSOR").Tables[0];
        }
        #endregion

        private string GetVal(DataTable dt, int row, string colnm)
        {
            string colactNM = "";
            for(int i=0;i<dt.Columns.Count;i++)
            {
                if(dt.Columns[i].ColumnName.ToUpper().Contains(colnm.ToUpper()))
                {
                    colactNM= dt.Columns[i].ColumnName.ToUpper();
                    break;
                }
            }
            if(string.IsNullOrEmpty(colactNM) == false)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    if (row == i)
                    {
                        return dt.Rows[i][colactNM].ToString().Trim();
                    }
                }
            }
            return "";
            
        }
        private DataRow GetPartValid(string partno, string partnm, string st_date)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD",cbo01_BIZCD.GetValue());
            paramSet.Add("PARTNO", partno);
            paramSet.Add("PARTNM", partnm);
            paramSet.Add("ST_DATE", st_date);
            DataTable dt =_WSCOM_N.ExecuteDataSet("ZPG_ZSD02170.GET_VALID_PARTNO", paramSet, "OUT_CURSOR").Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
            
        }
        public DateTime GetLastDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }
        private void CalcMobisOrderQTY(ref DataSet ds)
        {
            /*for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                string parton = ds.Tables[0].Rows[row]["PART NO"].ToString();
                if(string.IsNullOrEmpty(parton) == false)
                {
                    ds.Tables[0].Rows[row]["ORDER"] = Convert.ToDouble(ds.Tables[0].Rows[row]["ORDER"])
                                    - Convert.ToDouble(ds.Tables[0].Rows[row + 1]["R-DATE"])
                                    - Convert.ToDouble(ds.Tables[0].Rows[row + 1]["ORDER"])
                                    - Convert.ToDouble(ds.Tables[0].Rows[row + 1]["F16"])
                                    - Convert.ToDouble(ds.Tables[0].Rows[row + 1]["PRICE"]);
                }
            }*/
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                string parton = ds.Tables[0].Rows[row]["PART NO"].ToString();
                if (string.IsNullOrEmpty(parton) == false)
                {
                    ds.Tables[0].Rows[row]["ORDER"] = Convert.ToDouble(ds.Tables[0].Rows[row]["ORDER"])
                                    - Convert.ToDouble(ds.Tables[0].Rows[row]["Cancel"])
                                    - Convert.ToDouble(ds.Tables[0].Rows[row]["InTransit"])
                                    - Convert.ToDouble(ds.Tables[0].Rows[row]["M-RCV"])
                                    - Convert.ToDouble(ds.Tables[0].Rows[row]["ASN-Q"]);
                }
            }
        }
        private void CalcHMI_UP(ref DataSet ds)
        {
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                ds.Tables[0].Rows[row]["MATERIAL COST"] = Convert.ToDouble(ds.Tables[0].Rows[row]["MATERIAL COST"])
                                    / Convert.ToDouble(ds.Tables[0].Rows[row + 1]["PRICE"]);
            }
        }
        private void ReadExcelSheet(string SheetName, string file)
        {
            if (string.IsNullOrEmpty(SheetName)) return;

            OleDbConnection oleDB = null;
            try
            {
                this.BeforeInvokeServer();
                this.grd01.Cols["SEQ"].Visible = true;
                this.grd01.Cols["ED_DATE"].Visible = true;
                

                StringBuilder connectionString = new StringBuilder();
                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");
                connectionString.AppendFormat(@"Data Source={0}", file);
                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();
                string commandString = "SELECT ";
                commandString += " *";
                commandString += " FROM [" + SheetName + "]";
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                Dictionary<string, string> dicCols = null;
                switch(cbl01_CustPLANT.GetValue().ToString())
                {
                    case "HVF1":
                    case "HVF2":
                    case "HVF3":
                    case "HKF3":
                    case "HVF5":
                        dicCols = GetDicCols("ZSD02170");
                        break;
                    default:
                        if (cbl01_CustPLANT.GetValue().ToString().Contains("MBI"))
                        {   // Mobis
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                //ds.Tables[0].Rows.RemoveAt(0);
                                CalcMobisOrderQTY(ref ds);
                            }
                            dicCols = GetDicCols("ZSD02172");
                            
                        }
                        else
                        {   //Other OEM
                            dicCols = GetDicCols("ZSD02171");
                        }
                        break;
                }


                DataTable dt = GetData(true);
                int idx = 0;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    
                    DataRow dr = dt.NewRow();
                    dr["CORCD"] = cbo01_CORCD.GetValue().ToString();
                    dr["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                    dr["CUSTCD"] = cdx01_VENDCD.GetValue().ToString();
                    dr["UPDATE_ID"] = UserInfo.UserID;
                    foreach(KeyValuePair<string, string> pair in dicCols)
                    {
                        try
                        {
                            dr[pair.Key] = GetVal(ds.Tables[0], row, pair.Value);
                        }
                        catch { }
                        
                    }
                    if (dicCols.ContainsKey("CUST_PLANT") == false)
                    {
                        dr["CUST_PLANT"] = cbl01_CustPLANT.GetValue().ToString();
                    }
                    
                    
                    if(string.IsNullOrEmpty(dr["PARTNO"].ToString()) == false)
                    {
                        if (dr["CUST_PLANT"].ToString() != cbl01_CustPLANT.GetValue().ToString())
                        {
                            grd01.Initialize();
                            MsgBox.Show("Wrong Customer Plant Code!!", "Error");
                            return;
                        }
                        dr["SEQ"] = (idx+1).ToString();
                        DataRow validDR = GetPartValid(dr["PARTNO"].ToString(), dr["PARTNM"].ToString(), dr["ST_DATE"].ToString());
                        dr["PART_YN"] = validDR["PART_YN"].ToString();
                        dr["PARTNO"] = validDR["PARTNO"].ToString();
                        dr["PARTNM"] = validDR["PARTNM"].ToString();
                        dr["VINCD"] = validDR["VINCD"].ToString();
                        
                        DateTime dtSTDATE = Convert.ToDateTime(dr["ST_DATE"].ToString());

                        DateTime edDate = new DateTime(dtSTDATE.Year, dtSTDATE.Month, dtSTDATE.Day);
                        edDate = GetLastDayOfMonth(edDate);
                        dr["ED_DATE"] = edDate;
                        dt.Rows.Add(dr);

                        
                        idx++;
                        
                    }
                    

                }

                oleDB.Close();

                this.grd01.SetValue(dt);
                int rowcnt=0;
                int errcnt=0;
                for (int i = grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    
                    this.grd01[i, 0] = AxFlexGrid.FLAG_N;
                    if(grd01.GetValue(i,"PART_YN").ToString()=="N")
                    {
                        grd01.Rows[i].StyleNew.BackColor = Color.Red;
                        grd01.Rows[i].StyleNew.ForeColor = Color.White;
                        errcnt++;
                    }
                    rowcnt++;
                }
                Lbl_Total.Text = "Total Rows:" + rowcnt.ToString() + "   Error Rows:" + errcnt.ToString();
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
        private void axButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(cbl01_CustPLANT.GetValue().ToString()))
                {
                    MsgBox.Show("Customer Plant is needed!!","Question");
                    return;
                }
                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                string filename = this.ofdExcel.FileName;


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

        private void cbl01_CustPLANT_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbl01_CustPLANT.GetValue().ToString()))
                {
                    cdx01_VENDCD.SetValue("", "");
                    return;
                }
                cdx01_VENDCD.SetValue("", "");
                string selectedValue = this.cbl01_CustPLANT.GetValue().ToString();
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("PLANTCD", selectedValue);
                paramSet.Add("LANG_SET", UserInfo.Language);
                DataTable dt = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500.INQUERY_PLANT_DET", paramSet, "OUT_CURSOR").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string cd = dt.Rows[0]["VENDCD"].ToString();
                    string nm = dt.Rows[0]["VENDNM"].ToString();
                    cdx01_VENDCD.SetValue(nm, cd);                    
                }

            }
            catch (Exception eLog)
            {

            }
        }

    }
}

