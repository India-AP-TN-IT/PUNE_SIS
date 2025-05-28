using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;

using System.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
using System.Diagnostics;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// CKD Invoice별 입하 실적 조회 
    /// </summary>
    public partial class WM40550 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const string _IntFormat = "###,###,###,###,##0";

        public WM40550()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                #region grd01

                this.grd01.AllowEditing = false;
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.Initialize(2, 2); 
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "Base Qty", "BASE_QTY", "BAS_INV_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_I0", "QTY_I0", "I0");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_I1", "QTY_I1", "I1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_I3", "QTY_I3", "I3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_M1", "QTY_M1", "M1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_O1", "QTY_O1", "O1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_O2", "QTY_O2", "O2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_O3", "QTY_O3", "O3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_O4", "QTY_O4", "O4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_O5", "QTY_O5", "O5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_O6", "QTY_O6", "O6");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_O9", "QTY_O9", "O9");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_OE", "QTY_OE", "OE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_X", "QTY_X", "X");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "QTY_XX", "QTY_XX", "XX");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "End Qty", "END_QTY", "END_INV_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "BASE_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_I0");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_I1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_I3");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_M1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_O1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_O2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_O3");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_O4");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_O5");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_O6");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_O9");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_OE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_X");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_XX");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "END_QTY");

                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd01.AddMerge(0, 1, "BASE_QTY", "BASE_QTY");
                this.grd01.AddMerge(0, 1, "END_QTY", "END_QTY");
                this.grd01.AddMerge(0, 0, "QTY_I0", "QTY_I3");
                this.grd01.AddMerge(0, 0, "QTY_M1", "QTY_XX");
                this.grd01.SetHeadTitle(1, "QTY_I0", this.GetLabel("I0"));
                this.grd01.SetHeadTitle(1, "QTY_I1", this.GetLabel("I1"));
                this.grd01.SetHeadTitle(1, "QTY_I3", this.GetLabel("I3"));
                this.grd01.SetHeadTitle(1, "QTY_M1", this.GetLabel("M1"));
                this.grd01.SetHeadTitle(1, "QTY_O1", this.GetLabel("O1"));
                this.grd01.SetHeadTitle(1, "QTY_O2", this.GetLabel("O2"));
                this.grd01.SetHeadTitle(1, "QTY_O3", this.GetLabel("O3"));
                this.grd01.SetHeadTitle(1, "QTY_O4", this.GetLabel("O4"));
                this.grd01.SetHeadTitle(1, "QTY_O5", this.GetLabel("O5"));
                this.grd01.SetHeadTitle(1, "QTY_O6", this.GetLabel("O6"));
                this.grd01.SetHeadTitle(1, "QTY_O9", this.GetLabel("O9"));
                this.grd01.SetHeadTitle(1, "QTY_OE", this.GetLabel("OE"));
                this.grd01.SetHeadTitle(1, "QTY_X", this.GetLabel("X"));
                this.grd01.SetHeadTitle(1, "QTY_XX", this.GetLabel("XX"));
                this.grd01.SetHeadTitle(0, "QTY_I0", this.GetLabel("IN"));
                this.grd01.SetHeadTitle(0, "QTY_M1", this.GetLabel("OUT"));
                
                #endregion

                this.dtp01_PROD_SDATE.SetValue(DateTime.Now);
                this.dtp01_PROD_EDATE.SetValue(DateTime.Now);

                #region initilize combo

                // bizcd
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                #endregion

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_STOCK_DATE);

                BtnQuery_Click(null, null);
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
                string bizcd = this.UserInfo.BusinessCode;
                HEParameterSet set = new HEParameterSet();


                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                set.Add("SDATE", this.dtp01_PROD_SDATE.GetDateText());
                set.Add("EDATE", this.dtp01_PROD_EDATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM40550.INQUIRY", set, "OUT_CURSOR");
                 
                this.grd01.SetValue(source); 
                this.grd01.Cols.Frozen = 2;
                this.grd01.AutoSizeCols();
                ShowDataCount(source);
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
