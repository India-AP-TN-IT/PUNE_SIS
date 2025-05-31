#region ▶ Description & History
/* 
 * 프로그램명 : PD20350 PDA-SMS 호출 이력 조회
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


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 계측 정보 이력 조회 
    /// </summary>
    public partial class PD20350 : AxCommonBaseControl
    {
        //private IPD20350 _WSCOM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20350";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        public PD20350()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD20350>("PD", "PD20350.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody  = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "COR");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "SMS 업무", "SMS_TYPE", "SMS_TYPE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "호출순번", "SEQ", "CALL_SEQ2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "호출자사번", "CALL_USERID", "CALL_USERID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 350, "호출문자 내용", "SMS_DATA", "SMS_DATA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "호출일시", "SMS_DATE", "CALL_DATE_TIME");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "등록일자", "INSERT_DATE", "REG_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "등록자ID", "INSERT_USER_ID","INSERT_USER_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "수정일자", "UPDATE_DATE", "AMD_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "수정자ID", "UPDATE_USER_ID", "UPDATE_USER_ID");
                this.grd01.Cols["SMS_DATE"].Format = "yyyy-MM-dd HH:mm:ss";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "SMS_DATE");
                

                this.grd01.Cols["CORCD"].AllowMerging = true;
                this.grd01.Cols["BIZCD"].AllowMerging = true;
                this.grd01.Cols["WORK_DATE"].AllowMerging = true;
                this.grd01.Cols["SMS_TYPE"].AllowMerging = true;

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "사번", "EMPNO", "EMPNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "이름", "NAME_KOR", "HR_NAME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 105, "휴대폰번호", "MOB_PHONE_NO", "CELLNO");
                this.grd02.Cols[0].Visible = false;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                
                this.dtp01_SDATE.SetValue(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01));
                this.dtp01_EDATE.SetValue(DateTime.Now);
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
                set.Add("SMS_TYPE", this.cbo01_SMSTYPE.GetValue());

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

        #region [ 기타 이벤트 정의 ]

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            this.grd01.AllowMerging = (this.chk01_GRID_MERGE.Checked) ?
                C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                C1.Win.C1FlexGrid.AllowMergingEnum.None;
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            this.cbo01_SMSTYPE.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_SMSTYPELIST"), set).Tables[0]);
            //this.cbo01_SMSTYPE.DataBind(_WSCOM_MES.INQUERY_COMBO_SMSTYPELIST(bizcd).Tables[0]);
        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < 1) return;

                this.grd02.InitializeDataSource();
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("WORK_DATE", this.grd01.GetValue(row, "WORK_DATE"));
                set.Add("SMS_TYPE", this.grd01.GetValue(row, "SMS_TYPE"));
                set.Add("SEQ", this.grd01.GetValue(row, "SEQ"));

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_LIST(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LIST"), set, "OUT_CURSOR");

                this.grd02.SetValue(source);
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
    }
}
