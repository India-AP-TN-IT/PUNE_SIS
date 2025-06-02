#region ▶ Description & History
/* 
 * 프로그램명 : PD20330 공정불량호출 조치이력조회
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
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 공정불량 호출 조치이력 조회
    /// </summary>
    public partial class PD20330 : AxCommonBaseControl
    {
        //private IPD20330 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20330";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        //private IPDCOMMON_MES _WSCOM_MES;

        public PD20330()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM  = ClientFactory.CreateChannel<IPD20330>("PD", "PD20330.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }
        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2);
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD", "COR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "코드", "LINECD", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "라인", "LINENM", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "장착\n위치", "INSTALL_POS", "POSTITLE_LINE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "코드", "PROCCD","CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "공정", "PROCNM", "PROCINFO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "호출\n순번", "CALL_SEQ", "CALL_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "호출\n버튼", "BTN_TY", "BTN_TY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "업무코드", "SMS_TYPE", "SMS_TYPE_CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "명칭", "SMS_TYPE_NM", "INSPEC_POSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "포인트", "SMS_POINT", "SMS_POINT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "포인트명", "SMS_POINT_NM", "SMS_POINT_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "코드", "MANAGE_CODE", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "명칭", "MANAGE_NAME", "INSPEC_POSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 400, "호출문자내용", "SMS_DATA", "SMS_DATA");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "호출자 사번", "CALL_USER_ID", "CALL_USER_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "사번", "EMPNO", "EMPNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "이름", "EMP_NAME", "HR_NAME");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "핸드폰", "MOB_PHONE_NO", "CHR_MOBILE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 170, "호출일시", "CALL_DATE", "CALL_DATE_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 170, "조치완료일시", "MANAGE_DATE", "MANAGE_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "비가동시간\n(분)", "STOP_TIME", "NON_OPR_MIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "조치\n완료", "MANAGE_YN", "MANAGE_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "코드", "SELECT_CALL", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "명칭", "SELECT_CALL_NM", "INSPEC_POSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "코드", "SELECT_DEF", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "명칭", "SELECT_DEF_NM", "INSPEC_POSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "코드", "DEF_CODE", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "명칭", "DEF_NAME", "INSPEC_POSNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "수량", "DEF_QTY", "QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "기타사유", "ETC_DATA", "ETC_DATA");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "등록일자", "INSERT_DATE", "REG_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "등록자ID", "INSERT_USER_ID", "INSERT_USER_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "수정일자", "UPDATE_DATE", "AMD_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "수정자ID", "UPDATE_USER_ID", "UPDATE_USER_ID");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "CALL_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "MANAGE_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSERT_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "UPDATE_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CALL_SEQ");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "DEF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "MANAGE_YN");

                this.grd01.Cols["CALL_DATE"].Format = "G";
                this.grd01.Cols["MANAGE_DATE"].Format = "G";

                this.grd01.Cols.Frozen = this.grd01.Cols["PROCNM"].Index;

                #region [Grid Merge]

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd01.AddMerge(0, 1, "WORK_DATE", "WORK_DATE");
                this.grd01.AddMerge(0, 1, "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddMerge(0, 1, "CALL_SEQ", "CALL_SEQ");
                this.grd01.AddMerge(0, 1, "BTN_TY", "BTN_TY");
                this.grd01.AddMerge(0, 1, "SMS_DATA", "SMS_DATA");
                this.grd01.AddMerge(0, 1, "CALL_USER_ID", "CALL_USER_ID");
                this.grd01.AddMerge(0, 1, "CALL_DATE", "CALL_DATE");
                this.grd01.AddMerge(0, 1, "MANAGE_DATE", "MANAGE_DATE");
                this.grd01.AddMerge(0, 1, "STOP_TIME", "STOP_TIME");
                this.grd01.AddMerge(0, 1, "MANAGE_YN", "MANAGE_YN");
                this.grd01.AddMerge(0, 1, "ETC_DATA", "ETC_DATA");
                this.grd01.AddMerge(0, 1, "INSERT_DATE", "INSERT_DATE");
                this.grd01.AddMerge(0, 1, "INSERT_USER_ID", "INSERT_USER_ID");
                this.grd01.AddMerge(0, 1, "UPDATE_DATE", "UPDATE_DATE");
                this.grd01.AddMerge(0, 1, "UPDATE_USER_ID", "UPDATE_USER_ID");

                this.grd01.AddMerge(0, 1, "LINECD", "LINECD");
                this.grd01.AddMerge(0, 1, "LINENM", "LINENM");
                this.grd01.AddMerge(0, 1, "PROCCD", "PROCCD");
                this.grd01.AddMerge(0, 1, "PROCNM", "PROCNM");
                this.grd01.AddMerge(0, 0, "SMS_TYPE", "SMS_POINT_NM");
                this.grd01.SetHeadTitle(0, "SMS_TYPE", this.GetLabel("SMS_TYPE"));//"호출업무");

                this.grd01.AddMerge(0, 0, "MANAGE_CODE", "MANAGE_NAME");
                this.grd01.SetHeadTitle(0, "MANAGE_CODE", this.GetLabel("MGRT_CD"));//"조치구분");

                this.grd01.AddMerge(0, 0, "EMPNO", "MOB_PHONE_NO");
                this.grd01.SetHeadTitle(0, "EMPNO", this.GetLabel("CALL_MAN"));// "호출대상");

                this.grd01.AddMerge(0, 0, "SELECT_CALL", "SELECT_CALL_NM");
                this.grd01.SetHeadTitle(0, "SELECT_CALL",this.GetLabel("SELECT_CALL"));// "호출구분");

                this.grd01.AddMerge(0, 0, "SELECT_DEF", "SELECT_DEF_NM");
                this.grd01.SetHeadTitle(0, "SELECT_DEF", this.GetLabel("SELECT_DEF"));//"수정/폐기");

                this.grd01.AddMerge(0, 0, "DEF_CODE", "DEF_QTY");
                this.grd01.SetHeadTitle(0, "DEF_CODE", this.GetLabel("DEF_CODE"));//"불량단품");

                this.grd01.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                for (int i = 0; i <= this.grd01.Cols["ETC_DATA"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                #endregion

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                
                DataTable source3 = new DataTable();
                source3.Columns.Add("CODE");
                source3.Columns.Add("NAME");

                source3.Rows.Add("1", this.GetLabel("MGRT_COMPLETE"));//"조치완료");//@@@
                source3.Rows.Add("0", this.GetLabel("COMPLETE_N"));//"미완료");//@@@

                this.cbo01_MANAGE.DataBind(source3);
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
                set.Add("SELECT_DEF", this.cbo01_SELECT_DEF.GetValue());
                set.Add("SELECT_CALL", this.cbo01_SELECT_CALL.GetValue());
                set.Add("MANAGE", this.cbo01_MANAGE.GetValue());
                set.Add("WORK_SDATE", this.dtp01_WORK_SDATE.GetDateText());
                set.Add("WORK_EDATE", this.dtp01_WORK_EDATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
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

        #endregion

        #region [ 기타 컨트롤 이벤트 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                DataTable source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_CALLTYPE"), set).Tables[0];
                //DataTable source1 = _WSCOM_MES.INQUERY_COMBO_CALLTYPE(this.cbo01_BIZCD.GetValue().ToString()).Tables[0];
                this.cbo01_SELECT_DEF.DataBind(source1);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_SELECT_DEF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                set.Add("DETAIL_CODE", this.cbo01_SELECT_DEF.GetValue());

                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_DEFLIST"), set).Tables[0];
                //DataTable source = _WSCOM_MES.INQUERY_COMBO_DEFLIST(this.cbo01_BIZCD.GetValue().ToString(), set).Tables[0];
                this.cbo01_SELECT_CALL.DataBind(source);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                this.grd01.Tree.Column = 3;

                this.grd01.Styles["Subtotal0"].BackColor = Color.Khaki;
                this.grd01.Styles["Subtotal0"].ForeColor = Color.Black;

                this.grd01.Styles["Subtotal1"].BackColor = Color.Lavender;
                this.grd01.Styles["Subtotal1"].ForeColor = Color.Black;

                this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 0, 24, this.GetLabel("ALL_TOT"));//"전체 합계");
                this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 1, 3, 24, this.GetLabel("STOT")); //"[{0}] 합계"); → 소계
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
