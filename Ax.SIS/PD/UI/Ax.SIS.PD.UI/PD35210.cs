#region ▶ Description & History
/* 
 * 프로그램명 : PD35210 비가동 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23    배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *              2014-10-07    진승모     다국어 적용
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>비가동 조회</b>
    /// </summary>
    public partial class PD35210 : AxCommonBaseControl
    {
        //private IPD35210 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD35210";

        public PD35210()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD35210>("PM05", "PD35210.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
        }

        #region [ 초기화 작업 정의 ]

        private void PD35210_Load(object sender, EventArgs e)
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
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);


                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());

                


                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "비가동번호", "NON_OPRNO", "NON_OPRNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "일자", "OCCUR_DATE", "OCCUR_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "라인", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "장착위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "시작시간", "BEG_TIME", "BEG_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "종료시간", "END_TIME", "END_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "비가동코드", "NON_OPRCD", "NON_OPRCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "비가동명", "NON_OPRNM", "NON_OPRNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "인원", "PERSON", "PERSON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "실정지시간", "STOP_TIME_SUM", "STOP_TIME_SUM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "정지공수", "STOP_MH_SUM", "STOP_MH_SUM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "내역", "DET_DESC", "DET_DESC");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");
                this.grd01.Cols["STOP_MH_SUM"].Format = "###,###,##0.#";


                //DataSet source = _WSCOM.Get_NonOprCD(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_NON_OPRCD"), set);
                this.cbo01_NON_OPRCD.DataBind(source.Tables[0]);

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1();//new PM20015P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_BEG_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1();//new PM20015P1();
                //this.cdx01_LINECD.PopupTitle = "대표 라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_BEG_DATE.GetValue());

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
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetDateText().ToString());
                paramSet.Add("END_DATE", this.dtp01_END_DATE.GetDateText().ToString());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                paramSet.Add("NON_OPRCD", this.cbo01_NON_OPRCD.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                this.grd01.SetValue(source.Tables[0]);
                ShowDataCount(source);
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

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void cdx01_LINECD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
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
