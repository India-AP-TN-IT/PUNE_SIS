#region ▶ Description & History
/* 
* 프로그램명 : PD20160 차종별 사양표 관리 및 완제품 통전 사양 관리
* 설     명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
*				2019-04~29   KIM.JB      Modified for India Anantapur
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    
    /// <summary>
    /// 차종별 사양표 관리 및 완제품 통전 사양 관리
    /// </summary>
    public partial class PD20160 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20160";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        #region [ 초기화 작업 정의 ]

        public PD20160()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                #region grd01
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.EnabledActionFlag = false;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "번호", "ET_POS", "ET_POS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "통전그룹코드", "ET_GRPCD", "ET_GRPCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "통전그룹", "ET_GRPNM", "ET_GRPNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "통전상세코드", "ET_DTLCD", "ET_DTLCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "통전상세", "ET_DESC", "ET_DESC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "선택", "SEL_CHECK", "CHK");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "SEL_CHECK");

                this.grd01.AllowMerging = AllowMergingEnum.Free;
                this.grd01.Cols["ET_GRPNM"].AllowMerging = true;

                this.grd01.Cols[0].Visible = false;

                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);

                //전체선택 체크박스 추가. 2013.10.28 (배명희)
                CellStyle cs= this.grd01.Styles.Add("Boolean");
                cs.DataType = typeof(Boolean);
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                this.grd01.SetCellStyle(0, this.grd01.Cols[ "SEL_CHECK"].Index, cs); 


                #endregion

                #region grd02

                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.ClipSeparators = ";" + "\r";
                this.grd02.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Column;
                this.grd02.EnabledActionFlag = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "번호", "ET_POS", "ET_POS");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "통전그룹코드", "ET_GRPCD", "ET_GRPCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "통전그룹", "ET_GRPNM", "ET_GRPNM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "통전상세코드", "ET_DTLCD", "ET_DTLCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "통전상세", "ET_DESC", "ET_DESC");

                this.grd02.Cols.Frozen = this.grd02.Cols["ET_DESC"].Index;

                this.grd02.AllowMerging = AllowMergingEnum.Free;
                this.grd02.Cols["ET_GRPNM"].AllowMerging = true;

                this.grd02.Cols[0].Visible = false;

                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);

                #endregion

                #region grd03

                this.grd03.Initialize();
                //this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowFiltering = true;
                //this.grd03.EnabledActionFlag = false;

                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "법인코드", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "회사코드", "BIZCD", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "ALC", "ALCCD", "ALCCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "완제품 P/NO", "PARTNO", "PARTNO");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 180, "통전사양코드", "ET_SPECCD", "ET_SPECCD");

                //this.grd03.Cols[0].Visible = false;

                this.grd03.CurrentContextMenu.Items.RemoveAt(0);
                this.grd03.CurrentContextMenu.Items.RemoveAt(0);
                this.grd03.CurrentContextMenu.Items.RemoveAt(0);
                this.grd03.CurrentContextMenu.Items.RemoveAt(0);

                #endregion

                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("OBJECTCD", "VINCD");
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_OBJECT"), set).Tables[0];
                this.cbl01_VINCD.DataBind(source, this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L");    //차종코드;차종명

                set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("OBJECTCD", "ITEMCD");
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_OBJECT"), set).Tables[0];
                this.cbl01_ITEMCD.DataBind(source, this.GetLabel("ITEMCD") + ";" + this.GetLabel("ITEMNM"), "C;L");  //ITEM코드;ITEM명

                set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set).Tables[0];
                this.cbl02_INSTALL_POS.DataBind(source, this.GetLabel("POSCD") + ";" + this.GetLabel("POSCD_NM"), "C;L");  //위치코드;위치명

                this.SetRequired(lbl02_VEHICLE, lbl01_ITEM, lbl03_ET_SPECCD, lbl04_POSTITLE);
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
                if (this.cbl01_VINCD.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("{차종}을 선택하세요");
                    //{0}이(가) 선택되지 않았습니다.
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("VEHICLE"));
                    return;
                }

                if (this.cbl01_ITEMCD.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("{차종}을 선택하세요");
                    //{0}이(가) 선택되지 않았습니다.
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("ITEMCD"));
                    return;
                }

                this.grd01.SetValue(0, "SEL_CHECK", "0");   //전체선택 체크박스 해제 2013.10.28(배명희)

                this.grd03.InitializeDataSource();

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("VINCD", this.cbl01_VINCD.GetValue());
                set.Add("ITEMCD", this.cbl01_ITEMCD.GetValue());
                set.Add("ET_SPECCD", this.txt01_ET_SPECCD.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_VINCD"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                this.Inquery_Grd02(source.Tables[0]);
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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                    "CORCD", "VINCD", "ITEMCD", "ET_SPECCD", "ET_POS", "SEL_CHECK","BIZCD");

                foreach (DataRow row in set.Tables[0].Rows)
                {
                    row["CORCD"] = this.UserInfo.CorporationCode;
                    row["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                    row["VINCD"] = this.cbl01_VINCD.GetValue().ToString();
                    row["ITEMCD"] = this.cbl01_ITEMCD.GetValue().ToString();
                    row["ET_POS"] = row["ET_POS"].ToString();
                    row["ET_SPECCD"] = this.txt01_ET_SPECCD.GetValue().ToString();
                }

                for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
                {
                    if (set.Tables[0].Rows[i]["SEL_CHECK"].ToString().Equals("N"))
                        set.Tables[0].Rows.RemoveAt(i);
                }

                set.Tables[0].Columns.Remove("SEL_CHECK");

                if (!this.IsSaveValid(set)) return;

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DELETE_ET_SPECCD"), set);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "INSERT_ET_SPECCD"), set);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                //MsgBox.Show("입력하신 차종별 사용표 정보를 저장하였습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string corcd = this.UserInfo.CorporationCode;
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                DataSet set = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "VINCD", "ITEMCD", "ET_SPECCD", "ET_POS");

                set.Tables[0].Rows.Add(corcd, bizcd, this.cbl01_VINCD.GetValue(), this.cbl01_ITEMCD.GetValue(), this.txt01_ET_SPECCD.Text, "");

                if (!this.IsRemoveValid()) return;

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DELETE_ET_SPECCD", "ET_POS"), set);

                this.AfterInvokeServer();

                this.txt01_ET_SPECCD.Initialize();
                this.BtnQuery_Click(null, null);
                //MsgBox.Show("선택하신 차종별 사용표 정보를 삭제하였습니다.");
                //삭제되었습니다.
                MsgCodeBox.Show("CD00-0072");
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

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int col = this.grd02.ColSel;

                if(col <= this.grd02.Cols["ET_DESC"].Index) return;

                string col_name = this.grd02.Cols[col].Caption;

                this.txt01_ET_SPECCD.SetValue(col_name);

                this.BtnQuery_Click(null, null);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_VINCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD ", bizcd);
                set.Add("VINCD", this.cbl01_VINCD.GetValue().ToString());

                if (string.IsNullOrEmpty(this.cbl01_ITEMCD.GetValue().ToString()) == false)
                {
                    set.Add("ITEMCD", this.cbl01_ITEMCD.GetValue().ToString());

                    DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_ET_SPECCD"), set, "OUT_CURSOR").Tables[0];

                    this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "ET_SPECCD");

                    this.BtnQuery_Click(null, null);
                }
                this.cbl01_VINCD.Focus();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_INQ_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbl02_INSTALL_POS.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("{장착위치}를 선택하세요");
                    //{0}이(가) 선택되지 않았습니다.
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("POSTITLE"));
                    return;
                }

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue().ToString());
                set.Add("VINCD", this.cbl01_VINCD.GetValue());
                set.Add("ITEMCD", this.cbl01_ITEMCD.GetValue());
                set.Add("INSTALL_POS", this.cbl02_INSTALL_POS.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PARTNO"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd03.SetValue(source.Tables[0]);
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

        private void btn02_SAV_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsSavePartnoValid()) return;

                DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "PARTNO", "ET_SPECCD");

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "INSERT_PARTNO"), source);

                this.AfterInvokeServer();

                this.btn02_INQ_Click(null, null);

                //MsgBox.Show("입력하신 완제품 통전 사양관리 정보가 저장되었습니다.");
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
        
        private void btn02_BUP_Click(object sender, EventArgs e)
        {
            try
            {

                string path = ReadExcelFile();
                if (string.IsNullOrEmpty(path)) return;

                DataTable dt = InsertExcelData(path);
                if (dt.Rows.Count <= 0) return;
                if (!IsSavePartnoValid()) return;

                this.BeforeInvokeServer(true);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_PARTNO"), ds);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "INSERT_PARTNO_BATCH"), ds);

                this.AfterInvokeServer();

                this.btn02_INQ_Click(null, null);

                //MsgBox.Show("입력하신 완제품 통전 사양관리 정보가 저장되었습니다.");
                //저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
            }
            catch (Exception eLog)
            {
                this.AfterInvokeServer();
                MessageBox.Show(eLog.Message, "error");
            }
            finally
            {
                this.AfterInvokeServer();
            }

        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            //전체선택 체크박스 선택시 해당 선택값에 따라 모든 체크박스 업데이트 2013.10.28 (배명희)
            if (this.grd01.MouseRow == 0)
            {
                string val = this.grd01.GetValue(0, "SEL_CHECK").ToString();
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01.SetValue(i, "SEL_CHECK", val == "Y" ? "1" : "0");
                }
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("LANG_SET", this.UserInfo.Language);
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_CARTYPE"), set).Tables[0];

            HEParameterSet set2 = new HEParameterSet();
            set2.Add("LANG_SET", this.UserInfo.Language);
            DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];

            this.cbl01_VINCD.DataBind(source1, this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L");   //차종코드;차종명
            this.cbl02_INSTALL_POS.DataBind(source2, this.GetLabel("POSCD") + ";" + this.GetLabel("POSCD_NM"), "C;L");  //위치코드;위치명
        }
        
        #endregion

        #region [사용자 정의 메서드]

        private DataTable InsertExcelData(string filePath)
        {
            DataTable excelTable = new DataTable();
            excelTable.TableName = "EXCELTABLE";

            string strQuery = "SELECT '" + this.UserInfo.CorporationCode + "' as CORCD,'" + cbo01_BIZCD.GetValue().ToString() + "' AS BIZCD";
            strQuery += ",[PART NO] as PARTNO";
            strQuery += ",[SPEC CODE] as ET_SPECCD";
            strQuery += " FROM [SHEET1$]";

            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"{0}\";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"", filePath);

            System.Data.OleDb.OleDbConnection connection = null;
            System.Data.OleDb.OleDbDataAdapter adapter = null;

            try
            {
                connection = new System.Data.OleDb.OleDbConnection(connectionString);
                connection.Open();


                adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, connection);
                adapter.Fill(excelTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }
            finally
            {

                connection.Close();
                connection.Dispose();
            }
            return excelTable;
        }
        
        private string ReadExcelFile()
        {
            string strFilePath = string.Empty;
            string strFileName = string.Empty;

            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Excel (*.xls)|*.xls";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK && fileDialog.OpenFile() != null)
            {
                strFilePath = fileDialog.FileName;
                strFileName = fileDialog.SafeFileName;
            }
            else
            {
                return string.Empty;
            }

            return strFilePath;
        }
                
        private void Inquery_Grd02(DataTable source)
        {
            try
            {
                this.grd02.Rows.Count = 1;
                this.grd02.Cols.Count = 6;

                for (int i = 0; i < source.Rows.Count; i++)
                {
                    DataRow row = source.Rows[i];

                    this.grd02.AddItem(string.Format("{0};{1};{2};{3};{4};{5}", i+1, row["ET_POS"], row["ET_GRPCD"], row["ET_GRPNM"], row["ET_DTLCD"], row["ET_DESC"]));
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("VINCD", this.cbl01_VINCD.GetValue());
                set.Add("ITEMCD", this.cbl01_ITEMCD.GetValue());

                DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR").Tables[0];

                this.grd02.Cols.Count = 6;

                string strEtSpecCd = "";
                int iRow = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow oRow = dt.Rows[i];

                    //통전 사양 코드가 틀리면 Grid Column 추가
                    if (!strEtSpecCd.Equals(oRow["ET_SPECCD"].ToString()))
                    {
                        strEtSpecCd = oRow["ET_SPECCD"].ToString();

                        this.grd02.Cols.Count++;

                        this.grd02.Cols[this.grd02.Cols.Count - 1].AllowEditing = false;
                        this.grd02.Rows[0].AllowMerging = true;
                        this.grd02.Cols[this.grd02.Cols.Count - 1].TextAlign = TextAlignEnum.CenterCenter;
                        this.grd02.Cols[this.grd02.Cols.Count - 1].TextAlignFixed = TextAlignEnum.CenterCenter;
                        this.grd02.Cols[this.grd02.Cols.Count - 1].DataType = typeof(bool);

                        this.grd02.SetValue(0, this.grd02.Cols.Count - 1, strEtSpecCd);

                        iRow = 1;
                    }

                    string strEtPos = oRow["ET_POS"].ToString();

                    for (int j = iRow; j < this.grd02.Rows.Count; j++)
                    {
                        if (this.grd02.GetValue(j, 1).ToString().Equals(strEtPos))
                        {
                            this.grd02.SetValue(j, this.grd02.Cols.Count - 1, 1);

                            //다음 찾을 ROW
                            iRow = j + 1;
                            break;
                        }
                        else
                        {
                            this.grd02.SetValue(j, this.grd02.Cols.Count - 1, 0);
                        }
                    }
                }
                this.grd02.AutoSizeCols();
            
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet set)
        {
            if (this.txt01_ET_SPECCD.GetValue().ToString().Length == 0)
            {
                //MsgBox.Show("{사양코드}를 입력/선택 하세요.");
                //{0}이(가) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("ET_SPECCD"));
                return false;
            }

            if (set.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("저장할 차종별 사용표 관리 정보가 없습니다.");
                //저장할 데이터가 존재하지 않습니다.
                MsgCodeBox.Show("CD00-0042");
                return false;
            }

            //if (MsgBox.Show("입력하신 차종별 사용표 관리 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //저장하시겠습니까?
            if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private bool IsSavePartnoValid()
        {
            //if (MsgBox.Show("입력하신 완제품 통전 사양관리 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //저장하시겠습니까?
            if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private bool IsRemoveValid()
        {
            if (string.IsNullOrEmpty(this.cbl01_VINCD.GetValue().ToString()) == true)
            {
                //MsgBox.Show("저장할 차종별 사용표 관리 정보가 없습니다.");
                //저장할 데이터가 존재하지 않습니다.
                MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("VINCD"));
                return false;
            }

            if (string.IsNullOrEmpty(this.cbl01_ITEMCD.GetValue().ToString()) == true)
            {
                //MsgBox.Show("저장할 차종별 사용표 관리 정보가 없습니다.");
                //저장할 데이터가 존재하지 않습니다.
                MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("ITEM"));
                return false;
            }

            if (this.txt01_ET_SPECCD.GetValue().ToString().Length == 0)
            {
                //MsgBox.Show("{사양코드}를 입력/선택 하세요.");
                //{0}이(가) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("PD00-0009", this.GetLabel("ET_SPECCD"));
                return false;
            }



            //if (MsgBox.Show("선택하신 차종별 사용표 관리 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //삭제하시겠습니까?
            if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        #endregion

        private void cbl01_ITEMCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD ", bizcd);
                

                if (string.IsNullOrEmpty(this.cbl01_VINCD.GetValue().ToString()) == false)
                {
                    set.Add("VINCD", this.cbl01_VINCD.GetValue().ToString());
                    set.Add("ITEMCD", this.cbl01_ITEMCD.GetValue().ToString());

                    DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_ET_SPECCD"), set, "OUT_CURSOR").Tables[0];

                    this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "ET_SPECCD");

                    this.BtnQuery_Click(null, null);
                }
                this.cbl01_ITEMCD.Focus(); 
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
   
    }
}
