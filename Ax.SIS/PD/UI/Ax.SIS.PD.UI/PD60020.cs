#region ▶ Description & History
/* 
 * 프로그램명 : PD60020 사출 수지별 현 재고 조회
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
    /// 사출 수지별 현 재고 조회
    /// </summary>
    public partial class PD60020 : AxCommonBaseControl
    {
        //private IPD60020 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD60020";

        #region [ 초기화 작업 정의 ]

        public PD60020()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD60020>("PD", "PD60020.svc", "CustomBinding");
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

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "탱크 재고(Kg)", "TANK_WT", "TANK_WT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 160, "적재소 재고(Kg)", "SHOP_WT", "SHOP_WT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "총 재고(Kg)", "TOTAL_WT", "TOTAL_STOCK");

                this.grd01.Cols["TANK_WT"].Format = "N1";
                this.grd01.Cols["SHOP_WT"].Format = "N1";
                this.grd01.Cols["TOTAL_WT"].Format = "N1";

                for (int i = 0; i <= this.grd01.Cols["TOTAL_WT"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                DataTable dtPlant = new DataTable();
                dtPlant.Columns.Add("CODE");
                dtPlant.Columns.Add("NAME");

                dtPlant.Rows.Add("P01", this.GetLabel("PLANT_P01")); //"생산4동"); 
                dtPlant.Rows.Add("P02", this.GetLabel("PLANT_P02")); //"PILOT");  
                dtPlant.Rows.Add("P03", this.GetLabel("PLANT_P03")); //"생산2동"); 
                dtPlant.Rows.Add("P04", this.GetLabel("PLANT_P04")); //"두서공장");

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
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
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
