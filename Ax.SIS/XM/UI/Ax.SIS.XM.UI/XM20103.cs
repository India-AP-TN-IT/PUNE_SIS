#region ▶ Description & History
/* 
 * 프로그램명 : 다국어 관리 (메뉴별)
 * 설      명 : 특정 메뉴에서 사용하는 다국어 코드를 언어별로 나열하여 한번에 등록할수 있도록 한다. 기본 한국어, 영어, 중국어.
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-08-28      배명희      신규개발
 * 
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.XM.UI
{
    public partial class XM20103 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20103";
        private string PAKAGE_NAME_XM20101 = "APG_XM20101";
        private string PAKAGE_NAME_XM20102 = "APG_XM20102";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";
        
        private bool _isLoadCompleted = false;
        
        public XM20103()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [초기화 정의]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //시스템콤보상자
                DataTable dtSystemCode = this.getSystemCode();
                this.cbo01_SYSTEMCODE.DataBind(dtSystemCode, false);
                this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);
                               
                //대분류 모듈 콤보상자
                DataTable source3 = this.getModule();
                this.cbo01_Module.DataBind(source3);

                //메뉴 그리드 설정
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();  
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, "메뉴아이디", "MENUID", "MENUID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "메뉴명", "MENUNM", "MENUNM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 60, "부모메뉴아이디", "PARENTID", "PARENTID");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 60, "사용여부", "USEYN", "USEYN");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 60, "정렬순서", "MENUORDER", "MENUORDER");
                

                //언어 선택 그리드 설정
                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowEditing = true;
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 45, "선택", "CHK", "CHK");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 60, "언어코드", "TYPECD", "LANGSET");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "언어명", "OBJECT_NM", "LANG_NM");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                //디폴트 KO, EN, ZH 선택
                DataTable dtLangset = this.getLanguageCode();
                dtLangset.Columns.Add("CHK");
                foreach (DataRow dr in dtLangset.Rows)
                {
                    //if (dr["TYPECD"].ToString().Equals("KO") ||
                    //    dr["TYPECD"].ToString().Equals("EN") ||
                    //    dr["TYPECD"].ToString().Equals("ES"))
                    if (dr["USE_YN"].ToString().Equals("1"))
                        dr["CHK"] = 1;
                    else
                        dr["CHK"] = 0;
                }
                this.grd03.SetValue(dtLangset);

                for (int i = this.grd03.Cols.Fixed; i < this.grd03.Cols.Count; i++)
                {
                    if(this.grd03.Cols[i].Name.Equals("CHK"))
                        this.grd03.Cols[i].AllowEditing = true;
                    else
                        this.grd03.Cols[i].AllowEditing = false;
                }

                //다국어 코드 그리드 설정
                //grd02(다국어 코드 그리드)의 표시되는 컬럼은 grd03(언어선택) 그리드에서 체크한 언어만 표시된다.
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowEditing = true;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "코드", "CODE", "CODE");
                foreach (DataRow dr in dtLangset.Rows)
                {
                    if(dr["CHK"].ToString().Equals("1"))
                        this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, dr["OBJECT_NM"].ToString(), dr["TYPECD"].ToString(), dr["OBJECT_NM"].ToString());
                    else
                        this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 150, dr["OBJECT_NM"].ToString(), dr["TYPECD"].ToString(), dr["OBJECT_NM"].ToString());
                  
                }
                this.grd02.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange;
                
                //메뉴 조회
                this.BtnQuery_Click(null, null);

                _isLoadCompleted = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [공통 버튼 이벤트 정의]

        /// <summary>
        /// 메뉴정보를 조회한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string PARENTID = this.cbo01_Module.GetValue().ToString();
                string SYSTEMCODE = this.cbo01_SYSTEMCODE.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("PARENTID", PARENTID);
                set.Add("SYSTEMCODE", SYSTEMCODE);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20102, "AXD1300_INQUERY"), set);
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

        /// <summary>
        /// 화면을 초기화한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt01_Menuid.Initialize();
                this.txt01_Menuname.Initialize();
                this.grd02.InitializeDataSource();
                this.Inquery_grid03();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 다국어 코드별 코드명을 저장한다.
        /// (GRD03에 선택된 언어코드에 대해서만 저장됨.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //저장대상 언어코드 추출(기준이 되는 언어코드들)
                DataTable dtLangset = this.grd03.GetValue(AxFlexGrid.FActionType.All, "TYPECD", "CHK").Tables[0];

                if (dtLangset.Select("CHK='Y'").Length == 0)
                { 
                    //MsgBox.Show("저장할 다국어 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0055");
                    return;                
                }

                string[] args= new string[dtLangset.Select("CHK='Y'").Length + 1];
                args[0] = "CODE";

                int cnt = 1;

                for (int i = this.grd02.Cols.Fixed; i < this.grd02.Cols.Count; i++)
                {
                    if (this.grd02.Cols[i].Visible && dtLangset.Select("TYPECD = '" + this.grd02.Cols[i].Name + "'").Length > 0)
                    {
                        args[cnt] = this.grd02.Cols[i].Name;
                        cnt++;
                    }
                }

                //저장대상 다국어 코드 및 언어코드 추출(컬럼형태)
                DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.Save, args);

                //컬럼 형태로 되어 있는 언어코드별 다국어명을 
                //레코드 형태로 전환한다.(dsSave에)
                DataSet dsSave = this.GetDataSourceSchema("CODE", "LANGUAGE", "CODENAME", "USERID");
                for (int r = 0; r < source.Tables[0].Rows.Count; r++)
                {
                    DataRow dr = source.Tables[0].Rows[r];
                    for (int c = 1; c < source.Tables[0].Columns.Count; c++)
                    {
                        dsSave.Tables[0].Rows.Add(dr["CODE"].ToString(), 
                                                source.Tables[0].Columns[c].ColumnName, 
                                                dr[source.Tables[0].Columns[c].ColumnName].ToString(),
                                                this.UserInfo.UserID);
                    }
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), dsSave);

                this.AfterInvokeServer();

                this.btn01_Inquery_Click_grid02();
                MsgCodeBox.Show("XM00-0052");
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

        #region [유효성 체크]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 다국어 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0055");
                    return false;
                }

                //if (MsgBox.Show("선택하신 다국어 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0056", MessageBoxButtons.OKCancel) != DialogResult.OK)
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


        #region [컨트롤 이벤트 정의]
        /// <summary>
        /// 특정 메뉴를 더블클릭하면 해당 메뉴에 정의중인 다국어 코드를 나열한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.grd01.SelectedRowIndex < this.grd01.Rows.Fixed)
                {
                    this.BtnReset_Click(null, null);
                    return;
                }

                string MENUID = this.grd01.GetValue(this.grd01.SelectedRowIndex, "MENUID").ToString();
                string MENUNAME = this.grd01.GetValue(this.grd01.SelectedRowIndex, "MENUNM").ToString().Replace(".", "").Replace("┖", "");

                this.txt01_Menuid.SetValue(MENUID);
                this.txt01_Menuname.SetValue(MENUNAME);

                this.btn01_Inquery_Click_grid02();
              
                
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

        /// <summary>
        /// grd03(기준 언어 그리드)의 체크박스 선택시, grd02(다국어 코드 그리드)에 선택된 언어 컬럼 표시/비표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd03_CellChecked(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                string code = this.grd03.GetValue(e.Row, "TYPECD").ToString();

                this.grd02.Cols[code].Visible = this.grd03.GetValue(e.Row, "CHK").ToString().Equals("Y");
                
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

        /// <summary>
        /// grd03(기준 언어 그리드)의 체크박스 선택시, grd02(다국어 코드 그리드)에 선택된 언어 컬럼 표시/비표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd03_MouseClick(object sender, MouseEventArgs e)
        {
            int r = this.grd03.MouseRow;
            int c = this.grd03.MouseCol;

            if (r < this.grd03.Rows.Fixed || r >= this.grd03.Rows.Count)
                return;

            if (c != this.grd03.Cols["CHK"].Index)
                return;

            try
            {
                string code = this.grd03.GetValue(r, "TYPECD").ToString();

                this.grd02.Cols[code].Visible = this.grd03.GetValue(r, "CHK").ToString().Equals("Y");


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

        /// <summary>
        /// 메뉴아이디 입력후 enter키 치면 해당 메뉴의 다국어 코드별 코드명 정보 가져온다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt01_Menuid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt01_Menuname.SetValue("");

                this.btn01_Inquery_Click_grid02();
               
            }
        }

        /// <summary>
        /// 시스템코드 콤보상자 변경시 메뉴 데이터 재조회 및 화면 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo01_SYSTEMCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted)
            {
                DataTable source3 = this.getModule();
                this.cbo01_Module.DataBind(source3);

                BtnQuery_Click(null, null);
                BtnReset_Click(null, null);
            }
        }

    
        #endregion

        #region [사용자 정의 메서드 정의]

        /// <summary>
        /// 메뉴별 다국어 코드 및 다국어명 조회하여, 가공한 후,  grd02(다국어 그리드)에 표시한다.
        /// </summary>
        private void btn01_Inquery_Click_grid02()
        {
            try
            {
                if (this.txt01_Menuid.IsEmpty)
                {
                    this.BtnReset_Click(null, null);
                    return;
                }

                string MENUID = this.txt01_Menuid.GetValue().ToString();
               

                HEParameterSet set = new HEParameterSet();
                set.Add("MENUID", MENUID);
                set.Add("LANG_SET", this.UserInfo.Language);
                
                this.BeforeInvokeServer(true);
                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE"), set);

                //record단위의 다국어 코드별 코드명 데이터를
                //사용자가 알아보기 편하도록 column 단위로 전환한다.
                DataTable dtCode = this.GetPivotDataTable(source.Tables[0]);

                this.AfterInvokeServer();

                this.grd02.SetValue(dtCode);
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

        /// <summary>
        /// row단위의 데이터를 column 단위의 데이터로 변경.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private DataTable GetPivotDataTable(DataTable source)
        {
            DataTable dtReturn = new DataTable();
            try
            {
                dtReturn.Columns.Add("CODE"); //1. 다국어 코드 컬럼 추가

                //2. 언어코드 컬럼 추가.(KO, EN, ...)
                DataSet dtLang = this.grd03.GetValue(AxFlexGrid.FActionType.All, "TYPECD");                 
                foreach (DataRow dr in dtLang.Tables[0].Rows)
                    dtReturn.Columns.Add(dr["TYPECD"].ToString());

                //3. 레코드단위의 데이터 LOOP 돌면서
                //   해당 언어 컬럼에 코드명을 매핑한다.
                foreach (DataRow dr in source.Rows)
                {
                    DataRow[] drs = dtReturn.Select("CODE = '" + dr["CODE"].ToString() + "'"); //신규행여부 체크
                    if (drs.Length == 0) //신규행이면.. 신규행 추가하고 해당 언어컬럼에 코드명 매핑
                    {
                        DataRow drNew = dtReturn.NewRow();
                        drNew["CODE"] = dr["CODE"].ToString();
                        drNew[dr["LANGUAGE"].ToString()] = dr["CODENAME"].ToString();
                        dtReturn.Rows.Add(drNew);
                    }
                    else
                        drs[0][dr["LANGUAGE"].ToString()] = dr["CODENAME"].ToString(); //기존행이면 기존행의 해당 언어 컬럼에 코드명 매핑
                }
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
              
                MsgBox.Show(ex.ToString());
            }
            finally
            {
              

            }
            return dtReturn;
        }


        /// <summary>
        /// 언어 선택 그리드 초기화
        /// </summary>
        private void Inquery_grid03()
        {
            try
            {
                //디폴트로 KO, EN, ZH 선택되도록.
                DataTable dtLangset = this.getLanguageCode();
                dtLangset.Columns.Add("CHK");
                foreach (DataRow dr in dtLangset.Rows)
                {
                    //if (dr["TYPECD"].ToString().Equals("KO") ||
                    //    dr["TYPECD"].ToString().Equals("EN") ||
                    //    dr["TYPECD"].ToString().Equals("ES"))
                    if (dr["USE_YN"].ToString().Equals("1"))
                        dr["CHK"] = 1;
                    else
                        dr["CHK"] = 0;
                }
                this.grd03.SetValue(dtLangset);

                foreach (DataRow dr in dtLangset.Rows)
                {
                    if (dr["CHK"].ToString().Equals("1"))
                        this.grd02.Cols[dr["TYPECD"].ToString()].Visible = true;
                    else
                        this.grd02.Cols[dr["TYPECD"].ToString()].Visible = false;
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

        /// <summary>
        /// 시스템 콤보상자를 위한 데이터 조회
        /// </summary>
        /// <returns></returns>
        private DataTable getSystemCode()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20001, "INQUERY_SYSTEMCODE"), set);


                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// 모듈 콤보상자를 위한 데이터 조회
        /// </summary>
        /// <returns></returns>
        private DataTable getModule()
        {
            try
            {               

                HEParameterSet set = new HEParameterSet();
                set.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20102, "AXD1300_INQUERY_MODULE"), set);


                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// 언어 데이터 조회
        /// </summary>
        /// <returns></returns>
        private DataTable getLanguageCode()
        {
            try
            {
              
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20101, "INQUERY_LANG_SET"), set);


                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {

                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        #endregion

       

        

       
    }
}
