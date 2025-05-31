#region ▶ Description & History
/* 
 * 프로그램명 : PD20340 PDA-SMS 호출 그룹 관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 : 
 * 
 *				날짜			    작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09      배명희         SIS 이관
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
    /// <summary>
    /// PDA-SMS 호출 그룹 관리
    /// </summary>
    public partial class PD20340 : AxCommonBaseControl
    {
        //private IPD20340 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20340";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        public PD20340()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20340>("PD", "PD20340.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                this.grd01.EnabledActionFlag = false;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "부서", "LINENM", "DEPART");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "사번", "EMPNO", "EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "이름", "NAME_KOR", "HR_NAME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "휴대폰번호", "MOBILE", "CELLNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "등록", "IN_CHECK", "REGIST");

                this.grd01.Cols["LINENM"].AllowMerging = true;

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "IN_CHECK");

                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);

                this.grd02.AllowEditing = true;
                this.grd02.Initialize(2, 2);
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "법인", "CORCD", "COR");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "사업장", "BIZCD", "BIZNM2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "코드", "SMS_TYPE", "CODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "명칭", "SMS_TYPENM", "INSPEC_POSNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "코드", "PDA_SMS_GROUP","CODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "명칭", "PDA_SMS_GROUPNM","INSPEC_POSNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "사번", "EMPNO", "EMPNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "이름", "NAME_KOR","HR_NAME");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "사용여부", "USE_YN", "USEYN");

                this.grd02.Cols["CORCD"].AllowMerging = true;
                this.grd02.Cols["BIZCD"].AllowMerging = true;
                this.grd02.Cols["SMS_TYPE"].AllowMerging = true;
                this.grd02.Cols["SMS_TYPENM"].AllowMerging = true;
                this.grd02.Cols["PDA_SMS_GROUP"].AllowMerging = true;
                this.grd02.Cols["PDA_SMS_GROUPNM"].AllowMerging = true;

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");
                         
                this.grd02.CurrentContextMenu.Items.RemoveAt(0);

                #region [Grid Merge]

                for (int i = 0; i < grd02.Cols.Count; i++)
                    this.grd02[1, i] = this.grd02.Cols[i].Caption;

                this.grd02.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd02.AddMerge(0, 1, "BIZCD", "BIZCD");

                this.grd02.AddMerge(0, 0, "SMS_TYPE", "SMS_TYPENM");
                this.grd02.SetHeadTitle(0, "SMS_TYPE", this.GetLabel("SMS_TYPE2"));//"SMS업무");

                this.grd02.AddMerge(0, 0, "PDA_SMS_GROUP", "USE_YN");
                this.grd02.SetHeadTitle(0, "PDA_SMS_GROUP", this.GetLabel("PDA_SMS_GROUP"));//"호출그룹");//@@@

                this.grd02.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;

                #endregion


                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                //this.BtnQuery_Click(null, null);
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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", bizcd);
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("SMS_TYPE", this.cbo01_SMS_TYPE.GetValue());
                set.Add("PDA_SMS_GROUP", this.cbo01_PDA_SMS_GROUP.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
//                DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd02.SetValue(source.Tables[0]);

                this.chk01_MERGE_CheckedChanged(null, null);
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
                DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "PDA_SMS_GROUP", "SMS_TYPE", "EMPNO", "USE_YN", "REG_EMPNO");

                foreach (DataRow row in source.Tables[0].Rows)
                {
                    row["USE_YN"] = row["USE_YN"].ToString().Equals("Y") ? 1 : 0;
                    row["REG_EMPNO"] = this.UserInfo.EmpNo;
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);


                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 PDA - SMS 호출 그룹 정보가 저장되었습니다.");
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

        protected override void  BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.Remove,
                    "CORCD", "BIZCD", "SMS_TYPE", "PDA_SMS_GROUP", "EMPNO");

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 PDA - SMS 호출 그룹 정보가 삭제되었습니다");
                MsgCodeBox.Show("CD00-0010"); //정상적으로 삭제되었습니다.
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

        private void btn02_INQ_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl02_LINECD.GetValue());
                set.Add("NAME_KOR", this.txt02_NAME_KOR.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_EMP(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_EMP"), set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);

                this.chk01_MERGE_CheckedChanged(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_SAV_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] grd01_rows = ((DataTable)this.grd01.GetValue()).Select("IN_CHECK = '1'");

                DataSet source = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("CORCD");
                dt.Columns.Add("BIZCD");
                dt.Columns.Add("PDA_SMS_GROUP");
                dt.Columns.Add("SMS_TYPE");
                dt.Columns.Add("EMPNO");
                dt.Columns.Add("USE_YN");
                dt.Columns.Add("REG_EMPNO");

                source.Tables.Add(dt);

                foreach (DataRow grd01_row in grd01_rows)
                {
                    dt.Rows.Add(
                            this.UserInfo.CorporationCode,
                            this.cbo01_BIZCD.GetValue(),
                            this.cbo01_PDA_SMS_GROUP.GetValue(),
                            this.cbo01_SMS_TYPE.GetValue(),
                            grd01_row["EMPNO"],
                            1,
                            this.UserInfo.EmpNo
                    );
                }

                if (!IsSaveBatchValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);

                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.btn02_INQ_Click(null, null);
                //MsgBox.Show("입력하신 PDA - SMS 호출 그룹 정보가 일괄 저장되었습니다.");
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

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_SMSTYPELIST"), set).Tables[0];
                //DataTable source1 = _WSCOM_MES.INQUERY_COMBO_SMSTYPELIST(bizcd).Tables[0];

                this.cbo01_SMS_TYPE.DataBind(source1);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_SMS_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", bizcd);
                set.Add("DCODE", this.cbo01_SMS_TYPE.GetValue());

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_PDASMSGROUP"), set).Tables[0];
                //DataTable source = _WSCOM_MES.INQUERY_COMBO_PDASMSGROUP(bizcd, set).Tables[0];

                this.cbo01_PDA_SMS_GROUP.DataBind(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk01_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.grd01.AllowMerging = (this.chk01_GRID_MERGE.Checked == true) ?
                    C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                    C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd02.AllowMerging = (this.chk01_GRID_MERGE.Checked == true) ?
                    C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                    C1.Win.C1FlexGrid.AllowMergingEnum.None;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl02_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", bizcd);

                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_DEPARTMENT"), set).Tables[0];
                //DataTable source2 = _WSCOM_ERM.INQUERY_COMBO_DEPARTMENT(set).Tables[0];
                this.cbl02_LINECD.DataBind(source2, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");//라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 PDA - SMS 호출 그룹 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042"); //저장할 데이터가 존재하지 않습니다.
                    return false;
                }

                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK) //저장하시겠습니까?
                //if (MsgBox.Show("입력하신 PDA - SMS 호출 그룹 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsSaveBatchValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 PDA - SMS 호출 그룹 정보가 존재하지 않습니다.");//@@@
                    MsgCodeBox.Show("COM-00020");//저장할 대상 Data가 없습니다. @@@
                    return false;
                }

                if (this.cbo01_SMS_TYPE.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("호출 업무가 선택되지 않습니다.");//@@@
                    MsgCodeBox.ShowFormat("CD00-0080", this.lbl01_SMS_TYPE.Text); //{0}가(이) 선택되지 않았습니다. @@@
                    return false;
                }

                if (this.cbo01_PDA_SMS_GROUP.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("호출 그룹이 선택되지 않습니다.");//@@@
                    MsgCodeBox.ShowFormat("CD00-0080", this.lbl01_PDA_SMS_GROUP.Text); //{0}가(이) 선택되지 않았습니다. @@@
                    return false;
                }

                //if (MsgBox.Show("입력하신 PDA - SMS 호출 그룹 정보를 일괄 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)//데이터를 저장하시겠습니까? 
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
                    //MsgBox.Show("삭제할 PDA - SMS 호출 그룹 정보가 존재하지 않습니다.");//@@@
                    MsgCodeBox.Show("COM-00023"); //삭제할 대상 Data가 없습니다. @@@
                    return false;
                }

                //if (MsgBox.Show("선택하신 PDA - SMS 호출 그룹 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@
                if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel) != DialogResult.OK)//데이터를 삭제하시겠습니까? @@@
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

        #region [미들서버에 코드정보 전송]
        //2014.02.10 - MES9908 SMS호출 - 대상자 관리 MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES9908", bizcd).Tables[0].Rows[0][0].ToString();

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
        #endregion
    }
}
