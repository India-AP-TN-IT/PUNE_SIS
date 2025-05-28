#region ▶ Description & History
/* 
 * 프로그램명 : 메뉴별 다국어 설정
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-04      배명희      프로그램 아이디 변경(XM70010 -> XM20102)
 *				                            웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
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
    /// 메뉴별 다국어 설정
    /// </summary>
    public partial class XM20102 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20102";
        private string PAKAGE_NAME_XM20101 = "APG_XM20101";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";
        private bool _isLoadCompleted = false;
        public XM20102()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [초기화 정의]
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable dtSystemCode = this.getSystemCode();
                this.cbo01_SYSTEMCODE.DataBind(dtSystemCode, false);
                this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);
                
                DataTable source2 = this.GetDataSourceSchema("CODE", "CODENAME").Tables[0];
                
                DataTable source3 = this.getModule();

                source2.Rows.Add("CMBTN", "CMBTN");
                source2.Rows.Add("XM", "XM");
                source2.Rows.Add("FXCODE", "FXCODE");
                source2.Rows.Add("MENU", "MENU");
                source2.Rows.Add("TEMP", "TEMP");

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "_메뉴아이디", "MENUID", "MENUID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "_메뉴명", "MENUNM", "MENUNM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 060, "_부모메뉴아이디", "PARENTID", "PARENTID");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 060, "_사용여부", "USEYN", "USEYN");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 060, "_정렬순서", "MENUORDER", "MENUORDER");
                
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowEditing = true;
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 045, "_선택", "CHK", "CHK");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_코드", "CODE", "CODE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 350, "_코드명", "CODENAME", "CODENAME");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_비고", "INCLUDE", "INCLUDE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check,"CHK");
                
                this.grd03.Initialize();
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "_그리드명", "GRIDNAME", "GRIDNAME");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "_헤더갯수", "HEADERCOUNT", "HEADERCOUNT");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "HEADERCOUNT");
                
                DataTable dtLangset = this.getLanguageCode();  
                this.cbo01_LANGUAGE.DataBind(dtLangset, false);
                this.cbo01_LANGUAGE.SetValue(this.UserInfo.Language);

                this.cbo01_Module.DataBind(source3);

                this.txt01_CODE.SetValid(AxTextBox.TextType.UAlphabet);
                this.txt01_CODENAME.SetValid(AxTextBox.TextType.Hangle);

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
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1300_INQUERY"), set);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt01_Menuid.Initialize();
                this.txt01_Menuname.Initialize();
                this.cbo01_LANGUAGE.SetValue(this.UserInfo.Language);
                this.chk01_INCLUDE_MSG.SetValue("Y");
                this.txt01_CODE.Initialize();
                this.txt01_CODENAME.Initialize();

                this.grd02.InitializeDataSource();
                this.grd03.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string MENUID = this.txt01_Menuid.GetValue().ToString();
                if (MENUID.Length == 0)
                {
                    //MsgBox.Show("다국어 정보를 입력할 메뉴를 먼저 선택하세요.");
                    MsgCodeBox.Show("XM00-0051");
                    return;
                }

                DataSet source = this.GetDataSourceSchema("MENUID", "CODE");
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    string CHK = this.grd02.GetValue(i, "CHK").ToString();
                    string CODE = this.grd02.GetValue(i, "CODE").ToString();

                    if (CHK.Equals("Y"))
                        source.Tables[0].Rows.Add(MENUID, CODE);
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.XD1420_SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1420_SAVE"), source);
                this.AfterInvokeServer();

                this.chk01_INCLUDE_MSG.SetValue("Y");
                this.btn01_Inquery_Click_grid02();
                //MsgBox.Show("선택하신 다국어 정보가 저장되었습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string MENUID = this.txt01_Menuid.GetValue().ToString();
                if (MENUID.Length == 0)
                {
                    //MsgBox.Show("다국어 정보를 삭제할 메뉴를 먼저 선택하세요.");
                    MsgCodeBox.Show("XM00-0053");
                    return;
                }

                DataSet source = this.GetDataSourceSchema("MENUID", "CODE");
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    string CHK = this.grd02.GetValue(i, "CHK").ToString();
                    string CODE = this.grd02.GetValue(i, "CODE").ToString();

                    if (CHK.Equals("Y"))
                        source.Tables[0].Rows.Add(MENUID, CODE);
                }

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1420_REMOVE"), source);
                this.AfterInvokeServer();

                this.chk01_INCLUDE_MSG.SetValue("Y");
                this.btn01_Inquery_Click_grid02();
                //MsgBox.Show("선택하신 다국어 정보가 삭제되었습니다.");
                MsgCodeBox.Show("XM00-0054");
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

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 다국어 정보를 선택하지 않았습니다.");
                    MsgCodeBox.Show("XM00-0057");
                    return false;
                }

                //if (MsgBox.Show("선택하신 다국어 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0058", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        #region [기타 버튼 이벤트 정의]

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
                this.btn01_Inquery_Click_grid03();
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

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            this.btn01_Inquery_Click_grid02();
        }

        private void btn03_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string MENUID = this.txt01_Menuid.GetValue().ToString();
                if (MENUID.Length == 0)
                {
                    //MsgBox.Show("그리드 헤더정보를 입력할 메뉴를 먼저 선택하세요.");
                    MsgCodeBox.Show("XM00-0059");
                    return;
                }

                DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.Save, "MENUID", "GRIDNAME", "HEADERCOUNT");
                foreach (DataRow rows in source.Tables[0].Rows)
                    rows["MENUID"] = MENUID;

                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 그리드 헤더정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0060");
                    return;
                }

                //if (MsgBox.Show("입력하신 그리드 헤더정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0061", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                this.BeforeInvokeServer(true);
                //_WSCOM.XD1430_SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1430_SAVE"), source);
                this.AfterInvokeServer();

                this.btn01_Inquery_Click_grid03();
                //MsgBox.Show("선택하신 그리드 헤더정보가 저장되었습니다.");
                MsgCodeBox.Show("XM00-0062");
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

        private void btn03_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                string MENUID = this.txt01_Menuid.GetValue().ToString();
                if (MENUID.Length == 0)
                {
                    //MsgBox.Show("그리드 헤더정보를 삭제할 메뉴를 먼저 선택하세요.");
                    MsgCodeBox.Show("XM00-0063");
                    return;
                }

                DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.Remove, "MENUID", "GRIDNAME");
                foreach (DataRow rows in source.Tables[0].Rows)
                    rows["MENUID"] = MENUID;

                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 그리드 헤더정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0064");
                    return;
                }

                //if (MsgBox.Show("선택하신 그리드 헤더정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0065", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                this.BeforeInvokeServer(true);
                //_WSCOM.XD1430_REMOVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1430_REMOVE"), source);
                this.AfterInvokeServer();

                this.btn01_Inquery_Click_grid03();
                //MsgBox.Show("선택하신 그리드 헤더정보가 삭제되었습니다.");
                MsgCodeBox.Show("XM00-0066");
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

        #region [컨트롤 이벤트 정의]

        private void grd03_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.grd03.SelectedRowIndex < this.grd03.Rows.Fixed)
                    return;

                string MENUID = this.txt01_Menuid.GetValue().ToString();
                if (MENUID.Length == 0)
                {
                    //MsgBox.Show("그리드 컬럼 정보를 입력할 메뉴를 먼저 선택하세요.");
                    MsgCodeBox.Show("XM00-0067");
                    return;
                }

                string GRIDNAME = this.grd03.GetValue(this.grd03.SelectedRowIndex, "GRIDNAME").ToString();
                string HEADERCOUNT = this.grd03.GetValue(this.grd03.SelectedRowIndex, "HEADERCOUNT").ToString();

                XM20102P1 control = new XM20102P1(MENUID, GRIDNAME, HEADERCOUNT);
                PopupHelper helper = new PopupHelper(control, this.GetLabel("XM20102P1"));
                helper.ShowDialog(false);

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

        private void txt01_Menuid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt01_Menuname.SetValue("");

                this.btn01_Inquery_Click_grid02();
                this.btn01_Inquery_Click_grid03();
            }
        }

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
        
        private void txt01_CODE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btn01_Inquery_Click(null, null);
        }

        private void txt01_CODENAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btn01_Inquery_Click(null, null);
        }
        #endregion

        #region [사용자 정의 메서드 정의]

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
                string CODE = this.txt01_CODE.GetValue().ToString();
                string CODENAME = this.txt01_CODENAME.GetValue().ToString();
                string LANGUAGE = this.cbo01_LANGUAGE.GetValue().ToString();
                string INCLUDE_YN = this.chk01_INCLUDE_MSG.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("MENUID", MENUID);
                set.Add("CODE", CODE);
                set.Add("CODENAME", CODENAME);
                set.Add("LANGUAGE", LANGUAGE);
                set.Add("INCLUDE_YN", INCLUDE_YN);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.XD1420_INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1420_INQUERY"), set);
                this.AfterInvokeServer();

                this.grd02.SetValue(source.Tables[0]);
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

        private void btn01_Inquery_Click_grid03()
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

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.XD1430_INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1430_INQUERY"), set);
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

        private DataTable getModule()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1300_INQUERY_MODULE"), set);
                
                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return null;
        }

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
