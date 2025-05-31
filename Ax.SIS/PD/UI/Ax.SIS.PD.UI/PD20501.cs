#region ▶ Description & History
/* 
 * 프로그램명 : PD20501 
 * 설     명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 : 
 * 
 *				날짜			    작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09      배명희         SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Data.OleDb;
using System.IO;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 완/반제품 계측 기준정보 관리
    /// </summary>
    public partial class PD20501 : AxCommonBaseControl
    {
        
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20501";

        private const string _ExcelProvider
           = @"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=""Excel 12.0;HDR=YES;"";Data Source={0}";

        private const string _ExcelSQL
            = @"SELECT UCASE(TRIM([PARTNO])) AS PARTNO,
                       UCASE(TRIM([ALCCD])) AS ALCCD,
                       UCASE(TRIM([LEDCD])) AS LEDCD
                  FROM [{0}$] 
                 WHERE [PARTNO] IS NOT NULL";

        public PD20501()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20501>("PD", "PD20501.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
               
                this.grd01.Initialize(1, 1);
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 070, "SEQ", "SEQ", "SEQ");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "자재 품번", "PARTNO", "MAT_PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "적재대 번호", "LEDCD", "LEDCD");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "LEDCD");
                this.grd01.Cols["LEDCD"].Format = "#########0";

                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);


                this.grd02.AllowEditing = false;
                this.grd02.Initialize(1,1);
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.EnabledActionFlag = false;

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "SEQ", "SEQ", "SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "ALC", "ALCCD", "ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "자재 품번", "PARTNO", "MAT_PARTNO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "적재대 번호", "LEDCD", "LEDCD");

                this.cdx02_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx02_VINCD);


                this.grd03.AllowEditing = false;
                this.grd03.Initialize(1,1);
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.EnabledActionFlag = false;

                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "SEQ", "SEQ", "SEQ");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "ALC", "ALCCD", "ALCCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "자재 품번", "PARTNO", "MAT_PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적재대 번호", "LEDCD", "LEDCD");

                this.BtnReset_Click(null, null);

                #region LED 적재대 맵 초기화 정보

                for(int i=1; i<33;i++)
                {
                    AxLabel oLabel = (AxLabel)grp01_LED1.Controls["lbl01_LED1_" + i];
                    oLabel.Value = i.ToString();
                }
                for (int i = 1; i < 21; i++)
                {
                    AxLabel oLabel = (AxLabel)grp01_LED2.Controls["lbl01_LED2_" + i];
                    oLabel.Value = (i+32).ToString();
                }

                #endregion
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tab_tabPage2.SelectedIndex == 0)
                {   //조회 및 개별 등록
                    this.cbl01_ALCCD.Initialize();
                    this.txt01_PARTNO.Initialize();
                    this.cdx01_VINCD.Initialize();
                }
                else if(this.tab_tabPage2.SelectedIndex ==1)
                {   //일괄등록
                    this.cbl02_ALCCD.Initialize();
                    this.txt02_PARTNO.Initialize();
                    this.txt02_EXCEL_FILE.Initialize();
                    this.cbo02_EXCEL_SHEET.Initialize();
                    this.cdx02_VINCD.Initialize();
                }
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
                //조회 및 개별 등록
                if (this.tab_tabPage2.SelectedIndex == 0)
                {   
                    HEParameterSet set = new HEParameterSet();
                    set.Add("ALCCD", this.cbl01_ALCCD.Visible == true ? this.cbl01_ALCCD.GetValue() : this.txt01_ALCCD.GetValue());
                    set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                    set.Add("VINCD", this.cdx01_VINCD.GetValue());

                    this.BeforeInvokeServer(true);

                    DataSet dsResult = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                    this.grd01.SetValue(dsResult.Tables[0]);
                    ShowDataCount(dsResult);
                    this.AfterInvokeServer();
                }
                //일괄등록
                else
                {   
                    HEParameterSet set = new HEParameterSet();
                    set.Add("ALCCD", this.cbl02_ALCCD.Visible == true ? this.cbl02_ALCCD.GetValue() : this.txt02_ALCCD.GetValue());
                    set.Add("PARTNO", this.txt02_PARTNO.GetValue());
                    set.Add("VINCD", this.cdx02_VINCD.GetValue());

                    this.BeforeInvokeServer(true);

                    DataSet dsResult = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                    this.grd03.SetValue(dsResult.Tables[0]);
                    ShowDataCount(dsResult);

                    this.AfterInvokeServer();

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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //조회 및 개별 등록
                if (this.tab_tabPage2.SelectedIndex == 0)
                {
                    DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "SEQ", "ALCCD", "PARTNO", "LEDCD");

                    if (!this.IsSaveValid(set)) return;

                    this.BeforeInvokeServer(true);
                    using (AxClientProxy proxy = new AxClientProxy())
                    {
                        proxy.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE_EACH"), set);
                    }

                    this.AfterInvokeServer();

                    //MsgCodeBox.Show("입력하신 정보가 저장되었습니다.");
                    MsgCodeBox.Show("PD00-0049");

                    this.BtnQuery_Click(null, null);

                }
                //일괄등록
                else
                {
                    DataSet set = this.grd02.GetValue(AxFlexGrid.FActionType.All, "SEQ", "ALCCD", "PARTNO", "LEDCD");

                    if (!this.IsSaveValid(set)) return;

                    this.BeforeInvokeServer(true);
                    using (AxClientProxy proxy = new AxClientProxy())
                    {
                        proxy.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), set);
                    }

                    this.AfterInvokeServer();

                    //MsgCodeBox.Show("입력하신 정보가 일괄 저장되었습니다.");
                    MsgCodeBox.Show("PD00-0006");

                    this.BtnQuery_Click(null, null);
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //조회 및 개별 등록
                if (this.tab_tabPage2.SelectedIndex == 0)
                {
                    DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove, "ALCCD", "PARTNO");

                    if (!IsDeleteValid(source)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_DELETE"), source);

                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                    //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                    //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                    this.AfterInvokeServer();

                    this.BtnReset_Click(null, null);
                    this.BtnQuery_Click(null, null);

                    //if (isSyncOK) 
                    
                    //MsgBox.Show("삭제되었습니다.");
                    MsgCodeBox.Show("CD00-0072");
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

        #endregion

        #region [ 기타 컨트롤 이벤트 ]

        private void cbl01_ALCCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("VINCD", this.cdx01_VINCD.GetValue());
                this.lbl01_ALCTITLE.Value = this.GetLabel("ALCTITLE");  //ALC 코드

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_ALC"), set, "OUT_CURSOR").Tables[0];

                this.cbl01_ALCCD.DataBind(source, this.GetLabel("VIN") + ";" + this.GetLabel("ALCCODE"), "C;L"); // 차종;ALC CODE

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private void cbl02_ALCCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("VINCD", this.cdx02_VINCD.GetValue());
                this.lbl02_ALCTITLE.Value = this.GetLabel("ALCTITLE");  //ALC 코드

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_ALC"), set, "OUT_CURSOR").Tables[0];

                this.cbl02_ALCCD.DataBind(source, this.GetLabel("VIN") + ";" + this.GetLabel("ALCCODE"), "C;L"); // 차종;ALC CODE

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_VINCD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //VINCD 변경 (VINCD 선택시 콤보BOX / 미선택시 TEXT BOX)
                change_AlccdBox();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx02_VINCD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //VINCD 변경 (VINCD 선택시 콤보BOX / 미선택시 TEXT BOX)
                change_AlccdBox();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_EXCEL_FILE_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                this.txt02_EXCEL_FILE.SetValue(ofdExcel.FileName);

                string connectionString = String.Format(_ExcelProvider, ofdExcel.FileName);
                OleDbConnection conn = new OleDbConnection(connectionString);

                using (conn)
                {
                    conn.Open();
                    DataTable worksheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    DataTable dtSheet = new DataTable();
                    dtSheet.Columns.Add("SHEET_CODE");
                    dtSheet.Columns.Add("SHEET_NAME");
                    for (int i = 0; i < worksheets.Rows.Count; i++)
                    {
                        DataRow row = dtSheet.NewRow();
                        string sheetName = worksheets.Rows[i]["TABLE_NAME"].ToString();
                        if (sheetName.IndexOf('$') == -1)
                            continue;

                        sheetName = sheetName.Substring(0, sheetName.Length - 1);
                        row["SHEET_CODE"] = sheetName;
                        row["SHEET_NAME"] = sheetName;

                        dtSheet.Rows.Add(row);
                    }

                    this.cbo02_EXCEL_SHEET.DataBind(dtSheet, false);


                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.grd02.InitializeDataSource();
            }
        }

        private void btn02_EXCEL_LOAD_Click(object sender, EventArgs e)
        {
            // Note :
            // 엑셀 파일의 첫번째 행을 HEADER 로 인식한다.
            // 엑셀 파일 첫번째 행에는 반드시 아래와 같은 HEADER 정보가 명시되어야하며 오타는 에러로 처리한다.
            //  - ALCCD
            //  - PARTNO
            //  - LEDCD
            // 순서는 관계없으며 HEADER 정보가 일치하지 않을 시 예외가 발생하여 엑셀파일을 읽을 수 없다.
            try
            {
                if (cbo02_EXCEL_SHEET.ByteCount == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("시트를 선택하지 않았습니다.");
                    MsgCodeBox.Show("PD00-0071");
                    return;
                }

                string connectionString = String.Format(_ExcelProvider, ofdExcel.FileName);
                OleDbConnection conn = new OleDbConnection(connectionString);
                using (conn)
                {
                    conn.Open();
                    DataTable worksheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string commandString = String.Format(_ExcelSQL, this.cbo02_EXCEL_SHEET.GetValue().ToString());
                    OleDbCommand cmd = new OleDbCommand(commandString, conn);
                    OleDbDataAdapter dapt = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dapt.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["PARTNO"] = dt.Rows[i]["PARTNO"].ToString().Replace(" ", "");
                    }

                    this.grd02.SetValue(dt);
                }
            }
            catch (OleDbException)
            {
                //메세지 코드 처리
                //MsgBox.Show("선택하신 시트는 생산품번 일괄등록을 위한 올바른 형식의 시트가 아닙니다.\r\n\r\nPARTNO, SAF_INV_QTY, LINECD, ALCCD, SEMI_DIV, LEVCD, WARN_LEV_TYPE, SPEA_TYPE 정보가 \r\n\r\n존재하는 시트를 선택하십시오.");
                MsgCodeBox.Show("PD00-0072");

                this.grd02.InitializeDataSource();
            }
        }

        private void btn02_EXCEL_DOWN_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            //saveFileDialog.FileName = this.GetLabel("??"); // "LED매칭일괄등록";    //1420에 확인 zz
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls;*.xlsx|All files (*.*)|*.*";

            string filePath = null;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                File.WriteAllBytes(@filePath, Ax.SIS.PD.UI.Properties.Resources.LED매칭일괄등록);
                MsgCodeBox.Show("CD00-0009");
            }
            else
            {
                return;
            }


        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void change_AlccdBox()
        {
            try
            {
                //조회 및 개별 등록
                if (this.tab_tabPage2.SelectedIndex == 0)
                {
                    if (cdx01_VINCD.GetValue().ToString().Equals(""))
                    {
                        txt01_ALCCD.Visible = true;
                        cbl01_ALCCD.Visible = false;
                        txt01_ALCCD.Value = "";
                        cbl01_ALCCD.Text = "";
                    }
                    else
                    {
                        txt01_ALCCD.Visible = false;
                        cbl01_ALCCD.Visible = true;
                        txt01_ALCCD.Value = "";
                        cbl01_ALCCD.Text = "";
                    }
                }
                //일괄등록
                else
                {
                    if (cdx02_VINCD.GetValue().ToString().Equals(""))
                    {
                        txt02_ALCCD.Visible = true;
                        cbl02_ALCCD.Visible = false;
                        txt02_ALCCD.Value = "";
                        cbl02_ALCCD.Text = "";
                    }
                    else
                    {
                        txt02_ALCCD.Visible = false;
                        cbl02_ALCCD.Visible = true;
                        txt02_ALCCD.Value = "";
                        cbl02_ALCCD.Text = "";
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source != null && source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 데이터가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow row = source.Tables[0].Rows[i];
                    DataRow seq = source.Tables[1].Rows[i];

                    if (this.Nvl(row["ALCCD"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {ALCCD}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0007", i.ToString(), this.grd01.Cols[0].Caption.ToString());
                        return false;
                    }

                    if (this.Nvl(row["PARTNO"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 {PARTNO}가 선택되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("PD00-0007", i.ToString(), this.grd01.Cols[1].Caption.ToString());
                        return false;
                    }
                    row["LEDCD"] = (row["LEDCD"].ToString() == "0" ? null : row["LEDCD"]);
                }

                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                    //MsgBox.Show("삭제할 데이터가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        






    }
}
