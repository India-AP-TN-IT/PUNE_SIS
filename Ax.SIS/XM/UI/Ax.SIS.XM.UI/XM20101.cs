#region ▶ Description & History
/* 
 * 프로그램명 : 다국어 입력
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2013-09-10	    배명희     #001 메시지 데이터 (XD1500) 다국어 입력 기능 추가.
 *				2014-07-03      배명희     프로그램 아이디 변경(XM70000 -> XM20101)
 *				                           웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *			    2014-07-21      배명희     source언어, target언어 병렬 조회하여 source언어의 코드명/메시지를 참고하면서
 *			                                target언어의 코드명/메시지를 등록할수 있도록 로직 추가함
 *			    2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거                           
 *			    2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
 * 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// 다국어 관리
    /// </summary>
    public partial class XM20101 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private bool _isLoadCompleted = false;
        private string PAKAGE_NAME = "APG_XM20101";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";

        public XM20101()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [초기화 설정]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {               
                DataTable source2 = this.GetDataSourceSchema("CODE", "CODENAME").Tables[0];               
                source2.Rows.Add("CMBTN", "CMBTN");
                source2.Rows.Add("XM", "XM");
                source2.Rows.Add("FXCODE", "FXCODE");
                source2.Rows.Add("MENU", "MENU");
                source2.Rows.Add("TEMP", "TEMP");

                DataTable dtLangset = this.getLanguageCode();
                this.cbo01_LANGUAGE.DataBind(dtLangset, false);
                this.cbo01_LANGUAGE.SetValue(this.UserInfo.Language);

                this.cbo03_TARGET_LANGSET.DataBind(dtLangset, false);
                this.cbo04_TARGET_LANGSET.DataBind(dtLangset, false);

                this.grd01.Initialize();               
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "_언어", "LANGUAGE", "LANGUAGE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_코드", "CODE", "CODE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "_코드명", "CODENAME", "CODENAME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_구분", "TYPENM2", "TYPENM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 350, "_DESCRIPTION", "DESCRIPTION", "DESCRIPTION");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtLangset, "LANGUAGE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source2, "TYPENM2");
                              
                DataTable dtSystemCode = this.getSystemCode();
                this.cbo01_SYSTEMCODE.DataBind(dtSystemCode, true);
                this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);

                //메시지 다국어(#001)
                this.grd02.Initialize();                                
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_System", "SYSTEMCODE", "SYSTEMCODE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "_언어", "LANGUAGE", "LANGUAGE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_코드", "CODE", "CODE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 450, "_메시지", "MESSAGE", "MESSAGE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_타이틀", "TITLE", "TITLE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtLangset, "LANGUAGE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtSystemCode, "SYSTEMCODE");
                                
                this.grd03.Initialize();
                this.grd03.CurrentContextMenu.Items[0].Visible = false;
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "_코드", "CODE", "CODE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "_원본 코드명", "SOURCE_CODENAME", "SOURCE_CODENAME");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "_대상코드명", "TARGET_CODENAME", "TARGET_CODENAME");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "_구분", "TYPE", "TYPE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "_DESCRIPTION", "DESCRIPTION", "DESCRIPTION");
                                
                this.grd04.Initialize();
                this.grd04.CurrentContextMenu.Items[0].Visible = false;
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "_코드", "CODE", "CODE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "_원본 메시지", "SOURCE_MESSAGE", "SOURCE_MESSAGE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "_TITLE", "SOURCE_TITLE", "SOURCE_TITLE");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "_대상 메시지", "TARGET_MESSAGE", "TARGET_MESSAGE");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_TITLE", "TARGET_TITLE", "TARGET_TITLE");
                this.grd04.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 060, "_System", "SYSTEMCODE", "SYSTEMCODE");
                
                this.txt01_CODE.SetValid(AxTextBox.TextType.UAlphabet);
                this.txt01_CODENAME.SetValid(AxTextBox.TextType.Hangle);

                this.BtnQuery_Click(null, null);

                _isLoadCompleted = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [공용 버튼 이벤트에 대한 정의]

        //현재 선택된 탭의 다국어 데이터 조회
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string language = this.cbo01_LANGUAGE.GetValue().ToString();
                string code = this.txt01_CODE.GetValue().ToString();
                string codename = this.txt01_CODENAME.GetValue().ToString();

                this.BeforeInvokeServer(true);
                
                if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CODE", code);
                    paramSet.Add("CODENAME", codename);
                    paramSet.Add("LANGUAGE", language);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1400_INQUERY"), paramSet);
                    this.grd01.SetValue(source.Tables[0]);
                    this.ShowDataCount(source);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    //#001 
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CODE", code);
                    paramSet.Add("MESSAGE", codename);
                    paramSet.Add("LANGUAGE", language);
                    paramSet.Add("SYSTEMCODE", cbo01_SYSTEMCODE.GetValue().ToString());
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1500_INQUERY"), paramSet);
                    this.grd02.SetValue(source.Tables[0]);
                    this.ShowDataCount(source);
                }
                else if (tabControl1.SelectedIndex == 2)
                {                    
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CODE", code);
                    paramSet.Add("CODENAME", codename);
                    paramSet.Add("LANGUAGE", language);                   
                    paramSet.Add("TARGET_LANG", cbo03_TARGET_LANGSET.GetValue().ToString());
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1400_MULT_INQUERY"), paramSet);
                    this.grd03.SetValue(source.Tables[0]);
                    this.ShowDataCount(source);

                    //그리드 컬럼 헤더에 기준 언어 및 대상언어 표기
                    this.grd03.SetValue(0, "TARGET_CODENAME", this.GetLabel("TARGET_CODENAME") + " (" + this.cbo03_TARGET_LANGSET.GetValue().ToString() + ")");
                    this.grd03.SetValue(0, "SOURCE_CODENAME", this.GetLabel("SOURCE_CODENAME") + " (" + this.cbo01_LANGUAGE.GetValue().ToString() + ")");
                }
                else if (tabControl1.SelectedIndex == 3)
                {                   
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CODE", code);
                    paramSet.Add("MESSAGE", codename);
                    paramSet.Add("LANGUAGE", language);
                    paramSet.Add("SYSTEMCODE", cbo01_SYSTEMCODE.GetValue().ToString());
                    paramSet.Add("TARGET_LANG", cbo04_TARGET_LANGSET.GetValue().ToString());
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1500_MULTI_INQUERY"), paramSet);
                    this.grd04.SetValue(source.Tables[0]);
                    this.ShowDataCount(source);
                    
                    //그리드 컬럼 헤더에 기준 언어 및 대상언어 표기
                    this.grd04.SetValue(0, "TARGET_MESSAGE", this.GetLabel("TARGET_MESSAGE") + " (" + this.cbo04_TARGET_LANGSET.GetValue().ToString() + ")");
                    this.grd04.SetValue(0, "SOURCE_MESSAGE", this.GetLabel("SOURCE_MESSAGE") + " (" + this.cbo01_LANGUAGE.GetValue().ToString() + ")");
                    this.grd04.SetValue(0, "TARGET_TITLE", this.GetLabel("TARGET_TITLE") + " (" + this.cbo04_TARGET_LANGSET.GetValue().ToString() + ")");
                    this.grd04.SetValue(0, "SOURCE_TITLE", this.GetLabel("SOURCE_TITLE") + " (" + this.cbo01_LANGUAGE.GetValue().ToString() + ")");
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

        //현재 선택된 탭의 그리드 초기화
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    this.grd01.InitializeDataSource();
                }
                else if (tabControl1.SelectedIndex == 1)
                {   
                    //#001 
                    this.grd02.InitializeDataSource();
                }
                else if (tabControl1.SelectedIndex == 2)
                {   
                    this.grd03.InitializeDataSource();
                }
                else if (tabControl1.SelectedIndex == 3)
                {   
                    this.grd04.InitializeDataSource();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        //현재 선택된 탭의 다국어 데이터 저장함.
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {                
                if (tabControl1.SelectedIndex == 0)
                {
                    DataSet source = grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CODE", "LANGUAGE", "CODENAME", "TYPE", "TYPENM2", "DESCRIPTION", "UPDATE_ID");

                    foreach (DataRow rows in source.Tables[0].Rows)
                    {
                        rows["UPDATE_ID"] = this.UserInfo.EmpNo;
                        rows["TYPE"] = rows["TYPENM2"].ToString();
                    }

                    if (!IsSaveValid(source)) return;

                    source.Tables[0].Columns.Remove("TYPENM2");

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1400_SAVE"), source);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    //#001 
                    DataSet source = grd02.GetValue(AxFlexGrid.FActionType.Save,
                    "CODE", "LANGUAGE", "MESSAGE", "TITLE", "SYSTEMCODE");

                    if (!IsSaveValid2(source)) return;

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1500_SAVE"), source);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    //다국어 매핑(코드)
                    DataSet source = grd03.GetValue(AxFlexGrid.FActionType.Save,
                   "CODE", "LANGUAGE", "CODENAME", "TARGET_CODENAME", "TYPE", "DESCRIPTION", "UPDATE_ID");

                    foreach (DataRow rows in source.Tables[0].Rows)
                    {
                        rows["LANGUAGE"] = this.cbo03_TARGET_LANGSET.GetValue().ToString();
                        rows["UPDATE_ID"] = this.UserInfo.EmpNo;
                        rows["CODENAME"] = rows["TARGET_CODENAME"].ToString();
                    }
                    if (!IsSaveValid3(source)) return;

                    source.Tables[0].Columns.Remove("TARGET_CODENAME");

                    this.BeforeInvokeServer(true);
                    
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1400_SAVE"), source);
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    //다국어 매핑(메시지)
                    DataSet source = grd04.GetValue(AxFlexGrid.FActionType.Save,
                    "CODE", "LANGUAGE", "MESSAGE", "TARGET_MESSAGE", "TITLE", "TARGET_TITLE", "SYSTEMCODE");

                    foreach (DataRow rows in source.Tables[0].Rows)
                    {
                        rows["LANGUAGE"] = this.cbo04_TARGET_LANGSET.GetValue().ToString();
                        rows["MESSAGE"] = rows["TARGET_MESSAGE"].ToString();
                        rows["TITLE"] = rows["TARGET_TITLE"].ToString();
                    }

                    if (!IsSaveValid4(source)) return;

                    source.Tables[0].Columns.Remove("TARGET_MESSAGE");
                    source.Tables[0].Columns.Remove("TARGET_TITLE");

                    this.BeforeInvokeServer(true);
                    
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1500_SAVE"), source);
                }
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                //MsgBox.Show("입력하신 다국어 정보가 저장되었습니다.");
                MsgCodeBox.Show("XM00-0041");
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

        //현재 선택된 탭의 다국어 데이터 삭제함.
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {                
                if (tabControl1.SelectedIndex == 0) //코드 등록 탭
                {
                    DataSet source = grd01.GetValue(AxFlexGrid.FActionType.Remove, "CODE", "LANGUAGE");

                    if (!IsDeleteValid(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.XD1400_REMOVE(source);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1400_REMOVE"), source);
                }
                else if (tabControl1.SelectedIndex == 1) //메시지 등록 탭
                {
                    //#001 
                    DataSet source = grd02.GetValue(AxFlexGrid.FActionType.Remove, "CODE", "LANGUAGE", "SYSTEMCODE");

                    if (!IsDeleteValid(source)) return;

                    this.BeforeInvokeServer(true);
                    //_WSCOM.XD1500_REMOVE(source);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1500_REMOVE"), source);
                }
                else if (tabControl1.SelectedIndex == 2) //코드 매핑 탭
                {
                    DataSet source = grd03.GetValue(AxFlexGrid.FActionType.Remove, "CODE", "LANGUAGE");

                    if (!IsDeleteValid(source)) return;

                    foreach (DataRow dr in source.Tables[0].Rows)
                    {
                        dr["LANGUAGE"] = this.cbo03_TARGET_LANGSET.GetValue().ToString();
                    }
                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1400_REMOVE"), source);
                }
                else if (tabControl1.SelectedIndex == 3) //메시지 매핑탭
                {
                    DataSet source = grd04.GetValue(AxFlexGrid.FActionType.Remove, "CODE", "LANGUAGE", "SYSTEMCODE");

                    if (!IsDeleteValid(source)) return;
                    foreach (DataRow dr in source.Tables[0].Rows)
                    {
                        dr["LANGUAGE"] = this.cbo04_TARGET_LANGSET.GetValue().ToString();
                    }
                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1500_REMOVE"), source);
                }

                this.AfterInvokeServer();

                //재조회
                this.BtnQuery_Click(null, null);
                
                //MsgBox.Show("선택하신 다국어 정보가 삭제되었습니다.");
                MsgCodeBox.Show("XM00-0042");
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

        #region [사용자 정의 메서드]

        //시스템 콤보상자용 데이터 조회
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

        //언어 콤보상자용 데이터 조회
        private DataTable getLanguageCode()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_LANG_SET"), set);

                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return null;
        }
        
        #endregion

        #region [유효성 체크]

        //다국어정보(코드) 탭 - (XD1400 데이터) 저장시 유효성 검사
        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 다국어 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0043");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string LANGUAGE = this.Nvl(source.Tables[0].Rows[i]["LANGUAGE"], "").ToString();
                    string CODE = this.Nvl(source.Tables[0].Rows[i]["CODE"], "").ToString();
                    string CODENAME = this.Nvl(source.Tables[0].Rows[i]["CODENAME"], "").ToString();
                    /*
                    LANGUAGE", "CODENAME", "TYPE", "DESCRIPTION
                    */
                    if (this.GetByteCount(LANGUAGE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 언어가 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["LANGUAGE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CODE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어 코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["CODE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CODE) > 30)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어 코드는 30byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["CODE"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(CODENAME) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["CODENAME"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CODENAME) > 300)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어는 300byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["CODENAME"].Caption, 30);
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 다국어 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0046", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        
        //#001 
        //다국어정보(메시지) 탭 - (XD1500 데이터) 저장시 유효성 검사
        private bool IsSaveValid2(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 메시지 다국어 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0049");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string LANGUAGE = this.Nvl(source.Tables[0].Rows[i]["LANGUAGE"], "").ToString();
                    string CODE = this.Nvl(source.Tables[0].Rows[i]["CODE"], "").ToString();
                    string MESSAGE = this.Nvl(source.Tables[0].Rows[i]["MESSAGE"], "").ToString();
                    string TITLE = this.Nvl(source.Tables[0].Rows[i]["TITLE"], "").ToString();
                    string SYSTEMCODE = this.Nvl(source.Tables[0].Rows[i]["SYSTEMCODE"], "").ToString();

                    if (this.GetByteCount(SYSTEMCODE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 시스템코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["SYSTEMCODE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(LANGUAGE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 언어가 선택되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["LANGUAGE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CODE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어 코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["CODE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CODE) > 20)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어 코드는 20byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["CODE"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(MESSAGE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 메시지가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["MESSAGE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(MESSAGE) > 300)
                    {
                        //MsgBox.Show(i + " 번째 행에 메시지는 300byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["MESSAGE"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(TITLE) > 30)
                    {
                        //MsgBox.Show(i + " 번째 행에 캡션 타이틀은 30byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["TITLE"].Caption, 30);
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 메시지 다국어 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0050", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        //다국어 매핑 (코드) 탭 - 유효성 검사
        private bool IsSaveValid3(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 다국어 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0043");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string LANGUAGE = this.Nvl(source.Tables[0].Rows[i]["LANGUAGE"], "").ToString();
                    string CODE = this.Nvl(source.Tables[0].Rows[i]["CODE"], "").ToString();
                    string CODENAME = this.Nvl(source.Tables[0].Rows[i]["CODENAME"], "").ToString();                  

                    if (this.GetByteCount(CODE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어 코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd03.Cols["CODE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CODE) > 30)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어 코드는 30byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd03.Cols["CODE"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(CODENAME) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd03.Cols["TARGET_CODENAME"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CODENAME) > 300)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어는 300byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd03.Cols["TARGET_CODENAME"].Caption, 30);
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 다국어 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0046", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        //다국어 매핑 (메시지) 탭 - 유효성 검사
        private bool IsSaveValid4(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 메시지 다국어 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0049");
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string LANGUAGE = this.Nvl(source.Tables[0].Rows[i]["LANGUAGE"], "").ToString();
                    string CODE = this.Nvl(source.Tables[0].Rows[i]["CODE"], "").ToString();
                    string MESSAGE = this.Nvl(source.Tables[0].Rows[i]["MESSAGE"], "").ToString();
                    string TITLE = this.Nvl(source.Tables[0].Rows[i]["TITLE"], "").ToString();
                    string SYSTEMCODE = this.Nvl(source.Tables[0].Rows[i]["SYSTEMCODE"], "").ToString();

                    if (this.GetByteCount(SYSTEMCODE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 시스템코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd04.Cols["SYSTEMCODE"].Caption);
                        return false;
                    }
                  
                    if (this.GetByteCount(CODE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어 코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd04.Cols["CODE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CODE) > 20)
                    {
                        //MsgBox.Show(i + " 번째 행에 다국어 코드는 20byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd04.Cols["CODE"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(MESSAGE) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 메시지가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd04.Cols["TARGET_MESSAGE"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(MESSAGE) > 300)
                    {
                        //MsgBox.Show(i + " 번째 행에 메시지는 300byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd04.Cols["TARGET_MESSAGE"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(TITLE) > 30)
                    {
                        //MsgBox.Show(i + " 번째 행에 캡션 타이틀은 30byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd04.Cols["TARGET_TITLE"].Caption, 30);
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 메시지 다국어 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0050", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        //다국어 데이터 삭제시 확인 메시지(전 TAB 공통)
        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 다국어 정보를 선택하지 않았습니다.");
                    MsgCodeBox.Show("XM00-0047");
                    return false;
                }

                //if (MsgBox.Show("선택하신 다국어 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0048", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        
        #endregion

        #region [기타컨트롤 이벤트]

        //XD1400관련 탭에서는 시스템코드 콤보상자 비표시함.(XD1500에만 SYSTEMCODE가 있으므로)
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 ||  tabControl1.SelectedIndex == 2)
            {
                //this.cbo01_SYSTEMCODE.SetReadOnly(true);
                this.cbo01_SYSTEMCODE.Visible = false;
                this.lbl01_SYSTEMCODE.Visible = false;
            }
            else
            {
                //this.cbo01_SYSTEMCODE.SetReadOnly(false);
                this.cbo01_SYSTEMCODE.Visible = true;
                this.lbl01_SYSTEMCODE.Visible = true;
            }
        }

        //다국어정보(메시지) 탭에서 그리드 행추가시 "SYSTEMCODE" 컬럼값 넣어준다. (현재 선택된 SYSTEMCODE콤보상자의 값으로)
        private void grd02_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
            {
                if (!this.cbo01_SYSTEMCODE.GetValue().ToString().Equals(string.Empty))
                {
                    this.grd02.SetValue(i, "SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue().ToString());
                }
                this.grd02.SetValue(i, "LANGUAGE", this.cbo01_LANGUAGE.GetValue().ToString());    
                this.grd02.Rows[i].Height = 22;
            }
        }
        
        //조회조건인 시스템코드 콤보상자 값 변경시, 관련 그리드 초기화 함.
        private void cbo01_SYSTEMCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted)
            {
                if (this.tabControl1.SelectedIndex == 1)
                {
                    this.grd02.InitializeDataSource();
                }
                else if (this.tabControl1.SelectedIndex == 3)
                {
                    this.grd04.InitializeDataSource();
                }               
            }
        }

        //저장대상언어 변경시, 관련 그리드 초기화 처리
        private void cbo03_TARGET_LANGSET_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_isLoadCompleted)
                this.grd03.InitializeDataSource();
        }

        //저장대상언어 변경시, 관련 그리드 초기화 처리
        private void cbo04_TARGET_LANGSET_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadCompleted)
                this.grd04.InitializeDataSource();
        }

        #endregion
    }
}
