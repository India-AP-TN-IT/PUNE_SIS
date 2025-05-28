#region ▶ Description & History
/* 
 * 프로그램명 : PD40110 제품별 작업 내역 추적
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
    /// 제품별 작업내역 추적
    /// </summary>
    public partial class PD40110 : AxCommonBaseControl
    {
        //private IPD40110 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40110";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        public PD40110()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD40110>("PD", "PD40110_N.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();

        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody  = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd02.AllowEditing = false;
                this.grd01.Initialize();
                this.grd02.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "Lot No", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "ALC", "ALCCD", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "완제품 P/No", "PARTNO", "PART_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "공정상태", "WORK_STATUS_DESC", "WORK_STATUS_DESC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "라인코드", "LINECD", "LINECD");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "공정코드", "PROCCD", "PROCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "공정명", "PROCNM", "PROCNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "횟수", "WORK_CNT", "WORK_CNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "시작일자", "BEG_DATE", "BEG_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "시작시간", "BEG_TIME", "BEG_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "완료일자", "END_DATE", "END_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "완료시간", "END_TIME", "END_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "결과", "WORK_STATUS_DESC", "WORK_STATUS_DESC");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                this.cbl01_INSTALL_POS.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"),set2).Tables[0], this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");    //타입코드;타입명
                //this.cbl01_INSTALL_POS.DataBind(_WSCOM_ERM.INQUERY_COMBO_POSINFOLIST().Tables[0], this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");    //타입코드;타입명
                
                this.dtp01_SDATE.SetValue(DateTime.Now);
                this.SetRequired(lbl01_BIZNM2, lbl02_WORK_DATE, lbl04_LINE);
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
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                //DataSet source = _WSCOM.INQUERY(bizcd, set);

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
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("PRDT_DIV", "A0A");
            set.Add("LANG_SET", this.UserInfo.Language);
            this.cbl01_LINECD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0], this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
            //this.cbl01_LINECD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0], this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명
        }

        private void cbo01_LINECD_SelectedIndexChanged(object sender, EventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set.Add("LINECD", this.cbl01_LINECD.GetValue());
            DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_PROCLIST"), set).Tables[0];
            //DataTable source = _WSCOM_ERM.INQUERY_COMBO_PROCLIST(set).Tables[0];
            if (source.Rows.Count > 0)
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, source, "PROCNM");
        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < 0) return;

                string lotno = this.grd01.GetValue(row, "LOTNO").ToString();
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LOTNO", lotno);
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PROC_HISTORY"), set, "OUT_CURSOR");
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR");

                //DataSet source1 = _WSCOM.INQUERY_PROC_HISTORY(bizcd, set);
                //DataSet source2 = _WSCOM.INQUERY_DETAIL(bizcd, set);

                if (source2.Tables[0].Rows.Count > 0)
                {
                    DataRow r = source2.Tables[0].Rows[0];

                    string PROD_TIME = r["PROD_TIME"].ToString();
                    string IN_READ_TIME = r["IN_READ_TIME"].ToString();
                    string OUT_READ_TIME = r["OUT_READ_TIME"].ToString();

                    this.txt02_LOTNO.SetValue(r["LOTNO"]);
                    this.txt02_ALC.SetValue(r["ALCCD"]);
                    this.txt02_PARTNO.SetValue(r["PARTNO"]);
                    if (PROD_TIME.Length >= 6)
                    {
                        this.txt02_TAGDATETIME.SetValue(String.Format("{0} {1}:{2}:{3}", r["RSLT_DATE"] != DBNull.Value ? Convert.ToDateTime(r["RSLT_DATE"]).ToShortDateString() : r["RSLT_DATE"],
                            PROD_TIME.Substring(0, 2), PROD_TIME.Substring(2, 2), PROD_TIME.Substring(4, 2)));
                    }
                    else
                    {
                        txt02_TAGDATETIME.SetValue("");
                    }
                    this.txt02_PRODDATE.SetValue(r["PROD_DATE"]);
                    if (IN_READ_TIME.Length >= 6)
                    {
                        this.txt02_INDATETIME.SetValue(String.Format("{0} {1}:{2}:{3}", r["IN_READ_DATE"] != DBNull.Value ? Convert.ToDateTime(r["IN_READ_DATE"]).ToShortDateString() : r["IN_READ_DATE"],
                            IN_READ_TIME.Substring(0, 2), IN_READ_TIME.Substring(2, 2), IN_READ_TIME.Substring(4, 2)));
                    }
                    else
                    {
                        txt02_INDATETIME.SetValue("");
                    }
                    if (OUT_READ_TIME.Length >= 6)
                    {
                        this.txt02_OUTDATETIME.SetValue(String.Format("{0} {1}:{2}:{3}", r["OUT_READ_DATE"] != DBNull.Value ? Convert.ToDateTime(r["OUT_READ_DATE"]).ToShortDateString() : r["OUT_READ_DATE"],
                            OUT_READ_TIME.Substring(0, 2), OUT_READ_TIME.Substring(2, 2), OUT_READ_TIME.Substring(4, 2)));
                    }
                    else
                    {
                        txt02_OUTDATETIME.SetValue("");
                    }
                    this.txt02_APPLYDATE.SetValue(r["DELI_DATE"] != DBNull.Value ? Convert.ToDateTime(r["DELI_DATE"]).ToShortDateString() : r["DELI_DATE"]);
                    this.txt02_FACTORY_LINE_SEQ.SetValue(String.Format("{0} / {1} / {2}", r["CUST_PLANT"], r["CUST_LINE"], r["ALC_SEQ"]));
                }

                this.grd02.SetValue(source1);
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
