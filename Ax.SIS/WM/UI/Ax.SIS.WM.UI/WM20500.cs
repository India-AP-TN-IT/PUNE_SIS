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

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// FIFO 위반 이력 조회 
    /// </summary>
    public partial class WM20500 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public WM20500()
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

                //제품
                this.cbo01_PRDT_DIV.DataBind("A0");
                this.cbo01_PRDT_DIV.SelectedItem = 0;

                this.cbo01_DOM_IMP_DIV.DataBind("EK", true);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "Business", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Standard Date", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "Working Time", "WORK_TIME", "WORK_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Lot NO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "Seq NO", "SEQNO", "SEQNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part no", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 210, "Part name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 130, "Inventory Status", "INV_STATUS", "INV_STATUS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Product div", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Qty", "QTY", "QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "USER ID", "USER_ID", "USER_ID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "USER NAME", "NAME_ENG", "NAME_ENG");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "STD_DATE");
                this.grd01.Cols["STD_DATE"].Format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                    this.grd01.Cols[i].AllowMerging = true;
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
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("ST_DATE", dtp01_PROD_SDATE.GetDateText());
                set.Add("ED_DATE", dtp01_PROD_EDATE.GetDateText());
                set.Add("PRDT_DIV", cbo01_PRDT_DIV.GetValue());
                set.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20500.INQUERY", set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
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

    }
}
