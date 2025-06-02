#region ▶ Description & History
/* 
 * 프로그램명 : PD35220 비가동 조회 - 코드
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

//using HE.ERM.PM.PM05.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>비가동 조회 - 코드</b>
    /// - 작 성 자 : 김선환<br />
    /// - 작 성 일 : 2010-07-15 오전 9:14:24<br />
    /// </summary>
    public partial class PD35220 : AxCommonBaseControl
    {
        //private IPD35220 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD35220";

        public PD35220()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD35220>("PM05", "PD35220.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
        }

        #region [ 초기화 작업 정의 ]

        private void PD35220_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;
                this.axDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_SAUP.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_SAUP.SetValue(this.UserInfo.BusinessCode);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "비가동코드", "NON_OPRCD", "NON_OPRCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "비가동명", "NON_OPRNM", "STOP_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "라인", "LINECD", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "인원", "PERSON", "EMPCNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "실정지시간", "STOP_TIME_SUM", "PD25220_STOP_TIME_SUM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "정지공수", "STOP_MH_SUM", "PD25220_STOP_MH_SUM");

                this.grd01.AllowMerging = AllowMergingEnum.RestrictRows;
                this.grd01.Cols["NON_OPRCD"].AllowMerging = true;
                this.grd01.Cols["NON_OPRCD"].TextAlign = TextAlignEnum.LeftTop;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_SAUP.GetValue());

                //DataSet source = _WSCOM.Get_NonOprCD(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_NON_OPRCD"), set);
                this.cbo01_NON_OPRCD.DataBind(source.Tables[0]);

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
                if (!IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_SAUP.GetValue().ToString());
                paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetDateText().ToString());
                paramSet.Add("END_DATE", this.dtp01_END_DATE.GetDateText().ToString());
                paramSet.Add("NON_OPRCD", this.cbo01_NON_OPRCD.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                grd01.MergedRanges.Clear();
                this.grd01.SetValue(source.Tables[0]);
                ShowDataCount(source);

                //string[] sSumLable = { "소계", "합계" }; //
                string[] sSumLable = { this.GetLabel("STOT"), this.GetLabel("TOTAL") }; //
                grd01.setSumStyle(2, 3, AxFlexGrid.eSumStyle.RowColMode, sSumLable);
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
                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {
                DateTime t1 = DateTime.Parse(dtp01_BEG_DATE.GetValue().ToString());
                DateTime t2 = DateTime.Parse(dtp01_END_DATE.GetValue().ToString());

                TimeSpan t3 = t2 - t1;

                if (t3.Days < 0)
                {
                    //MsgBox.Show("날짜 지정이 올바르지 않습니다.");
                    MsgCodeBox.Show("PD00-0080");
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        #endregion
    }
}
