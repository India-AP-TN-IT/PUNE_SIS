#region ▶ Description & History
/* 
 * 프로그램명 : PD40410 기타출고품 조회
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
    public partial class PD40410 : AxCommonBaseControl
    {
        //private IPD40410 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40410";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40410()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                
                //if (this.UserInfo.BusinessCode == "5220")
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40410>("PD", "PD40410.svc", "CustomBinding");
                //}
                //else
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40410>("PD", "PD40410_N.svc", "CustomBinding");
                //}
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "라인", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "LOT NO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "ALC", "ALC", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "입고일자", "IN_READ_DATE", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "출고일자", "OUT_READ_DATE", "OUT_DATE");


                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "A0A");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);
                
                //this.cbl01_LINECD.DataBind(source1.Tables[0], "LINECD", "LINENM", "라인코드;라인명", "C;L");
                this.cbl01_LINECD.DataBind(source1.Tables[0], "LINECD", "LINENM", GetLabel("LINECD")+";"+GetLabel("LINENM"), "C;L");

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2);
                //DataSet source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST();

                //this.cbl01_INSTALL_POS.DataBind(source2.Tables[0], "TYPECD", "OBJECT_NM", "타입코드;타입명", "C;L");
                this.cbl01_INSTALL_POS.DataBind(source2.Tables[0], "TYPECD", "OBJECT_NM", GetLabel("TYPE_CD")+";"+GetLabel("TYPE_NM"), "C;L");
                
                DataTable source3 = new DataTable();
                source3.Columns.Add("CODE");
                source3.Columns.Add("NAME");

                source3.Rows.Add("O3", this.GetLabel("CHK_TYPE_O3"));// "결품추가"); //@@@
                source3.Rows.Add("O4", this.GetLabel("CHK_TYPE_O4"));// "추가파견"); //@@@
                source3.Rows.Add("O5", this.GetLabel("CHK_TYPE_O5"));// "기타출고"); //@@@
                source3.Rows.Add("O7", this.GetLabel("CHK_TYPE_O7"));// "임시출고"); //@@@
                source3.Rows.Add("OE", this.GetLabel("CHK_TYPE_OE"));// "출고금지"); //@@@

                this.cbo01_CHK_TYPE.DataBind(source3);             
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
                string bizcd = this.UserInfo.BusinessCode;
                HEParameterSet set = new HEParameterSet();
                DataSet source = null;
                
                //if (bizcd != "5210")
                //{
                //    set.Add("CORCD", this.UserInfo.CorporationCode);
                //    set.Add("BIZCD", bizcd);
                //    set.Add("LINECD", this.cbl01_LINECD.GetValue());
                //    set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                //    set.Add("LOTNO", this.txt01_LOTNO.GetValue());
                //    set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                //    set.Add("ALCCD", this.txt01_ALCCD.GetValue());
                //    set.Add("S_DATE", this.dtp01_INSPEC_SDATE.GetValue());
                //    set.Add("E_DATE", this.dtp01_INSPEC_EDATE.GetValue());

                //    this.BeforeInvokeServer(true);
                //    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                //    source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                //}
                //else
                //{
                //    set.Add("CORCD", this.UserInfo.CorporationCode);
                //    set.Add("BIZCD", bizcd);
                //    set.Add("LINECD", this.cbl01_LINECD.GetValue());
                //    set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                //    set.Add("INV_STATUS", this.cbo01_CHK_TYPE.GetValue());
                //    set.Add("LOTNO", this.txt01_LOTNO.GetValue());
                //    set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                //    //set.Add("ALCCD", this.txt01_ALCCD.GetValue());
                //    set.Add("S_DATE", this.dtp01_INSPEC_SDATE.GetValue());
                //    set.Add("E_DATE", this.dtp01_INSPEC_EDATE.GetValue());

                //    this.BeforeInvokeServer(true);
                //    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                //    source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_ULSAN"), set, "OUT_CURSOR");
                //}

                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("INV_STATUS", this.cbo01_CHK_TYPE.GetValue());
                set.Add("LOTNO", this.txt01_LOTNO.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                set.Add("ALCCD", this.txt01_ALCCD.GetValue());
                set.Add("S_DATE", this.dtp01_INSPEC_SDATE.GetDateText());
                set.Add("E_DATE", this.dtp01_INSPEC_EDATE.GetDateText());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

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
    }
}
