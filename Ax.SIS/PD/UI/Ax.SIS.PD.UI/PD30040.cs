#region ▶ Description & History
/* 
 * 프로그램명 : PD30040 수지Lot 추적조회
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
using System.Drawing;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 수지Lot 추적조회
    /// </summary>
    public partial class PD30040 : AxCommonBaseControl
    {
        //private IPD30040 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD30040";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;

        public PD30040()
        {
            InitializeComponent();

            //_WSCOM = AxClientProxy.CreateChannel<IPD30040>("PD", "PD30040.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
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
                this.grd02.AllowEditing = false;
                this.grd03.AllowEditing = false;
                this.grd04.AllowEditing = false;
                this.grd01.Initialize();
                this.grd02.Initialize();
                this.grd03.Initialize();
                this.grd04.Initialize();
                this.grd02.EnabledActionFlag = false;
                this.grd04.EnabledActionFlag = false;

                this.grd02.SubtotalPosition = SubtotalPositionEnum.AboveData;
                this.grd04.SubtotalPosition = SubtotalPositionEnum.AboveData;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 0, "", "");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "투입일자", "WORK_DATE", "INPUT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "탱크번호", "RES_TANK_NO", "TANKNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "투입순번", "SEQ", "IN_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "수지 PART NO", "PARTNO", "RESIN_PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "Grade No", "GRADE_NO", "GRADE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "수지 Lot No", "RES_LOTNO", "RESINLOTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "라인", "LINECD", "LINE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 0, "", "");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "법인코드", "CORCD", "CORCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "라인", "LINECD", "LINE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "RSLT_DATE", "PROD_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "제품 P/NO", "PARTNO", "ASSY_PNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "LOT NO", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD", "VIN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "ALC", "ALCCD", "ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "실적일자", "PROD_DATE", "RSLT_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "생산시간", "PROD_TIME", "PROD_TIME");
                //this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE"); SUB TOTAL, TOTAL 기능사용하기 위해.. 날짜포맷 지정 안함..
                //this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "RSLT_DATE"); SUB TOTAL, TOTAL 기능사용하기 위해.. 날짜포맷 지정 안함..

                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 0, "", "");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "라인", "LINECD", "LINE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "반제품PARTNO", "PARTNO", "SEMI_PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "반제품LOTNO", "LOTNO", "SEMI_LOTNO");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");

                this.grd04.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 0, "", "");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "투입일자", "WORK_DATE", "INPUT_DATE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "수지탱크(라인)", "RES_TANK_NO", "RES_TANK_LM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "투입순번", "SEQ", "IN_SEQ");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "수지 PART NO", "PARTNO", "RESIN_PARTNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Grade No", "GRADE_NO", "GRADE_NO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 130, "수지 Lot No", "RES_LOTNO", "RESINLOTNOTITLE");
                //this.grd04.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE"); //SUB TOTAL, TOTAL 기능사용하기 위해.. 날짜포맷 지정 안함..

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.dtp01_SDATE.SetValue(DateTime.Now);

                grp01_PD30040_GRP_1.Text = GetLabel("PD30040_GRP_1");
                grp01_PD30040_GRP_2.Text = GetLabel("PD30040_GRP_2");
                grp01_PD30040_GRP_3.Text = GetLabel("PD30040_GRP_3");
                grp01_PD30040_GRP_4.Text = GetLabel("PD30040_GRP_4");

                tabControl1.TabPages[0].Text = GetLabel("SEMI_SEARCH");
                tabControl1.TabPages[1].Text = GetLabel("RESIN_LOT_SEARCH");             
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
                set.Add("LOTNO", this.txt01_LOTNO.GetValue());
                set.Add("LINECD", this.cbl01_LINECD.GetValue());

                this.BeforeInvokeServer(true);
                if (this.tabControl1.SelectedIndex == 0)
                    //this.grd01.SetValue(_WSCOM.INQUERY(bizcd, set));
                    grd01.SetValue(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR"));
                else
                    grd03.SetValue(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_BATCH"), set, "OUT_CURSOR"));
                    //this.grd03.SetValue(_WSCOM.INQUERY_BATCH(bizcd, set));
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

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("PRDT_DIV", "");
            set.Add("LANG_SET", this.UserInfo.Language);
            this.cbl01_LINECD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set).Tables[0], GetLabel("LINECD") + ";" + GetLabel("LINENM"), "C;L");
            ////this.cbl01_LINECD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0], "라인코드;라인명", "C;L");
            //this.cbl01_LINECD.DataBind(_WSCOM_ERM.INQUERY_COMBO_LINELIST(set).Tables[0], GetLabel("LINECD")+";"+GetLabel("LINENM"), "C;L");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab.Text = "반제품 조회";
            //this.lbl01_INPUT_DATE.SetValue("투입일자");
            //this.lbl01_RESINLOTNOTITLE.SetValue("수지Lot");

            this.tabControl1.SelectedTab.Text = GetLabel("SEMI_SEARCH");
            this.lbl01_INPUT_DATE.SetValue(GetLabel("INPUT_DATE"));
            this.lbl01_RESINLOTNOTITLE.SetValue(GetLabel("RESINLOTNOTITLE"));

            if (this.tabControl1.SelectedIndex > 0)
            {
                //this.tabControl1.SelectedTab.Text = "수지Lot 조회";
                //this.lbl01_INPUT_DATE.SetValue("생산일자");
                //this.lbl01_RESINLOTNOTITLE.SetValue("반제품LotNo");

                this.tabControl1.SelectedTab.Text = GetLabel("RESIN_LOT_SEARCH");
                this.lbl01_INPUT_DATE.SetValue(GetLabel("PROD_DATE"));
                this.lbl01_RESINLOTNOTITLE.SetValue(GetLabel("SEMI_LOTNO"));
            }
        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < 0) return;

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LOTNO", this.grd01.GetValue(row, "RES_LOTNO"));
                set.Add("LINECD", this.grd01.GetValue(row, "LINECD"));
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_LIST(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LIST"), set, "OUT_CURSOR");

                //-- 날짜 포맷을 현재  시스템의 FORMAT으로 맞게 변경 작업.
                source.Tables[0].Columns.Add("PROD_DATE_", typeof(DateTime));
                source.Tables[0].Columns.Add("RSLT_DATE_", typeof(DateTime));

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    if (dr["PROD_DATE"] == DBNull.Value)
                        dr["PROD_DATE_"] = DBNull.Value;
                    else
                    {
                         dr["PROD_DATE_"] = Convert.ToDateTime(dr["PROD_DATE"]);
                         dr["PROD_DATE"] = Convert.ToDateTime(dr["PROD_DATE_"]).ToShortDateString();
                    }


                    if (dr["RSLT_DATE"] == DBNull.Value)
                        dr["RSLT_DATE_"] = DBNull.Value;
                    else
                    {
                        dr["RSLT_DATE_"] = Convert.ToDateTime(dr["RSLT_DATE"]);
                        dr["RSLT_DATE"] = Convert.ToDateTime(dr["RSLT_DATE_"]).ToShortDateString();
                    }
                }
                
                source.Tables[0].Columns.Remove("PROD_DATE_");
                source.Tables[0].Columns.Remove("RSLT_DATE_");

                //-- 날짜 포맷을 현재  시스템의 FORMAT으로 맞게 변경하는 작업.

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

        private void grd03_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd03.SelectedRowIndex;
                if (row < 0) return;

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LOTNO", this.grd03.GetValue(row, "LOTNO"));

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_BATCH_LIST(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_BATCH_LIST"), set, "OUT_CURSOR");


                //-- 날짜 포맷을 현재  시스템의 FORMAT으로 맞게 변경 작업.                
                source.Tables[0].Columns.Add("WORK_DATE_", typeof(DateTime));

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    if (dr["WORK_DATE"] == DBNull.Value)
                        dr["WORK_DATE_"] = DBNull.Value;
                    else
                    {
                        dr["WORK_DATE_"] = Convert.ToDateTime(dr["WORK_DATE"]);
                        dr["WORK_DATE"] = Convert.ToDateTime(dr["WORK_DATE_"]).ToShortDateString();
                    }

                }

                source.Tables[0].Columns.Remove("WORK_DATE_");

                this.grd04.SetValue(source);
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

        private void grd02_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            this.grd02.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, 2, 7);

            this.grd02.Tree.Column = 2;
            //this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count, 0, 0, 5, "전체 합계");
            //this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count, 1, 5, 5, "[{0}] 합계");

            this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count, 0, 0, 5, GetLabel("ALL_TOT"));
            this.grd02.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count, 1, 5, 5, "[{0}] " + GetLabel("TOTAL"));

            this.grd02.Styles["Subtotal0"].BackColor = Color.Gold;
            this.grd02.Styles["Subtotal0"].ForeColor = Color.Black;

            this.grd02.Styles["Subtotal1"].BackColor = Color.LightYellow;
            this.grd02.Styles["Subtotal1"].ForeColor = Color.Black;
        }

        private void grd04_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            this.grd04.Tree.Column = 2;
            //this.grd04.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count, 0, 0, 3, "전체 합계");
            //this.grd04.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count, 1, 2, 3, "[{0}] 합계");

            this.grd04.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count, 0, 0, 3, GetLabel("ALL_TOT"));
            this.grd04.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Count, 1, 2, 3, "[{0}] "+GetLabel("TOTAL"));

            this.grd04.Styles["Subtotal0"].BackColor = Color.Gold;
            this.grd04.Styles["Subtotal0"].ForeColor = Color.Black;

            this.grd04.Styles["Subtotal1"].BackColor = Color.LightYellow;
            this.grd04.Styles["Subtotal1"].ForeColor = Color.Black;
        }

        #endregion

    }
}
