#region ▶ Description & History
/* 
 * 프로그램명 : PD31340 고객사 시간대별 결 품 예상 현황
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 이현범
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜		      작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2016-06-01    이현범   
 *				2017-07~09    배명희     SIS 이관
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
using System.Drawing;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>고객사 과부족 현황 </b>
    /// </summary>
    public partial class PD31340 : AxCommonBaseControl
    {
        //private IPMCommon _WSCOM;
        private AxClientProxy _WSCOM;

        public PD31340()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPMCommon>("PM", "PMCommon.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        private void PD31340_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;
                this.axDockingTab1.LinkBody = this.panel2;
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
                this.grd01.Initialize(2,2);
                this.grd01.Font = new Font("맑은 고딕", 8);
                //this.grd01.Styles.Frozen.BackColor = Color.Transparent;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 050, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 040, "업무", "JOB_TYPE", "SYS_CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "전일\n실적", "PREVDAY_RSLT_QTY", "PREVDAY_RSLT_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "기초재고", "BAS_INV_QTY", "BAS_INV"); //당사/고객을 기초재고 하나로 통합

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "Day1", "D0D1Q", "D0D1Q");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "Day2", "D0D2Q", "D0D2Q");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "Night1", "D0N1Q", "D0N1Q");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "Night2", "D0N2Q", "D0N2Q");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "추가", "D0N3Q", "ADD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "계", "PLAN_QTY", "TOT2");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "07-12", "RSLT_QTY_07");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "12-16", "RSLT_QTY_12");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "16-21", "RSLT_QTY_16");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "21-07", "RSLT_QTY_21");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "계", "PROD_RSLT_QTY", "TOT2");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 040, "기초재고 + 실적", "TOT_QTY", "BAS_RSLT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 050, "TRIM\nIN\n수량", "ALC_CNT", "ALC_CNT_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "SEQ\nNO", "LSEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 040, "TRIM\nIN\n시간", "LAST_TIME", "LAST_TIME_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "재공", "WIP_QTY", "WIP_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "1", "DDAY1_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "2", "DDAY2_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "3", "DDAY3_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "4", "DDAY4_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "5", "DDAY5_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "6", "DDAY6_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "7", "DDAY7_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "8", "DDAY8_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "9", "DDAY9_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "10", "DDAY10_QTY");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "1", "D1DAY1_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "2", "D1DAY2_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "3", "D1DAY3_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "4", "D1DAY4_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "5", "D1DAY5_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "6", "D1DAY6_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "7", "D1DAY7_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "8", "D1DAY8_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "9", "D1DAY9_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "10", "D1DAY10_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "1", "D2DAY1_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "2", "D2DAY2_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "3", "D2DAY3_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "4", "D2DAY4_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "5", "D2DAY5_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "6", "D2DAY6_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "7", "D2DAY7_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "8", "D2DAY8_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "9", "D2DAY9_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "10", "D2DAY10_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "1", "D3DAY1_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "2", "D3DAY2_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "3", "D3DAY3_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "4", "D3DAY4_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "5", "D3DAY5_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "6", "D3DAY6_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "7", "D3DAY7_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 030, "8", "D3DAY8_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "9", "D3DAY9_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "10", "D3DAY10_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 030, "10", "DDAY_QTY");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "CTR PLN", "E0C2");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "LOW PNL", "E0C4");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "UPR PLN", "E0C7");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "UPR PLN(MODULE)", "E0CB");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PW S/W", "E0E1");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PKG SACHUL", "E0E5");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "A/REST", "E0F3");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "GARNISH", "E0F8");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "MAX_LSEQ", "MAX_LSEQ");
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "PARTNO_NOW", "PARTNO_NOW");

                /*
E0C2 	C2:CENTER PANEL(MODULE) 
E0C4	C4:LOWER PANEL
E0C7	C7:UPR PNL
E0CB	CB:UPR PLN(MODULE)
E0E1	E1:SWITCH-PW SW
E0E5	E5:PKG SACHUL
E0F3	F3:A/REST
E0F8 	F8:GARNISH 
                 */

                this.grd01.Cols["PREVDAY_RSLT_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["BAS_INV_QTY"].Format = "###,###,###,###,###";

                this.grd01.Cols["PROD_RSLT_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["WIP_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY1_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY2_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY3_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY4_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY5_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY6_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY7_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY8_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY9_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["DDAY10_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY1_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY2_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY3_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY4_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY5_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY6_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY7_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY8_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY9_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D1DAY10_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY1_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY2_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY3_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY4_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY5_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY6_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY7_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY8_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY9_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D2DAY10_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY1_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY2_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY3_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY4_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY5_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY6_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY7_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY8_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY9_QTY"].Format = "###,###,###,###,###";
                this.grd01.Cols["D3DAY10_QTY"].Format = "###,###,###,###,###";

                this.grd01.Cols["D0D1Q"].Format = "###,###,###,###,###";
                this.grd01.Cols["D0D2Q"].Format = "###,###,###,###,###";
                this.grd01.Cols["D0N1Q"].Format = "###,###,###,###,###";
                this.grd01.Cols["D0N2Q"].Format = "###,###,###,###,###";
                //this.grd01.Cols["D0N3Q"].Format = "###,###,###,###,###";
                this.grd01.Cols["PLAN_QTY"].Format = "###,###,###,###,###";

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PREVDAY_RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BAS_INV_QTY");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PROD_RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "WIP_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_QTY_07");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_QTY_12");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_QTY_16");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_QTY_21");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "ALC_CNT");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY1_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY2_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY3_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY4_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY5_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY6_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY7_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY8_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY9_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY10_QTY");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY1_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY2_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY3_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY4_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY5_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY6_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY7_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY8_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY9_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY10_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY1_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY2_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY3_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY4_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY5_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY6_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY7_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY8_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY9_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY10_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY1_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY2_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY3_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY4_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY5_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY6_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY7_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY8_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY9_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY10_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D0D1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D0D2Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D0N1Q");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D0N2Q");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D0N3Q");                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");                

                

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                
                this.grd01.AddMerge(0, 1, "VINCD", "VINCD");
                this.grd01.AddMerge(0, 1, "LINECD", "LINECD");
                this.grd01.AddMerge(0, 1, "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddMerge(0, 1, "ALCCD", "ALCCD");
                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "PREVDAY_RSLT_QTY", "PREVDAY_RSLT_QTY");
                this.grd01.AddMerge(0, 1, "BAS_INV_QTY", "BAS_INV_QTY");
                

                this.grd01.AddMerge(0, 1, "ALC_CNT", "ALC_CNT");
                this.grd01.AddMerge(0, 1, "LAST_TIME", "LAST_TIME");
                this.grd01.AddMerge(0, 1, "LSEQ", "LSEQ");

                
                

                this.grd01.AddMerge(0, 0, "RSLT_QTY_07", "PROD_RSLT_QTY");
                this.grd01.SetHeadTitle(0, 0, "RSLT_QTY_07", "PROD_RSLT_QTY", this.GetLabel("PROD_RSLT")); //생산실적

                this.grd01.AddMerge(0, 0, "D0D1Q", "PLAN_QTY");
                this.grd01.SetHeadTitle(0, 0, "D0D1Q", "PLAN_QTY", this.GetLabel("PROD_PLAN")); //생산계획

                this.grd01.AddMerge(0, 0, "WIP_QTY", "DDAY10_QTY");
                this.grd01.SetHeadTitle(0, 0, "WIP_QTY", "DDAY10_QTY", "D+DAY");
                //this.grd01.AddMerge(1, 1, "WIP_QTY", "DDAY10_QTY");
                //this.grd01.SetHeadTitle(1, 1, "WIP_QTY", "DDAY10_QTY", "고객사 당일 계획");

                this.grd01.AddMerge(0, 0, "D1DAY1_QTY", "D1DAY10_QTY");
                this.grd01.SetHeadTitle(0, 0, "D1DAY1_QTY", "D1DAY10_QTY", "D+1");
                //this.grd01.AddMerge(1, 1, "D1DAY1_QTY", "D1DAY10_QTY");
                //this.grd01.SetHeadTitle(1, 1, "D1DAY1_QTY", "D1DAY10_QTY", "고객사 당일 계획");

                this.grd01.AddMerge(0, 0, "D2DAY1_QTY", "D2DAY10_QTY");
                this.grd01.SetHeadTitle(0, 0, "D2DAY1_QTY", "D2DAY10_QTY", "D+2");
                //this.grd01.AddMerge(1, 1, "D2DAY1_QTY", "D2DAY10_QTY");
                //this.grd01.SetHeadTitle(1, 1, "D2DAY1_QTY", "D2DAY10_QTY", "고객사 당일 계획");

                this.grd01.AddMerge(0, 0, "D3DAY1_QTY", "D3DAY10_QTY");
                this.grd01.SetHeadTitle(0, 0, "D3DAY1_QTY", "D3DAY10_QTY", "D+3");
                //this.grd01.AddMerge(1, 1, "D3DAY1_QTY", "D3DAY10_QTY");
                //this.grd01.SetHeadTitle(1, 1, "D3DAY1_QTY", "D3DAY10_QTY", "고객사 당일 계획");

                //this.grd01.AddMerge(0, 1, "E0C2", "E0C2");
                //this.grd01.AddMerge(0, 1, "E0C4", "E0C4");
                //this.grd01.AddMerge(0, 1, "E0C7", "E0C7");
                //this.grd01.AddMerge(0, 1, "E0CB", "E0CB");
                //this.grd01.AddMerge(0, 1, "E0E1", "E0E1");
                //this.grd01.AddMerge(0, 1, "E0E5", "E0E5");
                //this.grd01.AddMerge(0, 1, "E0F3", "E0F3");
                //this.grd01.AddMerge(0, 1, "E0F8", "E0F8");

                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");

                grd01.Cols.Frozen = 6;

                CellStyle csSHORT = grd01.Styles.Add("SHORT");
                csSHORT.Font = new Font(this.Font, FontStyle.Bold);
                csSHORT.ForeColor = Color.OrangeRed;

                
                CellStyle csSHORT_ALC = grd01.Styles.Add("SHORT_ALC");
                csSHORT_ALC.Font = new Font(this.Font, FontStyle.Bold);
                csSHORT_ALC.ForeColor = Color.Blue;  
                //csSHORT_ALC.BackColor = Color.Transparent;

                CellStyle csNSHORT = grd01.Styles.Add("NSHORT");
                csNSHORT.BackColor = Color.LightGreen;

                CellStyle csLAST_SEQ = grd01.Styles.Add("LAST_SEQ");
                csLAST_SEQ.BackColor = Color.LightBlue;


                this.grd01.Cols["D0D1Q"].Visible = false;
                this.grd01.Cols["D0D2Q"].Visible = false;
                this.grd01.Cols["D0N1Q"].Visible = false;
                this.grd01.Cols["D0N2Q"].Visible = false;
                //this.grd01.Cols["D0N3Q"].Visible = false;
                this.grd01.Cols["PLAN_QTY"].Visible = false;

                this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, true, this.cdx01_VINCD);
                this.cdx01_VINCD.Recall_CreateCodeBoxControl();

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD")); // new PM20015P1();
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_PLAN_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                this.cdx01_LINECD.Recall_CreateCodeBoxControl();

                DataSet ds = this.GetDataSourceSchema("Code", "CodeValue");
                ds.Tables[0].Rows.Add("0", "D+0");
                ds.Tables[0].Rows.Add("1", "D+0 ~ D+1");
                this.cbo01_CRT_DATE.DataBind(ds.Tables[0], true, "ALL");

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_STD_DATE);
                
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
                //if (!IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("PLAN_DATE", this.dtp01_PLAN_DATE.GetDateText().ToString());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue().ToString());
                //paramSet.Add("CHK_DDAY", this.chk01_DDAY_SHORTAGE.Checked ? "Y":"N");
                paramSet.Add("CHK_DDAY", this.cbo01_CRT_DATE.GetValue()); 
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_PD31340.INQUERY", paramSet);
                this.grd01.SetValue(source.Tables[0]);
                ShowDataCount(source);

                this.grd01.Cols["D0D1Q"].Visible = this.chk01_PROD_PLAN.Checked;
                this.grd01.Cols["D0D2Q"].Visible = this.chk01_PROD_PLAN.Checked;
                this.grd01.Cols["D0N1Q"].Visible = this.chk01_PROD_PLAN.Checked;
                this.grd01.Cols["D0N2Q"].Visible = this.chk01_PROD_PLAN.Checked;
                //this.grd01.Cols["D0N3Q"].Visible = this.chk01_PROD_PLAN.Checked;
                this.grd01.Cols["PLAN_QTY"].Visible = this.chk01_PROD_PLAN.Checked;
             
                //this.grd01.Styles.Clear();
                CellStyle csSHORT_ALC = grd01.Styles["SHORT_ALC"];
  

                //CellStyle csPARTNO_NOW = grd01.Styles.Add("PARTNO_NOW");
                //csPARTNO_NOW.BackColor = Color.Tomato;
           
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    Int64 cust_qty = 0;
                    Int64 tot_qty = 0; //기초재고 + 생산실적 합계
                    Int64 tot_remain_qty = 0;
                    Int64 alc_cnt = 0;
                    
                    tot_qty = Convert.ToInt64(this.grd01.Rows[i]["TOT_QTY"].ToString());
                    tot_remain_qty = tot_qty;

                    alc_cnt = Convert.ToInt64(this.grd01.Rows[i]["ALC_CNT"].ToString());


                    this.grd01.Rows[i].StyleNew.Clear();

                    if((!this.grd01.Rows[i]["LSEQ"].ToString().Equals("")) && this.grd01.Rows[i]["LSEQ"].ToString() == this.grd01.Rows[i]["MAX_LSEQ"].ToString())
                    {
                        this.grd01.SetCellStyle(i, this.grd01.Cols["LSEQ"].Index, "LAST_SEQ"); //SEQ NO 컬럼 배경색 "연하늘"
                    }


                    //if ((!this.grd01.Rows[i]["PARTNO_NOW"].ToString().Equals("")) && this.grd01.Rows[i]["PARTNO_NOW"].ToString() == this.grd01.Rows[i]["PARTNO_NOW"].ToString())
                    //{
                    //    this.grd01.SetCellStyle(i, this.grd01.Cols["PARTNO"].Index, csPARTNO_NOW);
                    //}


                    for (int j = this.grd01.Cols.IndexOf("WIP_QTY"); j <= this.grd01.Cols.IndexOf("D3DAY10_QTY"); j++)
                    {
                        
                        cust_qty += Convert.ToInt64(this.grd01.Rows[i][j].ToString());
                        

                        if (tot_qty >= cust_qty)
                        {
                            //this.grd01.GetCellRange(i, j, i, this.grd01.Cols["E0C2"].Index - 1).StyleNew.BackColor = Color.LightGreen;                            
                            this.grd01.SetCellStyle(i, j, "NSHORT"); //배경색 : green
                            tot_remain_qty -= cust_qty;
                        }
                        if (tot_qty < cust_qty)
                        {
                            //cr = this.grd01.GetCellRange(i, j, i, this.grd01.Cols["E0C2"].Index - 1);
                            //cr.Style = this.grd01.Styles["SHORT"];
                            this.grd01.SetCellStyle(i, j, "SHORT"); //글자색 : 진한빨강

                        }
                        
                        if (alc_cnt >= cust_qty)
                        {
                            //cr = this.grd01.GetCellRange(i, j, i, this.grd01.Cols["E0C2"].Index - 1);
                            //cr.Style = this.grd01.Styles["SHORT_ALC"];
                            csSHORT_ALC.BackColor = this.grd01.GetCellStyle(i, j).BackColor; //글자색 : 진한파랑
                            this.grd01.SetCellStyle(i, j, csSHORT_ALC);
                        }
                    }
                }

                if (this.chk01_PD31340_OPTION1.Checked == true)
                {
                    this.grd01.Cols["D2DAY1_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY2_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY3_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY4_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY5_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY6_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY7_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY8_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY9_QTY"].Visible = true;
                    this.grd01.Cols["D2DAY10_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY1_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY2_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY3_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY4_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY5_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY6_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY7_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY8_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY9_QTY"].Visible = true;
                    this.grd01.Cols["D3DAY10_QTY"].Visible = true;
                }
                if (this.chk01_PD31340_OPTION1.Checked == false)
                {
                    this.grd01.Cols["D2DAY1_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY2_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY3_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY4_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY5_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY6_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY7_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY8_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY9_QTY"].Visible = false;
                    this.grd01.Cols["D2DAY10_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY1_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY2_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY3_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY4_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY5_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY6_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY7_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY8_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY9_QTY"].Visible = false;
                    this.grd01.Cols["D3DAY10_QTY"].Visible = false;

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

        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {
                //if (this.GetByteCount(this.cbo01_PRDT_DIV.GetValue().ToString()) == 0)
                //{
                //    //MsgBox.Show("제품구분을 입력하여 주십시오.");
                //    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("PRDT_TYPE"));
                //    return false;
                //}

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion



    }
}
