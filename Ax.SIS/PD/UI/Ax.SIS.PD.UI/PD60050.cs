#region ▶ Description & History
/* 
 * 프로그램명 : PD60050 사출수지 현재고 조회
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
    /// 완제품 창고 현재고 조회
    /// </summary>
    public partial class PD60050 : AxCommonBaseControl
    {
        //private IPD60050 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD60050";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;

        #region [ 초기화 작업 정의 ]

        public PD60050()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD60050>("PD", "PD60050.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody  = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd03.AllowEditing = false;
                this.grd03.Initialize();

                this.grd01.AllowMerging = AllowMergingEnum.FixedOnly;
                this.grd01.EnabledActionFlag = false;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "차종코드", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "수지 PART NAME", "PARTNM", "MIXER_PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "수지품번", "PARTNO", "RESIN_PNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "재고량", "STOCK_COUNT", "STOCK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOCK_COUNT");

                this.grd02.SubtotalPosition = SubtotalPositionEnum.AboveData;
                this.grd02.AllowSorting = AllowSortingEnum.MultiColumn;
                this.grd02.AllowMerging = AllowMergingEnum.Free;
                this.grd02.AutoGenerateColumns = false;
                this.grd02.Rows.MinSize = 22;
                this.grd02.AllowMerging = AllowMergingEnum.RestrictCols;
                this.grd02.EnabledActionFlag = false;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "RACK 번호", "LODTBL_NO", "LODTBL_NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "차종코드", "VINCD", "VINCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "수지 PART NAME", "PARTNM", "MIXER_PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "LOT NO", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "입고일자", "IN_DATE", "RCV_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "적재일수", "STOCKED_DAYS", "STOCKED_DAYS");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOCKED_DAYS");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "IN_DATE");

                this.grd03.SubtotalPosition = SubtotalPositionEnum.AboveData;
                this.grd03.AllowSorting = AllowSortingEnum.None;
                this.grd03.AllowMerging = AllowMergingEnum.Free;
                this.grd03.AutoGenerateColumns = false;
                this.grd03.Rows.MinSize = 22;
                this.grd03.AllowMerging = AllowMergingEnum.RestrictCols;
                this.grd03.EnabledActionFlag = false;
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "RACK 번호", "LODTBL_NO", "LODTBL_NO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "차종코드", "VINCD", "VINCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "수지 PART NAME", "PARTNM", "MIXER_PARTNM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "재고량", "PRDCNT", "STOCK_QTY");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal, "PRDCNT");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.SetRequired(lbl01_BIZCD);

                DataTable dtPlant = new DataTable();
                dtPlant.Columns.Add("CODE");
                dtPlant.Columns.Add("NAME");

                //dtPlant.Rows.Add("P03", "2공장");
                //dtPlant.Rows.Add("P01", "4공장");
                //dtPlant.Rows.Add("P02", "파일롯동");

                dtPlant.Rows.Add("P01", GetLabel("PLANT_P01")); //생산4동
                dtPlant.Rows.Add("P02", GetLabel("PLANT_P02")); //PILOT
                dtPlant.Rows.Add("P03", GetLabel("PLANT_P03")); //생산2동
                dtPlant.Rows.Add("P04", GetLabel("PLANT_P04")); //두서공장

                //this.cbl01_Plant.DataBind(dtPlant, "공장코드;공장명", "C;L");
                this.cbl01_Plant.DataBind(dtPlant, "CODE", "NAME", GetLabel("PLANTCD") + ";" + GetLabel("PLANTNM"), "C;L");
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
                this.grd02.InitializeDataSource();
                this.grd03.InitializeDataSource();

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode); ;
                set.Add("BIZCD", bizcd);
                set.Add("PLANT", this.cbl01_Plant.GetValue());
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

        #region [ 기타 컨트롤 이벤트 ]

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();                
            //DataSet source1 = _WSCOM_MES.INQUERY_COMBO_RESTANK_LINE(bizcd);
            //this.cbl01_RES_TANK_NO.DataBind(source1.Tables[0], "수지호기코드;명칭", "C;L");            
        }

        private void grd01_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PLANT", this.cbl01_Plant.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_RACK_LIST(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_RACK_LIST"), set, "OUT_CURSOR");

                this.grd03.SetValue(source);
                this.AfterInvokeServer();
                this.grd03.Tree.Column = 1;
                //this.grd03.Subtotal(AggregateEnum.Sum, 0, -1, 4, "전체 합계");
                //this.grd03.Subtotal(AggregateEnum.Sum, 1, 1, 4, "[{0}] 합계");

                this.grd03.Subtotal(AggregateEnum.Sum, 0, -1, 4, GetLabel("ALL_TOT"));
                this.grd03.Subtotal(AggregateEnum.Sum, 1, 1, 4, "[{0}]"+GetLabel("TOTAL"));

                if (this.grd01.Rows.Count > 1)
                {
                    this.grd01.Row = 1;
                    this.grd01_Click(this.grd01, e);
                }

                this.grd03.Styles["Subtotal0"].BackColor = Color.Yellow;
                this.grd03.Styles["Subtotal0"].ForeColor = Color.Black;

                this.grd03.Styles["Subtotal1"].BackColor = Color.LightYellow;
                this.grd03.Styles["Subtotal1"].ForeColor = Color.Black;                              
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

        private void grd01_Click(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                if (row < 0)
                    return;

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PARTNO", this.grd01.GetValue(row, "PARTNO"));
                set.Add("PLANT", this.cbl01_Plant.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY_RACK_DETAIL(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_RACK_DETAIL"), set, "OUT_CURSOR");

                this.grd02.SetValue(source);
                this.AfterInvokeServer();
                this.grd02.Tree.Column = 1;

                //this.grd02.Subtotal(AggregateEnum.Count, 0, -1, 5, "전체 합계"); //@@@
                //this.grd02.Subtotal(AggregateEnum.Count, 1, 1, 5, "[{0}] 합계"); //@@@
                this.grd02.Subtotal(AggregateEnum.Count, 0, -1, 4, this.GetLabel("ALL_TOT")); //@@@
                this.grd02.Subtotal(AggregateEnum.Count, 1, 1, 4, "[{0}] " + this.GetLabel("TOTAL")); //@@@

                this.grd02.Styles["Subtotal0"].BackColor = Color.Yellow;
                this.grd02.Styles["Subtotal0"].ForeColor = Color.Black;

                this.grd02.Styles["Subtotal1"].BackColor = Color.LightYellow;
                this.grd02.Styles["Subtotal1"].ForeColor = Color.Black;
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
