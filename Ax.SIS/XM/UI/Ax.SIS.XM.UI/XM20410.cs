#region ▶ Description & History
/* 
 * 프로그램명 : 사용자별 권한 현황
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-02      배명희      프로그램 아이디 변경(XM60030 -> XM20410)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거     
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;



using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;

namespace Ax.SIS.XM.UI
{
    public partial class XM20410 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20410";

        #region [초기화 설정]

        public XM20410()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                HEParameterSet paramSet_Menu = new HEParameterSet();
                DataSet source_Menu = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MENU"), paramSet_Menu);
                

                cbo01_S_GROUPID.DataBind(source_Menu.Tables[0], false);
                cbo01_GROUPID.DataBind(source_Menu.Tables[0], true, "ALL"); //조회

                SetCategory();

                this.cbo02_CATEGORY.DropDownStyle = ComboBoxStyle.DropDown;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "Doc No.", "DOC_NO", "DOCCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "Group ID", "GROUPID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Group Name", "GROUPNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "Subject", "TITLE", "SUBJECT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "다국어적용여부", "APPLY_LANGUAGE","APPLY_LANGUAGE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Category", "CATEGORY");
                

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "First Inserted ID", "INSERT_ID", "INSERT_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "First Inserted Date", "INSERT_DATE", "INSERT_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Last Updated ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "Last Updated Date", "UPDATE_DATE", "UPDATE_DATE");
                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("GROUPID");
                

                
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;             
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Parameter", "PARAM_NM", "PARAM_NM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "Langguage Code", "LANG_CODE", "LANG_CODE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "Not Null", "IS_VALIDATION", "IS_VALIDATION");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Type", "PARAM_TYPE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Type Code", "COMM_CODE", "COMM_CODE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "Default", "DEFAULT_DATA", "INI_DEFAULT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "Sort", "SORT_SEQ", "SORT_SEQ");                

                this.grd02.AddHiddenColumn("CORCD");
                this.grd02.AddHiddenColumn("DOC_NO");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "IS_VALIDATION");                

                HEParameterSet paramSet = new HEParameterSet();                                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_TYPE"), paramSet);                
                this.grd02.SetColumnType_Original(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "PARAM_TYPE", false);

                this.grd02.RowInserted += new AxFlexGrid.FAlterRowInsertEventHandler(grd02_RowInserted);

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }



        #endregion

        #region [공통 버튼 이벤트]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                InputInit();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("TITLE", this.txt01_TITLE.GetValue());
                paramSet.Add("GROUPID", this.cbo01_GROUPID.GetValue());
                paramSet.Add("CATEGORY", this.cbo01_CATEGORY.GetValue());
                

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                SetCategory();
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
                string doc_no = string.Empty;
                if (string.IsNullOrEmpty(txt01_DOC_NO.GetValue().ToString()))
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DOC_NO"), paramSet);
                    doc_no = source.Tables[0].Rows[0]["DOC_NO"].ToString();
                }
                else doc_no = txt01_DOC_NO.GetValue().ToString();
                
                DataSet save_query = AxFlexGrid.GetDataSourceSchema
                (
                    "CORCD", "DOC_NO", "S_GROUPID", "TITLE", "CLOB$SCRIPT_QUERY", "CLOB$SUB_QUERY", "LINK_COLUMN", "USER_ID", "APPLY_LANGUAGE", "CATEGORY"
                );
                save_query.Tables[0].Rows.Add(UserInfo.CorporationCode, doc_no, cbo01_S_GROUPID.GetValue().ToString(), txt02_TITLE.GetValue().ToString(), txt01_QUERY.GetValue().ToString()
                    , txt02_QUERY.GetValue().ToString(), txt01_LINK_COLUMN.GetValue().ToString()
                    , UserInfo.UserID, chk01_APPLY_LANGUAGE.GetValue()
                    , cbo02_CATEGORY.GetText()
                    );

                if (string.IsNullOrEmpty(txt02_TITLE.GetValue().ToString()))
                {
                    MsgCodeBox.ShowFormat("CD00-0079", lbl02_SUBJECT.Text);
                    return;
                }
                else if (string.IsNullOrEmpty(txt02_QUERY.GetValue().ToString()) != string.IsNullOrEmpty(txt01_LINK_COLUMN.GetValue().ToString()))
                {
                    MsgCodeBox.ShowFormat("CD00-0079", lbl01_LINK_COLUMN.Text);
                    return;
                }

                DataSet save_param = this.grd02.GetValue(AxFlexGrid.FActionType.All, "CORCD", "DOC_NO", "PARAM_NM", "LANG_CODE", "IS_VALIDATION"
                    , "PARAM_TYPE", "COMM_CODE", "DEFAULT_DATA", "SORT_SEQ", "USER_ID");
                for (int i = 0; i < save_param.Tables[0].Rows.Count; i++)
                {
                    DataRow row = save_param.Tables[0].Rows[i];

                    row["CORCD"] = this.UserInfo.CorporationCode;
                    row["USER_ID"] = UserInfo.UserID;
                    row["DOC_NO"] = doc_no;
                }

                if (!IsSaveValid(save_param)) return;

                this.BeforeInvokeServer(true);                

                _WSCOM.MultipleExecuteNonQueryTx(new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_AXD9110"), 
                                                                string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_AXD9120") }, 
                                                 new DataSet[] { save_query, save_param });

                this.AfterInvokeServer();
                MsgCodeBox.Show("CD00-0071");
                BtnQuery_Click(null, null);
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
                DataSet save_query = AxFlexGrid.GetDataSourceSchema
                (
                    "CORCD", "DOC_NO"
                );
                save_query.Tables[0].Rows.Add(UserInfo.CorporationCode, txt01_DOC_NO.GetValue().ToString());

                if (!this.IsRemoveValid(save_query))
                    return;
                
                this.BeforeInvokeServer(true);
                _WSCOM.MultipleExecuteNonQueryTx(new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE") }, new DataSet[] { save_query });

                this.AfterInvokeServer();
                MsgCodeBox.Show("CD00-0072");

                BtnQuery_Click(null, null);
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
            SearchInit();
            InputInit();
        }

        private void InputInit()
        {
            txt01_DOC_NO.Initialize();
            txt01_QUERY.Initialize();
            txt02_QUERY.Initialize();
            txt01_LINK_COLUMN.Initialize();
            txt02_TITLE.Initialize();
            cbo01_S_GROUPID.Initialize();
            chk01_APPLY_LANGUAGE.Checked = true;            
            cbo02_CATEGORY.Initialize();
            this.grd02.InitializeDataSource();                
        }

        private void SearchInit()
        {
            txt01_TITLE.Initialize();
            cbo01_GROUPID.Initialize();
            cbo01_CATEGORY.Initialize();
            this.grd01.InitializeDataSource();
        }

        #endregion

        #region [컨트롤 이벤트]

        private void grd02_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                int tmpCol = e.Col;
                int tmpRow = e.Row;
                if (this.grd02.Cols[e.Col].Name == "PARAM_NM")
                {
                    grd02.SetValue(tmpRow, "LANG_CODE", grd02.GetValue(tmpRow, "PARAM_NM"));
                }
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                
            }
        }

        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.MouseRow;
                int col = this.grd01.MouseCol;
                if (this.grd01.Row > 0
                    && this.grd01.Selection.TopRow == this.grd01.Selection.BottomRow
                    && this.grd01.Selection.LeftCol == this.grd01.Selection.RightCol
                    )
                {
                    if (grd01.MouseRow < grd01.Rows.Fixed || col < 0)
                    {
                        return;
                    }

                    string CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                    string DOC_NO = this.grd01.GetValue(row, "DOC_NO").ToString();
                    string GROUPID = this.grd01.GetValue(row, "GROUPID").ToString();
                    this.Inquery_Detail(CORCD, DOC_NO, GROUPID);
                }

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            int sort = 0;
            for (int i = this.grd02.Rows.Fixed + 1; i < grd02.Rows.Count; i++)
            {
                if (int.Parse(this.grd02.GetValue(i, "SORT_SEQ").ToString()) > sort)
                {
                    sort = int.Parse(this.grd02.GetValue(i, "SORT_SEQ").ToString());
                }                
            }

            for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
            {   
                this.grd02.SetValue(i, "IS_VALIDATION", "0");                
                this.grd02.SetValue(i, "SORT_SEQ", sort + 1);   
            }
        }

        private void btn01_DELETE_Click(object sender, EventArgs e)
        {
            try
            {   
                
                DataSet save_param = this.grd02.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "DOC_NO","PARAM_NM");

                if (save_param.Tables[0].Rows.Count == 0)
                {
                    MsgCodeBox.Show("CD00-0041");
                    return;
                }

                this.BeforeInvokeServer(true);
                _WSCOM.MultipleExecuteNonQueryTx(new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_PARAM") }, new DataSet[] { save_param });
                this.AfterInvokeServer();
                MsgCodeBox.Show("CD00-0071");


                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("DOC_NO", txt01_DOC_NO.GetValue());
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_PARAM"), paramSet);                
                this.grd02.SetValue(source.Tables[0]); //파라메터
                
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

        private void btn01_DELETE_Click_1(object sender, EventArgs e)
        {
            try
            {

                DataSet save_param = this.grd02.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "DOC_NO", "PARAM_NM");

                if (save_param.Tables[0].Rows.Count == 0)
                {
                    MsgCodeBox.Show("CD00-0041");
                    return;
                }

                this.BeforeInvokeServer(true);
                _WSCOM.MultipleExecuteNonQueryTx(new string[] { "APG_XM20410.REMOVE_PARAM" }, new DataSet[] { save_param });
                this.AfterInvokeServer();
                MsgCodeBox.Show("CD00-0071");


                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("DOC_NO", txt01_DOC_NO.GetValue());
                DataSet source = _WSCOM.ExecuteDataSet("APG_XM20410.INQUERY_PARAM", paramSet);
                this.grd02.SetValue(source.Tables[0]); //파라메터

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

        private void axButton1_Click(object sender, EventArgs e)
        {
            txt01_DOC_NO.SetValue(string.Empty);
        }

        #endregion

        #region [사용자 정의 메서드]

        private bool IsRemoveValid(DataSet source)
        {
            try
            {
                if(source.Tables[0].Rows[0]["DOC_NO"] == null || string.IsNullOrEmpty(source.Tables[0].Rows[0]["DOC_NO"].ToString()))
                {
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

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

        private bool IsSaveValid(DataSet source)
        {      

            //if (source.Tables[0].Rows.Count == 0)
            //{
            //    MsgCodeBox.Show("XM00-0109"); //저장할 데이터가 존재하지 않습니다.
            //    return false;
            //}

            for (int i = 0; i < source.Tables[0].Rows.Count; i++)
            {
                DataRow seq = source.Tables[1].Rows[i];

                DataRow row = source.Tables[0].Rows[i];

                string SORT_SEQ = Convert.ToString(row["SORT_SEQ"]);
                string PARAM_TYPE = Convert.ToString(row["PARAM_TYPE"]);
                string IS_VALIDATION = Convert.ToString(row["IS_VALIDATION"]);
                string PARAM_NM = Convert.ToString(row["PARAM_NM"]);

                if (this.GetByteCount(PARAM_NM) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd02.Cols["PARAM_NM"].Caption);
                    return false;
                }
                if (this.GetByteCount(IS_VALIDATION) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd02.Cols["IS_VALIDATION"].Caption);
                    return false;
                }
                if (this.GetByteCount(PARAM_TYPE) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd02.Cols["PARAM_TYPE"].Caption);
                    return false;
                }
                if (this.GetByteCount(SORT_SEQ) == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd02.Cols["SORT_SEQ"].Caption);
                    return false;
                }
            }

            //데이터를 저장하시겠습니까?
            if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private void Inquery_Detail(string CORCD, string DOC_NO, string GROUPID)
        {
            try
            {
                InputInit();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", CORCD);
                paramSet.Add("DOC_NO", DOC_NO);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), paramSet);                

                if (source != null)
                {
                    txt02_TITLE.SetValue(source.Tables[0].Rows[0]["TITLE"].ToString());
                    txt01_QUERY.SetValue(source.Tables[0].Rows[0]["SCRIPT_QUERY"].ToString());
                    txt02_QUERY.SetValue(source.Tables[0].Rows[0]["SUB_QUERY"].ToString());
                    txt01_LINK_COLUMN.SetValue(source.Tables[0].Rows[0]["LINK_COLUMN"].ToString());
                    txt01_DOC_NO.SetValue(DOC_NO);
                    cbo01_S_GROUPID.SetValue(GROUPID);
                    cbo02_CATEGORY.SetValue(source.Tables[0].Rows[0]["CATEGORY"].ToString());
                    chk01_APPLY_LANGUAGE.Checked = (source.Tables[0].Rows[0]["APPLY_LANGUAGE"].ToString().Equals("Y")) ? true : false;
                }

                if (!string.IsNullOrEmpty(source.Tables[0].Rows[0]["PARAM_NM"].ToString()))
                {
                    this.grd02.SetValue(source.Tables[0]); //파라메터
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {                 
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                
            }
        }
        private void SetCategory()
        {
            HEParameterSet paramSet_Category = new HEParameterSet();
            DataSet source_Category = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CATEGORY"), paramSet_Category);
            cbo01_CATEGORY.DataBind(source_Category.Tables[0], true, "ALL"); //조회
            cbo02_CATEGORY.DataBind(source_Category.Tables[0], true, "");
        }
        #endregion

        
    }
}
