#region ▶ Description & History
/* 
* 프로그램명 : PD20165 차종별 사양표 공정 관리
* 설     명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
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
    public partial class PD20165 : AxCommonBaseControl
    {
        //private IPD20165 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20165";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        //private IPDCOMMON_ERM _WSCOM_ERM;

        #region [ 초기화 작업 정의 ]

        public PD20165()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20165>("PD", "PD20165.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
           // _WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region grd01
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.EnabledActionFlag = false;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "공정순서", "PROC_SEQ", "PROC_SEQ");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "공정코드", "PROCCD", "PROCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "공정명", "PROCNM", "PROCNM");

                this.grd01.AllowMerging = AllowMergingEnum.Free;
                this.grd01.Cols[0].Visible = false;
              

                #endregion
                // a.CORCD, a.ET_SPECCD,b.ET_GRPCD, c.ET_GRPNM, a.ET_POS, b.ET_DESC, a.PROCD 
                #region grd02

                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.ClipSeparators = ";" + "\r";
                this.grd02.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Column;
                this.grd02.EnabledActionFlag = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "통전사양", "ET_SPECCD", "ET_SPECCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "번호", "ET_POS", "ET_POS");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "통전그룹코드", "ET_GRPCD", "ET_GRPCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "통전그룹", "ET_GRPNM", "ET_GRPNM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "통전상세코드", "ET_DTLCD", "ET_DTLCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "통전상세", "ET_DESC", "ET_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "공정코드", "PROCCD", "PROCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "공정명", "PROCNM", "PROCNM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "차종", "VINCD", "VINCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "법인", "CORCD", "CORCD");

                this.grd02.Cols.Frozen = this.grd02.Cols["ET_DESC"].Index;

                this.grd02.AllowMerging = AllowMergingEnum.Free;
                this.grd02.Cols["ET_GRPNM"].AllowMerging = true;

                this.grd02.Cols[0].Visible = false;

                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);

                #endregion

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PRDT_DIV", "A0A");
                set.Add("LANG_SET", this.UserInfo.Language);
                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];
                //DataTable source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST().Tables[0];
                DataTable source3 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0];
                //DataTable source3 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];

                this.cbl02_INSTALL_POS.DataBind(source2, this.GetLabel("POSCD") + ";" + this.GetLabel("POSCD_NM"), "C;L");  //위치코드;위치명
                this.cbl01_LINECD.DataBind(source3, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        

        

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd02.Rows.Count < 2) return;
                
                DataSet set = this.grd02.GetValue(AxFlexGrid.FActionType.All,
                    "CORCD", "VINCD", "ET_SPECCD", "ET_POS","PROCCD", "BIZCD","EMPNO");
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    row["BIZCD"] = this.UserInfo.BusinessCode;
                    row["EMPNO"] = this.UserInfo.EmpNo;
                }


                this.BeforeInvokeServer(true);
//                _WSCOM.SAVE(cbo01_BIZCD.GetValue().ToString(), set);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_INSERT"), set);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.cbo01_BIZCD.GetValue().ToString());
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();
                this.BtnQuery_Click(null, null);
                //MsgBox.Show("입력하신 통전검사사양에 공정을 저장하였습니다.");
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (this.cbl01_LINECD.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("{라인}을 선택하세요");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LINE"));
                    return;
                }
                if (this.cbl02_INSTALL_POS.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("{장착위치}를 선택하세요");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("POSTITLE"));
                    return;
                }

                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl02_INSTALL_POS.GetValue());

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set1.Add("LINECD", this.cbl01_LINECD.GetValue());

                this.BeforeInvokeServer(true);
                //DataTable source = _WSCOM.INQUERY_VINCD(this.cbo01_BIZCD.GetValue().ToString(), set1).Tables[0];
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_VINCD"), set1, "OUT_CURSOR").Tables[0];

                this.AfterInvokeServer();

                this.grd01.SetValue(source);
                
                DispETDRadio();
                //this.Inquery_Grd02(source.Tables[0]);
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
                string bizcd = this.UserInfo.BusinessCode;
                DataSet set = this.GetDataSourceSchema("VINCD", "ET_SPECCD", "BIZCD");
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    row["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!this.IsRemoveValid()) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.UserInfo.BusinessCode, set);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE_DATA"), set);

                this.AfterInvokeServer();

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

        void rdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string speccd = ((RadioButton)sender).Text;


                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", speccd);

                this.BeforeInvokeServer(true);
                //DataTable source1 = _WSCOM.INQUERY(this.cbo01_BIZCD.GetValue().ToString(), set).Tables[0];
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR").Tables[0];
                this.AfterInvokeServer();

                this.grd02.SetValue(source1);
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                throw ex;
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
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set.Add("PRDT_DIV", "A0A");
            set.Add("LANG_SET", this.UserInfo.Language);
            HEParameterSet set2 = new HEParameterSet();
            set2.Add("LANG_SET", this.UserInfo.Language);
            DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];
            //DataTable source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST().Tables[0];
            DataTable source3 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0];
            //DataTable source3 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0];

            this.cbl02_INSTALL_POS.DataBind(source2, this.GetLabel("POSCD") + ";" + this.GetLabel("POSCD_NM"), "C;L");  //위치코드;위치명
            this.cbl01_LINECD.DataBind(source3, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");    //라인코드;라인명
        }

        private void heButton1_Click(object sender, EventArgs e)
        {
            if (grd01.Row < 1)
            {
                //MsgBox.Show("공정정보가 잘못선택되었습니다.");
                MsgCodeBox.Show("PD00-0032");
                return;
            }
            if (grd02.Row < 1)
            {
                //MsgBox.Show("복사대상의 그리드 선택이 잘못되었습니다.");
                MsgCodeBox.Show("PD00-0033");
                return;
            }

            grd02.Rows[grd02.Row]["PROCCD"] = grd01.Rows[grd01.Row]["PROCCD"];
            grd02.Rows[grd02.Row]["PROCNM"] = grd01.Rows[grd01.Row]["PROCNM"];
        }

        private void btn02_BUP_Click(object sender, EventArgs e)
        {
            if (grd01.Row < 1)
            {
                //MsgBox.Show("공정정보가 잘못선택되었습니다.");
                MsgCodeBox.Show("PD00-0032");
                return;
            }
            for (int row = 1; row < grd02.Rows.Count; row++)
            {
                grd02.Rows[row]["PROCCD"] = grd01.Rows[grd01.Row]["PROCCD"];
                grd02.Rows[row]["PROCNM"] = grd01.Rows[grd01.Row]["PROCNM"];
            }
        }

        private void heButton2_Click(object sender, EventArgs e)
        {
            if (grd02.Row < 1)
            {
                //MsgBox.Show("삭제대상의 그리드 선택이 잘못되었습니다.");
                MsgCodeBox.Show("PD00-0034");
                return;
            }
            grd02.Rows[grd02.Row]["PROCCD"] = "";
            grd02.Rows[grd02.Row]["PROCNM"] = "";
        }

        private void heButton3_Click(object sender, EventArgs e)
        {
            for (int row = 1; row < grd02.Rows.Count; row++)
            {
                grd02.Rows[row]["PROCCD"] = "";
                grd02.Rows[row]["PROCNM"] = "";
            }
        }
        
        #endregion

        #region [사용자 정의 메서드]

        private DataTable InsertExcelData(string filePath)
        {
            DataTable excelTable = new DataTable();
            excelTable.TableName = "EXCELTABLE";

            string strQuery = "SELECT '1000' as CORCD";
            strQuery += ",[완제품 P/NO] as PARTNO";
            strQuery += ",[통전사양코드] as ET_SPECCD";
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
                MessageBox.Show(ex.Message, "ERROR!");
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

        private void DispETDRadio()
        {
            flowLayoutPanel1.Controls.Clear();
            
            HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl02_INSTALL_POS.GetValue());

                DataTable dt2 = (DataTable)grd02.DataSource;
                if (dt2 != null)
                {
                    dt2.Rows.Clear();
                    grd02.DataSource = dt2;
                }
            //DataTable dt = _WSCOM.INQUERY_COMBO_ET_SPECCD(cbo01_BIZCD.GetValue().ToString(), set).Tables[0];
                DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMBO_ET_SPECCD"), set, "OUT_CURSOR").Tables[0];

            for (int row = 0; row<dt.Rows.Count; row++)
            {
                RadioButton rdBtn = new RadioButton();
                rdBtn.Appearance = Appearance.Button;
                rdBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                rdBtn.Text = dt.Rows[row]["ET_SPECCD"].ToString();
                rdBtn.Name = "rdBtn" + row.ToString();
                rdBtn.Width = 70;
                flowLayoutPanel1.Controls.Add(rdBtn);
                rdBtn.Click += new EventHandler(rdBtn_Click);
            }
            
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet set)
        {
            
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
            //if (MsgBox.Show("선택하신 차종별 사용표 관리 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //삭제하시겠습니까?
            if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        #endregion
             
    }
}
