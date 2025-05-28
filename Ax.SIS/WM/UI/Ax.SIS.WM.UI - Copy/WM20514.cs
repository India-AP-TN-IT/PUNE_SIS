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

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 완반/자재 창고 재고 조회 
    /// </summary>
    public partial class WM20514 : AxCommonBaseControl
    {
        #region [Initialize]
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";
        private const string _DecimalFormat = "###,###,###,###,##0.00";

        public WM20514()
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

                //제품
                //this.cbo01_PRDT_DIV.DataBind("A0");
                //this.cbo01_PRDT_DIV.SelectedItem = 0;
                this.cdx01_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD"));
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "");
                this.cdx01_LINECD.SetCodePixedLength();

                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";

                this.cbo01_SHIFT.DataBind("EI", true);

                //cbo01_DTYPE.DataBind("D6", true);
                DataTable source1 = new DataTable();
                source1.Columns.Add("CODE");
                source1.Columns.Add("VALUE");
                source1.Rows.Add("1", "JIS");   //1 라인
                source1.Rows.Add("2", "JIT");   //2 라인
                cbo01_DTYPE.DataBind(source1, true);

                lbl01_DTYPE.Visible = false;
                cbo01_DTYPE.Visible = false;


                //MATERIAL / GOODS
                DataTable dt_PRODNM = new DataTable();
                dt_PRODNM.Columns.Add("CODE");
                dt_PRODNM.Columns.Add("NAME");
                dt_PRODNM.Rows.Add("MATERIAL", "MATERIAL");   //EKV
                dt_PRODNM.Rows.Add("GOODS", "GOODS");
                cbo01_PRDT_TYPE.DataBind(dt_PRODNM, true);

                #endregion

                //this.SetRequired(lbl01_VENDCD);
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);

                cbo01_PRDT_TYPE.Location = cbo01_SHIFT.Location;
                lbl01_PRDT_TYPE.Location = lbl01_SHIFT.Location;
                cbo01_DTYPE.Location = cbo01_SHIFT.Location;
                lbl01_DTYPE.Location = lbl01_SHIFT.Location;
                this.cbo01_VINCD.DataBind("A3", true);
                #region grd01

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "W/Center", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "W/Center Name", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "Vendor", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 230, "Vendor Name", "VENDNM", "VENDNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 40, "UNIT", "UNIT", "UNIT");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "REQ.QTY(A)", "REQ_QTY", "REQ_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "STOCK(B)", "STOCK_QTY", "STOCK_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "OUT.QTY(C)", "ISS_QTY", "ISS_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "DIFF.QTY(B+C-A)", "DIFF", "DIFF");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "REQ_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "STOCK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "ISS_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "DIFF");

                this.grd01.Cols["REQ_QTY"].Format = _IntFormat;
                this.grd01.Cols["STOCK_QTY"].Format = _IntFormat;
                this.grd01.Cols["ISS_QTY"].Format = _IntFormat;
                this.grd01.Cols["DIFF"].Format = _IntFormat;

                //for (int i = 0; i < grd01.Cols.Count; i++)
                //    this.grd01[1, i] = this.grd01.Cols[i].Caption;
                //전체선택 체크박스
                //CellStyle cs = this.grd01.Styles.Add("Boolean");
                //cs.DataType = typeof(Boolean);
                //cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                //this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                {
                    this.grd01.Cols[i].AllowMerging = true;
                }
                #endregion

                #region grd02
                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "Product Group", "PRDT_TYPE", "PRDT_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "W/Center", "LINECD", "LINECD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "W/Center Name", "LINENM", "LINENM");


                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "Vendor", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Vendor Name", "VENDNM", "VENDNM");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part name", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UNIT", "UNIT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "BASE STOCK", "STOCK_QTY", "SAP_BASE_STOCK");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Production done", "PRODUCTION_DONE", "PRODUCTION_DONE");

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

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PLAN SUM", "TOT", "TOT");
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

                CellStyle csFWBR_MAT = grd02.Styles.Add("CS_FWBR");//Foreground:White|Background:Red
                csFWBR_MAT.BackColor = Color.Red;
                csFWBR_MAT.ForeColor = Color.White;
                #endregion

                #region grd03
                this.grd03.AllowEditing = true;
                this.grd03.Initialize();
                //this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Product Group", "PRDT_TYPE", "PRDT_TYPE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "D/TYPE", "DELI_TYPE", "DELI_TYPE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "W/Center", "LINECD", "LINECD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "W/Center Name", "LINENM", "LINENM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "ALC", "ALCCD", "ALCCD");

                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 60, "Vendor", "VENDCD", "VENDCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 250, "Vendor Name", "VENDNM", "VENDNM");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part name", "PARTNM", "PARTNM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "UNIT", "UNIT", "UNIT");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "BASE STOCK", "STOCK_QTY", "SAP_BASE_STOCK");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "KMI STOCK", "KMI_STOCK", "KMI_STOCK");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "ISSUE", "ISS_QTY", "ISS_QTY");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D0", "D0", "D0");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D0", "D0_DIFF", "D0_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D1", "D1", "D1");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D1", "D1_DIFF", "D1_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D2", "D2", "D2");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D2", "D2_DIFF", "D2_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D3", "D3", "D3");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D3", "D3_DIFF", "D3_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D4", "D4", "D4");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D4", "D4_DIFF", "D4_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D5", "D5", "D5");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D5", "D5_DIFF", "D5_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D6", "D6", "D6");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D6", "D6_DIFF", "D6_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D7", "D7", "D7");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D7", "D7_DIFF", "D7_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D8", "D8", "D8");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D8", "D8_DIFF", "D8_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D9", "D9", "D9");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D9", "D9_DIFF", "D9_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D10", "D10", "D10");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D10", "D10_DIFF", "D10_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D11", "D11", "D11");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D11", "D11_DIFF", "D11_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D12", "D12", "D12");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D12", "D12_DIFF", "D12_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D13", "D13", "D13");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D13", "D13_DIFF", "D13_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D14", "D14", "D14");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D14", "D14_DIFF", "D14_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D15", "D15", "D15");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D15", "D15_DIFF", "D15_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D16", "D16", "D16");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D16", "D16_DIFF", "D16_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D17", "D17", "D17");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D17", "D17_DIFF", "D17_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D18", "D18", "D18");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D18", "D18_DIFF", "D18_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D19", "D19", "D19");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D19", "D19_DIFF", "D19_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D20", "D20", "D20");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D20", "D20_DIFF", "D20_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D21", "D21", "D21");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D21", "D21_DIFF", "D21_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D22", "D22", "D22");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D22", "D22_DIFF", "D22_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D23", "D23", "D23");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D23", "D23_DIFF", "D23_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D24", "D24", "D24");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D24", "D24_DIFF", "D24_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D25", "D25", "D25");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D25", "D25_DIFF", "D25_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D26", "D26", "D26");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D26", "D26_DIFF", "D26_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D27", "D27", "D27");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D27", "D27_DIFF", "D27_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D28", "D28", "D28");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D28", "D28_DIFF", "D28_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D29", "D29", "D29");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D29", "D29_DIFF", "D29_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D30", "D30", "D30");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "D30", "D30_DIFF", "D30_DIFF");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "PLAN SUM", "TOT", "TOT");

                for (int i = 0; i < 31; i++)
                {
                    this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "D" + i.ToString());
                    this.grd03.Cols["D" + i.ToString()].Format = _IntFormat;
                    this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "D" + i.ToString() + "_DIFF");
                    this.grd03.Cols["D" + i.ToString()].Format = _IntFormat;
                    this.grd03.Cols["D" + i.ToString() + "_DIFF"].Format = _IntFormat;
                    this.grd03.AddMerge(0, 0, "D" + i.ToString(), "D" + i.ToString() + "_DIFF");
                }
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "STOCK_QTY");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "ISS_QTY");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "TOT");

                this.grd03.Cols["ISS_QTY"].Format = _IntFormat;
                this.grd03.Cols["STOCK_QTY"].Format = _IntFormat;
                this.grd03.Cols["TOT"].Format = _IntFormat;

                for (int j = 0; j < this.grd03.Cols.Count; j++)
                {
                    this.grd03.Cols[j].AllowMerging = true;
                }

                CellStyle csFWBR_ASSY = grd03.Styles.Add("CS_FWBR");//Foreground:White|Background:Red
                csFWBR_ASSY.BackColor = Color.Red;
                csFWBR_ASSY.ForeColor = Color.White;

                #endregion


                tabControl1_SelectedIndexChanged(this.tabControl1, null);
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
                HEParameterSet set_plan = new HEParameterSet();
                set_plan.Add("CORCD", this.UserInfo.CorporationCode);
                set_plan.Add("BIZCD", this.UserInfo.BusinessCode);

                DataSet source_plan = _WSCOM.ExecuteDataSet("APG_WM20514.GET_PLAN_DATE", set_plan, "OUT_CURSOR");
                if (null != source_plan && null != source_plan.Tables[0] && source_plan.Tables[0].Rows.Count != 0)
                {
                    ////System.Diagnostics.Debug.WriteLine(Convert.ToString(source_plan.Tables[0].Rows[0]["PLAN_DATE"]));
                    if (!axLabel2.Visible) axLabel2.Visible = true;
                    if (!axLabel3.Visible) axLabel3.Visible = true;
                    axLabel3.Value =source_plan.Tables[0].Rows[0]["PLAN_DATE"];
                }

                if (tabControl1.SelectedIndex == 0)
                {
                    Query_Our_Plan_Material();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    Query_Cust_Plan_Material();
                }
                else if (tabControl1.SelectedIndex == 2)
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
        /*
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(checkBox1.Checked ==true)
                {
                    MsgBox.Show("WMS Stock Can not change!!");
                    return;
                }
                DataSet source = null;
                if (tabControl1.SelectedIndex == 0)
                {
                    source = grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "PARTNO", "STOCK_QTY", "USERID");
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    source = grd02.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "PARTNO", "STOCK_QTY", "USERID");
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    source = grd03.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "PARTNO", "STOCK_QTY", "USERID");
                }

                for (int i = 0; i < source.Tables[0].Rows.Count;i++ )
                {
                    source.Tables[0].Rows[i]["CORCD"] = UserInfo.CorporationCode;
                    source.Tables[0].Rows[i]["BIZCD"] = UserInfo.BusinessCode;
                    source.Tables[0].Rows[i]["USERID"] = UserInfo.UserID;
                }
                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx("APG_WM20514.SAVE", source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

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
*/
        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    DataSet copy_set = new DataSet();// ((DataSet)this.grd01.DataSource).Copy();
                    DataTable p_table = (DataTable)this.grd01.DataSource;

                    if (p_table.Rows.Count == 0) return;

                    copy_set.Tables.Add(p_table.Copy());
                    copy_set.Tables[0].TableName = "DATA";

                    if (copy_set.Tables["DATA"].Rows.Count == 0) return;

                    HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                    report.ReportName = @"RxRpt/WM20514";

                    // Main section(메인리포트 파라미터 셋)
                    HERexSection main_section = new HERexSection();
                    main_section.ReportParameter.Add("DATE", this.dtp01_STD_DATE.GetDateText());
                    report.Sections.Add("MAIN", main_section);

                    HERexSection xml_section = new HERexSection(copy_set, new HEParameterSet());
                    report.Sections.Add("XML1", xml_section);//레포트파일의 커넥션이름과동일해야함.
                    AxRexpertReportViewer.ShowReport(report);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [Define Method]
        private void Query_Our_Plan_Material()
        {
            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", this.UserInfo.BusinessCode);
            set1.Add("VENDCD", this.cdx01_VENDCD.GetValue());
            set1.Add("LINECD", cdx01_LINECD.GetValue());
            set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
            set1.Add("LANG_SET", this.UserInfo.Language);
            set1.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());
            set1.Add("WMS_STOCK_YN", checkBox1.Checked ? "Y" : "N");
            set1.Add("VINCD", cbo01_VINCD.GetValue());
            this.BeforeInvokeServer(true);

            DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20514.INQUERY", set1, "OUT_CURSOR");
            this.grd01.SetValue(source1);
            ShowDataCount(source1);
        }
        private void Query_Cust_Plan_Material()
        {
            for (int i = 0; i < 31; i++)
            {
                this.grd02.Cols["D" + i.ToString()].Caption = this.dtp01_STD_DATE.Value.AddDays(i).ToString("dd/MM");
            }
            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", this.UserInfo.BusinessCode);
            set1.Add("VENDCD", this.cdx01_VENDCD.GetValue());
            set1.Add("LINECD", cdx01_LINECD.GetValue());
            set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
            set1.Add("LANG_SET", this.UserInfo.Language);
            set1.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());
            set1.Add("WMS_STOCK_YN", checkBox1.Checked ? "Y" : "N");
            set1.Add("PRDT_TYPE", cbo01_PRDT_TYPE.GetValue());
            set1.Add("VINCD", cbo01_VINCD.GetValue());
            this.BeforeInvokeServer(true);

            DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20514.INQUERY_CUST", set1, "OUT_CURSOR");
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
        private void Query_Cust_Plan_ASSY()
        {
            for (int i = 0; i < 31; i++)
            {
                this.grd03.Cols["D" + i.ToString()].Caption = this.dtp01_STD_DATE.Value.AddDays(i).ToString("dd/MM");
            }
            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", this.UserInfo.BusinessCode);
            set1.Add("VENDCD", this.cdx01_VENDCD.GetValue());
            set1.Add("LINECD", cdx01_LINECD.GetValue());
            set1.Add("PARTNO", this.txt01_PARTNO.GetValue());
            set1.Add("LANG_SET", this.UserInfo.Language);
            set1.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());
            System.Diagnostics.Debug.WriteLine(cbo01_DTYPE.GetValue().ToString());
            set1.Add("DTYPE", cbo01_DTYPE.GetText());
            set1.Add("WMS_STOCK_YN", checkBox1.Checked ? "Y" : "N");
            set1.Add("VINCD", cbo01_VINCD.GetValue());
            

            this.BeforeInvokeServer(true);

            DataSet source1 = _WSCOM.ExecuteDataSet("APG_WM20514.INQUERY_ASSY", set1, "OUT_CURSOR");
            this.grd03.SetValue(source1);
            ShowDataCount(source1);

            for (int j_cnt = grd03.Rows.Fixed; j_cnt < grd03.Rows.Count; j_cnt++)
            {   // Change Cell Color
                for (int i = 0; i < 31; i++)
                {
                    float n_diff = 0;
                    string s_stock = string.Format("D{0}", i);
                    string s_diff = string.Format("D{0}_DIFF", i);
                    float.TryParse(Convert.ToString(grd03.GetValue(j_cnt, s_diff)), out n_diff);
                    if (n_diff < 0)
                    {
                        grd03.SetCellStyle(j_cnt, grd03.Cols[s_stock].Index, "CS_FWBR");
                        grd03.SetCellStyle(j_cnt, grd03.Cols[s_diff].Index, "CS_FWBR");
                    }
                }
            }
        }
        #endregion

        #region [Controls Event]
        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bizcd = this.cbo01_BIZCD.GetValue().ToString();

            HEParameterSet set1 = new HEParameterSet();
            set1.Add("CORCD", this.UserInfo.CorporationCode);
            set1.Add("BIZCD", bizcd);

            DataTable source1 = _WSCOM.ExecuteDataSet("APG_WM20510.INQUIRY_COMBO_WHCD", set1, "OUT_CURSOR").Tables[0];

            //this.cbo01_WHCD.DataBind(source1, false);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl obj_tab = sender as TabControl;

            cbo01_SHIFT.Visible = false;
            lbl01_SHIFT.Visible = false;
            cbo01_DTYPE.Visible = false;
            lbl01_DTYPE.Visible = false;
            cbo01_PRDT_TYPE.Visible = false;
            lbl01_PRDT_TYPE.Visible = false;

           
            if (obj_tab.SelectedIndex == 1)
            {
                cbo01_PRDT_TYPE.Visible = true;
                lbl01_PRDT_TYPE.Visible = true;
            }
            if (obj_tab.SelectedIndex == 2)
            {
                cbo01_DTYPE.Visible = true;
                lbl01_DTYPE.Visible = true;
            }
        }
        #endregion
    }
}
