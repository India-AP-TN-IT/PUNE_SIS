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

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 메뉴관리
    /// </summary>
    public partial class WM20450 : AxCommonBaseControl //HECommonUserControl//
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_WM20450";

        #region [ 초기화 작업 정의 ]

        public WM20450()
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
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "MENUID", "MENUID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "PMENUID", "PMENUID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 050, "SEQ", "ORD_SEQ");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "TYPE", "MENUTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "BEG_DATE", "BEG_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "END_DATE", "END_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "MENU NAME", "MENUNM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 200, "RUN_PGM", "RUN_PGM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 200, "COMMENT", "COMMENTS");

                DataSet dsMTY = AxFlexGrid.GetDataSourceSchema("CODE", "NAME");
                dsMTY.Tables[0].Rows.Add("R", "RUNABLE");
                dsMTY.Tables[0].Rows.Add("F", "FOLDER");
                this.cboMENUTY.DataBind(dsMTY.Tables[0]);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

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
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);        
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
                this.txtMENUID.Initialize();
                this.txtPMENUID.Initialize();
                this.txtMENUNM.Initialize();
                this.cboMENUTY.SetValue("R");
                this.txtRUN_PGM.Initialize();
                this.dtpBEG_DATE.Initialize();
                this.dtpEND_DATE.Initialize();
                this.txtORD_SEQ.SetValue("1");
                this.txtCOMMENTS.SetValue("");
                this.txtMENUID.SetReadOnly(false);
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

                if (this.txtMENUID.IsEmpty)
                {
                    //MsgBox.Show("메뉴ID를 입력하세요.");
                    MsgCodeBox.Show("XM00-0028");
                    this.txtMENUID.Focus();
                    return;
                }

                if (this.txtMENUNM.IsEmpty)
                {
                    //MsgBox.Show("메뉴명을 입력하세요.");
                    MsgCodeBox.Show("XM00-0029");
                    this.txtMENUNM.Focus();
                    return;
                }

                if (this.cboMENUTY.IsEmpty)
                {
                    //MsgBox.Show("메뉴행동을 선택하세요.");
                    MsgCodeBox.Show("XM00-0031");
                    this.cboMENUTY.Focus();
                    return;
                }

                if (Convert.ToString(cboMENUTY.GetValue()).Equals("R"))
                {
                    if (this.txtRUN_PGM.IsEmpty)
                    {
                        MsgCodeBox.ShowFormat("CD00-0079", lblPGMNM.Text); //{0} 가(이) 입력되지 않았습니다.
                        this.txtRUN_PGM.Focus();
                        return;
                    }
                }

                if (this.txtORD_SEQ.IsEmpty)
                {
                    //MsgBox.Show("정렬순서를 입력하세요.");
                    MsgCodeBox.Show("XM00-0032");
                    this.txtORD_SEQ.Focus();
                    return;
                }

                #endregion

                //if (MsgBox.Show("입력하신 메뉴를 저장하시겠습니까?", "주의", 
                if (MsgCodeBox.Show("XM00-0033", 
                    MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                string CORCD = UserInfo.CorporationCode;
                string BIZCD = UserInfo.BusinessCode;
                string MENUID = this.txtMENUID.GetValue().ToString();
                string PMENUID = this.txtPMENUID.GetValue().ToString();
                string ORD_SEQ = this.txtORD_SEQ.GetValue().ToString();
                string MENUNM = this.txtMENUNM.GetValue().ToString();
                string MENUTY = this.cboMENUTY.GetValue().ToString();
                string RUN_PGM = this.txtRUN_PGM.GetValue().ToString();
                string BEG_DATE = this.dtpBEG_DATE.GetValue().ToString();
                string END_DATE = this.dtpEND_DATE.GetValue().ToString();
                string USERID = UserInfo.UserID;
                string COMMENTS = this.txtCOMMENTS.GetValue().ToString();
                
                DataSet source = AxFlexGrid.GetDataSourceSchema(
                    "CORCD",
                    "BIZCD",
                    "MENUID",
                    "PMENUID",
                    "ORD_SEQ",
                    "MENUNM",
                    "MENUTY",
                    "RUN_PGM",
                    "BEG_DATE",
                    "END_DATE",
                    "USERID",
                    "COMMENTS");

                source.Tables[0].Rows.Add(
                        CORCD,
                        BIZCD,
                        MENUID,
                        PMENUID,
                        ORD_SEQ,
                        MENUNM,
                        MENUTY,
                        RUN_PGM,
                        BEG_DATE,
                        END_DATE,
                        USERID,
                        COMMENTS);

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.txtMENUID.SetReadOnly(true);
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
                if (!this.txtMENUID.ReadOnly)
                {
                    //MsgBox.Show("삭제할 메뉴를 선택하세요.");
                    MsgCodeBox.Show("XM00-0035");
                    return;
                }

                //--삭제하기 전에 하위 메뉴가 존재하는지 체크 (tree구조에서 항상 마지막 레벨의 데이터 부터 삭제되도록)
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", UserInfo.BusinessCode);
                set.Add("MENUID", this.txtMENUID.GetValue());
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

                HEParameterSet setDEL = new HEParameterSet();
                setDEL.Add("CORCD", UserInfo.CorporationCode);
                setDEL.Add("BIZCD", UserInfo.BusinessCode);
                setDEL.Add("MENUID", this.txtMENUID.GetValue());

                this.BeforeInvokeServer(true);
               // _WSCOM.REMOVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), setDEL);
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

        private void grdMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.grd01.SelectedRowIndex < this.grd01.Rows.Fixed)
                return;

            this.txtMENUID.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "MENUID"));
            this.txtPMENUID.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "PMENUID"));
            this.txtORD_SEQ.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "ORD_SEQ"));
            this.txtMENUNM.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "MENUNM"));
            this.cboMENUTY.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "MENUTY"));
            this.txtRUN_PGM.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "RUN_PGM"));
            this.dtpBEG_DATE.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "BEG_DATE"));
            this.dtpEND_DATE.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "END_DATE"));
            this.txtCOMMENTS.SetValue(this.grd01.GetValue(this.grd01.SelectedRowIndex, "COMMENTS"));

            this.txtMENUID.SetReadOnly(true);
        }

        private void grdResize(object sender, EventArgs e)
        {
            //if (this.grd01 == null || 
            //    this.grd01.Cols["MENUNM"] == null) return;

            //if (this.grd01.Width > 560)
            //    this.grd01.Cols["MENUNM"].Width = this.grd01.Cols["MENUNM"].Width + (this.grd01.Width - 360);
            //else
            //    this.grd01.Cols["MENUNM"].Width = (this.grd01.Width - 360);
        }
        
        #endregion

        private void btnCPOY_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtMENUID.ReadOnly)
                {
                    //MsgBox.Show("복사할 메뉴를 선택하세요.");
                    MsgCodeBox.Show("XM00-0146");
                    return;
                }

                this.txtMENUID.Initialize();
                this.txtMENUID.SetReadOnly(false);
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

        private void cboMENUTY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(cboMENUTY.GetValue()).Equals("F"))
            {
                this.txtRUN_PGM.Text = string.Empty;
                this.txtRUN_PGM.Enabled = false;
            }
            else
            {
                this.txtRUN_PGM.Enabled = true;
            }
        }
    }
}
