#region ▶ Description & History
/* 
 * 프로그램명 : PD40010 장기재고 이력조회
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
    /// 장기재고 이력조회
    /// </summary>
    public partial class PD40010 : AxCommonBaseControl
    {
        //private IPD40010 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;

        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40010";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40010()
        {
            InitializeComponent();
            
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _WSCOM_N = new AxClientProxy();

                //if (this.UserInfo.BusinessCode == "5220")
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40010>("PD", "PD40010.svc", "CustomBinding");
                //}
                //else
                //{
                //_WSCOM = ClientFactory.CreateChannel<IPD40010>("PD", "PD40010_N.svc", "CustomBinding");
                //}

                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "라인", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "라인명", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "P/NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "ALC", "ALC", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "LOT NO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "RACK NO", "LODTBL_NO", "LODTBL_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "입고일자", "IN_READ_DATE", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "확정/해제", "APPLY_DAY", "APPLY_DAY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "재고일", "DIFF_CNT", "STOCK_DAY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "상태", "CLS_STATE", "STATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "해제사유", "CLS_TYPE", "CLS_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "작업자", "WORKER", "WORKER");

                //this.grd01.Cols["IN_READ_DATE"].Format = "G";
                //this.grd01.Cols["APPLY_DAY"].Format = "G";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "IN_READ_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "APPLY_DAY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DIFF_CNT");

                for (int i = 0; i <= this.grd01.Cols["CLS_TYPE"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "A0A");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

                this.cbl01_LINECD.DataBind(source1.Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2);
                //DataSet source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST();

                this.cbl01_INSTALL_POS.DataBind(source2.Tables[0], "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");    //타입코드;타입명

                DataTable source3 = new DataTable();
                source3.Columns.Add("CODE");
                source3.Columns.Add("NAME");

                source3.Rows.Add("AP", this.GetLabel("STOCK_SET")); //장기재고 확정
                source3.Rows.Add("CL", this.GetLabel("STOCK_CLEAR"));   //장기재고 해제

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
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("CHK_TYPE", this.cbo01_CHK_TYPE.GetValue());
                set.Add("PROD_SDATE", this.dtp01_INSPEC_SDATE.GetDateText());
                set.Add("PROD_EDATE", this.dtp01_INSPEC_EDATE.GetDateText());
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
    }
}
