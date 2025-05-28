using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;

using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 조회 
    /// </summary>
    public partial class XM39030 : AxCommonBaseControl
    {
        #region [Initialize]
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public XM39030()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;


                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));




                DataSet source = this.GetTypeCode("1F");
                source.Tables[0].DefaultView.RowFilter = "OBJECT_ID IN ('1F3000','1F3001','1F3100','1F7920','1F7900')"; //평가클래스, 1F3000 원자재, 1F3001 부자재, 1F3100 상품, 1F7920 완제품, 1F7900 반제품

                this.cbo01_ESTI_CLASS.DataBind(source.Tables[0].DefaultView.ToTable().Copy());

                #endregion

                //this.SetRequired(lbl01_VENDCD);
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);


                #region grd01
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Product Group", "PRDT_TYPE", "XM39030_PRDT_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "W/Center", "LINECD", "XM39030_LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "W/Center Name", "LINENM", "XM39030_LINENM");


                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "Vendor", "VENDCD", "XM39030_VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Vendor Name", "VENDNM", "XM39030_VENDNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UNIT", "UNIT_NAME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "SAP BASE STOCK", "STOCK_QTY", "SAP_BASE_STOCK");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D0", "D0", "D0");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D0", "D0_DIFF", "D0_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D1", "D1", "D1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D1", "D1_DIFF", "D1_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D2", "D2", "D2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D2", "D2_DIFF", "D2_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D3", "D3", "D3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D3", "D3_DIFF", "D3_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D4", "D4", "D4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D4", "D4_DIFF", "D4_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D5", "D5", "D5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D5", "D5_DIFF", "D5_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D6", "D6", "D6");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D6", "D6_DIFF", "D6_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D7", "D7", "D7");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D7", "D7_DIFF", "D7_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D8", "D8", "D8");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D8", "D8_DIFF", "D8_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D9", "D9", "D9");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D9", "D9_DIFF", "D9_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D10", "D10", "D10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D10", "D10_DIFF", "D10_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D11", "D11", "D11");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D11", "D11_DIFF", "D11_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D12", "D12", "D12");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D12", "D12_DIFF", "D12_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D13", "D13", "D13");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D13", "D13_DIFF", "D13_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D14", "D14", "D14");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D14", "D14_DIFF", "D14_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D15", "D15", "D15");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D15", "D15_DIFF", "D15_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D16", "D16", "D16");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D16", "D16_DIFF", "D16_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D17", "D17", "D17");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D17", "D17_DIFF", "D17_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D18", "D18", "D18");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D18", "D18_DIFF", "D18_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D19", "D19", "D19");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D19", "D19_DIFF", "D19_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D20", "D20", "D20");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D20", "D20_DIFF", "D20_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D21", "D21", "D21");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D21", "D21_DIFF", "D21_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D22", "D22", "D22");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D22", "D22_DIFF", "D22_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D23", "D23", "D23");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D23", "D23_DIFF", "D23_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D24", "D24", "D24");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D24", "D24_DIFF", "D24_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D25", "D25", "D25");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D25", "D25_DIFF", "D25_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D26", "D26", "D26");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D26", "D26_DIFF", "D26_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D27", "D27", "D27");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D27", "D27_DIFF", "D27_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D28", "D28", "D28");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D28", "D28_DIFF", "D28_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D29", "D29", "D29");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D29", "D29_DIFF", "D29_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D30", "D30", "D30");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D30", "D30_DIFF", "D30_DIFF");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PLAN SUM", "TOT", "XM39030_TOT");
                for (int i = 0; i < 31; i++)
                {
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D" + i.ToString());
                    this.grd01.Cols["D" + i.ToString()].Format = _IntFormat;
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "D" + i.ToString() + "_DIFF");
                    this.grd01.Cols["D" + i.ToString()].Format = _IntFormat;
                    this.grd01.Cols["D" + i.ToString() + "_DIFF"].Format = _IntFormat;
                    this.grd01.AddMerge(0, 0, "D" + i.ToString(), "D" + i.ToString() + "_DIFF");
                }
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "STOCK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT");

                this.grd01.Cols["STOCK_QTY"].Format = _IntFormat;
                this.grd01.Cols["TOT"].Format = _IntFormat;

                for (int j = 0; j < this.grd01.Cols.Count; j++)
                {
                    this.grd01.Cols[j].AllowMerging = true;
                }

                CellStyle csFWBR_MAT = grd01.Styles.Add("CS_FWBR");//Foreground:White|Background:Red
                csFWBR_MAT.BackColor = Color.Red;
                csFWBR_MAT.ForeColor = Color.White;
                #endregion

                #region grd02
                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Product Group", "PRDT_TYPE", "PRDT_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "D/TYPE", "DELI_TYPE", "XM39030_DELI_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "W/Center", "LINECD", "XM39030_LINECD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "W/Center Name", "LINENM", "XM39030_LINENM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "ALC", "ALCCD", "ALC");

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 60, "Vendor", "VENDCD", "XM39030_VENDCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 250, "Vendor Name", "VENDNM", "XM39030_VENDNM");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UNIT", "UNIT_NAME");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "SAP BASE STOCK", "STOCK_QTY", "SAP_BASE_STOCK");
                

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D0", "D0", "D0");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D0", "D0_DIFF", "D0_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D1", "D1", "D1");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D1", "D1_DIFF", "D1_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D2", "D2", "D2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D2", "D2_DIFF", "D2_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D3", "D3", "D3");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D3", "D3_DIFF", "D3_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D4", "D4", "D4");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D4", "D4_DIFF", "D4_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D5", "D5", "D5");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D5", "D5_DIFF", "D5_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D6", "D6", "D6");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D6", "D6_DIFF", "D6_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D7", "D7", "D7");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D7", "D7_DIFF", "D7_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D8", "D8", "D8");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D8", "D8_DIFF", "D8_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D9", "D9", "D9");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D9", "D9_DIFF", "D9_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D10", "D10", "D10");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D10", "D10_DIFF", "D10_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D11", "D11", "D11");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D11", "D11_DIFF", "D11_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D12", "D12", "D12");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D12", "D12_DIFF", "D12_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D13", "D13", "D13");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D13", "D13_DIFF", "D13_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D14", "D14", "D14");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D14", "D14_DIFF", "D14_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D15", "D15", "D15");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D15", "D15_DIFF", "D15_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D16", "D16", "D16");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D16", "D16_DIFF", "D16_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D17", "D17", "D17");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D17", "D17_DIFF", "D17_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D18", "D18", "D18");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D18", "D18_DIFF", "D18_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D19", "D19", "D19");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D19", "D19_DIFF", "D19_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D20", "D20", "D20");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D20", "D20_DIFF", "D20_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D21", "D21", "D21");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D21", "D21_DIFF", "D21_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D22", "D22", "D22");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D22", "D22_DIFF", "D22_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D23", "D23", "D23");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D23", "D23_DIFF", "D23_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D24", "D24", "D24");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D24", "D24_DIFF", "D24_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D25", "D25", "D25");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D25", "D25_DIFF", "D25_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D26", "D26", "D26");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D26", "D26_DIFF", "D26_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D27", "D27", "D27");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D27", "D27_DIFF", "D27_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D28", "D28", "D28");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D28", "D28_DIFF", "D28_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D29", "D29", "D29");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D29", "D29_DIFF", "D29_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D30", "D30", "D30");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D30", "D30_DIFF", "D30_DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PLAN SUM", "TOT", "XM39030_TOT");

                for (int i = 0; i < 31; i++)
                {
                    this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D" + i.ToString());
                    this.grd02.Cols["D" + i.ToString()].Format = _IntFormat;
                    this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "D" + i.ToString() + "_DIFF");
                    this.grd02.Cols["D" + i.ToString()].Format = _IntFormat;
                    this.grd02.Cols["D" + i.ToString() + "_DIFF"].Format = _IntFormat;
                    this.grd02.AddMerge(0, 0, "D" + i.ToString(), "D" + i.ToString() + "_DIFF");
                }
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "STOCK_QTY");                
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "TOT");                
                this.grd02.Cols["STOCK_QTY"].Format = _IntFormat;
                this.grd02.Cols["TOT"].Format = _IntFormat;

                for (int j = 0; j < this.grd02.Cols.Count; j++)
                {
                    this.grd02.Cols[j].AllowMerging = true;
                }

                CellStyle csFWBR_ASSY = grd02.Styles.Add("CS_FWBR");//Foreground:White|Background:Red
                csFWBR_ASSY.BackColor = Color.Red;
                csFWBR_ASSY.ForeColor = Color.White;

                #endregion

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [Common Btn Event]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
         

                if (tabControl1.SelectedIndex == 0)
                {
                    Query_Cust_Plan_Material();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    Query_Cust_Plan_ASSY();
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

       
        #endregion

        #region [Define Method]
       
        private void Query_Cust_Plan_Material()
        {
            for (int i = 0; i < 31; i++)
            {
                this.grd01.Cols["D" + i.ToString()].Caption = this.dtp01_STD_DATE.Value.AddDays(i).ToString("dd/MM");
            }
            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", this.cbo01_BIZCD.GetValue());            
            set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
            set1.Add("LANG_SET", this.UserInfo.Language);
            set1.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());            
            set1.Add("ESTI_CLASS", cbo01_ESTI_CLASS.GetValue());

            this.BeforeInvokeServer(true);

            DataSet source1 = _WSCOM.ExecuteDataSet("APG_XM39030.INQUERY_CUST", set1, "OUT_CURSOR");
            this.grd01.SetValue(source1);
            ShowDataCount(source1);

            for (int j_cnt = grd01.Rows.Fixed; j_cnt < grd01.Rows.Count; j_cnt++)
            {   // Change Cell Color
                for (int i = 0; i < 31; i++)
                {
                    float n_diff = 0;
                    string s_stock = string.Format("D{0}", i);
                    string s_diff = string.Format("D{0}_DIFF", i);
                    float.TryParse(Convert.ToString(grd01.GetValue(j_cnt, s_diff)), out n_diff);
                    if (n_diff < 0)
                    {
                        grd01.SetCellStyle(j_cnt, grd01.Cols[s_stock].Index, "CS_FWBR");
                        grd01.SetCellStyle(j_cnt, grd01.Cols[s_diff].Index, "CS_FWBR");
                    }
                }
            }

        }
        private void Query_Cust_Plan_ASSY()
        {
            for (int i = 0; i < 31; i++)
            {
                this.grd02.Cols["D" + i.ToString()].Caption = this.dtp01_STD_DATE.Value.AddDays(i).ToString("dd/MM");
            }
            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
            set1.Add("LANG_SET", this.UserInfo.Language);
            set1.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());
            set1.Add("ESTI_CLASS", cbo01_ESTI_CLASS.GetValue());
            

            //System.Diagnostics.Debug.WriteLine(cbo01_DTYPE.GetValue().ToString());
            

            this.BeforeInvokeServer(true);

            DataSet source1 = _WSCOM.ExecuteDataSet("APG_XM39030.INQUERY_ASSY", set1, "OUT_CURSOR");
            this.grd02.SetValue(source1);
            ShowDataCount(source1);

            for (int j_cnt = grd02.Rows.Fixed; j_cnt < grd02.Rows.Count; j_cnt++)
            {   // Change Cell Color
                for (int i = 0; i < 31; i++)
                {
                    float n_diff = 0;
                    string s_stock = string.Format("D{0}", i);
                    string s_diff = string.Format("D{0}_DIFF", i);
                    float.TryParse(Convert.ToString(grd02.GetValue(j_cnt, s_diff)), out n_diff);
                    if (n_diff < 0)
                    {
                        grd02.SetCellStyle(j_cnt, grd02.Cols[s_stock].Index, "CS_FWBR");
                        grd02.SetCellStyle(j_cnt, grd02.Cols[s_diff].Index, "CS_FWBR");
                    }
                }
            }
        }
        #endregion

        #region [Controls Event]
        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
          
          
        }

        
        #endregion
    }
}
