#region ▶ Description & History
/* 
 * 프로그램명 : PD40310 사출 중량 온도 계측 LOT별 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
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
    public partial class PD40310 : AxCommonBaseControl
    {
        //private IPD40310 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private string PAKCAGE_NAME = "APG_PD40310";
        private string PACKAGE_NAME_MES = "APG_PDCOMMON_MES";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        public PD40310()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD40310>("PD", "PD40310_N.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
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
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업일자", "PROD_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "라인", "LINECD", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "검사일자", "INSPEC_DATE", "INSPECT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "작업형태", "PRESS_TYPE", "TYPE_WORK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "검사일시", "INSPEC_TIME", "INSPEC_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "계측유형코드", "INSPEC_DIV", "INSPECTION_TYPECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "계측유형명칭", "INSPEC_DIVNM", "INSPEC_DIV_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "계측항목코드", "INSPEC_ITEMCD", "INSPECTION_ITEMCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "계측항목명칭", "INSPEC_ITEMNM", "MGRT_EXPNCD_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "계측위치", "INSPEC_POS", "INSPECTION_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "측정값", "RSLT_INSPEC", "MEASURE_TITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "기준값", "STD_VALUE", "STD_VALUE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "하한값", "MIN_VALUE", "MIN_VALUE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "상한값", "MAX_VALUE", "MAX_VALUE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "결과", "RESULT", "RESULT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_INSPEC");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "MIN_VALUE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "MAX_VALUE");

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.dtp01_PROD_SDATE.SetValue(DateTime.Now);
                
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

                if (cbl01_LINECD.GetValue().ToString() == "")
                {
                    MsgCodeBox.ShowFormat("CD00-0082", this.lbl03_LINE.Text);// "라인");//@@@
                    return;
                }
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PROD_SDATE", this.dtp01_PROD_SDATE.GetDateText());
                set.Add("PROD_EDATE", this.dtp01_PROD_SDATE.GetDateText());                
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("PARTNO", this.cbl01_PARTNO.GetValue());

                set.Add("INSPEC_DIV", this.cbl01_INSPEC_DIV.GetValue());
                set.Add("INSPEC_ITEMCD", this.cbl01_INSPEC_ITEMCD.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKCAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

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
            grd01.AllowMerging = (this.chk01_MERGE.Checked) ?
                C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                C1.Win.C1FlexGrid.AllowMergingEnum.None;
        }

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set.Add("PRDT_DIV", this.rdo01_ASSYPNO.Checked ? "A0A" : "A0S");  //완/반 구분에 따라 제품구분 조건 설정 2013.05.14 배명희
            set.Add("LANG_SET", this.UserInfo.Language);
            this.cbl01_LINECD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            //this.cbl01_LINECD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
        }

        private void cbl01_PARTNO_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("RSLT_SDATE", this.dtp01_PROD_SDATE.GetDateText());
            set.Add("RSLT_EDATE", this.dtp01_PROD_SDATE.GetDateText());
            set.Add("LINECD", this.cbl01_LINECD.GetValue());
            set.Add("ASSY", this.rdo01_ASSYPNO.Checked ? "1" : "2");
            set.Add("LANG_SET", this.UserInfo.Language);
            this.cbl01_PARTNO.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_RESULTPARTNO"), set).Tables[0], "PARTNO", "PARTNO", this.GetLabel("PARTNOTITLE") + ";" + this.GetLabel("PARTNONM") + ";ALC;" + this.GetLabel("VEHICLE"), "L;L;C;L");    //품번;품명;ALC;차종
            //this.cbl01_PARTNO.DataBind(_WSCOM_MES.INQUERY_COMBO_RESULTPARTNO(bizcd, set).Tables[0], "PARTNO", "PARTNO", this.GetLabel("PARTNOTITLE") + ";" + this.GetLabel("PARTNONM") + ";ALC;" + this.GetLabel("VEHICLE"), "L;L;C;L");    //품번;품명;ALC;차종
        }

        private void cbl01_INSPEC_DIV_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", bizcd);
            
            this.cbl01_INSPEC_DIV.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECDIV"), set1).Tables[0], "INSPEC_DIV", "INSPEC_DIVNM", this.GetLabel("OBJECTID") + ";" + this.GetLabel("INSPEC_DIV_NM"), "C;L");   //유형코드;계측유형명
            //this.cbl01_INSPEC_DIV.DataBind(_WSCOM_MES.INQUERY_COMBO_INSPECDIV(bizcd, set1).Tables[0], "INSPEC_DIV", "INSPEC_DIVNM", this.GetLabel("OBJECTID") + ";" + this.GetLabel("INSPEC_DIV_NM"), "C;L");   //유형코드;계측유형명
        }

        private void cbl01_INSPEC_ITEMCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("INSPEC_DIV", this.cbl01_INSPEC_DIV.GetValue());
            
            this.cbl01_INSPEC_ITEMCD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_MES, "INQUERY_COMBO_INSPECITEM"), set).Tables[0], "INSPEC_ITEMCD", "INSPEC_ITEMNM", this.GetLabel("MGRT_EXPNCD") + ";" + this.GetLabel("MGRT_EXPNCD_NM"), "C;L");    //항목코드;계측항목명
            //this.cbl01_INSPEC_ITEMCD.DataBind(_WSCOM_MES.INQUERY_COMBO_INSPECITEM(bizcd, set).Tables[0], "INSPEC_ITEMCD", "INSPEC_ITEMNM", this.GetLabel("MGRT_EXPNCD") + ";" + this.GetLabel("MGRT_EXPNCD_NM"), "C;L");    //항목코드;계측항목명
        }

        #endregion
    }
}
