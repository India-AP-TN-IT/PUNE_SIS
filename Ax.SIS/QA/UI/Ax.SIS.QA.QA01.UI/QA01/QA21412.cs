#region ▶ Description & History
/* 
 * 프로그램명 : 판매대수관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-08-19      배명희      신규 생성
 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.IO;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.Data.OleDb;
using System.Text;

namespace Ax.SIS.QA.QA01.UI
{
    
    public partial class QA21412 : AxCommonBaseControl
    {
        #region [필드에 대한 정의]

        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA21412";

        #endregion
        
        #region [생성자에 대한 정의]

        public QA21412()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();           
        }

        #endregion

        #region [초기화 작업에 대한 정의]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox3.Text = this.GetLabel("QA21412_MSG1");
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], true);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo02_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                                
                //if (this.UserInfo.IsAdmin == "Y")
                //{
                //    this.cbo01_BIZCD.Enabled = true;
                //    this.cbo02_BIZCD.Enabled = true;
                //}
                //else
                //{
                //    this.cbo01_BIZCD.Enabled = false;
                //    this.cbo02_BIZCD.Enabled = false;
                //}

                this.nme02_SAL_QTY.DataType = typeof(int);
                this.nme02_SAL_QTY.NullText = "";                
                this.nme02_SAL_QTY.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_SAL_QTY.DisplayFormat.CustomFormat = "#,###,###,###";
                this.nme02_SAL_QTY.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat;
                this.nme02_SAL_QTY.EditFormat.CustomFormat = "#,###,###,###";
                
                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "판매년월", "SAL_MONTH", "SAL_MONTH");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산처", "PROD_CUST2", "PROD_CUST2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "차종", "VIN", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "판매대수", "SAL_QTY2", "SAL_QTY2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "최종수정자", "NAME_KOR", "NAME_KOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "최종수정일시", "UPDATE_DATE", "UPDATE_DATE");

                this.grd01.Cols["BIZCD"].TextAlign = TextAlignEnum.CenterCenter;                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");

                this.SetBindComboBox01();
                this.SetBindComboBox02();
              
                this.SetRequired(lbl02_BIZNM, lbl02_SAL_MONTH, lbl02_PROD_CUST2, lbl02_VIN, lbl02_SAL_QTY2);
                          
                this.BtnQuery_Click(null, null);

                this.cbo01_BIZCD.SelectedValueChanged += new EventHandler(cbo01_BIZCD_SelectedValueChanged);
                this.cbo02_BIZCD.SelectedValueChanged += new EventHandler(cbo02_BIZCD_SelectedValueChanged);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
               
                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string CUST_PLANT = this.cbo01_PROD_CUST.GetValue().ToString();
                string SAL_MONTH = this.dte01_SAL_MONTH.GetDateText().Substring(0,7);
                string PROD_CUST = this.cbo01_PROD_CUST.GetValue().ToString();
                string VINCD = this.cbo01_VINCD.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("SAL_MONTH", SAL_MONTH);
                paramSet.Add("PROD_CUST", PROD_CUST);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

                this.grd01.SetValue(source);

                this.BtnReset_Click(null, null);    
                
                
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
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.dte02_SAL_MONTH.Initialize();
                this.cbo02_PROD_CUST.SelectedIndex = -1;
                this.cbo02_VINCD.SelectedIndex = -1;
                this.nme02_SAL_QTY.Initialize();

                this.grd01.Row = -1;
                //if (this.UserInfo.IsAdmin == "Y")
                //{
                //    this.cbo02_BIZCD.Enabled = true;
                //}
                //else
                //{
                //    this.cbo02_BIZCD.Enabled = false;
                //}             
             
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
                
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            { 
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                paramSet.Add("SAL_MONTH", this.dte02_SAL_MONTH.GetDateText().Substring(0,7));
                paramSet.Add("PROD_CUST", this.cbo02_PROD_CUST.GetValue());
                paramSet.Add("VINCD", this.cbo02_VINCD.GetValue()); 
                paramSet.Add("SAL_QTY", this.nme02_SAL_QTY.GetDBValue());
                paramSet.Add("REMARK", this.txt02_REMARK.GetValue());
                paramSet.Add("USERID", this.UserInfo.EmpNo);

             
                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), paramSet);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("판매 대수 정보가 저장되었습니다.");
                MsgCodeBox.Show("QA01-0016");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }            
        }

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "SAL_MONTH", "PROD_CUST", "VINCD");
                source.Tables[0].Rows.Add(
                    this.UserInfo.CorporationCode,
                    this.cbo02_BIZCD.GetValue(),
                    this.dte02_SAL_MONTH.GetDateText().Substring(0,7),
                    this.cbo02_PROD_CUST.GetValue(),
                    this.cbo02_VINCD.GetValue()
                );

                if (!IsDeleteValid()) return;

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);

                this.AfterInvokeServer();

                //MsgBox.Show("판매대수 정보가 삭제 되었습니다.");
                MsgCodeBox.Show("QA01-0017");

                this.BtnQuery_Click(null, null);
               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }            
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int rowidx = this.grd01.MouseRow;

                
                if (rowidx >= this.grd01.Rows.Fixed && rowidx< this.grd01.Rows.Count)
                {
                    this.SelectGridRow(rowidx);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SetBindComboBox01();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo02_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.SetBindComboBox02();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        #endregion

        #region [사용자 정의 메서드]
        /// <summary>
        /// 하단 입력 컨트롤에 현재 선택된 그리드 행의 판매대수 정보를 표시한다.
        /// </summary>
        /// <param name="rowIdx">현재 선택된 그리드 행의 인덱스(행번호)</param>
        private void SelectGridRow(int rowIdx)
        {
            try
            {
             

                string BIZCD = this.grd01.GetValue(rowIdx, "BIZCD").ToString();
                string SAL_MONTH = this.grd01.GetValue(rowIdx, "SAL_MONTH").ToString();
                string PROD_CUST = this.grd01.GetValue(rowIdx, "PROD_CUST2").ToString();
                string VINCD = this.grd01.GetValue(rowIdx, "VIN").ToString();
                string SAL_QTY = this.grd01.GetValue(rowIdx, "SAL_QTY2").ToString();
                string REMARK = this.grd01.GetValue(rowIdx, "REMARK").ToString();

                this.cbo02_BIZCD.SetValue(BIZCD);
                this.dte02_SAL_MONTH.SetValue(SAL_MONTH + "-01");
                this.cbo02_PROD_CUST.SetValue(PROD_CUST);
                this.cbo02_VINCD.SetValue(VINCD);
                this.nme02_SAL_QTY.SetValue(SAL_QTY);
                this.txt02_REMARK.SetValue(REMARK);

                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 사업장코드 변경시 해당 bizcd에 따른 콤보상자 재바인딩 처리.
        /// </summary>
        private void SetBindComboBox01()
        {
            try
            {

                DataSet source = this.GetProdCust();
                this.cbo01_PROD_CUST.DataBind(source.Tables[0], true);
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "PROD_CUST2");

                source = this.GetVinCd();
                this.cbo01_VINCD.DataBind(source.Tables[0], true);
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "VIN");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 사업장코드 변경시 해당 bizcd에 따른 콤보상자 재바인딩 처리.
        /// </summary>
        private void SetBindComboBox02()
        {
            try
            {

                DataSet source = this.GetProdCust();
                this.cbo02_PROD_CUST.DataBind(source.Tables[0], false);
              
                source = this.GetVinCd();
                this.cbo02_VINCD.DataBind(source.Tables[0], false);
               

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 생산처 콤보상자용 데이터 조회
        /// </summary>
        /// <returns></returns>
        private DataSet GetProdCust()
        {
            HEParameterSet param = new HEParameterSet();            
            param.Add("CORCD", this.UserInfo.CorporationCode);
            param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            param.Add("LANG_SET", this.UserInfo.Language);
            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_PROD_CUST"), param);
        }

        /// <summary>
        /// 차종 콤보상자용 데이터조회
        /// </summary>
        /// <returns></returns>
        private DataSet GetVinCd()
        {
            HEParameterSet param = new HEParameterSet();
            param.Add("CORCD", this.UserInfo.CorporationCode);
            param.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            param.Add("LANG_SET", this.UserInfo.Language);
            return _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_VINCD"), param);
        }


        private void btn01_FILE_UPLOAD_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = this.txt01_EXCEL.GetValue().ToString();

                string[] FileNames = filename.Split('.');
                int EndFile = FileNames.Length - 1;

                StringBuilder connectionString = new StringBuilder();

                string FType = filename.Substring(filename.LastIndexOf(".") + 1).ToUpper();
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

                //if (MsgBox.Show("일클레임자료를 업로드하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                if (MsgCodeBox.Show("QA01-0040", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                connectionString.AppendFormat(@"Data Source={0}", filename);

                OleDbConnection oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();


                DataTable worksheets = oleDB.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string temp = "";
                for (int i = this.grd02.Cols.Fixed; i < this.grd02.Cols.Count; i++)
                {
                    if (!this.grd02.Cols[i].Name.Equals(string.Empty))
                    {
                        temp += " TRIM([" + this.grd02.Cols[i].Caption + "])  AS " + this.grd02.Cols[i].Name + ",";
                    }
                }

                string commandString = "SELECT " + "'{0}' AS CORCD, '{1}' AS BIZCD," +
                                        " TRIM([판매년월])  AS SAL_MONTH," +
                                        " TRIM([생산처])  AS PROD_CUST," +
                                        " TRIM([차종])  AS VINCD," +
                                        " TRIM([판매대수])  AS SAL_QTY," + 
                                        " '{3}' AS REMARK, '{2}' AS USERID" +
                                        " FROM [" + worksheets.Rows[0]["TABLE_NAME"].ToString() + "] "
                                        ;                        
                commandString = string.Format(commandString, this.UserInfo.CorporationCode, this.cbo02_BIZCD.GetValue(), this.UserInfo.EmpNo,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " EXCEL UPLOAD [USER:" + this.UserInfo.EmpNo +"]");

                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                


                DataSet ds = new DataSet();
                adapter.Fill(ds);
                oleDB.Close();

                if (!IsSaveValid(ds)) return;
                
                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), ds);    

                this.AfterInvokeServer();

                //MsgBox.Show("파일업로드가 완료 되었습니다.");
                MsgCodeBox.Show("QA01-0004");

                this.BtnQuery_Click(null, null);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

        }

        private void btn01_EXCEL_SELECT_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = this.GetSysEnviroment("FILTER", "EXCEL");

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _DOCUMENT = new byte[(int)fs.Length];
                    fs.Read(_DOCUMENT, 0, _DOCUMENT.Length);
                    fs.Close();

                    this.txt01_EXCEL.SetValue(fs.Name);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void btn01_EXCEL_DOWN_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "클레임_정보관리_추가사항 양식";
                saveFileDialog.DefaultExt = "xlsx";                
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files  (*.xls)|*.xls|All files (*.*)|*.*";

                string filePath = null;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    File.WriteAllBytes(@filePath, Properties.Resources._161005_클레임_정보관리_추가사항);
                    //MessageBox.Show("양식이 정상적으로 저장되었습니다.");
                    MsgCodeBox.Show("CD00-0107");
                }
                else
                {
                    return;
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

 

        #endregion

        #region [유효성 검사]

        /// <summary>
        /// 저장시 엑셀 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool IsSaveValid(DataSet source)
        {
            try
            {
                AxFlexGrid commgrid = new AxFlexGrid();
                if (source.Tables[0].Rows.Count == 0)
                {
                    MsgCodeBox.Show("CD00-0108"); //저장할 그리드 컬럼 정보가 존재하지 않습니다.
                    return false;
                }

                bool check = true;
                string caption = string.Empty;
                int seq = 2;
                foreach (DataRow row in source.Tables[0].Rows)
                {                    

                    if (this.GetByteCount(row["BIZCD"].ToString())  == 0)
                    {
                        check = false;
                        caption = "BIZCD";
                    }

                    if (this.GetByteCount(row["SAL_MONTH"].ToString()) == 0)
                    {
                        check = false;
                        caption = "SAL_MONTH";
                    }

                    else if (this.GetByteCount(row["PROD_CUST"].ToString()) == 0)
                    {
                        check = false;
                        caption = "PROD_CUST2";
                    }

                    else if (this.GetByteCount(row["VINCD"].ToString()) == 0)
                    {
                        check = false;
                        caption = "VIN";
                    }

                    else if (this.GetByteCount(row["SAL_QTY"].ToString()) == 0 || row["SAL_QTY"].ToString() == "0")
                    {
                        check = false;
                        caption = "SAL_QTY2";
                    }
              
                    if (check == false)
                    {
                        this.AfterInvokeServer();
                        MsgCodeBox.ShowFormat("CD00-0091", seq.ToString(), grd01.GetValue(0, caption)); //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                        return false;
                    }
                    seq++;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// 저장시 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool IsSaveValid()
        {
            try
            {
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string SAL_MONTH = this.dte02_SAL_MONTH.GetDateText().Substring(0,7);
                string PROD_CUST = this.cbo02_PROD_CUST.GetValue().ToString();
                string VINCD = this.cbo02_VINCD.GetValue().ToString();
                string SAL_QTY = this.nme02_SAL_QTY.GetValue().ToString();
                string REMARK = this.txt02_REMARK.GetValue().ToString();

                if (this.GetByteCount(BIZCD) == 0)
                {
                    //MsgBox.Show("사업장코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA01-0013", lbl02_BIZNM.GetValue());
                    this.cbo02_BIZCD.Focus();
                    return false;
                }


                if (this.GetByteCount(SAL_MONTH) == 0)
                {
                    //MsgBox.Show("판매년월 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA01-0013", lbl02_SAL_MONTH.GetValue());
                    this.dte02_SAL_MONTH.Focus();
                    return false;
                }

                if (this.GetByteCount(PROD_CUST) == 0)
                {
                    //MsgBox.Show("생산처 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA01-0013", lbl02_PROD_CUST2.GetValue());
                    this.cbo02_PROD_CUST.Focus();
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA01-0013", lbl02_VIN.GetValue());
                    this.cbo02_VINCD.Focus();
                    return false;
                }

                if (this.GetByteCount(SAL_QTY) == 0 || SAL_QTY == "0")
                {
                    //MsgBox.Show("판매대수 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA01-0013", lbl02_SAL_QTY2.GetValue());
                    this.nme02_SAL_QTY.Focus();
                    return false;
                }

                if (this.GetByteCount(REMARK) > 4000)
                {
                    //MsgBox.Show("비고 데이터는 4000bytes 이하로 입력하여 주세요.");
                    MsgCodeBox.ShowFormat("QA01-0014", lbl02_REMARK.GetValue(), 4000);
                    this.txt02_REMARK.Focus();
                    return false;
                }


                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 삭제시 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool IsDeleteValid()
        {
            try
            {

                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string SAL_MONTH = this.dte02_SAL_MONTH.GetDateText().Substring(0,7);
                string PROD_CUST = this.cbo02_PROD_CUST.GetValue().ToString();
                string VINCD = this.cbo02_VINCD.GetValue().ToString();


                if (this.GetByteCount(BIZCD) == 0)
                {
                    MsgCodeBox.ShowFormat("QA01-0013", lbl02_BIZNM.GetValue());
                    this.cbo02_BIZCD.Focus();
                    return false;
                }

                if (this.GetByteCount(SAL_MONTH) == 0)
                {
                    //MsgBox.Show("삭제할 데이터를 선택 하지 않았습니다.");
                    MsgCodeBox.Show("QA01-0015");
                    this.dte02_SAL_MONTH.Focus();
                    return false;
                }

                if (this.GetByteCount(PROD_CUST) == 0)
                {
                    //MsgBox.Show("삭제할 데이터를 선택 하지 않았습니다.");
                    MsgCodeBox.Show("QA01-0015");
                    this.cbo02_PROD_CUST.Focus();
                    return false;
                }

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("삭제할 데이터를 선택 하지 않았습니다.");
                    MsgCodeBox.Show("QA01-0015");
                    this.cbo02_VINCD.Focus();
                    return false;
                }

                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion
    }
}
