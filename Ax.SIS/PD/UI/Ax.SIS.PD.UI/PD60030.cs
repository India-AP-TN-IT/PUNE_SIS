#region ▶ Description & History
/* 
 * 프로그램명 : PD60030 사출 수지 입-출고 이력 조회
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
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 사출 수지 입-출고 이력 조회
    /// </summary>
    public partial class PD60030 : AxCommonBaseControl
    {
        //private IPD60030 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD60030";

        #region [ 초기화 작업 정의 ]

        public PD60030()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();

            //_WSCOM = ClientFactory.CreateChannel<IPD60030>("PD", "PD60030.svc", "CustomBinding");
        }

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

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 170, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "위치", "WORK_POS", "POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Grade No", "GRADE_NO", "GRADE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "LOT NO", "GRADE_NO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "LOT 중량", "LOT_WT", "LOT_WT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "재고상태", "INV_STATUS", "INV_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "입고일자", "IN_DATE", "RCV_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "입고시간", "IN_TIME", "RCV_TIME1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "투입일자", "OUT_DATE", "INPUT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "투입시간", "OUT_TIME", "INPUT_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "투입탱크", "RES_TANK_NO", "DEIVERYTANK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "생성일자", "CREATE_DATE", "CREATEDATE");

                this.grd01.Cols["LOT_WT"].Format = "N1";

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "IN_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "OUT_DATE");

                this.grd01.Cols["CREATE_DATE"].Format = "yyyy-MM-dd HH:mm:ss";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "CREATE_DATE");

                for (int i = 0; i <= this.grd01.Cols["GRADE_NO"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                DataTable dtPlant = new DataTable();
                dtPlant.Columns.Add("CODE");
                dtPlant.Columns.Add("NAME");

                dtPlant.Rows.Add("P01", this.GetLabel("PLANT_P01"));//"생산4동"); 
                dtPlant.Rows.Add("P02", this.GetLabel("PLANT_P02"));//"PILOT"); 
                dtPlant.Rows.Add("P03", this.GetLabel("PLANT_P03"));//"생산2동"); 
                dtPlant.Rows.Add("P04", this.GetLabel("PLANT_P04"));//"두서공장"); 

                //this.cbl01_Plant.DataBind(dtPlant, "CODE", "NAME", "공장코드" + ";" + "공장명", "C;L"); 
                this.cbl01_Plant.DataBind(dtPlant, "CODE", "NAME", this.GetLabel("PLANTCD") + ";" + this.GetLabel("PLANTNM"), "C;L"); 
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

                int DIV = 0;

                if (this.rdo01_NOW_INV.Checked)
                    DIV = 0;
                else if (this.rdo01_RCV.Checked)
                    DIV = 1;
                else if (this.rdo01_DELIVERY.Checked)
                    DIV = 2;
                else if (this.rdo01_LOSS.Checked)
                    DIV = 3;
                else if (this.rdo01_TAGPRINT.Checked)
                    DIV = 4;

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("DIV", DIV);
                set.Add("SDATE", this.dtp01_IN_SDATE.GetDateText());
                set.Add("EDATE", this.dtp01_IN_EDATE.GetDateText());
                set.Add("WORK_POS", this.cbl01_Plant.GetValue());
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

        
        #region [ 기타 이벤트 정의 ]

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.grd01.AllowMerging = (this.chk01_GRID_MERGE.Checked == true) ?
                    C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                    C1.Win.C1FlexGrid.AllowMergingEnum.None;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                this.grd01.Tree.Column = 1;
                
                this.grd01.Styles["Subtotal0"].BackColor = Color.Khaki;
                this.grd01.Styles["Subtotal0"].ForeColor = Color.Black;

                // 그리드 - 합계 처리
                //this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 4, 7, "[{0}] 합계");
                this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 4, 7, "[{0}] "+GetLabel("TOTAL"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbo01_BIZCD.GetValue().ToString() == "5210")
            {
                lbl01_PLANT.Visible = true;
                cbl01_Plant.Visible = true;
            }
            else
            {
                lbl01_PLANT.Visible = false;
                cbl01_Plant.Visible = false;
                cbl01_Plant.SetValue("");
            }
        }

        #endregion
    }
}
