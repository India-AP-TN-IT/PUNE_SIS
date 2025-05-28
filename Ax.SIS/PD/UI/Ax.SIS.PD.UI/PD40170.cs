#region ▶ Description & History
/* 
 * 프로그램명 : PD40170 생산계획 대 실적 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 진승모
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜		      작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-01-29    진승모     기준 시간 변경(08 -> 07)
 *				2014-07-23    배명희     cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *				                         cdx01_ITEMCD 연결 팝업 변경 (CM20011P2 -> CM30010P1)
 *				2014-10-07    진승모     다국어 적용
 *				2017-07~09    배명희     SIS 이관
*/
#endregion

using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>생산계획 대 실적 조회</b>
    /// </summary>
    public partial class PD40170 : AxCommonBaseControl
    {
        //private IPMCommon _WSCOM;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD40170";
        public PD40170()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPMCommon>("PM", "PMCommon.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
        }

        #region [ 초기화 작업 정의 ]

        private void PD40170_Load(object sender, EventArgs e)
        {
            try
            {
                this.AxDockingTab1.LinkPanel = this.panel1;
                this.AxDockingTab1.LinkBody = this.panel2;
                base.ShowMessage("Ver. : 2019-08-21_ 001");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2, false);
                this.grd01.Font = new Font("맑은 고딕", 8);
                this.grd01.Styles.Frozen.BackColor = Color.Transparent;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "업\n\r무", "JOB_TYPE", "JOB_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "ALC", "ALCCD", "ALCCD");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "ALC2", "ALCCD2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "품목", "ITEMCD", "ITEMCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "전일실적", "PREVDAY_RSLT_QTY", "PREVDAY_RSLT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "기초\n\r재고", "BAS_INV_QTY", "BAS_INV_LINE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "고객사\n\r재고", "SAL_INV_QTY", "SAL_INV_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "고객사\n\r계획", "CUST_DDAY_QTY", "CUST_DDAY_QTY_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "과부족", "DIF_QTY", "EXC_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "주1", "D0D1Q", "PD40170_D0D1Q");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "주2", "D0D2Q", "PD40170_D0D2Q");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "야1", "D0N1Q", "PD40170_D0N1Q");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "야2", "D0N2Q", "PD40170_D0N2Q");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "추가", "D0N3Q", "ADD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "계획합", "PLAN_QTY", "PLAN_SUM"); //, "PLAN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "실적합", "SUM_QTY", "RSLT_SUM"); //, "SUM_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "최종\n\r과부족", "LACK_QTY", "FINAL_LACK_QTY"); //, "PM31511LACK_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "조정\n\r수량", "CHNG_QTY", "CHNG_QTY_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "달성율\n\r(%)", "RATE", "RATE_LINE"); //, "ACHI_RATION");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "주간\n\r실적", "RSLT_QTY_D", "RSLT_QTY_D"); //, "RSLT_QTY_D");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "야간\n\r실적", "RSLT_QTY_N", "RSLT_QTY_N"); //, "RSLT_QTY_N");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "T/IN\n\r수량", "ALC_CNT", "TIN_QTY_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "T/IN\n\r과부족", "ALC_CNT_LACK", "TIN_LACKQTY_LINE");
                
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "07", "RSLT_QTY_07");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "08", "RSLT_QTY_08");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "09", "RSLT_QTY_09");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "10", "RSLT_QTY_10");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "11", "RSLT_QTY_11");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "12", "RSLT_QTY_12");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "13", "RSLT_QTY_13");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "14", "RSLT_QTY_14");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "15", "RSLT_QTY_15");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "16", "RSLT_QTY_16");

                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "16_1", "RSLT_QTY_16_1");
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "16_2", "RSLT_QTY_16_2");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "17", "RSLT_QTY_17");
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "18", "RSLT_QTY_18");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "18_1", "RSLT_QTY_18_1");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "18_2", "RSLT_QTY_18_2");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "19", "RSLT_QTY_19");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "20", "RSLT_QTY_20");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "21", "RSLT_QTY_21");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "22", "RSLT_QTY_22");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "23", "RSLT_QTY_23");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "00", "RSLT_QTY_24");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "01", "RSLT_QTY_01");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "02", "RSLT_QTY_02");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "03", "RSLT_QTY_03");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "04", "RSLT_QTY_04");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "05", "RSLT_QTY_05");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "06", "RSLT_QTY_06");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "주1", "D1D1Q", "PD40170_D0D1Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "주2", "D1D2Q", "PD40170_D0D2Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "야1", "D1N1Q", "PD40170_D0N1Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "야2", "D1N2Q", "PD40170_D0N2Q");
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "추가", "D1N3Q", "ADD");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "주1", "D2D1Q", "PD40170_D0D1Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "주2", "D2D2Q", "PD40170_D0D2Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "야1", "D2N1Q", "PD40170_D0N1Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "야2", "D2N2Q", "PD40170_D0N2Q");
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "추가", "D2N3Q", "ADD");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "주1", "D3D1Q", "PD40170_D0D1Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "주2", "D3D2Q", "PD40170_D0D2Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "야1", "D3N1Q", "PD40170_D0N1Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "야2", "D3N2Q", "PD40170_D0N2Q");
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "추가", "D3N3Q", "ADD");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "주1", "D4D1Q", "PD40170_D0D1Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "주2", "D4D2Q", "PD40170_D0D2Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "야1", "D4N1Q", "PD40170_D0N1Q");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "야2", "D4N2Q", "PD40170_D0N2Q");
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "추가", "D4N3Q", "ADD");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D1", "CUST_D1DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D2", "CUST_D2DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D3", "CUST_D3DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D4", "CUST_D4DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D5", "CUST_D5DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D6", "CUST_D6DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D7", "CUST_D7DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D8", "CUST_D8DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D9", "CUST_D9DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D10", "CUST_D10DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D11", "CUST_D11DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "D12", "CUST_D12DAY_QTY");


                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "LACK_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PREVDAY_RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "BAS_INV_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SAL_INV_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_DDAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D0D1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D0D2Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D0N1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D0N2Q");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D0N3Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PLAN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SUM_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CHNG_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RATE");
                this.grd01.Cols["RATE"].Format = "###,###.##";
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "ALC_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "ALC_CNT_LACK");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_D");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_N");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_07");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_08");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_09");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_10");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_11");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_12");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_13");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_14");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_15");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_16");

                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_16_1");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_16_2");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_17");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_18");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_18_1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_18_2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_19");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_20");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_21");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_22");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_23");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_24");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_01");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_02");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_03");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_04");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_05");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY_06");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D1D1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D1D2Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D1N1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D1N2Q");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D1N3Q");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D2D1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D2D2Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D2N1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D2N2Q");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D2N3Q");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D3D1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D3D2Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D3N1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D3N2Q");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D3N3Q");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D4D1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D4D2Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D4N1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D4N2Q");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "D4N3Q");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D1DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D2DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D3DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D4DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D5DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D6DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D7DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D8DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D9DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D10DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D11DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "CUST_D12DAY_QTY");

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "ALCCD", "ALCCD");
                //this.grd01.AddMerge(0, 1, "ALCCD2", "ALCCD2");
                this.grd01.AddMerge(0, 1, "VINCD", "VINCD");
                this.grd01.AddMerge(0, 1, "LINECD", "LINECD");
                this.grd01.AddMerge(0, 1, "ITEMCD", "ITEMCD");
                this.grd01.AddMerge(0, 1, "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddMerge(0, 1, "PREVDAY_RSLT_QTY", "PREVDAY_RSLT_QTY");
                this.grd01.AddMerge(0, 1, "BAS_INV_QTY", "BAS_INV_QTY");
                this.grd01.AddMerge(0, 1, "SAL_INV_QTY", "SAL_INV_QTY");
                this.grd01.AddMerge(0, 1, "CUST_DDAY_QTY", "CUST_DDAY_QTY");
                this.grd01.AddMerge(0, 1, "DIF_QTY", "DIF_QTY");
                this.grd01.AddMerge(0, 1, "PLAN_QTY", "PLAN_QTY");
                this.grd01.AddMerge(0, 1, "SUM_QTY", "SUM_QTY");
                this.grd01.AddMerge(0, 1, "LACK_QTY", "LACK_QTY");
                this.grd01.AddMerge(0, 1, "CHNG_QTY", "CHNG_QTY");
                this.grd01.AddMerge(0, 1, "RATE", "RATE");
                this.grd01.AddMerge(0, 1, "RSLT_QTY_D", "RSLT_QTY_D");
                this.grd01.AddMerge(0, 1, "RSLT_QTY_N", "RSLT_QTY_N");
                
                this.grd01.AddMerge(0, 1, "ALC_CNT", "ALC_CNT");
                this.grd01.AddMerge(0, 1, "ALC_CNT_LACK", "ALC_CNT_LACK");

                this.grd01.AddMerge(0, 0, "D0D1Q", "D0N2Q");
                this.grd01.SetHeadTitle(0, "D0D1Q", "D" + this.GetLabel("PLAN"));
                this.grd01.AddMerge(0, 0, "RSLT_QTY_07", "RSLT_QTY_06");
                this.grd01.SetHeadTitle(0, "RSLT_QTY_07", this.GetLabel("RSLT"));
                this.grd01.AddMerge(0, 0, "D1D1Q", "D1N2Q");
                this.grd01.SetHeadTitle(0, "D1D1Q", "D1" + this.GetLabel("PLAN"));
                this.grd01.AddMerge(0, 0, "D2D1Q", "D2N2Q");
                this.grd01.SetHeadTitle(0, "D2D1Q", "D2" + this.GetLabel("PLAN"));
                this.grd01.AddMerge(0, 0, "D3D1Q", "D3N2Q");
                this.grd01.SetHeadTitle(0, "D3D1Q", "D3" + this.GetLabel("PLAN"));
                this.grd01.AddMerge(0, 0, "D4D1Q", "D4N2Q");
                this.grd01.SetHeadTitle(0, "D4D1Q", "D4" + this.GetLabel("PLAN"));
                this.grd01.AddMerge(0, 0, "CUST_D1DAY_QTY", "CUST_D12DAY_QTY");
                this.grd01.SetHeadTitle(0, "CUST_D1DAY_QTY", this.GetLabel("CUST_PLAN"));

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A1", "JOB_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A4", "ITEMCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");                

                grd01.Cols.Frozen = 6;

                //CellStyle csALCCD2 = grd01.Styles.Add("ALCCD2");
                //csALCCD2.BackColor = Color.Red;

                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);
                this.cdx01_VINCD.Recall_CreateCodeBoxControl();

                //this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3");
                //this.cdx01_VINCD.CodeParameterName = "CODE";
                //this.cdx01_VINCD.NameParameterName = "CODENAME";
                //this.cdx01_VINCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_VINCD.HEUserParameterSetValue("CLASS_ID", "A3");
                //this.cdx01_VINCD.SetCodePixedLength();
                //this.cdx01_VINCD.PrefixCode = "A3";
                //this.cdx01_VINCD.HEPopupHelper = new CM20011P1(); //new PM20011P1();
                //this.cdx01_VINCD.PopupTitle = "차종코드";
                //this.cdx01_VINCD.CodeParameterName = "VINCD";
                //this.cdx01_VINCD.NameParameterName = "VINCDNM";
                //this.cdx01_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                //this.cdx01_VINCD.SetCodePixedLength();
                //this.cdx01_VINCD.PrefixCode = "A3";

                this.cdx01_ITEMCD.HEPopupHelper = new CM30010P1("A4", true, true, this.cdx01_ITEMCD);
                this.cdx01_ITEMCD.Recall_CreateCodeBoxControl();

                //this.cdx01_ITEMCD.HEPopupHelper = new CM30010P1("A4");
                //this.cdx01_ITEMCD.CodeParameterName = "CODE";
                //this.cdx01_ITEMCD.NameParameterName = "CODENAME";
                //this.cdx01_ITEMCD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_ITEMCD.HEUserParameterSetValue("CLASS_ID", "A4");
                //this.cdx01_ITEMCD.SetCodePixedLength();
                //this.cdx01_ITEMCD.PrefixCode = "A4";
                //this.cdx01_ITEMCD.HEPopupHelper = new CM20011P2(); //new PM20011P2();
                //this.cdx01_ITEMCD.PopupTitle = "품목코드";
                //this.cdx01_ITEMCD.CodeParameterName = "ITEMCD";
                //this.cdx01_ITEMCD.NameParameterName = "ITEMNM";
                //this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                //this.cdx01_ITEMCD.SetCodePixedLength();
                //this.cdx01_ITEMCD.PrefixCode = "A4";

                cbo01_PRDT_DIV.DataBind("A0",true);
                this.cbo01_PRDT_DIV.SelectedIndex = 1;
                this.cbo01_INSTALL_POS.DataBind("A7");
                CellStyle csLACK = grd01.Styles.Add("LACK_QTY");
                csLACK.BackColor = Color.OrangeRed;

                this.SetRequired(this.lbl01_BIZNM, this.lbl01_PRDT_DIV, this.lbl01_STD_DATE);

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
                if (!IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("PLAN_DATE", this.dtp01_BEG_DATE.GetDateText().ToString());
                paramSet.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue().ToString());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue().ToString());
                paramSet.Add("ITEMCD", this.cdx01_ITEMCD.GetValue().ToString());
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"),paramSet);
                this.grd01.SetValue(source.Tables[0]);
                ShowDataCount(source);

                DateTime dt;
                string sColTitle = "";
                foreach (Column col in grd01.Rows[0].Grid.Cols)
                {
                    dt = Convert.ToDateTime(this.dtp01_BEG_DATE.GetValue().ToString());
                    switch (col.Name.ToString())
                    {
                        case "D0D1Q":
                        case "D0D2Q":
                        case "D0N1Q":
                        case "D0N2Q":
                            //this.grd01.Rows[0][col.Index] = dt.ToShortDateString() + " 당사계획";
                            this.grd01.Rows[0][col.Index] = dt.ToShortDateString() + " " + this.GetLabel("HANIL_PLAN");
                            break;

                        case "D1D1Q":
                        case "D1D2Q":
                        case "D1N1Q":
                        case "D1N2Q":
                            this.grd01.Rows[0][col.Index] = dt.AddDays(1).ToShortDateString() + " " + this.GetLabel("HANIL_PLAN");;
                            break;

                        case "D2D1Q":
                        case "D2D2Q":
                        case "D2N1Q":
                        case "D2N2Q":
                            this.grd01.Rows[0][col.Index] = dt.AddDays(2).ToShortDateString() + " " + this.GetLabel("HANIL_PLAN");;
                            break;

                        case "D3D1Q":
                        case "D3D2Q":
                        case "D3N1Q":
                        case "D3N2Q":
                            this.grd01.Rows[0][col.Index] = dt.AddDays(3).ToShortDateString() + " " + this.GetLabel("HANIL_PLAN");;
                            break;

                        case "D4D1Q":
                        case "D4D2Q":
                        case "D4N1Q":
                        case "D4N2Q":
                            this.grd01.Rows[0][col.Index] = dt.AddDays(4).ToShortDateString() + " " + this.GetLabel("HANIL_PLAN");;
                            break;

                        case "CUST_D1DAY_QTY":
                            //sColTitle = dt.AddDays(1).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(1).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(1).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D2DAY_QTY":
                            //sColTitle = dt.AddDays(2).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(2).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(2).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D3DAY_QTY":
                            //sColTitle = dt.AddDays(3).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(3).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(3).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D4DAY_QTY":
                            //sColTitle = dt.AddDays(4).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(4).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(4).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D5DAY_QTY":
                            //sColTitle = dt.AddDays(5).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(5).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(5).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle; ;
                            break;

                        case "CUST_D6DAY_QTY":
                            //sColTitle = dt.AddDays(6).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(6).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(6).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D7DAY_QTY":
                            //sColTitle = dt.AddDays(7).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(7).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(7).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D8DAY_QTY":
                            //sColTitle = dt.AddDays(8).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(8).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(8).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D9DAY_QTY":
                            //sColTitle = dt.AddDays(9).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(9).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(9).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D10DAY_QTY":
                            //sColTitle = dt.AddDays(10).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(10).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(10).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D11DAY_QTY":
                            //sColTitle = dt.AddDays(11).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(11).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(11).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;

                        case "CUST_D12DAY_QTY":
                            //sColTitle = dt.AddDays(12).ToShortDateString().Substring(5, 5);
                            sColTitle = dt.AddDays(12).Month.ToString().PadLeft(2, '0') + "-" + dt.AddDays(12).Day.ToString().PadLeft(2, '0');
                            this.grd01.Rows[1][col.Index] = sColTitle;
                            break;
                    }

                }

                if (this.chk01_OPTION1_PD40170.Checked == true)
                {
                    this.grd01.Cols["RSLT_QTY_07"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_08"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_09"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_10"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_11"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_12"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_13"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_14"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_15"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_16"].Visible = true;
                    //this.grd01.Cols["RSLT_QTY_16_1"].Visible = true;
                    //this.grd01.Cols["RSLT_QTY_16_2"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_17"].Visible = true;
                    //this.grd01.Cols["RSLT_QTY_18"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_18_1"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_18_2"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_19"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_20"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_21"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_22"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_23"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_24"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_01"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_02"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_03"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_04"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_05"].Visible = true;
                    this.grd01.Cols["RSLT_QTY_06"].Visible = true;
                    
                }
                if (this.chk01_OPTION1_PD40170.Checked == false)
                {
                    this.grd01.Cols["RSLT_QTY_07"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_08"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_09"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_10"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_11"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_12"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_13"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_14"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_15"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_16"].Visible = false;
                    //this.grd01.Cols["RSLT_QTY_16_1"].Visible = false;
                    //this.grd01.Cols["RSLT_QTY_16_2"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_17"].Visible = false;
                    //this.grd01.Cols["RSLT_QTY_18"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_18_1"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_18_2"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_19"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_20"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_21"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_22"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_23"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_24"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_01"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_02"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_03"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_04"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_05"].Visible = false;
                    this.grd01.Cols["RSLT_QTY_06"].Visible = false;
                    
                }

                if (this.chk01_OPTION2_PD40170.Checked == true)
                {
                    this.grd01.Cols["D1D1Q"].Visible = true;
                    //this.grd01.Cols["D1D2Q"].Visible = true;
                    this.grd01.Cols["D1N1Q"].Visible = true;
                    this.grd01.Cols["D1N2Q"].Visible = true;
                    this.grd01.Cols["D2D1Q"].Visible = true;
                    //this.grd01.Cols["D2D2Q"].Visible = true;
                    this.grd01.Cols["D2N1Q"].Visible = true;
                    this.grd01.Cols["D2N2Q"].Visible = true;
                    this.grd01.Cols["D3D1Q"].Visible = true;
                    //this.grd01.Cols["D3D2Q"].Visible = true;
                    this.grd01.Cols["D3N1Q"].Visible = true;
                    this.grd01.Cols["D3N2Q"].Visible = true;
                    this.grd01.Cols["D4D1Q"].Visible = true;
                    //this.grd01.Cols["D4D2Q"].Visible = true;
                    this.grd01.Cols["D4N1Q"].Visible = true;
                    this.grd01.Cols["D4N2Q"].Visible = true;
                }
                if (this.chk01_OPTION2_PD40170.Checked == false)
                {
                    this.grd01.Cols["D1D1Q"].Visible = false;
                    //this.grd01.Cols["D1D2Q"].Visible = false;
                    this.grd01.Cols["D1N1Q"].Visible = false;
                    this.grd01.Cols["D1N2Q"].Visible = false;
                    this.grd01.Cols["D2D1Q"].Visible = false;
                    //this.grd01.Cols["D2D2Q"].Visible = false;
                    this.grd01.Cols["D2N1Q"].Visible = false;
                    this.grd01.Cols["D2N2Q"].Visible = false;
                    this.grd01.Cols["D3D1Q"].Visible = false;
                    //this.grd01.Cols["D3D2Q"].Visible = false;
                    this.grd01.Cols["D3N1Q"].Visible = false;
                    this.grd01.Cols["D3N2Q"].Visible = false;
                    this.grd01.Cols["D4D1Q"].Visible = false;
                    //this.grd01.Cols["D4D2Q"].Visible = false;
                    this.grd01.Cols["D4N1Q"].Visible = false;
                    this.grd01.Cols["D4N2Q"].Visible = false;
                }

                if (source.Tables[0].Rows.Count > 0)
                {
                    this.grd01.setAlternateRowStyle("ALCCD");
                    this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Clear);
                    for (int i = 7; i < this.grd01.Cols.Count; i++)
                    {
                        if (!this.grd01.Cols[i].Name.Equals("RATE"))
                        {
                            this.grd01.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, -1, i, "");
                        }
                    }

                    this.grd01.Rows[2][0] = this.grd01.Rows[2]["RATE"] = "";
                    CellStyle cs1 = this.grd01.Styles.Add("Sum");
                    cs1.BackColor = Color.FromArgb(208, 253, 248);
                    cs1.ForeColor = Color.FromArgb(0, 0, 0);
                    CellRange cr = grd01.GetCellRange(2, 1, 2, this.grd01.Cols.Count - this.grd01.Cols.Fixed);
                    cr.Style = this.grd01.Styles["Sum"];

                    grd01.Rows.Frozen = 1;

                    //for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    //{
                    //    if (grd01.GetValue(i, "ALCCD2").ToString().Length != 0)
                    //    {
                    //        for (int j = 1; j < grd01.Cols.Count; j++)
                    //            grd01.SetCellStyle(i, j, grd01.Styles["ALCCD2"]);
                    //    }
                    //}


                    int idx = this.grd01.Cols["LACK_QTY"].Index;              
                    for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(grd01.GetValue(i, "LACK_QTY").ToString()) < 0 )
                        {
                            grd01.SetCellStyle(i, idx, grd01.Styles["LACK_QTY"]);
                        }
                        if (Convert.ToInt32(grd01.GetValue(i, "ALC_CNT_LACK").ToString()) < 0)
                        {
                            grd01.SetCellStyle(i, this.grd01.Cols["ALC_CNT_LACK"].Index, grd01.Styles["LACK_QTY"]);
                        }
                    }

                }
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]
        
        private void cbo01_PRDT_DIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cdx01_LINECD.Initialize();

                if (this.cbo01_PRDT_DIV.GetValue().ToString() == "A0A")
                {
                    Get_LineCD("A0A");
                }

                if (this.cbo01_PRDT_DIV.GetValue().ToString() == "A0S")
                {
                    Get_LineCD("A0S");
                }

                if (this.cbo01_PRDT_DIV.GetValue().ToString() == "A0M")
                {
                    Get_LineCD("A0M");
                }

                if (this.cbo01_PRDT_DIV.GetValue().ToString() == "")
                {
                    Get_LineCD("");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {
                if (this.GetByteCount(this.cbo01_PRDT_DIV.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("제품구분을 입력하여 주십시오.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("PRDT_DIV"));
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion
        
        #region [ 사용자 정의 메서드 ]

        private void Get_LineCD(string Line_Div)
        {
            try
            {
                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("REP_LINECD"));
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", Line_Div);
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "");
                this.cdx01_LINECD.SetCodePixedLength();
                this.cdx01_LINECD.Recall_CreateCodeBoxControl();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion
    }
}
