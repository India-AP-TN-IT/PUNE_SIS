#region ▶ Description & History
/* 
* 프로그램명 : PD201C0 사출수지 호퍼드라이어 관리
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
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    
    public partial class PD201C0 : AxCommonBaseControl
    {
        //private IPD201C0 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD201C0";

        #region [ 초기화 작업 정의 ]

        public PD201C0()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD201C0>("PD", "PD201C0.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable CORCD = this.GetCorCD().Tables[0];
                DataTable BIZCD = this.GetBizCD(this.UserInfo.CorporationCode).Tables[0];

                this.cbo01_CORCD.DataBind(CORCD);
                this.cbo01_BIZCD.DataBind(BIZCD);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD",  "COR");
                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 080, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 100, "라인번호", "LINECD", "BUZEI");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 130, "사출호기", "LINENM", "INJECTION_SEQ");   
                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 100, "금형번호", "MOLDNO", "MOLDNO");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 250, "금형명", "MOLDNM", "MOLDNM");        
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "호퍼드라이어 번호", "HOPPER", "HOPPER_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "등록일자", "UPDATE_DATE", "REG_DATE");        
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 070, "등록자ID", "EMPNO", "INSERT_USER_ID");

                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;
                this.grd01.CurrentContextMenu.Items[3].Visible = false;

                BtnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");


                if (source.Tables.Count>0)
                {
                    this.grd01.SetValue(source.Tables[0]);
                    //this.ShowMessage(source.Tables[0].Rows.Count.ToString() + "건 조회 되었습니다.");
                    this.ShowMessage(string.Format(TheOne.Text.MessageManager.GetMessage("CD00-0078"), source.Tables[0].Rows.Count));
                }
                else
                    this.grd01.InitializeDataSource();

                
                this.AfterInvokeServer();
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
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "LINECD", "MOLDNO", "HOPPER", "EMPNO");

                //if (!IsValidation(source)) return;

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    if (rows["HOPPER"].ToString() != "")
                    {
                        rows["CORCD"] = rows["CORCD"];
                        rows["BIZCD"] = rows["BIZCD"];
                        rows["LINECD"] = rows["LINECD"];
                        rows["MOLDNO"] = rows["MOLDNO"];
                        rows["HOPPER"] = rows["HOPPER"];
                        rows["EMPNO"] = UserInfo.EmpNo;
                    }
                }

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.cbo01_BIZCD.GetValue().ToString(), source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);

                //bool isSyncOK = this.DN_MESCODE(this.cbo01_BIZCD.GetValue().ToString());

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 사출수지 호퍼드라이어 정보가 저장되었습니다.");
                MsgCodeBox.Show("CD00-0009"); //정상적으로 저장되었습니다.
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

        #region [ 유효성 검사 ]

        private bool IsValidation(DataSet ds)
        {
            bool bRst = true;

            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                if (rows["HOPPER"].ToString().Trim() == "")
                {
                    //MsgBox.Show("호퍼드라이이 번호는 공백을 넣을수 없습니다");
                    MsgCodeBox.ShowFormat("CD00-0079", this.grd01.Cols["HOPPER"].Caption); //{0} 가(이) 입력되지 않았습니다.
                    bRst = false;
                    break;
                }
            }
            return bRst;
        }

        #endregion

        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES1280", bizcd).Tables[0].Rows[0][0].ToString();
        //        if (!msg.StartsWith("OK"))
        //        {
        //            if (bizcd.Equals("5210"))
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show("울산사업장 MESCODE 전송에 실패하였습니다.");
        //                return false;
        //            }
        //            else if (bizcd.Equals("5220"))
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show("아산사업장 MESCODE 전송에 실패하였습니다.");
        //                return false;

        //            }
        //            else
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show(msg);
        //                return false;
        //            }
        //        }

        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    return true;
        //}
    }
}
