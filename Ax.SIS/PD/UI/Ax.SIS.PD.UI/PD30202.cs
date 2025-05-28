using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.Drawing;
using HE.Framework.ServiceModel;
using System.Data.OleDb;
using System.Text;
using System.Collections.Generic;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>실사 생산 실적 관리</b>
    /// </summary>
    public partial class PD30202 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD30202";
        List<string> m_Cols = new List<string>();

        public PD30202()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();	
        }

        #region [ 초기화 작업 정의 ]
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.dte01_PLAN_DATE.SetMMFromStart();

                #region [grd01]
                this.grd01.Initialize();
                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2);

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "CAR"      , "VINCD"     , "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PGN"      , "PGN"       , "PGN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PAC"      , "PAC"       , "PAC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO"  , "PARTNO"    , "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "PART NAME", "PARTNM"    , "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#01", "OPT01_DESC", "OPT01_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#02", "OPT02_DESC", "OPT02_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#03", "OPT03_DESC", "OPT03_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#04", "OPT04_DESC", "OPT04_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#05", "OPT05_DESC", "OPT05_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#06", "OPT06_DESC", "OPT06_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#07", "OPT07_DESC", "OPT07_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#08", "OPT08_DESC", "OPT08_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#09", "OPT09_DESC", "OPT09_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#10", "OPT10_DESC", "OPT10_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#11", "OPT11_DESC", "OPT11_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#12", "OPT12_DESC", "OPT12_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#13", "OPT13_DESC", "OPT13_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#14", "OPT14_DESC", "OPT14_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#15", "OPT15_DESC", "OPT15_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#16", "OPT16_DESC", "OPT16_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#17", "OPT17_DESC", "OPT17_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#18", "OPT18_DESC", "OPT18_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#19", "OPT19_DESC", "OPT19_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#20", "OPT20_DESC", "OPT20_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#21", "OPT21_DESC", "OPT21_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#22", "OPT22_DESC", "OPT22_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#23", "OPT23_DESC", "OPT23_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#24", "OPT24_DESC", "OPT24_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#25", "OPT25_DESC", "OPT25_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#26", "OPT26_DESC", "OPT26_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#27", "OPT27_DESC", "OPT27_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#28", "OPT28_DESC", "OPT28_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#29", "OPT29_DESC", "OPT29_DESC");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#30", "OPT30_DESC", "OPT30_DESC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D0", "DDAY_QTY", "DDAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D1", "D1DAY_QTY", "D1DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D2", "D2DAY_QTY", "D2DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D3", "D3DAY_QTY", "D3DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D4", "D4DAY_QTY", "D4DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D5", "D5DAY_QTY", "D5DAY_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D6", "D6DAY_QTY", "D6DAY_QTY");

                this.grd01.Cols["DDAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["D1DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["D2DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["D3DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["D4DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["D5DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["D6DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D4DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D5DAY_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D6DAY_QTY");

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "VINCD", "VINCD");
                this.grd01.AddMerge(0, 1, "PGN", "PGN");
                this.grd01.AddMerge(0, 1, "PAC", "PAC");
                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd01.AddMerge(0, 1, "OPT01_DESC", "OPT01_DESC");
                this.grd01.AddMerge(0, 1, "OPT02_DESC", "OPT02_DESC");
                this.grd01.AddMerge(0, 1, "OPT03_DESC", "OPT03_DESC");
                this.grd01.AddMerge(0, 1, "OPT04_DESC", "OPT04_DESC");
                this.grd01.AddMerge(0, 1, "OPT05_DESC", "OPT05_DESC");
                this.grd01.AddMerge(0, 1, "OPT06_DESC", "OPT06_DESC");
                this.grd01.AddMerge(0, 1, "OPT07_DESC", "OPT07_DESC");
                this.grd01.AddMerge(0, 1, "OPT08_DESC", "OPT08_DESC");
                this.grd01.AddMerge(0, 1, "OPT09_DESC", "OPT09_DESC");
                this.grd01.AddMerge(0, 1, "OPT10_DESC", "OPT10_DESC");
                this.grd01.AddMerge(0, 1, "OPT11_DESC", "OPT11_DESC");
                this.grd01.AddMerge(0, 1, "OPT12_DESC", "OPT12_DESC");
                this.grd01.AddMerge(0, 1, "OPT13_DESC", "OPT13_DESC");
                this.grd01.AddMerge(0, 1, "OPT14_DESC", "OPT14_DESC");
                this.grd01.AddMerge(0, 1, "OPT15_DESC", "OPT15_DESC");
                this.grd01.AddMerge(0, 1, "OPT16_DESC", "OPT16_DESC");
                this.grd01.AddMerge(0, 1, "OPT17_DESC", "OPT17_DESC");
                this.grd01.AddMerge(0, 1, "OPT18_DESC", "OPT18_DESC");
                this.grd01.AddMerge(0, 1, "OPT19_DESC", "OPT19_DESC");
                this.grd01.AddMerge(0, 1, "OPT20_DESC", "OPT20_DESC");
                //this.grd01.AddMerge(0, 1, "OPT21_DESC", "OPT21_DESC");
                //this.grd01.AddMerge(0, 1, "OPT22_DESC", "OPT22_DESC");
                //this.grd01.AddMerge(0, 1, "OPT23_DESC", "OPT23_DESC");
                //this.grd01.AddMerge(0, 1, "OPT24_DESC", "OPT24_DESC");
                //this.grd01.AddMerge(0, 1, "OPT25_DESC", "OPT25_DESC");
                //this.grd01.AddMerge(0, 1, "OPT26_DESC", "OPT26_DESC");
                //this.grd01.AddMerge(0, 1, "OPT27_DESC", "OPT27_DESC");
                //this.grd01.AddMerge(0, 1, "OPT28_DESC", "OPT28_DESC");
                //this.grd01.AddMerge(0, 1, "OPT29_DESC", "OPT29_DESC");
                //this.grd01.AddMerge(0, 1, "OPT30_DESC", "OPT30_DESC");

                this.grd01.AddMerge(0, 0, "DDAY_QTY", "D6DAY_QTY");
                //Changed KMI to KIN
                this.grd01.SetHeadTitle(0, "DDAY_QTY", "KIN PLAN (" + this.dte01_PLAN_DATE.GetDateText() + ")");
                #endregion

                #region [grd02]
                this.grd02.Initialize();
                this.grd02.AllowEditing = false;
                this.grd02.Initialize(2, 2);

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "CAR", "VINCD", "VINCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PGN", "PGN", "PGN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PAC", "PAC", "PAC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "PART NAME", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#01", "OPT01_DESC", "OPT01_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#02", "OPT02_DESC", "OPT02_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#03", "OPT03_DESC", "OPT03_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#04", "OPT04_DESC", "OPT04_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#05", "OPT05_DESC", "OPT05_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#06", "OPT06_DESC", "OPT06_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#07", "OPT07_DESC", "OPT07_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#08", "OPT08_DESC", "OPT08_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#09", "OPT09_DESC", "OPT09_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#10", "OPT10_DESC", "OPT10_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#11", "OPT11_DESC", "OPT11_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#12", "OPT12_DESC", "OPT12_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#13", "OPT13_DESC", "OPT13_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#14", "OPT14_DESC", "OPT14_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#15", "OPT15_DESC", "OPT15_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#16", "OPT16_DESC", "OPT16_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#17", "OPT17_DESC", "OPT17_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#18", "OPT18_DESC", "OPT18_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#19", "OPT19_DESC", "OPT19_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#20", "OPT20_DESC", "OPT20_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#21", "OPT21_DESC", "OPT21_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#22", "OPT22_DESC", "OPT22_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#23", "OPT23_DESC", "OPT23_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#24", "OPT24_DESC", "OPT24_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#25", "OPT25_DESC", "OPT25_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#26", "OPT26_DESC", "OPT26_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#27", "OPT27_DESC", "OPT27_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#28", "OPT28_DESC", "OPT28_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#29", "OPT29_DESC", "OPT29_DESC");
                //this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "OPTION#30", "OPT30_DESC", "OPT30_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D0", "DDAY_QTY", "DDAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D1", "D1DAY_QTY", "D1DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D2", "D2DAY_QTY", "D2DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D3", "D3DAY_QTY", "D3DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D4", "D4DAY_QTY", "D4DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D5", "D5DAY_QTY", "D5DAY_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "D6", "D6DAY_QTY", "D6DAY_QTY");


                this.grd02.Cols["DDAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols["D1DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols["D2DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols["D3DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols["D4DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols["D5DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols["D6DAY_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "DDAY_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D1DAY_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D2DAY_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D3DAY_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D4DAY_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D5DAY_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D6DAY_QTY");

                for (int i = 0; i < grd02.Cols.Count; i++)
                    this.grd02[1, i] = this.grd02.Cols[i].Caption;

                this.grd02.AddMerge(0, 1, "VINCD", "VINCD");
                this.grd02.AddMerge(0, 1, "PGN", "PGN");
                this.grd02.AddMerge(0, 1, "PAC", "PAC");
                this.grd02.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd02.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd02.AddMerge(0, 1, "OPT01_DESC", "OPT01_DESC");
                this.grd02.AddMerge(0, 1, "OPT02_DESC", "OPT02_DESC");
                this.grd02.AddMerge(0, 1, "OPT03_DESC", "OPT03_DESC");
                this.grd02.AddMerge(0, 1, "OPT04_DESC", "OPT04_DESC");
                this.grd02.AddMerge(0, 1, "OPT05_DESC", "OPT05_DESC");
                this.grd02.AddMerge(0, 1, "OPT06_DESC", "OPT06_DESC");
                this.grd02.AddMerge(0, 1, "OPT07_DESC", "OPT07_DESC");
                this.grd02.AddMerge(0, 1, "OPT08_DESC", "OPT08_DESC");
                this.grd02.AddMerge(0, 1, "OPT09_DESC", "OPT09_DESC");
                this.grd02.AddMerge(0, 1, "OPT10_DESC", "OPT10_DESC");
                this.grd02.AddMerge(0, 1, "OPT11_DESC", "OPT11_DESC");
                this.grd02.AddMerge(0, 1, "OPT12_DESC", "OPT12_DESC");
                this.grd02.AddMerge(0, 1, "OPT13_DESC", "OPT13_DESC");
                this.grd02.AddMerge(0, 1, "OPT14_DESC", "OPT14_DESC");
                this.grd02.AddMerge(0, 1, "OPT15_DESC", "OPT15_DESC");
                this.grd02.AddMerge(0, 1, "OPT16_DESC", "OPT16_DESC");
                this.grd02.AddMerge(0, 1, "OPT17_DESC", "OPT17_DESC");
                this.grd02.AddMerge(0, 1, "OPT18_DESC", "OPT18_DESC");
                this.grd02.AddMerge(0, 1, "OPT19_DESC", "OPT19_DESC");
                this.grd02.AddMerge(0, 1, "OPT20_DESC", "OPT20_DESC");
                //this.grd02.AddMerge(0, 1, "OPT21_DESC", "OPT21_DESC");
                //this.grd02.AddMerge(0, 1, "OPT22_DESC", "OPT22_DESC");
                //this.grd02.AddMerge(0, 1, "OPT23_DESC", "OPT23_DESC");
                //this.grd02.AddMerge(0, 1, "OPT24_DESC", "OPT24_DESC");
                //this.grd02.AddMerge(0, 1, "OPT25_DESC", "OPT25_DESC");
                //this.grd02.AddMerge(0, 1, "OPT26_DESC", "OPT26_DESC");
                //this.grd02.AddMerge(0, 1, "OPT27_DESC", "OPT27_DESC");
                //this.grd02.AddMerge(0, 1, "OPT28_DESC", "OPT28_DESC");
                //this.grd02.AddMerge(0, 1, "OPT29_DESC", "OPT29_DESC");
                //this.grd02.AddMerge(0, 1, "OPT30_DESC", "OPT30_DESC");

                this.grd02.AddMerge(0, 0, "DDAY_QTY", "D6DAY_QTY");
                this.grd02.SetHeadTitle(0, "DDAY_QTY", "OUR PLAN (" + this.dte01_PLAN_DATE.GetDateText() + ")");
                #endregion


                this.grd03.Initialize();
                this.grd03.AllowEditing = false;

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "P/DATE", "PLAN_DATE", "PLAN_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "CAR", "VINCD", "VINCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PGN", "PGN", "PGN");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PAC", "PAC", "PAC");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO", "PARTNO", "PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "PART NAME", "PARTNM", "PARTNM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "P/QTY", "PLAN_QTY", "PLAN_QTY");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "OUR-STOCK", "STOCK_QTY", "STOCK_QTY");


                this.grd04.Initialize();
                this.grd04.AllowEditing = false;



                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PGN", "PGN", "PGN");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "PAC", "PAC", "PAC");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO", "PARTNO", "PARTNO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "ITEM NAME", "PGNDESC", "PGNDESC");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "P/QTY", "PLAN_QTY", "PLAN_QTY");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "S/QTY", "RSLT_QTY", "RSLT_QTY");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "DIFF", "DIFF", "DIFF");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "RATE(%)", "RATE", "RATE");

                tabControl1.SelectedIndex = 2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt01_PAC.Initialize();
                this.txt01_PGN.Initialize();
                this.txt01_PARTNO.Initialize();
                this.dte01_PLAN_DATE.Initialize();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PLAN_DATE", this.dte01_PLAN_DATE.GetDateText());
                set.Add("PGN", this.txt01_PGN.GetValue().ToString());
                set.Add("PAC", this.txt01_PAC.GetValue().ToString());
                set.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());

                this.BeforeInvokeServer(true);
                if(tabControl1.SelectedIndex == 0)
                {
                    DataSet source1 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CUST"), set);
                    grd01.SetValue(source1);
                    this.grd01.SetHeadTitle(0, "DDAY_QTY", "KMI PLAN (" + this.dte01_PLAN_DATE.GetDateText() + ")");   //출고
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    DataSet source2 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_OUR"), set);
                    grd02.SetValue(source2);
                    this.grd02.SetHeadTitle(0, "DDAY_QTY", "OUR PLAN (" + this.dte01_PLAN_DATE.GetDateText() + ")");   //출고
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    DataSet source3 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_OMIS"), set);
                    grd03.SetValue(source3);
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    DataSet source4 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DIFF"), set);
                    grd04.SetValue(source4);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        #endregion

        #region [ 기타 컨트롤들에 대한 이벤트 정의 ]
        #endregion

        #region [ 사용자 정의 메서드 ]
        #endregion
    }
}
