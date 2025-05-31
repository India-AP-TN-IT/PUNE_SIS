#region ▶ Description & History
/* 
 * 프로그램명 : PD20320 공정불량호출 이력 조회/등록
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
    /// 공정불량 호출이력 조회/등록
    /// </summary>
    public partial class PD20320 : AxCommonBaseControl
    {
        //private IPD20320 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20320";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxComboList grd_EMPNO;
        private AxComboList grd_SELECT_CALL;
        private AxComboList grd_SELECT_DEF;
        private AxComboList grd_DEF_CODE;
        private bool _isDesign;

        public PD20320()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD20320>("PD", "PD20320.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");

            this.grd_EMPNO = new AxComboList();
            this.grd_SELECT_CALL = new AxComboList();
            this.grd_SELECT_DEF = new AxComboList();
            this.grd_DEF_CODE = new AxComboList();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _isDesign = true;
                this.grd_EMPNO.BeforeOpen +=new System.ComponentModel.CancelEventHandler(grd_EMPNO_BeforeOpen);
                this.grd_SELECT_CALL.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_SELECT_CALL_BeforeOpen);
                this.grd_SELECT_CALL.SelectedValueChanged += new EventHandler(grd_SELECT_CALL_SelectedValueChanged);
                this.grd_SELECT_DEF.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_SELECT_DEF_BeforeOpen);
                this.grd_SELECT_DEF.SelectedValueChanged +=new EventHandler(grd_SELECT_DEF_SelectedValueChanged);
                this.grd_DEF_CODE.BeforeOpen +=new System.ComponentModel.CancelEventHandler(grd_DEF_CODE_BeforeOpen);
                this.grd_DEF_CODE.SelectedValueChanged += new EventHandler(grd_DEF_CODE_SelectedValueChanged);

                this.grd01.AllowEditing = true;
                this.grd02.AllowEditing = false;
                this.grd01.Initialize(2, 2);
                this.grd02.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 000, "법인",     "CORCD",           "COR");
                this.grd01.AddColumn(true,  false, AxFlexGrid.FtextAlign.C, 000, "사업장",   "BIZCD",            "BIZNM2");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 080, "작업일자",  "WORK_DATE",        "WORKDATE");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 070, "라인",     "LINECD",           "LINE");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.L, 150, "라인명",    "LINENM",          "LINENM");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 040, "장착\n위치", "INSTALL_POS",     "POSTITLE_LINE");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 050, "공정",      "PROCCD",          "PROCINFO");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.L, 090, "공정명",     "PROCNM",          "PROCNM");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 040, "호출\n순번", "CALL_SEQ",        "CALL_SEQ");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 060, "호출업무",   "SMS_TYPE",        "SMS_TYPE");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.L, 100, "업무명",     "SMS_TYPE_NM",     "SMS_TYPE_NM");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.R, 060, "포인트",     "SMS_POINT",       "SMS_POINT");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 060, "조치구분",    "MANAGE_CODE",    "MGRT_CD");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.L, 070, "조치구분명",  "MANAGE_NAME",     "MANAGE_NAME");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.L, 300, "호출문자내용", "SMS_DATA",       "SMS_DATA");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 070, "호출자",      "CALL_USER_ID",    "CALL_USER_ID");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 145, "호출일시",    "CALL_DATE",       "CALL_DATE_TIME");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 145, "조치완료일시", "MANAGE_DATE",     "MANAGE_DATE");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 040, "조치\n완료",   "MANAGE_YN",      "MANAGE_YN");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 040, "호출구분",     "SELECT_CALL",    "SELECT_CALL");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.L, 070, "호출구분명",   "SELECT_CALL_NM", "SELECT_CALL_NM");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 080, "수정/폐기",   "SELECT_DEF",      "SELECT_DEF");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.C, 080, "수정/폐기",   "SELECT_DEF_NM",   "SELECT_DEF_NM");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.C, 040, "불량단품",    "DEF_CODE",        "DEF_CODE");
                this.grd01.AddColumn(true,  true,  AxFlexGrid.FtextAlign.L, 100, "불량단품명",  "DEF_NAME",        "DEF_CODE_NM");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.R, 050, "수량",       "DEF_QTY",         "QTY");
                this.grd01.AddColumn(false, true,  AxFlexGrid.FtextAlign.L, 120, "기타사유",    "ETC_DATA",        "ETC_DATA");

                this.grd01.Cols["CALL_DATE"].Format = "yyyy-MM-dd HH:mm:ss";
                this.grd01.Cols["MANAGE_DATE"].Format = "yyyy-MM-dd HH:mm:ss";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "CALL_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "MANAGE_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "MANAGE_YN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DEF_QTY");
                this.grd01.Cols["CALL_DATE"].Format = "yyyy-MM-dd HH:mm:ss";
                this.grd01.Cols["MANAGE_DATE"].Format = "yyyy-MM-dd HH:mm:ss";

                this.grd01.Cols["CALL_USER_ID"].Editor = this.grd_EMPNO;
                this.grd01.Cols["SELECT_CALL"].Editor = this.grd_SELECT_CALL;
                this.grd01.Cols["SELECT_DEF"].Editor = this.grd_SELECT_DEF;
                this.grd01.Cols["DEF_CODE"].Editor = this.grd_DEF_CODE;

                

                
                for (int i = this.grd01.Cols.Fixed; i <= this.grd01.Cols["PROCNM"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                this.grd01.AddMerge(0, 1, "WORK_DATE", "WORK_DATE");
                this.grd01.AddMerge(0, 1, "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddMerge(0, 1, "CALL_SEQ", "CALL_SEQ");
                this.grd01.AddMerge(0, 1, "SMS_DATA", "SMS_DATA");
                this.grd01.AddMerge(0, 1, "CALL_USER_ID", "CALL_USER_ID");
                this.grd01.AddMerge(0, 1, "CALL_DATE", "CALL_DATE");
                this.grd01.AddMerge(0, 1, "MANAGE_DATE", "MANAGE_DATE");
                this.grd01.AddMerge(0, 1, "MANAGE_YN", "MANAGE_YN");
                this.grd01.AddMerge(0, 1, "ETC_DATA", "ETC_DATA");

                this.grd01.AddMerge(0, 0, "LINECD", "LINENM");
                this.grd01.AddMerge(0, 0, "PROCCD", "PROCNM");
                this.grd01.AddMerge(0, 0, "SMS_TYPE", "SMS_POINT");
                this.grd01.AddMerge(0, 0, "MANAGE_CODE", "MANAGE_NAME");
                this.grd01.AddMerge(0, 0, "SELECT_CALL", "SELECT_CALL_NM");
                this.grd01.AddMerge(0, 0, "SELECT_DEF", "SELECT_DEF_NM");
                this.grd01.AddMerge(0, 0, "DEF_CODE", "DEF_QTY");

                this.grd01.SetHeadTitle(1, "LINECD", this.GetLabel("CODE"));//"코드");
                this.grd01.SetHeadTitle(1, "LINENM", this.GetLabel("INSPEC_POSNM"));//"명칭");
                this.grd01.SetHeadTitle(1, "PROCCD", this.GetLabel("CODE"));//"코드");
                this.grd01.SetHeadTitle(1, "PROCNM", this.GetLabel("INSPEC_POSNM"));//"명칭");
                this.grd01.SetHeadTitle(1, "SMS_TYPE", this.GetLabel("SYS_CODE"));// "업무");
                this.grd01.SetHeadTitle(1, "SMS_TYPE_NM", this.GetLabel("SMS_TYPE_NM"));//"업무명");
                this.grd01.SetHeadTitle(1, "SMS_POINT", this.GetLabel("SMS_POINT"));//"포인트");
                this.grd01.SetHeadTitle(1, "MANAGE_CODE", this.GetLabel("CODE"));//"코드");
                this.grd01.SetHeadTitle(1, "MANAGE_NAME", this.GetLabel("INSPEC_POSNM"));//"명칭");
                this.grd01.SetHeadTitle(1, "SELECT_CALL", this.GetLabel("CODE"));//"코드");
                this.grd01.SetHeadTitle(1, "SELECT_CALL_NM", this.GetLabel("INSPEC_POSNM"));//"명칭");
                this.grd01.SetHeadTitle(1, "SELECT_DEF", this.GetLabel("CODE"));//"코드");
                this.grd01.SetHeadTitle(1, "SELECT_DEF_NM", this.GetLabel("INSPEC_POSNM"));//"명칭");
                this.grd01.SetHeadTitle(1, "MANAGE_CODE", this.GetLabel("CODE"));//"코드");
                this.grd01.SetHeadTitle(1, "MANAGE_NAME", this.GetLabel("INSPEC_POSNM"));//"명칭");
                this.grd01.SetHeadTitle(1, "DEF_CODE", this.GetLabel("CODE"));//"코드");
                this.grd01.SetHeadTitle(1, "DEF_NAME", this.GetLabel("INSPEC_POSNM"));//"명칭");
                this.grd01.SetHeadTitle(1, "DEF_QTY", this.GetLabel("QTY"));//"수량");

                this.grd01.Cols.Frozen = this.grd01.Cols["PROCNM"].Index;

                this.grd01.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "사번", "EMPNO","EMPNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "이름", "NAME_KOR","HR_NAME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "휴대폰번호", "MOB_PHONE_NO", "CELLNO");
                DataTable BIZCD = this.GetBizCD(this.UserInfo.CorporationCode).Tables[0];

                this.cbo01_BIZCD.DataBind(BIZCD);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.grd01.CurrentContextMenu.Items.RemoveAt(1);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);

                _isDesign = false;
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
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("SDATE", this.dtp01_SDATE.GetDateText());
                set.Add("EDATE", this.dtp01_EDATE.GetDateText());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("MANAGE_CODE", this.cbo01_4M.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CALL_DATE", "MANAGE_DATE", "MANAGE_YN", "SELECT_CALL", "SELECT_DEF",
                    "DEF_CODE", "DEF_QTY", "ETC_DATA", "UPDATE_USER_ID", "CORCD",
                    "BIZCD", "WORK_DATE", "LINECD", "INSTALL_POS", "CALL_SEQ", "MANAGE_CODE");

                foreach (DataRow row in source.Tables[0].Rows)
                {
                    row["UPDATE_USER_ID"] = this.UserInfo.EmpNo;
                    string MANAGE_DATE = "";
                    string CALL_DATE = "";

                    if (row["MANAGE_DATE"].ToString().Length > 0)
                    {
                        if (row["MANAGE_DATE"].ToString().Length == 15)
                            MANAGE_DATE = DateTime.Parse(row["MANAGE_DATE"].ToString().Insert(13, ":").Insert(11, ":").Insert(10, " ").Insert(8, " ").Insert(6, "-").Insert(4, "-")).ToString("yyyyMMdd HH:mm:ss");
                        else
                            MANAGE_DATE = DateTime.Parse(row["MANAGE_DATE"].ToString().Insert(14, ":").Insert(12, ":").Insert(10, " ").Insert(8, " ").Insert(6, "-").Insert(4, "-")).ToString("yyyyMMdd HH:mm:ss");
                    }


                    row["MANAGE_DATE"] = MANAGE_DATE;
                    row["CALL_DATE"] = CALL_DATE;
                    row["MANAGE_YN"] = row["MANAGE_YN"].ToString().Equals("Y") ? 1 : 0;
                    
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.UPDATE(bizcd, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_UPDATE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 공정불량 호출이력이 저장되었습니다");
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

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow row = source.Tables[0].Rows[i];
                    DataRow seq = source.Tables[1].Rows[i];

                    //if (this.Nvl(row["CALL_DATE"], "").ToString().Length == 0)
                    //{
                    //    MsgBox.Show(String.Format("{0}행의 호출일시를 입력하세요.", seq["GRIDSEQ"]));
                    //    return false;
                    //}

                    if (this.Nvl(row["MANAGE_DATE"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 조치완료일시를 입력하세요.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("COM-00904", seq["GRIDSEQ"], this.grd01.Cols["MANAGE_DATE"].Caption); //{0}번째 행의 {1}를(을) 입력해주세요.
                        return false;
                    }

                    if (this.Nvl(row["SELECT_CALL"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 호출구분을 선택하세요.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("COM-00904", seq["GRIDSEQ"], this.grd01.Cols["SELECT_CALL"].Caption); //{0}번째 행의 {1}를(을) 입력해주세요.
                        return false;
                    }
                    /*
                    if (this.Nvl(row["SELECT_DEF"], "").ToString().Length == 0)
                    {
                        MsgBox.Show(String.Format("{0}행의 수정/폐기를 선택하세요.", seq["GRIDSEQ"]));
                        return false;
                    }

                    if (this.Nvl(row["DEF_CODE"], "").ToString().Length == 0)
                    {
                        MsgBox.Show(String.Format("{0}행의 불량단품을 선택하세요.", seq["GRIDSEQ"]));
                        return false;
                    }

                    if (this.Nvl(row["DEF_QTY"], "").ToString().Length == 0)
                    {
                        MsgBox.Show(String.Format("{0}행의 수량을 입력하세요.", seq["GRIDSEQ"]));
                        return false;
                    }
                    */
                    //if (this.Nvl(row["ETC_DATA"], "").ToString().Length == 0)
                    //{
                    //    MsgBox.Show(String.Format("{0}행의 기타사유를 입력하세요.", seq["GRIDSEQ"]));
                    //    return false;
                    //}
                }
                
                //if (MsgBox.Show("입력하신 공정불량 호출이력을 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
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


        #region [ 기타 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
                this.grd02.InitializeDataSource();

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", bizcd);
                DataSet source2 = _WSCOM_N.ExecuteDataSet("ASP_PDCOMMON_MES.INQUERY_COMBO_4MLIST", set1);
                //DataSet source2 = _WSCOM_MES.INQUERY_COMBO_4MLIST(bizcd);
                this.cbo01_4M.DataBind(source2.Tables[0]);
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source2.Tables[0], "MANAGE_NAME");
                if (source2.Tables[0].Rows.Count > 0)
                {
                    cbo01_4M.SelectedIndex = 1;
                }
                

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("CORCD", this.UserInfo.CorporationCode);
                set2.Add("BIZCD", bizcd);
                DataTable source3 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_PROCNAME"), set2).Tables[0];
                //DataTable source3 = _WSCOM_ERM.INQUERY_COMBO_PROCNAME(set2).Tables[0];
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source3, "PROCNM");

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_EMPNO_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);

            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_CALLUSER"), set).Tables[0];
            //DataTable source = _WSCOM_ERM.INQUERY_COMBO_CALLUSER(set).Tables[0];
            //this.grd_EMPNO.DataBind(source, "EMPNO", "EMPNO", "라인;사번;성명", "L;C;C");
            this.grd_EMPNO.DataBind(source, "EMPNO", "EMPNO", this.GetLabel("LINE") + ";" + this.GetLabel("EMPNO") + ";" + this.GetLabel("EMPNM"), "L;C;C");
        }

        void grd_SELECT_CALL_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_CALLTYPE"), set).Tables[0];
            //DataTable source = _WSCOM_MES.INQUERY_COMBO_CALLTYPE(bizcd).Tables[0];

            //this.grd_SELECT_CALL.DataBind(source, "DETAIL_CODE", "DETAIL_CODE", "호출구분;호출구분명", "C;L");//@@@
            this.grd_SELECT_CALL.DataBind(source, "DETAIL_CODE", "DETAIL_CODE", this.GetLabel("SELECT_CALL") + ";" + this.GetLabel("SELECT_CALL_NM"), "C;L"); 
        }

        void grd_SELECT_CALL_SelectedValueChanged(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            this.grd01.SetValue(row, "SELECT_CALL_NM", this.grd_SELECT_CALL.GetValue("DETAIL_DESC"));
        }

        void grd_SELECT_DEF_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();
            int row = this.grd01.SelectedRowIndex;

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("DETAIL_CODE", this.grd01.GetValue(row, "SELECT_CALL"));

            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_DEFLIST"), set).Tables[0];
            //DataTable source = _WSCOM_MES.INQUERY_COMBO_DEFLIST(bizcd, set).Tables[0];

            //this.grd_SELECT_DEF.DataBind(source, "DETAIL_CODE", "DETAIL_CODE", "수정폐기구분;수정폐기구분명", "C;L");
            this.grd_SELECT_DEF.DataBind(source, "DETAIL_CODE", "DETAIL_CODE", this.GetLabel("SELECT_DEF") + ";" + this.GetLabel("SELECT_DEF_NM"), "C;L");
        }

        void grd_SELECT_DEF_SelectedValueChanged(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            this.grd01.SetValue(row, "SELECT_DEF_NM", this.grd_SELECT_DEF.GetValue("DETAIL_DESC"));
        }

        void grd_DEF_CODE_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("LANG_SET", this.UserInfo.Language);
            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_MATERIALGROUP"),set).Tables[0];
            //DataTable source = _WSCOM_ERM.INQUERY_COMBO_MATERIALGROUP().Tables[0];

            //this.grd_DEF_CODE.DataBind(source, "TYPECD", "TYPECD", "그룹코드;그룹명", "C;L");
            this.grd_DEF_CODE.DataBind(source, "TYPECD", "TYPECD", this.GetLabel("DCODE")+ ";" + this.GetLabel("DNAME"), "C;L");
        }

        void grd_DEF_CODE_SelectedValueChanged(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            this.grd01.SetValue(row, "DEF_NAME", this.grd_DEF_CODE.GetValue("OBJECT_NM"));
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

                //this.cbl01_LINECD.DataBind(source, "라인코드;라인명", "C;L");
                this.cbl01_LINECD.DataBind(source, this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

                int row = this.grd01.SelectedRowIndex;
                if (row < this.grd01.Rows.Fixed)
                    return;

                string bizcd = this.grd01.GetValue(row, "BIZCD").ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.grd01.GetValue(row, "CORCD"));
                set.Add("BIZCD", bizcd);
                set.Add("WORK_DATE", this.grd01.GetValue(row, "WORK_DATE"));
                set.Add("LINECD", this.grd01.GetValue(row, "LINECD"));
                set.Add("INSTALL_POS", this.grd01.GetValue(row, "INSTALL_POS"));
                set.Add("CALL_SEQ", this.grd01.GetValue(row, "CALL_SEQ"));

                //DataSet source = _WSCOM.INQUERY_EMPINFO(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_EMPINFO"), set, "OUT_CURSOR");


                this.grd02.SetValue(source.Tables[0]);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            this.Grid_Merge();
        }

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk01_GRID_MERGE.Checked == true)
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
            else
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
        }

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void Grid_Merge()
        {
            if (_isDesign) return;

            if (!this.chk01_AUTO_INSERT.Checked) return;

            int row = this.grd01.SelectedRowIndex;
            if (string.IsNullOrEmpty(this.grd01.GetValue(row, "MANAGE_DATE").ToString()))
            {
                this.grd01.SetValue(row, "MANAGE_DATE", DateTime.Now);
            }
            //this.grd01.SetValue(row, "MANAGE_DATE", DateTime.Now);
        }

        #endregion
    }
}
