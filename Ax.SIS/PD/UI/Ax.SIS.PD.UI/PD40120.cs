#region ▶ Description & History
/* 
 * 프로그램명 : PD40120 제품별 작업 이력 ？ 전체 현황
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


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 제품별 작업 이력 - 전체 현황
    /// </summary>
    public partial class PD40120 : AxCommonBaseControl
    {
        //private IPD40120 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40120";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40120()
        {
            InitializeComponent();

            //_WSCOM  = ClientFactory.CreateChannel<IPD40120>("PD", "PD40120_N.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Lot No", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "출력 시간", "PROD_TIME", "BARCODE_PRINT_TIME"); //바코드 출력시간
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "완제품 P/No", "PARTNO", "PART_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "이종검사", "PARTS_CHECK", "PARTS_CHECK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "입고일자", "PROD_DATE", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "입고시간", "IN_READ_TIME", "RCV_TIME1"); //입고시간
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "출고일자", "DELI_DATE", "OUT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "출고순번", "ALC_SEQ", "ALC_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "공정순번", "PROC_SEQ", "PROC_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "공정코드", "PROCCD", "PROCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "공정명", "PROCNM", "PROCNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "시작시간", "BEG_TIME", "BEG_TIME"); //시작시간
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "종료시간", "END_TIME", "END_TIME"); //종료시간
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "공정상태", "WORK_STATUS", "WORK_STATUS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DELI_DATE");
                for (int i = 0; i <= this.grd01.Cols["ALC_SEQ"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2);
                //DataSet source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST();

                this.cbl01_INSTALL_POS.DataBind(source2.Tables[0], "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");    //타입코드;타입명

                this.txt01_LOTNO.SetValid(AxTextBox.TextType.UAlphabet);
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
                if (this.cbl01_LINECD.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("라인은 필수 조건입니다.");
                    //{0}이(가) 선택되지 않았습니다.
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LINE"));
                    return;
                }

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("RSLT_SDATE", this.dtp01_RSLT_SDATE.GetDateText());
                set.Add("RSLT_EDATE", this.dtp01_RSLT_EDATE.GetDateText());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("LOTNO", this.txt01_LOTNO.GetValue());
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

        #region [기타 컨트롤 이벤트]

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PRDT_DIV", "");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

                this.cbl01_LINECD.DataBind(source1.Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
