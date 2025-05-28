#region ▶ Description & History
/* 
 * 프로그램명 : PD20360 SMS 호출 - 공정
 * 설     명 : 
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
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// SMS호출 - 공정 관리
    /// </summary>
    public partial class PD20360 : AxCommonBaseControl
    {
        private bool _IsBinded;
        //private IPD20360 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20360";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;

        public PD20360()
        {
            _IsBinded = false;

            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20360>("PD", "PD20360.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo02_BIZCD.SetReadOnly(true);
                this.cbo02_CORCD.SetReadOnly(true);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2);
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD", "COR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "코드", "LINECD", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "명칭", "LINENM", "INSPEC_POSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "장착\n위치", "INSTALL_POS", "POSTITLE_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "코드", "PROCCD", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "명칭", "PROCNM", "INSPEC_POSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "설비\n공정", "EQUIP_YN", "EQUIP_PROC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "코드", "SMS_TYPE", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "명칭", "SMS_TYPE_NM", "INSPEC_POSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "포인트", "SMS_POINT", "SMS_POINT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "사용", "USE_YN", "USEYN2");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "EQUIP_YN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");

                #region [Grid Merge]

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd01.AddMerge(0, 1, "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddMerge(0, 1, "EQUIP_YN", "EQUIP_YN");

                this.grd01.AddMerge(0, 0, "LINECD", "LINENM");
                this.grd01.SetHeadTitle(0, "LINECD", this.GetLabel("LINE"));//"라인");

                this.grd01.AddMerge(0, 0, "PROCCD", "PROCNM");
                this.grd01.SetHeadTitle(0, "PROCCD", this.GetLabel("MACHINEPLC")); //"설비");

                this.grd01.AddMerge(0, 0, "SMS_TYPE", "USE_YN");
                this.grd01.SetHeadTitle(0, "SMS_TYPE", this.GetLabel("SMS_TYPE2"));//"SMS 업무");

                #endregion

                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "사번", "EMPNO", "EMPNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "이름", "NAME_KOR", "HR_NAME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "휴대폰번호", "MOBILE", "CELLNO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "사용여부", "USE_YN", "USEYN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "Button", "BTN_TY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");

                this.grd02.CurrentContextMenu.Items.RemoveAt(0);

                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.EnabledActionFlag = false;

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "부서", "LINENM", "DEPART");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "사번", "EMPNO", "EMPNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "이름", "NAME_KOR", "HR_NAME");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "휴대폰번호", "MOBILE", "CELLNO");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "등록", "IN_CHECK", "REGIST");

                this.grd03.SetColumnType(AxFlexGrid.FCellType.Check, "IN_CHECK");

                this.grd03.CurrentContextMenu.Items.RemoveAt(0);
                this.grd03.CurrentContextMenu.Items.RemoveAt(0);
                this.grd03.CurrentContextMenu.Items.RemoveAt(0);
                this.grd03.CurrentContextMenu.Items.RemoveAt(0);

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST().Tables[0];

                this.cbo02_CORCD.DataBind_CORCD(false);
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo02_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbl02_INSTALL_POS.DataBind(source, this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");//"타입코드;타입명", "C;L");//@@@

                this.SetRequired(lbl02_COR, lbl02_BIZNM2, lbl02_LINE, lbl02_PROCINFO, lbl02_POSTITLE, lbl02_SMS_TYPE, lbl02_SMS_POINT);

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                _IsBinded = false;

                this.cbo02_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbl02_INSTALL_POS.Initialize();
                this.cbl02_LINECD.Initialize();
                this.cbl02_PROCCD.Initialize();
                this.cbo02_SMS_TYPE.Initialize();
                this.nme02_SMS_POINT.Initialize();
                this.chk02_EQUIP_PROC_YN.SetValue("N");
                this.chk02_USEYN2.SetValue("Y");

                this.cbl04_LINECD.Initialize();
                this.txt04_NAME_KOR.Initialize();

                this.grd02.InitializeDataSource();
                this.grd03.InitializeDataSource();

                this.cbl02_LINECD.SetReadOnly(false);
                this.cbl02_PROCCD.SetReadOnly(false);
                this.cbl02_INSTALL_POS.SetReadOnly(false);

                this.btn03_SAVE.Enabled = false;
                this.btn03_DELETE.Enabled = false;
                this.btn04_INQUERY.Enabled = false;
                this.btn04_REGIST.Enabled = false;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("SMS_TYPE", this.cbo01_SMS_TYPE.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

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
        
        
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsSaveValid()) return;

                string CORCD = this.cbo02_CORCD.GetValue().ToString();
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string PROCCD = this.cbl02_PROCCD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "PROCCD", "INSTALL_POS", "EQUIP_YN", "SMS_TYPE", "SMS_POINT", "USE_YN", "EMPNO");

                source.Tables[0].Rows.Add(
                    this.cbo02_CORCD.GetValue(),
                    this.cbo02_BIZCD.GetValue(),
                    this.cbl02_LINECD.GetValue(),
                    this.cbl02_PROCCD.GetValue(),
                    this.cbl02_INSTALL_POS.GetValue(),
                    this.chk02_EQUIP_PROC_YN.GetValue().ToString().Equals("Y") ? 1 : 0,
                    this.cbo02_SMS_TYPE.GetValue(),
                    this.nme02_SMS_POINT.GetDBValue(),
                    this.chk02_USEYN2.GetValue().ToString().Equals("Y") ? 1 : 0,
                    this.UserInfo.EmpNo
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_MES9906(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_MES9906"), source);


                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE_MES9906(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.Inquery(CORCD, BIZCD, LINECD, PROCCD, INSTALL_POS);

                //MsgBox.Show("입력하신 SMS호출 - 공정 정보가 저장되었습니다.");//@@@
                MsgCodeBox.Show("CD00-0071"); //저장되었습니다.//@@@
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
                if (!IsDeleteValid()) return;

                DataSet source = this.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "PROCCD", "INSTALL_POS");

                source.Tables[0].Rows.Add(
                    this.cbo02_CORCD.GetValue(),
                    this.cbo02_BIZCD.GetValue(),
                    this.cbl02_LINECD.GetValue(),
                    this.cbl02_PROCCD.GetValue(),
                    this.cbl02_INSTALL_POS.GetValue()
                    );

                this.BeforeInvokeServer(true);
                //_WSCOM.REMOVE_MES9906(this.UserInfo.BusinessCode, source);
                //  _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE9906", source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE9906"), source);
                
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE_MES9906(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝


                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("선택하신 SMS호출 - 공정 정보가 삭제되었습니다");//@@@
                MsgCodeBox.Show("CD00-0072"); //삭제되었습니다. @@@
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

        #region [컨트롤 이벤트]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed) return;

                string CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                string BIZCD = this.grd01.GetValue(row, "BIZCD").ToString();
                string LINECD = this.grd01.GetValue(row, "LINECD").ToString();
                string PROCCD = this.grd01.GetValue(row, "PROCCD").ToString();
                string INSTALL_POS = this.grd01.GetValue(row, "INSTALL_POS").ToString();

                this.Inquery(CORCD, BIZCD, LINECD, PROCCD, INSTALL_POS);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
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
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_SMSTYPELIST"), set).Tables[0];
                //DataTable source = _WSCOM_MES.INQUERY_COMBO_SMSTYPELIST(bizcd).Tables[0];

                this.cbo01_SMS_TYPE.DataBind(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", bizcd);
                set1.Add("PRDT_DIV", "");
                set1.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set1).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set1).Tables[0];

                this.cbl01_LINECD.DataBind(source,this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");//"라인코드;라인명", "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo02_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo02_BIZCD.GetValue().ToString();

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", bizcd);
                set1.Add("PRDT_DIV", "");
                set1.Add("LANG_SET", this.UserInfo.Language);
                HEParameterSet set2 = new HEParameterSet();
                set2.Add("CORCD", this.UserInfo.CorporationCode);
                set2.Add("BIZCD", bizcd);
                               

                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set1).Tables[0];
                //DataTable source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set1).Tables[0];

                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_SMSTYPELIST"), set2).Tables[0];
                //DataTable source2 = _WSCOM_MES.INQUERY_COMBO_SMSTYPELIST(bizcd).Tables[0];

                this.cbl02_LINECD.DataBind(source1, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");//"라인코드;라인명", "C;L");
                this.cbo02_SMS_TYPE.DataBind(source2);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl02_LINECD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                set.Add("LINECD", this.cbl02_LINECD.GetValue());

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_PROCLIST"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_PROCLIST(set).Tables[0];
                this.cbl02_PROCCD.DataBind(source, this.GetLabel("PROCCD") + ";" + this.GetLabel("PROCNM"), "C;L");//"공정코드;공정명", "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbl04_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.cbo02_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", bizcd);

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_DEPARTMENT"), set).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_DEPARTMENT(set).Tables[0];

                this.cbl04_LINECD.DataBind(source, this.GetLabel("DEPARTCD") + ";" + this.GetLabel("DEPTNAME"), "C;L");// "부서코드;부서명", "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn03_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                string CORCD = this.cbo02_CORCD.GetValue().ToString();
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string PROCCD = this.cbl02_PROCCD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "LINECD", "PROCCD", "INSTALL_POS", "EMPNO", "USE_YN", "REG_EMPNO", "BTN_TY");

                foreach (DataRow row in source.Tables[0].Rows)
                {
                    row["CORCD"] = CORCD;
                    row["BIZCD"] = BIZCD;
                    row["LINECD"] = LINECD;
                    row["PROCCD"] = PROCCD;
                    row["INSTALL_POS"] = INSTALL_POS;
                    row["USE_YN"] = row["USE_YN"].ToString().Equals("Y") ? 1 : 0;
                    row["REG_EMPNO"] = this.UserInfo.EmpNo;
                    row["BTN_TY"] = GetBtnTY();
                }

                if (!IsSaveDetailValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.SAVE_MES9907(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_MES9907"), source);   
             
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE_MES9907(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.Inquery(CORCD, BIZCD, LINECD, PROCCD, INSTALL_POS);

                //MsgBox.Show("입력하신 호출 사원 정보가 저장되었습니다.");//@@@
                MsgCodeBox.Show("CD00-0009"); //정상적으로 저장되었습니다. @@@

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

        private void btn03_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                string CORCD = this.cbo02_CORCD.GetValue().ToString();
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string PROCCD = this.cbl02_PROCCD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "LINECD", "PROCCD", "EMPNO", "INSTALL_POS");

                foreach (DataRow row in source.Tables[0].Rows)
                {
                    row["CORCD"] = CORCD;
                    row["BIZCD"] = BIZCD;
                    row["LINECD"] = LINECD;
                    row["PROCCD"] = PROCCD;
                    row["INSTALL_POS"] = INSTALL_POS;
                }

                if (!IsDeleteDetailValid(source)) return;

                this.BeforeInvokeServer(true);
//                _WSCOM.REMOVE_MES9907(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE9907"), source);


                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE_MES9907(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.Inquery(CORCD, BIZCD, LINECD, PROCCD, INSTALL_POS);

                //MsgBox.Show("선택하신 호출 사원 정보가 삭제되었습니다.");//@@@
                MsgCodeBox.Show("CD00-0010"); //정상적으로 삭제되었습니다. @@@
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

        private void btn04_INQ_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                
                HEParameterSet set = new HEParameterSet();
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl04_LINECD.GetValue());
                set.Add("NAME_KOR", this.txt04_NAME_KOR.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                //DataSet source = _WSCOM.INQUERY_EMP_LIST(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_EMP_LIST"), set, "OUT_CURSOR");

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

        private void btn04_REGIST_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] grd03 = ((DataTable)this.grd03.GetValue()).Select("IN_CHECK = '1'");

                string CORCD = this.cbo02_CORCD.GetValue().ToString();
                string BIZCD = this.cbo02_BIZCD.GetValue().ToString();
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string PROCCD = this.cbl02_PROCCD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();

                DataSet source = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("CORCD");
                dt.Columns.Add("BIZCD");
                dt.Columns.Add("LINECD");
                dt.Columns.Add("PROCCD");
                dt.Columns.Add("INSTALL_POS");
                dt.Columns.Add("EMPNO");
                dt.Columns.Add("USE_YN");
                dt.Columns.Add("REG_EMPNO");
                dt.Columns.Add("BTN_TY");
                source.Tables.Add(dt);

                foreach (DataRow grd03_row in grd03)
                {
                    dt.Rows.Add(
                            CORCD,
                            BIZCD,
                            LINECD,
                            PROCCD,
                            INSTALL_POS,
                            grd03_row["EMPNO"].ToString(),
                            1,
                            this.UserInfo.EmpNo,
                            GetBtnTY()
                    );
                }

                if (!IsSaveBatchlValid(source)) return;

                this.BeforeInvokeServer(true);
//                _WSCOM.SAVE_MES9907(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE9907"), source);


                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 시작
                //bool isSyncOK = this.DN_MESCODE_MES9907(this.UserInfo.BusinessCode);
                //2014.02.10 MES CODE 미들서버에 전송 로직 추가 >>> 끝

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                this.Inquery(CORCD, BIZCD, LINECD, PROCCD, INSTALL_POS);

                //MsgBox.Show("입력하신 SMS호출 - 공정 정보가 저장되었습니다.");//@@@
                MsgCodeBox.Show("CD00-0009"); //정상적으로 저장되었습니다. //@@@
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

        private string GetBtnTY()
        {
            if (RB_01.Checked == true)
            {
                return "01";
            }
            else if (RB_02.Checked == true)
            {
                return "02";
            }
            else if (RB_03.Checked == true)
            {
                return "03";
            }
            else if (RB_04.Checked == true)
            {
                return "04";
            }
            return "0";
        }
        
        private void Inquery(string CORCD, string BIZCD, string LINECD, string PROCCD, string INSTALL_POS)
        {
            try
            {
                _IsBinded = true;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", CORCD);
                set.Add("BIZCD", BIZCD);
                set.Add("LINECD", LINECD);
                set.Add("PROCCD", PROCCD);
                set.Add("INSTALL_POS", INSTALL_POS);
                

                //DataTable source1 = _WSCOM.INQUERY_DETAIL(BIZCD, set).Tables[0];
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR").Tables[0];

                if (source1.Rows.Count == 0) return;
                DataRow row = source1.Rows[0];

                this.cbo02_CORCD.SetValue(row["CORCD"]);
                this.cbo02_BIZCD.SetValue(row["BIZCD"]);
                this.cbl02_LINECD.SetValue(row["LINECD"]);
                this.cbl02_PROCCD.SetValue(row["PROCCD"].ToString().Trim());
                this.cbl02_INSTALL_POS.SetValue(row["INSTALL_POS"]);
                this.cbo02_SMS_TYPE.SetValue(row["SMS_TYPE"]);
                this.nme02_SMS_POINT.SetValue(row["SMS_POINT"]);
                this.chk02_EQUIP_PROC_YN.SetValue(row["EQUIP_YN"]);
                this.chk02_USEYN2.SetValue(row["USE_YN"]);

                this.cbl02_LINECD.SetReadOnly(true);
                this.cbl02_PROCCD.SetReadOnly(true);
                this.cbl02_INSTALL_POS.SetReadOnly(true);

                this.btn03_SAVE.Enabled = true;
                this.btn03_DELETE.Enabled = true;
                this.btn04_INQUERY.Enabled = true;
                this.btn04_REGIST.Enabled = true;

                set.Add("LANG_SET", this.UserInfo.Language);
                //DataTable source2 = _WSCOM.INQUERY_CALL_EMP(BIZCD, set).Tables[0];
                DataTable source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CALL_EMP"), set, "OUT_CURSOR").Tables[0];

                this.grd02.SetValue(source2);

                this.btn04_INQ_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            try
            {
                
                string LINECD = this.cbl02_LINECD.GetValue().ToString();
                string PROCCD = this.cbl02_PROCCD.GetValue().ToString();
                string INSTALL_POS = this.cbl02_INSTALL_POS.GetValue().ToString();
                string SMS_TYPE = this.cbo02_SMS_TYPE.GetValue().ToString();
                string SMS_POINT = this.nme02_SMS_POINT.GetValue().ToString();

                if (this.GetByteCount(LINECD) == 0)
                {
                    //MsgBox.Show("라인이 선택되지 않았습니다.");//@@@
                    MsgCodeBox.ShowFormat("CD00-0080", this.lbl02_LINE.Text); //{0}가(이) 선택되지 않았습니다. //@@@
                    return false;
                }

                if (this.GetByteCount(PROCCD) == 0)
                {
                    //MsgBox.Show("공정이 선택되지 않았습니다.");//@@@
                    MsgCodeBox.ShowFormat("CD00-0080", this.lbl02_PROCINFO.Text); //{0}가(이) 선택되지 않았습니다. //@@@
                    return false;
                }

                if (this.GetByteCount(INSTALL_POS) == 0)
                {
                    //MsgBox.Show("장착 위치가 선택되지 않았습니다.");//@@@
                    MsgCodeBox.ShowFormat("CD00-0080", this.lbl02_POSTITLE.Text); //{0}가(이) 선택되지 않았습니다. //@@@
                    return false;
                }

                if (this.GetByteCount(SMS_TYPE) == 0)
                {
                    //MsgBox.Show("호출업무가 선택되지 않았습니다.");//@@@
                    MsgCodeBox.ShowFormat("CD00-0080", this.lbl02_SMS_TYPE.Text); //{0}가(이) 선택되지 않았습니다. //@@@
                    return false;
                }

                if (this.GetByteCount(SMS_POINT) == 0)
                {
                    //MsgBox.Show("포인트가 입력되지 않았습니다.");//@@@
                    MsgCodeBox.ShowFormat("CD00-0080", this.lbl02_SMS_POINT.Text); //{0}가(이) 선택되지 않았습니다. //@@@
                    return false;
                }

                //if (MsgBox.Show("입력하신 SMS호출 - 공정 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)//저장하시겠습니까? @@@
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsSaveDetailValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 호출 사원정보가 없습니다.");//@@@
                    MsgCodeBox.Show("COM-00020"); //저장할 대상 Data가 없습니다. //@@@
                    return false;
                }

                //if (MsgBox.Show("입력하신 호출 사원정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@
                if (MsgCodeBox.Show("COM-00909", MessageBoxButtons.OKCancel) != DialogResult.OK)// 저장하시겠습니까? @@@
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsSaveBatchlValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 호출사원 배치 정보가 없습니다.");//@@@
                    MsgCodeBox.Show("COM-00020"); //저장할 대상 Data가 없습니다. //@@@
                    return false;
                }

                //if (MsgBox.Show("입력하신 호출사원 배치 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@
                if (MsgCodeBox.Show("COM-00909", MessageBoxButtons.OKCancel) != DialogResult.OK)// 저장하시겠습니까? @@@
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid()
        {
            try
            {
                if (!_IsBinded)
                {
                    //MsgBox.Show("삭제할 SMS호출 - 공정 정보가 선택되지 않습니다.");//@@@
                    MsgCodeBox.Show("COM-00023"); //삭제할 대상 Data가 없습니다. @@@
                    return false;
                }

                //if (MsgBox.Show("선택하신 SMS호출 - 공정 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@ 삭제하시겠습니까?
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteDetailValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 호출 사원정보가 없습니다.");//@@@
                    MsgCodeBox.Show("COM-00023"); //삭제할 대상 Data가 없습니다. @@@
                    return false;
                }

                //if (MsgBox.Show("선택하신 호출 사원정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)//@@@ 삭제하시겠습니까?
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
        //2014.02.10 - MES9906 현장 SMS 호출 공정 MESCODE 전송
        //private bool DN_MESCODE_MES9906(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES9906", bizcd).Tables[0].Rows[0][0].ToString();

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

        //2014.02.10 - MES9907 현장 SMS 호출 대상 - 공정 MESCODE 전송
        //private bool DN_MESCODE_MES9907(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
        //        msg = _WSCOM_ERM.SyncMESIF("MES9907", bizcd).Tables[0].Rows[0][0].ToString();

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
