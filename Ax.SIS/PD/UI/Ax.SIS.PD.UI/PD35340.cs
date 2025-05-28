#region ▶ Description & History
/* 
 * 프로그램명 : PD35330 공수일지 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2015-09-24    오세민   
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using System.Drawing;

namespace Ax.SIS.PD.UI
{
    public partial class PD35340 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD35340";
        public PD35340()
        {
            InitializeComponent();
            //_WSCOM = new AxClientProxy("HANILDEV");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);


                this.dtp01_YYYY_MM.SetMMFromStart();
                //this.grd01.AllowEditing = false;
                //this.grd01.Initialize(1,1, false);
                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2,2);

                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "1", "P_01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "1", "W_01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "2", "P_02");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "2", "W_02");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "3", "P_03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "3", "W_03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "4", "P_04");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "4", "W_04");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "5", "P_05");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "5", "W_05");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "6", "P_06");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "6", "W_06");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "7", "P_07");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "7", "W_07");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "8", "P_08");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "8", "W_08");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "9", "P_09");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "9", "W_09");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "10", "P_10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "10", "W_10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "11", "P_11");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "11", "W_11");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "12", "P_12");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "12", "W_12");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "13", "P_13");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "13", "W_13");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "14", "P_14");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "14", "W_14");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "15", "P_15");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "15", "W_15");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "16", "P_16");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "16", "W_16");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "17", "P_17");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "17", "W_17");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "18", "P_18");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "18", "W_18");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "19", "P_19");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "19", "W_19");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "20", "P_20");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "20", "W_20");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "21", "P_21");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "21", "W_21");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "22", "P_22");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "22", "W_22");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "23", "P_23");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "23", "W_23");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "24", "P_24");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "24", "W_24");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "25", "P_25");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "25", "W_25");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "26", "P_26");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "26", "W_26");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "27", "P_27");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "27", "W_27");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "28", "P_28");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "28", "W_28");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "29", "P_29");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "29", "W_29");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "30", "P_30");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "30", "W_30");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "31", "P_31");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 055, "31", "W_31");

                this.grd01.AddMerge(0, 1, this.grd01.Cols["LINECD"].Index, this.grd01.Cols["LINECD"].Index);

                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_01"].Index, this.grd01.Cols["W_01"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_02"].Index, this.grd01.Cols["W_02"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_03"].Index, this.grd01.Cols["W_03"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_04"].Index, this.grd01.Cols["W_04"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_05"].Index, this.grd01.Cols["W_05"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_06"].Index, this.grd01.Cols["W_06"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_07"].Index, this.grd01.Cols["W_07"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_08"].Index, this.grd01.Cols["W_08"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_09"].Index, this.grd01.Cols["W_09"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_10"].Index, this.grd01.Cols["W_10"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_11"].Index, this.grd01.Cols["W_11"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_12"].Index, this.grd01.Cols["W_12"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_13"].Index, this.grd01.Cols["W_13"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_14"].Index, this.grd01.Cols["W_14"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_15"].Index, this.grd01.Cols["W_15"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_16"].Index, this.grd01.Cols["W_16"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_17"].Index, this.grd01.Cols["W_17"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_18"].Index, this.grd01.Cols["W_18"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_19"].Index, this.grd01.Cols["W_19"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_20"].Index, this.grd01.Cols["W_20"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_21"].Index, this.grd01.Cols["W_21"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_22"].Index, this.grd01.Cols["W_22"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_23"].Index, this.grd01.Cols["W_23"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_24"].Index, this.grd01.Cols["W_24"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_25"].Index, this.grd01.Cols["W_25"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_26"].Index, this.grd01.Cols["W_26"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_27"].Index, this.grd01.Cols["W_27"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_28"].Index, this.grd01.Cols["W_28"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_29"].Index, this.grd01.Cols["W_29"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_30"].Index, this.grd01.Cols["W_30"].Index);
                this.grd01.AddMerge(0, 0, this.grd01.Cols["P_31"].Index, this.grd01.Cols["W_31"].Index);

                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_01"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_02"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_03"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_04"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_05"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_06"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_07"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_08"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_09"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_10"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_11"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_12"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_13"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_14"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_15"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_16"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_17"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_18"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_19"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_20"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_21"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_22"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_23"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_24"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_25"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_26"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_27"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_28"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_29"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_30"].Index, this.GetLabel("PROD_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["P_31"].Index, this.GetLabel("PROD_RSLT"));

                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_01"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_02"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_03"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_04"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_05"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_06"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_07"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_08"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_09"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_10"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_11"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_12"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_13"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_14"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_15"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_16"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_17"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_18"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_19"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_20"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_21"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_22"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_23"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_24"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_25"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_26"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_27"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_28"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_29"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_30"].Index, this.GetLabel("MAN_HOUR_RSLT"));
                this.grd01.SetHeadTitle(1, this.grd01.Cols["W_31"].Index, this.GetLabel("MAN_HOUR_RSLT"));

                CellStyle csRed = this.grd01.Styles.Add("csRed");
                csRed.BackColor = Color.Red;

                //CellStyle csRed2 = this.grd01.Styles.Add("csRed2");
                //csRed2.ForeColor= Color.Red;
                //Font f = new Font(csRed2.Font, FontStyle.Bold);
                //csRed2.Font = f;

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_STD_YYYYMM);

                this.BtnReset_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]       

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            this.grd01.InitializeDataSource();

            //월별로 마지막 날짜 체크하여 그리드 컬럼 표시 여부 적용(28일자부터 31일자까지만 체크)
            string yyyymm = this.dtp01_YYYY_MM.GetDateText().Substring(0, 7);
            int last_day = Convert.ToDateTime(yyyymm + "-01").AddMonths(1).AddDays(-1).Day;
            for (int i = 28; i <= 31; i++)
            {
                if (i <= last_day)
                {
                    this.grd01.Cols["P_" + i.ToString()].Visible = true;
                    this.grd01.Cols["W_" + i.ToString()].Visible = true;
                }
                else
                {
                    this.grd01.Cols["P_" + i.ToString()].Visible = false;
                    this.grd01.Cols["W_" + i.ToString()].Visible = false;
                }
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());                
                paramSet.Add("YYYY_MM", this.dtp01_YYYY_MM.GetDateText().Substring(0, 7));
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(paramSet);                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                this.AfterInvokeServer();

                BtnReset_Click(null, null);


                this.grd01.SetValue(source.Tables[0]);

                this.SetGridColor();
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

        #region [ 유효성 검사 ]

        #endregion

        #region [ 기타 이벤트 정의 ]
        
    
        
        #endregion

        #region [ 사용자 정의 메서드 ] 
        
        private void SetGridColor()
        {
            for (int row = this.grd01.Rows.Fixed; row < this.grd01.Rows.Count; row++)
            {
                this.grd01.Rows[row].StyleNew.Clear();
                for (int i = 1; i <= 31; i++)
                {
                    string no = i.ToString().PadLeft(2, '0');
                    if (this.grd01.Cols["P_" + no].Visible)
                    {
                        string valP = this.grd01.GetValue(row, "P_" + no).ToString();
                        string valW = this.grd01.GetValue(row, "W_" + no).ToString();
                        if (valP != valW)
                        {
                            this.grd01.SetCellStyle(row, this.grd01.Cols["P_" + no].Index, "csRed");
                            this.grd01.SetCellStyle(row, this.grd01.Cols["W_" + no].Index, "csRed");
                        }

                    }
                }
            }

        }
        
        #endregion

    }
}
