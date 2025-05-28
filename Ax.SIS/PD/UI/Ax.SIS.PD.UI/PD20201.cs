#region ▶ Description & History
/* 
 * 프로그램명 : PD20201 ALC 상세 사양관리 일괄 등록
 * 설      명 : 
 * 최초작성자 : 오세민
 * 최초작성일 : 2011-05-24 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 : 
 * 
 *				날짜			    작성자		  이슈
 *				---------------------------------------------------------------------------------------------
 *				2010-05-24		오세민         최초 개발
 *				2014-07-23      배명희         cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *				2017-07~09      배명희         SIS 이관
*/
#endregion
using System;
using System.Data;
using System.Data.OleDb;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Text;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// ALC 상세 사양관리 일괄 등록 프로그램
    /// </summary>
    public partial class PD20201 : AxCommonBaseControl
    {
        //private IPM20036 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD20201";
        private DataSet _DSGridHeader;
        private bool _IsDisplay;
        private const string _ExcelProvider 
            = @"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=""Excel 12.0;HDR=YES;"";Data Source={0}";

        private const string _ExcelSQL
            = @" SELECT TRIM([라인코드]) AS [라인코드], TRIM([장착위치]) AS [장착위치], TRIM([ALC]) AS [ALC], 
                        TRIM([내장컬러]) AS [내장컬러], TRIM([어퍼/로어]) AS [어퍼/로어], TRIM([로어 2]) AS [로어 2],
                        TRIM([A/R 컬러]) AS [A/R 컬러], TRIM([A/R 엠블렘]) AS [A/R 엠블렘],
                        TRIM([가니시]) AS [가니시],
                        TRIM([P/W SW]) AS [P/W SW],
                        TRIM([I/PAD]) AS [I/PAD],
                        TRIM([SEAT SW]) AS [SEAT SW], TRIM([컨텍터]) AS [컨텍터],
                        TRIM([스피커그릴]) AS [스피커그릴], TRIM([커튼]) AS [커튼],
                        TRIM([TWT SPK]) AS [TWT SPK], TRIM([무드램프]) AS [무드램프] FROM [{0}$]";

        public PD20201()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM20036>("PM00", "PM20036.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        
        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {            
            try
            {
                this.cbo01_SAUP.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_SAUP.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_SAUP.SetReadOnly(false);
                else
                    this.cbo01_SAUP.SetReadOnly(true);

                //DataSet source = this.GetTypeCode("A3", "CA");

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                this.cdx01_LINECD.SetCodePixedLength();

                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1();
                //this.cdx01_LINECD.PopupTitle = "라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                //this.cdx01_LINECD.SetCodePixedLength();

                this.cbo01_INSTALL_POS.DataBind("A7");
                //this.cdx01_VINCD.PrefixCode = "A3";

                this.SetRequired(this.lbl01_LINECD, this.lbl01_POSTITLE);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 그리드 헤더정보 생성
        /// </summary>
        private void DynamicColumn()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                set.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());

                this.BeforeInvokeServer(true);
                //_DSGridHeader = _WSCOM.GridHeader(set);
                _DSGridHeader = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GRIDHEADER"), set);

                if (_DSGridHeader.Tables[0].Rows.Count < 4)
                    return;

                foreach (DataRow row in _DSGridHeader.Tables[0].Rows)
                {                    
                    this.grd01.AddColumn(true, true, row["ALIGN"].ToString() == "L" ? AxFlexGrid.FtextAlign.L : (row["ALIGN"].ToString() == "R" ? AxFlexGrid.FtextAlign.R : AxFlexGrid.FtextAlign.C),
                        Convert.ToInt32(row["WIDTH"].ToString()), row["COLUMN_ID"].ToString(), row["COLUMN_ID"].ToString());
                    this.grd02.AddColumn(true, true, row["ALIGN"].ToString() == "L" ? AxFlexGrid.FtextAlign.L : (row["ALIGN"].ToString() == "R" ? AxFlexGrid.FtextAlign.R : AxFlexGrid.FtextAlign.C),
                        Convert.ToInt32(row["WIDTH"].ToString()), row["COLUMN_ID"].ToString(), row["COLUMN_ID"].ToString());
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

        #endregion
        
        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.Rows.Count < 1)
                    return;
                int size = this.grd01.GridColumns.Count;
                string[] columns = new string[size];
                for (int i = 1; i <= size; i++)
                {
                    columns[i-1] = this.grd01.Cols[i].Name;
                }

                DataSet source = this.grd01.GetValue
                (
                    AxFlexGrid.FActionType.All, 
                    columns
                    //"LINECD", "INSTALL_POS", "ALCCD", "ASSY_COLOR", "UPPER_COLOR", "LOWER_COLOR",
                    //"AR_COLOR", "AR_EMBLEM", "GARNISH", "PW_SW", "PAD", "SEAT_SW", "CONTACTOR", "SPK_GRILL", "CURTAIN", "TWT_SPK",  "LAMP"
                );

                DataSet source2 = AxFlexGrid.GetDataSourceSchema("LINECD", "INSTALL_POS", "ALCCD", "PARTNO", "SPEC");
                
                foreach (DataRow rows in source.Tables[0].Rows)
                {   
                    DataRow dr = source2.Tables[0].NewRow();
                    dr["LINECD"] = rows["라인코드"].ToString();
                    dr["ALCCD"] = rows["ALC"].ToString();
                    dr["INSTALL_POS"] = "A7" + rows["장착위치"].ToString();
                    dr["PARTNO"] = rows["파트넘버"].ToString();

                    StringBuilder sb = new StringBuilder();
                    for (int i = 3; i < columns.Length; i++)
                    {
                        sb.Append(rows[i].ToString());
                        if (i == source.Tables[0].Columns.Count - 1)
                            break;
                        sb.Append(";");
                    }
                    dr["SPEC"] = sb.ToString();
                    source2.Tables[0].Rows.Add(dr);                    
                }                

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source2);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source2);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 ALC CODE 상세 정보가 저장되었습니다.");
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
                if (grd02.Cols.Count < 2)
                    DynamicColumn();

                HEParameterSet set = new HEParameterSet();                
                set.Add("LINECD",        this.cdx01_LINECD.GetValue().ToString());
                set.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());

                if (!this.IsQueryValid(set)) return;

                this.BeforeInvokeServer(true);
                //DataSet dsInquery = _WSCOM.Inquery(set);
                DataSet dsInquery = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);

                
                int size = this.grd02.GridColumns.Count;
                string[] headers = new string[size];
                for (int i = 1; i <= size; i++)
                {
                    headers[i-1] = this.grd01.Cols[i].Name;
                }
                DataSet ds = this.GetDataSourceSchema(headers);
                //DataSet ds = grd02.GetValue(AxFlexGrid.FActionType.All, headers);

                foreach (DataRow rows in dsInquery.Tables[0].Rows)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    dr[0] = rows["LINECD"].ToString();
                    dr[1] = rows["INSTALL_POS"].ToString();
                    dr[2] = rows["ALCCD"].ToString();
                    dr[3] = rows["PARTNO"].ToString();
                    string[] columns = rows["SPEC"].ToString().Split(';');
                    for (int i = 0; i < columns.Length; i++)
                    {

                        dr[i + 3] = columns[i];
                    }
                    ds.Tables[0].Rows.Add(dr);
                }
                this.grd02.SetValue(ds);
                this.AfterInvokeServer();
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
            try
            {
                this.grd01.InitializeDataSource();
                this.grd02.InitializeDataSource();
                this.cdx01_LINECD.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
            set.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());

            if (!this.IsRemoveValid(set)) return;

            try
            {
                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(set);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), set);
                this.AfterInvokeServer();

                //MsgBox.Show("정상 삭제되었습니다.");
                MsgCodeBox.Show("CD00-0072");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void btn01_EXCEL_FILE_Click(object sender, EventArgs e)
        {
            if (_IsDisplay)
                return;
            try
            {
                if (!IsExcelFile())
                    return;
                //그리드 동적으로 생성
                DynamicColumn();

                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                this.txt01_EXCEL_FILE.SetValue(ofdExcel.FileName);

                string connectionString = String.Format(_ExcelProvider, ofdExcel.FileName);
                OleDbConnection conn    = new OleDbConnection(connectionString);
                
                using(conn)
                {
                    conn.Open();
                    DataTable worksheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    DataTable dtSheet    = new DataTable();
                    dtSheet.Columns.Add("SHEET_CODE");
                    dtSheet.Columns.Add("SHEET_NAME");
                    for (int i = 0; i < worksheets.Rows.Count; i++)
                    {
                        DataRow row       = dtSheet.NewRow();
                        string  sheetName = worksheets.Rows[i]["TABLE_NAME"].ToString();
                        if (sheetName.IndexOf('$') == -1)
                            continue;

                        sheetName         = sheetName.Substring(0, sheetName.Length - 1);
                        row["SHEET_CODE"] = sheetName;
                        row["SHEET_NAME"] = sheetName;

                        dtSheet.Rows.Add(row);
                    }

                    this.cbo01_EXCEL_SHEET.DataBind(dtSheet, false);
                }
                _IsDisplay = true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.grd01.InitializeDataSource();
            }
        }

        private void btn01_EXCEL_LOAD_Click(object sender, EventArgs e)
        {
            // Note :
            // 엑셀 파일의 첫번째 행을 HEADER 로 인식한다.
            // 엑셀 파일 첫번째 행에는 반드시 아래와 같은 HEADER 정보가 명시되어야하며 오타는 에러로 처리한다.
            //  - ALCCD
            //  - PARTNO
            //  - USAGE
            // 순서는 관계없으며 HEADER 정보가 일치하지 않을 시 예외가 발생하여 엑셀파일을 읽을 수 없다.
            try
            {
                string columns = string.Empty;

                for (int i = 2; i < _DSGridHeader.Tables[0].Rows.Count; i++)
                {
                    DataRow row = _DSGridHeader.Tables[0].Rows[i];
                    columns += ", [" + row["COLUMN_ID"].ToString() + "]";
                }
                string query = "SELECT [라인코드], [장착위치], [ALC], [파트넘버]" + columns + "FROM [{0}$]";
                if (cbo01_EXCEL_SHEET.ByteCount == 0)
                {
                    //MsgBox.Show("시트를 선택하지 않았습니다.");
                    MsgCodeBox.Show("PD00-0071");
                    return;
                }

                string connectionString = String.Format(_ExcelProvider, ofdExcel.FileName);
                OleDbConnection conn    = new OleDbConnection(connectionString);
                using(conn)
                {
                    conn.Open();
                    DataTable worksheets  = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string commandString  = String.Format(query, this.cbo01_EXCEL_SHEET.GetValue().ToString());
                    OleDbCommand cmd      = new OleDbCommand(commandString, conn);
                    OleDbDataAdapter dapt = new OleDbDataAdapter(cmd);
                    DataTable dt          = new DataTable();

                    dapt.Fill(dt);
                    
                    this.grd01.SetValue(dt);
                }
            }
            catch(OleDbException)
            {
                //MsgBox.Show("선택하신 시트는 ALC 일괄등록을 위한 올바른 형식의 시트가 아닙니다.\r\n\r\n컬럼 정보가 일치하는 시트를 선택하십시오.");
                MsgCodeBox.Show("PD00-0077");
                this.grd01.InitializeDataSource();
            }
        }

        private void cdx01_LINECD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        public bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 ALC 코드 정보가 존재하지 않습니다.");
                    MsgCodeBox.ShowFormat("PD00-0078", this.GetLabel("ALCCODE"));
                    return false;
                }

                if (this.cbo01_SAUP.ByteCount == 0)
                {
                    //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                    MsgCodeBox.Show("PD00-0079");
                    return false;
                }
                

                //if (this.cbo01_WORK_DIR_DIV.ByteCount == 0)
                //{
                //    MsgBox.Show("작업지시구분코드가 입력되지 않았습니다.");
                //    return false;
                //}

                //if (this.txt01_VEND_ITEMCD.ByteCount == 0)
                //{
                //    MsgBox.Show("고객품목코드가 입력되지 않았습니다.");
                //    return false;
                //}

                //string BEG_DATE = this.dte01_APPLY_BEG_DATE.GetValue().ToString();
                //if (this.GetByteCount(BEG_DATE) == 0)
                //{
                //    MsgBox.Show("적용 시작일을 입력하지 않았습니다.");
                //    return false;
                //}

                //if (this.GetByteCount(BEG_DATE) > 10)
                //{
                //    MsgBox.Show("적용 시작일은 10Byte 이상 입력할 수 없습니다.");
                //    return false;
                //}

                //for (int i = 1; i<source.Tables[0].Rows.Count; i++)
                //{
                //    DataRow row   = source.Tables[0].Rows[i];
                //    string LINECD = row["LINECD"].ToString();
                //    string INSTALL_POS = row["INSTALL_POS"].ToString();
                //    string ALCCD  = row["ALCCD"].ToString();                    

                //    if (this.GetByteCount(ALCCD) == 0)
                //    {
                //        MsgBox.Show(i + " 번째 행에 ALC 코드를 입력하지 않았습니다.");
                //        return false;
                //    }

                //    if (this.GetByteCount(ALCCD) > 5)
                //    {
                //        MsgBox.Show(i + " 번째 행에 ALC 코드는 5Byte 이상 입력할 수 없습니다.");
                //        return false;
                //    }

                //    if (this.GetByteCount(LINECD) == 0)
                //    {
                //        MsgBox.Show(i + " 번째 행에 LINECD를 입력하지 않았습니다.");
                //        return false;
                //    }

                //    if (this.GetByteCount(LINECD) > 10)
                //    {
                //        MsgBox.Show(i + " 번째 행에 PART-NO는 20Byte 이상 입력할 수 없습니다.");
                //        return false;
                //    }
                //}

                //if (MsgBox.Show("입력하신 ALC 코드 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public bool IsQueryValid(HEParameterSet set)
        {
            try
            {
                if (set.Keys[0].Length == 0)
                {
                    //MsgBox.Show("{0}이(가) 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LINECD"));
                    return false;
                }

                if (this.cbo01_INSTALL_POS.ByteCount == 0)
                {
                    //MsgBox.Show("장착위치가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("POSTITLE"));
                    return false;
                }       
                //if (MsgBox.Show("입력하신 ALC 코드 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public bool IsRemoveValid(HEParameterSet set)
        {
            try
            {
                if (set.Keys[0].Length == 0)
                {
                    //MsgBox.Show("삭제할 라인코드 정보가 존재하지 않습니다.");
                    MsgCodeBox.ShowFormat("PD00-0061", this.GetLabel("LINECD"));
                    return false;
                }

                if (this.cbo01_INSTALL_POS.ByteCount == 0)
                {
                    //MsgBox.Show("장착위치가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("POSTITLE"));
                    return false;
                }

                //if (MsgBox.Show("라인코드:" + set.Values[0].ToString() + ", 장착위치:" + set.Values[1].ToString() + " 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        public bool IsExcelFile()
        {
            try
            {
                if (cdx01_LINECD.Text.Trim().Length < 5)
                {
                    //MsgBox.Show("{0}이(가) 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LINECD"));
                    return false;
                }

                if (this.cbo01_INSTALL_POS.ByteCount == 0)
                {
                    //MsgBox.Show("장착위치가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("POSTITLE"));
                    return false;
                }
                //if (MsgBox.Show("입력하신 ALC 코드 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        #endregion        

    }
}
