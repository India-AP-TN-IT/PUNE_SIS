#region ▶ Description & History
/* 
 * 프로그램명 : 메뉴관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-02      배명희      프로그램 아이디 변경(XM60000 -> XM20005)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
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
    /// 메뉴관리
    /// </summary>
    public partial class XM20005 : AxCommonBaseControl //HECommonUserControl//
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20005";
        private string PAKAGE_NAME_XM20001 = "APG_XM20001";

        private bool _isLoadCompleted = false;

        #region [ 초기화 작업 정의 ]

        public XM20005()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
              
                //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "_메뉴아이디", "MENUID", "MENUID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_상위메뉴", "PARENTID_TM", "PARENTID_TM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "_사용여부", "USEYN", "USEYN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 070, "_정렬순서", "MENUORDER", "MENUORDER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "_메뉴명", "MENUNM", "MENUNM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "USEYN");

                this.grd02.Initialize();
                
                //this.grd02.Cols.RemoveRange(1, this.grd02.Cols.Count - 1);
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "_그룹ID", "GROUPID", "GROUPID");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "_그룹명", "GROUPNAME", "GROUPNAME");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_생성", "BASICACLC3", "BASICACLC3");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_읽기", "BASICACLR3", "BASICACLR3");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_수정", "BASICACLU2", "BASICACLU2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_삭제", "BASICACLD2", "BASICACLD2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_리셋", "EXTACL1_2", "EXTACL1_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_처리", "EXTACL2_2", "EXTACL2_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_출력", "EXTACL3_2", "EXTACL3_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_다운", "EXTACL4_2", "EXTACL4_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "_업", "EXTACL5_2", "EXTACL5_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLC3");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLR3");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLU2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLD2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL1_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL2_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL3_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL4_2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL5_2");


                this.grd_UserListByMenu.Initialize();
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "사용자ID", "USERID", "USERID");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "사용자명", "USERNAME", "USERNAME");
                this.grd_UserListByMenu.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "그룹ID", "GROUPID", "GROUPID");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "그룹명", "GROUPNAME", "GROUPNAME");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "생성", "BASICACLC", "BASICACLC3");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "읽기", "BASICACLR", "BASICACLR3");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "수정", "BASICACLU", "BASICACLU2");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "삭제", "BASICACLD", "BASICACLD2");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "리셋", "EXTACL1", "EXTACL1_2");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "처리", "EXTACL2", "EXTACL2_2");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "출력", "EXTACL3", "EXTACL3_2");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "다운", "EXTACL4", "EXTACL4_2");
                this.grd_UserListByMenu.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 35, "업", "EXTACL5", "EXTACL5_2");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLC");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLR");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLU");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "BASICACLD");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL1");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL2");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL3");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL4");
                this.grd_UserListByMenu.SetColumnType(AxFlexGrid.FCellType.Check, "EXTACL5");

                DataTable source2 = this.getSystemCode();
                this.cbo01_SYSTEMCODE.DataBind(source2, false);
                this.cbo01_SYSTEMCODE.SetValue(this.UserInfo.SystemCode);

                this.cbo02_SYSTEMCODE.DataBind(source2, false);

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("DIVISION", "A");
                set1.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set1.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source1 = _WSCOM.INQUERY_CODE(set1);
                DataSet source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE"), set1);
                this.cbo01_CODE.DataBind(source1.Tables[0]);               

                DataSet source3 = AxFlexGrid.GetDataSourceSchema("CODE", "NAME");
                source3.Tables[0].Rows.Add("0", "NONE");
                source3.Tables[0].Rows.Add("1", "NAVIGATE");
                source3.Tables[0].Rows.Add("2", "OPENUI");
                source3.Tables[0].Rows.Add("3", "EXPAND");
                this.cbo02_MENUACTION.DataBind(source3.Tables[0]);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                _isLoadCompleted = true;
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

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {                
                HEParameterSet set = new HEParameterSet();
                set.Add("PARENTID", this.cbo01_CODE.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), set);
                this.AfterInvokeServer();
                
                this.grd01.SetValue(source);
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
                this.txt02_MENUID.Initialize();
                this.txt02_MENUNAME.Initialize();
                this.cbo02_SYSTEMCODE.SetValue("ERM");
                this.cbo02_MENUACTION.Initialize();
                this.chk02_MENUHIDE3.Initialize();
                this.chk02_FORCEENABLED3.Initialize();
                this.chk02_EXPANDED3.Initialize();
                this.chk02_USEYN2.SetValue(true);
                //this.txt02_MENUDLLURL.SetValue("http://erm.hanileh.com/erm/smartclient/");
                this.txt02_MENUDLLURL.Initialize();
                this.txt02_MENUCLASS.Initialize();
                this.txt02_PARENTID.Initialize();
                this.txt02_MENUORDER.SetValue("0");
                this.txt02_EXTRAINFO.Initialize();

                HEParameterSet set = new HEParameterSet();
                set.Add("DIVISION", "B");
                set.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source = _WSCOM.INQUERY_CODE(set);
                
                DataSet source= _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE"), set);
                this.grd02.SetValue(source);

                this.txt02_MENUID.SetReadOnly(false);
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region validations...

                if (this.txt02_MENUID.IsEmpty)
                {
                    //MsgBox.Show("메뉴ID를 입력하세요.");
                    MsgCodeBox.Show("XM00-0028");
                    this.txt02_MENUID.Focus();
                    return;
                }

                if (this.txt02_MENUNAME.IsEmpty)
                {
                    //MsgBox.Show("메뉴명을 입력하세요.");
                    MsgCodeBox.Show("XM00-0029");
                    this.txt02_MENUNAME.Focus();
                    return;
                }

                if (this.cbo02_SYSTEMCODE.IsEmpty)
                {
                    //MsgBox.Show("시스템 코드를 선택하세요.");
                    MsgCodeBox.Show("XM00-0030");
                    this.cbo02_SYSTEMCODE.Focus();
                    return;
                }

                if (this.cbo02_MENUACTION.IsEmpty)
                {
                    //MsgBox.Show("메뉴행동을 선택하세요.");
                    MsgCodeBox.Show("XM00-0031");
                    this.cbo02_MENUACTION.Focus();
                    return;
                }

                if (this.txt02_MENUORDER.IsEmpty)
                {
                    //MsgBox.Show("정렬순서를 입력하세요.");
                    MsgCodeBox.Show("XM00-0032");
                    this.txt02_MENUORDER.Focus();
                    return;
                }

                #endregion

                //if (MsgBox.Show("입력하신 메뉴를 저장하시겠습니까?", "주의", 
                if (MsgCodeBox.Show("XM00-0033", 
                    MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
                
                string MENUID = this.txt02_MENUID.GetValue().ToString();       
                string SYSTEMCODE = this.cbo02_SYSTEMCODE.GetValue().ToString();  
                string MENUNAME = this.txt02_MENUNAME.GetValue().ToString();        
                string MENUACTION = this.cbo02_MENUACTION.GetValue().ToString();     
                string MENUHIDE = this.chk02_MENUHIDE3.Checked ? "1" : "0";  
                string FORCEENABLED = this.chk02_FORCEENABLED3.Checked ? "1" : "0";   
                string EXPANDED = this.chk02_EXPANDED3.Checked ? "1" : "0";       
                string MENUDLLURL = this.txt02_MENUDLLURL.GetValue().ToString();   
                string MENUCLASS = this.txt02_MENUCLASS.GetValue().ToString(); 
                string PARENTID = this.txt02_PARENTID.GetValue().ToString();        
                string EXTRAINFO = this.txt02_EXTRAINFO.GetValue().ToString();      
                string MENUORDER = this.txt02_MENUORDER.GetValue().ToString();   
                string USEYN = this.chk02_USEYN2.Checked ? "1" : "0";         
                string MANAGERNO = this.UserInfo.UserID;

                string GROUPID = "0";        
                string BASICACLC = "0";        
                string BASICACLR = "0";        
                string BASICACLU = "0";       
                string BASICACLD = "0";        
                string EXTACL1 = "0";        
                string EXTACL2 = "0";         
                string EXTACL3 = "0";        
                string EXTACL4 = "0";        
                string EXTACL5 = "0";

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "LANG_SET", "MENUID", "SYSTEMCODE", "MENUNAME", "MENUACTION", "MENUHIDE", "FORCEENABLED",
                    "EXPANDED", "MENUDLLURL", "MENUCLASS", "PARENTID", "EXTRAINFO", "MENUORDER", "USEYN", "MANAGERNO",
                    "GROUPID", "BASICACLC", "BASICACLR", "BASICACLU", "BASICACLD", "EXTACL1", "EXTACL2", "EXTACL3", "EXTACL4", "EXTACL5");
    
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    GROUPID = this.grd02.GetValue(i, "GROUPID").ToString();
                    BASICACLC = this.grd02.GetValue(i, "BASICACLC3").ToString().Equals("Y") ? "1" : "0";
                    BASICACLR = this.grd02.GetValue(i, "BASICACLR3").ToString().Equals("Y") ? "1" : "0";
                    BASICACLU = this.grd02.GetValue(i, "BASICACLU2").ToString().Equals("Y") ? "1" : "0";
                    BASICACLD = this.grd02.GetValue(i, "BASICACLD2").ToString().Equals("Y") ? "1" : "0";
                    EXTACL1 = this.grd02.GetValue(i, "EXTACL1_2").ToString().Equals("Y") ? "1" : "0";
                    EXTACL2 = this.grd02.GetValue(i, "EXTACL2_2").ToString().Equals("Y") ? "1" : "0";
                    EXTACL3 = this.grd02.GetValue(i, "EXTACL3_2").ToString().Equals("Y") ? "1" : "0";
                    EXTACL4 = this.grd02.GetValue(i, "EXTACL4_2").ToString().Equals("Y") ? "1" : "0";
                    EXTACL5 = this.grd02.GetValue(i, "EXTACL5_2").ToString().Equals("Y") ? "1" : "0";

                    source.Tables[0].Rows.Add(this.UserInfo.Language,
                        MENUID, SYSTEMCODE, MENUNAME, MENUACTION, MENUHIDE, FORCEENABLED,
                        EXPANDED, MENUDLLURL, MENUCLASS, PARENTID, EXTRAINFO, MENUORDER, USEYN, MANAGERNO,
                        GROUPID, BASICACLC, BASICACLR, BASICACLU, BASICACLD, EXTACL1, EXTACL2, EXTACL3, EXTACL4, EXTACL5);
                }

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.txt02_MENUID.SetReadOnly(true);
                this.BtnQuery_Click(null, null);
                //MsgBox.Show("선택하신 메뉴를 저장하였습니다.");
                MsgCodeBox.Show("XM00-0034");
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
                if (!this.txt02_MENUID.ReadOnly)
                {
                    //MsgBox.Show("삭제할 메뉴를 선택하세요.");
                    MsgCodeBox.Show("XM00-0035");
                    return;
                }

                //--삭제하기 전에 하위 메뉴가 존재하는지 체크 (tree구조에서 항상 마지막 레벨의 데이터 부터 삭제되도록)
                HEParameterSet set = new HEParameterSet();
                set.Add("SYSTEMCODE", this.cbo02_SYSTEMCODE.GetValue());
                set.Add("MENUID", this.txt02_MENUID.GetValue());
                DataSet sub =  _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SUB_MENU"), set);
                if (sub.Tables[0].Rows[0][0].ToString() != "0")
                {
                    MsgCodeBox.Show("CD00-0100"); //하위 데이터가 존재하여 삭제할 수 없습니다.
                    return;
                }
                //--


                //if (MsgBox.Show("선택하신 메뉴를 삭제하시겠습니까?", "주의",
                if (MsgCodeBox.Show("XM00-0036",
                    MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                DataSet source = AxFlexGrid.GetDataSourceSchema("MENUID");
                source.Tables[0].Rows.Add(this.txt02_MENUID.GetValue());

                this.BeforeInvokeServer(true);
               // _WSCOM.REMOVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                //MsgBox.Show("선택하신 메뉴를 삭제하였습니다.");
                MsgCodeBox.Show("XM00-0037");
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

        #region [ 기타 이벤트 정의 ]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.grd01.SelectedRowIndex < this.grd01.Rows.Fixed)
                    return;

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("DIVISION", "C");
                set1.Add("MENUID", this.grd01.GetValue(this.grd01.SelectedRowIndex, "MENUID"));
                set1.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set1.Add("LANG_SET", this.UserInfo.Language);

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("DIVISION", "D");
                set2.Add("MENUID", this.grd01.GetValue(this.grd01.SelectedRowIndex, "MENUID"));
                set2.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set2.Add("LANG_SET", this.UserInfo.Language);
                
                HEParameterSet set3 = new HEParameterSet();
                set3.Add("DIVISION", "E");
                set3.Add("MENUID", this.grd01.GetValue(this.grd01.SelectedRowIndex, "MENUID"));
                set3.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set3.Add("LANG_SET", this.UserInfo.Language); 
                
                this.BeforeInvokeServer(true);

                ////DataSet source1 = _WSCOM.INQUERY_CODE(set1);
                //DataSet source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE"), set1);
                ////DataSet source2 = _WSCOM.INQUERY_CODE(set2);
                //DataSet source2 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE"), set2);

                System.Collections.Generic.List<HEParameterSet> paramList = new System.Collections.Generic.List<HEParameterSet>();
                paramList.Add(set1);
                paramList.Add(set2);
                paramList.Add(set3);
                DataSet ds = _WSCOM.MultipleExecuteDataSet(new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE"), 
                                                                          string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE"), 
                                                                          string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE") }, 
                                                           paramList);                

                
                this.AfterInvokeServer();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = ds.Tables[0].Rows[0];

                    this.txt02_MENUID.SetValue(r["MENUID"]);
                    this.txt02_MENUNAME.SetValue(r["MENUNAME"]);
                    this.cbo02_SYSTEMCODE.SetValue(r["SYSTEMCODE"]);
                    this.cbo02_MENUACTION.SetValue(r["MENUACTION"]);
                    this.chk02_MENUHIDE3.SetValue(r["MENUHIDE"]);
                    this.chk02_FORCEENABLED3.SetValue(r["FORCEENABLED"]);
                    this.chk02_EXPANDED3.SetValue(r["EXPANDED"]);
                    this.chk02_USEYN2.SetValue(r["USEYN"]);
                    this.txt02_MENUDLLURL.SetValue(r["MENUDLLURL"]);
                    this.txt02_MENUCLASS.SetValue(r["MENUCLASS"]);
                    this.txt02_PARENTID.SetValue(r["PARENTID"]);
                    this.txt02_EXTRAINFO.SetValue(r["EXTRAINFO"]);
                    this.txt02_MENUORDER.SetValue(r["MENUORDER"]);
                }

                this.grd02.SetValue(ds.Tables[1]);
                this.grd_UserListByMenu.SetValue(ds.Tables[2]);
                this.txt02_MENUID.SetReadOnly(true);
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

        private void btn02_CPOY_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txt02_MENUID.ReadOnly)
                {
                    //MsgBox.Show("복사할 메뉴를 선택하세요.");
                    MsgCodeBox.Show("XM00-0146");
                    return;
                }

                this.txt02_MENUID.Initialize();
                this.txt02_MENUID.SetReadOnly(false);
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

        private void grd01_Resize(object sender, EventArgs e)
        {
            if (this.grd01 == null || 
                this.grd01.Cols["MENUNM"] == null) return;

            if (this.grd01.Width > 524)
                this.grd01.Cols["MENUNM"].Width = 240 + (this.grd01.Width - 524);
            else
                this.grd01.Cols["MENUNM"].Width = 240;
        }

        private void cbo01_SYSTEMCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoadCompleted) return;

            try
            {
                HEParameterSet set1 = new HEParameterSet();
                set1.Add("DIVISION", "A");
                set1.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());
                set1.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source1 = _WSCOM.INQUERY_CODE(set1);
                DataSet source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_CODE"), set1);
                this.cbo01_CODE.DataBind(source1.Tables[0]);

                BtnReset_Click(null, null);
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

        #endregion

        #region private methods...

        //시스템코드 콤보상자용 데이터 조회
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

        private void SetListBoxMultiItems(ListBox list, params string[] parameter)
        {
            for (int i = 0; i < list.Items.Count; i++)
                for (int j = 0; j < parameter.Length; j++)
                    if (((DataRowView)list.Items[i]).Row[0].ToString().Equals(parameter[j]))
                        list.SetSelected(i, true);
        }

        private string[] GetListBoxMultiItems(ListBox list)
        {
            string[] parameter = new string[list.SelectedItems.Count];
            for (int i = 0; i < list.SelectedItems.Count; i++)
                parameter[i] = ((DataRowView)list.SelectedItems[i]).Row[0].ToString();

            return parameter;
        }

        #endregion

    }
}
