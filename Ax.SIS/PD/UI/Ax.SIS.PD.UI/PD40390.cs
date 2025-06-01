#region ▶ Description & History
/* 
 * 프로그램명 : PD40390 통전/이종 검사 불량/누락 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
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
    /// 장기재고 이력조회
    /// </summary>
    public partial class PD40390 : AxCommonBaseControl
    {
        //private IPD40390 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40390";
        private string PACKAGE_NAME_PD40130 = "APG_PD40130";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        public PD40390()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD40390>("PD", "PD40390_N.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //if (this.UserInfo.BusinessCode == "5220")
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40390>("PD", "PD40390.svc", "CustomBinding");

                //}
                //else
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40390>("PD", "PD40390_N.svc", "CustomBinding");
                //}
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "통전검사상태", "CHK_ET_DESC", "CHK_ET_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "이종검사상태", "CHK_DI_DESC", "CHK_DI_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "공정상태", "PROC_STATUS", "WORK_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "LOT NO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "ALC", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산시간", "PROD_TIME", "PROD_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "입고일자", "IN_READ_DATE", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "입고시간", "IN_READ_TIME", "RCV_TIME1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "출고일자", "OUT_READ_DATE", "OUT_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "IN_READ_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "OUT_READ_DATE");


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "검사항목", "ET_DTLNM", "ET_DTLNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "검사결과", "RESULT_DESC", "INSPECT_RSLT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "검사일자", "INSPEC_DATE", "INSPECT_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "검사시간", "INSPEC_TIME", "INSPECT_TIME");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD",  cbo01_BIZCD.GetValue().ToString());
                set.Add("PRDT_DIV", "A0A");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);
                

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
                if (string.IsNullOrEmpty(cbl01_VINCD.GetValue().ToString()))
                {
                    //MsgBox.Show("차종을 선택하지 않았습니다.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("VEHICLE"));
                    cbl01_VINCD.Focus();
                    return;
                }
                this.grd02.SetValue(new DataTable());
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue().ToString());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());               
                set.Add("PROD_SDATE", this.dtp01_INSPEC_SDATE.GetDateText());
                set.Add("PROD_EDATE", this.dtp01_INSPEC_EDATE.GetDateText());
                set.Add("LOTNO", this.heTextBox1.Text);
                set.Add("PARTNO", this.heTextBox2.Text);
                set.Add("VINCD", this.cbl01_VINCD.GetValue().ToString());
                set.Add("OEM_ONLY",chk01_OEM_YN.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(cbo01_BIZCD.GetValue().ToString(), set);
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

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set.Add("PRDT_DIV", "");
            set.Add("LANG_SET", this.UserInfo.Language);
            DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
            //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

            this.cbl01_LINECD.DataBind(source1.Tables[0], this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명
            
       
        }

        private void cbl01_VINCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("LANG_SET", this.UserInfo.Language);
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_CARTYPE"), set);
            //DataSet source2 = _WSCOM_ERM.INQUERY_COMBO_CARTYPE(set);
            this.cbl01_VINCD.DataBind(source2.Tables[0], "TYPECD", "OBJECT_NM", this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L");  //차종코드;차종명
        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            if (grd01.SelectedRowIndex < 1)
                return;
            string LOTNO = grd01.Rows[grd01.SelectedRowIndex]["LOTNO"].ToString();
            HEParameterSet set2 = new HEParameterSet();
            set2.Add("CORCD", this.UserInfo.CorporationCode);
            set2.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set2.Add("LOTNO", LOTNO);
            set2.Add("VINCD", "");
            set2.Add("LINECD", this.cbl01_LINECD.GetValue());

            DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_PD40130, "INQUERY_ETHISTORY"), set2, "OUT_CURSOR");

            //IPD40130 iCom = ClientFactory.CreateChannel<IPD40130>("PD", "PD40130_N.svc", "CustomBinding");
            //DataTable source2 = iCom.INQUERY_ETHISTORY(this.cbo01_BIZCD.GetValue().ToString(), set2).Tables[0];
            this.grd02.SetValue(source2);
        }

        #endregion

    }
}
