#region ▶ Description & History
/* 
 * 프로그램명 : 권한그룹 설정
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-01      배명희      프로그램 아이디 변경(XM60010 -> XM20001)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *              2014-07-15      배명희      cbo02_SYSTEMCODE 콤보상자 비활성 로직 제거(타 시스템의 권한 그룹도 등록하기 위해)
 *              2014-07-16      배명희      사용자 정보 코드박스의 연결 팝업 변경(퇴사자도 조회되는 팝업으로 교체) : CM20021P1 -> CM30020P1
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거
 *              2014-12-09      배명희     사용자별 권한그룹 그리드에 시스템정보 컬럼 추가. (GRD02에 SYSTEMCODE 추가 및 조회쿼리(APG_XM20001.INQUERY_XD1110)에 전달 파라메터(SYSTEMCODE) 추가.
 *              2015-04-13      김민재     유효성 표시(그룹아이디, 시스템코드. 그룸명)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// 권한그룹 설정
    /// </summary>
    public partial class XM20001 : AxCommonBaseControl 
    {       
        private bool _Isbinded;
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20001";
        public XM20001()
        {
            InitializeComponent();         
            _Isbinded = false;

            _WSCOM = new AxClientProxy();
        }

        #region [초기화 작업 정의]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable dtSystemCode = this.getSystemCode();
                this.cbo01_SYSTEMCODE.DataBind(dtSystemCode);
                this.cbo02_SYSTEMCODE.DataBind(dtSystemCode);

                this.grp01_XM20001_GRP_1.Text = this.GetLabel("XM20001_GRP_1");
                this.grp01_XM20001_GRP_2.Text = this.GetLabel("XM20001_GRP_2");
                this.grp01_XM20001_GRP_3.Text = this.GetLabel("XM20001_GRP_3");
                this.grp01_XM20001_GRP_4.Text = this.GetLabel("XM20001_GRP_4");
                
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "_시스템", "SYSTEMCODE","SYSTEMCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "_권한ID", "GROUPID","GROUPID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "_권한명", "GROUPNAME","GROUPNAME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "_설명", "GROUPNOTE","GROUPNOTE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtSystemCode, "SYSTEMCODE");

                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "_사용자ID", "USERID", "USERID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_사용자명", "USERNAME", "USERNAME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "_시스템", "SYSTEMCODE", "SYSTEMCODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "_권한ID", "GROUPID", "GROUPID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "_권한명", "GROUPNAME","GROUPNAME");
                this.grd02.CurrentContextMenu.Items[0].Visible = false;

                this.grd03.Initialize();
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_사용자ID", "USERID", "USERID");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "_사용자명", "USERNAME", "USERNAME");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "_직급", "TITLENM", "TITLENM4");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "_직책", "RESP_WORKNM", "RESP_WORKNM3");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "_팀명", "TEAMNM", "TEAMNM2");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_사원구분", "EMP_DIV", "EMP_DIV");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "_재직구분", "RETIRE_DIV_2", "RETIRE_DIV_2");
                
                this.txt01_GROUPID.SetValid(4, AxTextBox.TextType.OnlyNumber);
                this.txt02_GROUPID.SetValid(4, AxTextBox.TextType.OnlyNumber);

                this.cdx01_USERID.HEPopupHelper = new CM30020P1();
                this.cdx01_USERID.PopupTitle = this.GetLabel("EMP_INFO"); // "사원정보";
                this.cdx01_USERID.CodeParameterName = "EMPNO";
                this.cdx01_USERID.NameParameterName = "NAME_KOR";
                this.cdx01_USERID.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_USERID.HEParameterAdd("LANG_SET", this.UserInfo.Language);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                SetRequired(this.lbl02_GROUPID, this.lbl02_SYSTEMCODE, this.lbl02_GROUPNAME);
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

        #region [공통 버튼에 대한 이벤트]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("GROUPID", this.txt01_GROUPID.GetValue().ToString());
                set.Add("GROUPNAME", this.txt01_GROUPNAME.GetValue().ToString());
                set.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue().ToString());
                this.BeforeInvokeServer(true);
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
                this.txt02_GROUPID.Initialize();
                this.txt02_GROUPNAME.Initialize();
                this.txt02_GROUPNOTE.Initialize();
                this.txt02_GROUPID.SetReadOnly(false);
                this.cbo02_SYSTEMCODE.Initialize();
                _Isbinded = false;
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
            //try
            //{
                #region validations...

                if (this.txt02_GROUPID.IsEmpty)
                {
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_GROUPID.GetValue()); //MsgBox.Show("권한ID를 입력하세요.");
                    this.txt02_GROUPID.Focus();
                    return;
                }

                if (this.cbo02_SYSTEMCODE.IsEmpty)
                {
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_SYSTEMCODE.GetValue());//MsgBox.Show("시스템 코드를 선택하세요.");
                    this.cbo02_SYSTEMCODE.Focus();
                    return;
                }

                if (this.txt02_GROUPNAME.IsEmpty)
                {
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl02_GROUPNAME.GetValue());// MsgBox.Show("권한명을 입력하세요.");
                    this.txt02_GROUPNAME.Focus();
                    return;
                }

                #endregion

                //if (MsgBox.Show("입력하신 권한을 저장하시겠습니까?", "주의", 
                 if(MsgCodeBox.Show("XM00-0003", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "SYSTEMCODE", "GROUPID", "GROUPNAME", "GROUPNOTE");
    
                source.Tables[0].Rows.Add(
                    this.cbo02_SYSTEMCODE.GetValue(),
                    this.txt02_GROUPID.GetValue(),
                    this.txt02_GROUPNAME.GetValue(),
                    this.txt02_GROUPNOTE.GetValue());

                this.BeforeInvokeServer(true);
                 
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
               
                this.AfterInvokeServer();  
                 
                this.txt02_GROUPID.SetReadOnly(true);
                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("XM00-0002"); //MsgBox.Show("입력하신 권한을 저장하였습니다.");
            //}
            //catch (FaultException<ExceptionDetail> ex)
            //{
            //    this.AfterInvokeServer();
            //    MsgBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    this.AfterInvokeServer();
            //}
        }

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txt02_GROUPID.ReadOnly)
                {
                    MsgCodeBox.Show("XM00-0004");//MsgBox.Show("삭제할 권한을 선택하세요.");
                    return;
                }

                //if (MsgBox.Show("선택하신 권한을 삭제하시겠습니까?", "주의",
                if (MsgCodeBox.Show("XM00-0005", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                DataSet source = AxFlexGrid.GetDataSourceSchema("GROUPID");
                source.Tables[0].Rows.Add(this.txt02_GROUPID.GetValue());
                 
                this.BeforeInvokeServer(true);
                 
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
               
                this.AfterInvokeServer();                  

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
                MsgCodeBox.Show("XM00-0006"); // MsgBox.Show("선택하신 권한을 삭제하였습니다.");
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
        
        #region [기타 버튼에 대한 이벤트]

        private void btn03_QUERY_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cdx01_USERID.IsEmpty)
                {
                    MsgCodeBox.ShowFormat("XM00-0001", this.lbl03_USERID.GetValue()); // MsgBox.Show("사용자ID를 입력하세요.");
                    this.cdx01_USERID.Focus();
                    return;
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("USERID", this.cdx01_USERID.GetValue());
                set.Add("SYSTEMCODE", this.cbo01_SYSTEMCODE.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_AXD1110"), set); 
                this.AfterInvokeServer();

               
                this.grd02.SetValue(source);
                _Isbinded = true;
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

        private void btn03_COPY_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_Isbinded)
                {
                    MsgCodeBox.Show("XM00-0007");//MsgBox.Show("사용자ID로 권한을 먼저 조회하세요.");
                    this.cdx01_USERID.Focus();
                    return;
                }

                XM20001P1 form = new XM20001P1(this.GetLabel("XM20001P1"));
                //form.ShowDialog();
                this.ShowPopup(form);                

                string TOUSERID = form.Input_UserID;
                string USERID = this.cdx01_USERID.GetValue().ToString();
                string OPTION = form.Input_Option;
                if (TOUSERID.Length == 0)
                {
                    MsgCodeBox.Show("XM00-0008");//MsgBox.Show("복사작업이 취소되었습니다.");
                    return;
                }

                //if (MsgBox.Show("권한을 모두 복사하시겠습니까?", "주의",
                if (MsgCodeBox.Show("XM00-0009",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                
                DataSet source = AxFlexGrid.GetDataSourceSchema("TOUSERID", "USERID", "OPTION");
                source.Tables[0].Rows.Add(TOUSERID, USERID, OPTION);
                 
                this.BeforeInvokeServer(true);
                 
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "COPY_AXD1110"), source);
               
                this.AfterInvokeServer();                 

                this.cdx01_USERID.SetValue(TOUSERID);
                this.btn03_QUERY_Click(null, null);
                MsgCodeBox.Show("XM00-0010");//MsgBox.Show("조회된 권한을 모두 복사하였습니다.");
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

        private void btn03_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_Isbinded)
                {
                    MsgCodeBox.Show("XM00-0007");// MsgBox.Show("사용자ID로 권한을 먼저 조회하세요.");
                    this.cdx01_USERID.Focus();
                    return;
                }

                DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.Remove, "USERID", "GROUPID");
                if (source.Tables[0].Rows.Count == 0)
                {
                    MsgCodeBox.Show("XM00-0004");//MsgBox.Show("삭제할 권한을 선택하세요.");
                    return;
                }

                //if (MsgBox.Show("해당 사용자에 대해 선택하신 권한을 삭제하시겠습니까?", "주의",
                if (MsgCodeBox.Show("XM00-0011",
                    MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                this.BeforeInvokeServer(true);
                 
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_AXD1110"), source);
               
                this.AfterInvokeServer();                   
                 
                this.btn03_QUERY_Click(null, null);
                MsgCodeBox.Show("XM00-0012");//MsgBox.Show("조회된 사용자에 대해 선택하신 권한을 삭제하였습니다.");
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
        
        private void btn02_ADD_GROUP_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txt02_GROUPID.ReadOnly)
                {
                    MsgCodeBox.Show("XM00-0013");//MsgBox.Show("추가할 권한을 선택하세요.");
                    return;
                }

                if (!_Isbinded)
                {
                    MsgCodeBox.Show("XM00-0014");//MsgBox.Show("추가할 사용자ID로 권한을 먼저 조회하세요.");
                    this.cdx01_USERID.Focus();
                    return;
                }

                //if (MsgBox.Show("선택하신 권한을 해당 사용자의 권한그룹에 추가하시겠습니까?", "주의",
                if (MsgCodeBox.Show("XM00-0015",
                    MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                DataSet source = AxFlexGrid.GetDataSourceSchema("USERID", "GROUPID");
                source.Tables[0].Rows.Add(
                   this.cdx01_USERID.GetValue(), 
                   this.txt02_GROUPID.GetValue());
                 
                this.BeforeInvokeServer(true);
                 
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "ADD_AXD1110"), source);
               
                this.AfterInvokeServer();

                this.btn03_QUERY_Click(null, null);
                MsgCodeBox.Show("XM00-0016");//MsgBox.Show("선택하신 권한을 해당 사용자의 권한그룹에 추가하였습니다.");
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
        
        #region [기타 컨트롤에 대한 이벤트]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;

                this.txt02_GROUPID.SetValue(this.grd01.GetValue(row, "GROUPID"));
                this.txt02_GROUPNAME.SetValue(this.grd01.GetValue(row, "GROUPNAME"));
                this.txt02_GROUPNOTE.SetValue(this.grd01.GetValue(row, "GROUPNOTE"));
                this.cbo02_SYSTEMCODE.SetValue(this.grd01.GetValue(row, "SYSTEMCODE"));
                
                this.txt02_GROUPID.SetReadOnly(true);

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("GROUPID", this.grd01.GetValue(row, "GROUPID"));
                
                DataSet ds = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_USERBYGROUPID"), paramSet);
                this.grd03.SetValue(ds);

                this.cdx01_USERID.Initialize();
                this.grd02.InitializeDataSource();

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

        private void cdx01_USERID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btn03_QUERY_Click(null, null);
        }

        private void grd03_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int row = this.grd03.SelectedRowIndex;
            if (row < this.grd03.Rows.Fixed)
                return;
            
            this.cdx01_USERID.SetValue(this.grd03.GetValue(row, "USERID"));

            this.btn03_QUERY_Click(null, null);
        }

        #endregion                

        #region [사용자 정의 메서드]

        private DataTable getSystemCode()
        {
            try
            {                
                HEParameterSet set = new HEParameterSet();

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_SYSTEMCODE"), set);

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
